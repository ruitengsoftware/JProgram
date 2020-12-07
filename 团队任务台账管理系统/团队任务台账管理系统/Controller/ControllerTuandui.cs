using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerTuandui
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 解除某个团队
        /// </summary>
        /// <param name="tuanduimingchen"></param>
        /// <returns></returns>
        public bool JiechuTuandui(string tuanduimingchen)
        {
            string str_sql = $"update jjtuandui set 状态='已解除',解除时间='{DateTime.Now.ToString()}' where 名称='{tuanduimingchen}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 解除多个团队
        /// </summary>
        /// <param name="tuanduimingchen"></param>
        /// <returns></returns>
        public bool JiechuTuandui(List<string> list)
        {
            //构造文字集合
            List<string> mylist = new List<string>();
            foreach (string item in list)
            {
                mylist.Add($"'{item}'");
            }
            string str_sql = $"update jjtuandui set 状态='已解除',解除时间='{DateTime.Now.ToString()}' where 名称 in ({string.Join(",", mylist)})";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 向团队信息中加入成员
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool JiaruTuandui(List<string> list)
        {
            int num = 0;//用于保存受影响的行数
            //循环获得list的团队名称
            foreach (string mystr in list)
            {
                //获得团队成员，拆分成list
                string str_sql = $"select 成员 from jjtuandui where 状态='工作中' and 名称='{mystr}'";
                string chengyuan = mysqlhelper.ExecuteScalar(str_sql).ToString();
                List<string> listchengyuan = Regex.Split(chengyuan, ",").ToList();
                //判断list是否包含jjlogininfo.shiming
                if (!listchengyuan.Contains(JJLoginInfo._shiming))
                {
                    //加入到list中
                    listchengyuan.Add(JJLoginInfo._shiming);
                }
                //构造成员
                chengyuan = string.Join(",", listchengyuan);

                //更新成员到团队信息
                str_sql = $"update jjtuandui set 成员='{chengyuan}' where 名称='{mystr}' and 状态='工作中'";
                num +=mysqlhelper.ExecuteNonQuery(str_sql);
            }
                //返回结果true false
                return num > 0 ? true : false;
        }

        /// <summary>
        /// 向团队信息中退出成员
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool TuichuTuandui(List<string> list)
        {
            int num = 0;//用于保存受影响的行数
            //循环获得list的团队名称
            foreach (string mystr in list)
            {
                //获得团队成员，拆分成list
                string str_sql = $"select 成员 from jjtuandui where 状态='工作中' and 名称='{mystr}'";
                string chengyuan = mysqlhelper.ExecuteScalar(str_sql).ToString();
                List<string> listchengyuan = Regex.Split(chengyuan, ",").ToList();
                //判断list是否包含jjlogininfo.shiming
                if (listchengyuan.Contains(JJLoginInfo._shiming))
                {
                    //加入到list中
                    listchengyuan.Remove(JJLoginInfo._shiming);
                }
                //构造成员
                chengyuan = string.Join(",", listchengyuan);

                //更新成员到团队信息
                str_sql = $"update jjtuandui set 成员='{chengyuan}' where 名称='{mystr}' and 状态='工作中'";
                num += mysqlhelper.ExecuteNonQuery(str_sql);
            }
            //返回结果true false
            return num > 0 ? true : false;
        }


        /// <summary>
        /// 判断团队是否已经存在
        /// </summary>
        /// <param name="tuanduimingcheng">团队名称</param>
        /// <returns></returns>
        public bool ExistTuandui(string tuanduimingcheng)
        {
            string str_sql = $"select count(*) from jjtuandui where 名称='{tuanduimingcheng}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql));
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 新建团队到数据库中
        /// </summary>
        /// <param name="tuandui"></param>
        /// <param name="fuzeren"></param>
        /// <param name="chengyuan"></param>
        /// <returns></returns>
        public bool InsertTuandui(JJTuanduiInfo myinfo)
        {
            //判断是否已经存在了这个团队，如果存在那么就做修改，如果不存在就做插入
            string str_sql = $"select count(*) from jjtuandui where 名称='{myinfo._mingcheng}' and 状态='工作中' ";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
            if (num > 0)
            {
                str_sql = $"update jjtuandui set 名称='{myinfo._mingcheng}',负责人='{myinfo._fuzeren}',成员='{myinfo._chengyuan}',团队图片='{myinfo._tuanduitupian}',工作领域='{myinfo._gongzuolingyu}' where 名称='{myinfo._mingcheng}' and 状态='工作中'";
            }
            else
            {
                str_sql = $"insert into jjtuandui values('{myinfo._mingcheng}'," +
                       $"'{myinfo._fuzeren}','{myinfo._chengyuan}','{DateTime.Now.ToString()}','工作中','--'," +
                       $"'{myinfo._tuanduitupian}','{myinfo._gongzuolingyu}')";
            }
            int num2 = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num2 > 0 ? true : false;

        }
        /// <summary>
        /// 获得所有得团队信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetTuandui()
        {
            string str_sql = $"select * from jjtuandui where 状态='工作中'";
            DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql);
            return mydt;
        }
    }
}
