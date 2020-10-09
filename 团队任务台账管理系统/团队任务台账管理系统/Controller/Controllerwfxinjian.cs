using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
    public class Controllerwfxinjian
    {

        MySQLHelper mysqlhelper = new MySQLHelper();
        public bool DeleteTask(string task)
        {

            string str_sql = "delete from jjtask where 任务名称=@renwumingcheng";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("@renwumingcheng", task)
            });
            return num > 1 ? true : false;
        }

        public bool AddTask(string task, string jinjichengdu, string jutiyaoqiu, string fenjie, string jinzhan, string shuifuze, string shuipizhun, string zixunshui, string tongzhishui, string shixian, string beizhu)
        {
            string str_sql = $"insert into jjtask values(@task,@jinjichengdu,@jutiyaoqiu,@fenjie,@jinzhan,@shuifuze,@shuipizhun,@zixunshui,@tongzhishui,@shixian,@beizhu,@zhuangtai,@yidu,@kaishishijian)";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, new MySql.Data.MySqlClient.MySqlParameter[] {
            new MySql.Data.MySqlClient.MySqlParameter("@task",task),
            new MySql.Data.MySqlClient.MySqlParameter("@jinjichengdu",jinjichengdu),
            new MySql.Data.MySqlClient.MySqlParameter("@jutiyaoqiu",jutiyaoqiu),
            new MySql.Data.MySqlClient.MySqlParameter("@fenjie",fenjie),
            new MySql.Data.MySqlClient.MySqlParameter("@jinzhan",jinzhan),
            new MySql.Data.MySqlClient.MySqlParameter("@shuifuze",shuifuze),
            new MySql.Data.MySqlClient.MySqlParameter("@shuipizhun",shuipizhun),
            new MySql.Data.MySqlClient.MySqlParameter("@zixunshui",zixunshui),
            new MySql.Data.MySqlClient.MySqlParameter("@tongzhishui",tongzhishui),
            new MySql.Data.MySqlClient.MySqlParameter("@shixian",shixian),
            new MySql.Data.MySqlClient.MySqlParameter("@beizhu",beizhu),
            new MySql.Data.MySqlClient.MySqlParameter("@zhuangtai","未撤销"),
                        new MySql.Data.MySqlClient.MySqlParameter("@yidu","0"),
                        new MySql.Data.MySqlClient.MySqlParameter("@kaishishijian","--")

            });
            return num > 0 ? true : false;


        }



    }
}
