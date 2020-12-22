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
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.WinForm;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCMessage : UserControl
    {
        ControllerUCmsg _myc = new ControllerUCmsg();
        object task = new object();
        public UCMessage()
        {
            InitializeComponent();
        }
        UIHelper _ui = new UIHelper();
        public UCMessage(object o)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            task = o;
            if (o is JJQingdanInfo)
            {
                JJQingdanInfo info=o as JJQingdanInfo;
                //在uc上显示   象限  名称  完成时间
                this.lbl_xiangxian.Text = info._xiangxian;
                this.lbl_mingcheng.Text = info._renwumingcheng;
                this.lbl_wanchengshijian.Text = info._wanchengshijian;
            }
            if (o is JJTongzhiInfo)
            {
                JJTongzhiInfo info = o as JJTongzhiInfo;
                //在uc上显示  状态标题 发布时间
                this.lbl_xiangxian.Text = info._zhuangtai;
                this.lbl_mingcheng.Text = info._biaoti;
                this.lbl_wanchengshijian.Text = info._fabushijian;

            }
            if (o is JJchangguiInfo)
            {
                JJchangguiInfo info = o as JJchangguiInfo;
                this.lbl_xiangxian.Text = info._jinjichengdu;
                this.lbl_mingcheng.Text = info._renwumingcheng;
                this.lbl_wanchengshijian.Text = info._shixian ;

            }




        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            _ui.DrawRoundRect((Control)sender);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.SteelBlue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.DimGray;
        }
        /// <summary>
        /// 点击内容按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            //判断uc的类型，工作清单，通知公告，待办任务
            if (task is JJchangguiInfo)

            {
                JJTaskInfo ci = _myc.GetChangguiInfo(lbl_mingcheng.Text);
                WFchangguishixiang mywin = new WFchangguishixiang();
                if (mywin.ShowDialog()==DialogResult.OK)
                {
                    //刷新数据
                }
            }
            if (task is JJTongzhiInfo)

            {
                JJTongzhiInfo ci = _myc.GetTongzhiInfo(lbl_mingcheng.Text);
                WFtongzhigonggao mywin = new WFtongzhigonggao(ci);
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                }
            }
            if (task is JJQingdanInfo)

            {
                JJQingdanInfo ci = _myc.GetQingdanInfo(lbl_mingcheng.Text);
                WFgongzuoqingdan mywin = new WFgongzuoqingdan(ci);
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                }
            }











        }
    }
}
