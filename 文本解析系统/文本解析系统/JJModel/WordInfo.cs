using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJModel
{
    public class WordInfo
    {
        Aspose.Words.Document _myword = null;
        /// <summary>
        /// 用于存放计算好的对象基础信息
        /// </summary>
        List<BaseInfo> _list_baseinfo = new List<BaseInfo>();
        /// <summary>
        /// 文件名
        /// </summary>
        public string _wenjianming = string.Empty;
        /// <summary>
        /// 主标题集合
        /// </summary>
        public List<string> _zhubiaoti = new List<string>();
        /// <summary>
        /// 副标题集合
        /// </summary>
        public List<string> _fubiaoti = new List<string>();
        /// <summary>
        /// 全文字符串
        /// </summary>
        public string _quanwen = string.Empty;
        /// <summary>
        /// 正文字符串集合
        /// </summary>
        public List<string> _zhengwen = new List<string>();
        /// <summary>
        /// 正文纲要
        /// </summary>
        public List<string> _zhengwengangyao = new List<string>();
        /// <summary>
        /// 一级标题集合
        /// </summary>
        public List<string> _yijibiaoti = new List<string>();
        /// <summary>
        /// 一级标题纲要集合
        /// </summary>
        public List<string> _yijibiaotigangyao = new List<string>();
        /// <summary>
        /// 二级标题集合
        /// </summary>
        public List<string> _erjibiaoti = new List<string>();


        /// <summary>
        /// 二级标题纲要
        /// </summary>
        public List<string> _erjibiaotigangyao = new List<string>();
        /// <summary>
        /// 三级标题集合
        /// </summary>
        public List<string> _sanjibiaoti = new List<string>();
        /// <summary>
        /// 三级标题纲要集合
        /// </summary>
        public List<string> _sanjibiaotigangyao = new List<string>();
        /// <summary>
        /// 标准段集合
        /// </summary>
        public List<string> _biaozhunduan = new List<string>();
        /// <summary>
        /// 标准句集合
        /// </summary>
        public List<string> _biaozhunju = new List<string>();
        /// <summary>
        /// 段首标准局集合
        /// </summary>
        public List<string> _duanshoubiaozhunju = new List<string>();
        /// <summary>
        /// 文件名索引句集合
        /// </summary>
        public List<string> _wenjianmingsuoyinju = new List<string>();
        /// <summary>
        /// 主标题索引句集合
        /// </summary>
        public List<string> _zhubiaotisuoyinju = new List<string>();
        /// <summary>
        /// 副标题索引句集合
        /// </summary>
        public List<string> _fubiaotisuoyinju = new List<string>();
        /// <summary>
        /// 一级标题索引句集合
        /// </summary>
        public List<string> _yijibiaotisuoyinju = new List<string>();
        /// <summary>
        /// 二级标题索引句集合
        /// </summary>
        public List<string> _erjibiaotisuoyinju = new List<string>();
        /// <summary>
        /// 三级标题索引句集合
        /// </summary>
        public List<string> _sanjibiaotisuoyinju = new List<string>();
        /// <summary>
        /// 段首标准句索引句集合
        /// </summary>
        public List<string> _duanshoubiaozhunjusuoyinju = new List<string>();
        /// <summary>
        /// 普通索引句集合
        /// </summary>
        public List<string> _putongsuoyinju = new List<string>();
        /// <summary>
        /// 用于存放所有基础信息的集合
        /// </summary>
        public List<BaseInfo> list_baseinfo = new List<BaseInfo>();
        /// <summary>
        /// 传入一个word文件名，在构造函数中分解成基本信息
        /// </summary>
        /// <param name="filename"></param>
        public WordInfo(string filename)
        {
            _myword = new Aspose.Words.Document(filename);
        }
        public BaseInfo wenjianminginfo = new BaseInfo();
        public BaseInfo zhubiaotiinfo = new BaseInfo();
        public BaseInfo fubiaotiinfo = new BaseInfo();
        public BaseInfo yijibiaoti = new BaseInfo();
        public BaseInfo erjibiaoti = new BaseInfo();
        public BaseInfo sanjibiaoti = new BaseInfo();
        public BaseInfo zhengwen = new BaseInfo();
        public BaseInfo biaozhunduan = new BaseInfo();
        public BaseInfo biaozhunju = new BaseInfo();
        public BaseInfo duanshoubiaozhunju = new BaseInfo();
        public BaseInfo wenjianmingsuoyinju = new BaseInfo();
        public BaseInfo zhubiaotisuoyinju = new BaseInfo();
        public BaseInfo fubiaotisuoyinju = new BaseInfo();
        public BaseInfo yijibiaotisuoyinju = new BaseInfo();
        public BaseInfo erjibiaotisuoyinju = new BaseInfo();
        public BaseInfo sanjibiaotisuoyinju = new BaseInfo();
        public BaseInfo duanshoubiaozhunjusuoyinju = new BaseInfo();
        public BaseInfo putongsuoyinju = new BaseInfo();
        /// <summary>
        /// 分析文档，得到所有的对象和他的相关信息，包括文本，MD5值，热度，字数，位置关联信息，内容关联信息，关联标准段
        /// </summary>
        public void AnalysisInfo()
        {
            MatchCollection mc = null;//用于保存热度结果

            ///1、文件名
            wenjianminginfo._mingncheng = "文件名";
            wenjianminginfo._wenben = _wenjianming;
            wenjianminginfo._MD5 = Md5Helper.Md5(_wenjianming);
            mc = Regex.Matches(_myword.Range.Text, $@"{_wenjianming}");
            wenjianminginfo._redu = mc.Count;
            wenjianminginfo._zishu = _wenjianming.Length;
            wenjianminginfo._neirongguanlian = string.Join(@"|", _zhengwengangyao);
            //从全文中提取所在的标准段
            wenjianminginfo._guanlianbiaozhunduan = Regex.Match(_quanwen, $@"(?<[^\r\n]){_wenjianming}(?=\r\n)").Value;


            //2、主标题

            //3、副标题
            //4、一级标题
            //5、二级标题
            //6、三级标题
            //7、正文
            //8、标准段
            //9、标准句
            //10、段首标准句
            //10-1、首段标准句
            //11、文件名索引句
            //12、主标题索引句

            //13、副标题索引句
            //14、一级标题索引句
            //15、二级标题索引句
            //16、三级标题索引句
            //17、段首标准局索引句
            //18、普通索引句




        }



        /// <summary>
        /// 获得文件名字段值
        /// </summary>
        public void GetWenjianming()
        {
            _wenjianming = _myword.OriginalFileName;
        }
        /// <summary>
        /// 获得主标题集合
        /// </summary>
        public void GetZhubiaoti()
        {
            //两种方法得到主标题，一是居中的第一个自然段，另一个是以第一章，第一编等文字开头的整个段落
            List<Paragraph> list_para = new List<Paragraph>();
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph para in sec.Body.Paragraphs)
                {
                    string paratext = para.Range.Text.Trim();
                    if (!paratext.Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                    {
                        list_para.Add(para);
                    }
                }
            }
            _zhubiaoti.Add(list_para[0].Range.Text);
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph para in sec.Body.Paragraphs)
                {
                    string paratext = para.Range.Text.Trim();
                    bool b = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]+?[编章][\s\S]+");
                    if (b)
                    {
                        _zhubiaoti.Add(paratext);
                    }
                }
            }
        }
        /// <summary>
        /// 获得副标题集合
        /// </summary>
        public void GetFubiaoti()
        {
            List<Paragraph> list_para = new List<Paragraph>();
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph para in sec.Body.Paragraphs)
                {
                    string paratext = para.Range.Text.Trim();
                    if (!paratext.Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                    {
                        list_para.Add(para);
                    }
                }
            }
            _zhubiaoti.Add(list_para[1].Range.Text);
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph para in sec.Body.Paragraphs)
                {
                    string paratext = para.Range.Text.Trim();
                    bool b1 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]+?节[\s\S]+");
                    bool b2 = Regex.IsMatch(paratext, @"^目\s*录[\s\S]+");
                    bool b3 = Regex.IsMatch(paratext, @"^前\s*言[\s\S]+");
                    if (b1 || b2 || b3)
                    {
                        _zhubiaoti.Add(paratext);
                    }
                }
            }
        }

        /// <summary>
        /// 获得一级标题
        /// </summary>
        public void GetYijibiaoti()
        {
            foreach (Section section in _myword.Sections)
            {
                foreach (Paragraph paragraph in section.Body.Paragraphs)
                {
                    string paratext = paragraph.Range.Text.Trim();
                    bool b1 = Regex.IsMatch(paratext, @"^[一二三四五六七八九十]+、[\s\S]+");
                    if (b1)
                    {
                        _yijibiaoti.Add(paratext);
                    }
                }
            }
        }
        /// <summary>
        /// 获得二级标题
        /// </summary>
        public void GetErjibiaoti()
        {

            foreach (Section section in _myword.Sections)
            {
                foreach (Paragraph paragraph in section.Body.Paragraphs)
                {
                    string paratext = paragraph.Range.Text.Trim();
                    bool b1 = Regex.IsMatch(paratext, @"^[\(（]一二三四五六七八九十]+[\)）]、[\s\S]+");
                    if (b1)
                    {
                        _erjibiaoti.Add(paratext);
                    }
                }
            }
        }
        /// <summary>
        /// 获得三级标题
        /// </summary>
        public void GetSanjibiaoti()
        {
            foreach (Section section in _myword.Sections)
            {
                foreach (Paragraph paragraph in section.Body.Paragraphs)
                {
                    string paratext = paragraph.Range.Text.Trim();
                    bool b1 = Regex.IsMatch(paratext, @"^[一二三四五六七八九十]要是[\s\S]+");
                    bool b2 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]+？[,，][\s\S]+");
                    bool b3 = Regex.IsMatch(paratext, @"^首先[\s\S]+");
                    bool b4 = Regex.IsMatch(paratext, @"^其次[\s\S]+");
                    bool b5 = Regex.IsMatch(paratext, @"^[\(（]\d+?[）\)][\s\S]+");
                    bool b6 = Regex.IsMatch(paratext, @"^①②③④⑤⑥⑦⑧⑨⑩[\s\S]+");
                    bool b7 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]条[\s\S]+");
                    bool b8 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]条第[一二三四五六七八九十]款");
                    bool b9 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]条第[一二三四五六七八九十]款第[一二三四五六七八九十]条[\s\S]+");
                    if (b1 || b2 || b3 || b4 || b5 || b6 || b7 || b8 || b9)
                    {
                        _sanjibiaoti.Add(paratext);
                    }
                }
            }



        }
        /// <summary>
        /// 获得标准段和全文字符串（包括主标题）
        /// </summary>
        public void GetBiaozhunduan()//不知道是否包含主,副标题
        {
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph paragraph in sec.Body.Paragraphs)
                {
                    string paratext = paragraph.Range.Text.Trim();
                    if (!paratext.Equals(string.Empty))
                    {
                        _biaozhunduan.Add(paratext);
                        _quanwen += paratext + "\r";
                    }
                }
            }
        }
        /// <summary>
        /// 获得标准句
        /// </summary>
        public void GetBiaozhunju()
        {
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph para in sec.Body.Paragraphs)
                {

                    string paratext = para.Range.Text;
                    //拆分标准句
                    MatchCollection mc = Regex.Matches(paratext, @"(?<[。？！；：……!?;:])\s\S+(?=[。？！；：……!?;:$])");
                    foreach (Match m in mc)
                    {
                        _biaozhunju.Add(m.Value);
                    }

                }
            }
        }


        /// <summary>
        /// 获得段首标准句
        /// </summary>
        public void GetDuanshoubiaozhunju()
        {
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph para in sec.Body.Paragraphs)
                {

                    string paratext = para.Range.Text;
                    //拆分标准句
                    MatchCollection mc = Regex.Matches(paratext, @"(?<[。？！；：……!?;:])\s\S+(?=[。？！；：……!?;:$])");

                    _duanshoubiaozhunju.Add(mc[0].Value);
                }
            }
        }






        /// <summary>
        /// 获得正文集合
        /// </summary>
        public void GetZhengwen()
        {
            //循环所有的自然段，如果主标题副标题，一级标题，二级标题，三级标题都不包括
            foreach (Section item in _myword.Sections)
            {
                foreach (Paragraph paragraph in item.Body.Paragraphs)
                {
                    string paratext = paragraph.Range.Text;
                    bool b1 = _zhubiaoti.Contains(paratext);
                    bool b2 = _fubiaoti.Contains(paratext);
                    bool b3 = _yijibiaoti.Contains(paratext);
                    bool b4 = _erjibiaoti.Contains(paratext);
                    bool b5 = _sanjibiaoti.Contains(paratext);
                    if (!b1 && !b2 && !b3 && !b4 && !b5)
                    {
                        _zhengwen.Add(paratext);
                    }
                }
            }
        }
        /// <summary>
        /// 获得各种索引句
        /// </summary>
        public void GetSuoyinju()
        {
            MatchCollection mc = null;
            //文件名索引据
            mc = Regex.Matches(_wenjianming, @"(?<[,，、。])[\s\S]+?(?=[,，、。])");
            foreach (Match match in mc)
            {
                _wenjianmingsuoyinju.Add(match.Value);
            }
            //副标题索引句
            foreach (string str in _fubiaoti)
            {
                mc = Regex.Matches(str, @"(?<[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _fubiaotisuoyinju.Add(match.Value);
                }
            }
            //主标题索引据
            foreach (string str in _zhubiaoti)
            {
                mc = Regex.Matches(str, @"(?<[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _zhubiaotisuoyinju.Add(match.Value);
                }
            }
            //一级标题索引句
            foreach (string str in _yijibiaoti)
            {
                mc = Regex.Matches(str, @"(?<[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _yijibiaotisuoyinju.Add(match.Value);
                }
            }
            //二级标题索引据
            foreach (string str in _erjibiaoti)

            {
                mc = Regex.Matches(str, @"(?<[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _erjibiaotisuoyinju.Add(match.Value);
                }
            }

            //三级标题索引句
            foreach (string str in _sanjibiaoti)

            {
                mc = Regex.Matches(str, @"(?<[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _sanjibiaotisuoyinju.Add(match.Value);
                }
            }

            //段首标准句索引句
            foreach (string str in _duanshoubiaozhunju)

            {
                mc = Regex.Matches(str, @"(?<[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _duanshoubiaozhunjusuoyinju.Add(match.Value);
                }
            }






            //普通索引句
            //获得全文所有的标准句，排除主标题索引句，副标题索引句，一级二级三级标题索引句，段首标准句索引句之后的索引句
            List<string> list_temp = new List<string>();
            foreach (string str in _biaozhunduan)
            {
                mc = Regex.Matches(str, @"(?<[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    list_temp.Add(match.Value);
                }

            }
            foreach (string str in list_temp)
            {
                bool b1 = _zhubiaotisuoyinju.Contains(str);
                bool b2 = _fubiaotisuoyinju.Contains(str);
                bool b3 = _yijibiaotisuoyinju.Contains(str);
                bool b4 = _erjibiaotisuoyinju.Contains(str);
                bool b5 = _sanjibiaotisuoyinju.Contains(str);
                bool b6 = _duanshoubiaozhunjusuoyinju.Contains(str);
                if (!b1 && !b2 && b3 && !b4 && !b5 && !b6)
                {
                    _putongsuoyinju.Add(str);
                }


            }
        }










    }
}
