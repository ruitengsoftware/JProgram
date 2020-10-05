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
using WindowsFormsApp1.Controller;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.UC
{
    delegate void DelSearchAll();

    public partial class UCChachong : UserControl
    {
        UIHelper uihelper = new UIHelper();
        Action startall = new Action(() => { });//由于参数不能为空，那么放一个没有用的代码进去
        //Action stopall = new Action(() => { });
        ControllerChachong mycontroller = new ControllerChachong();
        public UCChachong()
        {
            InitializeComponent();
        }

        private void UCChachong_Load(object sender, EventArgs e)
        {
            //加载所有格式到下拉列表中
            var format = mycontroller.GetFormat();
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
            string[] arr_shtname = mycontroller.GetTableName();
            cbb_biaozhunjubiao.Items.AddRange(arr_shtname);
            cbb_zhengwenbiao.Items.AddRange(arr_shtname);
            cbb_zhengwenchachongbiao.Items.AddRange(arr_shtname);
            cbb_cijuchachongbiao.Items.AddRange(arr_shtname);
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
                //将list_files形成任务列表中的控件
                for (int i = 0; i < list_files.Count; i++)

                {
                    string item = list_files[i];
                    //UCTask myuc = new UCTask(item) { Dock = DockStyle.Top };
                    //uihelper.AddControl(panel_task, myuc);
                    //startall += myuc.SearchRepeat;
                    //stopall += myuc.StopResearch;
                    int index = dgv_task.Rows.Add();
                    dgv_task.Rows[index].Cells["wendangming"].Value = item;
                    dgv_task.Rows[index].Cells["xuhao"].Value = i + 1;

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
            //panel_task.Controls.Clear();
            dgv_task.Rows.Clear();
        }
        /// <summary>
        /// 点击全部开始按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_start_Click(object sender, EventArgs e)
        {
            mycontroller.stop = false;//先给是否停止查询赋值false
            Action<object> a = mycontroller.SearchRepeat;
            //异步执行查询，查询结束提示
            a.BeginInvoke(dgv_task.Rows, (o) => { MessageBox.Show("本次查询已结束！"); }, null);
        }

        private void lbl_stop_Click(object sender, EventArgs e)
        {
            mycontroller.stop = true;
        }

        private void tableLayoutPanel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_path1_TextChanged(object sender, EventArgs e)
        {
            Setting._savepath100 = tb_path1.Text;
        }

        private void tb_path2_TextChanged(object sender, EventArgs e)
        {
            Setting._savepath = tb_path2.Text;
        }

        private void cb_qian_CheckedChanged(object sender, EventArgs e)
        {
            Setting._qian = ((CheckBox)sender).Checked;
        }

        private void cb_hou_CheckedChanged(object sender, EventArgs e)
        {
            Setting._hou = ((CheckBox)sender).Checked;
        }

        private void pb_folder1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_path1.Text = fbd.SelectedPath;
            }
        }

        private void pb_folder2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_path2.Text = fbd.SelectedPath;
            }

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
            //    mycontroller.SaveDocument(dic_task);
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
            mycontroller.DeleteFormat(formatname);
            MessageBox.Show($"格式 {formatname} 已删除成功！");

            var format = mycontroller.GetFormat();
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
            string lujing100 =Regex.Replace( tb_path1.Text,@"\\","\\\\");
            string lujingfei100 = Regex.Replace(tb_path2.Text, @"\\", "\\\\");
            string rizhilujing= Regex.Replace(tb_rizhilujing.Text, @"\\", "\\\\");
            mycontroller.DeleteFormat(formatname);
            string str_sql = $"insert into tablesetting (xuhao,geshimingcheng,xiahuaxian,weizhu,chongfulvqian," +
                $"shanchu100,rizhilujing,lujing100,lujingfei100,zidongdaochu,chongfulvhou,zhengwenchachong,cijuchachong,zhengwenchachongbiao," +
                $"cijuchachongbiao,zhengwenruku,cijuruku,zhengwenrukubiao,cijurukubiao,shijian) values " +
                $"(1,'{formatname}'," +
                $"{(cb_xiahuaxian.Checked ? 1 : 0)}," +
                $"{(cb_weizhu.Checked ? 1 : 0)}," +
                $"{(cb_qian.Checked ? 1 : 0)}," +
                $"{(cb_shanchu100.Checked ? 1 : 0)}," +
                $"'{rizhilujing}'," +
                $"'{lujing100}'," +
                $"'{lujingfei100}'," +
                $"{(cb_daochu.Checked ? 1 : 0)}," +
                $"{(cb_hou.Checked ? 1 : 0)}," +
                $"{(cb_zhengwenchachong.Checked ? 1 : 0)}," +
                $"{(cb_cijuchachong.Checked ? 1 : 0)}," +
                $"'{cbb_zhengwenchachongbiao.Text}'," +
                $"'{cbb_cijuchachongbiao.Text}'," +
                $"{(cb_zhengwenruku.Checked ? 1 : 0)}," +
                $"{(cb_cijuruku.Checked ? 1 : 0)}," +
                $"'{cbb_zhengwenbiao.Text}'," +
                $"'{cbb_biaozhunjubiao.Text}','{DateTime.Now.ToString("yyyy-MM-dd")}')";
            //str_sql = $"insert into tablesetting (xuhao,geshimingcheng,xiahuaxian) values(1,'{formatname}',{(cb_xiahuaxian.Checked ? 1 : 0)})";
            //Dictionary<string, object> dic = new Dictionary<string, object>()
            //{
            //    {"格式名称", formatname},
            //    {"正文查重",cb_zhengwenchachong.Checked },
            //    {"词句查重",cb_cijuchachong.Checked },
            //    {"下划线",cb_xiahuaxian.Checked },
            //    {"尾注", cb_weizhu.Checked},
            //    {"重复率前", cb_qian.Checked},
            //    {"重复率后", cb_hou.Checked},
            //    {"删除100",cb_shanchu100.Checked},
            //    {"路径100",tb_path1.Text },
            //    {"路径非100",tb_path2.Text },
            //    {"自动导出",cb_daochu.Checked },
            //    {"正文查重表", cbb_zhengwenchachongbiao.Text},
            //    {"词句查重表", cbb_cijuchachongbiao.Text},
            //    {"正文入库",cb_zhengwenruku.Checked },
            //    {"词句入库", cb_cijuruku.Checked},
            //    {"正文入库表",cbb_zhengwenbiao.Text },
            //    {"词句入库表", cbb_biaozhunjubiao.Text}
            //};
            mycontroller.SaveFormat(str_sql);
            cbb_geshi.Items.Clear();
            var format = mycontroller.GetFormat();
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
            var dic_setting = mycontroller.GetSetting(str_setting);
            cb_xiahuaxian.Checked = Setting._xiahuaxian = Convert.ToBoolean(dic_setting["下划线"]);
            cb_zhengwenchachong.Checked = Setting._zhengwenchachong = Convert.ToBoolean(dic_setting["正文查重"]);
            cb_cijuchachong.Checked = Setting._cijuchachong = Convert.ToBoolean(dic_setting["词句查重"]);

            cb_weizhu.Checked = Setting._weizhu = Convert.ToBoolean(dic_setting["尾注"]);
            cb_qian.Checked = Setting._qian = Convert.ToBoolean(dic_setting["重复率前"]);
            cb_hou.Checked = Setting._hou = Convert.ToBoolean(dic_setting["重复率后"]);
            cb_shanchu100.Checked = Setting._shanchu100 = Convert.ToBoolean(dic_setting["删除100"]);
            tb_rizhilujing.Text=Setting._rizhilujing= dic_setting["日志路径"].ToString();
            tb_path1.Text = Setting._savepath100 = dic_setting["路径100"].ToString();
            tb_path2.Text = Setting._savepath = dic_setting["路径非100"].ToString();
            cb_daochu.Checked = Setting._daochu = Convert.ToBoolean(dic_setting["自动导出"]);
            cbb_cijuchachongbiao.Text = Setting._cijuchachongbiao = dic_setting["词句查重表"].ToString();
            cbb_zhengwenchachongbiao.Text = Setting._zhengwenchachongbiao = dic_setting["正文查重表"].ToString();
            cb_zhengwenruku.Checked = Setting._zhengwenruku = Convert.ToBoolean(dic_setting["正文入库"]);
            cb_cijuruku.Checked = Setting._cijuruku = Convert.ToBoolean(dic_setting["词句入库"]);
            cbb_zhengwenbiao.Text = Setting._zhengwenrukubiao = dic_setting["正文入库表"].ToString();
            cbb_biaozhunjubiao.Text = Setting._cijurukubiao = dic_setting["词句入库表"].ToString();


            Setting._currentformat = str_setting;


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
            Setting._zhengwenchachong = ((CheckBox)sender).Checked;
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
            string[] arr_shtname = mycontroller.GetTableName();
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
            ((PictureBox)sender).Image = Properties.Resources.wenjianjia;

        }

        private void Lbl_rizhi_Click(object sender, EventArgs e)
        {
            //判断dgv——rizhi的visible
            if (dgv_rizhi.Visible)
            {





                dgv_rizhi.Visible = false;
            }
            else
            {
                dgv_rizhi.Visible = true;
                //获得数据
                DataTable mydt = mycontroller.GetRizhiDT();
                //在dgv_rizhi中显示
                dgv_rizhi.DataSource = null;
                dgv_rizhi.DataSource = mydt;
            }


        }

        private void Tb_rizhilujing_TextChanged(object sender, EventArgs e)
        {
            Setting._rizhilujing = tb_rizhilujing.Text;
        }
    }
}
