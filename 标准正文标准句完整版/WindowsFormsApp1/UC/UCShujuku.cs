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
using BLL;
using Common;
using WindowsFormsApp1.Controller;

namespace WindowsFormsApp1.UC
{
    public partial class UCShujuku : UserControl
    {

        SqliteHelper mysqliter = null;
        UIHelper uihelper = new UIHelper();
        ControllerClickhouse mycontroller = new ControllerClickhouse();
        string dbfile = string.Empty;

        public UCShujuku()
        {
            InitializeComponent();
            dbfile = $"{Environment.CurrentDirectory}\\ruitengdb.db";
            mysqliter = new SqliteHelper(dbfile);
            mysqliter.Open();

        }

        /// <summary>
        /// 加载数据库管理用户控件时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCShujuku_Load(object sender, EventArgs e)
        {

            if (Setting._currentdb != string.Empty)
            {
                List<string> list_table = mycontroller.GetTablesName();
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
                List<string> list_table = mycontroller.GetTablesName();
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
                mycontroller.InsertDT2DB(mydt, Setting._currentdb);
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
            //判断是否选择了范围，如果没有，则每30000条保存一次
            DataTable mydt = dgv_data.DataSource as DataTable;


            if (tb_start.Text.Trim().Equals(string.Empty) && tb_end.Text.Trim().Equals(string.Empty))
            {
                mycontroller.SaveDtSplit(mydt, 30000, lbl_dbname.Text);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel 97-2003工作簿|*.xls|Excel 工作簿|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string houzhui = Path.GetExtension(sfd.FileName);
                    //将数据保存为excel
                    int start = Convert.ToInt32(tb_start.Text.Trim())-1;
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
            mycontroller.AddDatabase();
            //UCShujuku_Load(null, null);
        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label1_Click(object sender, EventArgs e)
        {
            mycontroller.DeleteDatabase(lbl_dbname.Text);
            UCShujuku_Load(null, null);

        }
        /// <summary>
        /// 点击编辑按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label3_Click(object sender, EventArgs e)
        {
            mycontroller.EditDatabase(lbl_dbname.Text);

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
            //获得该表下数据datatable
            string str_sql = $"select * from {shtname}";
            mycontroller.SelectDB("default");
            DataTable mydt = mycontroller.GetDataFromTable(str_sql);

            lbl_shuliang.Text = $"（{mydt.Rows.Count} 条）";
            //将数据绑定到dgv_data
            CommonMethod.AddXuhao(mydt);
            dgv_data.DataSource = null;
            dgv_data.DataSource = mydt;

        }
    }
}
