using Aspose.Words;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static 谦海数据解析系统.JJmodel.TagInfo;

namespace 谦海数据解析系统.JJmodel
{
    /// <summary>
    /// 该类用于解析word文档，在实例化的同时，将文档解析为标准段，标准句，索引句
    /// 
    /// </summary>
    public class JJDocument
    {
        Aspose.Words.Document _doc = null;
        /// <summary>
        /// 文档文件名
        /// </summary>
        public string _fileName = string.Empty;
        /// <summary>
        /// 信息库名
        /// </summary>
        public string _infoDBName = string.Empty;


        /// <summary>
        /// 内容信息库名称
        /// </summary>
        public string _neirongDBName = string.Empty;
        /// <summary>
        /// 基础分类
        /// </summary>
        public string _baseType = string.Empty;
        /// <summary>
        /// 权威性
        /// </summary>
        public string _authority = string.Empty;
        /// <summary>
        /// 脚尾注
        /// </summary>
        public string _footer = string.Empty;
        /// <summary>
        /// 作者
        /// </summary>
        public string _author = string.Empty;
        /// <summary>
        /// 来源
        /// </summary>
        public string _original = string.Empty;
        /// <summary>
        /// 日期
        /// </summary>
        public string _date = string.Empty;
        /// <summary>
        /// 基础解析格式名称
        /// </summary>
        public string _formatName = string.Empty;
        public FormatInfo _baseFormatInfo = new FormatInfo();
        /// <summary>
        /// 内容解析格式名称
        /// </summary>
        public string _contentFormat = string.Empty;
        public FormatInfo _contentFormatInfo = new FormatInfo();
        /// <summary>
        /// 用于内容解析的所有标签信息，可以在构造函数时取得
        /// </summary>
        public List<TagInfo> list_tag = new List<TagInfo>();


        /// <summary>
        /// 标准段（子级是标准句，孙子级索引句）
        /// </summary>
        List<JJParagraph> _paragraphs = new List<JJParagraph>();
        public JJDocument() { }
        public JJDocument(string filename)
        {
            _fileName = filename;
            _doc = new Aspose.Words.Document(_fileName);
            //解析基础分类，权威性。脚尾注，作者 ，来源  日期
            List<string> list_str = Regex.Split(Path.GetFileNameWithoutExtension(_fileName), @"\.").ToList();
            for (int j = 0; j < list_str.Count; j++)
            {
                if (Regex.IsMatch(list_str[j], @"\d星"))
                {
                    list_str[j] = $"{list_str[j - 1] }.{list_str[j]}";
                    list_str.RemoveAt(j - 1);
                    break;
                }

            }
            _baseType = list_str[0];
            _authority = list_str[1];
            _author = list_str[2];
            //开始提取来源
            for (int i = 0; i < list_str.Count; i++)
            {
                bool b1 = Regex.IsMatch(list_str[i], @"\[M\]");
                bool b2 = Regex.IsMatch(list_str[i], @"\[[NJ]\]");
                bool b3 = Regex.IsMatch(list_str[i], @"来源于");
                bool b4 = Regex.IsMatch(list_str[i], @"来源");

                bool b5 = Regex.IsMatch(list_str[i], @"源自");

                if (b1)
                {
                    _original = Regex.Replace(list_str[i], @"\[M\]", "");
                }
                else if (b2)
                {
                    _original = list_str[i + 1];
                }
                else if (b3)
                {
                    _original = Regex.Replace(list_str[i], @"来源于", "");

                }
                else if (b4)
                {
                    _original = Regex.Replace(list_str[i], @"来源", "");

                }
                else if (b5)
                {
                    _original = Regex.Replace(list_str[i], @"源自", "");
                }


            }
            //开始提取日期
            if (Regex.IsMatch(_fileName, @"\d{2,4}年"))
            {
                _date = Regex.Match(_fileName, @"\d{2,4}年").Value;
            }
            if (Regex.IsMatch(_fileName, @"\d{2,4}年\d{1,2}月"))
            {
                _date = Regex.Match(_fileName, @"\d{2,4}年\d{1,2}月").Value;
            }
            if (Regex.IsMatch(_fileName, @"\d{2,4}年\d{1,2}月\d{1,2}日"))
            {
                _date = Regex.Match(_fileName, @"\d{2,4}年\d{1,2}月\d{1,2}日").Value;
            }
            //解析文章，得到 段，句，索引句集合
            foreach (Section sec in _doc.Sections)
            {
                for (int i = 0; i < sec.Body.Paragraphs.Count; i++)
                {
                    var para = sec.Body.Paragraphs[i];
                    var aglin = para.ParagraphFormat.Alignment;
                    string text = para.Range.Text.Trim();
                    if (!text.Equals(string.Empty))//如果段落内容不为0，那么进入段落集合，并拆分段落成为标准句
                    {
                        //开始结构化每一个标准段，以及它的标准句，直到索引句
                        JJParagraph jjp = new JJParagraph()
                        {
                            _text = text,
                            _index = i,
                            _parent = this,
                            _aglignment = para.ParagraphFormat.Alignment
                        };
                        //将text分解成标准句
                        var list = Regex.Matches(jjp._text, @".+?(?=[。！?:……])");
                        for (int j = 0; j < list.Count; j++)
                        {

                            JJSentence jjs = new JJSentence()
                            {
                                _text = Regex.Replace(list[j].Value, "。", ""),//为了防止标准句中带有句号，用正则替换掉
                                _index = j,
                                _parent = jjp
                            };
                            //将标准句的text拆分成索引句，先以逗号分割，再进入下一层以顿号分割
                            List<string> list0 = Regex.Split(jjs._text, "[,，]").ToList();
                            for (int k = 0; k < list0.Count; k++)
                            {
                                JJIndexSentence jjis = new JJIndexSentence()
                                {
                                    _text = list0[k],
                                    _parent = jjs,
                                    _index = k
                                };
                                //如果句子内含有顿号，用顿号分割每一个以逗号结尾的索引句
                                if (jjis._text.Contains("、"))
                                {
                                    var list1 = Regex.Split(jjis._text, "、").ToList();
                                    for (int m = 0; m < list1.Count; m++)
                                    {
                                        JJIndexSentence jjis1 = new JJIndexSentence()
                                        {
                                            _text = list1[m],
                                            _parent = jjs,
                                            _index = m
                                        };
                                        jjs._indexSentences.Add(jjis1);
                                    }

                                }
                                jjs._indexSentences.Add(jjis);
                            }
                            jjp._sentences.Add(jjs);
                        }
                        _paragraphs.Add(jjp);
                    }
                }
            }
            //获得所有的内容解析标签信息集合，获得内容格式信息（包含保存路径)
            _contentFormatInfo._formatName = SystemInfo._userInfo._nrjx;
            _contentFormatInfo.GetFormatInfo();
            GetTagInfos();
            //获得所有的基础解析标签信息
            _baseFormatInfo._formatName = SystemInfo._userInfo._jcjx;
            _baseFormatInfo.GetFormatInfo();
        }




