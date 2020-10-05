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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Model;
using Aspose.Words;
using Aspose.Words.Replacing;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Cells;
using WindowsFormsApp2.Controller;

namespace WindowsFormsApp2.UC  
{
    delegate void DelSearchAll();

    public partial class UCNeirongchuli : UserControl
    {
        bool _stopchuli = false;
        UIHelper uihelper = new UIHelper();
        Action startall = new Action(() => { });//由于参数不能为空，那么放一个没有用的代码进去
        //Action stopall = new Action(() => { });
       ControllerNeirongchuli mycontroller = new ControllerNeirongchuli();
        public UCNeirongchuli()
        {
            InitializeComponent();
        }

        private void UCChachong_Load(object sender, EventArgs e)
        {
            //var format = mycontroller.GetFormat();
            //cbb_geshi.Items.AddRange(format);
            //cbb_geshi.SelectedIndex = 0;
            //加载所有格式到下拉列表中
            //var format = mycontroller.GetFormat();
            //cbb_geshi.Items.AddRange(format);
            //try
            //{
            //    //判断setting._currentformat是否有值
            //    if (Setting._currentformat.Equals(string.Empty))
            //    {
            //    cbb_geshi.SelectedIndex = 0;

            //    }
            //    else
            //    {
            //        cbb_geshi.Text = Setting._currentformat;
            //    }

            //}
            //catch { }
            ////加载所有数据库名到zhengwenbiao和biaozhunjubiao
            //string[] arr_shtname = mycontroller.GetTableName();
            ////隐藏查重日志dgv_rizhi

            //splitContainer2.Panel2Collapsed = true;


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
            _stopchuli = false;//刷新是否停止处理的判断
            Action a = ChuliWords;
            //构造字典参数，放入dgv的rowcollection，和
            //异步执行查询，查询结束提示
            a.BeginInvoke((o) =>
            {
                //删除重复率是（重复的）dgvrow
                MessageBox.Show("内容处理完成！");
            }, null);
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
            _stopchuli = true;
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
        }
        /// <summary>
        /// 点击保存格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_baocun_Click(object sender, EventArgs e)
        {
            string formatname = cbb_geshi.Text;
            mycontroller.DeleteFormat(formatname);
            //形成模板信息
            MubanInfo mubaninfo = new MubanInfo();
            mubaninfo._mubanname = formatname;
            List<string> list_buzhou = new List<string>();
            for (int i = 0; i < Setting.list_guize.Count; i++)
            {
                var myrow = dgv_guize.Rows[i];
                mubaninfo.list_buzhou.Add(Setting.list_guize[i]);
            }
            string json = JsonConvert.SerializeObject(mubaninfo);
            Dictionary<string, object> dic_muban = new Dictionary<string, object>() {
                {"模板名称",formatname },
                {"模板信息",json},
                //{ "日志路径",tb_rizhilujing.Text},
                {"正文",cb_zhengwen.Checked },
                {"文件名", cb_wenjianming.Checked }
            };
            mycontroller.SaveFormat(dic_muban);
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
            var dic_setting = mycontroller.GetMuBan(str_setting);
            Dictionary<string, object> dic = dic_setting as Dictionary<string, object>;
            //获得日志路径，赋值到tb_rizhilujing
            string rizhilujing = dic["日志路径"].ToString();
            //tb_rizhilujing.Text = rizhilujing;
            //cb_wenjianming赋值
            cb_wenjianming.Checked = Convert.ToBoolean(dic["文件名"]);
            //cb_zhengwen赋值
            cb_zhengwen.Checked = Convert.ToBoolean(dic["正文"]);
            //获得模板信息
            string mubanjson = dic["模板信息"].ToString();

            //转化为模板类
            MubanInfo mymubaninfo = JsonConvert.DeserializeObject<MubanInfo>(mubanjson);
            //得到模板信息
            Setting.list_guize = mymubaninfo.list_buzhou;
            //刷新规则列表
            UpdateDgvGuize();





            //tb_rizhilujing.Text = Setting._rizhilujing = dic_setting["日志路径"].ToString();
            //Setting._currentformat = str_setting;
            ////添加数据库ucdatabase
            //string str_shujukushai = dic_setting["数据库筛"].ToString();
            //Setting.list_ucdb.Clear();

            //if (str_shujukushai.Trim().Equals(string.Empty))
            //{
            //    return;
            //}
            //List<string> list_db = str_shujukushai.Split(new char[] { ',' }).ToList();
            ////虚幻实例化UC
            //foreach (string item in list_db)
            //{
            //    var myuc = new Common.WinForm.UCDatabase(item);
            //}
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
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    tb_rizhilujing.Text = ofd.FileName;

            //}
        }

