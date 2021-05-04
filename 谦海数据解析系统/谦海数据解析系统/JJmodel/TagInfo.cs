using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 谦海数据解析系统.JJmodel
{
    /// <summary>
    /// 内容标签表库的model类
    /// </summary>
    public class TagInfo
    {
        /// <summary>
        /// 库名
        /// </summary>
        public string _kuming = string.Empty;
        /// <summary>
        /// 标签名称
        /// </summary>
        public string _mingcheng = string.Empty;
        /// <summary>
        /// 标签级别
        /// </summary>
        public int _jibie = 0;
        /// <summary>
        /// 设置的json表达方式，这一项再初始化时不需要
        /// </summary>
        public TagRoot _tagRoot = new TagRoot();
        /// <summary>
        /// 设置
        /// </summary>
        public string _biaoqianSet = string.Empty;
        /// <summary>
        /// 创建人
        /// </summary>
        public string _chuangjianren = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string _chuangjianshijian = string.Empty;
        /// <summary>
        /// 该标签的所有子节点
        /// </summary>
        public List<TagInfo> _childNodes = new List<TagInfo>();
        /// <summary>
        /// 父节点名称，用于获得父节点信息
        /// </summary>
        public string _parentName = string.Empty;


        /// <summary>
        /// 该标签节点的父节点
        /// </summary>
        public TagInfo _parent = null;
        /// <summary>
        /// 不含参数的构造函数
        /// </summary>
        public TagInfo()
        {
        }



        /// <summary>
        /// 不含参数的构造函数
        /// </summary>
        public TagInfo(string name, TagInfo tag)
        {
            if (tag==null)
            {
                _parent = new TagInfo();
                return;
            }
            _mingcheng = name;
            _kuming = tag._kuming;
            _parent = tag;
            GetTagInfo();
        }





        /// <summary>
        /// 获得自己的信息，包括设置，以及父标签和子标签集合
        /// </summary>
        public void GetTagInfo()
        {
            List<TagInfo> list_result = new List<TagInfo>();
            string str_sql = $"select * from 数据解析库.内容标签表 " +
                $"where 删除=0 and 名称='{_mingcheng}' and 库名='{_kuming}'";
            DataRow mydr = MySqlHelper.ExecuteDataRow(SystemInfo._strConn, str_sql);
            _jibie = Convert.ToInt32(mydr["级别"].ToString());
            _biaoqianSet = mydr["设置"].ToString();
            _chuangjianren = mydr["创建人"].ToString();
            _chuangjianshijian = mydr["创建时间"].ToString();
            _parentName = mydr["父标签名"].ToString();
            //GetParentNode();
            GetChildNodes();
            TagRoot root = JsonConvert.DeserializeObject<TagRoot>(_biaoqianSet);
        }

        /// <summary>
        /// 获得父节点
        /// </summary>
        public void GetParentNode()
        {
            //先判断是否是内容标签，内容标签没有父节点
            if (_parentName.Equals("无"))
            {
                return;
            }
            string str_sql = $"select * from 数据解析库.内容标签表 " +
        $"where 删除=0 and 名称='{_parentName}' and 库名='{_kuming}'";
            DataRow mydr = MySqlHelper.ExecuteDataRow(SystemInfo._strConn, str_sql);
            _parent._kuming = mydr["库名"].ToString();
            _parent._mingcheng = mydr["名称"].ToString();
            _parent._jibie = Convert.ToInt32(mydr["级别"].ToString());
            _parent._biaoqianSet = mydr["设置"].ToString();
            _parent._chuangjianren = mydr["创建人"].ToString();
            _parent._chuangjianshijian = mydr["创建时间"].ToString();
            _parent._parentName = mydr["父标签名"].ToString();
            TagRoot root = JsonConvert.DeserializeObject<TagRoot>(_parent._biaoqianSet);
            _parent._tagRoot = root;
        }


        /// <summary>
        /// 获得节点的所有子节点信息
        /// </summary>
        /// <returns></returns>
        public void GetChildNodes()
        {
            List<TagInfo> list_result = new List<TagInfo>();
            string str_sql = $"select * from 数据解析库.内容标签表 " +
                $"where 删除=0 and 父标签名='{_mingcheng}' and 库名='{_kuming}'";
            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                DataRow mydr = mydt.Rows[i];
                TagInfo myinfo = new TagInfo(
                    mydr["名称"].ToString(),
                  this
                    )
                { };

                TagRoot root = JsonConvert.DeserializeObject<TagRoot>(myinfo._biaoqianSet);
                myinfo._tagRoot = root;
                _childNodes.Add(myinfo);
            }
        }





        /// <summary>
        /// 用于存放每个标签设置的root
        /// </summary>
        public class TagRoot
        {
            /// <summary>
            /// 内容标签类别
            /// </summary>
            public List<string> list_leibie = new List<string>();
            /// <summary>
            /// 标签说明
            /// </summary>
            public string shuoming = string.Empty;
            /// <summary>
            /// 正则条件
            /// </summary>
            public string zhengze = string.Empty;
            /// <summary>
            /// 对象位置
            /// </summary>
            public List<string> list_position = new List<string>();
            /// <summary>
            /// 顺数段索引
            /// </summary>
            public int shunshu = 0;
            /// <summary>
            /// 倒数段索引
            /// </summary>
            public int daoshu = 0;
            /// <summary>
            /// 匹配度
            /// </summary>
            public List<string> list_pipei = new List<string>();
            /// <summary>
            /// 固定值
            /// </summary>
            public string gudingzhi = string.Empty;
            /// <summary>
            /// 句首值
            /// </summary>
            public string jushouzhi = string.Empty;
            /// <summary>
            /// 句中值
            /// </summary>
            public string juzhongzhi = string.Empty;
            /// <summary>
            /// 句尾值
            /// </summary>
            public string juweizhi = string.Empty;
            /// <summary>
            /// 位置前字词
            /// </summary>
            public string weizhiqian0 = string.Empty;
            /// <summary>
            /// 位置前值
            /// </summary>
            public string weizhiqian1 = string.Empty;
            /// <summary>
            /// 位置后字词
            /// </summary>
            public string weizhihou0 = string.Empty;
            /// <summary>
            /// 位置后值
            /// </summary>
            public string weizhihou1 = string.Empty;
            /// <summary>
            /// 节点内容
            /// </summary>
            public List<string> list_neirong = new List<string>();
            /// <summary>
            /// 特定语篇内容提取
            /// </summary>
            public List<string> list_yupian = new List<string>();
            /// <summary>
            /// 正则提取式
            /// </summary>
            public string zhengzetiqu = string.Empty;

        }
    }
}
