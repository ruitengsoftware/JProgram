using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCchengguo : UserControl
    {
        public UCchengguo()
        {
            InitializeComponent();
        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
