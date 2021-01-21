using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.JJWinForm;
using 团队任务台账管理系统.WinForm;

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
            //判断是否存在新版本，如果不存在，直接登录，如果存在，显示正在下载框
            //先下载软件新版本
            //获得数据库最新软件的版本
            MySQLHelper _mysql = new MySQLHelper();
            string str_sql = $"select * from jjdbrenwutaizhang.附件信息表 " +
                $"where 类型='系统'";
            var mydr = _mysql.ExecuteDataRow(str_sql);
            string newversion = mydr["文件名"].ToString();

            if (newversion != Properties.Settings.Default.version)
            {
                //升级程序位置
                string fileupdate =Application.StartupPath+ $"\\update\\UpdateOA.exe";
                //打开更新程序
                System.Diagnostics.Process.Start(fileupdate);
                //杀掉自身程序
                System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("团队任务台账管理系统");
                foreach (System.Diagnostics.Process pro in proc)
                {
                    pro.Kill();
                }


                ////显示正在下载窗体
                //WinFormVersion mywin0 = new WinFormVersion(mydr);
                //if (mywin0.ShowDialog()==DialogResult.OK)
                //{
                //    System.Diagnostics.Process.Start(Application.StartupPath + $"团队任务台账管理系统.exe");
                //}
            }



            //先弹出登录窗体，如果成功返回dialogresult.ok 
            WinFormdenglu mywin = new WinFormdenglu()
            {
                TopLevel = true
            };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                JJLoginInfo._huaming = mywin._huaming;
                //JJLoginInfo.GetLoginInfo(JJLoginInfo._huaming);
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
