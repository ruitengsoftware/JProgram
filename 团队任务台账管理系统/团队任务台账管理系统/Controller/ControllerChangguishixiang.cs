using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerChangguishixiang
    {
        MySQLHelper _mysql = new MySQLHelper();

        public bool AddTask(JJTaskInfo myinfo)
        {

            //判断该任务是否存在，如果存在，使用update，如果不存在使用insert into
            string str_sql = $"select count(*) from jjdbrenwutaizhang.任务信息表 where 删除=0 and 名称='{myinfo._mingcheng}' and 类型='{myinfo._leixing}'";
            int num = Convert.ToInt32(_mysql.ExecuteScalar(str_sql));
            if (num > 0)
            {
                str_sql = $"update jjdbrenwutaizhang.任务信息表 set 名称='{myinfo._mingcheng}',紧急程度='{myinfo._jinjichengdu}',具体要求='{myinfo._jutiyaoqiu}'," +
                    $"附件=@附件,时限='{myinfo._shixian}',办理意见='{myinfo._banliyijian}'," +
                    $"办理人员='{myinfo._banlirenyuan}',进展情况='{myinfo._jinzhanqingkuang}' where 名称='{myinfo._mingcheng}' and 删除=0 and 类型='{myinfo._leixing}'";
            }
            else
            {
                str_sql = $"insert into jjdbrenwutaizhang.任务信息表 (名称,紧急程度,具体要求,附件,时限," +
                    $"办理意见,办理人员,进展情况,创建时间,创建人,类型,删除,状态) " +
                    $"values('{myinfo._mingcheng}','{myinfo._jinjichengdu}','{myinfo._jutiyaoqiu}',@附件,'{myinfo._shixian}'," +
                    $"'{myinfo._banliyijian}','{myinfo._banlirenyuan}','{myinfo._jinzhanqingkuang}','{myinfo._chuangjianshijian}','{myinfo._chuangjianren}','{myinfo._leixing}',0,'{myinfo._zhuangtai}')";
            }
            num = _mysql.ExecuteNonQuery(str_sql,new MySqlParameter("@附件",myinfo._fujian ));
            return num > 0 ? true : false;

        }
        public bool FasongBanli(JJTaskInfo myinfo)
        {

          string  str_sql = $"insert into jjdbrenwutaizhang.任务信息表 (名称,紧急程度,具体要求,附件,时限," +
                $"办理意见,办理人员,进展情况,发送时间,发送人,类型,删除,状态) " +
                $"values('{myinfo._mingcheng}','{myinfo._jinjichengdu}','{myinfo._jutiyaoqiu}',@附件,'{myinfo._shixian}'," +
                $"'{myinfo._banliyijian}','{myinfo._banlirenyuan}','{myinfo._jinzhanqingkuang}','{myinfo._fasongshijian}','{myinfo._fasongren}','{myinfo._leixing}',0,'{myinfo._zhuangtai}')";
            int num = _mysql.ExecuteNonQuery(str_sql, new MySqlParameter("@附件", myinfo._fujian));
            return num > 0 ? true : false;
        }





    }
}
