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
            JJBaifenbiList mylist = new JJBaifenbiList();
            mylist.list_baifenbi = new List<JJBaifenbi>();
            //构造json格式的百分比设置
            foreach (UserControl uc in panel1.Controls)
            {
                JJUCbairfenbi myuc = uc as JJUCbairfenbi;
                mylist.list_baifenbi.Add(myuc._myb);
            }
            string json_baifenbi = JsonConvert.SerializeObject(mylist);
            info._baifenbishezhi = json_baifenbi;
            //保存数据
            bool b = _myc.SaveFormat(info);
            if (b)
            {
                MessageBox.Show("格式已保存！");
            }
            //刷新界面数据,切换一下选中的文格式名称
            //cbb_chachongku.Text = string.Empty;
            //cbb_chachongku.Text = formatname;

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
           bool b= _myc.DeleteFormat(info);
            if (b)
            {
                MessageBox.Show("格式已删除！");
                //刷新界面数据
                cbb_geshimingcheng.SelectedIndex = 0;


            }
        }






        private void btn_baifenbi_Click(object sender, EventArgs e)
        {
            //实例化一个ucbaifenbi
            JJUCbairfenbi myuc = new JJUCbairfenbi() { Dock = DockStyle.Top };
            panel1.Controls.Add(myuc);
            panel1.Controls.SetChildIndex(myuc, 0);



        }

        private void cbb_geshimingcheng_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //获得jjgeshiinof 类
                JJGeshiInfo info = _myc.GetGeshiInfo(cbb_geshimingcheng.Text);
                //刷新界面显示
                UpdateView(info);
            }
            catch { }
        }


        private void UpdateView(JJGeshiInfo jj)
        {

            //刷新界面显示
            cbb_geshimingcheng.Text = jj._mingcheng;
            cbb_chachongku.Text = jj._chachongku;
            if (jj._quanwenchongfulujing.Equals(string.Empty))
            {
                cb_quanwenmoren.Checked = true;
            }
            else
            {
                tb_quanwenchongfulujing.Text = jj._quanwenchongfulujing;
            }
            if (jj._zhengwenchongfulujing.Equals(string.Empty))
            {
                cb_zhengwenmoren.Checked = true;
            }
            else
            {
                tb_zhengwenchongfulujing.Text = jj._zhengwenchongfulujing;
            }
            cb_quanwenchachong.Checked = Convert.ToBoolean(jj._quanwenchachong);
            cb_zhengwenchachong.Checked = Convert.ToBoolean(jj._zhengwenchachong);
            cb_biaozhunduanchachong.Checked = Convert.ToBoolean(jj._biaozhunduanchachong);
            cb_biaozhunjuchachong.Checked = Convert.ToBoolean(jj._biaozhunjuchachong);
            cb_quanwenruku.Checked = Convert.ToBoolean(jj._quanwenruku);
            cb_zhengwenruku.Checked = Convert.ToBoolean(jj._zhengwenruku);
            cb_biaozhunduanruku.Checked = Convert.ToBoolean(jj._biaozhunduanruku);
            cb_biaozhunjuruku.Checked = Convert.ToBoolean(jj._biaozhunjuruku);
            //百分比设置
            panel1.Controls.Clear();
            JJBaifenbiList jjb = JsonConvert.DeserializeObject<JJBaifenbiList>(jj._baifenbishezhi);
            foreach (JJBaifenbi b in jjb.list_baifenbi)
            {
                JJUCbairfenbi myuc = new JJUCbairfenbi(b) { Dock=DockStyle.Top};
                panel1.Controls.Add(myuc);
                //panel1.Controls.SetChildIndex(myuc, 0);
            }
        }

        private void cbb_geshimingcheng_DropDown(object sender, EventArgs e)
        {
            cbb_geshimingcheng.Items.Clear();
            var list = _myc.GetAllGeshiName();
            cbb_geshimingcheng.Items.AddRange(list.ToArray());
        }
    }
}
