using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 团队任务台账管理系统.Controller
{

    

   public class ControllerUCshouquan
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        public DataTable GetPerson()
        {
            string str_sql = $"select * from jjperson";
            DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql, null);
            return mydt;
        }

        public bool UpdatePerson(string xingming,string quanxian)
        {
            string str_sql = $"update jjperson set 权限='{quanxian}' where 花名='{xingming}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql);
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
