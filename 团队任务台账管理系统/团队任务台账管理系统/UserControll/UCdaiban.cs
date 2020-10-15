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
using System.Text.RegularExpressions;
using 团队任务台账管理系统.Properties;

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

                    //MessageBox.Show("Test");
                    //item.DefaultCellStyle.Font = new Font(dgv_data.Font, FontStyle.Bold);
                    //item.Cells[1].Style.Font = new Font("隶书", 9);
                    // item.Cells["紧急程度"].Style.Font = new Font(dgv_data.Font, FontStyle.Bold);
                    item.DefaultCellStyle.BackColor = Color.Black;
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
            string fenjie = dgv_data.CurrentRow.Cells["分解"].Value.ToString();
            string jinzhan = dgv_data.CurrentRow.Cells["进展"].Value.ToString();
            string mingcheng = dgv_data.CurrentRow.Cells["任务名称"].Value.ToString();
            string banliren = dgv_data.CurrentRow.Cells["办理人"].Value.ToString();
            string yanshouren = dgv_data.CurrentRow.Cells["验收人"].Value.ToString();
            //显示再窗体上
            tb_renwumingcheng.Text = mingcheng;
            tb_jutiyaoqiu.Text = yaoqiu;
            tb_fenjie.Text = fenjie;
            tb_jinzhan.Text = jinzhan;
            tb_banliren.Text = banliren;
            tb_yanshouren.Text = yanshouren;

            //判断记录是否为已读，如果未读更新该条记录为已读，并更新开始时间，如果已读不在执行
            int yidu = Convert.ToInt32(dgv_data.CurrentRow.Cells["已读"].Value);
            if (yidu == 0)
            {


                string str_time = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

                string renwumingcheng = dgv_data.CurrentRow.Cells["任务名称"].Value.ToString();
                mycontroller.UpdateData(renwumingcheng, str_time);
                //更新状态栏标题,当前行已读为1，获得data，计算总未读
                dgv_data.CurrentRow.Cells["已读"].Value = 1;
                dgv_data.CurrentRow.Cells["打开时间"].Value = str_time;

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
        /// <summary>
        /// 点击更新按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gengxin_Click(object sender, EventArgs e)
        {
            //获得 任务名称，具体要求，分解，进展
            string mingcheng = tb_renwumingcheng.Text;
            string yaoqiu = tb_jutiyaoqiu.Text;
            string fenjie = tb_fenjie.Text;
            string jinzhan = tb_jinzhan.Text;
            string banliren = tb_banliren.Text;
            string yanshouren = tb_yanshouren.Text;
            bool b = mycontroller.UpdateTask(mingcheng, yaoqiu, fenjie, jinzhan, banliren,yanshouren);
            //刷新数据
            int selectindex = dgv_data.SelectedRows[0].Index;
            UCdaiban_Load(null, null);
            dgv_data.Rows[0].Selected = false;
            dgv_data.Rows[selectindex].Selected = true;
            if (b) MessageBox.Show("更新数据成功！");

        }

        private void pb_tianjia_Click(object sender, EventArgs e)
        {
            string str_person = tb_banliren.Text;
            //打开人员表,选择人员并确认
            WFperson mywfperson = new WFperson(str_person);
            if (mywfperson.ShowDialog() == DialogResult.OK)
            {
                string xingming = string.Join(",", mywfperson.list_person);
                tb_banliren.Text = xingming;
            }

        }
        /// <summary>
        /// 点击发送按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fasong_Click(object sender, EventArgs e)
        {
            string renwumingcheng = tb_renwumingcheng.Text;
            string yanshouren = tb_yanshouren.Text;
            //获得办理人员的名单

            string banliren = tb_banliren.Text ;
            List<string> list_person = Regex.Split(banliren, @"[,，]").ToList();

            //将任务名称和发送时间，办理人员存入数据库中jjtasksend
           bool b= mycontroller.SendTask(renwumingcheng, list_person, yanshouren);

            if (b) MessageBox.Show("任务发送成功！");


        }

        private void pb_yanshou_Click(object sender, EventArgs e)
        {
            string str_person = tb_yanshouren.Text;
            //打开人员表,选择人员并确认
            WFperson mywfperson = new WFperson(str_person);
            if (mywfperson.ShowDialog() == DialogResult.OK)
            {
                string xingming = string.Join(",", mywfperson.list_person);
                tb_yanshouren.Text = xingming;
            }
        }
        /// <summary>
        /// 点击提交验收按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_yanshou_Click(object sender, EventArgs e)
        {
            string renwumingcheng = tb_renwumingcheng.Text;
            string yanshouren = tb_yanshouren.Text;
           
            //将任务名称和发送时间，办理人员存入数据库中jjtasksend
            bool b = mycontroller.TijiaoYanshou(renwumingcheng, Settings.Default.user);

            if (b) MessageBox.Show("任务已提交验收！");
        }
        /// <summary>
        /// 点击通过验收按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_tongguoyanshou_Click(object sender, EventArgs e)
        {
            string renwumingcheng = tb_renwumingcheng.Text;
            string yanshouren = tb_yanshouren.Text;

            //将任务名称和发送时间，办理人员存入数据库中jjtasksend
            bool b = mycontroller.YanshouRenwu(renwumingcheng, Settings.Default.user);

            if (b) MessageBox.Show("任务已通过验收！");
        }
    }
}
