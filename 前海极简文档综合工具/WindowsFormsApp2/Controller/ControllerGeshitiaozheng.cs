
using Org.BouncyCastle.Asn1.TeleTrust;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.DLL;

namespace WindowsFormsApp2.Controller
{
    public class ControllerGeshitiaozheng
    {
       public MySqlHelper _sqlhelper = new MySqlHelper();
        /// <summary>
        /// 获得数据库中的总体格式
        /// </summary>
        /// <returns></returns>
        public List<string> GetFormat(string field,string shtname)
        {
           return _sqlhelper.GetSingleField(field, shtname);
        }


        //获得页码格式对应的设置dic
        public Dictionary<string, object> GetPageSet(string pagename)
        {
            //string str_sql = $"select distinct * from tablepage";
            //return _sqlhelper.GetAnySet("pagename", pagename, "tablepage")[0];
            Dictionary<string, object> mydic = new Dictionary<string, object> {
                { "pagename",pagename}
            };
            return _sqlhelper.GetAnySet("tablepage", mydic)[0];

        }
        //获得页眉或者页脚的具体设置
        public List<string> GetYemeiOrYejiao(string type)
        {
            
            //string str_sql = $"select distinct fname from tableformat where fposition='{type}'";
            return _sqlhelper.GetSingleField("fname", "tableformat");
            
        }
        //获得某一总体格式下的各级标题名称
        public Dictionary<string, object> GetGejibiaoti(string format)
        {
            Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "ttname",format}
            };
            var list = _sqlhelper.GetAnySet("tabletotalformat", mydic);
          return list[0];
            
        }






        //获得边距格式名称对应的值
        public Dictionary<string, object> GetBianjuSet(string format)
        {
            Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "name",format}
            };
            return _sqlhelper.GetAnySet("tablepagemargin",mydic)[0];
        }
        //获得页眉页脚格式下的设置
        public Dictionary<string, object> GetYemeiYejiaoSet(string format)
        {
            Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "name",format }
            };
            return _sqlhelper.GetAnySet("tableyemeiyejiao",mydic)[0];

        }
        //获得某一页眉格式下所有设置
        public Dictionary<string, object> GetYemeiSet(string format)
        {
            //string str_sql = $"select * from tableformat where fname='{format} and fposition='yemei''";
            Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "fname",format},
                { "fposition","yemei"}
            };

            return _sqlhelper.GetAnySet("tableformat",mydic)[0];

        }
        //获得某一页脚格式下所有设置
        public Dictionary<string, object> GetYejiaoSet(string format)
        {
            //string str_sql = $"select * from tableformat where fname='{format} and fposition='yemei''";
            Dictionary<string, object> mydic = new Dictionary<string, object>
            {
                { "fname",format},
                { "fposition","yejiao"}
            };

            return _sqlhelper.GetAnySet("tableformat", mydic)[0];

        }





        //删除指定格式
        public void DeleteAnyFormat(string field, string value, string tablename)
        {
            _sqlhelper.DeleteAnyFormat(field, value,tablename);
        }
        //删除调整格式得页边距的格式
        public void DeleteYemianFormat(string format)
        {
            _sqlhelper.DeleteAnyFormat("name", format, "tablepagemargin");
        }
        //保存格式调整中页边距的格式
        public void SaveYebianjuFormat(Dictionary<string, object> dic)
        {
            _sqlhelper.SaveAnyFormat(dic, "tablepagemargin");


        }



        //插入指定格式
        public void SaveFormat(Dictionary<string, object> dic)
        {
            //string str_sql = $"insert into tabletotalformat(ttname,dabiaoti,fubiaoti,zhengwen,yijibiaoti,erjibiaoti,sanjibiaoti,yemian,wordformat," +
            //    $"usedabiaoti,usefubiaoti,usezhengwen,useyijibiaoti,useerjibiaoti,usesanjibiaoti,useyemian) " +
            //    $"values(@ttname,@dabiaoti,@fubiaoti,@zhengwen,@yijibiaoti,@erjibiaoti,@sanjibiaoti,@yemian,@wordformat," +
            //    $"@usedabiaoti,@usefubiaoti,@usezhengwen,@useyijibiaoti,@useerjibiaoti,@usesanjibiaoti,@useyemian)";
            _sqlhelper.SaveAnyFormat(dic, "tabletotalformat");
        }



        //删除页眉页脚格式
        public void DeleteYemeiYejiaoFormat(string format)
        {
            _sqlhelper.DeleteAnyFormat("name", format, "tableyemeiyejiao");
        }



        //保存页眉页脚格式
        public void SaveYemeiYejiaoFormat(Dictionary<string, object> dic)
        {
            _sqlhelper.SaveAnyFormat(dic, "tableyemeiyejiao");

        }


        //删除页眉
        public void DeleteYemeiFormat(string format)
        {
            //mycmd.CommandText = $"delete from tableformat where fname='{format}' and fposition='yemei'";
            _sqlhelper.DeleteAnyFormat("fname", format, "tableformat");

        }
        //保存页眉
        public void SaveYemeiFormat(Dictionary<string, object> dic)
        {
            //string str_sql = $"insert into tableformat(fname,ftext,ffontname,fsize,fbold,fjuzhong,fposition,tableformat) " +
            //    $"values(@fname,@ftext,@ffontname,@fsize,@fbold,@fjuzhong,@fposition,@tableformat)";
            _sqlhelper.SaveAnyFormat(dic, "tableformat");

        }




        //删除页眉
        public void DeleteYejiaoFormat(string format)
        {
            //mycmd.CommandText = $"delete from tableformat where fname='{format}' and fposition='yejiao'";

            _sqlhelper.DeleteAnyFormat("fname", format, "tableformat");
        }
        //保存页眉
        public void SaveYejiaoFormat(Dictionary<string, object> dic)
        {
            //string str_sql = $"insert into tableformat(fname,ftext,ffontname,fsize,fbold,fjuzhong,fposition,tableformat) " +
            //    $"values(@fname,@ftext,@ffontname,@fsize,@fbold,@fjuzhong,@fposition,@tableformat)";
            _sqlhelper.SaveAnyFormat(dic, "tableformat");
        }
        //删除页眉
        public void DeleteYemaFormat(string format)
        {
            //string str_sql = $"delete from tablepage where pagename='{format}'";
            _sqlhelper.DeleteAnyFormat("pagename", format, "tablepage");
        }
        //保存页眉
        public void SaveYemaFormat(Dictionary<string, object> dic)
        {
            //string str_sql = $"insert into tablepage(pagename,pageformat,pagefontstyle,pagejuzhong,tablepage) " +
            //    $"values(@pagename,@pageformat,@pagefontstyle,@pagejuzhong,@tablepage)";
            _sqlhelper.SaveAnyFormat(dic, "tablepage");
        }





    }
}
