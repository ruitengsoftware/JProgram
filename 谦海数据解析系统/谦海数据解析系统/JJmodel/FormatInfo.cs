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
   public class FormatInfo
    {
        /// <summary>
        /// 格式名称
        /// </summary>
        public string _formatName = string.Empty;
        /// <summary>
        /// 格式信息
        /// </summary>
        public string _formatSet = string.Empty;


        /// <summary>
        /// 本格式所包含的所有规则信息,除了内容信息
        /// </summary>
        public List<RuleInfo> list_ruleInfo = new List<RuleInfo>();
        /// <summary>
        /// 本格式包含的所有内容标签信息
        /// </summary>
        public List<TagInfo> list_tagInfo = new List<TagInfo>();


        /// <summary>
        /// 格式类型
        /// </summary>
        public string _formatType = string.Empty;
        /// <summary>
        /// 解析文件存储位置
        /// </summary>
        public string _savePath = string.Empty;
        /// <summary>
        /// 源文件夹
        /// </summary>
        public bool _yuanwenjianjia = false;

        /// <summary>
        /// 指定文件夹
        /// </summary>
        public bool _zhidingwenjianjia = false;

        public FormatInfo() { }

        /// <summary>
        /// 构造函数，仅传递格式名称进来  
        /// </summary>
        /// <param name="name"></param>
        public FormatInfo(string name)
        {
            _formatName = name;
            GetFormatInfo();
            //获取规则设置，内容解析的规则保存在单独的数据表中
            //如果formatinf的类型是内容解析，那么要从其他表格获得list
            if (_formatType.Equals("内容解析"))
            {
                GetTagInfo();
            }
            else
            {
            GetRuleInfo();

            }
        }

        /// <summary>
        /// 带有参数的构造函数,,保存路径（此项针对基础解析，内容解析和大数据版）
        /// </summary>
        /// <param name="name">格式名称</param>
        /// <param name="set">格式设置</param>
        /// <param name="type">格式类型</param>
       /// <param name="savePath">保存路径</param>

        public FormatInfo(string name, string set, string type,string savePath,bool yuan,bool zhiding)
        {
            _formatName = name;
            _formatSet = set;
            _formatType = type;
            _savePath = savePath;
            _yuanwenjianjia = yuan;
            _zhidingwenjianjia = zhiding;
        }
 /// <summary>
        /// 带有参数的构造函数
        /// </summary>
        /// <param name="name">格式名称</param>
        /// <param name="set">格式设置</param>
        /// <param name="type">格式类型</param>
        public FormatInfo(string name, string set, string type)
        {
            _formatName = name;
            _formatSet = set;
            _formatType = type;
        }

        /// <summary>
        /// 保存格式信息到数据库中，格式名称，格式类型和格式信息
        /// </summary>
        public void SaveFormatInfo()
        {
            //删除
            string str_sql = $"delete from 数据解析库.格式信息表 " +
                $"where 格式名称='{_formatName}' and 删除=0";
            MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
            //插入 insert  into
            str_sql = $"insert into 数据解析库.格式信息表 " +
                $"value('{_formatName}','{_formatSet}','{_formatType}',@savepath,{_yuanwenjianjia},{_zhidingwenjianjia},0)";
            MySqlHelper.ExecuteScalar(SystemInfo._strConn, str_sql,new MySqlParameter[] {
            new MySqlParameter("@savepath",_savePath )
            });
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
            _savePath = mydr["保存路径"].ToString();
            _yuanwenjianjia = Convert.ToBoolean(mydr["原文件夹"]);
            _zhidingwenjianjia = Convert.ToBoolean(mydr["指定文件夹"]);
        }
        /// <summary>
        /// 获得内容解析标签集合
        /// </summary>
        public void GetTagInfo()
        {
            string[] arrRule = Regex.Split(_formatSet, @"\|");
            foreach (string str in arrRule)
            {
                //str是解析库名称
                string str_sql = $"select * from 数据解析库.内容标签表 " +
                    $"where 库名='{str}' and 删除=0";
                DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
                foreach (DataRow item in mydt.Rows)
                {
                    string name = item["名称"].ToString();
                    //根据父标签名构造一个taginfo
                    TagInfo parentti = new TagInfo();


                    TagInfo ti = new TagInfo(name, null);
                    list_tagInfo.Add(ti);
                }
            }
        }



        /// <summary>
        /// 该方法获得格式的所有规则信息
        /// </summary>
        public void GetRuleInfo()
        {
            //在获得的格式set中，非内容解析格式获得的是直接的ruleinfo
            //但是对于内容解析，获得的是解析规则上衣层级的库名，所以需要一个方法，根据库名获得该库名下的所有taginfo
            string[] arrRule = Regex.Split(_formatSet, @"\|");
            foreach (string str in arrRule)
            {
                //如果是内容解析，应该创建标签信息实例
                RuleInfo ri = new RuleInfo(str, _formatType);
                list_ruleInfo.Add(ri);
            }
        }





    }
}
