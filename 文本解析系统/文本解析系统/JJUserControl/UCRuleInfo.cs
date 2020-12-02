using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJModel;

namespace 文本解析系统.JJUserControl
{
    public partial class UCRuleInfo : UserControl
    {
        public UCRuleInfo()
        {
            InitializeComponent();
        }


        public UCRuleInfo(RuleDetail ruledetail)
        {
            InitializeComponent();
            //选中checkbox
            foreach (Control item in flp_duixiangxuanze.Controls)
            {
                if (ruledetail.duixiangxuanze.Contains(item.Text))
                {
                    (item as CheckBox).Checked = true;
                    
                }
            }
            //赋值文本特征
            tb_wenbentezheng.Text = ruledetail.wenbentezheng;
            //赋值文本特征结果
            tb_zidingyijieguo.Text = ruledetail._zidingyivalue;
            foreach (Control item in flp_juzhi.Controls)
            {
                if (item is CheckBox && ruledetail.fuzhi.Contains(item.Text))
                {
                    (item as CheckBox).Checked = true;
                }
            }
            //赋值类型
            cbb_fuzhileixing.Text = ruledetail.fuzhileixing;
            //赋值覆盖范围
            foreach (Control control in flp_fugaifanwei.Controls)
            {
                if (ruledetail.fuzhifanwei.Contains(control.Text))
                {
                    (control as CheckBox).Checked = true;
                }
            }

        }


        private void pb_shanchu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pb_shanchu_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.delete4;
        }

        private void pb_shanchu_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.delete3;

        }

        private void pb_wenhao_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.wenhao2;
        }

        private void pb_wenhao_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.wenhao1;

        }

        private void pb_wenhao_Click(object sender, EventArgs e)
        {
            //打开网页，正则表达式的指引
            System.Diagnostics.Process.Start("explorer.exe", "https://c.runoob.com/front-end/854");

        }
    }
}
