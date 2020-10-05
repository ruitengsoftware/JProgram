using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class BiaozhuInfo
    {
        //名称
        public string _name = string.Empty;
        //范围
        public string _region = string.Empty;
        //内容
        public string _content = string.Empty;
        //设置
        public string _style = string.Empty;
        //修改时间
        public string _updatetime = string.Empty;
    }
    public class BZMBInfo
    {
        public BZMBInfo()
        {

            _mubanname = string.Empty;
            list_biaozhu = new List<BiaozhuInfo>();
        }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string _mubanname { get; set; }
        /// <summary>
        /// 该模板包含的步骤信息
        /// </summary>
        public List<BiaozhuInfo> list_biaozhu { get; set; }
    }
}
