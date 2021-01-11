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
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态='未读' and (参与人='{JJLoginInfo._huaming}' or 负责人='{JJLoginInfo._huaming}')";
            DataTable mydt = _mysql.ExecuteDataTable(str_sql);
            return mydt.Rows.Count;
        }

        /// <summary>
        /// 修改任务状态
        /// </summary>
        /// <param name="ti"></param>
        /// <returns></returns>
        public bool UpdateZhuangtai(JJTaskInfo ti)
        {
            //判断任务类型，构造不同的str_sql语句
            string str_sql = string.Empty;
            if (ti._leixing.Equals("意见建议"))
            {
                str_sql = $"update jjdbrenwutaizhang.任务信息表 set 状态='{ti._zhuangtai}' where 标题='{ti._biaoti}' and 类型='{ti._leixing}' " +
                                $"and 反馈对象='{ti._fankuiduixiang}' and 删除=0";

            }
            if (ti._leixing.Equals("常规事项"))
            {
                str_sql = $"update jjdbrenwutaizhang.任务信息表 set 状态='{ti._zhuangtai}' where 名称='{ti._mingcheng}' and 类型='{ti._leixing}' " +
                                $"and 办理人员='{ti._banlirenyuan}' and 删除=0";
            }
            if (ti._leixing.Equals("OKR事项"))
            {
                str_sql = $"update jjdbrenwutaizhang.任务信息表 set 状态='{ti._zhuangtai}' where 名称='{ti._mingcheng}' and 类型='{ti._leixing}' " +
                                $"and 总体验收人='{ti._zongtiyanshouren}' and 删除=0";
            }
            if (ti._leixing.Equals("请休假单"))
            {
                str_sql = $"update jjdbrenwutaizhang.任务信息表 set 状态='{ti._zhuangtai}' where 事由='{ti._shiyou}' and 类型='{ti._leixing}' " +
                                $"and 审核人员='{ti._shenherenyuan}' and 删除=0";
            }
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;

        }
    }
}
