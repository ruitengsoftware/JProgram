using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 谦海数据解析系统.JJwinform
{
    public partial class SelectDBForm : Form
    {
        public SelectDBForm()
        {
            InitializeComponent();
        }

        private void lbl_tuichu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_queding_Click(object sender, EventArgs e)
        {

            //获得选中的数据库类别和数据库信息
            string _dbLeibie = listBox1.SelectedItem.ToString();
            string _dbName = listBox2.SelectedItem.ToString();
            //更新userinfo的信息
            SystemInfo._userInfo._dbLeibie = _dbLeibie;
            SystemInfo._userInfo._dbName = _dbName;

            //保存userinfode的信息到数据库中
            SystemInfo.SaveUserInfo();




            this.DialogResult = DialogResult.OK;
        }
    }
}
