using Newtonsoft.Json;
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
using 查重工具.JJController;
using 查重工具.JJModel;
using 查重工具.JJUserControl;

namespace 查重工具
{
    public partial class Form1 : Form
    {
        JJControllerForm _myc = new JJControllerForm();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_qingkong_Click(object sender, EventArgs e)
        {
            dgv_task.Rows.Clear();
        }

        private void btn_tianjiarenwu_Click(object sender, EventArgs e)
        {
            //选择文件夹

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.GetFiles(fbd.SelectedPath);
                foreach (string str in files)
                {
                    //判断是否包含doc docx  $
                    bool b1 = Path.GetExtension(str).Equals(".doc");
                    bool b2 = Path.GetExtension(str).Equals(".docx");
                    bool b3 = str.Contains("$");
                    if (b3)
                    {
                        continue;
                    }
                    if (b1 || b2)
                    {
                        int index = dgv_task.Rows.Add();
                        dgv_task.Rows[index].Cells[1].Value = str;
                    }
                }
            }





        }
        /// <summary>
        /// 点击保存格式按钮式触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string formatname = cbb_geshimingcheng.Text;
            //构造一个jjgeshiinfo
            JJGeshiInfo info = new JJGeshiInfo()
            {
                _mingcheng = cbb_geshimingcheng.Text,
                _chachongku = cbb_chachongku.Text,
                _quanwenchongfulujing = tb_quanwenchongfulujing.Text,
                _zhengwenchongfulujing = tb_zhengwenchongfulujing.Text,
                _quanwenchachong = Convert.ToInt32(cb_quanwenchachong.Checked),
                _zhengwenchachong = Convert.ToInt32(cb_zhengwenchachong.Checked),
                _biaozhunduanchachong = Convert.ToInt32(cb_biaozhunduanchachong.Checked),
                _biaozhunjuchachong = Convert.ToInt32(cb_biaozhunjuchachong.Checked),
                _quanwenruku = Convert.ToInt32(cb_quanwenruku.Checked),
                _zhengwenruku = Convert.ToInt32(cb_zhengwenruku.Checked),
                _biaozhunduanruku = Convert.ToInt32(cb_biaozhunduanruku.Checked),
                _biaozhunjuruku = Convert.ToInt32(cb_biaozhunjuruku.Checked)



            };
            List<JJBaifenbi> list = new List<JJBaifenbi>();
            //构造json格式的百分比设置
            foreach (UserControl uc in panel1.Controls)
            {
                JJUCbairfenbi myuc = uc as JJUCbairfenbi;
                list.Add(myuc._myb);
            }
            string json_baifenbi = JsonConvert.SerializeObject(list);
            info._baifenbishezhi = json_baifenbi;
            //保存数据
            bool b = _myc.SaveFormat(info);
            if (b)
            {
                MessageBox.Show("格式已保存！");
            }
            //刷新界面数据,切换一下选中的文格式名称
            cbb_chachongku.Text = string.Empty;
            cbb_chachongku.Text = formatname;

        }
        /// <summary>
        /// 点击删除按钮式触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {


            //构造一个jjgeshiinfo
            JJGeshiInfo info = new JJGeshiInfo()
            {
                _mingcheng = cbb_geshimingcheng.Text


            };
            //删除格式
            _myc.DeleteFormat(info);
            //刷新界面数据
            cbb_geshimingcheng.SelectedIndex = 0;
        }






        private void btn_baifenbi_Click(object sender, EventArgs e)
        {
            //实例化一个ucbaifenbi
            JJUCbairfenbi myuc = new JJUCbairfenbi() { Dock = DockStyle.Top };
            panel1.Controls.Add(myuc);
            panel1.Controls.SetChildIndex(myuc, 0);



        }
    }
}
