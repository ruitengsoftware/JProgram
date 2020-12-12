using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 团队任务台账管理系统.JJModel;
using 文本解析系统.JJCommon;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerWFzhuce
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        /// <summary>
        /// 注册一个员工到数据库中
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public bool Zhuce(Dictionary<string, string> dic)
        {
            string str_sql = $"insert into jjperson values('{dic["花名"]}','{dic["实名"]}','{dic["部门"]}','{dic["职级"]}','{dic["密码"]}','{dic["手机号"]}','{dic["电子邮箱"]}'," +
                $"'{dic["自定义账号"]}','{dic["头像"]}','{dic["工作证件照"]}','{dic["微信号"]}',0)";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <returns></returns>
        public bool BaocunInfo(JJPersonInfo p)
        {

            //判断花名，如果已经存在，使用update语句，如果不存在使用insertinto语句
            string str_sql = $"select count(*) from jjdbrenwutaizhang.jjperson where 花名='{p._huaming}' and 删除=0";
            int num0 = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql));
            if (num0>0)
            {
            str_sql = $"update jjdbrenwutaizhang.jjperson set 实名='{p._shiming}',部门='普通员工','{p._bumen}',部门,职级='{p._zhiji}',密码='{p._mima}',手机号='{p._shoujihao}',电子邮箱='{p._dianziyouxiang}'," +
                $"自定义账号='{p._zidingyizhanghao}',密码='{p._mima}',头像='{p._touxiang}',工作证件照='{p._gongzuozhengjianzhao}',微信号='{p._weixinhao}',个人签名='{p._gerenqianming}' where 花名='{JJLoginInfo._huaming}'";

            }
            else
            {
           str_sql = $"insert into jjdbrenwutaizhang.jjperson values('{p._huaming}','{p._shiming}','{p._bumen}'," +
                    $"'普通用户','{p._zhiji}','{p._mima}','{p._shoujihao}','{p._dianziyouxiang}'," +
                    $"'{p._zidingyizhanghao}','{p._touxiang}','{p._gongzuozhengjianzhao}','{p._weixinhao}',0,'{p._gerenqianming}',1,'','','','')";

            }
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }


        /// <summary>
        /// 判断花名是否已经有人注册
        /// </summary>
        /// <param name="huaming"></param>
        /// <returns></returns>
        public bool ExistsHuaming(string huaming)
        {
            string str_sql = $"select count(*) from jjdbrenwutaizhang.jjperson where 花名='{huaming}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
            return num > 0 ? true : false;

        }
        /// <summary>
        /// 判断自定义账号是否已经被注册
        /// </summary>
        /// <param name="zhanghao"></param>
        /// <returns></returns>
        public bool ExistsZidingyi(string zhanghao)
        {
            string str_sql = $"select count(*) from jjdbrenwutaizhang.jjperson where 自定义账号='{zhanghao}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
            return num > 0 ? true : false;

        }


    }
}
