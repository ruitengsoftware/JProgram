using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.IO;
using Spire.Xls;
using System.Text.RegularExpressions;
using Model;
using DLL;
using System.Data.OleDb;
using System.Threading;
using Spire.Doc.Fields;
using Spire.Doc.Collections;
using Spire.Doc;

namespace WindowsFormsApp2.UC
{
    public partial class UCExcelSplit : UserControl
    {
        DrawHelper mydrawer = new DrawHelper();
        bool isrun = true;

        public UCExcelSplit()
        {
            InitializeComponent();
        }


        private void label4_MouseEnter(object sender, EventArgs e)
        {
            mydrawer.MouseEnterRed((Control)sender);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            mydrawer.MouseLeaveRed((Control)sender);
        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect((Control)sender);
        }
        /// <summary>
        /// 拆分excel表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblcreate_Click(object sender, EventArgs e)
        {
            UpdateStatue("正在拆分Excel表……");

            Action a = () =>
            {

                //获得文件夹下所有得excel文件
                string path = tbqiefen.Text;
                List<string> list_file = new List<string>();
                GetFiles(new DirectoryInfo(path), "*.*", ref list_file);
                //拆分文件
                List<ExcelInfo> list_temp = new List<ExcelInfo>();
                for (int i = 0; i < list_file.Count; i++)
                {
                    list_temp = GetSplitExcel(list_file[i], Convert.ToInt32(tbnum.Text));
                    Global.list_splitfiles.AddRange(list_temp);
                }




                //显示任务列表
                dgv_task.Rows.Clear();
                for (int i = 0; i < Global.list_splitfiles.Count; i++)
                {
                    UpdateDgv(Global.list_splitfiles[i]);
                }
            };
            a.BeginInvoke(o =>
            {
                UpdateStatue("版权所有 深圳前海极简信息咨询服务有限公司");
            }, null);

        }
        private void UpdateDgv(ExcelInfo ei)
        {
            if (this.InvokeRequired)
            {

                Action<ExcelInfo> a = UpdateDgv;
                this.BeginInvoke(a, ei);
            }
            else
            {
                int index = dgv_task.Rows.Add();
                dgv_task.Rows[index].Cells[0].Value = index + 1;
                dgv_task.Rows[index].Cells[1].Value = ei._yuanwenjian;
                dgv_task.Rows[index].Cells[2].Value = ei._filename;
                dgv_task.Rows[index].Cells[3].Value = ei._hangshu;
            }
        }

        /// <summary>
        /// 获得拆分之后的若干表信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<ExcelInfo> GetSplitExcel(string path, int num)
        {
            List<ExcelInfo> list_result = new List<ExcelInfo>();
            string tablename = Path.GetFileNameWithoutExtension(path);
            DataTable dt = ExcelToDS(path,"select count(*) as total from ["+tablename+"$]");
            //Workbook mywbk = new Workbook();
            //mywbk.LoadFromFile(path);
            //Worksheet mysht = mywbk.Worksheets[0];
            int recordnum =Convert.ToInt32( dt.Rows[0]["total"].ToString());
            //获得拆分后的文件个数
            decimal filenum = Math.Ceiling(Convert.ToDecimal(recordnum) / Convert.ToDecimal(num));
            //获得扩展名
            string kuozhanming = Path.GetExtension(path);
            //获得不带扩展名的文件名
            string filename = System.IO.Path.GetFileNameWithoutExtension(path);
            //获得目录
            string directory = Path.GetDirectoryName(path);
            //获得切分后的文件名
            ExcelInfo ei = new ExcelInfo();
            for (int i = 0; i < filenum; i++)
            {
                ei = new ExcelInfo();
                ei._filename = directory + "\\" + filename + "_" + (i + 1) + kuozhanming;
                ei._hangshu = Convert.ToInt16(num);
                ei._yuanwenjian = path;
                ei._data = dt.Clone();
                for (int k = i*ei._hangshu; k < (i+1)*ei._hangshu; k++)
                {
                    ei._data.ImportRow(dt.Rows[k]);
                }
                list_result.Add(ei);
            }
            return list_result;
        }


