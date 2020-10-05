using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuiTengDll;
using System.IO;
using Common;
using WindowsFormsApp1.Common;
using WindowsFormsApp1.Controller;

namespace WindowsFormsApp1.UC
{
    public partial class UCShujuku : UserControl
    {

        SqliteHelper mysqliter = null;
        UIHelper uihelper = new UIHelper();
        ControllerShujuku _mycontroller = new ControllerShujuku();
        string dbfile = string.Empty;
        ControllerClickhouse _cchelper = null;

        public UCShujuku()
        {
            InitializeComponent();
            _cchelper = new ControllerClickhouse();

        }
        /// <summary>
        /// 加载数据库管理用户控件时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCShujuku_Load(object sender, EventArgs e)
        {
        
                // dgv_data.AutoResizeColumns();
                if (Setting._currentdb != string.Empty)
                {
                    List<string> list_table = _mycontroller.GetTablesName().ToList();
                    if (list_table.Contains(Setting._currentdb))
                    {
                        lbl_dbname.Text = Setting._currentdb;
                    }
                    else
                    {
                        //获得所有数据表名称
                        lbl_dbname.Text = list_table[0];
                    }

                }
                else
                {
                    //获得所有数据表名称
                    List<string> list_table = _mycontroller.GetTablesName().ToList();
                    lbl_dbname.Text = list_table[0];
                }

        }

