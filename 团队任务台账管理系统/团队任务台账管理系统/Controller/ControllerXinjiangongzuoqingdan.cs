using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerXinjiangongzuoqingdan
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 新建工作清单
        /// </summary>
        /// <returns></returns>
        public bool SaveGongzuoqingdan(JJQingdanInfo renwu)
        {
            //先删除任务
            string str_sql = $"delete from jjdbrenwutaizhang.工作清单表 where 创建人='{renwu._chuangjianren}' " +
                $"and 名称='{renwu._renwumingcheng}' and 删除=0";
            _mysqlhelper.ExecuteNonQuery(str_sql);


            //保存任务
            str_sql = $"insert into jjdbrenwutaizhang.工作清单表(名称,轻重缓急,完成时间,备注,任务内容,创建时间,创建人,删除,状态) " +
                $"values('{renwu._renwumingcheng}','{renwu._qingzhonghuanji}','{renwu._wanchengshijian}','{renwu._beizhu}'," +
                $"'{renwu._renwuneirong}','{renwu._chuangjianshijian}','{renwu._chuangjianren}',0,'{renwu._zhuangtai}')";
            int num = _mysqlhelper.ExecuteNonQuery(str_sql);

            //返回值
            return num > 0 ? true : false;
        }


    }
}
