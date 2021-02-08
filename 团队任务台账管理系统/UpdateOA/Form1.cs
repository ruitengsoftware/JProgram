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
using static UpdateOA.MySqlHelper;

namespace UpdateOA
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

        public Form1()
        {
            InitializeComponent();
        }

            //获得update所在目录
            string pathupdate = Directory.GetCurrentDirectory();

            //获得oa系统所在目录
            string pathoa = Directory.GetParent(Application.StartupPath).FullName;

        private async void Form1_Load(object sender, EventArgs e)
        {
            MySQLHelper _mysql = new MySQLHelper();
            string str_sql = $"select * from jjdbrenwutaizhang.附件信息表 " +
                $"where 类型='系统'";
            var _mydr = _mysql.ExecuteDataRow(str_sql);
            //获得最新版本号，显示在界面上

            string str_version = _mydr["文件名"].ToString();
            lbl_version.Text = str_version;
            //获得服务器路径
            string webpath = _mydr["全路径"].ToString();
            //下载文件
            await JJMethod.DownLoadFileAsync(webpath, pathupdate + $"\\{Path.GetFileName(webpath)}");
            //解压到当前文件夹
            //JJMethod.UnZip(pathupdate + $"\\{Path.GetFileName(webpath)}", pathoa);
           await JJMethod.Compress(pathoa, pathupdate + $"\\{Path.GetFileName(webpath)}", null);
            
            //删除压缩包
            File.Delete(pathupdate + $"\\{Path.GetFileName(webpath)}");
            //显示进入界面按钮
            lbl_jinru.Visible = true;
            label1.Text = "版本更新已完成！";
        }

        private void InterVal(int time)
        {
            var t = DateTime.Now.AddMilliseconds(time);
            while (DateTime.Now < t) Application.DoEvents();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCC((Control)sender, Color.CornflowerBlue,Color.White);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCC((Control)sender, Color.DodgerBlue, Color.White);
        }

        private void lbl_jinru_Click(object sender, EventArgs e)
        {
            //打开OA程序
            System.Diagnostics.Process.Start(pathoa + "\\团队任务台账管理系统.exe");
            //杀掉自身程序
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("UpdateOA");
            foreach (System.Diagnostics.Process pro in proc)
            {
                pro.Kill();
            }


        }
    }
}
