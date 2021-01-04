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
using 团队任务台账管理系统.UserControll;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFokrshixiang : Form
    {
        ControllerOkrshixiang _mycontroller = new ControllerOkrshixiang();

        public WFokrshixiang()
        {
            InitializeComponent();
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_xinzeng_Click(object sender, EventArgs e)
        {

            int index = panel_my.Controls.Count;

            //构造一个ucokr
            UCchengguo myuc = new UCchengguo(index+1);
            myuc.Dock = DockStyle.Top;

            //添加到panel_my中
            panel_my.Controls.Add(myuc);
            panel_my.Controls.SetChildIndex(myuc, 0);
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            //构造okrinfo
            JJOkrInfo myokr = new JJOkrInfo();
            myokr._renwumingcheng = tb_renwumingcheng.Text;
            if (rb_putong.Checked)
            {
                myokr._jinjichengdu = "普通";

            }
            else if (rb_jinji.Checked)
            {
                myokr._jinjichengdu = "急件";

            }
            myokr._mubiao = tb_mubiao.Text;
            List<JJchengguoInfo> list = new List<JJchengguoInfo>();
            foreach (UCchengguo item in panel_my.Controls)
            {
                JJchengguoInfo jjchengguoinfo = new JJchengguoInfo();
                jjchengguoinfo._guanjianchengguo = item.tb_guanjianchengguo.Text;
                jjchengguoinfo._zerenren = item.tb_zerenren.Text;
                jjchengguoinfo._yanshouren = item.tb_yanshouren.Text;
                jjchengguoinfo._shixian = item.tb_shixian.Text;
                jjchengguoinfo._jinzhanqingkuang = item.tb_jinzhanqingkuang.Text;
                list.Add(jjchengguoinfo);
            }
            myokr._chengguoji._list_chengguo=list;


            //保存信息
           bool b= _mycontroller.SaveOkrshixiang(myokr);
            if (b)
            {
            MessageBox.Show("保存okr事项成功！");
            this.DialogResult = DialogResult.OK;

            }


        }
    }
}
