
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 文本解析系统.JJCommon;

namespace 文本解析系统.JJController
{
   public class ControllerDenglu
    {
        MySQLHelper mysqlhelper = null;



        public ControllerDenglu()
        {
            mysqlhelper = new MySQLHelper();
        }

        /// <summary>
        /// 获得花名对应的登陆人员信息
        /// </summary>
        /// <param name="huaming"></param>
        /// <returns></returns>
        public void GetLoginInfo(string huaming)
        {
            string str_sql = $"select * from jjperson where 花名='{huaming}'";

            var mydr = mysqlhelper.ExecuteDataRow(str_sql);
            //JJLoginInfo._huaming = mydr["花名"].ToString();
            //JJLoginInfo._shiming = mydr["实名"].ToString();
            //JJLoginInfo._bumen = mydr["部门"].ToString();
            //JJLoginInfo._zhiji = mydr["职级"].ToString();
            //JJLoginInfo._mima = mydr["密码"].ToString();
            //JJLoginInfo._shoujihao = mydr["手机号"].ToString();
            //JJLoginInfo._dianziyouxiang = mydr["电子邮箱"].ToString();
            //JJLoginInfo._zidingyizhanghao = mydr["自定义账号"].ToString();
            //JJLoginInfo._touxiang = mydr["头像"].ToString();
            //JJLoginInfo._gongzuozhengjianzhao = mydr["工作证件照"].ToString();
            //JJLoginInfo._weixinhao = mydr["微信号"].ToString();
            //JJLoginInfo._gerenqianming = mydr["个人签名"].ToString();
        }

        //判断是否存在用户名和密码
        public bool Login(string uid, string pwd)
        {
            string str_sql = $"select count(*) from jjperson where 花名='{uid}' and 密码='{pwd}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 将图片转换为base64编码
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string ConvertImageToBase64(Image file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.Save(memoryStream, file.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
        /// <summary>
        /// 将64位编码转化成图片
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public Image ConvertBase64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    return Image.FromStream(ms, true);
                }

            }
            catch
            {
                return null;
            }
        }



    }
}
