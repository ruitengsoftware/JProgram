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

        /// <summary>
        /// 信息类型，包括工作清单，通知公告，待办事项
        /// </summary>
        public string _msgtype = string.Empty;

        public UCMessage()
        {
            InitializeComponent();
        }
        UIHelper _ui = new UIHelper();
        public UCMessage(string stra,string strb,string strc)
        {
            InitializeComponent();
           
            this.Dock = DockStyle.Top;
            label1.Text = stra;
            label2.Text = strb;
            label3.Text = strc;

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
            if (this._msgtype.Equals("待办任务"))

            {
                JJchangguiInfo ci = _myc.GetChangguiInfo(label2.Text);
                WFchangguishixiang mywin = new WFchangguishixiang(ci);
                if (mywin.ShowDialog()==DialogResult.OK)
                {
                    //刷新数据
                }
            }
            if (this._msgtype.Equals("通知公告"))

            {
                JJTongzhiInfo ci = _myc.GetTongzhiInfo(label2.Text);
                WFtongzhigonggao mywin = new WFtongzhigonggao(ci);
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                }
            }
            if (this._msgtype.Equals("工作清单"))

            {
                JJchangguiInfo ci = _myc.GetChangguiInfo(label2.Text);
                WFchangguishixiang mywin = new WFchangguishixiang(ci);
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                }
            }











        }
    }
}
