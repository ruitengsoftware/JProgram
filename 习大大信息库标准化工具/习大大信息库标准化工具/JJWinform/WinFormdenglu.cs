using RuiTengDll;
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
using 习大大信息库标准化工具.JJCommon;
using 习大大信息库标准化工具.JJController;
using 习大大信息库标准化工具.Properties;

namespace 习大大信息库标准化工具.JJWinForm
{
    public partial class WinFormdenglu : Form
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



        public WinFormdenglu()
        {
            InitializeComponent();
        }
        private void WinFormLogin_Load(object sender, EventArgs e)
        {
            this.Size = new Size(310, 410);
            UIHelper.DrawRoundRect(this);
            UIHelper.DrawRoundRect(lbl_denglu);
            tableLayoutPanel2.BackColor = Color.FromArgb(0, 255, 255, 255);
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

        private void lbl_denglu_Click(object sender, EventArgs e)
        {
            string name = cbb_yonghuming.Text.Trim();
            string pwd = tb_mima.Text.Trim();
            bool successlogin =Login(name, pwd);//登录，并返回成功失败

           




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


                //获得登录者信息
                JJuserinfo.GetLoginInfo(name);
                //判断登录权限，如果没有权限就要退出本方法
                if (JJuserinfo._denlguquan==0)
                {
                    MessageBox.Show("对不起，您暂无权限使用该系统！");
                    return;
                }



                //显示登陆者花名

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
            UIHelper.UpdateCC((Control)sender, Color.MediumSeaGreen, Color.White);
        }

        private void lbl_denglu_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCC((Control)sender, Color.SeaGreen, Color.White);
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

        private void lbl_tuichu_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void lbl_tuichu_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void llbl_wangjimima_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFormZhaohuimima mywin = new WinFormZhaohuimima() {
                StartPosition = FormStartPosition.CenterParent
            };
            if (mywin.ShowDialog()==DialogResult.OK)
            {

            }


        }





        #region  controller

        MySqlHelper mysqlhelper = new MySqlHelper();


        //判断是否存在用户名和密码
        public bool Login(string uid, string pwd)
        {
            string str_sql = $"select count(*) from jjdbrenwutaizhang.jjperson where 花名='{uid}' and 密码='{pwd}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 将图片转换为base64编码
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string ConvertImageToBase64(Image file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.Save(memoryStream, file.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
        /// <summary>
        /// 将64位编码转化成图片
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public Image ConvertBase64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    return Image.FromStream(ms, true);
                }

            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
