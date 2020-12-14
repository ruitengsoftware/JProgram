using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{
   public class ControllerWFZhaohuimima
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="huaming"></param>
        /// <param name="shiming"></param>
        /// <param name="youxiang"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdatePassword(string huaming, string shiming, string youxiang,string pwd)
        {
            string str_sql= $"update jjdbrenwutaizhang.jjperson set 密码=@pwd where 花名='{huaming}' and 实名='{shiming}' " +
                    $"and 电子邮箱='{youxiang}'";
            int num=_mysqlhelper.ExecuteNonQuery(str_sql,new MySqlParameter[] {new MySql.Data.MySqlClient.MySqlParameter("@pwd", pwd) }    );
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 根据花名和实名获得用户邮箱
        /// </summary>
        /// <param name="huaming"></param>
        /// <param name="shiming"></param>
        /// <returns></returns>
        public string GetEmail(string huaming, string shiming)
        {
            string str_sql = $"select 电子邮箱 from jjdbrenwutaizhang.jjperson where 花名='{huaming}'" +
                    $" and 实名='{shiming}'";
            string youxiang = _mysqlhelper.ExecuteScalar(str_sql).ToString();
            return youxiang;
        
        
        
        }






    }
}
