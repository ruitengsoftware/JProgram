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

        public string dbname = string.Empty;
        public WinFormSelectDb()
        {
            InitializeComponent();
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
        ControllerClickhouse chhelper = new ControllerClickhouse();
        private void WinFormSelectDb_Load(object sender, EventArgs e)
        {
            //获得数据所有表明
            //string dbfile = $"{Environment.CurrentDirectory}\\ruitengdb.db";
            //SqliteHelper mysqliter = new SqliteHelper(dbfile);
            //mysqliter.Open();
            //var dbnames = mysqliter.GetAllTableName().ToArray(); ;
            //lb_db.Items.AddRange(dbnames);
            string dbfile = "select name from tables where database='default'";
            chhelper.SelectDB("system");
            var dt = chhelper.GetDataFromTable(dbfile);
            List<string> listtablename = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tablename = dt.Rows[i]["name"].ToString();
                if (!listtablename.Contains(tablename))
                {
                    listtablename.Add(dt.Rows[i]["name"].ToString());
                }
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
