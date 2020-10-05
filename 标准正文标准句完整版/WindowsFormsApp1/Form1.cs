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
using WindowsFormsApp1.Controller;

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
        private void lbl_shujuku_Click(object sender, EventArgs e)
        {
            panel_bottom.Controls.Clear();
            UC.UCShujuku myuc = new UC.UCShujuku() { Dock = DockStyle.Fill };
            uihelper.AddControl(panel_bottom,myuc);
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
        
        private void Button1_Click(object sender, EventArgs e)
        {
            ControllerClickhouse mycontroller = new ControllerClickhouse();
            var dt = mycontroller.GetDataFromTable("select * from rt1");
        }
    }
}
