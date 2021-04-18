using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 谦海数据解析系统.JJwinform
{
    public partial class NewBQKForm : Form
    {
        public NewBQKForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击取消按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击确定按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            string str_sql = $"insert into 数据解析库.内容标签表 " +
                $"value('{tb_biaoqiankuming.Text}','内容标签',1,'无','null','{SystemInfo._userInfo._shiming}','{DateTime.Now.ToString("yyyy-MM-dd")}',0)";
            MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
            MessageBox.Show($"数据库 {tb_biaoqiankuming.Text} 已新建成功！");
            this.DialogResult = DialogResult.OK;
        }
    }
}
