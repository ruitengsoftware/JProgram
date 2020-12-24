
using System;
using System.Collections.Generic;
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


    }
}
