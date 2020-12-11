using Newtonsoft.Json;
using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJModel;
using 文本解析系统.JJUserControl;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormGuize : Form
    {
        JJController.ControllerGuize mycontroller = new JJController.ControllerGuize();
        public WinFormGuize()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 解析规则窗体的构造函数，带参数
        /// </summary>
        /// <param name="rulename">名称</param>
        public WinFormGuize(string rulename)
        {
            InitializeComponent();
            //获得数据库中rulename的对象，包括名称，规则说明，规则详情  
            RuleInfo myri = mycontroller.GetRuleInfo(rulename);
            //名称赋值
            tb_guizemingcheng.Text = myri._guizemingcheng;
            //规则说明赋值
            tb_shuoming.Text = myri._guizeshuoming;
            //文本特征集合转化成jigexiguize类，构造uc，添加到panel中
            JiexiGuize myjiexiguize = JsonConvert.DeserializeObject<JiexiGuize>(myri._wenbentezheng);
            for (int i = myjiexiguize.ruleinfo.Count - 1; i >= 0; i--)
            {
                UCRuleInfo myuc = new UCRuleInfo(myjiexiguize.ruleinfo[i]);
                myuc.Dock = DockStyle.Top;
                panel_wenbentezheng.Controls.Add(myuc);
                panel_wenbentezheng.Controls.SetChildIndex(myuc, 0);
            }
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
            panel_wenbentezheng.Controls.SetChildIndex(myuc, 0);

        }

        private void WinFormGuize_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_baocun_Click(object sender, EventArgs e)
        {
            //获得名称
            string guizemingcheng = tb_guizemingcheng.Text;
            //获得规则说明
            string guizeshuoming = tb_shuoming.Text;
            //获得规则详情集合，循环获得panel_wenbentezheng中所有的control,转换成ucruleinfo，获得信息
            JiexiGuize jiexiguize = new JiexiGuize();
            foreach (UserControl uc in panel_wenbentezheng.Controls)
            {
                var myuc = uc as UCRuleInfo;
                RuleDetail ri = new RuleDetail();

                ri._shunshu = myuc.tb_shunshu.Text.Trim().Equals(string.Empty)?0: Convert.ToInt32( myuc.tb_shunshu.Text);
                ri._daoshu = myuc.tb_daoshu.Text.Trim().Equals(string.Empty) ? 0 : Convert.ToInt32(myuc.tb_daoshu.Text);
                //获得对象选择，myuc.flp_duixiangxuanze中checked=true的text
                foreach (Control item in myuc.flp_duixiangxuanze.Controls)
                {

                    if (item is CheckBox && (item as CheckBox).Checked)
                    {
                        ri.duixiangxuanze.Add(item.Text);
                       
                    }
                }
                //获得文本特征
                ri.wenbentezheng = myuc.tb_wenbentezheng.Text;
                //获得文本特征结果
                ri._zidingyivalue = myuc.tb_zidingyijieguo.Text;
                foreach (Control item in myuc.flp_juzhi.Controls)
                {

                    if (item is CheckBox && (item as CheckBox).Checked)
                    {
                            ri.fuzhi.Add(item.Text);
                    }
                }
                //获得赋值类型
                ri.fuzhileixing = myuc.cbb_fuzhileixing.Text;
                //获得赋值覆盖范围
                foreach (Control mycontrol in myuc.flp_fugaifanwei.Controls)
                {
                    if ((mycontrol as CheckBox).Checked)
                    {
                        ri.fuzhifanwei.Add(mycontrol.Text);
                    }
                }
                jiexiguize.ruleinfo.Add(ri);
            }
            //将解析规则转为json格式
            string json = JsonConvert.SerializeObject(jiexiguize, Formatting.None);
            //在保存之前先删除
            mycontroller.DeleteRule(guizemingcheng);
            //保存规则
            bool b = mycontroller.SaveRule(guizemingcheng, guizeshuoming, json);
            if (b)
            {
                MessageBox.Show("保存规则成功！");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("保存失败！");
            }


        }
        UIHelper myuihelper = new UIHelper();
        private void label2_Paint(object sender, PaintEventArgs e)
        {
            myuihelper.DrawRoundRect((Control)sender);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            myuihelper.UpdateCC((Control)sender, Color.Salmon,Color.White);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            myuihelper.UpdateCC((Control)sender, Color.Tomato, Color.White);

        }
    }
}
