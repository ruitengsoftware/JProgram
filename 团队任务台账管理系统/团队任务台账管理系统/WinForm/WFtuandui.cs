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
    public partial class WFtuandui : Form
    {

        ControllerTuandui mycontroller = new ControllerTuandui();
        public Action updatedata;
        public WFtuandui()
        {
            InitializeComponent();

        }
        public WFtuandui(JJTuanduiInfo myinfo)
        {
            InitializeComponent();
            this.tb_mingcheng.Text = myinfo._mingcheng;
            this.tb_fuzeren.Text = myinfo._fuzeren;
            this.tb_chengyuan.Text = myinfo._chengyuan;
            this.pb_zhaopian.Image = JJImageHelper.ConvertBase64ToImage(myinfo._tuanduitupian);
                this.tb_lingyu.Text = myinfo._gongzuolingyu;
        }
        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击添加负责人按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_fuzeren_Click(object sender, EventArgs e)
        {
            WFperson mywf = new WFperson(string.Empty);//这里必须传参，但实际没有需要
            if (mywf.ShowDialog() == DialogResult.OK)
            {
                tb_fuzeren.Text = string.Join(",", mywf.list_person);
            }
        }

        private void pb_chengyuan_Click(object sender, EventArgs e)
        {
            WFperson mywf = new WFperson(string.Empty);//这里必须传参，但实际没有需要
            if (mywf.ShowDialog() == DialogResult.OK)
            {
                tb_chengyuan.Text = string.Join(",", mywf.list_person);



            }

        }

        private void btn_chuangjian_Click(object sender, EventArgs e)
        {

            //构造一个团队信息类

            JJTuanduiInfo myinfo = new JJTuanduiInfo()
            {
                _mingcheng = tb_mingcheng.Text.Trim(),
                _fuzeren = tb_fuzeren.Text.Trim(),
                _chengyuan = tb_chengyuan.Text.Trim(),
                _tuanduitupian = JJImageHelper.ConvertImageToBase64(pb_zhaopian.Image),
                _gongzuolingyu = tb_lingyu.Text.Trim()


            };
            if (myinfo._mingcheng.Equals(string.Empty))
            {
                MessageBox.Show("团队名不能为空！");
                return;
            }

            //添加团队名称，负责人，成员到数据库
            bool bb = mycontroller.InsertTuandui(myinfo);

            //提示是否保存成功
            if (bb)
            {
                MessageBox.Show("团队创建成功！");
            }
            //刷新父窗体
            //dialog.result赋值
            this.DialogResult = DialogResult.OK;



        }

        private void lbl_shangchuan_Click(object sender, EventArgs e)
        {
            //打开文件选择
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //文件转化成图片
                Image img = Image.FromFile(ofd.FileName);
                //图片改变尺寸
                Image newimg = JJImageHelper.UpdateImageSize(img, 256, 256);
                //显示在image中
                
                pb_zhaopian.Image = newimg;
            }






        }
    }
}
