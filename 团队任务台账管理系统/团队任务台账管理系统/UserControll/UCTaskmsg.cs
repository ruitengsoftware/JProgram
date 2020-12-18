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

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCTaskmsg : UserControl
    {
        UIHelper _ui = new UIHelper();
        public UCTaskmsg()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            _ui.DrawRoundRect((Control)sender);
        }
    }
}
