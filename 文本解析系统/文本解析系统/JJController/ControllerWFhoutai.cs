using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{
   public class ControllerWFhoutai
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();

        public DataTable GetPerson()
        {
            string str_sql = $"select * from jjdbrenwutaizhang.jjperson where 删除='0'";
            DataTable mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            return mydt;        
        }


        public bool UpdateShouquan(string huaming, int denglu, string d1, string d2, string s1, string s2)
        { 
        string str_sql=$"update jjdbwenbenjiexi.jjperson set 登录权={denglu},}"
        
        
        }



    }
}
