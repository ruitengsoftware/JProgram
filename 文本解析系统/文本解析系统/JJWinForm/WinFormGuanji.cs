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

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormGuanji : Form
    {
        public WinFormGuanji()
        {
            InitializeComponent();
        }

        private void WinFormGuanji_Load(object sender, EventArgs e)
        {
            //启动倒计时，同时更新按钮秒数，倒计时结束，窗体dialogresult==ok
            timer1.Start();



        }
            int second = 10;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (second == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lbl_guanji.Text = $@"关机（{second}s）";
                second--;
            }

        }

        private void btn_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_guanji_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void lbl_quxiao_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);



        }

        private void lbl_quxiao_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, 1);
        }

        private void lbl_quxiao_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);

        }
    }
}
