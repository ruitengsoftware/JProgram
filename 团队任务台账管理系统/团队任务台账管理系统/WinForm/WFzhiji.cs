using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFzhiji : Form
    {
        public WFzhiji()
        {
            InitializeComponent();
        }
        public string str_select = string.Empty;
        private void btn_queding_Click(object sender, EventArgs e)
        {
            str_select = tv_my.SelectedNode.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
