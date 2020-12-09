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
        public List<BaseInfo> _list_baseinfo = new List<BaseInfo>();
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
        public string _zhengwengangyao = string.Empty;
        /// <summary>
        /// 一级标题集合
        /// </summary>
        public List<string> _yijibiaoti = new List<string>();
        /// <summary>
        /// 一级标题纲要
        /// </summary>
        public string _yijibiaotigangyao = string.Empty;
        /// <summary>
        /// 二级标题集合
        /// </summary>
        public List<string> _erjibiaoti = new List<string>();


        /// <summary>
        /// 二级标题纲要
        /// </summary>
        public string _erjibiaotigangyao = string.Empty;
        /// <summary>
        /// 三级标题集合
        /// </summary>
        public List<string> _sanjibiaoti = new List<string>();
        /// <summary>
        /// 三级标题纲要集合
        /// </summary>
        public string _sanjibiaotigangyao = string.Empty;
        /// <summary>
        /// word文档的所有自然段集合
        /// </summary>
        public List<string> _ziranduan = new List<string>();

        /// <summary>
        /// 标准段集合,每个标准段都含有1个以上的标准句
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
        /// 正文首个标准段集合
        /// </summary>
        public List<string> _zhengwenshougebiaozhunju = new List<string>();

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
        /// 传入一个word文件名，在构造函数中分解成基本信息
        /// </summary>
        /// <param name="filename"></param>
        public WordInfo(string filename)
        {
            _myword = new Aspose.Words.Document(filename);
        }
        //public BaseInfo wenjianminginfo = new BaseInfo();
        //public BaseInfo zhubiaotiinfo = new BaseInfo();
        //public BaseInfo fubiaotiinfo = new BaseInfo();
        //public BaseInfo yijibiaotiinfo = new BaseInfo();
        //public BaseInfo erjibiaotiinfo = new BaseInfo();
        //public BaseInfo sanjibiaotiinfo = new BaseInfo();
        //public BaseInfo zhengweninfo = new BaseInfo();
        //public BaseInfo biaozhunduaninfo = new BaseInfo();
        //public BaseInfo biaozhunjuinfo = new BaseInfo();
        //public BaseInfo duanshoubiaozhunjuinfo = new BaseInfo();
        //public BaseInfo shouduanbiaozhunjuinfo = new BaseInfo();
        //public BaseInfo wenjianmingsuoyinjuinfo = new BaseInfo();
        //public BaseInfo zhubiaotisuoyinjuinfo = new BaseInfo();
        //public BaseInfo fubiaotisuoyinjuinfo = new BaseInfo();
        //public BaseInfo yijibiaotisuoyinjuinfo = new BaseInfo();
        //public BaseInfo erjibiaotisuoyinjuinfo = new BaseInfo();
        //public BaseInfo sanjibiaotisuoyinjuinfo = new BaseInfo();
        //public BaseInfo duanshoubiaozhunjusuoyinjuinfo = new BaseInfo();
        //public BaseInfo putongsuoyinjuinfo = new BaseInfo();
        //public BaseInfo zhengwengangyaoinfo = new BaseInfo();
        //public BaseInfo yijibiaotigangyaoinfo = new BaseInfo();
        //public BaseInfo erjibiaotigangyaoinfo = new BaseInfo();
        //public BaseInfo sanjibiaotigangyaoinfo = new BaseInfo();

        /// <summary>
        /// 获得所有的文本
        /// </summary>
        public void GetAllWenben()
        {
            GetZiranduan();
            GetWenjianming();
            GetZhubiaoti();
            GetFubiaoti();
            GetZhengwen();
            GetYijibiaoti();
            GetYijibiaotigangyao();
            GetErjibiaoti();
            GetErjibiaotigangyao();
            GetSanjibiaoti();
            GetSanjibiaotigangyao();
            GetBiaozhunduan();
            GetZhengwenshouduanbiaozhunju();

            GetBiaozhunju();
            GetDuanshoubiaozhunju();
            GetWenjianmingsuoyinju();
            GetZhubiaotisuoyinju();
            GetFubiaotisuoyinju();
            GetYijibiaotisuoyinju();
            GetErjibiaotisuoyinju();
            GetSanjibiaotisuoyinju();
            GetDuanshoubiaozhunjusuoyinju();
            GetZhengwengangyao();

            GetPutongsuoyinju();
        }
        /// <summary>
        /// 首段标准句
        /// </summary>
        private void GetZhengwenshouduanbiaozhunju()
        {
            if (_fubiaoti.Count > 0)
            {
                //循环所有自然段，如果自然段的文本是副标题，
                for (int i = 0; i < _ziranduan.Count; i++)
                {
                    string wenben = _ziranduan[i];
                    //定位副标题，那么下一个自然段就是首段，进行标准句拆分，不等于空的句子都是正文首个标准句
                    if (wenben.Equals(_fubiaoti[0]))
                    {
                        var biaozhunju = Regex.Split(_ziranduan[i + 1], @"[,!?。]");
                        foreach (string item in biaozhunju)
                        {
                            if (!item.Trim().Equals(string.Empty))
                            {
                                _zhengwenshougebiaozhunju.Add(item);
                            }
                        }
                        break;
                    }
                }
            }
            else//如果不存在副标题,那么从第二个自然段开始就都是正文首个标准句
            {
                var biaozhunju = Regex.Split(_ziranduan[1], @"[,!?。]");
                foreach (string item in biaozhunju)
                {
                    if (!item.Trim().Equals(string.Empty))
                    {
                        _zhengwenshougebiaozhunju.Add(item);
                    }
                }
            }
        }






        /// <summary>
        /// 普通索引句
        /// </summary>
        private void GetPutongsuoyinju()
        {
            List<string> list_temp = new List<string>();
            foreach (string item in _ziranduan)
            {
                string[] mymc = Regex.Split(item, $@"[:：,，、。]");
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
                bool length = mystr.Length > 2;
                if (!b1 && !b2 && !b3 && !b4 && !b5 && !b6 && !b7 && length)
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
                string[] mymc = Regex.Split(item, $@"[:：,，、。]");
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
                string[] mymc = Regex.Split(item, $@"[:：,，、。]");
                foreach (string mymatch in mymc)
                {
                    if (mymatch.Length >= 2)
                    {
                        _erjibiaotisuoyinju.Add(mymatch);

                    }
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
                    if (mymatch.Length >= 2)
                    {
                        _yijibiaotisuoyinju.Add(mymatch);
                    }

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
            _sanjibiaotigangyao = string.Join("|", _sanjibiaoti);
        }

        /// <summary>
        /// 生成二级标题纲要
        /// </summary>
        private void GetErjibiaotigangyao()
        {
            _erjibiaotigangyao = string.Join("|", _erjibiaoti);
        }

        /// <summary>
        /// 生成一级标题纲要
        /// </summary>
        private void GetYijibiaotigangyao()
        {
            _yijibiaotigangyao = string.Join("|", _yijibiaoti);
        }


        /// <summary>
        /// 分析文档，得到所有的对象和他的相关信息，包括文本，MD5值，热度，字数，位置关联信息，内容关联信息，关联标准段
        /// </summary>
        public void AnalysisInfo()
        {




            MatchCollection mc = null;//用于保存热度结果

            ///1、文件名

            BaseInfo newbi = new BaseInfo();
            newbi._mingcheng = "文件名";
            newbi._wenben = _wenjianming;

            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            mc = Regex.Matches(_quanwen, $"{_wenjianming}");
            newbi._redu = 1;
            newbi._zishu = _wenjianming.Length;
            //位置关联

            for (int i = 0; i < _biaozhunju.Count; i++)
            {
                if (_biaozhunju[i].Contains(_wenjianming))
                {
                    if (i == _biaozhunju.Count - 1)
                    {
                        newbi._weizhiguanlian = _biaozhunju[i + 1];
                    }

                }
            }

            //内容关联
            newbi._neirongguanlian = _zhengwengangyao;
            _list_baseinfo.Add(newbi);



            //2、主标题
            foreach (string item in _zhubiaoti)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "主标题";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }





                //内容关联
                newbi._neirongguanlian = _zhengwengangyao;
                _list_baseinfo.Add(newbi);
            }
            //3、副标题
            foreach (string item in _fubiaoti)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "副标题";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }
                //内容关联
                newbi._neirongguanlian = _zhengwengangyao;

                _list_baseinfo.Add(newbi);
            }
            //4、一级标题
            foreach (string item in _yijibiaoti)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "一级标题";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }

                //内容关联
                newbi._neirongguanlian = _yijibiaotigangyao;
                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }
                _list_baseinfo.Add(newbi);
            }
            //4-1 一级标题纲要
            newbi = new BaseInfo();
            newbi._mingcheng = "一级标题纲要";
            newbi._wenben = _yijibiaotigangyao;
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;
            _list_baseinfo.Add(newbi);
            //5、二级标题
            foreach (string item in _erjibiaoti)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "二级标题";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联 

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }

                //内容关联
                newbi._neirongguanlian = _erjibiaotigangyao;
                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }

            //5-1二级标题纲要
            newbi = new BaseInfo();
            newbi._mingcheng = "二级标题纲要";
            newbi._wenben = _erjibiaotigangyao;
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;
            _list_baseinfo.Add(newbi);
            //6、三级标题
            foreach (string item in _sanjibiaoti)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "三级标题";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联信息

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }

                //内容关联
                newbi._neirongguanlian = _sanjibiaotigangyao;
                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }

            //6-1、三级标题纲要
            newbi = new BaseInfo();
            newbi._mingcheng = "三级标题纲要";
            newbi._wenben = _sanjibiaotigangyao;
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;
            _list_baseinfo.Add(newbi);

            //7、正文
            newbi = new BaseInfo();
            newbi._mingcheng = "正文";
            newbi._wenben = string.Join("", _zhengwen);
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;
            _list_baseinfo.Add(newbi);


            //7-1、正文纲要
            newbi = new BaseInfo();
            newbi._mingcheng = "正文纲要";
            newbi._wenben = _zhengwengangyao;
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;
            _list_baseinfo.Add(newbi);


            //8、标准段
            foreach (string item in _biaozhunduan)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "标准段";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }

                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //8-1、正文首个标准句
            foreach (string item in _zhengwenshougebiaozhunju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "正文首个标准句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }


                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }



                _list_baseinfo.Add(newbi);
            }

            //9、标准句
            foreach (string item in _biaozhunju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "标准句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }

                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //10、段首标准句
            foreach (string item in _duanshoubiaozhunju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "段首标准句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联

                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            newbi._weizhiguanlian = _biaozhunju[i + 1];
                        }

                    }
                }
                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }


            //11、文件名索引句
            foreach (string item in _wenjianmingsuoyinju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "文件名索引句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联
                //获得包括索引句在内的两句话
                //全部拆分为索引句
                //从最后一句循环，知道本索引句结束
                string liangju = string.Empty;
                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            liangju = _biaozhunju[i] + _biaozhunju[i + 1];
                        }
                        else
                        {
                            liangju = _biaozhunju[i];
                        }
                        break;
                    }
                }
                var list_suoyinju = Regex.Matches(liangju, @"[\s\S]+?[:,、。，：\r]");
                for (int i = list_suoyinju.Count - 1; i >= 0; i--)
                {
                    if (list_suoyinju[i].Value.Contains(item))
                    {
                        break;
                    }
                    newbi._weizhiguanlian = list_suoyinju[i].Value + newbi._weizhiguanlian;
                }




                //内容关联
                newbi._neirongguanlian = _zhengwengangyao;
                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //12、主标题索引句
            foreach (string item in _zhubiaotisuoyinju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "主标题索引句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联
                //获得包括索引句在内的两句话
                //全部拆分为索引句
                //从最后一句循环，知道本索引句结束
                string liangju = string.Empty;
                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            liangju = _biaozhunju[i] + _biaozhunju[i + 1];
                        }
                        else
                        {
                            liangju = _biaozhunju[i];
                        }
                        break;
                    }
                }
                var list_suoyinju = Regex.Matches(liangju, @"[\s\S]+?[:,、。，：\r]");
                for (int i = list_suoyinju.Count - 1; i >= 0; i--)
                {
                    if (list_suoyinju[i].Value.Contains(item))
                    {
                        break;
                    }
                    newbi._weizhiguanlian = list_suoyinju[i].Value + newbi._weizhiguanlian;
                }


                //内容关联
                newbi._neirongguanlian = _zhengwengangyao;

                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //13、副标题索引句
            foreach (string item in _fubiaotisuoyinju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "副标题索引句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联
                //获得包括索引句在内的两句话
                //全部拆分为索引句
                //从最后一句循环，知道本索引句结束
                string liangju = string.Empty;
                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            liangju = _biaozhunju[i] + _biaozhunju[i + 1];
                        }
                        else
                        {
                            liangju = _biaozhunju[i];
                        }
                        break;
                    }
                }
                var list_suoyinju = Regex.Matches(liangju, @"[\s\S]+?[:,、。，：\r]");
                for (int i = list_suoyinju.Count - 1; i >= 0; i--)
                {
                    if (list_suoyinju[i].Value.Contains(item))
                    {
                        break;
                    }
                    newbi._weizhiguanlian = list_suoyinju[i].Value + newbi._weizhiguanlian;
                }
                //内容关联
                newbi._neirongguanlian = _zhengwengangyao;
                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //14、一级标题索引句
            foreach (string item in _yijibiaotisuoyinju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "一级标题索引句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联
                //获得包括索引句在内的两句话
                //全部拆分为索引句
                //从最后一句循环，知道本索引句结束
                string liangju = string.Empty;
                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            liangju = _biaozhunju[i] + _biaozhunju[i + 1];
                        }
                        else
                        {
                            liangju = _biaozhunju[i];
                        }
                        break;
                    }
                }
                var list_suoyinju = Regex.Matches(liangju, @"[\s\S]+?[:,、。，：\r]");
                for (int i = list_suoyinju.Count - 1; i >= 0; i--)
                {
                    if (list_suoyinju[i].Value.Contains(item))
                    {
                        break;
                    }
                    newbi._weizhiguanlian = list_suoyinju[i].Value + newbi._weizhiguanlian;
                }


                //内容关联
                newbi._neirongguanlian = _yijibiaotigangyao;

                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //15、二级标题索引句
            foreach (string item in _erjibiaotisuoyinju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "二级标题索引句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联
                //获得包括索引句在内的两句话
                //全部拆分为索引句
                //从最后一句循环，知道本索引句结束
                string liangju = string.Empty;
                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            liangju = _biaozhunju[i] + _biaozhunju[i + 1];
                        }
                        else
                        {
                            liangju = _biaozhunju[i];
                        }
                        break;
                    }
                }
                var list_suoyinju = Regex.Matches(liangju, @"[\s\S]+?[:,、。，：\r]");
                for (int i = list_suoyinju.Count - 1; i >= 0; i--)
                {
                    if (list_suoyinju[i].Value.Contains(item))
                    {
                        break;
                    }
                    newbi._weizhiguanlian = list_suoyinju[i].Value + newbi._weizhiguanlian;
                }


                //内容关联
                newbi._neirongguanlian = _erjibiaotigangyao;
                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //16、三级标题索引句
            foreach (string item in _sanjibiaotisuoyinju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "三级标题索引句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联
                //获得包括索引句在内的两句话
                //全部拆分为索引句
                //从最后一句循环，知道本索引句结束
                string liangju = string.Empty;
                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            liangju = _biaozhunju[i] + _biaozhunju[i + 1];
                        }
                        else
                        {
                            liangju = _biaozhunju[i];
                        }
                        break;
                    }
                }
                var list_suoyinju = Regex.Matches(liangju, @"[\s\S]+?[:,、。，：\r]");
                for (int i = list_suoyinju.Count - 1; i >= 0; i--)
                {
                    if (list_suoyinju[i].Value.Contains(item))
                    {
                        break;
                    }
                    newbi._weizhiguanlian = list_suoyinju[i].Value + newbi._weizhiguanlian;
                }


                //内容关联
                newbi._neirongguanlian = _sanjibiaotigangyao;
                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //17、段首标准局索引句
            foreach (string item in _duanshoubiaozhunjusuoyinju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "段首标准局索引句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联
                //获得包括索引句在内的两句话
                //全部拆分为索引句
                //从最后一句循环，知道本索引句结束
                string liangju = string.Empty;
                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            liangju = _biaozhunju[i] + _biaozhunju[i + 1];
                        }
                        else
                        {
                            liangju = _biaozhunju[i];
                        }
                        break;
                    }
                }
                var list_suoyinju = Regex.Matches(liangju, @"[\s\S]+?[:,、。，：\r]");
                for (int i = list_suoyinju.Count - 1; i >= 0; i--)
                {
                    if (list_suoyinju[i].Value.Contains(item))
                    {
                        break;
                    }
                    newbi._weizhiguanlian = list_suoyinju[i].Value + newbi._weizhiguanlian;
                }


                //内容关联
                newbi._neirongguanlian = _zhengwengangyao;

                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
            //18、普通索引句
            foreach (string item in _putongsuoyinju)
            {

                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "普通索引句";
                //文本
                newbi._wenben = item;
                //MD5
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                //热度
                newbi._redu = 1;
                //字数
                newbi._zishu = newbi._wenben.Length;
                //位置关联
                //获得包括索引句在内的两句话
                //全部拆分为索引句
                //从最后一句循环，知道本索引句结束
                string liangju = string.Empty;
                for (int i = 0; i < _biaozhunju.Count; i++)
                {
                    if (_biaozhunju[i].Contains(item))
                    {
                        if (i < _biaozhunju.Count - 1)
                        {
                            liangju = _biaozhunju[i] + _biaozhunju[i + 1];
                        }
                        else
                        {
                            liangju = _biaozhunju[i];
                        }
                        break;
                    }
                }
                MatchCollection list_suoyinju = Regex.Matches(liangju, @"[\s\S]+?[:,、。，：\r]");
                for (int i = list_suoyinju.Count - 1; i >= 0; i--)
                {
                    if (list_suoyinju[i].Value.Contains(item))
                    {
                        break;
                    }
                    newbi._weizhiguanlian = list_suoyinju[i].Value + newbi._weizhiguanlian;
                }



                //关联标准段
                foreach (string mystr in _biaozhunduan)
                {
                    //判断是否包含了文本内容
                    if (mystr.Contains(item))
                    {
                        newbi._guanlianbiaozhunduan = mystr;
                    }
                }

                _list_baseinfo.Add(newbi);
            }
        }
        /// <summary>
        /// 获得正文纲要
        /// </summary>
        public void GetZhengwengangyao()
        {


            //如果有多个zhu标题，就等于主标题集合
            if (_zhubiaoti.Count > 1)
            {
                _zhengwengangyao = string.Join("|", _zhubiaoti);
                return;
            }

            //如果一级标题只有一个就等一一级标题
            if (_zhubiaoti.Count == 1)
            {
                _zhengwengangyao = string.Join("|", _yijibiaoti);
                return;
            }

            //如果一级标题为空，就等于段首标准句
            if (_yijibiaoti.Count == 0)
            {
                _zhengwengangyao = string.Join("|", _duanshoubiaozhunju);
                return;

            }

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
            _zhubiaoti.Add(list_para[0].Range.Text.Trim());
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
            if (list_para.Count > 2)
            {
                _fubiaoti.Add(list_para[1].Range.Text.Trim());

            }
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
                    bool b1 = Regex.IsMatch(paratext, @"^[\(（][一二三四五六七八九十]+?[\)）]、?[\s\S]+");
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
                    bool b1_1 = Regex.IsMatch(paratext, @"[一二三四五六七八九十]是[\s\S]+?。");
                    bool b2 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]+？[,，][\s\S]+");
                    bool b3 = Regex.IsMatch(paratext, @"^首先[\s\S]+");
                    bool b4 = Regex.IsMatch(paratext, @"^其次[\s\S]+");
                    bool b5 = Regex.IsMatch(paratext, @"^[\(（]\d+?[）\)][，,][\s\S]+");
                    bool b6 = Regex.IsMatch(paratext, @"^①②③④⑤⑥⑦⑧⑨⑩[\s\S]+");
                    bool b7 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]条[\s\S]+");
                    bool b8 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]条第[一二三四五六七八九十]款");
                    bool b9 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十]条第[一二三四五六七八九十]款第[一二三四五六七八九十]条[\s\S]+");
                    if (b1 || b1_1 || b2 || b3 || b4 || b5 || b6 || b7 || b8 || b9)
                    {
                        _sanjibiaoti.Add(paratext);
                    }
                }
            }



        }
        /// <summary>
        /// 获得word的自然段集合
        /// </summary>
        public void GetZiranduan()
        {
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph paragraph in sec.Body.Paragraphs)
                {
                    string paratext = paragraph.Range.Text.Trim();
                    if (!paratext.Equals(string.Empty))
                    {
                        _ziranduan.Add(paratext);
                        _quanwen += paratext + "\r";
                    }
                }
            }
        }

        /// <summary>
        /// 获得标准段（包括主标题）
        /// </summary>
        public void GetBiaozhunduan()//不知道是否包含主,副标题
        {
            foreach (Section sec in _myword.Sections)
            {
                foreach (Paragraph paragraph in sec.Body.Paragraphs)
                {
                    string paratext = paragraph.Range.Text.Trim();

                    //拆分标准句，如果标准句的数量大于1，认定为标准段
                    var biaozhunju = Regex.Matches(paratext, @"[\s\S]+?[。；？！……;!?$]");
                    if (biaozhunju.Count > 1)
                    {
                        _biaozhunduan.Add(paratext);
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
                    var mc = Regex.Matches(paratext, @"[\s\S]+?[。；？！……;!?\r]");
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
            //循环标准段获得第一句
            foreach (string item in _biaozhunduan)
            {
                var biaozhunju = Regex.Split(item, @"[。？！；……!?;]").ToList();
                _duanshoubiaozhunju.Add(biaozhunju[0]);
            }
        }






        /// <summary>
        /// 获得正文集合
        /// </summary>
        public void GetZhengwen()
        {
            //循环所有的自然段，主标题副标题，一级标题，二级标题，三级标题都不包括
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
            mc = Regex.Matches(_wenjianming, @"(?<=[,，、。])[\s\S]+?(?=[,，、。])");
            foreach (Match match in mc)
            {
                _wenjianmingsuoyinju.Add(match.Value);
            }
            //副标题索引句
            foreach (string str in _fubiaoti)
            {
                mc = Regex.Matches(str, @"(?<=[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _fubiaotisuoyinju.Add(match.Value);
                }
            }
            //主标题索引据
            foreach (string str in _zhubiaoti)
            {
                mc = Regex.Matches(str, @"(?<=[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _zhubiaotisuoyinju.Add(match.Value);
                }
            }
            //一级标题索引句
            foreach (string str in _yijibiaoti)
            {
                mc = Regex.Matches(str, @"(?<=[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _yijibiaotisuoyinju.Add(match.Value);
                }
            }
            //二级标题索引据
            foreach (string str in _erjibiaoti)

            {
                mc = Regex.Matches(str, @"(?<=[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _erjibiaotisuoyinju.Add(match.Value);
                }
            }

            //三级标题索引句
            foreach (string str in _sanjibiaoti)

            {
                mc = Regex.Matches(str, @"(?<=[,，、。])[\s\S]+?(?=[,，、。])");
                foreach (Match match in mc)
                {
                    _sanjibiaotisuoyinju.Add(match.Value);
                }
            }

            //段首标准句索引句
            foreach (string str in _duanshoubiaozhunju)

            {
                mc = Regex.Matches(str, @"(?<=[,，、。])[\s\S]+?(?=[,，、。])");
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
                mc = Regex.Matches(str, @"(?<=[,，、。])[\s\S]+?(?=[,，、。])");
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
