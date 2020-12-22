using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WinFormYidu : Form
    {


        ControllerWFyidu _myc = new ControllerWFyidu();
        public WinFormYidu()
        {
            InitializeComponent();
        }
        public WinFormYidu(JJTaskInfo myti)
        {
            InitializeComponent();
            //根据myti的名称和类型获得所有的taskinfo

            var list = _myc.GetTasks(myti);
            //判断每个taskinfo的人员类别，添加label控件到负责人和参与人中，同时根据已读未读设置背景色
            foreach (JJTaskInfo ti in list)
            {
                Label ml = new Label() {
                Text=ti._canyuren,
                BackColor=Color.LightGray
                };
                if (ti._zhuangtai!="已读")
                {
                    ml.BackColor = Color.SeaGreen;
                }
                flp_canyu.Controls.Add(ml);



            }













        }


        private void WinFormYidu_Load(object sender, EventArgs e)
        {

        }
    }
}
