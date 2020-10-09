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
    public partial class WFzhuce : Form
    {
        ControllerWFzhuce mycontroller = new ControllerWFzhuce();
        public WFzhuce()
        {
            InitializeComponent();
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
            //判断是否有没填写的项目
            string nicheng = tb_nicheng.Text.Trim();
            string xingming = tb_xingming.Text.Trim();
            string shoujihao = tb_shoujihao.Text.Trim();
            string bumen = tb_bumen.Text.Trim();
            string quanxian = cbb_quanxian.Text.Trim();
            string youxiang = tb_youxiang.Text.Trim();
            string shurumima = tb_shurumima.Text.Trim();
            string querenmima = tb_querenmima.Text.Trim();

            //判断密码是否相同
            if (!shurumima.Equals(querenmima))
            {
                tb_shurumima.Clear();
                tb_querenmima.Clear();
                MessageBox.Show("两次输入的密码不匹配！");
                return;
            }
            if (nicheng.Equals(string.Empty) || xingming.Equals(string.Empty) || shoujihao.Equals(string.Empty) ||
                bumen.Equals(string.Empty) || quanxian.Equals(string.Empty)||youxiang.Equals(string.Empty)||shurumima.Equals(string.Empty)||
                querenmima.Equals(string.Empty))
            {
                MessageBox.Show("请输入完整信息！");
            }
            //构造dic
            Dictionary<string, string> dic = new Dictionary<string, string>() {
                {"昵称",nicheng },
                {"姓名",xingming },
                {"手机号",shoujihao },
                {"部门",bumen },
                {"权限",quanxian },
                {"邮箱",youxiang },
                {"密码",querenmima },
            };
           bool b= mycontroller.Zhuce(dic);
            if (b) MessageBox.Show("注册成功！");
            this.Dispose();





        }
    }
}
