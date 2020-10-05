using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Entity;
using System.Data.SQLite;
using RuiTengDll;
using WindowsFormsApp2.DLL;
using WindowsFormsApp2.Controller;

namespace WindowsFormsApp2
{
    public partial class UCdata : UserControl
    {
        UIHelper mydrawer = new UIHelper();

        public UCdata()
        {
            InitializeComponent();
            label1_Click(null, null);
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect((Control)sender);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin - 1));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin + 1));

        }

        private void label1_Click(object sender, EventArgs e)
        {

            //隐藏查询框
            tbkeywords.Visible = false;
            DataTable dtbl = _mycontroller._sqlhelper.GetDataSet("*", "muban").Tables[0];
                    //dgvdata.AutoGenerateColumns = false;//不自动生成列，从数据库可能取得很多列，使其不显示在DataGridView中
                    this.dgvdata.DataSource = dtbl;
                    this.dgvdata.Columns["id"].HeaderText = "序号";
                    this.dgvdata.Columns["name"].HeaderText = "格式名";
                    this.dgvdata.Columns["lstype"].HeaderText = "行距类型";
                    this.dgvdata.Columns["lsvalue"].HeaderText = "行距值";
                    this.dgvdata.Columns["fontname"].HeaderText = "字体";
                    this.dgvdata.Columns["fontsize"].HeaderText = "字号";
                    this.dgvdata.Columns["bold"].HeaderText = "粗体";
                    this.dgvdata.Columns["suojin"].HeaderText = "首行缩进";
                    this.dgvdata.Columns["space"].HeaderText = "空行";
                    this.dgvdata.Columns["position"].HeaderText = "居中对齐";
                    this.dgvdata.Columns["deleted"].Visible = false;
                    //重新给id排序
                    for (int i = 0; i < dgvdata.Rows.Count; i++)
                    {
                        this.dgvdata.Rows[i].Cells["id"].Value = i + 1;
                    }
        }


        private void pbsearch_MouseEnter(object sender, EventArgs e)
        {
            //显示搜索栏
            tbkeywords.Visible = true;
            ((PictureBox)sender).Image = Properties.Resources.search2;

        }

        private void pbsearch_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.search1;

        }

        private void dgvdata_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //提取当前行内容，给文本框赋值
                int index = dgvdata.CurrentRow.Index;
                tbformatname.Text = dgvdata.Rows[index].Cells["name"].Value.ToString();
                cbblstype.Text = dgvdata.Rows[index].Cells["lstype"].Value.ToString();
                nudlsvalue.Value = Convert.ToDecimal(dgvdata.Rows[index].Cells["lsvalue"].Value.ToString());
                tbfontname.Text = dgvdata.Rows[index].Cells["fontname"].Value.ToString();
                nudfontsize.Value = Convert.ToDecimal(dgvdata.Rows[index].Cells["fontsize"].Value.ToString());
                cbbold.Checked = dgvdata.Rows[index].Cells["bold"].Value.ToString() == "1" ? true : false;
                cbbposition.Text = dgvdata.Rows[index].Cells["position"].Value.ToString();
                cbbspace.Text = dgvdata.Rows[index].Cells["space"].Value.ToString();

            }
            catch
            {
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pbsearch_Click(object sender, EventArgs e)
        {
            //打开数据库，得到全部记录

                    DataSet myset = _mycontroller._sqlhelper.GetDataSet("*", "muban", new Dictionary<string, object> { { "name", tbkeywords.Text } });
                    DataTable dtbl = myset.Tables[0];
                    //dgvdata.AutoGenerateColumns = false;//不自动生成列，从数据库可能取得很多列，使其不显示在DataGridView中
                    this.dgvdata.DataSource = dtbl;
                    this.dgvdata.Columns["id"].HeaderText = "序号";
                    this.dgvdata.Columns["name"].HeaderText = "格式名";
                    this.dgvdata.Columns["lstype"].HeaderText = "行距类型";
                    this.dgvdata.Columns["lsvalue"].HeaderText = "行距值";
                    this.dgvdata.Columns["fontname"].HeaderText = "字体";
                    this.dgvdata.Columns["fontsize"].HeaderText = "字号";
                    this.dgvdata.Columns["bold"].HeaderText = "粗体";
                    this.dgvdata.Columns["suojin"].HeaderText = "首行缩进";
                    this.dgvdata.Columns["space"].HeaderText = "空行";
                    this.dgvdata.Columns["position"].HeaderText = "居中对齐";
                    this.dgvdata.Columns["deleted"].Visible = false;
        }
        MySqlHelper _mysqlhelper = new MySqlHelper();

        ControllerData _mycontroller = new ControllerData();
        /// <summary>
        /// 点击修改格式触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label4_Click(object sender, EventArgs e)
        {
            int index = dgvdata.CurrentRow.Index;
            Dictionary<string, object> entity = new Dictionary<string, object> {
                                { "lstype",cbblstype.Text},
                                { "lsvalue",nudlsvalue.Value},
                                {"fontname",tbfontname.Text },
                                { "fontsize",nudfontsize.Value},
                                { "bold",cbbold.Checked==true?1:0 },
                                {"position",cbbposition.Text },
                                {"space",cbbspace.Text },
                                { "suojin",nudsuojin.Value},
                             };

            DialogResult dr = MessageBox.Show(string.Format("确定修改格式“{0}”的相关设置？", tbformatname.Text), "消息提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //删除格式
                _mycontroller._sqlhelper.DeleteAnyFormat("name", tbformatname.Text, "muban");
                //保存格式
                _mycontroller._sqlhelper.SaveAnyFormat(entity, "muban");
                label1_Click(null, null);
                foreach (DataGridViewRow item in dgvdata.Rows)
                {
                    item.Selected = false;
                }
                dgvdata.Rows[index].Selected = true; ;
                MessageBox.Show(string.Format("已成功修改格式！"));

            }


        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label3_Click(object sender, EventArgs e)
        {
         
            DialogResult dr = MessageBox.Show(string.Format("确定删除格式“{0}”？", tbformatname.Text), "消息提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                _mycontroller._sqlhelper.DeleteAnyFormat("name", tbformatname.Text, "muban");
                label1_Click(null, null);
                MessageBox.Show(string.Format("已成功删除格式！", tbformatname.Text));
            }


        }

        private void button1_Click(object sender, EventArgs e)
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

        private void cbblstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbblstype.Text == "固定值")
            {
                nudlsvalue.Enabled = true;
            }
            else
            {
                nudlsvalue.Enabled = false;
            }
        }
    }
}
