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
using 团队任务台账管理系统.WinForm;
using System.Text.RegularExpressions;

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
            //带有文件名的全路径
            path = $"http://49.233.40.109/person/{JJLoginInfo._huaming}/{file}";
            //不带有文件名的服务器路径
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
    $"'{info._chuangjianshijian}','{info._quanlujing}',{info._xiazaicishu},0,'{string.Empty }','{info._leixing}')";

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
            if (_myinfo == null)
            {
                //判断文件是否存在，如果不存在上传，显示已上传，如果已经存在，直接显示已上传
                bool exist = ExistFile(path);
                lbl_wenjianming.Text = file;
                if (!exist)
                {
                    JJFujianInfo info = new JJFujianInfo()
                    {
                        _wenjianming = file,
                        _chuangjianren = JJLoginInfo._shiming,
                        _leixing = "共享",
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
                //共享文件可以看见垃圾桶,非共享文件可以
                if (!_myinfo._leixing.Equals("共享"))
                {
                    pb_shanchu.Visible = true;
                }
                //创建人上传的共享任务可以设置可见范围，显示眼睛
                if (JJLoginInfo._shiming.Equals(_myinfo._chuangjianren) && _myinfo._leixing.Equals("共享"))
                {
                    pb_kejian.Visible = true;
                }

            }

        }
        private void pb_shanchu_Click(object sender, EventArgs e)
        {

            //从数据库中删除本条,
            string str_sql = $"update jjdbrenwutaizhang.附件信息表 " +
                $"set 删除=1 " +
                $"where 文件名='{_myinfo._wenjianming}' and 创建人='{_myinfo._chuangjianren}'";
            _mysql.ExecuteNonQuery(str_sql);

            this.Dispose();
        }

        private async void lbl_xiazai_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 97-2003工作簿|*.xls|Excel 工作簿|*.xlsx|压缩文件(ZIP)|*.zip";
            sfd.FileName = Path.GetFileName(_myinfo._quanlujing);
            if (Path.GetExtension(_myinfo._quanlujing).Equals(".xls"))
            {
                sfd.Filter = "Excel 97-2003工作簿|*.xls";
            }
            if (Path.GetExtension(_myinfo._quanlujing).Equals(".xlsx"))
            {
                sfd.Filter = "Excel 工作簿|*.xlsx";


            }
            if (Path.GetExtension(_myinfo._quanlujing).Equals(".zip"))
            {
                sfd.Filter = "压缩文件(ZIP)|*.zip";

            }
            if (Path.GetExtension(_myinfo._quanlujing).Equals(".doc"))
            {
                sfd.Filter = "Word 97-2003文档|*.doc";

            }
            if (Path.GetExtension(_myinfo._quanlujing).Equals(".docx"))
            {
                sfd.Filter = "Word 文档|*.docx";

            }
            if (Path.GetExtension(_myinfo._quanlujing).Equals(".txt"))
            {
                sfd.Filter = "文本文件TXT|*.txt";

            }



            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lbl_info.Visible = true;
                lbl_info.Text = "正在下载……";
                await JJMethod.DownLoadFileAsync(_myinfo._quanlujing, sfd.FileName);
                lbl_info.Visible = false;

                MessageBox.Show("下载完成！");
            }
        }
        /// <summary>
        /// 点击可见按钮时触发的事件，保存可见人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_kejian_Click(object sender, EventArgs e)
        {
            //打开选择人员对话框，需要把当前的可见人员传进去
            List<string> list_person = Regex.Split(_myinfo._kejian, @"\|").ToList();
            WFperson mywin = new WFperson(list_person)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                _myinfo._kejian = string.Join("|", mywin.list_selected);
                //保存这个附件信息
                bool b = UpdateKejian(_myinfo);
                if (b)
                {
                    MessageBox.Show("附件可见人员已保存！");

                }
            }


        }
        /// <summary>
        /// 修改附件的可见范围
        /// </summary>
        /// <returns></returns>
        private bool UpdateKejian(JJFujianInfo info)
        {
            string str_sql = $"update jjdbrenwutaizhang.附件信息表 " +
                $"set 可见='{info._kejian}' " +
                $"where 文件名='{info._wenjianming}' and 创建人='{info._chuangjianren}' " +
                $"and 删除=0";
            int num = _mysql.ExecuteNonQuery(str_sql);
            return num > 0 ? true : false;
        }



    }
}
