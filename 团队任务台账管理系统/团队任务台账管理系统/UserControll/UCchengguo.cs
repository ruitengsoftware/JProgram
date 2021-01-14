using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.WinForm;
using 团队任务台账管理系统.JJModel;
using System.Text.RegularExpressions;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCchengguo : UserControl
    {
        public JJchengguoInfo myinfo = new JJchengguoInfo();
        public UCchengguo()
        {
            InitializeComponent();
        }
        public UCchengguo(JJchengguoInfo ji)
        {
            InitializeComponent();
            myinfo = ji;
            tb_guanjianchengguo.Text = ji._guanjianchengguo;
            tb_jutiyaoqiu.Text = ji._jutiyaoqiu;
            //加载附件
            foreach (string s in Regex.Split(ji._fujian, @"\|"))
            {
                UCfujianInfo myuc = new UCfujianInfo(s) { Dock = DockStyle.Top };
                uCfujian1.panel_fujian.Controls.Add(myuc);
            }

            dtp_shixian.Text = ji._shixian;
            tb_banliyijian.Text = ji._banliyijian;
            tb_banlirenyuan.Text = ji._banlirenyuan;
            tb_jinzhanqingkuang.Text = ji._jinzhanqingkuang;



        }

        public UCchengguo(int i)
        {
            InitializeComponent();
            lbl_chengguo.Text = $"关键成果{i}";


        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_banlirenyuan.Text = string.Join(",", mywin.list_selected);
            }
        }

        private void tb_guanjianchengguo_TextChanged(object sender, EventArgs e)
        {
            myinfo._guanjianchengguo = tb_guanjianchengguo.Text;
        }

        private void tb_jutiyaoqiu_TextChanged(object sender, EventArgs e)
        {
            myinfo._jutiyaoqiu = tb_jutiyaoqiu.Text;
        }

        private void dtp_shixian_ValueChanged(object sender, EventArgs e)
        {
            myinfo._shixian = dtp_shixian.Value.ToString();
        }

        private void tb_banliyijian_TextChanged(object sender, EventArgs e)
        {
            myinfo._banliyijian = tb_banliyijian.Text;
        }

        private void tb_banlirenyuan_TextChanged(object sender, EventArgs e)
        {
            myinfo._banlirenyuan = tb_banlirenyuan.Text;
        }

        private void tb_jinzhanqingkuang_TextChanged(object sender, EventArgs e)
        {
            myinfo._jinzhanqingkuang = tb_jinzhanqingkuang.Text;
        }
    }
}
