
using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Controller;

namespace WinFormSearchRepeat.WinForm
{
    public partial class WinFromAddTask : Form
    {
        public WinFromAddTask()
        {
            InitializeComponent();
        }
        ControllerAddTask _mycontroller = new ControllerAddTask();
        /// <summary>
        /// 点击添加文档按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label2_Click(object sender, EventArgs e)
        {
            List<string> list_files = _mycontroller.GetDocument();
            //把文件名添加到文本框中tb_file
            StringBuilder sb_files = new StringBuilder();
            for (int i = 0; i < list_files.Count; i++)
            {
                sb_files.AppendLine(list_files[i]);
            }
            tb_file.Text = sb_files.ToString();
        }
        /// <summary>
        /// 点击批量添加按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label1_Click(object sender, EventArgs e)
        {
            List<string> list_files = _mycontroller.GetFlies();
            //把文件名添加到文本框中tb_file
            StringBuilder sb_files = new StringBuilder();
            for (int i = 0; i < list_files.Count; i++)
            {
                sb_files.AppendLine(list_files[i]);
            }
            tb_file.Text = sb_files.ToString();

        }
        public List<string> outvalue = new List<string>();
        /// <summary>
        /// 点击添加任务按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_addtask_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 重写窗体关闭时触发的事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            string str = tb_file.Text;
           outvalue= Regex.Split(str, @"\r\n").ToList();
        }

        private void Lbl_addtask_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect(((Control)sender));
        }

        private void Lbl_addtask_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void Lbl_addtask_MouseLeave(object sender, EventArgs e)
        {
           UIHelper UIHelper = new UIHelper();
            UIHelper.UpdateCSize((Control)sender, 1);

        }

        private void Label1_MouseEnter(object sender, EventArgs e)
        {

            ((Control)sender).ForeColor = Color.FromName("deepskyblue");
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.FromName("ControlDarkDark");
        }

        private void Lbl_wenjianjia_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                tb_file.Text = fbd.SelectedPath;
            }


            //List<string> list_files = _mycontroller.GetFlies();
            ////把文件名添加到文本框中tb_file
            //StringBuilder sb_files = new StringBuilder();
            //for (int i = 0; i < list_files.Count; i++)
            //{
            //    sb_files.AppendLine(list_files[i]);
            //}
            //tb_file.Text = sb_files.ToString();
        }
    }
}
