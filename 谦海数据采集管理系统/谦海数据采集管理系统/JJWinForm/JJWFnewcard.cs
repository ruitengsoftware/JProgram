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
using 谦海数据采集管理系统.JJModel;

namespace 谦海数据采集管理系统.JJWinForm
{
    public partial class JJWFnewcard : Form
    {
      public  JJTaskInfo _myTaskInfo = new JJTaskInfo();



        public JJWFnewcard()
        {
            InitializeComponent();
        }

        private void lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击保存按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            string str_sql = $"insert into 谦海数据库.任务信息表(名称,描述,优先级,创建人,创建时间,删除)" +
                $"values('{tb_mingcheng.Text}','{tb_miaoshu.Text}','{cbb_youxianji.Text}'," +
                $"'{JJUserInfo._xingming}','{DateTime.Now.ToString()}',0)";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();

            int num = MySqlHelper.ExecuteNonQuery(constr, str_sql);

            if (num > 0)
            {
                _myTaskInfo._mingcheng = tb_mingcheng.Text;
                _myTaskInfo._miaoshu = tb_miaoshu.Text;
                _myTaskInfo._youxianji = cbb_youxianji.Text;
                _myTaskInfo._chuangjianren = JJUserInfo._xingming;
                _myTaskInfo._chuangjianshijian = DateTime.Now.ToString();


                MessageBox.Show($"任务卡 [{tb_mingcheng.Text}] 已添加成功！");
                this.DialogResult = DialogResult.OK;
            }

        }
    }
}
