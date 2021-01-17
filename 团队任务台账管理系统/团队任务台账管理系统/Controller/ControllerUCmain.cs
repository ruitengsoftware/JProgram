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
        /// 获得工作签单得总页码数
        /// </summary>
        /// <returns></returns>
        public double GetGongzuoqingdanPagenums()
        {
            string str_sql = string.Empty;
            //string str_sql = $"select * from jjdbrenwutaizhang.工作清单表 where 创建人='{JJLoginInfo._shiming}' and 删除=0 and 象限='{xiangxian}' order by 完成时间";
            str_sql = $"select count(*) from jjdbrenwutaizhang.工作清单表 where  删除=0 and 创建人='{JJLoginInfo._huaming}'";
            int num = Convert.ToInt32(_mysqlhelper.ExecuteScalar(str_sql));
            return Math.Ceiling(Convert.ToDouble(num) / 10);
        }
        /// <summary>
        /// 获得工作签单得总页码数
        /// </summary>
        /// <returns></returns>
        public double GetDaibanPagenums()
        {
            string str_sql = string.Empty;
            //string str_sql = $"select * from jjdbrenwutaizhang.工作清单表 where 创建人='{JJLoginInfo._shiming}' and 删除=0 and 象限='{xiangxian}' order by 完成时间";
           str_sql = $"select count(*) from jjdbrenwutaizhang.任务信息表 where  删除=0 and 状态<>'已处理' " +
                $"and (反馈对象='{JJLoginInfo._huaming}' or 审核人员='{JJLoginInfo._huaming}' or 委托对象='{JJLoginInfo._huaming}' or " +
                $"总体验收人='{JJLoginInfo._huaming}' or 办理人员='{JJLoginInfo._huaming}')";
    //        str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where  删除=0 and 状态='未读' " +
    //$"and (反馈对象='{JJLoginInfo._huaming}' or 审核人员='{JJLoginInfo._huaming}' or 委托对象='{JJLoginInfo._huaming}' or " +
    //$"总体验收人='{JJLoginInfo._huaming}' or 办理人员='{JJLoginInfo._huaming}')";

            //DataTable mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            int num = Convert.ToInt32(_mysqlhelper.ExecuteScalar(str_sql));
            return Math.Ceiling(Convert.ToDouble(num) / 10);
        }
        /// <summary>
        /// 获得工作签单得总页码数
        /// </summary>
        /// <returns></returns>
        public double GetTongzhiPagenums()
        {
            string str_sql = string.Empty;
            //string str_sql = $"select * from jjdbrenwutaizhang.工作清单表 where 创建人='{JJLoginInfo._shiming}' and 删除=0 and 象限='{xiangxian}' order by 完成时间";
            str_sql = $"select count(*) from jjdbrenwutaizhang.通知公告表 where 删除=0 and 状态='未读' and 阅读范围='{JJLoginInfo._huaming}'";
            int num = Convert.ToInt32(_mysqlhelper.ExecuteScalar(str_sql));
            return Math.Ceiling(Convert.ToDouble(num) / 10);
        }





        /// <summary>
        /// 获得创建人的任务
        /// </summary>
        /// <param name="xiangxian">象限</param>
        /// <returns></returns>
        public List<JJQingdanInfo> GetGongzuoqingdan(int start, string kw)
        {
            List<JJQingdanInfo> list = new List<JJQingdanInfo>();
            DataTable mydt = new DataTable();
            string str_sql = string.Empty;
            //string str_sql = $"select * from jjdbrenwutaizhang.工作清单表 where 创建人='{JJLoginInfo._shiming}' and 删除=0 and 象限='{xiangxian}' order by 完成时间";
            str_sql = $"select * from jjdbrenwutaizhang.工作清单表 " +
                $"where 名称 like '%{kw}%' and 删除=0 and 创建人='{JJLoginInfo._huaming}' " +
                $"and 状态<>'已处理' " +
                $"order by 轻重缓急,完成时间 desc " +
                $"limit {10 * (start - 1)},10";
            mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in mydt.Rows)
            {
                JJQingdanInfo info = new JJQingdanInfo()
                {
                    _renwumingcheng = mydr["名称"].ToString(),
                    _chuangjianren = mydr["创建人"].ToString(),
                    _wanchengshijian = mydr["完成时间"].ToString(),
                    _qingzhonghuanji = mydr["轻重缓急"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString(),
                    //_zhuangtai = mydr["状态"].ToString(),
                    //_xiaoxiang = Convert.ToInt32(mydr["销项"].ToString()),
                    _beizhu = mydr["备注"].ToString(),
                    _jingyanjiaoxun = mydr["经验教训"].ToString(),
                };
                list.Add(info);
            }
            return list;
        }



        /// <summary>
        /// 获得待办任务 ,包括OKR,常规事项，请休假单，意见建议
        /// </summary>
        /// <returns></returns>
        public List<JJTaskInfo> GetDaibanRenwu(int start, string s)
        {
            List<JJTaskInfo> list = new List<JJTaskInfo>();
            string str_sql = string.Empty;
            DataTable data = null;

            //获得紧急程度是紧急的四种任务，按照请休假，okr，常规事项，意见建议排序，其中又按照完成时间排序
            //获得请休假单
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 " +
                $"where 事由 like '%{s}%' and 删除=0 and 类型='请休假单' and 紧急程度='紧急' and 状态<>'已处理'  and 状态<>'保存' " +
                $"and (审核人员='{JJLoginInfo._huaming}' or 委托对象='{JJLoginInfo._huaming}') " +
                $"order by 起止时间 desc";
            data = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng = dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _fuzeren = dr["负责人"].ToString(),
                    _shixian = dr["时限"].ToString(),
                    _leixing = dr["类型"].ToString(),
                    _canyuren = dr["参与人"].ToString(),
                    _zhuangtai = dr["状态"].ToString(),
                    _xiangqing = dr["详情"].ToString(),
                    _chuangjianren = dr["创建人"].ToString(),
                    _chuangjianshijian = dr["创建时间"].ToString(),
                    _mubiao = dr["总体目标"].ToString(),
                    _chengguoji = dr["成果集"].ToString(),
                    _shenqingren = dr["申请人"].ToString(),
                    _shiyou = dr["事由"].ToString(),
                    _kaishishijian = dr["开始时间"].ToString(),
                    _jieshushijian = dr["结束时间"].ToString(),
                    _weituoduixiang = dr["委托对象"].ToString(),
                    _shenherenyuan=dr["审核人员"].ToString(),
                    _shenheyijian = dr["审核意见"].ToString(),
                    _qizhishijian=dr["起止时间"].ToString(),
                    _fasongren=dr["发送人"].ToString()
                };
                list.Add(info);

            }
            //获得okr
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 名称 like '%{s}%' and 删除=0 and 类型='okr事项' " +
                $"and 紧急程度='紧急' and 状态<>'已处理'  and 状态<>'保存' " +
                $"and (总体验收人='{JJLoginInfo._huaming}' or 办理人员='{JJLoginInfo._huaming}') " +
                $"order by 时限 desc";
            data = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng = dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _zongtiyanshouren = dr["总体验收人"].ToString(),
                    _mubiao = dr["总体目标"].ToString(),
                    _chengguoji = dr["成果集"].ToString(),
                    _leixing = dr["类型"].ToString(),
                    _zhuangtai = dr["状态"].ToString(),
                    _fasongren=dr["发送人"].ToString()

                };
                list.Add(info);

            }

            //获得常规事项
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 名称 like '%{s}%' and 删除=0 and " +
                $"类型='常规事项' and 紧急程度='紧急' and 状态<>'已处理' and 状态<>'保存' and 办理人员='{JJLoginInfo._huaming}' " +
                $"order by 时限 desc";
            data = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng = dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _jutiyaoqiu = dr["具体要求"].ToString(),
                    _fujian = dr["附件"].ToString(),
                    _shixian = dr["时限"].ToString(),
                    _banliyijian = dr["办理意见"].ToString(),
                    _banlirenyuan = dr["办理人员"].ToString(),
                    _jinzhanqingkuang = dr["进展情况"].ToString(),
                    _leixing = dr["类型"].ToString(),
                    _zhuangtai = dr["状态"].ToString(),
                    _fasongren = dr["发送人"].ToString()



                };
                list.Add(info);

            }
            //获得意见建议
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 标题 like '%{s}%' and 删除=0 and " +
                $"类型='意见建议' and 紧急程度='紧急' and 状态<>'已处理'  and 状态<>'保存' and 反馈对象='{JJLoginInfo._huaming}'" +
                $"order by 时限 desc";
            data = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng = dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _fuzeren = dr["负责人"].ToString(),
                    _shixian = dr["时限"].ToString(),
                    _leixing = dr["类型"].ToString(),
                    _canyuren = dr["参与人"].ToString(),
                    _zhuangtai = dr["状态"].ToString(),
                    _xiangqing = dr["详情"].ToString(),
                    _chuangjianren = dr["创建人"].ToString(),
                    _chuangjianshijian = dr["创建时间"].ToString(),
                    //_mubiao = dr["objectives目标"].ToString(),
                    _chengguoji = dr["成果集"].ToString(),
                    _biaoti = dr["标题"].ToString(),
                    _fankuiren = dr["反馈人"].ToString(),
                    _fankuiduixiang = dr["反馈对象"].ToString(),
                    _neirong = dr["内容"].ToString(),
                    _fasongren = dr["发送人"].ToString(),
                    _chuliyijian = dr["处理意见"].ToString()
                    

                };
                list.Add(info);

            }
            //获得紧急程度是普通的四种任务
            //获得请休假单
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 " +
                $"where 事由 like '%{s}%' and 删除=0 and 类型='请休假单' and 紧急程度='普通' and 状态<>'已处理'  and 状态<>'保存' " +
                $"and (审核人员='{JJLoginInfo._huaming}' or 委托对象='{JJLoginInfo._huaming}')" +
                $"order by 起止时间 desc";
            data = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng = dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _fuzeren = dr["负责人"].ToString(),
                    _shixian = dr["时限"].ToString(),
                    _leixing = dr["类型"].ToString(),
                    _canyuren = dr["参与人"].ToString(),
                    _zhuangtai = dr["状态"].ToString(),
                    _xiangqing = dr["详情"].ToString(),
                    _chuangjianren = dr["创建人"].ToString(),
                    _chuangjianshijian = dr["创建时间"].ToString(),
                    _mubiao = dr["总体目标"].ToString(),
                    _chengguoji = dr["成果集"].ToString(),
                    _shenqingren = dr["申请人"].ToString(),
                    _shiyou = dr["事由"].ToString(),
                    _kaishishijian = dr["开始时间"].ToString(),
                    _jieshushijian = dr["结束时间"].ToString(),
                    _weituoduixiang = dr["委托对象"].ToString(),
                    _shenheyijian = dr["审核意见"].ToString(),
                    _qizhishijian = dr["起止时间"].ToString(),
                    _shenherenyuan=dr["审核人员"].ToString(),
                    _fasongren=dr["发送人"].ToString()
                };
                list.Add(info);

            }
            //获得okr
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 名称 like '%{s}%' and 删除=0 and 类型='okr事项' " +
                $"and 紧急程度='普通' and 状态<>'已处理'  and 状态<>'保存' " +
                $"and (总体验收人='{JJLoginInfo._huaming}' or 办理人员='{JJLoginInfo._huaming}') " +
                $"order by 时限 desc";
            data = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng = dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _zongtiyanshouren = dr["总体验收人"].ToString(),
                    _mubiao = dr["总体目标"].ToString(),
                    _chengguoji = dr["成果集"].ToString(),
                    _leixing = dr["类型"].ToString(),
                    _zhuangtai = dr["状态"].ToString(),
                    _fasongren=dr["发送人"].ToString()


                };
                list.Add(info);

            }
            //获得常规事项
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 名称 like '%{s}%' and 删除=0 and " +
                $"类型='常规事项' and 紧急程度='普通' and 状态<>'已处理'  and 状态<>'保存' " +
                $"and 办理人员='{JJLoginInfo._huaming}' " +
                $"order by 时限 desc";
            data = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng = dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _jutiyaoqiu = dr["具体要求"].ToString(),
                    _fujian = dr["附件"].ToString(),
                    _shixian = dr["时限"].ToString(),
                    _banliyijian = dr["办理意见"].ToString(),
                    _banlirenyuan = dr["办理人员"].ToString(),
                    _jinzhanqingkuang = dr["进展情况"].ToString(),
                    _leixing = dr["类型"].ToString(),
                    _zhuangtai=dr["状态"].ToString(),
                    _fasongren = dr["发送人"].ToString()


                };
                list.Add(info);

            }
            //获得意见建议
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 标题 like '%{s}%' and 删除=0 and " +
                $"类型='意见建议' and 紧急程度='普通' and 状态<>'已处理'  and 状态<>'保存' " +
                $"and 反馈对象='{JJLoginInfo._huaming}'" +
                $"order by 时限 desc";
            data = _mysqlhelper.ExecuteDataTable(str_sql);
            foreach (DataRow dr in data.Rows)
            {
                JJTaskInfo info = new JJTaskInfo()
                {
                    _mingcheng = dr["名称"].ToString(),
                    _jinjichengdu = dr["紧急程度"].ToString(),
                    _fuzeren = dr["负责人"].ToString(),
                    _shixian = dr["时限"].ToString(),
                    _leixing = dr["类型"].ToString(),
                    _canyuren = dr["参与人"].ToString(),
                    _zhuangtai = dr["状态"].ToString(),
                    _xiangqing = dr["详情"].ToString(),
                    _chuangjianren = dr["创建人"].ToString(),
                    _chuangjianshijian = dr["创建时间"].ToString(),
                    //_mubiao = dr["objectives目标"].ToString(),
                    _chengguoji = dr["成果集"].ToString(),
                    _biaoti = dr["标题"].ToString(),
                    _fankuiren = dr["反馈人"].ToString(),
                    _fankuiduixiang = dr["反馈对象"].ToString(),
                    _neirong = dr["内容"].ToString(),
                    _fasongren = dr["发送人"].ToString(),
                    _chuliyijian = dr["处理意见"].ToString()


                };
                list.Add(info);

            }

            //获得第i个开始的10个结果
            List<JJTaskInfo> list_result = new List<JJTaskInfo>();
            for (int i = (start-1)*10; i < start*10; i++)
            {
                try
                {
                list_result.Add(list[i]);

                }
                catch { break; }
            }
            return list_result;
        }
        /// <summary>
        /// 获得通知公告
        /// </summary>
        /// <returns></returns>
        public List<JJTongzhiInfo> GetTongzhi(int start,string kw)
        {
            List<JJTongzhiInfo> list = new List<JJTongzhiInfo>();
            string str_sql = $"select * from jjdbrenwutaizhang.通知公告表 " +
                $"where 标题 like '%{kw}%' and 删除=0 " +
                $"and 阅读范围='{JJLoginInfo._huaming}' " +
                $"limit {10*(start-1)},10";
            var data = _mysqlhelper.ExecuteDataTable(str_sql, null);
            foreach (DataRow dr in data.Rows)
            {
                JJTongzhiInfo info = new JJTongzhiInfo()
                {
                    _biaoti = dr["标题"].ToString(),
                    _qianfaren = dr["签发人"].ToString(),
                    _neirongpath = dr["内容"].ToString(),
                    _zhuangtai = dr["状态"].ToString(),
                    _fabushijian = dr["发布时间"].ToString(),
                    _qingzhonghuanji = dr["轻重缓急"].ToString(),
                    _shixian = dr["时限"].ToString(),
                    _yuedufanwei = dr["阅读范围"].ToString(),
                    _fujian = dr["附件"].ToString()


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
            string str_sql = $"update 工作清单表 set 删除=1 where 任务名称='{mingcheng }' and 主办人='{JJLoginInfo._shiming}'";
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
            string str_sql = $"update 工作清单表 set 状态='完成' where 任务名称='{mingcheng }' and 主办人='{JJLoginInfo._shiming}'";
            int num = _mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;

        }

    }
}
