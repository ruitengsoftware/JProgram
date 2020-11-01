using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZhuceDll;
//测试github的同步
namespace WindowsFormsApp2
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

            //1、从本机获得注册码
           ZhuceDll.Common.GetMNum();
           ZhuceDll.Common.GetRNum();
            //2、获得机器码，计算机器码
            ZhuceDll.Model.SName = "exceltoword";
            if (ZhuceDll.Common.TestRegist())
            {
                Application.Run(new Form1());

            }
            else {
                FormR fr = new FormR();
                if (fr.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    return;
                }
            }
        }
    }
}
