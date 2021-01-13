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

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCwodeyunpan : UserControl
    {
        MySQLHelper _mysql = new MySQLHelper();
        public UCwodeyunpan()
        {
            InitializeComponent();
        }

        public List<JJFujianInfo> GetGongxiang()
        {
            List<JJFujianInfo> list = new List<JJFujianInfo>();
            string str = $"select * from jjdbrenwutaizhang.附件信息表 " +
                $"where 创建人='共享' and 删除=0";
            DataTable mydt = _mysql.ExecuteDataTable(str);
            foreach (DataRow dr  in mydt.Rows)
            {
                JJFujianInfo info = new JJFujianInfo() {
                    _wenjianming = dr["文件名"].ToString(),
                    _chuangjianren = dr["创建人"].ToString(),
                    _chuangjianshijian = dr["创建时间"].ToString(),
                    _quanlujing=dr["全路径"].ToString(),
                _xiazaicishu=Convert.ToInt32( dr["下载次数"].ToString())
                
                };
                list.Add(info);


            }
            return list;
        }

        public List<JJFujianInfo> GetGerenwenjian()
        {
            List<JJFujianInfo> list = new List<JJFujianInfo>();
            string str = $"select * from jjdbrenwutaizhang.附件信息表 " +
                $"where 删除=0 and 创建人='{JJLoginInfo._huaming}'";
            DataTable mydt = _mysql.ExecuteDataTable(str);
            foreach (DataRow dr in mydt.Rows)
            {
                JJFujianInfo info = new JJFujianInfo()
                {
                    _wenjianming = dr["文件名"].ToString(),
                    _chuangjianren = dr["创建人"].ToString(),
                    _chuangjianshijian = dr["创建时间"].ToString(),
                    _quanlujing = dr["全路径"].ToString(),
                    _xiazaicishu = Convert.ToInt32(dr["下载次数"].ToString())

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

            //更新按钮样式
            lbl_gongxiang.ForeColor = Color.Black;
            lbl_gongxiang.BackColor = Color.White;
            lbl_wodeshangchuan.ForeColor = Color.White;
            lbl_wodeshangchuan.BackColor = Color.FromArgb(64, 64, 64);

            //获得所有共享资料
            var list = GetGongxiang();
            //加载到Panelfujianzhong
            panel_fujian.Controls.Clear();
            foreach (JJFujianInfo s in list)
            {
                UCfujianInfo myuc = new UCfujianInfo(s) { Dock = DockStyle.Top };
                panel_fujian.Controls.Add(myuc);
            }

        }

        private void lbl_wodeshangchuan_Click(object sender, EventArgs e)
        {

            //更新按钮样式
            lbl_gongxiang.ForeColor = Color.White;
            lbl_gongxiang.BackColor = Color.FromArgb(64,64,64);

            //更新按钮样式
            lbl_wodeshangchuan.ForeColor = Color.Black;
            lbl_wodeshangchuan.BackColor = Color.White;

            //获得所有共享资料
            var list = GetGerenwenjian();
            //加载到Panelfujianzhong
            panel_fujian.Controls.Clear();

            foreach (JJFujianInfo s in list)
            {
                UCfujianInfo myuc = new UCfujianInfo(s) { Dock = DockStyle.Top };
                panel_fujian.Controls.Add(myuc);
            }

        }
    }
}
