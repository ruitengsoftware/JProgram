using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.JJWinForm;

namespace 团队任务台账管理系统
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
                JJLoginInfo._huaming = mywin._huaming;
                Form1 myform1 = new Form1();
                //判断登录权限，如果没有权限就要退出本方法
                if (JJLoginInfo._denlguquan == 0)
                {
                    MessageBox.Show("对不起，您暂无权限使用该系统！");
                    return;
                }

                Application.Run(myform1);
            }
        }
    }
}
