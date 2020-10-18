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
    public partial class UCrizhi : UserControl
    {

        ControllerUCrizhi mycontroller = new ControllerUCrizhi();

        public UCrizhi()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获得所有日志数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCrizhi_Load(object sender, EventArgs e)
        {
            dgv_data.DataSource = null;
            var mydt = mycontroller.GetRizhi();
            dgv_data.DataSource = mydt;
        }

        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            WFrizhi mywin = new WFrizhi();
            mywin.update = () => {
                dgv_data.DataSource = null;
                var mydt = mycontroller.GetRizhi();
                dgv_data.DataSource = mydt;
            };
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog()==DialogResult.OK)
            {
              
            }
        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shanchu_Click(object sender, EventArgs e)
        {
            var myrow = dgv_data.CurrentCell.OwningRow;
            bool b = mycontroller.DeleteRizhi(myrow.Cells["标题"].Value.ToString());
            if (b)
            {
                UCrizhi_Load(null, null);
                MessageBox.Show("数据删除成功！");
            }




        }

        private void pb_sousuo_Click(object sender, EventArgs e)
        {
            //获得关键词
            string str_kw = tb_guanjianci.Text.Trim();

            //查找数据,判断关键词是否为空，如果是，显示所有记录，如果不为空，返回搜索结果
            DataTable mydt = null;
            if (str_kw.Equals(string.Empty))
            {
                mydt = mycontroller.GetRizhi();
            }
            else
            {
            mydt = mycontroller.ChazhaoRizhi(str_kw);

            }
            dgv_data.DataSource = null;
            dgv_data.DataSource = mydt;


        }
    }
}
