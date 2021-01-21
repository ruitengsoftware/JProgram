using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UpdateOA.MySqlHelper;

namespace UpdateOA
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //获得update所在目录
            string pathupdate = Directory.GetCurrentDirectory();

            //获得oa系统所在目录
            string pathoa = Directory.GetParent(Application.StartupPath).FullName;
            MySQLHelper _mysql = new MySQLHelper();
            string str_sql = $"select * from jjdbrenwutaizhang.附件信息表 " +
                $"where 类型='系统'";
            var _mydr = _mysql.ExecuteDataRow(str_sql);
            //获得服务器路径
            string webpath = _mydr["全路径"].ToString();
            //下载文件
            await JJMethod.DownLoadFileAsync(webpath, pathupdate + $"\\{Path.GetFileName(webpath)}");
            //解压到当前文件夹
            JJMethod.UnZip(pathupdate + $"\\{Path.GetFileName(webpath)}", pathoa);
            //删除压缩包
            File.Delete(pathupdate + $"\\{Path.GetFileName(webpath)}");
            //打开OA程序
            System.Diagnostics.Process.Start(pathoa+"\\团队任务台账管理系统.exe");
            //杀掉自身程序
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("UpdateOA");
            foreach (System.Diagnostics.Process pro in proc)
            {
                pro.Kill();
            }


        }





    }
}
