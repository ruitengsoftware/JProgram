using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 查重工具.JJCommon;

namespace 查重工具
{
    public partial class WinFormNewTask : Form
    {
        public string _wenjianjia = string.Empty;
        public string _geshi = string.Empty;
        JJMySQLHelper _mysql = new JJMySQLHelper();
        public WinFormNewTask()
        {
            InitializeComponent();
        }

        private void cbb_format_DropDown(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            string str_sql = $"select 名称 from 查重工具库.格式信息表 where 删除=0";
            DataTable mydt = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow dr in mydt.Rows)
            {
                list.Add(dr["名称"].ToString());
            }
            cbb_format.Items.AddRange(list.ToArray());
        }

        private void cbb_format_TextChanged(object sender, EventArgs e)
        {
            _geshi = cbb_format.Text;
        }

        private void pb_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_folder.Text = fbd.SelectedPath;

                _wenjianjia = fbd.SelectedPath;
            }
        }

        private void btn_queding_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
