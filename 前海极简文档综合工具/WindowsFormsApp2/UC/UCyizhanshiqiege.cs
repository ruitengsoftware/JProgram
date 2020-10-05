using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Controller;

namespace WindowsFormsApp2.UC
{
    public partial class UCyizhanshiqiege : UserControl
    {
        public UCyizhanshiqiege()
        {
            InitializeComponent();
        }

        private void TableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
        ControllerQiege _mycontroller = new ControllerQiege();
        private void UCyizhanshiqiege_Load(object sender, EventArgs e)
        {
            cbbzongtigeshi.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("totalname", "tablesplit");
            cbbzongtigeshi.Items.AddRange(list.ToArray());
        }

        private void cbbzongtigeshi_TextChanged(object sender, EventArgs e)
        {
            //加载总体格式
            //List<object> list_data = myMySqlHelper.ExecuteRow("select * from tablesplit where totalname='" + cbbzongtigeshi.Text + "'", null, null);
            Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"totalname",cbbzongtigeshi.Text }
            };

            var list_data = _mycontroller._sqlhelper.GetAnySet("tablesplit",mydic);
            //加载段落
            myflp.Controls.Clear();
            foreach (object o in list_data)
            {
                UCformate2w uce2w = new UCformate2w(o);
                uce2w.Dock = DockStyle.Top;
                myflp.Controls.Add(uce2w);
            }
            //加载选中标题
            flpfield.Controls.Clear();
            if (list_data.Count == 0)
            {
                return;
            }
            Dictionary<string, object> dic = list_data[0] as Dictionary<string, object>;
            string[] arr_allfields = dic["alltitle"].ToString().Split(new char[] { ',', '，' });
            for (int i = 0; i < arr_allfields.Length; i++)
            {
                Label lbl_field = new Label
                {
                    Text = arr_allfields[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 80,
                    Margin = new Padding(1, 1, 1, 1)
                };
                lbl_field.Click += Mylbl_Click;
                flpfield.Controls.Add(lbl_field);
            }
            string[] arr_title = dic["titlefields"].ToString().Split(new char[] { ',', '，' });
            foreach (Control c in flpfield.Controls)
            {
                if (arr_title.Contains(c.Text))
                {
                    c.BackColor = Color.SteelBlue;
                    c.ForeColor = Color.White;
                }
            }
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

        private void lbldelete_Click(object sender, EventArgs e)
        {
            //加载总体格式
            _mycontroller._sqlhelper.DeleteAnyFormat("totalname", cbbzongtigeshi.Text, "tablesplit");
            MessageBox.Show("删除格式成功！");

        }

        private void lblsave_Click(object sender, EventArgs e)
        {
            if (cbbzongtigeshi.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("总体格式名不许为空！");
                return;
            }

            string fieldstr = cbbzongtigeshi.Text;


            List<Dictionary<string, object>> list_dic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = null;
            for (int i = 0; i < myflp.Controls.Count; i++)
            {
                dic = new Dictionary<string, object>();
                //获得选中字段和全部字段
                List<string> list_allfields = new List<string>();
                List<string> list_selectfields = new List<string>();
                List<Control> list_control = new List<Control>();
                for (int j = 0; j < ((UCformate2w)myflp.Controls[i]).flp.Controls.Count; j++)
                {
                    list_allfields.Add(((UCformate2w)myflp.Controls[i]).flp.Controls[j].Text);
                    if (((UCformate2w)myflp.Controls[i]).flp.Controls[j].ForeColor == Color.White)//获得所有字段
                    {
                        list_selectfields.Add(((UCformate2w)myflp.Controls[i]).flp.Controls[j].Text);
                    }

                }
                List<string> list_alltitle = new List<string>();
                List<string> list_titlefields = new List<string>();
                for (int k = 0; k < flpfield.Controls.Count; k++)
                {
                    list_alltitle.Add(flpfield.Controls[k].Text);
                    if (flpfield.Controls[k].ForeColor == Color.White)
                    {
                        list_titlefields.Add(flpfield.Controls[k].Text);
                    }
                }
                dic["allfields"] = string.Join(",", list_allfields);
                dic["selectfields"] = string.Join(",", list_selectfields);
                dic["titlefields"] = string.Join(",", list_titlefields);
                dic["hangju"] = ((UCformate2w)myflp.Controls[i]).cbblinespace.Text;
                dic["hangjuvalue"] = ((UCformate2w)myflp.Controls[i]).nudlinespace.Value;
                dic["fontname"] = ((UCformate2w)myflp.Controls[i]).tbfontname.Text;
                dic["fontsize"] = ((UCformate2w)myflp.Controls[i]).nudfontsize.Value;
                dic["bold"] = ((UCformate2w)myflp.Controls[i]).cbbold.Checked;
                dic["position"] = ((UCformate2w)myflp.Controls[i]).cbbposition.Text;
                dic["space"] = ((UCformate2w)myflp.Controls[i]).cbbkonghang.Text;
                dic["suojin"] = ((UCformate2w)myflp.Controls[i]).nudsuojin.Value;
                dic["formatname"] = ((UCformate2w)myflp.Controls[i]).cbbformat.Text;
                dic["sort"] = i;
                dic["totalname"] = cbbzongtigeshi.Text;
                dic["alltitle"] = string.Join(",", list_alltitle);
                list_dic.Add(dic);
            }
            _mycontroller._sqlhelper.DeleteAnyFormat("totalname", fieldstr, "tablesplit");

            for (int i = 0; i < list_dic.Count; i++)
            {
                //保存数据
                _mycontroller._sqlhelper.SaveAnyFormat(list_dic[i], "tablesplit");
            }
            MessageBox.Show("保存数据成功！");
        }
    }
}
