using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFperson : Form
    {
        public WFperson(string person)
        {
            InitializeComponent();
            _person = person;
        }
        ControllerWFperson mycontroller = new ControllerWFperson();
        string _person = string.Empty;
        private void WFperson_Load(object sender, EventArgs e)
        {
            var data = mycontroller.GetAllPerson();
            dgv_data.DataSource = null;
            dgv_data.DataSource = data;
            //添加多选框列
            DataGridViewCheckBoxColumn dgvcol = new DataGridViewCheckBoxColumn();
            dgvcol.HeaderText = "选择";
            dgvcol.Name = "选择";
            //dgvcol.DisplayIndex = 0;
            dgv_data.Columns.Add(dgvcol);
            dgv_data.Columns["选择"].DisplayIndex = 0;
            //将已包含的人名前的复选框选中
            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                var dgvrow = dgv_data.Rows[i];
                string name = dgvrow.Cells["实名"].Value.ToString();
                if (_person.Contains(name))
                {
                    var mycell = (DataGridViewCell)dgvrow.Cells["选择"];
                    mycell.Value = true;
                }


            }



        }
        public List<string> list_person = new List<string> ();

        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_quding_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                var myrow = dgv_data.Rows[i];
                bool value = (Boolean)myrow.Cells["选择"].FormattedValue;
                string name = myrow.Cells["实名"].Value.ToString();
                if (Convert.ToBoolean(value))
                {
                    list_person.Add(name);
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
