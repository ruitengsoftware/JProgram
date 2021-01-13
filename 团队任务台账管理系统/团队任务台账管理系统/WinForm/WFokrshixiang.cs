using Newtonsoft.Json;
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
using 团队任务台账管理系统.UserControll;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFokrshixiang : Form
    {
        ControllerOkrshixiang _mycontroller = new ControllerOkrshixiang();
        JJTaskInfo _info = new JJTaskInfo();


        public WFokrshixiang() {
            InitializeComponent();
        }


        public WFokrshixiang(JJTaskInfo ji)
        {
            InitializeComponent();
            _info = ji;
            //加载信息到窗体
            tb_renwumingcheng.Text = _info._mingcheng;
            rb_putong.Checked = _info._jinjichengdu.Equals("普通") ? true : false;
            rb_jinji.Checked = _info._jinjichengdu.Equals("紧急") ? true : false;
            tb_mubiao.Text = _info._mubiao;
            tb_zongtiyanshouren.Text = _info._zongtiyanshouren;
            JJchengguoji jc = JsonConvert.DeserializeObject<JJchengguoji>(_info._chengguoji);
            for (int i = 0; i < jc._list_chengguo.Count; i++)
            {
                var item = jc._list_chengguo[i];
                UCchengguo myuc = new UCchengguo(item);
                panel_my.Controls.Add(myuc);

            }

           //判断登录信息，创建人是否等于登录人,如果不是，任务任务名称，紧急程度，任务具体要求，上传附件，时限不可用
           if (!JJLoginInfo._huaming.Equals(_info._fasongren))
           {
               tb_renwumingcheng.Enabled = false;
                flp_jinjichengdu.Enabled = false;
                tb_mubiao.Enabled = false;
                tb_zongtiyanshouren.Enabled = false;
                tlp_chengguoji.Enabled = false;
                panel_my.Enabled = false;
           }


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
            List<JJchengguoInfo> list = new List<JJchengguoInfo>();
            foreach (UCchengguo item in panel_my.Controls)
            {
                list.Add(item.myinfo);
            }
            //序列化chengguoji
            JJchengguoji chengguoji = new JJchengguoji() { 
            _list_chengguo=list};

            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _mingcheng = tb_renwumingcheng.Text,
                _mubiao = tb_mubiao.Text,
                _zongtiyanshouren = tb_zongtiyanshouren.Text,
                _chuangjianshijian = DateTime.Now.ToString(),
                _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                _chuangjianren = JJLoginInfo._huaming,
                _leixing = "OKR事项",
                _zhuangtai = "保存",
                _chengguoji = JsonConvert.SerializeObject(chengguoji)
                
            };

            //保存信息
            bool b = _mycontroller.SaveOkrshixiang(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null, null);

                MessageBox.Show("保存okr事项成功！");
            //this.DialogResult = DialogResult.OK;

            }


        }

        private void lbl_fasongbanli_Click(object sender, EventArgs e)
        {
            List<JJchengguoInfo> list = new List<JJchengguoInfo>();
            foreach (UCchengguo item in panel_my.Controls)
            {
                list.Add(item.myinfo);
            }
            //序列化chengguoji
            JJchengguoji chengguoji = new JJchengguoji()
            {
                _list_chengguo = list
            };

            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _mingcheng = tb_renwumingcheng.Text,
                _mubiao = tb_mubiao.Text,
                _zongtiyanshouren = tb_zongtiyanshouren.Text,
                _fasongshijian = DateTime.Now.ToString(),
              
                _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                _fasongren = JJLoginInfo._huaming,
                _leixing = "OKR事项",
                _zhuangtai = "未读",
                _chengguoji = JsonConvert.SerializeObject(chengguoji)
            };           
            bool b = _mycontroller.FasongBanli(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null,null) ;
                MessageBox.Show("发送办理成功！");
            }
        }

        private void pb_person_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson() { 
            StartPosition=FormStartPosition.CenterParent
            };
            if (mywin.ShowDialog()==DialogResult.OK)
            {
                tb_zongtiyanshouren.Text = string.Join(",", mywin.list_selected);
            }
        }

        private void lbl_quxiao_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void lbl_quxiao_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void lbl_quxiao_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
    }
}
