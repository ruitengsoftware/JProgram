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
                string webpath = $"http://39.107.125.33";
                string filepath = Path.GetDirectoryName(str_uploadfile);
                string filename = Path.GetFileName(str_uploadfile);
                UpLoadFile(str_uploadfile, webpath, false);//上传文件
                                                           //    System.Net.WebClient myWebClient = new System.Net.WebClient();
                                                           //NetworkCredential credentials = new NetworkCredential("Administrator", "Lxr+850223");
                                                           //myWebClient.Credentials = credentials;
                                                           //myWebClient.UploadFile(webpath, "put", str_uploadfile);



            }

            //iZmahmn46g6czhZ	172.17.19.156	联机 - 未启动性能计数器	2020/10/6 23:56:58	00430-00000-00000-AA534(已激活)


        }

        private async void btn_xiazai_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel 97~2003工作簿|*.xls|Excel 工作簿|*.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    WebClient myWebClient = new WebClient();
                    NetworkCredential credentials = new NetworkCredential("Administrator", "Lxr+850223");
                    myWebClient.Credentials = credentials;
                    Uri myuri = new Uri("http://39.107.125.33/标准任务表.xlsx");
                   myWebClient.DownloadFileAsync(myuri, sfd.FileName);
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
            NetworkCredential credentials = new NetworkCredential("Administrator", "Lxr+850223");
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
        /// 从本地上传文件至服务器
        /// </summary>  
        /// <param name="src">远程服务器路径（共享文件夹路径）</param>  
        /// <param name="dst">本地文件夹路径</param>  
        /// <param name="fileName">上传至服务器上的文件名，包含扩展名</param>  
        public static void UpLoadFile(string src, string dst, string fileName)
        {
            if (!Directory.Exists(dst))
            {
                Directory.CreateDirectory(dst);
            }
            src = src + fileName;
            FileStream inFileStream = new FileStream(src, FileMode.OpenOrCreate);    //从远程服务器下载到本地的文件 

            FileStream outFileStream = new FileStream(dst, FileMode.Open);    //远程服务器文件  此处假定远程服务器共享文件夹下确实包含本文件，否则程序报错  

            byte[] buf = new byte[outFileStream.Length];

            int byteCount;

            while ((byteCount = outFileStream.Read(buf, 0, buf.Length)) > 0)
            {
                inFileStream.Write(buf, 0, byteCount);

            }

            inFileStream.Flush();

            inFileStream.Close();

            outFileStream.Flush();

            outFileStream.Close();

        }
        /// <summary>
        /// 上传文件到服务器
        /// </summary>
        /// <param name="str_path">需要存放到服务器上的路径</param>
        /// <param name="file1">客户端文件</param>
        /// <returns>上传是否成功</returns>
        public static string UpFile(string str_path, HttpPostedFile file1, out string v_err)
        {
            v_err = null;
            string aaa = file1.FileName;
            if (Directory.Exists(str_path) == false)
            {
                Directory.CreateDirectory(str_path);
            }
            char[] a = { '\\' };
            string file_name = Guid.NewGuid().ToString("n") + file1.FileName.Split(a)[file1.FileName.Split(a).Length - 1];
            if (file_name == "")
            {
                str_path = "";
                v_err = "客户端文件不存在！";
                return null;
            }
            else
            {
                str_path = str_path + "\\" + file_name;
                file1.SaveAs(str_path);
                return file_name;
            }
        }
        /// <summary>
        /// 点击新建按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            WFxinjian wfxinjian = new WFxinjian();
            wfxinjian.StartPosition = FormStartPosition.CenterParent;
            wfxinjian.ShowDialog();
        }
    }
}
