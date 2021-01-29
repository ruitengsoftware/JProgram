using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCpersonName : UserControl
    {
        JJTongzhiInfo myinfo = null;
        public UCpersonName()
        {
            InitializeComponent();
        }

        public UCpersonName(JJTongzhiInfo info )
        {
            InitializeComponent();
            myinfo = info;
        }

        private void UCpersonName_Load(object sender, EventArgs e)
        {
            lbl_name.Text = myinfo._yuedufanwei;
            if (myinfo._zhuangtai.Equals("未读"))
            {

            }
            else
            {
                lbl_name.BackColor = Color.MediumSeaGreen;
                lbl_name.ForeColor = Color.White;
            }
        }
    }
}
