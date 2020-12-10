using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJController;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormHoutaiguanli : Form
    {
        ControllerWFhoutai _mycontroller = new ControllerWFhoutai();
        public WinFormHoutaiguanli()
        {
            InitializeComponent();
        }

        private void WinFormHoutaiguanli_Load(object sender, EventArgs e)
        {
            //显示personinfo
            DataTable mydt = _mycontroller.GetPerson();
            dgv_person.DataSource = mydt;
            //模拟点击一次表格
            dgv_person_CellMouseClick(null, null);


        }

        private void lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgv_person_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //获得选中行
            DataGridViewRow mydr = dgv_person.CurrentRow;
            //把信息显示在窗体中
            tb_huaming.Text = mydr.Cells["花名"].Value.ToString();
            tb_diaoyongguize.Text = mydr.Cells["调用规则"].Value.ToString();
            tb_diaoyongchachongku.Text = mydr.Cells["调用查重库"].Value.ToString();
            tb_jiechuguize.Text = mydr.Cells["删除规则"].Value.ToString();
            tb_jiechuchachongku.Text = mydr.Cells["删除查重库"].Value.ToString();
            if (Convert.ToInt32(mydr.Cells["登录权"].Value) == 1)
            {
                rb_keyi.Checked = true;
            }
            else
            {
                rb_bukeyi.Checked = true;

            }

        }
    }
}
