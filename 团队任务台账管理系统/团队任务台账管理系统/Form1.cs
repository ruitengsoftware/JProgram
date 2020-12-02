using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Properties;
using 团队任务台账管理系统.UserControll;

namespace 团队任务台账管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //UserControl myuc = new UserControl();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = true;
            this.Width = 1000;
            this.Height = 625;
            UCdenglu ucdenglu = new UCdenglu();
            ucdenglu.Dock = DockStyle.Fill;
            panel_my.Controls.Add(ucdenglu);
            
        }

        private void pb_home_Click(object sender, EventArgs e)
        {
            panel_my.Controls.Clear();
            UCmain uc_main = new UCmain();
            uc_main.Dock = DockStyle.Fill;
           panel_my.Controls.Add(uc_main);
        }

        private void pb_tuichu_Click(object sender, EventArgs e)
        {
            //清空panel
            panel_my.Controls.Clear();
            //自动登录设置为false
            Settings.Default.zidongdenglu = false;
            //回退到登陆界面
            this.splitContainer1.Panel1Collapsed = true;

            this.Width = 1000;
            this.Height = 625;
            UCdenglu ucdenglu = new UCdenglu();
            ucdenglu.Dock = DockStyle.Fill;

           panel_my.Controls.Add(ucdenglu);
        }

        private void pb_touxiang_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_wodedaiban_Click(object sender, EventArgs e)
        {
            panel_my.Controls.Clear();
            UCdaiban uc_daiban = new UCdaiban();
            uc_daiban.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_daiban); 

        }

        private void btn_wodeyanshou_Click(object sender, EventArgs e)
        {
            panel_my.Controls.Clear();
            UCdaiban uc_daiban = new UCdaiban();
            uc_daiban.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_daiban);
        }

        private void btn_daiban_Click(object sender, EventArgs e)
        {
           panel_my.Controls.Clear();
            UCdaiban uc_daiban = new UCdaiban();
            uc_daiban.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_daiban);
        }

        private void btn_yanshou_Click(object sender, EventArgs e)
        {
            panel_my.Controls.Clear();
            UCdaiban uc_daiban = new UCdaiban();
            uc_daiban.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_daiban);
        }

        private void btn_shezhi_Click(object sender, EventArgs e)
        {
            panel_my.Controls.Clear();

            panel_my.Controls.Add(new UCshouquan() { Dock = DockStyle.Fill });
        }



        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
           panel_my.Controls.Clear();
            UCxinjian uc_xinjian = new UCxinjian();
            uc_xinjian.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_xinjian);

        }

        private void btn_tuandui_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            panel_my.Controls.Clear();
            UCtuandui uc_tuandui = new UCtuandui();
            uc_tuandui.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_tuandui);

        }

        private void btn_rizhi_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCrizhi uc_rizhi = new UCrizhi();
            uc_rizhi.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_rizhi);
        }

        private void btn_fankui_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(new UCfankui() { Dock = DockStyle.Fill }); ;
        }

        private void btn_xiaoxiang_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            panel_my.Controls.Clear();

            panel_my.Controls.Add(new UCxiaoxiang() { Dock = DockStyle.Fill }); ;

        }

        private void btn_shouquan_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            panel_my.Controls.Clear();

            panel_my.Controls.Add(new UCshouquan() { Dock = DockStyle.Fill });

        }

    }
}
