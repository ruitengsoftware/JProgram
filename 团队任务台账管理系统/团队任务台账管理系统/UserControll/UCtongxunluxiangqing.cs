using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;
using System.IO;
using 团队任务台账管理系统.WinForm;
using RuiTengDll;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCtongxunluxiangqing : UserControl
    {
       public JJPersonInfo _jjpi = new JJPersonInfo();
        public UCtongxunluxiangqing()
        {
            InitializeComponent();
        }
        public UCtongxunluxiangqing(JJPersonInfo personinfo)
        {
            InitializeComponent();
            _jjpi = personinfo;
            this.lbl_xingming.Text = $"名字：{personinfo._shiming}";
            this.lbl_zhiwu.Text = $"职级职务：{personinfo._zhiji}";
            this.lbl_lianxifangshi.Text = $"手机号码：{personinfo._shoujihao}";
            Image img = ConvertBase64ToImage(personinfo._touxiang);
            pb_touxiang.Image = img;
        }

        /// <summary>
        /// 将64位编码转化成图片
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public Image ConvertBase64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    return Image.FromStream(ms, true);
                }

            }
            catch
            {
                return Properties.Resources.touxiang;
            }
        }

        private void pb_touxiang_Click(object sender, EventArgs e)
        {

            WFzhuce mywin = new WFzhuce(_jjpi);
            if (mywin.ShowDialog()==DialogResult.OK)
            {

            }


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }
    }
}
