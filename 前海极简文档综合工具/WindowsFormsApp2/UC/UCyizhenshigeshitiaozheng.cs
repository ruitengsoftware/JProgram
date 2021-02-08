using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuiTengDll;
using WindowsFormsApp2.Controller;

namespace WindowsFormsApp2.UC
{
    public partial class UCyizhenshigeshitiaozheng : UserControl
    {
        UIHelper UIHelper = new UIHelper();

        public UCyizhenshigeshitiaozheng()
        {
            InitializeComponent();
            //向标题和正文添加ucformat
            for (int i = 0; i < mytabcontrol.TabPages.Count - 1; i++)
            {
                UCFormat ucformat = new UCFormat();
                ucformat.Dock = DockStyle.Fill;
                mytabcontrol.TabPages[i].Controls.Add(ucformat);
            }
        }
        private void UCyizhenshigeshitiaozheng_Load(object sender, EventArgs e)
        {
        }

        private void Cbbzongtigeshi_TextChanged(object sender, EventArgs e)
        {
            MySetting.Default.updateformattotalformat = ((Control)sender).Text;
            /**/
            string ttname = cbbzongtigeshi.Text;

            /*加载总体格式*/
            //获得所有的字段记录
            Dictionary<string, object> dic0 = _mycontroller.GetFormatSet(ttname);
            ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbbformat.Text = dic0["dabiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usedabiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbbformat.Text = dic0["fubiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usefubiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbbformat.Text = dic0["zhengwen"].ToString();
            ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usezhengwen"]);
            ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbbformat.Text = dic0["yijibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["useyijibiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbbformat.Text = dic0["erjibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["useerjibiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbbformat.Text = dic0["sanjibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usesanjibiaoti"]);
            cbqiyong.Checked = Convert.ToBoolean(dic0["useyemian"]);
            cbpage.Checked = Convert.ToBoolean(dic0["useyema"]);
            cbqiyongyemei.Checked = Convert.ToBoolean(dic0["useyemei"]);
            cbqiyongyejiao.Checked = Convert.ToBoolean(dic0["useyejiao"]);

            cbbbianju.Text = dic0["yemian"].ToString();
            cbbymname.Text = dic0["yemei"].ToString();
            cbbyjname.Text = dic0["yejiao"].ToString();
        }
        /// <summary>
        /// 点击删除按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lblshanchu_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbzongtigeshi.Text;
            _mycontroller.DeleteFormat(fieldstr, "tabletotalformat");
            MessageBox.Show("删除数据成功！");

        }

        private void Lblbaocun_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void Lblbaocun_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            UIHelper.UpdateCSize((Control)sender, 1);

        }

        private void Lblbaocun_Click(object sender, EventArgs e)
        {
            if (cbbzongtigeshi.Text.Trim() == "")
            {
                MessageBox.Show("格式名称不允许为空！");
                return;
            }

            string fieldstr = cbbzongtigeshi.Text;
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("dabiaoti", ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbbformat.Text);
            dic.Add("usedabiaoti", ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbenable.Checked);
            dic.Add("fubiaoti", ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbbformat.Text);
            dic.Add("usefubiaoti", ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbenable.Checked);
            dic.Add("zhengwen", ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbbformat.Text);
            dic.Add("usezhengwen", ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbenable.Checked);
            dic.Add("yijibiaoti", ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbbformat.Text);
            dic.Add("useyijibiaoti", ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbenable.Checked);
            dic.Add("erjibiaoti", ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbbformat.Text);
            dic.Add("useerjibiaoti", ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbenable.Checked);
            dic.Add("sanjibiaoti", ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbbformat.Text);
            dic.Add("usesanjibiaoti", ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbenable.Checked);
            dic.Add("yemian", cbbbianju.Text);
            dic.Add("useyemian", cbqiyong.Checked);
            dic.Add("yemei", cbbymname.Text);
            dic.Add("useyemei", cbqiyongyemei.Checked);
            dic.Add("yejiao", cbbyjname.Text);
            dic.Add("useyejiao", cbqiyongyejiao.Checked);
            dic.Add("useyema", cbpage.Checked);
            dic.Add("ttname", cbbzongtigeshi.Text);

           //向数据库插入数据
            _mycontroller.SaveFormat(dic);
        }

        private void Lblbaocun_Paint(object sender, PaintEventArgs e)
        {
            //向页面添加页边距
            UIHelper.DrawRoundRect((Control)sender);

        }
        ControllerYizhanshi _mycontroller = new ControllerYizhanshi();
        private void cbbzongtigeshi_DropDown(object sender, EventArgs e)
        {
            cbbzongtigeshi.Items.Clear();
            cbbzongtigeshi.Items.AddRange(_mycontroller.GetFormatName().ToArray());
        }
    }
}
