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
using Model;
using Spire.Doc;
using WindowsFormsApp2.Controller;

namespace WindowsFormsApp2.UC
{
    public partial class UCYiZhanShi : UserControl
    {
        public UCYiZhanShi()
        {
            InitializeComponent();
        }

        private void UCYiZhanShi_Load(object sender, EventArgs e)
        {
            UC.UCStep myuc0 = new UCStep("格式调整");
            myflp.Controls.Add(myuc0);
            myuc0.lbl_text.Click += ControlAdd;
            UC.UCStep myuc1 = new UCStep("文件切割");
            myflp.Controls.Add(myuc1);
            myuc1.lbl_text.Click += ControlAdd;

            UC.UCStep myuc2 = new UCStep("文档生成");
            myflp.Controls.Add(myuc2);
            myuc2.lbl_text.Click += ControlAdd;

            UC.UCStep myuc3 = new UCStep("批量改名");
            myflp.Controls.Add(myuc3);
            myuc3.lbl_text.Click += ControlAdd;

        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.folderenter;
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.folderlv;

        }

        public void ControlAdd(object sender, EventArgs e/*Panel p,UserControl uc*/)
        {
            var lbl = sender as Label;
            var uc = lbl.Parent.Parent as UCStep;
            if (uc.lbl_text.Text.Equals("文档生成"))
            {
                UCyizhanshiwendangshengcheng myuc = new UCyizhanshiwendangshengcheng();
                myuc.Dock = DockStyle.Fill;
                mypanel.Controls.Clear();
                mypanel.Controls.Add(myuc);

            }
            else if (uc.lbl_text.Text.Equals("文件切割"))
            {
                UCyizhanshiqiege myuc = new UCyizhanshiqiege();
                myuc.Dock = DockStyle.Fill;

                mypanel.Controls.Clear();
                mypanel.Controls.Add(myuc);

            }
            else if (uc.lbl_text.Text.Equals("批量改名"))
            {
                UCyizhanshigaiming myuc = new UCyizhanshigaiming();
                myuc.Dock = DockStyle.Fill;

                mypanel.Controls.Clear();
                mypanel.Controls.Add(myuc);
            }
            else if (uc.lbl_text.Text.Equals("格式调整"))
            {
                UCyizhenshigeshitiaozheng myuc = new UCyizhenshigeshitiaozheng();
                myuc.Dock = DockStyle.Fill;

                mypanel.Controls.Clear();
                mypanel.Controls.Add(myuc);

            }
        }

        /// <summary>
        /// 将word保存为doc格式
        /// </summary>
        /// <param name="o"></param>
        public void SaveDoc(object o)
        {
            string file = o as string;
            //保存文档为doc格式
            string parent = Directory.GetParent(MySetting.Default.fieldirectory).FullName;
            string savedir = file.Replace(parent, "");
            if (!Directory.Exists(savedir))
            {
                Directory.CreateDirectory(savedir);
            }
            string filename = Path.GetFileNameWithoutExtension(file);
            string savepath = savedir + "\\" + filename + ".docx";
            Spire.Doc.Document mydoc = new Spire.Doc.Document();
            mydoc.SaveToFile(savepath, FileFormat.Docx);

            mydoc.Close();

            //去水印
            Aspose.Words.Document aspdoc = new Aspose.Words.Document(savepath);
            aspdoc.Sections[0].Body.Paragraphs.RemoveAt(0);
            aspdoc.Save(savedir + "\\" + filename + ".doc", Aspose.Words.SaveFormat.Doc);
            //删除docx文件
            File.Delete(savepath);
        }
        /// <summary>
        /// 将文件保存为docx格式的word文档
        /// </summary>
        /// <param name="o"></param>
        public void SaveDocx(object o)
        {
            string file = o as string;
            //保存文档为doc格式
            string parent = Directory.GetParent(MySetting.Default.fieldirectory).FullName;
            string savedir = file.Replace(parent, "");
            if (!Directory.Exists(savedir))
            {
                Directory.CreateDirectory(savedir);
            }
            string filename = Path.GetFileNameWithoutExtension(file);
            string savepath = savedir + "\\" + filename + ".docx";
            Spire.Doc.Document mydoc = new Document();
            mydoc.SaveToFile(savepath, FileFormat.Docx);

            mydoc.Close();

            //去水印
            Aspose.Words.Document aspdoc = new Aspose.Words.Document(savepath);
            aspdoc.Sections[0].Body.Paragraphs.RemoveAt(0);
            aspdoc.Save(savepath);
        }

        public delegate void DelProcessor(object o);
        DelProcessor myprocessor = null;
        /// <summary>
        /// 点击开始按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_start_Click(object sender, EventArgs e)
        {
            //获得所有文件夹
            string folder = tb_folder.Text;
            //获得
            //获得四个步骤的顺序
            
            for (int i = 0; i < myflp.Controls.Count; i++)
            {
                var uc = myflp.Controls[i] as UCStep;
                if (uc.lbl_text.Text == "批量改名")
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>() {
                        { "filename",dgv_task.Rows[0].Cells["wenjianjia"].Value.ToString()},
                        { "field","测试字段"},
                        { "qian",true}
                    };
                    myprocessor += GaiMingSingle;
                }

            }
            //对每一个文件夹进行操作



        }

        /// <summary>
        /// 文件切割方法
        /// </summary>
        /// <param name="o"></param>
        public void WenjianQiege(object o)
        {


        }



       /// <summary>
       /// 修改单一文件命
       /// </summary>
       /// <param name="o"></param>
        public void GaiMingSingle(object o)
        {
            Dictionary<string, object> dic = o as Dictionary<string, object>;

            string filename = dic["filename"].ToString();
            string field = dic["field"].ToString();
            bool qian = Convert.ToBoolean(dic["qian"]);
            //判断是否为word文件
            if (!filename.Contains(".docx") && !filename.Contains(".doc"))
            {
                return;
            }
            //对每一个文件获得文件名
            string file = Path.GetFileNameWithoutExtension(filename);
            string lujing = Path.GetDirectoryName(filename);
            string houzhui = Path.GetExtension(filename);
            //形成新的文件名
            string newname = string.Empty;
            if (qian)
            {
                newname = field + "-" + file;
            }
            else
            {
                newname = file + "-" + field;
            }
            //修改文件名
            //File.Move(filename, lujing + @"\" + newname + houzhui);
            Directory.Move(filename, lujing + @"\" + newname + houzhui);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                tb_save.Text = fbd.SelectedPath;
            }
        }
        ControllerYizhanshi _mycontroller = new ControllerYizhanshi();
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_folder.Text = fbd.SelectedPath;
                //在任务列表显示所有文件夹
                //FileHelper.GetFile(fbd.SelectedPath, ".xlsx");
               _mycontroller.GetDir(fbd.SelectedPath);
                //list加载到dgv
                Update(_mycontroller.list_dir);
               
            }

        }

        public void Update(List<FileInfo> list)
        {
            int index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                index = dgv_task.Rows.Add();
                dgv_task.Rows[index].Cells["xuhao"].Value = index + 1;
                dgv_task.Rows[index].Cells["wenjianjia"].Value = list[i].FullName;
            }
        }
        public void Update(List<string> list)
        {
            int index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                index = dgv_task.Rows.Add();
                dgv_task.Rows[index].Cells["xuhao"].Value = index + 1;
                dgv_task.Rows[index].Cells["wenjianjia"].Value = list[i];
            }
        }



    }
}
