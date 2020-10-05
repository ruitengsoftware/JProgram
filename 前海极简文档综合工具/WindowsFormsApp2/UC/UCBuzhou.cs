using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.UC
{
    public partial class UCBuzhou : UserControl
    {
        /// <summary>
        /// 处理示例文本得委托
        /// </summary>
        public UCBuzhou()
        {
            InitializeComponent();
        }
        public UCBuzhou(string zhengze,string tihuan)
        {
            InitializeComponent();
            tb_tihuan.Text = tihuan;
            tb_zhengze.Text = zhengze;

        }

        private void 提取数字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tb_zhengze.Text = @"([+-]?\d+(\.\d+)?)";
        }

        private void 提取邮箱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tb_zhengze.Text = @"(\w+(?:[-+.]\w+)*@\w+(?:[-.]\w+)*\.\w+(?:[-.]\w+)*)";
        }

        private void Pb_zhengze_MouseClick(object sender, MouseEventArgs e)
        {
            cms_zhengze.Show(MousePosition.X, MousePosition.Y);
        }

        private void 中文字符ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tb_zhengze.Text = @"[\u4e00-\u9fa5]";
        }

        private void 提取Email地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tb_zhengze.Text = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        }

        private void 提取身份证号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tb_zhengze.Text = @"(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)";
        }

        private void Pb_zhengze_MouseEnter(object sender, EventArgs e)
        {
         ((PictureBox)sender).Image=Properties.Resources.addfielden;
        }

        private void Pb_zhengze_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.addfieldlv;

        }
    }
}
