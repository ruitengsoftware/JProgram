using Aspose.Words;
using Aspose.Words.Replacing;
using Common;
using RuiTengDll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindowsFormsApp1.Common;

namespace WindowsFormsApp1.Controller
{
    public class ControllerTask
    {
        public string _chachonglv = string.Empty;
        public int _chongfushu = 0;
        public string _jindu = string.Empty;
        //public string dbfile = Environment.CurrentDirectory + "\\ruitengdb.db";
        //SqliteHelper mysqliter = null;
        ControllerClickhouse chhelper = null;
       public List<string> _list_same = new List<string>();


        public ControllerTask()
        {
            //mysqliter = new SqliteHelper(dbfile);
            //mysqliter.Open();
            chhelper = new ControllerClickhouse();
        }



        /// <summary>
        /// 获得word文档正文
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetZhengwen(string filename)
        {
            Aspose.Words.Document mydoc = new Aspose.Words.Document(filename);

            //获得标题和文本
            string text = mydoc.Range.Text;
            //string zhengwen = Regex.Match(text, @"(?<=^\S*?\s)[\s\S]*$").Value;

            string zhengwen = string.Empty;//存放正文内容
            //循环判断每一个自然段,选择正文

            foreach (Aspose.Words.Section mysec in mydoc.Sections)
            {
                foreach (Aspose.Words.Paragraph para in mysec.Body.Paragraphs)
                {
                    //1、居中并以\s结尾的段落

                    string str = para.GetText().Trim();
                    bool b = Regex.IsMatch(str, @"^[\s\S]*[。？！……：；:;)）]$");

                    bool yemei = para is Aspose.Words.HeaderFooter;//判断是否为页眉
                    if (!yemei && para.ParagraphFormat.Alignment != ParagraphAlignment.Center && b)
                    {
                        zhengwen += str;
                    }

                    //2、去掉所有空行空格\S
                    zhengwen = Regex.Replace(zhengwen, @"\s", "");
                }
            }
            ////把字符串内容转为二进制
            //zhengwen = String2Byte(zhengwen);
            return zhengwen;
        }
        /// <summary>
        /// 将字符串转成二进制
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string String2Byte(string s)
        {
            byte[] data = Encoding.Unicode.GetBytes(s);
            StringBuilder result = new StringBuilder(data.Length * 8);

            foreach (byte b in data)
            {
                result.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return result.ToString();
        }
        /// <summary>
        /// 将二进制转成字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Byte2String(string s)
        {
            System.Text.RegularExpressions.CaptureCollection cs =
                System.Text.RegularExpressions.Regex.Match(s, @"([01]{8})+").Groups[1].Captures;
            byte[] data = new byte[cs.Count];
            for (int i = 0; i < cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value, 2);
            }
            return Encoding.Unicode.GetString(data, 0, data.Length);
        }

        /// <summary>
        /// MD5字符串加密
        /// </summary>
        /// <param name="txt">需要加密的字符串</param>
        /// <returns>加密后字符串</returns>
        public string GenerateMD5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }


        /// <summary>
        /// 该方法用于给已经重复的句子添加尾注
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="content"></param>
        public void AddFooter(string filename, string content)
        {
            ////获得所有的标准句，如果标准句内容包括content，就添加脚注
            //Aspose.Words.Document mydoc = new Document(filename);
            //DocumentBuilder builder = new DocumentBuilder(mydoc);
            ////再标准句表中查找content的来源
            //string str_sql = $"select 来源 from 标准句表 where 内容='{Hulue(content.Trim())}'";
            //List<object> list_o = mysqliter.ExecuteRow(str_sql, null, null);
            //Dictionary<string, object> dic = list_o[0] as Dictionary<string, object>;
            //string laiyuan = dic["来源"].ToString();




            //NodeList nodes = mydoc.Document.SelectNodes(@"//Run");
            //string text = mydoc.Document.SelectSingleNode(@"//Run[2]").GetText();

            ////var nodess = from k in nodes
            ////             where k.Range.Text.Trim().Contains(content)
            ////             select k;
            ////nodess.ToList().ForEach(node =>
            ////{
            ////    builder.MoveTo(node);
            ////    builder.InsertFootnote(FootnoteType.Endnote, laiyuan);
            ////    EndnoteOptions option = mydoc.EndnoteOptions;
            ////    option.Position = EndnotePosition.EndOfSection;
            ////    ((Run)node).Font.HighlightColor = Color.Yellow;
            ////});

            ////option.StartNumber = 2;
            //mydoc.Save(filename);
        }

        //对单一文档进行查重，如果文档存在于数据库内，那么判断是否累计热度，如果不在数据库内，判断是否入库
        public void SearchSingle(string filename)
        {



            //获得正文
            string str_zhengwen = GetZhengwen(filename);
            //获得正文md5
            string str_md5 = GenerateMD5(str_zhengwen);
            //正文转二进制
            string str_erjinzhi = String2Byte(str_zhengwen);
            //判断正文是否存在
            bool b_exist = IsExistZhengwen(str_md5);
            //文章查重是一定要做的，所以可以选择的只有两项，一个是正文是否入库，一个是否累计热度

            if (b_exist)
            {
                _chongfushu++;
                _list_same.Add(filename);
                //判断是否累计热度,如果是的话讲此条数据插入数据库
                if (Setting._leijiredu)
                {
                    string str_sql = $"insert into {Setting._zhengwenrukubiao} (bianhao,laiyuan,zhengwenneirong,zhuanzailiang,shijian,riqi) values " +
                                           $"('{str_md5}','{Path.GetFileName(filename)}','{str_erjinzhi}',1,'{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}')";
                    chhelper.DoSQL(str_sql);
                }
            }
            else
            {
                //判断是否入库
                if (Setting._zhengwenruku)
                {
                        string str_sql = $"insert into {Setting._zhengwenrukubiao} (bianhao,laiyuan,zhengwenneirong,zhuanzailiang,shijian,riqi) values " +
                                               $"('{str_md5}','{Path.GetFileName(filename)}','{str_erjinzhi}',1,'{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}')";
                        chhelper.DoSQL(str_sql);
                }
            }

        }


        /// <summary>
        /// 该方法用于查找标准正文是否存在
        /// </summary>
        /// <param name="sentence">MD5加密后的正文编码</param>
        /// <returns></returns>
        public bool IsExistZhengwen(string md5)
        {
            bool exist = false;
            //mysqliter.Open();
            string str_sql = $"select * from {Setting._zhengwenchachongbiao} where bianhao='{md5}'";
            var dt = chhelper.GetDataFromTable(str_sql);
            int num = dt.Rows.Count;
            if (num > 0)
            {
                exist = true;
            }
            return exist;
        }


        public void SearchAll(string filename)
        {






        }




    }
}
