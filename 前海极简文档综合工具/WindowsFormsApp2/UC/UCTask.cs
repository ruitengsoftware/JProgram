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

using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
//using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2.UC
{
    public partial class UCTask : UserControl
    {
        public UCTask()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击关闭按钮时 触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pb_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void PictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.startlv;
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void PictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.startenter;
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void Pb_close_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.closeenter;
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void Pb_close_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.closelv;
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;

        }
        /// <summary>
        /// 更改进度条的最大值
        /// </summary>
        /// <param name="myuctask"></param>
        /// <param name="max"></param>
        public void SetPBMaxmium(UC.UCTask myuctask, int max, int value)
        {
            if (this.InvokeRequired)
            {
                Action<UC.UCTask, int, int> a = SetPBMaxmium;
                this.BeginInvoke(a, myuctask, max, value);
            }
            else
            {
                myuctask.pb_jindu.Maximum = max;
                myuctask.pb_jindu.Value = value;
            }

        }
        /// <summary>
        /// 更改控件的文本
        /// </summary>
        /// <param name="myuctask"></param>
        /// <param name="max"></param>
        public void SetText(Control myctrl, string str)
        {
            if (this.InvokeRequired)
            {
                Action<Control, string> a = SetText;
                this.BeginInvoke(a, myctrl, str);
            }
            else
            {
                myctrl.Text = str;
            }

        }


    }
}
