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
            string str_sql = $"select * from ";
            var list=_mycontroller.GetTaskinfo()

            //构造ucteakmsg


            //添加到panel_task
            panel_task.Controls.Clear();


        }
    }
}
