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
    public partial class WjmRuleForm : Form
    {
        RuleInfo _ruleInfo = null;
        public WjmRuleForm()
        {
            InitializeComponent();
        }
        public WjmRuleForm(RuleInfo ri)
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

            JJmodel.WjmRuleRoot ruleRoot = new WjmRuleRoot();
            ruleRoot.ruleExplain = tb_explain.Text;
            foreach (Control myc in flp_my.Controls)
            {
                CheckBox cb = myc as CheckBox;
                if (cb.Checked)
                {
                    ruleRoot.position.Add(cb.Text);
                }
            }
            ruleRoot.delete = tb_delete.Text;
            ruleRoot.newText = tb_new.Text;
            ruleRoot.replace0 = tb_replace0.Text;
            ruleRoot.replace = tb_replace.Text;
           //构造一个ruleinfo
           RuleInfo ri = new RuleInfo(tb_rulename.Text,SystemInfo._currentModule,ruleRoot,SystemInfo._userInfo._shiming,
                DateTime.Now.ToString("yyyy-MM-dd"));
            //保存到数据库的规则信息表中
            ri.SaveRuleInfo();
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 文件名规则窗体加载时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WjmRuleForm_Load(object sender, EventArgs e)
        {
            //如果ruleInfo不是null说明传进来一个实例，需要显示再界面上
            if (_ruleInfo!=null)
            {
                tb_rulename.Text = _ruleInfo.ruleName;
                tb_explain.Text =(_ruleInfo._root as WjmRuleRoot).ruleExplain;
                foreach (Control c   in flp_my.Controls)
                {
                    if ((_ruleInfo._root as WjmRuleRoot).position.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                tb_delete.Text = (_ruleInfo._root as WjmRuleRoot).delete;
                tb_new.Text = (_ruleInfo._root as WjmRuleRoot).newText;
                tb_replace0.Text = (_ruleInfo._root as WjmRuleRoot).replace0;
                tb_replace.Text = (_ruleInfo._root as WjmRuleRoot).replace;
            }
        }
    }
}
