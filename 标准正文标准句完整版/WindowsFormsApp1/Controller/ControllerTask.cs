using Aspose.Words;
using Aspose.Words.Replacing;
using Common;
using RuiTengDll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class ControllerTask
    {
        public string _chachonglv = string.Empty;
        public string _jindu = string.Empty;
        public string dbfile = Environment.CurrentDirectory + "\\ruitengdb.db";
        SqliteHelper mysqliter = null;


        public ControllerTask()
        {
            mysqliter = new SqliteHelper(dbfile);
            mysqliter.Open();
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







    }
}
