using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCfujian : UserControl
    {
        /// <summary>
        /// 已选中的附件的集合
        /// </summary>
        public List<string> list_fujian = new List<string>();

        public UCfujian()
        {
            InitializeComponent();
        }

        private void pb_xuanze_Click(object sender, EventArgs e)
        {

        }

        private void pb_shangchuan_Click(object sender, EventArgs e)
        {
            //选择文件
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //实例化ucfujianinfo
                UCfujianInfo myuc = new UCfujianInfo(ofd.FileName) { Dock=DockStyle.Top};
                panel_fujian.Controls.Add(myuc);
            }



            ////构造存放位置路径
            //string str_path = "http://" + $"49.233.40.109/常规事项/{JJLoginInfo._huaming}/";
            ////string str_path = "http://" + $"49.233.40.109/haahah/";
            ////上传
            //JJMethod.UpLoadFile(str, str_path, false);

        }
        private void panel_fujian_ControlAdded(object sender, ControlEventArgs e)
        {
            list_fujian.Clear();
            foreach (Control c in panel_fujian.Controls)
            {
                UCfujianInfo myuc = c as UCfujianInfo;
                if (!list_fujian.Contains(myuc.file))
                {
                    list_fujian.Add(myuc.path);
                }

            }
        }

        private void panel_fujian_ControlRemoved(object sender, ControlEventArgs e)
        {
            list_fujian.Clear();
            foreach (Control c in panel_fujian.Controls)
            {
                UCfujianInfo myuc = c as UCfujianInfo;
                if (!list_fujian.Contains(myuc.file))
                {
                    list_fujian.Add(myuc.path);
                }

            }

        }
    }
}
