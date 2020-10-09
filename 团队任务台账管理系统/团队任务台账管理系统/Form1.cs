using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.UserControll;

namespace 团队任务台账管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //UserControl myuc = new UserControl();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 625;
            UCdenglu ucdenglu = new UCdenglu();
            ucdenglu.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(ucdenglu);
            this.splitContainer1.Panel1Collapsed = true;
        }

        private void pb_home_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            UCmain uc_main = new UCmain();
            uc_main.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(uc_main);
        }
    }
}
