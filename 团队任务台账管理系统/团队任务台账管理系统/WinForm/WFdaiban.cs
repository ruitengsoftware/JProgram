using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFdaiban : Form
    {
        ControllerWfdaiban _mycontroller = new ControllerWfdaiban();
        public WFdaiban()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数2
        /// </summary>
        /// <param name="renwuming">任务名称</param>
        public WFdaiban(JJchangguiInfo ci)
        {
            InitializeComponent();
            //获得任务详细信息,赋值到界面中
            tb_renwumingcheng.Text = ci._renwumingcheng;
            //tb_jutiyaoqiu.Text = ci._jutiyaoqiu;
            //tb_jinzhan.Text = ci._jinzhanqingkuang;
            //tb_zerenren.Text = ci._zerenren;
            //tb_yanshouren.Text = ci._yanshouren;


        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void WinFormRenwuxiangqing_Load(object sender, EventArgs e)
        {

        }

        private void btn_gengxin_Click(object sender, EventArgs e)
        {
            //构造一个待办任务实例

            JJchangguiInfo ci = new JJchangguiInfo()
            {
                _renwumingcheng = tb_renwumingcheng.Text,
                //_jutiyaoqiu = tb_jutiyaoqiu.Text,
                //_jinzhanqingkuang = tb_jinzhan.Text,
                //_zerenren = tb_zerenren.Text,
                //_yanshouren = tb_yanshouren.Text
            };


            bool b = _mycontroller.UpdateTask(ci);
            if (b)
            {
                MessageBox.Show("更新数据成功！");
                this.DialogResult = DialogResult.OK;

            }
            ////刷新数据
            //int selectindex = dgv_data.SelectedRows[0].Index;
            //UCdaiban_Load(null, null);
            //dgv_data.Rows[0].Selected = false;
            //dgv_data.Rows[selectindex].Selected = true;
            //if (b) MessageBox.Show("更新数据成功！");
        }

        private void btn_yanshou_Click(object sender, EventArgs e)
        {
            //将选中的任务构造jjchangguinifo实例
            JJchangguiInfo info = new JJchangguiInfo()
            {
                _renwumingcheng = tb_renwumingcheng.Text
            };
            //将任务名称和发送时间，办理人员存入数据库中jjtasksend
            bool b = _mycontroller.TijiaoYanshou(info);

            if (b)
            {
                MessageBox.Show("任务已提交验收！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btn_fasong_Click(object sender, EventArgs e)
        {
            string renwumingcheng = tb_renwumingcheng.Text;
            string yanshouren = tb_yanshouren.Text;
            //获得办理人员的名单

            string banliren = tb_zerenren.Text;
            List<string> list_person = Regex.Split(banliren, @"[,，]").ToList();

            //将任务名称和发送时间，办理人员存入数据库中jjtasksend
            bool b = _mycontroller.SendTask(renwumingcheng, list_person, yanshouren);

            if (b)
            {
                MessageBox.Show("任务发送成功！");
                this.DialogResult = DialogResult.OK;
            }
        }
        /// <summary>
        /// 点击通过验收按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_tongguoyanshou_Click(object sender, EventArgs e)
        {

            //将选中的任务构造jjchangguinifo实例
            JJchangguiInfo info = new JJchangguiInfo()
            {
                _renwumingcheng = tb_renwumingcheng.Text
            };
            //将任务名称和发送时间，办理人员存入数据库中jjtasksend
            bool b = _mycontroller.YanshouRenwu(info);

            if (b)
            {
                MessageBox.Show("任务已通过验收！");
                this.DialogResult = DialogResult.OK;
            }

        }

        private void pb_addbanliren_Click(object sender, EventArgs e)
        {
        //    string str_person = tb_zerenren.Text;
        //    //打开人员表,选择人员并确认
        //    WFperson mywfperson = new WFperson(str_person);
        //    if (mywfperson.ShowDialog() == DialogResult.OK)
        //    {
        //        string xingming = string.Join(",", mywfperson.list_selected);
        //        tb_zerenren.Text = xingming;
        //    }
        }

        private void pb_addyanshouren_Click(object sender, EventArgs e)
        {
            //string str_person = tb_yanshouren.Text;
            ////打开人员表,选择人员并确认
            //WFperson mywfperson = new WFperson(str_person);
            //if (mywfperson.ShowDialog() == DialogResult.OK)
            //{
            //    string xingming = string.Join(",", mywfperson.list_selected);
            //    tb_yanshouren.Text = xingming;
            //}
        }
    }
}
