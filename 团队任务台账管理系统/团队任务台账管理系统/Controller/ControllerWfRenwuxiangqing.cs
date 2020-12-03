using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.Properties;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerWfRenwuxiangqing
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        public DataTable GetData()
        {
            string str_sql = $"select * from jjtask where 状态='未撤销'";

            var data = mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }
        /// <summary>
        /// 用来刷新已读状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateData(string renwumingcheng, string str_time)
        {
            string str_sql = $"update jjtask set 已读=1,打开时间='{str_time}' where 任务名称='{renwumingcheng}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 该方法用于更新任务的详情
        /// </summary>
        /// <param name="renwumingcheng"></param>
        /// <param name="jutiyaoqiu"></param>
        /// <param name="fenjie"></param>
        /// <param name="jinzhan"></param>
        /// <returns></returns>
        public bool UpdateTask(string renwumingcheng, string jutiyaoqiu, string fenjie, string jinzhan, string banliren, string yanshouren)
        {
            string str_sql = $"update jjtask set 具体要求='{jutiyaoqiu}',分解='{fenjie}',进展='{jinzhan}',办理人='{banliren}',验收人='{yanshouren}' where 任务名称='{renwumingcheng}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;



        }
        /// <summary>
        /// 提交验收任务
        /// </summary>
        /// <param name="renwumingcheng">任务名称</param>
        /// <param name="user">提交人</param>
        /// <returns></returns>
        
        public bool TijiaoYanshou(string renwumingcheng,string banliren)
        {
            bool b = false;
           // string str_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
          string str_sql = string.Empty;
           // for (int i = 0; i < person.Count; i++)
            //{
                //str_sql = $"insert into jjtasksend values('{renwumingcheng}','{banliren}','{str_date}','已发送','{yanshouren}')";
            str_sql = $"update jjtasksend set 任务状态='提交验收' where 任务名称='{renwumingcheng}' and 办理人='{banliren}'";
                int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
                if (num > 0) b = true;
            //}
            return b;

        }

        /// <summary>
        /// 验收已提交的任务
        /// </summary>
        /// <param name="renwumingcheng">任务名称</param>
        /// <param name="yanshouren">验收人</param>
        /// <returns></returns>
        public bool YanshouRenwu(string renwumingcheng,string yanshouren)
        {
            bool b = false;
            // string str_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string str_sql = string.Empty;
            // for (int i = 0; i < person.Count; i++)
            //{
            //str_sql = $"insert into jjtasksend values('{renwumingcheng}','{banliren}','{str_date}','已发送','{yanshouren}')";
            str_sql = $"update jjtasksend set 任务状态='通过验收' where 任务名称='{renwumingcheng}' and 验收人='{yanshouren}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            if (num > 0) b = true;
            //}
            return b;

        }
        public bool SendTask(string renwumingcheng, List<string> person, string yanshouren)
        {
            //构造datatable，用于大量插入数据
            //DataTable mydt = new DataTable();
            //mydt.TableName = "jjtasksend";
            //mydt.Columns.Add("任务名称");
            //mydt.Columns.Add("办理人");
            //mydt.Columns.Add("发送时间");
            //mydt.Columns.Add("任务状态");
            //mydt.Columns.Add("验收人");
            bool b = false;
            string str_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string str_sql = string.Empty;
            for (int i = 0; i < person.Count; i++)
            {
                string banliren = person[i];
                str_sql = $"insert into jjtasksend values('{renwumingcheng}','{banliren}','{str_date}','已发送','{yanshouren}')";
                int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
                if (num > 0) b = true;
            }
            return b;
        }

        /// <summary>
        /// 获得未读任务数量
        /// </summary>
        /// <returns></returns>
        public int GetWeidu()
        {
            string str_sql = $"select count(*) from jjtask where 状态='未撤销' and 已读=0";
            //string str_sql = $"update jjtask set 已读=1 where 任务名称='{renwumingcheng}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
            return num;

        }

    }
}
