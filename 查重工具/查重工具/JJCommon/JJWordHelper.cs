using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using 查重工具.JJModel;

namespace 查重工具.JJCommon
{
    public class JJWordHelper
    {
        public string _filename = string.Empty;
        public string _quanwen = string.Empty;
        public string _zhengwen = string.Empty;
        public List<string> list_biaozhunduan = new List<string>();
        public List<string> list_biaozhunju = new List<string>();

        public string _biaozhunduan = string.Empty;
        public string _biaozhunju = string.Empty;

        public JJGeshiInfo _geshiinfo = new JJGeshiInfo();
        public JJMySQLHelper _mysql = new JJMySQLHelper();


        public double _duanchongfulv = 0;
        public double _juchongfulv = 0;






        public JJWordHelper()
        {


        }

        public JJWordHelper(string filename, string geshiname)
        {
            _filename = filename;
            _geshiinfo = GetGeshiInfo(geshiname);
            //获得全文  正文  标准短 标准句
            _quanwen = GetPipeiduixiangStr(new List<string>() { "全文" });
            _zhengwen = GetPipeiduixiangStr(new List<string> { "正文" });
            _biaozhunduan = GetPipeiduixiangStr(new List<string> { "普通标准短" });
            _biaozhunju = GetPipeiduixiangStr(new List<string> { "普通标准句" });
            list_biaozhunduan = Regex.Split(_biaozhunduan, "\r\n").ToList();
            list_biaozhunju = Regex.Split(_biaozhunju, "\r\n").ToList();
        }
        /// <summary>
        /// 移动文件到指定文件夹
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="path"></param>
        public void MoveFile(string filename, string path)
        {
            //获得带有后缀的文件名
            string s = Path.GetFileName(filename);
            //拼接新的保存路径
            string newfilename = $@"{path}/{s}";
            FileInfo file = new FileInfo(filename);
            file.MoveTo(newfilename);
        }


