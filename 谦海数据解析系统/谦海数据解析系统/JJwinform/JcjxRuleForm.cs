using MySql.Data.MySqlClient;
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
using 谦海数据解析系统.JJModel;
using 谦海数据解析系统.JJUserControl;

namespace 谦海数据解析系统.JJWinForm
{
    public partial class JcjxRuleForm : Form
    {
        public JcjxRuleForm()
        {
            InitializeComponent();
            btn_xinzeng_Click(null, null);
        }
        /// <summary>
        /// 解析规则窗体的构造函数，带参数
        /// </summary>
        /// <param name="rulename">名称</param>
        public JcjxRuleForm(string rulename)
        {
            InitializeComponent();
            //获得数据库中rulename的对象，包括名称，规则说明，规则详情  
            RuleInfoOriginal myri =GetRuleInfo(rulename);
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
                //获得横.列名称
                ri._liemingcheng = myuc.rb_liemingcheng.Checked;
                jiexiguize.ruleinfo.Add(ri);
            }
            //将解析规则转为json格式
            string json = JsonConvert.SerializeObject(jiexiguize, Formatting.None);
            //在保存之前先删除
            DeleteRule(guizemingcheng);
            //保存规则
            bool b = SaveRule(guizemingcheng, guizeshuoming, json);
            if (b)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show($"规则 {guizemingcheng} 保存失败！");
            }
        }
        private void label2_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCC((Control)sender, Color.Salmon,Color.White);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCC((Control)sender, Color.Tomato, Color.White);

        }


        /// <summary>
        /// 保存规则
        /// </summary>
        /// <returns></returns>
        public bool SaveRule(string mingcheng, string shuoming, string xiangqing)
        {
            string str_sql = $"insert into 数据解析库.规则信息表_基础 (创建人,创建时间,名称,规则说明,文本特征,删除) values(@创建人,@创建时间,@名称,@规则说明,@文本特征,0)";
            int num = MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql,
                new MySqlParameter("@创建人", SystemInfo._userInfo._shiming),
                new MySqlParameter(@"创建时间", DateTime.Now.ToString()),
                new MySqlParameter("@名称", mingcheng),
                new MySqlParameter("@规则说明", shuoming),
                new MySqlParameter("@文本特征", xiangqing));
            return num > 0 ? true : false;
        }
        /// <summary>
        /// 删除指定的规则
        /// </summary>
        /// <param name="mingcheng">名称</param>
        /// <returns></returns>
        public bool DeleteRule(string mingcheng)
        {
            string str_sql = $"delete from 数据解析库.规则信息表_基础 where 名称='{mingcheng}'";
            int num = MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
            return num > 0 ? true : false;

        }
        /// <summary>
        /// 获得规则信息，返回一个rulinfo对象
        /// </summary>
        /// <param name="rulename">名称</param>
        /// <returns></returns>
        public RuleInfoOriginal GetRuleInfo(string rulename)
        {
            string str_sql = $"select * from 数据解析库.规则信息表_基础 where 名称='{rulename}'";
            DataRow mydr = MySqlHelper.ExecuteDataRow(SystemInfo._strConn, str_sql);
            RuleInfoOriginal myri = new RuleInfoOriginal();
            myri._guizemingcheng = mydr["名称"].ToString();
            myri._guizeshuoming = mydr["规则说明"].ToString();
            myri._wenbentezheng = mydr["文本特征"].ToString();
            myri._chuangjianren = mydr["创建人"].ToString();
            myri._chuangjianshijian = mydr["创建时间"].ToString();
            return myri;
        }


    }
}
