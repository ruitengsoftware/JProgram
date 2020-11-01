using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文本解析系统.JJModel
{
    public class FormatInfo
    {
        /// <summary>
        /// 格式名称
        /// </summary>
        public string _formatname = string.Empty;
        /// <summary>
        /// 查重处理的设置，无，全文，正文，插入新MD5
        /// </summary>
        public string _chachongchuli = string.Empty;
        /// <summary>
        /// excel文件位置，如果为空，则为默认位置 
        /// </summary>
        public string _excelpath = string.Empty;
        /// <summary>
        /// 解析规则集合
        /// </summary>
        public List<string> list_jiexiguize = new List<string>();


    }
}
