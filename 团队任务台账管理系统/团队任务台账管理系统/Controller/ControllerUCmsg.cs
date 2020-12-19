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
        public JJTaskInfo GetChangguiInfo(string s)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.常规事项表 where 任务名称='{s}' and 删除=0";
            DataRow mydr = _sql.ExecuteDataRow(str_sql);
            JJTaskInfo myti = new JJTaskInfo() { 
            
            
            
            };
            return myti;


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

        public JJQingdanInfo GetQingdanInfo(string s)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.jjgongzuoqingdan where 任务名称='{s}' and 删除=0";
            DataRow mydr = _sql.ExecuteDataRow(str_sql);
            JJQingdanInfo ci = new JJQingdanInfo()
            {
                _renwumingcheng = mydr["任务名称"].ToString(),
                 _chuangjianren= mydr["创建人"].ToString(),
                _zhubanren = mydr["主办人"].ToString(),
                _wanchengshijian = mydr["完成时间"].ToString(),
                _xiangxian = mydr["象限"].ToString(),
                _chuangjianshijian = mydr["创建时间"].ToString(),
               _zhuangtai= mydr["状态"].ToString(),
            };
            return ci;
        }



    }
}
