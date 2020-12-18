using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerUCmain
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();

        public bool UpdateGerenqianming(string qianming)
        {
            string sql_sql = $"update jjdbrenwutaizhang.jjperson set 个人签名='{qianming}' where 花名='{JJLoginInfo._huaming}'";
            int num = _mysqlhelper.ExecuteNonQuery(sql_sql);
            return num > 0 ? true : false;

        }
        /// <summary>
        /// 获得创建人的各个象限任务
        /// </summary>
        /// <param name="xiangxian">象限</param>
        /// <returns></returns>
        public DataTable GetGongzuoqingdan(string xiangxian)
        {
            DataTable mydt = new DataTable();
            string str_sql = $"select * from jjdbrenwutaizhang.jjgongzuoqingdan where 创建人='{JJLoginInfo._shiming}' and 删除=0 and 象限='{xiangxian}' order by 完成时间";
            str_sql = $"select * from jjdbrenwutaizhang.jjgongzuoqingdan where  删除=0 and 象限='{xiangxian}' order by 完成时间";
            mydt = _mysqlhelper.ExecuteDataTable(str_sql, null);
            return mydt;
        }
        /// <summary>
        /// 获得待办任务 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDaibanRenwu(string s)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.常规事项表 where 任务名称 like '%{s}%' and 删除=0";
            
            var data = _mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }
        /// <summary>
        /// 获得通知公告
        /// </summary>
        /// <returns></returns>
        public DataTable GetTongzhi()
        {
            string str_sql = $"select * from jjdbrenwutaizhang.通知公告表 where 删除=0";

            var data = _mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }

       


        /// <summary>
        /// 删除工作清单
        /// </summary>
        /// <param name="mingcheng"></param>
        /// <returns></returns>
        public bool DeleteQingdan(string mingcheng)
        {
            string str_sql = $"update jjgongzuoqingdan set 删除=1 where 任务名称='{mingcheng }' and 主办人='{JJLoginInfo._shiming}'";
        int num = _mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        
        }
        /// <summary>
        /// 完成工作清单（另该清单状态变成完成）
        /// </summary>
        /// <param name="mingcheng"></param>
        /// <returns></returns>
        public bool FinishQingdan(string mingcheng)
        {
            string str_sql = $"update jjgongzuoqingdan set 状态='完成' where 任务名称='{mingcheng }' and 主办人='{JJLoginInfo._shiming}'";
            int num = _mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;

        }

    }
}
