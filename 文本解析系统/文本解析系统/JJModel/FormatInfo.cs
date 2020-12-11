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
        /// <summary>
        /// 新Md5值
        /// </summary>
        public bool _newmd5 = false;
        /// <summary>
        /// 查重处理“无”选项
        /// </summary>
        public bool _wu2 = false;
        /// <summary>
        /// 查重MD5值
        /// </summary>
        public bool _chachongmd5 = false;
        /// <summary>
        /// 全文库
        /// </summary>
        public string _quanwenku = string.Empty;
        /// <summary>
        /// 正文库
        /// </summary>
        public string _zhengwenku = string.Empty;
        /// <summary>
        /// 标准段库
        /// </summary>
        public string _biaozhunduanku = string.Empty;
        /// <summary>
        /// 标准句库
        /// </summary>
        public string _biaozhunjuku = string.Empty; 





    }
}
