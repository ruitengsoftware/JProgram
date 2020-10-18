using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerUCrizhi
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 获得数据库中所有日志的信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetRizhi()
        {
            DataTable mydt = new DataTable();
            string str_sql = "select * from jjrizhi";
            mydt = mysqlhelper.ExecuteDataTable(str_sql);
            return mydt;
        }

        /// <summary>
        /// 获得数据库中所有日志的信息
        /// </summary>
        /// <returns></returns>
        public DataTable ChazhaoRizhi(string kw)
        {
            DataTable mydt = new DataTable();
            string str_sql = $"select * from jjrizhi where 内容 like '%{kw}%'";
            mydt = mysqlhelper.ExecuteDataTable(str_sql);
            return mydt;
        }


        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="rizhi">日志标题名称</param>
        /// <returns></returns>
        public bool DeleteRizhi(string rizhi)
        {
            string str_sql = $"delete from jjrizhi where 标题='{rizhi}'";
            int num=mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }



    }
}
