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

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCtongxunluxiangqing : UserControl
    {
        bool _checked=false;
        public UCtongxunluxiangqing()
        {
            InitializeComponent();
        }
        public UCtongxunluxiangqing(JJPersonInfo personinfo)
        {
            InitializeComponent();

            this.lbl_xingming.Text = personinfo._shiming;
            this.lbl_zhiwu.Text = personinfo._zhiji;
            this.lbl_lianxifangshi.Text = personinfo._shoujihao;

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

        private void lbl_xiangqing_Click(object sender, EventArgs e)
        {

        }

    }
}
