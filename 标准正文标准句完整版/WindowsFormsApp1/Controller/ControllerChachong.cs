using Aspose.Words;
using Aspose.Words.Replacing;
using Common;
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
using WindowsFormsApp1.Controller;

namespace BLL
{
    public class ControllerChachong
    {
        SqliteHelper mysqliter = null;
        string dbfile = $"{Environment.CurrentDirectory}\\ruitengdb.db";
        Action<DataGridViewRow> a = new Action<DataGridViewRow>((o) => { });
        /// <summary>
        /// 是否终止查重
        /// </summary>
        public bool stop = false;
        public ControllerChachong()
        {
            mysqliter = new SqliteHelper(dbfile);
            mysqliter.Open();
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
        /// 获得word文档标题
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetTitle(string filename)
        {
            Aspose.Words.Document mydoc = new Aspose.Words.Document(filename);
            //获得标题和文本
            string text = mydoc.Range.Text;
            string title = Regex.Match(text, @"^\S*?\s").Value;
            return title;
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
            string zhengwen = Regex.Match(text, @"(?<=^\S*?\s)[\s\S]*$").Value;
            return zhengwen;
        }
        /// <summary>
        /// 获得数据库中所有数据表
        /// </summary>
        /// <returns></returns>
        public string[] GetTableName()
        {
            return chhelper.GetTablesName().ToArray();
            //return mysqliter.GetAllTableName().ToArray();

        }

        /// <summary>
        /// 获得一个文档内所有下划线的句子
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public List<string> GetRedLine(string filename)
        {
            List<string> list_result = new List<string>();
            Spire.Doc.Document mydoc = new Spire.Doc.Document(filename);
            //提取所有的标准句
            List<string> list_biaozhunju = GetBiaozhunJuFromFile(filename);
            foreach (string str0 in list_biaozhunju)
            {
                //过滤忽略词
                string str = Hulue(str0);
                var texts = mydoc.FindAllString(str, false, true);
                if (texts == null)
                {
                    continue;
                }
                foreach (TextSelection text in texts)
                {
                    var underline = text.GetAsOneRange().CharacterFormat.UnderlineStyle;
                    if (underline == UnderlineStyle.Double)
                    {
                        list_result.Add(str);
                    }
                }
            }
            return list_result;
        }

        /// <summary>
        /// 该方法用于将word文档内容拆分为标准句
        /// </summary>
        /// <param name="file">word文档fullname</param>
        /// <returns></returns>
        public List<string> GetBiaozhunJuFromFile(string file)
        {
            List<string> list_sentence = new List<string>();//用于接收标准句
            Aspose.Words.Document mydoc = new Aspose.Words.Document(file);
            //获得标题和文本
            string text = mydoc.Range.Text;
            MatchCollection mymc = Regex.Matches(text, @"[^。？！(……)：；:;]+?\r");
            //将主标题一级标题二级标题三级标题拆分为标准句
            foreach (Match item in mymc)
            {
                if (!item.Value.Trim().Equals(string.Empty))
                {
                    //忽略词，忽略句
                    list_sentence.Add(item.Value.Trim());

                }
            }
            //拆分正文为标准句添加到list中
            string zhengwen = Regex.Match(text, @"\r[\s\S]*$").Value.Trim();
            MatchCollection mc = Regex.Matches(zhengwen, @"[\s\S]*?(?=[。？！……：；:;\s])");
            foreach (Match item in mc)
            {
                if (!item.Value.Equals(string.Empty))
                {
                    list_sentence.Add(item.Value.Trim());
                }
            }
            return list_sentence;
        }
        /// <summary>
        /// 该方法从一个文本中拆分出标准句
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<string> GetBiaozhunJuFromStr(string str)
        {
            List<string> list_sentence = new List<string>();//用于接收标准句
            //获得标题和文本
            MatchCollection mymc = Regex.Matches(str, @"((?!。|？|！|……|：|；|:|;)\S)+?\s");
            //将主标题一级标题二级标题三级标题拆分为标准句
            foreach (Match item in mymc)
            {
                //忽略词，忽略句
                string parttern = @"[一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十]、|" +
                    @"[（(][一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十][)）]|" +
                    @"\d.\d.\d\.|" +
                    @"[（(]\d.\d.\d[)）]|" +
                    @"第[一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十]，|" +
                    "首先，|" +
                    "其次，|" +
                    "一方面，|" +
                    "另一方面，";
                string hulue = Regex.Replace(item.Value, parttern, "");
                list_sentence.Add(hulue);
            }

            //拆分正文为标准句添加到list中
            string zhengwen = Regex.Match(str, @"(?<=^\S*?\s)[\s\S]*$").Value;
            MatchCollection mc = Regex.Matches(zhengwen, @"\w*?[。？！……：；:;]");
            foreach (Match item in mc)
            {
                list_sentence.Add(item.Value);
            }
            return list_sentence;
        }
        /// <summary>
        /// 该方法用于查找标准句是否存在
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public bool IsExistSentence(string sentence)
        {
            bool exist = false;
            string str_sql = $"select * from {Setting._cijuchachongbiao} where 内容='{sentence}'";
            mysqliter.Open();
            List<object> num = mysqliter.ExecuteRow(str_sql, null, null);
            if (num.Count > 0)
            {
                exist = true;
            }
            return exist;
        }
        /// <summary>
        /// 该方法用于查找标准正文是否存在
        /// </summary>
        /// <param name="sentence">MD5加密后的正文编码</param>
        /// <returns></returns>
        public bool IsExistZhengwen(string sentence)
        {
            bool exist = false;

            try
            {
                mysqliter.Open();
                string str_sql = $"select * from {Setting._zhengwenchachongbiao} where bianhao='{sentence}'";
                var mydt = chhelper.GetDataFromTable(str_sql);
                if (mydt.Rows.Count > 0)
                {
                    exist = true;
                }
            }
            catch { }

            return exist;
        }
        /// <summary>
        /// 计算进度
        /// </summary>
        /// <param name="n"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public string GetJindu(int n, int total)
        {
            //获得进度赋值给字段
            double result = Convert.ToDouble(n) * 100 / Convert.ToDouble(total);
            string jindu = result.ToString("0.00") + "%";
            return jindu;
        }
        /// <summary>
        /// 加下划线，使用aspose类库
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="str"></param>
        public void RedLine2(string filename, string str)
        {
            Aspose.Words.Document aspdoc = new Aspose.Words.Document(filename);
            Regex regex = new Regex(str, RegexOptions.IgnoreCase);
            FindReplaceOptions options = new FindReplaceOptions();
            options.ReplacingCallback = new ReplaceEvaluatorFindAndRedLine();
            options.Direction = FindReplaceDirection.Backward;
            aspdoc.Range.Replace(regex, "", options);
            aspdoc.Save(filename);
        }
        /// <summary>
        /// 该方法用于去掉未使用正版spire而出现的水印
        /// </summary>
        /// <param name="filename">带水印的文件名</param>
        public void ClearShuiyin(string filename)
        {
            //去水印
            Aspose.Words.Document myaspdoc = new Aspose.Words.Document(filename);
            myaspdoc.FirstSection.Body.FirstParagraph.Remove();
            myaspdoc.Save(filename);
            myaspdoc = null;
        }
        /// <summary>
        /// 添加尾注
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="str"></param>
        public void AddWeizhu(string filename, string str)
        {
            //获得数据库中str对应的来源
            string str_sql = $"select 来源 from {Setting._cijuchachongbiao} where 内容='{Hulue(str.Trim())}'";
            Dictionary<string, object> dic = mysqliter.ExecuteRow(str_sql, null, null)[0] as Dictionary<string, object>;
            string laiyuan = dic["来源"].ToString();
            Spire.Doc.Document mydoc = new Spire.Doc.Document();
            mydoc.LoadFromFile(filename);
            TextSelection[] texts = mydoc.FindAllString(str, false, true);
            if (texts == null)
            {
                return;
            }
            //给所有查找到的文字添加脚注
            foreach (TextSelection item in texts)
            {
                //实例化一个脚注的同时，直接创建在指定textselection所在的段落
                Spire.Doc.Fields.Footnote footnote = item.GetAsOneRange().OwnerParagraph.AppendFootnote(Spire.Doc.FootnoteType.Endnote);
                //向脚注内添加文字
                footnote.TextBody.AddParagraph().AppendText(laiyuan);
                //获得这个自然段
                Spire.Doc.Documents.Paragraph mypara = item.GetAsOneRange().OwnerParagraph;
                //向这个段落内的子节点添加脚注
                mypara.ChildObjects.Insert(mypara.ChildObjects.IndexOf(item.GetAsOneRange()) + 1, footnote);
            }
            mydoc.SaveToFile(filename);
            mydoc.Dispose();
            //去水印
            ClearShuiyin(filename);
        }


        /// <summary>
        /// 计算从查重率
        /// </summary>
        /// <param name="n"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public string GetChongfulv(int n, int total)
        {
            //获得查重率赋值给字段
            //获得进度赋值给字段
            double result = Convert.ToDouble(n) * 100 / Convert.ToDouble(total);
            string jindu = result.ToString("0.00") + "%";
            return jindu;
        }

        /// <summary>
        /// 该方法用于标准句或正文入库
        /// </summary>
        /// <param name="dic"></param>
        public void Ruku(string tablename, Dictionary<string, object> dic)
        {
            mysqliter.Save(tablename, dic);
        }

        /// <summary>
        /// 从文件名中提取日期
        /// </summary>
        /// <param name="filename"></param>
        public string GetDateFromFilename(string filename)
        {
            string parttern = @"\d{4}年\d{1,2}月\d{1,2}日|\d{4}年\d月|\d{4}-\d{2}-\d{2}|\d{4}\.\d{2}\.\d{2}|\d{4}";
            string date = Regex.Match(filename, parttern).Value;
            if (date.Length == 4)
            {
                date += "年";
            }
            return date;

        }
        /// <summary>
        /// 热度加1
        /// </summary>
        /// <param name="neirong">语句热度</param>
        /// <returns></returns>
        public void ReduPlus(string neirong)
        {
            //获得热度，热度+1
            string str_sql = $"update 标准句表 set 热度=热度+1 where 内容='{neirong}'";
            mysqliter.ExecuteRow(str_sql, null, null);
        }

        /// <summary>
        /// 该方法用于忽略语句中的不必要词汇
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Hulue(string str)
        {
            string parttern = @"[一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十]、|" +
                    @"[（(][一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十][)）]|" +
                    @"\d.\d.\d\.|" +
                    @"[（(]\d.\d.\d[)）]|" +
                    @"第[一二三四五六七八九十]*[一二三四五六七八九十]*[一二三四五六七八九十]，|" +
                    "首先，|" +
                    "其次，|" +
                    "一方面，|" +
                    "另一方面，";
            string hulue = Regex.Replace(str, parttern, "");
            return hulue;
        }

        /// <summary>
        /// 将word文档保存到指定路径中,文档会根据是否添加重复率
        /// </summary>
        /// <param name="o">字典，包含完整文件名和重复率</param>
        public void SaveDocument(object o)
        {
            //将参数o里氏转换为所有的uctask
            DataGridViewRow myrow = o as DataGridViewRow;
            //获得文件名，保存路径，重复率，以及是否添加重复率的位置
            string filename = myrow.Cells["wendangming"].Value.ToString();
            string chongfulv = myrow.Cells["chongfulv"].Value.ToString();
            /*如果重复率是100%，保存到100文件夹下，如果add的值是true，要拼接一个新的名称
             如果position在前，那么重复率放在前面，否则放在后面，然后保存新的文件名到指定路径中
            */
            string oldname = Path.GetFileNameWithoutExtension(filename);
            string newname = string.Empty;

            if (Setting._qian)
            {
                oldname = chongfulv + oldname;
            }
            if (Setting._hou)
            {
                oldname = oldname + chongfulv;
            }


            string newfilename = oldname + Path.GetExtension(filename);

            Aspose.Words.Document mydoc = new Aspose.Words.Document(filename);

            if (chongfulv.Equals("100.00%"))
            {
                mydoc.Save($"{Setting._savepath100}\\{newfilename}");
            }
            else
            {
                mydoc.Save($"{Setting._savepath}\\{newfilename}");
            }



        }
        /// <summary>
        /// 删除word文档
        /// </summary>
        /// <param name="file"></param>
        public void DeleteFile(string file)
        {
            File.Delete(file);

        }

        /// <summary>
        /// 该方法用于删除数据库中的格式设置信息
        /// </summary>
        /// <param name="formatname"></param>
        public void DeleteFormat(string formatname)
        {
            //mysqliter.Open();
            //mysqliter.Delete("软件设置表", $"格式名称='{formatname}'");
            string str_sql = $"alter table tablesetting delete where geshimingcheng='{formatname}'";
            chhelper.SelectDB("default");
            chhelper.DoSQL(str_sql);

        }

        /// <summary>
        /// 该方法用于保存设置
        /// </summary>
        /// <param name="formatname"></param>
        public void SaveFormat(string sql)
        {
            chhelper.SelectDB("default");
            chhelper.DoSQL(sql);
        }


        ControllerClickhouse chhelper = new ControllerClickhouse();
        /// <summary>
        /// 获得软件设置表中的所有格式
        /// </summary>
        /// <returns></returns>
        public string[] GetFormat()
        {
            string str_sql = @"select distinct geshimingcheng from tablesetting";
            List<string> arr_format = chhelper.GetFormatsName();

            return arr_format.ToArray();
        }
        /// <summary>
        /// 该方法用于获得指定格式下所有设置
        /// </summary>
        /// <param name="formatname"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetSetting(string formatname)
        {
            string str_sql = $"select * from zhengwensetting where geshimingcheng='{formatname}'";
            chhelper.SelectDB("default");
            var dt = chhelper.GetDataFromTable(str_sql);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            DataRow mydr = dt.Rows[0];

            dic.Add("下划线", mydr["xiahuaxian"].ToString() == "1" ? true : false);
            dic.Add("正文查重", mydr["zhengwenchachong"].ToString() == "1" ? true : false);
            dic.Add("词句查重", mydr["cijuchachong"].ToString() == "1" ? true : false);
            dic.Add("尾注", mydr["weizhu"].ToString() == "1" ? true : false);
            dic.Add("重复率前", mydr["chongfulvqian"].ToString() == "1" ? true : false);
            dic.Add("重复率后", mydr["chongfulvhou"].ToString() == "1" ? true : false);
            dic.Add("删除100", mydr["shanchu100"].ToString() == "1" ? true : false);
            dic.Add("日志路径", mydr["rizhilujing"].ToString());

            dic.Add("路径100", mydr["lujing100"].ToString());
            dic.Add("路径非100", mydr["lujingfei100"].ToString());
            dic.Add("自动导出", mydr["zidongdaochu"].ToString() == "1" ? true : false);
            dic.Add("词句查重表", mydr["cijuchachongbiao"].ToString());
            dic.Add("正文查重表", mydr["zhengwenchachongbiao"].ToString());
            dic.Add("正文入库", mydr["zhengwenruku"].ToString() == "1" ? true : false);
            dic.Add("词句入库", mydr["cijuruku"].ToString() == "1" ? true : false);
            dic.Add("正文入库表", mydr["zhengwenrukubiao"].ToString());
            dic.Add("词句入库表", mydr["cijurukubiao"].ToString());
            dic.Add("日期", Convert.ToDateTime(mydr["shijian"].ToString()));
            return dic;
        }
        /// <summary>
        /// 该方法用于正文查重
        /// </summary>
        public void ZhengwenChachong(DataGridViewRow dgvrow, ref string chachonglv)
        {
            string filename = dgvrow.Cells["wendangming"].Value.ToString();
            string zhengwen = GetZhengwen(filename);
            string md5zhengwen = GenerateMD5(zhengwen);
            bool existzhengwen = IsExistZhengwen(md5zhengwen);
            if (existzhengwen)//如果正文存在于数据库
            {
                //显示查重进度
                dgvrow.Cells["jindu"].Value = "100.00%";
                Application.DoEvents();
                //显示重复率
                dgvrow.Cells["chongfulv"].Value = chachonglv = "重复";
                Application.DoEvents(); 



                if (Setting._shanchu100)
                {
                    File.Delete(filename);
                }
            }
            else//如果正文不在数据库内
            {
                //显示查重进度
                dgvrow.Cells["jindu"].Value = "100.00%";
                Application.DoEvents();
                //显示重复率
                dgvrow.Cells["chongfulv"].Value = chachonglv = "不重复";
                Application.DoEvents();
                if (!existzhengwen && Setting._zhengwenruku)//如果正文入库，那么入库正文
                {
                    //Dictionary<string, object> dic = new Dictionary<string, object>() {
                    //     {"编号",md5zhengwen },
                    //     {"来源",Path.GetFileName(filename) },
                    //    { "正文内容",zhengwen}
                    // };
                    string str_sql = $"insert into {Setting._zhengwenrukubiao} (bianhao,laiyuan,zhengwenneirong,shijian) values " +
                        $"('{md5zhengwen}','{Path.GetFileName(filename)}','{zhengwen}','{DateTime.Now.ToString("yyyy-MM-dd")}')";
                    chhelper.DoSQL(str_sql);
                     
                    //Ruku(Setting._zhengwenrukubiao, dic);
                }
            }
            if (Setting._daochu)
            {
                SaveDocument(dgvrow);
            }

        }

        /// <summary>
        /// 该方法用于词句查重
        /// </summary>
        public void CijuChachong(DataGridViewRow dgvrow)
        {
            string filename = dgvrow.Cells["wendangming"].Value.ToString();
            //获得正文内容（不包含标题）
            string zhengwen = GetZhengwen(filename);
            string md5zhengwen = GenerateMD5(zhengwen);
            //获得下划线的文字
            List<string> list_red = GetRedLine(filename);
            bool existzhengwen = IsExistZhengwen(md5zhengwen);
            if (existzhengwen)//如果标准正文存在
            {
                //显示查重进度
                dgvrow.Cells["jindu"].Value = "100.00%";
                Application.DoEvents();
                //显示重复率
                dgvrow.Cells["chongfulv"].Value = "100.00%";
                Application.DoEvents();
                //删除重复率100的文章,需要判断是否自动导出，以及是否选中了删除100重复文档
                if (Setting._shanchu100 && Setting._daochu)
                {
                    File.Delete(filename);
                }
            }
            else//如果标准正文不存在
            {
                if (!existzhengwen && Setting._zhengwenruku)//如果正文入库，那么入库正文
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>() {
                         {"编号",md5zhengwen },
                         {"来源",Path.GetFileName(filename) }
                     };
                    Ruku(Setting._zhengwenrukubiao, dic);
                }

                //2、在标准句表中进行词句查重
                //获得所有句子
                List<string> list_sentence = GetBiaozhunJuFromFile(filename);
                int repeatnum = 0;
                for (int i = 0; i < list_sentence.Count; i++)
                {
                    if (stop)//这里先判断用户是否手动停止了查重
                    {
                        break;
                    }
                    //判断该句是否重复
                    string str = Hulue(list_sentence[i]);
                    bool exist = IsExistSentence(str.Trim());

                    //记录重复句数
                    if (exist)
                    {
                        repeatnum++;
                    }

                    //增加热度，判断该句是否重复，如果已有下划线，则不计算热度
                    if (exist && !list_red.Contains(str))
                    {
                        ReduPlus(str);
                    }
                    //判断是否需要添加下划线并执行相关方法
                    if (exist && Setting._xiahuaxian)
                    {
                        RedLine2(filename, list_sentence[i]);
                    }
                    //判断是否需要添加尾注并执行相关方法
                    if (exist && Setting._weizhu)
                    {
                        AddWeizhu(filename, list_sentence[i].Trim());
                    }
                    //根据入库设置执行是否入库
                    if (!exist && Setting._cijuruku)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>() {
                            {"编号",GenerateMD5(str) },
                            {"来源",Path.GetFileName( filename)},
                             {"热度", 1},
                             {"内容",Regex.Replace( str.Trim(),@"。|？|！|……|：|；|:|;" ,"") },//这里需要对标准句处理一下，去掉尾部的标点，
                             {"时间",GetDateFromFilename(filename)}
                        };
                        Ruku(Setting._cijurukubiao, dic);
                    }
                    //显示查重进度
                    dgvrow.Cells["jindu"].Value = GetJindu(i + 1, list_sentence.Count);
                    Application.DoEvents();
                    //显示重复率
                    dgvrow.Cells["chongfulv"].Value = GetJindu(repeatnum, list_sentence.Count);
                    Application.DoEvents();
                }
                //删除重复率100的文章，满足条件删除100并且不到处
                if (Setting._shanchu100 && !Setting._daochu)
                {
                    File.Delete(filename);
                }
            }
            //判断是否导出文档
            if (Setting._daochu)
            {
                SaveDocument(dgvrow);
            }
        }
        /// <summary>
        /// 终止查重
        /// </summary>
        public void StopSearch()
        {
            stop = true;
        }

