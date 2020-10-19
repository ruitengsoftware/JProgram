using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int num=mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 判断花名是否已经有人注册
        /// </summary>
        /// <param name="huaming"></param>
        /// <returns></returns>
        public bool ExistsHuaming(string huaming)
        {
            string str_sql = $"select count(*) from jjperson where 花名='{huaming}'";
            int num =Convert.ToInt32( mysqlhelper.ExecuteScalar(str_sql, null));
            return num > 0 ? true : false;

        }
        /// <summary>
        /// 判断自定义账号是否已经被注册
        /// </summary>
        /// <param name="zhanghao"></param>
        /// <returns></returns>
        public bool ExistsZidingyi(string zhanghao)
        {
            string str_sql = $"select count(*) from jjperson where 自定义账号='{zhanghao}'";
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
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }

    }
}
