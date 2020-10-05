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

namespace Common.WinForm
{
    public partial class UCDatabase : UserControl
    {
        UIHelper uihelper = new UIHelper();
        public UCDatabase()
        {
            InitializeComponent();
        }
        public UCDatabase(string str)
        {
            InitializeComponent();
            lbl_dbname.Text = str;
        }
        private void Pb_delete_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Pb_right_Click(object sender, EventArgs e)
        {
            uihelper.MoveControl((FlowLayoutPanel)((Control)sender).Parent.Parent.Parent, ((Control)sender).Parent.Parent, 1);
        }

        private void Pb_left_Click(object sender, EventArgs e)
        {
            uihelper.MoveControl((FlowLayoutPanel)((Control)sender).Parent.Parent.Parent,((Control)sender).Parent.Parent, -1);

        }

        private void Pb_delete_MouseEnter(object sender, EventArgs e)
        {
            //((PictureBox)sender).Image = Properties.Resources.deleteen;
        }

        private void Pb_delete_MouseLeave(object sender, EventArgs e)
        {
           // ((PictureBox)sender).Image = Properties.Resources.deletelv;

        }
    }
}
