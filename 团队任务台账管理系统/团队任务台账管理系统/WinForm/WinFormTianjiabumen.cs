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
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WinFormTianjiabumen : Form
    {
        //如果登录权限为超级管理员，那么可以设置一级标题，如果选中了一级标题，那么所属节点flp不可见
        //如果扽牢固权限为管理员，那么级别中只可显示二级标题，所属部门一直可见





        ControllerTianjiabumen _mycontroller = new ControllerTianjiabumen();




        public WinFormTianjiabumen()
        {
            InitializeComponent();
           //加载级别列表
            if (JJLoginInfo._quanxian.Equals("超级管理员"))
            {
                cbb_jibie.Items.Add("一级部门");
                cbb_jibie.Items.Add("二级部门");

            }
            else if (JJLoginInfo._quanxian.Equals("管理员"))
            {
                cbb_jibie.Items.Add("二级部门");
            }
            //加载所属部门列表
            List<string> list = _mycontroller.GetYijibumen();
            cbb_suoshubumen.Items.AddRange(list.ToArray());




        }

        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_queding_Click(object sender, EventArgs e)
        {
            //判断是否有为输入的文本，名称，级别，所属部门
            //如果是二级标题，需要判断2个内容
            //如果是一级标题，需要判断1个内容
            bool _mingcheng = tb_mingcheng.Text.Trim().Equals(string.Empty);
            bool _bumen = cbb_suoshubumen.Text.Trim().Equals(string.Empty);
            if (cbb_jibie.Text.Trim().Equals("一级部门"))
            {
                if (_mingcheng)
                {
                    MessageBox.Show("请完善信息！");
                }
            }
            else if (cbb_jibie.Text.Trim().Equals("二级部门"))
            {
                if (_mingcheng || _bumen)
                {
                    MessageBox.Show("请完善信息！");
                }

            }


            JJBumenInfo ji = new JJBumenInfo()
            {
                _mingcheng = tb_mingcheng.Text,
                _jibie = cbb_jibie.Text,
                _suoshubumen = cbb_suoshubumen.Text
            };
            bool b = _mycontroller.SaveBumen(ji);
            if (b)
            {
                MessageBox.Show("部门已添加！");
                this.DialogResult = DialogResult.OK;
            }




        }

        private void cbb_jibie_TextChanged(object sender, EventArgs e)
        {
            string str_jibie = cbb_jibie.Text;
            if (str_jibie.Equals("二级部门"))
            {
                flp_suoshubumen.Visible = true;
            }
            else
            {
                flp_suoshubumen.Visible = false;
            }
        }
    }
}
