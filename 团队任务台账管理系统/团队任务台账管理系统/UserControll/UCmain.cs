using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCmain : UserControl
    {
        public UCmain()
        {
            InitializeComponent();
        }

        private void btn_daiban_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCdaiban uc_daiban = new UCdaiban();
            uc_daiban.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_daiban);
            
        }

        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCxinjian uc_xinjian = new UCxinjian();
            uc_xinjian.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_xinjian);

        }

        private void btn_tuandui_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCtuandui uc_tuandui = new UCtuandui();
            uc_tuandui.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_tuandui);

        }

        private void btn_rizhi_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCrizhi uc_rizhi = new UCrizhi();
            uc_rizhi.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_rizhi);
        }

        private void btn_fankui_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(new UCfankui() { Dock = DockStyle.Fill }); ;
        }

        private void btn_xiaoxiang_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();

            parent.Controls.Add(new UCxiaoxiang() { Dock = DockStyle.Fill }); ;

        }

        private void btn_shouquan_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();

            parent.Controls.Add(new UCshouquan() { Dock = DockStyle.Fill }); ;

        }
    }
}
