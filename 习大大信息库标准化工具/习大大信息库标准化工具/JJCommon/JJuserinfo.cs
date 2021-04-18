using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 习大大信息库标准化工具.JJCommon
{
    class JJuserinfo
    {
        static MySqlHelper _mysqlhelper = new MySqlHelper();
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
            _huaming = mydr["花名"].ToString();
            _shiming = mydr["实名"].ToString();
            _bumen = mydr["部门"].ToString();
            _quanxian = mydr["权限"].ToString();
            _zhiji = mydr["职级"].ToString();
            _mima = mydr["密码"].ToString();
            _shoujihao = mydr["手机号"].ToString();
            _dianziyouxiang = mydr["电子邮箱"].ToString();
            _zidingyizhanghao = mydr["自定义账号"].ToString();
            _touxiang = mydr["头像"].ToString();
            _gongzuozhengjianzhao = mydr["工作证件照"].ToString();
            _weixinhao = mydr["微信号"].ToString();
            _gerenqianming = mydr["个人签名"].ToString();
            _denlguquan = Convert.ToInt32(mydr["登录权"].ToString());
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
            _diaoyongguize = string.Join("|", list);
            str_sql = $"select 名称 from jjdbwenbenjiexi.查重库信息表 where 删除=0";
            dt = _mysqlhelper.ExecuteDataTable(str_sql);
            list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i]["名称"].ToString());
            }
            _diaoyongchachongku = string.Join("|", list);


            _suodingguize = mydr["锁定规则"].ToString();
            _suodingchachongku = mydr["锁定查重库"].ToString();
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

