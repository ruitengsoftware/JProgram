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
            string nicheng = mydr.Cells["花名"].Value.ToString();
            string shiming = mydr.Cells["实名"].Value.ToString();
            string bumen = mydr.Cells["部门"].Value.ToString();
            string zhiji = mydr.Cells["职级"].Value.ToString();
            string mima = mydr.Cells["密码"].Value.ToString();
            string shoujihao = mydr.Cells["手机号"].Value.ToString();
            string dianziyouxiang = mydr.Cells["电子邮箱"].Value.ToString();
            string zidingyizhanghao = mydr.Cells["自定义账号"].Value.ToString();
            var touxiang = mydr.Cells["头像"].Value.ToString().Equals(string.Empty) ? null : mycontroller.ConvertBase64ToImage(mydr.Cells["头像"].Value.ToString());

            var zhengjianzhao = mydr.Cells["工作证件照"].Value.ToString().Equals(string.Empty) ? null: mycontroller.ConvertBase64ToImage(mydr.Cells["工作证件照"].Value.ToString()) ;
            string weixinhao = mydr.Cells["微信号"].Value.ToString();
            //显示这些信息
            tb_huaming.Text = nicheng;
            tb_bumen.Text = bumen;
            tb_zhiji.Text = zhiji;
            tb_mima.Text = mima;
            tb_shiming.Text = shiming;
            tb_shoujihao.Text = shoujihao;
            tb_dianziyouxiang.Text = dianziyouxiang;
            tb_zidingyizhanghao.Text = zidingyizhanghao;
            tb_weixinhao.Text = weixinhao;
            try
            {
                pb_zhengjianzhao.Image = zhengjianzhao;
            }
            catch { }
            pb_touxiang.Image = touxiang;
        }

        private void btn_baocun_Click(object sender, EventArgs e)
        {
            //获得当前员工信息
            string huaming = tb_huaming.Text;
            string bumen = tb_bumen.Text;
            string zhiji = tb_zhiji.Text;
            string mima = tb_mima.Text;
            string shiming = tb_shiming.Text;
            string lianxifangshi = tb_shoujihao.Text;
            string youxiang = tb_dianziyouxiang.Text;



            //更新jjperson数据库

            bool b = mycontroller.UpdatePerson(huaming, zhiji);
            DataTable mydt = mycontroller.GetPerson();
            dgv_data.DataSource = null;
            dgv_data.DataSource = mydt;
            if (b) MessageBox.Show("更新数据成功！");
            



        }
    }
}
