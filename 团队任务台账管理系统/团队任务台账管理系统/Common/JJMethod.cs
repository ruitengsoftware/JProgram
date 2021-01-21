using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace 团队任务台账管理系统.Common
{
    public static class JJMethod
    {


        /// <summary>
        /// 检查是否有新任务并且显示任务数量和闪烁托盘图标
        /// </summary>
        public static Action<object, EventArgs> a_checknewtask = null;
        /// <summary>
        /// 刷新主页
        /// </summary>
        public static Action<object, EventArgs> a_shuaxinzhuye = null;


        static bool start_shanshuo = false;
        public static NotifyIcon nf;
        static Thread t = new Thread(new ThreadStart(() => { }));

        public static void IconStartShanshuo()
        {
            nf.Icon = Properties.Resources.ruitengicon;

            t.Abort();
            t = new Thread(new ThreadStart(() =>
            {
                start_shanshuo = true;
                do
                {
                    try
                    {

                        nf.Icon = Properties.Resources.blank;
                        InterVal(400);
                        nf.Icon = Properties.Resources.ruitengicon;
                        InterVal(400);
                    }
                    catch { }

                } while (start_shanshuo);
            }));
            t.Start();

        }
        public static void IconStopShanshuo()
        {
            start_shanshuo = false;
        }

        public static void InterVal(int time)
        {
            var t = DateTime.Now.AddMilliseconds(time);
            while (DateTime.Now < t) Application.DoEvents();
        }

        /// <summary>
        /// WebClient上传文件至服务器
        /// </summary>
        /// <param name="fileNamePath">文件名，全路径格式</param
        /// <param name="uriString">服务器文件夹路径</param>
        /// <param name="IsAutoRename">是否自动按照时间重命名</param>
        public static async Task UpLoadFile(string fileNamePath, string uriString, bool IsAutoRename)
        {
            await Task.Run(() =>
            {

                NetworkCredential credentials = new NetworkCredential("Administrator", "Lxr+19850223");
                //判断是否存在文件夹，如果不存在，新建
                if (!Directory.Exists(uriString))
                {
                    HttpWebRequest mywebRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(uriString));
                    mywebRequest.Credentials = credentials;
                    // mywebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    mywebRequest.Method = "MKCOL";
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
                // myWebClient.Headers.Add("Content-Type", "application/octet-stream");//注意头部必须是form-data
                Stream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
                //FileStream fs = OpenFile();  
                BinaryReader r = new BinaryReader(fs);
                byte[] postArray = r.ReadBytes((int)fs.Length);
                Stream postStream = myWebClient.OpenWrite(uriString, "PUT");



                try
                {
                    //使用UploadFile方法可以用下面的格式
                    //myWebClient.UploadFileAsync(new Uri(uriString), "PUT", fileNamePath);

                    if (postStream.CanWrite)
                    {
                        postStream.WriteAsync(postArray, 0, postArray.Length);
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
                    //postStream.Close();
                    //fs.Dispose();
                }


            });
        }
        public async static Task DownLoadFileAsync(string downloadfile, string localpath)
        {
            await Task.Run(() =>
            {
                WebClient myWebClient = new WebClient();
                NetworkCredential credentials = new NetworkCredential("Administrator", "Lxr+19850223");
                myWebClient.Credentials = credentials;
                Uri myuri = new Uri(downloadfile);
                myWebClient.DownloadFile(myuri, localpath);
            });
        }
        public static void DownLoadFile(string downloadfile, string localpath)
        {
                WebClient myWebClient = new WebClient();
                NetworkCredential credentials = new NetworkCredential("Administrator", "Lxr+19850223");
                myWebClient.Credentials = credentials;
                Uri myuri = new Uri(downloadfile);
                myWebClient.DownloadFile(myuri, localpath);
        }
        /// <summary>  
        /// 解压缩文件(压缩文件中含有子目录)  
        /// </summary>  
        /// <param name="zipfilepath">待解压缩的文件路径</param>  
        /// <param name="unzippath">解压缩到指定目录</param>  
        /// <returns>解压后的文件列表</returns>  
        public static List<string> UnZip(string zipfilepath, string unzippath)
        {
            //解压出来的文件列表  
            List<string> unzipFiles = new List<string>();

            //检查输出目录是否以“\\”结尾  
            if (unzippath.EndsWith("\\") == false || unzippath.EndsWith(":\\") == false)
            {
                unzippath += "\\";
            }

            ZipInputStream s = new ZipInputStream(File.OpenRead(zipfilepath));
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(unzippath);
                string fileName = Path.GetFileName(theEntry.Name);

                //生成解压目录【用户解压到硬盘根目录时，不需要创建】  
                if (!string.IsNullOrEmpty(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                if (fileName != String.Empty)
                {
                    //如果文件的压缩后大小为0那么说明这个文件是空的,因此不需要进行读出写入  
                    if (theEntry.CompressedSize == 0)
                        continue;
                    //解压文件到指定的目录  
                    directoryName = Path.GetDirectoryName(unzippath + theEntry.Name);
                    //建立下面的目录和子目录  
                    Directory.CreateDirectory(directoryName);

                    //记录导出的文件  
                    unzipFiles.Add(unzippath + theEntry.Name);

                    FileStream streamWriter = File.Create(unzippath + theEntry.Name);

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            s.Close();
            GC.Collect();
            return unzipFiles;
        }



    }


}



