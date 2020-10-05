using ClickHouse.Ado;
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
using WindowsFormsApp1.Controller;

namespace WindowsFormsApp1.WinForm
{
    public partial class WinFormSelectDb : Form
    {
        string mysql_constr = $"server={Properties.Settings.Default._ip};port=3306;user=root;password=111111; database=qianhai;";
        MySqlConnection mysql = null;

        public string dbname = string.Empty;
        public WinFormSelectDb()
        {
            InitializeComponent();
            mysql = new MySqlConnection(mysql_constr);
            mysql.Open();

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (lb_db.SelectedItem == null)
            {
                dbname = string.Empty;
            }
            else
            {
                dbname = lb_db.SelectedItem.ToString();

            }

        }

        private void Lbl_queding_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void WinFormSelectDb_Load(object sender, EventArgs e)
        {

            List<string> listtablename = new List<string>();

            string str_sql = "select table_name from innodb_table_stats where database_name='qianhai'";
            mysql.ChangeDatabase("mysql");
            MySqlCommand mycmd = new MySqlCommand(str_sql, mysql);
            var myreader = mycmd.ExecuteReader();
            while (myreader.Read())
            {
                listtablename.Add(myreader.GetString(0));
            }
           
            lb_db.Items.AddRange(listtablename.ToArray());
        }



    UIHelper uihelper = new UIHelper();
    private void Lbl_guanbi_Paint(object sender, PaintEventArgs e)
    {
        uihelper.DrawRoundRect((Control)sender);
    }

    private void Lbl_guanbi_Click(object sender, EventArgs e)
    {
        this.Dispose();
    }
}
}
