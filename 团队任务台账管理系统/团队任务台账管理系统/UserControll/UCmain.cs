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
        ControllerUCmain _mycontroller = new ControllerUCmain();
        //记录当前右键选中的dgv
        DataGridView dgv_right = null;
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
            lbl_name.Text = $"{JJModel.JJLoginInfo._shiming}({JJLoginInfo._huaming})";
            tb_qianming.Text = JJLoginInfo._gerenqianming;
            /*加载登录者的任务*/
            int qingdannum = 0;//储存工作清单总数
            //加载第一象限
            DataTable mydt = _mycontroller.GetGongzuoqingdan("第一象限");
            dgv_a.DataSource = null;
            dgv_a.DataSource = mydt;
            lbl_a.Text = $"重要且紧急-立即做 {mydt.Rows.Count}项";
            qingdannum += mydt.Rows.Count;
            //加载第二象限
            mydt = _mycontroller.GetGongzuoqingdan("第二象限");
            dgv_b.DataSource = null;
            dgv_b.DataSource = mydt;
            lbl_b.Text = $"重要且不紧急-集中精力做 {mydt.Rows.Count}项";
            qingdannum += mydt.Rows.Count;

            //加载第三象限
            mydt = _mycontroller.GetGongzuoqingdan("第三象限");
            dgv_c.DataSource = null;
            dgv_c.DataSource = mydt;
            lbl_c.Text = $"不重要但紧急-找帮手做 {mydt.Rows.Count}项";
            qingdannum += mydt.Rows.Count;

            //加载第四象限
            mydt = _mycontroller.GetGongzuoqingdan("第四象限");
            dgv_d.DataSource = null;
            dgv_d.DataSource = mydt;
            lbl_d.Text = $"不重要且不紧急-抽空做 {mydt.Rows.Count}项";
            qingdannum += mydt.Rows.Count;

            //刷新工作清单总数
            lbl_gongzuoqingdan.Text = $"工作清单  {qingdannum}项";



            /*刷新待办任务*/
            mydt = _mycontroller.GetDaibanRenwu();
            dgv_daiban.DataSource = null;
            dgv_daiban.DataSource = mydt;
            /*刷新通知公告*/
            mydt = _mycontroller.GetTongzhi();
            dgv_tongzhi.DataSource = null;
            dgv_tongzhi.DataSource = mydt;


        }

        private void lbl_name_Click(object sender, EventArgs e)
        {
            //弹出注册窗体
            WFzhuce mywin = new WFzhuce(0);
            if (mywin.ShowDialog() == DialogResult.OK)
            {

            }

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
                bool b = _mycontroller.UpdateGerenqianming(tb_qianming.Text);
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
            WinForm.WFgongzuoqingdan mywinform = new WinForm.WFgongzuoqingdan();
            if (mywinform.ShowDialog() == DialogResult.OK)
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
                    dgv_right = (DataGridView)sender;
                }
            }
        }

        private void dgv_daiban_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //判断是否左键点击
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            //判断是否点击了任务名称列
            bool b = ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("任务名称");
            //获得任务名称
            string renwuming = ((DataGridView)sender).CurrentCell.Value.ToString();
            //如果是,构造jjchangguiinfo,弹出任务详情窗体
            DataGridViewRow mydr = dgv_daiban.CurrentRow;
            JJchangguiInfo info = new JJchangguiInfo()
            {
                _renwumingcheng = mydr.Cells["任务名称"].Value.ToString(),
                _jinjichengdu = mydr.Cells["紧急程度"].Value.ToString(),
                _jutiyaoqiu = mydr.Cells["具体要求"].Value.ToString(),
                _zerenren = mydr.Cells["责任人"].Value.ToString(),
                _yanshouren = mydr.Cells["验收人"].Value.ToString(),
                _shixian = mydr.Cells["时限"].Value.ToString(),
                _jinzhanqingkuang = mydr.Cells["进展情况"].Value.ToString()
            };



            if (b)
            {

                WFdaiban mywin = new WFdaiban(info);
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    ///刷新数据
                    this.UCmain_Load(null, null);
                }
            }
        }

        private void dgv_a_Paint(object sender, PaintEventArgs e)
        {
            DataGridView mydgv = sender as DataGridView;
            /*过期清单标记为红色*/
            //获得当前日期
            DateTime _now = DateTime.Now;
            //循环获得dgv中的日期
            for (int i = 0; i < mydgv.Rows.Count; i++)
            {
                DataGridViewRow myrow = mydgv.Rows[i];
                DateTime _finish = Convert.ToDateTime(myrow.Cells["完成时间"].Value);
                //判断，如果当前日期>完成日期
                if (_now > _finish)
                {
                    //显示为红色
                    mydgv.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得按钮所在的contextmenustrip
            //获得选中行,构造一个清单info
            var mydr = dgv_right.CurrentRow;
            JJQingdanInfo myqi = new JJQingdanInfo()
            {
                _renwumingcheng = mydr.Cells["任务名称"].Value.ToString(),
                _xiangxian = mydr.Cells["象限"].Value.ToString(),
                _zhubanren = mydr.Cells["主办人"].Value.ToString(),
                _wanchengshijian = mydr.Cells["完成时间"].Value.ToString()

            };
            //构造一个wfgongzuoqingdan
            WFgongzuoqingdan mywin = new WFgongzuoqingdan(myqi);
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                //更新任务内容
                UCmain_Load(null, null);

            }




        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得清单名称
            string qingdanmingcheng = dgv_right.CurrentRow.Cells["任务名称"].Value.ToString();

            //删除清单和人名对应的这条清单，删除=1
            bool b = _mycontroller.DeleteQingdan(qingdanmingcheng);
            if (b)
            {
                //更新任务内容
                UCmain_Load(null, null);
            }
        }

        private void 完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得清单名称
            string qingdanmingcheng = dgv_right.CurrentRow.Cells["任务名称"].Value.ToString();

            //删除清单和人名对应的这条清单，删除=1
            bool b = _mycontroller.FinishQingdan(qingdanmingcheng);
            if (b)
            {
                //更新任务内容
                UCmain_Load(null, null);
            }
        }
        /// <summary>
        /// 重回通知公告信息时触发的事件，未读的通知要加粗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_tongzhi_Paint(object sender, PaintEventArgs e)
        {
            DataGridView mydgv = sender as DataGridView;
            int weidunum = 0;//记录未读数量
            for (int i = 0; i < mydgv.Rows.Count; i++)
            {
                string zhuangtai = mydgv.Rows[i].Cells["状态"].Value.ToString();
                if (zhuangtai.Equals("未读"))
                {
                    mydgv.Rows[i].DefaultCellStyle.Font = new Font(mydgv.Font, FontStyle.Bold);
                    weidunum++;
                }


            }
            //刷新通知公告栏 数量
            lbl_gonggao.Text = $"通知公告 （{weidunum}）";

        }
    }
}

