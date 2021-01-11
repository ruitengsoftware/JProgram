using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerOkrshixiang
    {
        MySQLHelper _mysql = new MySQLHelper();
        public bool SaveOkrshixiang(JJTaskInfo myinfo)
        {

            //判断该任务是否存在，如果存在，使用update，如果不存在使用insert into
            string str_sql = $"select count(*) from jjdbrenwutaizhang.任务信息表 where 删除=0 and 名称='{myinfo._mingcheng}' and 类型='{myinfo._leixing}'";
            int num = Convert.ToInt32(_mysql.ExecuteScalar(str_sql));
            if (num > 0)
            {
                str_sql = $"update jjdbrenwutaizhang.任务信息表 set 名称='{myinfo._mingcheng}',紧急程度='{myinfo._jinjichengdu}',总体目标='{myinfo._mubiao}'," +
                    $"总体验收人='{myinfo._zongtiyanshouren}',成果集='{myinfo._chengguoji}' where 名称='{myinfo._mingcheng}' and 删除=0 and 类型='{myinfo._leixing}'";
            }
            else
            {
                str_sql = $"insert into jjdbrenwutaizhang.任务信息表 (名称,紧急程度,总体目标,总体验收人,成果集,创建人,创建时间,类型,删除,状态) " +
                    $"values('{myinfo._mingcheng}','{myinfo._jinjichengdu}','{myinfo._mubiao}','{myinfo._zongtiyanshouren}','{myinfo._chengguoji}'," +
                    $"'{JJLoginInfo._huaming}','{myinfo._chuangjianshijian}','{myinfo._leixing}',0,'{myinfo._zhuangtai}')";

            }
            num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;

        }
        public bool FasongBanli(JJTaskInfo myinfo)
        {

            string str_sql = $"insert into jjdbrenwutaizhang.任务信息表 (名称,紧急程度,总体目标,总体验收人,成果集,发送人,发送时间,类型,删除,状态) " +
                $"values('{myinfo._mingcheng}','{myinfo._jinjichengdu}','{myinfo._mubiao}','{myinfo._zongtiyanshouren}','{myinfo._chengguoji}'," +
                $"'{myinfo._fasongren}','{myinfo._fasongshijian}','{myinfo._leixing}',0,'{myinfo._zhuangtai}')";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }




    }
}
