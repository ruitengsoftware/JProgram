using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{
   public class ControllerWFmydb
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 获得查重表信息类集合
        /// </summary>
        /// <returns></returns>
        public DataTable GetChachongInfo(string str)
        {
            DataTable mydt = _mysqlhelper.ExecuteDataTable(str);
            return mydt;
        }
        /// <summary>
        /// 删除数据库信息表中的信息
        /// </summary>
        /// <param name="dbname"></param>
        /// <returns></returns>
        public bool DeletbMydb(string dbname)
        {
            string str_sql = $"update jjdbwenbenjiexi.查重库信息表 set 删除=1 where 名称='{dbname}' and 创建人='{UserInfo._huaming}'";
            int num=_mysqlhelper.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;

        }



    }
}
