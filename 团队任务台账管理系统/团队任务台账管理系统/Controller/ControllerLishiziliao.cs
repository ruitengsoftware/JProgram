using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerLishiziliao
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();
        public List<JJQingdanInfo> GetLishiziliao()
        {
            List<JJQingdanInfo> list = new List<JJQingdanInfo>();
            string str_sql = "select * from jjdbrenwutaizhang.工作清单表 where " +
                "状态='已处理' and 删除=0";
            DataTable mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in mydt.Rows)
            {
                JJQingdanInfo info = new JJQingdanInfo()
                {
                    _qingzhonghuanji=mydr["轻重缓急"].ToString(),
                    _renwumingcheng = mydr["名称"].ToString(),
                    _chuangjianren = mydr["创建人"].ToString(),
                    _wanchengshijian = mydr["完成时间"].ToString(),
                    _xiangxian = mydr["象限"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString(),
                    _zhuangtai = mydr["状态"].ToString(),
                    //_xiaoxiang = Convert.ToInt32(mydr["销项"].ToString()),
                    _beizhu = mydr["备注"].ToString(),
                    _jingyanjiaoxun = mydr["经验教训"].ToString(),
                };
                list.Add(info);
            }
            return list;
        }

        public List<JJTongzhiInfo> GetTongzhiLishi()
        {
            List<JJTongzhiInfo> list = new List<JJTongzhiInfo>();
            string str_sql = "select * from jjdbrenwutaizhang.通知公告表 where 状态='已处理' and 删除=0";
            DataTable mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in mydt.Rows)
            {
                JJTongzhiInfo info = new JJTongzhiInfo()
                {
                    _biaoti = mydr["标题"].ToString(),
                    _qianfaren = mydr["签发人"].ToString(),
                    _neirongpath = mydr["内容"].ToString(),
                    _zhuangtai = mydr["状态"].ToString(),
                    _fabushijian = mydr["发布时间"].ToString(),
                    _qingzhonghuanji = mydr["轻重缓急"].ToString(),
                    _shixian = mydr["时限"].ToString(),
                    _yuedufanwei = mydr["阅读范围"].ToString(),
                    _fujian = mydr["附件"].ToString(),
                };
                list.Add(info);
            }
            return list;



        }

    }
}
