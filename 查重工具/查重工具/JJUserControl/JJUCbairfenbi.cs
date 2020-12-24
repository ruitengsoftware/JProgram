using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 查重工具.JJModel;

namespace 查重工具.JJUserControl
{
    public partial class JJUCbairfenbi : UserControl
    {
        /// <summary>
        /// 百分比类
        /// </summary>
       public JJBaifenbi _myb = new JJBaifenbi();

        public JJUCbairfenbi()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tb_baifenbi_TextChanged(object sender, EventArgs e)
        {
            _myb.Percent = tb_baifenbi.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_morenlujing.Checked)
            {
                _myb.SavePath = string.Empty;
                tb_baocunlujing.Enabled = false;
            }
            else
            {
                tb_baocunlujing.Enabled = true;
            }

        }

        private void tb_baocunlujing_TextChanged(object sender, EventArgs e)
        {
            _myb.SavePath = tb_baocunlujing.Text;
        }
    }
}
