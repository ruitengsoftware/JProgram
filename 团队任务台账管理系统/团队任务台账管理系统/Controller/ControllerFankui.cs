using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerFankui
    {
        MySQLHelper mysqlhelper = new MySQLHelper();

        public DataTable GetFankui()
        {

            string str_sql = $"select * from jjfankui";
            DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql);
            return mydt;

        }
        /// <summary>
        /// 判断反馈是否已经存在
        /// </summary>
        /// <param name="tuanduimingcheng">反馈名称</param>
        /// <returns></returns>
        public bool ExistFankui(string fankuimingcheng)
        {
            string str_sql = $"select count(*) from jjfankui where 名称='{fankuimingcheng}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql));
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 插入反馈到数据库中
        /// </summary>
        /// <param name="mingcheng">反馈名称</param>
        /// <param name="lianxifangshi">联系方式</param>
        /// <param name="duixiang">对象</param>
        /// <param name="neirong">内容</param>
        /// <returns></returns>
        public bool InsertFankui(string mingcheng, string lianxifangshi, string duixiang,string neirong)
        {
            string str_sql = $"insert into jjfankui values('{mingcheng}'," +
                    $"'{lianxifangshi}','{duixiang}','{neirong}','{DateTime.Now.ToString()}',0)";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;

        }

        /// <summary>
        /// 从数据库中删除反馈
        /// </summary>
        /// <param name="fankuimingcheng"></param>
        /// <returns></returns>
        public bool Shanchufankui(string fankuimingcheng)
        {
            string str_sql = $"update jjfankui set 删除=1 where 名称='{fankuimingcheng}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        public bool UpdateFankui(string fankui, string lianxifangshi, string duixiang, string neirong)
        {
            string str_sql = $"update jjfankui set 联系方式='{lianxifangshi}',对象='{duixiang}',内容='{neirong}' where 名称='{fankui}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

    }
}
