using Renci.SshNet.Security.Cryptography.Ciphers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFfankui : Form
    {
        ControllerFankui mycontroller = new ControllerFankui();
        public Action updatedata;
        public WFfankui()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击提交反馈按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_tijiao_Click(object sender, EventArgs e)
        {
            //判断反馈名称，不许为空
            string mingcheng = tb_mingcheng.Text.Trim();
            string lianxifangshi = tb_lianxifangshi.Text.Trim();
            string duixiang = tb_duixiang.Text.Trim();
            string neirong = tb_neirong.Text.Trim();

            if (mingcheng.Equals(string.Empty))
            {
                MessageBox.Show("名称不能为空！");
                return;
            }
            //判断反馈名是否为重复，如果重复，提示，退出本方法
            bool b = mycontroller.ExistFankui(mingcheng);
            if (b)
            {
                MessageBox.Show("反馈名称已存在！");
                return;

            }
            //添加反馈名称，联系方式，对象，内容
            bool bb = mycontroller.InsertFankui(mingcheng, lianxifangshi, duixiang,neirong);

            //提示是否保存成功
            if (bb)
            {
                MessageBox.Show("提交反馈成功！");
            }
            //刷新父窗体

            updatedata();

            //dialog.result赋值
            this.DialogResult = DialogResult.OK;

        }

        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
