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
    public partial class WinFormRenwuxiangqing : Form
    {
        ControllerWfRenwuxiangqing _mycontroller = new ControllerWfRenwuxiangqing();
        public WinFormRenwuxiangqing()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void WinFormRenwuxiangqing_Load(object sender, EventArgs e)
        {

        }

        private void btn_gengxin_Click(object sender, EventArgs e)
        {
            //获得 任务名称，具体要求，分解，进展
            string mingcheng = tb_renwumingcheng.Text;
            string yaoqiu = tb_jutiyaoqiu.Text;
            string fenjie = tb_fenjie.Text;
            string jinzhan = tb_jinzhan.Text;
            string banliren = tb_banliren.Text;
            string yanshouren = tb_yanshouren.Text;
            bool b = _mycontroller.UpdateTask(mingcheng, yaoqiu, fenjie, jinzhan, banliren, yanshouren);
            //刷新数据
            int selectindex = dgv_data.SelectedRows[0].Index;
            UCdaiban_Load(null, null);
            dgv_data.Rows[0].Selected = false;
            dgv_data.Rows[selectindex].Selected = true;
            if (b) MessageBox.Show("更新数据成功！");
        }
    }
}
