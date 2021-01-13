using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;
using MySql.Data.MySqlClient;
using RuiTengDll;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCfujianInfo : UserControl
    {

        MySQLHelper _mysql = new MySQLHelper();

        public UCfujianInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 文件名
        /// </summary>
       public string file;
        /// <summary>
        /// 服务器文件全名
        /// </summary>
       public string path;
        /// <summary>
        /// 服务器目录
        /// </summary>
       public string uripath;
       public string _filename;//完整的文件本地路径


        public JJFujianInfo _myinfo = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename">文件的本地全路径</param>
        public UCfujianInfo(string filename)
        {
            InitializeComponent();
            _filename = filename;
            //获得file的文件名和登录人员花名
           file = Path.GetFileName(filename);
            //组成服务器名
            path = $"http://49.233.40.109/person/{JJLoginInfo._huaming}/{file}";
            uripath = $"http://49.233.40.109/person/{JJLoginInfo._huaming}/";
        }

        public UCfujianInfo(JJFujianInfo info)
        {
            InitializeComponent();
            _myinfo = info;

        }
        /// <summary>
        /// 判断文件名是否存在于服务器
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool ExistFile(string filename)
        {
            string str_sql = $"select count(*) from jjdbrenwutaizhang.附件信息表 where 删除=0 and 全路径=@全路径";
            int num = Convert.ToInt32(_mysql.ExecuteScalar(str_sql, new MySqlParameter("@全路径", filename)));
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 判断文件名是否存在于服务器
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool InsertFile(JJFujianInfo info)
        {
            
                        string str_sql = $"insert into jjdbrenwutaizhang.附件信息表 values('{info._wenjianming}','{info._chuangjianren}'," +
                $"'{info._chuangjianshijian}','{info._quanlujing}',{info._xiazaicishu},0)";

            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 点击垃圾桶按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UCfujianInfo_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private async void UCfujianInfo_Load(object sender, EventArgs e)
        {
            if (_myinfo==null)
            {
            //判断文件是否存在，如果不存在上传，显示已上传，如果已经存在，直接显示已上传
            bool exist = ExistFile(path);
            lbl_wenjianming.Text = file;
               

            if (!exist)
            {
                JJFujianInfo info = new JJFujianInfo()
                {
                    _wenjianming = file,
                    _chuangjianren = JJLoginInfo._huaming,
                    _quanlujing = path,
                    _chuangjianshijian = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    _xiazaicishu = 0,
                };
                InsertFile(info);
                lbl_info.Text = "正在上传……";
                await JJMethod.UpLoadFile(_filename, uripath, false);
            }
            lbl_info.Text = "已上传!";

            }
            else
            {
                lbl_wenjianming.Text = _myinfo._wenjianming;
                lbl_chuangjianren.Text = _myinfo._chuangjianren;
                lbl_chuangjianren.Visible = true;
                lbl_shijian.Text = _myinfo._chuangjianshijian;
                lbl_shijian.Visible = true;
                lbl_xiazai.Visible = true;
                lbl_info.Visible = false;
                pb_guanbi.Visible = false;
                pb_shanchu.Visible = true;
            }

        }
    }
}