        /// <summary>
        /// 查重单行
        /// </summary>
        public void SearchRepeat(object o)
        {
            string starttime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
            int chongfunum = 0;//存储重复条数
            List<string> list_same = new List<string>();//存储重复文件
            /*由于同时存在停止查重的stopsearch方法，该方法通过改变stop的值来进行实现，为防止
            *为防止执行了一次stopsearch方法后无法重新查询，所以需要先重新赋值stop=false
            * 查重时分为两种情况，首先分离标题与正文，然后查找正文所转化的md5再标准正文表中的md5编号，如果
            * 存在那么进度显示为100%，重复率显示为100%（标准正文）
            * 如果不存在相同编号，那么连同标题进行正常的标准句查询，查询时更新进度与重复率
            * 判断setting中的设置是否入库，如果是的话需要将所有的不重复句子，以及md5加密后的正文添加进入数据库
            */
            DataGridViewRowCollection rows = o as DataGridViewRowCollection;
            DataGridViewRow myrow = null;
            //a = (row) =>
            // {

            stop = false;
            foreach (var item in rows)
            {
                if (stop)
                {
                    break;
                }
                myrow = item as DataGridViewRow;
                //在标准正文表中查找标准正文
                //这里需要修改，对每一行查重结束之后，需要返回
                if (Setting._zhengwenchachong)
                {
                    string chongfulv = string.Empty;
                    ZhengwenChachong(myrow, ref chongfulv);
                    if (chongfulv.Equals("重复"))//刷新重复条数
                    {
                        chongfunum++;
                        list_same.Add(myrow.Cells["wendangming"].Value.ToString());
                    }
                }
                if (Setting._cijuchachong)//选择词句查重时进行的流程
                {
                    CijuChachong(myrow);
                }
            }
            //写入查重日志
            StringBuilder mysb = new StringBuilder();
            string endtime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
            mysb.AppendLine($"{starttime}————{endtime}  {rows.Count}条  重复{chongfunum}条");
            list_same.ForEach((same) => { mysb.AppendLine($"{list_same.IndexOf(same)}.{same}"); });
            mysb.AppendLine();

            //获得查重日志，如果没有的话创建
            StreamWriter sw = new StreamWriter(Setting._rizhilujing, true);
            sw.WriteLine(mysb);
            sw.Flush();
            sw.Close();

            // };
            //a.BeginInvoke(myrow, null, null);
        }


