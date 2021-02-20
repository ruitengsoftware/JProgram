using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerWFtongzhigonggao
    {
        MySQLHelper _mysql= new MySQLHelper();

        public bool SaveTongzhi(JJTongzhiInfo myinfo)
        {
            string str_sql = $"insert into jjdbrenwutaizhang.通知公告表 values('{myinfo._biaoti}','{myinfo._qianfaren}','{myinfo._neirongpath}',0,'{myinfo._zhuangtai}','{myinfo._fabushijian}','{myinfo._qingzhonghuanji}'" +
                $",'{myinfo._shixian}','{myinfo._yuedufanwei}','{myinfo._fujian}','{myinfo._chuangjianren}')";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }

        public bool Yidu(JJTongzhiInfo info)
        {
            //string str_sql = $"update jjdbrenwutaizhang.通知公告表 set 状态='已读' where 标题='{info._biaoti}' and 删除=0 " +
            //                $"and 状态='未读' and 签发人='{info._qianfaren}'";
            string str_sql = $"update jjdbrenwutaizhang.通知公告表 set 状态='已读' where 标题='{info._biaoti}'";

            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }


    }
}
