using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFqingxiujiadan : Form
    {
        ControllerWFqingxiujia _mycontroller = new ControllerWFqingxiujia();
        JJTaskInfo _info = new JJTaskInfo();
        public WFqingxiujiadan()
        {
            InitializeComponent();
        }
        public WFqingxiujiadan(JJTaskInfo ji)
        {
            InitializeComponent();
            _info = ji;
            if (!JJLoginInfo._huaming.Equals(_info._chuangjianren))
            {
                tb_shiyou.Enabled = false;
                panel1.Enabled = false;
                tlp_shijian.Enabled = false;
                tb_qingjaitianshu.Enabled = false;
                tb_weituoren.Enabled = false;
                tb_xiaojiaqingkuang.Enabled = false;

            }





        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            //构造qingjaiinfo
            JJTaskInfo myinfo = new JJTaskInfo()
            {
                _shiyou = tb_shiyou.Text,
                _jinjichengdu = rb_putong.Checked ? "普通" : "紧急",
                _qingjiatianshu = Convert.ToInt32(tb_qingjaitianshu.Text),
                _qizhishijian = $"{dtp_start.Value.ToString()}|{dtp_end.Value.ToString()}",
                _weituoduixiang=tb_weituoren.Text,
                _shenherenyuan=tb_shenherenyuan.Text,
                _shenheyijian=tb_shenheyijian.Text,
               _xiaojiaqingkuang=tb_xiaojiaqingkuang.Text,
                 _chuangjianshijian = DateTime.Now.ToString(),
                _chuangjianren = JJLoginInfo._huaming,
                _leixing = "常规事项",
                _zhuangtai = "保存"

            };

            //保存
            bool b = _mycontroller.SaveQingxiujia(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null, null);

                MessageBox.Show("保存成功!");
                this.DialogResult = DialogResult.OK;

            }

        }
        /// <summary>
        /// 点击发送办理按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label10_Click(object sender, EventArgs e)
        {
            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _shiyou = tb_shiyou.Text,
                _jinjichengdu = rb_putong.Checked ? "普通" : "紧急",
                _qingjiatianshu = Convert.ToInt32(tb_qingjaitianshu.Text),
                _qizhishijian = $"{dtp_start.Value.ToString()}|{dtp_end.Value.ToString()}",
                _weituoduixiang = tb_weituoren.Text,
                _shenherenyuan = tb_shenherenyuan.Text,
                _shenheyijian = tb_shenheyijian.Text,
                _xiaojiaqingkuang = tb_xiaojiaqingkuang.Text,
                _fasongshijian = DateTime.Now.ToString(),
                _fasongren = JJLoginInfo._huaming,
                _leixing = "请休假单",
                _zhuangtai = "未读"

            };            
            //拆解反馈对象，对每一个对象，向任务信息表中插入一条jjtaskinfo
            bool b = _mycontroller.FasongBanli(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null, null);

                MessageBox.Show("发送办理成功！");
            }

        }

        private void pb_person_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_weituoren.Text = string.Join(",", mywin.list_selected);
            }

        }

        private void pb_person2_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_shenherenyuan.Text = string.Join(",", mywin.list_selected);
            }

        }
        UIHelper _ui = new UIHelper();
        private void lbl_baocun_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void lbl_baocun_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void lbl_baocun_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
    }
}
