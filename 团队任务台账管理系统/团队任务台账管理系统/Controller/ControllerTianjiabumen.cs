using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerTianjiabumen
    {
        MySQLHelper _mysql = new MySQLHelper();

        /// <summary>
        /// 保存新的部门信息
        /// </summary>
        /// <param name="ji"></param>
        /// <returns></returns>
        public bool SaveBumen(JJBumenInfo ji)
        {
            string str_sql = $"insert into jjdbrenwutaizhang.部门信息表 values('{ji._mingcheng}','{ji._jibie}','{ji._suoshubumen}',0)";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 获得所有的一级部门名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetYijibumen()
        {
            List<string> list = new List<string>();
            string str_sql = $"select * from jjdbrenwutaizhang.部门信息表 where 删除=0 and 级别='一级部门'";
            DataTable mydt = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in mydt.Rows)
            {
                list.Add(mydr["名称"].ToString());
            }
            return list;
        }
    }
}
