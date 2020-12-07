using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.Properties;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerWfdaiban
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        public DataTable GetData()
        {
            string str_sql = $"select * from 常规事项表 where 删除=0";

            var data = mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }
        /// <summary>
        /// 用来刷新已读状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateData(string renwumingcheng, string str_time)
        {
            string str_sql = $"update 常规事项表 set 已读=1,打开时间='{str_time}' where 任务名称='{renwumingcheng}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 更新常规事项的信息
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public bool UpdateTask(JJchangguiInfo ci)
        {
            string str_sql = $"update 常规事项表 set 具体要求='{ci._jutiyaoqiu}',进展情况='{ci._jinzhanqingkuang}',责任人='{ci._zerenren}',验收人='{ci._yanshouren}' where 任务名称='{ci._renwumingcheng}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }
       /// <summary>
       /// 提交任务进行验收
       /// </summary>
       /// <param name="ci"></param>
       /// <returns></returns>
        public bool TijiaoYanshou(JJchangguiInfo ci)
        {
            bool b = false;
           // string str_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
          string str_sql = string.Empty;
           // for (int i = 0; i < person.Count; i++)
            //{
                //str_sql = $"insert into jjtasksend values('{renwumingcheng}','{banliren}','{str_date}','已发送','{yanshouren}')";
            str_sql = $"update 常规事项表 set 状态='待验收' where 任务名称='{ci._renwumingcheng}' and 状态='进行中'";
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
        public bool YanshouRenwu(JJchangguiInfo ci)
        {
            // string str_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string str_sql = string.Empty;
            // for (int i = 0; i < person.Count; i++)
            //{
            //str_sql = $"insert into jjtasksend values('{renwumingcheng}','{banliren}','{str_date}','已发送','{yanshouren}')";
            str_sql = $"update 常规事项表 set 状态='通过验收' where 任务名称='{ci._renwumingcheng}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;

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
                str_sql = $"insert into 常规事项表 values('{renwumingcheng}','{banliren}','{str_date}','已发送','{yanshouren}')";
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
            string str_sql = $"select count(*) from 常规事项表 where 状态='未撤销' and 已读=0";
            //string str_sql = $"update jjtask set 已读=1 where 任务名称='{renwumingcheng}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
            return num;

        }

    }
}
