
using RuiTengDll;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.UC
{
    public partial class WinFormWrong : Form
    {
        public WinFormWrong()
        {
            InitializeComponent();
        }
        public WinFormWrong(DataTable dt)
        {
            InitializeComponent();
            dgv_wrong.DataSource = dt;
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
           UIHelper mydrawer = new UIHelper();

        private void WinFormWrong_Load(object sender, EventArgs e)
        {
        }

        private void lbl_close_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect((Control)sender);
        }

        private void lbl_close_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin - 1));

        }

        private void lbl_close_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin + 1));

        }

        private void label3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 工作簿|*.xlsx|Excel 97-2003工作簿|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Workbook mywbk = new Workbook();
                Worksheet mysht = mywbk.Worksheets[0];
                for (int i = 0; i < dgv_wrong.ColumnCount; i++)
                {
                    mysht.Range[1, i + 1].Value = dgv_wrong.Columns[i].HeaderText;
                }
                for (int j = 0; j < dgv_wrong.RowCount; j++)
                {
                    for (int k = 0; k < dgv_wrong.ColumnCount; k++)
                    {
                        if (dgv_wrong.Rows[j].Cells[k].Value != null)
                        {
                            mysht.Range[j + 2, k + 1].Value = dgv_wrong.Rows[j].Cells[k].Value.ToString();

                        }
                        else
                        {
                            mysht.Range[j + 2, k + 1].Value = "";
                        }
                    }
                }
                mywbk.SaveToFile(sfd.FileName, ExcelVersion.Version2010);
                MessageBox.Show("导出Excel完成！");

            }

        }
    }
}
