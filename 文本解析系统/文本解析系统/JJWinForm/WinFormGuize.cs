using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJUserControl;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormGuize : Form
    {
        public WinFormGuize()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 解析规则窗体的构造函数，带参数
        /// </summary>
        /// <param name="rulename">规则名称</param>
        public WinFormGuize(string rulename)
        {
            InitializeComponent();



        }

        /// <summary>
        /// 点击新增按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xinzeng_Click(object sender, EventArgs e)
        {
            //构造规则UC
            UCRuleInfo myuc = new UCRuleInfo();

            //添加到panel中，dock属性为top
            myuc.Dock = DockStyle.Top;
            panel_wenbentezheng.Controls.Add(myuc);

        }

        private void WinFormGuize_Load(object sender, EventArgs e)
        {

        }
    }
}
