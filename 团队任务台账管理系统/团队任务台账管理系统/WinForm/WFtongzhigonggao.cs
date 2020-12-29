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
    public partial class WFtongzhigonggao : Form
    {

        ControllerWFtongzhigonggao _mycontroller = new ControllerWFtongzhigonggao();
        public WFtongzhigonggao()
        {
            InitializeComponent();
        }

        public WFtongzhigonggao(JJTongzhiInfo ti)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            tb_biaoti.Text = ti._biaoti;
            tb_wenhao.Text = ti._qianfaren;
            tb_neirong.Text = ti._neirong;




        }



        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label5_Click(object sender, EventArgs e)
        {
            //构造一个jjtongzhiinfo
            JJTongzhiInfo myinfo = new JJTongzhiInfo()
            {
                _biaoti = tb_biaoti.Text,
                _qianfaren = tb_wenhao.Text,
                _neirong = tb_neirong.Text,
                _qingzhonghuanji=
                
             



            };
            //保存jjtonzhiinfo
            bool b = _mycontroller.SaveTongzhi(myinfo);
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

        private void WFtongzhigonggao_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
