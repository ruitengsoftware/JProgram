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
    public partial class UClishiziliao : UserControl
    {
        ControllerLishiziliao _mycontroller = new ControllerLishiziliao();
        public UClishiziliao()
        {
            InitializeComponent();
        }

        private void UClishiziliao_Load(object sender, EventArgs e)
        {
            panel_my.Controls.Clear();
            //var list = _mycontroller.GetLishiziilao();
            //foreach (JJQingdanInfo info in list)
            //{
            //    UCMessage myuc = new UCMessage(info);
            //    myuc._updatemaindata = UClishiziliao_Load;
            //    panel_my.Controls.Add(myuc);
            //}
            var list = _mycontroller.GetLishiziliao();
            foreach (JJQingdanInfo info in list)
            {
                UCMessage myuc = new UCMessage(info);
                myuc._updatemaindata = UClishiziliao_Load;
                panel_my.Controls.Add(myuc);
            }
        }
    }
}