        /// <summary>
        /// 获得日志历史记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetRizhiDT()
        {
            StreamReader sr = new StreamReader(Setting._rizhilujing);
            MatchCollection matches = Regex.Matches(sr.ReadToEnd(), @"\d{8}.*?重复\d*条");
            DataTable mydt = new DataTable();
            mydt.Columns.Add("时间");
            mydt.Columns.Add("任务数量");
            mydt.Columns.Add("重复数量");
            foreach (Match match in matches)
            {
                string record = match.Value;
                var newrow = mydt.NewRow();
                newrow["时间"] = Regex.Match(record, @"\d{8}[\s\S]*(?=\s)").Value;
                newrow["任务数量"] = Regex.Match(record, @"(?<=\s)\d*条").Value;
                newrow["重复数量"] = Regex.Match(record, @"重复\d*条").Value;
                mydt.Rows.Add(newrow);
            }
            return mydt;
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
        /// <summary>    
        /// 将指定运行的文本分成两个运行。    
        /// 在指定的运行之后插入新的运行。  
        /// </summary>    
        private static Run SplitRun(Run run, int position)
        {
            Run afterRun = (Run)run.Clone(true);
            afterRun.Text = run.Text.Substring(position);
            run.Text = run.Text.Substring(0, position);
            run.ParentNode.InsertAfter(afterRun, run);
            return afterRun;
        }

    }
}
