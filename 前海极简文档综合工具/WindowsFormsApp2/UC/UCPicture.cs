using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.IO;
using RuiTengDll;
using WindowsFormsApp2.DLL;

namespace WindowsFormsApp2.UC
{
    public partial class UCPicture : UserControl
    {
        UIHelper uihelper = new UIHelper();
        public bool _checked = false;
        MySqlHelper _sqlhelper = new MySqlHelper();
        public UCPicture()
        {
            InitializeComponent();
        }
        public UCPicture(PictureInfo picinfo)
        {
            InitializeComponent();
           
            pb_tupian.Image = Base64StringToImage(picinfo._base64);
            lbl_name.Text = picinfo._picName;
            pb_xuanze.BackColor = Color.Transparent;
            pb_xuanze.Parent = pb_tupian;
            uihelper.DrawRoundRect((Control)pb_tupian);
        }
        /// <summary>
        /// base64编码的文本转为图片
        /// </summary>
        /// <param name="base64Str"></param>
        /// <param name="savePath"></param>
        public Image Base64StringToImage(string base64Str)
        {
            //将base64头部信息替换
            base64Str = base64Str.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "")
                .Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
            byte[] arr = Convert.FromBase64String(base64Str);
            using (MemoryStream ms = new MemoryStream(arr))
            {
                return new Bitmap(ms);
            }
        }

        public void Pb_xuanze_Click(object sender, EventArgs e)
        {
            //判断
            if (_checked == false)
            {
                pb_xuanze.Image = Properties.Resources.对号;
                this.BackColor = Color.MediumSeaGreen;
                _checked = true;
            }
            else
            {
                pb_xuanze.Image = Properties.Resources.圆圈;
                this.BackColor = Color.Silver;
                _checked = false;

            }
            //给字段选中赋值


        }

        private void Pb_tupian_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cms_right.Show(MousePosition.X, MousePosition.Y);//dgv_rightmenu是鼠标右键菜单控件
            }

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得图片名称
            string str = lbl_name.Text;
            _sqlhelper.DeleteAnyFormat("图片名", str, "图片表");
            this.Dispose();
            MessageBox.Show($"图片 {str} 删除成功！");

        }
    }
}
