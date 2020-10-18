using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Properties;

namespace 团队任务台账管理系统.Controller
{
    public class ControllerWFrizhi
    {
        MySQLHelper mysqlhelper = new MySQLHelper();
        public bool BaocunRizhi(string title, string content)
        {
            //判断标题名称是否存在，如果存在，提示选择覆盖或者退出
            string str_sql = $"select count(*) from jjrizhi where 标题='{title}'";
            int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql));


            if (num == 0)
            {
                str_sql = $"insert into jjrizhi values('{Settings.Default.huaming}','{DateTime.Now.ToString()}','{content}','{title}')";
                num = mysqlhelper.ExecuteNonQuery(str_sql, null);
                return num > 0 ? true : false;

            }
            else
            {
                var msgbox = System.Windows.Forms.MessageBox.Show("已存在相同的标题，是否覆盖？", "消息提示", System.Windows.Forms.MessageBoxButtons.OKCancel);
                if (msgbox == DialogResult.OK)
                {
                    //str_sql = $"insert into jjrizhi values('{Settings.Default.huaming}','{DateTime.Now.ToString()}','{content}','{title}')";
                    str_sql = $"update jjrizhi set 内容='{content}',时间='{DateTime.Now.ToString()}' where 标题='{title}'";
                    num = mysqlhelper.ExecuteNonQuery(str_sql, null);
                    return num > 0 ? true : false;
                }
                return false;
            }








        }





    }
}
