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

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCdaiban : UserControl
    {
        public UCdaiban()
        {
            InitializeComponent();
        }
        ControllerUCdaiban mycontroller = new ControllerUCdaiban();
        private void UCdaiban_Load(object sender, EventArgs e)
        {
            //刷新数据
            var data = mycontroller.GetData();
            dgv_data.DataSource = null;
            dgv_data.DataSource = data;

            //刷新标题栏代办和未读的数量
            var datarows = data.Select("已读=0");//获得未读数量
            int num = data.Rows.Count;
            lbl_biaoti.Text = $"待办任务( {num} 项,未读 {datarows.Length} 项)";
            //给未读的任务加粗


            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                var item = dgv_data.Rows[i];
                if (Convert.ToInt32(item.Cells["已读"].Value) == 0)
                {

                    MessageBox.Show("Test");
                    //item.DefaultCellStyle.Font = new Font(dgv_data.Font, FontStyle.Bold);
                    //item.Cells[1].Style.Font = new Font("隶书", 9);
                   //item.Cells["紧急程度"].Style.Font = new Font(dgv_data.Font, FontStyle.Bold);
                    //item.DefaultCellStyle.ForeColor = Color.Black;
                    //Application.DoEvents();
                }

            }


        }

        /// <summary>
        /// 点击dgv_data时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //获得选中行的任务具体要求
            string yaoqiu = dgv_data.CurrentRow.Cells["具体要求"].Value.ToString();
            //显示再窗体上
            lbl_xiangqing.Text = yaoqiu;
            //更新该条记录为已读
            string renwumingcheng = dgv_data.CurrentRow.Cells["任务名称"].Value.ToString();
            mycontroller.UpdateData(renwumingcheng);
            //更新状态栏标题,当前行已读为1，获得data，计算总未读
            dgv_data.CurrentRow.Cells["已读"].Value = 1;
            Application.DoEvents();
            int numweidu = mycontroller.GetWeidu();
            lbl_biaoti.Text = $"待办任务( {dgv_data.Rows.Count} 项,未读 {numweidu} 项)";
            //给未读的任务加粗
            foreach (DataGridViewRow item in dgv_data.Rows)
            {
                if (Convert.ToInt32(item.Cells["已读"].Value) == 0)
                {
                    //item.DefaultCellStyle.Font = new Font(dgv_data.Font, FontStyle.Bold);
                    //item.Cells[1].Style.Font = new Font("隶书", 9);
                    item.DefaultCellStyle.Font = new Font(dgv_data.Font, FontStyle.Bold);
                }
            }

        }





    }
}
