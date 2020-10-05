
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class FileHelper
    {
        /// <summary>
        /// 私有变量
        /// </summary>
        public static List<FileInfo> lst = new List<FileInfo>();

        public static List<string> list_dir = new List<string>();


        /// <summary>
        /// 获得目录下所有文件或指定文件类型文件(包含所有子文件夹)
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="extName">扩展名可以多个 例如 .mp3.wma.rm</param>
        /// <returns>List<FileInfo></returns>
        public static List<FileInfo> GetFile(string path, string extName)
        {
            GetDir(path, extName);
            return lst;
        }
        public static void GetDir(string path)
        {
            try
            { 
                
                string[] dir = Directory.GetDirectories(path); //文件夹列表   
                if (dir.Length != 0 ) //当前目录文件或文件夹不为空                   
                {
                          list_dir.Add(path);

                    foreach (string d in  dir)
                    {
                        GetDir(d);//递归   
                    }
                }
                else
                {
                    list_dir.Add(path);
                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// 私有方法,递归获取指定类型文件,包含子文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <param name="extName"></param>
        private static void GetDir(string path, string extName)
        {
            try
            {
                string[] dir = Directory.GetDirectories(path); //文件夹列表   
                DirectoryInfo fdir = new DirectoryInfo(path);
                FileInfo[] file = fdir.GetFiles();
                //FileInfo[] file = Directory.GetFiles(path); //文件列表   
                if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空                   
                {
                    foreach (FileInfo f in file) //显示当前目录所有文件   
                    {
                        if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
                        {
                            lst.Add(f);
                        }
                    }
                    foreach (string d in dir)
                    {
                        GetDir(d, extName);//递归   
                    }
                }
            }
            catch {
                
            }
        }
    }


    //public partial class FileGet1
    //{
    //    /// <summary>
    //    /// 获得目录下所有文件或指定文件类型文件(包含所有子文件夹)
    //    /// </summary>
    //    /// <param name="path">文件夹路径</param>
    //    /// <param name="extName">扩展名可以多个 例如 .mp3.wma.rm</param>
    //    /// <returns>List<FileInfo></returns>
    //    public static List<FileInfo> GetFile(string path, string extName)
    //    {

    //        try
    //        {
    //            List<FileInfo> lst = new List<FileInfo>();
    //            string[] dir = Directory.GetDirectories(path); //文件夹列表   
    //            DirectoryInfo fdir = new DirectoryInfo(path);
    //            FileInfo[] file = fdir.GetFiles();
    //            //FileInfo[] file = Directory.GetFiles(path); //文件列表   
    //            if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空                   
    //            {
    //                foreach (FileInfo f in file) //显示当前目录所有文件   
    //                {
    //                    if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
    //                    {
    //                        lst.Add(f);
    //                    }
    //                }
    //                foreach (string d in dir)
    //                {
    //                    GetFile(d, extName);//递归   
    //                }
    //            }
    //            return lst;
    //        }
    //        catch (Exception ex)
    //        {
    //            // LogHelper.WriteLog(ex);
    //            //  throw ex;
    //            return null;
    //        }
    //    }

    //}
}
