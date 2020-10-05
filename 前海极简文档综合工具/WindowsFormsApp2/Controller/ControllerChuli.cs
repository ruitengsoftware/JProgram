using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Controller
{
    public class ControllerChuli
    {
        public string QingkongHuanhang(string content) =>
    Regex.Replace(content, "\r\n", "");
        public string TianjiaHouzhui(string content, string houzhui)
        {
            content = content + houzhui;
            return content;
        }

        public string TianjiaQianzhui(string content, string qianzhui)
        {
            content = qianzhui + content;
            return content;
        }
        public string ZhengzeChuli(string content, string tihuanqian, string tihuanhou) =>
    Regex.Replace(content, tihuanqian, tihuanhou);
    }
}
