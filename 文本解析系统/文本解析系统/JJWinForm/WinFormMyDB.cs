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

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormMyDB : Form
    {
        ControllerWFmydb _mycontroller = new ControllerWFmydb();
        public WinFormMyDB()
        {
            InitializeComponent();
        }

        private void cbb_leibie_SelectedIndexChanged(object sender, EventArgs e)
        {
            //更新数据，以登录信息和类型作为查找条件
            string str_sql = $"select * from jjdbwenbenjiexi.查重库信息表 where 类型='{cbb_leibie.Text}' and 创建人='{UserInfo._huaming}'" +
                $" and 删除=0";
            DataTable dt = _mycontroller.GetChachongInfo(str_sql);
            dgv_data.DataSource = null;
            dgv_data.DataSource = dt;



        }

        private void lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu_Click(object sender, EventArgs e)
        {
            //获得选中的datarow
            for (int i = dgv_data.Rows.Count - 1; i >=0 ; i--)
            {
                DataGridViewRow dr = dgv_data.Rows[i];
                //判断该行是否选中
                bool b = Convert.ToBoolean(dr.Cells["xuanze"].EditedFormattedValue);
                //如果选中就删除
                if (b)
                {
                    _mycontroller.DeletbMydb(dr.Cells["名称"].Value.ToString());
                }
            }
            MessageBox.Show("删除成功！");
            this.DialogResult = DialogResult.OK;

        }
    }
}
