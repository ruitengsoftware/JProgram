using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 谦海数据采集管理系统
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


            //显示登录画面，如果登录成功，显示主界面
            JJWinForm.JJWFLogin mywin = new JJWinForm.JJWFLogin();
            if (mywin.ShowDialog() == DialogResult.OK)
            {

                Application.Run(new Form1());

            }

        }
    }
}
