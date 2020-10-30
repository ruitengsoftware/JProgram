using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{
    public class ControllerGuize
    {
        MySQLHelper mysqlhelper = new MySQLHelper(MySQLHelper.str_connother);

        /// <summary>
        /// 保存规则
        /// </summary>
        /// <returns></returns>
        public bool SaveRule(string mingcheng ,string shuoming,string xiangqing)
        {

            string str_sql = $"insert into 规则信息表 set(规则名称,规则说明,规则详情) values(@规则名称,@规则说明,@规则详情)";
            
        int num=mysqlhelper.ExecuteNonQuery(str_sql,new MySqlParameter("@规则名称",mingcheng),
            new MySqlParameter("@规则说明", shuoming),
            new MySqlParameter("@规则详情", xiangqing));


            return num > 0 ? true : false;
        }


    }
}
