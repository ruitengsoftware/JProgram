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

namespace WindowsFormsApp2.UC
{
    public partial class UCStep : UserControl
    {
        public UCStep()
        {
            InitializeComponent();

        }
        public UCStep(string str)
        {
            InitializeComponent();
            UIHelper.DrawRoundRect(lbl_text);

            lbl_text.Text = str;
        }

        private void UCStep_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Pb_left_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.leftenter;
        }

        private void Pb_left_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.leftlv;

        }

        private void Pb_right_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.rightenter;

        }

        private void Pb_right_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.rightlv;

        }

        private void Pb_left_Click(object sender, EventArgs e)
        {
           
            //获得父容器
            FlowLayoutPanel panel = this.Parent as FlowLayoutPanel;

            //获得当前index
            int index = panel.Controls.IndexOf(this);
            //调整当前index-1
            panel.Controls.SetChildIndex(this, index - 1);
        }

        private void Pb_right_Click(object sender, EventArgs e)
        {
            //获得父容器
            FlowLayoutPanel panel = this.Parent as FlowLayoutPanel;

            //获得当前index
            int index = panel.Controls.IndexOf(this);
            //调整当前index-1
            panel.Controls.SetChildIndex(this, index +1 );

        }

        private void lbl_text_Click(object sender, EventArgs e)
        {

            Label lbl = ((Label)sender);
            if (lbl.BackColor == Color.SteelBlue)
            {
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Black;
            }
            else
            {
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.SteelBlue;
            }
        }
    }
}
