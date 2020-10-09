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
    public partial class UCxiaoxiang : UserControl
    {
        public UCxiaoxiang()
        {
            InitializeComponent();
        }
        ControllerUCxiaoxiang mycontroller = new ControllerUCxiaoxiang();
        private void UCxiaoxiang_Load(object sender, EventArgs e)
        {
            var data = mycontroller.GetData();
            dgv_data.DataSource = null;
            dgv_data.DataSource = data;
        }

        private void btn_renwuxiaoxiang_Click(object sender, EventArgs e)
        {
            //获得选中任务的名称
            string renwumingcheng = dgv_data.CurrentRow.Cells[0].Value.ToString();

            //更新该任务的状态为销项
            string str_sql = $"update jjtask set 状态='已撤销' where 任务名称='{renwumingcheng}' ";
           bool b= mycontroller.UpdateData(str_sql);
            if (b) MessageBox.Show("销项成功！");

            //刷新数据
            var data = mycontroller.GetData();
            dgv_data.DataSource = null;
            dgv_data.DataSource = data;
        }
    }
}
