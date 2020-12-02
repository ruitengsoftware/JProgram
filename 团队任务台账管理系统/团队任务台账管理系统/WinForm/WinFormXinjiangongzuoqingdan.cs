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
    public partial class WinFormXinjiangongzuoqingdan : Form
    {
        public WinFormXinjiangongzuoqingdan()
        {
            InitializeComponent();
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        ControllerXinjiangongzuoqingdan _mycontroller = new ControllerXinjiangongzuoqingdan();
        private void lbl_queding_Click(object sender, EventArgs e)
        {
            //保存任务，构建一个任务对象，保存到数据库
            JJRenwu myrenwu = new JJRenwu() {
                _renwumingcheng = tb_renwumingcheng.Text,
                _chuangjianren = JJPerson._shiming,
                _zhubanren = tb_zhubanren.Text,
                _wanchengshijian = dtp_wanchengshijian.Value.ToString("yyyy年MM月dd日 hh:mm:ss"),
            _xiangxian=cbb_xiangxian.Text
            };

            _mycontroller.SaveGongzuoqingdan(myrenwu);
            this.DialogResult = DialogResult.OK;

        }
    }
}
