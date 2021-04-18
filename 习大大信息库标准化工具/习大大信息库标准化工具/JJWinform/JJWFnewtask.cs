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
using 习大大信息库标准化工具.JJController;

namespace 习大大信息库标准化工具.JJWinform
{
    public partial class JJWFnewtask : Form
    {
        JJCnewtask mycontroller = new JJCnewtask();


        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string _folder = string.Empty;
        /// <summary>
        /// 解析规则
        /// </summary>
        public string _ruler = string.Empty;
        /// <summary>
        /// 完成后操作
        /// </summary>
        public string _action = "无";
        public JJWFnewtask()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            _folder = tb_folder.Text.Trim();
            _ruler = cbb_jiexigeshi.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void pb_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                tb_folder.Text = fbd.SelectedPath;
            }
        }
        /// <summary>
        /// 下拉解析格式列表时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_jiexigeshi_DropDown(object sender, EventArgs e)
        {
            ////获得所有解析格式的名称
            //List<string> list_format = mycontroller.GetFormat();
            ////加载cbb的item
            //cbb_jiexigeshi.Items.Clear();
            //cbb_jiexigeshi.Items.AddRange(list_format.ToArray());
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect(((Control)sender));
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            //((PictureBox)sender).Image = Properties.Resources.folderenter;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            //((PictureBox)sender).Image = Properties.Resources.folderlv;
        }

        private void lbl_queding_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCC((Control)sender, Color.Salmon, Color.White);    
        }

        private void lbl_queding_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCC((Control)sender, Color.Tomato, Color.White);

        }

        private void cbb_jiexigeshi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //记载格式为默认格式
            Properties.Settings.Default.defaultformat = cbb_jiexigeshi.Text;
            Properties.Settings.Default.Save();

        }

        private void WinFormNewTask_Load(object sender, EventArgs e)
        {
            cbb_jiexigeshi.Text = Properties.Settings.Default.defaultformat;
        }
    }
}
