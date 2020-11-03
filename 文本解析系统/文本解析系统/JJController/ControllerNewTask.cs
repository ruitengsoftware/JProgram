using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{

   public class ControllerNewTask
    {
        MySQLHelper mysqlhelper = new MySQLHelper(MySQLHelper.str_connother);
        /// <summary>
        /// 获得数据库中所有的解析格式
        /// </summary>
        /// <returns></returns>
        public List<string> GetFormat()
        {
            List<string> list = new List<string>();
            string str_sql = $"select 格式名称 from 解析格式表 where 删除=0";
            DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql, null);
            foreach (DataRow item in mydt.Rows)
            {
                list.Add(item["格式名称"].ToString());
            }
            return list;

        }



    }
}
