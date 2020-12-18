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
                _renwumingcheng=mydr["名称"].ToString(),
                    _leixing=mydr["类型"].ToString()
                };
                list.Add(myti);

            }
            return list;
        
        
        }






    }
}
