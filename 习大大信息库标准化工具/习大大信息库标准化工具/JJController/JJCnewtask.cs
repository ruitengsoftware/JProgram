using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 习大大信息库标准化工具.JJCommon;

namespace 习大大信息库标准化工具.JJController
{

   public class JJCnewtask
    {
        string str_con = "data source=49.233.40.109;userid=root;pwd=111111";
        MySqlHelper mysqlhelper = new MySqlHelper();
        /// <summary>
        /// 获得数据库中所有的解析格式
        /// </summary>
        /// <returns></returns>
        //public List<string> GetFormat()
        //{
            //List<string> list = new List<string>();
            //string str_sql = $"select 格式名称 from 解析格式表 where 删除=0";
            //DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql, null);
            //foreach (DataRow item in mydt.Rows)
            //{
            //    list.Add(item["格式名称"].ToString());
            //}
            //return list;
        //}
    }
}
