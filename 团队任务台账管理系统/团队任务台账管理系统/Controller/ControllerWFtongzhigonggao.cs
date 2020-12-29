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
        MySQLHelper _mysqlhelper = new MySQLHelper();

        public bool SaveTongzhi(JJTongzhiInfo myinfo)
        {
            string str_sql = $"insert into jjdbrenwutaizhang.通知公告表 values('{myinfo._biaoti}','{myinfo._qianfaren}','{myinfo._neirong}',0,'{myinfo._zhuangtai}','{myinfo._fabushijian}','{myinfo._qingzhonghuanji}'" +
                $",'{myinfo._shixian}','{myinfo._yuedufanwei}','{myinfo._shangchuanfujian}')";
        int num = _mysqlhelper.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;



        }

    }
}
