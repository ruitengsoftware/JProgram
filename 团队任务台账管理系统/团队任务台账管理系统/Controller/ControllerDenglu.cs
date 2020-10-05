using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerDenglu
    {

        MySQLHelper mysqlhelper = null;



        public ControllerDenglu()
        {
            string str_conn = $"server=39.107.125.33;port=3306;user=root;password=111111; database=jjdbrenwutaizhang;";
            mysqlhelper = new MySQLHelper(str_conn);
        }
        //判断是否存在用户名和密码
        public bool Login(string uid,string pwd) 
        {
            string str_sql = $"select count(*) from jjperson where jjyonghuming='{uid}' and jjmima='{pwd}'";
           int num=Convert.ToInt32( mysqlhelper.ExecuteScalar(str_sql, null));
            return num > 0 ? true : false;        
        }






    }
}
