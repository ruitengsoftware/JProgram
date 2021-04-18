using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 谦海数据解析系统.JJmodel;

namespace 谦海数据解析系统
{
    class SystemInfo
    {
        /// <summary>
        /// 系统版本号
        /// </summary>
        public static string _version ="v1.0.1";
        /// <summary>
        /// 版本发布日期
        /// </summary>
        public static string _publishDate = "2021年4月17日";
        /// <summary>
        /// 用户当前选中的左侧模块
        /// </summary>
        public static string _currentModule = "文件名标准化";
        /// <summary>
        /// 配置文件中的数据库连接字符串
        /// </summary>
        public static string _strConn = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        /// <summary>
        /// 存放登录者信息
        /// </summary>
        public static UserInfo _userInfo = new UserInfo();

        /// <summary>
        /// 获得花名对应的登陆人员信息
        /// </summary>
        /// <param name="huaming"></param>
        /// <returns></returns>
        public static void GetUserInfo(string huaming)
        {
            string str_sql = $"select * from jjdbrenwutaizhang.jjperson where 花名='{huaming}' and 删除=0";
            var mydr = MySqlHelper.ExecuteDataRow(_strConn,str_sql);
            _userInfo._huaming = mydr["花名"].ToString();
            _userInfo._shiming = mydr["实名"].ToString();
            _userInfo._bumen = mydr["部门"].ToString();
            _userInfo._quanxian = mydr["权限"].ToString();
            _userInfo._zhiji = mydr["职级"].ToString();
            _userInfo._mima = mydr["密码"].ToString();
            _userInfo._shoujihao = mydr["手机号"].ToString();
            _userInfo._dianziyouxiang = mydr["电子邮箱"].ToString();
            _userInfo._zidingyizhanghao = mydr["自定义账号"].ToString();
            _userInfo._touxiang = mydr["头像"].ToString();
            _userInfo._gongzuozhengjianzhao = mydr["工作证件照"].ToString();
            _userInfo._weixinhao = mydr["微信号"].ToString();
            _userInfo._gerenqianming = mydr["个人签名"].ToString();
            _userInfo._dbLeibie = mydr["信息库类别"].ToString();
            _userInfo._dbName = mydr["信息库名称"].ToString();
            _userInfo._wjmbzh = mydr["文件名标准化格式"].ToString();
            _userInfo._wjbzh = mydr["文件标准化格式"].ToString();
            _userInfo._ccqx = mydr["查重清洗格式"].ToString();
            _userInfo._jcjx = mydr["基础解系格式"].ToString();
            _userInfo._nrjx = mydr["内容解析格式"].ToString();
            _userInfo._dsjb = mydr["大数据版格式"].ToString();

            // _userInfo._denlguquan = Convert.ToInt32(mydr["登录权"].ToString());
            //调用查重库和规则，暂时开放所有权限
            //LoginInfo._diaoyongchachongku = mydr["调用查重库"].ToString();
            //LoginInfo._diaoyongguize = mydr["调用规则"].ToString();
        }
        /// <summary>
        /// 保存userinfo个人信息到数据库中
        /// </summary>
        public static void SaveUserInfo()
        {
            string str_sql = $"update jjdbrenwutaizhang.jjperson " +
                $"set 实名='{_userInfo._shiming}',部门='{_userInfo._bumen}',权限='{_userInfo._quanxian}',职级='{_userInfo._zhiji}'," +
                $"密码='{_userInfo._mima}',手机号='{_userInfo._shoujihao}',电子邮箱='{_userInfo._dianziyouxiang}',自定义账号='{_userInfo._zidingyizhanghao}'," +
                $"头像='{_userInfo._touxiang}',工作证件照='{_userInfo._gongzuozhengjianzhao}',微信号='{_userInfo._weixinhao}'," +
                $"个人签名='{_userInfo._gerenqianming}',信息库类别='{_userInfo._dbLeibie}',信息库名称='{_userInfo._dbName}',文件名标准化格式='{_userInfo._wjmbzh}'," +
                $"文件标准化格式='{_userInfo._wjbzh}',查重清洗格式='{_userInfo._ccqx}',基础解系格式='{_userInfo._jcjx}',内容解析格式='{_userInfo._nrjx}',大数据版格式='{_userInfo._dsjb}' " +
                $"where 花名='{_userInfo._huaming}'";
            MySqlHelper.ExecuteScalar(_strConn, str_sql);
        }
    }
}
