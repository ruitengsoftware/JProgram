﻿using Aspose.Words;
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
            GetZiranduan();//获得所有自然段文本集合， 同时获得全文（用\r\n分割段落）
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
                                string mystr = item;
                                //去除一二三级标题序号标点
                                mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                                mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                                mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                                mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                                mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                                mystr = Regex.Replace(mystr, @"首先[，,]", "");
                                mystr = Regex.Replace(mystr, @"其次[，,]", "");
                                mystr = Regex.Replace(mystr, @"\d+?\.", "");
                                mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                                mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");
                                _zhengwenshougebiaozhunju.Add(mystr);
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
            for (int i = 0; i < list_temp.Count; i++)
            {
                string mystr = list_temp[i];
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
                    //去除序号等一二三级标题特点
                    mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                    mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                    mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                    mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                    mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                    mystr = Regex.Replace(mystr, @"首先[，,]", "");
                    mystr = Regex.Replace(mystr, @"其次[，,]", "");
                    mystr = Regex.Replace(mystr, @"\d+?\.", "");
                    mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                    mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");

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
                    string mystr = mymatch;
                    //去除一二三级标题序号标点
                    mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                    mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                    mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                    mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                    mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                    mystr = Regex.Replace(mystr, @"首先[，,]", "");
                    mystr = Regex.Replace(mystr, @"其次[，,]", "");
                    mystr = Regex.Replace(mystr, @"\d+?\.", "");
                    mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                    mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");
                    //判断索引句的字符数量，大于4个，留下
                    if (mystr.Length >= 4)
                    {
                        _duanshoubiaozhunjusuoyinju.Add(mystr);
                    }
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
                    string mystr = mymatch;
                    //去除一二三级标题序号标点
                    mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                    mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                    mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                    mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                    mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                    mystr = Regex.Replace(mystr, @"首先[，,]", "");
                    mystr = Regex.Replace(mystr, @"其次[，,]", "");
                    mystr = Regex.Replace(mystr, @"\d+?\.", "");
                    mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                    mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");
                    //判断索引句的字符数量，大于4个，留下
                    if (mystr.Length >= 4)
                    {

                        _sanjibiaotisuoyinju.Add(mystr);
                    }
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
                        string mystr = mymatch;
                        //去除一二三级标题序号标点
                        mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                        mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                        mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                        mystr = Regex.Replace(mystr, @"首先[，,]", "");
                        mystr = Regex.Replace(mystr, @"其次[，,]", "");
                        mystr = Regex.Replace(mystr, @"\d+?\.", "");
                        mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");
                        //判断索引句的字符数量，大于4个，留下
                        if (mystr.Length >= 4)
                        {

                            _erjibiaotisuoyinju.Add(mystr);
                        }
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
                        string mystr = mymatch;
                        //去除一二三级标题序号标点
                        mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                        mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                        mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                        mystr = Regex.Replace(mystr, @"首先[，,]", "");
                        mystr = Regex.Replace(mystr, @"其次[，,]", "");
                        mystr = Regex.Replace(mystr, @"\d+?\.", "");
                        mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");
                        //判断索引句的字符数量，大于4个，留下
                        if (mystr.Length >= 4)
                        {

                            _yijibiaotisuoyinju.Add(mystr);
                        }
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
        /// 法律法规基础规则
        /// </summary>
        public void AnalysisInfo2()
        {

            BaseInfo newbi = new BaseInfo();

            //19、基本信息（json 信息）
            foreach (string item in _ziranduan)
            {
                bool b1 = Regex.IsMatch(item, @"[:：]");
                bool b2 = Regex.IsMatch(item, @"[。，!;,；！……]");
                if (b1 && !b2)
                {
                    string[] arr = Regex.Split(item, @"[:：]");
                    newbi = new BaseInfo()
                    {
                        _mingcheng = arr[0],
                        _wenben = arr[1],
                        _MD5 = Md5Helper.Md5(arr[1]),
                        _redu = 1,
                        _zishu = arr[1].Length
                    };
                    _list_baseinfo.Add(newbi);
                }


            }
            //20、法律修订
            newbi = new BaseInfo()
            {
                _mingcheng = "法律修订"
            };
            List<string> list = new List<string>();
            foreach (string item in _ziranduan)
            {
                bool b1 = Regex.IsMatch(item, @"[\s\S]+[(（]?通过[）)]?$");
                bool b2 = Regex.IsMatch(item, @"[\s\S]+[(（]?修订[）)]?$");
                bool b3 = Regex.IsMatch(item, @"[\s\S]+[(（]?修正[）)]?$");
                if (b1 || b2 || b3)
                {
                    list.Add(item);
                }
            }
            newbi._wenben = string.Join("\r\n", list);
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;

            _list_baseinfo.Add(newbi);

            //21、目录解析 
            //21-1 总目录，包含所有的编，章，节
            newbi = new BaseInfo()
            {
                _mingcheng = "总目录"
            };
            list = new List<string>();
            foreach (string item in _ziranduan)
            {
                bool b1 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+编");
                bool b2 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+章");
                bool b3 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+节");
                if (b1 || b2 || b3)
                {
                    list.Add(item);
                }
            }
            newbi._wenben = string.Join("\r\n", list);
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;

            _list_baseinfo.Add(newbi);
            //21-2 编目录
            newbi = new BaseInfo()
            {
                _mingcheng = "编目录"
            };
            list = new List<string>();
            foreach (string item in _ziranduan)
            {
                bool b1 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+编");
                if (b1)
                {
                    list.Add(item);
                }
            }
            newbi._wenben = string.Join("\r\n", list);
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;

            _list_baseinfo.Add(newbi);

            //21-3 章目录
            newbi = new BaseInfo()
            {
                _mingcheng = "章目录"
            };
            list = new List<string>();
            foreach (string item in _ziranduan)
            {
                bool b2 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+章");
                if (b2)
                {
                    list.Add(item);
                }
            }
            newbi._wenben = string.Join("\r\n", list);
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;

            _list_baseinfo.Add(newbi);




            //21-2 便利总目录，分解出编章节

            //先获得所有的目录（总目录），然后寻找章，如果遇到就新建一个newbi（第几章节），然后向下获得所有节list，最后join
            list = new List<string>();
            foreach (string item in _ziranduan)
            {
                bool b1 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+编");
                bool b2 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+章");
                bool b3 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+节");
                if (b1 || b2 || b3)
                {
                    list.Add(item);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                string str = list[i];
                if (Regex.IsMatch(str, "第[一二三四五六七八九十百零]+章"))
                {
                    List<string> list_jie = new List<string>();//存放所有的节目录
                    newbi = new BaseInfo()
                    {
                        _mingcheng = $"{Regex.Match(str, @"第[一二三四五六七八九十百零]+章").Value}节目录"
                    };
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        string str_jie = list[j];
                        //判断是否为第几节
                        bool b1 = Regex.IsMatch(str_jie, "第[一二三四五六七八九十百零]+节");
                        bool b2 = Regex.IsMatch(str_jie, "第[一二三四五六七八九十百零]+章");
                        //如果是第几章就跳出节的循环
                        if (b1)
                        {
                            list_jie.Add(str_jie);
                        }
                        if (b2)
                        {
                            i = j - 1;
                            newbi._wenben = string.Join("\r\n", list_jie);
                            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                            newbi._redu = 1;
                            newbi._zishu = newbi._wenben.Length;

                            _list_baseinfo.Add(newbi);

                            break;
                        }
                        newbi._wenben = string.Join("\r\n", list_jie);
                        newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                        newbi._redu = 1;
                        newbi._zishu = newbi._wenben.Length;

                        _list_baseinfo.Add(newbi);
                    }
                }

            }



            //22、正文解析
            //条款 项
            MatchCollection mctiao = Regex.Matches(string.Join("\r\n", _ziranduan), @"第[一二三四五六七八九十百零]+条[\s\S]+?(?=(\r\n第[一二三四五六七八九十百零]+条|$))");

            foreach (Match m in mctiao)
            {
                //获得第几条
                string dijitiao = Regex.Match(m.Value, "第[一二三四五六七八九十百零]+条").Value;
                string str_tiao = Regex.Replace(m.Value, dijitiao, "");//获得了整条的内容,去除前面的第几条
                //不管哪种情况都要添加条
                //除了得到分解的第几条第几项，还要得到条+项的集合
                newbi = new BaseInfo()
                {
                    _mingcheng = dijitiao,
                    _wenben = str_tiao
                };
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                newbi._redu = 1;
                newbi._zishu = newbi._wenben.Length;

                _list_baseinfo.Add(newbi);

                //分解条内容的获得所有的自然段
                string[] duan = Regex.Split(str_tiao, "\r\n");
                //循环自然段,获得项和款数量
                List<string> list_k = new List<string>();
                List<string> list_x = new List<string>();
                for (int i = 0; i < duan.Length; i++)
                {
                    string str = duan[i];
                    if (Regex.IsMatch(str, @"[(（][一二三四五六七八九十百零]+[）)][\s\S]+?"))
                    {
                        list_x.Add(str);
                    }
                    else
                    {
                        list_k.Add(str);
                    }
                }
                //开始对段落循环生成baseinfo

                //if (list_k.Count == 1 && list_x.Count == 0)//第几条：只有一款，没有项
                //{
                //    newbi = new BaseInfo()
                //    {
                //        _mingcheng = dijitiao,
                //        _wenben = list_k[0]
                //    };
                //    _list_baseinfo.Add(newbi);

                //}
                if (list_k.Count == 1 && list_x.Count > 0)//第几条第几项：只有一款，有一些项
                {
                    for (int i = 0; i < list_x.Count; i++)
                    {
                        newbi = new BaseInfo()
                        {
                            _mingcheng = $"{dijitiao}第{ArabToDaxie(i + 1)}项",
                            _wenben = list_x[i]
                        };
                        newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                        newbi._redu = 1;
                        newbi._zishu = newbi._wenben.Length;

                        _list_baseinfo.Add(newbi);
                    }
                }

                if (list_k.Count > 1)//有好几款
                {
                    string dijikuan = string.Empty;//记录第几款
                                                   //从第一自然段开始向下，如果不是以（）开头，并且下一段也不是以（）开头或者没有下一行，就newbi一个
                    int index_k = 1;//这个参数用来记录获得第几款

                    for (int i = 0; i < duan.Length; i++)
                    {
                        string str = duan[i];
                        string str_next = i == duan.Length - 1 ? string.Empty : duan[i + 1];
                        bool b1 = Regex.IsMatch(str, @"[（(][一二三四五六七八九十百零]+[）)][]\s\S]+");
                        bool b2 = Regex.IsMatch(str_next, @"[（(][一二三四五六七八九十百零]+[）)][]\s\S]+");
                        bool b3 = i == duan.Length - 1;
                        if (!b1 && (!b2 || b3))//如果不跟着项
                        {

                            newbi = new BaseInfo()
                            {
                                _mingcheng = $"{dijitiao}第{ArabToDaxie(index_k)}款",
                                _wenben = duan[i]
                            };
                            index_k++;
                            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                            newbi._redu = 1;
                            newbi._zishu = newbi._wenben.Length;

                            _list_baseinfo.Add(newbi);
                        }
                        //如果不是以（）并且下一行是以（）开头那么就向下一行进入循环并且newbi，直到不以（）开头
                        if (!b1 && b2)
                        {

                            int index_x = 0;
                            List<string> list_tk = new List<string>();//记录第i款下的所有项
                            for (int j = i + 1; j < duan.Length; j++)//开始记录项，这里需要初始化一个index记录第几项
                            {
                                bool b4 = Regex.IsMatch(duan[j], @"[（(][一二三四五六七八九十百零]+[）)][]\s\S]+");
                                bool b5 = i == duan.Length - 1;
                                if (b4)
                                {
                                    index_x++;//指数自增1
                                    newbi = new BaseInfo()
                                    {
                                        _mingcheng = $"{dijitiao}第{ArabToDaxie(index_k)}款第{ArabToDaxie(index_x)}项",
                                        _wenben = duan[j]
                                    };
                                    newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                                    newbi._redu = 1;
                                    newbi._zishu = newbi._wenben.Length;

                                    _list_baseinfo.Add(newbi);
                                    list_tk.Add(duan[j]);
                                }
                                else if (!b4 || b5)//如果不是以（）开头，或者没有下一段就退出循环,
                                {
                                    //在此添加提几条第几款
                                    newbi = new BaseInfo()
                                    {
                                        _mingcheng = $"{dijitiao}第{ArabToDaxie(index_k)}款",
                                        _wenben = $"{duan[i]}\r\n{string.Join("\r\n", list_tk)}"
                                    };
                                    newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                                    newbi._redu = 1;
                                    newbi._zishu = newbi._wenben.Length;
                                    index_k++;
                                    _list_baseinfo.Add(newbi);
                                    i = j - 1;
                                    break;
                                }
                            }
                        }

                    }
                }

            }
            //23、附件
            //从上向下判断，遇到附件一开头的自然段就向下查找以\d开头的文本
            for (int i = 0; i < _ziranduan.Count; i++)
            {
                string str = _ziranduan[i];
                bool b = Regex.IsMatch(str, "^附件[一二三四五六七八九十百零]{1,3}");
                if (b)
                {
                    List<string> list_fujian = new List<string>();
                    newbi = new BaseInfo() { _mingcheng = Regex.Match(str, "附件[一二三四五六七八九十百零]{1,3}").Value };
                    for (int j = i + 1; j < _ziranduan.Count; j++)
                    {
                        string str1 = _ziranduan[j];
                        //判断是否以冒号结尾或者以\d开头
                        bool b1 = Regex.IsMatch(str1, @"[\s\S]+[:：]");
                        bool b2 = Regex.IsMatch(str1, @"\d{1,2}·[\s\S]+");
                        if (b1 || b2)
                        {
                            list_fujian.Add(str1);
                        }
                        else if (!b1 && !b2)
                        {
                            i = j - 1;
                            newbi._wenben = string.Join("\r\n", list_fujian);
                            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                            newbi._redu = 1;
                            newbi._zishu = newbi._wenben.Length;


                            _list_baseinfo.Add(newbi);
                            break;
                        }
                        newbi._wenben = string.Join("\r\n", list_fujian);
                        newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                        newbi._redu = 1;
                        newbi._zishu = newbi._wenben.Length;


                        _list_baseinfo.Add(newbi);
                    }


                }
            }




        }


        /// <summary>
        /// 裁判文书基础规则，得到所有的对象和他的相关信息，包括文本，MD5值，热度，字数，位置关联信息，内容关联信息，关联标准段
        /// </summary>
        public void AnalysisInfo()
        {
            MatchCollection mc = null;//用于保存热度结果
            ///1、文件名
            BaseInfo newbi = new BaseInfo();
            newbi._mingcheng = "文件名";
            newbi._wenben = _wenjianming;

            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
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
            //1-1全文
            //全文和正文有可能超过单元格的最大容量，这里需要对文本做一个切分
            //切分后的形式是全文ABCD....
            Dictionary<int, string> dic = new Dictionary<int, string>() {
                {1,"A" }, {2,"B" }, {3,"C" }, {4,"D" }, {5,"E" }, {6,"F" },
                {7,"G" }, {8,"H" }, {9,"I" }, {10,"J" }, {11,"K" }, {12,"L" },
                {13,"M" }, {14,"N" }, {15,"O" }, {16,"P" }, {17,"Q" }, {18,"R" },
                {19,"S" }, {20,"T" }, {21,"U" }, {22,"V" }, {23,"W" }, {24,"X" },
                {25,"Y" }, {26,"Z" }
            };
            newbi = new BaseInfo();
            List<string> list = ChaifenStr(_quanwen, 32000);
            if (list.Count > 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newbi = new BaseInfo();
                    newbi._wenben = list[i];
                    newbi._mingcheng = $"全文{dic[i + 1]}";

                    newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                    newbi._redu = 1;
                    newbi._zishu = newbi._wenben.Length;
                    _list_baseinfo.Add(newbi);

                }
            }
            else
            {
                newbi._wenben = _quanwen;
                newbi._mingcheng = "全文";
                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
                newbi._redu = 1;
                newbi._zishu = newbi._wenben.Length;
                _list_baseinfo.Add(newbi);

            }


            //2、主标题
            foreach (string item in _zhubiaoti)
            {
                newbi = new BaseInfo();
                newbi._mingcheng = "主标题";
                //文本
                newbi._wenben = item;

                //名称,判断文本是否含有章，编，节，如果有的话，将名称改为对应的标题
                if (newbi._wenben.Contains("编"))
                {
                    newbi._mingcheng = "编标题";
                }
                else if (newbi._wenben.Contains("章"))
                {
                    newbi._mingcheng = "章标题";
                }
                else if (newbi._wenben.Contains("节"))
                {
                    newbi._mingcheng = "节标题";
                }

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
                //文本
                newbi._wenben = item;
                //名称,判断文本是否含有章，编，节，如果有的话，将名称改为对应的标题
                if (newbi._wenben.Contains("编"))
                {
                    newbi._mingcheng = "编标题";
                }
                else if (newbi._wenben.Contains("章"))
                {
                    newbi._mingcheng = "章标题";
                }
                else if (newbi._wenben.Contains("节"))
                {
                    newbi._mingcheng = "节标题";
                }


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
                //处理文本内容，去掉序号和标点
                newbi._wenben = Regex.Replace(newbi._wenben, @"[一二三四五六七八九十]+?、", "");
                //newbi._wenben= Regex.Replace(newbi._wenben,@"[,.，。！？……、：;!?]","");
                _list_baseinfo.Add(newbi);
            }
            //4-1 一级标题纲要
            newbi = new BaseInfo();
            newbi._mingcheng = "一级标题纲要";
            newbi._wenben = _yijibiaotigangyao;
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;
            // newbi._wenben = Regex.Replace(newbi._wenben, @"[,.，。！？……、：;!?]", "");
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

                //处理文本内容，去掉序号和标点
                newbi._wenben = Regex.Replace(newbi._wenben, @"[(（][一二三四五六七八九十]+?[)）]", "");
                // newbi._wenben = Regex.Replace(newbi._wenben, @"[,.，。！？……、：;!?]", "");

                _list_baseinfo.Add(newbi);
            }

            //5-1二级标题纲要
            newbi = new BaseInfo();
            newbi._mingcheng = "二级标题纲要";
            newbi._wenben = _erjibiaotigangyao;
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;
            //处理文本内容，去掉序号和标点
            newbi._wenben = Regex.Replace(newbi._wenben, @"[(（][一二三四五六七八九十]+?[)）]", "");
            // newbi._wenben = Regex.Replace(newbi._wenben, @"[,.，。！？……、：;!?]", "");

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
                //处理文本内容，去掉序号和标点
                newbi._wenben = Regex.Replace(newbi._wenben, @"[一二三四五六七八九十]+?是", "");
                newbi._wenben = Regex.Replace(newbi._wenben, @"[一二三四五六七八九十]+?(?=要)", "");
                newbi._wenben = Regex.Replace(newbi._wenben, @"第[一二三四五六七八九十]+?[，,]", "");
                newbi._wenben = Regex.Replace(newbi._wenben, @"首先[，,]", "");
                newbi._wenben = Regex.Replace(newbi._wenben, @"其次[，,]", "");
                newbi._wenben = Regex.Replace(newbi._wenben, @"\d+?\.", "");
                newbi._wenben = Regex.Replace(newbi._wenben, @"[(（]\d{1,3}?[)）]", "");
                newbi._wenben = Regex.Replace(newbi._wenben, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");
                //newbi._wenben = Regex.Replace(newbi._wenben, @"[,.，。！？……、：;!?]", "");

                _list_baseinfo.Add(newbi);
            }

            //6-1、三级标题纲要
            newbi = new BaseInfo();
            newbi._mingcheng = "三级标题纲要";
            newbi._wenben = _sanjibiaotigangyao;
            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            newbi._redu = 1;
            newbi._zishu = newbi._wenben.Length;
            //处理文本内容，去掉序号和标点
            newbi._wenben = Regex.Replace(newbi._wenben, @"[一二三四五六七八九十]+?是", "");
            newbi._wenben = Regex.Replace(newbi._wenben, @"[一二三四五六七八九十]+?(?=要)", "");
            newbi._wenben = Regex.Replace(newbi._wenben, @"第[一二三四五六七八九十]+?[，,]", "");
            newbi._wenben = Regex.Replace(newbi._wenben, @"首先[，,]", "");
            newbi._wenben = Regex.Replace(newbi._wenben, @"其次[，,]", "");
            newbi._wenben = Regex.Replace(newbi._wenben, @"\d+?\.", "");
            newbi._wenben = Regex.Replace(newbi._wenben, @"[(（]\d{1,3}?[)）]", "");
            newbi._wenben = Regex.Replace(newbi._wenben, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");
            // newbi._wenben = Regex.Replace(newbi._wenben, @"[,.，。！？……、：;!?]", "");

            _list_baseinfo.Add(newbi);

            //7、正文
            //newbi = new BaseInfo();
            //newbi._mingcheng = "正文";
            //newbi._wenben = string.Join("", _zhengwen);
            //newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //newbi._redu = 1;
            //newbi._zishu = newbi._wenben.Length;
            //_list_baseinfo.Add(newbi);


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

            //9、普通标准句
            foreach (string item in _biaozhunju)
            {
                newbi = new BaseInfo();
                //名称
                newbi._mingcheng = "普通标准句";
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
                newbi._mingcheng = "段首标准句索引句";
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


            ////19、基本信息（json 信息）
            //foreach (string item in _ziranduan)
            //{
            //    bool b1 = Regex.IsMatch(item, @"[:：]");
            //    bool b2 = Regex.IsMatch(item, @"[。，!;,；！……]");
            //    if (b1 && !b2)
            //    {
            //        string[] arr = Regex.Split(item, @"[:：]");
            //        newbi = new BaseInfo()
            //        {
            //            _mingcheng = arr[0],
            //            _wenben = arr[1],
            //            _MD5=Md5Helper.Md5(arr[1]),
            //            _redu=1,
            //            _zishu=arr[1].Length
            //        };
            //        _list_baseinfo.Add(newbi);
            //    }


            //}
            ////20、法律修订
            //newbi = new BaseInfo()
            //{
            //    _mingcheng = "法律修订"
            //};
            //List<string> list = new List<string>();
            //foreach (string item in _ziranduan)
            //{
            //    bool b1 = Regex.IsMatch(item, @"[\s\S]+[(（]?通过[）)]?$");
            //    bool b2 = Regex.IsMatch(item, @"[\s\S]+[(（]?修订[）)]?$");
            //    bool b3 = Regex.IsMatch(item, @"[\s\S]+[(（]?修正[）)]?$");
            //    if (b1 || b2 || b3)
            //    {
            //        list.Add(item);
            //    }
            //}
            //newbi._wenben = string.Join("\r\n", list);
            //newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //newbi._redu = 1;
            //newbi._zishu = newbi._wenben.Length;
            //_list_baseinfo.Add(newbi);
            ////21、目录解析 
            ////21-1 总目录，包含所有的编，章，节
            //newbi = new BaseInfo()
            //{
            //    _mingcheng = "总目录"
            //};
            //list = new List<string>();
            //foreach (string item in _ziranduan)
            //{
            //    bool b1 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+编");
            //    bool b2 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+章");
            //    bool b3 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+节");
            //    if (b1 || b2 || b3)
            //    {
            //        list.Add(item);
            //    }
            //}
            //newbi._wenben = string.Join("\r\n", list);
            //newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //newbi._redu = 1;
            //newbi._zishu = newbi._wenben.Length;
            //_list_baseinfo.Add(newbi);
            ////21-2 编目录
            //newbi = new BaseInfo()
            //{
            //    _mingcheng = "编目录"
            //};
            //list = new List<string>();
            //foreach (string item in _ziranduan)
            //{
            //    bool b1 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+编");
            //    if (b1)
            //    {
            //        list.Add(item);
            //    }
            //}
            //newbi._wenben = string.Join("\r\n", list);
            //newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //newbi._redu = 1;
            //newbi._zishu = newbi._wenben.Length;
            //_list_baseinfo.Add(newbi);
            ////21-3 章目录
            //newbi = new BaseInfo()
            //{
            //    _mingcheng = "章目录"
            //};
            //list = new List<string>();
            //foreach (string item in _ziranduan)
            //{
            //    bool b2 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+章");
            //    if (b2)
            //    {
            //        list.Add(item);
            //    }
            //}
            //newbi._wenben = string.Join("\r\n", list);
            //newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //newbi._redu = 1;
            //newbi._zishu = newbi._wenben.Length;
            //_list_baseinfo.Add(newbi);
            ////21-2 便利总目录，分解出编章节
            ////先获得所有的目录（总目录），然后寻找章，如果遇到就新建一个newbi（第几章节），然后向下获得所有节list，最后join
            //list = new List<string>();
            //foreach (string item in _ziranduan)
            //{
            //    bool b1 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+编");
            //    bool b2 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+章");
            //    bool b3 = Regex.IsMatch(item, "第[一二三四五六七八九十百零]+节");
            //    if (b1 || b2 || b3)
            //    {
            //        list.Add(item);
            //    }
            //}
            //for (int i = 0; i < list.Count; i++)
            //{
            //    string str = list[i];
            //    if (Regex.IsMatch(str, "第[一二三四五六七八九十百零]+章"))
            //    {
            //        List<string> list_jie = new List<string>();//存放所有的节目录
            //        newbi = new BaseInfo()
            //        {
            //            _mingcheng = $"{Regex.Match(str, @"第[一二三四五六七八九十百零]+章").Value}节目录"
            //        };
            //        for (int j = i + 1; j < list.Count; j++)
            //        {
            //            string str_jie = list[j];
            //            //判断是否为第几节
            //            bool b1 = Regex.IsMatch(str_jie, "第[一二三四五六七八九十百零]+节");
            //            bool b2 = Regex.IsMatch(str_jie, "第[一二三四五六七八九十百零]+章");
            //            //如果是第几章就跳出节的循环
            //            if (b1)
            //            {
            //                list_jie.Add(str_jie);
            //            }
            //            if (b2)
            //            {
            //                i = j - 1;
            //                newbi._wenben = string.Join("\r\n", list_jie);
            //                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //                newbi._redu = 1;
            //                newbi._zishu = newbi._wenben.Length;

            //                _list_baseinfo.Add(newbi);

            //                break;
            //            }
            //            newbi._wenben = string.Join("\r\n", list_jie);
            //            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //            newbi._redu = 1;
            //            newbi._zishu = newbi._wenben.Length;

            //            _list_baseinfo.Add(newbi);
            //        }
            //    }

            //}
            ////22、正文解析
            ////条款 项
            //MatchCollection mctiao = Regex.Matches(string.Join("\r\n", _ziranduan), @"第[一二三四五六七八九十百零]+条[\s\S]+?(?=(\r\n第[一二三四五六七八九十百零]+条|$))");
            //foreach (Match m in mctiao)
            //{
            //    //获得第几条
            //    string dijitiao = Regex.Match(m.Value, "第[一二三四五六七八九十百零]+条").Value;
            //    string str_tiao = Regex.Replace(m.Value, dijitiao, "");//获得了整条的内容,去除前面的第几条
            //    //不管哪种情况都要添加条
            //    //除了得到分解的第几条第几项，还要得到条+项的集合
            //    newbi = new BaseInfo()
            //    {
            //        _mingcheng = dijitiao,
            //        _wenben = str_tiao
            //    };
            //    newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //    newbi._redu = 1;
            //    newbi._zishu = newbi._wenben.Length;

            //    _list_baseinfo.Add(newbi);

            //    //分解条内容的获得所有的自然段
            //    string[] duan = Regex.Split(str_tiao, "\r\n");
            //    //循环自然段,获得项和款数量
            //    List<string> list_k = new List<string>();
            //    List<string> list_x = new List<string>();
            //    for (int i = 0; i < duan.Length; i++)
            //    {
            //        string str = duan[i];
            //        if (Regex.IsMatch(str, @"[(（][一二三四五六七八九十百零]+[）)][\s\S]+?"))
            //        {
            //            list_x.Add(str);
            //        }
            //        else
            //        {
            //            list_k.Add(str);
            //        }
            //    }
            //    //开始对段落循环生成baseinfo

            //    //if (list_k.Count == 1 && list_x.Count == 0)//第几条：只有一款，没有项
            //    //{
            //    //    newbi = new BaseInfo()
            //    //    {
            //    //        _mingcheng = dijitiao,
            //    //        _wenben = list_k[0]
            //    //    };
            //    //    _list_baseinfo.Add(newbi);

            //    //}
            //    if (list_k.Count == 1 && list_x.Count > 0)//第几条第几项：只有一款，有一些项
            //    {
            //        for (int i = 0; i < list_x.Count; i++)
            //        {
            //            newbi = new BaseInfo()
            //            {
            //                _mingcheng = $"{dijitiao}第{ArabToDaxie(i + 1)}项",
            //                _wenben = list_x[i]
            //            };
            //            newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //            newbi._redu = 1;
            //            newbi._zishu = newbi._wenben.Length;

            //            _list_baseinfo.Add(newbi);
            //        }
            //    }

            //    if (list_k.Count > 1)//有好几款
            //    {
            //        string dijikuan = string.Empty;//记录第几款
            //        //从第一自然段开始向下，如果不是以（）开头，并且下一段也不是以（）开头或者没有下一行，就newbi一个
            //            int index_k = 1;//这个参数用来记录获得第几款

            //        for (int i = 0; i < duan.Length; i++)
            //        {
            //            string str = duan[i];
            //            string str_next = i == duan.Length - 1 ? string.Empty : duan[i + 1];
            //            bool b1 = Regex.IsMatch(str, @"[（(][一二三四五六七八九十百零]+[）)][]\s\S]+");
            //            bool b2 = Regex.IsMatch(str_next, @"[（(][一二三四五六七八九十百零]+[）)][]\s\S]+");
            //            bool b3 = i == duan.Length - 1;
            //            if (!b1 && (!b2 || b3))//如果不跟着项
            //            {
            //                index_k++;
            //                newbi = new BaseInfo()
            //                {
            //                    _mingcheng = $"{dijitiao}第{ArabToDaxie(index_k)}款",
            //                    _wenben = duan[i]
            //                };
            //                newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //                newbi._redu = 1;
            //                newbi._zishu = newbi._wenben.Length;

            //                _list_baseinfo.Add(newbi);
            //            }
            //            //如果不是以（）并且下一行是以（）开头那么就向下一行进入循环并且newbi，直到不以（）开头
            //            if (!b1 && b2)
            //            {
            //                int index_x = 0;
            //                List<string> list_tk = new List<string>();//记录第i款下的所有项
            //                for (int j = i + 1; j < duan.Length; j++)//开始记录项，这里需要初始化一个index记录第几项
            //                {
            //                    bool b4 = Regex.IsMatch(duan[j], @"[（(][一二三四五六七八九十百零]+[）)][]\s\S]+");
            //                    bool b5 = i == duan.Length - 1;
            //                    if (b4)
            //                    {
            //                        index_x++;//指数自增1
            //                        newbi = new BaseInfo()
            //                        {
            //                            _mingcheng = $"{dijitiao}第{ArabToDaxie(index_k)}款第{ArabToDaxie(index_x)}项",
            //                            _wenben = duan[j]
            //                        };
            //                        newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //                        newbi._redu = 1;
            //                        newbi._zishu = newbi._wenben.Length;

            //                        _list_baseinfo.Add(newbi);
            //                        list_tk.Add(duan[j]);
            //                    }
            //                    else if (!b4 || b5)//如果不是以（）开头，或者没有下一段就退出循环,
            //                    {
            //                        //在此添加提几条第几款
            //                        newbi = new BaseInfo()
            //                        {
            //                            _mingcheng = $"{dijitiao}第{ArabToDaxie(index_k)}款",
            //                            _wenben = $"{duan[i]}\r\n{string.Join("\r\n", list_tk)}"
            //                        };
            //                        newbi._MD5 = Md5Helper.Md5(newbi._wenben);
            //                        newbi._redu = 1;
            //                        newbi._zishu = newbi._wenben.Length;

            //                        _list_baseinfo.Add(newbi);
            //                        i = j - 1;
            //                        break;
            //                    }
            //                }
            //            }

            //        }
            //    }

            //}
            ////23、附件
            ////从上向下判断，遇到附件一开头的自然段就向下查找以\d开头的文本
            //for (int i = 0; i < _ziranduan.Count; i++)
            //{
            //    string str = _ziranduan[i];
            //    bool b = Regex.IsMatch(str, "^附件[一二三四五六七八九十百零]{1,3}");
            //    if (b)
            //    {
            //        List<string> list_fujian = new List<string>();
            //        newbi = new BaseInfo() { _mingcheng = Regex.Match(str, "附件[一二三四五六七八九十百零]{1,3}").Value };
            //        for (int j = i + 1; j < _ziranduan.Count; j++)
            //        {
            //            string str1 = _ziranduan[j];
            //            //判断是否以冒号结尾或者以\d开头
            //            bool b1 = Regex.IsMatch(str1, @"[\s\S]+[:：]");
            //            bool b2 = Regex.IsMatch(str1, @"\d{1,2}·[\s\S]+");
            //            if (b1 || b2)
            //            {
            //                list_fujian.Add(str1);
            //            }
            //            else if (!b1 && !b2)
            //            {
            //                i = j - 1;
            //                newbi._wenben = string.Join("\r\n", list_fujian);
            //                _list_baseinfo.Add(newbi);
            //                break;
            //            }
            //            newbi._wenben = string.Join("\r\n", list_fujian);
            //            _list_baseinfo.Add(newbi);
            //        }


            //    }
            //}
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
            _wenjianming = Path.GetFileName(_myword.OriginalFileName);

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
                    bool b = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十百零]+?[编章][\s\S]+");
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
                    bool b1 = Regex.IsMatch(paratext, @"^第[一二三四五六七八九十百零]+?节[\s\S]+");
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
                    bool b1 = Regex.IsMatch(paratext, @"^[一二三四五六七八九十百零]+、[\s\S]+");
                    if (b1)
                    {
                        //处理文本内容，去掉序号和标点
                        string mystr = paratext;
                        //去除序号等一二三级标题特点
                        mystr = Regex.Replace(mystr, "[一二三四五六七八九十百零]+?、", "");
                        mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十百零]+?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十百零]+?是", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十百零]+?(?=要)", "");
                        mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十百零]+?[，,]", "");
                        mystr = Regex.Replace(mystr, @"首先[，,]", "");
                        mystr = Regex.Replace(mystr, @"其次[，,]", "");
                        mystr = Regex.Replace(mystr, @"\d+?\.", "");
                        mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");

                        _yijibiaoti.Add(mystr);
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
                        string mystr = paratext;
                        //去除序号等一二三级标题特点
                        mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                        mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                        mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                        mystr = Regex.Replace(mystr, @"首先[，,]", "");
                        mystr = Regex.Replace(mystr, @"其次[，,]", "");
                        mystr = Regex.Replace(mystr, @"\d+?\.", "");
                        mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");

                        _erjibiaoti.Add(mystr);
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
                        //用句号拆分成几个句子
                        List<string> list = Regex.Split(paratext, "。").ToList();
                        //去除空值
                        list.Remove(string.Empty);
                        for (int j = 0; j < list.Count; j++)
                        {
                            string mystr = list[j];
                            //去除序号等一二三级标题特点
                            mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                            mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                            mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                            mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                            mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                            mystr = Regex.Replace(mystr, @"首先[，,]", "");
                            mystr = Regex.Replace(mystr, @"其次[，,]", "");
                            mystr = Regex.Replace(mystr, @"\d+?\.", "");
                            mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                            mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");



                            _sanjibiaoti.Add(mystr);

                        }


                    }
                }
            }



        }
        /// <summary>
        /// 获得word的自然段集合,顺便获得了全文，以\r分隔
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
                        _quanwen += paratext + "\r\n";
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
                    var biaozhunju = Regex.Matches(paratext, @"[\s\S]+?[。；:：？！……;!?$]");
                    if (biaozhunju.Count > 1)
                    {
                        if (biaozhunju.Count == 2 && Regex.IsMatch(biaozhunju[0].Value, "[:：]"))
                        {
                            continue;
                        }
                        else
                        {
                            string mystr = paratext;
                            //去除序号等一二三级标题特点
                            mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                            mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                            mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                            mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                            mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                            mystr = Regex.Replace(mystr, @"首先[，,]", "");
                            mystr = Regex.Replace(mystr, @"其次[，,]", "");
                            mystr = Regex.Replace(mystr, @"\d+?\.", "");
                            mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                            mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");

                            _biaozhunduan.Add(mystr);
                        }
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

                        string mystr = m.Value;
                        //去除一二三级标题序号标点
                        mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                        mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                        mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                        mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                        mystr = Regex.Replace(mystr, @"首先[，,]", "");
                        mystr = Regex.Replace(mystr, @"其次[，,]", "");
                        mystr = Regex.Replace(mystr, @"\d+?\.", "");
                        mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                        mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");



                        //判断其他条件
                        //是否全部为数字
                        bool b = Regex.IsMatch(mystr, @"^\d+$");
                        if (b) continue;
                        //添加到标准句集合中
                        _biaozhunju.Add(mystr);
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

                //去除序号等一二三级标题特点
                string mystr = biaozhunju[0];

                mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                mystr = Regex.Replace(mystr, @"首先[，,]", "");
                mystr = Regex.Replace(mystr, @"其次[，,]", "");
                mystr = Regex.Replace(mystr, @"\d+?\.", "");
                mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");
                //判断其他条件
                //是否全部为数字
                bool b = Regex.IsMatch(mystr, @"^\d+$");
                if (b) continue;
                //添加到标准句集合中

                _duanshoubiaozhunju.Add(mystr);
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
            for (int i = 0; i < list_temp.Count; i++)

            {
                string mystr = list_temp[i];
                bool b1 = _zhubiaotisuoyinju.Contains(mystr);
                bool b2 = _fubiaotisuoyinju.Contains(mystr);
                bool b3 = _yijibiaotisuoyinju.Contains(mystr);
                bool b4 = _erjibiaotisuoyinju.Contains(mystr);
                bool b5 = _sanjibiaotisuoyinju.Contains(mystr);
                bool b6 = _duanshoubiaozhunjusuoyinju.Contains(mystr);
                if (!b1 && !b2 && b3 && !b4 && !b5 && !b6)
                {
                    //去除序号等一二三级标题特点
                    mystr = Regex.Replace(mystr, "[一二三四五六七八九十]+?、", "");
                    mystr = Regex.Replace(mystr, "[(（][一二三四五六七八九十]+?[)）]", "");
                    mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?是", "");
                    mystr = Regex.Replace(mystr, @"[一二三四五六七八九十]+?(?=要)", "");
                    mystr = Regex.Replace(mystr, @"第[一二三四五六七八九十]+?[，,]", "");
                    mystr = Regex.Replace(mystr, @"首先[，,]", "");
                    mystr = Regex.Replace(mystr, @"其次[，,]", "");
                    mystr = Regex.Replace(mystr, @"\d+?\.", "");
                    mystr = Regex.Replace(mystr, @"[(（]\d{1,3}?[)）]", "");
                    mystr = Regex.Replace(mystr, @"[①②③④⑤⑥⑦⑧⑨⑩]", "");

                    _putongsuoyinju.Add(mystr);
                }


            }
        }

        /// <summary>
        /// 将阿拉伯数字转换成大写数字
        /// </summary>
        public string ArabToDaxie(int num)
        {
            string str = string.Empty;
            Dictionary<int, string> dic = new Dictionary<int, string>() {
                {0,"零" },
                {1,"一" },
                {2,"二" },
                {3,"三" },
                {4,"四" },
                {5,"五" },
                {6,"六" },
                {7,"七" },
                {8,"八" },
                {9,"九" },
            };
            //判断num的位数
            int weishu = num.ToString().Length;
            //如果只有一位
            if (weishu == 1)
            {
                return dic[num];
            }
            //两位，第二位是0

            //两位，第二位不是0
            if (weishu == 2)
            {
                if (num.ToString()[1].Equals(0))
                {
                    return $"{num.ToString()[0]}十";
                }
                if (num.ToString()[1].Equals(0))
                {
                    return $"{num.ToString()[0]}十{num.ToString()[0]}";
                }
            }
            //三位，第二位是0，第三位不是0
            //第二位是0，第三位是0
            //第二位不是0，第三位是0
            //第二位不是0，第三位也不是0

            if (weishu == 3)
            {
                if (num.ToString()[1].Equals(0) && num.ToString()[2].Equals(0))
                {
                    return $"{num.ToString()[0]}百";
                }
                if (num.ToString()[1].Equals(0) && !num.ToString()[2].Equals(0))
                {
                    return $"{num.ToString()[0]}百零{num.ToString()[2]}";
                }
                if (!num.ToString()[1].Equals(0) && num.ToString()[2].Equals(0))
                {
                    return $"{num.ToString()[0]}百{num.ToString()[1]}十";
                }

                if (!num.ToString()[1].Equals(0) && !num.ToString()[2].Equals(0))
                {
                    return $"{num.ToString()[0]}百{num.ToString()[1]}十{num.ToString()[2]}";
                }
            }
            return string.Empty;

        }


        /// <summary>
        /// 把文字拆分成多个字符串
        /// </summary>
        /// <param name="s">整个字符串</param>
        /// <param name="num">每段的字符串上限</param>
        /// <returns></returns>
        public List<string> ChaifenStr(string s, int num)
        {
            List<string> list = new List<string>();
            string str = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                str += s[i];
                if (str.Length >= num || i == s.Length - 1)
                {
                    list.Add(str);
                    str = string.Empty;
                }
            }
            return list;
        }
    }
}
