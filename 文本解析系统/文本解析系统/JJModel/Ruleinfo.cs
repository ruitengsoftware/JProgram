using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文本解析系统.JJModel
{
    public class Ruleinfo
    {
        /// <summary>
        /// 对象选择
        /// </summary>
        public string duixiangxuanze { get; set; }
        /// <summary>
        /// 文本特征
        /// </summary>
        public string wenbentezheng { get; set; }
        /// <summary>
        /// 文本特征结果
        /// </summary>
        public string wenbentezhengjieguo { get; set; }
        /// <summary>
        /// 赋值类型
        /// </summary>
        public string fuzhileixing { get; set; }
    }

    public class JiexiGuize
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Ruleinfo> ruleinfo = new List<Ruleinfo>();
    }
}
