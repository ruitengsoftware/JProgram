using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.JJModel
{
    public class JJchengguoInfo
    {
        /// <summary>
        /// 关键成果
        /// </summary>
        public string _guanjianchengguo { get; set; }
        /// <summary>
        /// 责任人
        /// </summary>
        public string _zerenren { get; set; }
        /// <summary>
        /// 验收人
        /// </summary>
        public string _yanshouren { get; set; }
        /// <summary>
        /// 时限
        /// </summary>
        public string _shixian { get; set; }
        /// <summary>
        /// 进展情况
        /// </summary>
        public string _jinzhanqingkuang { get; set; }
    }

    public class JJchengguoji
    {
        /// <summary>
        /// 
        /// </summary>
        public List<JJchengguoInfo> _list_chengguo { get; set; }
    }
}