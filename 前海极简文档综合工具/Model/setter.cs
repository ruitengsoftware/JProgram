using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class setter
    {
        /// <summary>
        /// 空行
        /// </summary>
        public int konghang = 0;
        /// <summary>
        /// 文件名字段集合
        /// </summary>
        public List<string> namefields = new List<string>();
        /// <summary>
        /// 行距类型
        /// </summary>
        public string hangjustyle = string.Empty;
        /// <summary>
        /// 行距固定值
        /// </summary>
        public Single hangjuvalue = 0;
        /// <summary>
        /// 字体名称
        /// </summary>
        public string fontname = string.Empty;
        /// <summary>
        /// 字体大小
        /// </summary>
        public Single fontsize = 0;
        /// <summary>
        /// 居中
        /// </summary>
        public string juzhong = string.Empty;
        /// <summary>
        /// 缩进
        /// </summary>
        public Single suojin = 0;
        /// <summary>
        /// 粗体
        /// </summary>
        public int bold =0;
    }
}
