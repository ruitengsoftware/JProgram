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

using System.Text.RegularExpressions;
using RuiTengDll;
using WindowsFormsApp2.Controller;

namespace WindowsFormsApp2
{
    public partial class UCUpdateName : UserControl
    {
        public UCUpdateName()
        {
            InitializeComponent();
        }
        UIHelper mydrawer = new UIHelper();

        /// <summary>
        /// 点击开始按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnstart_Click(object sender, EventArgs e)
        {
            try
            {
                for (int m = 0; m < dgv_task.Rows.Count; m++)
                {


                    //获得目录下所有文件
                    string path = dgv_task.Rows[m].Cells["biaomingcheng"].Value.ToString();
                    string[] str_files = Directory.GetFiles(path);

                    for (int i = 0; i < str_files.Length; i++)
                    {
                        dgv_task.Rows[m].Cells["zhuangtai"].Value = (100 * Convert.ToDecimal(i + 1) / Convert.ToDecimal(str_files.Length)).ToString("00.00") + "%";

                        //判断是否为word文件
                        if (!str_files[i].Contains(".docx") && !str_files[i].Contains(".doc"))
                        {
                            continue;
                        }
                        //对每一个文件获得文件名
                        string filename = str_files[i];
                        //给文件改名
                        Dictionary<string, object> dic = new Dictionary<string, object>()
                        {
                            { "filename",filename},
                            { "fieldqian",tb_qian.Text },
                            {"fieldhou",tb_hou.Text }
                        };
                        string finalname = GaiMingSingle(dic);
                    }
                }
                //提示
                MessageBox.Show("修改名称成功");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }



        #region 可以写死的代码



        private void label7_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect(((Label)sender));
        }


