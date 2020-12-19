using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerUCmytask
    {
        MySQLHelper mysql = new MySQLHelper();
        /// <summary>
        /// 获得需要的任务信息
        /// </summary>
        /// <param name="s">sql语句</param>
        /// <returns></returns>
        public List<JJTaskInfo> GetTaskinfo(string s)
        {
            List<JJTaskInfo> list = new List<JJTaskInfo>();
            JJTaskInfo myti = new JJTaskInfo();
            DataTable mydt = mysql.ExecuteDataTable(s);

            foreach (DataRow mydr in mydt.Rows)
            {
                myti = new JJTaskInfo() { 
                _mingcheng=mydr["名称"].ToString(),
                    _leixing=mydr["类型"].ToString(),
                    _canyuren=mydr["参与人"].ToString(),
                    _fuzeren=mydr["负责人"].ToString(),
                    _zhuangtai=mydr["状态"].ToString(),
                    _xiangqing=mydr["详情"].ToString(),
                    _chuangjianren = mydr["创建人"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString(),
                    _duqushijian = mydr["读取时间"].ToString(),
                    _shixian = mydr["时限"].ToString(),
                    _jinjichengdu = mydr["紧急程度"].ToString(),
                    _shanchu =Convert.ToInt32( mydr["删除"].ToString())


                };
                list.Add(myti);

            }
            return list;
        
        
        }






    }
}
