using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 谦海数据解析系统.JJmodel;

namespace 谦海数据解析系统.JJwinform
{
    public partial class DsjRuleForm : Form
    {
        public RuleInfo _ruleInfo = null;

        public DsjRuleForm()
        {
            InitializeComponent();
        }
        public DsjRuleForm(RuleInfo ri)
        {
            InitializeComponent();
            _ruleInfo = ri;
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            //构造一个root传入ruleinfo中
            JJmodel.DsjRuleRoot ruleRoot = new DsjRuleRoot();
            ruleRoot._ruleExplain = tb_explain.Text;
            foreach (Control myc in flp_xinxi.Controls)
            {
                if (myc is CheckBox && (myc as CheckBox).Checked)
                {
                    ruleRoot._xinxiku.Add(myc.Text);
                }
            }
            foreach (Control myc in flp_fanwei.Controls)
            {
                CheckBox cb = myc as CheckBox;
                if (cb.Checked)
                {
                    ruleRoot._fanwei.Add(cb.Text);
                }
            }
            foreach (Control myc in flp_biaozhu.Controls)
            {
                CheckBox cb = myc as CheckBox;
                if (cb.Checked)
                {
                    ruleRoot._biaozhu.Add(cb.Text);
                }
            }
            foreach (Control myc in flp_mingci.Controls)
            {
                CheckBox cb = myc as CheckBox;
                if (myc is CheckBox && (myc as CheckBox).Checked)
                {
                    ruleRoot._mingci.Add(myc.Text);
                }
            }
            foreach (Control myc in flp_chonghe.Controls)
            {
                if (myc is CheckBox && (myc as CheckBox).Checked)
                {
                    ruleRoot._chonghe.Add(myc.Text);
                }
            }
            //构造一个ruleinfo
            _ruleInfo = new RuleInfo(tb_rulename.Text, SystemInfo._currentModule, ruleRoot, SystemInfo._userInfo._shiming,
                    DateTime.Now.ToString("yyyy-MM-dd"));
            //保存到数据库的规则信息表中
            _ruleInfo.SaveRuleInfo();
            this.DialogResult = DialogResult.OK;

        }

        private void DsjRuleForm_Load(object sender, EventArgs e)
        {
            if (_ruleInfo != null)
            {
                tb_rulename.Text = _ruleInfo.ruleName;
                tb_explain.Text = (_ruleInfo._root as DsjRuleRoot)._ruleExplain;
                foreach (Control c in flp_xinxi.Controls)
                {
                    if ((_ruleInfo._root as DsjRuleRoot)._xinxiku.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_fanwei.Controls)
                {
                    if ((_ruleInfo._root as DsjRuleRoot)._fanwei.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_biaozhu.Controls)
                {
                    if ((_ruleInfo._root as DsjRuleRoot)._biaozhu.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_mingci.Controls)
                {
                    if ((_ruleInfo._root as DsjRuleRoot)._mingci.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_chonghe.Controls)
                {
                    if ((_ruleInfo._root as DsjRuleRoot)._chonghe.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
            }










        }
    }
}
