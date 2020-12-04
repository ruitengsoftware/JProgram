using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerUCtongxulu
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 获得所有的员工信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPersonInfo()
        {
            DataTable mydt = new DataTable();
            string str_sql = $"select * from jjperson where 删除=0";
            mydt = _mysqlhelper.ExecuteDataTable(str_sql, null);
            return mydt;
        }





    }
}
