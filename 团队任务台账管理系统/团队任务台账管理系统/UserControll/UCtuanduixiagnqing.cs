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
using 团队任务台账管理系统.WinForm;
using 团队任务台账管理系统.Common;

namespace 团队任务台账管理系统.UserControll
{

    public partial class UCtuanduixiagnqing : UserControl
    {
      public  bool _checked = false;

        public UCtuanduixiagnqing()
        {
            InitializeComponent();

        }
        JJTuanduiInfo _tuanduiinfo = new JJTuanduiInfo();
        public Action<object, EventArgs> Updatedate;
        public UCtuanduixiagnqing(JJTuanduiInfo myinfo)
        {
            InitializeComponent();
            _tuanduiinfo = myinfo;
            //赋值控件值
            this.lbl_tuanduimingcheng.Text = myinfo._mingcheng;
            this.lbl_fuzeren.Text = myinfo._fuzeren;
            var list_chengyuan = Regex.Split(myinfo._chengyuan, ",").ToList();
            list_chengyuan.Remove("");
            this.lbl_renshu.Text = list_chengyuan.Count.ToString();
            this.pb_tuandui.Image = JJImageHelper.ConvertBase64ToImage(myinfo._tuanduitupian);
        }

        private void lbl_xiangqing_Click(object sender, EventArgs e)
        {
            WFtuandui mywin = new WFtuandui(_tuanduiinfo);
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                Updatedate(null, null);
            }




        }
        private void pb_select_Click(object sender, EventArgs e)
        {
            if (_checked)//如果当前状态是选中
            {
                _checked = false;
                this.BackColor = Color.Transparent;
                pb_select.Image = Properties.Resources.对号__1_;
            }
            else
            {
                _checked = true;
                this.BackColor = Color.MediumSeaGreen;
                pb_select.Image = Properties.Resources.对号;
            }

        }
    }
}