        /// <summary>
        /// 获得指定目录下的所有文件，包括子目录
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="pattern"></param>
        /// <param name="fileList"></param>
        public void GetFiles(DirectoryInfo directory, string pattern, ref List<string> fileList)
        {
            if (directory.Exists || pattern.Trim() != string.Empty)
            {
                try
                {
                    foreach (FileInfo info in directory.GetFiles(pattern))
                    {
                        fileList.Add(info.FullName.ToString());
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                foreach (DirectoryInfo info in directory.GetDirectories())//获取文件夹下的子文件夹
                {
                    GetFiles(info, pattern, ref fileList);//递归调用该函数，获取子文件夹下的文件
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbqiefen.Text = fbd.SelectedPath;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbcunfang.Text = fbd.SelectedPath;
            }

        }

        private void UCExcelSplit_Load(object sender, EventArgs e)
        {
            cbbzongtigeshi.Items.Clear();
            //加载总体格式
            DBHelper mydbhelper = new DBHelper(Environment.CurrentDirectory + "\\ruitengdb.db");
            mydbhelper.Open();
            List<object> list_data = mydbhelper.ExecuteRow("select distinct totalname from tablesplit", null, null);
            foreach (object o in list_data)
            {
                Dictionary<string, object> dic = o as Dictionary<string, object>;
                cbbzongtigeshi.Items.Add(dic["totalname"]);
            }
            mydbhelper.Close();
            cbbzongtigeshi.SelectedIndex = 0;
        }

        private void lbldelete_Click(object sender, EventArgs e)
        {
            //加载总体格式
            DBHelper mydbhelper = new DBHelper(Environment.CurrentDirectory + "\\ruitengdb.db");
            mydbhelper.Open();
            List<object> list_data = mydbhelper.ExecuteRow("select distinct totalname from tablesplit", null, null);
            int num = mydbhelper.Delete("tablesplit", "totalname='" + cbbzongtigeshi.Text + "'", null);
            if (num > 0)
            {
                MessageBox.Show("删除格式成功！");
            }
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic = o as Dictionary<string, object>;
            //    cbbzongtigeshi.Items.Add(dic["totalname"]);
            //}

            //清空下拉菜单
            cbbzongtigeshi.Items.Clear();
            //获得所有的字段记录
            List<object> list_result = mydbhelper.ExecuteRow("select distinct totalname from tablesplit", null, null);
            foreach (object o in list_result)
            {
                Dictionary<string, object> dic0 = (Dictionary<string, object>)o;
                //添加进下拉菜单
                cbbzongtigeshi.Items.Add(dic0["totalname"].ToString());
            }
            //显示第一项
            cbbzongtigeshi.SelectedIndex = 0;
            mydbhelper.Close();
        }

        private void lblsave_Click(object sender, EventArgs e)
        {
            if (cbbzongtigeshi.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("总体格式名不许为空！");
                return;
            }

            string fieldstr = cbbzongtigeshi.Text;
            //打开数据库
            string dbfile = Environment.CurrentDirectory + @"\ruitengdb.db";
            DBHelper mysqliter = new DBHelper(dbfile);
            mysqliter.Open();
            //构造数据

            List<Dictionary<string, object>> list_dic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = null;
            for (int i = 0; i < myflp.Controls.Count; i++)
            {
                dic = new Dictionary<string, object>();
                //获得选中字段和全部字段
                List<string> list_allfields = new List<string>();
                List<string> list_selectfields = new List<string>();
                List<Control> list_control = new List<Control>();
                for (int j = 0; j < ((UCformate2w)myflp.Controls[i]).flp.Controls.Count; j++)
                {
                    list_allfields.Add(((UCformate2w)myflp.Controls[i]).flp.Controls[j].Text);
                    if (((UCformate2w)myflp.Controls[i]).flp.Controls[j].ForeColor == Color.White)//获得所有字段
                    {
                        list_selectfields.Add(((UCformate2w)myflp.Controls[i]).flp.Controls[j].Text);
                    }

                }
                List<string> list_titlefields = new List<string>();
                for (int k = 0; k < flpfield.Controls.Count; k++)
                {
                    if (flpfield.Controls[k].ForeColor == Color.White)
                    {
                        list_titlefields.Add(flpfield.Controls[k].Text);
                    }
                }
                dic["allfields"] = string.Join(",", list_allfields);
                dic["selectfields"] = string.Join(",", list_selectfields);
                dic["titlefields"] = string.Join(",", list_titlefields);
                dic["hangju"] = ((UCformate2w)myflp.Controls[i]).cbblinespace.Text;
                dic["hangjuvalue"] = ((UCformate2w)myflp.Controls[i]).nudlinespace.Value;
                dic["fontname"] = ((UCformate2w)myflp.Controls[i]).tbfontname.Text;
                dic["fontsize"] = ((UCformate2w)myflp.Controls[i]).nudfontsize.Value;
                dic["bold"] = ((UCformate2w)myflp.Controls[i]).cbbold.Checked;
                dic["position"] = ((UCformate2w)myflp.Controls[i]).cbbposition.Text;
                dic["space"] = ((UCformate2w)myflp.Controls[i]).cbbkonghang.Text;
                dic["suojin"] = ((UCformate2w)myflp.Controls[i]).nudsuojin.Value;
                dic["formatname"] = ((UCformate2w)myflp.Controls[i]).cbbformat.Text;
                dic["sort"] = i;
                dic["totalname"] = cbbzongtigeshi.Text;
                list_dic.Add(dic);
            }




            //判断词条数据是否存在
            List<object> list_result = mysqliter.ExecuteRow(string.Format("select * from tablesplit where totalname='{0}'", fieldstr), null, null);
            if (list_result.Count > 0)//如果存在这条记录，执行修改操作
            {
                mysqliter.Delete("tablesplit", string.Format("totalname='{0}'", fieldstr), null);
                //更新数据
            }


            for (int i = 0; i < list_dic.Count; i++)
            {
                //保存数据
                mysqliter.Save("tablesplit", list_dic[i]);
            }
            MessageBox.Show("保存数据成功！");

            //清空下拉菜单
            cbbzongtigeshi.Items.Clear();
            //获得所有的字段记录
            List<object> list_item = mysqliter.ExecuteRow("select distinct totalname from tablesplit", null, null);
            foreach (object o in list_item)
            {
                Dictionary<string, object> dic0 = (Dictionary<string, object>)o;
                //添加进下拉菜单
                cbbzongtigeshi.Items.Add(dic0["totalname"].ToString());
            }
            //显示第一项
            cbbzongtigeshi.SelectedIndex = 0;
        }

        private void cbbzongtigeshi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //加载总体格式
            DBHelper mydbhelper = new DBHelper(Environment.CurrentDirectory + "\\ruitengdb.db");
            mydbhelper.Open();
            List<object> list_data = mydbhelper.ExecuteRow("select * from tablesplit where totalname='" + cbbzongtigeshi.Text + "'", null, null);
            //加载段落
            myflp.Controls.Clear();
            foreach (object o in list_data)
            {
                UCformate2w uce2w = new UCformate2w(o);
                uce2w.Dock = DockStyle.Top;
                myflp.Controls.Add(uce2w);
            }
            //加载选中标题
            flpfield.Controls.Clear();
            Dictionary<string, object> dic = list_data[0] as Dictionary<string, object>;
            string[] arr_allfields = dic["allfields"].ToString().Split(new char[] { ',', '，' });
            for (int i = 0; i < arr_allfields.Length; i++)
            {
                Label lbl_field = new Label
                {
                    Text = arr_allfields[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 80,
                    Margin = new Padding(1, 1, 1, 1)
                };
                lbl_field.Click += Mylbl_Click;
                flpfield.Controls.Add(lbl_field);
            }
            string[] arr_title = dic["titlefields"].ToString().Split(new char[] { ',', '，' });
            foreach (Control c in flpfield.Controls)
            {
                if (arr_title.Contains(c.Text))
                {
                    c.BackColor = Color.SteelBlue;
                    c.ForeColor = Color.White;
                }
            }




            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic = o as Dictionary<string, object>;
            //    cbbzongtigeshi.Items.Add(dic["totalname"]);
            //}
            mydbhelper.Close();
        }

        public void Mylbl_Click(object sender, EventArgs e)
        {
            Label lbl = ((Label)sender);
            if (lbl.BackColor == Color.SteelBlue)
            {
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Black;
            }
            else
            {
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.SteelBlue;
            }
        }

        /// <summary>
        /// 更新状态栏文字
        /// </summary>
        /// <param name="str"></param>
        private void UpdateStatue(string str)
        {
            if (this.InvokeRequired)
            {
                Action<string> a = UpdateStatue;
                this.BeginInvoke(a, str);
            }
            else
            {
                lblstatue.Text = str;
            }
        }
        /// <summary>
        /// 从excel数据库提取数据
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public System.Data.DataTable ExcelToDS(string excelPath, string sqlstr)

        {
            DataSet ds = null;

            System.Data.DataTable dt = null;

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + excelPath + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            strExcel = sqlstr;//这里sheet1对应excel的工作表名称，一定要注意。
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            dt = ds.Tables[0];
            conn.Close();
            return dt;
        }

        private DataTable GetSplitDT(ExcelInfo ei)
        {
            //获得份文件编号
            string fileid = Regex.Match(ei._filename, @"(?<=_).+?(?=\.)").ToString();
            Workbook mywbk = new Workbook();
            mywbk.LoadFromFile(ei._yuanwenjian);
            string shtname = mywbk.Worksheets[0].Name;
            int startrow = (Convert.ToInt32(fileid) - 1) * ei._hangshu;
            DataTable dt = ExcelToDS(ei._yuanwenjian, string.Format("select * from [{0}$]", shtname));
            DataTable dt_result = dt.Clone();
            for (int i = startrow; i < startrow + ei._hangshu; i++)
            {
                try
                {
                    dt_result.ImportRow(dt.Rows[i]);
                }
                catch { }
            }
            return dt_result;
        }

        private void lblconvert_Click(object sender, EventArgs e)
        {
            //判断输出路径是否存在
            string importpath = tbcunfang.Text;
            if (!Directory.Exists(importpath))
            {
                MessageBox.Show("保存路径不存在！");
                return;
            }
           // UpdateStatue("正在提取文本格式……");
            /*识别所有的mycu*/
            UCformate2w myuc = null;

            for (int i = 0; i < myflp.Controls.Count; i++)
            {
                myuc = new UCformate2w();
                myuc = ((UCformate2w)myflp.Controls[i]);
                myuc.mysetter = new Model.setter();
                //给myuc的setter赋值
                for (int j = 0; j < myuc.flp.Controls.Count; j++)
                {
                    Label mylbl0 = ((Label)myuc.flp.Controls[j]);
                    if (mylbl0.BackColor == Color.SteelBlue)
                    {
                        myuc.mysetter.listcolumn.Add(mylbl0.TabIndex);
                    }
                }
                //myuc.mysetter.listcolumn = GetContent(tbfilename.Text, rowindex, myuc);
                myuc.mysetter.hangjustyle = myuc.cbblinespace.Text;
                myuc.mysetter.hangjuvalue = Convert.ToSingle(myuc.nudlinespace.Value);
                myuc.mysetter.fontname = myuc.tbfontname.Text;
                myuc.mysetter.fontsize = Convert.ToSingle(myuc.nudfontsize.Value);
                myuc.mysetter.juzhong = myuc.cbbposition.Text;
                myuc.mysetter.bold = myuc.cbbold.Checked ? 1 : 0;
                myuc.mysetter.suojin = Convert.ToSingle(myuc.nudsuojin.Value);
                myuc.mysetter.konghang = Convert.ToInt32(myuc.cbbkonghang.Text);
                //把uc提取到集合中
                Global.list_myuc.Add(myuc);
            }

            //接收选中的列用于文件名
            Label mylbl = null;
            for (int i = 0; i < flpfield.Controls.Count; i++)
            {
                mylbl = ((Label)flpfield.Controls[i]);
                if (mylbl.BackColor == Color.SteelBlue)
                {
                    Global.listfilename.Add(mylbl.TabIndex);
                }
            }
            Thread t = null;

            for (int m = 0; m < dgv_task.Rows.Count; m++)
            {
                try
                {
                    while (t.ThreadState == ThreadState.Running) Application.DoEvents();
                }
                catch { }
                t = new Thread(CreateDocument);
                t.Name = "thread_" + m;

                t.Start(Global.list_splitfiles[m]);

            }

            /*提示完成*/
            UpdateStatue("版权所有 深圳前海极简信息咨询服务有限公司！");
        }


        private void CreateDocument(object o)
        {
            ExcelInfo ei = o as ExcelInfo;

            dgv_task.Rows[ei._id - 1].Cells[4].Value = "正在准备";
            //获得 table
            DataTable dt_split = ei._data;
            //读取excel，得到行数
            /*生成一个新的word*/
            Spire.Doc.Document spdoc = new Spire.Doc.Document();
            /*循环把list中的mycu内容添加到word文档*/
            for (int rowindex = 0; rowindex < dt_split.Rows.Count; rowindex++)
            {
                dgv_task.Rows[ei._id - 1].Cells[4].Value = (100 * Convert.ToDecimal(rowindex + 1) / Convert.ToDecimal(dt_split.Rows.Count)).ToString("00.00") + "%";
                //更新状态栏文字
                //string str_statue = "正在生成第{0}个，共{1}个……";
                //UpdateStatue(string.Format(str_statue, rowindex - 1, lastrow - 1));
                ///载入一个空白文档
                spdoc.LoadFromFile(Environment.CurrentDirectory + @"\newdoc.docx");
                for (int i = Global.list_myuc.Count - 1; i >= 0; i--)
                {
                    //设置文本
                    string str_n = string.Empty;
                    //设置空行
                    for (int ji = 0; ji < Global.list_myuc[i].mysetter.konghang; ji++)
                    {
                        str_n += "\n";
                    }
                    //添加一个段落

                    Spire.Doc.Documents.Paragraph parainsert = spdoc.LastSection.AddParagraph();
                    //Spire.Doc.Documents.Paragraph parainsert = spdoc.CreateParagraph();
                    TextRange tx = parainsert.AppendText(GetContent(Global.list_myuc[i].mysetter.listcolumn, rowindex, dt_split) + str_n);
                    //字体名称
                    tx.CharacterFormat.FontName = Global.list_myuc[i].mysetter.fontname;
                    //字体大小
                    tx.CharacterFormat.FontSize = Global.list_myuc[i].mysetter.fontsize;
                    //设置行距
                    switch (Global.list_myuc[i].mysetter.hangjustyle)
                    {
                        case "单倍行距":
                            parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.AtLeast;
                            break;
                        case "1.5倍行距":
                            parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
                            break;
                        case "2倍行距":
                            parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Multiple;
                            break;
                        default:
                            parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
                            parainsert.Format.LineSpacing = Global.list_myuc[i].mysetter.hangjuvalue;
                            break;
                    }
                    //首行缩进
                    parainsert.Format.SetFirstLineIndent(Global.list_myuc[i].mysetter.suojin);//首行缩进
                                                                                              //粗体
                    tx.CharacterFormat.Bold = Global.list_myuc[i].mysetter.bold == 1 ? true : false;
                    switch (Global.list_myuc[i].mysetter.juzhong)
                    {
                        case "左对齐":
                            parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                            break;
                        case "居中":
                            parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                            break;
                        case "右对齐":
                            parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                            break;
                    }
                }

                SectionCollection sections = spdoc.Sections;
                //创建一个HeaderFooter类实例，添加页脚
                for (int i = 0; i < sections.Count; i++)
                {
                    sections[i].PageSetup.Margins.Top = 72f;
                    sections[i].PageSetup.Margins.Left = 90f;
                    sections[i].PageSetup.Margins.Bottom = 72f;
                    sections[i].PageSetup.Margins.Right = 90f;
                    Spire.Doc.HeaderFooter footer = sections[i].HeadersFooters.Footer;
                    Spire.Doc.Documents.Paragraph footerPara = footer.AddParagraph();

                    //添加字段类型为页码，添加当前页、分隔线以及总页数
                    footerPara.AppendField("页码", FieldType.FieldPage);
                    footerPara.AppendText(" / ");
                    footerPara.AppendField("总页数", FieldType.FieldNumPages);
                    footerPara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                }
                /*保存文档*/
                //组成文件名
                List<string> strfilename = new List<string>();
                for (int i = 0; i < Global.listfilename.Count; i++)
                {
                    string filename_element = Regex.Replace(dt_split.Rows[rowindex][Global.listfilename[i] + 1].ToString(), @"[\s/\:*?''<>|]", "");
                    strfilename.Add(filename_element);
                }
                spdoc.BuiltinDocumentProperties.Author = "潜挖智库";
                spdoc.SaveToFile(tbcunfang.Text + @"\" + string.Join("-", strfilename) + @".docx");
                spdoc.Close();
            }
        }


        /// <summary>
        /// 获得setter的content内容
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="row"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetContent(List<int> list, int row, DataTable dt)
        {
            //List<string> listresult = new List<string>();
            //Spire.Xls.Workbook mywbk = new Workbook();
            //mywbk.LoadFromFile(filename);
            //Worksheet mysht = mywbk.Worksheets[0];
            string result = string.Empty;

            for (int i = 0; i < list.Count; i++)
            {
                // listresult.Add(mysht.Range[row, list[i] + 1].Value);
                //result += mysht.Range[row, list[i] + 1].Value;
                result += dt.Rows[row][list[i]];
            }
            //string str = string.Join("\n", listresult);
            return result;
        }

    }
}
