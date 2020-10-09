using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerWFzhuce
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 注册一个员工到数据库中
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public bool Zhuce(Dictionary<string, string> dic)
        {
            string str_sql = $"insert into jjperson values('{dic["昵称"]}','{dic["部门"]}','{dic["权限"]}','{dic["密码"]}','{dic["姓名"]}','{dic["手机号"]}','{dic["邮箱"]}')";
            int num=mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }





    }
}
