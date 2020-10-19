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
            //判断团队名称，不许为空
            string tuandui = tb_mingcheng.Text.Trim();
            string fuzeren = tb_fuzeren.Text.Trim();
            string chengyuan = tb_chengyuan.Text.Trim();
            if (tuandui.Equals(string.Empty))
            {
                MessageBox.Show("团队名不能为空！");
                return;
            }
            //判断团队名是否为重复，如果重复，提示，退出本方法
            bool b = mycontroller.ExistTuandui(tuandui);
            if (b)
            {
                MessageBox.Show("团队名称已存在！");
                return;

            }
            //添加团队名称，负责人，成员到数据库
            bool bb = mycontroller.InsertTuandui(tuandui, fuzeren, chengyuan);

            //提示是否保存成功
            if (bb)
            {
                MessageBox.Show("团队创建成功！");
            }
            //刷新父窗体

            updatedata();

            //dialog.result赋值
            this.DialogResult = DialogResult.OK;



        }
    }
}
