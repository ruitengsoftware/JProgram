using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StackExchange.Redis;






namespace 谦海数据解析系统.JJwinform
{

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        #region 无边框窗体移动
        private Point mPoint;
        private void WinFormXuanfu_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void WinFormXuanfu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion
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


        /// <summary>
        /// 点击登录按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_denglu_Click(object sender, EventArgs e)
        {
            string name = cbb_yonghuming.Text.Trim();
            string pwd = tb_mima.Text.Trim();
            bool successlogin = Login(name, pwd);//登录，并返回成功失败

            if (successlogin)//如果登陆成功就进行
            {
                //记录登录者信息
                List<string> list = Regex.Split(Properties.Settings.Default.alluser, ",").ToList();
                if (!list.Contains(name))
                {
                    list.Add(name);
                }
                list.Remove("");
                Properties.Settings.Default.alluser = string.Join(",", list);


                //获得登录者信息
                SystemInfo.GetUserInfo(name);
                //判断登录权限，如果没有权限就要退出本方法
                //if (LoginInfo._denlguquan == 0)
                //{
                //    MessageBox.Show("对不起，您暂无权限使用该系统！");
                //    return;
                //}



                //显示登陆者花名

                //var parent = this.Parent;
                //parent.Controls.Clear();
                //UCmain uc_main = new UCmain();
                //uc_main.Dock = DockStyle.Fill;
                //parent.Controls.Add(uc_main);
                //((SplitContainer)parent.Parent.Parent).Panel1Collapsed = false;
                //((Form1)parent.Parent.Parent.Parent).pb_touxiang.Image = mycontroller.ConvertBase64ToImage(JJModel.JJLoginInfo._touxiang);
                //settings获得自动登录，记住我，姓名，密码
                Properties.Settings.Default.lastuser = name;
                Properties.Settings.Default.lastpwd = pwd;
                Properties.Settings.Default.jizhumima = cb_jizhuwo.Checked;
                Properties.Settings.Default.zidongdenglu = cb_zidongdenlgu.Checked;
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("登陆失败！");
            }





        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //加载setting中的设置，用户名，全部用户，记住密码，自动登录
            //如果记住密码为true ，加载密码，否则显示为空
            //如果自动登录为true，则自动点击登录按钮
            string[] arr_user = Properties.Settings.Default.alluser.Split(',');
            cbb_yonghuming.Items.AddRange(arr_user);
            cb_jizhuwo.Checked = Properties.Settings.Default.jizhumima;
            cb_zidongdenlgu.Checked = Properties.Settings.Default.zidongdenglu;
            cbb_yonghuming.Text = Properties.Settings.Default.lastuser;
            if (cb_jizhuwo.Checked)
            {
                tb_mima.Text = Properties.Settings.Default.lastpwd;
            }




        }

        private void pb_guanbi_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        #region Controller


        string str_con = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        /// <summary>
        /// 使用用户名和密码登录，返回登陆结果
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Login(string uid, string pwd)
        {

            string str_sql = $"select count(*) from jjdbrenwutaizhang.jjperson where 花名=@uid and 密码=@pwd";
            int num = Convert.ToInt32(MySqlHelper.ExecuteScalar(str_con, str_sql,new MySqlParameter[] {
            new MySqlParameter("@uid",uid),
            new MySqlParameter("@pwd",pwd)
            
            }));
            return num > 0 ? true : false;
        }

        #endregion




    }
}
