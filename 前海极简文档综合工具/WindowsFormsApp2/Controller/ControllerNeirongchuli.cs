
using Aspose.Words;
using Aspose.Words.Replacing;
//using Common.WinForm;
using Newtonsoft.Json;
using RuiTengDll;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Common;
using WindowsFormsApp2.DLL;
using Paragraph = Spire.Doc.Documents.Paragraph;




namespace WindowsFormsApp2.Controller
{
    public class ControllerNeirongchuli
    {
        private Action<DataGridViewRow> a;
        private string dbfile;
        public bool stop;
        private UIHelper uihelper;

       public MySqlHelper _sqlhelper = new MySqlHelper();






        public void AddWeizhu(string filename, string str)
        {
            Dictionary<string, object> dic = new Dictionary<string, object> {
                {"内容", this.Hulue(str.Trim())}
            };
            var list = _sqlhelper.GetAnySet(Setting._cijuchachongbiao, dic);
            string text = list[0]["来源"].ToString();
            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile(filename);
            TextSelection[] selectionArray = document.FindAllString(str, false, true);
            if (selectionArray != null)
            {
                TextSelection[] selectionArray2 = selectionArray;
                int index = 0;
                while (true)
                {
                    if (index >= selectionArray2.Length)
                    {
                        document.SaveToFile(filename);
                        document.Dispose();
                        this.ClearShuiyin(filename);
                        break;
                    }
                    TextSelection selection = selectionArray2[index];
                    Spire.Doc.Fields.Footnote entity = selection.GetAsOneRange().OwnerParagraph.AppendFootnote(Spire.Doc.FootnoteType.Endnote);
                    entity.TextBody.AddParagraph().AppendText(text);
                    Paragraph ownerParagraph = selection.GetAsOneRange().OwnerParagraph;
                    ownerParagraph.ChildObjects.Insert(ownerParagraph.ChildObjects.IndexOf(selection.GetAsOneRange()) + 1, entity);
                    index++;
                }
            }
        }
        public void CijuChachong(DataGridViewRow dgvrow)
        {
            string filename = dgvrow.Cells["wendangming"].Value.ToString();
            string zhengwen = this.GetZhengwen(filename);
            string sentence = this.GenerateMD5(zhengwen);
            List<string> redLine = this.GetRedLine(filename);
            bool flag = this.IsExistZhengwen(sentence);
            if (flag)
            {
                dgvrow.Cells["jindu"].Value = "100.00%";
                Application.DoEvents();
                dgvrow.Cells["chongfulv"].Value = "100.00%";
                Application.DoEvents();
                if (Setting._shanchu100 && Setting._daochu)
                {
                    File.Delete(filename);
                }
            }
            else
            {
                if (!flag && Setting._zhengwenruku)
                {
                    Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
                    dictionary1.Add("编号", sentence);
                    dictionary1.Add("来源", Path.GetFileName(filename));
                    Dictionary<string, object> dic = dictionary1;
                    this.Ruku(Setting._zhengwenrukubiao, dic);
                }
                List<string> biaozhunJuFromFile = this.GetBiaozhunJuFromFile(filename);
                int n = 0;
                int num2 = 0;
                while (true)
                {
                    bool flag12 = num2 < biaozhunJuFromFile.Count;
                    if (flag12)
                    {
                        bool stop = this.stop;
                        if (!stop)
                        {
                            string item = this.Hulue(biaozhunJuFromFile[num2]);
                            bool flag5 = this.IsExistSentence(item.Trim());
                            if (flag5)
                            {
                                n++;
                            }
                            if (flag5 && !redLine.Contains(item))
                            {
                                this.ReduPlus(item);
                            }
                            if (flag5 && Setting._xiahuaxian)
                            {
                                this.RedLine2(filename, biaozhunJuFromFile[num2]);
                            }
                            if (flag5 && Setting._weizhu)
                            {
                                this.AddWeizhu(filename, biaozhunJuFromFile[num2].Trim());
                            }
                            if (!flag5 && Setting._cijuruku)
                            {
                                Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
                                dictionary3.Add("编号", this.GenerateMD5(item));
                                dictionary3.Add("来源", Path.GetFileName(filename));
                                dictionary3.Add("转载量", 1);
                                dictionary3.Add("内容", Regex.Replace(item.Trim(), "。|？|！|……|：|；|:|;", ""));
                                dictionary3.Add("时间", this.GetDateFromFilename(filename));
                                Dictionary<string, object> dic = dictionary3;
                                this.Ruku(Setting._cijurukubiao, dic);
                            }
                            dgvrow.Cells["jindu"].Value = this.GetJindu(num2 + 1, biaozhunJuFromFile.Count);
                            Application.DoEvents();
                            dgvrow.Cells["chongfulv"].Value = this.GetJindu(n, biaozhunJuFromFile.Count);
                            Application.DoEvents();
                            num2++;
                            continue;
                        }
                    }
                    if (Setting._shanchu100 && !Setting._daochu)
                    {
                        File.Delete(filename);
                    }
                    break;
                }
            }
            if (Setting._daochu)
            {
                this.SaveDocument(dgvrow);
            }
        }




