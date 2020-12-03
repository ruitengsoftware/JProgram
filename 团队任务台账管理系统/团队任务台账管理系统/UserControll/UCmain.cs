using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.WinForm;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCmain : UserControl
    {
        ControllerWFmain _mycontroller = new ControllerWFmain();

        public UCmain()
        {
            InitializeComponent();
        }

        private void btn_daiban_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCdaiban uc_daiban = new UCdaiban();
            uc_daiban.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_daiban);

        }

        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCxinjian uc_xinjian = new UCxinjian();
            uc_xinjian.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_xinjian);

        }

        private void btn_tuandui_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCtuandui uc_tuandui = new UCtuandui();
            uc_tuandui.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_tuandui);

        }

        private void btn_rizhi_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCrizhi uc_rizhi = new UCrizhi();
            uc_rizhi.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_rizhi);
        }

        private void btn_fankui_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(new UCfankui() { Dock = DockStyle.Fill }); ;
        }

        private void btn_xiaoxiang_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();

            parent.Controls.Add(new UCxiaoxiang() { Dock = DockStyle.Fill }); ;

        }

        private void btn_shouquan_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();

            parent.Controls.Add(new UCshouquan() { Dock = DockStyle.Fill });

        }

        private void tb_qianming_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BorderStyle = BorderStyle.FixedSingle;
        }

        private void tb_qianming_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BorderStyle = BorderStyle.None;

        }

        private void UCmain_Load(object sender, EventArgs e)
        {
            //加载ucmain的时候要提取登陆者信息，显示在界面中
            lbl_name.Text = $"{JJModel.JJPersonInfo._shiming}({JJPersonInfo._huaming})";
            tb_qianming.Text = JJPersonInfo._gerenqianming;
            /*加载登录者的任务*/
            //加载第一象限
            DataTable mydt = _mycontroller.GetRenwu("第一象限");
            dgv_a.DataSource = null;
            dgv_a.DataSource = mydt;
            lbl_a.Text = $"重要且紧急-立即做 {mydt.Rows.Count}项";
            //加载第二象限
            mydt = _mycontroller.GetRenwu("第二象限");
            dgv_b.DataSource = null;
            dgv_b.DataSource = mydt;
            lbl_b.Text = $"重要且不紧急-集中精力做 {mydt.Rows.Count}项";

            //加载第三象限
            mydt = _mycontroller.GetRenwu("第三象限");
            dgv_c.DataSource = null;
            dgv_c.DataSource = mydt;
            lbl_c.Text = $"不重要但紧急-找帮手做 {mydt.Rows.Count}项";
            //加载第四象限
            mydt = _mycontroller.GetRenwu("第四象限");
            dgv_d.DataSource = null;
            dgv_d.DataSource = mydt;
            lbl_d.Text = $"不重要且不紧急-抽空做 {mydt.Rows.Count}项";

            /*刷新待办任务*/
          mydt=  _mycontroller.GetDaibanRenwu();
            dgv_daiban.DataSource = null;
            dgv_daiban.DataSource = mydt;



        }

        private void lbl_name_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            string zhuangtai = lbl_xiugai.Text;
            if (zhuangtai.Equals("修改"))
            {

                tb_qianming.BorderStyle = BorderStyle.FixedSingle;
                tb_qianming.Focus();
                lbl_xiugai.Text = "保存";
            }
            else
            {
                tb_qianming.BorderStyle = BorderStyle.None;
                bool b=_mycontroller.UpdateGerenqianming(tb_qianming.Text);
                             lbl_xiugai.Text = "修改";

            }
        }
        /// <summary>
        /// 点击钉子按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_dingzi_Click(object sender, EventArgs e)
        {
            WinForm.WinFormXinjiangongzuoqingdan mywinform = new WinForm.WinFormXinjiangongzuoqingdan();
            if (mywinform.ShowDialog()==DialogResult.OK)
            {
                //更新任务内容
                UCmain_Load(null, null);


            }
        }

        private void dgv_a_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    ((DataGridView)sender).ClearSelection();
                    ((DataGridView)sender).Rows[e.RowIndex].Selected = true;
                    ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                   cms_right.Show(MousePosition.X, MousePosition.Y);//dgv_rightmenu是鼠标右键菜单控件
                }
            }
        }

        private void dgv_daiban_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //判断是否点击了任务名称列
            bool b = ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("任务名称");
            //获得任务名称
            string renwuming = ((DataGridView)sender).CurrentCell.Value.ToString();
            //如果是的话弹出任务详情窗体
            if (b)
            {
                WinFormRenwuxiangqing mywin = new WinFormRenwuxiangqing(renwuming);
                if (mywin.ShowDialog()==DialogResult.OK)
                {
                    this.UCmain_Load(null, null);
                }





            }
        }
    }
}
