﻿using RuiTengDll;
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
    public partial class WFgongzuoqingdan : Form
    {
        public WFgongzuoqingdan()
        {
            InitializeComponent();
        }
        public WFgongzuoqingdan(JJQingdanInfo q)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            rb_a.Checked = q._qingzhonghuanji.Contains("A类") ? true : false;
            rb_b.Checked = q._qingzhonghuanji.Contains("B类") ? true : false;

            rb_c.Checked = q._qingzhonghuanji.Contains("C类") ? true : false;

            rb_d.Checked = q._qingzhonghuanji.Contains("D类") ? true : false;

            tb_renwumingcheng.Text = q._renwumingcheng;
            dtp_wanchengshijian.Value = Convert.ToDateTime(q._wanchengshijian);
            tb_beizhu.Text = q._beizhu;
            tb_jingyanjiaoxun.Text = q._jingyanjiaoxun;
            foreach (RadioButton rb in groupBox2.Controls)
            {
                if (rb.Text==q._qingzhonghuanji)
                {
                    rb.Checked = true;
                }
            }
        }
        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        ControllerXinjiangongzuoqingdan _mycontroller = new ControllerXinjiangongzuoqingdan();
        private void lbl_queding_Click(object sender, EventArgs e)
        {


            //保存任务，构建一个任务对象，保存到数据库
            JJQingdanInfo myrenwu = new JJQingdanInfo() {
                _renwumingcheng = tb_renwumingcheng.Text,
                _chuangjianren = JJLoginInfo._huaming,
                _wanchengshijian = dtp_wanchengshijian.Value.ToString("yyyy年MM月dd日 hh:mm:ss"),
              
                _chuangjianshijian = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss"),
                _beizhu=tb_beizhu.Text,
                _jingyanjiaoxun=tb_jingyanjiaoxun.Text,
                _zhuangtai="未处理"
            };
            if (rb_a.Checked)
            {
                myrenwu._qingzhonghuanji = "A类紧急且重要";
            }
            if (rb_b.Checked)
            {
                myrenwu._qingzhonghuanji = "B类紧急但不重要";
            }
            if (rb_c.Checked)
            {
                myrenwu._qingzhonghuanji = "C类不急但重要";
            }
            if (rb_d.Checked)
            {
                myrenwu._qingzhonghuanji = "D类不急且不重要";
            }




            //保存工作清单任务
          bool b=  _mycontroller.SaveGongzuoqingdan(myrenwu);
            if (b)
            {
                MessageBox.Show("清单已添加！");
           this.DialogResult = DialogResult.OK;

            }

        }

        private void WFgongzuoqingdan_Load(object sender, EventArgs e)
        {
            //tb_zhubanren.Text = JJLoginInfo._shiming;
        }

        private void rb_a_CheckedChanged(object sender, EventArgs e)
        {
            //获得选中的radiobutton的text
            if ((sender as RadioButton).Checked)
            {
                //保存到setting中
                Properties.Settings.Default.轻重缓急 = (sender as RadioButton).Text;
                Properties.Settings.Default.Save();
            }


        }
        UIHelper _ui = new UIHelper();
        private void lbl_quxiao_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);

        }

        private void lbl_queding_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void lbl_quxiao_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
    }
}
