using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Spire.Xls;
using System.Text.RegularExpressions;
using Model;

using System.Data.OleDb;
using System.Threading;
using Spire.Doc.Fields;
using Spire.Doc.Collections;
using Spire.Doc;
using Word = Microsoft.Office.Interop.Word;
using Spire.Doc.Documents;
using WinFormSearchRepeat.WinForm;
using Aspose.Words;
using RuiTengDll;
using WindowsFormsApp2.Controller;
using MySql.Data.MySqlClient;
using Aspose.Words.Replacing;
using System.Collections;

namespace WindowsFormsApp2.UC
{
    public partial class UCExcelSplit : UserControl
    {

        string myfolder = string.Empty;
        UIHelper mydrawer = new UIHelper();
        WordHelper myworder = new WordHelper();
        bool isrun = true;
        /// <summary>
        /// 保存切分为后的文件夹路径
        /// </summary>
        string savepath = string.Empty;
        ControllerSplitExcel _mycontroller = new ControllerSplitExcel();
        public UCExcelSplit()
        {
            InitializeComponent();
            //向标题和正文添加ucformat
            for (int i = 0; i < mytabcontrol.TabPages.Count - 1; i++)
            {
                UCFormat ucformat = new UCFormat();
                ucformat.Dock = DockStyle.Fill;
                mytabcontrol.TabPages[i].Controls.Add(ucformat);
            }
            //添加标注控件
            UCBiaozhu myuc = new UCBiaozhu() { Dock = DockStyle.Fill };
            tabControl1.TabPages["wenbenbiaozhu"].Controls.Add(myuc);


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
            if (list_fields.Count == 0)
            {
                MessageBox.Show("没有可以用来生成内容的字段！");
                return;
            }
            UCformate2w mycu = new UCformate2w(list_fields);
            mycu.Dock = DockStyle.Top;
            myflp.Controls.Add(mycu);

        }
        private void ClearDGV(DataGridView dgv)
        {
            if (this.InvokeRequired)
            {

                Action<DataGridView> a = ClearDGV;
                this.BeginInvoke(a, dgv);
            }
            else
            {
                dgv.Rows.Clear();
            }

        }

