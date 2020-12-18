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
        public UCTaskmsg()
        {
            InitializeComponent();
        }


        public UCTaskmsg(JJTaskInfo ti)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            lbl_renwuming.Text = ti._renwumingcheng;
            lbl_renwuleixing.Text = ti._leixing;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            _ui.DrawRoundRect((Control)sender);
        }
    }
}
