using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuiTengDll;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCTaskmsg : UserControl
    {
        UIHelper _ui = new UIHelper();
        public Panel _p = new Panel();//存放uctaskinfo的容器
        ControllerUCmessage _myc = new ControllerUCmessage();
        public Action a = null;
        public Action _closepanel = null;
        public Action _updatedata = null;
        JJTaskInfo myti = new JJTaskInfo();
        public UCTaskmsg()
        {
            InitializeComponent();
        }


        public UCTaskmsg(JJTaskInfo ti)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            myti = ti;
            string leixing = string.Empty;
            if (ti._leixing.Equals("OKR事项"))
            {
                leixing = "OKR";
                lbl_renwuming.Text = ti._mingcheng;

            }
            else if (ti._leixing.Equals("常规事项"))
            {
                leixing = "事务";
                lbl_renwuming.Text = ti._mingcheng;

            }
            else if (ti._leixing.Equals("请休假单"))
            {
                leixing = "假单";
                lbl_renwuming.Text = ti._shiyou;

            }
            else if (ti._leixing.Equals("意见建议"))
            {
                leixing = "建言";
                lbl_renwuming.Text = ti._mubiao;

            }

            lbl_renwuleixing.Text = leixing;
            try
            {
                lbl_shixian.Text = Convert.ToDateTime(ti._shixian).ToString("yyyy-MM-dd");

            }
            catch { }
            if (myti._zhuangtai.Equals("未读"))
            {
                pb_weidu.Visible = true;
            }
            else
            {
                pb_weidu.Visible = false;
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }
        /// <summary>
        /// 点击任务名时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_renwuming_Click(object sender, EventArgs e)
        {
            //如果myti的状态是未读，就把状态变成未处理，然后让信封消失
            if (myti._zhuangtai.Equals("未读"))
            {
                pb_weidu.Visible = false;
                myti._zhuangtai = "未处理";
                _myc.UpdateZhuangtai(myti);
            }

            //弹出任务信息窗体，在split右侧加载uc
            UCTaskInfo myuc = new UCTaskInfo(myti);
            myuc._closepanel = _closepanel;
            myuc._updatedata = _updatedata;
            _p.Controls.Clear();
            _p.Controls.Add(myuc);
            a();
            //判断未读任务数量，如果是0，要取消主界面我的任务右侧的红点

            int num = JJLoginInfo.GetWeiduTaskNum();
            if (num > 0)
            {
               ( this.ParentForm as Form1). lbl_newtask.Visible = true;
                (this.ParentForm as Form1).btn_woderenwu.Width = 65;

                (this.ParentForm as Form1). lbl_newtask.Text = $"{num}";
            }
            else
            {
                (this.ParentForm as Form1).lbl_newtask.Visible = false;
                (this.ParentForm as Form1).btn_woderenwu.Width = 94;

            }





        }

        private void lbl_shixian_Click(object sender, EventArgs e)
        {

        }

        private void lbl_renwuleixing_Click(object sender, EventArgs e)
        {

        }
    }
}
