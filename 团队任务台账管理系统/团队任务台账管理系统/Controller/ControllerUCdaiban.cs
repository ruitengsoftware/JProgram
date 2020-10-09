﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerUCdaiban
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        public DataTable GetData()
        {
            string str_sql = $"select * from jjtask where 状态='未撤销'";

            var data =  mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }
        /// <summary>
        /// 用来刷新已读状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateData(string renwumingcheng)
        {
            string str_sql = $"update jjtask set 已读=1 where 任务名称='{renwumingcheng}'";
           int num= mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 获得未读任务数量
        /// </summary>
        /// <returns></returns>
        public int GetWeidu()
        {
            string str_sql = $"select count(*) from jjtask where 状态='未撤销' and 已读=0";
            //string str_sql = $"update jjtask set 已读=1 where 任务名称='{renwumingcheng}'";
            int num =Convert.ToInt32( mysqlhelper.ExecuteScalar(str_sql, null));
            return num;

        }

    }
}