        /// <summary>
        /// 根据格式名称获得格式信息类
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public JJGeshiInfo GetGeshiInfo(string s)
        {
            string str_sql = $"select * from 查重工具库.格式信息表 where 名称='{s}' and 删除=0";
            DataRow dr = _mysql.ExecuteDataRow(str_sql);
            JJGeshiInfo j = new JJGeshiInfo()
            {
                _mingcheng = dr["名称"].ToString(),
                _chachongku = dr["查重库"].ToString(),
                _quanwenchongfulujing = dr["全文重复路径"].ToString(),
                _zhengwenchongfulujing = dr["正文重复路径"].ToString(),
                _quanwenchachong = Convert.ToInt32(dr["全文查重"].ToString()),
                _zhengwenchachong = Convert.ToInt32(dr["正文查重"].ToString()),
                _biaozhunduanchachong = Convert.ToInt32(dr["标准段查重"].ToString()),
                _biaozhunjuchachong = Convert.ToInt32(dr["标准句查重"].ToString()),
                _quanwenruku = Convert.ToInt32(dr["全文入库"].ToString()),
                _zhengwenruku = Convert.ToInt32(dr["正文入库"].ToString()),
                _biaozhunduanruku = Convert.ToInt32(dr["标准段入库"].ToString()),
                _biaozhunjuruku = Convert.ToInt32(dr["标准句入库"].ToString()),
                _baifenbishezhi = dr["百分比设置"].ToString()
            };
            return j;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">查询</param>
        /// <param name="leixing"></param>
        /// <returns></returns>
        public bool IsExist(string str, string leixing)
        {
            string str_md5 = Md5Helper.Md5(str);
            string str_sql = $"select count(*) from 查重工具库.{_geshiinfo._chachongku} where MD5='{str_md5}' and 类型='{leixing}'";
            int num = Convert.ToInt32(_mysql.ExecuteScalar(str_sql));
            return num > 0 ? true : false;

        }

        /// <summary>
        /// 获得字符串形式的待处理对象（全文，正文，标准段落，标准句）
        /// </summary>
        /// <param name="myword"></param>
        /// <param name="duixiang"></param>
        /// <returns></returns>
        public string GetPipeiduixiangStr(List<string> duixiang)
        {
            Aspose.Words.Document myword = new Document(_filename);
            List<string> result = new List<string>();
            foreach (string str in duixiang)
            {


                //对word中的所有自然段，通过格式等判断方式
                //获得全文
                if (str.Equals("全文"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            if (!para.Range.Text.Trim().Equals(string.Empty))
                            {
                                result.Add(para.Range.Text.Trim());
                            }
                        }
                    }
                }
                //获得正文
                else if (str.Equals("正文"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                            {
                                result.Add(para.Range.Text.Trim());
                            }
                        }
                    }
                }
                //else if (duixiang.Equals("文件名"))//获得文件名
                //{
                //    result.Add(Path.GetFileName(myword.OriginalFileName));

                //}
                //else if (duixiang.Equals("主标题"))//获得主标题
                //{
                //    List<Paragraph> list_para = new List<Paragraph>();
                //    //获得所有居中自然段，第一个就是主标题
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            if (!para.Range.Text.Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                //            {
                //                list_para.Add(para);
                //            }
                //        }
                //    }
                //    result.Add(list_para[0].Range.Text.Trim());
                //    //循环所有自然段，匹配正则表达式  第一章/编
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                //            {
                //                bool b = Regex.IsMatch(para.Range.Text.Trim(), $@"^第[\s\S]+[编章][\s\S]+");
                //                result.Add(para.Range.Text.Trim());
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("副标题"))//获得副标题
                //{
                //    List<Paragraph> list_para = new List<Paragraph>();
                //    //获得所有居中自然段，第一个就是主标题,其余为副标题
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            if (!para.Range.Text.Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                //            {
                //                list_para.Add(para);
                //            }
                //        }
                //    }
                //    for (int i = 1; i < list_para.Count; i++)
                //    {
                //        result.Add(list_para[i].Range.Text.Trim());
                //    }
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //判断结尾是否为标点
                //            bool jieweifuhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$");
                //            //判断段落的居中
                //            var alignment = para.ParagraphFormat.Alignment == ParagraphAlignment.Center;
                //            //判断是否以第一节
                //            bool kaitou1 = Regex.IsMatch(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                //            //是否以目录前言开始
                //            bool kaitou2 = Regex.IsMatch(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                //            //判断文字是否为空
                //            bool empty = para.Range.Text.Trim().Equals(string.Empty);
                //            if ((!empty && !alignment && !jieweifuhao) || kaitou1 || kaitou2)
                //            {
                //                result.Add(para.Range.Text.Trim());
                //            }
                //        }
                //    }

                //}
                //else if (duixiang.Equals("一级标题"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+、[\s\S]+(?![；。;])");
                //            //bool juhao = Regex.IsMatch(para.Range.Text, $@"!(?!<。)[\s\S]+(?!。)$");
                //            if (kaitou)
                //            {
                //                result.Add(para.Range.Text.Trim());
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("二级标题"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[(（][一二三四五六七八九十][)）][\s\S]+");
                //            // bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;]$");
                //            if (kaitou)
                //            {
                //                result.Add(para.Range.Text.Trim());
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("三级标题"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou1 = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+是要[\s\S]+");
                //            bool kaitou2 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+?[,，][\s\S]+");
                //            bool kaitou3 = Regex.IsMatch(para.Range.Text, $@"^首先[,，][\s\S]+");
                //            bool kaitou4 = Regex.IsMatch(para.Range.Text, $@"^其次[,，][\s\S]+");
                //            bool kaitou5 = Regex.IsMatch(para.Range.Text, $@"^[(（]\d+[)）][\s\S]+");
                //            bool kaitou6 = Regex.IsMatch(para.Range.Text, $@"^[(（][①②③④⑤⑥⑦⑧⑨⑩][)）][\s\S]+");
                //            bool kaitou7 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+?条[\s\S]+");
                //            bool kaitou8 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+?款[\s\S]+");
                //            bool kaitou9 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+?项[\s\S]+");
                //            if (kaitou1 || kaitou2 || kaitou3 || kaitou4 || kaitou5 || kaitou6 || kaitou7 | kaitou8 | kaitou9)
                //            {
                //                result.Add(para.Range.Text.Trim());
                //            }

                //        }
                //    }
                //}
                //else if (duixiang.Equals("正文纲要"))//全文纲要改名为正文纲要
                //{
                //    //暂时使用和一级标题完全相同的获得方式
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //判断标题级别是否为1
                //            bool jibie = para.ListFormat.ListLevelNumber == 1;
                //            if (jibie)
                //            {
                //                result.Add(para.Range.Text.Trim());
                //            }
                //        }
                //    }


                //}
                //else if (duixiang.Equals("一级标题纲要"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //判断标题级别是否为1
                //            bool jibie = para.ListFormat.ListLevelNumber == 1;
                //            if (jibie)
                //            {
                //                result.Add(para.Range.Text.Trim());
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("二级标题纲要"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //判断标题级别是否为2
                //            bool jibie = para.ListFormat.ListLevelNumber == 2;
                //            if (jibie)
                //            {
                //                result.Add(para.Range.Text);
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("三级标题纲要"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //判断标题级别是否为3
                //            bool jibie = para.ListFormat.ListLevelNumber == 3;
                //            if (jibie)
                //            {
                //                result.Add(para.Range.Text);
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("法条"))//推后开发
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {

                //        }
                //    }
                //}
                //else if (duixiang.Equals("政策文件条款"))//推后开发
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {

                //        }
                //    }
                //}
                //else if (duixiang.Equals("语义统计分析"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {

                //        }
                //    }
                //}
                //else if (duixiang.Equals("首段"))
                //{
                //    //获得所有居中自然段，第二个就是首段
                //    foreach (Section sec in myword.Sections)
                //    {
                //        for (int i = 0; i < sec.Body.Paragraphs.Count; i++)
                //        {
                //            bool center = sec.Body.Paragraphs[i].ParagraphFormat.Alignment == ParagraphAlignment.Center;
                //            bool empty = sec.Body.Paragraphs[i].Range.Text.Trim().Equals(string.Empty);
                //            if (!empty && center)
                //            {
                //                //获得下一段的文本，如果是空，就再向下滚动
                //                string nextparatext;
                //                do
                //                {
                //                    i++;
                //                    nextparatext = sec.Body.Paragraphs[i].Range.Text.Trim();
                //                } while (nextparatext.Equals(string.Empty));


                //                string md5 = Md5Helper.Md5(nextparatext);
                //                //判断是否在标准段中，如果在，提出，如果不在，判断是否加入到对应库中，并加入到解析对象中去
                //                string str_sql = $"select * from {fi._biaozhunduanku} where md5='{md5}'";
                //                int num = mysqlhelper.ExecuteNonQuery(str_sql);
                //                if (num == 0)//存在
                //                {
                //                    //判断是否写入对应的标准段库
                //                    if (fi._chachongmd5)
                //                    {
                //                        str_sql = $"insert into {fi._biaozhunduanku} values('{md5}')";
                //                        mysqlhelper.ExecuteNonQuery(str_sql);
                //                    }


                //                    result.Add(nextparatext);
                //                }
                //                break;
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("尾段"))
                //{
                //    var shouduan = myword.LastSection.Body.LastParagraph;
                //        result.Add(shouduan.Range.Text);
                //}
                //else if (duixiang.Equals("单句段"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //判断是否有句号
                //            bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+。[\S\s]");
                //            if (!juhao)
                //            {

                //                    result.Add(para.Range.Text);
                //            }
                //        }
                //    }
                //}
                else if (duixiang.Equals("普通标准段"))
                {
                    //获得首段
                    //string shouduan = string.Empty;
                    //foreach (Section sec in myword.Sections)
                    //{
                    //    for (int i = 0; i < sec.Body.Paragraphs.Count; i++)
                    //    {
                    //        bool center = sec.Body.Paragraphs[i].ParagraphFormat.Alignment == ParagraphAlignment.Center;
                    //        bool empty = sec.Body.Paragraphs[i].Range.Text.Trim().Equals(string.Empty);
                    //        if (!empty && center)
                    //        {
                    //            //获得下一段的文本，如果是空，就再向下滚动
                    //            string nextparatext;
                    //            do
                    //            {
                    //                i++;
                    //                nextparatext = sec.Body.Paragraphs[i].Range.Text.Trim();
                    //            } while (nextparatext.Equals(string.Empty));
                    //            shouduan = sec.Body.Paragraphs[i].Range.Text.Trim();
                    //            break;
                    //        }
                    //    }
                    //}
                    ////获得尾端
                    //string weiduan = myword.LastSection.Body.LastParagraph.Range.Text.Trim();


                    ////获得单据段
                    //List<string> list_danjuduan = new List<string>();
                    //foreach (Section sec in myword.Sections)
                    //{
                    //    foreach (Paragraph para in sec.Body.Paragraphs)
                    //    {
                    //        bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+。[\S\s]");
                    //        if (!juhao)
                    //        {
                    //            list_danjuduan.Add(para.Range.Text.Trim());
                    //        }
                    //    }
                    //}
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            string paratext = para.Range.Text.Trim();
                            //bool b1 = shouduan.Equals(paratext);
                            //bool b2 = weiduan.Equals(paratext);
                            //bool b3 = list_danjuduan.Contains(paratext);
                            //if (!b1 && !b2 && !b3)
                            //{
                            //    string md5 = Md5Helper.Md5(paratext);
                            //    //判断是否在标准段中，如果在，提出，如果不在，判断是否加入到对应库中，并加入到解析对象中去
                            //    string str_sql = $"select * from {fi._biaozhunduanku} where md5='{md5}'";
                            //    int num = mysqlhelper.ExecuteNonQuery(str_sql);
                            //    if (num == 0)//存在
                            //    {
                            //        //判断是否写入对应的标准段库
                            //        if (fi._chachongmd5)
                            //        {
                            //            str_sql = $"insert into {fi._biaozhunduanku} values('{md5}')";
                            //            mysqlhelper.ExecuteNonQuery(str_sql);
                            //        }


                            result.Add(paratext);
                            //    }
                            //}
                        }
                    }
                }
                //else if (duixiang.Equals("无标点标准句"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool juwei = Regex.IsMatch(para.Range.Text, $@"[\s\S]+(?![;。；……？！?!:])");
                //            if (!juwei)
                //            {
                //                string md5 = Md5Helper.Md5(para.Range.Text);
                //                //判断是否在标准段中，如果在，提出，如果不在，判断是否加入到对应库中，并加入到解析对象中去
                //                string str_sql = $"select * from {fi._biaozhunjuku} where md5='{md5}'";
                //                int num = mysqlhelper.ExecuteNonQuery(str_sql);
                //                if (num == 0)//存在
                //                {
                //                    //判断是否写入对应的库
                //                    if (fi._chachongmd5)
                //                    {
                //                        str_sql = $"insert into {fi._biaozhunjuku} values('{md5}')";
                //                        mysqlhelper.ExecuteNonQuery(str_sql);
                //                    }


                //                    result.Add(para.Range.Text);
                //                }
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("有标点标准句"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool juwei = Regex.IsMatch(para.Range.Text, $@"[\s\S]+(?![。……？！?!:])");
                //            if (juwei)
                //            {
                //                string md5 = Md5Helper.Md5(para.Range.Text);
                //                //判断是否在标准段中，如果在，提出，如果不在，判断是否加入到对应库中，并加入到解析对象中去
                //                string str_sql = $"select * from {fi._biaozhunjuku} where md5='{md5}'";
                //                int num = mysqlhelper.ExecuteNonQuery(str_sql);
                //                if (num == 0)//存在
                //                {
                //                    //判断是否写入对应的库
                //                    if (fi._chachongmd5)
                //                    {
                //                        str_sql = $"insert into {fi._biaozhunjuku} values('{md5}')";
                //                        mysqlhelper.ExecuteNonQuery(str_sql);
                //                    }


                //                    result.Add(para.Range.Text);
                //                }
                //                result.Add(para.Range.Text);
                //            }
                //        }
                //    }
                //}
                //else if (duixiang.Equals("段首标准句"))//需要写清楚
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //获得所有标准句,取第一个集合为段首标准句
                //            var matches = Regex.Matches(para.Range.Text, $@"[\s\S]+(?![。……？！?!:])");

                //            string md5 = Md5Helper.Md5(para.Range.Text);
                //            //判断是否在标准段中，如果在，提出，如果不在，判断是否加入到对应库中，并加入到解析对象中去
                //            string str_sql = $"select * from {fi._biaozhunjuku} where md5='{md5}'";
                //            int num = mysqlhelper.ExecuteNonQuery(str_sql);
                //            if (num == 0)//存在
                //            {
                //                //判断是否写入对应的库
                //                if (fi._chachongmd5)
                //                {
                //                    str_sql = $"insert into {fi._biaozhunjuku} values('{md5}')";
                //                    mysqlhelper.ExecuteNonQuery(str_sql);
                //                }


                //                result.Add(para.Range.Text);
                //            }



                //            result.Add(para.Range.Text);
                //        }
                //    }
                //}
                //else if (duixiang.Equals("首段标准句"))//需要写清楚
                //{
                //    string paratext = myword.FirstSection.Body.FirstParagraph.Range.Text;
                //    //获得所有标准句,取第一个集合为段首标准句
                //    var matches = Regex.Matches(paratext, $@"[\s\S]+(?![。……？！?!:])");
                //    foreach (string mystr in matches)
                //    {
                //        string md5 = Md5Helper.Md5(mystr);
                //        //判断是否在标准段中，如果在，提出，如果不在，判断是否加入到对应库中，并加入到解析对象中去
                //        string str_sql = $"select * from {fi._biaozhunjuku} where md5='{md5}'";
                //        int num = mysqlhelper.ExecuteNonQuery(str_sql);
                //        if (num == 0)//存在
                //        {
                //            //判断是否写入对应的库
                //            if (fi._chachongmd5)
                //            {
                //                str_sql = $"insert into {fi._biaozhunjuku} values('{md5}')";
                //                mysqlhelper.ExecuteNonQuery(str_sql);
                //            }


                //            result.Add(mystr);
                //        }
                //    }

                //}
                else if (duixiang.Equals("普通标准句"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //获得所有标准句,取第一个集合为段首标准句
                            var matches = Regex.Matches(para.Range.Text, $@"[\s\S]+(?![。……？！?!:])");
                            for (int i = 1; i < matches.Count; i++)
                            {
                                //string md5 = Md5Helper.Md5(matches[i].Value);
                                ////判断是否在标准段中，如果在，提出，如果不在，判断是否加入到对应库中，并加入到解析对象中去
                                //string str_sql = $"select * from {fi._biaozhunjuku} where md5='{md5}'";
                                //int num = mysqlhelper.ExecuteNonQuery(str_sql);
                                //if (num == 0)//存在
                                //{
                                //    //判断是否写入对应的库
                                //    if (fi._chachongmd5)
                                //    {
                                //        str_sql = $"insert into {fi._biaozhunjuku} values('{md5}')";
                                //        mysqlhelper.ExecuteNonQuery(str_sql);
                                //    }

                                result.Add(matches[i].Value);
                                //}
                            }
                        }
                    }
                }
                //else if (duixiang.Equals("文件名索引句"))
                //{
                //    string filename = myword.OriginalFileName;
                //    var matches = Regex.Matches(filename, $@"(?<[、，,。])[\s\S]+、?(?=[，,。、])");
                //    foreach (Match item in matches)
                //    {
                //        result.Add(item.Value);
                //    }
                //}
                //else if (duixiang.Equals("主标题索引据"))
                //{
                //    string mystr = string.Empty;
                //    bool get = false;//记录是否已经捕捉到第一个居中的自然段

                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //获得主标题
                //            if (!get && !para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                //            {
                //                if (Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$"))//判断结尾是否含有标点符号
                //                {
                //                    mystr += para.Range.Text;
                //                    get = true;//如果已经找到第一个居中不为零的自然段，那么就记录下来
                //                }
                //            }
                //            else if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                //            {
                //                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^第[\s\S]+[编章][\s\S]+");
                //                foreach (Match item in matches0)
                //                {
                //                    mystr += item.Value;
                //                }
                //            }
                //        }
                //    }
                //    //对主标题文本开始匹配
                //    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        result.Add(item.Value);
                //    }
                //}
                //else if (duixiang.Equals("副标题索引句"))
                //{
                //    string mystr = string.Empty;//用于记录副标题
                //    bool get1 = false;//记录是否已经捕捉到第一个居中的自然段
                //    bool get2 = false;//记录是否已经捕捉到第二个居中的自然段
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //判断结尾是否为标点
                //            bool jieweifuhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$");
                //            //判断段落的居中
                //            var alignment = para.ParagraphFormat.Alignment == ParagraphAlignment.Center;
                //            //判断是否以第一节
                //            bool kaitou1 = Regex.IsMatch(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                //            //是否以目录前言开始
                //            bool kaitou2 = Regex.IsMatch(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                //            //判断文字是否为空
                //            bool empty = para.Range.Text.Trim().Equals(string.Empty);
                //            if (!empty && alignment && jieweifuhao)
                //            {
                //                if (!get1)//判断和标记第一个居中自然段
                //                {
                //                    get1 = true;//如果已经找到第一个居中不为零的自然段，那么就记录下来
                //                }
                //                else if (!get2)
                //                {
                //                    mystr += para.Range.Text;
                //                    get2 = true;
                //                }

                //            }
                //            else if (kaitou1 && !jieweifuhao)
                //            {
                //                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                //                foreach (Match item in matches0)
                //                {
                //                    mystr += item.Value;
                //                }
                //            }
                //            else if (kaitou2 && !jieweifuhao)
                //            {
                //                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                //                foreach (Match item in matches0)
                //                {
                //                    mystr += item.Value;
                //                }
                //            }
                //        }
                //    }
                //    //对副标题文本开始匹配
                //    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        result.Add(item.Value);
                //    }
                //}
                //else if (duixiang.Equals("一级标题索引据"))
                //{
                //    string mystr = string.Empty;
                //    //获得一级标题
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+、[\s\S]+(?![；。;])");
                //            bool juhao = Regex.IsMatch(para.Range.Text, $@"!(?!<。)[\s\S]+(?!。)$");
                //            if (kaitou && juhao)
                //            {
                //                mystr += para.Range.Text;
                //            }
                //        }
                //    }
                //    //获得一级标题索引
                //    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        result.Add(item.Value);
                //    }


                //}
                //else if (duixiang.Equals("二级标题索引句"))
                //{
                //    string mystr = string.Empty;
                //    //获得二级标题
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[(（][一二三四五六七八九十][)）][\s\S]+");
                //            bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;]$");
                //            if (kaitou && juhao)
                //            {
                //                mystr += para.Range.Text;
                //            }
                //        }
                //    }
                //    //对二级标题开始匹配
                //    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        result.Add(item.Value);
                //    }
                //}
                //else if (duixiang.Equals("三级标题索引句"))
                //{
                //    string mystr = string.Empty;
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou1 = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+是要[\s\S]+");
                //            bool kaitou2 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+[,，][\s\S]+");
                //            bool kaitou3 = Regex.IsMatch(para.Range.Text, $@"^首先[\s\S]+");
                //            bool kaitou4 = Regex.IsMatch(para.Range.Text, $@"^其次[\s\S]+");
                //            bool kaitou5 = Regex.IsMatch(para.Range.Text, $@"^[(（]\d+[)）][\s\S]+");
                //            bool kaitou6 = Regex.IsMatch(para.Range.Text, $@"^[(（][①②③④⑤⑥⑦⑧⑨⑩][)）][\s\S]+");
                //            bool kaitou7 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+条[\s\S]+");
                //            bool kaitou8 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+款[\s\S]+");
                //            bool kaitou9 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+项[\s\S]+");
                //            if (kaitou1 || kaitou2 || kaitou3 || kaitou4 || kaitou5 || kaitou6 || kaitou7 | kaitou8 | kaitou9)
                //            {
                //                mystr += para.Range.Text;
                //            }

                //        }
                //    }
                //    //对三级标题开始匹配
                //    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        result.Add(item.Value);
                //    }
                //}
                //else if (duixiang.Equals("段首索引句"))
                //{
                //    //这里的段首索引句提取了整个文章的每一段的第一个索引句
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            var matches = Regex.Matches(para.Range.Text, $@"(?<=[、，,])[\s\S]+、?(?=[，,])");
                //            if (matches.Count > 0)
                //            {
                //                result.Add(matches[0].Value);

                //            }
                //        }
                //    }

                //}
                //else if (duixiang.Equals("法条索引句"))//以后在做
                //{

                //}
                //else if (duixiang.Equals("政策条款索引句"))//以后再做
                //{

                //}
                //else if (duixiang.Equals("普通索引句"))
                //{
                //    List<string> list_all = new List<string>();
                //    //获得全部的索引据
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            var matches0 = Regex.Matches(para.Range.Text, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //            foreach (Match item in matches0)
                //            {
                //                list_all.Add(item.Value);
                //            }
                //        }
                //    }

                //    //建立一个字段集合，存储之前获得的所有非普通索引据
                //    List<string> list = new List<string>();
                //    //获得文件名索引句
                //    string filename = myword.OriginalFileName;
                //    var matches = Regex.Matches(filename, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        list.Add(item.Value);
                //    }
                //    //获得主标题索引句
                //    string mystr = string.Empty;
                //    bool get = false;//记录是否已经捕捉到第一个居中的自然段
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //获得主标题
                //            if (!get && !para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                //            {
                //                if (Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$"))//判断结尾是否含有标点符号
                //                {
                //                    mystr += para.Range.Text;
                //                    get = true;//如果已经找到第一个居中不为零的自然段，那么就记录下来
                //                }
                //            }
                //            else if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                //            {
                //                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^第[\s\S]+[编章][\s\S]+");
                //                foreach (Match item in matches0)
                //                {
                //                    mystr += item.Value;
                //                }
                //            }
                //        }
                //    }
                //    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        list.Add(item.Value);
                //    }
                //    //获得副标题索引句
                //    mystr = string.Empty;//用于记录副标题
                //    bool get1 = false;//记录是否已经捕捉到第一个居中的自然段
                //    bool get2 = false;//记录是否已经捕捉到第二个居中的自然段
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            //判断结尾是否为标点
                //            bool jieweifuhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$");
                //            //判断段落的居中
                //            var alignment = para.ParagraphFormat.Alignment == ParagraphAlignment.Center;
                //            //判断是否以第一节
                //            bool kaitou1 = Regex.IsMatch(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                //            //是否以目录前言开始
                //            bool kaitou2 = Regex.IsMatch(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                //            //判断文字是否为空
                //            bool empty = para.Range.Text.Trim().Equals(string.Empty);
                //            if (!empty && alignment && jieweifuhao)
                //            {
                //                if (!get1)//判断和标记第一个居中自然段
                //                {
                //                    get1 = true;//如果已经找到第一个居中不为零的自然段，那么就记录下来
                //                }
                //                else if (!get2)
                //                {
                //                    mystr += para.Range.Text;
                //                    get2 = true;
                //                }

                //            }
                //            else if (kaitou1 && !jieweifuhao)
                //            {
                //                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                //                foreach (Match item in matches0)
                //                {
                //                    mystr += item.Value;
                //                }
                //            }
                //            else if (kaitou2 && !jieweifuhao)
                //            {
                //                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                //                foreach (Match item in matches0)
                //                {
                //                    mystr += item.Value;
                //                }
                //            }
                //        }
                //    }
                //    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        list.Add(item.Value);
                //    }
                //    //一级标题索引句
                //    mystr = string.Empty;
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+、[\s\S]+(?![；。;])");
                //            bool juhao = Regex.IsMatch(para.Range.Text, $@"!(?!<。)[\s\S]+(?!。)$");
                //            if (kaitou && juhao)
                //            {
                //                mystr += para.Range.Text;
                //            }
                //        }
                //    }
                //    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        list.Add(item.Value);
                //    }
                //    //二级标题索引句
                //    mystr = string.Empty;
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[(（][一二三四五六七八九十][)）][\s\S]+");
                //            bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;]$");
                //            if (kaitou && juhao)
                //            {
                //                mystr += para.Range.Text;
                //            }
                //        }
                //    }
                //    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        list.Add(item.Value);
                //    }
                //    //三级标题索引句
                //    mystr = string.Empty;
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            bool kaitou1 = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+是要[\s\S]+");
                //            bool kaitou2 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+[,，][\s\S]+");
                //            bool kaitou3 = Regex.IsMatch(para.Range.Text, $@"^首先[\s\S]+");
                //            bool kaitou4 = Regex.IsMatch(para.Range.Text, $@"^其次[\s\S]+");
                //            bool kaitou5 = Regex.IsMatch(para.Range.Text, $@"^[(（]\d+[)）][\s\S]+");
                //            bool kaitou6 = Regex.IsMatch(para.Range.Text, $@"^[(（][①②③④⑤⑥⑦⑧⑨⑩][)）][\s\S]+");
                //            bool kaitou7 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+条[\s\S]+");
                //            bool kaitou8 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+款[\s\S]+");
                //            bool kaitou9 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+项[\s\S]+");
                //            if (kaitou1 || kaitou2 || kaitou3 || kaitou4 || kaitou5 || kaitou6 || kaitou7 | kaitou8 | kaitou9)
                //            {
                //                mystr += para.Range.Text;
                //            }

                //        }
                //    }
                //    //对三级标题开始匹配
                //    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //    foreach (Match item in matches)
                //    {
                //        list.Add(item.Value);
                //    }
                //    //段首索引句
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            var matches0 = Regex.Matches(para.Range.Text, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                //            list.Add(matches[0].Value);
                //        }
                //    }
                //    //法条索引句，以后做
                //    //政策条款索引句，以后做
                //    //排除所有的非普通索引句
                //    foreach (string mystr1 in list_all)
                //    {
                //        if (!list.Contains(mystr1))
                //        {
                //            result.Add(mystr1);
                //        }
                //    }
                //}
                //else if (duixiang.Equals("顺数标准段"))
                //{
                //    List<string> list_paras = new List<string>();
                //    foreach (Section section in myword.Sections)
                //    {
                //        foreach (Paragraph para in section.Body.Paragraphs)
                //        {
                //            string paratext = para.Range.Text.Trim();
                //            if (!paratext.Equals(string.Empty))
                //            {
                //                list_paras.Add(paratext);
                //            }
                //        }
                //    }
                //    int z = shunshu + 1;
                //    result.Add(list_paras[z]);
                //}
                //else if (duixiang.Equals("倒数标准段"))
                //{
                //    List<string> list_paras = new List<string>();
                //    foreach (Section section in myword.Sections)
                //    {
                //        foreach (Paragraph para in section.Body.Paragraphs)
                //        {
                //            string paratext = para.Range.Text.Trim();
                //            if (!paratext.Equals(string.Empty))
                //            {
                //                list_paras.Add(paratext);
                //            }
                //        }
                //    }
                //    //把倒数转换成正数
                //    int d = list_paras.Count - daoshu + 1;

                //    result.Add(list_paras[d]);
                //}






            }
            string str_result = string.Join("\r\n", result);
            return str_result;
        }


        /// <summary>
        /// 计算标准段重复率
        /// </summary>
        public void CalDuanChongfulv()
        {
            string str_chongfu = string.Empty;
            //循环标准段，转为MD5 ，去库中查找，如果重复，记录字数和

            foreach (string str in list_biaozhunduan)
            {
                bool b = IsExist(str, "标准段");
                if (b)
                {
                str_chongfu += str;

                }
            }
            //用重复字数比全文字符数，得到重复率
            _duanchongfulv = Convert.ToDouble(100 * Convert.ToDouble(str_chongfu.Length) / Convert.ToDouble(_quanwen.Length));
        }
        /// <summary>
        /// 计算标准句重复率
        /// </summary>
        public void CalJuChongfulv()
        {
            string str_chongfu = string.Empty;
            //循环标准段，转为MD5 ，去库中查找，如果重复，记录字数和

            foreach (string str in list_biaozhunduan)
            {
                bool b = IsExist(str, "标准句");
                if (b)
                {
                    str_chongfu += str;

                }
            }
            //用重复字数比全文字符数，得到重复率
            _duanchongfulv = Convert.ToDouble(100 * Convert.ToDouble(str_chongfu.Length) / Convert.ToDouble(_quanwen.Length));


        }







    }
}
