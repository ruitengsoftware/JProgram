using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string huaming = tb_huaming.Text.Trim();
            string shiming = tb_shiming.Text.Trim();
            string shoujihao = tb_shoujihao.Text.Trim();
            string bumen = tb_bumen.Text.Trim();
            string zhiji = tb_zhiji.Text.Trim();
            string dianziyouxiang = tb_dianziyouxiang.Text.Trim();
            string shurumima = tb_shurumima.Text.Trim();
            string querenmima = tb_querenmima.Text.Trim();
            string zidingyizhanghao = tb_zidingyi.Text.Trim();
            var touxiang = pb_touxiang.Image;
            var zhengjianzhao = pb_gongzuozheng.Image;
            string weixinhao = tb_weixinhao.Text.Trim();
            //判断密码是否相同
            if (!shurumima.Equals(querenmima))
            {
                tb_shurumima.Clear();
                tb_querenmima.Clear();
                MessageBox.Show("两次输入的密码不匹配！");
                return;
            }
            if (huaming.Equals(string.Empty) || shiming.Equals(string.Empty) || shoujihao.Equals(string.Empty) ||
                bumen.Equals(string.Empty) || touxiang==null||weixinhao.Equals(string.Empty)||dianziyouxiang.Equals(string.Empty)||
                shurumima.Equals(string.Empty)||
                querenmima.Equals(string.Empty))
            {
                MessageBox.Show("请输入完整信息！");
            }
            //判断花名是否已经被注册
            bool existhuaming = mycontroller.ExistsHuaming(huaming);
            if (existhuaming)
            {
                lbl_cunzai.Text = "花名有主";
                return;
            }
            else
            {
                lbl_cunzai.Text = "可以捷足先登";
            }
            //判断自定义账号是否已经被注册
            string zhanghao = tb_zidingyi.Text.Trim();
            if (!zhanghao.Equals(string.Empty))
            {
                bool existzhanghao = mycontroller.ExistsZidingyi(zhanghao);
                if (existzhanghao)
                {
                    lbl_zhanghaocunzai.Text = "账号有主";
                    return;
                }
                else
                {
                    lbl_zhanghaocunzai.Text = "可以捷足先登";
                }
            }


            //构造dic
            Dictionary<string, string> dic = new Dictionary<string, string>() {
                {"花名",huaming },
                {"实名",shiming },
                {"部门",bumen },
                {"职级",zhiji },
                {"密码",querenmima },
                {"手机号",shoujihao },
                                {"电子邮箱",dianziyouxiang },
                {"自定义账号",zidingyizhanghao },

                {"头像",mycontroller.ConvertImageToBase64(touxiang)},//把图片转换成base64
                {"工作证件照",mycontroller.ConvertImageToBase64(zhengjianzhao)},
                {"微信号",weixinhao },

            };
           bool b= mycontroller.Zhuce(dic);
            if (b) MessageBox.Show("注册成功！");
            this.Dispose();





        }


        private void lbl_bumen_Click(object sender, EventArgs e)
        {
            WFshenfen mywin = new WFshenfen();
            if (mywin.ShowDialog()==DialogResult.OK)
            {
                tb_bumen.Text = mywin.str_select;
            }
        }

        private void lbl_zhiji_Click(object sender, EventArgs e)
        {
            WFzhiji mywin = new WFzhiji();
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
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                Bitmap mybmp = new Bitmap(ofd.FileName);
                pb_touxiang.Image = mybmp;
            }

            

        }

        private void pb_tianjiagongzuozhao_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap mybmp = new Bitmap(ofd.FileName);
                pb_gongzuozheng.Image = mybmp;
            }

        }
    }
}
