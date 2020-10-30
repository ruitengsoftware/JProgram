using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文本解析系统.JJModel
{
   public class RuleInfo
    {
        /// <summary>
        /// 规则名称
        /// </summary>

        public string _guizemingcheng = string.Empty;
        /// <summary>
        /// 规则说明
        /// </summary>
        public string _guizeshuoming = string.Empty;
        /// <summary>
        /// 创建人
        /// </summary>
        public string _chuangjianren = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        public string _chuangjianshijian = string.Empty;
        /// <summary>
        /// 文本特征集合,包含多个规则详情的ruledetail集合
        /// </summary>
        public string _wenbentezheng = string.Empty;


    }
}
