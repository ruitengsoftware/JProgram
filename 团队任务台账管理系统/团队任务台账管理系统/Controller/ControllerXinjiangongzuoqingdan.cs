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
            string str_sql = $"delete from jjgongzuoqingdan where 创建人='{JJLoginInfo._shiming}' and 任务名称='{renwu._renwumingcheng}'";
            _mysqlhelper.ExecuteNonQuery(str_sql);


            //保存任务
            str_sql = $"insert into jjgongzuoqingdan values('{renwu._renwumingcheng}','{JJLoginInfo._shiming}','{renwu._zhubanren}','{renwu._wanchengshijian}',0,'{renwu._xiangxian}','{renwu._chuangjianshijian}')";
           int num= _mysqlhelper.ExecuteNonQuery(str_sql);

            //返回值
            return num > 0 ? true : false;
        }


    }
}
