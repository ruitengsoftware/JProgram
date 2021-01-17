using RuiTengDll;
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
using 团队任务台账管理系统.Common;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFqingxiujiadan : Form
    {
        ControllerWFqingxiujia _mycontroller = new ControllerWFqingxiujia();
        JJTaskInfo _info = null;
        public WFqingxiujiadan()
        {
            InitializeComponent();
        }
        public WFqingxiujiadan(JJTaskInfo ji)
        {
            InitializeComponent();
            _info = ji;
            if (!JJLoginInfo._huaming.Equals(_info._chuangjianren))
            {
                tb_shiyou.Enabled = false;
                panel1.Enabled = false;
                tlp_shijian.Enabled = false;
                tb_qingjaitianshu.Enabled = false;
                tb_weituoren.Enabled = false;
                tb_xiaojiaqingkuang.Enabled = false;
            }
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            //构造qingjaiinfo
            JJTaskInfo myinfo = new JJTaskInfo()
            {
                _shiyou = tb_shiyou.Text,
                _jinjichengdu = rb_putong.Checked ? "普通" : "紧急",
                _qingjiatianshu = Convert.ToInt32(tb_qingjaitianshu.Text),
                _qizhishijian = $"{dtp_start.Value.ToString()}|{dtp_end.Value.ToString()}",
                _weituoduixiang=tb_weituoren.Text,
                _shenherenyuan=tb_shenherenyuan.Text,
                _shenheyijian=tb_shenheyijian.Text,
               _xiaojiaqingkuang=tb_xiaojiaqingkuang.Text,
                 _chuangjianshijian = DateTime.Now.ToString(),
                _chuangjianren = JJLoginInfo._huaming,
                _leixing = "请休假单",
                _zhuangtai = "保存"

            };

            //保存
            bool b = _mycontroller.SaveQingxiujia(myinfo);
            if (b)
            {
                JJMethod.a_checknewtask(null, null);

                MessageBox.Show("保存成功!");
                this.DialogResult = DialogResult.OK;

            }

        }
        /// <summary>
        /// 点击发送办理按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label10_Click(object sender, EventArgs e)
        {
            //再发送之前先保存任务信息

            //构造qingjaiinfo
            JJTaskInfo myinfo = new JJTaskInfo()
            {
                _shiyou = tb_shiyou.Text,
                _jinjichengdu = rb_putong.Checked ? "普通" : "紧急",
                _qingjiatianshu = Convert.ToInt32(tb_qingjaitianshu.Text),
                _qizhishijian = $"{dtp_start.Value.ToString()}|{dtp_end.Value.ToString()}",
                _weituoduixiang = tb_weituoren.Text,
                _shenherenyuan = tb_shenherenyuan.Text,
                _shenheyijian = tb_shenheyijian.Text,
                _xiaojiaqingkuang = tb_xiaojiaqingkuang.Text,
                _chuangjianshijian = DateTime.Now.ToString(),
                _chuangjianren = JJLoginInfo._huaming,
                _leixing = "请休假单",
                _zhuangtai = "保存"
            };

            //保存
            bool b = _mycontroller.SaveQingxiujia(myinfo);
            //分解委托对象
            string[] arr_weituoduixiang = Regex.Split(tb_weituoren.Text, ",");
            //分解审核人员
            string[] arr_shenherenyuan = Regex.Split(tb_shenherenyuan.Text, ",");
            foreach (string weituoren in arr_weituoduixiang)
            {
                foreach (string shenheduixiang in arr_shenherenyuan)
                {
                    //构造一个jjtongzhiinfo
                    JJTaskInfo info = new JJTaskInfo
                    {
                        _shiyou = tb_shiyou.Text,
                        _jinjichengdu = rb_putong.Checked ? "普通" : "紧急",
                        _qingjiatianshu = Convert.ToInt32(tb_qingjaitianshu.Text),
                        _qizhishijian = $"{dtp_start.Value.ToString()}|{dtp_end.Value.ToString()}",
                        _weituoduixiang = weituoren,
                        _shenherenyuan = shenheduixiang,
                        _shenheyijian = tb_shenheyijian.Text,
                        _xiaojiaqingkuang = tb_xiaojiaqingkuang.Text,
                        _fasongshijian = DateTime.Now.ToString(),
                        _fasongren = JJLoginInfo._huaming,
                        _leixing = "请休假单",
                        _zhuangtai = "未读"
                    };
                    //拆解反馈对象，对每一个对象，向任务信息表中插入一条jjtaskinfo
                     b = _mycontroller.FasongBanli(info);
                }
            }
            JJMethod.a_checknewtask(null, null);
            MessageBox.Show("发送办理成功！");
        }

        private void pb_person_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_weituoren.Text = string.Join(",", mywin.list_selected);
            }

        }

        private void pb_person2_Click(object sender, EventArgs e)
        {
            WFperson mywin = new WFperson()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_shenherenyuan.Text = string.Join(",", mywin.list_selected);
            }

        }
        UIHelper _ui = new UIHelper();
        private void lbl_baocun_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void lbl_baocun_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void lbl_baocun_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
        /// <summary>
        /// 加载界面数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WFqingxiujiadan_Load(object sender, EventArgs e)
        {
            if (_info!=null)
            {
            tb_shiyou.Text = _info._shiyou;
            rb_jinji.Checked = _info._jinjichengdu.Equals("紧急") ? true : false;
            rb_putong.Checked = _info._jinjichengdu.Equals("普通") ? true : false;

            tb_qingjaitianshu.Text = _info._qingjiatianshu.ToString();
            dtp_start.Value = Convert.ToDateTime(Regex.Split(_info._qizhishijian,@"\|")[0]);
            dtp_end.Value = Convert.ToDateTime(Regex.Split(_info._qizhishijian, @"\|")[1]);
                //委托对象和审核人员，这里还没有做完
                tb_weituoren.Text = _info._weituoduixiang;
                tb_shenherenyuan.Text = _info._shenherenyuan;
            tb_shenheyijian.Text = _info._shenheyijian;
            tb_xiaojiaqingkuang.Text = _info._xiaojiaqingkuang;

            }
        }
    }
}
