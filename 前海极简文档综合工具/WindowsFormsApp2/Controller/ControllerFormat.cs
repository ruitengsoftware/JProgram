
using Spire.Email.Outlook;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.DLL;

namespace WindowsFormsApp2.Controller
{
    public class ControllerFormat
    {
        //获得所有的format格式名称

        public List<string> GetFormatName(string field, string shtname)
        {
            var list = _sqlhelper.GetSingleField(field, shtname);
            return list;
        }

        //获得某个格式下所有的设置值
        public Dictionary<string, object> GetSet(string format)
        {
            var list = _sqlhelper.GetAnySet("muban", new Dictionary<string, object> { { "name", format } });
            return list[0];
        }
        MySqlHelper _sqlhelper = new MySqlHelper();

        //删除格式

        public void DeleteFormat(string format)
        {
            _sqlhelper.DeleteAnyFormat("name", format, "muban");
        }
        //保存格式
        public void SaveFormat(Dictionary<string, object> dic)
        {
            _sqlhelper.SaveAnyFormat(dic, "muban");
        }


    }
}
