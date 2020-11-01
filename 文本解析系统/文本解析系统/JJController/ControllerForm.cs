using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJCommon;
using 文本解析系统.JJModel;

namespace 文本解析系统.JJController
{
    public class ControllerForm
    {
        public List<string> _childdirectories = new List<string>();
        public void GetDirectory(string folder)
        {

           //判断是否含有子文件夹，如果没有，加入



            _childdirectories = new List<string>();
            _childdirectories.Add(folder);
            DirectoryInfo mydir = new DirectoryInfo(folder);
            string[] dirs = Directory.GetDirectories(folder);
            if (dirs.Length==0)
            {
                _childdirectories.Add(folder);
            }
            else
            {
                foreach (string item in dirs)
                {
                    GetDirectory(item);
                }
            }


        }
        MySQLHelper mysqlhelper = new MySQLHelper(MySQLHelper.str_connother);
        /// <summary>
        /// 获得所有的规则
        /// </summary>
        /// <returns></returns>
        public DataTable GetGuize()
        {
            string str_sql = $"select * from 规则信息表 where 删除=0";
            return mysqlhelper.ExecuteDataTable(str_sql, null);
        }
        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteGuize(string name)
        {
            string str_sql = $"update 规则信息表 set 删除=1 where 规则名称='{name}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 删除格式,令删除字段为1
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteFormat(string name)
        {
            string str_sql = $"update 解析格式表 set 删除=1 where 格式名称='{name}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 删除格式，彻底删除
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool RealDeleteFormat(string name)
        {
            string str_sql = $"delete from 解析格式表 where 格式名称='{name}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 保存解析格式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="chachong"></param>
        /// <param name="excel"></param>
        /// <param name="guize"></param>
        /// <returns></returns>
        public bool SaveFormat(string name, string chachong, string excel, List<string> guize)
        {
            string str_guize = string.Join("|", guize);
            //保存之前判断格式名称是否重复
            //string str_sql = $"select count(*) from 解析格式表 where 格式名称='{name}' and 删除=0";
            //int formatnum =Convert.ToInt32 (mysqlhelper.ExecuteScalar(str_sql,null));
            //if (formatnum>0)
            //{
            //    MessageBox.Show("保存失败，格式名已存在！");
            //    return false;
            //}
            //保存格式
          string  str_sql = $"insert into 解析格式表 values('{name}','{chachong}','{excel}','{str_guize}',0)";
            int num=mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        
        }
        /// <summary>
        /// 获得数据库中所有解析格式的名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetFormat()
        {
            List<string> list = new List<string>();
            string str_sql = $"select 格式名称 from 解析格式表 where 删除=0";
            DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql, null);
            foreach (DataRow item in mydt.Rows)
            {
                list.Add(item["格式名称"].ToString());
            }
            return list;
        
        }
    /// <summary>
    /// 获得某格式信息
    /// </summary>
    /// <param name="formatname">解析格式名称</param>
    /// <returns></returns>
        public FormatInfo GetFormatInfo(string formatname)
        {
            List<string> list = new List<string>();
            string str_sql = $"select * from 解析格式表 where 格式名称='{formatname}' and 删除=0";
            DataRow mydr = mysqlhelper.ExecuteDataRow(str_sql, null);
            return new FormatInfo() {
                _formatname = mydr["格式名称"].ToString(),
                _chachongchuli = mydr["查重处理"].ToString(),
                _excelpath = mydr["excel存放"].ToString(),
                list_jiexiguize = Regex.Split(mydr["解析规则"].ToString(), "|").ToList()
            };

        }





        /// <summary>
        /// 刷新dgv_jiexiguize的数据
        /// </summary>
        /// <param name="mydgv"></param>
        public void UpdateDGV(DataGridView mydgv)
        {
            mydgv.Rows.Clear();
            //更新dgv_guize的数据
            DataTable mydt = GetGuize();
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                int index = mydgv.Rows.Add();
                mydgv.Rows[index].Cells[1].Value = mydt.Rows[i]["规则名称"].ToString();
                mydgv.Rows[index].Cells[2].Value = mydt.Rows[i]["创建人"].ToString();
                mydgv.Rows[index].Cells[3].Value = mydt.Rows[i]["创建时间"].ToString();
            }
        }


    }
}
