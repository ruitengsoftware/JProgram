﻿using System;
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
            this.splitContainer1.Panel2.Controls.Add(ucdenglu);
            
        }

        private void pb_home_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            UCmain uc_main = new UCmain();
            uc_main.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(uc_main);
        }

        private void pb_tuichu_Click(object sender, EventArgs e)
        {
            //清空panel
            splitContainer1.Panel2.Controls.Clear();
            //自动登录设置为false
            Settings.Default.zidongdenglu = false;
            //回退到登陆界面
            this.splitContainer1.Panel1Collapsed = true;
            this.Width = 1000;
            this.Height = 625;
            UCdenglu ucdenglu = new UCdenglu();
            ucdenglu.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(ucdenglu);
        }
    }
}
