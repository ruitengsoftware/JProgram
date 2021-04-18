using MySql.Data.MySqlClient;
using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 习大大信息库标准化工具.JJCommon;
using 习大大信息库标准化工具.JJController;

namespace 习大大信息库标准化工具.JJWinForm
{
    public partial class WinFormZhaohuimima : Form
    {
        public WinFormZhaohuimima()
        {
            InitializeComponent();
        }

        private void lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_queding_Click(object sender, EventArgs e)
        {
            //判断花名，实名为条件  是否和邮箱匹配
            string huaming = tb_huaming.Text;
            string shiming = tb_shiming.Text;
            string youxiang = tb_youxiang.Text;
            string mima1 = tb_xinmima.Text;
            string mima2 = tb_querenmima.Text;
            string myyouxiang = GetEmail(huaming, shiming);
            if (myyouxiang.Equals(youxiang))
            {
                //判断密码是否一直，如果不一致，退出
                if (mima1.Equals(mima2))
                {
                    bool b = UpdatePassword(huaming, shiming, myyouxiang, mima2);
                    if (b)
                    {
                        MessageBox.Show("修改密码成功！");
                        this.DialogResult = DialogResult.OK;
                    }

                }
                else
                {
                    MessageBox.Show("两次输入的密码不一致！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("邮箱不匹配！");
                return;            }
        }
        private void WinFormZhaohuimima_Load(object sender, EventArgs e)
        {


        }

        private void lbl_queding_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);

        }

        private void lbl_queding_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, 1);

        }

        private void lbl_queding_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }



        #region controller
        JJCommon.MySqlHelper _mysqlhelper = new JJCommon.MySqlHelper();
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="huaming"></param>
        /// <param name="shiming"></param>
        /// <param name="youxiang"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdatePassword(string huaming, string shiming, string youxiang, string pwd)
        {
            string str_sql = $"update jjdbrenwutaizhang.jjperson set 密码=@pwd where 花名='{huaming}' and 实名='{shiming}' " +
                    $"and 电子邮箱='{youxiang}'";
            int num = _mysqlhelper.ExecuteNonQuery(str_sql, new MySqlParameter[] { new MySql.Data.MySqlClient.MySqlParameter("@pwd", pwd) });
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 根据花名和实名获得用户邮箱
        /// </summary>
        /// <param name="huaming"></param>
        /// <param name="shiming"></param>
        /// <returns></returns>
        public string GetEmail(string huaming, string shiming)
        {
            string str_sql = $"select 电子邮箱 from jjdbrenwutaizhang.jjperson where 花名='{huaming}'" +
                    $" and 实名='{shiming}'";
            string youxiang = _mysqlhelper.ExecuteScalar(str_sql).ToString();
            return youxiang;



        }



        #endregion
    }
}
