using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFbumen : Form
    {
        public WFbumen()
        {
            InitializeComponent();
        }

        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public string str_select = string.Empty;
        private void btn_queding_Click(object sender, EventArgs e)
        {
            str_select = tv_my.SelectedNode.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void WFbumen_Load(object sender, EventArgs e)
        {
            tv_my.Nodes.Add("全部", "全部");
            var data_bumen = GetAllBumen();
            //添加一级部门
            foreach (DataRow dr in data_bumen.Rows)
            {
                //TreeNode tr = new TreeNode(dr["所属部门"].ToString());
                if (dr["级别"].ToString().Equals("一级部门"))
                {
                    tv_my.Nodes["全部"].Nodes.Add(dr["名称"].ToString(), dr["名称"].ToString());
                }
            }
            //添加二级部门
            foreach (DataRow dr in data_bumen.Rows)
            {
                //TreeNode tr = new TreeNode(dr["所属部门"].ToString());
                if (dr["级别"].ToString().Equals("二级部门"))
                {

                    tv_my.Nodes["全部"].Nodes[dr["所属部门"].ToString()].Nodes.Add(dr["名称"].ToString(), dr["名称"].ToString());
                }
            }

        }
        MySQLHelper _mysql = new MySQLHelper();
        /// <summary>
        /// 获得所有的部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBumen()
        {
            string str_sql = "select * from jjdbrenwutaizhang.部门信息表 where 删除=0 order by 名称";
            var data = _mysql.ExecuteDataTable(str_sql);
            return data;
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
    }
}
