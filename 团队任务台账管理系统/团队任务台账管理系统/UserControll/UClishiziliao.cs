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
    public partial class UClishiziliao : UserControl
    {
        ControllerLishiziliao _mycontroller = new ControllerLishiziliao();
        public UClishiziliao()
        {
            InitializeComponent();
        }

        private void UClishiziliao_Load(object sender, EventArgs e)
        {
            DataTable mydt = _mycontroller.GetLishiziilao();
            dgv_data.DataSource = mydt;
        }
    }
}
