using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuiTengDll;
using Common;
using BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using WindowsFormsApp1.Controller;
using WindowsFormsApp1.Common;
using Common.WinForm;
using System.Threading;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1.UC
{
    delegate void DelSearchAll();
    public partial class UCChachong : UserControl
    {
        UIHelper uihelper = new UIHelper();
        //由于参数不能为空，那么放一个没有用的代码进去
        DelSearchAll _startall = new DelSearchAll(() => { });

        Action _stopall = new Action(() => { });
        ControllerChachong _mycontroller = new ControllerChachong();
        ControllerClickhouse chhelper = new ControllerClickhouse();
        public UCChachong()
        {
            InitializeComponent();
        }

        private void UCChachong_Load(object sender, EventArgs e)
        {
            //加载所有格式到下拉列表中
            var format = _mycontroller.GetFormat();
            cbb_geshi.Items.AddRange(format);
            try
            {
                //判断setting._currentformat是否有值
                if (Setting._currentformat.Equals(string.Empty))
                {
                    cbb_geshi.SelectedIndex = 0;

                }
                else
                {
                    cbb_geshi.Text = Setting._currentformat;
                }

            }
            catch { }
            //加载所有数据库名到zhengwenbiao和biaozhunjubiao
            string[] arr_shtname = _mycontroller.GetTableName();
            cbb_zhengwenbiao.Items.AddRange(arr_shtname);
            cbb_zhengwenchachongbiao.Items.AddRange(arr_shtname);
            //隐藏查重日志dgv_rizhi

            splitContainer2.Panel2Collapsed = true;


        }
        /// <summary>
        /// 点击添加任务按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_addtask_Click(object sender, EventArgs e)
        {
            /*弹出选择任务窗体，根据选择的结果再任务panel中显示所有任务*/
            WinForm.WinFromAddTask mywinform = new WinForm.WinFromAddTask();
            if (mywinform.ShowDialog() == DialogResult.OK)
            {
                dgv_task.Rows.Clear();
                List<string> list_files = mywinform.outvalue;
                UCTask myuc = null;
                //将list_files形成任务列表中的控件
                for (int i = 0; i < list_files.Count; i++)
                {
                    string item = list_files[i];
                    myuc = new UCTask(item) { Dock = DockStyle.Top };
                    uihelper.AddControl(panel_task, myuc);
                    _startall += myuc.ZhengwenChachong;
                    _stopall += myuc.StopResearch;


                    //int index = dgv_task.Rows.Add();
                    //dgv_task.Rows[index].Cells["wendangming"].Value = item;
                    //dgv_task.Rows[index].Cells["xuhao"].Value = i + 1;
                }
            }
        }




        /// <summary>
        /// 点击清楚任务按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_clear_Click(object sender, EventArgs e)
        {
            /*清空任务列表中的所有任务*/
            panel_task.Controls.Clear();
            //dgv_task.Rows.Clear();
        }
        /// <summary>
        /// 点击全部开始按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_start_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            //watch.Start();//开始计时
            ////_mycontroller.stop = false;//先给是否停止查询赋值false
            //Action<object> a = _mycontroller.SearchRepeat;
            ////构造字典参数，放入dgv的rowcollection，和
            ////异步执行查询，查询结束提示
            //this.BeginInvoke(_startall);

            //获得panel_task中的所有task控件，模拟点击开始按钮
            foreach (UCTask item in panel_task.Controls)
            {

                Action<object, EventArgs> a = item.PictureBox2_Click;
                this.BeginInvoke(a,null,null);




                //Thread myt = new Thread(item.PictureBox2_Click());
                //myt.Start(null, null);

            }




        }


        public void DeleteRow(DataGridViewRow row)
        {
            if (this.InvokeRequired)
            {
                Action<DataGridViewRow> a = DeleteRow;
                this.BeginInvoke(a, row);
            }
            else
            {
                dgv_task.Rows.Remove(row);
            }


        }


        private void lbl_stop_Click(object sender, EventArgs e)
        {
            Action a = null;
            foreach (UCTask item in panel_task.Controls)
            {
                a = item.StopResearch;
                this.BeginInvoke(a);


            }

        }

        private void tableLayoutPanel17_Paint(object sender, PaintEventArgs e)
        {

        }



        private void cb_qian_CheckedChanged(object sender, EventArgs e)
        {
            Setting._qian = ((CheckBox)sender).Checked;
        }

        private void cb_hou_CheckedChanged(object sender, EventArgs e)
        {
            Setting._hou = ((CheckBox)sender).Checked;
        }



        /// <summary>
        /// 点击保存文档按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_save_Click(object sender, EventArgs e)
        {
            //foreach (Control item in panel_task.Controls)
            //{
            //    UCTask myuc = item as UCTask;
            //    Dictionary<string, object> dic_task = new Dictionary<string, object>() {
            //        {"filename", myuc.lbl_filename.Text },
            //        {"chongfulv",myuc.lbl_chongfulv.Text }
            //    };
            //    _mycontroller.SaveDocument(dic_task);
            //}
        }

        private void lbl_save_Paint(object sender, PaintEventArgs e)
        {
            uihelper.DrawRoundRect((Control)sender);
        }

        private void lbl_save_MouseEnter(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, new Padding(m - 1));

        }

        private void lbl_save_MouseLeave(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            uihelper.UpdateCSize((Control)sender, new Padding(m + 1));

        }

        private void cb_xiahuaxian_CheckedChanged(object sender, EventArgs e)
        {
            Setting._xiahuaxian = ((CheckBox)sender).Checked;
        }

        private void cb_ruku_CheckedChanged(object sender, EventArgs e)
        {
            Setting._zhengwenruku = ((CheckBox)sender).Checked;

        }

        private void cb_weizhu_CheckedChanged(object sender, EventArgs e)
        {
            Setting._weizhu = ((CheckBox)sender).Checked;
        }

        private void Cb_ruku2_CheckedChanged(object sender, EventArgs e)
        {
            Setting._cijuruku = ((CheckBox)sender).Checked;

        }

        private void Cb_daochu_CheckedChanged(object sender, EventArgs e)
        {
            Setting._daochu = ((CheckBox)sender).Checked;
        }
        /// <summary>
        /// 点击删除格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_shanchu_Click(object sender, EventArgs e)
        {
            string formatname = cbb_geshi.Text;
            _mycontroller.DeleteFormat(formatname, "zhengwensetting");
            MessageBox.Show($"格式 {formatname} 已删除成功！");

            var format = _mycontroller.GetFormat();
            cbb_geshi.Items.Clear();
            cbb_geshi.Items.AddRange(format);
            try
            {
                cbb_geshi.SelectedIndex = 0;

            }
            catch
            {
                cbb_geshi.Text = string.Empty;
            }

        }
        /// <summary>
        /// 点击保存格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_baocun_Click(object sender, EventArgs e)
        {
            string formatname = cbb_geshi.Text;
            //string lujing100 = Regex.Replace(tb_path1.Text, @"\\", "\\\\");
            //string lujingfei100 = Regex.Replace(tb_path2.Text, @"\\", "\\\\");
            string rizhilujing = Regex.Replace(tb_rizhilujing.Text, @"\\", "\\\\");
            _mycontroller.DeleteFormat(formatname, "zhengwensetting");
            List<string> list_db = new List<string>();
            foreach (UCDatabase item in Setting.list_ucdb)
            {
                list_db.Add(item.lbl_dbname.Text);
            }
            string str_sql = $"insert into zhengwensetting (xuhao,geshimingcheng,zhengwenchachong,shanchu100,zhengwenchachongbiao," +
                $"zhengwenruku,zhengwenrukubiao,rizhilujing,shujukushai,riqi) values " +
                $"(1,'{formatname}'," +
                $"{(cb_leijiredu.Checked ? 1 : 0)}," +
                $"{(cb_shanchu100.Checked ? 1 : 0)}," +
                $"'{cbb_zhengwenchachongbiao.Text}'," +
                $"{(cb_zhengwenruku.Checked ? 1 : 0)}," +
                $"'{cbb_zhengwenbiao.Text}'," +
                $"'{rizhilujing}'," +
                $"'{string.Join(",", list_db)}'," +
                $"'{DateTime.Now.ToString("yyyy-MM-dd")}')";
            //Dictionary<string, object> dic = new Dictionary<string, object>()
            //{
            //    {"格式名称", formatname},
            //    {"正文查重",cb_zhengwenchachong.Checked },
            //    {"删除100",cb_shanchu100.Checked},
            //    {"正文查重表", cbb_zhengwenchachongbiao.Text},
            //    {"正文入库",cb_zhengwenruku.Checked },
            //    {"正文入库表",cbb_zhengwenbiao.Text },
            //    { "日志路径",tb_rizhilujing.Text},
            //    {"数据库筛",string.Join(",",list_db )}
            //};
            //_mycontroller.SaveFormat(dic);
            chhelper.DoSQL(str_sql);
            cbb_geshi.Items.Clear();

            var format = _mycontroller.GetFormat();
            cbb_geshi.Items.AddRange(format);
            MessageBox.Show($"格式 {formatname} 已保存成功！");
        }
        /// <summary>
        /// 下拉框选项发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbb_geshi_SelectedIndexChanged(object sender, EventArgs e)
        {

            string str_setting = cbb_geshi.Text;
            var dic_setting = _mycontroller.GetSetting(str_setting);
            cb_leijiredu.Checked = Setting._zhengwenchachong = Convert.ToBoolean(dic_setting["正文查重"]);
            cb_shanchu100.Checked = Setting._shanchu100 = Convert.ToBoolean(dic_setting["删除100"]);
            cbb_zhengwenchachongbiao.Text = Setting._zhengwenchachongbiao = dic_setting["正文查重表"].ToString();
            cb_zhengwenruku.Checked = Setting._zhengwenruku = Convert.ToBoolean(dic_setting["正文入库"]);
            cbb_zhengwenbiao.Text = Setting._zhengwenrukubiao = dic_setting["正文入库表"].ToString();
            tb_rizhilujing.Text = Setting._rizhilujing = dic_setting["日志路径"].ToString();
            Setting._currentformat = str_setting;
            //添加数据库ucdatabase
            string str_shujukushai = dic_setting["数据库筛"].ToString();
            Setting.list_ucdb.Clear();
            flp_db.Controls.Clear();
            if (str_shujukushai.Trim().Equals(string.Empty))
            {
                return;
            }
            List<string> list_db = str_shujukushai.Split(new char[] { ',' }).ToList();
            //循环实例化UC
            foreach (string item in list_db)
            {
                var myuc = new UCDatabase(item) { Dock = DockStyle.Top };
                uihelper.AddControl(flp_db, myuc);

            }
        }

        private void Cbb_zhengwenbiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting._zhengwenrukubiao = ((Control)sender).Text;
        }

        private void Cbb_biaozhunjubiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting._cijurukubiao = ((Control)sender).Text;
        }

        private void Cb_zhengwenchachong_CheckedChanged(object sender, EventArgs e)
        {
            Setting._leijiredu = ((CheckBox)sender).Checked;
        }

        private void Cb_cijuchachong_CheckedChanged(object sender, EventArgs e)
        {
            Setting._cijuchachong = ((CheckBox)sender).Checked;
        }

        private void Cbb_zhengwenchachongbiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting._zhengwenchachongbiao = ((Control)sender).Text;

        }

        private void Cbb_cijuchachongbiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting._cijuchachongbiao = ((Control)sender).Text;

        }

        private void Cbb_zhengwenbiao_DropDown(object sender, EventArgs e)
        {
            //加载所有数据库名到zhengwenbiao和biaozhunjubiao
            string[] arr_shtname = _mycontroller.GetTableName();
            ((System.Windows.Forms.ComboBox)sender).Items.Clear();
            ((System.Windows.Forms.ComboBox)sender).Items.AddRange(arr_shtname);

        }

        private void Pb_rizhi_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tb_rizhilujing.Text = ofd.FileName;

            }
        }

        private void Pb_rizhi_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.wenjianjia1;
        }

        private void Pb_rizhi_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.wenjianjia2;

        }
        /// <summary>
        /// 点击查重日志按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_rizhi_Click(object sender, EventArgs e)
        {
            DataTable mydt = _mycontroller.GetRizhiDT();
            //在dgv_rizhi中显示
            dgv_rizhi.DataSource = null;
            dgv_rizhi.DataSource = mydt;
            //判断dgv——rizhi的visible
            if (splitContainer2.Panel2Collapsed == true)
            {
                splitContainer2.Panel2Collapsed = false;
            }
            else
            {
                splitContainer2.Panel2Collapsed = true;
                //dgv_rizhi.Visible = true;
                //获得数据
            }
        }

        private void Tb_rizhilujing_TextChanged(object sender, EventArgs e)
        {
            Setting._rizhilujing = tb_rizhilujing.Text;
        }

        private void Cb_shanchu100_CheckedChanged(object sender, EventArgs e)
        {
            Setting._shanchu100 = ((CheckBox)sender).Checked;
        }

        private void Pb_adddb_Click(object sender, EventArgs e)
        {
            //获得数据库名
            string dbname = cbb_zhengwenchachongbiao.Text;
            //实例化一个ucdatabase，传进数据库名
            UCDatabase myuc = new UCDatabase(dbname) { Dock = DockStyle.Top };
            //把ucdatabase添加到flpdb
            uihelper.AddControl(flp_db, myuc);

        }

        private void Pb_adddb_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.xiangxiaB;
        }

        private void Pb_adddb_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.xiangxiaA;

        }

        private void Flp_db_ControlAdded(object sender, ControlEventArgs e)
        {
            Setting.list_ucdb.Clear();
            //获得数据库筛中的控件
            foreach (UserControl ucdb in flp_db.Controls)
            {
                Setting.list_ucdb.Add(ucdb);
            }

        }

        private void Flp_db_ControlRemoved(object sender, ControlEventArgs e)
        {
            Setting.list_ucdb.Clear();
            //获得数据库筛中的控件
            foreach (UserControl ucdb in flp_db.Controls)
            {
                Setting.list_ucdb.Add(ucdb);
            }

        }
    }
}
