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
    public partial class WFxinjian : Form
    {
        public WFxinjian()
        {
            InitializeComponent();
        }
        Controllerwfxinjian mycontroller = new Controllerwfxinjian();
        private void btn_shanchu_Click(object sender, EventArgs e)
        {
            //获得任务名称
            string str_task = tb_renwumingcheng.Text;
            //从数据库中删除这条记录
           bool b= mycontroller.DeleteTask(str_task);
            if (b) MessageBox.Show("删除任务成功！");





        }

        private void btn_baocun_Click(object sender, EventArgs e)
        {
            string renwumingcheng = tb_renwumingcheng.Text;
            string jinjichengdu = string.Empty;
            if (rb_jinji.Checked)
            {
                jinjichengdu = "紧急";
            }
            if (rb_jijian.Checked)
            {
                jinjichengdu = "急件";
            }
            if (rb_putong.Checked)
            {
                jinjichengdu = "普通";
            }
            string jutiyaoqiu = tb_jutiyaoqiu.Text;
            string fenjie = tb_fenjie.Text;
            string jinzhan = tb_jinzhan.Text;
            string shuifuze = tb_shuifuze.Text;
            string shuipizhun = tb_shuipizhun.Text;
            string zixunshui = tb_zixunshui.Text;
            string tongzhishui = tb_tongzhishui.Text;
            string shixian = dtp_shixian.Value.ToLongDateString();
            string beizhu = tb_beizhu.Text;
            
            bool b=mycontroller.AddTask(renwumingcheng, jinjichengdu, jutiyaoqiu, fenjie, jinzhan, shuifuze, shuipizhun, zixunshui, tongzhishui, shixian, beizhu);
            if (b) MessageBox.Show("添加任务成功！");





        }
    }
}
