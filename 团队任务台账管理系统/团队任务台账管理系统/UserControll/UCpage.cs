using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCpage : UserControl
    {
        public int currentpage = 0;
        public double totalpage = 0;
        public Func<int,string,object> f = null;//获得数据
        public Action<object> a = null;//刷新显示
        public string kw = string.Empty;//关键字
        public UCpage()
        {
            InitializeComponent();

        }

        public void tb_page_TextChanged(object sender, EventArgs e)
        {
            currentpage = Convert.ToInt32(tb_page.Text);
            object list_o = f(currentpage,kw);
            a(list_o);


        }

        private void btn_shouye_Click(object sender, EventArgs e)
        {
            if (totalpage == 0) return;

            tb_page.Text = "1";
        }

        private void btn_shangyiye_Click(object sender, EventArgs e)
        {
            if (totalpage == 0) return;

            tb_page.Text = (currentpage - 1) == 0 ? "1" : (currentpage - 1).ToString();
        }

        private void btn_weiye_Click(object sender, EventArgs e)
        {
            if (totalpage == 0) return;

            tb_page.Text = totalpage.ToString();

        }

        private void btn_xiayiye_Click(object sender, EventArgs e)
        {
            if (totalpage == 0) return;
            tb_page.Text = (currentpage + 1) > totalpage ? totalpage.ToString() : (currentpage + 1).ToString();
        }

        private void flp_page_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.DodgerBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.SteelBlue;

        }
    }
}
