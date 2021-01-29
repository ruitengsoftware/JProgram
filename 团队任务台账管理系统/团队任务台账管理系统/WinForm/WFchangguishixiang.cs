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
using 团队任务台账管理系统.UserControll;

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
            rb_putong.Checked = myinfo._jinjichengdu.Equals("普通") ? true : false;
            rb_jinji.Checked = myinfo._jinjichengdu.Equals("紧急") ? true : false;
            tb_jutiyaoqiu.Text = myinfo._jutiyaoqiu;
            tb_banlirenyuan.Text = myinfo._banlirenyuan;
            tb_banliyijian.Text = myinfo._banliyijian;
            tb_jinzhanqingkuang.Text = myinfo._jinzhanqingkuang;
            dtp_shixian.Value = Convert.ToDateTime(myinfo._shixian);
            //加载附件
            foreach (string s in Regex.Split(myinfo._fujian, @"\|"))
            {
                if (s.Equals(string.Empty))
                {
                    continue;
                }
                UCfujianInfo myuc = new UCfujianInfo(s) { Dock = DockStyle.Top };
                uCfujian1.panel_fujian.Controls.Add(myuc);
            }
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
            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _mingcheng = tb_renwumingcheng.Text,
                _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                _jutiyaoqiu = tb_jutiyaoqiu.Text,
                _fujian = string.Join("|", uCfujian1.list_fujian),
                _shixian = dtp_shixian.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                _banliyijian = tb_banliyijian.Text,
                _banlirenyuan = tb_banlirenyuan.Text,
                _jinzhanqingkuang = tb_jinzhanqingkuang.Text,
                _chuangjianshijian = DateTime.Now.ToString(),
                _chuangjianren = JJLoginInfo._shiming,
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
        /// <summary>
        /// 点击发送办理按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fasongbanli_Click(object sender, EventArgs e)
        {
            //发送任务之前，需要先保存任务信息，方便打开的时候调用
            //构造一个jjtongzhiinfo
            JJTaskInfo myinfo = new JJTaskInfo
            {
                _mingcheng = tb_renwumingcheng.Text,
                _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                _jutiyaoqiu = tb_jutiyaoqiu.Text,
                _fujian = string.Join("|", uCfujian1.list_fujian),
                _shixian = dtp_shixian.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                _banliyijian = tb_banliyijian.Text,
                _banlirenyuan = tb_banlirenyuan.Text,
                _jinzhanqingkuang = tb_jinzhanqingkuang.Text,
                _chuangjianshijian = DateTime.Now.ToString(),
                _chuangjianren = JJLoginInfo._shiming,
                _leixing = "常规事项",
                _zhuangtai = "保存"
            };

            //添加任务
            bool b = mycontroller.AddTask(myinfo);
            //分解办理人员
            string[] arr_banlirenyuan = Regex.Split(tb_banlirenyuan.Text, ",");
            foreach (string s in arr_banlirenyuan)
            {
                //构造一个jjtongzhiinfo
                myinfo = new JJTaskInfo
                {
                    _mingcheng = tb_renwumingcheng.Text,
                    _jinjichengdu = rb_jinji.Checked == true ? "紧急" : "普通",
                    _jutiyaoqiu = tb_jutiyaoqiu.Text,
                    _fujian = string.Join("|", uCfujian1.list_fujian),
                    _shixian = dtp_shixian.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                    _banliyijian = tb_banliyijian.Text,
                    _banlirenyuan = s,
                    _jinzhanqingkuang = tb_jinzhanqingkuang.Text,
                    _fasongshijian = DateTime.Now.ToString(),
                    _fasongren = JJLoginInfo._shiming,
                    _leixing = "常规事项",
                    _zhuangtai = "未读"
                };
                //拆解反馈对象，对每一个对象，向任务信息表中插入一条jjtaskinfo
                 b = mycontroller.FasongBanli(myinfo);
            }
                JJMethod.a_checknewtask(null, null);
                MessageBox.Show("发送办理成功！");
        }



        private void pb_person_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson();
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_banlirenyuan.Text = string.Join(",", mywin.list_selected);
            }
        }

        private void btn_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        UIHelper _ui = new UIHelper();
        private void label7_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }

        private void WFchangguishixiang_Load(object sender, EventArgs e)
        {

        }
    }
}
