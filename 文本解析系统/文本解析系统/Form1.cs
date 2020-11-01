using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJModel;

namespace 文本解析系统
{
    public partial class Form1 : Form
    {

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
                string jiexiguize = mywin._ruler;
                string wanchenghou = mywin._action;
                //获得文件夹下所有的文件夹
                for (int i = 0; i < _mycontroller._childdirectories.Count; i++)
                {
                    //在待处理人物列表增加行
                    int index = dgv_daichuli.Rows.Add();
                    var myrow = dgv_daichuli.Rows[index];
                    myrow.Cells["xuhao"].Value = index + 1;
                    myrow.Cells["mubiaowenjianjia"].Value = _mycontroller._childdirectories[i];
                    myrow.Cells["jiexiguize"].Value = jiexiguize;
                    myrow.Cells["wanchenghou"].Value = wanchenghou;
                }




            }
        }

        private void dgv_daichuli_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgv_daichuli.CurrentCell.ValueType.ToString().ToLower().Equals("system.drawing.image"))
                {
                    dgv_daichuli.Rows.RemoveAt(e.RowIndex);
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
            //点击button按钮事件
            if (dgv_jiexiguize.Columns[e.ColumnIndex].Name == "bianjianniu" && e.RowIndex >= 0)
            {
                //从数据库中获得该规则对应的文本特征，显示到新打开的winformguize中
                string rulename = dgv_jiexiguize.Rows[e.RowIndex].Cells["jiexiguizemingcheng"].Value.ToString();
                //构造一个winformguize
                JJWinForm.WinFormGuize mywin = new JJWinForm.WinFormGuize(rulename);
                mywin.StartPosition = FormStartPosition.CenterParent;
                mywin.ShowDialog();
            }
            //点击button按钮事件
            if (dgv_jiexiguize.Columns[e.ColumnIndex].Name == "shanchuanniu" && e.RowIndex >= 0)
            {
                //获得规则名称
                string rulename = dgv_jiexiguize.Rows[e.RowIndex].Cells["jiexiguizemingcheng"].Value.ToString();
                //规则信息表该条规则的删除字段赋值为1
                _mycontroller.DeleteGuize(rulename);

            }

            //刷新数据
            _mycontroller.UpdateDGV(dgv_jiexiguize);



        }

        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            JJWinForm.WinFormGuize mywin = new JJWinForm.WinFormGuize();
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                _mycontroller.UpdateDGV(dgv_jiexiguize);
            }
        }
        /// <summary>
        /// 加载form1窗体时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

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
            //显示该格式上一条名称，如果没有格式，不显示，所有得设置为空

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
            //保存解析格式
            bool b = _mycontroller.SaveFormat(formatname, chachong, excelpath, list_guize);
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
                if (item.Text.Equals(myfi._chachongchuli))
                {
                   (item as CheckBox).Checked = true;
                }
            }

            //excel存放赋值
            if (myfi._excelpath.Equals(string.Empty))
            {
                cb_moren.Checked = true;
            }
            else
            {
                cb_qita.Checked = true;
                tb_savepath.Text = myfi._excelpath;
            }


            //把选中规则前面的对号打上

            foreach (DataGridViewRow item in dgv_jiexiguize.Rows)
            {
                string name = item.Cells[1].Value.ToString();
                if (myfi.list_jiexiguize.Contains(name))
                {
                    item.Cells[0].Value = true;


                }
            }




        }
    }
}
