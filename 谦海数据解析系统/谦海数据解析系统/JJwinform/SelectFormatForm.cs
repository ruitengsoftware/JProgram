using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 谦海数据解析系统.JJmodel;

namespace 谦海数据解析系统.JJwinform
{
    public partial class SelectFormatForm : Form
    {
        public DirectoryInfo _dirInfo = null;
        public SelectFormatForm()
        {
            InitializeComponent();
        }

        private void pb_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_folder.Text = fbd.SelectedPath;
            }
        }
        /// <summary>
        /// 点击确定按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_queding_Click(object sender, EventArgs e)
        {
            _dirInfo = new DirectoryInfo(tb_folder.Text);
            //保存设置到userinfo的数据库个人信息中
            SystemInfo._userInfo._wjmbzh = cbb_wenjianming.Text;
            SystemInfo._userInfo._wjbzh = cbb_geshihua.Text;
            SystemInfo._userInfo._ccqx = cbb_chachong.Text;
            SystemInfo._userInfo._jcjx = cbb_jichujiexi.Text;
            SystemInfo._userInfo._nrjx = cbb_neirongjiexi.Text;
            SystemInfo._userInfo._dsjb = cbb_dashujuban.Text;
            SystemInfo.SaveUserInfo();
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 加载新建任务窗体事触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFormatForm_Load(object sender, EventArgs e)
        {
            var list=MyMethod.GetFormats("文件名标准化");
            cbb_wenjianming.Items.AddRange(list.ToArray());
            list = MyMethod.GetFormats("格式标准化");
            cbb_geshihua.Items.AddRange(list.ToArray());
            list = MyMethod.GetFormats("查重清洗");
            cbb_chachong.Items.AddRange(list.ToArray());
            list = MyMethod.GetFormats("基础解析");
            cbb_jichujiexi.Items.AddRange(list.ToArray());
            list = MyMethod.GetFormats("内容解析");
            cbb_neirongjiexi.Items.AddRange(list.ToArray());
            list = MyMethod.GetFormats("大数据版");
            cbb_dashujuban.Items.AddRange(list.ToArray());

            //将用户个人信息显示再界面上，上次的选择
            cbb_wenjianming.Text = SystemInfo._userInfo._wjmbzh;
            cbb_geshihua.Text = SystemInfo._userInfo._wjbzh;
            cbb_chachong.Text = SystemInfo._userInfo._ccqx;
            cbb_jichujiexi.Text = SystemInfo._userInfo._jcjx;
            cbb_neirongjiexi.Text = SystemInfo._userInfo._nrjx;
            cbb_dashujuban.Text = SystemInfo._userInfo._dsjb;


        }
        /// <summary>
        /// 点击取消按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
