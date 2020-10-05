using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using RuiTengDll;
using Common;

namespace WindowsFormsApp2.UC
{
    public partial class UCchuli : UserControl
    {/// <summary>
     /// 该委托用于存放刷新示例得方法
     /// </summary>
        public Action update_shili = null;

        //存放刷新步骤列表空间集合得方法
        public Action update_buzhou = null;
        public BuzhouInfo myinfo = new BuzhouInfo();
        public Control control_xiangqing = new Control();
        public UCchuli()
        {
            InitializeComponent();
        }

        public UCchuli(BuzhouInfo buzhouinfo)
        {
            InitializeComponent();
            myinfo = buzhouinfo;
            lbl_buzhou.Text = myinfo._name;
            //构造步骤详情
            if (myinfo._name.Contains("替换"))
            {
                control_xiangqing = new UCBuzhou(myinfo._zhengze, myinfo._tihuan) { Dock = DockStyle.Fill };
                (control_xiangqing as UCBuzhou).tb_zhengze.TextChanged += Tb_zhengze_TextChanged;
                (control_xiangqing as UCBuzhou).tb_tihuan.TextChanged += Tb_tihuan_TextChanged;
                (control_xiangqing as UCBuzhou).tb_zhengze.Leave += UCchuli_Leave;
                (control_xiangqing as UCBuzhou).tb_tihuan.Leave += UCchuli_Leave;

            }
            else if (myinfo._name.Contains("缀") || myinfo._name.Contains("清除"))
            {
                control_xiangqing = new System.Windows.Forms.TextBox() { Dock = DockStyle.Fill, Text = myinfo._text, Multiline = true };
                ((TextBox)control_xiangqing).TextChanged += UCchuli_TextChanged;
                ((TextBox)control_xiangqing).Leave += UCchuli_Leave;
            }
        }

        public UCchuli(string str, string selfname)
        {
            InitializeComponent();

            lbl_buzhou.Text = str;
            myinfo._selfname = selfname;
            myinfo._updatedate = DateTime.Now.ToString("yyyy-MM-dd");
            myinfo._name = str;
            //判断步骤类型，给text,_zhengze,_tihuan属性赋值
            if (str.Equals("正则替换"))
            {
                myinfo._zhengze = "请输入正则表达式…";
                myinfo._tihuan = "请输入…";
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Name = "步骤详情";
                ucchachong.groupBox5.Name = "处理前";
            }
            else if (myinfo._name.Equals("文本替换"))
            {
                myinfo._zhengze = "请输入…";
                myinfo._tihuan = "请输入…";
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Name = "步骤详情";
                ucchachong.groupBox5.Name = "处理前";

            }
            else if (myinfo._name.Contains("添加前缀"))
            {
                myinfo._text = "请输入…";
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Name = "前缀内容";
                ucchachong.groupBox5.Name = "需要匹配的内容";

            }
            else if (myinfo._name.Contains("添加后缀"))
            {
                myinfo._text = "请输入…";
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Name = "后缀内容";
                ucchachong.groupBox5.Name = "需要匹配的内容";

            }
            else if (myinfo._name.Contains("清除换行符"))
            {
                myinfo._text = "清除换行符…";
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Name = "步骤详情";
                ucchachong.groupBox5.Name = "处理前";

            }
            //构造步骤详情uc
            if (str.Contains("替换"))
            {
                control_xiangqing = new UCBuzhou(myinfo._zhengze, myinfo._tihuan) { Dock = DockStyle.Fill };
                (control_xiangqing as UCBuzhou).tb_zhengze.TextChanged += Tb_zhengze_TextChanged;
                (control_xiangqing as UCBuzhou).tb_tihuan.TextChanged += Tb_tihuan_TextChanged;
                (control_xiangqing as UCBuzhou).tb_zhengze.Leave += UCchuli_Leave;
                (control_xiangqing as UCBuzhou).tb_tihuan.Leave += UCchuli_Leave;

            }
            else if (str.Contains("缀") || str.Contains("清除"))
            {
                control_xiangqing = new System.Windows.Forms.TextBox() { Dock = DockStyle.Fill, Text = myinfo._text, Multiline = true };
                ((TextBox)control_xiangqing).TextChanged += UCchuli_TextChanged;
                ((TextBox)control_xiangqing).Leave += UCchuli_Leave;
            }
        }

        private void UCchuli_Leave(object sender, EventArgs e)
        {
            update_shili();
        }

        private void UCchuli_TextChanged(object sender, EventArgs e)
        {
            myinfo._text = ((Control)sender).Text;
        }

        private void Tb_tihuan_TextChanged(object sender, EventArgs e)
        {
            myinfo._tihuan = ((Control)sender).Text;
        }

        private void Tb_zhengze_TextChanged(object sender, EventArgs e)
        {
            myinfo._zhengze = ((Control)sender).Text;
        }




        private void Pb_delete_Click(object sender, EventArgs e)
        {
            this.Dispose();
            update_buzhou();

        }
        UIHelper uihelper = new UIHelper();
        private void Pb_right_Click(object sender, EventArgs e)
        {
            Control myc = sender as Control;
            uihelper.MoveControl((Panel)myc.Parent.Parent.Parent, myc.Parent.Parent, -1);
            update_buzhou();
        }

        private void Pb_left_Click(object sender, EventArgs e)
        {
            Control myc = sender as Control;
            uihelper.MoveControl((Panel)myc.Parent.Parent.Parent, myc.Parent.Parent, 1);
            update_buzhou();

        }

        private void Lbl_buzhou_Click(object sender, EventArgs e)
        {

            //本控件意外全部不高亮
            foreach (UCchuli uc in Setting.list_ucchuli)
            {
                uc.lbl_buzhou.BackColor = Color.LightGray;
                uc.lbl_buzhou.ForeColor = Color.Black;

            }
            //高两
            lbl_buzhou.BackColor = Color.SteelBlue;
            lbl_buzhou.ForeColor = Color.White;
        }
        private void Lbl_buzhou_Paint(object sender, PaintEventArgs e)
        {
            uihelper.DrawRoundRect((Control)sender);
        }

        private void Pb_delete_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.delete4;

        }

        private void Pb_delete_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.delete3;

        }
    }
}
