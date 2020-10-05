using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Controller
{
   public class ControllerAddTask
    {

        public List<string> GetChildFolder()
        {
            List<string> list = new List<string>();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string str2 in Directory.GetDirectories(dialog.SelectedPath))
                {
                    string[] directories = Directory.GetDirectories(str2);
                    if (directories.Length == 0)
                    {
                        list.Add(str2);
                    }
                    else
                    {
                        this.GetChildFolder();
                    }
                }
            }
            return list;
        }
        public List<string> GetDocument()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Word 97~2003文档|*.doc|Word 文档|*.docx",
                Multiselect = true
            };
            List<string> list = new List<string>();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                list = dialog.FileNames.ToList<string>();
            }
            return list;
        }
        public void GetFiles(DirectoryInfo directory, string pattern, ref List<string> fileList)
        {
            if (directory.Exists || (pattern.Trim() != string.Empty))
            {
                try
                {
                    foreach (FileInfo info in directory.GetFiles(pattern))
                    {
                        fileList.Add(info.FullName.ToString());
                    }
                }
                catch (Exception exception1)
                {
                    Console.WriteLine(exception1.ToString());
                }
                foreach (DirectoryInfo info2 in directory.GetDirectories())
                {
                    this.GetFiles(info2, pattern, ref fileList);
                }
            }
        }

        public List<string> GetFlies()
        {
            List<string> fileList = new List<string>();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.GetFiles(new DirectoryInfo(dialog.SelectedPath), "*.*", ref fileList);
            }
            return fileList;
        }

        public List<string> GetFlies(string floder)
        {
            List<string> fileList = new List<string>();
            try
            {
                fileList = new List<string>();
                this.GetFiles(new DirectoryInfo(floder), "*.*", ref fileList);
            }
            catch
            {
                fileList = null;
            }
            return fileList;
        }


        //public List<string> GetShenglueci(string dbfile, string str_sql, string field)
        //{
        //    List<string> list = new List<string>();
        //    this.mysqliter = new SqliteHelper(dbfile);
        //    this.mysqliter.Open();
        //    foreach (object obj2 in this.mysqliter.ExecuteRow(str_sql, null, null))
        //    {
        //        Dictionary<string, object> dictionary = obj2 as Dictionary<string, object>;
        //        list.Add(dictionary[field].ToString());
        //    }
        //    this.mysqliter.Close();
        //    return list;
        //}


        //public bool SentenceIsExist(string str, string dbname, string tablename, string fieldname)
        //{
        //    this.mysqliter = new SqliteHelper(dbname);
        //    this.mysqliter.Open();
        //    bool flag = false;
        //    if (this.mysqliter.ExecuteRow(string.Format("select * from " + tablename + " where {0}='{1}'", fieldname, str), null, null).Count > 0)
        //    {
        //        flag = true;
        //    }
        //    return flag;
        //}
    }
}
