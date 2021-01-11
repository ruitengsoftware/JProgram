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
        /// <summary>
        /// 获得所有的员工信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPerson()
        {
            string str_sql = "select * from jjdbrenwutaizhang.jjperson";
            var data = mysqlhelper.ExecuteDataTable(str_sql);
            return data;
        }
        /// <summary>
        /// 获得所有的部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBumen()
        {
            string str_sql = "select * from jjdbrenwutaizhang.部门信息表";
            var data = mysqlhelper.ExecuteDataTable(str_sql);
            return data;
        }

    }
}
