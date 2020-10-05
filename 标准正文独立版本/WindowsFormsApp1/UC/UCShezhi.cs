using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.UC
{
    public partial class UCShezhi : UserControl
    {
        public UCShezhi()
        {
            InitializeComponent();
        }

        private void Tb_ip_TextChanged(object sender, EventArgs e)
        {
        }

        private void UCShezhi_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default._ip.Equals(string.Empty))
            {
                cbb_ip.SelectedIndex = 0;
            }
            else
            {
            cbb_ip.Text = Properties.Settings.Default._ip;

            }
        }

        private void Cbb_ip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._ip = cbb_ip.Text;
            Properties.Settings.Default.Save();
        }
    }
}
