﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerWFtongzhigonggao
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();

        public bool SaveTongzhi(JJTongzhiInfo myinfo)
        {
            string str_sql = $"insert into 通知公告表 values('{myinfo._biaoti}','{myinfo._qianfaren}','{myinfo._neirong}',0,'未读','{DateTime.Now.ToString("yyyyMMdd hh:mm:ss")}')";
        int num = _mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;



        }

    }
}
