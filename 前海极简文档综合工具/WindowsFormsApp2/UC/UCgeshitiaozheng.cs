using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Text.RegularExpressions;
using System.IO;
using Spire.Doc.Documents;
using Spire.Doc.Collections;
using Spire.Doc;
using Spire.Doc.Fields;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Aspose.Words;
using WindowsFormsApp2.UC;
using WindowsFormsApp2.Controller;
using RuiTengDll;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.CryptoPro;
using System.Drawing.Design;
using Aspose.Words.Replacing;

namespace WindowsFormsApp2
{
    public partial class UCgeshitiaozheng : UserControl
    {
        UIHelper mydrawer = new UIHelper();
        WordHelper myworder = new WordHelper();

        public UCgeshitiaozheng()
        {
            InitializeComponent();

        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            mydrawer.DrawRoundRect(((Label)sender));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 从yc控件中获得format
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public Format GetFormat(Control c)
        {
            UCFormat myformat = c as UCFormat;
            Format format = new Format();
            //获得粗体值
            format.bold = myformat.cbbold.Checked ? 1 : 0;
            //获得字体名
            format.fontname = myformat.tbfontname.Text;
            //获得字体大小
            format.fontsize = Convert.ToSingle(myformat.nudfontsize.Value);
            //获得行距类型
            format.lstype = myformat.cbblstype.Text;
            //获得行距固定值
            format.lsvalue = Convert.ToSingle(myformat.nudlsvalue.Value);
            //获得居中设置
            format.juzhong = myformat.cbbposition.Text;
            //获得空行数量
            format.space = Convert.ToInt16(myformat.cbbspace.Text);
            //获得缩进值
            format.suojin = Convert.ToSingle(myformat.nudsuojin.Value);
            //获得格式名称
            format.formatname = myformat.cbbformat.Text;
            //是否启用
            format.enable = myformat.cbenable.Checked;
            return format;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin - 1));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, new Padding(margin + 1));
        }

        /// <summary>
        /// 调整word文档中内容的格式
        /// </summary>
        /// <param name="filepath">word文件名</param>
        public void TiaozhengGeshi(object o)
        {

        }
        /// <summary>
        /// 将word保存为doc格式
        /// </summary>
        /// <param name="o"></param>
        public string SaveDoc(object o)
        {
            string file = o as string;
            Spire.Doc.Document mydoc = new Spire.Doc.Document();

            mydoc.LoadFromFile(file);
            //判断当前文档格式
            string houzhui = Path.GetExtension(file);
            string savepath0 = string.Empty;
            //把全部文档转换成docx格式
            if (houzhui.Equals(".doc"))
            {
                //保存文档为docx格式
                string savedir = Directory.GetParent(file).FullName;
                string filename = Path.GetFileNameWithoutExtension(file);
                file = savedir + "\\" + filename + ".docx";

                mydoc.SaveToFile(file, Spire.Doc.FileFormat.Docx);
                mydoc.Close();
            }
            //去水印, aspose只能操作 docx
            Aspose.Words.Document aspdoc = new Aspose.Words.Document(file);
            aspdoc.Sections[0].Body.Paragraphs.RemoveAt(0);
            //构造doc文件名
            string newfile = Regex.Replace(file, @"docx", "doc");
            aspdoc.Save(newfile, Aspose.Words.SaveFormat.Doc);
            //删除docx文件
            File.Delete(file);
            return newfile;
        }
        /// <summary>
        /// 将文件保存为docx格式的word文档
        /// </summary>
        /// <param name="o"></param>
        public string SaveDocx(object o)
        {
            string file = o as string;
            Spire.Doc.Document mydoc = new Spire.Doc.Document();

            mydoc.LoadFromFile(file);

            //判断当前文档格式
            string houzhui = Path.GetExtension(file);
            string savepath0 = string.Empty;
            //把全部文档转换成docx格式
            if (houzhui.Equals(".doc"))
            {
                //保存文档为docx格式
                string savedir = Directory.GetParent(file).FullName;
                string filename = Path.GetFileNameWithoutExtension(file);
                file = savedir + "\\" + filename + ".docx";
                mydoc.SaveToFile(file, Spire.Doc.FileFormat.Docx);
                mydoc.Close();
            }
            //去水印
            Aspose.Words.Document aspdoc = new Aspose.Words.Document(file);
            aspdoc.Sections[0].Body.Paragraphs.RemoveAt(0);
            aspdoc.Save(file);
            return file;
        }
        /// <summary>
        /// 点击批量doc按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label6_Click(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// 点击批量docx按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbfolder.Text = fbd.SelectedPath;
                //显示所有子目录
                dgv_task.Rows.Clear();
                //List<string> list_files = new List<string>();
                //GetFiles(new DirectoryInfo(path), "*.*", ref list_files);

                List<string> list_dir = GetChildFolder(fbd.SelectedPath);

                int index = 0;
                for (int i = 0; i < list_dir.Count; i++)
                {
                    index = dgv_task.Rows.Add();
                    dgv_task.Rows[index].Cells[0].Value = index + 1;

                    dgv_task.Rows[index].Cells["wenjianjiaming"].Value = list_dir[i];
                    //获得文件夹所含文件数量

                    string[] str_files = Directory.GetFiles(list_dir[i]);
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
            List<string> list = new List<string>();
            var child = Directory.GetDirectories(path);
            if (child.Length > 0)
            {
                foreach (string item in child)
                {
                    list.AddRange(GetChildFolder(item));

                }
                list.Insert(0, path);
                return list;
            }
            else
            {
                list.Add(path);
                return list;
            }



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    tbpath.Text = fbd.SelectedPath;
            //}

        }
        /// <summary>
        /// 点击保存页边距按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblsave_Click(object sender, EventArgs e)
        {
            //从数据库读取所有页边距格式
            Dictionary<string, object> dic = new Dictionary<string, object>() {
                {"left", nudleft.Value},
                {"right", nudright.Value},
                {"top", nudtop.Value},
                {"bottom", nudbottom.Value},
                {"name",cbbbianju.Text }
            };
            _mycontroller.SaveYebianjuFormat(dic);
            MessageBox.Show("保存格式成功！");
        }
        /// <summary>
        /// 下拉边距格式时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbbianju_DropDown(object sender, EventArgs e)
        {
            cbbbianju.Items.Clear();
            List<string> list = _mycontroller.GetFormat("name", "tablepagemargin");
            cbbbianju.Items.AddRange(list.ToArray());

        }
        /// <summary>
        /// 更改边距格式时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbbianju_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = _mycontroller.GetBianjuSet(cbbbianju.Text);
            nudleft.Value = Convert.ToDecimal(dic["left"]);
            nudright.Value = Convert.ToDecimal(dic["right"]);
            nudtop.Value = Convert.ToDecimal(dic["top"]);
            nudbottom.Value = Convert.ToDecimal(dic["bottom"]);
        }

        private void btnfont0_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 点击页脚选择字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfont1_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 点击选择字体按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfont0_Click_1(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 点击删除页眉按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblymshanchu_Click(object sender, EventArgs e)
        {


        }
        /// <summary>
        /// 点击保存页眉按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblymbaocun_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///选择页眉名称下拉框时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbymname_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 切换页脚名称时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbyjname_SelectedIndexChanged(object sender, EventArgs e)
        {
        }        /// <summary>
                 /// 点击保存页脚按钮时触发的事件，保存页脚
                 /// </summary>
                 /// <param name="sender"></param>
                 /// <param name="e"></param>
        private void lblyjbaocun_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 点击删除页脚时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblyjshanchu_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 切换总体格式名称时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbzongtigeshi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击开始转换按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblbaocun_Click(object sender, EventArgs e)
        {
            Global.dt_wrong = new DataTable();
            //判断输出路径是否存在
            //string importpath = tbpath.Text;
            //if (!Directory.Exists(importpath))
            //{
            //    MessageBox.Show("保存路径不存在！");
            //    return;
            //}
            #region 获得用于调整word格式的设置
            Dictionary<string, Format> dic_format = new Dictionary<string, Format>();
            Control mytab = null;

            //获得正文格式
            mytab = mytabcontrol.TabPages[2].Controls[0];
            dic_format.Add("正文", GetFormat(mytab));
            //获得 大标题格式
            mytab = mytabcontrol.TabPages[0].Controls[0];
            dic_format.Add("大标题", GetFormat(mytab));


            //获得副标题
            mytab = mytabcontrol.TabPages[1].Controls[0];
            dic_format.Add("副标题", GetFormat(mytab));


            //获得一级标题格式
            mytab = mytabcontrol.TabPages[3].Controls[0];
            dic_format.Add("一级标题", GetFormat(mytab));

            //获得二级标题格式
            mytab = mytabcontrol.TabPages[4].Controls[0];
            dic_format.Add("二级标题", GetFormat(mytab));

            //获得三级标题格式
            mytab = mytabcontrol.TabPages[5].Controls[0];
            dic_format.Add("三级标题", GetFormat(mytab));

            #endregion

            //增加异常原因列到dt_wrong中去
            Global.dt_wrong.Columns.Add("文件名");

            Global.dt_wrong.Columns.Add("异常原因");
            //开始生成，同时更新任务列表信息
            Global.run = true;
            for (int m = 0; m < dgv_task.Rows.Count; m++)
            {
                //获得任务列表中每一行的文件夹
                string wordpath = dgv_task.Rows[m].Cells["wenjianjiaming"].Value.ToString();
                //获得文件夹下的word文档名
                //List<FileInfo> files = FileHelper.GetFile(wordpath, ".dox.docx");
                List<string> files = Directory.GetFiles(wordpath, "*").ToList();

                //刷新显示任务记录数
                dgv_task.Rows[m].Cells["jilushu"].Value = files.Count.ToString();

                //对每一行，生成word,返回文件名
                for (int p = 0; p < files.Count; p++)
                {
                    string currentfile = files[p];
                    //string savepath = tbpath.Text;
                    //string currentfile = savepath + "\\" + Path.GetFileName(originalpath);
                    //File.Move(originalpath, currentfile);
                    if (!Global.run)
                    {
                        MessageBox.Show("任务已终止！");
                        break;
                    }
                    //计算百分比
                    string baifenbi = (Convert.ToDouble(p + 1) * 100 / Convert.ToDouble(files.Count)).ToString("00.00") + "%";
                    //将进度赋值给任务列表
                    dgv_task.Rows[m].Cells["zhuangtai"].Value = baifenbi;
                    Application.DoEvents();
                    try
                    {
                        //判断是否对word进行格式调整
                        if (cb_qiyong.Checked)
                        {
                            Dictionary<string, object> dic2 = new Dictionary<string, object>() {
                                {"filename",  currentfile},
                                { "format",dic_format},
                            };
                            currentfile = UpdateFormat2(dic2);
                        }
                        //判断是否调整页脚页眉和页码
                        if (cb_qiyongymyj.Checked)
                        {
                            //调整finalfile的页眉页脚和页码
                            currentfile = UpdateHeaderFooter(currentfile);

                            //currentfile = UpdateHeaderFooterDefault(currentfile);
                        }
                        //判断是否进行文本标注
                        var biaozhucontroller = (tabControl1.TabPages["wenbenbiaozhu"].Controls[0] as UCBiaozhu).mycontroller;
                        bool b = biaozhucontroller._enable;
                        if (b)
                        {
                            biaozhucontroller.WenbenBiaozhu(currentfile);
                        }

                    }
                    catch (Exception ex)
                    {
                        //获得一个dt_wrong的新行newrow

                        var newrow = Global.dt_wrong.NewRow();
                        newrow["文件名"] = files[p];
                        newrow["异常原因"] = ex.Message;
                        Global.dt_wrong.Rows.Add(newrow);
                        //跳过该行
                        continue;
                    }

                }
                dgv_task.Rows[m].Cells["zhuangtai"].Value = "已完成";
            }
        }







        /// <summary>
        /// 修改页眉页脚页码
        /// </summary>
        /// <param name="myfile"></param>
        /// <returns></returns>
        private string UpdateHeaderFooter(string myfile)
        {
            Aspose.Words.Document mydoc = new Aspose.Words.Document(myfile);
            DocumentBuilder builder = new DocumentBuilder(mydoc);
            Aspose.Words.SectionCollection sections = mydoc.Sections;


            /*设置页眉*/
            if (cbqiyongyemei.Checked)
            {

                //builder.PageSetup.PageNumberStyle = NumberStyle.GB1;
                //    builder.InsertField("PAGE", "");
                // Add any custom text
                //builder.Write(" / ");
                // Add field for total page numbers in document
                //builder.InsertField("NUMPAGES", "");
                // 光标移动到页眉,并设置页眉的居中
                builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.HeaderPrimary);

                if (cbbjuzhong0.Text.Equals("左对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                }
                else if (cbbjuzhong0.Text.Equals("居中"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                }
                else if (cbbjuzhong0.Text.Equals("右对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                }
                builder.Write(tbcontent0.Text);
                builder.Font.NameBi = tbfontname0.Text;
                builder.Font.SizeBi = Convert.ToDouble(nudfontsize0.Value);
                builder.Font.BoldBi = cbymbold.Checked;
            }
            /*设置页脚*/
            if (cbqiyongyejiao.Checked)
            {

                builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
                // 光标移动到页眉,并设置页眉的居中
                if (cbbjuzhong1.Text.Equals("左对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                }
                else if (cbbjuzhong1.Text.Equals("居中"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                }
                else if (cbbjuzhong1.Text.Equals("右对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                }
                builder.Font.NameBi = tbfontname1.Text;
                builder.Font.SizeBi = Convert.ToDouble(nudfontsize1.Value);
                builder.Font.BoldBi = cbyjbold.Checked;
                var newpara = builder.InsertParagraph();
                builder.MoveTo(newpara);
                builder.Write(tbcontent1.Text);
            }
            /*设置页码*/
            if (cbpage.Checked)
            {
                ////光标定位到页脚
                builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
                //判断是否已经包含页码字样，如果是，跳出判断
                string str_yemau = builder.CurrentSection.GetText();
                if (!str_yemau.Contains("PAGE") && !str_yemau.Contains("NUMPAGES"))
                {

                    //设置页码居中样式
                    if (cbb_yemajuzhong.Text.Equals("左对齐"))
                    {
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                    }
                    else if (cbb_yemajuzhong.Text.Equals("居中"))
                    {
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                    }
                    else if (cbb_yemajuzhong.Text.Equals("右对齐"))
                    {
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                    }
                    var newpara = builder.InsertParagraph();
                    builder.MoveTo(newpara);
                    //判断
                    //设置页码格式并插入页码
                    if (cbb_yangshi.Text.Equals("1、2……"))
                    {
                        builder.InsertField("PAGE", "");
                    }
                    else if (cbb_yangshi.Text.Equals("-1-"))
                    {
                        builder.Write("- ");
                        builder.InsertField("PAGE", "");

                        builder.Write(" -");

                    }
                    else if (cbb_yangshi.Text.Equals("第 1 页，第 2 页……"))
                    {
                        builder.Write("第 ");
                        builder.InsertField("PAGE", "");

                        builder.Write(" 页");

                    }
                    else if (cbb_yangshi.Text.Equals("第 1 页，共 2 页……"))
                    {
                        builder.Write("第 ");
                        builder.InsertField("PAGE", "");
                        builder.Write(" 页，");
                        builder.Write("共 ");
                        builder.InsertField("NUMPAGES", "");
                        builder.Write(" 页");

                    }
                    else if (cbb_yangshi.Text.Equals("1/N,2/N……"))
                    {
                        //builder.InsertField("PAGE", "");
                        builder.InsertField(Aspose.Words.Fields.FieldType.FieldPage, true);

                        builder.Write("/");
                        builder.InsertField(Aspose.Words.Fields.FieldType.FieldNumPages, true);

                        //builder.InsertField("NUMPAGES", "");

                    }
                    //设置页码字体
                    if (cbb_fontformat.Text.Equals("1、2、3……"))
                    {
                        builder.PageSetup.PageNumberStyle = NumberStyle.Arabic;
                    }
                    else if (cbb_fontformat.Text.Equals("Ⅰ、Ⅱ、Ⅲ……"))
                    {
                        builder.PageSetup.PageNumberStyle = NumberStyle.UppercaseRoman;

                    }
                    else if (cbb_fontformat.Text.Equals("a、b、c……"))
                    {
                        builder.PageSetup.PageNumberStyle = NumberStyle.LowercaseLetter;

                    }
                    else if (cbb_fontformat.Text.Equals("A、B、C……"))
                    {
                        builder.PageSetup.PageNumberStyle = NumberStyle.UppercaseLetter;

                    }
                }
            }
            //删除页脚多余的空行
            builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
            builder.CurrentSection.HeadersFooters[0].Paragraphs.RemoveAt(0);
            mydoc.Save(myfile);
            return myfile;

        }
        /// <summary>
        /// 在不选择启用页码的情况下加载页码
        /// </summary>
        /// <param name="myfile"></param>
        /// <returns></returns>
        private string UpdateHeaderFooterDefault(string myfile)
        {
            Aspose.Words.Document mydoc = new Aspose.Words.Document(myfile);
            DocumentBuilder builder = new DocumentBuilder(mydoc);
            //Aspose.Words.SectionCollection sections = mydoc.Sections;

            ////光标定位到页脚
            builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);

            //判断是否已经包含页脚
            string str_yemau = builder.CurrentSection.Range.Text;
            if (!str_yemau.Contains("PAGE") && !str_yemau.Contains("NUMPAGES"))
            {

                //设置页码居中样式
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                builder.InsertField("PAGE", "");
                builder.Write("/");
                builder.InsertField("NUMPAGES", "");
                //设置页码字体
                builder.PageSetup.PageNumberStyle = NumberStyle.Arabic;
            }
            mydoc.Save(myfile);

            return myfile;
        }

        /// <summary>
        /// 已段落为单位调整格式的方法
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string UpdateFormat2(object o)
        {
            Jdoc myjdoc = new Jdoc();
            Jpara myjpara = new Jpara();
            bool _existdabiaoti = false;
            bool _existfubiaoti = false;
            var dic = o as Dictionary<string, object>;
            string file = dic["filename"].ToString();
            Dictionary<string, Format> dic_format = dic["format"] as Dictionary<string, Format>;

            Aspose.Words.Document mydoc = new Aspose.Words.Document(file);
            var paras = mydoc.FirstSection.Body.Paragraphs;//获得文档所有的自然段
            for (int i = 0; i < paras.Count; i++)
            {
                //去掉段内的空格              
                var para = paras[i];
                para.Range.Replace(new Regex(@"\s"), "",new FindReplaceOptions());
                string str_text = para.Range.Text;
                myjpara = new Jpara();
                if (para.ParagraphFormat.Alignment == ParagraphAlignment.Center && !_existdabiaoti)
                {
                    _existdabiaoti = true;
                    SetParaFormat(para, dic_format["大标题"]);
                    continue;
                }
                //判断自然段是否为大标题
                bool bb1 = Regex.IsMatch(str_text, "^(第一编|第一章).*");//是否以指定文字开头
                //var bb2 = Regex.IsMatch(str_text, @"\s\S+[。.；;！!，,：:……~'”‘’？?""“]$");//是否以符号结尾
                if (bb1)
                {
                    SetParaFormat(para, dic_format["大标题"]);
                    continue;
                }
                //判断自然段是否为副标题
                if (para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                {
                    bool b1 = Regex.IsMatch(str_text, @"^(第一节|目\s*录|前\s*言)");//是否以指定文字开头
                    bool b2 = Regex.IsMatch(str_text, @"\s\S+[。.；;！!，,：:……~'”‘’？?""“]$");//是否以符号结尾
                    if (_existdabiaoti && b1 && !b2)
                    {
                        //myjpara._leixing = "副标题";
                        //myjdoc._existfubiaoti = true;
                        //myjpara._asposepara = para;
                        _existfubiaoti = true;
                        SetParaFormat(para, dic_format["副标题"]);
                        continue;
                    }
                }
                //判断是否是正文或各级标题
                if (para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                {
                    SetStrFormat(para, dic_format);

                }
                //myjdoc._jparacollection.Add(myjpara);
            }
            /*设置页边距*/
            if (cbqiyong.Checked)
            {
                var sections = mydoc.Sections;
                for (int i = 0; i < sections.Count; i++)
                {
                    //页边距 
                    sections[i].PageSetup.LeftMargin = Convert.ToSingle(nudleft.Value);
                    sections[i].PageSetup.RightMargin = Convert.ToSingle(nudright.Value);
                    sections[i].PageSetup.TopMargin = Convert.ToSingle(nudtop.Value);
                    sections[i].PageSetup.BottomMargin = Convert.ToSingle(nudbottom.Value);
                }
            }

            //保存一次

            //mydoc.Save(file);

            string finalfile = string.Empty;
            //再次保存为指定格式
            if (rbdoc.Checked)
            {
                mydoc.Save(file, SaveFormat.Doc);
                //finalfile = SaveDoc(file);
            }
            else
            {
                mydoc.Save(file, SaveFormat.Docx);

                // finalfile = SaveDocx(file);
            }
            return file;
        }
        /// <summary>
        /// 调整段落内的各段匹配文字的样式
        /// </summary>
        /// <param name="mypara"></param>
        /// <param name="dic_format"></param>
        public void SetStrFormat(Aspose.Words.Paragraph mypara, Dictionary<string, Format> dic_format)
        {
            Regex regex = null;
            //格式的设置包括那几个方面，字体大小，字体名称，斜体，加粗，倾斜，下划线等,缩进，对齐，行距值
            //1、将整个段落的格式设置成正文
            //获得正文格式
            SetParaFormat(mypara, dic_format["正文"]);
            //2、提取一级标题，设置格式
            FindReplaceOptions options = new FindReplaceOptions();
            options.Direction = FindReplaceDirection.Backward;
            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(dic_format["一级标题"].fontname, dic_format["一级标题"].fontsize, dic_format["三级标题"].bold == 1 ? true : false);
            regex = new Regex(@"((?<!。).)*[一二三四五六七八九十]、[\s\S]*$", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);



            //3、提取二级标题，设置格式
            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(dic_format["二级标题"].fontname, dic_format["二级标题"].fontsize, dic_format["三级标题"].bold == 1 ? true : false);
            regex = new Regex(@"^[（\(][一二三四五六七八九十][\)）][\s\S]*$", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);


            //4、提取三级标题，设置格式

            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(dic_format["三级标题"].fontname, dic_format["三级标题"].fontsize, dic_format["三级标题"].bold == 1 ? true : false);
            regex = new Regex(@"第[一二三四五六七八九十]+?[,，][\s\S]*", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@"第[\s\S]+?[条款项][\s\S]*");
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@"^(首先|其次)[\s\S]*");
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@".*?是要[\s\S]*");
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@"（\([123456789]\)）[\s\S]*");
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@"^[①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳㉑㉒㉓㉔㉕㉖㉗㉘㉙㉚㉛㉜㉝㉞㉟㊱㊲㊳㊴㊵㊶㊷㊸㊹㊺㊻㊼㊽㊾㊿][\s\S]*");
            mypara.Range.Replace(regex, "", options);



        }

        /// <summary>
        /// 设置自然段的格式，包括字体，字号，粗体，缩进，对齐方式，行间距等
        /// </summary>
        /// <param name="mypara"></param>
        /// <param name="f"></param>
        public void SetParaFormat(Aspose.Words.Paragraph mypara, Format f)
        {
            Run myrun = mypara.Runs[0];

            if (!f.enable || myrun == null)
            {
                return;
            }

            //mypara.ParagraphFormat.Style.Font.Name = f.fontname;//设置字体
            myrun.Font.Name = f.fontname;                                               //设置字号
            //mypara.ParagraphFormat.Style.Font.Size = f.fontsize;
            myrun.Font.Size = f.fontsize;
            //设置 粗体
            //mypara.ParagraphFormat.Style.Font.Bold = f.bold == 1;
            myrun.Font.Bold = f.bold == 1;
            //设置缩进
            //mypara.ParagraphFormat.FirstLineIndent = f.suojin;

            myrun.ParentParagraph.ParagraphFormat.FirstLineIndent = f.suojin;
            //设置对齐
            string juzhong = f.juzhong;
            if (juzhong != null)
            {
                if (juzhong == "左对齐")
                {
                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                    myrun.ParentParagraph.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                }
                else if (juzhong == "居中")
                {
                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                    myrun.ParentParagraph.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                }
                else if (juzhong == "右对齐")
                {
                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                    myrun.ParentParagraph.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                }
            }
            //设置空行
            //设置行距值
            //mypara.ParagraphFormat.LineSpacingRule = Aspose.Words.LineSpacingRule.Exactly;
            myrun.ParentParagraph.ParagraphFormat.LineSpacingRule = Aspose.Words.LineSpacingRule.Exactly;

            // mypara.ParagraphFormat.LineSpacing = f.lsvalue;
            myrun.ParentParagraph.ParagraphFormat.LineSpacing = f.lsvalue;

        }



        /// <summary>
        /// 调整word的格式
        /// </summary>
        /// <param name="o">word文件名</param>
        public string UpdateFormat(object o)
        {
            var dic = o as Dictionary<string, object>;
            string file = dic["filename"].ToString();
            Dictionary<string, Format> dic_format = dic["format"] as Dictionary<string, Format>;
            //用spire打开文件
            Spire.Doc.Document mydoc = new Spire.Doc.Document();

            mydoc.LoadFromFile(file);

            if (!Path.GetExtension(file).Contains("doc"))
            {
                return string.Empty;
            }
            //删除spire水印以及两行回车
            //判断是否包含水印Evaluation Warning:
            string content = mydoc.Sections[0].Paragraphs[0].Text;

            //mydoc.SaveToFile($"{Path.GetDirectoryName(file)}\\myxml.xml", FileFormat.Xml);
            //Aspose.Words.Document myddd = new Aspose.Words.Document($"{Path.GetDirectoryName(file)}\\myxml.xml",new LoadOptions(){LoadFormat=LoadFormat.Text });
            //myddd.Save($"{Path.GetDirectoryName(file)}\\wode.docx", SaveFormat.Docx);


            //mydoc.SaveToFile(@"C:\Users\瑞腾软件\Desktop\新建文件夹\myxml.xml", FileFormat.WordXml);
            //mydoc.SaveToFile(@"C:\Users\瑞腾软件\Desktop\新建文件夹\myxml.html", FileFormat.Html);
            //mydoc.SaveToFile(@"C:\Users\瑞腾软件\Desktop\新建文件夹\myxml.ooxml", FileFormat.OOXML);

            //mydoc.LoadFromFile(@"C:\Users\瑞腾软件\Desktop\新建文件夹\myxml.xml");
            //mydoc.SaveToFile(file, FileFormat.Docx);
            if (content.Contains("Evaluation Waring"))
            {
                mydoc.Sections[0].Paragraphs.RemoveAt(0);
            }
            //dgv_task.Rows[d].Cells["zhuangtai"].Value = (100 * Convert.ToDecimal(word + 1) / Convert.ToDecimal(list_word.Count)).ToString("00.00") + "%";
            #region 调整格式
            //必须将手动换行符替换为自动换行符
            //string wholestory = mydoc.GetText();

            //判断是否消除空行
            if (cb_xiaochukonghang.Checked)
            {
                //删除文章中的空白行
                for (int secindex = mydoc.Sections.Count - 1; secindex >= 0; secindex--)
                {
                    var sec = mydoc.Sections[secindex];

                    for (int paraindex = sec.Paragraphs.Count - 1; paraindex >= 0; paraindex--)
                    {
                        var para = sec.Paragraphs[paraindex];
                        if (para.Text.Trim().Equals(string.Empty))
                        {
                            sec.Paragraphs.Remove(para);
                        }
                    }
                }

            }
            //提取word内容
            //string wordcontent = mydoc.Document.GetText();
            StringBuilder wordcontent = new StringBuilder();//获得所有段落的文本放在一起

            //遍历节和段落，获取段落中的文本
            foreach (Spire.Doc.Section section in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph paragraph in section.Paragraphs)
                {
                    wordcontent.AppendLine(paragraph.Text);
                }
            }
            MatchCollection mckw = null;
            TextSelection[] myts = null;
            TextSelection myts0 = null;
            /*1、设置正文格式*/

            mckw = Regex.Matches(wordcontent.ToString(), @".+?(\v|\r\n)");

            for (int i = 0; i < mckw.Count; i++)
            {
                if (mckw[i].ToString().Trim().Equals(""))
                {
                    continue;
                }
                //myts0 = mydoc.FindString(mckw[i].ToString().Trim(), false, true);
                var selectionarr = mydoc.FindAllString(mckw[i].ToString().Trim(), false, true);
                if (selectionarr.Length == 1)
                {
                    myworder.FormatSet(selectionarr[0], dic_format["正文"]);
                }
                else
                {
                    foreach (var selection in selectionarr)
                    {
                        myworder.FormatSet(selection, dic_format["正文"]);

                    }
                }

                //mydoc.SaveToFile(file, FileFormat.Docx);
            }

            /*2、设置大标题格式*/
            //提取大标题


            mckw = Regex.Matches(wordcontent.ToString(), @".*?\r\n");
            string str_title = string.Empty;
            int titlerow = 0;//记录大标题再第几行，用于定位副标题
            for (int i = 0; i < mckw.Count; i++)
            {
                //如果文本内容不是空，那么他是大标题
                if (!mckw[i].ToString().Trim().Equals(""))
                {
                    str_title = mckw[i].ToString().Trim();
                    titlerow = i;
                    break;
                }

            }
            //大标题格式设置
            TextSelection ts_title = mydoc.FindString(str_title, false, true);
            myworder.FormatSet(ts_title, dic_format["大标题"]);
            //增加第一编，第一章开头的段落设置为大标题格式
            foreach (Spire.Doc.Section sec in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in sec.Paragraphs)
                {
                    if (Regex.IsMatch(para.Text.Trim(), @"^\s*?第[一二三四五六七八九十].*?[章编].*"))
                    {
                        //定位需要转换的文字区域
                        TextSelection ts = para.Find(new Regex(@"^\s*?第[一二三四五六七八九十].*?[章编].*"));
                        //对文字区域的格式进行调整
                        myworder.FormatSet(ts, dic_format["大标题"]);
                    }
                }
            }
            /*设置副标题*/
            //提取副标题
            int title2end = 0;
            for (int i = titlerow + 1; i < mckw.Count; i++)
            {
                if (mckw[i].ToString().Trim().Equals(""))
                {
                    title2end = i;
                    break;
                }
            }
            string title2 = string.Empty;//存放副标题
                                         //副标题格式设置             
            for (int i = titlerow + 1; i < title2end; i++)
            {
                title2 = Regex.Replace(mckw[i].ToString(), "\r\n", "");
                if (title2 == "")
                {
                    break;
                }
                myts = mydoc.FindAllString(title2, false, false);//获得文本区域对其进行操作
                myworder.FormatSet(myts, dic_format["副标题"]);
            }
            //补充副标题格式设置
            //增加第一编，第一章开头的段落设置为大标题格式
            foreach (Spire.Doc.Section sec in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in sec.Paragraphs)
                {
                    if (Regex.IsMatch(para.Text.Trim(), @"^\s*?第[一二三四五六七八九十].*?节.*"))
                    {
                        TextSelection ts = para.Find(new Regex(@"^\s*?第[一二三四五六七八九十].*?节.*"));
                        myworder.FormatSet(ts, dic_format["副标题"]);
                    }
                    if (Regex.IsMatch(para.Text.Trim(), @"^\s*?(目\s*?录|前\s*?言).*"))
                    {
                        TextSelection ts = para.Find(new Regex(@"^\s*?(目\s*?录|前\s*?言).*"));
                        myworder.FormatSet(ts, dic_format["副标题"]);

                    }

                }
            }

            /*3、设置一级标题格式*/
            string regexrule = @"^[一二三四五六七八九十][一二三四五六七八九十]?、.+";

            foreach (Spire.Doc.Section section in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in section.Paragraphs)
                {
                    //获得所有的句子
                    //判断是否含有句号
                    string regrule = string.Empty;
                    if (Regex.IsMatch(para.Text, "。"))
                    {
                        regrule = ".+?[。;；]";
                    }
                    else
                    {
                        regrule = ".+$";
                    }
                    mckw = Regex.Matches(para.Text, regrule);
                    List<string> list_santence = new List<string>();
                    foreach (Match match in mckw)
                    {
                        list_santence.Add(match.ToString());
                    }
                    //判断句子的开头是否满足规则
                    foreach (string str in list_santence)
                    {
                        if (Regex.IsMatch(str.Trim(), regexrule))
                        {
                            TextSelection ts = para.Find(str.Trim(), false, false);
                            myworder.FormatSet(ts, dic_format["一级标题"]);
                        }
                    }
                }
            }
            /*4、设置二级标题格式*/
            regexrule = @"^[(（][一二三四五六七八九十].{0,2}[)）].*?(\r\n|。)";
            string regexrule2 = @"^[(（][一二三四五六七八九十].{0,2}[)）].*?$";
            foreach (Spire.Doc.Section section in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in section.Paragraphs)
                {
                    //判断段落的开头是否满足规则
                    if (Regex.IsMatch(para.Text, regexrule))
                    {
                        TextSelection ts = para.Find(new Regex(regexrule));
                        myworder.FormatSet(ts, dic_format["二级标题"]);

                    }
                    else if (Regex.IsMatch(para.Text, regexrule2))
                    {

                        TextSelection ts = para.Find(new Regex(regexrule2));
                        myworder.FormatSet(ts, dic_format["二级标题"]);

                    }
                }
            }
            /*5、设置三标题格式*/
            regexrule = "([一二三四五六七八九十]{1,3}[是要])|" +
                     "((第[一二三四五六七八九十]{1,3}[,，])|(最后[，,]))|" +
                     "((首先|其次)[,，])|" +
                     "(其[一二三四五六七八九十]{1,3}[,，])|" +
                     @"([(（][1-9]\d{0,2}[)）])|" +
                     "([①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳㉑㉒㉓㉔㉕㉖㉗㉘㉙㉚㉛㉜㉝㉞㉟㊱㊲㊳㊴㊵㊶㊷㊸㊹㊺㊻㊼㊽㊾㊿])|" +
                        "(另?一方面)|" +
                        "(第[一二三四五六七八九十百千]+?条第[一二三四五六七八九十百千]+?款第[一二三四五六七八九十百千]+?项)|" +
                        "(第[一二三四五六七八九十百千]+?条第[一二三四五六七八九十百千]+?款)|" +
                        "(第[一二三四五六七八九十]+?条)";





            MatchCollection mc = Regex.Matches(mydoc.GetText(), regexrule);
            foreach (Match item in mc)
            {
                TextSelection[] ts = mydoc.FindAllString(item.Value, false, false);
                foreach (TextSelection t in ts)
                {
                    myworder.FormatSet(t, dic_format["三级标题"]);
                }

            }

            foreach (Spire.Doc.Section section in mydoc.Sections)
            {
                foreach (Spire.Doc.Documents.Paragraph para in section.Paragraphs)
                {
                    TextSelection ts = para.Find(new Regex(@"(^\s*?([1-9]\d{0,2}|300)[,，\\.])|(^\s*?第[一二三四五六七八九十].*?条之[一二三四五六七八九十])"));
                    myworder.FormatSet(ts, dic_format["三级标题"]);
                }
            }
            #endregion



            #region 设置页面
            /*设置页边距*/
            if (cbqiyong.Checked)
            {
                Spire.Doc.Collections.SectionCollection sections = mydoc.Sections;
                for (int i = 0; i < sections.Count; i++)
                {
                    //页边距 
                    sections[i].PageSetup.Margins.Left = Convert.ToSingle(nudleft.Value);
                    sections[i].PageSetup.Margins.Right = Convert.ToSingle(nudright.Value);
                    sections[i].PageSetup.Margins.Top = Convert.ToSingle(nudtop.Value);
                    sections[i].PageSetup.Margins.Bottom = Convert.ToSingle(nudbottom.Value);
                }
            }


            #endregion
            //保存一次

            mydoc.SaveToFile(file);
            string finalfile = string.Empty;
            //再次保存为指定格式
            if (rbdoc.Checked)
            {
                finalfile = SaveDoc(file);
            }
            else
            {
                finalfile = SaveDocx(file);
            }
            return finalfile;
        }

        /// <summary>
        /// 点击删除总体格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblshanchu_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击删除页边距按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbldelete_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbbianju.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("name", fieldstr, "tablepagemargin");
            MessageBox.Show("删除数据成功！");
        }
        /// <summary>
        /// 点击页边距保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblsave_Click_1(object sender, EventArgs e)
        {
            if (cbbbianju.Text.Trim() == "")
            {
                MessageBox.Show("格式名称不允许为空！");
                return;
            }

            string fieldstr = cbbbianju.Text;
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("right", nudright.Value);
            dic.Add("left", nudleft.Value);
            dic.Add("top", nudtop.Value);
            dic.Add("bottom", nudbottom.Value);
            dic.Add("name", cbbbianju.Text);
            _mycontroller._sqlhelper.DeleteAnyFormat("name", fieldstr, "tablepagemargin");
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tablepagemargin");
            MessageBox.Show("保存数据成功！");

        }
        /// <summary>
        /// 却换页边距格式名称时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbbianju_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /**/
            string ttname = cbbbianju.Text;
            Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"name",ttname }
            };

            var list = _mycontroller._sqlhelper.GetAnySet("tablepagemargin", mydic);
            Dictionary<string, object> dic0 = list[0];
            nudleft.Value = Convert.ToDecimal(dic0["left"]);
            nudright.Value = Convert.ToDecimal(dic0["right"]);
            nudtop.Value = Convert.ToDecimal(dic0["top"]);
            nudbottom.Value = Convert.ToDecimal(dic0["bottom"]);
            //cbbbianju.Text = dic0["name"].ToString();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }
        ControllerGeshitiaozheng _mycontroller = new ControllerGeshitiaozheng();
        private void UCgeshizhuanhua_Load(object sender, EventArgs e)
        {
            //向标题和正文添加ucformat
            for (int i = 0; i < mytabcontrol.TabPages.Count - 1; i++)
            {
                UCFormat ucformat = new UCFormat();
                ucformat.Dock = DockStyle.Fill;
                mytabcontrol.TabPages[i].Controls.Add(ucformat);
            }
            UC.UCBiaozhu myuc = new UC.UCBiaozhu() { Dock = DockStyle.Fill };
            tabControl1.TabPages["wenbenbiaozhu"].Controls.Add(myuc);
            //加载页码设置下拉菜单
            List<string> list = _mycontroller.GetFormat("pagename", "tablepage");
            cbb_page.Items.Clear();
            cbb_page.Items.AddRange(list.ToArray());
        }
        /// <summary>
        /// 改变页眉页脚格式内容时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbyemeiyejiao_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 调整格式名内容发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbzongtigeshi0_TextChanged(object sender, EventArgs e)
        {
            //cbbymname.Text = string.Empty;
            //cbbymname.Text = dic0["yemei"].ToString();
            //cbbyjname.Text = string.Empty;
            //cbbyjname.Text = dic0["yejiao"].ToString();

        }
        /// <summary>
        /// 点击调整格式选项卡下保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label4_Click(object sender, EventArgs e)
        {

            string format = cbbzongtigeshi0.Text;
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("dabiaoti", ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbbformat.Text);
            dic.Add("usedabiaoti", ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbenable.Checked);
            dic.Add("fubiaoti", ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbbformat.Text);
            dic.Add("usefubiaoti", ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbenable.Checked);
            dic.Add("zhengwen", ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbbformat.Text);
            dic.Add("usezhengwen", ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbenable.Checked);
            dic.Add("yijibiaoti", ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbbformat.Text);
            dic.Add("useyijibiaoti", ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbenable.Checked);
            dic.Add("erjibiaoti", ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbbformat.Text);
            dic.Add("useerjibiaoti", ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbenable.Checked);
            dic.Add("sanjibiaoti", ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbbformat.Text);
            dic.Add("usesanjibiaoti", ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbenable.Checked);
            dic.Add("yemian", cbbbianju.Text);
            dic.Add("useyemian", cbqiyong.Checked);
            dic.Add("ttname", format);
            //dic.Add("yemei", cbbymname.Text);
            //dic.Add("useyemei", cbqiyongyemei.Checked);
            //dic.Add("yejiao", cbbyjname.Text);
            //dic.Add("useyejiao", cbqiyongyejiao.Checked);
            //dic.Add("useyema", cbpage.Checked);
            string wordformat = string.Empty;
            if (rbdoc.Checked)
            {
                wordformat = "doc";
            }
            if (rbdocx.Checked)
            {
                wordformat = "docx";
            }
            dic.Add("wordformat", wordformat);
            _mycontroller._sqlhelper.DeleteAnyFormat("ttname", format, "tabletotalformat");
            _mycontroller.SaveFormat(dic);
            MessageBox.Show("格式保存成功！");
        }
        /// <summary>
        /// 点击删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label2_Click_1(object sender, EventArgs e)
        {
            string fieldstr = cbbzongtigeshi0.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("ttname", fieldstr, "tabletotalformat");
            MessageBox.Show("删除数据成功！");
        }
        /// <summary>
        /// 点击保存页边距按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label17_Click(object sender, EventArgs e)
        {
            string ttname = cbbbianju.Text;
            //打开数据库
            Dictionary<string, object> dic = new Dictionary<string, object>() {
                {"name",ttname },
                {"myleft",nudleft.Value },
                {"myright" ,nudright.Value},
                {"mytop" ,nudtop.Value},
                 {"mybottom" ,nudbottom.Value},
            };
            //删除格式
            _mycontroller._sqlhelper.DeleteAnyFormat("name", ttname, "tablepagemargin");
            //保存 dic
            _mycontroller.SaveYebianjuFormat(dic);
            //提示保存成功
            MessageBox.Show("格式已保存成功！");
        }
        /// <summary>
        /// 点击页边距删除按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label18_Click(object sender, EventArgs e)
        {
            string ttname = cbbbianju.Text;
            //删除指定的页边距信息
            _mycontroller._sqlhelper.DeleteAnyFormat("name", ttname, "tablepagemargin");
            //提示保存成功
            MessageBox.Show("格式已删除！");
        }
        /// <summary>
        /// 切换边距下拉项时，获得该项对应的设置值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbbianju_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击终止转换按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lblshanchu_Click_1(object sender, EventArgs e)
        {
            Global.run = false;
        }

        /// <summary>
        /// 页眉格式名称发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbymname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string format = cbbymname.Text;
                Dictionary<string, object> dic = _mycontroller.GetYemeiSet(format);
                tbcontent0.Text = dic["ftext"].ToString();
                tbfontname0.Text = dic["ffontname"].ToString();
                nudfontsize0.Value = Convert.ToDecimal(dic["fsize"]);
                cbymbold.Checked = Convert.ToBoolean(dic["fbold"]);
                cbbjuzhong0.Text = Convert.ToString(dic["fjuzhong"]);

            }
            catch { }

        }
        /// <summary>
        /// 页脚格式名称发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbbyjname_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string format = cbbymname.Text;
                Dictionary<string, object> dic = _mycontroller.GetYemeiSet(format);
                tbcontent1.Text = dic["ftext"].ToString();
                tbfontname1.Text = dic["ffontname"].ToString();
                nudfontsize1.Value = Convert.ToDecimal(dic["fsize"]);
                cbyjbold.Checked = Convert.ToBoolean(dic["fbold"]);
                cbbjuzhong1.Text = Convert.ToString(dic["fjuzhong"]);
            }
            catch { }
        }
        /// <summary>
        /// 点击保存页眉按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Lblymbaocun_Click_1(object sender, EventArgs e)
        {

            string fieldstr = cbbymname.Text;
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("fname", cbbymname.Text);
            dic.Add("ftext", tbcontent0.Text);
            dic.Add("ffontname", tbfontname0.Text);
            dic.Add("fsize", nudfontsize0.Value);
            dic.Add("fbold", cbymbold.Checked);
            dic.Add("fjuzhong", cbbjuzhong0.Text);
            dic.Add("fposition", "yemei");
            _mycontroller._sqlhelper.DeleteAnyFormat("fname", fieldstr, "tableformat");
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tableformat");
            MessageBox.Show("保存数据成功！");
        }
        /// <summary>
        /// 点击删除页眉格式按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lblymshanchu_Click_1(object sender, EventArgs e)
        {
            string fieldstr = cbbymname.Text;
            //删除格式fieldstr对应的数据
            _mycontroller.DeleteYemeiFormat(fieldstr);
            MessageBox.Show("格式已删除！");
        }
        /// <summary>
        /// 点击保存页脚格式按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lblyjbaocun_Click_1(object sender, EventArgs e)
        {
            string fieldstr = cbbymname.Text;
            _mycontroller._sqlhelper.DeleteAnyFormat("fname", fieldstr, "tableformat");
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("fname", cbbymname.Text);
            dic.Add("ftext", tbcontent0.Text);
            dic.Add("ffontname", tbfontname0.Text);
            dic.Add("fsize", nudfontsize0.Value);
            dic.Add("fbold", cbymbold.Checked);
            dic.Add("fjuzhong", cbbjuzhong0.Text);
            dic.Add("fposition", "yejiao");
            _mycontroller._sqlhelper.SaveAnyFormat(dic, "tableformat");
            MessageBox.Show("保存数据成功！");
        }
        /// <summary>
        /// 删除页脚格式按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lblyjshanchu_Click_1(object sender, EventArgs e)
        {
            string fieldstr = cbbyjname.Text;
            _mycontroller.DeleteYejiaoFormat(fieldstr);
            MessageBox.Show("格式已删除！");
        }
        /// <summary>
        /// 点击删除页码格式按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label30_Click(object sender, EventArgs e)
        {
            string fieldstr = cbb_page.Text;
            //打开数据库
            _mycontroller.DeleteYemaFormat(fieldstr);
            MessageBox.Show("格式已删除！");

        }

        /// <summary>
        /// 点击保存页码格式按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label29_Click(object sender, EventArgs e)
        {
            string fieldstr = cbb_page.Text;
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagename", fieldstr);
            dic.Add("pageformat", cbb_yangshi.Text);
            dic.Add("pagefontstyle", cbb_fontformat.Text);
            dic.Add("pagejuzhong", cbb_yemajuzhong.Text);

            _mycontroller.SaveYemaFormat(dic);
            MessageBox.Show("保存数据成功！");
        }
        /// <summary>
        /// 点击保存页眉页脚格式按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label37_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbyemeiyejiao.Text;
            //构造数据
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("name", cbbyemeiyejiao.Text);
            dic.Add("yemeishezhi", cbbymname.Text);
            dic.Add("yejiaoshezhi", cbbyjname.Text);
            dic.Add("yemashezhi", cbb_page.Text);
            dic.Add("enableyemei", cbqiyongyemei.Checked);
            dic.Add("enableyejiao", cbqiyongyejiao.Checked);
            dic.Add("enableyema", cbpage.Checked);
            _mycontroller.SaveYemeiYejiaoFormat(dic);
            MessageBox.Show("保存数据成功！");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label36_Click(object sender, EventArgs e)
        {
            string fieldstr = cbbyemeiyejiao.Text;
            //打开数据库
            //删除格式fieldstr对应的数据
            _mycontroller.DeleteYemeiYejiaoFormat(fieldstr);
            MessageBox.Show("删除数据成功！");
        }

        private void cbbbianju_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void cbb_page_DropDown(object sender, EventArgs e)
        {
            List<string> list = _mycontroller.GetFormat("pagename", "tablepage");
            cbb_page.Items.Clear();
            cbb_page.Items.AddRange(list.ToArray());
        }

        private void cbbyemeiyejiao_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void cbbymname_DragDrop(object sender, DragEventArgs e)
        {
            List<string> list = _mycontroller.GetYemeiOrYejiao("yemei");
            cbbymname.Items.Clear();
            cbbymname.Items.AddRange(list.ToArray());
        }

        private void cbbyjname_DragDrop(object sender, DragEventArgs e)
        {
            List<string> list = _mycontroller.GetYemeiOrYejiao("yejiao");
            cbbymname.Items.Clear();
            cbbymname.Items.AddRange(list.ToArray());

        }

        private void cbbzongtigeshi0_SelectedIndexChanged(object sender, EventArgs e)
        {

            string ttname = cbbzongtigeshi0.Text;
            /*加载总体格式*/
            //获得所有的字段记录

            Dictionary<string, object> dic0 = _mycontroller.GetGejibiaoti(ttname);
            ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbbformat.Text = dic0["dabiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[0].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usedabiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbbformat.Text = dic0["fubiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[1].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usefubiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbbformat.Text = dic0["zhengwen"].ToString();
            ((UCFormat)mytabcontrol.TabPages[2].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usezhengwen"]);
            ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbbformat.Text = dic0["yijibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[3].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["useyijibiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbbformat.Text = dic0["erjibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[4].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["useerjibiaoti"]);
            ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbbformat.Text = dic0["sanjibiaoti"].ToString();
            ((UCFormat)mytabcontrol.TabPages[5].Controls[0]).cbenable.Checked = Convert.ToBoolean(dic0["usesanjibiaoti"]);
            cbqiyong.Checked = Convert.ToBoolean(dic0["useyemian"]);
            //cbpage.Checked = Convert.ToBoolean(dic0["useyema"]);
            //cbqiyongyemei.Checked = Convert.ToBoolean(dic0["useyemei"]);
            //cbqiyongyejiao.Checked = Convert.ToBoolean(dic0["useyejiao"]);
            //doc，docx赋值
            string wordformat = dic0["wordformat"].ToString();
            if (wordformat.Equals("doc"))
            {
                rbdoc.Checked = true;
            }
            if (wordformat.Equals("docx"))
            {
                rbdocx.Checked = true;
            }
            cbbbianju.Text = string.Empty;
            cbbbianju.Text = dic0["yemian"].ToString();

        }

        private void cbbyemeiyejiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fieldstr = cbbyemeiyejiao.Text;
                //打开数据库
                Dictionary<string, object> dic0 = _mycontroller.GetYemeiYejiaoSet(fieldstr);
                //添加进下拉菜单

                cbbyemeiyejiao.Text = dic0["name"].ToString();
                cbbymname.Text = dic0["yemeishezhi"].ToString();
                cbbyjname.Text = dic0["yejiaoshezhi"].ToString();
                cbb_page.Text = dic0["yemashezhi"].ToString();

                cbqiyongyemei.Checked = Convert.ToBoolean(dic0["enableyemei"]);
                cbqiyongyejiao.Checked = Convert.ToBoolean(dic0["enableyejiao"]);
                cbpage.Checked = Convert.ToBoolean(dic0["enableyema"]);


            }
            catch { }

        }

        private void cbbzongtigeshi0_DropDown(object sender, EventArgs e)
        {
            List<string> list = _mycontroller.GetFormat("ttname", "tabletotalformat");
            cbbzongtigeshi0.Items.Clear();
            cbbzongtigeshi0.Items.AddRange(list.ToArray());
        }

        private void cbbyemeiyejiao_DropDown(object sender, EventArgs e)
        {
            List<string> list = _mycontroller.GetFormat("name", "tableyemeiyejiao");
            cbbyemeiyejiao.Items.Clear();
            cbbyemeiyejiao.Items.AddRange(list.ToArray());

        }

        private void cbbbianju_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            string ttname = cbbbianju.Text;
            //打开数据库

            Dictionary<string, object> dic0 = _mycontroller.GetBianjuSet(ttname);
            nudleft.Value = Convert.ToDecimal(dic0["myleft"]);
            nudright.Value = Convert.ToDecimal(dic0["myright"]);
            nudtop.Value = Convert.ToDecimal(dic0["mytop"]);
            nudbottom.Value = Convert.ToDecimal(dic0["mybottom"]);

        }

        private void cbbbianju_DropDown_1(object sender, EventArgs e)
        {
            List<string> list = _mycontroller.GetFormat("name", "tablepagemargin");
            cbbbianju.Items.Clear();
            cbbbianju.Items.AddRange(list.ToArray());
        }

        private void cbb_page_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> dic = _mycontroller.GetPageSet(cbb_page.Text);
                cbb_fontformat.Text = dic["pagefontstyle"].ToString();
                cbb_yangshi.Text = dic["pageformat"].ToString();
                cbb_yemajuzhong.Text = dic["pagejuzhong"].ToString();
            }
            catch { }

        }
    }

}
