using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 谦海数据采集管理系统.JJWinForm
{
    public partial class JJWFLogin : Form
    {
        public JJWFLogin()
        {
            InitializeComponent();
        }

        private void lbl_denglu_Click(object sender, EventArgs e)
        {
            //根据用户民共和密码判断登录是否成功如果成功，让dialogresult=ok
            //记录用户登录信息
            string username = tb_yonghuming.Text;
            string pwd = tb_mima.Text;
            string str_sql = $"select count(*) from 谦海数据库.人员信息表 " +
                $"where 用户名='{username}' and 密码='{pwd}'";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
            int num = Convert.ToInt32(MySqlHelper.ExecuteScalar(constr, str_sql));
            if (num>0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
