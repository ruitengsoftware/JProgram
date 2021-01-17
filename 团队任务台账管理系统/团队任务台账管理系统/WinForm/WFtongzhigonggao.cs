using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFtongzhigonggao : Form
    {

        ControllerWFtongzhigonggao _mycontroller = new ControllerWFtongzhigonggao();
        public WFtongzhigonggao()
        {
            InitializeComponent();
        }

        public WFtongzhigonggao(JJTongzhiInfo ti)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            tb_biaoti.Text = ti._biaoti;
            tb_wenhao.Text = ti._qianfaren;
           // tb_neirong.Text = ti._neirong;




        }



        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void label5_Click(object sender, EventArgs e)
        {
            //将内容保存到本地
            //这里为了防止通知过多，需要单独创建一个temp文件夹存放，通知的数量始终保持一个
            string localdir = $"{Environment.CurrentDirectory}\\temp";
            if (Directory.Exists(localdir))
            {
                //清空temp中的文件
                string[] files = Directory.GetFiles(localdir);
                File.Delete(files[0]);
            }
            else
            {
            Directory.CreateDirectory(localdir);

            }
            string filename = $"{localdir}\\{tb_biaoti.Text}.rtf";
            devUCrichtextbox1.richEditControl1.Document.SaveDocument(filename, DevExpress.XtraRichEdit.DocumentFormat.Rtf);
            //将本地文件上传到服务器,存放位置
            string uristring = $"http://49.233.40.109/通知公告";
           await JJMethod.UpLoadFile(filename, uristring, false);
            //将服务器地址赋值给tongzhiinfo的内容




            //分解阅读范围
            string[] person = Regex.Split(tb_yuedufanwei.Text,",");
            foreach (string s in person)
            {
                //构造一个jjtongzhiinfo
                JJTongzhiInfo myinfo = new JJTongzhiInfo()
                {
                    _biaoti = tb_biaoti.Text,
                    _qianfaren = tb_wenhao.Text,
                   _neirongpath = $"{ uristring}/{tb_biaoti.Text}.rtf",
           
                _qingzhonghuanji = rb_putong.Checked ? "普通" : "紧急",
                _zhuangtai="未读",
                
                _fabushijian=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
               _shixian=dtp_shixian.Value.ToString("yyyy-MM-dd hh:mm:ss"),
               _yuedufanwei=s
            };
            //保存jjtonzhiinfo
             _mycontroller.SaveTongzhi(myinfo);
         
            }

    
          
            MessageBox.Show("保存成功！");
          
            this.DialogResult = DialogResult.OK;
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void WFtongzhigonggao_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pb_renyuan_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson();
            if (mywin.ShowDialog()==DialogResult.OK)
            {
                tb_yuedufanwei.Text = string.Join(",", mywin.list_selected);

            }
        }
        UIHelper _ui = new UIHelper();
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void lbl_quxiao_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }

        private void lbl_quxiao_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

    }
}
