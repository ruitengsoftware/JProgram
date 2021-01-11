using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public  class ControllerWFqingxiujia
    {
        MySQLHelper _mysql = new MySQLHelper();

        /// <summary>
        /// 保存请假信息
        /// </summary>
        /// <param name="myinfo"></param>
        /// <returns></returns>
        public bool SaveQingxiujia(JJTaskInfo myinfo)
        {
            string str_sql = $"select count(*) from jjdbrenwutaizhang.任务信息表 where 删除=0 and 事由='{myinfo._shiyou}' and 类型='{myinfo._leixing}'";
            int num = Convert.ToInt32(_mysql.ExecuteScalar(str_sql));
            if (num > 0)
            {
                str_sql = $"update jjdbrenwutaizhang.任务信息表 set 事由='{myinfo._shiyou}',紧急程度='{myinfo._jinjichengdu}',请假天数={myinfo._qingjiatianshu}," +
                    $"起止时间='{myinfo._qizhishijian}',委托对象='{myinfo._weituoduixiang}',审核人员='{myinfo._shenherenyuan}'," +
                    $"审核意见='{myinfo._shenheyijian}',销假情况='{myinfo._xiaojiaqingkuang}' where 事由='{myinfo._shiyou}' and 删除=0 and 类型='{myinfo._leixing}'";
            }
            else
            {
                str_sql = $"insert into jjdbrenwutaizhang.任务信息表 (事由,紧急程度,请假天数,起止时间,委托对象," +
                    $"审核人员,审核意见,销假情况,创建时间,创建人,类型,删除,状态) " +
                    $"values('{myinfo._shiyou}','{myinfo._jinjichengdu}',{myinfo._qingjiatianshu},'{myinfo._qizhishijian}','{myinfo._weituoduixiang}'," +
                    $"'{myinfo._shenherenyuan}','{myinfo._shenheyijian}','{myinfo._xiaojiaqingkuang}','{myinfo._chuangjianshijian}','{myinfo._chuangjianren}','{myinfo._leixing}',0,'{myinfo._zhuangtai}')";
            }
            num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;


        }

        public bool FasongBanli(JJTaskInfo myinfo)
        {

          string  str_sql = $"insert into jjdbrenwutaizhang.任务信息表 (事由,紧急程度,请假天数,起止时间,委托对象," +
                $"审核人员,审核意见,销假情况,发送时间,发送人,类型,删除,状态) " +
                $"values('{myinfo._shiyou}','{myinfo._jinjichengdu}',{myinfo._qingjiatianshu},'{myinfo._qizhishijian}','{myinfo._weituoduixiang}'," +
                $"'{myinfo._shenherenyuan}','{myinfo._shenheyijian}','{myinfo._xiaojiaqingkuang}','{myinfo._fasongshijian}','{myinfo._fasongren}','{myinfo._leixing}',0,'{myinfo._zhuangtai}')";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }


    }
}
