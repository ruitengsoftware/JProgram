using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJController;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormSelect : Form
    {
        ControllerWFdiaoyongguize _mycontroller = new ControllerWFdiaoyongguize();
        public string _selectstr = string.Empty;
        string _guizeorchachong = string.Empty;
        public WinFormSelect()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="s">将已经选中的规则传进来</param>
        /// <param name="r">选择规则或查重库</param>

        public WinFormSelect(string s,string r)
        {
            InitializeComponent();
            _selectstr = s;
            _guizeorchachong = r;
        }
        private void WinFormDiaoyongguize_Load(object sender, EventArgs e)
        {
            //获得所有规则，显示在窗体中
            DataTable mydt = _mycontroller.GetData(_guizeorchachong);
            dgv_data.DataSource = mydt;

            //在已选中规则前打勾
            foreach (DataGridViewRow mydr in dgv_data.Rows)
            {
                string name = mydr.Cells["名称"].Value.ToString();
                if (_selectstr.Contains(name))
                {
                    mydr.Cells["xuanze"].Value = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //获得所有选中的规则名称组成字符串
            List<string> selectguize = new List<string>();
            foreach (DataGridViewRow dr in dgv_data.Rows)
            {
                bool b = Convert.ToBoolean(dr.Cells["xuanze"].EditedFormattedValue);
                if (b)
                {
                    selectguize.Add(dr.Cells["名称"].Value.ToString());
                }
            }

            //字符串赋值给——guize
            _selectstr = string.Join(",", selectguize);
            //关闭窗体
            this.DialogResult = DialogResult.OK;
        }

        private void lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
