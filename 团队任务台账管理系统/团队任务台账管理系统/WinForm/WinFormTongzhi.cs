using Aspose.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WinFormTongzhi : Form
    {


        ControllerWFtongzhigonggao _myc = new ControllerWFtongzhigonggao();
        JJTongzhiInfo myinfo = new JJTongzhiInfo();


        public WinFormTongzhi()
        {
            InitializeComponent();
            richTextBox1.LoadFile(@".\tongzhi.rtf");
        }

        public  WinFormTongzhi(JJTongzhiInfo info)
        {
            InitializeComponent();
            myinfo = info;
        }



        private void lbl_yiyuezhi_Click(object sender, EventArgs e)
        {
          bool b=  _myc.Yidu(myinfo);
            if (b)
            {
                MessageBox.Show("已阅读通知！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private async void WinFormTongzhi_Load(object sender, EventArgs e)
        {
            //下载到临时文件，然后加载到richtextbox
            await JJMethod.DownLoadFileAsync(myinfo._neirongpath, ".\\temp.rtf");
            richTextBox1.LoadFile(".\\temp.rtf");

        }
    }
}
