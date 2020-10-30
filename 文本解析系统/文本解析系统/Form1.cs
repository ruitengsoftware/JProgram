using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            JJWinForm.WinFormGuize mywin = new JJWinForm.WinFormGuize();
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog() == DialogResult.OK)
            {

            }
        }
        /// <summary>
        /// 加载form1窗体时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //更新dgv_guize的数据
            




        }
    }
}
