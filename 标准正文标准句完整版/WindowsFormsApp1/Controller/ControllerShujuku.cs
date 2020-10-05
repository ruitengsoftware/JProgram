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

namespace BLL
{
    public class ControllerShujuku
    {
        SqliteHelper mysqliter = null;
        public static string _newtablename = string.Empty;
        OfficeHelper officehelper = new OfficeHelper();
        public ControllerShujuku()
        {
            string dbfile = $"{Environment.CurrentDirectory}\\ruitengdb.db";
            mysqliter = new SqliteHelper(dbfile);
            mysqliter.Open();
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
                    string str_sql = $"CREATE TABLE {tablename}(序号,编号,时间,来源,内容,热度)";
                    mysqliter.ExecuteRow(str_sql, null, null);
                    System.Windows.Forms.MessageBox.Show($"数据表 {tablename} 已成功添加!");

                }
                else if ((leixing.Equals("标准正文")))
                {
                    string str_sql = $"CREATE TABLE {tablename}(序号,编号,来源,正文内容)";
                    mysqliter.ExecuteRow(str_sql, null, null);
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
                string str_sql = $"ALTER TABLE {table0} RENAME TO {table1}";
                mysqliter.ExecuteRow(str_sql, null, null);
                System.Windows.Forms.MessageBox.Show($"数据表 {table1} 改名已成功!");
            }
        }
        /// <summary>
        /// 该方法用于删除数据库
        /// </summary>
        public void DeleteDatabase(string tablename)
        {
            string str_sql = $"drop table {tablename}";
            mysqliter.ExecuteRow(str_sql, null, null);
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
            if (list_head.Contains("热度"))//判断事标准句表
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string bianhao = dt.Rows[i]["编号"].ToString();
                    //判断编号是否存在与数据库中
                    string str_sql = $"select * from {tablename} where 编号='{bianhao}'";
                    List<object> list_o = mysqliter.ExecuteRow(str_sql, null, null);
                    if (list_o.Count > 0)
                    {
                        //获得表中得热度和时间
                        string str_sql2 = $"select 热度,时间 from {tablename} where 编号='{bianhao}'";
                        List<object> list_o2 = mysqliter.ExecuteRow(str_sql2, null, null);
                        Dictionary<string, object> dic2 = list_o2[0] as Dictionary<string, object>;
                        var redu1 = dic2["热度"].ToString();
                        var shijian1 = dic2["时间"].ToString();
                        //获得导入表中的热度和时间
                        var redu2 = dt.Rows[i]["热度"].ToString();
                        var shijian2 = dt.Rows[i]["时间"].ToString();
                        //热度选择最大值，时间选择早值
                        int redumax = Math.Max(Convert.ToInt32(redu1), Convert.ToInt32(redu2));

                        DateTime shijianold = Convert.ToDateTime(shijian1) > Convert.ToDateTime(shijian2) ? Convert.ToDateTime(shijian2) : Convert.ToDateTime(shijian1);
                        //构造dic
                        Dictionary<string, object> dic3 = new Dictionary<string, object>() {
                        {"热度",redumax },
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
                   
                    if (end>dt.Rows.Count)
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
