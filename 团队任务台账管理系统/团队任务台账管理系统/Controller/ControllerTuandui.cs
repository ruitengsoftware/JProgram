using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerTuandui
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 点击解除按钮时触发的事件
        /// </summary>
        /// <param name="tuanduimingchen"></param>
        /// <returns></returns>
        public bool JiechuTuandui(string tuanduimingchen)
        {
            string str_sql = $"update jjtuandui set 状态='已解除',解除时间='{DateTime.Now.ToString()}' where 名称='{tuanduimingchen}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 判断团队是否已经存在
        /// </summary>
        /// <param name="tuanduimingcheng">团队名称</param>
        /// <returns></returns>
        public bool ExistTuandui(string tuanduimingcheng)
        {
            string str_sql = $"select count(*) from jjtuandui where 名称='{tuanduimingcheng}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql));
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 新建团队到数据库中
        /// </summary>
        /// <param name="tuandui"></param>
        /// <param name="fuzeren"></param>
        /// <param name="chengyuan"></param>
        /// <returns></returns>
        public bool InsertTuandui(string tuandui, string fuzeren, string chengyuan)
        {
            string str_sql = $"insert into jjtuandui values('{tuandui}'," +
                    $"'{fuzeren}','{chengyuan}','{DateTime.Now.ToString()}','工作中','--')";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;

        }
        /// <summary>
        /// 获得所有得团队信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetTuandui()
        {
            string str_sql = $"select * from jjtuandui";
            DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql);
            return mydt;
        }
    }
}
