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
            JJyijianInfo myinfo = new JJyijianInfo
            {
                _biaoti = tb_biaoti.Text,
                _fankuiren = JJLoginInfo._shiming,
                _fankuiduixiang = tb_fankuiduixiang.Text,
                _neirong = tb_neirong.Text,
                _chuangjianishijian = DateTime.Now.ToString()
            };
            //保存jjtonzhiinfo
            bool b = _mycontroller.SaveYijian(myinfo);
            if (b)
            {
                MessageBox.Show("保存成功！");
            }
            this.DialogResult = DialogResult.OK;
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
