using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerBumentongxun
    {
        MySQLHelper _mysql = new MySQLHelper();

        /// <summary>
        /// 获得所有的部门信息
        /// </summary>
        /// <returns></returns>
        public List<JJBumenInfo> GetBumeninfos()
        {
            List<JJBumenInfo> list = new List<JJBumenInfo>();
            JJBumenInfo ji = new JJBumenInfo();
            string str_sql = $"select * from jjdbrenwutaizhang.部门信息表 where 删除=0";
            DataTable mydt = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in mydt.Rows)
            {
                ji = new JJBumenInfo() { 
                _mingcheng=mydr["名称"].ToString(),
                _jibie= mydr["级别"].ToString(),
                _suoshubumen= mydr["所属部门"].ToString()
                };
                list.Add(ji);
            }
            return list;
        }
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="ji"></param>
        /// <returns></returns>
        public bool DeleteBumen(JJBumenInfo ji)
        {
            string str_sql = $"update jjdbrenwutaizhang.部门信息表 set 删除=1 where 名称='{ji._mingcheng}'";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }
     /// <summary>
     /// 获得某部门的所有人员信息
     /// </summary>
     /// <param name="bumen">所属部门</param>
     /// <returns></returns>
        public DataTable GetPersonInfo(string bumen)
        {
            DataTable mydt = new DataTable();
            string str_sql = $"select * from jjdbrenwutaizhang.jjperson where 删除=0 and 部门='{bumen}'";
            mydt = _mysql.ExecuteDataTable(str_sql, null);
            return mydt;
        }


    }
}
