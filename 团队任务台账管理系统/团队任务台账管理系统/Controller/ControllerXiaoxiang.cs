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
            string str_sql = $"update jjdbrenwutaizhang.工作清单表 set 状态='已处理',经验教训='{info._jingyanjiaoxun}' " +
                $"where 名称='{info._renwumingcheng}'  and 创建人='{info._chuangjianren}' " +
                    $"and 删除=0";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }





    }
}
