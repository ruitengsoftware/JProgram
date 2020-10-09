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
            //var datarows=data.Select("已读=0");//获得未读数量
            //int num = data.Rows.Count;
            //lbl_biaoti.Text = $"待办任务({num}项,未读{datarows.Length}项)";

        }

        private void dgv_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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




        }
    }
}
