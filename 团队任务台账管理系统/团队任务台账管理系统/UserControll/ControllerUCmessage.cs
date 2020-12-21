using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.UserControll
{
   public class ControllerUCmessage
    {

        MySQLHelper _mysql = new MySQLHelper();
        /// <summary>
        /// 根据任务名称获得结果表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetTaskInfo(string name)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 名称='{name}'";
            DataTable mydt = _mysql.ExecuteDataTable(str_sql);
            return mydt;
        }
        /// <summary>
        /// 获得未读任务数量
        /// </summary>
        /// <returns></returns>
        public int GetWeiduTaskNum()
        {
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态='未读' and 负责人='{JJLoginInfo._huaming}' or 参与人='{JJLoginInfo._huaming}'";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num;
        }

        /// <summary>
        /// 修改任务状态
        /// </summary>
        /// <param name="ti"></param>
        /// <returns></returns>
        public bool UpdateZhuangtai(JJTaskInfo ti)
        {
            string str_sql = $"update jjdbrenwutaizhang.任务信息表 set 状态='{ti._zhuangtai}' where 名称='{ti._mingcheng}' and 创建时间='{ti._chuangjianshijian}' and 创建人='{ti._chuangjianren}'";
            int num=_mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        
        }
    }
}
