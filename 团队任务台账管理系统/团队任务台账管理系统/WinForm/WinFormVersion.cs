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
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WinFormVersion : Form
    {
        MySQLHelper _mysql = new MySQLHelper();
        DataRow _mydr = null;
        public WinFormVersion()
        {
            InitializeComponent();
            

        }
        public WinFormVersion(DataRow dataRow)
        {
            InitializeComponent();
            _mydr = dataRow;

        }
        /// <summary>
        /// 点击确定按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void label1_Click(object sender, EventArgs e)
        {
            //获得数据库最新软件的版本
            string str_sql = $"select * from jjdbrenwutaizhang.附件信息表 " +
                $"where 类型='系统'";
            var mydr = _mysql.ExecuteDataRow(str_sql);
            string newversion = mydr["文件名"].ToString();

            if (newversion != Properties.Settings.Default.version)
            {
                //获得本地保存路径
                string path = Environment.CurrentDirectory;
                string localpath =Directory.GetCurrentDirectory( );
                string downloadpath = mydr["全路径"].ToString();
                //下载文件
                await JJMethod.DownLoadFileAsync(downloadpath, path+$"\\{Path.GetFileName(downloadpath)}");
                this.DialogResult = DialogResult.OK;
            }
        }

        private async void WinFormVersion_Load(object sender, EventArgs e)
        {
            //获得本地保存路径
            string path = Environment.CurrentDirectory;
            string downloadpath = _mydr["全路径"].ToString();
            //下载文件
             await   JJMethod.DownLoadFileAsync(downloadpath, path + $"\\{Path.GetFileName(downloadpath)}");
            //解压到当前文件夹
            JJMethod.UnZip(path + $"\\{Path.GetFileName(downloadpath)}", path);
            //删除压缩包
            File.Delete(path + $"\\{Path.GetFileName(downloadpath)}");
            this.DialogResult = DialogResult.OK;
        }
    }
}
