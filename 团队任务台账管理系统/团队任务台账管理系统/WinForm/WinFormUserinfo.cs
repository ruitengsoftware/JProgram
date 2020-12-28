using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.UserControll;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WinFormUserinfo : Form
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

        public WinFormUserinfo()
        {
            InitializeComponent();
        }

        private void WinFormUserinfo_Load(object sender, EventArgs e)
        {
            lbl_nicheng.Text = $"实名:{JJLoginInfo._shiming}({JJLoginInfo._huaming})";
            lbl_zhijizhiwu.Text = $"职级:{JJLoginInfo._zhiji}";
           tb_gexingqianming.Text = JJLoginInfo._gerenqianming;

        }

        private void lbl_xiugai_Click(object sender, EventArgs e)
        {
            string zhuangtai = lbl_xiugai.Text;
            if (zhuangtai.Equals("修改"))
            {

                tb_gexingqianming.BorderStyle = BorderStyle.FixedSingle;
                tb_gexingqianming.Focus();
                lbl_xiugai.Text = "保存";
            }
            else
            {
                tb_gexingqianming.BorderStyle = BorderStyle.None;
                bool b = UpdateGerenqianming(tb_gexingqianming.Text);
                lbl_xiugai.Text = "修改";

            }
        }
        MySQLHelper _mysqlhelper = new MySQLHelper();

        public bool UpdateGerenqianming(string qianming)
        {
            string sql_sql = $"update jjdbrenwutaizhang.jjperson set 个人签名='{qianming}' where 花名='{JJLoginInfo._huaming}'";
            int num = _mysqlhelper.ExecuteNonQuery(sql_sql);
            return num > 0 ? true : false;

        }

        private void WinFormUserinfo_MouseLeave(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_gerenziliao_Click(object sender, EventArgs e)
        {
            this.Dispose();
            ////弹出注册窗体
            WFzhuce mywin = new WFzhuce(0);
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                //更新头像
                //this.parent pb_touxiang.Image = _mycontroller.ConvertBase64ToImage(JJModel.JJLoginInfo._touxiang);
                JJLoginInfo.GetLoginInfo(JJLoginInfo._huaming);
            }

        }
    }
}
