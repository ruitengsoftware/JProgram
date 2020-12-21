using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerWFperson
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        public DataTable GetAllPerson()
        {
            string str_sql = "select * from jjdbrenwutaizhang.jjperson";
            var data = mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }



    }
}