        /// <summary>
        /// 获得文档的内容解析标签信息
        /// </summary>
        public void GetTagInfos()
        {
            //获得当前所选内容解析格式下的设置，将所选中的库名
            string str_sql = $"select * from 数据解析库.格式信息表 " +
                $"where 格式类型='内容解析' and 格式名称='{SystemInfo._userInfo._nrjx}' " +
                $"and 删除=0";
            DataRow mydr = MySqlHelper.ExecuteDataRow(SystemInfo._strConn, str_sql);
            string dbname = Regex.Split(mydr["格式设置"].ToString(), @"\|")[0];

            str_sql = $"select * from 数据解析库.内容标签表 " +
                    $"where 删除=0 and 库名='{dbname}' and 级别>1";



            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            foreach (DataRow item in mydt.Rows)
            {
                TagInfo tagInfo = new TagInfo();
                tagInfo._kuming = item["库名"].ToString();
                tagInfo._mingcheng = item["名称"].ToString();
                tagInfo._jibie = Convert.ToInt32(item["级别"].ToString());
                tagInfo._biaoqianSet = item["设置"].ToString();
                tagInfo._chuangjianren = item["创建人"].ToString();
                tagInfo._chuangjianshijian = item["创建时间"].ToString();
                tagInfo._tagRoot = JsonConvert.DeserializeObject<TagRoot>(tagInfo._biaoqianSet);
                list_tag.Add(tagInfo);
            }
        }