        public void ClearShuiyin(string filename)
        {
            Aspose.Words.Document document = new Aspose.Words.Document(filename);
            document.FirstSection.Body.FirstParagraph.Remove();
            document.Save(filename);
            document = null;
        }

        public void DeleteFile(string file)
        {
            File.Delete(file);
        }


        public void DeleteFormat(string formatname)
        {
            _sqlhelper.DeleteAnyFormat("模板名称", formatname, "模板信息表");
        }


        public string Dic2Json(object o) =>
    JsonConvert.SerializeObject(o);



        public string GenerateMD5(string txt)
        {
            string str;
            using (MD5 md = MD5.Create())
            {
                byte[] buffer2 = md.ComputeHash(Encoding.Default.GetBytes(txt));
                StringBuilder builder = new StringBuilder();
                int index = 0;
                while (true)
                {
                    if (index >= buffer2.Length)
                    {
                        str = builder.ToString();
                        break;
                    }
                    builder.Append(buffer2[index].ToString("x2"));
                    index++;
                }
            }
            return str;
        }

        public List<string> GetBiaozhunJuFromFile(string file)
        {
            List<string> list = new List<string>();
            string text = new Aspose.Words.Document(file).Range.Text;
            foreach (Match match in Regex.Matches(text, @"[^。？！(……)：；:;]+?\r"))
            {
                if (!match.Value.Trim().Equals(string.Empty))
                {
                    list.Add(match.Value.Trim());
                }
            }
            foreach (Match match2 in Regex.Matches(Regex.Match(text, @"\r[\s\S]*$").Value.Trim(), @"[\s\S]*?(?=[。？！……：；:;\s])"))
            {
                if (!match2.Value.Equals(string.Empty))
                {
                    list.Add(match2.Value.Trim());
                }
            }
            return list;
        }


        public List<string> GetBiaozhunJuFromStr(string str)
        {
            List<string> list = new List<string>();
            foreach (Match match in Regex.Matches(str, @"((?!。|？|！|……|：|；|:|;)\S)+?\s"))
            {
                string pattern = @"[一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十]、|[（(][一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十][)）]|\d.\d.\d\.|[（(]\d.\d.\d[)）]|第[一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十]，|首先，|其次，|一方面，|另一方面，";
                string item = Regex.Replace(match.Value, pattern, "");
                list.Add(item);
            }
            foreach (Match match2 in Regex.Matches(Regex.Match(str, @"(?<=^\S*?\s)[\s\S]*$").Value, @"\w*?[。？！……：；:;]"))
            {
                list.Add(match2.Value);
            }
            return list;
        }

