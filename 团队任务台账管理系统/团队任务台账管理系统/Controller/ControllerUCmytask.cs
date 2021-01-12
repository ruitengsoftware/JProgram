using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.Controller
{
   public class ControllerUCmytask
    {
        MySQLHelper mysql = new MySQLHelper();
        /// <summary>
        /// 获得需要的任务信息
        /// </summary>
        /// <param name="s">sql语句</param>
        /// <returns></returns>
        public List<JJTaskInfo> GetTaskinfo(string s)
        {
            List<JJTaskInfo> list = new List<JJTaskInfo>();
            JJTaskInfo myti = new JJTaskInfo();
            DataTable mydt = mysql.ExecuteDataTable(s);

            foreach (DataRow mydr in mydt.Rows)
            {
                myti = new JJTaskInfo() { 
                _mingcheng=mydr["名称"].ToString(),
                    _leixing=mydr["类型"].ToString(),
                    _canyuren=mydr["参与人"].ToString(),
                    _fuzeren=mydr["负责人"].ToString(),
                    _zhuangtai=mydr["状态"].ToString(),
                    _xiangqing=mydr["详情"].ToString(),
                    _chuangjianren = mydr["创建人"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString(),
                    _duqushijian = mydr["读取时间"].ToString(),
                    _shixian = mydr["时限"].ToString(),
                    _jinjichengdu = mydr["紧急程度"].ToString(),
                    _shanchu =Convert.ToInt32( mydr["删除"].ToString()),
                    _mubiao= mydr["总体目标"].ToString(),
                    _chengguoji= mydr["成果集"].ToString(),
                    _shenqingren= mydr["申请人"].ToString(),
                    _shiyou= mydr["事由"].ToString(),
                    _kaishishijian= mydr["开始时间"].ToString(),
                    _jieshushijian= mydr["结束时间"].ToString(),
                    _weituoduixiang= mydr["委托对象"].ToString(),
                    _shenheyijian= mydr["审核意见"].ToString(),
                    _biaoti= mydr["标题"].ToString(),
                    _fankuiren= mydr["反馈人"].ToString(),
                    _fankuiduixiang= mydr["反馈对象"].ToString(),
                    _neirong= mydr["内容"].ToString(),
                    _banliyijian= mydr["办理意见"].ToString(),
                    _banlirenyuan= mydr["办理人员"].ToString(),
                    _jinzhanqingkuang= mydr["进展情况"].ToString(),
                    _zongtiyanshouren= mydr["总体验收人"].ToString(),
                    _chuliyijian = mydr["处理意见"].ToString(),
                    _shenherenyuan= mydr["审核人员"].ToString(),
                    _fasongren= mydr["发送人"].ToString()


                };
                list.Add(myti);

            }
            return list;
        
        
        }






    }
}
