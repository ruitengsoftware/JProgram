using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{

   public class ControllerWFdiaoyongguize
    {

        MySQLHelper _mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 获得所有规则信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetData(string s)
        {
            //判断s的值，提取规则数据，或者查重库数据
            string str_sql = string.Empty;
            if (s.Equals("规则"))
            {
           str_sql = $"select * from jjdbwenbenjiexi.规则信息表 where 删除=0";

            }
            else if(s.Equals("查重"))
            {
                str_sql = $"select * from jjdbwenbenjiexi.查重库信息表 where 删除=0";
            }

            DataTable mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            return mydt;
        
        }



    }
}
