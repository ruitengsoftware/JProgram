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
            lbl_renwuming.Text = ti._mingcheng;
            lbl_renwuleixing.Text = ti._leixing;
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
            _ui.DrawRoundRect((Control)sender);
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

            ////获得任务名称，根据名称获得datatable
            //DataTable dt = _myc.GetTaskInfo(lbl_renwuming.Text);


            ////获得任务jjtaskinfo
            //JJTaskInfo ti = new JJTaskInfo()
            //{
            //    _mingcheng = dt.Rows[dt.Rows.Count - 1]["名称"].ToString(),
            //    _leixing = dt.Rows[dt.Rows.Count - 1]["类型"].ToString(),
            //    _fuzeren = dt.Rows[dt.Rows.Count - 1]["负责人"].ToString(),
            //    _canyuren = dt.Rows[dt.Rows.Count - 1]["参与人"].ToString(),
            //    _zhuangtai = dt.Rows[dt.Rows.Count - 1]["状态"].ToString(),
            //    _xiangqing = dt.Rows[dt.Rows.Count - 1]["详情"].ToString(),
            //    _chuangjianren = dt.Rows[dt.Rows.Count - 1]["创建人"].ToString(),
            //    _chuangjianshijian = dt.Rows[dt.Rows.Count - 1]["创建时间"].ToString(),
            //    _duqushijian = dt.Rows[dt.Rows.Count - 1]["读取时间"].ToString(),
            //    _shixian = dt.Rows[dt.Rows.Count - 1]["时限"].ToString(),
            //    _jinjichengdu = dt.Rows[dt.Rows.Count - 1]["紧急程度"].ToString()
            //};

            //弹出任务信息窗体，在split右侧加载uc
            UCTaskInfo myuc = new UCTaskInfo(myti);
            myuc._closepanel = _closepanel;
            myuc._updatedata = _updatedata;
            _p.Controls.Clear();
            _p.Controls.Add(myuc);
            a();
            //判断未读任务数量，如果是0，要取消主界面我的任务右侧的红点

            int num = _myc.GetWeiduTaskNum();
            if (num==0)
            {
            (this.ParentForm as Form1).pb_newtask.Visible = false;

            }





        }
    }
}
