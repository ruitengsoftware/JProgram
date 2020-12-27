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

        public JJUCbairfenbi(JJBaifenbi b)
        {
            InitializeComponent();
            tb_baifenbia.Text = b.PercentA.ToString();
            tb_baifenbib.Text = b.PercentB.ToString();
            cbb_leixing.Text = b.Leixing;
                tb_baocunlujing.Text = b.SavePath;

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tb_baifenbi_TextChanged(object sender, EventArgs e)
        {
            _myb.PercentA =Convert.ToDouble( tb_baifenbia.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void tb_baocunlujing_TextChanged(object sender, EventArgs e)
        {
            _myb.SavePath = tb_baocunlujing.Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                tb_baocunlujing.Text = fbd.SelectedPath;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _myb.Leixing = cbb_leixing.Text;
        }

        private void tb_baifenbib_TextChanged(object sender, EventArgs e)
        {
            _myb.PercentB = Convert.ToDouble(tb_baifenbib.Text);

        }
    }
}
