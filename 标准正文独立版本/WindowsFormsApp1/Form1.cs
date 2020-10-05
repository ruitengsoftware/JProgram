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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UC.UCChachong ucchachong = null;

        UIHelper uihelper = new UIHelper();
        UC.UCShujuku ucshujuku = null;

        private void lbl_shujuku_Click(object sender, EventArgs e)
        {
            panel_bottom.Controls.Clear();
            if (ucshujuku == null)
            {
                ucshujuku = new UC.UCShujuku() { Dock = DockStyle.Fill };
            }
            uihelper.AddControl(panel_bottom, ucshujuku);
        }

        private void lbl_chachong_Click(object sender, EventArgs e)
        {
            panel_bottom.Controls.Clear();

            if (ucchachong==null)
            {
            ucchachong = new UC.UCChachong() { Dock = DockStyle.Fill };
            }
            uihelper.AddControl(panel_bottom,ucchachong);

        }

        private void lbl_chachong_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
            ((Control)sender).ForeColor = Color.Black;
        }

        private void lbl_shujuku_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Gray;
            ((Control)sender).ForeColor = Color.White;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_chachong_Click(null, null);
        }

        UC.UCShezhi _ucshezhi = null;
        private void Lbl_ruanjianshezhi_Click(object sender, EventArgs e)
        {
            panel_bottom.Controls.Clear();
            if (_ucshezhi == null)
            {
                _ucshezhi = new UC.UCShezhi() { Dock = DockStyle.Fill };
            }
            uihelper.AddControl(panel_bottom, _ucshezhi);
        }
    }
}