        public string GetChongfulv(int n, int total) =>
    (((Convert.ToDouble(n) * 100.0) / Convert.ToDouble(total)).ToString("0.00") + "%");

        public string GetDateFromFilename(string filename)
        {
            string str3 = Regex.Match(Path.GetFileNameWithoutExtension(filename), @"\d{4}年\d{1,2}月\d{1,2}日|\d{4}年\d月|\d{4}-\d{2}-\d{2}|\d{4}\.\d{2}\.\d{2}|\d{4}").Value;
            if (str3.Length == 4)
            {
                str3 = str3 + "年";
            }
            if (str3.Equals(string.Empty))
            {
                str3 = DateTime.Now.ToString();
            }
            return str3;
        }
        public string[] GetFormat()
        {
            var list = _sqlhelper.GetSingleField("模板名称", "模板信息表");
            return list.ToArray();
        }

        public string GetJindu(int n, int total) =>
    (((Convert.ToDouble(n) * 100.0) / Convert.ToDouble(total)).ToString("0.00") + "%");

        public Dictionary<string, object> GetMuBan(string formatname)
        {
            Dictionary<string, object> dic = new Dictionary<string, object> { { "模板名称",formatname} };
            var list = _sqlhelper.GetAnySet("模板信息表", dic);
            return list[0];
        }

        public List<string> GetRedLine(string filename)
        {
            List<string> list = new List<string>();
            Spire.Doc.Document document = new Spire.Doc.Document(filename);
            foreach (string str in this.GetBiaozhunJuFromFile(filename))
            {
                string matchString = this.Hulue(str);
                TextSelection[] selectionArray = document.FindAllString(matchString, false, true);
                if (selectionArray != null)
                {
                    foreach (TextSelection selection in selectionArray)
                    {
                        if (selection.GetAsOneRange().CharacterFormat.UnderlineStyle == UnderlineStyle.Double)
                        {
                            list.Add(matchString);
                        }
                    }
                }
            }
            return list;
        }

        public DataTable GetRizhiDT()
        {
            MatchCollection matchs = Regex.Matches(new StreamReader(Setting._rizhilujing).ReadToEnd(), @"\d{8}.*?修改\d*条");
            DataTable table = new DataTable();
            table.Columns.Add("时间");
            table.Columns.Add("任务数量");
            table.Columns.Add("修改word文档数量");
            foreach (Match match in matchs)
            {
                string input = match.Value;
                DataRow row = table.NewRow();
                row["时间"] = Regex.Match(input, @"\d{8}[\s\S]*(?=\s)").Value;
                row["任务数量"] = Regex.Match(input, @"(?<=\s)\d*(?=条)").Value;
                row["修改word文档数量"] = Regex.Match(input, @"(?<=修改)\d*").Value;
                table.Rows.Add(row);
            }
            return table;
        }



        public string[] GetTableName()
        {
            Dictionary<string, object> dic = new Dictionary<string, object> { {"TABLE_SCHEMA", "documenttools"} };

            var list = _sqlhelper.GetSingleField("table_name", "information_schema.TABLES", dic);
            return list.ToArray();
        }

        public string GetTitle(string filename) =>
    Regex.Match(new Aspose.Words.Document(filename).Range.Text, @"^\S*?\s").Value;



        public string GetZhengwen(string filename)
        {
            Aspose.Words.Document document = new Aspose.Words.Document(filename);
            string text = document.Range.Text;
            string input = string.Empty;
            foreach (Aspose.Words.Section section in document.Sections)
            {
                foreach (Aspose.Words.Paragraph current in section.Body.Paragraphs)
                {
                    string str3 = current.GetText().Trim();
                    bool flag = Regex.IsMatch(str3, @"^[\s\S]*[。？！……：；:;)）]$");
                    bool flag2 = false;
                    if ((!flag2 && (current.ParagraphFormat.Alignment != ParagraphAlignment.Center)) & flag)
                    {
                        input = input + str3;
                    }
                    input = Regex.Replace(input, @"\s", "");
                }
            }
            return input;
        }


