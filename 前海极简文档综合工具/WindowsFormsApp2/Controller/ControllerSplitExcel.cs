using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.DLL;

namespace WindowsFormsApp2.Controller
{
    public class ControllerSplitExcel
    {
       public DLL.MySqlHelper _sqlhelper = new DLL.MySqlHelper();
        /// <summary>
        /// 获得数据库中的总体格式
        /// </summary>
        /// <returns></returns>
        public List<string> GetFormat(string field, string shtname)
        {

            return _sqlhelper.GetSingleField(field, shtname);
        }
        public void DeleteFormat(string field,string value,string tablename)
        {
            
        }

        /// <summary>
        /// 保存格式
        /// </summary>
        /// <param name="format"></param>
        public void SaveFormat(List<Dictionary<string, object>> list_dic)
        {
            string format = list_dic[0]["totalname"].ToString();
            DeleteFormat("totalname", format, "tablesplit");
            for (int i = 0; i < list_dic.Count; i++)
            {
                var dic = list_dic[i];
                _sqlhelper.SaveAnyFormat(dic, "tablesplit");
            }
        }



        //获得调整格式对应的设置
        public Dictionary<string, object> GetTiaozhengGeshiSet(string format)
        {
            //string str_sql = $"select * from tableformat where fname='{format} and fposition='yemei''";
            Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "ttname",format},
            };

            return _sqlhelper.GetAnySet("tableformat", mydic)[0];
        }

        internal void SaveYemei(Dictionary<string,object> dic,string tablename)
        {
            _sqlhelper.SaveAnyFormat(dic, tablename);
        }
    }
}
