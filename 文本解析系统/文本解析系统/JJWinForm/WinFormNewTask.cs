using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJController;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormNewTask : Form
    {
        ControllerNewTask mycontroller = new ControllerNewTask();


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
        public WinFormNewTask()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            _folder = tb_folder.Text;
            _ruler = cbb_jiexigeshi.Text;
            if (cb_wu.Checked)
            {
                _action = "无";
            }
            if (cb_guanji.Checked)
            {
                _action = "关机";
            }


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
            //获得所有解析格式的名称
            List<string> list_format = mycontroller.GetFormat();
            //加载cbb的item
            cbb_jiexigeshi.Items.Clear();
            cbb_jiexigeshi.Items.AddRange(list_format.ToArray());
        }
    }
}
