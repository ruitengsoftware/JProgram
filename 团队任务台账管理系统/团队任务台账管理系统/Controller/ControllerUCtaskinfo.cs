using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerUCtaskinfo
    {
        MySQLHelper mysql = new MySQLHelper();
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool DoSql(string s)
        {
            int num = mysql.ExecuteNonQuery(s);
            return num > 0 ? true : false;
        }


    }
}
