using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using 团队任务台账管理系统.WinForm;
using 团队任务台账管理系统.JJModel;
using System.Text.RegularExpressions;
using 团队任务台账管理系统.Common;
using RuiTengDll;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCxinjian : UserControl
    {
        public UCxinjian()
        {
            InitializeComponent();
        }
        //服务器IP 39.107.125.33


        private void btn_shangchuan_Click(object sender, EventArgs e)
        {
            //选择要上传的文件
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string str_uploadfile = ofd.FileName;
               // string webpath = $"http://49.233.40.109/哈哈哈/";
                string webpath = $"http://49.233.40.109/常规事项/测试花名/";

                string filepath = Path.GetDirectoryName(str_uploadfile);
                string filename = Path.GetFileName(str_uploadfile);
                UpLoadFile(str_uploadfile, webpath, false);//上传文件
            }
        }

        private async void btn_xiazai_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel 97~2003工作簿|*.xls|Excel 工作簿|*.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filename = "http://49.233.40.109/标准表格.xlsx";
                   await JJMethod.DownLoadFileAsync(filename, sfd.FileName);
                    MessageBox.Show("表格下载成功！");
                }

            }
            catch (Exception ex) { string aa = ex.Message; }
        }
        /// <summary>
        /// WebClient上传文件至服务器
        /// </summary>
        /// <param name="fileNamePath">文件名，全路径格式</param
        /// <param name="uriString">服务器文件夹路径</param>
        /// <param name="IsAutoRename">是否自动按照时间重命名</param>
        public void UpLoadFile(string fileNamePath, string uriString, bool IsAutoRename)
        {
            NetworkCredential credentials = new NetworkCredential("Administrator", "Lxr+19850223");
            //判断是否存在文件夹，如果不存在，新建
            if (!Directory.Exists(uriString))
            {
                HttpWebRequest mywebRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(uriString));
                mywebRequest.Credentials = credentials;
                // mywebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                mywebRequest.Method = "MKD";

                try
                {
                    //FtpWebResponse response = mywebRequest.GetResponse() as FtpWebResponse;
                   HttpWebResponse response = mywebRequest.GetResponse() as HttpWebResponse;

                }
                catch { }
            }
            string fileName = fileNamePath.Substring(fileNamePath.LastIndexOf("\\") + 1);
            //上传的文件样式xxxxxxxxx_006.xlsx
            //string strVN = NewFileName.Substring(NewFileName.LastIndexOf("_") + 1);//"006.xlsx"
            //strVN.Substring(0, strVN.LastIndexOf("."));//006
            //NewFileName.Substring(0, NewFileName.LastIndexOf("_"))//xxxxxxxxx
            string NewFileName = fileName;
            if (IsAutoRename)
            {
                NewFileName = DateTime.Now.ToString("yyMMddhhmmss") + DateTime.Now.Millisecond.ToString() + fileNamePath.Substring(fileNamePath.LastIndexOf("."));
            }
            string fileNameExt = fileName.Substring(fileName.LastIndexOf(".") + 1);
            if (uriString.EndsWith("/") == false) uriString = uriString + "/";
            uriString = uriString + NewFileName;
            WebClient myWebClient = new WebClient();
            // myWebClient.Credentials = CredentialCache.DefaultCredentials;
            myWebClient.Credentials = credentials;
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            //FileStream fs = OpenFile();  
            BinaryReader r = new BinaryReader(fs);
            byte[] postArray = r.ReadBytes((int)fs.Length);
            Stream postStream = myWebClient.OpenWrite(uriString, "PUT");
            try
            {
                //使用UploadFile方法可以用下面的格式
                //myWebClient.UploadFile(uriString,"PUT",fileNamePath);
                if (postStream.CanWrite)
                {
                    postStream.Write(postArray, 0, postArray.Length);
                    postStream.Close();
                    fs.Dispose();
                }
                else
                {
                    postStream.Close();
                    fs.Dispose();
                }
            }
            catch
            {
                postStream.Close();
                fs.Dispose();
            }
            finally
            {
                postStream.Close();
                fs.Dispose();
            }
        }
        public void DownLoadFile(string downloadfile)
        {
            //更新文件的路径
            WebClient wc = new WebClient();
            //更新文件的路径，发布到服务器上
            string url = "http://192.168.22.239:82/Fairy.zip";
            //获取应用当前目录，指的是程序的目录
            string dir = System.IO.Directory.GetCurrentDirectory();
            //将字符串组合成一个路径加压缩包的名称
            string fileName = System.IO.Path.Combine(dir, "Fairy" + ".zip");
            //连接服务器的用户和密码
            wc.Credentials = new System.Net.NetworkCredential("administrator", "Admin239");
            //下载文件
            wc.DownloadFile(url, "Fairy.zip");

            //wc.UploadFile(url, "Fairy.zip");
            //释放资源
            wc.Dispose();
        }
        /// <summary>
        /// 点击新建按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_changguishixiang_Click(object sender, EventArgs e)
        {
            WFchangguishixiang mywin = new WFchangguishixiang() {
                StartPosition = FormStartPosition.CenterParent,
                WindowState = FormWindowState.Maximized
            };
            mywin.TopLevel = false;
            mywin.MdiParent = this.ParentForm;
            panel_task.Controls.Add(mywin);
            mywin.Show();
        }

        private void lbl_gongzuoqingdan_Click(object sender, EventArgs e)
        {
            WinForm.WFgongzuoqingdan mywinform = new WinForm.WFgongzuoqingdan() {
                StartPosition = FormStartPosition.CenterParent,
                WindowState=FormWindowState.Maximized
            };
            mywinform.TopMost = true;
            mywinform.MdiParent = this.ParentForm;
            panel_task.Controls.Add(mywinform);
            mywinform.Show();

        }

        private void lbl_okrshixiang_Click(object sender, EventArgs e)
        {
            WFokrshixiang mywin = new WFokrshixiang() {
                WindowState = FormWindowState.Maximized,

                StartPosition = FormStartPosition.CenterParent };
            mywin.TopLevel = false;
            mywin.MdiParent = this.ParentForm;
            panel_task.Controls.Add(mywin);
            mywin.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            var mywin = new WFtongzhigonggao() {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterParent };
            //mywin.TopLevel = false;
            mywin.MdiParent = this.ParentForm;
            panel_task.Controls.Add(mywin);
            mywin.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            var mywin = new WFqingxiujiadan() {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterParent };
            //mywin.TopLevel = false;
            mywin.MdiParent = this.ParentForm;
            panel_task.Controls.Add(mywin);
            mywin.Show();


        }

        private void label7_Click(object sender, EventArgs e)
        {
            var mywin = new WFyijianjianyi() {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterParent };
            //mywin.TopLevel = false;
            mywin.MdiParent = this.ParentForm;
            panel_task.Controls.Add(mywin);
            mywin.Show();


        }
        UIHelper _ui = new UIHelper();
        private void lbl_gongzuoqingdan_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void lbl_gongzuoqingdan_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void lbl_gongzuoqingdan_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
    }
}
