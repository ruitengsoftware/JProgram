using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerWFyijian
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();

        public bool SaveYijian(JJyijianInfo myinfo)
        {
string str_sql=$"insert into 意见建议表 values('{myinfo._biaoti}','{myinfo._fankuiren}','{myinfo._fankuiduixiang}','{myinfo._neirong}'," +
                $"'{myinfo._chuangjianishijian}',0)";
            int num = _mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;



        }

    }
}
