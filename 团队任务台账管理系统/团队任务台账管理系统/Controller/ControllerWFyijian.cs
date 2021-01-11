using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerWFyijian
    {
        MySQLHelper _mysql = new MySQLHelper();

        public bool SaveYijian(JJTaskInfo myinfo)
        {
            //判断该任务是否存在，如果存在，使用update，如果不存在使用insert into
            string str_sql = $"select count(*) from jjdbrenwutaizhang.任务信息表 where 删除=0 and 名称='{myinfo._mingcheng}' and 类型='{myinfo._leixing}'";
            int num = Convert.ToInt32(_mysql.ExecuteScalar(str_sql));
            if (num > 0)
            {
                str_sql = $"update jjdbrenwutaizhang.任务信息表 set 标题='{myinfo._biaoti}',紧急程度='{myinfo._jinjichengdu}',内容='{myinfo._neirong}'," +
                    $"反馈对象='{myinfo._fankuiduixiang}',处理意见='{myinfo._chuliyijian}' where 标题='{myinfo._mingcheng}' and 删除=0 and 类型='{myinfo._leixing}'";
            }
            else
            {
                str_sql = $"insert into jjdbrenwutaizhang.任务信息表 (标题,紧急程度,内容,反馈对象,处理意见,创建人,创建时间,类型,删除,状态) " +
                    $"values('{myinfo._biaoti}','{myinfo._jinjichengdu}','{myinfo._neirong}','{myinfo._fankuiduixiang}','{myinfo._chuliyijian}'," +
                    $"'{JJLoginInfo._huaming}','{myinfo._chuangjianshijian}','{myinfo._leixing}',0,'{myinfo._zhuangtai}')";

            }
            num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }



        public bool FasongBanli(JJTaskInfo myinfo)
        {
            string[] arr_duixiang = Regex.Split(myinfo._fankuiduixiang, ",");
            int num = 0;
            foreach (string str in arr_duixiang)
            {
                myinfo = new JJTaskInfo
                {
                    _biaoti = myinfo._biaoti,
                    _fankuiduixiang = str,
                    _neirong = myinfo._neirong,
                    _fasongshijian = myinfo._fasongshijian,
                    _jinjichengdu = myinfo._jinjichengdu,
                    _chuliyijian = myinfo._chuliyijian,
                    _leixing = "意见建议",
                    _zhuangtai = "未读",
                    _fasongren = myinfo._fasongren,

                };

                string str_sql = $"insert into jjdbrenwutaizhang.任务信息表 (标题,紧急程度,内容,反馈对象,处理意见,发送人,发送时间,类型,删除,状态) " +
            $"values('{myinfo._biaoti}','{myinfo._jinjichengdu}','{myinfo._neirong}','{myinfo._fankuiduixiang}','{myinfo._chuliyijian}'," +
            $"'{JJLoginInfo._huaming}','{myinfo._fasongshijian}','{myinfo._leixing}',0,'{myinfo._zhuangtai}')";
                num = _mysql.ExecuteNonQuery(str_sql);
            }
            return num > 0 ? true : false;
        }

    }
}
