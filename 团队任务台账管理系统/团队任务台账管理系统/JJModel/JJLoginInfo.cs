using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;

namespace 团队任务台账管理系统.JJModel
{
    public class JJLoginInfo
    {
        static MySQLHelper _mysqlhelper = new MySQLHelper();
        public static Form1 _form1 = null;
        /// <summary>
        /// 登录人员花名
        /// </summary>
        public static string _huaming = string.Empty;

        public static string _shiming = string.Empty;

        public static string _bumen = string.Empty;
        public static string _quanxian = string.Empty;
        public static string _zhiji = string.Empty;
        public static string _mima = string.Empty;
        public static string _shoujihao = string.Empty;
        public static string _dianziyouxiang = string.Empty;
        public static string _zidingyizhanghao = string.Empty;
        public static string _touxiang = string.Empty;
        public static string _gongzuozhengjianzhao = string.Empty;

        public static string _weixinhao = string.Empty;
        public static string _gerenqianming = string.Empty;
        public static int _denlguquan = 0;
        public static string _diaoyongguize = string.Empty;
        public static string _diaoyongchachongku = string.Empty;
        public static string _suodingguize = string.Empty;
        public static string _suodingchachongku = string.Empty;

        /// <summary>
        /// 获得花名对应的登陆人员信息
        /// </summary>
        /// <param name="huaming"></param>
        /// <returns></returns>
        public static void GetLoginInfo(string huaming)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.jjperson where 花名='{huaming}' and 删除=0";
            var mydr = _mysqlhelper.ExecuteDataRow(str_sql);
            JJLoginInfo._huaming = mydr["花名"].ToString();
            JJLoginInfo._shiming = mydr["实名"].ToString();
            JJLoginInfo._bumen = mydr["部门"].ToString();
            JJLoginInfo._quanxian = mydr["权限"].ToString();
            JJLoginInfo._zhiji = mydr["职级"].ToString();
            JJLoginInfo._mima = mydr["密码"].ToString();
            JJLoginInfo._shoujihao = mydr["手机号"].ToString();
            JJLoginInfo._dianziyouxiang = mydr["电子邮箱"].ToString();
            JJLoginInfo._zidingyizhanghao = mydr["自定义账号"].ToString();
            JJLoginInfo._touxiang = mydr["头像"].ToString();
            var pt = JJImageHelper.ConvertBase64ToImage(JJLoginInfo._touxiang);
            _form1.pb_touxiang.Image =  JJImageHelper.UpdateImageSize(pt,128,128);
            JJLoginInfo._gongzuozhengjianzhao = mydr["工作证件照"].ToString();
            JJLoginInfo._weixinhao = mydr["微信号"].ToString();
            JJLoginInfo._gerenqianming = mydr["个人签名"].ToString();
            JJLoginInfo._denlguquan = Convert.ToInt32(mydr["登录权"].ToString());
            //调用查重库和规则，暂时开放所有权限
            //LoginInfo._diaoyongchachongku = mydr["调用查重库"].ToString();
            //LoginInfo._diaoyongguize = mydr["调用规则"].ToString();
            str_sql = $"select 名称 from jjdbwenbenjiexi.规则信息表 where 删除=0";
            var dt = _mysqlhelper.ExecuteDataTable(str_sql);
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i]["名称"].ToString());
            }
            JJLoginInfo._diaoyongguize = string.Join("|", list);
            str_sql = $"select 名称 from jjdbwenbenjiexi.查重库信息表 where 删除=0";
            dt = _mysqlhelper.ExecuteDataTable(str_sql);
            list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i]["名称"].ToString());
            }
            JJLoginInfo._diaoyongchachongku = string.Join("|", list);


            JJLoginInfo._suodingguize = mydr["锁定规则"].ToString();
            JJLoginInfo._suodingchachongku = mydr["锁定查重库"].ToString();
        }
        /// <summary>
        /// 判断是否有新任务
        /// </summary>
        /// <returns></returns>
        public static int GetWeiduTaskNum()
        {
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态='未读' and (参与人='{JJLoginInfo._huaming}' or 负责人='{JJLoginInfo._huaming}' or " +
                $"反馈对象='{JJLoginInfo._huaming}' or 办理人员='{JJLoginInfo._huaming}' or 委托对象='{JJLoginInfo._huaming}' or " +
                $"审核人员='{JJLoginInfo._huaming}' or 总体验收人='{JJLoginInfo._huaming}' )";
            DataTable mydt = _mysqlhelper.ExecuteDataTable(str_sql);
            if (mydt.Rows.Count>0)
            {
                JJMethod.IconStartShanshuo();
            }
            else
            {
                JJMethod.IconStopShanshuo();
            }


            return mydt.Rows.Count;
        }





    }
    public class PersonInfo
    {

        /// <summary>
        /// 登录人员花名
        /// </summary>
        public string _huaming = string.Empty;

        public string _shiming = string.Empty;

        public string _bumen = string.Empty;
        public string _quanxian = string.Empty;
        public string _zhiji = string.Empty;
        public string _mima = string.Empty;
        public string _shoujihao = string.Empty;
        public string _dianziyouxiang = string.Empty;
        public string _zidingyizhanghao = string.Empty;
        public string _touxiang = string.Empty;
        public string _gongzuozhengjianzhao = string.Empty;

        public string _weixinhao = string.Empty;
        public string _gerenqianming = string.Empty;
        public int _dengluquan = 0;
        public string _diaoyongguize = string.Empty;
        public string _diaoyongchachongku = string.Empty;
        public string _suodingguize = string.Empty;
        public string _suodingchachongku = string.Empty;
    }
}

