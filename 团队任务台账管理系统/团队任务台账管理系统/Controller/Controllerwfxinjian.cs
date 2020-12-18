using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class Controllerwfxinjian
    {

        MySQLHelper mysqlhelper = new MySQLHelper();
        public bool DeleteTask(string task)
        {

            string str_sql = "delete from 常规事项表 where 任务名称=@renwumingcheng";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("@renwumingcheng", task)
            });
            return num > 1 ? true : false;
        }

        public bool AddTask(JJchangguiInfo ci)
        {
            //将常规事项的内容同时插入到常规事项表和    任务信息汇总表中
            string str_sql = $"insert into jjdbrenwutaizhang.任务信息表 values('{ci._renwumingcheng}','常规事项')";
            mysqlhelper.ExecuteNonQuery(str_sql);
            //判断该任务名是否存在，如果存在，使用update语句，否则


            str_sql = $"insert into 常规事项表 values('{ci._renwumingcheng}','{ci._jinjichengdu}','{ci._jutiyaoqiu}'," +
                            $"'{ci._zerenren}','{ci._yanshouren}','{ci._shixian}','{ci._jinzhanqingkuang}','进行中','','',0,'{DateTime.Now.ToString()}',0)";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;


        }



    }
}