        private void UpdateDgv(List<string> list)
        {
            if (this.InvokeRequired)
            {

                Action<List<string>> a = UpdateDgv;
                this.BeginInvoke(a, list);
            }
            else
            {
                dgv_task.Rows.Clear();
                int index = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Trim().Equals(string.Empty))
                    {
                        continue;
                    }
                    index = dgv_task.Rows.Add();
                    dgv_task.Rows[index].Cells["xuhao"].Value = index + 1;
                    dgv_task.Rows[index].Cells["biaomingcheng"].Value = list[i];
                }

            }
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
                dgv_task.Rows[index].Cells[0].Value = ei._id;
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
            DataTable dt = ExcelToDS(path, "select * from [" + tablename + "$]");
            //Workbook mywbk = new Workbook();
            //mywbk.LoadFromFile(path);
            //Worksheet mysht = mywbk.Worksheets[0];
            int recordnum = dt.Rows.Count;
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
                for (int k = i * ei._hangshu; k < (i + 1) * ei._hangshu; k++)
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
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    tbqiefen.Text = fbd.SelectedPath;
            //}
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbcunfang.Text = fbd.SelectedPath;
            }

        }
        /// <summary>
        /// 窗体加载时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCExcelSplit_Load(object sender, EventArgs e)
        {
            cbbzongtigeshi.Items.Clear();
            cbbzongtigeshi0.Items.Clear();
            //加载文件切割格式名



            //List<object> list_data = mysqliter.ExecuteRow("select distinct totalname from tablesplit", null, null);
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic = o as Dictionary<string, object>;
            //    cbbzongtigeshi.Items.Add(dic["totalname"]);
            //}
            //加载格式调整名
            //list_data = mysqliter.ExecuteRow("select distinct ttname from tabletotalformat", null, null);
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic = o as Dictionary<string, object>;
            //    cbbzongtigeshi0.Items.Add(dic["ttname"]);
            //}
            //加载页边距格式名
            //list_data = mysqliter.ExecuteRow("select * from tablepagemargin", null, null);
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic = o as Dictionary<string, object>;
            //    cbbbianju.Items.Add(dic["name"]);
            //}

            //加载批量改名文件名
            //获得所有的字段记录

            //list_data = mysqliter.ExecuteRow("select * from tablefield", null, null);
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic0 = (Dictionary<string, object>)o;
            //    //添加进下拉菜单
            //    cbbfield.Items.Add(dic0["fieldname"].ToString());
            //}

            //加载页眉设置的格式
            //list_data = mysqliter.ExecuteRow("select distinct * from tableformat where fposition='yemei'", null, null);
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic0 = (Dictionary<string, object>)o;
            //    //添加进下拉菜单
            //    cbbymname.Items.Add(dic0["fname"].ToString());
            //}
            //加载页脚设置的格式
            //list_data = mysqliter.ExecuteRow("select distinct * from tableformat where fposition='yejiao'", null, null);
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic0 = (Dictionary<string, object>)o;
            //    //添加进下拉菜单
            //    cbbyjname.Items.Add(dic0["fname"].ToString());
            //}
            //加载页码设置的格式
            //list_data = mysqliter.ExecuteRow("select distinct * from tablepage", null, null);
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic0 = (Dictionary<string, object>)o;
            //    //添加进下拉菜单
            //    cbb_page.Items.Add(dic0["pagename"].ToString());
            //}
            //加载页眉页脚设置的格式
            //list_data = mysqliter.ExecuteRow("select * from tableyemeiyejiao", null, null);
            //foreach (object o in list_data)
            //{
            //    Dictionary<string, object> dic0 = (Dictionary<string, object>)o;
            //    //添加进下拉菜单
            //    cbbyemeiyejiao.Items.Add(dic0["name"].ToString());
            //}

            //加载一站式总格式
            //try
            //{
            //    /**/
            //    //打开数据库
            //    string dbfile = Environment.CurrentDirectory + @"\ruitengdb.db";
            //    mysqliter = new MySqlHelper(dbfile);
            //    mysqliter.Open();
            //    List<object> list_result = new List<object>();


            //    /*加载一站格式*/
            //    list_result = mysqliter.ExecuteRow("select * from tableyizhangeshi", null, null);
            //    foreach (object o in list_result)
            //    {
            //        Dictionary<string, object> dic0 = (Dictionary<string, object>)o;
            //        //添加进下拉菜单
            //        cbb_yizhangeshi.Items.Add(dic0["yizhanshiname"].ToString());
            //    }
            //    cbb_yizhangeshi.SelectedIndex = 0;

            //}
            //catch { }

            //mysqliter.Close();
        }
        /// <summary>
        /// 点击删除按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbldelete_Click(object sender, EventArgs e)
        {
            //加载总体格式
            string format = cbbzongtigeshi.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("totalname", format, "tablesplit");
            MessageBox.Show("删除格式成功！");

        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblsave_Click(object sender, EventArgs e)
        {
            if (cbbzongtigeshi.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("总体格式名不许为空！");
                return;
            }

            string fieldstr = cbbzongtigeshi.Text;
            List<Dictionary<string, object>> list_dic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = null;
            for (int i = 0; i < myflp.Controls.Count; i++)
            {
                dic = new Dictionary<string, object>();
                //获得选中字段和全部字段
                List<string> list_allfields = new List<string>();//存放excel表的全部字段，用于生成内容
                List<string> list_selectfields = new List<string>();//存放excel表的选中字段，用于生成内容
                List<Control> list_control = new List<Control>();
                for (int j = 0; j < ((UCformate2w)myflp.Controls[i]).flp.Controls.Count; j++)
                {
                    list_allfields.Add(((UCformate2w)myflp.Controls[i]).flp.Controls[j].Text);//获得所有字段
                    if (((UCformate2w)myflp.Controls[i]).flp.Controls[j].ForeColor == Color.White)
                    {
                        list_selectfields.Add(((UCformate2w)myflp.Controls[i]).flp.Controls[j].Text);//根据颜色判断获得了选中字段
                    }
                }
                List<string> list_alltitle = new List<string>();//存放excel表的全部字段，用于生成内容
                List<string> list_titlefields = new List<string>(); //存放excel表的选中字段，用于生成内容
                for (int k = 0; k < flpfield.Controls.Count; k++)
                {
                    Label mylbl = ((UCStep)flpfield.Controls[k]).lbl_text;
                    list_alltitle.Add(mylbl.Text);
                    if (mylbl.ForeColor == Color.White)
                    {
                        list_titlefields.Add(mylbl.Text);
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
                dic["myposition"] = ((UCformate2w)myflp.Controls[i]).cbbposition.Text;
                dic["myspace"] = ((UCformate2w)myflp.Controls[i]).cbbkonghang.Text;
                dic["suojin"] = ((UCformate2w)myflp.Controls[i]).nudsuojin.Value;
                dic["formatname"] = ((UCformate2w)myflp.Controls[i]).cbbformat.Text;
                dic["sort"] = i;
                dic["totalname"] = cbbzongtigeshi.Text;
                dic["alltitle"] = string.Join(",", list_alltitle);
                list_dic.Add(dic);
            }
            _mycontroller.SaveFormat(list_dic);
            MessageBox.Show("保存数据成功！");
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
        /// <summary>
        /// 点击开始转化按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblconvert_Click(object sender, EventArgs e)
        {
            //判断输出路径是否存在
            string importpath = tbcunfang.Text;
            if (!Directory.Exists(importpath))
            {
                MessageBox.Show("保存路径不存在！");
                return;
            }
            UpdateStatue("正在提取文本格式……");
            /*识别用于生成word的myflp中所有的mycu所设置的格式*/
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
                        //myuc.mysetter.listcolumn.Add(mylbl0.TabIndex);
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

            //识别flpfield选中的列用于文件名
            Global.list_title.Clear();
            Label mylbl = null;
            Global.dt_wrong = new DataTable();
            for (int i = 0; i < flpfield.Controls.Count; i++)
            {
                //将flpfield中的空间转化成label格式
                mylbl = ((Label)flpfield.Controls[i]);
                if (mylbl.BackColor == Color.SteelBlue)
                {
                    Global.list_title.Add(mylbl.Text);
                }
                //错误表中增添字段对应的列
                Global.dt_wrong.Columns.Add(mylbl.Text);
            }
            //收集异常信息的data增加异常原因列
            Global.dt_wrong.Columns.Add("异常原因");
            //开始转换
            for (int m = 0; m < dgv_task.Rows.Count; m++)
            {
                string filename = dgv_task.Rows[m].Cells["biaomingcheng"].Value.ToString();
                int id = Convert.ToInt32(dgv_task.Rows[m].Cells["xuhao"].Value.ToString());
                ExcelInfo ei = new ExcelInfo();
                ei._id = id;
                ei._filename = filename;
                //判断线程是否被终端
                try
                {
                    while (Global.t.ThreadState != ThreadState.Stopped) Application.DoEvents();
                }
                catch { }
                //Global.t = new Thread(CreateDocument);
                //Global.t.Name = "thread_" + m;
                ////开始执行线程createdocument方法，传递excel名参数进去
                //Global.t.Start(ei);

            }

            /*提示完成*/
            // myapp.Quit();
            UpdateStatue("版权所有 深圳前海极简信息咨询服务有限公司");
        }
        /// <summary>
        /// 批量根据excel生成文档
        /// </summary>
        /// <param name="o"></param>
        public void CreateDoces(object o)
        {
            if (this.InvokeRequired)
            {
                Action<object> a = CreateDoces;
                this.BeginInvoke(a, o);
            }
            else
            {
                //MessageBox.Show("文件切割");
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
                            //myuc.mysetter.listcolumn.Add(mylbl0.TabIndex);
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
                Global.list_title.Clear();
                Label mylbl = null;
                Global.dt_wrong = new DataTable();
                for (int i = 0; i < flpfield.Controls.Count; i++)
                {
                    mylbl = ((Label)flpfield.Controls[i]);
                    if (mylbl.BackColor == Color.SteelBlue)
                    {
                        Global.list_title.Add(mylbl.Text);
                    }
                    Global.dt_wrong.Columns.Add(mylbl.Text);

                }
                //收集异常信息的data增加异常原因列
                Global.dt_wrong.Columns.Add("异常原因");
                //开始转换
                for (int m = 0; m < Global.list_splitfiles.Count; m++)
                {
                    CreateDocument(Global.list_splitfiles[m]);
                    //int i = m;
                }

            }
        }


        /// <summary>
        /// 生成word，使用excel包含的信息
        /// </summary>
        /// <param name="o">一个字典类型的参数，包括excel文件名和需要被转换的信息行</param>
        /// <returns>返回文件名</returns>
        private string CreateDocument(object o)
        {
            //if (this.InvokeRequired)
            //{
            //    Func<object,string> a = CreateDocument;
            //    //this.BeginInvoke(a, o);
            //    return a(o);
            //}
            //else
            //{
            string savedirectory = string.Empty;
            //Dictionary<string, object> dic = o as Dictionary<string, object>;

            //ExcelInfo ei = dic["excelinfo"] as ExcelInfo;
            DataTable dt_temp = Global.dt_wrong.Clone();
            //将object类型参数转换成dic对象
            Dictionary<string, object> dic = o as Dictionary<string, object>;
            //获得需要转换的信息
            DataRow mydr = dic["datarow"] as DataRow;
            //获得excel表名
            string filename = dic["filename"] as string;
            //dgv_task.Rows[ei._id - 1].Cells[4].Value = "正在准备";
            ////获得 table
            ////string tablename = Path.GetFileNameWithoutExtension(ei._yuanwenjian);
            //Workbook mywbk = new Workbook();
            //mywbk.LoadFromFile(ei._filename);
            //string tablename = mywbk.Worksheets[0].Name;
            //DataTable dt_split = ExcelToDS(ei._filename, "select * from [" + tablename + "$]");
            //增加异常原因列
            //dt_split.Columns.Add("异常原因");
            //dgv_task.Rows[ei._id - 1].Cells[3].Value = dt_split.Rows.Count;
            //读取excel，得到行数
            /*生成一个新的word*/
            Spire.Doc.Document spdoc = new Spire.Doc.Document();
            /*循环把list中的mycu内容添加到word文档*/

            //try
            //{
            //创建保存文档用的文件夹
            savedirectory = tbcunfang.Text + @"\" + Path.GetFileNameWithoutExtension(filename);
            savedirectory = Regex.Replace(savedirectory, @"\(", "（");
            savedirectory = Regex.Replace(savedirectory, @"\)", "）");

            if (!Directory.Exists(savedirectory))
            {
                Directory.CreateDirectory(savedirectory);
            }

            // dgv_task.Rows[ei._id - 1].Cells[4].Value = (100 * Convert.ToDecimal(rowindex + 1) / Convert.ToDecimal(dt_split.Rows.Count)).ToString("00.00") + "%";
            //更新状态栏文字
            //string str_statue = "正在生成第{0}个，共{1}个……";
            //UpdateStatue(string.Format(str_statue, rowindex - 1, lastrow - 1));
            ///载入一个空白文档
            spdoc.LoadFromFile(Environment.CurrentDirectory + @"\newdoc.docx");
            //向word空白文档加入内容
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
                TextRange tx = parainsert.AppendText(GetContent(Global.list_myuc[i].mysetter.namefields, mydr) + str_n);
                //删掉首位的回车

                //Regex.Replace( spdoc.GetText(),@"^\r\n","");
                // Regex.Replace(spdoc.GetText(), @"\r\n$", "");

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
                //设置居中样式
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
            /*保存文档*/
            //组成文件名
            List<string> strfilename = new List<string>();
            for (int i = 0; i < Global.list_title.Count; i++)
            {
                string filename_element = Regex.Replace(mydr[Global.list_title[i]].ToString(), @"[""”“\s/\:*?''<>|]", "");
                filename_element = Regex.Replace(filename_element, "00000", "");
                strfilename.Add(filename_element);
            }
            spdoc.BuiltinDocumentProperties.Author = "挖潜智库";
            string savepath = tbcunfang.Text + @"\" + Path.GetFileNameWithoutExtension(filename) + @"\" + string.Join("-", strfilename) + @".docx";
            //如果保存发生了异常，需要使用商业版的进行保存并去除水印
            //删除文档最前面的空白
            foreach (Spire.Doc.Documents.Paragraph item in spdoc.Sections[0].Paragraphs)
            {
                if (item.Text.Trim().Equals(string.Empty))
                {
                    spdoc.Sections[0].Paragraphs.Remove(item);
                }
                else
                {
                    break;
                }
            }
            //调整页边距
            Spire.Doc.Collections.SectionCollection sections = spdoc.Sections;
            for (int i = 0; i < sections.Count; i++)
            {
                //页边距 
                sections[i].PageSetup.Margins.Left = 90.2f;
                sections[i].PageSetup.Margins.Right = 90.2f;
                sections[i].PageSetup.Margins.Top = 70f;
                sections[i].PageSetup.Margins.Bottom = 70f;
            }
            string wordcont = spdoc.GetText();
            //处理一下savepath中的非法括号
            //处理filename的非法字符
            savepath = Regex.Replace(savepath, @"\)", "）");
            savepath = Regex.Replace(savepath, @"\(", "（");



            spdoc.SaveToFile(savepath);
            //spdoc.LoadFromFile(savepath);
            spdoc.Close();
            return savepath;
            //}
            //catch (Exception ex)
            //{
            //    dt_split.Rows[rowindex]["异常原因"] = ex.Message;
            //    dt_temp.ImportRow(dt_split.Rows[rowindex]);
            //    Global.dt_wrong.ImportRow(dt_split.Rows[rowindex]);
            //    dgv_task.Rows[ei._id - 1].Cells[4].Style.BackColor = Color.Orange;
            //    dgv_task.Rows[ei._id - 1].Cells[4].Style.ForeColor = Color.White;
            //    return string.Empty;
            //}

            // dgv_task.Rows[ei._id - 1].Cells[4].Value = "已完成";
            //把错误datatable保存到文件夹下
            //SaveDT2Excel(dt_temp, savedirectory, "异常数据.xlsx");
            //}
        }






        public void SaveDT2Excel(DataTable dt, string path, string wbkname)
        {
            Aspose.Cells.Workbook mywbk = new Aspose.Cells.Workbook();
            Aspose.Cells.Worksheet mysht = mywbk.Worksheets[0];
            mysht.Name = "Result";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                mysht.Cells[0, i].Value = dt.Columns[i].ColumnName;
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    if (dt.Rows[j][k] != null)
                    {
                        mysht.Cells[j + 1, k].Value = dt.Rows[j][k].ToString();

                    }
                    else
                    {
                        mysht.Cells[j, k].Value = "";
                    }
                }
            }
            mywbk.Save(path + @"\" + wbkname, Aspose.Cells.SaveFormat.Xlsx);
        }
        /// <summary>
        /// 保存datatable的数据到excel中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filepath"></param>
        public void DataToExcel(DataTable dt, string filepath)
        {
            Workbook mywbk = new Workbook();
            Worksheet mysht = mywbk.Worksheets.Create("wronginformation");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                mysht.Range[1, i + 1].Value = dt.Columns[i].ColumnName;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    mysht.Range[i + 2, j + 1].Value = dt.Rows[i][j].ToString();
                }
            }
            mywbk.SaveToFile(filepath);




        }

        /// <summary>
        /// 获得setter的content内容
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="row"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetContent(List<string> list, DataRow dr)
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
                result += dr[list[i]].ToString().Trim() + "\r";
            }
            //string str = string.Join("\n", listresult);
            return result;
        }

        private void lblabort_Click(object sender, EventArgs e)
        {
            Global.t.Abort();
        }

        private void lbl_yichang_Click(object sender, EventArgs e)
        {
            WinFormWrong wf_wrong = new WinFormWrong(Global.dt_wrong);
            wf_wrong.Show();
        }
        delegate void DelOneStep(object o);
        /// <summary>
        /// 去除文档中的水印
        /// </summary>
        /// <param name="file"></param>
        public void ClearShuiYin(string file)
        {
            //获得文件后缀
            string houzhui = Path.GetExtension(file);
            Aspose.Words.Document aspdoc = new Aspose.Words.Document(file);
            aspdoc.Sections[0].Body.Paragraphs.RemoveAt(0);            //构造doc文件名
            if (houzhui.Equals(".doc"))
            {
                aspdoc.Save(file, Aspose.Words.SaveFormat.Doc);
            }
            else
            {
                aspdoc.Save(file, Aspose.Words.SaveFormat.Docx);

            }
        }

        /// <summary>
        /// 将word保存为doc格式
        /// </summary>
        /// <param name="o"></param>
        public string SaveDoc(object o)
        {
            string file = o as string;
            Spire.Doc.Document mydoc = new Spire.Doc.Document();

            mydoc.LoadFromFile(file);
            //判断当前文档格式
            string houzhui = Path.GetExtension(file);
            string savepath0 = string.Empty;
            //把全部文档转换成docx格式
            if (houzhui.Equals(".doc"))
            {
                //保存文档为docx格式
                string savedir = Directory.GetParent(file).FullName;
                string filename = Path.GetFileNameWithoutExtension(file);
                file = savedir + "\\" + filename + ".docx";

                mydoc.SaveToFile(file, Spire.Doc.FileFormat.Docx);
                mydoc.Close();
            }
            //去水印, aspose只能操作 docx
            Aspose.Words.Document aspdoc = new Aspose.Words.Document(file);
            aspdoc.Sections[0].Body.Paragraphs.RemoveAt(0);
            //构造doc文件名
            string newfile = Regex.Replace(file, @"docx", "doc");
            aspdoc.Save(newfile, Aspose.Words.SaveFormat.Doc);
            //删除docx文件
            File.Delete(file);
            return newfile;
        }
        /// <summary>
        /// 将文件保存为docx格式的word文档
        /// </summary>
        /// <param name="o"></param>
        public string SaveDocx(object o)
        {
            string file = o as string;
            Spire.Doc.Document mydoc = new Spire.Doc.Document();

            mydoc.LoadFromFile(file);

            //判断当前文档格式
            string houzhui = Path.GetExtension(file);
            string savepath0 = string.Empty;
            //把全部文档转换成docx格式
            if (houzhui.Equals(".doc"))
            {
                //保存文档为docx格式
                string savedir = Directory.GetParent(file).FullName;
                string filename = Path.GetFileNameWithoutExtension(file);
                file = savedir + "\\" + filename + ".docx";

                mydoc.SaveToFile(file, Spire.Doc.FileFormat.Docx);
                mydoc.Close();
            }
            //去水印
            Aspose.Words.Document aspdoc = new Aspose.Words.Document(file);
            aspdoc.Sections[0].Body.Paragraphs.RemoveAt(0);

            aspdoc.Save(file);
            return file;
        }
        /// <summary>
        /// 从yc控件中获得format
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public Format GetFormat(Control c)
        {
            UCFormat myformat = c as UCFormat;
            Format format = new Format();
            //获得粗体值
            format.bold = myformat.cbbold.Checked ? 1 : 0;
            //获得字体名
            format.fontname = myformat.tbfontname.Text;
            //获得字体大小
            format.fontsize = Convert.ToSingle(myformat.nudfontsize.Value);
            //获得行距类型
            format.lstype = myformat.cbblstype.Text;
            //获得行距固定值
            format.lsvalue = Convert.ToSingle(myformat.nudlsvalue.Value);
            //获得居中设置
            format.juzhong = myformat.cbbposition.Text;
            //获得空行数量
            format.space = Convert.ToInt16(myformat.cbbspace.Text);
            //获得缩进值
            format.suojin = Convert.ToSingle(myformat.nudsuojin.Value);
            //获得格式名称
            format.formatname = myformat.cbbformat.Text;
            //是否启用
            format.enable = myformat.cbenable.Checked;
            return format;
        }
        OfficeHelper OfficeHelper = new OfficeHelper();
        /// <summary>
        /// 调整word的格式
        /// </summary>
        /// <param name="o">word文件名</param>
        public string UpdateFormat(object o)
        {
            var dic = o as Dictionary<string, object>;
            string file = dic["filename"].ToString();
            Dictionary<string, Format> dic_format = dic["format"] as Dictionary<string, Format>;
            //用spire打开文件
            Spire.Doc.Document mydoc = new Spire.Doc.Document();
            mydoc.LoadFromFile(file);

            if (!Path.GetExtension(file).Contains("doc"))
            {
                return string.Empty;
            }
            //判断是否包含水印Evaluation Warning:
            string content = mydoc.Sections[0].Paragraphs[0].Text;
            if (content.Contains("Evaluation Waring"))
            {
                mydoc.Sections[0].Paragraphs.RemoveAt(0);
            }
            //dgv_task.Rows[d].Cells["zhuangtai"].Value = (100 * Convert.ToDecimal(word + 1) / Convert.ToDecimal(list_word.Count)).ToString("00.00") + "%";
            #region 设置格式
            //判断是否需要消除空行
            if (cb_xiaochukonghang.Checked)
            {
                //删除文章中的空白行
                for (int secindex = mydoc.Sections.Count - 1; secindex >= 0; secindex--)
                {
                    var sec = mydoc.Sections[secindex];
                    for (int paraindex = sec.Paragraphs.Count - 1; paraindex >= 0; paraindex--)
                    {
                        var para = sec.Paragraphs[paraindex];
                        if (para.Text.Trim().Equals(string.Empty))
                        {
                            sec.Paragraphs.Remove(para);
                        }
                    }
                }

            }
            //提取word内容
            //string wordcontent = mydoc.Document.GetText();
            StringBuilder wordcontent = new StringBuilder();

            //遍历节和段落，获取段落中的文本
            foreach (Spire.Doc.Section section in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph paragraph in section.Paragraphs)
                {
                    wordcontent.AppendLine(paragraph.Text);
                }
            }
            MatchCollection mckw = null;
            TextSelection[] myts = null;
            TextSelection myts0 = null;
            /*1、设置正文格式*/
            mckw = Regex.Matches(wordcontent.ToString(), @".+?\r\n");

            for (int i = 0; i < mckw.Count; i++)
            {
                myts0 = mydoc.FindString(mckw[i].ToString().Trim(), false, true);
                myworder.FormatSet(myts0, dic_format["正文"]);
            }


            /*2、设置大标题格式*/
            //提取大标题


            mckw = Regex.Matches(wordcontent.ToString(), @".*?\r\n");
            string str_title = string.Empty;
            int titlerow = 0;//记录大标题再第几行，用于定位副标题
            for (int i = 0; i < mckw.Count; i++)
            {
                //如果文本内容不是空，那么他是大标题
                if (!mckw[i].ToString().Trim().Equals(""))
                {
                    str_title = mckw[i].ToString().Trim();
                    titlerow = i;
                    break;
                }

            }
            //大标题格式设置
            TextSelection ts_title = mydoc.FindString(str_title, false, true);
            myworder.FormatSet(ts_title, dic_format["大标题"]);
            //增加第一编，第一章开头的段落设置为大标题格式
            foreach (Spire.Doc.Section sec in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in sec.Paragraphs)
                {
                    if (Regex.IsMatch(para.Text.Trim(), @"^\s*?第[一二三四五六七八九十].*?[章编].*"))
                    {
                        //定位需要转换的文字区域
                        TextSelection ts = para.Find(new Regex(@"^\s*?第[一二三四五六七八九十].*?[章编].*"));
                        //对文字区域的格式进行调整
                        myworder.FormatSet(ts, dic_format["大标题"]);
                    }
                }
            }
            /*设置副标题*/
            //提取副标题
            int title2end = 0;
            for (int i = titlerow + 1; i < mckw.Count; i++)
            {
                if (mckw[i].ToString().Trim().Equals(""))
                {
                    title2end = i;
                    break;
                }
            }
            string title2 = string.Empty;//存放副标题
                                         //副标题格式设置             
            for (int i = titlerow + 1; i < title2end; i++)
            {
                title2 = Regex.Replace(mckw[i].ToString(), "\r\n", "");
                if (title2 == "")
                {
                    break;
                }
                myts = mydoc.FindAllString(title2, false, false);//获得文本区域对其进行操作
                myworder.FormatSet(myts, dic_format["副标题"]);
            }
            //补充副标题格式设置
            //增加第一编，第一章开头的段落设置为大标题格式
            foreach (Spire.Doc.Section sec in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in sec.Paragraphs)
                {
                    if (Regex.IsMatch(para.Text.Trim(), @"^\s*?第[一二三四五六七八九十].*?节.*"))
                    {
                        TextSelection ts = para.Find(new Regex(@"^\s*?第[一二三四五六七八九十].*?节.*"));
                        myworder.FormatSet(ts, dic_format["副标题"]);
                    }
                    if (Regex.IsMatch(para.Text.Trim(), @"^\s*?(目\s*?录|前\s*?言).*"))
                    {
                        TextSelection ts = para.Find(new Regex(@"^\s*?(目\s*?录|前\s*?言).*"));
                        myworder.FormatSet(ts, dic_format["副标题"]);

                    }

                }
            }

            /*3、设置一级标题格式*/
            string regexrule = @"^[一二三四五六七八九十][一二三四五六七八九十]?、.+";

            foreach (Spire.Doc.Section section in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in section.Paragraphs)
                {
                    //获得所有的句子
                    //判断是否含有句号
                    string regrule = string.Empty;
                    if (Regex.IsMatch(para.Text, "。"))
                    {
                        regrule = ".+?[。;；:：]";
                    }
                    else
                    {
                        regrule = ".+$";
                    }
                    mckw = Regex.Matches(para.Text, regrule);
                    List<string> list_santence = new List<string>();
                    foreach (Match match in mckw)
                    {
                        list_santence.Add(match.ToString());
                    }
                    //判断句子的开头是否满足规则
                    foreach (string str in list_santence)
                    {
                        if (Regex.IsMatch(str.Trim(), regexrule))
                        {
                            TextSelection ts = para.Find(str.Trim(), false, false);
                            myworder.FormatSet(ts, dic_format["一级标题"]);
                        }
                    }
                }
            }
            /*4、设置二级标题格式*/
            regexrule = @"^[(（][一二三四五六七八九十].{0,2}[)）].*?(\r\n|。)";
            string regexrule2 = @"^[(（][一二三四五六七八九十].{0,2}[)）].*?$";
            foreach (Spire.Doc.Section section in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in section.Paragraphs)
                {
                    //判断段落的开头是否满足规则
                    if (Regex.IsMatch(para.Text, regexrule))
                    {
                        TextSelection ts = para.Find(new Regex(regexrule));
                        myworder.FormatSet(ts, dic_format["二级标题"]);

                    }
                    else if (Regex.IsMatch(para.Text, regexrule2))
                    {

                        TextSelection ts = para.Find(new Regex(regexrule2));
                        myworder.FormatSet(ts, dic_format["二级标题"]);

                    }
                }
            }
            /*5、设置三标题格式*/
            regexrule = "([一二三四五六七八九十]{1,3}[是要])|" +
                        "((第[一二三四五六七八九十]{1,3}[,，])|(最后[，,]))|" +
                        "((首先|其次)[,，])|" +
                        "(其[一二三四五六七八九十]{1,3}[,，])|" +

                        @"([(（][1-9]\d{0,2}[)）])|" +
                        "([①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳㉑㉒㉓㉔㉕㉖㉗㉘㉙㉚㉛㉜㉝㉞㉟㊱㊲㊳㊴㊵㊶㊷㊸㊹㊺㊻㊼㊽㊾㊿])|" +
                        "(另?一方面)|" +
                        "第([一二三四五六七八九十].*?)条(?![\u4e00-\u9fa5])";
            MatchCollection mc = Regex.Matches(mydoc.GetText(), regexrule);
            foreach (Match item in mc)
            {
                TextSelection[] ts = mydoc.FindAllString(item.Value, false, false);
                foreach (TextSelection t in ts)
                {
                    myworder.FormatSet(t, dic_format["三级标题"]);
                }

            }

            foreach (Spire.Doc.Section section in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in section.Paragraphs)
                {
                    TextSelection ts = para.Find(new Regex(@"(^\s*?([1-9]\d{0,2}|300)[,，\\.])|(^\s*?第[一二三四五六七八九十].*?条之[一二三四五六七八九十])"));
                    myworder.FormatSet(ts, dic_format["三级标题"]);
                }
            }
            #endregion
            #region 设置页面
            /*设置页边距*/
            if (cbqiyong.Checked)
            {
                Spire.Doc.Collections.SectionCollection sections = mydoc.Sections;
                for (int i = 0; i < sections.Count; i++)
                {
                    //页边距 
                    sections[i].PageSetup.Margins.Left = Convert.ToSingle(nudleft.Value);
                    sections[i].PageSetup.Margins.Right = Convert.ToSingle(nudright.Value);
                    sections[i].PageSetup.Margins.Top = Convert.ToSingle(nudtop.Value);
                    sections[i].PageSetup.Margins.Bottom = Convert.ToSingle(nudbottom.Value);
                }
            }


            #endregion
            //保存一次
            mydoc.SaveToFile(file);
            string finalfile = string.Empty;
            //再次保存为指定格式
            if (rbdoc.Checked)
            {
                finalfile = SaveDoc(file);
            }
            else
            {
                finalfile = SaveDocx(file);
            }
            return finalfile;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            ////判断输出路径是否存在
            //if (!Directory.Exists(savepath))
            //{
            //    MessageBox.Show("保存路径不存在！");
            //    return;
            //}

            ////根据选择情况开始绑定事件
            //DelOneStep myonestep = null;
            //if (cb1.Checked)
            //{
            //    //绑定文件切割事件
            //    myonestep += CreateDoces;
            //}
            //if (cb2.Checked)
            //{
            //    //绑定批量改名事件
            //    myonestep += GaiMinges;
            //}

            //if (cb3.Checked)
            //{
            //    //绑定格式调整事件
            //    myonestep += UpdateFormat;

            //}
            ////执行事件
            //this.Invoke(myonestep, new object(), null);

        }


        /// <summary>
        /// 批量改名事件
        /// </summary>
        /// <param name="o"></param>
        public void GaiMinges(object o)
        {
            //MessageBox.Show("批量改名");
            //绑定批量改名事件
            DirectoryInfo mydi = new DirectoryInfo(savepath);
            List<string> list = new List<string>();
            GetFiles(mydi, "*", ref list);
            string field = cbbfield.Text;
            for (int i = 0; i < list.Count; i++)
            {
                string filename = list[i];
                Dictionary<string, object> dic = new Dictionary<string, object>() {
                    {"filename",filename },
                    {"field", field},
                };
                GaiMingSingle(dic);
            }
        }


        /// <summary>
        /// 修改单一文件命
        /// </summary>
        /// <param name="o">字典类型参数，保存文件名前后位置，以及添加字段</param>
        public string GaiMingSingle(object o)
        {

            Dictionary<string, object> dic = o as Dictionary<string, object>;

            string filename = dic["filename"].ToString();
            string fieldqian = dic["fieldqian"].ToString();
            string fieldhou = dic["fieldhou"].ToString();
            //判断是否为word文件
            if (!filename.Contains(".docx") && !filename.Contains(".doc"))
            {
                return string.Empty;
            }
            //对每一个文件获得文件名
            string oldname = Path.GetFileNameWithoutExtension(filename);
            string newfilename = string.Empty;
            if (!fieldqian.Trim().Equals(string.Empty))
            {
                bool b = Regex.IsMatch(filename, oldname);
                newfilename = fieldqian + "-" + oldname;
            }
            if (!fieldhou.Trim().Equals(string.Empty))
            {
                newfilename = newfilename + "-" + fieldhou;

            }
            //修改文件名
            //File.Move(filename, lujing + @"\" + newname + houzhui);
            string directory = Path.GetDirectoryName(filename);
            string houzhui = Path.GetExtension(filename);
            newfilename = directory + "\\" + newfilename + houzhui;
            Directory.Move(filename, newfilename);
            return newfilename;
        }




        /// <summary>
        /// 切分路径文本发生变化时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbqiefen_TextChanged(object sender, EventArgs e)
        {
            //UpdateStatue("正在拆分Excel表……");
            //Global.list_splitfiles = new List<ExcelInfo>();
            //Action a = () =>
            //{

            //获得文件夹下所有得excel文件
            //string path = tbqiefen.Text;
            //if (!Directory.Exists(path))
            //{
            //    return;
            //}
            //    List<string> list_file = new List<string>();
            //    GetFiles(new DirectoryInfo(path), "*.*", ref list_file);
            //    //拆分文件
            //    List<ExcelInfo> list_temp = new List<ExcelInfo>();
            //    ExcelInfo ei = new ExcelInfo();
            //    for (int i = 0; i < list_file.Count; i++)
            //    {
            //        // list_temp = GetSplitExcel(list_file[i], Convert.ToInt32(tbnum.Text));
            //        ei = new ExcelInfo();
            //        //Global.list_splitfiles.AddRange(list_temp);
            //        ei._id = i + 1;
            //        ei._yuanwenjian = list_file[i];
            //        ei._filename = list_file[i];
            //        //ei._hangshu = Convert.ToInt32(tbnum.Text);
            //        Global.list_splitfiles.Add(ei);
            //    }




            //    //显示任务列表
            //    ClearDGV(dgv_task);
            //    for (int i = 0; i < Global.list_splitfiles.Count; i++)
            //    {
            //        UpdateDgv(Global.list_splitfiles[i]);
            //    }
            //};
            //a.BeginInvoke(o =>
            //{
            //    UpdateStatue("版权所有 深圳前海极简信息咨询服务有限公司");
            //}, null);

        }
        /// <summary>
        /// 选择保存路径时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcunfang_TextChanged(object sender, EventArgs e)
        {
            savepath = tbcunfang.Text;
        }
        /// <summary>
        ///改变格式调整名称时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {

            string ttname = cbbzongtigeshi0.Text;

            Dictionary<string, object> dic0 = _mycontroller.GetTiaozhengGeshiSet(ttname);
            ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbbformat.Text = dic0["dabiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usedabiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbbformat.Text = dic0["fubiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usefubiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbbformat.Text = dic0["zhengwen"].ToString();
            ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usezhengwen"]);
            ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbbformat.Text = dic0["yijibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["useyijibiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbbformat.Text = dic0["erjibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["useerjibiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbbformat.Text = dic0["sanjibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usesanjibiaoti"]);
            cbqiyong.Checked = Convert.ToBoolean(dic0["useyemian"]);
            //cbpage.Checked = Convert.ToBoolean(dic0["useyema"]);
            //cbqiyongyemei.Checked = Convert.ToBoolean(dic0["useyemei"]);
            //cbqiyongyejiao.Checked = Convert.ToBoolean(dic0["useyejiao"]);
            //doc，docx赋值
            string wordformat = dic0["wordformat"].ToString();
            if (wordformat.Equals("doc"))
            {
                rbdoc.Checked = true;
            }
            if (wordformat.Equals("docx"))
            {
                rbdocx.Checked = true;
            }
            cbbbianju.Text = string.Empty;
            cbbbianju.Text = dic0["yemian"].ToString();
            //cbbymname.Text = string.Empty;
            //cbbymname.Text = dic0["yemei"].ToString();
            //cbbyjname.Text = string.Empty;
            //cbbyjname.Text = dic0["yejiao"].ToString();

        }
        /// <summary>
        /// 点击保存格式调整按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lblbaocun_Click(object sender, EventArgs e)
        {
            string format = cbbzongtigeshi0.Text;

            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("dabiaoti", ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbbformat.Text);
            dic.Add("usedabiaoti", ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbenable.Checked);
            dic.Add("fubiaoti", ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbbformat.Text);
            dic.Add("usefubiaoti", ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbenable.Checked);
            dic.Add("zhengwen", ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbbformat.Text);
            dic.Add("usezhengwen", ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbenable.Checked);
            dic.Add("yijibiaoti", ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbbformat.Text);
            dic.Add("useyijibiaoti", ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbenable.Checked);
            dic.Add("erjibiaoti", ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbbformat.Text);
            dic.Add("useerjibiaoti", ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbenable.Checked);
            dic.Add("sanjibiaoti", ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbbformat.Text);
            dic.Add("usesanjibiaoti", ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbenable.Checked);
            dic.Add("yemian", cbbbianju.Text);
            dic.Add("useyemian", cbqiyong.Checked);
            //dic.Add("yemei", cbbymname.Text);
            //dic.Add("useyemei", cbqiyongyemei.Checked);
            //dic.Add("yejiao", cbbyjname.Text);
            //dic.Add("useyejiao", cbqiyongyejiao.Checked);
            //dic.Add("useyema", cbpage.Checked);
            string wordformat = string.Empty;
            if (rbdoc.Checked)
            {
                wordformat = "doc";
            }
            if (rbdocx.Checked)
            {
                wordformat = "docx";
            }
            dic.Add("wordformat", wordformat);
            dic.Add("ttname", cbbzongtigeshi0.Text);
            //删除数据
            _mycontroller._sqlhelper.DeleteAnyFormat("ttname", format, "tabletotalformat");
            //保存数据
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tabletotalformat");
            MessageBox.Show("保存数据成功！");
        }

        private void Lblshanchu_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbzongtigeshi0.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("ttname", fieldstr, "tabletotalformat");
            MessageBox.Show("删除数据成功！");
        }
        /// <summary>
        /// 存放excel中包含的所有字段值
        /// </summary>
        List<string> list_fields = new List<string>();
        /// <summary>
        /// 点击新建按钮时触发的时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            //获得一站式名称，目的是为了在新建任务之后继续使用之前的一站格式
            string yizhanshigeshi = cbb_yizhangeshi.Text;

            //实例化一个新建任务按钮
            WinFromAddTask wf_addtask = new WinFromAddTask();
            //显示窗体
            if (wf_addtask.ShowDialog() == DialogResult.OK)
            {
                List<string> list_files = wf_addtask.outvalue;
                //向任务列表中增加excel
                UpdateDgv(list_files);
                //excel字段加载入flpfield中，用于组合word文件名
                list_fields = GetFields(list_files[0]);
                UpdateFlpFields(list_fields);


            }
            //cbb_yizhangeshi.Text = string.Empty;
            //cbb_yizhangeshi.Text = yizhanshigeshi;
        }

        /// <summary>
        /// 将字段添加进入flpfield中
        /// </summary>
        /// <param name="list"></param>

        public void UpdateFlpFields(List<string> list)
        {

            //向字段flp中添加标签        
            UCStep mystep = null;
            Label mylbl = null;
            cbbzongtigeshi.Text = string.Empty;
            myflp.Controls.Clear();
            flpfield.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                mystep = new UCStep();
                mylbl = mystep.lbl_text;
                // mystep.Width = 80;
                mystep.Margin = new Padding(1, 1, 1, 1);

                mylbl.Text = list[i];
                mystep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                mylbl.TextAlign = ContentAlignment.MiddleCenter;
                flpfield.Controls.Add(mystep);
            }


        }
        /// <summary>
        /// 获得excel表中所有的字段
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public List<string> GetFields(string filename)
        {
            List<string> list_fieldname = new List<string>();
            //读取excel表的标题
            Workbook mywbk = new Workbook();

            mywbk.LoadFromFile(filename);
            Worksheet mysht = mywbk.Worksheets[0];
            //获得最后一列带内容得列号

            for (int i = 1; i <= mysht.LastColumn; i++)
            {
                list_fieldname.Add(mysht.Range[1, i].Value);
            }
            return list_fieldname;

        }

        /// <summary>
        /// 点击开始按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            //判断输出路径是否存在
            string importpath = tbcunfang.Text;
            if (!Directory.Exists(importpath))
            {
                MessageBox.Show("保存路径不存在！");
                return;
            }

            //获得任务列表中的一个excel
            UpdateStatue("正在提取文本格式……");
            //获得用于生成word的myflp中所有的mycu所设置的格式
            UCformate2w myuc = null;
            Global.list_myuc.Clear();
            for (int i = 0; i < myflp.Controls.Count; i++)
            {
                myuc = new UCformate2w();
                //将tabcontrol中的控件转化为ucformate2w控件
                myuc = ((UCformate2w)myflp.Controls[i]);
                myuc.mysetter = new Model.setter();
                //给myuc的setter赋值
                //获得用于增添word内容的字段
                for (int j = 0; j < myuc.flp.Controls.Count; j++)
                {
                    Label mylbl0 = myuc.flp.Controls[j] as Label;
                    if (mylbl0.BackColor == Color.SteelBlue)
                    {
                        myuc.mysetter.namefields.Add(mylbl0.Text);
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
            #region 获得用于调整word格式的设置
            Dictionary<string, Format> dic_format = new Dictionary<string, Format>();
            Control mytab = null;

            //获得正文格式
            mytab = mytabcontrol.TabPages[2].Controls[0];
            dic_format.Add("正文", GetFormat(mytab));
            //获得 大标题格式
            mytab = mytabcontrol.TabPages[0].Controls[0];
            dic_format.Add("大标题", GetFormat(mytab));


            //获得副标题
            mytab = mytabcontrol.TabPages[1].Controls[0];
            dic_format.Add("副标题", GetFormat(mytab));


            //获得一级标题格式
            mytab = mytabcontrol.TabPages[3].Controls[0];
            dic_format.Add("一级标题", GetFormat(mytab));

            //获得二级标题格式
            mytab = mytabcontrol.TabPages[4].Controls[0];
            dic_format.Add("二级标题", GetFormat(mytab));

            //获得三级标题格式
            mytab = mytabcontrol.TabPages[5].Controls[0];
            dic_format.Add("三级标题", GetFormat(mytab));

            #endregion

            //获得flpfield选中的列用于文件名
            Global.list_title.Clear();
            Label mylbl = null;
            Global.dt_wrong = new DataTable();
            for (int i = 0; i < flpfield.Controls.Count; i++)
            {
                //将flpfield中的空间转化成label格式
                mylbl = ((UCStep)flpfield.Controls[i]).lbl_text;
                if (mylbl.BackColor == Color.SteelBlue)
                {
                    Global.list_title.Add(mylbl.Text);
                }
                //错误表中增添字段对应的列
                Global.dt_wrong.Columns.Add(mylbl.Text);
            }
            //收集异常信息的data增加异常原因列
            Global.dt_wrong.Columns.Add("异常原因");
            //开始生成，同时更新任务列表信息
            Global.run = true;
            for (int m = 0; m < dgv_task.Rows.Count; m++)
            {
                UpdateStatue("正在生成word文档……");

                //构造一个excelinfo
                string filename = dgv_task.Rows[m].Cells["biaomingcheng"].Value.ToString();
                int id = Convert.ToInt32(dgv_task.Rows[m].Cells["xuhao"].Value.ToString());
                ExcelInfo ei = new ExcelInfo();
                ei._id = id;
                ei._filename = filename;
                ////判断线程是否被终止
                //try
                //{
                //    while (Global.t.ThreadState != ThreadState.Stopped) Application.DoEvents();
                //}
                //catch { }

                //Global.t = new Thread(CreateDocument);
                //Global.t.Name = "thread_" + m;
                ////开始执行线程createdocument方法，传递excel名参数进去
                //Global.t.Start(ei);
                //获得excel下所有的行
                DataTable mydt = _mycontroller._sqlhelper.ExcelToDS(ei._filename, "select * from [sheet1$]");
                //把记录数赋值给数据窗体
                dgv_task.Rows[m].Cells["jilushu"].Value = mydt.Rows.Count.ToString();
                //对每一行，生成word,返回文件名
                for (int p = 0; p < mydt.Rows.Count; p++)
                {
                    string currentfile = string.Empty;
                    if (!Global.run)
                    {
                        MessageBox.Show("任务已终止！");
                        break;
                    }
                    //计算百分比
                    string baifenbi = (Convert.ToDouble(p + 1) * 100 / Convert.ToDouble(mydt.Rows.Count)).ToString("00.00") + "%";

                    //将进度赋值给任务列表
                    dgv_task.Rows[m].Cells["zhuangtai"].Value = baifenbi;
                    Application.DoEvents();
                    Dictionary<string, object> dic0 = new Dictionary<string, object>() {
                        {"filename", ei._filename},
                        {"datarow",mydt.Rows[p] }
                    };
                    try
                    {
                        //生成word文档并返回文件名
                        currentfile = CreateDocument(dic0);
                        //清除水印
                        ClearShuiYin(currentfile);
                        //判断是否启用改名
                        string newfilename = string.Empty;
                        if (cb_qiyongplgm.Checked)
                        {
                            //对word进行改名
                            //构造一个dic
                            Dictionary<string, object> dic1 = new Dictionary<string, object>() {
                                {"filename", currentfile},
                                {"fieldqian",tb_qian.Text },
                                {"fieldhou",tb_hou.Text },
                            };
                            currentfile = GaiMingSingle(dic1);
                        }
                        //判断是否调整格式
                        string myfile = string.Empty;
                        if (cb_qiyonggstz.Checked)
                        {
                            //对word进行格式调整
                            Dictionary<string, object> dic2 = new Dictionary<string, object>() {
                                {"filename", currentfile},
                                { "format",dic_format}
                            };
                            currentfile = UpdateFormat2(dic2);

                        }
                        //判断是否调整页脚页眉和页码
                        if (cb_qiyongymyj.Checked)
                        {
                            //调整finalfile的页眉页脚和页码
                            currentfile = UpdateHeaderFooter(currentfile);

                        }
                        else
                        {
                            currentfile = UpdateHeaderFooterDefault(currentfile);
                        }
                        //判断是否进行文本标注
                        var biaozhucontroller = (tabControl1.TabPages["wenbenbiaozhu"].Controls[0] as UCBiaozhu).mycontroller;
                        bool b = biaozhucontroller._enable;
                        if (b)
                        {
                            biaozhucontroller.WenbenBiaozhu(currentfile);
                        }
                    }
                    catch (Exception ex)
                    {
                        //获得一个dt_wrong的新行newrow

                        var newrow = Global.dt_wrong.NewRow();
                        //对mydt.rows[p]的字段名循环
                        for (int i = 0; i < mydt.Rows[p].Table.Columns.Count; i++)
                        {
                            for (int j = 0; j < newrow.Table.Columns.Count; j++)
                            {
                                if (newrow.Table.Columns[j].ColumnName == mydt.Rows[p].Table.Columns[i].ColumnName)
                                {//如果字段和newrow相等,newrow要赋值
                                    newrow[j] = mydt.Rows[p][i].ToString();
                                    break;
                                }
                            }

                        }
                        newrow["异常原因"] = ex.Message;
                        Global.dt_wrong.Rows.Add(newrow);
                        //跳过该行
                        continue;
                    }

                }
                dgv_task.Rows[m].Cells["zhuangtai"].Value = "已完成";
                UpdateStatue("版权所有 深圳前海极简信息咨询服务有限公司");
            }
        }
        /// <summary>
        /// 读取记事本
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string Txt2Text(string path)
        {
            StreamReader srFile = null;
            string msg = string.Empty;
            try
            {

                srFile = new StreamReader(path, System.Text.Encoding.UTF8);
                msg = srFile.ReadToEnd();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (srFile != null)
                {
                    srFile.Dispose();
                    srFile.Close();
                }
            }
            return msg;
        }

        /// <summary>
        /// 以段落为单位调整格式的方法
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string UpdateFormat2(object o)
        {
            Jdoc myjdoc = new Jdoc();
            Jpara myjpara = new Jpara();
            bool _existdabiaoti = false;
            bool _existfubiaoti = false;
            var dic = o as Dictionary<string, object>;
            string file = dic["filename"].ToString();
            Dictionary<string, Format> dic_format = dic["format"] as Dictionary<string, Format>;

            Aspose.Words.Document mydoc = new Aspose.Words.Document(file);
            #region 在这里获得xml格式得word文档

            //留空暂用


            #endregion


            var paras = mydoc.FirstSection.Body.Paragraphs;//获得文档所有的自然段
            for (int i = 0; i < paras.Count; i++)
            {
                var para = paras[i];
                string str_text = para.Range.Text.Trim();
                myjpara = new Jpara();
                if (para.ParagraphFormat.Alignment == ParagraphAlignment.Center && !_existdabiaoti)
                {
                    _existdabiaoti = true;
                    SetParaFormat(para, dic_format["大标题"]);
                    continue;
                }


                //判断自然段是否为大标题

                bool bb1 = Regex.IsMatch(str_text, "^(第一编|第一章).*");//是否以指定文字开头
                                                                   //var bb2 = Regex.IsMatch(str_text, @"\s\S+[。.；;！!，,：:……~'”‘’？?""“]$");//是否以符号结尾
                if (bb1)
                {
                    SetParaFormat(para, dic_format["大标题"]);
                    continue;
                }


                //判断自然段是否为副标题
                if (para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                {
                    bool b1 = Regex.IsMatch(str_text, @"^(第一节|目\s*录|前\s*言)");//是否以指定文字开头
                    bool b2 = Regex.IsMatch(str_text, @"\s\S+[。.；;！!，,：:……~'”‘’？?""“]$");//是否以符号结尾
                    if (_existdabiaoti && b1 && !b2)
                    {
                        //myjpara._leixing = "副标题";
                        //myjdoc._existfubiaoti = true;
                        //myjpara._asposepara = para;
                        _existfubiaoti = true;
                        SetParaFormat(para, dic_format["副标题"]);
                        continue;

                    }
                }
                //判断是否是正文或各级标题
                if (para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                {
                    SetStrFormat(para, dic_format);

                    ////是否为一级标题
                    //bool b1 = Regex.IsMatch(str_text, @"^[一二三四五六七八九十].*[,，、]");//是否以指定文字开头
                    ////bool b2 = Regex.IsMatch(str_text, @"[\s\S]+[。.；;！!，,：:……~'”‘’？?""“]$");//是否以符号结尾
                    ////bool b3 = Regex.IsMatch(str_text, @"。");//是否含有句号
                    //if (b1 /*&& !b2 && !b3*/)
                    //{
                    //    //myjpara._leixing = "一级标题";
                    //    //myjpara._asposepara = para;
                    //    SetParaFormat(para, dic_format["一级标题"]);

                    //    continue;
                    //}
                    ////是否为二级标题
                    //bool c1 = Regex.IsMatch(str_text, @"^[\(（][一二三四五六七八九十].*?[\)）]");//是否以指定文字开头
                    //bool c2 = Regex.IsMatch(str_text, @"[。;；\r\r\n]$");//是否含有句号
                    //if (c1 && c2)
                    //{
                    //    //myjpara._leixing = "二级标题";
                    //    //myjpara._asposepara = para;
                    //    SetParaFormat(para, dic_format["二级标题"]);
                    //    continue;
                    //}
                    ////是否为三级标题
                    //bool t1 = Regex.IsMatch(str_text, @"^.*?是要");//是否以指定文字开头
                    //bool t2 = Regex.IsMatch(str_text, @"^第[一二三四五六七八九].*?，,");
                    //bool t3 = Regex.IsMatch(str_text, "^首先|其次");
                    //bool t4 = Regex.IsMatch(str_text, @"^\([123456789].*?\)");
                    //bool t5 = Regex.IsMatch(str_text, @"^[①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳㉑㉒㉓㉔㉕㉖㉗㉘㉙㉚㉛㉜㉝㉞㉟㊱㊲㊳㊴㊵㊶㊷㊸㊹㊺㊻㊼㊽㊾㊿]");
                    //bool t6 = Regex.IsMatch(str_text, @"^第\S*?[条|款|项].*");
                    //if (t1 || t2 || t3 || t4 || t5 || t6)
                    //{
                    //    //myjpara._leixing = "三级标题";
                    //    //myjpara._asposepara = para;
                    //    SetParaFormat(para, dic_format["三级标题"]);

                    //    continue;
                    //}
                    ////以上情况均不属于，那么判别为正文
                    ////myjpara._leixing = "正文";
                    ////myjpara._asposepara = para;
                    //SetParaFormat(para, dic_format["正文"]);

                }
                //myjdoc._jparacollection.Add(myjpara);
            }
            /*设置页边距*/
            if (cbqiyong.Checked)
            {
                var sections = mydoc.Sections;
                for (int i = 0; i < sections.Count; i++)
                {
                    //页边距 
                    sections[i].PageSetup.LeftMargin = Convert.ToSingle(nudleft.Value);
                    sections[i].PageSetup.RightMargin = Convert.ToSingle(nudright.Value);
                    sections[i].PageSetup.TopMargin = Convert.ToSingle(nudtop.Value);
                    sections[i].PageSetup.BottomMargin = Convert.ToSingle(nudbottom.Value);
                }
            }

            //保存一次

            //mydoc.Save(file);

            string finalfile = string.Empty;
            //再次保存为指定格式
            if (rbdoc.Checked)
            {
                mydoc.Save(file, SaveFormat.Doc);
                //finalfile = SaveDoc(file);
            }
            else
            {
                mydoc.Save(file, SaveFormat.Docx);

                // finalfile = SaveDocx(file);
            }
            return file;
        }

        /// <summary>
        /// 调整段落内的各段匹配文字的央样式
        /// </summary>
        /// <param name="mypara"></param>
        /// <param name="dic_format"></param>
        public void SetStrFormat(Aspose.Words.Paragraph mypara, Dictionary<string, Format> dic_format)
        {
            Regex regex = null;
            //格式的设置包括那几个方面，字体大小，字体名称，斜体，加粗，倾斜，下划线等,缩进，对齐，行距值
            //1、将整个段落的格式设置成正文
            //获得正文格式
            SetParaFormat(mypara, dic_format["正文"]);
            //2、提取一级标题，设置格式
            FindReplaceOptions options = new FindReplaceOptions();
            options.Direction = FindReplaceDirection.Backward;
            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(dic_format["一级标题"].fontname, dic_format["一级标题"].fontsize, dic_format["三级标题"].bold == 1 ? true : false);
            regex = new Regex(@"((?<!。).)*[一二三四五六七八九十]、((?!。)[\s\S])*$", RegexOptions.IgnoreCase);

            mypara.Range.Replace(regex, "", options);



            //3、提取二级标题，设置格式
            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(dic_format["二级标题"].fontname, dic_format["二级标题"].fontsize, dic_format["三级标题"].bold == 1 ? true : false);
            regex = new Regex(@"^[（\(][一二三四五六七八九十][\)）][\s\S]+[。;；]", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);


            //4、提取三级标题，设置格式

            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(dic_format["三级标题"].fontname, dic_format["三级标题"].fontsize, dic_format["三级标题"].bold == 1 ? true : false);
            regex = new Regex(@"第[一二三四五六七八九十]+?(?=，|、|,)|第[\s\S]+?[条款项]|首先|其次|.是要|（\([123456789]\)）|①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳㉑㉒㉓㉔㉕㉖㉗㉘㉙㉚㉛㉜㉝㉞㉟㊱㊲㊳㊴㊵㊶㊷㊸㊹㊺㊻㊼㊽㊾㊿", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);




        }

        /// <summary>
        /// 设置整个自然段的格式，包括字体，字号，粗体，缩进，对齐方式，行间距等
        /// </summary>
        /// <param name="mypara"></param>
        /// <param name="f"></param>
        public void SetParaFormat(Aspose.Words.Paragraph mypara, Format f)
        {
            Run myrun = mypara.Runs[0];
            if (!f.enable || myrun == null)
            {
                return;
            }
            //mypara.ParagraphFormat.Style.Font.Name = f.fontname;
            myrun.Font.Name = f.fontname;     //设置字体                                         
            //mypara.ParagraphFormat.Style.Font.Size = f.fontsize;
            myrun.Font.Size = f.fontsize; //设置字号
            //设置 粗体
            //mypara.ParagraphFormat.Style.Font.Bold = f.bold == 1;
            myrun.Font.Bold = f.bold == 1;
            //设置缩进
            //mypara.ParagraphFormat.FirstLineIndent = f.suojin;
            myrun.ParentParagraph.ParagraphFormat.FirstLineIndent = f.suojin;
            //设置对齐
            string juzhong = f.juzhong;
            if (juzhong != null)
            {
                if (juzhong == "左对齐")
                {
                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                    myrun.ParentParagraph.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                }
                else if (juzhong == "居中")
                {
                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                    myrun.ParentParagraph.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                }
                else if (juzhong == "右对齐")
                {
                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                    myrun.ParentParagraph.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                }
            }
            //设置空行
            //设置行距值
            //mypara.ParagraphFormat.LineSpacingRule = Aspose.Words.LineSpacingRule.Exactly;
            myrun.ParentParagraph.ParagraphFormat.LineSpacingRule = Aspose.Words.LineSpacingRule.Exactly;
            // mypara.ParagraphFormat.LineSpacing = f.lsvalue;
            myrun.ParentParagraph.ParagraphFormat.LineSpacing = f.lsvalue;
        }






        /// <summary> 
        /// 在不选择启用页码的情况下加载页码
        /// </summary>
        /// <param name="myfile"></param>
        /// <returns></returns>
        private string UpdateHeaderFooterDefault(string myfile)
        {
            Aspose.Words.Document mydoc = new Aspose.Words.Document(myfile);
            DocumentBuilder builder = new DocumentBuilder(mydoc);
            Aspose.Words.SectionCollection sections = mydoc.Sections;

            ////光标定位到页脚
            builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
            //设置页码居中样式
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            builder.InsertField("PAGE", "");
            builder.Write("/");
            builder.InsertField("NUMPAGES", "");
            //设置页码字体

            builder.PageSetup.PageNumberStyle = NumberStyle.Arabic;
            mydoc.Save(myfile);
            return myfile;
        }

        /// <summary>
        /// 修改页眉页脚页码
        /// </summary>
        /// <param name="myfile"></param>
        /// <returns></returns>
        private string UpdateHeaderFooter(string myfile)
        {
            Aspose.Words.Document mydoc = new Aspose.Words.Document(myfile);
            DocumentBuilder builder = new DocumentBuilder(mydoc);
            Aspose.Words.SectionCollection sections = mydoc.Sections;


            /*设置页眉*/
            if (cbqiyongyemei.Checked)
            {

                //builder.PageSetup.PageNumberStyle = NumberStyle.GB1;
                //    builder.InsertField("PAGE", "");
                // Add any custom text
                //builder.Write(" / ");
                // Add field for total page numbers in document
                //builder.InsertField("NUMPAGES", "");
                // 光标移动到页眉,并设置页眉的居中
                builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.HeaderPrimary);
                if (cbbjuzhong0.Text.Equals("左对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                }
                else if (cbbjuzhong0.Text.Equals("居中"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                }
                else if (cbbjuzhong0.Text.Equals("右对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                }
                builder.Write(tbcontent0.Text);
                builder.Font.NameBi = tbfontname0.Text;
                builder.Font.SizeBi = Convert.ToDouble(nudfontsize0.Value);
                builder.Font.BoldBi = cbymbold.Checked;
            }
            /*设置页码*/
            if (cbpage.Checked)
            {
                ////光标定位到页脚
                builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
                //设置页码居中样式
                if (cbb_yemajuzhong.Text.Equals("左对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                }
                else if (cbb_yemajuzhong.Text.Equals("居中"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                }
                else if (cbb_yemajuzhong.Text.Equals("右对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                }
                var newpara = builder.InsertParagraph();
                builder.MoveTo(newpara);
                //判断
                //设置格式
                if (cbb_yangshi.Text.Equals("1、2……"))
                {
                    builder.InsertField("PAGE", "");
                }
                else if (cbb_yangshi.Text.Equals("-1-"))
                {
                    builder.Write("- ");
                    builder.InsertField("PAGE", "");

                    builder.Write(" -");

                }
                else if (cbb_yangshi.Text.Equals("第 1 页，第 2 页……"))
                {
                    builder.Write("第 ");
                    builder.InsertField("PAGE", "");

                    builder.Write(" 页");

                }
                else if (cbb_yangshi.Text.Equals("第 1 页，共 2 页……"))
                {
                    builder.Write("第 ");
                    builder.InsertField("PAGE", "");
                    builder.Write(" 页，");
                    builder.Write("共 ");
                    builder.InsertField("NUMPAGES", "");
                    builder.Write(" 页");

                }
                else if (cbb_yangshi.Text.Equals("1/N,2/N……"))
                {
                    builder.InsertField("PAGE", "");
                    builder.Write("/");
                    builder.InsertField("NUMPAGES", "");

                }
                //设置页码字体
                if (cbb_fontformat.Text.Equals("1、2、3……"))
                {
                    builder.PageSetup.PageNumberStyle = NumberStyle.Arabic;
                }
                else if (cbb_fontformat.Text.Equals("Ⅰ、Ⅱ、Ⅲ……"))
                {
                    builder.PageSetup.PageNumberStyle = NumberStyle.UppercaseRoman;

                }
                else if (cbb_fontformat.Text.Equals("a、b、c……"))
                {
                    builder.PageSetup.PageNumberStyle = NumberStyle.LowercaseLetter;

                }
                else if (cbb_fontformat.Text.Equals("A、B、C……"))
                {
                    builder.PageSetup.PageNumberStyle = NumberStyle.UppercaseLetter;

                }
            }

            /*设置页脚*/
            if (cbqiyongyejiao.Checked)
            {

                builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
                // 光标移动到页眉,并设置页眉的居中
                if (cbbjuzhong1.Text.Equals("左对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                }
                else if (cbbjuzhong1.Text.Equals("居中"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                }
                else if (cbbjuzhong1.Text.Equals("右对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                }
                builder.Font.NameBi = tbfontname1.Text;
                builder.Font.SizeBi = Convert.ToDouble(nudfontsize1.Value);
                builder.Font.BoldBi = cbyjbold.Checked;
                var newpara = builder.InsertParagraph();
                builder.MoveTo(newpara);
                builder.Write(tbcontent1.Text);

            }

            //删除页脚多余的空行
            builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);

            foreach (var item in builder.CurrentSection.HeadersFooters[0].Paragraphs)
            {
                string content = item.GetText();
                if (content.Trim().Equals(string.Empty))
                {
                    builder.CurrentSection.HeadersFooters[0].Paragraphs.Remove(item);
                }

            }
            mydoc.Save(myfile);
            return myfile;

        }

        private void Lblbaocun_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect((Control)sender);
        }

        private void Lblshanchu_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect((Control)sender);

        }

        private void Lblbaocun_MouseEnter(object sender, EventArgs e)
        {
            mydrawer.UpdateCSize((Control)sender, new Padding(1, 1, 1, 1));
        }

        private void Lblbaocun_MouseLeave(object sender, EventArgs e)
        {
            mydrawer.UpdateCSize((Control)sender, new Padding(2, 2, 2, 2));

        }
        /// <summary>
        /// 点击保存页眉按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lblymbaocun_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbymname.Text;
            //删除格式fieldstr对应的数据
            _mycontroller._sqlhelper.DeleteAnyFormat("fname", fieldstr, "tableforamt");
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("fname", cbbymname.Text);
            dic.Add("ftext", tbcontent0.Text);
            dic.Add("ffontname", tbfontname0.Text);
            dic.Add("fsize", nudfontsize0.Value);
            dic.Add("fbold", cbymbold.Checked);
            dic.Add("fjuzhong", cbbjuzhong0.Text);
            dic.Add("fposition", "yemei");
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tableformat");
            MessageBox.Show("保存数据成功！");
        }

        private void Lblyjbaocun_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbyjname.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("fname", fieldstr, "tableformat");
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("fname", fieldstr);
            dic.Add("ftext", tbcontent1.Text);
            dic.Add("ffontname", tbfontname1.Text);
            dic.Add("fsize", nudfontsize1.Value);
            dic.Add("fbold", cbyjbold.Checked);
            dic.Add("fjuzhong", cbbjuzhong1.Text);
            dic.Add("fposition", "yejiao");
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tableformat");
            MessageBox.Show("保存数据成功！");

        }

        private void Lblyjshanchu_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbyjname.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("fname", fieldstr, "tableformat");
            MessageBox.Show("格式已删除！");

        }

        private void Lblymshanchu_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbymname.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("fname", fieldstr, "tableformat");
            MessageBox.Show("格式已删除！");
        }
        /// <summary>
        /// 点击改名的保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label7_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbfield.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("fieldname", fieldstr, "tablefield");
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>() {
                { "fieldname", fieldstr},
                { "fieldqian", tb_qian.Text},
                { "fieldhou", tb_hou.Text}
            };
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tablefield");
            MessageBox.Show("保存字段成功！");
        }
        /// <summary>
        /// 点击删除字段按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label8_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbfield.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("fieldname", fieldstr, "tablefield");
            MessageBox.Show("删除字段成功！");
        }
        /// <summary>
        /// 页眉格式名称发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbymname_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "fname",cbbymname.Text},
                { "fposition","yemei"}
            };
            var list = _mycontroller._sqlhelper.GetAnySet("tableformat", mydic);
            var dic = list[0];
            tbcontent0.Text = dic["ftext"].ToString();
            tbfontname0.Text = dic["ffontname"].ToString();
            nudfontsize0.Value = Convert.ToDecimal(dic["fsize"]);
            cbymbold.Checked = Convert.ToBoolean(dic["fbold"]);
            cbbjuzhong0.Text = Convert.ToString(dic["fjuzhong"]);
        }
        /// <summary>
        /// 页脚格式名称发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbyjname_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "fname",cbbymname.Text},
                { "fposition","yejiao"}
            };
            var list = _mycontroller._sqlhelper.GetAnySet("tableformat", mydic);
            Dictionary<string, object> dic = list[0]; //这里实际上需要区分页眉页脚
            tbcontent1.Text = dic["ftext"].ToString();
            tbfontname1.Text = dic["ffontname"].ToString();
            nudfontsize1.Value = Convert.ToDecimal(dic["fsize"]);
            cbyjbold.Checked = Convert.ToBoolean(dic["fbold"]);
            cbbjuzhong1.Text = Convert.ToString(dic["fjuzhong"]);
        }

        private void Btnfont1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbfontname1.Text = fd.Font.Name;
                nudfontsize1.Value = Convert.ToDecimal(fd.Font.Size);
                cbyjbold.Checked = fd.Font.Bold;
            }

        }

        private void Btnfont0_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbfontname0.Text = fd.Font.Name;
                nudfontsize0.Value = Convert.ToDecimal(fd.Font.Size);
                cbymbold.Checked = fd.Font.Bold;
            }

        }
        /// <summary>
        /// 点击删除页码格式时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label30_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbymname.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("pagename", fieldstr, "tablepage");

            MessageBox.Show("格式已删除！");
        }

        private void Label29_Click(object sender, EventArgs e)
        {
            string fieldstr = cbb_page.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("pagename", fieldstr, "tablepage");
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagename", fieldstr);
            dic.Add("pageformat", cbb_yangshi.Text);
            dic.Add("pagefontstyle", cbb_fontformat.Text);
            dic.Add("pagejuzhong", cbb_yemajuzhong.Text);
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tablepage");
            MessageBox.Show("保存数据成功！");
        }
        /// <summary>
        /// 页码格式名称发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbb_page_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"pagename",cbb_page.Text }
            };
            var list = _mycontroller._sqlhelper.GetAnySet("tablepage", mydic);
            Dictionary<string, object> dic = list[0];
            cbb_fontformat.Text = dic["pagefontstyle"].ToString();
            cbb_yangshi.Text = dic["pageformat"].ToString();
            cbb_yemajuzhong.Text = dic["pagejuzhong"].ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Global.run = false;
        }
        /// <summary>
        /// 批量改名格式名称发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbfield_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string fieldstr = cbbfield.Text;
                Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"fieldname",fieldstr }
            };

                var list = _mycontroller._sqlhelper.GetAnySet("tablefield", mydic);
                Dictionary<string, object> dic = list[0];
                tb_qian.Text = dic["fieldqian"].ToString();
                tb_hou.Text = dic["fieldhou"].ToString();

            }
            catch { }

        }

        private void Cbqiyongyemei_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击保存一站格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_saveyizhan_Click(object sender, EventArgs e)
        {
            string fieldstr = cbb_yizhangeshi.Text;
            //构造dic数据,用于保存到数据库
            Dictionary<string, object> dic = new Dictionary<string, object>() {
                { "yizhanshiname",fieldstr},//一站式名称
                { "formatwjqg",cbbzongtigeshi.Text },//文件切割格式
                {"formatplgm",cbbfield.Text },
                {"formatgstz",cbbzongtigeshi0.Text },
                {"formatymyj",cbbyemeiyejiao.Text },
                { "enablewjqg",cb_qiyongwjqg.Checked},
                {"enableplgm",cb_qiyongplgm.Checked },
                {"enablegstz",cb_qiyonggstz.Checked },
                //页眉页脚启用情况
                { "enableymyj",cb_qiyongymyj.Checked},
                //文本标注是否启用以及名称
                { "启用标注",(tabControl1.TabPages["wenbenbiaozhu"].Controls[0] as UCBiaozhu).mycontroller._enable},
                { "标注格式",(tabControl1.TabPages["wenbenbiaozhu"].Controls[0] as UCBiaozhu).mycontroller._format}
            };

            //删除该一站格式
            _mycontroller._sqlhelper.DeleteAnyFormat("yizhanshiname", fieldstr, "tableyizhangeshi");
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tableyizhangeshi");
            MessageBox.Show("保存数据成功！");

        }
        /// <summary>
        /// 点击保存页眉页脚按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label37_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbyemeiyejiao.Text;
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("name", cbbyemeiyejiao.Text);
            dic.Add("yemeishezhi", cbbymname.Text);
            dic.Add("yejiaoshezhi", cbbyjname.Text);
            dic.Add("yemashezhi", cbb_page.Text);
            dic.Add("enableyemei", cbqiyongyemei.Checked);
            dic.Add("enableyejiao", cbqiyongyejiao.Checked);
            dic.Add("enableyema", cbpage.Checked);
            _mycontroller._sqlhelper.DeleteAnyFormat("name", fieldstr, "tableyemeiyejiao");
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tableyemeiyejiao");
            MessageBox.Show("保存数据成功！");
            //清空下拉菜单
        }
        /// <summary>
        /// 点击删除一站格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_yizhanshanchu_Click(object sender, EventArgs e)
        {

            string fieldstr = cbb_yizhangeshi.Text;
            //删除该一站格式
            _mycontroller._sqlhelper.DeleteAnyFormat("yizhanshiname", fieldstr, "tableyizhangeshi");
            MessageBox.Show("删除数据成功！");
        }
        /// <summary>
        /// 当一站格式名称发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbb_yizhangeshi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string fieldstr = cbb_yizhangeshi.Text;
                //打开数据库
                Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"yizhanshiname",fieldstr}
                };
                var list = _mycontroller._sqlhelper.GetAnySet("tableyizhangeshi", mydic);
                Dictionary<string, object> dic0 = list[0];
                //向四个步骤格式名称赋值
                cbbzongtigeshi.Text = string.Empty;
                cbbzongtigeshi.Text = dic0["formatwjqg"].ToString();
                cbbfield.Text = string.Empty;
                cbbfield.Text = dic0["formatplgm"].ToString();
                cbbzongtigeshi0.Text = string.Empty;
                cbbzongtigeshi0.Text = dic0["formatgstz"].ToString();
                cbbyemeiyejiao.Text = string.Empty;
                cbbyemeiyejiao.Text = dic0["formatymyj"].ToString();
                //是否启用按钮赋值
                cb_qiyongwjqg.Checked = Convert.ToBoolean(dic0["enablewjqg"]);
                cb_qiyongplgm.Checked = Convert.ToBoolean(dic0["enableplgm"]);
                cb_qiyonggstz.Checked = Convert.ToBoolean(dic0["enablegstz"]);
                cb_qiyongymyj.Checked = Convert.ToBoolean(dic0["enableymyj"]);
                //获得文本标注控件
                UCBiaozhu myuc = tabControl1.TabPages["wenbenbiaozhu"].Controls[0] as UCBiaozhu;
                myuc.cbb_format.Text = dic0["标注格式"].ToString();
                myuc.cb_biaozhu.Checked = Convert.ToBoolean(dic0["启用标注"]);
            }
            catch { }
        }
        /// <summary>
        /// 文件切割格式内容发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbzongtigeshi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //判断格式名是否存在，如果不存在什么都不做
                string formatname = cbbzongtigeshi.Text;
                Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "totalname",formatname}
            };
                var list = _mycontroller._sqlhelper.GetAnySet("tablesplit", mydic);
                if (list.Count == 0)
                {
                    return;
                }
                Dictionary<string, object> mydic_data = new Dictionary<string, object>
            {
                { "totalname",cbbzongtigeshi.Text}
            };
                var list_data = _mycontroller._sqlhelper.GetAnySet("tablesplit", mydic_data);
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
                string[] arr_allfields = dic["alltitle"].ToString().Split(new char[] { ',', '，' });//获得所有的文件名字段
                string[] arr_title = dic["titlefields"].ToString().Split(new char[] { ',', '，' });//获得选中字段，用于生成word文件名

                for (int i = 0; i < arr_allfields.Length; i++)
                {
                    UCStep mystep = new UCStep();

                    mystep.lbl_text.Text = arr_allfields[i];
                    mystep.lbl_text.TextAlign = ContentAlignment.MiddleCenter;
                    mystep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    mystep.Margin = new Padding(1, 1, 1, 1);
                    if (arr_title.Contains(mystep.lbl_text.Text))
                    {
                        mystep.lbl_text.BackColor = Color.SteelBlue;
                        mystep.lbl_text.ForeColor = Color.White;
                    }
                    flpfield.Controls.Add(mystep);
                }
            }
            catch { }
        }
        /// <summary>
        /// 点击删除页眉页脚按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label36_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbyemeiyejiao.Text;
            //打开数据库
            _mycontroller._sqlhelper.DeleteAnyFormat("name", fieldstr, "tableyemeiyejiao");
            MessageBox.Show("删除数据成功！");
        }
        /// <summary>
        /// 改变页眉页脚格式内容时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbyemeiyejiao_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string fieldstr = cbbyemeiyejiao.Text;
                //打开数据库
                Dictionary<string, object> mydic = new Dictionary<string, object> {

                {"name",fieldstr }
            };

                var list = _mycontroller._sqlhelper.GetAnySet("tableyemeiyejiao", mydic);
                Dictionary<string, object> dic0 = list[0];
                //添加进下拉菜单
                cbbyemeiyejiao.Text = dic0["name"].ToString();
                cbbymname.Text = dic0["yemeishezhi"].ToString();
                cbbyjname.Text = dic0["yejiaoshezhi"].ToString();
                cbb_page.Text = dic0["yemashezhi"].ToString();
                cbqiyongyemei.Checked = Convert.ToBoolean(dic0["enableyemei"]);
                cbqiyongyejiao.Checked = Convert.ToBoolean(dic0["enableyejiao"]);
                cbpage.Checked = Convert.ToBoolean(dic0["enableyema"]);
            }
            catch { }
        }

        private void cbbbianju_TextChanged(object sender, EventArgs e)
        {

            string ttname = cbbbianju.Text;
            Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"name",ttname }
            };

            var list = _mycontroller._sqlhelper.GetAnySet("tablepagemargin", mydic);
            Dictionary<string, object> dic0 = list[0];
            nudleft.Value = Convert.ToDecimal(dic0["left"]);
            nudright.Value = Convert.ToDecimal(dic0["right"]);
            nudtop.Value = Convert.ToDecimal(dic0["top"]);
            nudbottom.Value = Convert.ToDecimal(dic0["bottom"]);
        }
        /// <summary>
        /// 点击保存页边距按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label17_Click(object sender, EventArgs e)
        {

            string ttname = cbbbianju.Text;
            //打开数据库
            _mycontroller._sqlhelper.DeleteAnyFormat("name", ttname, "tablepagemargin");
            //保存页边距信息到数据库
            //构造dic
            Dictionary<string, object> dic = new Dictionary<string, object>() {
                {"name",ttname },
                {"left",nudleft.Value },
                {"right" ,nudright.Value},
                {"top" ,nudtop.Value},
                 {"bottom" ,nudbottom.Value},
            };
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tablepagemargin");
            //提示保存成功
            MessageBox.Show("格式已保存成功！");
            //重新加载cbbbianju
        }
        /// <summary>
        /// 点击删除页边距按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label18_Click(object sender, EventArgs e)
        {
            string ttname = cbbbianju.Text;
            //打开数据库
            _mycontroller._sqlhelper.DeleteAnyFormat("name", ttname, "tablepagemargin");
            //提示保存成功
            MessageBox.Show("格式已删除！");
        }

        private void cbb_yizhangeshi_DropDown(object sender, EventArgs e)
        {
            cbb_yizhangeshi.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("yizhanshiname", "tableyizhangeshi");
            cbb_yizhangeshi.Items.AddRange(list.ToArray());
        }

        private void cbbzongtigeshi_DropDown(object sender, EventArgs e)
        {
            cbbzongtigeshi.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("totalname", "tablesplit");
            cbbzongtigeshi.Items.AddRange(list.ToArray());

        }

        private void cbbfield_DropDown(object sender, EventArgs e)
        {
            cbbfield.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("fieldname", "tablefield");
            cbbfield.Items.AddRange(list.ToArray());
        }

        private void cbbbianju_DropDown(object sender, EventArgs e)
        {
            cbbbianju.Items.Clear();

            var list = _mycontroller._sqlhelper.GetSingleField("name", "tablepagemargin");
            cbbbianju.Items.AddRange(list.ToArray());
        }

        private void cbbzongtigeshi0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = this.cbbzongtigeshi0.Text;
            var list = _mycontroller._sqlhelper.GetAnySet("tabletotalformat", new Dictionary<string, object> { { "ttname", text } });
            foreach (object obj2 in list)
            {
                Dictionary<string, object> dictionary = (Dictionary<string, object>)obj2;
                ((UCFormat)this.mytabcontrol.TabPages[0].Controls[0]).cbbformat.Text = dictionary["dabiaoti"].ToString();
                ((UCFormat)this.mytabcontrol.TabPages[0].Controls[0]).cbenable.Checked = Convert.ToBoolean(dictionary["usedabiaoti"]);
                ((UCFormat)this.mytabcontrol.TabPages[1].Controls[0]).cbbformat.Text = dictionary["fubiaoti"].ToString();
                ((UCFormat)this.mytabcontrol.TabPages[1].Controls[0]).cbenable.Checked = Convert.ToBoolean(dictionary["usefubiaoti"]);
                ((UCFormat)this.mytabcontrol.TabPages[2].Controls[0]).cbbformat.Text = dictionary["zhengwen"].ToString();
                ((UCFormat)this.mytabcontrol.TabPages[2].Controls[0]).cbenable.Checked = Convert.ToBoolean(dictionary["usezhengwen"]);
                ((UCFormat)this.mytabcontrol.TabPages[3].Controls[0]).cbbformat.Text = dictionary["yijibiaoti"].ToString();
                ((UCFormat)this.mytabcontrol.TabPages[3].Controls[0]).cbenable.Checked = Convert.ToBoolean(dictionary["useyijibiaoti"]);
                ((UCFormat)this.mytabcontrol.TabPages[4].Controls[0]).cbbformat.Text = dictionary["erjibiaoti"].ToString();
                ((UCFormat)this.mytabcontrol.TabPages[4].Controls[0]).cbenable.Checked = Convert.ToBoolean(dictionary["useerjibiaoti"]);
                ((UCFormat)this.mytabcontrol.TabPages[5].Controls[0]).cbbformat.Text = dictionary["sanjibiaoti"].ToString();
                ((UCFormat)this.mytabcontrol.TabPages[5].Controls[0]).cbenable.Checked = Convert.ToBoolean(dictionary["usesanjibiaoti"]);
                this.cbqiyong.Checked = Convert.ToBoolean(dictionary["useyemian"]);
                string str3 = dictionary["wordformat"].ToString();
                if (str3.Equals("doc"))
                {
                    this.rbdoc.Checked = true;
                }
                if (str3.Equals("docx"))
                {
                    this.rbdocx.Checked = true;
                }
                this.cbbbianju.Text = string.Empty;
                this.cbbbianju.Text = dictionary["yemian"].ToString();
            }

        }

        private void cbbzongtigeshi0_DropDown(object sender, EventArgs e)
        {
            cbbzongtigeshi0.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("ttname", "tabletotalformat");
            cbbzongtigeshi0.Items.AddRange(list.ToArray());
        }

        private void cbbymname_DropDown(object sender, EventArgs e)
        {
            cbbymname.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("fname", "tableformat");
            cbbymname.Items.AddRange(list.ToArray());
        }

        private void cbbyjname_DropDown(object sender, EventArgs e)
        {
            cbbyjname.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("fname", "tableformat");
            cbbyjname.Items.AddRange(list.ToArray());

        }

        private void cbb_page_DragDrop(object sender, DragEventArgs e)
        {
            cbb_page.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("pagename", "tablepage");
            cbb_page.Items.AddRange(list.ToArray());

        }

        private void cbbyemeiyejiao_DropDown(object sender, EventArgs e)
        {
            cbbyemeiyejiao.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("name", "tableyemeiyejiao");
            cbbyemeiyejiao.Items.AddRange(list.ToArray());

        }
    }
    public class ReplaceEvaluatorFindAndHighlight : IReplacingCallback
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
                run.Font.HighlightColor = Color.Yellow;
            //向替换引擎发出信号，表示什么都不做，因为我们已经完成了所有想要做的事情。
            return ReplaceAction.Skip;
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
