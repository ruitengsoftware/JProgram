using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp2.Common;
using WindowsFormsApp2.UC;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       //测试git同步
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击批量改名按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            UCUpdateName ucun = new UCUpdateName();
            PAddControls(ucun);

        }


        UCgeshitiaozheng ucgszh = null;
        #region 按钮效果等代码

        private void PAddControls(Control o)
        {
            mypanel.Controls.Clear();
            o.Dock = DockStyle.Fill;
            mypanel.Controls.Add(o);
        }
        UIHelper mydrawer = new UIHelper();
        private void label3_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin - 1));
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
 int margin =((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender,new Padding(margin+1));
        
        }
        #endregion

        private void lblupdate_Click(object sender, EventArgs e)
        {
            if (ucgszh == null)
            {
                ucgszh = new UCgeshitiaozheng();

            }

            PAddControls(ucgszh);
        }

        private void lblcreate_Click(object sender, EventArgs e)
        {
            UCExcelToWord ucetow = new UCExcelToWord();
            PAddControls(ucetow);

        }

        private void label4_Click(object sender, EventArgs e)
        {
            UCdata ucdt = new UCdata();
            PAddControls(ucdt);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (lblcreate.Visible == true)
            {
                lblcreate_Click(null, null);
            }
            else
            {
                lblupdate_Click(null, null);
            }
        }
        UC.UCExcelSplit myucsplit = null;
        /// <summary>
        /// 点击文件分割按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            if (myucsplit == null)
            {
                myucsplit = new UC.UCExcelSplit();
            }

            myucsplit.Dock = DockStyle.Fill;
            mypanel.Controls.Clear();
            mypanel.Controls.Add(myucsplit);
        }

        private void Label2_Click_1(object sender, EventArgs e)
        {
            UC.UCYiZhanShi myuc = new UC.UCYiZhanShi();
            PAddControls(myuc);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MySetting.Default.Save();
        }

        static UCNeirongchuli myuc = null;

        UCNeirongchuli uc_neirongchuli = new UCNeirongchuli();
        private void Lbl_neirongchuli_Click(object sender, EventArgs e)
        {
            if (uc_neirongchuli == null)
            {
                uc_neirongchuli = new UCNeirongchuli();
            }
            uc_neirongchuli.Dock = DockStyle.Fill;
            mypanel.Controls.Clear();
            mypanel.Controls.Add(uc_neirongchuli);

        }
        UCTupianChuli uc_tupian = null;
        private void Lbl_tupianchuli_Click(object sender, EventArgs e)
        {
            if (uc_tupian == null)
            {
                uc_tupian = new UCTupianChuli();
            }
            uc_tupian.Dock = DockStyle.Fill;
            mypanel.Controls.Clear();
            mypanel.Controls.Add(uc_tupian);
        }
        UCFenlei _ucfenlei = null;
        private void Lbl_fenlei_Click(object sender, EventArgs e)
        {
            if (_ucfenlei == null)
            {
                _ucfenlei = new UCFenlei();
            }
            _ucfenlei.Dock = DockStyle.Fill;
            mypanel.Controls.Clear();
            mypanel.Controls.Add(_ucfenlei);
        }
    }
    public class Singleton
    {
        private static UCNeirongchuli instance;
        private Singleton() { }

        public static UCNeirongchuli getInstance()
        {
            if (instance == null)
            {
                instance = new UCNeirongchuli();
            }
            return instance;
        }
    }
}
