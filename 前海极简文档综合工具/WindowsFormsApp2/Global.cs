using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public static class Global
    {


        public static bool run = true;

        /// <summary>
        /// 任务线程
        /// </summary>
        public static Thread t = null;
        /// <summary>
        /// 存放excel生成word方法中需要用到的所有 格式
        /// </summary>
        public static List<UCformate2w> list_myuc = new List<UCformate2w>();
        public static List<int> listfilename = new List<int>();
        /// <summary>
        /// 存放字段，用户组成word文件名
        /// </summary>
        public static List<string> list_title = new List<string>();
        public static List<ExcelInfo> list_splitfiles = new List<ExcelInfo>();
        /// <summary>
        /// 存放处理发生错误的记录
        /// </summary>
        public static DataTable dt_wrong = new DataTable();
        /// <summary>
        /// 存放当前正在操作的目录
        /// </summary>
        public static List<string> list_dirs = new List<string>();
    }
}
