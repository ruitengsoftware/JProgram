 using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 谦海数据解析系统.JJmodel
{
    class FormatInfo
    {
        public FormatInfo() { }

        /// <summary>
        /// 构造函数，仅传递格式名称进来  
        /// </summary>
        /// <param name="name"></param>
        public FormatInfo(string name)
        {
            _formatName = name;
        }


        /// <summary>
        /// 构造函数，三个参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <param name="type"></param>
        public FormatInfo(string name,string info,string type) 
        {
            _formatName = name;
            _formatSet = info;
            _formatType = type;
        }




        /// <summary>
        /// 格式名称
        /// </summary>
        public  string _formatName = string.Empty;
        /// <summary>
        /// 格式信息
        /// </summary>
        public   string _formatSet = string.Empty;


        /// <summary>
        /// 本格式所包含的所有规则信息
        /// </summary>
        public List<RuleInfo> _ruleInfo = new List<RuleInfo>();
        /// <summary>
        /// 格式类型
        /// </summary>
        public  string _formatType = string.Empty;

        /// <summary>
        /// 保存格式信息到数据库中，格式名称，格式类型和格式信息
        /// </summary>
        public  void SaveFormatInfo()
        {
            //删除
            string str_sql = $"delete from 数据解析库.格式信息表 where 格式名称='{_formatName}' and 删除=0";
            MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
            //插入 insert  into
            str_sql = $"insert into 数据解析库.格式信息表 value('{_formatName}','{_formatSet}','{_formatType}',0)";
            MySqlHelper.ExecuteScalar(SystemInfo._strConn, str_sql);
            System.Windows.Forms.MessageBox.Show($"格式 {_formatName} 已保存成功！");
        }

        /// <summary>
        /// 获得格式名称对应的格式信息
        /// </summary>
        public void GetFormatInfo()
        {
            string str_sql = $"select * from 数据解析库.格式信息表 where 格式名称='{_formatName}' and 删除=0";
            DataRow mydr = MySqlHelper.ExecuteDataRow(SystemInfo._strConn, str_sql);
            _formatType = mydr["格式类型"].ToString();
            _formatSet = mydr["格式设置"].ToString();
        }


        /// <summary>
        /// 该方法获得格式的所有规则信息，需要先调用getformatinfo方法获得格式信息
        /// </summary>
        public void GetRuleInfo()
        {
            string[] arrRule = Regex.Split(_formatSet, @"\|");
            foreach (string str  in arrRule)
            {
                RuleInfo ri = new RuleInfo(str);
                ri.GetRuleInfo();
            }
        
        
        
        }




    }
}
