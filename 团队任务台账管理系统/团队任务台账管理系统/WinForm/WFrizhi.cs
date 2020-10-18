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
    public partial class WFrizhi : Form
    {
        ControllerWFrizhi mycontroller = new ControllerWFrizhi();
        public delegate void MethodDelegate();
        public MethodDelegate update;
        public WFrizhi()
        {
            InitializeComponent();

        }

        private void WFrizhi_Load(object sender, EventArgs e)
        {
            //给标题赋值为当前时间
            tb_biaoti.Text = DateTime.Now.ToString("");
            //给内容赋值
            rtb_neirong.Text = "在此写入内容";

        }

        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_qingkong_Click(object sender, EventArgs e)
        {
            rtb_neirong.Clear();
        }
        private void btn_baocun_Click(object sender, EventArgs e)
        {
            bool b = mycontroller.BaocunRizhi(tb_biaoti.Text, rtb_neirong.Text);
            if (b)
            {
                update();
                MessageBox.Show("保存日志成功！");
            }
        }
    }
}
