using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;
using System.Text.RegularExpressions;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCtuanduixiagnqing : UserControl
    {
        public UCtuanduixiagnqing()
        {
            InitializeComponent();

        }
        public UCtuanduixiagnqing(JJTuanduiInfo myinfo)
        {
            InitializeComponent();
            //赋值控件值
            this.lbl_tuanduimingcheng.Text = myinfo._mingcheng;
            this.lbl_fuzeren.Text = myinfo._fuzeren;
            string[] arr_chengyuan = Regex.Split(myinfo._chengyuan, ",");
            this.lbl_renshu.Text = arr_chengyuan.Length.ToString(); ;




        }





    }
}
