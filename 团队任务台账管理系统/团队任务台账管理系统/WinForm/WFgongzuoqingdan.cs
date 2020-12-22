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

            tb_renwumingcheng.Text = q._renwumingcheng;
            cbb_xiangxian.Text = q._xiangxian;
            tb_zhubanren.Text = q._zhubanren;
            dtp_wanchengshijian.Value = Convert.ToDateTime(q._wanchengshijian);
            tb_beizhu.Text = q._beizhu;
         

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
                _chuangjianren = JJLoginInfo._shiming,
                _zhubanren = tb_zhubanren.Text,
                _wanchengshijian = dtp_wanchengshijian.Value.ToString("yyyy年MM月dd日 hh:mm:ss"),
                _xiangxian = cbb_xiangxian.Text,
                _chuangjianshijian = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss"),
                _beizhu=tb_beizhu.Text
            };
            //保存工作清单任务
            _mycontroller.SaveGongzuoqingdan(myrenwu);
            this.DialogResult = DialogResult.OK;

        }

        private void WFgongzuoqingdan_Load(object sender, EventArgs e)
        {
            tb_zhubanren.Text = JJLoginInfo._shiming;
        }
    }
}
