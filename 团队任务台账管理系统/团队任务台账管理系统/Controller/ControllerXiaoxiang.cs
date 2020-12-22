using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerXiaoxiang
    {
        MySQLHelper _mysql = new MySQLHelper();

        public bool Xiaoxiang(JJQingdanInfo info)
        {
            string str_sql = $"update jjdbrenwutaizhang.jjgongzuoqingdan set 销项={info._xiaoxiang} " +
                    $",心得体会='{info._xindetihui}' where 任务名称='{info._renwumingcheng}' and 销项=0 and 创建人='{info._chuangjianren}'";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }





    }
}
