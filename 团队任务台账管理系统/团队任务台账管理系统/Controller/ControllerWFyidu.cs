using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{

  

   public class ControllerWFyidu
    {
        MySQLHelper _mysql = new MySQLHelper();


        public List<JJTaskInfo> GetTasks(JJTaskInfo ti)
        {
            List<JJTaskInfo> list = new List<JJTaskInfo>();
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 名称='{ti._mingcheng}' " +
                $"and 类型='{ti._leixing}'";
            DataTable mydt = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in mydt.Rows)
            {
                JJTaskInfo myinfo = new JJTaskInfo() { 
                _mingcheng=mydr["名称"].ToString(),
                //_leixing= mydr[""].ToString(),
                _canyuren= mydr["参与人"].ToString(),
                _zhuangtai= mydr["状态"].ToString(),




                };

                list.Add(myinfo);


            }

            return list;
        
        
        
        }



    }
}
