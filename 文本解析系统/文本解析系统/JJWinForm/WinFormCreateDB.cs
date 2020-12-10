using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJCommon;
using 文本解析系统.JJController;
using 文本解析系统.JJModel;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormCreateDB : Form
    {
        ControllerWFcreatedb _mycontroller = new ControllerWFcreatedb();


        public WinFormCreateDB()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击确定按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {

            //判断集中不能添加的情况
            //信息为空，pberror可见
            bool b1 = tb_dbname.Text.Trim().Equals(string.Empty);
            bool b2 = cbb_leixing.Text.Trim().Equals(string.Empty);
            bool b3 = pb_error.Visible;
            if (b1 || b2|| b3)
            {
                MessageBox.Show("新建失败！");
                return;
            }
            ChachongbiaoInfo myinfo = new ChachongbiaoInfo()
            {
                _mingcheng = tb_dbname.Text.Trim(),
                _leixing = cbb_leixing.Text,
                _chuangjianren = UserInfo._huaming,
                _chuangjianshijian = DateTime.Now.ToString()
            };
            //创建数据表并向数据库汇总表中添加新建信息
           bool b= _mycontroller.CreateDB(myinfo);
            if (b)
            {
                MessageBox.Show("新建数据库成功！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tb_dbname_Leave(object sender, EventArgs e)
        {
            //判断数据表是否存在
            bool b = _mycontroller.IsExist(tb_dbname.Text);
            if (b)
            {
                pb_error.Visible = true;
                toolTip1.SetToolTip(pb_error, "重复的数据表名称");
            }
            else
            {
                pb_error.Visible = false;
            }

        }
    }
}
