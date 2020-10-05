using BLL;
using Model;
using RuiTengDll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class DataHelper
    {


        /// <summary>
        /// 获得最新的省略词
        /// </summary>
        /// <returns></returns>
        public List<string> GetShenglueci(string dbfile, string str_sql,string field)
        {
            List<string> list_result = new List<string>();
            mysqliter = new SqliteHelper( dbfile);
            mysqliter.Open();
            List<object> list_o = mysqliter.ExecuteRow(str_sql, null, null);
            foreach (object o in list_o)
            {
                Dictionary<string, object> dic = o as Dictionary<string, object>;
                list_result.Add(dic[field].ToString());
            }
            mysqliter.Close();
            return list_result;
        }

        /// <summary>
        /// 获得所选目录下所有的文件
        /// </summary>
        /// <returns></returns>
        public List<string> GetFlies()
        {
            List<string> list_result = new List<string>();
            FolderBrowserDialog myfbd = new FolderBrowserDialog();
            if (myfbd.ShowDialog() == DialogResult.OK)
            {
                GetFiles(new DirectoryInfo(myfbd.SelectedPath), "*.*", ref list_result);
            }
            return list_result;
        }
        public List<string> GetFlies(string floder)
        {
            List<string> list_result = new List<string>();
            try
            {
                list_result = new List<string>();
                GetFiles(new DirectoryInfo(floder), "*.*", ref list_result);

            }
            catch {
                list_result = null;
            }
            return list_result;
        }



        /// <summary>
        /// 获得指定目录下的所有文件，包括子目录中
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="pattern"></param>
        /// <param name="fileList"></param>
        public void GetFiles(DirectoryInfo directory, string pattern, ref List<string> fileList)
        {
            if (directory.Exists || pattern.Trim() != string.Empty)
            {
                try
                {
                    foreach (FileInfo info in directory.GetFiles(pattern))
                    {
                        fileList.Add(info.FullName.ToString());
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                foreach (DirectoryInfo info in directory.GetDirectories())//获取文件夹下的子文件夹
                {
                    GetFiles(info, pattern, ref fileList);//递归调用该函数，获取子文件夹下的文件
                }
            }
        }
        /// <summary>
        /// 获得文件夹下的所有目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> GetChildFolder()
        {
            List<string> list_result = new List<string>();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                string[] arr_directorys0 = Directory.GetDirectories(path);
                foreach (string str in arr_directorys0)
                {
                    string[] arr_directorys1 = Directory.GetDirectories(str);
                    if (arr_directorys1.Length == 0)
                    {
                        list_result.Add(str);
                    }
                    else
                    {
                        GetChildFolder();
                    }
                }
            }
            return list_result;
        }

        /// <summary>
        /// 直接获得word文档集合
        /// </summary>
        /// <returns></returns>
        public List<string> GetDocument()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word 97~2003文档|*.doc|Word 文档|*.docx";
            ofd.Multiselect = true;
            List<string> list_result = new List<string>();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                list_result = ofd.FileNames.ToList();

            }
            return list_result;

        }



        SqliteHelper mysqliter = null;
        /// <summary>
        /// 判断某句话是否在数据库中包含
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool SentenceIsExist(string str,string dbname,string tablename,string fieldname)
        {
            mysqliter = new SqliteHelper(dbname);
            mysqliter.Open();

            bool existed = false;
                List<object> list_o = mysqliter.ExecuteRow(string.Format("select * from "+tablename+" where {0}='{1}'", fieldname,str), null, null);
                if (list_o.Count > 0)
                {
                    existed = true;
                }
            return existed;
        }

    }
}
