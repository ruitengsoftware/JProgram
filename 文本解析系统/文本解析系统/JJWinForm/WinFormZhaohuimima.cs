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
using 文本解析系统.JJController;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormZhaohuimima : Form
    {
        ControllerWFZhaohuimima _mycontroller = new ControllerWFZhaohuimima();
        public WinFormZhaohuimima()
        {
            InitializeComponent();
        }

        private void lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_queding_Click(object sender, EventArgs e)
        {
            //判断花名，实名为条件  是否和邮箱匹配
            string huaming = tb_huaming.Text;
            string shiming = tb_shiming.Text;
            string youxiang = tb_youxiang.Text;
            string mima1 = tb_xinmima.Text;
            string mima2 = tb_querenmima.Text;
            string myyouxiang = _mycontroller.GetEmail(huaming, shiming);
            if (myyouxiang.Equals(youxiang))
            {
                //判断密码是否一直，如果不一致，退出
                if (mima1.Equals(mima2))
                {
                    bool b = _mycontroller.UpdatePassword(huaming, shiming, myyouxiang, mima2);
                    if (b)
                    {
                        MessageBox.Show("修改密码成功！");
                        this.DialogResult = DialogResult.OK;
                    }

                }
                else
                {
                    MessageBox.Show("两次输入的密码不一致！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("邮箱不匹配！");
                return;            }
        }
        private void WinFormZhaohuimima_Load(object sender, EventArgs e)
        {


        }

        private void lbl_queding_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);

        }

        private void lbl_queding_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, 1);

        }

        private void lbl_queding_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }
    }
}
