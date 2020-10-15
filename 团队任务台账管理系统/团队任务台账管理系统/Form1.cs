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
            this.splitContainer2.Panel1Collapsed = true;
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
            this.splitContainer2.Panel1Collapsed = true;

            this.Width = 1000;
            this.Height = 625;
            UCdenglu ucdenglu = new UCdenglu();
            ucdenglu.Dock = DockStyle.Fill;

           panel_my.Controls.Add(ucdenglu);
        }

        private void pb_touxiang_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel1Collapsed == false)

            {
                
                splitContainer2.Panel1Collapsed = true;
            }
            else
            {
                splitContainer2.SplitterDistance = 100;
                splitContainer2.Panel1Collapsed = false;
            }
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
    }
}
