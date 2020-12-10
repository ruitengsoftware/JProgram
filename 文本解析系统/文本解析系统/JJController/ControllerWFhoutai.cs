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

        /// <summary>
        /// 更新权限
        /// </summary>
        /// <param name="huaming">花名</param>
        /// <param name="denglu">登录权</param>
        /// <param name="d1">调用规则</param>
        /// <param name="d2">调用查重库</param>
        /// <param name="s1">删除规则</param>
        /// <param name="s2">删除查重库</param>
        /// <returns></returns>
        public bool UpdateShouquan(string huaming, int denglu, string d1, string d2, string s1, string s2)
        {
            string str_sql = $"update jjdbwenbenjiexi.jjperson set 登录权={denglu},调用规则='{d1}',调用查重库='{d2}',删除规则='{s1}',删除查重库='{s2}' " +
                $"where 花名='{huaming}'";
                int num = _mysqlhelper.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }



    }
}
