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
    public partial class UCshouquan : UserControl
    {
        public UCshouquan()
        {
            InitializeComponent();
        }
        ControllerUCshouquan mycontroller = new ControllerUCshouquan();
        private void UCshouquan_Load(object sender, EventArgs e)
        {
            DataTable mydt = mycontroller.GetPerson();
            dgv_data.DataSource = null;
            dgv_data.DataSource = mydt;
        }

        private void dgv_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //获得当前点击的行

            DataGridViewRow mydr = dgv_data.CurrentRow;
            //获得昵称，部门，权限，密码，姓名，联系方式，邮箱
            string nicheng = mydr.Cells["昵称"].Value.ToString();
            string bumen = mydr.Cells["部门"].Value.ToString();
            string quanxian = mydr.Cells["权限"].Value.ToString();
            string mima = mydr.Cells["密码"].Value.ToString();
            string xingming = mydr.Cells["姓名"].Value.ToString();
            string lianxifangshi = mydr.Cells["联系方式"].Value.ToString();
            string youxiang = mydr.Cells["邮箱"].Value.ToString();

            //显示这些信息
            tb_nicheng.Text = nicheng;
            tb_bumen.Text = bumen;
            cbb_quanxian.Text = quanxian;
            tb_mima.Text = mima;
            tb_xingming.Text = xingming;
            tb_lianxifangshi.Text = lianxifangshi;
            tb_youxiang.Text = youxiang;



        }

        private void btn_baocun_Click(object sender, EventArgs e)
        {
            //获得当前员工信息
            string nicheng = tb_nicheng.Text;
            string bumen = tb_bumen.Text;
            string quanxian = cbb_quanxian.Text;
            string mima = tb_mima.Text;
            string xingming = tb_xingming.Text;
            string lianxifangshi = tb_lianxifangshi.Text;
            string youxiang = tb_youxiang.Text;



            //更新jjperson数据库

            bool b = mycontroller.UpdatePerson(xingming, quanxian);
            DataTable mydt = mycontroller.GetPerson();
            dgv_data.DataSource = null;
            dgv_data.DataSource = mydt;
            if (b) MessageBox.Show("更新数据成功！");
            //刷新显示数据



        }
    }
}
