using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using RuiTengDll;
using System.IO;

namespace WindowsFormsApp2.UC
{
    public partial class UCTupianChuli : UserControl
    {
        public UCTupianChuli()
        {
            InitializeComponent();
        }
        bool stop = false;
        Controller.ControllerPicture _mycontroller = new Controller.ControllerPicture();
        UIHelper uihelper = new UIHelper();
        private void UCTupianChuli_Load(object sender, EventArgs e)
        {
            //查重日志窗口折叠起来
            splitContainer2.Panel2Collapsed = true;

            //刷新显示所有图片
            RefreshPicPanel();
        }
        /// <summary>
        /// 显示数据库中所有的图片
        /// </summary>
        public void RefreshPicPanel()
        {
            //获得数据库中所有图片
            var picinfos = _mycontroller.GetPic();
            flp_pic.Controls.Clear();
            //对获得的图片构造ucpic并加载到flp中
            UC.UCPicture myuc = null;
            foreach (var picinfo in picinfos)
            {
                myuc = new UCPicture(picinfo) { Dock = DockStyle.Top };
                flp_pic.Controls.Add(myuc);
            }
        }
        private void Pb_add_Click(object sender, EventArgs e)
        {
            //打开选择文件对话框
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in ofd.FileNames)
                {
                    _mycontroller.SavePic(item);
                    //刷新图片区域
                }
                RefreshPicPanel();
            }

        }

        private void Lbl_format_Click(object sender, EventArgs e)
        {
            //获得样式名称
            string format = cbb_format.Text;
            //删除改样式
            _mycontroller.DeleteFormat(format);
            //获得日志路径，相似度，尺寸相同，选中的所有图片名称
            // string rizhipath = tb_rizhilujing.Text;
            string xiangsidu = tb_xiangsidu.Text;
            bool chicun = cb_chicun.Checked;
            List<string> list_select = new List<string>();
            foreach (var control in flp_pic.Controls)
            {
                UCPicture myc = control as UCPicture;
                if (myc._checked)
                {
                    list_select.Add(myc.lbl_name.Text);
                }
            }
            //构造dic
            Dictionary<string, object> dic = new Dictionary<string, object>() {
                {"格式名",format },
                //{"日志路径", rizhipath},
                {"相似度", xiangsidu},
                {"尺寸相同", chicun},
                {"选中图片",string.Join(",",list_select)},
                { "剪切至",tb_jianqie.Text}
            };
            //保存dic
            _mycontroller.SaveFormat(dic);
            //提示保存格式成功
            MessageBox.Show($"格式 {format} 保存成功！");
        }

        private void Pb_rizhi_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "txt文本|*.txt";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    tb_rizhilujing.Text = ofd.FileName;

            //}
        }

        private void Cbb_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mycontroller = new Controller.ControllerPicture();
            //获得格式名
            string format = cbb_format.Text;
            //获得记录
            var dicinfo = _mycontroller.GetForamtInfo(format);
            //选择图片
            List<string> list_pic = Regex.Split(dicinfo["选中图片"].ToString(), ",").ToList();
            foreach (var control in flp_pic.Controls)
            {
                UCPicture myuc = control as UCPicture;
                myuc.pb_xuanze.Image = Properties.Resources.圆圈;
                myuc.BackColor = Color.Silver;
                myuc._checked = false;
                if (list_pic.Contains(myuc.lbl_name.Text))
                {
                    _mycontroller._selectpic.Add(myuc.lbl_name.Text);
                    myuc.Pb_xuanze_Click(null, null);
                    Application.DoEvents();
                }
            }
            //赋值日志路径，相似度，尺寸相同
            //tb_rizhilujing.Text = dicinfo["日志路径"].ToString();
            tb_xiangsidu.Text = dicinfo["相似度"].ToString();
            cb_chicun.Checked = Convert.ToBoolean(dicinfo["尺寸相同"]);
            tb_jianqie.Text = dicinfo["剪切至"].ToString();
        }

        private void Lbl_chakanrizhi_Click(object sender, EventArgs e)
        {
            //DataTable mydt = _mycontroller.GetRizhiDT(tb_rizhilujing.Text);
            ////在dgv_rizhi中显示
            //dgv_rizhi.DataSource = null;
            //dgv_rizhi.DataSource = mydt;


            //bool b = splitContainer2.Panel2Collapsed;

            //splitContainer2.Panel2Collapsed = !b;

        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label11_Click(object sender, EventArgs e)
        {
            //获得样式名称
            string format = cbb_format.Text;
            //删除改样式
            _mycontroller.DeleteFormat(format);
            MessageBox.Show($"格式 {format} 删除成功！");
        }

        private void Label9_Paint(object sender, PaintEventArgs e)
        {
            uihelper.DrawRoundRect((Control)sender);
        }

        private void Label9_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, -1);
        }

        private void Label9_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, 1);

        }

        private void Label7_Click(object sender, EventArgs e)
        {
            _mycontroller._stop = true;
        }
        /// <summary>
        /// 点击全部按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label8_Click(object sender, EventArgs e)
        {
            stop = false;
            //获得设置
            _mycontroller._xiangsidu = tb_xiangsidu.Text;
            _mycontroller._jianqielujing = tb_jianqie.Text;
            _mycontroller._chicun = cb_chicun.Checked;


            Action a = () =>

            {
                //获得所有选中的图片的名称
                _mycontroller._selectpic.Clear();
                foreach (var item in flp_pic.Controls)
                {
                    UCPicture myuc = item as UCPicture;
                    if (myuc._checked)
                    {
                        _mycontroller._selectpic.Add(myuc.lbl_name.Text);

                    }
                }
                string starttime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
                int xiugainum = 0;//存储修改条数
                List<string> list_same = new List<string>();//存储修改文件
                foreach (DataGridViewRow myrow in dgv_task.Rows)
                {
                    if (_mycontroller._stop)
                    {
                        break;
                    }
                    int zongshu = 0;
                    int shanchu = 0;
                    string filename = myrow.Cells["wenjianming"].Value.ToString();
                    _mycontroller.ChuliTupian(filename, ref zongshu, ref shanchu);
                    //显示本条记录的总数和删除数
                    myrow.Cells["zongshu"].Value = zongshu;
                    myrow.Cells["shanchu"].Value = shanchu;

                    if (shanchu > 0)
                    {
                        xiugainum++;
                        list_same.Add(filename);
                    }
                    //准备写入查重日志的内容
                    //StringBuilder mysb = new StringBuilder();
                    //string endtime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
                    //mysb.AppendLine($"{starttime}————{endtime}  {dgv_task.Rows.Count}条  修改{xiugainum}条");
                    //list_same.ForEach((same) => { mysb.AppendLine($"{list_same.IndexOf(same)}.{same}"); });
                    //mysb.AppendLine();
                    //写入查重日志，如果没有的话创建
                    //StreamWriter sw = new StreamWriter(_mycontroller._rizhilujing, true);
                    //sw.WriteLine(mysb);
                    //sw.Flush();
                    //sw.Close();
                }
            };
            //构造字典参数，放入dgv的rowcollection，和
            //异步执行查询，查询结束提示
            a.BeginInvoke((o) =>
            {
                //删除重复率是（重复的）dgvrow
                MessageBox.Show("图片处理完成！");
            }, null);
        }

        private void Lbl_tianjia_Click(object sender, EventArgs e)
        {
            WinForm.WinFromAddTask mywin = new WinForm.WinFromAddTask();
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                dgv_task.Rows.Clear();
                List<string> list_files = mywin.outvalue;
                int id = 0;
                //将list_files形成任务列表中的控件
                for (int i = 0; i < list_files.Count; i++)

                {
                    string item = list_files[i];
                    //判断文件是否是隐藏文件
                    FileInfo myfi = new FileInfo(item);
                    if ((myfi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {

                        //UCTask myuc = new UCTask(item) { Dock = DockStyle.Top };
                        //uihelper.AddControl(panel_task, myuc);
                        //startall += myuc.SearchRepeat;
                        //stopall += myuc.StopResearch;
                        int index = dgv_task.Rows.Add();
                        dgv_task.Rows[index].Cells["wenjianming"].Value = item;
                        dgv_task.Rows[index].Cells["xuhao"].Value = ++id;

                    }

                }
            }
        }

        private void Tb_rizhilujing_TextChanged(object sender, EventArgs e)
        {
        }

        private void Cb_chicun_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Tb_xiangsidu_TextChanged(object sender, EventArgs e)
        {
        }

        private void Lbl_qingkong_Click(object sender, EventArgs e)
        {
            dgv_task.Rows.Clear();
        }

        private void Pb_jianqie_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_jianqie.Text = fbd.SelectedPath;
            }
        }

        private void Tb_jianqie_TextChanged(object sender, EventArgs e)
        {
        }

        private void Pb_rizhi_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.folderenter;
        }

        private void Pb_rizhi_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.folderlv;

        }


        private void cbb_format_DropDown(object sender, EventArgs e)
        {
            var list = _mycontroller._sqlhelper.GetSingleField("格式名", "图片处理表");
            cbb_format.Items.Clear();
           cbb_format.Items.AddRange(list.ToArray());

        }
    }
}
