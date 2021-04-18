using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 习大大信息库标准化工具.JJWinForm;

namespace 习大大信息库标准化工具
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

            //先弹出登录窗体，如果成功返回dialogresult.ok 
            WinFormdenglu mywin = new WinFormdenglu();
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());

            }


        }
    }
}
