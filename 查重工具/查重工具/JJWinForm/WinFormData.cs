using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 查重工具.JJCommon;

namespace 查重工具.JJWinForm
{
    public partial class WinFormData : Form
    {
        public WinFormData()
        {
            InitializeComponent();

        }

        private void WinFormData_Load(object sender, EventArgs e)
        {
            cbb_ku.Items.Clear();
            List<string> list = GetAllTablesName();
            list.Remove("格式信息表");
            cbb_ku.Items.AddRange(list.ToArray());
            cbb_ku.SelectedIndex = 0;
        }
        JJMySQLHelper my_sql = new JJMySQLHelper();
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string tablename = cbb_ku.Text;
            //刷新页码条的显示
            string str_sql = $"select count(md5) from 查重工具库.{tablename}";
            decimal pagenum = Math.Ceiling(Convert.ToDecimal(my_sql.ExecuteScalar(str_sql)) / 200);
            label2.Text = $"共 {pagenum} 页";

            tb_page.Text = "1";
            btn_shouye_Click(null, null);


        }

        private void btn_shouye_Click(object sender, EventArgs e)
        {
            string tablename = cbb_ku.Text;
            tb_page.Text = "1";
            int pagenum = Convert.ToInt32(tb_page.Text);

            string str_sql = $"select * from 查重工具库.{tablename} limit {(pagenum - 1) * 200},200";
            DataTable mydt = my_sql.ExecuteDataTable(str_sql);
            UpdateDgv(mydt);

        }

        void UpdateDgv(DataTable mydt)
        {

            dgv_data.DataSource = null;
            dgv_data.DataSource = mydt;
            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                dgv_data.Rows[i].Cells[0].Value = i + 1;


            }

        }

        private void tb_page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int pagesnum = Convert.ToInt32(Regex.Match(label2.Text, @"\d+").Value);
                if (Convert.ToInt32(tb_page.Text) < 1)
                {
                    tb_page.Text = "1";
                }
                if (Convert.ToInt32(tb_page.Text) > pagesnum)
                {
                    tb_page.Text = pagesnum.ToString();
                }



                string tablename = cbb_ku.Text;
                int pagenum = Convert.ToInt32(tb_page.Text);
                string str_sql = $"select * from 查重工具库.{tablename} limit {(pagenum - 1) * 200},200";
                DataTable mydt = my_sql.ExecuteDataTable(str_sql);
                UpdateDgv(mydt);

            }
        }

        private void btn_shangyiye_Click(object sender, EventArgs e)
        {
            string tablename = cbb_ku.Text;
            tb_page.Text = (Convert.ToInt32(tb_page.Text) - 1).ToString();
            int pagenum = Convert.ToInt32(tb_page.Text);
            if (pagenum > 0)
            {
                string str_sql = $"select * from 查重工具库.{tablename} limit {(pagenum - 1) * 200},200";
                DataTable mydt = my_sql.ExecuteDataTable(str_sql);
                UpdateDgv(mydt);

            }


        }

        private void btn_xiayiye_Click(object sender, EventArgs e)
        {


            string tablename = cbb_ku.Text;
            tb_page.Text = (Convert.ToInt32(tb_page.Text) + 1).ToString();
            int pagenum = Convert.ToInt32(tb_page.Text);
            int pagesnum = Convert.ToInt32(Regex.Match(label2.Text, @"\d+").Value);

            if (pagenum <= pagesnum)
            {
                string str_sql = $"select * from 查重工具库.{tablename} limit {(pagenum - 1) * 200},200";
                DataTable mydt = my_sql.ExecuteDataTable(str_sql);
                UpdateDgv(mydt);

            }

        }

        private void btn_weiye_Click(object sender, EventArgs e)
        {
            string tablename = cbb_ku.Text;
            int pagesnum = Convert.ToInt32(Regex.Match(label2.Text, @"\d+").Value);
            tb_page.Text = pagesnum.ToString();
            int pagenum = Convert.ToInt32(tb_page.Text);



            if (pagenum <= pagesnum)
            {
                string str_sql = $"select * from 查重工具库.{tablename} limit {(pagenum - 1) * 200},200";
                DataTable mydt = my_sql.ExecuteDataTable(str_sql);
                UpdateDgv(mydt);

            }

        }

        /// <summary>
        /// 获得所有查重表名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllTablesName()
        {
            List<string> list = new List<string>();

            string str_sql = $"select table_name from information_schema.tables where table_schema='查重工具库'";
            DataTable mydt = my_sql.ExecuteDataTable(str_sql);
            foreach (DataRow dr in mydt.Rows)
            {
                list.Add(dr["table_name"].ToString());
            }
            return list;

        }
        private void cbb_ku_DropDown(object sender, EventArgs e)
        {
            cbb_ku.Items.Clear();
            List<string> list = GetAllTablesName();
            list.Remove("格式信息表");
            cbb_ku.Items.AddRange(list.ToArray());
        }
    }
}
