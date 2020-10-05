using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.DLL;

namespace WindowsFormsApp2.Controller
{
    public class ControllerYizhanshi
    {
        public List<string> list_dir;
        public List<FileInfo> lst;
        MySqlHelper _sqlhelper = new MySqlHelper();

        public void GetDir(string path)
        {
            try
            {
                string[] directories = Directory.GetDirectories(path);
                if (directories.Length == 0)
                {
                    list_dir.Add(path);
                }
                else
                {
                    list_dir.Add(path);
                    foreach (string str in directories)
                    {
                        GetDir(str);
                    }
                }
            }
            catch
            {
            }
        }

        public void GetDir(string path, string extName)
        {
            try
            {
                string[] directories = Directory.GetDirectories(path);
                FileInfo[] files = new DirectoryInfo(path).GetFiles();
                if ((files.Length != 0) || (directories.Length != 0))
                {
                    FileInfo[] infoArray2 = files;
                    int index = 0;
                    while (true)
                    {
                        if (index >= infoArray2.Length)
                        {
                            foreach (string str in directories)
                            {
                                GetDir(str, extName);
                            }
                            break;
                        }
                        FileInfo item = infoArray2[index];
                        if (extName.ToLower().IndexOf(item.Extension.ToLower()) >= 0)
                        {
                            lst.Add(item);
                        }
                        index++;
                    }
                }
            }
            catch
            {
            }
        }



        //获得所有格式名称
        public List<string> GetFormatName()
        {
            string str_sql = "select ttname from tabletotalformat";
            return _sqlhelper.GetSingleField(str_sql, "ttname");
        }

        /// <summary>
        /// 获得某个格式名称下的所有设置值
        /// </summary>
        /// <param name="ttname"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetFormatSet(string ttname)
        {
            string str_sql = $"select * from tabletotalformat where ttname='{ttname}'";
            return _sqlhelper.GetFormatSet(str_sql);
        }
        /// <summary>
        /// 从数据库中删除指定格式的记录
        /// </summary>
        /// <param name="format"></param>
        /// <param name="tablename"></param>
        public void DeleteFormat(string format,string tablename)
        {
            _sqlhelper.Delete(format, tablename);
        }

        public void SaveFormat(Dictionary<string, object> dic)
        {
            string name = dic["ttname"].ToString();
            _sqlhelper.SaveAnyFormat(dic,"tabletotalformat");
        }




    }
}
