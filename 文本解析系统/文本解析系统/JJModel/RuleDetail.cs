using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文本解析系统.JJModel
{
    public class RuleDetail
    {
        /// <summary>
        /// 对象选择集合
        /// </summary>
        public List<string> duixiangxuanze = new List<string>();
        /// <summary>
        /// 文本特征(正则表达式)
        /// </summary>
        public string wenbentezheng = string.Empty;
        /// <summary>
        /// 赋值集合
        /// </summary>
        public List<string> fuzhi = new List<string>();
        /// <summary>
        /// 赋值类型
        /// </summary>
        public string fuzhileixing = string.Empty;
        /// <summary>
        /// 赋值覆盖范围
        /// </summary>
        public List<string> fuzhifanwei = new List<string>();
        /// <summary>
        /// 赋值结果，用于存放所有匹配结果
        /// </summary>
        public List<string> fuzhijieguo = new List<string>();
        /// <summary>
        /// 自定义赋值
        /// </summary>
        public string _zidingyivalue = string.Empty;
        /// <summary>
        /// 顺数标准段索引
        /// </summary>
        public int _shunshu = 0;
        /// <summary>
        /// 倒数标准段索引
        /// </summary>
        public int _daoshu = 0;
    }

    public class JiexiGuize
    {
        /// <summary>
        /// 解析规则详情集合
        /// </summary>
        public List<RuleDetail> ruleinfo = new List<RuleDetail>();
    }
}
