using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 谦海数据解析系统.JJmodel.BiaoqianInfo;

namespace 谦海数据解析系统.JJmodel
{
    class MyMethod
    {

        /// <summary>
        /// 用于刷新内容标签的方法
        /// </summary>
        public static Action _updateTag = null;



        /// <summary>
        /// 从规则信息表中获得所有规则信息datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRules(string ruleType,string kw)
        {
            string str_sql = $"select * from 数据解析库.规则信息表 where 规则名称 like '%{kw}%' and 删除=0 and 规则类型='{ruleType}'";

            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            return mydt;
        }
        /// <summary>
        /// 从规则信息表中获得所有规则信息datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRulesOriginal(string kw)
        {
            string str_sql = $"select * from 数据解析库.规则信息表_基础 where 名称 like '%{kw}%' and 删除=0";

            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            return mydt;
        }

        /// <summary>
        /// 获得指定格式类型的所有格式名称
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFormats(string ruleType)
        {
            List<string> list_result = new List<string>();
            string str_sql = $"select 格式名称 from 数据解析库.格式信息表 where 删除=0 and 格式类型='{ruleType}'";
            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                list_result.Add(mydt.Rows[i]["格式名称"].ToString());
            }
            return list_result;
        }


        /// <summary>
        /// 在指定空间后面位置插入新的控件
        /// </summary>
        public static void AddControl(Control c, Control parentc)
        {
            //获得父控件的容器和父控件的位置
            Panel _panel = parentc.Parent as Panel;
            int _index = _panel.Controls.GetChildIndex(c);
            //位置+1，把c插入到容器中
            _panel.Controls.Add(c);
            _panel.Controls.SetChildIndex(c, _index - 1);
        }

        /// <summary>
        /// 在指定空间后面位置插入新的控件
        /// </summary>
        public static void AddControl(Control c, Panel panel)
        {
            //获得父控件的容器和父控件的位置
            panel.Controls.Add(c);
            panel.Controls.SetChildIndex(c, 0);

        }


        /// <summary>
        /// 获得节点的所有子节点信息
        /// </summary>
        /// <returns></returns>
        public static List<BiaoqianInfo> GetChildNodes(BiaoqianInfo _bqInfo)
        {
            List<BiaoqianInfo> list_result = new List<BiaoqianInfo>();
            string str_sql = $"select * from 数据解析库.内容标签表 where 删除=0 and 父标签名='{_bqInfo._mingcheng}' and 库名='{_bqInfo._kuming}'";
            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                DataRow mydr = mydt.Rows[i];
                BiaoqianInfo myinfo = new BiaoqianInfo()
                {
                    _kuming = mydr["库名"].ToString(),
                    _mingcheng = mydr["名称"].ToString(),
                    _jibie = Convert.ToInt32(mydr["级别"].ToString()),
                    _fubiaoqianming = mydr["父标签名"].ToString(),
                    _biaoqianSet = mydr["设置"].ToString(),
                    _chuangjianren = mydr["创建人"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString()
                };
                BiaoqianRoot root = JsonConvert.DeserializeObject<BiaoqianRoot>(myinfo._biaoqianSet);
                myinfo._biaoqianRoot = root;
                list_result.Add(myinfo);
            }
            return list_result;
        }

        /// <summary>
        /// 获得节点的所有子节点信息
        /// </summary>
        /// <returns></returns>
        public static List<BiaoqianInfo> GetChildNodes(BiaoqianInfo2 _bqInfo2)
        {
            List<BiaoqianInfo> list_result = new List<BiaoqianInfo>();
            string str_sql = $"select * from 数据解析库.内容标签表 " +
                $"where 删除=0 and 父标签名='{_bqInfo2.list_tag.Last()}' and 库名='{_bqInfo2._dbName}'";
            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                DataRow mydr = mydt.Rows[i];
                BiaoqianInfo myinfo = new BiaoqianInfo()
                {
                    _kuming = mydr["库名"].ToString(),
                    _mingcheng = mydr["名称"].ToString(),
                    _jibie = Convert.ToInt32(mydr["级别"].ToString()),
                    _fubiaoqianming = mydr["父标签名"].ToString(),
                    _biaoqianSet = mydr["设置"].ToString(),
                    _chuangjianren = mydr["创建人"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString()
                };
                BiaoqianRoot root = JsonConvert.DeserializeObject<BiaoqianRoot>(myinfo._biaoqianSet);
                myinfo._biaoqianRoot = root;
                list_result.Add(myinfo);
            }
            return list_result;
        }


    }
}
