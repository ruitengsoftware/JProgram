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
    public partial class CcqxRuleForm : Form
    {
       public RuleInfo _ruleInfo = null;
        public CcqxRuleForm()
        {
            InitializeComponent();
        }


        public CcqxRuleForm(RuleInfo myri)
        {
            InitializeComponent();
            _ruleInfo = myri;
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            //构造一个root传入ruleinfo中
            CcqxRuleRoot ruleRoot = new CcqxRuleRoot();
            ruleRoot._shuoming = tb_explain.Text;
            foreach (Control myc in flp_xinxiku.Controls)
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
            foreach (Control myc in flp_shanchu.Controls)
            {
                CheckBox cb = myc as CheckBox;
                if (cb.Checked)
                {
                    ruleRoot._shanchu.Add(cb.Text);
                }
            }
            //构造一个ruleinfo
            _ruleInfo = new RuleInfo(tb_rulename.Text, SystemInfo._currentModule, ruleRoot, SystemInfo._userInfo._shiming,
                    DateTime.Now.ToString("yyyy-MM-dd"));
            //保存到数据库的规则信息表中
            _ruleInfo.SaveRuleInfo();
            this.DialogResult = DialogResult.OK;

        }

        private void CcqxRuleForm_Load(object sender, EventArgs e)
        {
            if (_ruleInfo != null)
            {
                tb_rulename.Text = _ruleInfo.ruleName;
                tb_explain.Text = (_ruleInfo._root as CcqxRuleRoot)._shuoming;
                foreach (Control c in flp_xinxiku.Controls)
                {
                    if ((_ruleInfo._root as CcqxRuleRoot)._xinxiku.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_fanwei.Controls)
                {
                    if ((_ruleInfo._root as CcqxRuleRoot)._fanwei.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_shanchu.Controls)
                {
                    if ((_ruleInfo._root as CcqxRuleRoot)._shanchu.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
            }
        }
    }
}
