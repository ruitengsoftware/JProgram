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
        /// 根据待办任务名称获得信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Yidu(JJTongzhiInfo info)
        {
            string str_sql = $"update jjdbrenwutaizhang.通知公告表 set 状态='已读' where 标题='{info._biaoti}' " +
                            $"and 状态='未读' and 签发人='{info._qianfaren}'";
           int num= _sql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
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
            string str_sql = $"select * from jjdbrenwutaizhang.工作清单表 where 任务名称='{s}' and 删除=0";
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
        /// <summary>
        /// 删除任务清单
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool DeleteGongzuoqingdan(object o)
        {
            JJQingdanInfo myinfo = o as JJQingdanInfo;
            string str_sql = $"update jjdbrenwutaizhang.工作清单表 set 删除=1 where 任务名称='{myinfo._renwumingcheng}' " +
                    $"and 创建人='{myinfo._chuangjianren}' and 删除=0";
            int num = _sql.ExecuteNonQuery(str_sql);

            return num > 0 ? true : false;
        
        }

    }
}
