using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Format
    {

        /// <summary>
        /// 该格式是否可用
        /// </summary>
        public bool enable = true;

        /// <summary>
        /// 格式名称，唯一
        /// </summary>
        public string formatname = string.Empty;
        /// <summary>
        /// 字体名称
        /// </summary>
        public string fontname = string.Empty;
        /// <summary>
        /// 字体大小
        /// </summary>
        public float fontsize = 0;
        /// <summary>
        /// 行距类型
        /// </summary>
        //public WdLineSpacing linespacestyle = new WdLineSpacing();
        public string lstype = string.Empty;
        /// <summary>
        /// 空行
        /// </summary>
        public int space = 0;
        /// <summary>
        /// 设置行距为固定值类型
        /// </summary>
        public float lsvalue = 0;
        /// <summary>
        /// 设置首行缩进值
        /// </summary>
        public float suojin = 0;
        /// <summary>
        /// 设置文本加粗
        /// </summary>
        public int bold = 0;
        /// <summary>
        /// 设置文本居中样式
        /// </summary>
        public string juzhong = string.Empty;


    }
}
