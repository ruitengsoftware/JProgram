using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using RuiTengDll;
using 团队任务台账管理系统.WinForm;
using 团队任务台账管理系统.Properties;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCdenglu : UserControl
    {
        public UCdenglu()
        {
            InitializeComponent();
        }
        ControllerDenglu mycontroller = new ControllerDenglu();
        private void btn_denglu_Click(object sender, EventArgs e)
        {
            string name = tb_yonghuming.Text.Trim();
            string pwd = tb_mima.Text.Trim();
            bool successlogin = mycontroller.Login(name, pwd);//登录，并返回成功失败

            if (successlogin)
            {
                Settings.Default.user = name;
                var parent = this.Parent;
                parent.Controls.Clear();
                UCmain uc_main = new UCmain();
                uc_main.Dock = DockStyle.Fill;
                parent.Controls.Add(uc_main);
                ((SplitContainer)parent.Parent).Panel1Collapsed = false;
            }
            else
            {
                MessageBox.Show("登陆失败！");
            }
        }
        UIHelper uihelper = new UIHelper();
        private void UCdenglu_Load(object sender, EventArgs e)
        {
            uihelper.DrawRoundRect(lbl_denglu);
            uihelper.DrawRoundRect(panel_my);
            tableLayoutPanel2.BackColor = Color.FromArgb(0, 255, 255, 255);
           panel_my.BackColor = Color.FromArgb(90, 255, 255, 255);
            foreach (Control c in tableLayoutPanel2.Controls)
            {
                if (c.Text.Contains("登    录"))
                {
                    continue;
                }
                try
                {
                    c.BackColor = Color.FromArgb(0, 255, 255, 255);
                }
                catch { }
            }


        }

        private void lbl_denglu_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.MediumSeaGreen;
        }

        private void lbl_denglu_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.SeaGreen;

        }

        private void llbl_woyaozhuce_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WFzhuce mywf = new WFzhuce();
            mywf.ShowDialog();
        }
    }
}
