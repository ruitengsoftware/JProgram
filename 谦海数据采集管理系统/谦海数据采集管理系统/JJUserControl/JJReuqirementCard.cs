using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 谦海数据采集管理系统.JJUserControl
{
    public partial class JJReuqirementCard : UserControl
    {
        public JJReuqirementCard()
        {
            InitializeComponent();
            RuiTengDll.UIHelper.DrawRoundRect(tableLayoutPanel1);
            this.Dock = DockStyle.Top;
        }
    }
}
