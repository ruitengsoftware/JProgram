using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WinFormXiaoxiang : Form
    {
        object mytask = new object();

        public WinFormXiaoxiang()
        {
            InitializeComponent();
        }
        public WinFormXiaoxiang(object o)
        {
            InitializeComponent();
            mytask = o;



        }

        private void lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void WinFormXiaoxiang_Load(object sender, EventArgs e)
        {

        }
        ControllerXiaoxiang _myc = new ControllerXiaoxiang();
        private void lbl_queding_Click(object sender, EventArgs e)
        {
            //将心得体会更新到工作清单表中，同时销项更新为1
            JJQingdanInfo info=mytask as JJQingdanInfo;
            info._xiaoxiang = 1;
            info._jingyanjiaoxun = tb_xindetihui.Text;
            //更新工作清单
            bool b = _myc.Xiaoxiang(info);
            if (b)
            {
                MessageBox.Show("销项成功！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
    }
}
