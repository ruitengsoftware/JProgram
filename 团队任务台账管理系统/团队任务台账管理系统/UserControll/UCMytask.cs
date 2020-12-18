using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCMytask : UserControl
    {
        ControllerUCmytask _mycontroller = new ControllerUCmytask();
        public UCMytask()
        {
            InitializeComponent();
        }

        private void lbl_quanbu_Click(object sender, EventArgs e)
        {
            //获得全部任务 
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表";
            var list = _mycontroller.GetTaskinfo(str_sql);

            //构造ucteakmsg
            foreach (JJTaskInfo ti in list)
            {
                UCTaskmsg myuc = new UCTaskmsg(ti);
                panel_task.Controls.Add(myuc);
                //添加到panel_task

            }
        }
    }
}
