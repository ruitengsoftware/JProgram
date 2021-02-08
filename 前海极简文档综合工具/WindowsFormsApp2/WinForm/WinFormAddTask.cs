using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.WinForm
{
    public partial class WinFromAddTask : Form
    {
        public WinFromAddTask()
        {
            InitializeComponent();
        }
        FileHelper myfiler = new FileHelper();
        UIHelper UIHelper = new UIHelper();
        /// <summary>
        /// 点击添加文档按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "所有文档|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //把文件名添加到文本框中tb_file
                StringBuilder sb_files = new StringBuilder();
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    sb_files.AppendLine(ofd.FileNames[i]);
                }
                listbox.Text += sb_files.ToString();
            }
        }
        /// <summary>
        /// 点击批量添加按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                listbox.Text += fbd.SelectedPath+"\r\n";
            }
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
            string str = listbox.Text;


                
           List<string> files=  Regex.Split(str, @"\r\n").ToList();
            
           files.Remove("");
            //循环判断文件名，如果文件后缀为0，那么需要提取该目录下所有的文件
            foreach (string  item in files)
            {
                string houzhui = Path.GetExtension(item);
                if (houzhui.Equals(""))//这里判断是一个文件夹
                {
                    List<string> listfiles = GetFiles(item);
                    listfiles.ForEach(file => { outvalue.Add(file);}) ;
                }
                else
                {
                outvalue.Add(item);

                }
            }




        }
        /// <summary>
        /// 获得目录下所有子文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public List<string> GetFiles(string dir)
        {

            List<string> list_files = new List<string>();
            FileHelper filehelper = new FileHelper();

           filehelper.GetFiles(new System.IO.DirectoryInfo(dir),"*.*",ref list_files);
            return list_files;


        }



        private void Lbl_addtask_Paint(object sender, PaintEventArgs e)
        {
            UIHelper UIHelper = new UIHelper();
            UIHelper.DrawRoundRect(((Control)sender));
        }

        private void Lbl_addtask_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void Lbl_addtask_MouseLeave(object sender, EventArgs e)
        {
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

        private void Label3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                listbox.Text = fbd.SelectedPath;
            }
        }
    }
}
