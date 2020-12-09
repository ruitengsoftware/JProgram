using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;
using 文本解析系统.JJModel;

namespace 文本解析系统.JJController
{
    public class ControllerWFcreatedb
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();

        /// <summary>
        /// 判断数据表名称是否已经存在
        /// </summary>
        /// <param name="dbname"></param>
        /// <returns></returns>
        public bool IsExist(string dbname)
        {
            
            string str_sql = $"select count(*) from jjdbwenbenjiexi.查重库信息表 where 名称='{dbname}'";
            int num =Convert.ToInt32( _mysqlhelper.ExecuteScalar(str_sql));
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CreateDB(ChachongbiaoInfo info)
        {
            string str_sql = $"insert into jjdbwenbenjiexi.查重库信息表 values('{info._mingcheng}'," +
                    $"'{info._leixing}','{UserInfo._huaming}','{info._chuangjianshijian}',0)";
            int num = _mysqlhelper.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        
        
        }



    }
}
