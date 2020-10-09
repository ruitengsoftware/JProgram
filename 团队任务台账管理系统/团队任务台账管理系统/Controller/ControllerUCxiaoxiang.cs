using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{

    public class ControllerUCxiaoxiang
    {
        MySQLHelper mysqlhelper = new MySQLHelper();

        public DataTable GetData()
        {
            string str_sql = $"select * from jjtask";
            var data = mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }


        public bool UpdateData(string cmdtext)
        {
            int num = mysqlhelper.ExecuteNonQuery(cmdtext, null);
            return num > 0 ? true : false;
        
        }

    }
}
