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
    /// 规则信息类，包含用于json转换的ruleroot
    /// </summary>
    public class RuleInfo
    {
        /// <summary>
        ///规则名称
        /// </summary>
        public string ruleName = string.Empty;
        /// <summary>
        /// 规则类型
        /// </summary>
        public string ruleType = string.Empty;
        /// <summary>
        /// 用于json格式化的ruleroot类
        /// </summary>
        public object _root = new object();
        /// <summary>
        /// 规则设置的文本信息，json格式
        /// </summary>
        public string ruleSet = string.Empty;
        /// <summary>
        /// 创建人
        /// </summary>
        public string _chuangjianren = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string _chuangjianshijian = string.Empty;

        public RuleInfo() { 
        }
        /// <summary>
        /// 构造函数，仅仅把格式名称传递进去
        /// </summary>
        /// <param name="name"></param>
        public RuleInfo(string name)
        {
            ruleName = name;
        }

        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        /// <param name="rulename"></param>
        /// <param name="ruletype"></param>
        /// <param name="r"></param>
        /// <param name="chuangjianren"></param>
        /// <param name="chuangjianshijian"></param>
        public RuleInfo(string rulename, string ruletype, object r, string chuangjianren, string chuangjianshijian)
        {
            ruleName = rulename;
            ruleType = ruletype;
            _root = r;
            ruleSet = JsonConvert.SerializeObject(r);
            _chuangjianren = chuangjianren;
            _chuangjianshijian = chuangjianshijian;
        }





        /// <summary>
        /// 保存规则信息到数据库中
        /// </summary>
        public void SaveRuleInfo()
        {
            //删除
            string str_sql = $"delete from 数据解析库.规则信息表 where 规则名称='{ruleName}'";
            MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
            //插入 insert  into
            str_sql = $"insert into 数据解析库.规则信息表 value('{ruleName}','{ruleType}','{ruleSet}'," +
                $"'{_chuangjianren}','{_chuangjianshijian}',0)";
            MySqlHelper.ExecuteScalar(SystemInfo._strConn, str_sql);
        }

        /// <summary>
        /// 获得规则信息
        /// </summary>
        public void GetRuleInfo()
        {
            string str_sql = $"select * from 数据解析库.规则信息表 where 规则名称='{ruleName}' and 删除=0";
            DataRow mydr = MySqlHelper.ExecuteDataRow(SystemInfo._strConn, str_sql);
            ruleType = mydr["规则类型"].ToString();
            ruleSet = mydr["规则设置"].ToString();
            _chuangjianren = mydr["创建人"].ToString();
            _chuangjianshijian = mydr["创建时间"].ToString();
            if (ruleType.Equals("文件名标准化"))
            {
                _root = JsonConvert.DeserializeObject<WjmRuleRoot>(ruleSet);
            }
            else if (ruleType.Equals("格式标准化"))
            {
                _root = JsonConvert.DeserializeObject<BzhRuleRoot>(ruleSet);

            }
            else if (ruleType.Equals("查重清洗"))
            {
                _root = JsonConvert.DeserializeObject<CcqxRuleRoot>(ruleSet);
            }
            else if (ruleType.Equals("基础解析"))
            {
                _root = JsonConvert.DeserializeObject<JcjxRuleRoot>(ruleSet);
            }
            else if (ruleType.Equals("内容解析"))
            {

            }
            else if (ruleType.Equals("大数据版"))
            {
                _root = JsonConvert.DeserializeObject<DsjRuleRoot>(ruleSet);
            }
        }


    }
    /// <summary>
    /// 文件名标准化规则root
    /// </summary>
    public class WjmRuleRoot
    {
        /// <summary>
        /// 规则说明
        /// </summary>
        public string ruleExplain = string.Empty;
        /// <summary>
        /// 文件名位置选择
        /// </summary>
        public List<string> position = new List<string>();
        /// <summary>
        /// 删除内容
        /// </summary>
        public string delete = string.Empty;
        /// <summary>
        /// 新增内容
        /// </summary>
        public string newText = string.Empty;
        /// <summary>
        /// 被替换内容
        /// </summary>
        public string replace0 = string.Empty;
        /// <summary>
        /// 替换内容
        /// </summary>
        public string replace = string.Empty;
    }
    /// <summary>
    /// 大数据版规则root
    /// </summary>
    public class DsjRuleRoot
    {
        /// <summary>
        /// 规则说明
        /// </summary>
        public string _ruleExplain = string.Empty;
        /// <summary>
        /// 比对MD5信息库
        /// </summary>
        public List<string> _xinxiku = new List<string>();
        /// <summary>
        /// 比对MD5值范围
        /// </summary>
        public List<string> _fanwei = new List<string>();
        /// <summary>
        /// MD5值重合标注操作
        /// </summary>
        public List<string> _biaozhu = new List<string>();
        /// <summary>
        /// 比对信息库标签中专有名词
        /// </summary>
        public List<string> _mingci = new List<string>();
        /// <summary>
        /// 标签库专有名词重合标注操作
        /// </summary>
        public List<string> _chonghe = new List<string>();
    }
    /// <summary>
    /// 查重清洗规则root
    /// </summary>
    public class CcqxRuleRoot
    {
        /// <summary>
        /// 规则说明
        /// </summary>
        public string _shuoming = string.Empty;
        /// <summary>
        /// 信息库
        /// </summary>
        public List<string> _xinxiku = new List<string>();
        /// <summary>
        /// MD5值比对范围
        /// </summary>
        public List<string> _fanwei = new List<string>();
        /// <summary>
        /// 删除操作
        /// </summary>
        public List<string> _shanchu = new List<string>();

    }
    /// <summary>
    /// 标准化规则root
    /// </summary>
    public class BzhRuleRoot
    {
        /*
        规则说明
        大标题行距方式，行距值，对齐方式，对其值，空行，字体，字号，粗体，缩进
        副标题行距方式，行距值，对齐方式，对其值，空行，字体，字号，粗体，缩进
        正文行距方式，行距值，对齐方式，对其值，空行，字体，字号，粗体，缩进
        一级标题行距方式，行距值，对齐方式，对其值，空行，字体，字号，粗体，缩进
        二级标题行距方式，行距值，对齐方式，对其值，空行，字体，字号，粗体，缩进
        三级标题行距方式，行距值，对齐方式，对其值，空行，字体，字号，粗体，缩进
        左边距，右边距，上边距，下边距
        页眉内容，页眉字体，页眉字号，页眉粗体，页眉居中
        页脚内容，页脚字体，页脚字号，页脚粗体，页脚居中
        页码格式，页码字体样式，页码居中
        空行消除
        标注名称
        文本范围
        文本内容
         */

        /// <summary>
        /// 左边距
        /// </summary>
        public decimal _zuobianju = 0;
        /// <summary>
        /// 右边距
        /// </summary>
        public decimal _youbianju = 0;
        /// <summary>
        /// 上边距
        /// </summary>
        public decimal _shangbianju = 0;
        /// <summary>
        /// 下边距
        /// </summary>
        public decimal _xiabianju = 0;
        /// <summary>
        /// 页眉内容
        /// </summary>
        public string _yemeinr = string.Empty;
        /// <summary>
        /// 页眉字体
        /// </summary>
        public string _yemeizt = string.Empty;
        /// <summary>
        /// 页眉字号
        /// </summary>
        public decimal _yemeizh = 0;
        /// <summary>
        /// 页眉粗体
        /// </summary>
        public bool _yemeict = false;
        /// <summary>
        /// 页眉居中
        /// </summary>
        public string _yemeijz = string.Empty;
        /// <summary>
        /// 也叫内容
        /// </summary>
        public string _yjnr = string.Empty;
        /// <summary>
        /// 页脚字体
        /// </summary>
        public string _yjzt = string.Empty;
        /// <summary>
        /// 页脚字号
        /// </summary>
        public decimal _yjzh = 0;
        /// <summary>
        /// 页脚粗体
        /// </summary>
        public bool _yjct = false;
        /// <summary>
        /// 页脚居中样式
        /// </summary>
        public string _yjjz = string.Empty;
        /// <summary>
        /// 说明
        /// </summary>
        public string _shuoming = string.Empty;
        /// <summary>
        /// 大标题行距样式
        /// </summary>
        public string _dbthjType = string.Empty;
        /// <summary>
        /// 大标题行距值
        /// </summary>
        public decimal _dbthjValue = 0;
        /// <summary>
        /// 大标题对齐样式
        /// </summary>
        public string _dbtdqType = string.Empty;
        /// <summary>
        /// 大标题对齐值
        /// </summary>
        public decimal _dbtdqValue = 0;
        /// <summary>
        /// 大标题空行
        /// </summary>
        public int _dbtkh = 0;
        /// <summary>
        /// 大标题字体
        /// </summary>
        public string _dbtzt = string.Empty;
        /// <summary>
        /// 大标题字号
        /// </summary>
        public decimal _dbtzh = 0;
        /// <summary>
        /// 大标题粗体
        /// </summary>
        public bool _dbtct = false;
        /// <summary>
        /// 大标题缩进
        /// </summary>
        public decimal _dbtsj = 0;
        /// <summary>
        /// 副标题行距样式
        /// </summary>
        public string _fbthjType = string.Empty;
        /// <summary>
        /// 副标题行距值
        /// </summary>
        public decimal _fbthjValue = 0;
        /// <summary>
        /// 副标题对其样式
        /// </summary>
        public string _fbtdqType = string.Empty;
        /// <summary>
        /// 副标题对齐值
        /// </summary>
        public decimal _fbtdqValue = 0;
        /// <summary>
        /// 副标题空行
        /// </summary>
        public int _fbtkh = 0;
        /// <summary>
        /// 副标题字体
        /// </summary>
        public string _fbtzt = string.Empty;
        /// <summary>
        /// 副标题字号
        /// </summary>
        public decimal _fbtzh = 0;
        /// <summary>
        /// 副标题粗体
        /// </summary>
        public bool _fbtct = false;
        /// <summary>
        /// 副标题缩进
        /// </summary>
        public decimal _fbtsj = 0;


        /// <summary>
        /// 正文行距样式
        /// </summary>
        public string _zwhjType = string.Empty;
        /// <summary>
        /// 正文行距值
        /// </summary>
        public decimal _zwhjValue = 0;
        /// <summary>
        /// 正文对齐样式
        /// </summary>
        public string _zwdqType = string.Empty;
        /// <summary>
        /// 正文对齐值
        /// </summary>
        public decimal _zwdqValue = 0;
        /// <summary>
        /// 正文空行
        /// </summary>
        public int _zwkh = 0;
        /// <summary>
        /// 正文字体
        /// </summary>
        public string _zwzt = string.Empty;
        /// <summary>
        /// 正文字号
        /// </summary>
        public decimal _zwzh = 0;
        /// <summary>
        /// 正文粗体
        /// </summary>
        public bool _zwct = false;
        /// <summary>
        /// 正文缩进
        /// </summary>
        public decimal _zwsj = 0;


        /// <summary>
        /// 一级标题行距样式
        /// </summary>
        public string _yjbthjType = string.Empty;
        /// <summary>
        /// 一级标题行距值
        /// </summary>
        public decimal _yjbthjValue = 0;
        /// <summary>
        /// 一级标题对齐样式
        /// </summary>
        public string _yjbtdqType = string.Empty;
        /// <summary>
        /// 一级标题对齐值
        /// </summary>
        public decimal _yjbtdqValue = 0;
        /// <summary>
        /// 一级标题空行
        /// </summary>
        public int _yjbtkh = 0;
        /// <summary>
        /// 一级标题字体
        /// </summary>
        public string _yjbtzt = string.Empty;
        /// <summary>
        /// 一级标题字号
        /// </summary>
        public decimal _yjbtzh = 0;
        /// <summary>
        /// 一级标题粗体
        /// </summary>
        public bool _yjbtct = false;
        /// <summary>
        /// 一级标题缩进
        /// </summary>
        public decimal _yjbtsj = 0;

        /// <summary>
        /// 二级标题行距类型
        /// </summary>
        public string _ejbthjType = string.Empty;
        /// <summary>
        /// 二级标题行距值
        /// </summary>
        public decimal _ejbthjValue = 0;
        /// <summary>
        /// 二级标题对齐方式
        /// </summary>
        public string _ejbtdqType = string.Empty;
        /// <summary>
        /// 二级标题对齐值
        /// </summary>
        public decimal _ejbtdqValue = 0;
        /// <summary>
        /// 二级标题空行
        /// </summary>
        public int _ejbtkh = 0;
        /// <summary>
        /// 二级标题字体
        /// </summary>
        public string _ejbtzt = string.Empty;
        /// <summary>
        /// 二级标题字号
        /// </summary>
        public decimal _ejbtzh = 0;
        /// <summary>
        /// 二级标题粗体
        /// </summary>
        public bool _ejbtct = false;
        /// <summary>
        /// 二级标题缩进
        /// </summary>
        public decimal _ejbtsj = 0;

        /// <summary>
        /// 三级标题行距样式
        /// </summary>
        public string _sjbthjType = string.Empty;
        /// <summary>
        /// 三级标题行距值
        /// </summary>
        public decimal _sjbthjValue = 0;
        /// <summary>
        /// 三级标题对齐样式
        /// </summary>
        public string _sjbtdqType = string.Empty;
        /// <summary>
        /// 三级标题对齐值
        /// </summary>
        public decimal _sjbtdqValue = 0;
        /// <summary>
        /// 三级标题空行
        /// </summary>
        public int _sjbtkh = 0;
        /// <summary>
        /// 三级标题字体
        /// </summary>
        public string _sjbtzt = string.Empty;
        /// <summary>
        /// 三级标题字号
        /// </summary>
        public decimal _sjbtzh = 0;
        /// <summary>
        /// 三级标题粗体
        /// </summary>
        public bool _sjbtct = false;
        /// <summary>
        /// 三级标题缩进
        /// </summary>
        public decimal _sjbtsj = 0;
        /// <summary>
        /// 页码格式
        /// </summary>
        public string _ymgs = string.Empty;
        /// <summary>
        /// 页码字体
        /// </summary>
        public string _ymzt = string.Empty;
        /// <summary>
        /// 页码居中方式
        /// </summary>
        public string _ymjz = string.Empty;
        /// <summary>
        /// 空行消除
        /// </summary>
        public bool _khxc = false;
        /// <summary>
        /// 标注名称
        /// </summary>
        public string _bzmc = string.Empty;
        /// <summary>
        /// 文本范围
        /// </summary>
        public string _wbfw = string.Empty;
        /// <summary>
        /// 文本内容
        /// </summary>
        public string _wbnr = string.Empty;
    }
    /// <summary>
    /// 基础解析规则root
    /// </summary>
    public class JcjxRuleRoot
    {
       





    }
}