        public string Hulue(string str)
        {
            string pattern = @"[一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十]、|[（(][一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十][)）]|\d.\d.\d\.|[（(]\d.\d.\d[)）]|第[一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十]，|首先，|其次，|一方面，|另一方面，";
            return Regex.Replace(str, pattern, "");
        }


        public bool IsExistSentence(string sentence)
        {
            Dictionary<string, object> dic = new Dictionary<string, object> { {"内容",sentence } };
            var list = _sqlhelper.GetAnySet(Setting._cijuchachongbiao,dic);
            return list.Count > 0 ? true : false;
        }

        public bool IsExistZhengwen(string sentence)
        {
            Dictionary<string, object> dic = new Dictionary<string, object> { { "编号", sentence } };
            var list = _sqlhelper.GetAnySet(Setting._zhengwenchachongbiao, dic);
            return list.Count > 0 ? true : false;
        }
        private class ReplaceEvaluatorFindAndRedLine : IReplacingCallback
        {
            /// <summary>    
            /// Aspose.Words为每个匹配项查找并替换引擎调用此方法。    
            ///即使跨多个运行，此方法也会突出显示匹配字符串。
            /// </summary>    
            ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
            {
                // 这是一个Run节点，其中包含开始或完全匹配。  
                Node currentNode = e.MatchNode;
                // 第一次（可能是唯一一次）运行可以包含比赛前的文字，
                // 在这种情况下，有必要拆分运行。  
                if (e.MatchOffset > 0)
                    currentNode = SplitRun((Run)currentNode, e.MatchOffset);
                // 此数组用于存储匹配的所有节点以进一步突出显示。  
                ArrayList runs = new ArrayList();
                // 查找包含匹配字符串部分的所有运行。    
                int remainingLength = e.Match.Value.Length;
                while (
                (remainingLength > 0) &&
                (currentNode != null) &&
                (currentNode.GetText().Length <= remainingLength))
                {
                    runs.Add(currentNode);
                    remainingLength = remainingLength - currentNode.GetText().Length;
                    //选择下一个“运行”节点。
                    //必须循环，因为可能还有其他节点，例如BookmarkStart等。 
                    do
                    {
                        currentNode = currentNode.NextSibling;
                    }
                    while ((currentNode != null) && (currentNode.NodeType != NodeType.Run));
                }
                //如果剩余文本，则拆分包含该匹配项的最后一次运行。    
                if ((currentNode != null) && (remainingLength > 0))
                {
                    SplitRun((Run)currentNode, remainingLength);
                    runs.Add(currentNode);
                }
                //现在突出显示序列中的所有运行。
                foreach (Run run in runs)
                {
                    run.Font.UnderlineColor = Color.Red;
                    run.Font.Underline = Underline.Double;

                }
                //向替换引擎发出信号，表示什么都不做，因为我们已经完成了所有想要做的事情。
                return ReplaceAction.Skip;
            }
        }

        public void RedLine2(string filename, string str)
        {
            Aspose.Words.Document document = new Aspose.Words.Document(filename);
            Regex pattern = new Regex(str, RegexOptions.IgnoreCase);
            FindReplaceOptions options = new FindReplaceOptions
            {
                ReplacingCallback = new ReplaceEvaluatorFindAndRedLine(),
                Direction = FindReplaceDirection.Backward
            };
            document.Range.Replace(pattern, "", options);
            document.Save(filename);
        }

        public void ReduPlus(string neirong)
        {
            string sql = "update 标准句表 set 转载量=转载量+1 where 内容='" + neirong + "'";

            _sqlhelper.ExecuteSql(sql);
        }

        public void Ruku(string tablename, Dictionary<string, object> dic)
        {
            _sqlhelper.SaveAnyFormat(dic, "tablename");
        }

