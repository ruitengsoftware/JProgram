using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;
using 文本解析系统.JJModel;

namespace 文本解析系统.JJController
{
    public class ControllerGuize
    {
        MySQLHelper mysqlhelper = new MySQLHelper(MySQLHelper.str_connother);

        /// <summary>
        /// 保存规则
        /// </summary>
        /// <returns></returns>
        public bool SaveRule(string mingcheng, string shuoming, string xiangqing)
        {
            string str_sql = $"insert into 规则信息表 (创建人,创建时间,规则名称,规则说明,文本特征,删除) values(@创建人,@创建时间,@规则名称,@规则说明,@文本特征,0)";
            int num = mysqlhelper.ExecuteNonQuery(str_sql,
                new MySqlParameter("@创建人", UserInfo._huaming),
                new MySqlParameter(@"创建时间", DateTime.Now.ToString()),
                new MySqlParameter("@规则名称", mingcheng),
                new MySqlParameter("@规则说明", shuoming),
                new MySqlParameter("@文本特征", xiangqing));
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 删除指定的规则
        /// </summary>
        /// <param name="mingcheng">规则名称</param>
        /// <returns></returns>
        public bool DeleteRule(string mingcheng)
        {
            string str_sql = $"delete from 规则信息表 where 规则名称='{mingcheng}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;

        }
        /// <summary>
        /// 获得规则信息，返回一个rulinfo对象
        /// </summary>
        /// <param name="rulename">规则名称</param>
        /// <returns></returns>
        public RuleInfo GetRuleInfo(string rulename)
        {
            string str_sql = $"select * from 规则信息表 where 规则名称='{rulename}'";
            DataRow mydr = mysqlhelper.ExecuteDataRow(str_sql, null);
            RuleInfo myri = new RuleInfo();
            myri._guizemingcheng = mydr["规则名称"].ToString();
            myri._guizeshuoming = mydr["规则说明"].ToString();
            myri._wenbentezheng = mydr["文本特征"].ToString();
            myri._chuangjianren = mydr["创建人"].ToString();
            myri._chuangjianshijian = mydr["创建时间"].ToString();
            return myri;
        }




    }
}
