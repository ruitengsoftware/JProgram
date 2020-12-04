using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerOkrshixiang
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();
        public bool SaveOkrshixiang(JJOkrInfo myokr)
        {
            string str_sql = $"delete from jjokrshixiang where 任务名称='{myokr._renwumingcheng}'";
            _mysqlhelper.ExecuteNonQuery(str_sql);
            str_sql = $"insert into jjokrshixiang values('{myokr._renwumingcheng}','{myokr._jinjichengdu}','{myokr._mubiao}','{JsonConvert.SerializeObject(myokr._chengguoji)}')";
           int num= _mysqlhelper.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;



        }




    }
}
