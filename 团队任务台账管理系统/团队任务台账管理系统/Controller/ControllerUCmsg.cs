using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerUCmsg
    {
        MySQLHelper _sql = new MySQLHelper();

        /// <summary>
        /// 根据待办任务名称获得信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public JJchangguiInfo GetChangguiInfo(string s)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.常规事项表 where 任务名称='{s}' and 删除=0";
            DataRow mydr = _sql.ExecuteDataRow(str_sql);
            JJchangguiInfo ci = new JJchangguiInfo()
            {
                _renwumingcheng =mydr["任务名称"].ToString(),
                _jinjichengdu = mydr["紧急程度"].ToString(),
                _jutiyaoqiu = mydr["具体要求"].ToString(),
                _zerenren = mydr["责任人"].ToString(),
                _yanshouren = mydr["验收人"].ToString(),
                _shixian = mydr["时限"].ToString(),
                _jinzhanqingkuang = mydr["进展情况"].ToString(),


            };
            return ci;


        }

        /// <summary>
        /// 获得通知公告信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public JJTongzhiInfo GetTongzhiInfo(string s)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.通知公告表 where 标题='{s}' and 删除=0";
            DataRow mydr = _sql.ExecuteDataRow(str_sql);
            JJTongzhiInfo ci = new JJTongzhiInfo()
            {
                _biaoti = mydr["标题"].ToString(),
                _qianfaren = mydr["签发人"].ToString(),
                _neirong = mydr["内容"].ToString(),
                _zhuangtai = mydr["状态"].ToString(),
                _fabushijian = mydr["发布时间"].ToString(),


            };
            return ci;


        }




    }
}
