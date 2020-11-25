﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文本解析系统.JJModel
{
    public class RuleDetail
    {
        /// <summary>
        /// 对象选择
        /// </summary>
        public string duixiangxuanze { get; set; }
        /// <summary>
        /// 文本特征(正则表达式)
        /// </summary>
        public string wenbentezheng { get; set; }
        /// <summary>
        /// 赋值
        /// </summary>
        public string fuzhi { get; set; }
        /// <summary>
        /// 赋值类型
        /// </summary>
        public string fuzhileixing { get; set; }
        /// <summary>
        /// 赋值覆盖范围
        /// </summary>
        public List<string> fanwei = new List<string>();
        /// <summary>
        /// 赋值结果，用于存放所有匹配结果
        /// </summary>
        public List<string> fuzhijieguo = new List<string>();
    }

    public class JiexiGuize
    {
        /// <summary>
        /// 解析规则详情集合
        /// </summary>
        public List<RuleDetail> ruleinfo = new List<RuleDetail>();
    }
}
