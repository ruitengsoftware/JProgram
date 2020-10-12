using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{

    

   public class ControllerUCshouquan
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        public DataTable GetPerson()
        {
            string str_sql = $"select * from jjperson";
            DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql, null);
            return mydt;
        }

        public bool UpdatePerson(string xingming,string quanxian)
        {
            string str_sql = $"update jjperson set 权限='{quanxian}' where 花名='{xingming}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }



    }
}