        private void cbb_shujubiao_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            uihelper.DrawRoundRect((Control)sender);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, new Padding(m - 1));
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, new Padding(m + 1));

        }
        OfficeHelper officehelper = new OfficeHelper();
        /// <summary>
        /// 点击导入按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_daoru_Click(object sender, EventArgs e)
        {
            WinForm.WinFormImportExcel mywinform = new WinForm.WinFormImportExcel();
            mywinform.StartPosition = FormStartPosition.CenterParent;
            if (mywinform.ShowDialog() == DialogResult.OK)
            {
                string selecttable = lbl_dbname.Text;
                DataTable mydt = mywinform.dt;
                //插入到选中的数据表
                _mycontroller.InsertDT2DB(mydt, Setting._currentdb);
                //刷新数据
                //获得该表下数据datatable
                string str_sql = $"select * from {Setting._currentdb}";
                DataTable dt = mysqliter.GetDataTable(str_sql);
                //将数据绑定到dgv_data
                dgv_data.DataSource = null;
                dgv_data.DataSource = dt;
                MessageBox.Show("导入数据成功！");
            }
        }
        /// <summary>
        /// 点击导出按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_daochu_Click(object sender, EventArgs e)
        {

            //获得数据库名
            string dbname = lbl_dbname.Text;
            var mylist = _mycontroller.MohuChaxun(new List<string>() { "编号" }, "", dbname);
            DataTable mydt = _mycontroller.List2DataTable(mylist);
            //判断是否选择了范围，如果没有，则导出全部数据
            if (tb_start.Text.Trim().Equals(string.Empty) && tb_end.Text.Trim().Equals(string.Empty))
            {
                _mycontroller.SaveDtSplit(mydt, mydt.Rows.Count, lbl_dbname.Text);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel 97-2003工作簿|*.xls|Excel 工作簿|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string houzhui = Path.GetExtension(sfd.FileName);
                    //将数据保存为excel
                    int start = Convert.ToInt32(tb_start.Text.Trim()) - 1;
                    int end = Convert.ToInt32(tb_end.Text.Trim());
                    officehelper.SaveDTRegion2Excel(mydt, sfd.FileName, houzhui, start, end);
                }
            }
        }




        /// <summary>
        /// 点击添加按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label2_Click(object sender, EventArgs e)
        {
            _mycontroller.AddDatabase();
            //UCShujuku_Load(null, null);
        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label1_Click(object sender, EventArgs e)
        {
            _mycontroller.DeleteDatabase(lbl_dbname.Text);
            UCShujuku_Load(null, null);

        }
        /// <summary>
        /// 点击编辑按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label3_Click(object sender, EventArgs e)
        {
            _mycontroller.EditDatabase(lbl_dbname.Text);

            UCShujuku_Load(null, null);
        }

        private void Pb_shujuku_Click(object sender, EventArgs e)
        {
            WinForm.WinFormSelectDb mywf = new WinForm.WinFormSelectDb();
            mywf.StartPosition = FormStartPosition.CenterParent;
            if (mywf.ShowDialog() == DialogResult.OK)
            {
                string dbname = mywf.dbname;
                if (!dbname.Equals(string.Empty))
                {
                    lbl_dbname.Text = dbname;

                }
            }
        }
        /// <summary>
        /// 数据表名称标题发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_dbname_TextChanged(object sender, EventArgs e)
        {
            //获得数据表名称
            string shtname = lbl_dbname.Text;
            Setting._currentdb = shtname;
            //判断是否为软件设置表，如果是，那么不以日期排序
            //if (shtname.Equals("软件设置表"))
            //{
            //    string str_sql = $"select * from {shtname}";
            //    _mycontroller.SelectDB("default");
            //    mydt = _mycontroller.GetDataFromTable(str_sql);
            //    lbl_shuliang.Text = $"（{mydt.Rows.Count} 条）";
            //}
            //else
            //{
            //获得总页数
            string str_sql = $"select * from {shtname}";


            //赋值 第一页tb  1/1
            var mylist = _mycontroller.GetDataFromTable(str_sql);
            if (mylist.Count == 0)
            {
                lbl_shuliang.Text = "0";

            }
            else
            {
                lbl_shuliang.Text = $"（{mylist.Count} 条）";

            }

            //获得页数
            double pagetotal = Math.Ceiling(Convert.ToDouble(mylist.Count) / Convert.ToDouble(100));
            if (pagetotal == 0)
            {
                pagetotal = 1;
            }
            double currentpage = 1;
            tb_page.Text = $"{currentpage} / {pagetotal}";
            mylist= _mycontroller.GetDTByPage($"{currentpage} / {pagetotal}", 100, shtname);
            DataTable mydt = _mycontroller.List2DataTable(mylist);
            //}
            //将数据绑定到dgv_data
            //CommonMethod.AddXuhao(mydt);
            dgv_data.DataSource = null;
            //调整序号与正文内容
            _mycontroller.AddXuhao(mydt);

            dgv_data.DataSource = mydt;
        }

        private void Dgv_data_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    ((DataGridView)sender).ClearSelection();
                    ((DataGridView)sender).Rows[e.RowIndex].Selected = true;
                    ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgv_rightmenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        /// <summary>
        /// 点击右键菜单中删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mycontroller.DeleteZhengwen(lbl_dbname.Text, dgv_data.CurrentRow.Cells["编号"].Value.ToString());
            //刷新数据
            //获得数据表名称
            string shtname = lbl_dbname.Text;
            //获得该表下数据datatable
            string str_sql = $"select count(*) from {shtname}";

            var mylist=_mycontroller.GetDataFromTable(str_sql);

            lbl_shuliang.Text = $"（{ mylist.Count} 条）";
            //将数据绑定到dgv_data
            mylist = _mycontroller.GetDTByPage(tb_page.Text, 100, lbl_dbname.Text);

            dgv_data.DataSource = null;
            dgv_data.DataSource = mylist;

        }

        private void Pb_search_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.searchenter;
        }

        private void Pb_search_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.searchlv;

        }

        private void Pb_search_Click(object sender, EventArgs e)
        {
            //获得所有待查字段
            List<string> list_fields = new List<string>();
            for (int i = 0; i < dgv_data.Columns.Count; i++)
            {
                string str_head = dgv_data.Columns[i].HeaderText;
                if (str_head.Equals("zhengwenneirong") || str_head.Equals("laiyuan"))
                {
                    list_fields.Add(str_head);

                }
            }
            //获得表名
            string shtname = lbl_dbname.Text;
            //获得数据
            string keywords = tb_kw.Text;
           var mylist = _mycontroller.MohuChaxun(list_fields, keywords, shtname);
            DataTable dt = _mycontroller.List2DataTable(mylist);
            //页码显示为总页数分之1
            double pagenum = Math.Ceiling(Convert.ToDouble(dt.Rows.Count) / 100);
            int page = 1;
            tb_page.Text = $"{page} / {pagenum}";
            //获得页码对应的数据
            DataTable mydt = dt.Clone();
            for (int i = 100 * (page - 1); i < 100 * page; i++)
            {
                try
                {
                    mydt.ImportRow(dt.Rows[i]);

                }
                catch { }
            }
            //刷新数据
            dgv_data.DataSource = null;
            _mycontroller.AddXuhao(mydt);

            dgv_data.DataSource = mydt;
        }
        /// <summary>
        /// 点击时间排序按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label6_Click(object sender, EventArgs e)
        {
            try//软件设置表无法按照日期排序
            {
                if (((Label)sender).Text.Equals("时间排序 ↑"))
                {
                    dgv_data.Sort(dgv_data.Columns["日期"], ListSortDirection.Descending);
                    ((Label)sender).Text = "时间排序 ↓";
                }
                else
                {
                    dgv_data.Sort(dgv_data.Columns["日期"], ListSortDirection.Ascending);
                    ((Label)sender).Text = "时间排序 ↑";
                }
            }
            catch { }

        }
        /// <summary>
        /// 点击转载量排序按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_redupaixu_Click(object sender, EventArgs e)
        {
            try//软件设置表无法按照转载量和日期排序
            {
                if (((Label)sender).Text.Equals("转载量排序 ↑"))
                {
                    dgv_data.Sort(dgv_data.Columns["转载量"], ListSortDirection.Descending);
                    ((Label)sender).Text = "转载量排序 ↓";
                }
                else
                {
                    dgv_data.Sort(dgv_data.Columns["转载量"], ListSortDirection.Ascending);
                    ((Label)sender).Text = "转载量排序 ↑";
                }
            }
            catch { }


        }

        private void Lbl_shangyiye_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.DodgerBlue;
        }

        private void Lbl_shangyiye_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.FromName(" ControlText");
        }

        private void Lbl_xiayiye_Click(object sender, EventArgs e)
        {
            //获得页数
            string yeshu = tb_page.Text;
            //是否包含/
            int page = 0;
            int pagenum = 0;
            page = Convert.ToInt32(yeshu.Split(new char[] { '/' })[0]);
            pagenum = Convert.ToInt32(yeshu.Split(new char[] { '/' })[1]);
            page++;
            if (page > pagenum)
            {
                page = pagenum;
            }
            yeshu = $"{page } / { pagenum}";
            tb_page.Text = yeshu;
        }

        private void Lbl_shangyiye_Click(object sender, EventArgs e)
        {
            //获得页数
            string yeshu = tb_page.Text;
            //是否包含/
            int page = 0;
            int pagenum = 0;
            page = Convert.ToInt32(yeshu.Split(new char[] { '/' })[0]);
            pagenum = Convert.ToInt32(yeshu.Split(new char[] { '/' })[1]);
            page--;
            if (page == 0)
            {
                page = 1;
            }
            yeshu = $"{page } / { pagenum}";
            tb_page.Text = yeshu;

        }

        private void Tb_page_TextChanged(object sender, EventArgs e)
        {
            //判断搜索栏中是否有内容
            string kw = tb_kw.Text.Trim();
            if (kw.Equals(string.Empty))
            {
                    
                  var mylist  = _mycontroller.GetDTByPage(tb_page.Text, 100, lbl_dbname.Text);
                DataTable mydt = _mycontroller.List2DataTable(mylist);


                dgv_data.DataSource = null;
                _mycontroller.AddXuhao(mydt);
                dgv_data.DataSource = mydt;
            }
            else
            {
                //获得所有待查字段
                List<string> list_fields = new List<string>();
                for (int i = 0; i < dgv_data.Columns.Count; i++)
                {
                    string str_head = dgv_data.Columns[i].HeaderText;
                    if (str_head.Equals("laiyuan") || str_head.Equals("zhengwenneirong"))
                    {
                        list_fields.Add(str_head);

                    }
                }
                //获得表名
                string shtname = lbl_dbname.Text;
                //获得数据
                string keywords = tb_kw.Text;
                var mylist = _mycontroller.MohuChaxun(list_fields, keywords, shtname);
                DataTable dt = _mycontroller.List2DataTable(mylist);
                //页码显示为总页数分之1
                string yema = tb_page.Text;
                int pagenum = Convert.ToInt32(yema.Split(new char[] { '/' })[1]);
                int page = Convert.ToInt32(yema.Split(new char[] { '/' })[0]);
                tb_page.Text = $"{page} / {pagenum}";
                //获得页码对应的数据
                DataTable mydt = dt.Clone();
                for (int i = 100 * (page - 1); i < 100 * page; i++)
                {
                    try
                    {
                        mydt.ImportRow(dt.Rows[i]);

                    }
                    catch { }
                }
                //刷新数据
                dgv_data.DataSource = null;
                _mycontroller.AddXuhao(mydt);

                dgv_data.DataSource = mydt;


            }




        }

        private void Lbl_dbname_Click(object sender, EventArgs e)
        {

        }
    }
}
