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
using MySql.Data.MySqlClient;
using WindowsFormsApp2.Controller;
using Spire.Xls;
using System.Web.Security;
using RuiTengDll;

namespace WindowsFormsApp2
{
    public partial class UCFormat : UserControl
    {
       UIHelper mydrawer = new UIHelper();
        MySqlHelper mydber = null;



        public UCFormat()
        {
            InitializeComponent();
            List<string> list = _mycontroller.GetFormatName("name", "muban");
            cbbformat.Items.Clear();
            cbbformat.Items.AddRange(list.ToArray());

        }

        private void btnfont_Click(object sender, EventArgs e)
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

        private void btnfont_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect(btnfont);
        }

        /// <summary>
        /// 格式列表内容发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbgeshi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string formatname = cbbformat.Text;
            //打开数据库
            Dictionary<string, object> dic = _mycontroller.GetSet(formatname);
            //给控件赋值
            tbfontname.Text = dic["fontname"].ToString();
            nudfontsize.Value = Convert.ToDecimal(dic["fontsize"]);
            cbbold.Checked = Convert.ToInt32(dic["bold"]) == 1 ? true : false;
            cbblstype.Text = dic["lstype"].ToString();
            nudlsvalue.Value = Convert.ToDecimal(dic["lsvalue"]);
            cbbspace.Text = dic["space"].ToString().Equals("")?"0":dic["space"].ToString();
            nudsuojin.Value = Convert.ToDecimal(dic["suojin"]);
            cbbposition.Text = dic["position"].ToString();
            


        }

        private void label6_Paint(object sender, PaintEventArgs e)
        {
           UIHelper mydrawer = new UIHelper();
            mydrawer.DrawRoundRect((Control)sender);
        }
        /// <summary>
        /// 点击保存按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label6_Click(object sender, EventArgs e)
        {
            //获得当前格式名称
            string formatname = cbbformat.Text;
            
            //重新保存该模板
            Dictionary<string, object> entity = new Dictionary<string, object> {
               { "lstype",cbblstype.Text},
               { "lsvalue",nudlsvalue.Value},
               {"fontname",tbfontname.Text },
               { "fontsize",nudfontsize.Value},
               { "bold",cbbold.Checked==true?1:0 },
               {"position",cbbposition.Text },
               {"space",cbbspace.Text },
               { "suojin",nudsuojin.Value},
               { "name",formatname}
            };
            _mycontroller.DeleteFormat(formatname);
            _mycontroller.SaveFormat(entity);
            MessageBox.Show("保存格式成功！");
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
        ControllerFormat _mycontroller = new ControllerFormat();
        private void cbbformat_DropDown(object sender, EventArgs e)
        {
            //向下拉菜单重新添加格式
            List<string> list = _mycontroller.GetFormatName("name", "muban");
            cbbformat.Items.Clear();
            cbbformat.Items.AddRange(list.ToArray());
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, -1);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, 1);
        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_shanchu_Click(object sender, EventArgs e)
        {
            string formatname = cbbformat.Text;
            _mycontroller.DeleteFormat(formatname);
            MessageBox.Show($"格式{formatname}已删除！");
        }

        private void UCFormat_Load(object sender, EventArgs e)
        {
        }
    }
}
