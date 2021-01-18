using MySqlX.XDevAPI.Common;
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
    public partial class WFzhuce : Form
    {
        ControllerWFzhuce _mycontroller = new ControllerWFzhuce();

        public WFzhuce()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 构造函数，展示当前登录信息窗口
        /// </summary>
        /// <param name="i"></param>
        public WFzhuce(int i)
        {
            InitializeComponent();
            tb_huaming.Text = JJLoginInfo._huaming;
            tb_shoujihao.Text = JJLoginInfo._shoujihao;
            tb_shiming.Text = JJLoginInfo._shiming;
            tb_zidingyi.Text = JJLoginInfo._zidingyizhanghao;
            tb_bumen.Text = JJLoginInfo._bumen;
            tb_zhiji.Text = JJLoginInfo._zhiji;
            //获得头像和额工作证件头像，然后进行缩小处理
            //var pt= JJImageHelper.ConvertBase64ToImage(JJLoginInfo._touxiang);
            //pb_touxiang.Image = JJImageHelper.UpdateImageSize(pt, 256, 256);
            pb_touxiang.Image = JJImageHelper.ConvertBase64ToImage(JJLoginInfo._touxiang); ;
            var pg = JJImageHelper.ConvertBase64ToImage(JJLoginInfo._gongzuozhengjianzhao);
            pb_gongzuozheng.Image = JJImageHelper.UpdateImageSize(pg, 128, 128);
            tb_weixinhao.Text = JJLoginInfo._weixinhao;
            tb_dianziyouxiang.Text = JJLoginInfo._dianziyouxiang;
            tb_gerenqianming.Text = JJLoginInfo._gerenqianming;
            tb_shurumima.Text = JJLoginInfo._mima;
            tb_querenmima.Text = JJLoginInfo._mima;

        }

        /// <summary>
        /// 构造函数，展示当前选中person窗口
        /// </summary>
        /// <param name="i"></param>
        public WFzhuce(JJPersonInfo pi)
        {
            InitializeComponent();
            tb_huaming.Text = pi._huaming;
            tb_shoujihao.Text = pi._shoujihao;
            tb_shiming.Text = pi._shiming;
            tb_zidingyi.Text = pi._zidingyizhanghao;
            tb_bumen.Text = pi._bumen;
            tb_shurumima.Text = pi._mima;
            tb_querenmima.Text = pi._mima;
            tb_zhiji.Text = pi._zhiji;
            pb_touxiang.Image = JJImageHelper.ConvertBase64ToImage(pi._touxiang);
            pb_gongzuozheng.Image = JJImageHelper.ConvertBase64ToImage(pi._gongzuozhengjianzhao);
            tb_weixinhao.Text = pi._weixinhao;
            tb_dianziyouxiang.Text = pi._dianziyouxiang;
            tb_gerenqianming.Text = pi._gerenqianming;




        }


        private void btn_tuichu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击注册按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zhuce_Click(object sender, EventArgs e)
        {

            //获得输入密码和确认密码
            string shurumima = tb_shurumima.Text;
            string querenmima = tb_querenmima.Text;
            //检测必填项目是否有空
            if (tb_shiming.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请填写实名！");
                return;
            }
            if (!Regex.IsMatch(tb_shoujihao.Text, @"\d{11}"))
            {
                MessageBox.Show("手机号格式不正确！");
                return;
            }
            if (tb_shurumima.Text.Trim().Equals(string.Empty) || tb_querenmima.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }

            //判断密码是否相同
            if (!shurumima.Equals(querenmima))
            {
                tb_shurumima.Clear();
                tb_querenmima.Clear();
                MessageBox.Show("两次输入的密码不匹配！");
                return;
            }
            if (tb_bumen.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请选择部门！");
                return;
            }
            if (tb_weixinhao.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请填写微信号！");
                return;
            }
            if (tb_dianziyouxiang.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请填写电子邮箱！");
                return;
            }







            //构造一个personinfo类
            JJPersonInfo myinfo = new JJPersonInfo()
            {
                _huaming = tb_huaming.Text.Trim(),
                _shiming = tb_shiming.Text.Trim(),
                _shoujihao = tb_shoujihao.Text.Trim(),
                _bumen = tb_bumen.Text.Trim(),
                _zhiji = tb_zhiji.Text.Trim(),
                _dianziyouxiang = tb_dianziyouxiang.Text.Trim(),
                //_shurumima = tb_shurumima.Text.Trim(),
                //_querenmima = tb_querenmima.Text.Trim(),
                _mima = tb_querenmima.Text.Trim(),
                _zidingyizhanghao = tb_zidingyi.Text.Trim(),
                _touxiang = JJImageHelper.ConvertImageToBase64(pb_touxiang.Image),
                _gongzuozhengjianzhao = JJImageHelper.ConvertImageToBase64(pb_gongzuozheng.Image),
                _weixinhao = tb_weixinhao.Text.Trim(),
                _gerenqianming = tb_gerenqianming.Text.Trim()
            };
            //保存到数据库中，update语句
            bool b = _mycontroller.BaocunInfo(myinfo);
            //如果保存成功，赋值给 jjlogininfo
            if (b)
            {
                JJLoginInfo.GetLoginInfo(JJLoginInfo._huaming);
                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK;
            }

        }


        private void lbl_bumen_Click(object sender, EventArgs e)
        {
            WFbumen mywin = new WFbumen() { StartPosition = FormStartPosition.CenterParent };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_bumen.Text = mywin.str_select;
            }
        }

        private void lbl_zhiji_Click(object sender, EventArgs e)
        {
            WFzhiji mywin = new WFzhiji() { StartPosition = FormStartPosition.CenterParent };
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_zhiji.Text = mywin.str_select;
            }
        }
        /// <summary>
        /// 点击添加头像按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_tianjiatouxiang_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap mybmp = new Bitmap(ofd.FileName);

                var newbmp = JJImageHelper.UpdateImageSize(mybmp, 128, 128);

                pb_touxiang.Image = newbmp;
            }



        }

        private void pb_tianjiagongzuozhao_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap mybmp = new Bitmap(ofd.FileName);
                var newbmp = new Bitmap(mybmp, 128, 128);

                pb_gongzuozheng.Image = mybmp;
            }

        }

        private void pb_gongzuozheng_MouseEnter(object sender, EventArgs e)
        {
            //toolTip1.InitialDelay = 1000;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(pb_gongzuozheng, "管理类、技术类必填，综合类选填");

        }

        private void WFzhuce_Load(object sender, EventArgs e)
        {

        }

        private void label8_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
    }
}
