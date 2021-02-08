using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Model;
using RuiTengDll;

namespace WindowsFormsApp2.UC
{
    public partial class UCBiaozhu : UserControl
    {
       public Controller.ControllerBiaozhu mycontroller = new Controller.ControllerBiaozhu();
        public UCBiaozhu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击导入按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label51_Click(object sender, EventArgs e)
        {
            //选择模板文件
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "极简模板|*.jxx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //获得文件流
                List<string> list_json = new List<string>();
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    list_json.Add(str);
                }


                foreach (string item in list_json)
                {                //反序列化为buzhouinfo
                    BiaozhuInfo mybuzhou = JsonConvert.DeserializeObject<BiaozhuInfo>(item);
                    //buzhouinfo添加到settinglistguize中
                    mycontroller.list_biaozhu.Add(mybuzhou);
                }
                //刷新dgvguize
                UpdateDgvGuize();
            }

        }
        /// <summary>
        /// 单机导出按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label52_Click(object sender, EventArgs e)
        {
            StringBuilder mysb = new StringBuilder();
            string defultfilename = string.Empty;
            //逐行判断是否为选中行
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var myrow = dgv.Rows[i];
                bool select = (bool)myrow.Cells[0].EditedFormattedValue;
                if (select)
                {
                    int index = myrow.Index;
                    if (defultfilename.Equals(string.Empty))
                    {
                        defultfilename = myrow.Cells["名称"].Value.ToString();
                    }
                    //如果选中了，获得myinfo的自定义姓名，类型name，正则，tihuan，text，修改时间，构造json
                    string myjson = JsonConvert.SerializeObject(mycontroller.list_biaozhu[index]);
                    mysb.AppendLine(myjson);
                }
            }
            //将json保存指定路径 savefiledialog
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "极简信息模板|*.jxx|所有文件|*.*";
            sfd.FileName = defultfilename + ".jxx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter mysw = new StreamWriter(sfd.FileName, false);
                mysw.Write(mysb.ToString());
                mysw.Close();
            }
            //提示保存成功
            MessageBox.Show($"模板 {Path.GetFileNameWithoutExtension(sfd.FileName)} 已保存成功！");
        }


        public void UpdateDgvGuize()
        {
            //加载规则列表,构造datatable
            DataTable mydt = new DataTable();
            mydt.Columns.Add("序号");
            mydt.Columns.Add("名称");

            mydt.Columns.Add("类型");
            mydt.Columns.Add("修改时间");
            mydt.Columns.Add("范围");
            mydt.Columns.Add("内容");
            for (int i = 0; i < mycontroller.list_biaozhu.Count; i++)
            {
                var mydr = mydt.Rows.Add();
                mydr["序号"] = i + 1;
                mydr["名称"] = mycontroller.list_biaozhu[i]._name;
                mydr["类型"] = mycontroller.list_biaozhu[i]._style;
                mydr["修改时间"] = mycontroller.list_biaozhu[i]._updatetime;
                mydr["范围"] = mycontroller.list_biaozhu[i]._region;
                mydr["内容"] = mycontroller.list_biaozhu[i]._content;
            }
            dgv.DataSource = null;
            dgv.DataSource = mydt;
            //隐藏正则表达式，替换为，文本列
            //dgv.Columns["范围"].Visible = false;
            //dgv.Columns["内容"].Visible = false;
            //优化数据窗样式
            dgv.Columns[0].Width = 50; 
            dgv.Columns["序号"].Width = 50;
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    ((DataGridView)sender).ClearSelection();
                    ((DataGridView)sender).Rows[e.RowIndex].Selected = true;
                    ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cms_dgv.Show(MousePosition.X, MousePosition.Y);//dgv_rightmenu是鼠标右键菜单控件
                }
            }
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label41_Click(object sender, EventArgs e)
        {
            string formatname = cbb_format.Text;
            mycontroller.DeleteFormat(formatname);
            //形成模板信息
            BZMBInfo mubaninfo = new BZMBInfo();
            mubaninfo._mubanname = formatname;
            List<string> list_buzhou = new List<string>();
            for (int i = 0; i < mycontroller.list_biaozhu.Count; i++)
            {
                var myrow = dgv.Rows[i];
                mubaninfo.list_biaozhu.Add(mycontroller.list_biaozhu[i]);
            }
            string json = JsonConvert.SerializeObject(mubaninfo);
            Dictionary<string, object> dic_muban = new Dictionary<string, object>() {
                {"名称",formatname },
                {"设置",json},
                //{ "日志路径",tb_rizhilujing.Text}
            };
            mycontroller.SaveFormat(dic_muban);
            MessageBox.Show($"格式 {formatname} 已保存成功！");
        }

        private void Cb_biaozhu_CheckedChanged(object sender, EventArgs e)
        {
            mycontroller._enable = ((CheckBox)sender).Checked;
        }

        private void Dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GetGuize();
        }
        private void GetGuize()
        {
            mycontroller.list_biaozhu.Clear();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var row = dgv.Rows[i];
                BiaozhuInfo biaozhuinfo = new BiaozhuInfo();
                biaozhuinfo._name = row.Cells["名称"].Value.ToString();
                biaozhuinfo._style = row.Cells["类型"].Value.ToString();
                biaozhuinfo._updatetime = row.Cells["修改时间"].Value.ToString();
                biaozhuinfo._region = row.Cells["范围"].Value.ToString();
                biaozhuinfo._content = row.Cells["内容"].Value.ToString();
                mycontroller.list_biaozhu.Add(biaozhuinfo);
            }
        }

        private void Dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetGuize();
        }

        private void Pb_tianjiabiaozhu_Click(object sender, EventArgs e)
        {
            cms_biaozhu.Show(MousePosition.X, MousePosition.Y);
        }

        private void 正则提取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //构造一个步骤info，显示在界面中
            BiaozhuInfo biaozhuinfo = new BiaozhuInfo();
            biaozhuinfo._name = tb_name.Text;
            biaozhuinfo._updatetime = DateTime.Now.ToString("yyyy-MM-dd");
            //获得添加的类型，如果是需要传递颜色的类型，那么弹出颜色选择器
            biaozhuinfo._style = ((ToolStripMenuItem)sender).Text;
            if (biaozhuinfo._style.Contains("高亮")|| biaozhuinfo._style.Contains("下划线")|| biaozhuinfo._style.Contains("字体颜色"))
            {
                if (colorDialog1.ShowDialog()==DialogResult.OK)
                {
                    int r = colorDialog1.Color.R;
                    int g = colorDialog1.Color.G;
                    int b = colorDialog1.Color.B;
                    int a= colorDialog1.Color.A;
                    biaozhuinfo._style += $"[{r},{g},{b}]";
                }


            }

            biaozhuinfo._region = cbb_region.Text;
            biaozhuinfo._content = tb_content.Text;
            //在规则列表中增加一行 
            //形成一个datatable，绑定到dgvguize中
            DataTable mydt0 = dgv.DataSource as DataTable;
            if (mydt0 == null)
            {
                mydt0 = new DataTable();
                mydt0.Columns.Add("序号");
                mydt0.Columns.Add("名称");
                mydt0.Columns.Add("类型");
                mydt0.Columns.Add("修改时间");
                mydt0.Columns.Add("范围");
                mydt0.Columns.Add("内容");

            }
            //mydt0.Columns.Remove("选择");
            mydt0.Rows.Add(new string[] { (mydt0.Rows.Count + 1).ToString(), biaozhuinfo._name, biaozhuinfo._style, biaozhuinfo._updatetime, biaozhuinfo._region, biaozhuinfo._content });
            dgv.DataSource = null;
            dgv.DataSource = mydt0;

        }

        private void UCBiaozhu_Load(object sender, EventArgs e)
        {
            //cbb_format.SelectedIndex = 0;
            //cbb_region.SelectedIndex = 0;
        }

        private void Cbb_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            mycontroller._format= cbb_format.Text;
            var dic_setting = mycontroller.GetMuBan(mycontroller._format);
            Dictionary<string, object> dic = dic_setting as Dictionary<string, object>;
            //获得日志路径，赋值到tb_rizhilujing
            //string rizhilujing = dic["日志路径"].ToString();
            //tb_rizhilujing.Text = rizhilujing;
            //获得模板信息
            string mubanjson = dic["设置"].ToString();
            //转化为模板类
            BZMBInfo mymubaninfo = JsonConvert.DeserializeObject<BZMBInfo>(mubanjson);
            //得到模板信息
            mycontroller.list_biaozhu = mymubaninfo.list_biaozhu;
            //刷新规则列表
            UpdateDgvGuize();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //删除选中的规则记录
            dgv.Rows.Remove(dgv.CurrentRow);


            //刷新数据
            UpdateDgvGuize();



        }
        private void Lbl_daoru_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void Lbl_daoru_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            UIHelper.UpdateCSize((Control)sender,-1);
        }

        private void Lbl_daoru_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            UIHelper.UpdateCSize((Control)sender, 1);

        }

        private void Label40_Click(object sender, EventArgs e)
        {
            string formatname = cbb_format.Text;
            mycontroller.DeleteFormat(formatname);
            MessageBox.Show($"格式 {formatname} 已删除成功！");

        }

        private void Dgv_Sorted(object sender, EventArgs e)
        {
            //重新为序号列排序
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["序号"].Value = i + 1;

            }
        }

        private void Cb_quanxuan_CheckedChanged(object sender, EventArgs e)
        {
            bool selectall = cb_quanxuan.Checked;
            foreach (DataGridViewRow myrow in dgv.Rows)
            {
                myrow.Cells[0].Value = selectall;
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            //获得当前选中的规则
            try
            {
            var myrow = dgv.SelectedRows[0];
            //将详情显示再文本内容中
            tb_content.Text = myrow.Cells["内容"].Value.ToString();

            }
            catch { }

        }

        private void Tb_content_TextChanged(object sender, EventArgs e)
        {
            //改变规则列表中 选中行的 内容
            var myrow =dgv.SelectedRows[0];
            myrow.Cells["内容"].Value = ((Control)sender).Text;
        }

        private void Tb_content_Leave(object sender, EventArgs e)
        {
            GetGuize();
        }

        private void cbb_format_DropDown(object sender, EventArgs e)
        {
            cbb_format.Items.Clear();
            var format = mycontroller.GetFormat();
            cbb_format.Items.AddRange(format);

        }
    }
}
