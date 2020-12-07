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
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFchangguishixiang : Form
    {
        public WFchangguishixiang()
        {
            InitializeComponent();
        }

        public WFchangguishixiang(JJchangguiInfo myinfo)
        {
            InitializeComponent();
            tb_renwumingcheng.Text = myinfo._renwumingcheng;
            if (myinfo._jinjichengdu.Equals("普遍"))
            {
                rb_putong.Checked = true;
            }
            else if (myinfo._jinjichengdu.Equals("急件"))
            {
                rb_jijian.Checked = true;
            }
            else if (myinfo._jinjichengdu.Equals("特急"))
            {
                rb_jinji.Checked = true;
            }
            tb_jutiyaoqiu.Text = myinfo._jutiyaoqiu;
            tb_zerenren.Text = myinfo._zerenren;
            tb_yanshouren.Text = myinfo._yanshouren;
            dtp_shixian.Value = Convert.ToDateTime(myinfo._shixian);
            tb_jinzhan.Text = myinfo._jinzhanqingkuang;


        }

        Controllerwfxinjian mycontroller = new Controllerwfxinjian();
        private void btn_shanchu_Click(object sender, EventArgs e)
        {
            // //获得任务名称
            // string str_task = tb_renwumingcheng.Text;
            // //从数据库中删除这条记录
            //bool b= mycontroller.DeleteTask(str_task);
            // if (b) MessageBox.Show("删除任务成功！");


            this.Dispose();


        }

        private void btn_baocun_Click(object sender, EventArgs e)
        {
            string jinjichengdu = string.Empty;
            if (rb_jinji.Checked)
            {
                jinjichengdu = "特急";
            }
            if (rb_jijian.Checked)
            {
                jinjichengdu = "急件";
            }
            if (rb_putong.Checked)
            {
                jinjichengdu = "普通";
            }

            JJchangguiInfo ci = new JJchangguiInfo() {
                _renwumingcheng = tb_renwumingcheng.Text,
                _jinjichengdu = jinjichengdu,
                _jutiyaoqiu=tb_jutiyaoqiu.Text,
                _zerenren=tb_zerenren.Text,
                _yanshouren=tb_yanshouren.Text,
                _shixian=dtp_shixian.Value.ToString(),
                _jinzhanqingkuang=tb_jinzhan.Text,
            };
            //添加任务
            bool b=mycontroller.AddTask(ci);
            if (b) MessageBox.Show("添加任务成功！");
            this.DialogResult = DialogResult.OK;





        }
    }
}
