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
    public partial class WFchangguishixiang : Form
    {
        public JJTaskInfo mytask = new JJTaskInfo();
        public WFchangguishixiang()
        {
            InitializeComponent();
        }

        public WFchangguishixiang(JJTaskInfo myinfo)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            tb_renwumingcheng.Text = myinfo._mingcheng;
            rb_putong.Checked = myinfo._jinjichengdu.Equals("普遍") ? true : false;
            rb_jinji.Checked = myinfo._jinjichengdu.Equals("紧急") ? true : false;
            lb_fujian.Items.AddRange(Regex.Split(myinfo._fujian, @"\|"));
            tb_jutiyaoqiu.Text = myinfo._xiangqing;
            tb_banlirenyuan.Text = myinfo._banlirenyuan;
            tb_banliyijian.Text = myinfo._banliyijian;
            tb_jinzhanqingkuang.Text = myinfo._jinzhanqingkuang;
            dtp_shixian.Value = Convert.ToDateTime(myinfo._shixian);
            //判断登录信息，创建人是否等于登录人,如果不是，任务任务名称，紧急程度，任务具体要求，上传附件，时限不可用
            if (!JJLoginInfo._huaming.Equals(myinfo._chuangjianren))
            {
                tb_renwumingcheng.Enabled = false;
                panel1.Enabled = false;
                tlp_yaoqiu.Enabled = false;
                panel_fujian.Enabled = false;
                dtp_shixian.Enabled = false;


            }


        }

        ControllerChangguishixiang mycontroller = new ControllerChangguishixiang();
        private void btn_shanchu_Click(object sender, EventArgs e)
        {
            // //获得任务名称
            // string str_task = tb_renwumingcheng.Text;
            // //从数据库中删除这条记录
            //bool b= mycontroller.DeleteTask(str_task);
            // if (b) MessageBox.Show("删除任务成功！");


            this.Dispose();


        }

        private void btn_baocun_Click(object sender, EventArgs e)
        {
            //判断信息是否为空
            bool b1 = tb_renwumingcheng.Text.Trim().Equals(string.Empty);
            bool b2 = tb_jutiyaoqiu.Text.Trim().Equals(string.Empty);

            if (b1)
            {
                MessageBox.Show("任务名称未填写！");
                return;
            }
            if (b2)
            {
                MessageBox.Show("详情未填写！");
                return;
            }
            List<string> list = new List<string>();
            foreach (string str in lb_fujian.Items)
            {
                list.Add(str);
            }

            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _mingcheng = tb_renwumingcheng.Text,
                _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                _jutiyaoqiu = tb_jutiyaoqiu.Text,
                _fujian = string.Join("|", list),
                _shixian = dtp_shixian.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                _banliyijian = tb_banliyijian.Text,
                _banlirenyuan = tb_banlirenyuan.Text,
                _jinzhanqingkuang = tb_jinzhanqingkuang.Text,
                _chuangjianshijian = DateTime.Now.ToString(),
                _chuangjianren = JJLoginInfo._huaming,
                _leixing = "常规事项",
                _zhuangtai = "保存"
            };

            //添加任务
            bool b = mycontroller.AddTask(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null, null);

                MessageBox.Show("保存成功！");
                mytask = myinfo;
                this.DialogResult = DialogResult.OK;

            }
        }

        private void btn_fasongbanli_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (string str in lb_fujian.Items)
            {
                list.Add(str);
            }


            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _mingcheng = tb_renwumingcheng.Text,
                _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                _jutiyaoqiu = tb_jutiyaoqiu.Text,
                _fujian = string.Join("|", list),
                _shixian = dtp_shixian.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                _banliyijian = tb_banliyijian.Text,
                _banlirenyuan = tb_banlirenyuan.Text,
                _jinzhanqingkuang = tb_jinzhanqingkuang.Text,
                _fasongshijian = DateTime.Now.ToString(),
                _fasongren = JJLoginInfo._huaming,
                _leixing = "常规事项",
                _zhuangtai = "未读"

            };


            //拆解反馈对象，对每一个对象，向任务信息表中插入一条jjtaskinfo
            bool b = mycontroller.FasongBanli(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null, null);

                MessageBox.Show("发送办理成功！");
            }
        }

        private void pb_xuanze_Click(object sender, EventArgs e)
        {
            //选择文件
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //文件名载入lb_fujian


                lb_fujian.Items.Add(ofd.FileName);
            }




        }

        private void pb_shanchu_Click(object sender, EventArgs e)
        {
            var select_item = lb_fujian.SelectedItem;
            lb_fujian.Items.Remove(select_item);
        }

        private void pb_shangchuan_Click(object sender, EventArgs e)
        {
            foreach (string str in lb_fujian.Items)
            {
                //构造存放位置路径
                string str_path = "http://" + $"49.233.40.109/常规事项/{JJLoginInfo._huaming}/";
                //string str_path = "http://" + $"49.233.40.109/haahah/";
                //上传
                JJMethod.UpLoadFile(str, str_path, false);
            }
            MessageBox.Show("附件已上传！");
        }
    }
}
