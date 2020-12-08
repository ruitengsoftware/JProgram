using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJWinForm;

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

            //先弹出登录窗体，如果成功返回dialogresult.ok 
            UCdenglu mywin = new UCdenglu();
            if (mywin.ShowDialog()==DialogResult.OK)
            {
            Application.Run(new Form1());

            }


           

        }
    }
}
