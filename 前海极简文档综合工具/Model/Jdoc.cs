using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Jdoc
    {
        /// <summary>
        /// 正在操作的文档路径
        /// </summary>
        public string _lujing = string.Empty;
        /// <summary>
        /// 正在操作的文档名
        /// </summary>
        public string _wendangming = string.Empty;
        /// <summary>
        /// 正在操作的文档分类
        /// </summary>
        public string _fenlei = string.Empty;
        /// <summary>
        /// 是否已经识别出大标题
        /// </summary>
        public bool _existdabiaoti = false;
        /// <summary>
        /// 是否已经识别出副标题
        /// </summary>
        public bool _existfubiaoti = false;
        /// <summary>
        /// 正在操作word的所有自然段
        /// </summary>
        public List<Jpara> _jparacollection = new List<Jpara>();
    }
}
