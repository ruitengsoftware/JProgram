using ClickHouse.Ado;
using ClickHouse.Net;
using Common;
using Common.WinForm;
using RuiTengDll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Controller
{
    public class ControllerClickhouse
    {

        ClickHouseDatabase mydb = null;
        public static string _newtablename = string.Empty;
        OfficeHelper officehelper = new OfficeHelper();
        string str_connectionn = "Compress=True;Host=119.45.47.2;Port=9000;User=default;Password=;Database=default;";

        public ControllerClickhouse()
        {
            string dbfile = $"{Environment.CurrentDirectory}\\ruitengdb.db";
            mydb = new ClickHouseDatabase(
               new ClickHouseConnectionSettings(str_connectionn),
               new ClickHouseCommandFormatter(),
               new ClickHouseConnectionFactory(),
               null,
               new DefaultPropertyBinder());
            mydb.Open();
        }
        /// <summary>
        /// 获得默认库中所有的表名
        /// </summary>
        /// <returns></returns>
        public List<string> GetTablesName()
        {
            mydb.ChangeDatabase("system");
            string dbfile = "select name from tables where database='default'";
            var dt = GetDataFromTable(dbfile);
            List<string> listtablename = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tablename = dt.Rows[i]["name"].ToString();
                if (!listtablename.Contains(tablename))
                {
                    listtablename.Add(dt.Rows[i]["name"].ToString());
                }
            }
            return listtablename;
        }
        /// <summary>
        /// 获得所有格式名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetFormatsName()
        {
            mydb.ChangeDatabase("default");
            string dbfile = "select geshimingcheng from tablesetting";
            var dt = GetDataFromTable(dbfile);
            List<string> listtablename = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tablename = dt.Rows[i]["geshimingcheng"].ToString();
                if (!listtablename.Contains(tablename))
                {
                    listtablename.Add(dt.Rows[i]["geshimingcheng"].ToString());
                }
            }
            return listtablename;

        }

        /// <summary>
        /// 查询数据到datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataFromTable(string sql)
        {
           
            DataTable mydt = new DataTable();
            var kk = mydb.ExecuteSelectCommand(sql, true);

            for (int i = 0; i < kk[0].Length; i++)
            {
                mydt.Columns.Add(kk[0][i].ToString());
            }
            DataRow dr = null;
            for (int i = 1; i < kk.Length; i++)
            {
                dr = mydt.Rows.Add();
                for (int j = 0; j < kk[i].Length; j++)
                {
                    dr[j] = kk[i][j];
                }
                //mydt.ImportRow(dr);
            }
            return mydt;
        }


        public void DoSQL(string str_sql)
        {
            
            mydb.ExecuteNonQuery(str_sql);

        }


        public void SelectDB(string dbname)
        {
            mydb.ChangeDatabase(dbname);
        }
        /// <summary>
        /// 该方法用于添加新数据库
        /// </summary>
        public void AddDatabase()
        {

            WinFormAddDatabase mywinform = new Common.WinForm.WinFormAddDatabase();
            mywinform.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            if (mywinform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string tablename = mywinform.tablename;
                string leixing = mywinform.leixing;
                if (leixing.Equals("标准句"))
                {
                    string str_sql = $"CREATE TABLE {tablename}(xuhao UInt8,bianhao String,shijian Date,laiyuan String,neirong String,redu UInt16) " +
                                     $"ENGINE MergeTree() " +
                                     $"PARTITION BY shijian " +
                                     $"ORDER BY xuhao ";

                    mydb.ExecuteNonQuery(str_sql);
                    System.Windows.Forms.MessageBox.Show($"数据表 {tablename} 已成功添加!");

                }
                else if ((leixing.Equals("标准正文")))
                {
                    string str_sql = $"CREATE TABLE {tablename}(xuhao UInt8,bianhao String,shijian Date,laiyuan String,zhengwenneirong String) " +
                                       $"ENGINE MergeTree() " +
                                       $"PARTITION BY shijian " + 
                                       $"ORDER BY xuhao ";
                    //$"PRIMARY KEY bianhao";

                    mydb.Open();
                    mydb.ExecuteNonQuery(str_sql);
                    System.Windows.Forms.MessageBox.Show($"数据表 {tablename} 已成功添加!");

                }
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
                mydb.ExecuteNonQuery(str_sql);
                System.Windows.Forms.MessageBox.Show($"数据表 {table1} 改名已成功!");
            }
        }
        /// <summary>
        /// 该方法用于删除数据库,实际上是删除数据表
        /// </summary>
        public void DeleteDatabase(string tablename)
        {
            string str_sql = $"drop table {tablename}";
            mydb.ExecuteNonQuery(str_sql);
            System.Windows.Forms.MessageBox.Show($"数据表 {tablename} 已成功删除!");
        }




        //将dt中得数据插入到数据表中去，插入时需要比较编号，如果编号相同，需要更新最大热度和最早时间
        //如果编号不存在那么插入一整条数据即可
        public void InsertDT2DB(DataTable dt, string tablename)
        {
            //判断是否包含热度，从而判断是否为正文表或者标准句表
            List<string> list_head = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                list_head.Add(dt.Columns[i].ColumnName);
            }
            if (list_head.Contains("redu"))//判断事标准句表
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string bianhao = dt.Rows[i]["bianhao"].ToString();
                    //判断编号是否存在与数据库中
                    string str_sql = $"select * from {tablename} where bianhao='{bianhao}'";
                    var mydt = GetDataFromTable(str_sql);
                    if (mydt.Rows.Count > 0)
                    {
                        //获得表中得热度和时间
                        string str_sql2 = $"select redu,shijian from {tablename} where bianhao='{bianhao}'";
                        var mydt2 = GetDataFromTable(str_sql2);
                        var redu1 = mydt2.Rows[1]["redu"].ToString();
                        var shijian1 = mydt2.Rows[1]["shijian"].ToString();
                        //获得导入表中的热度和时间
                        var redu2 = dt.Rows[i]["redu"].ToString();
                        var shijian2 = dt.Rows[i]["shijian"].ToString();
                        //热度选择最大值，时间选择早值
                        int redumax = Math.Max(Convert.ToInt32(redu1), Convert.ToInt32(redu2));

                        DateTime shijianold = Convert.ToDateTime(shijian1) > Convert.ToDateTime(shijian2) ? Convert.ToDateTime(shijian2) : Convert.ToDateTime(shijian1);
                        //构造dic
                        Dictionary<string, object> dic3 = new Dictionary<string, object>() {
                        {"热度",redumax },
                        {"时间", shijianold}
                    };
                        //update数据
                        string str_sql3 = $"update {tablename}(热度,时间) values({redumax},{shijianold}) where 编号='{bianhao}'";
                        mydb.ExecuteNonQuery(str_sql3);
                    }
                    else
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>() { };
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            dic.Add(dt.Columns[j].ColumnName, dt.Rows[i][j]);
                        }



                        //mydb.Save(tablename, dic);
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
                    // List<object> list_o = mysqliter.ExecuteRow(str_sql, null, null);
                    //if (list_o.Count == 0)
                    //{

                    //    Dictionary<string, object> dic = new Dictionary<string, object>() { };
                    //    for (int j = 0; j < dt.Columns.Count; j++)
                    //    {
                    //        dic.Add(dt.Columns[j].ColumnName, dt.Rows[i][j]);
                    //    }
                    // mysqliter.Save(tablename, dic);
                    //}
                }
            }

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
