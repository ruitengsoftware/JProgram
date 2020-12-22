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
        public List<JJQingdanInfo> GetLishiziilao()
        {
            List<JJQingdanInfo> list = new List<JJQingdanInfo>();
            string str_sql = "select * from jjdbrenwutaizhang.jjgongzuoqingdan where 销项=1";
            DataTable mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in mydt.Rows)
            {
                JJQingdanInfo info = new JJQingdanInfo()
                {
                    _renwumingcheng = mydr["任务名称"].ToString(),
                    _chuangjianren = mydr["创建人"].ToString(),
                    _zhubanren = mydr["主办人"].ToString(),
                    _wanchengshijian = mydr["完成时间"].ToString(),
                    _xiangxian = mydr["象限"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString(),
                    _zhuangtai = mydr["状态"].ToString(),
                    _xiaoxiang = Convert.ToInt32(mydr["销项"].ToString()),
                    _beizhu = mydr["备注"].ToString(),
                    _xindetihui = mydr["心得体会"].ToString(),
                };
                list.Add(info);
            }
            return list;
        }



    }
}
