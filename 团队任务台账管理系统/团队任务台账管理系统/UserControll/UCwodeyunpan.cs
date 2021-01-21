using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.Common;
using System.IO;
using System.Net;
using RuiTengDll;
using System.Text.RegularExpressions;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCwodeyunpan : UserControl
    {
        MySQLHelper _mysql = new MySQLHelper();

        bool _shareresult = true;//是否显示的为共享文件，如果个人文件赋值false
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public UCwodeyunpan()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获得共享文件
        /// </summary>
        /// <returns></returns>
        public List<JJFujianInfo> GetGongxiang(string kw)
        {
            List<JJFujianInfo> list = new List<JJFujianInfo>();
            string str = $"select * from jjdbrenwutaizhang.附件信息表 " +
                $"where 文件名 like '%{kw}%' and 类型='共享' and 删除=0";
            DataTable mydt = _mysql.ExecuteDataTable(str);
            foreach (DataRow dr in mydt.Rows)
            {
                JJFujianInfo info = new JJFujianInfo()
                {
                    _wenjianming = dr["文件名"].ToString(),
                    _chuangjianren = dr["创建人"].ToString(),
                    _chuangjianshijian = dr["创建时间"].ToString(),
                    _quanlujing = dr["全路径"].ToString(),
                    _xiazaicishu = Convert.ToInt32(dr["下载次数"].ToString()),
                    _leixing = dr["类型"].ToString(),
                    _kejian = dr["可见"].ToString()
                };
                list.Add(info);
            }
            return list;
        }
        /// <summary>
        /// 获得个人文件
        /// </summary>
        /// <returns></returns>
        public List<JJFujianInfo> GetGerenwenjian(string kw)
        {
            List<JJFujianInfo> list = new List<JJFujianInfo>();
            string str = $"select * from jjdbrenwutaizhang.附件信息表 " +
                $"where 文件名 like '%{kw}%' " +
                $"and 删除 = 0 and 创建人='{JJLoginInfo._huaming}' " +
                $"and 类型='个人'";
            DataTable mydt = _mysql.ExecuteDataTable(str);
            foreach (DataRow dr in mydt.Rows)
            {
                JJFujianInfo info = new JJFujianInfo()
                {
                    _wenjianming = dr["文件名"].ToString(),
                    _chuangjianren = dr["创建人"].ToString(),
                    _chuangjianshijian = dr["创建时间"].ToString(),
                    _quanlujing = dr["全路径"].ToString(),
                    _xiazaicishu = Convert.ToInt32(dr["下载次数"].ToString()),
                    _leixing = dr["类型"].ToString(),
                    _kejian = dr["可见"].ToString()

                };
                list.Add(info);
            }
            return list;
        }

        private void UCwodeyunpan_Load(object sender, EventArgs e)
        {
            lbl_gongxiang_Click(null, null);

        }
        /// <summary>
        /// 点击共享文件按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_gongxiang_Click(object sender, EventArgs e)
        {
            pb_shangchuangongxiang.Visible = true;
            pb_shangchuangeren.Visible = false;
            _shareresult = true;

            //更新按钮样式
            lbl_gongxiang.ForeColor = Color.White;
            lbl_gongxiang.BackColor = Color.Gray;
            lbl_wodeshangchuan.ForeColor = Color.Black;
            lbl_wodeshangchuan.BackColor = Color.White;

            //获得所有共享资料
            var list = GetGongxiang(tb_kw.Text);
            //加载到Panelfujianzhong
            panel_fujian.Controls.Clear();
            foreach (JJFujianInfo s in list)
            {
                //如果登陆者是创建人或者在可见范围内，就新增这个uc
                var listp = Regex.Split(s._kejian, @"\|").ToList();
                if (listp.Contains(JJLoginInfo._huaming) || s._chuangjianren.Equals(JJLoginInfo._huaming))
                {
                    UCfujianInfo myuc = new UCfujianInfo(s) { Dock = DockStyle.Top };
                    panel_fujian.Controls.Add(myuc);
                }
            }
        }

        private void lbl_wodeshangchuan_Click(object sender, EventArgs e)
        {
            pb_shangchuangongxiang.Visible = false;
            pb_shangchuangeren.Visible = true;

            _shareresult = false;
            //更新按钮样式
            lbl_gongxiang.ForeColor = Color.Black;
            lbl_gongxiang.BackColor = Color.White;
            lbl_wodeshangchuan.ForeColor = Color.White;
            lbl_wodeshangchuan.BackColor = Color.Gray;


            //获得所有共享资料
            var list = GetGerenwenjian(tb_kw.Text);
            //加载到Panelfujianzhong
            panel_fujian.Controls.Clear();

            foreach (JJFujianInfo s in list)
            {
                UCfujianInfo myuc = new UCfujianInfo(s) { Dock = DockStyle.Top };
                panel_fujian.Controls.Add(myuc);
            }

        }
        /// <summary>
        /// 点击放大镜按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_shareresult)
            {
                lbl_gongxiang_Click(null, null);
            }
            else
            {
                lbl_wodeshangchuan_Click(null, null);
            }


        }
        string uripath = $"http://49.233.40.109/共享资料";

        private async void pb_shangchuan_Click(object sender, EventArgs e)
        {
            pb_shangchuangongxiang.Visible = true;
            pb_shangchuangeren.Visible = false;

            //上传共享文件

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file = Path.GetFileName(ofd.FileName);

                JJFujianInfo info = new JJFujianInfo()
                {
                    _wenjianming = file,
                    _chuangjianren = "共享",
                    _quanlujing = $"{uripath}/{file}",
                    _chuangjianshijian = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    _xiazaicishu = 0,
                };



                //添加控件，显示正在上传
                UCfujianInfo myuc = new UCfujianInfo(info) { Dock = DockStyle.Top };
                panel_fujian.Controls.Add(myuc);

                Application.DoEvents();
                //开始上传
                myuc.lbl_info.Visible = true;
                myuc.lbl_info.Text = "正在上传……";
                Application.DoEvents();
                //UpSound_Request(uripath, ofd.FileName, "xxx.zip", progressBar1);
                await JJMethod.UpLoadFile(ofd.FileName, uripath, false);
                InsertFile(info);

                //上传完之后，不显示正在上传
                myuc.lbl_info.Text = string.Empty;
                myuc.lbl_info.Visible = false;




            }


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
        /// 上传录音文件
        /// </summary>
        /// <param name="address">文件上传到服务器的路径</param>
        /// <param name="fileNamePath">要上传的本地路径（全路径）</param>
        /// <param name="saveName">文件上传后的名称</param>
        /// <returns>成功返回1，失败返回2</returns>
        public int UpSound_Request(string address, string fileNamePath, string saveName, ProgressBar progressBar)
        {
            int returnValue = 0;
            //要上传的文件
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            //二进制对象
            BinaryReader r = new BinaryReader(fs);
            //时间戳
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");
            //请求的头部信息
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(saveName);
            sb.Append("\";");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            string strPostHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);
            // 根据uri创建HttpWebRequest对象   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(address));
            httpReq.Method = "POST";
            //对发送的数据不使用缓存   
            httpReq.AllowWriteStreamBuffering = false;
            //设置获得响应的超时时间（300秒）   
            httpReq.Timeout = 300000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            try
            {
                progressBar.Maximum = int.MaxValue;
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                //每次上传4k  
                int bufferLength = 409600;
                byte[] buffer = new byte[bufferLength]; //已上传的字节数   
                long offset = 0;         //开始上传时间   
                DateTime startTime = DateTime.Now;
                int size = r.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();         //发送请求头部消息   
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while (size > 0)
                {
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    //progressBar.Value = (int)(offset * (int.MaxValue / length));
                    //TimeSpan span = DateTime.Now - startTime;
                    //double second = span.TotalSeconds;
                    //labTime.Text = "已用时：" + second.ToString("F2") + "秒";
                    //if (second > 0.001)
                    //{
                    //    labSpeed.Text = "平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                    //}
                    //else
                    //{
                    //    labSpeed.Text = " 正在连接…";
                    //}
                    //labState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                    //labSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                    //Application.DoEvents();
                    size = r.Read(buffer, 0, bufferLength);
                }
                //添加尾部的时间戳   
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();
                //获取服务器端的响应   
                WebResponse webRespon = httpReq.GetResponse();
                Stream s = webRespon.GetResponseStream();
                //读取服务器端返回的消息  
                StreamReader sr = new StreamReader(s);
                String sReturnString = sr.ReadLine();
                s.Close();
                sr.Close();
                if (sReturnString == "Success")
                {
                    returnValue = 1;
                }
                else if (sReturnString == "Error")
                {
                    returnValue = 0;
                }
            }
            catch
            {
                returnValue = 0;
            }
            finally
            {
                fs.Close();
                r.Close();
            }
            return returnValue;
        }

        private void lbl_gongxiang_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private async void pb_shangchuangeren_Click(object sender, EventArgs e)
        {

            //上传共享文件

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file = Path.GetFileName(ofd.FileName);
                string uripath = $"http://49.233.40.109/person/{JJLoginInfo._huaming}";

                JJFujianInfo info = new JJFujianInfo()
                {
                    _wenjianming = file,
                    _chuangjianren = JJLoginInfo._huaming,
                    _quanlujing = $"{uripath}/{file}",
                    _chuangjianshijian = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    _xiazaicishu = 0,
                };



                //添加控件，显示正在上传
                UCfujianInfo myuc = new UCfujianInfo(info) { Dock = DockStyle.Top };
                panel_fujian.Controls.Add(myuc);

                Application.DoEvents();
                //开始上传
                myuc.lbl_info.Visible = true;
                myuc.lbl_info.Text = "正在上传……";
                Application.DoEvents();
                //UpSound_Request(uripath, ofd.FileName, "xxx.zip", progressBar1);
                await JJMethod.UpLoadFile(ofd.FileName, uripath, false);
                InsertFile(info);

                //上传完之后，不显示正在上传
                myuc.lbl_info.Text = string.Empty;
                myuc.lbl_info.Visible = false;

            }
        }
    }
}
