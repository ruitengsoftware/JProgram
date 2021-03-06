﻿using System;
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
            //复制对象选择，顺数标准段，倒数标准段
            foreach (Control item in flp_duixiangxuanze.Controls)
            {
                if (ruledetail.duixiangxuanze.Contains(item.Text))
                {
                    (item as CheckBox).Checked = true;

                }
            }
            tb_shunshu.Text = ruledetail._shunshu.ToString();
            tb_daoshu.Text = ruledetail._daoshu.ToString();
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
            //赋值解析表横，列名称

            rb_liemingcheng.Checked = ruledetail._liemingcheng;
            rb_hengmingcheng.Checked = !ruledetail._liemingcheng;

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

        private void cbb_fuzhileixing_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果选中了自定义，就显示tb zidingyifuzhimingcheng
            if (((Control)sender).Text.Contains("自定义"))
            {
                tb_zidingyifuzhimingcheng.Visible = true;
            }
            else
            {
                tb_zidingyifuzhimingcheng.Visible = false;
            }
        }

        private void rb_liemingcheng_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                flp_fugaifanwei.Enabled = true;
            }
            else
            {
                flp_fugaifanwei.Enabled = false;
            }
        }

        private void cb_quanbuduixiang_CheckedChanged(object sender, EventArgs e)
        {
            //如果选中了全部对象，其他checkbox就变成不可选的状态
            if (cb_quanbuduixiang.Checked)
            {
                foreach (Control c in flp_fugaifanwei.Controls)
                {
                    if (!c.Text.Equals("全部对象"))
                    {
                        (c as CheckBox).Checked = false;
                        c.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (Control c in flp_fugaifanwei.Controls)
                {
                    c.Enabled = true;
                }
            }



        }
    }
}
