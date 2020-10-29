using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文本解析系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            JJWinForm.WinFormLogin mywin = new JJWinForm.WinFormLogin();
            if (mywin.ShowDialog()==DialogResult.OK)
            {
            Application.Run(new Form1());

            }
            else
            {
                MessageBox.Show("登陆失败！");
                return;
            }
        }
    }
}
