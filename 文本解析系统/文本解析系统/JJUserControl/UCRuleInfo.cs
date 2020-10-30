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
            foreach (CheckBox item in flp_duixiangxuanze.Controls)
            {
                if (item.Text.Equals(ruledetail.duixiangxuanze))
                {
                    item.Checked = true;
                    break;
                }
            }
            //赋值文本特征
            tb_wenbentezheng.Text = ruledetail.wenbentezheng;
            //赋值文本特征结果
            foreach (Control item in flp_jieguo.Controls)
            {
                if (item is CheckBox && item.Text.Equals(ruledetail.wenbentezhengjieguo))
                {
                    (item as CheckBox).Checked = true;
                    break;
                }
                cb_zidingyijieguo.Checked = true;
                tb_zidingyijieguo.Text = ruledetail.wenbentezhengjieguo;
            }
            //赋值复制类型
            foreach (Control item in flp_fuzhileixing.Controls)
            {
                if (item is CheckBox && item.Text.Equals(ruledetail.fuzhileixing))
                {
                    (item as CheckBox).Checked = true;
                    break;
                }
                cb_zidingyileixing.Checked = true;
                tb_zidingyileixing.Text = ruledetail.fuzhileixing;
            }




        }


        private void pb_shanchu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
