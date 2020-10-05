using RuiTengDll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.WinForm;
using System.Windows.Forms;
using WindowsFormsApp1.Common;
using WindowsFormsApp1.Controller;
using ClickHouse.Ado;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.WinForm;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Controller
{
    public class ControllerShujuku
    {
        SqliteHelper mysqliter = null;
        public static string _newtablename = string.Empty;
        OfficeHelper officehelper = new OfficeHelper();
        ClickHouseConnection _mycon = null;
        string mysql_constr = $"server={Properties.Settings.Default._ip};port=3306;user=root;password=111111; database=qianhai;";
        MySqlConnection mysql = null;

        public ControllerShujuku()
        {
            

            mysql = new MySqlConnection(mysql_constr);
            mysql.Open();

        }
        Dictionary<string, string> dic_pinyin = new Dictionary<string, string>() {
            { "shijian","时间" },
            {"bianhao","编号" },
            {"laiyuan","来源" } ,
            {"zhengwenneirong","正文内容" },
            {"zhuanzailiang","转载量" },
            {"riqi","日期" },
            {"xuhao","序号" },
            {"geshimingcheng","格式名称" },
            {"zhengwenchachong","正文查重" },
            {"shanchu100","删除100" },
            {"zhengwenchachongbiao","正文查重表" },
            {"zhengwenruku","正文入库" },
            {"zhengwenrukubiao","正文入库表" },
            {"rizhilujing","日志路径" },
            {"shujukushai","数据库筛" },
        };


        /// <summary>
        /// 将dgv的表头拼音转换成中文
        /// </summary>
        /// <param name="dgv"></param>
        public void ConvertToZhongwen(DataGridView dgv)
        {
            //foreach (DataGridViewColumn item in dgv.Columns)
            //{
            //    item.HeaderText = dic_pinyin[item.Name];
            //}

        }

        public void AddXuhao(DataTable mydt)
        {
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                mydt.Rows[i]["序号"] = i + 1;
                string str_b = mydt.Rows[i]["正文内容"].ToString();
                string str = Byte2String(str_b);
                mydt.Rows[i]["正文内容"] = str;
            }
        }

        /// <summary>
        /// 将二进制转成字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Byte2String(string s)
        {
            System.Text.RegularExpressions.CaptureCollection cs =
                System.Text.RegularExpressions.Regex.Match(s, @"([01]{8})+").Groups[1].Captures;
            byte[] data = new byte[cs.Count];
            for (int i = 0; i < cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value, 2);
            }
            return Encoding.Unicode.GetString(data, 0, data.Length);
        }

        /// <summary>
        /// 获得数据表名
        /// </summary>
        /// <returns></returns>
        public string[] GetTablesName()
        {
            List<string> listtablename = new List<string>();

            string str_sql = "select table_name from innodb_table_stats where database_name='qianhai'";
            MySqlConnection mysql = new MySqlConnection(mysql_constr);
            mysql.Open();
            mysql.ChangeDatabase("mysql");
            MySqlCommand mycmd = new MySqlCommand(str_sql, mysql);
            var myreader = mycmd.ExecuteReader();
            while (myreader.Read())
            {
                listtablename.Add(myreader.GetString(0));

            }
            myreader.Close();
            mycmd.Dispose();
            mysql.Close();
            mysql.Dispose();
            return listtablename.ToArray();
        }

        /// <summary>
        /// 查询数据到datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<ZhengwenInfo> GetDataFromTable(string str_sql)
        {
            List<ZhengwenInfo> list = new List<ZhengwenInfo>();
            try
            {
            mysql.ChangeDatabase("qianhai");
            MySqlCommand mycmd = new MySqlCommand(str_sql, mysql);
            var myreader = mycmd.ExecuteReader();
            while (myreader.Read())
            {

                ZhengwenInfo zwinfo = new ZhengwenInfo()
                {
                    _xuhao = myreader.GetString(0),
                    _bianhao = myreader.GetString(1),
                    _laiyuan = myreader.GetString(2),
                    _zhuanzailiang = myreader.GetString(3),
                    _zhengwenneirong = myreader.GetString(4),
                    _shijian = myreader.GetString(5),
                    _riqi = myreader.GetString(6),
                };


                list.Add(zwinfo);
            }
            myreader.Close();

            }
            catch { }
            return list;
        }


        /// <summary>
        /// 该方法用于添加新数据库
        /// </summary>
        public void AddDatabase()
        {
            WinFormAddDatabase mywinform = new WinForm.WinFormAddDatabase();
            mywinform.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            if (mywinform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string tablename = mywinform.tablename;
                //string leixing = mywinform.leixing;
                //if (leixing.Equals("标准句"))
                //{
                //    string str_sql = $"CREATE TABLE {tablename}(序号,编号,时间,来源,内容,转载量)";
                //    string str_sqlindex = $"CREATE INDEX bianmaindex ON {tablename} (编号)";
                //    mysqliter.ExecuteRow(str_sql, null, null);
                //    System.Windows.Forms.MessageBox.Show($"数据表 {tablename} 已成功添加!");

                //}
                //else if ((leixing.Equals("标准正文")))
                //{
                //    string str_sql = $"CREATE TABLE {tablename}(序号,编号,日期,来源,转载量,正文内容)";
                //    mysqliter.ExecuteRow(str_sql, null, null);
                //    System.Windows.Forms.MessageBox.Show($"数据表 {tablename} 已成功添加!");
                //}
                string str_sql = $"CREATE TABLE {tablename}(xuhao UInt8,bianhao String,laiyuan String,zhuanzailiang UInt16,zhengwenneirong BLOB,shijian String,riqi Date) " +
                                       $"ENGINE MergeTree() " +
                                       $"PARTITION BY riqi " +
                                       $"ORDER BY xuhao ";



                str_sql = $"CREATE TABLE {tablename} (序号 INT, 编号 VARCHAR(100),来源 TEXT,转载量 INT," +
                    $"正文内容 TEXT,时间 Date" +
                    $") ENGINE=InnoDB DEFAULT CHARSET=utf8";
                //$"PRIMARY KEY bianhao";
                MySqlConnection mysql = new MySqlConnection(mysql_constr);
                mysql.Open();
                var mycmd = mysql.CreateCommand();

                mycmd.CommandText = str_sql;
                mycmd.ExecuteNonQuery();
                mycmd.Dispose();
                mysql.Close();
                mysql.Dispose();
                //_mycon.CreateCommand(str_sql).ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show($"数据表 {tablename} 已成功添加!");


            }
        }
        /// <summary>
        /// 该方法用于编辑数据库
        /// </summary>
        public void EditDatabase(string table0)
        {
            WinFromEditTable myform = new WinFromEditTable(table0);
            if (myform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string table1 = myform.table1;
                Setting._currentdb = table1;
                string str_sql = $"rename table {table0} TO {table1}";
                _mycon.CreateCommand(str_sql).ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show($"数据表 {table1} 改名已成功!");
            }
        }

        /// <summary>
        /// 该方法用于删除数据库,实际上是删除数据表
        /// </summary>
        public void DeleteDatabase(string tablename)
        {
            string str_sql = $"drop table {tablename}";
            MySqlConnection mysql = new MySqlConnection(mysql_constr);
            mysql.Open();
            var mycmd = mysql.CreateCommand();
            mycmd.CommandText = str_sql;
            mycmd.ExecuteNonQuery();
            mycmd.Dispose();
            mysql.Close();
            mysql.Dispose();
            // _mycon.CreateCommand(str_sql).ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show($"数据表 {tablename} 已成功删除!");


        }


        /// <summary>
        /// 将list集合转化成datatable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public DataTable List2DataTable(List<ZhengwenInfo> list)
        {
            DataTable mydt = new DataTable();
            mydt.Columns.Add("序号");
            mydt.Columns.Add("编号");
            mydt.Columns.Add("来源");
            mydt.Columns.Add("转载量");
            mydt.Columns.Add("正文内容");
            mydt.Columns.Add("时间");
            // mydt.Columns.Add("日期");
            DataRow dr = null;
            for (int i = 0; i < list.Count; i++)
            {
                dr = mydt.Rows.Add();
                dr["序号"] = list[i]._xuhao;
                dr["编号"] = list[i]._bianhao;
                dr["来源"] = list[i]._laiyuan;
                dr["转载量"] = list[i]._zhuanzailiang;
                dr["正文内容"] = list[i]._zhengwenneirong;
                dr["时间"] = list[i]._shijian;
                // dr["日期"] = list[i]._riqi;
            }
            return mydt;



        }


        /// <summary>
        /// 根据页数获得当页数据
        /// </summary>
        /// <param name="yeshu"></param>
        /// <param name="offset"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public List<ZhengwenInfo> GetDTByPage(string yeshu, int offset, string tablename)
        {



            List<ZhengwenInfo> list = new List<ZhengwenInfo>();
            if (tablename.Equals("tablesetting") || tablename.Equals("zhengwensetting"))
            {
                return list;
            }
            //分解出当前页和总页数
            int page = 0;
            int pagenum = 0;
            page = Convert.ToInt32(yeshu.Split(new char[] { '/' })[0]);
            pagenum = Convert.ToInt32(yeshu.Split(new char[] { '/' })[1]);
            string str_sql = $"select * from {tablename} order by 时间 desc limit {(page - 1) * offset},{offset}";
            MySqlConnection mysql = new MySqlConnection(mysql_constr);
            mysql.Open();
            mysql.ChangeDatabase("qianhai");
            MySqlCommand mycmd = new MySqlCommand(str_sql, mysql);
            var myreader = mycmd.ExecuteReader();
            try
            {
            while (myreader.Read())
            {
                ZhengwenInfo zwinfo = new ZhengwenInfo()
                {
                    _xuhao = myreader.GetString(0),
                    _bianhao = myreader.GetString(1),
                    _laiyuan = myreader.GetString(2),
                    _zhuanzailiang = myreader.GetString(3),
                    _zhengwenneirong = myreader.GetString(4),
                    _shijian = myreader.GetString(5),
                    _riqi = myreader.GetString(6),
                };
                list.Add(zwinfo);

            }

            }
            catch { }
            myreader.Close();
            mycmd.Dispose();
            mycmd.Clone();
            mysql.Dispose();
            //CommonMethod.AddXuhao(mydt);
            return list;
        }


        /// <summary>
        /// 将dt中得数据插入到数据表中去，插入时需要比较编号，如果编号相同，需要更新最大转载量和最早时间
        ////如果编号不存在那么插入一整条数据即可
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tablename"></param>
        public void InsertDT2DB(DataTable dt, string tablename)
        {
            //判断是否包含转载量，从而判断是否为正文表或者标准句表
            List<string> list_head = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                list_head.Add(dt.Columns[i].ColumnName);
            }
            if (list_head.Contains("转载量"))//判断事标准句表
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string bianhao = dt.Rows[i]["编号"].ToString();
                    //判断编号是否存在与数据库中
                    string str_sql = $"select * from {tablename} where 编号='{bianhao}'";
                    List<object> list_o = mysqliter.ExecuteRow(str_sql, null, null);
                    if (list_o.Count > 0)
                    {
                        //获得表中得转载量和时间
                        string str_sql2 = $"select 转载量,时间 from {tablename} where 编号='{bianhao}'";
                        List<object> list_o2 = mysqliter.ExecuteRow(str_sql2, null, null);
                        Dictionary<string, object> dic2 = list_o2[0] as Dictionary<string, object>;
                        var redu1 = dic2["转载量"].ToString();
                        var shijian1 = dic2["时间"].ToString();
                        //获得导入表中的转载量和时间
                        var redu2 = dt.Rows[i]["转载量"].ToString();
                        var shijian2 = dt.Rows[i]["时间"].ToString();
                        //转载量选择最大值，时间选择早值
                        int redumax = Math.Max(Convert.ToInt32(redu1), Convert.ToInt32(redu2));

                        DateTime shijianold = Convert.ToDateTime(shijian1) > Convert.ToDateTime(shijian2) ? Convert.ToDateTime(shijian2) : Convert.ToDateTime(shijian1);
                        //构造dic
                        Dictionary<string, object> dic3 = new Dictionary<string, object>() {
                        {"转载量",redumax },
                        {"时间", shijianold}
                   };
                        //update数据
                        mysqliter.Update(tablename, dic3, $"编号='{bianhao}'");
                    }
                    else
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>() { };
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            dic.Add(dt.Columns[j].ColumnName, dt.Rows[i][j]);
                        }
                        mysqliter.Save(tablename, dic);
                    }
                }

            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string bianhao = dt.Rows[i]["编号"].ToString();
                    //判断编号是否存在与数据库中
                    string str_sql = $"select * from {tablename} where 编号='{bianhao}'";
                    List<object> list_o = mysqliter.ExecuteRow(str_sql, null, null);
                    if (list_o.Count == 0)
                    {

                        Dictionary<string, object> dic = new Dictionary<string, object>() { };
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            dic.Add(dt.Columns[j].ColumnName, dt.Rows[i][j]);
                        }
                        mysqliter.Save(tablename, dic);
                    }
                }
            }

        }

        /// <summary>
        /// 从数据库中删除指定编号的记录
        /// </summary>
        /// <param name="bianhao">记录编号</param>
        public void DeleteZhengwen(string tablename, string bianhao)
        {
            mysqliter.Delete(tablename, $"编号='{bianhao}'");
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="list_fields">字段集合</param>
        /// <param name="str">搜索词</param>
        /// <param name="shtname">数据表名</param>
        /// <returns></returns>
        public List<ZhengwenInfo> MohuChaxun(List<string> list_fields, string str, string shtname)
        {
            List<ZhengwenInfo> list = new List<ZhengwenInfo>();
            List<string> list_where = new List<string>();
            foreach (var item in list_fields)
            {
                list_where.Add($"{item} like '%{str}%'");
            }
            string sql_where = string.Join(" or ", list_where);
            DataTable mydt = new DataTable();

            //获得该表下数据datatable 
            string str_sql = $"select * from {shtname} where ({sql_where}) order by riqi desc limit 100";
            if (str.Trim().Equals(string.Empty))
            {
                str_sql = $"select * from {shtname} order by riqi desc limit 100";
            }
            var myreader = _mycon.CreateCommand(str_sql).ExecuteReader();
            do
            {
                try
                {
                    while (myreader.Read())
                    {
                        ZhengwenInfo zwinfo = new ZhengwenInfo()
                        {
                            _xuhao = myreader.GetString(0),
                            _bianhao = myreader.GetString(1),
                            _laiyuan = myreader.GetString(2),
                            _zhuanzailiang = myreader.GetString(3),
                            _zhengwenneirong = myreader.GetString(4),
                            _shijian = myreader.GetString(5),
                            _riqi = myreader.GetString(6),
                        };
                        list.Add(zwinfo);
                    }
                }
                catch { }

            } while (myreader.NextResult());


            return list;
        }


        /// <summary>
        /// 拆分保存datatable
        /// </summary>
        public void SaveDtSplit(DataTable dt, int num, string dbfilename)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string dir = fbd.SelectedPath;

                for (int i = 0; i < dt.Rows.Count; i += num)
                {
                    int end = i + num;//存放文件名中最后记录的行数
                                      //判断i+num是否大于dt.rows.count
                    if (end > dt.Rows.Count)
                    {
                        end = dt.Rows.Count;
                    }
                    string filename = $"{dir}\\{dbfilename}({i + 1}-{end})-{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                    officehelper.SaveDTRegion2Excel(dt, filename, ".xlsx", i, i + num);
                }
                MessageBox.Show("数据已保存为Excel表格！");

            }
        }

    }
}
