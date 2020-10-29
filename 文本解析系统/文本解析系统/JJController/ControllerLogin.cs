using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文本解析系统.JJController
{
   public class ControllerLogin
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 登录系统，返回成功/失败结果
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Login(string uid, string pwd)
        {
            string str_sql = $"select count(*) from jjperson where 花名='{uid}' and 密码='{pwd}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
            return num > 0 ? true : false;
        }



    }
}
