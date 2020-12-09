﻿using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJCommon;
using 文本解析系统.JJModel;
using 文本解析系统.JJWinForm;

namespace 文本解析系统
{
    public partial class Form1 : Form
    {
        public bool zanting = false;//用来记录用户是否暂停
        public bool tingzhi = false;//用来记录用户是否已经停止
        public int startfolder = 0;//用于记录每次开始解析的文件夹的位置
        public int startfile = 0;//用于记录每次开始解析的文件的位置

        JJController.ControllerForm _mycontroller = new JJController.ControllerForm();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_xinzengrenwu_Click(object sender, EventArgs e)
        {
            JJWinForm.WinFormNewTask mywin = new JJWinForm.WinFormNewTask();
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                //如果点击ok，那么应该获得文件夹，解析规则，和完成后操作
                string folder = mywin._folder;
                _mycontroller.GetDirectory(folder);//获得所有子文件夹
                string jiexigeshi = mywin._ruler;
                string wanchenghou = mywin._action;
                //获得文件夹下所有的文件夹
                for (int i = 0; i < _mycontroller._childdirectories.Count; i++)
                {
                    //在待处理人物列表增加行
                    int index = dgv_task.Rows.Add();
                    var myrow = dgv_task.Rows[index];
                    myrow.Cells["xuhao"].Value = index + 1;
                    myrow.Cells["mubiaowenjianjia"].Value = _mycontroller._childdirectories[i];
                    myrow.Cells["jiexigeshi"].Value = jiexigeshi;
                }




            }
        }

