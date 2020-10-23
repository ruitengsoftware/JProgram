using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.DLL
{
    public class MySqlHelper
    {

        MySqlConnection _mycon = new MySqlConnection();
        string str_con = $"server=49.233.40.109;port=3306;user=root;password=111111; database=documenttools;";
        public MySqlHelper()
        {

            _mycon.ConnectionString = str_con;

        }

        public DataSet GetDataSet(string field,string tablename, params Dictionary<string, object>[] tiaojian)
        {
            _mycon.Open();
            string strsql = $"select {field} from {tablename}";

            if (tiaojian.Length != 0)
            {
                strsql += $" where ";
                List<string> mylist = new List<string>();
                var dic = tiaojian[0];
                foreach (KeyValuePair<string, object> keyValue in dic)
                {
                    mylist.Add($"{keyValue.Key}='{keyValue.Value}'");
                }
                strsql += string.Join(" and ", mylist);
            }

            MySqlDataAdapter myadap = new MySqlDataAdapter(strsql, _mycon);
            DataSet myset = new DataSet();
            myadap.Fill(myset);
            _mycon.Close();
            return myset;
        }


        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="strsql"></param>
        public void ExecuteSql(string strsql)
        {
            _mycon.Open();
            MySqlCommand mycmd = new MySqlCommand();
            mycmd.CommandText = strsql;
            mycmd.Connection = _mycon;
            _mycon.Close();


        }


        public void ChangeDatabase(string str) => _mycon.ChangeDatabase(str);

        /// <summary>
        /// 返回str_sql语句执行结果中指定的字段所有结果list
        /// </summary>
        /// <param name="fieldname"></param>
        /// <param name="tablename"></param>
        /// <param name="tiaojian"></param>
        /// <returns></returns>
        public List<string> GetSingleField(string fieldname, string tablename,params Dictionary<string,object>[]  tiaojian)
        {
            List<string> list = new List<string>();
            _mycon.Open();
            MySqlCommand mycmd = new MySqlCommand();
            string strsql= $"select distinct {fieldname} from {tablename}";
           
            if (tiaojian.Length!=0)
            {
                strsql += $" where ";
                List<string> mylist = new List<string>();
                var dic = tiaojian[0];
                foreach (KeyValuePair<string,object> keyValue  in dic)
                {
                    mylist.Add($"{keyValue.Key}='{keyValue.Value}'"); 
                }
                strsql += string.Join(" and ", mylist);
            }
            mycmd.CommandText = strsql;
            mycmd.Connection = _mycon;
            MySqlDataReader myreader = mycmd.ExecuteReader();
            while (myreader.Read())
            {
                list.Add(myreader[fieldname].ToString());
            }
            myreader.Close();
            myreader.Dispose();
            _mycon.Close();
            return list;
        }




        /// <summary>
        ///获得一个指定格式名称的所有设置，存为dic
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetFormatSet(string str_sql)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            _mycon.Open();
            MySqlCommand mycmd = new MySqlCommand();
            mycmd.CommandText = str_sql;
            mycmd.Connection = _mycon;
            MySqlDataReader myreader = mycmd.ExecuteReader();
            while (myreader.Read())
            {
                dic.Add("dabiaoti", myreader["dabiaoti"]);
                dic.Add("usedabiaoti", myreader["usedabiaoti"]);
                dic.Add("fubiaoti", myreader["fubiaoti"]);
                dic.Add("usefubiaoti", myreader["usefubiaoti"]);
                dic.Add("zhengwen", myreader["zhengwen"]);
                dic.Add("usezhengwen", myreader["usezhengwen"]);
                dic.Add("yijibiaoti", myreader["yijibiaoti"]);
                dic.Add("useyijibiaoti", myreader["useyijibiaoti"]);
                dic.Add("erjibiaoti", myreader["erjibiaoti"]);
                dic.Add("useerjibiaoti", myreader["useerjibiaoti"]);
                dic.Add("sanjibiaoti", myreader["sanjibiaoti"]);
                dic.Add("usesanjibiaoti", myreader["usesanjibiaoti"]);
                dic.Add("useyemian", myreader["useyemian"]);
                dic.Add("useyema", myreader["useyema"]);
                dic.Add("useyemei", myreader["useyemei"]);
                dic.Add("useyejiao", myreader["useyejiao"]);
            }
            myreader.Close();
            myreader.Dispose();
            _mycon.Close();
            return dic;
        }

        /// <summary>
        /// 从数据库中删除指定格式的记录
        /// </summary>
        /// <param name="format"></param>
        /// <param name="tablename"></param>
        public void Delete(string format, string tablename)
        {
            string str_sql = $"delete from {tablename} where ttname='{format}'";
            _mycon.Open();
            MySqlCommand mycmd = new MySqlCommand();
            mycmd.CommandText = str_sql;
            mycmd.Connection = _mycon;
            mycmd.ExecuteNonQuery();
            mycmd.Dispose();
            _mycon.Close();
        }
        /// <summary>
        /// 插入新的格式名称以及设置
        /// </summary>
        /// <param name="dic"></param>
        public void SaveAnyFormat(Dictionary<string, object> dic, string tablename)
        {
           // Delete(dic["ttname"].ToString(), "tabletotalformat");
            _mycon.Open();
            MySqlCommand mycmd = new MySqlCommand();

            //构造insert语句和values语句
            List<string> list_p = new List<string>();
            
            foreach (var item in dic.Keys.ToList())
            {
                list_p.Add($"@{item}");
                mycmd.Parameters.AddWithValue($"@{item}", dic[item]);
            }
            string _str_insert = $"insert into {tablename}({string.Join(",", dic.Keys.ToList())})" +
                $" values({string.Join(",", list_p)})";

            mycmd.Connection = _mycon;
            mycmd.CommandText = _str_insert;
            mycmd.ExecuteNonQuery();
            _mycon.Close();


        }
        /// <summary>
        /// 删除指定得格式
        /// </summary>
        /// <param name="field">格式字段名</param>
        /// <param name="value">格式值</param>
        /// <param name="tablename">数据表名</param>
        public void DeleteAnyFormat(string field, string value, string tablename)
        {
            _mycon.Open();
            string str_sql = $"delete from {tablename} where {field}='{value}'";
            MySqlCommand mycmd = new MySqlCommand();
            mycmd.Connection = _mycon;
            mycmd.CommandText = str_sql;
            mycmd.ExecuteNonQuery();
            _mycon.Close();
        }
        /// <summary>
        /// 获得指定格式的设置，以字典形式返回
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetAnySet(string tablename, params Dictionary<string,object>[] tiaojian)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            _mycon.Open();
            string strsql = $"select * from {tablename}";
            if (tiaojian.Length != 0)
            {
                strsql += $" where ";
                List<string> mylist = new List<string>();
                var dic = tiaojian[0];
                foreach (KeyValuePair<string, object> keyValue in dic)
                {
                    mylist.Add($"{keyValue.Key}='{keyValue.Value}'");
                }
                strsql += string.Join(" and ", mylist);
            }

            MySqlCommand mycmd = new MySqlCommand();
            mycmd.Connection = _mycon;
            mycmd.CommandText = strsql;
            MySqlDataReader myreader = mycmd.ExecuteReader();
            while (myreader.Read())
            {
                result = new Dictionary<string, object>();
                for (int i = 0; i < myreader.FieldCount; i++)
                {
                    result.Add(myreader.GetName(i), myreader[i]);
                }
                list.Add(result);
            }
            myreader.Close();
            myreader.Dispose();
            _mycon.Close();
            return list;
        }






        /// <summary>
        /// 从excel数据库提取数据
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public System.Data.DataTable ExcelToDS(string excelPath, string sqlstr)

        {
            DataSet ds = null;

            System.Data.DataTable dt = null;

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + excelPath + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            strExcel = sqlstr;//这里sheet1对应excel的工作表名称，一定要注意。
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            dt = ds.Tables[0];
            conn.Close();
            return dt;
        }

    }
}
