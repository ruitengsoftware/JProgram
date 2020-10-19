using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.WinForm;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCfankui : UserControl
    {
        ControllerFankui mycontroller = new ControllerFankui();
        public UCfankui()
        {
            InitializeComponent();
        }

        private void UCfankui_Load(object sender, EventArgs e)
        {
            //清空dgv_data
            dgv_data.DataSource = null;
            //获得全部数据
            DataTable mydt = mycontroller.GetFankui();
            //刷新显示数据
            dgv_data.DataSource = mydt;
            dgv_data_CellMouseClick(null, null);
        }

        private void dgv_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv_data.CurrentCell==null)
            {
                return;
            }
            //获得选中行
            DataGridViewRow mydr = dgv_data.CurrentCell.OwningRow;
            //显示信息
            string mingcheng = mydr.Cells["名称"].Value.ToString();
            string lianxifangshi = mydr.Cells["联系方式"].Value.ToString();
            string duixiang = mydr.Cells["对象"].Value.ToString();
            string neirong = mydr.Cells["内容"].Value.ToString();
            tb_mingcheng.Text = mingcheng;
            tb_lianxifangshi.Text = lianxifangshi;
            tb_duixiang.Text = duixiang;
            tb_neirong.Text = neirong;

        }


        private void btn_shanchufankui_Click(object sender, EventArgs e)
        {
            string mingcheng = tb_mingcheng.Text;
            bool b = mycontroller.Shanchufankui(mingcheng);
            Action myfun = () =>
            {
                //清空dgv_data
                dgv_data.DataSource = null;
                //获得全部数据
                DataTable mydt = mycontroller.GetFankui();
                //刷新显示数据
                dgv_data.DataSource = mydt;
                dgv_data_CellMouseClick(null, null);
            };
            myfun();
            if (b) MessageBox.Show("已删除该条反馈！");
        }

        private void btn_xinjianfankui_Click(object sender, EventArgs e)
        {
            WFfankui mywinform = new WFfankui();
            mywinform.StartPosition = FormStartPosition.CenterParent;
            mywinform.updatedata = () => {
                //清空dgv_data
                dgv_data.DataSource = null;
                //获得全部数据
                DataTable mydt = mycontroller.GetFankui();
                //刷新显示数据
                dgv_data.DataSource = mydt;
                dgv_data_CellMouseClick(null, null);
            };
            if (mywinform.ShowDialog() == DialogResult.OK)
            {



            }
        }
        /// <summary>
        /// 点击保存修改按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_baocunxiugai_Click(object sender, EventArgs e)
        {
            //获得名称，联系方式，对象，内容
            string mingcheng = tb_mingcheng.Text.Trim();
            string lianxifangshi = tb_lianxifangshi.Text.Trim();
            string duixiang = tb_duixiang.Text.Trim();
            string neirong = tb_neirong.Text.Trim();
            //更新数据库中该条反馈

            bool b = mycontroller.UpdateFankui(mingcheng, lianxifangshi, duixiang, neirong);
            if (b)
            {
                //刷新数据
                Action myfun = () =>
                {
                    //清空dgv_data
                    dgv_data.DataSource = null;
                    //获得全部数据
                    DataTable mydt = mycontroller.GetFankui();
                    //刷新显示数据
                    dgv_data.DataSource = mydt;
                    dgv_data_CellMouseClick(null, null);
                };
                myfun();
                MessageBox.Show("修改已保存成功！");
            }


        }
    }
}