        private void dgv_daichuli_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgv_task.CurrentCell.ValueType.ToString().ToLower().Equals("system.drawing.image"))
                {
                    dgv_task.Rows.RemoveAt(e.RowIndex);
                }

            }
            catch { }
        }
        /// <summary>
        /// 点击编辑，删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_jiexiguize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击编辑按钮事件,注意如果是基础规则那么点击无效
            if (dgv_jiexiguize.Columns[e.ColumnIndex].Name == "bianjianniu" && e.RowIndex >= 0)
            {
                //从数据库中获得该规则对应的文本特征，显示到新打开的winformguize中
                string rulename = dgv_jiexiguize.Rows[e.RowIndex].Cells["jiexiguizemingcheng"].Value.ToString();
                if (rulename.Contains("基础解析规则"))
                {
                    MessageBox.Show("不可编辑基础规则！");
                    return;
                }
                //构造一个winformguize
                JJWinForm.WinFormGuize mywin = new JJWinForm.WinFormGuize(rulename);
                mywin.StartPosition = FormStartPosition.CenterParent;
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                    _mycontroller.UpdateDGV(dgv_jiexiguize);
                }
            }
            //点击删除按钮事件,注意如果是基础规则那么点击无效
            if (dgv_jiexiguize.Columns[e.ColumnIndex].Name == "shanchuanniu" && e.RowIndex >= 0)
            {
                //获得规则名称
                string rulename = dgv_jiexiguize.Rows[e.RowIndex].Cells["jiexiguizemingcheng"].Value.ToString();
                if (rulename.Contains("基础解析规则"))//基础规则点击无效
                {
                    MessageBox.Show("不可删除基础规则！");
                    return;
                }
                //规则信息表该条规则的删除字段赋值为1
                _mycontroller.DeleteGuize(rulename);
                //刷新数据
                _mycontroller.UpdateDGV(dgv_jiexiguize);
            }
            //点击选择按钮
            //if (dgv_jiexiguize.Columns[e.ColumnIndex].Name == "xuanze" && e.RowIndex >= 0)
            //{
            //    if (Convert.ToBoolean( dgv_jiexiguize.Rows[e.RowIndex].Cells[0].FormattedValue) == true)
            //    {
            //        dgv_jiexiguize.Rows[e.RowIndex].Cells[0].Value = false;
            //    }
            //    else
            //    {
            //        dgv_jiexiguize.Rows[e.RowIndex].Cells[0].Value = true;
            //    }
            //}
        }

        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            JJWinForm.WinFormCreateDB mywin = new WinFormCreateDB();
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog() == DialogResult.OK)
            {
               //刷新查重库下拉列表
            }
        }
        /// <summary>
        /// 加载form1窗体时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //显示用户信息
            lbl_userinfo.Text = $"用户：{UserInfo._huaming}";
            _mycontroller.UpdateDGV(dgv_jiexiguize);
        }
        /// <summary>
        /// 点击删除格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shanchu_Click(object sender, EventArgs e)
        {
            //获得格式名称
            string formatname = cbb_jiexigeshi.Text;
            //赋值对应的删除字段为1
            bool b = _mycontroller.DeleteFormat(formatname);
            if (b)
            {
                MessageBox.Show("格式已删除！");
            }
            //重新加载格式
            //获得所有解析格式的名称
            List<string> list_format = _mycontroller.GetFormat();
            //加载cbb的item
            cbb_jiexigeshi.Items.Clear();
            cbb_jiexigeshi.Items.AddRange(list_format.ToArray());
            cbb_jiexigeshi.SelectedIndex = 0;

        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_baocun_Click(object sender, EventArgs e)
        {
            //获得解析格式名称
            string formatname = cbb_jiexigeshi.Text;
            //删除解析格式
            _mycontroller.RealDeleteFormat(formatname);
            //获得查重处理
            string chachong = string.Empty;
            foreach (Control item in tlp_chachong.Controls)
            {
                if (item is CheckBox && (item as CheckBox).Checked)
                {
                    if (item.Text == "写入新MD5值")
                    {
                        continue;
                    }
                    chachong = item.Text;
                }
            }

            //获得excel存放位置
            string excelpath = string.Empty;
            if (!tb_savepath.Text.Trim().Equals(string.Empty))
            {
                excelpath = tb_savepath.Text.Trim();
            }
            //获得所有选中的规则名称
            List<string> list_guize = new List<string>();
            foreach (DataGridViewRow item in dgv_jiexiguize.Rows)
            {
                //获得item是否选中
                if ((bool)item.Cells[0].FormattedValue == true)
                {
                    list_guize.Add(item.Cells[1].Value.ToString());
                }
            }
            //获得是否新MD5
            bool newmd5 = cb_md5.Checked;
            //保存解析格式
            bool b = _mycontroller.SaveFormat(formatname, chachong, excelpath, newmd5, list_guize);
            if (b) MessageBox.Show("解析格式保存成功！");
        }
        /// <summary>
        /// 解析格式列表下拉时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_jiexigeshi_DropDown(object sender, EventArgs e)
        {
            //获得所有解析格式的名称
            List<string> list_format = _mycontroller.GetFormat();
            //加载cbb的item
            cbb_jiexigeshi.Items.Clear();
            cbb_jiexigeshi.Items.AddRange(list_format.ToArray());
        }
        /// <summary>
        /// 切换解析格式名称下拉框时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_jiexigeshi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获得格式名称
            string formatname = cbb_jiexigeshi.Text;

            //获得格式名称对应的格式信息
            FormatInfo myfi = _mycontroller.GetFormatInfo(formatname);

            //查重处理赋值
            foreach (Control item in tlp_chachong.Controls)
            {

                if (item is CheckBox && item.Text.Equals(myfi._chachongchuli))
                {
                    (item as CheckBox).Checked = true;
                }
                else if (item is CheckBox && !item.Text.Equals(myfi._chachongchuli))
                {
                    (item as CheckBox).Checked = false;
                }
            }
            //新MD5复制
            if (myfi._newmd5)
            {
                cb_md5.Checked = true;
            }
            //excel存放赋值
            if (myfi._excelpath.Equals(string.Empty))
            {
                rb_moren.Checked = true;
            }
            else
            {
                rb_qita.Checked = true;
                tb_savepath.Text = myfi._excelpath;
            }


            //把选中规则前面的对号打上

            foreach (DataGridViewRow item in dgv_jiexiguize.Rows)
            {
                item.Cells[0].Value = false;
                string name = item.Cells[1].Value.ToString();
                if (myfi.list_jiexiguize.Contains(name))
                {
                    item.Cells[0].Value = true;
                }
            }




        }
        /// <summary>
        /// 点击开始按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_kaishi_Click(object sender, EventArgs e)
        {
            //更改软件状态
            lbl_statue.Text = " 状态：正在解析";
            //如果暂停状态是false,让开始文件夹，文件的序号等于0
            if (!zanting)
            {
                startfolder = startfile = 0;
                //所有任务进度为0
                for (int i = 0; i < dgv_task.Rows.Count; i++)
                {
                    dgv_task.Rows[i].Cells["jindu"].Value = "";

                }
            }
            zanting = false;//暂停状态设置为false
            tingzhi = false;//停止状态为false
            for (int i = startfolder; i < dgv_task.Rows.Count; i++)
            {//记录本次文件夹最终完成度，完成，未完成，重复
                string str_jiexijieguo = string.Empty;
                //记录正在执行的文件夹的位置
                startfolder = i;
                //获得文件夹名称
                string foldername = dgv_task.Rows[i].Cells[1].Value.ToString();
                string formatname = dgv_task.Rows[i].Cells[2].Value.ToString();
                //显示在处理列表中，更改状态为处理中
                dgv_task.Rows[i].Cells["zhuangtai"].Value = "未完成";
                //获得该文件夹下的所有文件，开始解析该文档，同时更新解析进度
                var files = Directory.GetFiles(foldername).ToList();
                for (int j = 0; j < files.Count; j++)
                {
                    //判断否人工停止,如果是，退出本方法
                    if (tingzhi) return;
                    if (zanting) return;

                    // 更新进度       
                    string jindu = (Convert.ToDouble(j + 1) * 100 / Convert.ToDouble(files.Count)).ToString("00.00");
                    dgv_task.Rows[i].Cells["jindu"].Value = $"{jindu}%";
                    //获得解析结果，如果成功显示处理完成，完成，重复
                    //判断文件名是否合法，不应含有$
                    if (files[j].Contains("$"))
                    {
                        continue;
                    }
                    //解析word文档
                    str_jiexijieguo = await _mycontroller.JiexiAsync(files[j], formatname);
                }
                dgv_task.Rows[i].Cells["zhuangtai"].Value = str_jiexijieguo;
            }
            //更新软件状态
            lbl_statue.Text = " 状态：等待执行";

            //判断是否选中完成后关机
            //如果是，那么弹出倒计时10秒提示框，并在及时完成后关机
            if (cb_guanji.Checked)
            {
                WinFormGuanji mywin = new WinFormGuanji();
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    Process.Start("shutdown.exe", "-s");
                }
            }
        }
        /// <summary>
        /// 点击excel存放文件夹图片时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_savepath.Text = fbd.SelectedPath;
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            UIHelper myuihelper = new UIHelper();
            //myuihelper.UpdateCSize((Control)sender, -1);
            myuihelper.UpdateCC((Control)sender, Color.MediumSeaGreen, Color.White);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            UIHelper myuihelper = new UIHelper();
            // myuihelper.UpdateCSize((Control)sender, 1);
            myuihelper.UpdateCC((Control)sender, Color.SeaGreen, Color.White);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            UIHelper myuihelper = new UIHelper();
            myuihelper.DrawRoundRect((Control)sender);
        }

        private void lbl_piliangshanchu_Click(object sender, EventArgs e)
        {
            //获得所有选中的行
            var selectrows = dgv_jiexiguize.SelectedRows;

            //删除数据库中对应的解析规则，刷新数据
            foreach (DataGridViewRow myrow in selectrows)
            {
                string guizename = myrow.Cells["jiexiguizemingcheng"].Value.ToString();
                if (guizename.Contains("基础解析规则"))//基础规则点击无效
                {
                    MessageBox.Show("不可删除基础规则！");
                    return;
                }
                //规则信息表该条规则的删除字段赋值为1
                _mycontroller.DeleteGuize(guizename);
                //刷新数据
                _mycontroller.UpdateDGV(dgv_jiexiguize);

            }
        }

        private void lbl_zanting_Click(object sender, EventArgs e)
        {
            lbl_statue.Text = " 状态：暂停中";

            zanting = true;

        }

        private void lbl_tingzhi_Click(object sender, EventArgs e)
        {
            lbl_statue.Text = " 状态：等待执行";

            tingzhi = true;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            UIHelper myuihelper = new UIHelper();
            //myuihelper.UpdateCSize((Control)sender, -1);
            myuihelper.UpdateCC((Control)sender, Color.Salmon, Color.White);

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            UIHelper myuihelper = new UIHelper();
            //myuihelper.UpdateCSize((Control)sender, -1);
            myuihelper.UpdateCC((Control)sender, Color.Tomato, Color.White);

        }

        private void lbl_daochu_Click(object sender, EventArgs e)
        {

        }

        private void lbl_daoru_Click(object sender, EventArgs e)
        {

        }

        private void pb_search_Click(object sender, EventArgs e)
        {
            //获得关键词
            string keyword = tb_search.Text;
            //刷新dgv
            _mycontroller.UpdateDGV(dgv_jiexiguize, keyword);
        }

        private void pb_search_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.fangdajing2;
        }

        private void pb_search_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.fangdajing1;

        }

        private void pb_path_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.folderenter;

        }

        private void pb_path_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.folderlv;

        }

        private void lbl_tuichu_Click(object sender, EventArgs e)
        {
            //关闭当前窗体，显示登录窗体，另自动登录的setting为false
            this.Hide();

            //this.Close();
            Properties.Settings.Default.zidongdenglu = false;
            WinFormdenglu mywin = new WinFormdenglu();
            if (mywin.ShowDialog()==DialogResult.OK)
            {
                (new Form1()).Show();
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void lbl_qingkong_Click(object sender, EventArgs e)
        {
            dgv_task.Rows.Clear();
        }
    }
}
