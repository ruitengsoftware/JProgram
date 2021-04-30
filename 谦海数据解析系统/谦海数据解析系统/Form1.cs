using Aspose.Words;
using MySql.Data.MySqlClient;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using 谦海数据解析系统.JJmodel;
using 谦海数据解析系统.JJusercontrol;
using 谦海数据解析系统.JJwinform;
using 谦海数据解析系统.JJWinForm;

namespace 谦海数据解析系统
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 该方法用于防止动态增减控件时窗体闪烁
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        /// <summary>
        /// 程序运行状态，0是停止，1是开始，2是暂停
        /// </summary>
        int statue = 0;
        /// <summary>
        /// 正在进行第几个文件夹
        /// </summary>
        int folderIndex = 0;
        /// <summary>
        /// 正在进行第几个文件
        /// </summary>
        int fileIndex = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载公用方法
            MyMethod._updateTag = UpdateBiaoqiankuPanel;
            //MessageBox.Show(ConfigurationManager.ConnectionStrings["connstr"].ToString());
            //ConfigurationOptions options = ConfigurationOptions.Parse("119.23.76.145:6379");
            //ConnectionMultiplexer mycon = ConnectionMultiplexer.Connect(options);
            //IDatabase db = mycon.GetDatabase();
            //db.StringSet("test", "中华");
            //RedisValue rv = db.StringGet("test");
            //MessageBox.Show(rv);
            lbl_username.Text = $"您好，{SystemInfo._userInfo._shiming}";
            toolTip1.SetToolTip(pb_out, "退出");
            toolTip1.SetToolTip(pb_qiehuan, "切换数据库");
            //如果用户当前选择的数据库名称是空，那么要弹出选择信息库窗体
            if (SystemInfo._userInfo._dbName.Equals(string.Empty))
            {
                SelectDBForm myform = new SelectDBForm();
                if (myform.ShowDialog() == DialogResult.OK)
                {

                }
            }
            UpdateFormtext();
            //将各个类别的规则集合加载到规则列表中
            //1、文件名格式和规则
            UpdateFormats("文件名标准化", cbb_formatName1);
            UpdateRules("文件名标准化", string.Empty, dgv_wenjianmingrules);
            //2、内容标签库里列表
            UpdateFormats("内容解析", cbb_format5);
            UpdateBiaoqiankuPanel();
            //3、显示大数据版规则
            UpdateFormats("大数据版", cbb_formatname6);
            UpdateRules("大数据版", string.Empty, dgv_dsjRules);
            //4、显示基础解析规则
            UpdateFormats("基础解析", cbb_format4);
            UpdateRulesOriginal(string.Empty, dgv_jichujiexi);
            //5、显示查重清洗
            UpdateFormats("查重清洗", cbb_format3);
            UpdateRules("查重清洗", string.Empty, dgv_chachong);
            //显示格式标准化
            UpdateFormats("格式标准化", cbb_format2);
            UpdateRules("格式标准化", string.Empty, dgv_biaozhunhua);


        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
            ((Control)sender).ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.DimGray;
            ((Control)sender).ForeColor = Color.White;
            //更新左侧按钮样式
            foreach (Control c in panel1.Controls)
            {
                if (c.Text.Equals(SystemInfo._currentModule))
                {
                    c.BackColor = Color.White;
                    c.ForeColor = Color.Black;
                }
                else
                {
                    c.BackColor = Color.DimGray;
                    c.ForeColor = Color.White;

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //记录当前模块
            SystemInfo._currentModule = ((Control)sender).Text;
            tabControl1.SelectTab(SystemInfo._currentModule);
        }
        /// <summary>
        /// 点击退出按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_out_Click(object sender, EventArgs e)
        {
            //点击退出按钮，隐藏当前窗体，显示登录界面，登陆界面的自动登录选项是取消掉的
            this.Visible = false;
            Properties.Settings.Default.zidongdenglu = false;
            LoginForm myform = new LoginForm();
            if (myform.ShowDialog() == DialogResult.OK)
            {
                //如果登录成功，重新加载form1窗体的信息
                this.Form1_Load(null, null);
                this.Visible = true;
            }
        }
        /// <summary>
        /// 点击切换数据库按钮时触发的事件，弹出数据库信息选择窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_qiehuan_Click(object sender, EventArgs e)
        {
            SelectDBForm myform = new SelectDBForm();
            if (myform.ShowDialog() == DialogResult.OK)
            {
                //选择信息库成功之后,刷新软件标题栏信息
                UpdateFormtext();
            }
        }

        /// <summary>
        /// 切换数据库之后刷新软件标题栏
        /// </summary>
        private void UpdateFormtext()
        {
            this.Text = $"{SystemInfo._userInfo._dbName} 数据解析系统 {SystemInfo._version} {SystemInfo._publishDate}";
        }
        /// <summary>
        /// 点击新增任务按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_xinzengrenwu_Click(object sender, EventArgs e)
        {
            //实例化一个选择任务窗体，显示出来，点击确定之后，将目标文件夹的信息加载到任务列表
            SelectFormatForm myform = new SelectFormatForm();
            if (myform.ShowDialog() == DialogResult.OK)
            {
                int index = dgv_task.Rows.Add();
                dgv_task.Rows[index].Cells[0].Value = index + 1;
                dgv_task.Rows[index].Cells[1].Value = myform._dirInfo.FullName;
                dgv_task.Rows[index].Cells[2].Value = myform._dirInfo.GetFiles().Length;
            }
        }

        private void lbl_qingkong_Click(object sender, EventArgs e)
        {
            //清空任务列表中所有的任务
            dgv_task.Rows.Clear();
        }

        private void lbl_xinjianguize1_Click(object sender, EventArgs e)
        {
            //实例化一个文件名标准化规则编辑窗体
            WjmRuleForm myform = new WjmRuleForm();
            if (myform.ShowDialog() == DialogResult.OK)
            {
                UpdateRules("文件名标准化", dgv_wenjianmingrules);
            }
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun1_Click(object sender, EventArgs e)
        {
            string formatName = cbb_formatName1.Text;
            string formatType = SystemInfo._currentModule;
            List<string> list = GetSelectRules(dgv_wenjianmingrules);
            FormatInfo myfi = new FormatInfo(formatName, string.Join("|", list), formatType);
            myfi.SaveFormatInfo();
            UpdateFormats("文件名标准化", cbb_formatName1);
        }

        /// <summary>
        /// 获得数据列表中所有选中的item名称
        /// </summary>
        /// <param name="mydgv"></param>
        /// <returns></returns>
        public List<string> GetSelectRules(DataGridView mydgv)
        {
            List<string> list = new List<string>();
            //获得所有规则列表中选中的规则名称
            for (int i = 0; i < mydgv.Rows.Count; i++)
            {
                bool _checked = (bool)mydgv.Rows[i].Cells[0].EditedFormattedValue;
                if (_checked)
                {
                    list.Add(mydgv.Rows[i].Cells[1].Value.ToString());
                }
            }
            return list;
        }
        /// <summary>
        /// 该方法用于获得内容标签选中的规则
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelectRules()
        {
            List<string> list = new List<string>();
            foreach (Control c in panel_5.Controls)
            {
                var myuc = c as BiaoqiankuControl;
                if (myuc.cb_biaoqianku.Checked)
                {
                    list.Add(myuc.cb_biaoqianku.Text);
                }
            }
            return list;
        }



        /// <summary>
        /// 点击文件名标准化模块的删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu1_Click(object sender, EventArgs e)
        {
            DeleteFormat(cbb_formatName1.Text, "文件名标准化", cbb_formatName1);
        }





        #region 更新界面显示等方法

        /// <summary>
        /// 用于删除格式的方法
        /// </summary>
        /// <param name="name">删除格式名</param>
        /// <param name="type">格式类型</param>
        /// <param name="mycbb">格式下拉列表</param>
        public void DeleteFormat(string formatName, string type, ComboBox mycbb)
        {
            //询问是否删除改格式
            DialogResult mydr = MessageBox.Show($"是否删除格式 {formatName} ?", "消息提醒", MessageBoxButtons.YesNoCancel);
            //如果是，就删除，并提示删除成功
            if (mydr == DialogResult.Yes)
            {
                string str_sql = $"delete from 数据解析库.格式信息表 where 格式名称='{formatName}' and 删除=0";
                MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
                //更新下拉列表
                UpdateFormats(type, mycbb);
                mycbb.SelectedIndex = 0;
                ////删除列表成功提示
                MessageBox.Show($"格式 {formatName} 已成功删除！");
            }
        }




        /// <summary>
        /// 更新文件名规则信息列表
        /// </summary>
        /// <param name="mydt"></param>
        public void UpdateRules(string ruleType, DataGridView mydgv)
        {
            //更新规则列表中的规则
            DataTable mydt = MyMethod.GetRules(ruleType, string.Empty);
            mydgv.Rows.Clear();
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                mydgv.Rows.Add();
                mydgv.Rows[i].Cells[1].Value = mydt.Rows[i]["规则名称"].ToString();
                mydgv.Rows[i].Cells[2].Value = mydt.Rows[i]["创建人"].ToString();
                mydgv.Rows[i].Cells[3].Value = mydt.Rows[i]["创建时间"].ToString();
            }
        }
        /// <summary>
        /// 根据指定关键词更新rule显示结果
        /// </summary>
        /// <param name="kw"></param>
        public void UpdateRules(string ruleType, string kw, DataGridView mydgv)
        {
            //更新规则列表中的规则
            DataTable mydt = MyMethod.GetRules(ruleType, kw);
            mydgv.Rows.Clear();
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                mydgv.Rows.Add();
                mydgv.Rows[i].Cells[1].Value = mydt.Rows[i]["规则名称"].ToString();
                mydgv.Rows[i].Cells[2].Value = mydt.Rows[i]["创建人"].ToString();
                mydgv.Rows[i].Cells[3].Value = mydt.Rows[i]["创建时间"].ToString();
            }
        }




        /// <summary>
        /// 更新显示文件名格式下拉菜单中的内容
        /// </summary>
        public void UpdateFormats(string ruleType, ComboBox mycbb)
        {
            mycbb.Items.Clear();
            var list = MyMethod.GetFormats(ruleType);
            mycbb.Items.AddRange(list.ToArray());
        }

        /// <summary>
        /// 切换文件名格式下拉列表中的内容时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_formatName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得格式信息，再规则信息设置中打勾
            string formatName = cbb_formatName1.Text;
            FormatInfo myfi = new FormatInfo(formatName);
            myfi.GetFormatInfo();
            SelectRules(myfi._formatSet, dgv_wenjianmingrules);
        }
        /// <summary>
        /// 该方法用于再规则信息列表中选择格式含有的规则信息，打勾
        /// </summary>
        private void SelectRules(string str, DataGridView mydgv)
        {
            List<string> list = str.Split('|').ToList();
            for (int i = 0; i < mydgv.Rows.Count; i++)
            {
                mydgv.Rows[i].Cells[0].Value = false;
                string ruleName = mydgv.Rows[i].Cells[1].Value.ToString();
                if (list.Contains(ruleName))
                {
                    mydgv.Rows[i].Cells[0].Value = true;
                }
            }
        }
        /// <summary>
        /// 该方法用于在内容解析模块下对所选格式相对应的
        /// </summary>
        /// <param name="str"></param>
        /// <param name="mydgv"></param>
        private void SelectRules(string str)
        {
            List<string> list = str.Split('|').ToList();
            foreach (Control c in panel_5.Controls)
            {
                var myuc = c as BiaoqiankuControl;
                myuc.cb_biaoqianku.Checked = false;
                if (list.Contains(myuc.cb_biaoqianku.Text))
                {
                    myuc.cb_biaoqianku.Checked = true;
                }
            }
        }

        #endregion
        /// <summary>
        /// 点击规则列表的内容时触发的事件，编辑和删除两项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_wenjianmingrules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ruleName = dgv_wenjianmingrules.Rows[e.RowIndex].Cells["jieximingcheng"].Value.ToString();
            //点击编辑按钮时
            if (dgv_wenjianmingrules.Columns[e.ColumnIndex].Name == "bianjianniu" && e.RowIndex >= 0)
            {
                //获得规则的信息ruleinfo
                RuleInfo myri = new RuleInfo(ruleName);
                myri.GetRuleInfo();
                //把ruleinfo传给wjmruleform窗体,立刻加载信息
                WjmRuleForm myform = new WjmRuleForm(myri);
                if (myform.ShowDialog() == DialogResult.OK)
                {
                    //UpdateWenjianmingRules();
                }
            }
            //点击删除按钮时
            if (dgv_wenjianmingrules.Columns[e.ColumnIndex].Name == "shanchuanniu" && e.RowIndex >= 0)
            {
                DialogResult mydr = MessageBox.Show($"是否删除规则 {ruleName} ?", "消息提醒", MessageBoxButtons.YesNoCancel);
                if (mydr == DialogResult.Yes)
                {
                    string str_sql = $"delete from 数据解析库.规则信息表 where 规则名称='{ruleName}' and 删除=0";
                    MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
                    //更新下拉列表
                    ////删除列表成功提示
                    //刷新格则列表显示
                    UpdateRules("文件名标准化", string.Empty, dgv_wenjianmingrules);
                    SelectRules(cbb_formatName1.Text, dgv_wenjianmingrules);
                    MessageBox.Show($"规则 {ruleName} 已删除成功！");
                }
            }
        }
        /// <summary>
        /// 点击搜索按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_search_Click(object sender, EventArgs e)
        {
            string kw = tb_search.Text;
            UpdateRules("文件名标准化", kw, dgv_wenjianmingrules);
        }
        /// <summary>
        /// 选择了不同的选项卡时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //软件窗体左侧的功能选择区也进行相应的选中
            SystemInfo._currentModule = tabControl1.SelectedTab.Text;
            //更新左侧按钮样式
            foreach (Control c in panel1.Controls)
            {
                if (c.Text.Equals(SystemInfo._currentModule))
                {
                    c.BackColor = Color.White;
                    c.ForeColor = Color.Black;
                }
                else
                {
                    c.BackColor = Color.DimGray;
                    c.ForeColor = Color.White;

                }
            }
        }
        /// <summary>
        /// 点击新建标签库按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_xinjianbiaoqianku_Click(object sender, EventArgs e)
        {
            NewBQKForm myform = new NewBQKForm();
            if (myform.ShowDialog() == DialogResult.OK)
            {
                //刷新标签库显示
                UpdateBiaoqiankuPanel();
            }
        }
        /// <summary>
        /// 刷新显示标签库和分级情况，默认折叠模式
        /// </summary>
        public void UpdateBiaoqiankuPanel()
        {
            //使用sql语句获得所有的不同数据库，这里应该转变一下思路，就是不要一次性加载所有的标签内容
            //而应该在鼠标点击展开时加载
            //所以仅仅显示一级标签就可以了
            string str_sql = $"select * from 数据解析库.内容标签表 where 删除=0 and 级别=1";
            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            panel_5.Controls.Clear();
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                DataRow mydr = mydt.Rows[i];
                //实例化一个标签信息
                BiaoqianInfo _biaoqianInfo = new BiaoqianInfo(
                    mydr["库名"].ToString(),
                    mydr["名称"].ToString(),
                    Convert.ToInt32(mydr["级别"].ToString()),
                    mydr["父标签名"].ToString(),
                    mydr["设置"].ToString(),
                    mydr["创建人"].ToString(),
                    mydr["创建时间"].ToString()
                );
                //将biaoqianinfo传递给标签库控件，显示在界面上
                BiaoqiankuControl myuc = new BiaoqiankuControl(_biaoqianInfo);
                MyMethod.AddControl(myuc, panel_5);
            }
        }
        /// <summary>
        /// 点击大数据版保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            string formatName = cbb_formatname6.Text;
            string formatType = SystemInfo._currentModule;
            List<string> list = GetSelectRules(dgv_dsjRules);
            FormatInfo myfi = new FormatInfo(formatName, string.Join("|", list), formatType);
            myfi.SaveFormatInfo();
            UpdateFormats("大数据版", cbb_formatname6);

        }
        /// <summary>
        /// 切换选择大数据版格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_formatname6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得格式信息，再规则信息设置中打勾
            string formatName = cbb_formatname6.Text;
            FormatInfo myfi = new FormatInfo(formatName);
            myfi.GetFormatInfo();
            SelectRules(myfi._formatSet, dgv_dsjRules);

        }
        /// <summary>
        /// 点击文件名标准化模块的批量删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_piliangshanchu1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击大数据版模块下的新建规则按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_xinjian6_Click(object sender, EventArgs e)
        {

            DsjRuleForm myform = new DsjRuleForm();
            if (myform.ShowDialog() == DialogResult.OK)
            {
                UpdateRules("大数据版", dgv_dsjRules);
                MessageBox.Show($"规则 {myform._ruleInfo.ruleName} 保存成功！");
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击大数据版放大镜按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_search6_Click(object sender, EventArgs e)
        {
            string kw = tb_search.Text;
            UpdateRules("大数据版", kw, dgv_dsjRules);

        }
        /// <summary>
        /// 点击大数据规则列表中的编辑和删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_dsjRules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ruleName = dgv_dsjRules.Rows[e.RowIndex].Cells[1].Value.ToString();

            //点击编辑按钮时
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                //获得规则的信息ruleinfo
                RuleInfo myri = new RuleInfo(ruleName);
                myri.GetRuleInfo();
                //把ruleinfo传给wjmruleform窗体,立刻加载信息
                DsjRuleForm myForm = new DsjRuleForm(myri);
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"规则 {myForm._ruleInfo.ruleName} 保存成功！");
                }
            }
            //点击删除按钮时
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                DialogResult mydr = MessageBox.Show($"是否删除规则 {ruleName} ?", "消息提醒", MessageBoxButtons.YesNoCancel);
                if (mydr == DialogResult.Yes)
                {
                    string str_sql = $"delete from 数据解析库.规则信息表 where 规则名称='{ruleName}' and 删除=0";
                    MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
                    //更新下拉列表
                    ////删除列表成功提示
                    //刷新格则列表显示
                    UpdateRules("大数据版", string.Empty, dgv_dsjRules);
                    SelectRules(cbb_formatname6.Text, dgv_dsjRules);
                    MessageBox.Show($"规则 {ruleName} 已成功删除！");
                }
            }
        }


        /// <summary>
        /// 点击大数据版模块下的删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu_Click(object sender, EventArgs e)
        {
            string formatname = cbb_formatname6.Text;
            DeleteFormat(formatname, "大数据版", cbb_formatname6);
        }
        /// <summary>
        /// 点击内容解析模块下的删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu5_Click(object sender, EventArgs e)
        {
            string formatname = cbb_format5.Text;
            DeleteFormat(formatname, "内容解析", cbb_format5);
        }
        /// <summary>
        /// 点击内容解析模块下的保存按钮时触发的时间 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun5_Click(object sender, EventArgs e)
        {
            string formatName = cbb_format5.Text;
            string formatType = SystemInfo._currentModule;
            List<string> list = GetSelectRules();
            FormatInfo myfi = new FormatInfo(formatName, string.Join("|", list), formatType);
            myfi.SaveFormatInfo();
            UpdateFormats("内容解析", cbb_format5);
        }
        /// <summary>
        /// 切换内容解析模块下的格式名称时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_format5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得格式信息，再规则信息设置中打勾
            string formatName = cbb_format5.Text;
            FormatInfo myfi = new FormatInfo(formatName);
            myfi.GetFormatInfo();
            SelectRules(myfi._formatSet);

        }

        private void cbb_format4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得格式信息，再规则信息设置中打勾
            string formatName = cbb_format4.Text;
            FormatInfo myfi = new FormatInfo(formatName);
            myfi.GetFormatInfo();
            SelectRules(myfi._formatSet, dgv_jichujiexi);


        }
        /// <summary>
        /// 点击基础解析模块的保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun4_Click(object sender, EventArgs e)
        {
            string formatName = cbb_format4.Text;
            string formatType = SystemInfo._currentModule;
            List<string> list = GetSelectRules(dgv_jichujiexi);
            FormatInfo myfi = new FormatInfo(formatName, string.Join("|", list), formatType);
            myfi.SaveFormatInfo();
            UpdateFormats("基础解析", cbb_format4);

        }
        /// <summary>
        /// 点击基础解析模块的删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu4_Click(object sender, EventArgs e)
        {
            string formatname = cbb_format4.Text;
            DeleteFormat(formatname, "基础解析", cbb_format4);

        }
        /// <summary>
        /// 点击基础解析模块的放大镜按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_search4_Click(object sender, EventArgs e)
        {
            string kw = tb_kw4.Text;
            UpdateRulesOriginal(kw, dgv_jichujiexi);

        }
        /// <summary>
        /// 点击基础解析模块的规则列表时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_jichujiexi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ruleName = dgv_jichujiexi.Rows[e.RowIndex].Cells[1].Value.ToString();

            //点击编辑按钮时
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                //获得规则的信息ruleinfo
                string rulename = dgv_jichujiexi.Rows[e.RowIndex].Cells[1].Value.ToString();
                //把ruleinfo传给wjmruleform窗体,立刻加载信息
                JcjxRuleForm myForm = new JcjxRuleForm(rulename);
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"规则 {ruleName} 保存成功！");
                }
            }
            //点击删除按钮时
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                DialogResult mydr = MessageBox.Show($"是否删除规则 {ruleName} ?", "消息提醒", MessageBoxButtons.YesNoCancel);
                if (mydr == DialogResult.Yes)
                {
                    string str_sql = $"delete from 数据解析库.规则信息表_基础 where 名称='{ruleName}' and 删除=0";
                    MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
                    //更新下拉列表
                    ////删除列表成功提示
                    //刷新格则列表显示
                    UpdateRulesOriginal(string.Empty, dgv_jichujiexi);
                    SelectRules(cbb_format4.Text, dgv_jichujiexi);
                    MessageBox.Show($"规则 {ruleName} 已成功删除！");
                }
            }

        }
        /// <summary>
        /// 点击基础解析模块的新建规则按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_xinjian4_Click(object sender, EventArgs e)
        {
            //获得cbb 解析格式的index 
            string f = cbb_format4.Text;
            JcjxRuleForm mywin = new JcjxRuleForm();
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                UpdateRules("基础解析", dgv_jichujiexi);
            }
        }

        /// <summary>
        /// 刷新基础解析模块的规则列表
        /// </summary>
        /// <param name="mydgv"></param>
        public void UpdateRulesOriginal(string kw, DataGridView mydgv)
        {
            //更新规则列表中的规则
            DataTable mydt = MyMethod.GetRulesOriginal(kw);
            mydgv.Rows.Clear();
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                mydgv.Rows.Add();
                mydgv.Rows[i].Cells[1].Value = mydt.Rows[i]["名称"].ToString();
                mydgv.Rows[i].Cells[2].Value = mydt.Rows[i]["创建人"].ToString();
                mydgv.Rows[i].Cells[3].Value = mydt.Rows[i]["创建时间"].ToString();
            }

            //让所有基础解析规则固定在解析规则的第一位
            //foreach (DataGridViewRow item in mydgv.Rows)
            //{
            //    string name = item.Cells["jieximingcheng"].Value.ToString();
            //    if (name.Contains("基础规则"))
            //    {

            //        //获得行索引
            //        var index = item.Index;
            //        //基础规则用蓝色显示
            //        mydgv.Rows[index].DefaultCellStyle.ForeColor = Color.DodgerBlue;
            //        //复制这一行
            //        mydgv.Rows.Remove(item);
            //        //在指定位置重新插入第一行
            //        mydgv.Rows.Insert(0, item);
            //    }
            //}

        }
        /// <summary>
        /// 点击查重清洗模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_format3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得格式信息，再规则信息设置中打勾
            string formatName = cbb_format3.Text;
            FormatInfo myfi = new FormatInfo(formatName);
            myfi.GetFormatInfo();
            SelectRules(myfi._formatSet, dgv_chachong);

        }
        /// <summary>
        /// 点击查重清洗模块中的删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu3_Click(object sender, EventArgs e)
        {
            string formatname = cbb_format3.Text;
            DeleteFormat(formatname, "查重清洗", cbb_format3);

        }
        /// <summary>
        /// 点击查重清洗模块中的保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun3_Click(object sender, EventArgs e)
        {
            string formatName = cbb_format3.Text;
            string formatType = SystemInfo._currentModule;
            List<string> list = GetSelectRules(dgv_chachong);
            FormatInfo myfi = new FormatInfo(formatName, string.Join("|", list), formatType);
            myfi.SaveFormatInfo();
            UpdateFormats("查重清洗", cbb_format3);
        }
        /// <summary>
        /// 点击查重清晰模块下的规则列表时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_chachong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ruleName = dgv_chachong.Rows[e.RowIndex].Cells[1].Value.ToString();

            //点击编辑按钮时
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                //获得规则的信息ruleinfo
                RuleInfo myri = new RuleInfo(ruleName);
                myri.GetRuleInfo();
                //把ruleinfo传给wjmruleform窗体,立刻加载信息
                CcqxRuleForm myForm = new CcqxRuleForm(myri);
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"规则 {myForm._ruleInfo.ruleName} 保存成功！");
                }
            }
            //点击删除按钮时
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                DialogResult mydr = MessageBox.Show($"是否删除规则 {ruleName} ?", "消息提醒", MessageBoxButtons.YesNoCancel);
                if (mydr == DialogResult.Yes)
                {
                    string str_sql = $"delete from 数据解析库.规则信息表 where 规则名称='{ruleName}' and 删除=0";
                    MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
                    //更新下拉列表
                    ////删除列表成功提示
                    //刷新格则列表显示
                    UpdateRules("查重清洗", string.Empty, dgv_chachong);
                    SelectRules(cbb_format3.Text, dgv_chachong);
                    MessageBox.Show($"规则 {ruleName} 已成功删除！");
                }
            }
        }
        /// <summary>
        /// 点击查重清洗模块下的放大镜按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_search3_Click(object sender, EventArgs e)
        {
            string kw = tb_kw3.Text;
            UpdateRules("查重清洗", kw, dgv_chachong);

        }
        /// <summary>
        /// 点击查重清洗模块下的新建规则按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_xinjianguize3_Click(object sender, EventArgs e)
        {
            CcqxRuleForm myform = new CcqxRuleForm();
            if (myform.ShowDialog() == DialogResult.OK)
            {
                UpdateRules("查重清洗", dgv_chachong);
                MessageBox.Show($"规则 {myform._ruleInfo.ruleName} 保存成功！");
            }

        }
        /// <summary>
        /// 点击格式标准化模块的删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu2_Click(object sender, EventArgs e)
        {
            string formatname = cbb_format2.Text;
            DeleteFormat(formatname, "格式标准化", cbb_format2);

        }
        /// <summary>
        /// 点击格式标准化模块中的保存按钮触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun2_Click(object sender, EventArgs e)
        {
            string formatName = cbb_format2.Text;
            string formatType = SystemInfo._currentModule;
            List<string> list = GetSelectRules(dgv_biaozhunhua);
            FormatInfo myfi = new FormatInfo(formatName, string.Join("|", list), formatType);
            myfi.SaveFormatInfo();
            UpdateFormats("格式标准化", cbb_format2);
        }
        /// <summary>
        /// 点击格式标准化按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_format2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得格式信息，再规则信息设置中打勾
            string formatName = cbb_format2.Text;
            FormatInfo myfi = new FormatInfo(formatName);
            myfi.GetFormatInfo();
            SelectRules(myfi._formatSet, dgv_biaozhunhua);
        }
        /// <summary>
        /// 点击格式标准化格式模块中的搜索按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_search2_Click(object sender, EventArgs e)
        {
            string kw = tb_kw2.Text;
            UpdateRules("格式标准化", kw, dgv_biaozhunhua);

        }
        /// <summary>
        /// 点击格式标准化下的规则列表时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_biaozhunhua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ruleName = dgv_biaozhunhua.Rows[e.RowIndex].Cells[1].Value.ToString();

            //点击编辑按钮时
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                //获得规则的信息ruleinfo
                RuleInfo myri = new RuleInfo(ruleName);
                myri.GetRuleInfo();
                //把ruleinfo传给wjmruleform窗体,立刻加载信息
                BzhRuleForm myForm = new BzhRuleForm(myri);
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"规则 {myForm._ruleInfo.ruleName} 保存成功！");
                }
            }
            //点击删除按钮时
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                DialogResult mydr = MessageBox.Show($"是否删除规则 {ruleName} ?", "消息提醒", MessageBoxButtons.YesNoCancel);
                if (mydr == DialogResult.Yes)
                {
                    string str_sql = $"delete from 数据解析库.规则信息表 where 规则名称='{ruleName}' and 删除=0";
                    MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
                    //更新下拉列表
                    ////删除列表成功提示
                    //刷新格则列表显示
                    UpdateRules("格式标准化", string.Empty, dgv_biaozhunhua);
                    SelectRules(cbb_format2.Text, dgv_biaozhunhua);
                    MessageBox.Show($"规则 {ruleName} 已成功删除！");
                }
            }

        }
        /// <summary>
        /// 点击标准化格式模块中的新建规则能力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_xinjianguize2_Click(object sender, EventArgs e)
        {
            BzhRuleForm myform = new BzhRuleForm();
            if (myform.ShowDialog() == DialogResult.OK)
            {
                UpdateRules("格式标准化", dgv_biaozhunhua);
                MessageBox.Show($"规则 {myform._ruleInfo.ruleName} 保存成功！");
            }

        }
        /// <summary>
        /// 点击开始按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_kaishi_Click(object sender, EventArgs e)
        {
            //修改程序状态为执行，刷新状态信息
            lbl_zhuangtai.Text = "正在进行数据解析……";
            lbl_kaishi.Enabled = false;
            lbl_kaishi.BackColor = Color.Gray;
            statue = 1;

            //获得文件夹下所有的文件名
            for (int i = folderIndex; i < dgv_task.Rows.Count; i++)
            {

                folderIndex = i;//时刻记录当前程序执行到的文件夹位置
                string folder = dgv_task.Rows[i].Cells[1].Value.ToString();
                string[] files = Directory.GetFiles(folder);
                for (int k = fileIndex; k < files.Length; k++)
                {
                    //计算百分率
                    double _processRate = 100 * Convert.ToDouble(k + 1) / Convert.ToDouble(files.Length);
                    dgv_task.Rows[i].Cells[3].Value = $"{_processRate.ToString("00.00")}%";
                    Application.DoEvents();

                    //如果用户终止了或者暂停了程序，就跳出循环
                    if (statue == 0 || statue == 2)
                    {
                        return;
                    }
                    fileIndex = k;//时刻记录当前程序执行到的文件位置
                    string file = files[k];
                    #region  1、文件名格式标准化
                    /*1、开始文件名格式标准化*/
                    //拆分出路径和文件名
                    string path = Path.GetDirectoryName(file);
                    string fileOriginal = Path.GetFileNameWithoutExtension(file);
                    string extension = Path.GetExtension(file);
                    string filename = string.Empty;//用于存放改后的文件名
                    ///拆分后的文件名集合,对list进行处理，如果是\d星，那么要和前一项合并
                    List<string> list = Regex.Split(fileOriginal, @"\.").ToList();
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (Regex.IsMatch(list[j], @"\d星"))
                        {
                            list[j] = $"{list[j - 1] }.{list[j]}";
                            list.RemoveAt(j - 1);
                            break;
                        }

                    }
                    //获得文件名标准格式下的所有rule名称
                    FormatInfo fi = new FormatInfo(SystemInfo._userInfo._wjmbzh);
                    fi.GetFormatInfo();
                    List<string> rules = Regex.Split(fi._formatSet, @"\|").ToList();
                    //对每一个rule循环，获得设置root
                    foreach (string rule in rules)
                    {
                        RuleInfo myri = new RuleInfo(rule);
                        myri.GetRuleInfo();
                        WjmRuleRoot myroot = ((WjmRuleRoot)myri._root);
                        //判断位置，得到操作目标,对每种可能的目标进行判断操作
                        if (myroot.position[0].Equals("整个文件名"))
                        {
                            //对操作目标进行操作
                            if (!myroot.delete.Trim().Equals(string.Empty))
                            {
                                filename = Regex.Replace(fileOriginal, myroot.delete.Trim(), "");
                            }
                            else if (!myroot.replace0.Trim().Equals(string.Empty))
                            {
                                filename = Regex.Replace(fileOriginal, myroot.replace0.Trim(), myroot.replace);
                            }
                        }
                        else if (myroot.position[0].Equals("文件名前"))
                        {
                            //新增内容
                            if (!myroot.newText.Trim().Equals(string.Empty))
                            {
                                filename = $"{myroot.newText}{fileOriginal}";
                            }
                        }
                        else if (myroot.position[0].Equals("文件名后"))
                        {
                            //新增内容
                            if (!myroot.newText.Trim().Equals(string.Empty))
                            {
                                filename = $"{fileOriginal}{myroot.newText}";
                            }
                        }
                        else if (Regex.IsMatch(myroot.position[0], @"文件名第\d项前"))
                        {
                            //获得数字，然后获得目标文本
                            int index = Convert.ToInt32(Regex.Match(myroot.position[0], @"\d").Value);
                            string target = list[index - 1];
                            //新增内容
                            if (!myroot.newText.Trim().Equals(string.Empty))
                            {
                                target = $"{myroot.newText.Trim()}{target}";
                            }
                            list[index - 1] = target;
                            filename = string.Join(".", list);
                        }
                        else if (Regex.IsMatch(myroot.position[0], @"文件名第\d项后"))
                        {
                            //获得数字，然后获得目标文本
                            int index = Convert.ToInt32(Regex.Match(myroot.position[0], @"\d").Value);
                            string target = list[index - 1];
                            //新增内容
                            if (!myroot.newText.Trim().Equals(string.Empty))
                            {
                                target = $"{target}{myroot.newText.Trim()}";
                            }
                            list[index - 1] = target;
                            filename = string.Join(".", list);
                        }
                        //给文件改名
                        File.Move($"{file}", $"{path}\\{filename}{extension}");

                    }

                    #endregion
                    string currentFilename = $"{path}\\{filename}{extension}";
                    #region 2、文档格式标准化
                    //获得标准化规则
                    FormatInfo _format = new FormatInfo(SystemInfo._userInfo._wjbzh);
                    _format.GetFormatInfo();
                    string _rule = Regex.Split(_format._formatSet, @"\|")[0];
                    RuleInfo _ruleInfo = new RuleInfo(_rule);
                    _ruleInfo.GetRuleInfo();
                    BzhRuleRoot _root = _ruleInfo._root as BzhRuleRoot;
                    //调整文档格式,包括大标题，副标题，正文，一级标题，二级标题，三级标题，页边距,
                    MyMethod.UpdateFormat2(currentFilename, _root);

                    //文本标注,暂时 放一放

                    #endregion
                    #region 3、查重清洗

                    #endregion
                    #region 4、基础解析

                    #endregion
                    JJDocument _jjDoc = new JJDocument(currentFilename);
                    var listbase=_jjDoc.GetBaseAnalysis();
                    _jjDoc.SaveList2Excel(listbase);
                    #region 5、内容解析

                    #endregion
                    #region 6、大数据版

                    #endregion
                }
            }
            //执行完成提示，完成并将系统状态还原为0
            statue = 0;
            lbl_kaishi.Enabled = true;

            lbl_kaishi.ForeColor = Color.White;
            lbl_kaishi.BackColor = Color.MediumSeaGreen;
            lbl_zhuangtai.Text = "已就绪，请点击\"开始\"执行解析";
            MessageBox.Show("本次数据处理已完成！");
        }








        /// <summary>
        /// 点击停止按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_tingzhi_Click(object sender, EventArgs e)
        {
            statue = 0;
            folderIndex = 0;
            fileIndex = 0;
            lbl_kaishi.Enabled = true;
            lbl_kaishi.ForeColor = Color.White;
            lbl_kaishi.BackColor = Color.MediumSeaGreen;
            lbl_zhuangtai.Text = "已就绪，请点击\"开始\"执行解析";

        }
        /// <summary>
        /// 点击暂停按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_zanting_Click(object sender, EventArgs e)
        {
            //判断程序如果已停止，那么不执行任何操作
            if (statue == 0)
            {
                return;
            }
            statue = 2;
            lbl_kaishi.Enabled = true;
            lbl_kaishi.ForeColor = Color.White;
            lbl_kaishi.BackColor = Color.MediumSeaGreen;
            lbl_zhuangtai.Text = "已暂停解析";
        }





    }
}
