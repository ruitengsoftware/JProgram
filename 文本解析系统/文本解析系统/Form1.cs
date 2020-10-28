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
        JJController.ControllerNewTask _mycontroller = new JJController.ControllerNewTask();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_xinzengrenwu_Click(object sender, EventArgs e)
        {
            JJWinForm.WinFormNewTask mywin = new JJWinForm.WinFormNewTask();
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog()==DialogResult.OK)
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
                    myrow.Cells["xuhao"].Value = index+1;
                    myrow.Cells["mubiaowenjianjia"].Value = _mycontroller._childdirectories[i];
                    myrow.Cells["jiexiguize"].Value = jiexiguize;
                    myrow.Cells["wanchenghou"].Value = wanchenghou;
                }




            }
        }

        private void dgv_daichuli_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv_daichuli.CurrentCell.ValueType.ToString().ToLower().Equals("system.drawing.image"))
            {
                dgv_daichuli.Rows.RemoveAt(e.RowIndex);
            } 
        }

        private void dgv_jiexiguize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            JJWinForm.WinFormGuize mywin = new JJWinForm.WinFormGuize();
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog()==DialogResult.OK)
            {

            }
        }
    }
}