        private void label1_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, -1);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, 1);
        }
        #endregion
        private void UCUpdateName_Load(object sender, EventArgs e)
        {
            cbbfield.Items.Clear();
            //加载文件切割格式名
            //var list_data=_mycontroller._sqlhelper.GetSingleField("totalname","tablesplit")
            //List<object> list_data = mysqliter.ExecuteRow("select distinct totalname from tablesplit", null, null);
            //加载批量改名文件名
            //获得所有的字段记录
            var list_data = _mycontroller._sqlhelper.GetSingleField("fieldname", "tablefield");
            cbbfield.Items.AddRange(list_data.ToArray());
        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbfield.Text;
            //打开数据库
            //删除数据
            _mycontroller._sqlhelper.DeleteAnyFormat("field", fieldstr, "tablefield");
            MessageBox.Show("删除数据成功！");

        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbfield.Text;
            //删除这条数据
            _mycontroller._sqlhelper.DeleteAnyFormat("field", fieldstr, "tablefield");
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("field", cbbfield.Text);
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tablefield");

            MessageBox.Show("保存数据成功！");

        }

        private void lbl_xuanze_Click(object sender, EventArgs e)
        {
            //选择目录
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                //显示目录
                string path = fbd.SelectedPath;
                tb_path.Text = path;
                //显示所有子目录
                dgv_task.Rows.Clear();
                //List<string> list_files = new List<string>();
                //GetFiles(new DirectoryInfo(path), "*.*", ref list_files);

                List<string> list_str = GetChildFolder(path);
                list_str.Insert(0, path);
                int index = 0;
                for (int i = 0; i < list_str.Count; i++)
                {
                    index = dgv_task.Rows.Add();
                    dgv_task.Rows[index].Cells[0].Value = index + 1;

                    dgv_task.Rows[index].Cells["biaomingcheng"].Value = list_str[i];
                    //获得文件夹所含文件数量

                    string[] str_files = Directory.GetFiles(list_str[i]);
                    dgv_task.Rows[index].Cells["jilushu"].Value = str_files.Length;

                }

            }

        }

        /// <summary>
        /// 获得文件夹下的所有目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string> GetChildFolder(string path)
        {
            List<string> list_result = new List<string>();
            string[] arr_directorys0 = Directory.GetDirectories(path);
            foreach (string str in arr_directorys0)
            {
                string[] arr_directorys1 = Directory.GetDirectories(str);
                if (arr_directorys1.Length == 0)
                {
                    list_result.Add(str);
                }
                else
                {
                    GetChildFolder(str);
                }
            }
            return list_result;
        }





        /// <summary>
        /// 获得指定目录下的所有文件，包括子目录
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="pattern"></param>
        /// <param name="fileList"></param>
        public void GetFiles(DirectoryInfo directory, string pattern, ref List<string> fileList)
        {
            if (directory.Exists || pattern.Trim() != string.Empty)
            {
                try
                {
                    foreach (FileInfo info in directory.GetFiles(pattern))
                    {
                        fileList.Add(info.FullName.ToString());
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                foreach (DirectoryInfo info in directory.GetDirectories())//获取文件夹下的子文件夹
                {
                    GetFiles(info, pattern, ref fileList);//递归调用该函数，获取子文件夹下的文件
                }
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击改名的保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label7_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbfield.Text;
            //打开数据库
            _mycontroller._sqlhelper.DeleteAnyFormat("fieldname", fieldstr, "tablefield");
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>() {
                { "fieldname", fieldstr},
                { "fieldqian", tb_qian.Text},
                { "fieldhou", tb_hou.Text}
            };
            //添加数据
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tablefield");
            MessageBox.Show("保存字段成功！");
        }
        /// <summary>
        /// 点击删除字段按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label8_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbfield.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("fieldname", fieldstr, "tablefield");
            MessageBox.Show("删除字段成功！");
        }
        /// <summary>
        /// 批量改名格式名称发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbfield_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string fieldstr = cbbfield.Text;
                //打开数据库
                Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"fieldname",fieldstr }
            };
                var list = _mycontroller._sqlhelper.GetAnySet("tablefield", mydic);
                Dictionary<string, object> dic = list[0];
                tb_qian.Text = dic["fieldqian"].ToString();
                tb_hou.Text = dic["fieldhou"].ToString();
            }
            catch { }
        }
        /// <summary>
        /// 修改单一文件命
        /// </summary>
        /// <param name="o">字典类型参数，保存文件名前后位置，以及添加字段</param>
        public string GaiMingSingle(object o)
        {

            Dictionary<string, object> dic = o as Dictionary<string, object>;

            string filename = dic["filename"].ToString();
            string fieldqian = dic["fieldqian"].ToString();
            string fieldhou = dic["fieldhou"].ToString();
            //判断是否为word文件
            if (!filename.Contains(".docx") && !filename.Contains(".doc"))
            {
                return string.Empty;
            }

            //对每一个文件获得文件名
            string oldname = Path.GetFileNameWithoutExtension(filename);
            oldname = Regex.Replace(oldname, @"\(", "\\(");
            oldname = Regex.Replace(oldname, @"\)", "\\)");

            string newfilename = string.Empty;
            if (!fieldqian.Trim().Equals(string.Empty))
            {
                newfilename = Regex.Replace(filename, oldname, fieldqian + "-" + oldname);
            }
            if (!fieldhou.Trim().Equals(string.Empty))
            {
                newfilename = Regex.Replace(newfilename, oldname, oldname + "-" + fieldhou);
            }
            //修改文件名
            //File.Move(filename, lujing + @"\" + newname + houzhui);
            newfilename = Regex.Replace(newfilename, @"\\\(", "(");
            newfilename = Regex.Replace(newfilename, @"\\\)", ")");

            Directory.Move(filename, newfilename);
            return newfilename;
        }
        ControllerUpdateName _mycontroller = new ControllerUpdateName();
        private void Cbbfield_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string fieldstr = cbbfield.Text;
                Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"fieldname",fieldstr },
            };
                var list = _mycontroller._sqlhelper.GetAnySet("tablefield", mydic);
                Dictionary<string, object> dic = list[0];
                tb_qian.Text = dic["fieldqian"].ToString();
                tb_hou.Text = dic["fieldhou"].ToString();

            }
            catch { }
        }

        private void Label7_Click_1(object sender, EventArgs e)
        {
            string fieldstr = cbbfield.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("fieldname", fieldstr, "tablefield");
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>() {
                { "fieldname", fieldstr},
                { "fieldqian", tb_qian.Text},
                { "fieldhou", tb_hou.Text}
            };
            //添加数据
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tablefield");
            MessageBox.Show("保存字段成功！");
        }

        private void Label8_Click_1(object sender, EventArgs e)
        {
            string fieldstr = cbbfield.Text;
            //打开数据库
            _mycontroller._sqlhelper.DeleteAnyFormat("fieldname", fieldstr, "tablefield");
            MessageBox.Show("删除字段成功！");
        }

        private void cbbfield_DropDown(object sender, EventArgs e)
        {
            cbbfield.Items.Clear();
            var list = _mycontroller._sqlhelper.GetSingleField("fieldname", "tablefield");
            cbbfield.Items.AddRange(list.ToArray()) ;
        }
    }
}
