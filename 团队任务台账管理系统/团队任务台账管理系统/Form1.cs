﻿using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.JJWinForm;
using 团队任务台账管理系统.Properties;
using 团队任务台账管理系统.UserControll;
using 团队任务台账管理系统.WinForm;

namespace 团队任务台账管理系统
{

    public partial class Form1 : Form
    {


        #region 窗体四周阴影
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
     );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                //cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }

        #endregion
        ControllerForm1 _mycontroller = new ControllerForm1();
        public Form1()
        {
            InitializeComponent();
            JJLoginInfo._form1 = this;
            JJLoginInfo.GetLoginInfo(JJLoginInfo._huaming);

        }
        //UserControl myuc = new UserControl();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "写手OA系统 " + JJSystemInfo._version;
            JJMethod.a_checknewtask = timer1_Tick;//给公共方法赋值
            JJMethod.a_shuaxinzhuye = pb_home_Click;
            JJMethod.nf = notifyIcon1;

            //this.FormBorderStyle = FormBorderStyle.None;
            lbl_woderenwu_Click(lbl_wodezhuye, null);



            //是否有新消息
            int num = JJLoginInfo.GetWeiduTaskNum();
            if (num > 0)
            {
                JJLoginInfo.newmsgnum = num;

                lbl_newtask.Visible = true;
                lbl_newtask.Text = $"{num}";
               
                myt.Start();
            }




            //开始监听新任务
            timer1.Start();
        }

        private void pb_home_Click(object sender, EventArgs e)
        {
            panel_my.Controls.Clear();
            UCmain uc_main = new UCmain(new List<string> { "通知公告", "待办任务", "工作清单" });
            uc_main.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_main);
        }

        private void pb_tuichu_Click(object sender, EventArgs e)
        {
            this.Hide();
            WinFormdenglu mywin = new WinFormdenglu();
            ////自动登录设置为false
            Settings.Default.zidongdenglu = false;

            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                JJLoginInfo.GetLoginInfo(JJLoginInfo._huaming);
                lbl_woderenwu_Click(lbl_wodezhuye, null);
                this.Show();
            };

            ////清空panel
            //panel_my.Controls.Clear();
            ////回退到登陆界面
            //this.splitContainer1.Panel1Collapsed = true;

            //this.Width = 1000;
            //this.Height = 625;
            //UCdenglu ucdenglu = new UCdenglu();
            //ucdenglu.Dock = DockStyle.Fill;

            //panel_my.Controls.Add(ucdenglu);
        }
        WinFormUserinfo mywin = null;
        private void pb_touxiang_Click(object sender, EventArgs e)
        {
            if (mywin != null)
            {
                mywin.Dispose();
            }


            mywin = new WinFormUserinfo();
            mywin.Show();
            mywin.Location = new Point(MousePosition.X, MousePosition.Y);

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
            HighControl(sender);

            panel_my.Controls.Clear();
            UCmain uc_main = new UCmain(new List<string> { "待办任务" });
            uc_main.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_main);



            //panel_my.Controls.Clear();
            //UCdaiban uc_daiban = new UCdaiban();
            //uc_daiban.Dock = DockStyle.Fill;
            //panel_my.Controls.Add(uc_daiban);
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
            HighControl(sender);

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
            HighControl(sender);

            var parent = this.Parent;
            panel_my.Controls.Clear();

            panel_my.Controls.Add(new UClishiziliao() { Dock = DockStyle.Fill }); ;

        }

        private void btn_shouquan_Click(object sender, EventArgs e)
        {
            HighControl(sender);

            var parent = this.Parent;
            panel_my.Controls.Clear();

            panel_my.Controls.Add(new UCshouquan() { Dock = DockStyle.Fill });

        }

        private void btn_tongxunlu_Click(object sender, EventArgs e)
        {
            HighControl(sender);

            UCbumentongxun myuc = new UCbumentongxun() { Dock = DockStyle.Fill };


            //UCtongxunlu myuc = new UCtongxunlu();
            panel_my.Controls.Clear();
            panel_my.Controls.Add(myuc);
        }

        private void lbl_woderenwu_Click(object sender, EventArgs e)
        {
            HighControl(sender);

            //panel_my.Controls.Add(new UCMytask() { Dock = DockStyle.Fill });
            panel_my.Controls.Clear();
            UCmain uc_main = new UCmain(new List<string> { "通知公告", "待办任务", "工作清单" });
            uc_main.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_main);

        }


        Timer myt = new Timer();

        private void timer1_Tick(object sender, EventArgs e)
        {
            //获得新消息，如果数量大于一，在 我的任务右侧显示红点
            int num = JJLoginInfo.GetWeiduTaskNum();
            if (num > 0)
            {
                lbl_newtask.Visible = true;
                lbl_newtask.Text = $"{num}";
                //判断软件目前界面是否为我的主页，如果是的话需要刷新
                if (lbl_wodezhuye.BackColor==Color.White)
                {
                    if (num> JJLoginInfo.newmsgnum)
                    {
                    JJMethod.a_shuaxinzhuye(null, null);
                        JJLoginInfo.newmsgnum = num;
                    }

                }
            }
            else
            {
                lbl_newtask.Visible = false;
            }

        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        private void pb_touxiang_MouseMove(object sender, MouseEventArgs e)
        {
            if (mywin != null)
            {
                mywin.Dispose();
            }
        }
        /// <summary>
        /// 点击工作清单按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gongzuoqingdan_Click(object sender, EventArgs e)
        {
            HighControl(sender);

            panel_my.Controls.Clear();
            UCmain uc_main = new UCmain(new List<string> { "工作清单" });
            uc_main.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_main);

        }

        private void btn_tongzhigonggao_Click(object sender, EventArgs e)
        {
            HighControl(sender);

            panel_my.Controls.Clear();
            UCmain uc_main = new UCmain(new List<string> { "通知公告" });
            uc_main.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_main);

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btn_gongxiangziliao_Click(object sender, EventArgs e)
        {
            HighControl(sender);

            panel_my.Controls.Clear();
            UCwodeyunpan uc_main = new UCwodeyunpan();
            uc_main.Dock = DockStyle.Fill;
            panel_my.Controls.Add(uc_main);

        }

        private void HighControl(object sender)
        {
           
            

            foreach (Control control in panel1.Controls)
            {
                control.BackColor = Color.DimGray;
                control.ForeColor = Color.White;
            }
            ((Control)sender).BackColor = Color.White;
            ((Control)sender).ForeColor = Color.Black;
            lbl_newtask.BackColor = lbl_wodezhuye.BackColor;
            Application.DoEvents();
        }

        private void lbl_newtask_Click(object sender, EventArgs e)
        {
            JJLoginInfo.newmsgnum =Convert.ToInt32( lbl_newtask.Text);
        }

        private void lbl_ruanjiangengxin_Click(object sender, EventArgs e)
        {
            //弹出软件新旧版本窗体
            WinFormVersion mywin = new WinFormVersion() { 
            StartPosition=FormStartPosition.CenterScreen
            };
            mywin.Show();


        }
        /// <summary>
        /// 点击我的任务按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_woderenwu_Click_1(object sender, EventArgs e)
        {
            HighControl(sender);

            panel_my.Controls.Clear();
            UCMytask myuc = new UCMytask() {
                Dock = DockStyle.Fill
            };
            panel_my.Controls.Add(myuc);


        }
    }
}
