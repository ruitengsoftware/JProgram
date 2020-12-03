using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerWFmain
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();

        public bool UpdateGerenqianming(string qianming)
        {
            string sql_sql = $"update jjperson set 个人签名='{qianming}' where 花名='{JJPersonInfo._huaming}'";
          int num=  _mysqlhelper.ExecuteNonQuery(sql_sql);
            return num > 0 ? true : false;
        
        }
    /// <summary>
    /// 获得创建人的各个象限任务
    /// </summary>
    /// <param name="xiangxian">象限</param>
    /// <returns></returns>
        public DataTable GetRenwu(string xiangxian)
        {
            DataTable mydt = new DataTable();
            string str_sql = $"select * from jjrenwu where 创建人='{JJPersonInfo._shiming}' and 删除=0 and 象限='{xiangxian}' order by 完成时间";
            mydt = _mysqlhelper.ExecuteDataTable(str_sql, null);
            return mydt;
        }
        /// <summary>
        /// 获得待办任务 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDaibanRenwu()
        {
            string str_sql = $"select 紧急程度,任务名称,时限 from jjtask where 状态='未撤销'";

            var data = _mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }



    }
}
