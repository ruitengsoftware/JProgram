using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using RuiTengDll;
using WindowsFormsApp2.Controller;

namespace WindowsFormsApp2
{
    public partial class UCformate2w : UserControl
    {
        public setter mysetter = new setter();
        UIHelper mydrawer = new UIHelper();

        public UCformate2w()
        {
            InitializeComponent();
            //获得当前软件运行路径
        }
        /// <summary>
        /// 根据数据库中得到的数据生成一个ucformate2w
        /// </summary>
        /// <param name="o"></param>
        public UCformate2w(object o)
        {
            InitializeComponent();
            Dictionary<string, object> dic = o as Dictionary<string, object>;
            //flp加入lbl
            string[] arr_fields = dic["allfields"].ToString().Split(new char[] { ',', '，' });
            for (int i = 0; i < arr_fields.Length; i++)
            {
                Label lbl_field = new Label
                {
                    Text = arr_fields[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 80,
                    Margin = new Padding(1, 1, 1, 1)
                };
                lbl_field.Click += Mylbl_Click;
                flp.Controls.Add(lbl_field);
            }
            //选择lbl
            string[] arr_selected = dic["selectfields"].ToString().Split(new char[] { ',', '，' });
            foreach (Control c in flp.Controls)
            {
                if (arr_selected.Contains(c.Text))
                {
                    c.BackColor = Color.SteelBlue;
                    c.ForeColor = Color.White;
                }
            }

            //赋值其他的控件值
            cbblinespace.Text = dic["hangju"].ToString();
            nudlinespace.Value = Convert.ToDecimal(dic["hangjuvalue"]);
            tbfontname.Text = dic["fontname"].ToString();
            nudfontsize.Value = Convert.ToDecimal(dic["fontsize"]);
            cbbold.Checked = Convert.ToBoolean(dic["bold"]);
            cbbposition.Text = dic["myposition"].ToString();
            cbbkonghang.Text = dic["myspace"].ToString();
            nudsuojin.Value = Convert.ToDecimal(dic["suojin"]);
            cbbformat.Text = dic["formatname"].ToString();


        }

        public UCformate2w(List<string> list)
        {
            InitializeComponent();
            cbbold.Checked = false;
            cbblinespace.SelectedIndex = 0;
            cbbposition.SelectedIndex = 0;
            cbbkonghang.SelectedIndex = 0;
            //把标签加入控件中
            Label mylbl = null;
            for (int i = 0; i < list.Count; i++)
            {
                mylbl = new Label();
                mylbl.Margin = new Padding(2, 2, 2, 2);
                mylbl.Text = list[i];
                mylbl.BorderStyle = BorderStyle.FixedSingle;
                mylbl.TextAlign = ContentAlignment.MiddleCenter;
                mylbl.Click += Mylbl_Click;
                flp.Controls.Add(mylbl);
            }
            //向格式下拉框加载格式
            cbbformat.Items.Clear();
            var list0 = _mycontroller._sqlhelper.GetSingleField("name", "muban");
            cbbformat.Items.AddRange(list0.ToArray());
        }

        public void Mylbl_Click(object sender, EventArgs e)
        {
            Label lbl = ((Label)sender);
            if (lbl.BackColor == Color.SteelBlue)
            {
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Black;
            }
            else
            {
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.SteelBlue;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbfontname.Text = fd.Font.Name;
                nudfontsize.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cbbold.Checked = true;
                }
                else
                {
                    cbbold.Checked = false;
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //获得当前格式名称
            string formatname = string.Empty;
            if (cbbformat.Text.Equals(""))
            {
                MessageBox.Show("请输入格式名称！");
                return;
            }
            var list = _mycontroller._sqlhelper.GetSingleField("name", "muban");
            //如果不存在格式名称
            foreach (object o in list)
            {
                Dictionary<string, object> d = (Dictionary<string, object>)o;
                foreach (string item in d.Values)
                {
                    if (item.Equals(cbbformat.Text))
                    {
                        DialogResult dr = MessageBox.Show(string.Format("是否覆盖格式“{0}”相关的所有设置？", cbbformat.Text), "提示窗口", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (dr == DialogResult.OK)
                        {
                            Dictionary<string, object> dic0 = new Dictionary<string, object> {
                                { "lstype",cbblinespace.Text},
                                { "lsvalue",nudlinespace.Value},
                                {"fontname",tbfontname.Text },
                                { "fontsize",nudfontsize.Value},
                                { "bold",cbbold.Checked==true?1:0 },
                                {"position",cbbposition.Text },
                                {"space",cbbkonghang.Text },
                                { "suojin",nudsuojin.Value},
                             };
                            //删除格式
                            _mycontroller._sqlhelper.DeleteAnyFormat("name", cbbformat.Text, "muban");
                            //插入格式
                            _mycontroller._sqlhelper.SaveAnyFormat(dic0, "muban");

                            MessageBox.Show("格式设置修改成功！");
                            return;
                        }
                    }
                }
            }
            //提取当前格式为一个format
            Format f = new Format();
            f.formatname = cbbformat.Text;
            f.fontname = tbfontname.Text;
            f.fontsize = (Single)nudfontsize.Value;
            f.bold = cbbold.Checked ? 1 : 0;
            f.juzhong = cbbposition.Text;
            f.space = Convert.ToInt32(cbbkonghang.Text);
            f.suojin = Convert.ToSingle(nudsuojin.Value);
            f.lstype = cbblinespace.Text;
            f.lsvalue = Convert.ToSingle(nudlinespace.Value);


            //构建dic
            Dictionary<string, object> dic = new Dictionary<string, object> {
                { "name",f.formatname },
                { "fontname",f.fontname },
                { "fontsize",f.fontsize },
                { "lsvalue",f.lsvalue },
                { "lstype",f.lstype },
                { "bold",f.bold },
                { "position",f.juzhong },
                { "suojin",f.suojin },
                { "space",f.space }
            };

            //执行插入操作
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "muban");
            //操作成功提示
            MessageBox.Show("已成功保存该格式！");
        }
        ControllerFormate2w _mycontroller = new ControllerFormate2w();
        private void cbbgeshi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //将o转化为字典
            Dictionary<string, object> mydic = new Dictionary<string, object> {
               
                {"name", cbbformat.Text}
            };

            var list = _mycontroller._sqlhelper.GetAnySet("muban",mydic);
            Dictionary<string, object> dic = list[0];
            //给控件赋值
            tbfontname.Text = dic["fontname"].ToString();
            nudfontsize.Value = Convert.ToDecimal(dic["fontsize"]);
            cbbold.Checked = Convert.ToInt32(dic["bold"]) == 1 ? true : false;
            cbblinespace.Text = dic["lstype"].ToString();
            nudlinespace.Value = Convert.ToDecimal(dic["lsvalue"]);
            cbbkonghang.Text = dic["space"].ToString();
            nudsuojin.Value = Convert.ToDecimal(dic["suojin"]);
            cbbposition.Text = dic["position"].ToString();
        }

        private void label6_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect(((Control)sender));
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbblinespace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbblinespace.Text == "固定值")
            {
                nudlinespace.Enabled = true;
            }
            else
            {
                nudlinespace.Enabled = false;
            }
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin - 1));

        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin + 1));

        }
    }
}
