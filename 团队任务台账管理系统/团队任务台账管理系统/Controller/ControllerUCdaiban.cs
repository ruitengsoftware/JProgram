using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerUCdaiban
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        public DataTable GetData()
        {
            string str_sql = $"select * from jjtask where 状态='未撤销'";

            var data =  mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }



    }
}
