using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{
    public class ControllerForm
    {
        public List<string> _childdirectories = new List<string>();
        public void GetDirectory(string folder)
        {

           //判断是否含有子文件夹，如果没有，加入



            _childdirectories = new List<string>();
            _childdirectories.Add(folder);
            DirectoryInfo mydir = new DirectoryInfo(folder);
            string[] dirs = Directory.GetDirectories(folder);
            if (dirs.Length==0)
            {
                _childdirectories.Add(folder);
            }
            else
            {
                foreach (string item in dirs)
                {
                    GetDirectory(item);
                }
            }


        }
        MySQLHelper mysqlhelper = new MySQLHelper(MySQLHelper.str_connother);
        /// <summary>
        /// 获得所有的规则
        /// </summary>
        /// <returns></returns>
        public DataTable GetGuize()
        {
            string str_sql = $"select * from 解析规则表";
            return mysqlhelper.ExecuteDataTable(str_sql, null);
        }



    }
}
