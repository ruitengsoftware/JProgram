using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// 首段标准局集合
        /// </summary>
        public List<string> _shouduanbiaozhunju = new List<string>();

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
        public BaseInfo yijibiaotiinfo = new BaseInfo();
        public BaseInfo erjibiaotiinfo = new BaseInfo();
        public BaseInfo sanjibiaotiinfo = new BaseInfo();
        public BaseInfo zhengweninfo = new BaseInfo();
        public BaseInfo biaozhunduaninfo = new BaseInfo();
        public BaseInfo biaozhunjuinfo = new BaseInfo();
        public BaseInfo duanshoubiaozhunjuinfo = new BaseInfo();
        public BaseInfo shouduanbiaozhunjuinfo = new BaseInfo();
        public BaseInfo wenjianmingsuoyinjuinfo = new BaseInfo();
        public BaseInfo zhubiaotisuoyinjuinfo = new BaseInfo();
        public BaseInfo fubiaotisuoyinjuinfo = new BaseInfo();
        public BaseInfo yijibiaotisuoyinjuinfo = new BaseInfo();
        public BaseInfo erjibiaotisuoyinjuinfo = new BaseInfo();
        public BaseInfo sanjibiaotisuoyinjuinfo = new BaseInfo();
        public BaseInfo duanshoubiaozhunjusuoyinjuinfo = new BaseInfo();
        public BaseInfo putongsuoyinjuinfo = new BaseInfo();
        public BaseInfo zhengwengangyaoinfo = new BaseInfo();
        public BaseInfo yijibiaotigangyaoinfo = new BaseInfo();
        public BaseInfo erjibiaotigangyaoinfo = new BaseInfo();
        public BaseInfo sanjibiaotigangyaoinfo = new BaseInfo();

        /// <summary>
        /// 获得所有的文本
        /// </summary>
        public void GetAllWenben()
        {
            GetWenjianming();
            GetZhubiaoti();
            GetFubiaoti();
            GetZhengwen();
            GetZhengwengangyao();
            GetYijibiaoti();
            GetYijibiaotigangyao();
            GetErjibiaoti();
            GetErjibiaotigangyao();
            GetSanjibiaoti();
            GetSanjibiaotigangyao();
            GetBiaozhunduan();
            GetBiaozhunju();
            GetDuanshoubiaozhunju();
            GetWenjianmingsuoyinju();
            GetZhubiaotisuoyinju();
            GetFubiaotisuoyinju();
            GetYijibiaotisuoyinju();
            GetErjibiaotisuoyinju();
            GetSanjibiaotisuoyinju();
            GetDuanshoubiaozhunjusuoyinju();
            GetPutongsuoyinju();
            GetShouduanbiaozhunju();
        }
        /// <summary>
        /// 首段标准句
        /// </summary>
        private void GetShouduanbiaozhunju()
        {
            string shouduan = string.Empty;
            //获得首段
            foreach (Section sec in _myword.Sections)
            {
                for (int i = 0; i < sec.Body.Paragraphs.Count; i++)
                {
                    bool center = sec.Body.Paragraphs[i].ParagraphFormat.Alignment == ParagraphAlignment.Center;
                    bool empty = sec.Body.Paragraphs[i].Range.Text.Trim().Equals(string.Empty);
                    if (!empty && center)
                    {
                        //获得下一段的文本，如果是空，就再向下滚动
                        string nextparatext;
                        do
                        {
                            i++;
                            nextparatext = sec.Body.Paragraphs[i].Range.Text.Trim();
                        } while (nextparatext.Equals(string.Empty));
                        shouduan=nextparatext;
                        break;
                    }
                }
            }
            //拆分为标准句子
            string[] mymc = Regex.Split(shouduan, $@"[。：；？！……;:?!]");
            foreach (string mymatch in mymc)
            {
                _shouduanbiaozhunju.Add(mymatch);
            }






        }






        /// <summary>
        /// 普通索引句
        /// </summary>
        private void GetPutongsuoyinju()
        {
            List<string> list_temp = new List<string>();
            foreach (string item in _biaozhunduan)
            {
                string[] mymc = Regex.Split(item, $@"[,，、。]");
                foreach (string mymatch in mymc)
                {
                    list_temp.Add(mymatch);
                }
            }
            //从list_temp中排除所有的段首标准句子，一，二，三级标题索引句，主，副标题索引句，文件名索引句
            foreach (string mystr in list_temp)
            {
                bool b1 = _duanshoubiaozhunjusuoyinju.Contains(mystr);
                bool b2 = _yijibiaotisuoyinju.Contains(mystr);
                bool b3 = _erjibiaotisuoyinju.Contains(mystr);
                bool b4 = _sanjibiaotisuoyinju.Contains(mystr);
                bool b5 = _zhubiaotisuoyinju.Contains(mystr);
                bool b6 = _fubiaotisuoyinju.Contains(mystr);
                bool b7 = _wenjianmingsuoyinju.Contains(mystr);
                if (!b1&&!b2 && !b3 && !b4 && !b5 && !b6 && !b7)
                {
                    _putongsuoyinju.Add(mystr);
                }

            }



        }



        /// <summary>
        /// 获得段首标准句索引句
        /// </summary>
        private void GetDuanshoubiaozhunjusuoyinju()
        {
            foreach (string item in _duanshoubiaozhunju)
            {
                string[] mymc = Regex.Split(item, $@"[,，、。]");
                foreach (string mymatch in mymc)
                {
                    _duanshoubiaozhunjusuoyinju.Add(mymatch);
                }

            }


        }

        /// <summary>
        /// 获得三级标题索引句
        /// </summary>
        private void GetSanjibiaotisuoyinju()
        {
            foreach (string item in _sanjibiaoti)
            {
                string[] mymc = Regex.Split(item, $@"[,，、。]");
                foreach (string mymatch in mymc)
                {
                    _sanjibiaotisuoyinju.Add(mymatch);
                }

            }

        }

        /// <summary>
        /// 获得二级标题索引句
        /// </summary>
        private void GetErjibiaotisuoyinju()
        {
            foreach (string item in _erjibiaoti)
            {
                string[] mymc = Regex.Split(item, $@"[,，、。]");
                foreach (string mymatch in mymc)
                {
                    _erjibiaotisuoyinju.Add(mymatch);
                }

            }

        }

        /// <summary>
        /// 获得一级标题索引句
        /// </summary>
        private void GetYijibiaotisuoyinju()
        {
            foreach (string item in _yijibiaoti)
            {
                string[] mymc = Regex.Split(item, $@"[,，、。]");
                foreach (string mymatch in mymc)
                {
                    _yijibiaotisuoyinju.Add(mymatch);
                }

            }

        }

        /// <summary>
        /// 获得副标题索引句
        /// </summary>
        private void GetFubiaotisuoyinju()
        {
            foreach (string item in _fubiaoti)
            {
                string[] mymc = Regex.Split(item, $@"[,，、。]");
                foreach (string mymatch in mymc)
                {
                    _fubiaotisuoyinju.Add(mymatch);
                }

            }

        }

        /// <summary>
        /// 获得主标题索引句
        /// </summary>
        private void GetZhubiaotisuoyinju()
        {
            foreach (string item in _zhubiaoti)
            {
                string[] mymc = Regex.Split(item, $@"[,，、。]");
                foreach (string mymatch in mymc)
                {
                    _zhubiaotisuoyinju.Add(mymatch);
                }

            }

        }

        /// <summary>
        /// 获得文件名索引句
        /// </summary>
        private void GetWenjianmingsuoyinju()
        {
            string[] mymc = Regex.Split(_wenjianming, $@"[,，、。]");
            foreach (string mymatch in mymc)
            {
                _wenjianmingsuoyinju.Add(mymatch);
            }
        }

        /// <summary>
        /// 生成三级标题纲要
        /// </summary>
        private void GetSanjibiaotigangyao()
        {
        }

        /// <summary>
        /// 生成二级标题纲要
        /// </summary>
        private void GetErjibiaotigangyao()
        {
        }

        /// <summary>
        /// 生成一级标题纲要
        /// </summary>
        private void GetYijibiaotigangyao()
        {
        }


        /// <summary>
        /// 分析文档，得到所有的对象和他的相关信息，包括文本，MD5值，热度，字数，位置关联信息，内容关联信息，关联标准段
        /// </summary>
        public void AnalysisInfo()
        {




            MatchCollection mc = null;//用于保存热度结果

            ///1、文件名
            wenjianminginfo._mingcheng = "文件名";
            wenjianminginfo._wenben = _wenjianming;
            wenjianminginfo._MD5 = Md5Helper.Md5(_wenjianming);
            mc = Regex.Matches(_quanwen, "{_wenjianming}");
            wenjianminginfo._redu = mc.Count;
            wenjianminginfo._zishu = _wenjianming.Length;
            wenjianminginfo._neirongguanlian = string.Join(@"|", _zhengwengangyao);
            //从全文中提取所在的标准段
            wenjianminginfo._guanlianbiaozhunduan = Regex.Match(_quanwen, "{_wenjianming}?(?=\r)").Value;


            //2、主标题
            zhubiaotiinfo._wenben = string.Join("|", _zhubiaoti);
            zhubiaotiinfo._MD5 = Md5Helper.Md5(zhubiaotiinfo._wenben);
            zhubiaotiinfo._mingcheng = "主标题";
            zhubiaotiinfo._zishu = zhubiaotiinfo._wenben.Length;
            //3、副标题
            fubiaotiinfo._mingcheng = "副标题";
            fubiaotiinfo._wenben = string.Join("|", _fubiaoti);
            fubiaotiinfo._MD5 = Md5Helper.Md5(fubiaotiinfo._wenben);
            fubiaotiinfo._zishu = fubiaotiinfo._wenben.Length;
            //4、一级标题
            yijibiaotiinfo._mingcheng = "一级标题";
            yijibiaotiinfo._wenben = string.Join("|", _yijibiaoti);
            yijibiaotiinfo._MD5 = Md5Helper.Md5(yijibiaotiinfo._wenben);
            yijibiaotiinfo._zishu = yijibiaotiinfo._wenben.Length;
            //4-1 一级标题纲要
            yijibiaotigangyaoinfo._mingcheng = "一级标题纲要";
            yijibiaotigangyaoinfo._wenben = string.Join("|", _yijibiaotigangyao);
            yijibiaotigangyaoinfo._MD5 = Md5Helper.Md5(yijibiaotigangyaoinfo._wenben);
            yijibiaotigangyaoinfo._zishu = yijibiaotigangyaoinfo._wenben.Length;


            //5、二级标题
            erjibiaotiinfo._mingcheng = "二级标题";
            erjibiaotiinfo._wenben = string.Join("|", _erjibiaoti);
            erjibiaotiinfo._MD5 = Md5Helper.Md5(erjibiaotiinfo._wenben);
            erjibiaotiinfo._zishu = erjibiaotiinfo._wenben.Length;
            //5-1二级标题纲要
            erjibiaotigangyaoinfo._mingcheng = "二级标题纲要";
            erjibiaotigangyaoinfo._wenben = string.Join("|", _erjibiaotigangyao);
            erjibiaotigangyaoinfo._MD5 = Md5Helper.Md5(yijibiaotigangyaoinfo._wenben);
            erjibiaotigangyaoinfo._zishu = erjibiaotigangyaoinfo._wenben.Length;

            //6、三级标题
            sanjibiaotiinfo._mingcheng = "三级标题";
            sanjibiaotiinfo._wenben = string.Join("|", _sanjibiaoti);

            sanjibiaotiinfo._MD5 = Md5Helper.Md5(sanjibiaotiinfo._wenben);
            sanjibiaotiinfo._zishu = sanjibiaotiinfo._wenben.Length;
            //6-1、三级标题纲要
            sanjibiaotigangyaoinfo._mingcheng = "三级标题纲要";
            sanjibiaotigangyaoinfo._wenben = string.Join("|", _sanjibiaotigangyao);

            sanjibiaotigangyaoinfo._MD5 = Md5Helper.Md5(sanjibiaotigangyaoinfo._wenben);
            sanjibiaotigangyaoinfo._zishu = sanjibiaotigangyaoinfo._wenben.Length;
            //7、正文
            zhengweninfo._mingcheng = "正文";
            zhengweninfo._wenben = string.Join("", _zhengwen);

            zhengweninfo._MD5 = Md5Helper.Md5(zhengweninfo._wenben);
            zhengweninfo._zishu = zhengweninfo._wenben.Length;
            //7-1、正文纲要
            zhengwengangyaoinfo._mingcheng = "正文纲要";
            zhengwengangyaoinfo._wenben = string.Join("|", zhengwengangyaoinfo._wenben);
            zhengwengangyaoinfo._MD5 = Md5Helper.Md5(zhengwengangyaoinfo._wenben);
            zhengwengangyaoinfo._zishu = zhengwengangyaoinfo._wenben.Length;
            //8、标准段
            biaozhunduaninfo._mingcheng = "标准段";
            biaozhunduaninfo._wenben = string.Join("|", _biaozhunduan);
            biaozhunduaninfo._MD5 = Md5Helper.Md5(biaozhunduaninfo._wenben);
            biaozhunduaninfo._zishu = biaozhunduaninfo._wenben.Length;
            //9、标准句
            biaozhunjuinfo._mingcheng = "标准句";
            biaozhunjuinfo._wenben = string.Join("|", _biaozhunju);
            biaozhunjuinfo._MD5 = Md5Helper.Md5(biaozhunjuinfo._wenben);
            biaozhunjuinfo._zishu = biaozhunjuinfo._wenben.Length;
            //10、段首标准句
            duanshoubiaozhunjuinfo._mingcheng = "段首标准句";
            duanshoubiaozhunjuinfo._wenben = string.Join("|", _duanshoubiaozhunju);

            duanshoubiaozhunjuinfo._MD5 = Md5Helper.Md5(duanshoubiaozhunjuinfo._wenben);
            duanshoubiaozhunjuinfo._zishu = duanshoubiaozhunjuinfo._wenben.Length;
            //10-1、首段标准句
            shouduanbiaozhunjuinfo._mingcheng = "首段标准句";
            shouduanbiaozhunjuinfo._wenben = string.Join("|", _shouduanbiaozhunju);

            shouduanbiaozhunjuinfo._MD5 = Md5Helper.Md5(shouduanbiaozhunjuinfo._wenben);
            shouduanbiaozhunjuinfo._zishu = shouduanbiaozhunjuinfo._wenben.Length;
            //11、文件名索引句
            wenjianmingsuoyinjuinfo._mingcheng = "文件名索引句";
            wenjianmingsuoyinjuinfo._wenben = string.Join("|", _wenjianmingsuoyinju);

            wenjianmingsuoyinjuinfo._MD5 = Md5Helper.Md5(wenjianmingsuoyinjuinfo._wenben);
            wenjianmingsuoyinjuinfo._zishu = wenjianmingsuoyinjuinfo._wenben.Length;
            //12、主标题索引句
            zhubiaotisuoyinjuinfo._mingcheng = "主标题索引句";
            zhubiaotisuoyinjuinfo._wenben = string.Join("|", _zhubiaotisuoyinju);

            zhubiaotisuoyinjuinfo._MD5 = Md5Helper.Md5(zhubiaotisuoyinjuinfo._wenben);
            zhubiaotisuoyinjuinfo._zishu = zhubiaotisuoyinjuinfo._wenben.Length;
            //13、副标题索引句
            fubiaotisuoyinjuinfo._mingcheng = "副标题索引句";
            fubiaotisuoyinjuinfo._wenben = string.Join("|", _fubiaotisuoyinju);

            fubiaotisuoyinjuinfo._MD5 = Md5Helper.Md5(fubiaotisuoyinjuinfo._wenben);
            fubiaotisuoyinjuinfo._zishu = fubiaotisuoyinjuinfo._wenben.Length;
            //14、一级标题索引句
            yijibiaotisuoyinjuinfo._mingcheng = "一级标题索引句";
            yijibiaotisuoyinjuinfo._wenben = string.Join("|", _yijibiaotisuoyinju);

            yijibiaotisuoyinjuinfo._MD5 = Md5Helper.Md5(yijibiaotisuoyinjuinfo._wenben);
            yijibiaotisuoyinjuinfo._zishu = yijibiaotisuoyinjuinfo._wenben.Length;
            //15、二级标题索引句
            erjibiaotisuoyinjuinfo._mingcheng = "二级标题索引句";
            erjibiaotisuoyinjuinfo._wenben = string.Join("|", _erjibiaotisuoyinju);

            erjibiaotisuoyinjuinfo._MD5 = Md5Helper.Md5(erjibiaotisuoyinjuinfo._wenben);
            erjibiaotisuoyinjuinfo._zishu = erjibiaotisuoyinjuinfo._wenben.Length;
            //16、三级标题索引句
            sanjibiaotisuoyinjuinfo._mingcheng = "三级标题索引句";
            sanjibiaotisuoyinjuinfo._wenben = string.Join("|", _sanjibiaotisuoyinju);

            sanjibiaotisuoyinjuinfo._MD5 = Md5Helper.Md5(sanjibiaotisuoyinjuinfo._wenben);
            sanjibiaotisuoyinjuinfo._zishu = sanjibiaotisuoyinjuinfo._wenben.Length;
            //17、段首标准局索引句
            duanshoubiaozhunjusuoyinjuinfo._mingcheng = "段首标准句索引句";
            duanshoubiaozhunjusuoyinjuinfo._wenben = string.Join("|", _duanshoubiaozhunjusuoyinju);

            duanshoubiaozhunjusuoyinjuinfo._MD5 = Md5Helper.Md5(duanshoubiaozhunjusuoyinjuinfo._wenben);
            duanshoubiaozhunjusuoyinjuinfo._zishu = duanshoubiaozhunjusuoyinjuinfo._wenben.Length;
            //18、普通索引句
            putongsuoyinjuinfo._mingcheng = "普通索引句";
            putongsuoyinjuinfo._wenben = string.Join("|", _putongsuoyinju);

            putongsuoyinjuinfo._MD5 = Md5Helper.Md5(putongsuoyinjuinfo._wenben);
            putongsuoyinjuinfo._zishu = putongsuoyinjuinfo._wenben.Length;

            ///把所有的baseinfo存入集合
            list_baseinfo.Add(wenjianminginfo);
            list_baseinfo.Add(zhubiaotiinfo);
            list_baseinfo.Add(fubiaotiinfo);
            list_baseinfo.Add(zhengweninfo);
            list_baseinfo.Add(zhengwengangyaoinfo);
            list_baseinfo.Add(yijibiaotiinfo);
            list_baseinfo.Add(yijibiaotigangyaoinfo);
            list_baseinfo.Add(erjibiaotiinfo);
            list_baseinfo.Add(erjibiaotigangyaoinfo);
            list_baseinfo.Add(sanjibiaotiinfo);
            list_baseinfo.Add(sanjibiaotigangyaoinfo);
            list_baseinfo.Add(biaozhunduaninfo);
            list_baseinfo.Add(biaozhunjuinfo);
            list_baseinfo.Add(duanshoubiaozhunjuinfo);
            list_baseinfo.Add(wenjianmingsuoyinjuinfo);
            list_baseinfo.Add(zhubiaotisuoyinjuinfo);
            list_baseinfo.Add(fubiaotisuoyinjuinfo);
            list_baseinfo.Add(yijibiaotisuoyinjuinfo);
            list_baseinfo.Add(erjibiaotisuoyinjuinfo);
            list_baseinfo.Add(sanjibiaotisuoyinjuinfo);
            list_baseinfo.Add(duanshoubiaozhunjusuoyinjuinfo);
            list_baseinfo.Add(putongsuoyinjuinfo);
            list_baseinfo.Add(shouduanbiaozhunjuinfo);
        }
        /// <summary>
        /// 获得正文纲要
        /// </summary>
        public void GetZhengwengangyao()
        {

        }

        /// <summary>
        /// 获得文件名字段值
        /// </summary>
        public void GetWenjianming()
        {
            _wenjianming = Path.GetFileNameWithoutExtension(_myword.OriginalFileName);

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
            _fubiaoti.Add(list_para[1].Range.Text);
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
                        _fubiaoti.Add(paratext);
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

                    string paratext = para.Range.Text.Trim();
                    //拆分标准句
                    MatchCollection mc = Regex.Matches(paratext, @"[\s\S]+?(?=[。？！；：……!?;:$])");
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

                    string paratext = para.Range.Text.Trim();
                    //拆分标准句
                    MatchCollection mc = Regex.Matches(paratext, @"[\s\S]+?(?=[。？！；：……!?;:$])");
                    if (mc.Count > 0)
                    {
                        _duanshoubiaozhunju.Add(mc[0].Value);

                    }
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