        private void Pb_rizhi_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.wenjianjia1;
        }

        private void Pb_rizhi_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.wenjianjia;

        }
        /// <summary>
        /// 点击查重日志按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_rizhi_Click(object sender, EventArgs e)
        {
            DataTable mydt = mycontroller.GetRizhiDT();
            //在dgv_rizhi中显示
            dgv_rizhi.DataSource = null;
            dgv_rizhi.DataSource = mydt;
            //判断dgv——rizhi的visible
            bool b = splitContainer2.Panel2Collapsed;
            splitContainer2.Panel2Collapsed = !b;
        }

        private void Tb_rizhilujing_TextChanged(object sender, EventArgs e)
        {
            //Setting._rizhilujing = tb_rizhilujing.Text;
        }

        private void Cb_shanchu100_CheckedChanged(object sender, EventArgs e)
        {
            Setting._shanchu100 = ((CheckBox)sender).Checked;
        }

        private void Pb_adddb_Click(object sender, EventArgs e)
        {
            //获得数据库名
            //实例化一个ucdatabase，传进数据库名
            //把ucdatabase添加到flpdb
        }

        private void Pb_adddb_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.xiangxiaB;
        }

        private void Pb_adddb_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.xiangxiaA;

        }


        private void Pb_chuli_MouseClick(object sender, MouseEventArgs e)
        {
            cms_chuli.Show(MousePosition.X, MousePosition.Y);
        }
        /// <summary>
        /// 点击整体提取按钮时触发得事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 正则提取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //构造一个步骤info，显示在界面中
            BuzhouInfo mybuzhou = new BuzhouInfo(((ToolStripMenuItem)sender).Text);
            mybuzhou._selfname = tb_guizemingcheng.Text;
            mybuzhou._updatedate = DateTime.Now.ToString("yyyy-MM-dd");
            if (mybuzhou._name.Contains("替换"))
            {
                mybuzhou._zhengze = "正则表达式……";
                mybuzhou._tihuan = "替换为……";
            }
            else if (mybuzhou._name.Contains("添加"))
            {
                mybuzhou._text = "请输入……";
            }
            else if (mybuzhou._name.Contains("清除换行符"))
            {
                mybuzhou._text = "清除换行符……";

            }


            //形成一个datatable，绑定到dgvguize中
            DataTable mydt0 = dgv_guize.DataSource as DataTable;
            //mydt0.Columns.Remove("选择");
            mydt0.Rows.Add(new string[] { (mydt0.Rows.Count + 1).ToString(), mybuzhou._selfname, mybuzhou._name, mybuzhou._updatedate, mybuzhou._zhengze, mybuzhou._tihuan, mybuzhou._text, });
            dgv_guize.DataSource = null;
            dgv_guize.DataSource = mydt0;
            Application.DoEvents();
            GetGuize();


            //显示详情控件
            Control control_xiangqing = null;
            if (mybuzhou._name.Contains("替换"))
            {
                control_xiangqing = new UCBuzhou(mybuzhou._zhengze, mybuzhou._tihuan) { Dock = DockStyle.Fill };
                (control_xiangqing as UCBuzhou).tb_zhengze.TextChanged += Tb_zhengze_TextChanged;
                (control_xiangqing as UCBuzhou).tb_tihuan.TextChanged += Tb_tihuan_TextChanged;
                (control_xiangqing as UCBuzhou).tb_zhengze.Leave += UCchuli_Leave;
                (control_xiangqing as UCBuzhou).tb_tihuan.Leave += UCchuli_Leave;

            }
            else if (mybuzhou._name.Contains("缀") || mybuzhou._name.Contains("清除"))
            {
                control_xiangqing = new System.Windows.Forms.TextBox() { Dock = DockStyle.Fill, Text = mybuzhou._text, Multiline = true };
                control_xiangqing.TextChanged += UCchuli_TextChanged;
                control_xiangqing.Leave += UCchuli_Leave;
            }
            //添加步骤详情
            panel_xiangqing.Controls.Clear();
            panel_xiangqing.Controls.Add(control_xiangqing);
            Application.DoEvents();
            //UpdateDgvGuize();
            //选中新添加的最后一行
            dgv_guize.ClearSelection();
            Application.DoEvents();
            dgv_guize.CurrentCell = dgv_guize.Rows[mydt0.Rows.Count - 1].Cells[0];
            Application.DoEvents();
            //显示最后一条的步骤详情


            //清空处理前，处理后
            tb_chuliqian.Clear();
            tb_chulihou.Clear();



            //实例化一个UC处理
            //string buzhouleixing = ((ToolStripMenuItem)sender).Text;

            //UC.UCchuli myuc = new UCchuli(buzhouleixing, tb_guizemingcheng.Text)
            //{
            //    Dock = DockStyle.Top,
            //};
            //myuc.lbl_buzhou.Click += DisplayXiangqing;
            //myuc.update_buzhou += GetBuzhou;
            //myuc.update_shili += ChuLiShili;
            ////myuc.tableLayoutPanel1.BackColor = Color.SteelBlue;

            //panel_chuli.Controls.Add(myuc);
            //panel_chuli.Controls.SetChildIndex(myuc, 0);
            ////当前uclbl高亮
            //foreach (UCchuli uc in Setting.list_ucchuli)
            //{
            //    uc.lbl_buzhou.BackColor = Color.LightGray;
            //    uc.lbl_buzhou.ForeColor = Color.Black;

            //}
            ////高两
            //myuc.lbl_buzhou.BackColor = Color.SteelBlue;
            //myuc.lbl_buzhou.ForeColor = Color.White;

            //更新步骤列表setting
            //GetBuzhou();
        }

        private void UCchuli_Leave(object sender, EventArgs e)
        {
            ChuLiShili();
            //UpdateDgvGuize();

        }

        private void UCchuli_TextChanged(object sender, EventArgs e)
        {
            int selectindex = dgv_guize.CurrentRow.Index;
            dgv_guize.Rows[selectindex].Cells["文本"].Value = ((Control)sender).Text;

            Setting.list_guize[selectindex]._text = ((Control)sender).Text;
        }
        private void Tb_tihuan_TextChanged(object sender, EventArgs e)
        {
            int selectindex = dgv_guize.CurrentRow.Index;
            dgv_guize.Rows[selectindex].Cells["替换为"].Value = ((Control)sender).Text;

            Setting.list_guize[selectindex]._tihuan = ((Control)sender).Text;
        }
        private void Tb_tihuan_Leave(object sender, EventArgs e)
        {
           // UpdateDgvGuize();
        }

        private void Tb_zhengze_TextChanged(object sender, EventArgs e)
        {
            int selectindex = dgv_guize.CurrentRow.Index;
            dgv_guize.Rows[selectindex].Cells["正则表达式"].Value= ((Control)sender).Text;
            Setting.list_guize[selectindex]._zhengze = ((Control)sender).Text;
        }
        private void Tb_zhengze_Leave(object sender, EventArgs e)
        {
            //
        }




        ControllerChuli controller_chuli = new ControllerChuli();
        /// <summary>
        /// 根据指定的规则，处理示例文本
        /// </summary>
        /// <param name="yuanwenben"></param>
        /// <returns></returns>
        public void ChuLiShili()
        {
            string yuanwenben = tb_chuliqian.Text;
            foreach (BuzhouInfo myguize in Setting.list_guize)
            {
                //判断name
                if (myguize._name.Contains("替换"))
                {
                    yuanwenben = controller_chuli.ZhengzeChuli(yuanwenben, myguize._zhengze, myguize._tihuan);
                }
                else if (myguize._name.Contains("添加前缀"))
                {
                    yuanwenben = controller_chuli.TianjiaQianzhui(yuanwenben, myguize._text);
                }
                else if (myguize._name.Contains("添加后缀"))
                {
                    yuanwenben = controller_chuli.TianjiaHouzhui(yuanwenben, myguize._text);
                }
                else if (myguize._name.Contains("清除"))
                {
                    yuanwenben = controller_chuli.QingkongHuanhang(yuanwenben);

                }

            }
            tb_chulihou.Text = yuanwenben;
        }

        /// <summary>
        /// 对文件名进行处理
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool ChuliWenJianMing(string filename0)
        {
            GetGuize();
            string directory = Path.GetDirectoryName(filename0);
            string extension = Path.GetExtension(filename0);
            string filename = Path.GetFileNameWithoutExtension(filename0);
            bool xiugai = false;//存放文档是否发生了修改
            //处理文本
            foreach (BuzhouInfo myinfo in Setting.list_guize)
            {
                //判断name
                if (myinfo._name.Contains("替换"))
                {
                    FindReplaceOptions opt = new FindReplaceOptions(FindReplaceDirection.Forward);
                    //判断正则表达式是否包含& 如果是，先替换&为空，然后再将后面替换为指定字符
                    if (myinfo._zhengze.Contains("&"))
                    {
                        string hou = myinfo._zhengze.Substring(1);
                        filename = Regex.Replace(filename, hou, myinfo._tihuan);
                        filename = Regex.Replace(filename, "&", "");
                    }
                    else
                    {
                        filename = Regex.Replace(filename, myinfo._zhengze, myinfo._tihuan);
                    }

                }
                else if (myinfo._name.Contains("添加前缀"))
                {
                    filename = myinfo._text + filename;
                }
                else if (myinfo._name.Contains("添加后缀"))
                {
                    filename = filename + myinfo._text;
                }
                //else if (ucchuli.myinfo._name.Contains("清除"))
                //{
                //    foreach (Section sec in myword.Sections)
                //    {
                //        foreach (Paragraph para in sec.Body.Paragraphs)
                //        {
                //            if (para.Range.Text.Trim().Equals(string.Empty))
                //            {
                //                sec.Body.Paragraphs.Remove(para);
                //            }
                //        }
                //    }
                //}
            }

            //组成修改后的文件
            string finalfilename = directory + @"\" + filename + extension;
            if (!finalfilename.Equals(filename0))
            {
                xiugai = true;
            }

            //修改文件名
            File.Move(filename0, finalfilename);
            return xiugai;

        }
        /// <summary>
        /// 处理excel文件的内容替换
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool ChuliExcel(string filename)
        {
            Workbook mywbk = new Workbook(filename);
            Worksheet mysht = mywbk.Worksheets[0];
            bool xiugai = false;
            foreach (Cell mycell in mysht.Cells)
            {
                //获得单元格文本
                string startvalue = mycell.StringValue;
                //处理该单元格内的文本
                for (int i = 0; i < Setting.list_guize.Count; i++)
                {

                    var buzhou = Setting.list_guize[i];


                    //判断name
                    if (buzhou._name.Contains("替换"))
                    {
                        //判断正则表达式是否包含& 如果是，先替换&为空，然后再将后面替换为指定字符
                        if (buzhou._zhengze.Contains("&"))
                        {
                            string hou = buzhou._zhengze.Substring(1);
                            mysht.Replace(hou, buzhou._tihuan);
                            mysht.Replace("&", "");
                        }
                        else
                        {
                            mysht.Replace(buzhou._zhengze, buzhou._tihuan);
                        }

                    }
                    //else if (ucchuli.myinfo._name.Contains("添加前缀"))
                    //{
                    //    yuanwenben = controller_chuli.TianjiaQianzhui(yuanwenben, ucchuli.myinfo._text);
                    //}
                    //else if (ucchuli.myinfo._name.Contains("添加后缀"))
                    //{
                    //    yuanwenben = controller_chuli.TianjiaHouzhui(yuanwenben, ucchuli.myinfo._text);
                    //}
                    //else if (ucchuli.myinfo._name.Contains("清除"))
                    //{
                    //    foreach (Section sec in myword.Sections)
                    //    {
                    //        foreach (Paragraph para in sec.Body.Paragraphs)
                    //        {
                    //            if (para.Range.Text.Trim().Equals(string.Empty))
                    //            {
                    //                sec.Body.Paragraphs.Remove(para);
                    //            }
                    //        }
                    //    }
                    //}
                }
                string endvalue = mycell.StringValue;
                //判断单元格的值是否发生了变化
                if (!endvalue.Equals(startvalue))
                {
                    xiugai = true;
                }
            }
            //保存word文档
            mywbk.Save(filename);
            return xiugai;
        }


        /// <summary>
        /// 处理word文档，并返回是否修经过处理true/false
        /// </summary>
        /// <param name="filename">文档全名</param>
        /// <returns></returns>
        public bool ChuliWord(string filename)
        {
            //打开word文件
            Aspose.Words.Document myword = new Aspose.Words.Document(filename);
            DocumentBuilder mybuilder = new DocumentBuilder(myword);
            //获得全部文本
            string content0 = myword.Range.Text;
            bool xiugai = false;//存放文档是否发生了修改
            //处理文本

            for (int i = 0; i < Setting.list_guize.Count; i++)
            {
                var buzhou = Setting.list_guize[i];
                //判断name
                if (buzhou._name.Contains("替换"))
                {
                    FindReplaceOptions opt = new FindReplaceOptions(FindReplaceDirection.Forward);
                    //判断正则表达式是否包含& 如果是，先替换&为空，然后再将后面替换为指定字符
                    if (buzhou._zhengze.Contains("&"))
                    {
                        string hou = buzhou._zhengze.Substring(1);
                        myword.Range.Replace(hou, buzhou._tihuan, opt);
                        myword.Range.Replace("&", "", opt);
                    }
                    else
                    {
                        myword.Range.Replace(buzhou._zhengze, buzhou._tihuan, opt);
                    }

                }
                //else if (ucchuli.myinfo._name.Contains("添加前缀"))
                //{
                //    yuanwenben = controller_chuli.TianjiaQianzhui(yuanwenben, ucchuli.myinfo._text);
                //}
                //else if (ucchuli.myinfo._name.Contains("添加后缀"))
                //{
                //    yuanwenben = controller_chuli.TianjiaHouzhui(yuanwenben, ucchuli.myinfo._text);
                //}
                else if (buzhou._name.Contains("清除"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            if (para.Range.Text.Trim().Equals(string.Empty))
                            {
                                sec.Body.Paragraphs.Remove(para);
                            }
                        }
                    }
                }
            }
            string content1 = myword.Range.Text;
            if (!content0.Equals(content1))
            {
                xiugai = true;
            }
            //保存word文档
            myword.Save(filename);
            return xiugai;
        }
        /// <summary>
        /// 处理所有word任务
        /// </summary>
        public void ChuliWords()
        {
            string starttime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
            int chongfunum = 0;//存储重复条数

            List<string> list_same = new List<string>();//存储重复文件

            foreach (DataGridViewRow dgvrow in dgv_task.Rows)
            {
                //判断用户是否手动停止了搜索
                if (_stopchuli)
                {
                    break;
                }
                string filename = dgvrow.Cells[1].Value.ToString();
                //判断用户是否选择了对正文处理或者对文件名处理
                bool xiugaizhengwen = false;

                if (Setting._zhengwen)
                {
                    //判断后缀是否为excel文件格式
                    string houzhui = Path.GetExtension(filename);
                    if (houzhui.Contains(".xls"))//处理excel文件
                    {
                        xiugaizhengwen = ChuliExcel(filename);
                    }
                    else//处理word文件
                    {
                        xiugaizhengwen = ChuliWord(filename);
                    }
                }
                bool xiugaiwenjianming = false;
                if (Setting._wenjianming)
                {
                    xiugaiwenjianming = ChuliWenJianMing(filename);
                }
                dgvrow.Cells[2].Value = "100%";
                if (xiugaizhengwen || xiugaiwenjianming)
                {
                    dgvrow.Cells[3].Value = "修改";
                    chongfunum++;
                }
                else
                {
                    dgvrow.Cells[3].Value = "无";

                }
            }
            //写入查重日志
            StringBuilder mysb = new StringBuilder();
            string endtime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
            mysb.AppendLine($"{starttime}————{endtime}  {dgv_task.Rows.Count}条  修改{chongfunum}条");
            list_same.ForEach((same) => { mysb.AppendLine($"{list_same.IndexOf(same)}.{same}"); });
            mysb.AppendLine();

            //获得查重日志，如果没有的话创建
            StreamWriter sw = new StreamWriter(Setting._rizhilujing, true);
            sw.WriteLine(mysb);
            sw.Flush();
            sw.Close();




        }



        /// <summary>
        /// 显示步骤对应的详情控件
        /// </summary>
        public void DisplayXiangqing(object sender, EventArgs e)
        {
            foreach (UCchuli item in Setting.list_ucchuli)
            {
                item.lbl_buzhou.BackColor = Color.White;
                item.lbl_buzhou.ForeColor = Color.Black;
            }
            UCchuli myuc = ((Control)sender).Parent.Parent as UCchuli;
            myuc.lbl_buzhou.BackColor = Color.SteelBlue;
            myuc.lbl_buzhou.ForeColor = Color.White;
            panel_xiangqing.Controls.Clear();
            panel_xiangqing.Controls.Add(myuc.control_xiangqing);

            //判断点击的步骤名称，改变group的组名
            string str = myuc.lbl_buzhou.Text;
            if (str.Equals("正则替换"))
            {
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Text = "步骤详情";
                ucchachong.groupBox5.Text = "处理前";
            }
            else if (str.Equals("文本替换"))
            {
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Text = "步骤详情";
                ucchachong.groupBox5.Text = "处理前";

            }
            else if (str.Equals("添加前缀"))
            {
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Text = "前缀内容";
                ucchachong.groupBox5.Text = "需要匹配的内容";

            }
            else if (str.Equals("添加后缀"))
            {
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Text = "后缀内容";
                ucchachong.groupBox5.Text = "需要匹配的内容";

            }
            else if (str.Equals("清除换行符"))
            {
                UCNeirongchuli ucchachong = Setting._ucneirongchuli as UCNeirongchuli;
                ucchachong.groupBox2.Text = "步骤详情";
                ucchachong.groupBox5.Text = "处理前";

            }




        }



        /// <summary>
        /// 获得当前所有步骤信息集合，保存在common得setting中
        /// </summary>
        /// <returns></returns>
        public void GetBuzhou()
        {
            //try
            //{
            //    Setting.list_ucchuli.Clear();
            //    ///判断所有ucbuzhou得颜色，如果都是灰色，那么高亮第一个，同时显示详细步骤
            //    bool existselect = false;
            //    foreach (UserControl item in panel_chuli.Controls)
            //    {
            //        UCchuli myuc = item as UCchuli;
            //        if (myuc.lbl_buzhou.ForeColor == Color.White)
            //        {
            //            existselect = true;
            //            break;
            //        }
            //    }
            //    if (!existselect)
            //    {
            //        UCchuli myuc = panel_chuli.Controls[0] as UCchuli;
            //        //高亮
            //        myuc.lbl_buzhou.BackColor = Color.SteelBlue;
            //        myuc.lbl_buzhou.ForeColor = Color.White;
            //        //添加步骤详情
            //        panel_xiangqing.Controls.Clear();
            //        panel_xiangqing.Controls.Add(myuc.control_xiangqing);
            //    }

            //    //更新步骤列表setting,此时myinfo已经存在于ucchuli之中了

            //    foreach (UserControl item in panel_chuli.Controls)
            //    {
            //        Setting.list_ucchuli.Add(item as UCchuli);
            //    }
            //    //使用setting.ucchuli生成datatable
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("序号");
            //    dt.Columns.Add("名称");
            //    dt.Columns.Add("类型");
            //    dt.Columns.Add("正则表达式");
            //    dt.Columns.Add("替换为");
            //    dt.Columns.Add("文本");
            //    dt.Columns.Add("修改时间");
            //    int xuhao = 0;
            //    for (int i = Setting.list_ucchuli.Count - 1; i >= 0; i--)
            //    {
            //        UCchuli myuc = Setting.list_ucchuli[i] as UCchuli;
            //        DataRow mydr = dt.NewRow();
            //        xuhao++;
            //        mydr["序号"] = xuhao;
            //        mydr["名称"] = myuc.myinfo._selfname;
            //        mydr["类型"] = myuc.myinfo._name;
            //        mydr["修改时间"] = myuc.myinfo._updatedate;
            //        dt.Rows.Add(mydr);
            //    }
            //    dgv_guize.DataSource = null;

            //    dgv_guize.DataSource = dt;

            //}
            //catch { }
        }



        private void Panel_chuli_ControlAdded(object sender, ControlEventArgs e)
        {
            GetBuzhou();
        }

        private void Panel_chuli_ControlRemoved(object sender, ControlEventArgs e)
        {
            GetBuzhou();
        }

        private void Pb_chuli_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.addfielden;

        }

        private void Pb_chuli_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.addfieldlv;

        }

        private void Pb_clear_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.delete0;

        }

        private void Pb_clear_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.delete1;

        }

        private void Cb_wenjianming_CheckedChanged(object sender, EventArgs e)
        {
            Setting._wenjianming = ((CheckBox)sender).Checked;
        }

        private void Cb_zhengwen_CheckedChanged(object sender, EventArgs e)
        {
            Setting._zhengwen = ((CheckBox)sender).Checked;

        }
        /// <summary>
        /// 点击导出模板按钮时触发的事件
        /// </summary>
        /// <param name="dgv"></param>
        public void DaoChuMuban(DataGridView dgv)
        {
            StringBuilder mysb = new StringBuilder();
            string defultfilename = string.Empty;
            //逐行判断是否为选中行
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var myrow = dgv.Rows[i];
                bool select = (bool)myrow.Cells[0].EditedFormattedValue;
                if (select)
                {
                    int index = myrow.Index;
                    if (defultfilename.Equals(string.Empty))
                    {
                        defultfilename = myrow.Cells["名称"].Value.ToString();
                    }
                    //如果选中了，获得myinfo的自定义姓名，类型name，正则，tihuan，text，修改时间，构造json
                    string myjson = JsonConvert.SerializeObject(Setting.list_guize[index]);
                    mysb.AppendLine(myjson);
                }
            }
            //将json保存指定路径 savefiledialog
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "极简信息模板|*.jxx|所有文件|*.*";
            sfd.FileName = defultfilename + ".jxx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter mysw = new StreamWriter(sfd.FileName, false);
                mysw.Write(mysb.ToString());
                mysw.Close();

            }
            //提示保存成功
            MessageBox.Show($"模板 {Path.GetFileNameWithoutExtension(sfd.FileName)} 已保存成功！");
        }

        /// <summary>
        /// 点击导出按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_daochu_Click(object sender, EventArgs e)
        {
            DaoChuMuban(dgv_guize);
        }
        /// <summary>
        /// 点击导入按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_daoru_Click(object sender, EventArgs e)
        {

            //选择模板文件
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "极简模板|*.jxx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //获得文件流
                List<string> list_json = new List<string>();
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    list_json.Add(str);
                }


                foreach (string item in list_json)
                {                //反序列化为buzhouinfo
                    BuzhouInfo mybuzhou = JsonConvert.DeserializeObject<BuzhouInfo>(item);
                    //buzhouinfo添加到settinglistguize中

                    Setting.list_guize.Add(mybuzhou);
                }




                //刷新dgvguize
                UpdateDgvGuize();





            }





        }

        public void UpdateDgvGuize()
        {
            //加载规则列表,构造datatable
            DataTable mydt = new DataTable();
            mydt.Columns.Add("序号");
            mydt.Columns.Add("名称");

            mydt.Columns.Add("类型");
            mydt.Columns.Add("修改时间");
            mydt.Columns.Add("正则表达式");
            mydt.Columns.Add("替换为");
            mydt.Columns.Add("文本");
            for (int i = 0; i < Setting.list_guize.Count; i++)
            {
                var mydr = mydt.Rows.Add();
                mydr["序号"] = i + 1;
                mydr["类型"] = Setting.list_guize[i]._name;
                mydr["名称"] = Setting.list_guize[i]._selfname;
                mydr["修改时间"] = Setting.list_guize[i]._updatedate;
                mydr["正则表达式"] = Setting.list_guize[i]._zhengze;
                mydr["替换为"] = Setting.list_guize[i]._tihuan;
                mydr["文本"] = Setting.list_guize[i]._text;
            }
            dgv_guize.DataSource = null;
            dgv_guize.DataSource = mydt;
            Application.DoEvents();
            //隐藏正则表达式，替换为，文本列
            //dgv_guize.Columns["正则表达式"].Visible = false;
            //dgv_guize.Columns["替换为"].Visible = false;
            //dgv_guize.Columns["文本"].Visible = false;
            //优化数据窗样式
            dgv_guize.Columns[0].Width = 50;
            dgv_guize.Columns["序号"].Width = 50;


        }


        /// <summary>
        /// 规则列表添加行时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_guize_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GetGuize();
        }

        private void GetGuize()
        {
            Setting.list_guize.Clear();
            for (int i = 0; i < dgv_guize.Rows.Count; i++)
            {
                var row = dgv_guize.Rows[i];
                BuzhouInfo myinfo = new BuzhouInfo();
                try
                {
                    myinfo._name = row.Cells["类型"].Value.ToString();

                }
                catch {
                    myinfo._name = string.Empty;
                }
                try
                {
                    myinfo._selfname = row.Cells["名称"].Value.ToString();
                }
                catch {
                    myinfo._selfname = string.Empty;
                }
                try
                {
                    myinfo._updatedate = row.Cells["修改时间"].Value.ToString();
                }
                catch {
                    myinfo._updatedate = string.Empty;
                }
                try
                {
                    myinfo._zhengze = row.Cells["正则表达式"].Value.ToString();
                }
                catch {
                    myinfo._zhengze = string.Empty;
                }
                try
                {
                    myinfo._tihuan = row.Cells["替换为"].Value.ToString();
                }
                catch {
                    myinfo._tihuan = string.Empty;
                }
                try
                {
                    myinfo._text = row.Cells["文本"].Value.ToString();
                }
                catch {
                    myinfo._text = string.Empty;
                }
                Setting.list_guize.Add(myinfo);
            }
        }

        private void Dgv_guize_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetGuize();
        }

        private void Dgv_guize_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //获得当前选中行
                int index = dgv_guize.SelectedRows[0].Index;
                //获得对应的buzhouinfo
                BuzhouInfo mybuzhou = Setting.list_guize[index];

                //显示处理详情控件
                //显示详情控件
                Control control_xiangqing = null;
                if (mybuzhou._name.Contains("替换"))
                {
                    control_xiangqing = new UCBuzhou(mybuzhou._zhengze, mybuzhou._tihuan) { Dock = DockStyle.Fill };
                    (control_xiangqing as UCBuzhou).tb_zhengze.TextChanged += Tb_zhengze_TextChanged;
                    (control_xiangqing as UCBuzhou).tb_tihuan.TextChanged += Tb_tihuan_TextChanged;
                    (control_xiangqing as UCBuzhou).tb_zhengze.Leave += UCchuli_Leave;
                    (control_xiangqing as UCBuzhou).tb_tihuan.Leave += UCchuli_Leave;

                }
                else if (mybuzhou._name.Contains("缀") || mybuzhou._name.Contains("清除"))
                {
                    control_xiangqing = new System.Windows.Forms.TextBox() { Dock = DockStyle.Fill, Text = mybuzhou._text, Multiline = true };
                    control_xiangqing.TextChanged += UCchuli_TextChanged;
                    control_xiangqing.Leave += UCchuli_Leave;
                }
                panel_xiangqing.Controls.Clear();
                panel_xiangqing.Controls.Add(control_xiangqing);
            }
            catch { }



        }

        private void Dgv_guize_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    ((DataGridView)sender).ClearSelection();
                    ((DataGridView)sender).Rows[e.RowIndex].Selected = true;
                    ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cms_dgv.Show(MousePosition.X, MousePosition.Y);//dgv_rightmenu是鼠标右键菜单控件
                }
            }

        }
        /// <summary>
        /// 该事件用于删除规则列表中的选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //删除选中的规则记录
            dgv_guize.Rows.Remove(dgv_guize.CurrentRow);


            //刷新数据
            UpdateDgvGuize();


        }

        private void Dgv_guize_Sorted(object sender, EventArgs e)
        {
            //重新为序号列排序
            for (int i = 0; i < dgv_guize.Rows.Count; i++)
            {
                dgv_guize.Rows[i].Cells["序号"].Value = i + 1;

            }

        }

        private void Cb_quanxuan_CheckedChanged(object sender, EventArgs e)
        {
            bool selectall = cb_quanxuan.Checked;
            foreach (DataGridViewRow myrow in dgv_guize.Rows)
            {
                myrow.Cells[0].Value = selectall;
            }
        }

        private void Dgv_guize_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void cbb_geshi_DropDown(object sender, EventArgs e)
        {
            cbb_geshi.Items.Clear();
            var list = mycontroller._sqlhelper.GetSingleField("模板名称", "模板信息表");
            cbb_geshi.Items.AddRange(list.ToArray());
        }
    }
}
