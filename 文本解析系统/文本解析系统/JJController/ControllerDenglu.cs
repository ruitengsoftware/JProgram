
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
        JJCommon.MySQLHelper mysqlhelper = null;



        public ControllerDenglu()
        {
            mysqlhelper = new MySQLHelper();
        }

        /// <summary>
        /// 获得花名对应的头像图片
        /// </summary>
        /// <param name="huaming"></param>
        /// <returns></returns>
        public Image GetTouxiang(string huaming)
        {
            string str_sql = $"select 头像 from jjperson where 花名='{huaming}'";
            string str_touxiang = mysqlhelper.ExecuteScalar(str_sql).ToString();
            return ConvertBase64ToImage(str_touxiang);
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
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }


    }
}
