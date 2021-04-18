using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 习大大信息库标准化工具.JJWinform;

namespace 习大大信息库标准化工具
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lbl_xinzeng_Click(object sender, EventArgs e)
        {
            //实例化一个新建任务窗体并显示出来
            JJWFnewtask mywin = new JJWFnewtask();
            if (mywin.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void lbl_wenjianming_Click(object sender, EventArgs e)
        {
            mytabcontrol.SelectTab("wenjianming");

        }

        private void lbl_chachongruku_Click(object sender, EventArgs e)
        {
                            mytabcontrol.SelectTab("chachongruku");

        }

        private void lbl_jichujiexi_Click(object sender, EventArgs e)
        {
            mytabcontrol.SelectTab("jichujiexi");

        }

        private void lbl_dashujuban_Click(object sender, EventArgs e)
        {
            mytabcontrol.SelectTab("dashujuban");
        }

        private void lbl_neirongjiexi_Click(object sender, EventArgs e)
        {
            mytabcontrol.SelectTab("neirongjiexi");

        }
    }
}
