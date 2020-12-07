using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerLishiziliao
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();
        public DataTable GetLishiziilao()
        {
            string str_sql = "select 任务名称,完成时间 from jjtask";
            DataTable mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            return mydt;
        
        }



    }
}
