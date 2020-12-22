using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerUCmain
    {
        MySQLHelper _mysqlhelper = new MySQLHelper();

        public bool UpdateGerenqianming(string qianming)
        {
            string sql_sql = $"update jjdbrenwutaizhang.jjperson set 个人签名='{qianming}' where 花名='{JJLoginInfo._huaming}'";
            int num = _mysqlhelper.ExecuteNonQuery(sql_sql);
            return num > 0 ? true : false;

        }
        /// <summary>
        /// 获得创建人的各个象限任务
        /// </summary>
        /// <param name="xiangxian">象限</param>
        /// <returns></returns>
        public DataTable GetGongzuoqingdan(string xiangxian)
        {
            DataTable mydt = new DataTable();
            string str_sql = $"select * from jjdbrenwutaizhang.jjgongzuoqingdan where 创建人='{JJLoginInfo._shiming}' and 删除=0 and 象限='{xiangxian}' order by 完成时间";
            str_sql = $"select * from jjdbrenwutaizhang.jjgongzuoqingdan where  删除=0 and 象限='{xiangxian}' order by 完成时间";
            mydt = _mysqlhelper.ExecuteDataTable(str_sql, null);
            return mydt;
        }
        /// <summary>
        /// 获得创建人的任务
        /// </summary>
        /// <param name="xiangxian">象限</param>
        /// <returns></returns>
        public List<JJQingdanInfo> GetGongzuoqingdan()
        {
            List<JJQingdanInfo> list = new List<JJQingdanInfo>();
            DataTable mydt = new DataTable();
            string str_sql = string.Empty;
            //string str_sql = $"select * from jjdbrenwutaizhang.jjgongzuoqingdan where 创建人='{JJLoginInfo._shiming}' and 删除=0 and 象限='{xiangxian}' order by 完成时间";
            str_sql = $"select * from jjdbrenwutaizhang.jjgongzuoqingdan where  删除=0 and 销项=0";
            mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in mydt.Rows)
            {
                JJQingdanInfo  info= new JJQingdanInfo() { 
                _renwumingcheng=mydr["任务名称"].ToString(),
                    _chuangjianren = mydr["创建人"].ToString(),
                    _zhubanren = mydr["主办人"].ToString(),
                    _wanchengshijian = mydr["完成时间"].ToString(),
                    _xiangxian = mydr["象限"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString(),
                    _zhuangtai = mydr["状态"].ToString(),
                    _xiaoxiang =Convert.ToInt32( mydr["销项"].ToString()),
                    _beizhu = mydr["备注"].ToString(),
                    _xindetihui = mydr["心得体会"].ToString(),
                };
                list.Add(info);
            }
            return list;
        }
        /// <summary>
        /// 获得待办任务 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDaibanRenwuDT(string s)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.常规事项表 where 任务名称 like '%{s}%' and 删除=0";

            var data = _mysqlhelper.ExecuteDataTable(str_sql, null);
            return data;
        }


        /// <summary>
        /// 获得待办任务 
        /// </summary>
        /// <returns></returns>
        public List<JJTaskInfo> GetDaibanRenwu(string s)
        {
            List<JJTaskInfo> list = new List<JJTaskInfo>();
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 名称 like '%{s}%' and 删除=0 and 类型='常规事项'";

            var data = _mysqlhelper.ExecuteDataTable(str_sql, null);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng=dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _fuzeren = dr["负责人"].ToString(),
                    _shixian = dr["时限"].ToString(),
                    _leixing=dr["类型"].ToString(),
                    _canyuren = dr["参与人"].ToString(),
                   _zhuangtai = dr["状态"].ToString(),
                   _xiangqing = dr["详情"].ToString(),
                   _chuangjianren = dr["创建人"].ToString(),
                   _chuangjianshijian = dr["创建时间"].ToString(),
                };
                list.Add(info);

            }
            return list;
        }
        /// <summary>
        /// 获得通知公告
        /// </summary>
        /// <returns></returns>
        public List<JJTongzhiInfo> GetTongzhi()
        {
            List<JJTongzhiInfo> list = new List<JJTongzhiInfo>();
            string str_sql = $"select * from jjdbrenwutaizhang.通知公告表 where 删除=0";
            var data = _mysqlhelper.ExecuteDataTable(str_sql, null);
            foreach (DataRow dr in data.Rows)
            {
                JJTongzhiInfo info = new JJTongzhiInfo() { 
                _biaoti=dr["标题"].ToString(),
                _qianfaren =dr["签发人"].ToString(),
                _neirong = dr["内容"].ToString(),
                _zhuangtai = dr["状态"].ToString(),
                _fabushijian = dr["发布时间"].ToString()
                };
                list.Add(info);

            }
            return list;
        }


        /// <summary>
        /// 删除工作清单
        /// </summary>
        /// <param name="mingcheng"></param>
        /// <returns></returns>
        public bool DeleteQingdan(string mingcheng)
        {
            string str_sql = $"update jjgongzuoqingdan set 删除=1 where 任务名称='{mingcheng }' and 主办人='{JJLoginInfo._shiming}'";
        int num = _mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        
        }
        /// <summary>
        /// 完成工作清单（另该清单状态变成完成）
        /// </summary>
        /// <param name="mingcheng"></param>
        /// <returns></returns>
        public bool FinishQingdan(string mingcheng)
        {
            string str_sql = $"update jjgongzuoqingdan set 状态='完成' where 任务名称='{mingcheng }' and 主办人='{JJLoginInfo._shiming}'";
            int num = _mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;

        }

    }
}
