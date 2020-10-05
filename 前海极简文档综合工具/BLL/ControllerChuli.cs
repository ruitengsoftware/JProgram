using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
   public class ControllerChuli
    {

        //正则表达式替换,以及文本替换
        public string ZhengzeChuli(string content, string tihuanqian, string tihuanhou)
        {
            string str_result = Regex.Replace(content, tihuanqian, tihuanhou);
            return str_result;
        }
        //添加前缀
        public string TianjiaQianzhui(string content, string qianzhui)
        {
            content = qianzhui + content;
            return content;

        }

        //添加后缀
        public string TianjiaHouzhui(string content, string houzhui)
        {
            content = content+houzhui;
            return content;

        }



        //清空换行符
        public string QingkongHuanhang(string content)
        {
            string str_result = Regex.Replace(content, "\r\n", "");
            return str_result;
        }
    }
}