        /// <summary>
        /// 获得副标题段落集合
        /// </summary>
        /// <returns></returns>
        public List<JJParagraph> GetFubiaoti()
        {
            List<JJParagraph> list = new List<JJParagraph>();
            bool b = false;//记录是否已经找到主标题
            foreach (var item in _paragraphs)
            {
                if (!b && item._aglignment == ParagraphAlignment.Center)
                {
                    b = true;

                }
                else if (b && item._aglignment == ParagraphAlignment.Center)
                {
                    list.Add(item);
                    break;
                }
            }
            foreach (var item in _paragraphs)
            {
                bool b1 = Regex.IsMatch(item._text, @"^第.节.*");
                bool b2 = Regex.IsMatch(item._text, @"^目录.*");
                bool b3 = Regex.IsMatch(item._text, @"^前言.*");
                if (b1 || b2 || b3)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 获得主标题段落集合
        /// </summary>
        /// <returns></returns>
        public List<JJParagraph> GetZhubiaoti()
        {
            List<JJParagraph> list = new List<JJParagraph>();
            foreach (var item in _paragraphs)
            {
                if (item._aglignment == ParagraphAlignment.Center)
                {
                    list.Add(item);
                    break;
                }
            }
            foreach (var item in _paragraphs)
            {
                bool b = Regex.IsMatch(item._text, @"^第.[章编].*");
                if (b)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 获得正文段落
        /// </summary>
        /// <returns></returns>
        public List<JJParagraph> GetZhengwen()
        {
            List<JJParagraph> result = new List<JJParagraph>();
            List<JJParagraph> list_zhubiaoti = GetZhubiaoti();
            List<JJParagraph> list_fubiaoti = GetFubiaoti();
            foreach (JJParagraph item in _paragraphs)
            {
                if (!list_zhubiaoti.Contains(item) && !list_fubiaoti.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }


        /// <summary>
        /// 获得所有一级标题集合
        /// </summary>
        /// <returns></returns>
        public List<JJParagraph> GetYijibiaoti()
        {
            List<JJParagraph> list = new List<JJParagraph>();
            foreach (JJParagraph item in _paragraphs)
            {
                bool b1 = Regex.IsMatch(item._text, @"^[一二三四五六七八九十]、.*");
                bool b2 = Regex.IsMatch(item._text, @".*[。？?！!：:；;……]$");
                bool b3 = item._text.Contains("。");
                if (b1 && !b2 && !b3)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 获得所有二级标题集合
        /// </summary>
        /// <returns></returns>
        public List<JJParagraph> GetErjibiaoti()
        {
            List<JJParagraph> list = new List<JJParagraph>();
            foreach (JJParagraph item in _paragraphs)
            {
                bool b1 = Regex.IsMatch(item._text, @"^[一二三四五六七八九十]、.*");
                bool b2 = Regex.IsMatch(item._text, @".*[。；;]$");
                if (b1 && b2)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 获得所有三级标题集合
        /// </summary>
        /// <returns></returns>
        public List<JJParagraph> GetSanjibiaoti()
        {
            List<JJParagraph> list = new List<JJParagraph>();
            foreach (JJParagraph item in _paragraphs)
            {
                bool b1 = Regex.IsMatch(item._text, @"^[一二三四五六七八九十]+?是要.*$");
                bool b2 = Regex.IsMatch(item._text, @"^第[一二三四五六七八九十].*$");
                bool b3 = Regex.IsMatch(item._text, @"^首先.*$");
                bool b4 = Regex.IsMatch(item._text, @"^其次.*$");
                bool b5 = Regex.IsMatch(item._text, @"^（\d{0，2}）.*$");
                bool b6 = Regex.IsMatch(item._text, @"^[①②③④⑤⑥⑦⑧⑨⑩].*$");
                bool b7 = Regex.IsMatch(item._text, @"^第[一二三四五六七八九十]+?条.*$");
                bool b8 = Regex.IsMatch(item._text, @"^第[一二三四五六七八九十]+?条第[一二三四五六七八九十]+?款.*$");
                bool b9 = Regex.IsMatch(item._text, @"^第[一二三四五六七八九十]+?条第[一二三四五六七八九十]+?款第[一二三四五六七八九十]+?项.*$");
                if (b1 || b2 || b3 || b4 || b5 || b6 || b7 || b8 || b9)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 获得普通标准句集合
        /// </summary>
        /// <returns></returns>
        public List<JJSentence> GetPutongbiaozhunju()
        {
            List<JJSentence> list = new List<JJSentence>();
            //判断标准句在所在段中的索引，如果index!=0，就是普通索引据
            foreach (JJParagraph jjp in _paragraphs)
            {
                foreach (JJSentence jjs in jjp._sentences)
                {
                    if (jjs._index != 0)
                    {
                        list.Add(jjs);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 普通索引句
        /// </summary>
        /// <returns></returns>
        public List<JJIndexSentence> GetPutongsuoyinju()
        {
            List<JJIndexSentence> list = new List<JJIndexSentence>();
            var list_zhubiaoti = GetZhubiaoti();
            var list_yijibiaoti = GetYijibiaoti();
            var list_erjibiaoti = GetErjibiaoti();
            var list_sanjibiaoti = GetSanjibiaoti();
            var list_fubiaoti = GetFubiaoti();
            //排除主标题段落，排除副标题段，一二三级标题段,以及第一个标准段
            for (int i = 1; i < _paragraphs.Count; i++)
            {

                var item = _paragraphs[i];
                bool b1 = list_zhubiaoti.Contains(item);
                bool b2 = list_fubiaoti.Contains(item);
                bool b3 = list_yijibiaoti.Contains(item);
                bool b4 = list_erjibiaoti.Contains(item);
                bool b5 = list_sanjibiaoti.Contains(item);
                if (!b1 && !b2 && !b3 && !b4 && !b5)
                {
                    //循环每一个标准句，第一句除外
                    for (int j = 0; j < item._sentences.Count; j++)
                    {
                        list.AddRange(item._sentences[j]._indexSentences);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 获得基础解析信息集合
        /// </summary>
        /// <returns></returns>
        public List<JcjxInfo> GetBaseAnalysis()
        {
            List<JcjxInfo> list = new List<JcjxInfo>();
            JcjxInfo jji = new JcjxInfo();

            //获得一级标题纲要
            var list_zhubiaoti = GetZhubiaoti();
            var list_yijibiaoti = GetYijibiaoti();
            var list_erjibiaoti = GetErjibiaoti();
            var list_sanjibiaoti = GetSanjibiaoti();
            var list_fubiaoti = GetFubiaoti();
            var list_zhengwen = GetZhengwen();
            var list_putongbiaozhunju = GetPutongbiaozhunju();
            var list_putongsuoyinju = GetPutongsuoyinju();
            //获得主标题info
            for (int i = 0; i < list_zhubiaoti.Count; i++)
            {
                var item = list_zhubiaoti[i];
                jji = new JcjxInfo();
                jji._nameType = "主标题";
                jji._nodeText = item._text;
                jji._nodeMD5 = Md5Helper.Md5(item._text);
                jji._length = item._text.Length;
                jji._hot = 1;
                jji._infodbName = _infoDBName;
                jji._baseType = _baseType;
                jji._authority = _authority;
                jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                jji._firstTitle = list_zhubiaoti[0]._text;
                jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                jji._footer = _footer;
                jji._author = _author;
                jji._original = _original;
                jji._date = _date;
                //构造关联内容MD5
                string str = string.Empty;
                try
                {
                    str = $"{string.Join("\r", list_yijibiaoti)}{string.Join("\r", list_fubiaoti)}{list_zhengwen[0]._sentences[0]._text}";

                }
                catch { }
                jji._positionTextMD5 = Md5Helper.Md5(str);
                //构造所在标准段MD5
                //jji._paraMD5 = Md5Helper.Md5(item._text);
                list.Add(jji);
            }
            //副标题
            for (int i = 0; i < list_fubiaoti.Count; i++)
            {
                var item = list_fubiaoti[i];
                jji = new JcjxInfo();
                jji._nameType = "副标题";
                jji._nodeText = item._text;
                jji._nodeMD5 = Md5Helper.Md5(item._text);
                jji._length = item._text.Length;
                jji._hot = 1;
                jji._infodbName = _infoDBName;
                jji._baseType = _baseType;
                jji._authority = _authority;
                jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                jji._firstTitle = list_zhubiaoti[0]._text;
                jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                jji._footer = _footer;
                jji._author = _author;
                jji._original = _original;
                jji._date = _date;
                //构造关联内容MD5
                string str = string.Empty;
                try
                {
                    str = $"{string.Join("\r", list_yijibiaoti)}{list_zhengwen[0]._sentences[0]._text}";

                }
                catch { }
                jji._positionTextMD5 = Md5Helper.Md5(str);
                //构造所在标准段MD5
                // jji._paraMD5 = Md5Helper.Md5(item._text);
                list.Add(jji);
            }
            //正文
            jji = new JcjxInfo();
            jji._nameType = "正文";
            jji._nodeText = string.Join("\r", list_zhengwen);
            jji._nodeMD5 = Md5Helper.Md5(jji._nodeText);
            jji._length = jji._nodeText.Length;
            jji._hot = 1;
            jji._infodbName = _infoDBName;
            jji._baseType = _baseType;
            jji._authority = _authority;
            jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
            jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
            jji._firstTitle = list_zhubiaoti[0]._text;
            jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
            jji._footer = _footer;
            jji._author = _author;
            jji._original = _original;
            jji._date = _date;
            list.Add(jji);
            //一级标题纲要
            //先判断有没有一级纲要
            if (list_yijibiaoti.Count > 0)
            {
                jji = new JcjxInfo();
                jji._nameType = "一级标题纲要";
                jji._nodeText = string.Join("\r", list_yijibiaoti);
                jji._nodeMD5 = Md5Helper.Md5(jji._nodeText);
                jji._length = jji._nodeText.Length;
                jji._hot = 1;
                jji._infodbName = _infoDBName;
                jji._baseType = _baseType;
                jji._authority = _authority;
                jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                jji._firstTitle = list_zhubiaoti[0]._text;
                jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                jji._footer = _footer;
                jji._author = _author;
                jji._original = _original;
                jji._date = _date;
                list.Add(jji);

            }
            //二级标题纲要

            if (list_erjibiaoti.Count > 0)
            {
                jji = new JcjxInfo();
                jji._nameType = "二级标题纲要";
                jji._nodeText = string.Join("\r", list_erjibiaoti);
                jji._nodeMD5 = Md5Helper.Md5(jji._nodeText);
                jji._length = jji._nodeText.Length;
                jji._hot = 1;
                jji._infodbName = _infoDBName;
                jji._baseType = _baseType;
                jji._authority = _authority;
                jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                jji._firstTitle = list_zhubiaoti[0]._text;
                jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                jji._footer = _footer;
                jji._author = _author;
                jji._original = _original;
                jji._date = _date;
                list.Add(jji);

            }

            //三级标题纲要
            if (list_sanjibiaoti.Count > 0)
            {
                jji = new JcjxInfo();
                jji._nameType = "三级标题纲要";
                jji._nodeText = string.Join("\r", list_sanjibiaoti);
                jji._nodeMD5 = Md5Helper.Md5(jji._nodeText);
                jji._length = jji._nodeText.Length;
                jji._hot = 1;
                jji._infodbName = _infoDBName;
                jji._baseType = _baseType;
                jji._authority = _authority;
                jji._fileName = Path.GetFileNameWithoutExtension(_fileName); ;
                jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                jji._firstTitle = list_zhubiaoti[0]._text;
                jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                jji._footer = _footer;
                jji._author = _author;
                jji._original = _original;
                jji._date = _date;
                list.Add(jji);
            }
            //标准段
            for (int i = 0; i < _paragraphs.Count; i++)
            {
                var item = _paragraphs[i];
                jji = new JcjxInfo();
                jji._nameType = "标准段";
                jji._nodeText = item._text;
                jji._nodeMD5 = Md5Helper.Md5(item._text);
                jji._length = item._text.Length;
                jji._hot = 1;
                jji._infodbName = _infoDBName;
                jji._baseType = _baseType;
                jji._authority = _authority;
                jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                jji._firstTitle = list_zhubiaoti[0]._text;
                jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                jji._footer = _footer;
                jji._author = _author;
                jji._original = _original;
                jji._date = _date;
                //构造关联内容MD5
                string str = string.Empty;
                if (i < _paragraphs.Count - 1)
                {
                    str = _paragraphs[i + 1]._text;
                }
                jji._positionTextMD5 = Md5Helper.Md5(str);
                //构造所在标准段MD5
                // jji._paraMD5 = Md5Helper.Md5(item._text);
                list.Add(jji);
            }

            //一级标题标准句
            for (int i = 0; i < list_yijibiaoti.Count; i++)
            {
                for (int j = 0; j < list_yijibiaoti[i]._sentences.Count; j++)
                {
                    var item = list_yijibiaoti[i]._sentences[j];
                    jji = new JcjxInfo();
                    jji._nameType = "一级标题标准句";
                    jji._nodeText = item._text;
                    jji._nodeMD5 = Md5Helper.Md5(item._text);
                    jji._length = item._text.Length;
                    jji._hot = 1;
                    jji._infodbName = _infoDBName;
                    jji._baseType = _baseType;
                    jji._authority = _authority;
                    jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                    jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                    jji._firstTitle = list_zhubiaoti[0]._text;
                    jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                    jji._footer = _footer;
                    jji._author = _author;
                    jji._original = _original;
                    jji._date = _date;
                    //构造关联内容MD5
                    string str = string.Empty;
                    str = $"{list_yijibiaoti[i]._sentences[j + 1]._text}{string.Join("\r", list_yijibiaoti)}{item._parent._sentences[item._index + 1]}";
                    jji._positionTextMD5 = Md5Helper.Md5(str);
                    //构造所在标准段MD5
                    jji._paraMD5 = Md5Helper.Md5(item._parent._text);
                    list.Add(jji);
                }
            }

            //二级标题标准句
            for (int i = 0; i < list_erjibiaoti.Count; i++)
            {
                for (int j = 0; j < list_erjibiaoti[i]._sentences.Count; j++)
                {
                    var item = list_erjibiaoti[i]._sentences[j];
                    jji = new JcjxInfo();
                    jji._nameType = "二级标题标准句";
                    jji._nodeText = item._text;
                    jji._nodeMD5 = Md5Helper.Md5(item._text);
                    jji._length = item._text.Length;
                    jji._hot = 1;
                    jji._infodbName = _infoDBName;
                    jji._baseType = _baseType;
                    jji._authority = _authority;
                    jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                    jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                    jji._firstTitle = list_zhubiaoti[0]._text;
                    jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                    jji._footer = _footer;
                    jji._author = _author;
                    jji._original = _original;
                    jji._date = _date;
                    //构造关联内容MD5
                    string str = string.Empty;
                    try
                    {
                        str = $"{list_erjibiaoti[i]._sentences[j + 1]._text}{string.Join("\r", list_erjibiaoti)}{item._parent._sentences[item._index + 1]}";
                    }
                    catch { }
                    jji._positionTextMD5 = Md5Helper.Md5(str);
                    //构造所在标准段MD5
                    jji._paraMD5 = Md5Helper.Md5(item._parent._text);
                    list.Add(jji);
                }
            }

            //三级标题标准句
            for (int i = 0; i < list_sanjibiaoti.Count; i++)
            {
                for (int j = 0; j < list_sanjibiaoti[i]._sentences.Count; j++)
                {
                    var item = list_sanjibiaoti[i]._sentences[j];
                    jji = new JcjxInfo();
                    jji._nameType = "三级标题标准句";
                    jji._nodeText = item._text;
                    jji._nodeMD5 = Md5Helper.Md5(item._text);
                    jji._length = item._text.Length;
                    jji._hot = 1;
                    jji._infodbName = _infoDBName;
                    jji._baseType = _baseType;
                    jji._authority = _authority;
                    jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                    jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                    jji._firstTitle = list_zhubiaoti[0]._text;
                    jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                    jji._footer = _footer;
                    jji._author = _author;
                    jji._original = _original;
                    jji._date = _date;
                    //构造关联内容MD5
                    string str = string.Empty;
                    try
                    {
                        str = $"{list_sanjibiaoti[i]._sentences[j + 1]._text}{string.Join("\r", list_sanjibiaoti)}{item._parent._sentences[item._index + 1]}";

                    }
                    catch { }
                    jji._positionTextMD5 = Md5Helper.Md5(str);
                    //构造所在标准段MD5
                    jji._paraMD5 = Md5Helper.Md5(item._parent._text);
                    list.Add(jji);
                }
            }

            //普通标准句
            for (int i = 0; i < list_putongbiaozhunju.Count; i++)
            {
                var item = list_putongbiaozhunju[i];
                jji = new JcjxInfo();
                jji._nameType = "普通标准句";
                jji._nodeText = item._text;
                jji._nodeMD5 = Md5Helper.Md5(item._text);
                jji._length = item._text.Length;
                jji._hot = 1;
                jji._infodbName = _infoDBName;
                jji._baseType = _baseType;
                jji._authority = _authority;
                jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                jji._firstTitle = list_zhubiaoti[0]._text;
                jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                jji._footer = _footer;
                jji._author = _author;
                jji._original = _original;
                jji._date = _date;
                //构造关联内容MD5
                string str = string.Empty;
                try//防止index+1之后超出了索引最大值的情况
                {
                    str = $"{item._parent._sentences[item._index + 1]._text}";

                }
                catch { }
                jji._positionTextMD5 = Md5Helper.Md5(str);
                //构造所在标准段MD5
                jji._paraMD5 = Md5Helper.Md5(item._parent._text);
                list.Add(jji);
            }
            //主标题索引句
            for (int i = 0; i < list_zhubiaoti.Count; i++)
            {
                for (int j = 0; j < list_zhubiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_zhubiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_zhubiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new JcjxInfo();
                        jji._nameType = "主标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._hot = 1;
                        jji._infodbName = _infoDBName;
                        jji._baseType = _baseType;
                        jji._authority = _authority;
                        jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                        jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                        jji._firstTitle = list_zhubiaoti[0]._text;
                        jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                        jji._footer = _footer;
                        jji._author = _author;
                        jji._original = _original;
                        jji._date = _date;
                        //构造关联内容MD5
                        string str = string.Empty;
                        str = $"{list_zhubiaoti[i]._sentences[j]._indexSentences[k]._text}{string.Join("\r", list_zhubiaoti)}" +
                            $"{list_zhubiaoti[i]._sentences[j]._indexSentences[k]._text}";
                        jji._positionTextMD5 = Md5Helper.Md5(str);
                        //构造所在标准段MD5
                        jji._paraMD5 = Md5Helper.Md5(item._parent._parent._text);
                        list.Add(jji);
                    }
                }
            }
            //副标题索引句
            for (int i = 0; i < list_fubiaoti.Count; i++)
            {
                for (int j = 0; j < list_fubiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_fubiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_fubiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new JcjxInfo();
                        jji._nameType = "副标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._hot = 1;
                        jji._infodbName = _infoDBName;
                        jji._baseType = _baseType;
                        jji._authority = _authority;
                        jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                        jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                        jji._firstTitle = list_zhubiaoti[0]._text;
                        jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                        jji._footer = _footer;
                        jji._author = _author;
                        jji._original = _original;
                        jji._date = _date;
                        //构造关联内容MD5
                        string str = string.Empty;
                        str = $"{list_fubiaoti[i]._sentences[j]._indexSentences[k]._text}{string.Join("\r", list_fubiaoti)}" +
                            $"{list_fubiaoti[i]._sentences[j]._indexSentences[k]._text}";
                        jji._positionTextMD5 = Md5Helper.Md5(str);
                        //构造所在标准段MD5
                        jji._paraMD5 = Md5Helper.Md5(item._parent._parent._text);
                        list.Add(jji);
                    }
                }
            }

            //一级标题索引句
            for (int i = 0; i < list_yijibiaoti.Count; i++)
            {
                for (int j = 0; j < list_yijibiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_yijibiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_yijibiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new JcjxInfo();
                        jji._nameType = "一级标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._hot = 1;
                        jji._infodbName = _infoDBName;
                        jji._baseType = _baseType;
                        jji._authority = _authority;
                        jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                        jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                        jji._firstTitle = list_zhubiaoti[0]._text;
                        jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                        jji._footer = _footer;
                        jji._author = _author;
                        jji._original = _original;
                        jji._date = _date;
                        //构造关联内容MD5
                        string str = string.Empty;
                        str = $"{list_yijibiaoti[i]._sentences[j]._indexSentences[k]._text}{string.Join("\r", list_yijibiaoti)}" +
                            $"{list_yijibiaoti[i]._sentences[j]._indexSentences[k]._text}";
                        jji._positionTextMD5 = Md5Helper.Md5(str);
                        //构造所在标准段MD5
                        jji._paraMD5 = Md5Helper.Md5(item._parent._parent._text);
                        list.Add(jji);
                    }
                }
            }

            //二级标题索引句
            for (int i = 0; i < list_erjibiaoti.Count; i++)
            {
                for (int j = 0; j < list_erjibiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_erjibiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_erjibiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new JcjxInfo();
                        jji._nameType = "二级标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._hot = 1;
                        jji._infodbName = _infoDBName;
                        jji._baseType = _baseType;
                        jji._authority = _authority;
                        jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                        jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                        jji._firstTitle = list_zhubiaoti[0]._text;
                        jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                        jji._footer = _footer;
                        jji._author = _author;
                        jji._original = _original;
                        jji._date = _date;
                        //构造关联内容MD5
                        string str = string.Empty;
                        str = $"{list_erjibiaoti[i]._sentences[j]._indexSentences[k]._text}{string.Join("\r", list_erjibiaoti)}" +
                            $"{list_erjibiaoti[i]._sentences[j]._indexSentences[k]._text}";
                        jji._positionTextMD5 = Md5Helper.Md5(str);
                        //构造所在标准段MD5
                        jji._paraMD5 = Md5Helper.Md5(item._parent._parent._text);
                        list.Add(jji);
                    }
                }
            }

            //三级标题索引句
            for (int i = 0; i < list_sanjibiaoti.Count; i++)
            {
                for (int j = 0; j < list_sanjibiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_sanjibiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_sanjibiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new JcjxInfo();
                        jji._nameType = "三级标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._hot = 1;
                        jji._infodbName = _infoDBName;
                        jji._baseType = _baseType;
                        jji._authority = _authority;
                        jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                        jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                        jji._firstTitle = list_zhubiaoti[0]._text;
                        jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                        jji._footer = _footer;
                        jji._author = _author;
                        jji._original = _original;
                        jji._date = _date;
                        //构造关联内容MD5
                        string str = string.Empty;
                        str = $"{list_sanjibiaoti[i]._sentences[j]._indexSentences[k]._text}{string.Join("\r", list_sanjibiaoti)}" +
                            $"{list_sanjibiaoti[i]._sentences[j]._indexSentences[k]._text}";
                        jji._positionTextMD5 = Md5Helper.Md5(str);
                        //构造所在标准段MD5
                        jji._paraMD5 = Md5Helper.Md5(item._parent._parent._text);
                        list.Add(jji);
                    }
                }
            }

            //普通索引句
            for (int i = 0; i < list_putongsuoyinju.Count; i++)
            {
                var item = list_putongsuoyinju[i];
                jji = new JcjxInfo();
                jji._nameType = "普通索引句";
                jji._nodeText = item._text;
                jji._nodeMD5 = Md5Helper.Md5(item._text);
                jji._length = item._text.Length;
                jji._hot = 1;
                jji._infodbName = _infoDBName;
                jji._baseType = _baseType;
                jji._authority = _authority;
                jji._fileName = Path.GetFileNameWithoutExtension(_fileName);
                jji._fileNameMD5 = Md5Helper.Md5(jji._fileName);
                jji._firstTitle = list_zhubiaoti[0]._text;
                jji._firstTitleMD5 = Md5Helper.Md5(list_zhubiaoti[0]._text);
                jji._footer = _footer;
                jji._author = _author;
                jji._original = _original;
                jji._date = _date;
                //构造关联内容MD5
                string str = string.Empty;
                try
                {
                    str = list_putongsuoyinju[i + 1]._text;

                }
                catch { }
                jji._positionTextMD5 = Md5Helper.Md5(str);
                //构造所在标准段MD5
                jji._paraMD5 = Md5Helper.Md5(item._parent._parent._text);
                list.Add(jji);

            }
            return list;
        }


        /// <summary>
        /// 该方法用于获得内容解析信息集合
        /// </summary>
        /// <returns></returns>
        public List<NrjxInfo> GetNeirongAnalysis()
        {
            List<NrjxInfo> list = new List<NrjxInfo>();
            NrjxInfo jji = null;

            //获得一级标题纲要
            var list_zhubiaoti = GetZhubiaoti();
            var list_yijibiaoti = GetYijibiaoti();
            var list_erjibiaoti = GetErjibiaoti();
            var list_sanjibiaoti = GetSanjibiaoti();
            var list_fubiaoti = GetFubiaoti();
            var list_zhengwen = GetZhengwen();
            var list_putongbiaozhunju = GetPutongbiaozhunju();
            var list_putongsuoyinju = GetPutongsuoyinju();
            //获得主标题info
            for (int i = 0; i < list_zhubiaoti.Count; i++)
            {
                var item = list_zhubiaoti[i];
                jji = new NrjxInfo();
                jji._nodeType = "主标题";
                jji._nodeText = item._text;
                jji._nodeTextMD5 = Md5Helper.Md5(jji._nodeText);
                jji._length = item._text.Length;
                jji._tagHot = 1;
                list.Add(jji);
            }
            //副标题
            for (int i = 0; i < list_fubiaoti.Count; i++)
            {
                var item = list_fubiaoti[i];
                jji = new NrjxInfo();
                jji._nodeType = "副标题";
                jji._nodeText = item._text;
                jji._nodeTextMD5 = Md5Helper.Md5(jji._nodeText);
                jji._length = item._text.Length;
                jji._tagHot = 1;
                list.Add(jji);
            }
            //正文
            jji = new NrjxInfo();
            jji._nodeType = "正文";
            List<string> list_str = new List<string>();
            foreach (JJParagraph item in list_zhengwen)
            {
                list_str.Add(item._text);
            }
            jji._nodeText = string.Join("\r", list_str);
            jji._nodeTextMD5 = Md5Helper.Md5(jji._nodeText);
            jji._length = jji._nodeText.Length;
            jji._tagHot = 1;
            list.Add(jji);
            //一级标题纲要
            //先判断有没有一级纲要
            if (list_yijibiaoti.Count > 0)
            {
                jji = new NrjxInfo();
                jji._nodeType = "一级标题纲要";
                jji._nodeText = string.Join("\r", list_yijibiaoti);
                jji._nodeTextMD5 = Md5Helper.Md5(jji._nodeText);
                jji._length = jji._nodeText.Length;
                jji._tagHot = 1;
                list.Add(jji);
            }
            //二级标题纲要

            if (list_erjibiaoti.Count > 0)
            {
                jji = new NrjxInfo();
                jji._nodeType = "二级标题纲要";
                jji._nodeText = string.Join("\r", list_erjibiaoti);
                jji._nodeTextMD5 = Md5Helper.Md5(jji._nodeText);
                jji._length = jji._nodeText.Length;
                jji._tagHot = 1;
                list.Add(jji);
            }

            //三级标题纲要
            if (list_sanjibiaoti.Count > 0)
            {
                jji = new NrjxInfo();
                jji._nodeType = "三级标题纲要";
                jji._nodeText = string.Join("\r", list_sanjibiaoti);
                jji._nodeTextMD5 = Md5Helper.Md5(jji._nodeText);
                jji._length = jji._nodeText.Length;
                jji._tagHot = 1;
                list.Add(jji);
            }
            //标准段
            for (int i = 0; i < _paragraphs.Count; i++)
            {
                var item = _paragraphs[i];
                jji = new NrjxInfo();
                jji._nodeType = "标准段";
                jji._nodeText = item._text;
                jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                jji._length = item._text.Length;
                jji._tagHot = 1;
                list.Add(jji);
            }

            //一级标题标准句
            for (int i = 0; i < list_yijibiaoti.Count; i++)
            {
                for (int j = 0; j < list_yijibiaoti[i]._sentences.Count; j++)
                {
                    var item = list_yijibiaoti[i]._sentences[j];
                    jji = new NrjxInfo();
                    jji._nodeType = "一级标题标准句";
                    jji._nodeText = item._text;
                    jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                    jji._length = item._text.Length;
                    jji._tagHot = 1;
                    list.Add(jji);
                }
            }

            //二级标题标准句
            for (int i = 0; i < list_erjibiaoti.Count; i++)
            {
                for (int j = 0; j < list_erjibiaoti[i]._sentences.Count; j++)
                {
                    var item = list_erjibiaoti[i]._sentences[j];
                    jji = new NrjxInfo();
                    jji._nodeType = "二级标题标准句";
                    jji._nodeText = item._text;
                    jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                    jji._length = item._text.Length;
                    jji._tagHot = 1;
                    list.Add(jji);
                }
            }

            //三级标题标准句
            for (int i = 0; i < list_sanjibiaoti.Count; i++)
            {
                for (int j = 0; j < list_sanjibiaoti[i]._sentences.Count; j++)
                {
                    var item = list_sanjibiaoti[i]._sentences[j];
                    jji = new NrjxInfo();
                    jji._nodeType = "三级标题标准句";
                    jji._nodeText = item._text;
                    jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                    jji._length = item._text.Length;
                    jji._tagHot = 1;
                    list.Add(jji);
                }
            }

            //普通标准句
            for (int i = 0; i < list_putongbiaozhunju.Count; i++)
            {
                var item = list_putongbiaozhunju[i];
                jji = new NrjxInfo();
                jji._nodeType = "普通标准句";
                jji._nodeText = item._text;
                jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                jji._length = item._text.Length;
                jji._tagHot = 1;
                list.Add(jji);
            }
            //主标题索引句
            for (int i = 0; i < list_zhubiaoti.Count; i++)
            {
                for (int j = 0; j < list_zhubiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_zhubiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_zhubiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new NrjxInfo();
                        jji._nodeType = "主标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._tagHot = 1;
                        list.Add(jji);
                    }
                }
            }
            //副标题索引句
            for (int i = 0; i < list_fubiaoti.Count; i++)
            {
                for (int j = 0; j < list_fubiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_fubiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_fubiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new NrjxInfo();
                        jji._nodeType = "副标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._tagHot = 1;
                        list.Add(jji);
                    }
                }
            }

            //一级标题索引句
            for (int i = 0; i < list_yijibiaoti.Count; i++)
            {
                for (int j = 0; j < list_yijibiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_yijibiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_yijibiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new NrjxInfo();
                        jji._nodeType = "一级标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._tagHot = 1;
                        list.Add(jji);
                    }
                }
            }

            //二级标题索引句
            for (int i = 0; i < list_erjibiaoti.Count; i++)
            {
                for (int j = 0; j < list_erjibiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_erjibiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_erjibiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new NrjxInfo();
                        jji._nodeType = "二级标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._tagHot = 1;
                        list.Add(jji);
                    }
                }
            }

            //三级标题索引句
            for (int i = 0; i < list_sanjibiaoti.Count; i++)
            {
                for (int j = 0; j < list_sanjibiaoti[i]._sentences.Count; j++)
                {
                    for (int k = 0; k < list_sanjibiaoti[i]._sentences[j]._indexSentences.Count; k++)
                    {
                        var item = list_sanjibiaoti[i]._sentences[j]._indexSentences[k];
                        jji = new NrjxInfo();
                        jji._nodeType = "三级标题索引句";
                        jji._nodeText = item._text;
                        jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                        jji._length = item._text.Length;
                        jji._tagHot = 1;
                        list.Add(jji);
                    }
                }
            }

            //普通索引句
            for (int i = 0; i < list_putongsuoyinju.Count; i++)
            {
                var item = list_putongsuoyinju[i];
                jji = new NrjxInfo();
                jji._nodeType = "普通索引句";
                jji._nodeText = item._text;
                jji._nodeTextMD5 = Md5Helper.Md5(item._text);
                jji._length = item._text.Length;
                jji._tagHot = 1;
                list.Add(jji);
            }


            //循环获得规则名称，对每一个规则，循环对所有的list元素
            foreach (var item in list_tag)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    //判断list元素是否是，规则的对象位置，如果是，那么用正则匹配，如果匹配到，要看是否是特定语篇提取
                    if (list[i]._nodeType.Contains(item._tagRoot.list_position[0]))
                    {
                        //对正则进行*拆分，判断是否同时
                        List<string> list0 = Regex.Split(item._tagRoot.zhengze, @"\*").ToList();

                        bool b = true;//用于存放是否满足所有的正则条件
                        foreach (string str in list0)
                        {
                            b = Regex.IsMatch(list[i]._nodeText, str);
                            if (!b)
                            {
                                break;
                            }
                        }
                        if (b)//如果匹配到，要看是否是特定语篇提取
                        {
                            //如果是提取特定语篇，那么要讲"节点文本"字段赋值成为特定语篇对应的正则匹配结果

                            if (item._tagRoot.list_yupian.Count == 0)//非特定语篇提取
                            {
                                //如果不是特定语篇，那么节点文本字段不用修改
                                //计算节点文本md5,字数，标签名称，匹配度，热度赋值
                                list[i]._nodeTextMD5 = Md5Helper.Md5(list[i]._nodeText);
                                list[i]._length = list[i]._nodeText.Length;
                                list[i]._tagName = item._mingcheng;
                                list[i]._tagDegree = item._tagRoot.gudingzhi;
                                list[i]._tagHot = 1;
                            }
                            else//特定语篇提取
                            {
                                //根据语篇的设置，提取正则对应的文本，
                                //包括几种情况：时间表达式，数字表达式，度量表达式，地址表达式专有名词，正则提取式
                                string re = string.Empty;//用于存放正则表达式
                                if (item._tagRoot.list_yupian[0].Equals("时间表达式"))
                                {
                                    re = @"\d{2,4}年\d{1,2}月\d{1,2}日";
                                }
                                else if (item._tagRoot.list_yupian[0].Equals("数字表达式"))
                                {

                                }
                                else if (item._tagRoot.list_yupian[0].Equals("度量表达式"))
                                {

                                }
                                else if (item._tagRoot.list_yupian[0].Equals("地址表达式"))
                                {

                                }
                                else if (item._tagRoot.list_yupian[0].Equals("专有名词"))
                                {

                                }
                                else if (item._tagRoot.list_yupian[0].Equals("正则提取式"))
                                {
                                    re = item._tagRoot.zhengzetiqu;
                                }
                                string match = Regex.Match(list[i]._nodeText, re).Value;
                                //如果提取到了，新建一个nrjxinfo,赋值节点文本，添加到list中
                                if (!match.Equals(string.Empty))
                                {
                                    NrjxInfo _ni = new NrjxInfo();
                                    _ni._nodeType = "特定语篇内容";
                                    _ni._nodeText = match;
                                    //计算节点文本md5,字数，标签名称，匹配度，标签热度赋值

                                    _ni._nodeTextMD5 = Md5Helper.Md5(_ni._nodeText);
                                    _ni._length = _ni._nodeText.Length;
                                    _ni._tagName = item._mingcheng;
                                    _ni._tagDegree = item._tagRoot.gudingzhi;
                                    _ni._tagHot = 1;
                                    list.Add(_ni);
                                }
                            }
                        }
                    }
                }
            }













            return list;
        }




        /// <summary>
        /// 保存基础解析结果
        /// </summary>
        public void SaveList2Excel(List<JcjxInfo> list)
        {
            //构造保存路径
            string file = Path.GetFileNameWithoutExtension(_fileName);
            string path = Path.GetDirectoryName(_fileName);
            //对预path要判断格式信息中的保存路径是否“空”，如果是空保存在同意路径下，如果不为空保存在新路径
            if (_baseFormatInfo._zhidingwenjianjia)
            {
                path = _baseFormatInfo._savePath.Trim();
            }
            string savefilename = $"{path}\\01-{file}.xlsx";
            Aspose.Cells.Workbook mywbk = new Aspose.Cells.Workbook();
            Aspose.Cells.Worksheet mysht = mywbk.Worksheets[0];
            //生成字段名
            mysht.Cells[0, 0].Value = "节点类型名称";
            mysht.Cells[0, 1].Value = "节点文本";
            mysht.Cells[0, 2].Value = "节点文本MD5";
            mysht.Cells[0, 3].Value = "字数";
            mysht.Cells[0, 4].Value = "热度";
            mysht.Cells[0, 5].Value = "信息库名";
            mysht.Cells[0, 6].Value = "基础分类";
            mysht.Cells[0, 7].Value = "权威性";
            mysht.Cells[0, 8].Value = "文件名";
            mysht.Cells[0, 9].Value = "文件名MD5";
            mysht.Cells[0, 10].Value = "主标题";
            mysht.Cells[0, 11].Value = "主标题MD5";
            mysht.Cells[0, 12].Value = "脚尾注";
            mysht.Cells[0, 13].Value = "脚尾注MD5";
            mysht.Cells[0, 14].Value = "作者";
            mysht.Cells[0, 15].Value = "来源";
            mysht.Cells[0, 16].Value = "日期";
            mysht.Cells[0, 17].Value = "位置关联内容MD5";
            mysht.Cells[0, 18].Value = "所在标准段MD5";

            for (int i = 0; i < list.Count; i++)
            {
                mysht.Cells[i + 1, 0].Value = list[i]._nameType;
                mysht.Cells[i + 1, 1].Value = list[i]._nodeText;
                mysht.Cells[i + 1, 2].Value = list[i]._nodeMD5;
                mysht.Cells[i + 1, 3].Value = list[i]._length;
                mysht.Cells[i + 1, 4].Value = list[i]._hot;
                mysht.Cells[i + 1, 5].Value = list[i]._infodbName;
                mysht.Cells[i + 1, 6].Value = list[i]._baseType;
                mysht.Cells[i + 1, 7].Value = list[i]._authority;
                mysht.Cells[i + 1, 8].Value = list[i]._fileName;
                mysht.Cells[i + 1, 9].Value = list[i]._fileNameMD5;
                mysht.Cells[i + 1, 10].Value = list[i]._firstTitle;
                mysht.Cells[i + 1, 11].Value = list[i]._firstTitleMD5;
                mysht.Cells[i + 1, 12].Value = list[i]._footer;
                mysht.Cells[i + 1, 13].Value = list[i]._footerMD5;
                mysht.Cells[i + 1, 14].Value = list[i]._author;
                mysht.Cells[i + 1, 15].Value = list[i]._original;
                mysht.Cells[i + 1, 16].Value = list[i]._date;
                mysht.Cells[i + 1, 17].Value = list[i]._positionTextMD5;
                mysht.Cells[i + 1, 18].Value = list[i]._paraMD5;
            }
            mywbk.Save(savefilename);
        }
        /// <summary>
        /// 保存内容解析结果
        /// </summary>
        /// <param name="list"></param>
        public void SaveList2Excel(List<NrjxInfo> list)
        {
            //构造保存路径
            string file = Path.GetFileNameWithoutExtension(_fileName);
            string path = Path.GetDirectoryName(_fileName);
            //判断指定文件夹是否勾选，如果不为空保存在新路径
            if (_contentFormatInfo. _zhidingwenjianjia)
            {
                path = _contentFormatInfo._savePath.Trim();
            }
            string savefilename = $"{path}\\02-{file}.xlsx";
            Aspose.Cells.Workbook mywbk = new Aspose.Cells.Workbook();
            Aspose.Cells.Worksheet mysht = mywbk.Worksheets[0];
            //生成字段名
            mysht.Cells[0, 0].Value = "节点类型名称";
            mysht.Cells[0, 1].Value = "节点文本";
            mysht.Cells[0, 2].Value = "节点文本MD5";
            mysht.Cells[0, 3].Value = "字数";
            mysht.Cells[0, 4].Value = "标签名称";
            mysht.Cells[0, 5].Value = "节点标签匹配度";
            mysht.Cells[0, 6].Value = "标签热度";
            for (int i = 0; i < list.Count; i++)
            {
                mysht.Cells[i + 1, 0].Value = list[i]._nodeType;
                mysht.Cells[i + 1, 1].Value = list[i]._nodeText;
                mysht.Cells[i + 1, 2].Value = list[i]._nodeTextMD5;
                mysht.Cells[i + 1, 3].Value = list[i]._length;
                mysht.Cells[i + 1, 4].Value = list[i]._tagName;
                mysht.Cells[i + 1, 5].Value = list[i]._tagDegree;
                mysht.Cells[i + 1, 6].Value = list[i]._tagHot;
            }
            mywbk.Save(savefilename);
        }
    }

    /// <summary>
    /// 极简标准段
    /// </summary>
    public class JJParagraph
    {
        public string _text = string.Empty;
        public List<JJSentence> _sentences = new List<JJSentence>();
        /// <summary>
        /// 标准段所在文档
        /// </summary>
        public JJDocument _parent = null;
        /// <summary>
        /// 该标准段在原文档中的索引
        /// </summary>
        public int _index = 0;
        /// <summary>
        /// 段落居中情况
        /// </summary>
        public ParagraphAlignment _aglignment = new ParagraphAlignment();
    }
    /// <summary>
    /// 极简标准句
    /// </summary>
    public class JJSentence
    {
        public string _text = string.Empty;
        public List<JJIndexSentence> _indexSentences = new List<JJIndexSentence>();
        public JJParagraph _parent = null;
        public int _index = 0;
    }
    /// <summary>
    /// 极简索引句
    /// </summary>
    public class JJIndexSentence
    {
        public string _text = string.Empty;
        public JJSentence _parent = null;
        public int _index = 0;
        public List<JJIndexSentence> _indexSentences = new List<JJIndexSentence>();
    }


    /// <summary>
    /// 用于生成基础解析表的model
    /// </summary>
    public class JcjxInfo
    {
        /// <summary>
        /// 节点名称类型
        /// </summary>
        public string _nameType = string.Empty;
        /// <summary>
        /// 节点文本
        /// </summary>
        public string _nodeText = string.Empty;

        /// <summary>
        /// 节点MD5
        /// </summary>
        public string _nodeMD5 = string.Empty;
        /// <summary>
        /// 字数
        /// </summary>
        public int _length = 0;
        /// <summary>
        /// 热度
        /// </summary>
        public int _hot = 0;
        /// <summary>
        /// 信息库名
        /// </summary>
        public string _infodbName = string.Empty;
        /// <summary>
        /// 基础分类
        /// </summary>
        public string _baseType = string.Empty;
        /// <summary>
        /// 权威性
        /// </summary>
        public string _authority = string.Empty;
        /// <summary>
        /// 文件名
        /// </summary>
        public string _fileName = string.Empty;
        /// <summary>
        /// 文件名MD5
        /// </summary>
        public string _fileNameMD5 = string.Empty;
        /// <summary>
        /// 主标题
        /// </summary>
        public string _firstTitle = string.Empty;
        /// <summary>
        /// 主标题MD5
        /// </summary>
        public string _firstTitleMD5 = string.Empty;
        /// <summary>
        /// 脚尾注
        /// </summary>
        public string _footer = string.Empty;
        /// <summary>
        /// 脚尾注MD5
        /// </summary>
        public string _footerMD5 = string.Empty;
        /// <summary>
        /// 作者
        /// </summary>
        public string _author = string.Empty;
        /// <summary>
        /// 来源
        /// </summary>
        public string _original = string.Empty;
        /// <summary>
        ///日期
        /// </summary>
        public string _date = string.Empty;
        /// <summary>
        /// 位置关联内容MD5
        /// </summary>
        public string _positionTextMD5 = string.Empty;
        /// <summary>
        /// 所在标准段MD5
        /// </summary>
        public string _paraMD5 = string.Empty;



    }
    /// <summary>
    /// 用于生成内容解析表的model
    /// </summary>
    public class NrjxInfo
    {
        public string _nodeType = string.Empty;

        public string _nodeText = string.Empty;

        public string _nodeTextMD5 = string.Empty;

        public int _length = 0;

        public string _tagName = string.Empty;

        public string _tagDegree = string.Empty;

        public int _tagHot = 0;


    }






}
