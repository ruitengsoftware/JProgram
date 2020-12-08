using RuiTengDll;
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
using 文本解析系统.JJCommon;
using 文本解析系统.JJController;
using 文本解析系统.Properties;

namespace 文本解析系统.JJWinForm
{
    public partial class UCdenglu : Form
    {
        public UCdenglu()
        {
            InitializeComponent();
        }
        UIHelper uihelper = new UIHelper();
        private void WinFormLogin_Load(object sender, EventArgs e)
        {
            this.Size = new Size(310, 410);
            uihelper.DrawRoundRect(this);
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
            //加载登陆者到列表中去

            cbb_yonghuming.Items.AddRange(Regex.Split(Properties.Settings.Default.loginnames, ","));
            //显示上次登录的用户名
            cbb_yonghuming.Text = Settings.Default.huaming;
            //给记住我，姓名，密码 自动登录赋值
            if (Settings.Default.jizhumima)
            {

                cb_jizhuwo.Checked = true;
                tb_mima.Text = Settings.Default.mima;
            }
            cb_zidongdenlgu.Checked = Settings.Default.zidongdenglu;
            //如果自动登录打勾，那么
            if (cb_zidongdenlgu.Checked)
            {
                tb_mima.Text = Settings.Default.mima;
                lbl_denglu_Click(null, null);
            }
        }
        ControllerDenglu mycontroller = new ControllerDenglu();

        private void lbl_denglu_Click(object sender, EventArgs e)
        {
            string name = cbb_yonghuming.Text.Trim();
            string pwd = tb_mima.Text.Trim();
            bool successlogin = mycontroller.Login(name, pwd);//登录，并返回成功失败

            if (successlogin)//如果登陆成功就进行
            {
                //记录登录者信息
                List<string> list = Regex.Split(Properties.Settings.Default.loginnames, ",").ToList();
                if (!list.Contains(name))
                {
                    list.Add(name);
                }
                list.Remove("");
                Properties.Settings.Default.loginnames = string.Join(",", list);
                //记录用户花名，用于在软件界面显示
                UserInfo._huaming = name;
                //获得登录者信息
                 //mycontroller.GetLoginInfo(name);

                //var parent = this.Parent;
                //parent.Controls.Clear();
                //UCmain uc_main = new UCmain();
                //uc_main.Dock = DockStyle.Fill;
                //parent.Controls.Add(uc_main);
                //((SplitContainer)parent.Parent.Parent).Panel1Collapsed = false;
                //((Form1)parent.Parent.Parent.Parent).pb_touxiang.Image = mycontroller.ConvertBase64ToImage(JJModel.JJLoginInfo._touxiang);
                //settings获得自动登录，记住我，姓名，密码
                Settings.Default.huaming = name;
                Settings.Default.mima = pwd;
                Settings.Default.jizhumima = cb_jizhuwo.Checked;
                Settings.Default.zidongdenglu = cb_zidongdenlgu.Checked;
                Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("登陆失败！");
            }
        }

        private void lbl_denglu_MouseEnter(object sender, EventArgs e)
        {
            uihelper.UpdateCC((Control)sender, Color.MediumSeaGreen, Color.White);
        }

        private void lbl_denglu_MouseLeave(object sender, EventArgs e)
        {
            uihelper.UpdateCC((Control)sender, Color.SeaGreen, Color.White);
        }
        //判断密码的显示状态
        bool xianshi = false;

        private void pb_xianshi_Click(object sender, EventArgs e)
        {
            //如果是隐藏，那么密码显示为星号，图片变成显示
            if (xianshi)
            {
                tb_mima.PasswordChar = '*';
                pb_xianshi.Image = Properties.Resources.xianshi;
                xianshi = false;
            }
            else if (!xianshi)
            {
                tb_mima.PasswordChar = new char();
                pb_xianshi.Image = Properties.Resources.yincang;
                xianshi =true;
            }
        }
    }
}
