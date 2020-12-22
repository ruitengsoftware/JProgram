using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool AddTask(JJTaskInfo ci)
        {
            string str_sql = string.Empty;
            int num = 0;
            //拆分参与人，循环对参与人构造新的记录，并执行insertinto命令
            string[] arr_canyuren = Regex.Split(ci._canyuren, "[,，|]");
            foreach (string str in arr_canyuren)
            {
                //将常规事项的内容同时插入到常规事项表和    任务信息汇总表中
                str_sql = $"insert into jjdbrenwutaizhang.任务信息表 values('{ci._mingcheng}'," +
                    $"'{ci._leixing}','{ci._fuzeren}','{str}','{ci._zhuangtai}','{ci._xiangqing}','{ci._chuangjianren}','{ci._chuangjianshijian}'," +
                    $"'{ci._duqushijian}','{ci._shixian}','{ci._jinjichengdu}',0)";
                num = mysqlhelper.ExecuteNonQuery(str_sql);
            }
            //判断该任务名是否存在，如果存在，使用update语句，否则
            //str_sql = $"insert into 常规事项表 values('{ci._renwumingcheng}','{ci._jinjichengdu}','{ci._jutiyaoqiu}'," +
            //$"'{ci._zerenren}','{ci._canjiarem}','{ci._shixian}','{ci._jinzhanqingkuang}','进行中','','',0,'{DateTime.Now.ToString()}',0)";
            //int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }
    }
}
