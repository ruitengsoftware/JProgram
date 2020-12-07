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
using 团队任务台账管理系统.JJModel;

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
            dgv_data_CellMouseClick(null, null);

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

            var zhengjianzhao = mydr.Cells["工作证件照"].Value.ToString().Equals(string.Empty) ? null : mycontroller.ConvertBase64ToImage(mydr.Cells["工作证件照"].Value.ToString());
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
            dgv_data_CellMouseClick(null, null);

            if (b) MessageBox.Show("保存成功！");




        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shanchu_Click(object sender, EventArgs e)
        {
            //获得花名
            string huaming = tb_huaming.Text.Trim();
            //修改jjperson中对应的 删除  字段 值

            //更新jjperson数据库

            bool b = mycontroller.DeletePerson(huaming);
            DataTable mydt = mycontroller.GetPerson();
            dgv_data.DataSource = null;
            dgv_data.DataSource = mydt;
            dgv_data_CellMouseClick(null, null);

            if (b) MessageBox.Show("数据已删除");
        }

        private void lbl_zhucerenyuan_Click(object sender, EventArgs e)
        {
            WFzhuce mywin = new WFzhuce();
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                UCshouquan_Load(null, null);

            }

        }

        private void dgv_data_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得dgv_data 当前选中行
            DataGridViewRow mydr = dgv_data.CurrentRow;
            //构造一个jjpersoninfo
            JJPersonInfo myinfo = new JJPersonInfo()
            {
                _huaming = mydr.Cells["花名"].Value.ToString(),
                _shiming = mydr.Cells["实名"].Value.ToString(),
                _bumen = mydr.Cells["部门"].Value.ToString(),
                _zhiji = mydr.Cells["职级"].Value.ToString(),
                _mima = mydr.Cells["密码"].Value.ToString(),
                _shoujihao = mydr.Cells["手机号"].Value.ToString(),
                _dianziyouxiang = mydr.Cells["电子邮箱"].Value.ToString(),
                _zidingyizhanghao = mydr.Cells["自定义账号"].Value.ToString(),
                _touxiang = mydr.Cells["头像"].Value.ToString(),
                _gongzuozhengjianzhao = mydr.Cells["工作证件照"].Value.ToString(),
                _weixinhao = mydr.Cells["微信号"].Value.ToString(),
                _gerenqianming = mydr.Cells["个人签名"].Value.ToString()
            };
            //构造一个wfzhuce，把jjpersoninfo传进去
            WFzhuce mywin = new WFzhuce(myinfo);
            //刷新dgv_data
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                UCshouquan_Load(null, null);
            }



        }


        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得dgv_data 当前选中行
            DataGridViewRow mydr = dgv_data.CurrentRow;
            string _huaming = mydr.Cells["花名"].Value.ToString();
            bool b=mycontroller.DeletePerson(_huaming);
            if (b)
            {
                UCshouquan_Load(null, null);
                MessageBox.Show("删除成功！");

            }


        }





    }
}


