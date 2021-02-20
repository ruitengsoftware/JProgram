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
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFgongzuoqingdan : Form
    {
        MySQLHelper _mysql = new MySQLHelper();

        public WFgongzuoqingdan()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数，传递进来一个清单信息
        /// </summary>
        /// <param name="q"></param>
        public WFgongzuoqingdan(JJQingdanInfo q)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            rb_a.Checked = q._qingzhonghuanji.Contains("A类") ? true : false;
            rb_b.Checked = q._qingzhonghuanji.Contains("B类") ? true : false;

            rb_c.Checked = q._qingzhonghuanji.Contains("C类") ? true : false;

            rb_d.Checked = q._qingzhonghuanji.Contains("D类") ? true : false;

            tb_renwumingcheng.Text = q._renwumingcheng;
            dtp_wanchengshijian.Value = Convert.ToDateTime(q._wanchengshijian);
            tb_beizhu.Text = q._beizhu;
            tb_renwuneirong.Text = q._renwuneirong;
            foreach (RadioButton rb in groupBox2.Controls)
            {
                if (rb.Text==q._qingzhonghuanji)
                {
                    rb.Checked = true;
                }
            }
            //判断是否为创建人打开的
            //如果是创建人代开的，不显示确定按钮
            if (!JJLoginInfo._shiming.Equals(q._chuangjianren))
            {
                lbl_queding.Visible =false;
            }



        }
        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        ControllerXinjiangongzuoqingdan _mycontroller = new ControllerXinjiangongzuoqingdan();
        /// <summary>
        /// 点击确定按钮时触发的时间，用于保存工作清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_queding_Click(object sender, EventArgs e)
        {
            //先判断数据库中是否有登陆人创建的同名工作清单
            string str_sql = $"select count(*) from jjdbrenwutaizhang.工作清单表 " +
                $"where 创建人='{JJLoginInfo._shiming}' and 名称='{tb_renwumingcheng.Text}'";
            int num =Convert.ToInt32( _mysql.ExecuteScalar(str_sql));
            if (num>0)
            {
                MessageBox.Show("任务名称重复！请重新输入！");
               
                return;
            }
            //保存任务，构建一个任务对象，保存到数据库
            JJQingdanInfo myrenwu = new JJQingdanInfo() {
                _renwumingcheng = tb_renwumingcheng.Text,
                _chuangjianren = JJLoginInfo._shiming,
                _wanchengshijian = dtp_wanchengshijian.Value.ToString("yyyy年MM月dd日 hh:mm:ss"),
              _renwuneirong=tb_renwuneirong.Text,
                _chuangjianshijian = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss"),
                _beizhu=tb_beizhu.Text,
                _zhuangtai="办理中"
            };
            if (rb_a.Checked)
            {
                myrenwu._qingzhonghuanji = "A类紧急且重要";
            }
            if (rb_b.Checked)
            {
                myrenwu._qingzhonghuanji = "B类紧急但不重要";
            }
            if (rb_c.Checked)
            {
                myrenwu._qingzhonghuanji = "C类不急但重要";
            }
            if (rb_d.Checked)
            {
                myrenwu._qingzhonghuanji = "D类不急且不重要";
            }




            //保存工作清单任务
          bool b=  _mycontroller.SaveGongzuoqingdan(myrenwu);
            if (b)
            {
                MessageBox.Show("清单已添加！");
           this.DialogResult = DialogResult.OK;

            }

        }

        private void WFgongzuoqingdan_Load(object sender, EventArgs e)
        {
            //tb_zhubanren.Text = JJLoginInfo._shiming;
        }

        private void rb_a_CheckedChanged(object sender, EventArgs e)
        {
            //获得选中的radiobutton的text
            if ((sender as RadioButton).Checked)
            {
                //保存到setting中
                Properties.Settings.Default.轻重缓急 = (sender as RadioButton).Text;
                Properties.Settings.Default.Save();
            }


        }
        UIHelper _ui = new UIHelper();
        private void lbl_quxiao_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);

        }

        private void lbl_queding_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void lbl_quxiao_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
        
        private void tb_renwumingcheng_TextChanged(object sender, EventArgs e)
        {
            //修改字数剩余
            int zishu = tb_renwumingcheng.Text.Length;
           int shengyuzishu = 400 - zishu;
            //如果字数剩余0，不可以继续输入
            if (shengyuzishu<0)
            {
                tb_renwumingcheng.Text = tb_renwumingcheng.Text.Substring(0, 400);
                lbl_zishu.Text = $"0/400";

            }

            else
            {
            lbl_zishu.Text = $"{shengyuzishu}/400";

            }
           

        }

        private void lbl_zishu_Click(object sender, EventArgs e)
        {

        }

        private void tb_renwuneirong_TextChanged(object sender, EventArgs e)
        {
            //修改字数剩余
            int zishu = tb_renwuneirong.Text.Length;
            int shengyuzishu = 400 - zishu;
            //如果字数剩余0，不可以继续输入
            if (shengyuzishu < 0)
            {
                tb_renwuneirong.Text = tb_renwuneirong.Text.Substring(0, 400);
                lbl_zishu2.Text = $"0/400";

            }

            else
            {
                lbl_zishu2.Text = $"{shengyuzishu}/400";

            }

        }
    }
}
