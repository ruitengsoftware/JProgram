
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 查重工具.JJCommon;
using 查重工具.JJModel;

namespace 查重工具.JJController
{
    public class JJControllerForm
    {
        JJMySQLHelper _mysql = new JJMySQLHelper();
        /// <summary>
        /// 保存格式信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool SaveFormat(JJGeshiInfo info)
        {

            string str_sql = $"delete from 查重工具库.格式信息表 where 名称='{info._mingcheng}' and 删除=0";
            _mysql.ExecuteNonQuery(str_sql);
            str_sql = $"insert into 查重工具库.格式信息表 values('{info._mingcheng}','{info._chachongku}','{info._quanwenchongfulujing}','{info._zhengwenchongfulujing}'," +
                    $"'{info._quanwenchachong}','{info._zhengwenchachong}','{info._biaozhunduanchachong}'," +
                    $"'{info._biaozhunjuchachong}','{info._quanwenruku}','{info._zhengwenruku}','{info._biaozhunduanruku}'," +
                    $"'{info._biaozhunjuruku}','{info._baifenbishezhi}','0')";
            int num = _mysql.ExecuteNonQuery(str_sql);

            return num > 0 ? true : false;

        }

        /// <summary>
        /// 删除格式
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool DeleteFormat(JJGeshiInfo info)
        {
            string str_sql = $"update  查重工具库.格式信息表 set 删除=1 where 名称='{info._mingcheng}' and 删除=0";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 获得所有的格式名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllGeshiName()
        {
            List<string> list = new List<string>();

            string str_sql = $"select 名称 from 查重工具库.格式信息表 where 删除=0";
            DataTable mydt = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow dr in mydt.Rows)
            {
                list.Add(dr["名称"].ToString());
            }
            return list;
        
        }



        /// <summary>
        /// 根据格式名称获得格式信息类
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public JJGeshiInfo GetGeshiInfo(string s)
        {
            string str_sql = $"select * from 查重工具库.格式信息表 where 名称='{s}' and 删除=0";
            DataRow dr = _mysql.ExecuteDataRow(str_sql);
            JJGeshiInfo j = new JJGeshiInfo()
            {
                _mingcheng=dr["名称"].ToString(),
                _chachongku= dr["查重库"].ToString(),
                _quanwenchongfulujing= dr["全文重复路径"].ToString(),
                _zhengwenchongfulujing=dr["正文重复路径"].ToString(),
                _quanwenchachong=Convert.ToInt32(dr["全文查重"].ToString()),
                _zhengwenchachong = Convert.ToInt32(dr["正文查重"].ToString()),
                _biaozhunduanchachong= Convert.ToInt32(dr["标准段查重"].ToString()),
                _biaozhunjuchachong= Convert.ToInt32(dr["标准句查重"].ToString()),
                _quanwenruku= Convert.ToInt32(dr["全文入库"].ToString()),
                _zhengwenruku= Convert.ToInt32(dr["正文入库"].ToString()),
                _biaozhunduanruku= Convert.ToInt32(dr["标准段入库"].ToString()),
                _biaozhunjuruku= Convert.ToInt32(dr["标准句入库"].ToString()),
                _baifenbishezhi=dr["百分比设置"].ToString()
            };
            return j;
        }


    }
}
