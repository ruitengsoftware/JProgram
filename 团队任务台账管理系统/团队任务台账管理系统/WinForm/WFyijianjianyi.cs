using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFyijianjianyi : Form
    {
        ControllerWFyijian _mycontroller = new ControllerWFyijian();
        JJTaskInfo _info = new JJTaskInfo();
        public WFyijianjianyi()
        {
            InitializeComponent();
        }
        public WFyijianjianyi(JJTaskInfo ji)
        {
            InitializeComponent();
            _info = ji;
            if (!JJLoginInfo._huaming.Equals(_info._chuangjianren))
            {
                tb_biaoti.Enabled = false;
                p_jinjichengdu.Enabled = false;
                tb_neirong.Enabled = false;
            }


        }
        private void lbl_baocun_Click(object sender, EventArgs e)
        {


            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _biaoti = tb_biaoti.Text,
                _fankuiren = JJLoginInfo._huaming,
                _fankuiduixiang = tb_fankuiduixiang.Text,
                _neirong = tb_neirong.Text,
                _chuangjianshijian = DateTime.Now.ToString(),
                _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                _chuliyijian = tb_chuliyijian.Text,
                _chuangjianren = JJLoginInfo._huaming,
                _leixing = "意见建议",
                _zhuangtai = "保存"

            };
            //保存jjtonzhiinfo
            bool b = _mycontroller.SaveYijian(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null, null);

                MessageBox.Show("保存成功！");
            }
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pb_selectperson_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson();
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_fankuiduixiang.Text = string.Join(",", mywin.list_selected);
            }
        }
        /// <summary>
        /// 点击发送办理按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_fasongbanli_Click(object sender, EventArgs e)
        {
            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _biaoti = tb_biaoti.Text,
                _fasongren = JJLoginInfo._huaming,
                _fankuiduixiang = tb_fankuiduixiang.Text,
                _neirong = tb_neirong.Text,
                _fasongshijian = DateTime.Now.ToString(),
                _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                _chuliyijian = tb_chuliyijian.Text,
                _leixing = "意见建议",
                _zhuangtai = "未读"

            };            //拆解反馈对象，对每一个对象，向任务信息表中插入一条jjtaskinfo
            bool b=_mycontroller.FasongBanli(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null, null);

                MessageBox.Show("发送办理成功！");
            }
        }
    }
}
