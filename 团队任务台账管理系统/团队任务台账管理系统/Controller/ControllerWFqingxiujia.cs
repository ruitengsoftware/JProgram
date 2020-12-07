using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public  class ControllerWFqingxiujia
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();

        /// <summary>
        /// 保存请假信息
        /// </summary>
        /// <param name="myinfo"></param>
        /// <returns></returns>
        public bool SaveQingxiujia(JJqingjiaInfo myinfo)
        {
            string str_sql = $"insert into 请休假表 values('{myinfo._shenqignren}','{myinfo._shiyou}','{myinfo._kaishishijian}'," +
                    $"'{myinfo._jieshushijian}','{myinfo._weituoduixiang}','{myinfo._shenheyijian}','{myinfo._zhuangtai}',0)";
           int num= _mysqlhelper.ExecuteNonQuery(str_sql,null);
            return num > 0 ? true : false;
        
        
        }



    }
}
