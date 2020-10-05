using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Jpara
    {
        /// <summary>
        /// 自然段类型，正文，大标题，空白等
        /// </summary>
        public string _leixing = string.Empty;
        /// <summary>
        /// 所属word文档
        /// </summary>
        public string _wendang = string.Empty;
        /// <summary>
        /// aspose.word类型的自然段
        /// </summary>
        public object _asposepara = null;
    }
}
