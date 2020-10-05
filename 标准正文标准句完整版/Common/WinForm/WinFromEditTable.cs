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

namespace Common.WinForm
{
    public partial class WinFromEditTable : Form
    {
        public string table0 = string.Empty;
        public string table1 = string.Empty;
        UIHelper uihelper = new UIHelper();
        public WinFromEditTable()
        {
            InitializeComponent();
        }
        public WinFromEditTable(string table)
        {
            InitializeComponent();
            table0 = table;
            tb_oldname.Text = table;
            tb_oldname.ReadOnly = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            table1 = tb_biaoming.Text;
        }

        private void Lbl_queding_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lbl_queding_Paint(object sender, PaintEventArgs e)
        {
            uihelper.DrawRoundRect((Control)sender);
        }

        private void Lbl_queding_MouseEnter(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, new Padding(m - 1));

        }

        private void Lbl_queding_MouseLeave(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, new Padding(m + 1));

        }
    }
}
