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
using WindowsFormsApp2.Controller;
using RuiTengDll;

namespace WindowsFormsApp2.UC
{
    public partial class UCFenlei : UserControl
    {

        ControllerFenlei _mycontroller = new ControllerFenlei();

        public UCFenlei()
        {
            InitializeComponent();
        }

        private void Lbl_addtask_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;


                //获得path下的所有文件夹名称
                _mycontroller._list_directories.Clear();
                _mycontroller.GetChildDirectory(path);
                //_mycontroller._list_directories.Reverse();
                dgv_task.Rows.Clear();

                for (int i = 0; i < _mycontroller._list_directories.Count; i++)
                {
                    string mypath = _mycontroller._list_directories[i];
                    int index = dgv_task.Rows.Add();
                    dgv_task.Rows[index].Cells["xuhao"].Value = i + 1;
                    dgv_task.Rows[index].Cells["wenjianjiamingcheng"].Value = mypath;
                    DirectoryInfo mydi = new DirectoryInfo(mypath);
                    dgv_task.Rows[index].Cells["shuliang"].Value = mydi.GetFiles().Length;

                }

            }
        }




        private void Tb_shuliang_Leave(object sender, EventArgs e)
        {
            int shuliang = Convert.ToInt32(tb_shuliang.Text);
            if (shuliang > 100000)
            {
                tb_shuliang.Text = "100000";
            }
        }
        ControllerFenlei mycontroller = new ControllerFenlei();
        private void UCFenlei_Load(object sender, EventArgs e)
        {
          
            splitContainer2.Panel2Collapsed = true;
        }

        private void Lbl_baocun_Click(object sender, EventArgs e)
        {
            string formatname = cbb_geshi.Text;
            mycontroller.DeleteFormat(formatname);
            Dictionary<string, object> dic_muban = new Dictionary<string, object>() {
                {"模板名称",formatname },
                {"剪切数量",tb_shuliang.Text},
                { "剪切路径",tb_jianqiedao.Text},
                {"默认",cb_moren.Checked },
                {"新文件夹",tb_wenjianjia.Text }
            };
            mycontroller.SaveFormat(dic_muban);
            MessageBox.Show($"格式 {formatname} 已保存成功！");
        }

        private void Pb_rizhi_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_jianqiedao.Text = fbd.SelectedPath; ;

            }
        }

        private void Lbl_shanchu_Click(object sender, EventArgs e)
        {
            string formatname = cbb_geshi.Text;
            mycontroller.DeleteFormat(formatname);
            MessageBox.Show($"格式 {formatname} 已删除成功！");
            var format = mycontroller.GetFormat();
            cbb_geshi.Items.Clear();
            cbb_geshi.Items.AddRange(format);
            try
            {
                cbb_geshi.SelectedIndex = 0;
            }
            catch
            {
                cbb_geshi.Text = string.Empty;
            }
        }

        private void Cbb_geshi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_setting = cbb_geshi.Text;
            var dic_setting = mycontroller.GetMuBan(str_setting);
            Dictionary<string, object> dic = dic_setting as Dictionary<string, object>;
            //获得日志路径，赋值到tb_rizhilujing
            string rizhilujing = dic["剪切路径"].ToString();
            tb_jianqiedao.Text = rizhilujing;
            //cb_wenjianming赋值
            tb_shuliang.Text = dic["剪切数量"].ToString();
            cb_moren.Checked = Convert.ToBoolean(dic["默认"]);
            tb_wenjianjia.Text = dic["新文件夹"].ToString();




        }

        private void Cb_zhengwen_CheckedChanged(object sender, EventArgs e)
        {
            //如果未选中，文件名文本框不可用
            if (cb_moren.Checked)
            {
                tb_wenjianjia.Enabled = false;
            }
            else
            {
                tb_wenjianjia.Enabled = true;
            }
        }
        bool _stopchuli = false;
        private void Lbl_stop_Click(object sender, EventArgs e)
        {
            _stopchuli = true;

        }

        private void Lbl_clear_Click(object sender, EventArgs e)
        {
            dgv_task.Rows.Clear();
        }

        private void Lbl_start_Click(object sender, EventArgs e)
        {
            Action a = () =>
            {
                _list_files.Clear();
                _shuliang = Convert.ToInt32(tb_shuliang.Text);
                _path = tb_jianqiedao.Text;
                _mycontroller._moren = cb_moren.Checked;
                if (_mycontroller._moren)
                {
                    _wenjianjia = ((new DirectoryInfo(dgv_task.Rows[0].Cells["wenjianjiamingcheng"].Value.ToString()).Name));
                }
                else
                {
                    _wenjianjia = tb_wenjianjia.Text;
                }

                List<string> list_shengyu = new List<string>();
                for (int i = 0; i < dgv_task.Rows.Count; i++)
                {
                    string filepath = dgv_task.Rows[i].Cells["wenjianjiamingcheng"].Value.ToString();
                    //判断i是不是最后一行，如果是的话，还需要保存剩余文件
                    if (i != dgv_task.RowCount - 1)
                    {
                        FenLei(filepath, i);
                    }
                    else
                    {
                        FenLei(filepath, i);
                        _mycontroller.MoveLast();
                    }
                    dgv_task.Rows[i].Cells["状态"].Value = "已完成";
                }
            };
            a.BeginInvoke(o =>
            {
                MessageBox.Show("分类完成！");
            }, null);
        }

        List<string> _list_files = new List<string>();
        int _shuliang = 0;
        string _wenjianjia = string.Empty;
        public int _foldernum = 0;
        string _path = string.Empty;

        /// <summary>
        /// 分类方法
        /// </summary>
        /// <param name="filename"></param>
        public void FenLei(string filename, int rowindex)
        {

            List<string> list_files = new List<string>();
            //循环每一个文件夹

            dgv_task.Rows[rowindex].Cells["状态"].Value = "提取文件中……";
            //获得文件夹内的文件
            DirectoryInfo mydi = new DirectoryInfo(filename);
            var arr_files = mydi.GetFiles();
            for (int k = 0; k < arr_files.Length; k++)
            {
                _list_files.Add(arr_files[k].FullName);
            }

            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
            for (int i = 0; i < _list_files.Count; i++)
            {
                //获得当前序号除1000的余数
                int index = i / _shuliang + 1;
                if (!dic.ContainsKey(index))
                {
                    dic.Add(index, new List<string>());
                }
                dic[index].Add(_list_files[i]);
            }
            int num = 0;
            //判断文件数量，如果等于_shuliang，那么移动否则添加到剩余的文件中
            foreach (KeyValuePair<int, List<string>> kv in dic)
            {
                num++;
                dgv_task.Rows[rowindex].Cells["状态"].Value = $"{(num * 100 / dic.Count).ToString("00.00")}%";

                if (kv.Value.Count == _shuliang)
                {
                    string folder = _wenjianjia;
                    _foldernum++;
                    //构造文件夹，如果存在则不需要
                    //判断文件夹内文件夹的数量
                    string path = $"{_path}\\{folder}-{_shuliang}-{(_foldernum).ToString("00")}-{DateTime.Now.ToString("yyyyMMdd")}";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    for (int i = 0; i < kv.Value.Count; i++)
                    {
                        string str_file = kv.Value[i];

                        //将源文件复制到这个文件夹
                        try
                        {
                            File.Move(str_file, $"{path}\\{Path.GetFileName(_list_files[i])}");

                        }
                        catch { }
                    }
                }
                else//加入剩余文件集合
                {
                    _list_files.Clear();
                    for (int i = 0; i < kv.Value.Count; i++)
                    {
                        string str_file = kv.Value[i];
                        //将源文件复制到这个文件夹
                        _list_files.Add(str_file);
                    }
                }
            }
            //如果最后一个文件夹中的文件数量也是_shuliang，那么_list_files清空
            if (dic.Count!=0 && dic.Values.Last().Count==_shuliang)
            {
                _list_files.Clear();
            }

        }


        /// <summary>
        /// 移动所剩下得文件
        /// </summary>
        public void MoveLast()
        {
            //判断剩余文件数量，如果为0，跳出方法
            if (_list_files.Count == 0)
            {
                return;
            }
            string folder = _wenjianjia;
            //判断保存路径文件夹内文件夹的数量
            string path = $"{_path}\\{folder}-{_shuliang}-{(_foldernum + 1).ToString("00")}-{DateTime.Now.ToString("yyyyMMdd")}";
            Directory.CreateDirectory(path);
            for (int i = 0; i < _list_files.Count; i++)
            {
                string str_file = _list_files[i];
                //将源文件复制到这个文件夹
                File.Move(str_file, $"{path}\\{Path.GetFileName(_list_files[i])}");
            }
        }




        UIHelper UIHelper = new UIHelper();
        private void Lbl_baocun_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void Lbl_baocun_MouseEnter(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void Lbl_baocun_MouseLeave(object sender, EventArgs e)
        {
            int m = ((Control)sender).Margin.Top;
            UIHelper.UpdateCSize((Control)sender,1);
        }

        private void Pb_rizhi_MouseEnter(object sender, EventArgs e)
        {
            pb_rizhi.Image = Properties.Resources.folderenter;
        }

        private void Pb_rizhi_MouseLeave(object sender, EventArgs e)
        {
            pb_rizhi.Image = Properties.Resources.folderlv;

        }

        private void cbb_geshi_DropDown(object sender, EventArgs e)
        {
            cbb_geshi.Items.Clear();
            var format = mycontroller.GetFormat();
            cbb_geshi.Items.AddRange(format);

        }
    }
}
