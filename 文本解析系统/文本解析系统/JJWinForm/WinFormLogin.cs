using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormLogin : Form
    {
        JJController.ControllerLogin mycontroller = new JJController.ControllerLogin();
        public WinFormLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击登录按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_denglu_Click(object sender, EventArgs e)
        {
            string name = tb_yonghuming.Text.Trim();
            string pwd = tb_mima.Text.Trim();
            bool successlogin = mycontroller.Login(name, pwd);//登录，并返回成功失败
            if (successlogin)//如果登陆成功就进行
            {
                this.DialogResult = DialogResult.OK;
            }

            else
            {
                MessageBox.Show("登陆失败！");
            }
        }
    }
}
