using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{
    public class ControllerWFhoutai
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 获得所有人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable(string str)
        {
            DataTable mydt = _mysqlhelper.ExecuteDataTable(str);
            return mydt;
        }
        /// <summary>
        /// 更新person表中删除规则或查重库的值
        /// </summary>
        /// <param name="s">更新值</param>
        /// <param name="t">更新字段，规则或查重库</param>
        /// <returns></returns>
        public bool UpdateSuoding(string s,string t)
        {
            string str_sql = $"update jjdbrenwutaizhang.jjperson set {t}='{s}' where 删除=0";
            int num = _mysqlhelper.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        
        }





        /// <summary>
        /// 更新权限
        /// </summary>
        /// <param name="huaming">花名</param>
        /// <param name="denglu">登录权</param>
        /// <param name="d1">调用规则</param>
        /// <param name="d2">调用查重库</param>
        /// <param name="s1">删除规则</param>
        /// <param name="s2">删除查重库</param>
        /// <returns></returns>
        public bool UpdateShouquan(PersonInfo p)
        {
            string str_sql = $"update jjdbrenwutaizhang.jjperson set 登录权={p._dengluquan},权限='{p._quanxian}',调用规则='{p._diaoyongguize}',调用查重库='{p._diaoyongchachongku}'" +
                $"where 花名='{p._huaming}'";
                int num = _mysqlhelper.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }



    }
}
