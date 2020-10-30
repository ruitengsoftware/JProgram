using Newtonsoft.Json;
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
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_baocun_Click(object sender, EventArgs e)
        {
            //获得规则名称
            string guizemingcheng = tb_guizemingcheng.Text;
            //获得规则说明
            string guizeshuoming = tb_shuoming.Text;
            //获得规则详情
            JiexiGuize jiexiguize = new JiexiGuize();
            foreach (UserControl uc in panel_wenbentezheng.Controls)
            {
                var myuc = uc as UCRuleInfo;
                Ruleinfo ri = new Ruleinfo();
                //获得对象选择，myuc.flp_duixiangxuanze中checked=true的text
                foreach (Control item in myuc.flp_duixiangxuanze.Controls)
                {

                    if (item is CheckBox && (item as CheckBox).Checked)
                    {
                        ri.duixiangxuanze = item.Text;
                        break;
                    }
                }
                //获得文本特征
                ri.wenbentezheng = myuc.tb_wenbentezheng.Text;
                //获得文本特征结果
                foreach (Control item in myuc.flp_jieguo.Controls)
                {

                    if (item is CheckBox && (item as CheckBox).Checked)
                    {
                        if (item.Text.Equals("自定义"))
                        {
                            ri.wenbentezhengjieguo = myuc.tb_zidingyijieguo.Text;
                            break;
                        }
                        else
                        {
                            ri.wenbentezhengjieguo = item.Text;
                            break;
                        }
                    }
                }
                //获得赋值类型
                foreach (Control item in myuc.flp_fuzhileixing.Controls)
                {

                    if (item is CheckBox && (item as CheckBox).Checked)
                    {
                        if (item.Text.Equals("自定义"))
                        {
                            ri.fuzhileixing = myuc.tb_zidingyileixing.Text;
                            break;
                        }
                        else
                        {
                            ri.fuzhileixing = item.Text;
                            break;
                        }
                    }
                }
                jiexiguize.ruleinfo.Add(ri);
            }
            //将解析规则转为json格式
            string json = JsonConvert.SerializeObject(jiexiguize,Formatting.None);
            //保存规则
           bool b= mycontroller.SaveRule(guizemingcheng, guizeshuoming, json);
            if (b)
            {
                MessageBox.Show("保存规则成功！");
            }
            else
            {
                MessageBox.Show("保存失败！");
            }


        }
    }
}
