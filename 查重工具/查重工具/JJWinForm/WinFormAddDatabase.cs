
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

namespace 查重工具.WinForm
{
    public partial class WinFormAddDatabase : Form
    {
        public string tablename = string.Empty;
        public string leixing = string.Empty;
        UIHelper uihelper = new UIHelper();
        public WinFormAddDatabase()
        {
            InitializeComponent();
        }

        private void Lbl_queding_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            tablename = tb_biaoming.Text;
            leixing = cbb_leixing.Text;
        }

        private void Lbl_queding_Paint(object sender, PaintEventArgs e)
        {
            uihelper.DrawRoundRect((Control)sender);
        }

        private void Lbl_queding_MouseEnter(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, -1);

        }

        private void Lbl_queding_MouseLeave(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, 1);

        }

        private void WinFormAddDatabase_Load(object sender, EventArgs e)
        {
            cbb_leixing.SelectedIndex = 0;
        }


    }
}
