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
using 团队任务台账管理系统.UserControll;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WinFormTongzhi : Form
    {

        MySQLHelper _mysql = new MySQLHelper();
        ControllerWFtongzhigonggao _myc = new ControllerWFtongzhigonggao();
        JJTongzhiInfo myinfo = new JJTongzhiInfo();//用于存储通知公告类


        public WinFormTongzhi()
        {
            InitializeComponent();
            richTextBox1.LoadFile(@".\tongzhi.rtf");
        }

        public WinFormTongzhi(JJTongzhiInfo info)
        {
            InitializeComponent();
            myinfo = info;
        }



        private void lbl_yiyuezhi_Click(object sender, EventArgs e)
        {
            bool b = _myc.Yidu(myinfo);
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
            //获得标题下所有人员，获得已读和未读人员，刷新未读panel

            UpdatePanelWeidu();

        }

        public void UpdatePanelWeidu()
        {
            string str_sql = $"select * from jjdbrenwutaizhang.通知公告表 where 标题='{myinfo._biaoti}'";
            var datatable = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow mydr in datatable.Rows)
            {
                //jjtongzhigonggaoinfo传递给ucpersonName
                JJTongzhiInfo myinfo = new JJTongzhiInfo()
                {
                    _yuedufanwei = mydr["阅读范围"].ToString(),
                    _zhuangtai = mydr["状态"].ToString()
                };
                UCpersonName myuc = new UCpersonName(myinfo)
                {
                    Dock = DockStyle.Top
                };
                p_weidu.Controls.Add(myuc);
            }
        }



    }
}