        public void SaveDocument(object o)
        {
            DataGridViewRow row = o as DataGridViewRow;
            string path = row.Cells["wendangming"].Value.ToString();
            string str2 = row.Cells["chongfulv"].Value.ToString();
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            if (Setting._qian)
            {
                fileNameWithoutExtension = str2 + fileNameWithoutExtension;
            }
            if (Setting._hou)
            {
                fileNameWithoutExtension = fileNameWithoutExtension + str2;
            }
            string str5 = fileNameWithoutExtension + Path.GetExtension(path);
            Aspose.Words.Document document = new Aspose.Words.Document(path);
            if (str2.Equals("100.00%"))
            {
                document.Save(Setting._savepath100 + @"\" + str5);
            }
            else
            {
                document.Save(Setting._savepath + @"\" + str5);
            }
        }

        public void SaveFormat(Dictionary<string, object> dic)
        {
            _sqlhelper.SaveAnyFormat(dic, "模板信息表");
        }

        //public void SearchRepeat(object o)
        //{
        //    string str = DateTime.Now.ToString("yyyyMMdd-HH:mm");
        //    int num = 0;
        //    List<string> list_same = new List<string>();
        //    DataGridViewRowCollection rows = o as DataGridViewRowCollection;
        //    DataGridViewRow dgvrow = null;
        //    foreach (UCDatabase database in Setting.list_ucdb)
        //    {
        //        int num2 = 0;
        //        database.BackColor = Color.LightSkyBlue;
        //        Setting._zhengwenchachongbiao = database.lbl_dbname.Text;
        //        this.stop = false;
        //        foreach (object obj2 in (IEnumerable)rows)
        //        {
        //            if (this.stop)
        //            {
        //                break;
        //            }
        //            dgvrow = obj2 as DataGridViewRow;
        //            if (Setting._zhengwenchachong)
        //            {
        //                string chachonglv = string.Empty;
        //                this.ZhengwenChachong(dgvrow, ref chachonglv);
        //                if (chachonglv.Equals("重复"))
        //                {
        //                    num++;
        //                    num2++;
        //                    list_same.Add(dgvrow.Cells["wendangming"].Value.ToString());
        //                }
        //            }
        //            if (Setting._cijuchachong)
        //            {
        //                this.CijuChachong(dgvrow);
        //            }
        //        }
        //        database.BackColor = Color.MediumSeaGreen;
        //        this.UpdateText(database.lbl_chongfu, num2);
        //    }
        //    StringBuilder mysb = new StringBuilder();
        //    string str2 = DateTime.Now.ToString("yyyyMMdd-HH:mm");
        //    mysb.AppendLine($"{str}————{str2}  {rows.Count}条  重复{num}条");
        //    list_same.ForEach(same => mysb.AppendLine($"{list_same.IndexOf(same)}.{same}"));
        //    mysb.AppendLine();
        //    StreamWriter writer = new StreamWriter(Setting._rizhilujing, true);
        //    writer.WriteLine(mysb);
        //    writer.Flush();
        //    writer.Close();
        //}


        public void SortDateStr(ref string strdate)
        {
            List<DateTime> values = new List<DateTime>();
            string[] strArray = Regex.Split(strdate, @"\r\n");
            int index = 0;
            while (true)
            {
                if (index >= strArray.Length)
                {
                    values.Sort();
                    strdate = string.Join<DateTime>("\r\n", values);
                    return;
                }
                DateTime item = Convert.ToDateTime(strArray[index]);
                values.Add(item);
                index++;
            }
        }

        private static Run SplitRun(Run run, int position)
        {
            Run newChild = (Run)run.Clone(true);
            newChild.Text = run.Text.Substring(position);
            run.Text = run.Text.Substring(0, position);
            run.ParentNode.InsertAfter(newChild, run);
            return newChild;
        }

        public void StopSearch()
        {
            this.stop = true;
        }



        public void UpdateText(Control c, int str)
        {
            if (!c.InvokeRequired)
            {
                c.Text = str.ToString() + " 条重复";
            }
            else
            {
                Action<Control, int> method = new Action<Control, int>(this.UpdateText);
                object[] args = new object[] { c, str };
                c.BeginInvoke(method, args);
            }
        }

        public void ZhengwenChachong(DataGridViewRow dgvrow, ref string chachonglv)
        {
            if (!(dgvrow.DefaultCellStyle.BackColor == Color.DarkOrange))
            {
                string filename = dgvrow.Cells["wendangming"].Value.ToString();
                string zhengwen = this.GetZhengwen(filename);
                string sentence = this.GenerateMD5(zhengwen);
                bool flag = this.IsExistZhengwen(sentence);
                if (!flag)
                {
                    dgvrow.Cells["jindu"].Value = "100.00%";
                    Application.DoEvents();
                    dgvrow.Cells["chongfulv"].Value = chachonglv = "不重复";
                    Application.DoEvents();
                    if (!flag && Setting._zhengwenruku)
                    {
                        Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
                        dictionary3.Add("编号", sentence);
                        dictionary3.Add("来源", Path.GetFileNameWithoutExtension(filename));
                        dictionary3.Add("正文内容", zhengwen);
                        dictionary3.Add("日期", this.GetDateFromFilename(filename));
                        dictionary3.Add("转载量", 1);
                        Dictionary<string, object> dic = dictionary3;
                        this.Ruku(Setting._zhengwenrukubiao, dic);
                    }
                }
                else
                {
                    dgvrow.Cells["jindu"].Value = "100.00%";
                    Application.DoEvents();
                    dgvrow.Cells["chongfulv"].Value = chachonglv = "重复";
                    Application.DoEvents();
                    var list = _sqlhelper.GetAnySet(Setting._zhengwenchachongbiao, new Dictionary<string, object> { {"编号",sentence } });
                    string str4 = list[0]["编号"].ToString();

                    //int num = Convert.ToInt32((this.mysqliter.ExecuteRow(string.Concat(textArray2), null, null)[0] as Dictionary<string, object>)["转载量"].ToString());
                    int num = Convert.ToInt32(list[0]["转载量"]);
                    //string[] textArray3 = new string[] { "select * from ", Setting._zhengwenchachongbiao, " where 编号='", sentence, "'" };
                    string input = list[0]["来源"].ToString();
                    //string[] textArray4 = new string[] { "select * from ", Setting._zhengwenchachongbiao, " where 编号='", sentence, "'" };
                    string strdate = list[0]["日期"].ToString();
                    if (!Regex.Split(input, @"\r\n").ToList<string>().Contains(Path.GetFileNameWithoutExtension(filename)))
                    {
                        num++;
                        input = input + "\r\n" + Path.GetFileNameWithoutExtension(filename);
                        string dateFromFilename = this.GetDateFromFilename(filename);
                        strdate = strdate + "\r\n" + dateFromFilename;
                        this.SortDateStr(ref strdate);
                        Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
                        dictionary1.Add("转载量", num);
                        dictionary1.Add("来源", input);
                        dictionary1.Add("日期", strdate);
                        dictionary1.Add("编号",sentence);
                        Dictionary<string, object> entity = dictionary1;
                        //删除正文
                        _sqlhelper.DeleteAnyFormat("编号", sentence, Setting._zhengwenchachongbiao);
                        //插入正文
                        _sqlhelper.SaveAnyFormat(entity, Setting._zhengwenchachongbiao);


                    }
                    if (Setting._shanchu100)
                    {
                        File.Delete(filename);
                        dgvrow.DefaultCellStyle.BackColor = Color.DarkOrange;
                        dgvrow.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
                if (Setting._daochu)
                {
                    this.SaveDocument(dgvrow);
                }
            }
        }















    }
}
