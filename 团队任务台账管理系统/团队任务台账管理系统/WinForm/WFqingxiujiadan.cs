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
            JJqingjiaInfo myinfo = new JJqingjiaInfo()
            {
                _shenqignren = JJLoginInfo._shiming,
                _shiyou = tb_shiyou.Text,
                _kaishishijian = dtp_start.Value.ToString(),
                _jieshushijian = dtp_end.Value.ToString(),
                _weituoduixiang = tb_weituoren.Text,
                _shenheyijian = tb_shenheyijian.Text

            };

            //保存
            bool b = _mycontroller.SaveQingxiujia(myinfo);
            if (b)
            {
                MessageBox.Show("保存成功!");
                this.DialogResult = DialogResult.OK;

            }

        }
    }
}
