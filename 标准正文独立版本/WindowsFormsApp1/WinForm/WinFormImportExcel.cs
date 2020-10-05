using Aspose.Cells;
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

namespace WindowsFormsApp1.WinForm
{
    public partial class WinFormImportExcel : Form
    {
        UIHelper uihelper = new UIHelper();
        public DataTable dt = new DataTable();//返回值datatable

        public WinFormImportExcel()
        {
            InitializeComponent();
        }

        private void Label4_Paint(object sender, PaintEventArgs e)
        {
            uihelper.DrawRoundRect((Control)sender);
        }
        private void Lbl_daoru_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            try
            {

                dt = GetDTFormExcel(tb_file.Text, cbb_sht.Text);

            }
            catch { }
        }

        /// <summary>
        /// 该方法用于获得excel指定sheet的数据，使用aspose获得datatble
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        private DataTable GetDTFormExcel(string filename,string tablename)
        {
            DataTable mydt = new DataTable();
            Workbook mywbk = new Workbook(filename);
            Worksheet mysht = mywbk.Worksheets[tablename];
            Cells cells = mysht.Cells;
            mydt = cells.ExportDataTable(0, 0, cells.MaxRow+1, cells.MaxColumn+1, true);
            return mydt;
        }



        private void Lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pb_folder_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tb_file.Text = ofd.FileName;

            }

        }
        OledbHelper oledbhelper = new OledbHelper();
        private void Tb_file_TextChanged(object sender, EventArgs e)
        {
            cbb_sht.Items.Clear();

            Aspose.Cells.Workbook mywbk = new Aspose.Cells.Workbook(tb_file.Text);
            foreach (Worksheet item in mywbk.Worksheets)
            {
                cbb_sht.Items.Add(item.Name);
            }
            cbb_sht.SelectedIndex = 0;
        }
    }
}
