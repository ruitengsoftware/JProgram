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
using System.Threading;
using Spire.Doc.Fields;
using Spire.Doc.Collections;
using Spire.Doc;
using Spire.Xls;
using System.Data.SQLite;
using Model;
using System.Data.OleDb;
using Spire.Doc.Documents;
using RuiTengDll;
using WindowsFormsApp2.Controller;

namespace WindowsFormsApp2
{
    public partial class UCExcelToWord : UserControl
    {
        delegate void DelOneStep(object o);
        string savepath = string.Empty;
        List<string> list_fieldname = new List<string>();
        UIHelper mydrawer = new UIHelper();
        ControllerExcelToWord _mycontroller = new ControllerExcelToWord();
        public UCExcelToWord()
        {
            InitializeComponent();
            //向标题和正文添加ucformat
            for (int i = 0; i < mytabcontrol.TabPages.Count - 1; i++)
            {
                UCFormat ucformat = new UCFormat();
                ucformat.Dock = DockStyle.Fill;
                mytabcontrol.TabPages[i].Controls.Add(ucformat);
            }
            //赋值页边距设置，也眉，总格式等
            try
            {
                /**/
                //打开数据库
                /*加载也边距格式*/
                var list = _mycontroller._sqlhelper.GetSingleField("name", "tablepagemargin");

                cbbbianju.Items.AddRange(list.ToArray());
                cbbbianju.SelectedIndex = 0;


                /*加载页眉格式*/
                //获得所有的字段记录
                Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"fposition","yemei" },
            };

                list = _mycontroller._sqlhelper.GetSingleField("fname", "tableformat", mydic);
                cbbymname.Items.AddRange(list.ToArray());
                //显示第一项
                cbbymname.SelectedIndex = 0;
                /*加载页脚格式*/
                //获得所有的字段记录
                Dictionary<string, object> mydic0 = new Dictionary<string, object> {
                {"fposition","yejiao" }
            };
                list = _mycontroller._sqlhelper.GetSingleField("fname", "tableformat", mydic0);

                cbbyjname.Items.Add(list.ToArray());
                //显示第一项
                cbbyjname.SelectedIndex = 0;
                /*加载总格式*/
                list = _mycontroller._sqlhelper.GetSingleField("ttname", "tabletotalformat");
                cbbzongtigeshi.Items.AddRange(list.ToArray());
                //显示第一项
                cbbzongtigeshi.SelectedIndex = 0;


            }
            catch { }

        }
        bool isrun = true;

        /// <summary>
        /// 点击导入excel按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            flpfield.Controls.Clear();
            panel.Controls.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel 工作簿|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbfilename.Text = ofd.FileName;
                //提取出所有的列名
                list_fieldname = new List<string>();
                Workbook mywbk = new Workbook();
                mywbk.LoadFromFile(ofd.FileName);
                Worksheet mysht = mywbk.Worksheets[0];
                //获得最后一列带内容得列号
                int lastcolindex = 0;
                for (int i = 16384; i >= 1; i--)
                {
                    if (mysht.Range[1, i].Value != "")
                    {
                        lastcolindex = i; break;
                    }
                }
                for (int i = 1; i <= lastcolindex; i++)
                {
                    list_fieldname.Add(mysht.Range[1, i].Value);
                }

            }
            //向字段flp中添加标签        
            Label mylbl = null;
            flpfield.Controls.Clear();
            for (int i = 0; i < list_fieldname.Count; i++)
            {
                mylbl = new Label();
                mylbl.Width = 80;
                mylbl.Margin = new Padding(1, 1, 1, 1);

                mylbl.Text = list_fieldname[i];
                mylbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                mylbl.TextAlign = ContentAlignment.MiddleCenter;
                mylbl.Click += Mylbl_Click;
                flpfield.Controls.Add(mylbl);
            }
        }
        public List<string> GetFields(string filename)
        {
            //读取excel表的标题
            Workbook mywbk = new Workbook();
            mywbk.LoadFromFile(filename);
            Worksheet mysht = mywbk.Worksheets[0];
            //获得最后一列带内容得列号
            int lastcolindex = 0;
            for (int i = 16384; i >= 1; i--)
            {
                if (mysht.Range[1, i].Value != "")
                {
                    lastcolindex = i; break;
                }
            }
            for (int i = 1; i <= lastcolindex; i++)
            {
                list_fieldname.Add(mysht.Range[1, i].Value);
            }
            return list_fieldname;

        }
        public void Mylbl_Click(object sender, EventArgs e)
        {
            Label lbl = ((Label)sender);
            if (lbl.BackColor == Color.SteelBlue)
            {
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Black;
            }
            else
            {
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.SteelBlue;
            }
        }

        UIHelper drawer = new UIHelper();
        private void label1_Paint(object sender, PaintEventArgs e)
        {
            drawer.DrawRoundRect(((Control)sender));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UCformate2w mycu = new UCformate2w(list_fieldname);
            mycu.Dock = DockStyle.Top;
            panel.Controls.Add(mycu);
        }
        /// <summary>
        /// 点击批量处理按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void label3_Click(object sender, EventArgs e)
        //{
        //    //判断输出路径是否存在
        //    string importpath = tbpath.Text;
        //    if (!Directory.Exists(importpath))
        //    {
        //        MessageBox.Show("保存路径不存在！");
        //        return;
        //    }
        //    UpdateStatue("正在提取文本格式……");
        //    //读取excel，得到行数
        //    Workbook mywbk = new Workbook();
        //    mywbk.LoadFromFile(tbfilename.Text);
        //    Worksheet mysht = mywbk.Worksheets[0];
        //    int lastrow = mysht.LastRow;
        //    /*识别所有的mycu*/
        //    UCformate2w myuc = null;
        //    List<UCformate2w> list_myuc = new List<UCformate2w>();

        //    for (int i = 0; i < panel.Controls.Count; i++)
        //    {
        //        myuc = new UCformate2w();
        //        myuc = ((UCformate2w)panel.Controls[i]);
        //        myuc.mysetter = new Model.setter();
        //        //给myuc的setter赋值
        //        for (int j = 0; j < myuc.flp.Controls.Count; j++)
        //        {
        //            Label mylbl0 = ((Label)myuc.flp.Controls[j]);
        //            if (mylbl0.BackColor == Color.SteelBlue)
        //            {
        //                //myuc.mysetter.listcolumn.Add(mylbl0.TabIndex);
        //            }
        //        }
        //        //myuc.mysetter.listcolumn = GetContent(tbfilename.Text, rowindex, myuc);
        //        myuc.mysetter.hangjustyle = myuc.cbblinespace.Text;
        //        myuc.mysetter.hangjuvalue = Convert.ToSingle(myuc.nudlinespace.Value);
        //        myuc.mysetter.fontname = myuc.tbfontname.Text;
        //        myuc.mysetter.fontsize = Convert.ToSingle(myuc.nudfontsize.Value);
        //        myuc.mysetter.juzhong = myuc.cbbposition.Text;
        //        myuc.mysetter.bold = myuc.cbbold.Checked ? 1 : 0;
        //        myuc.mysetter.suojin = Convert.ToSingle(myuc.nudsuojin.Value);
        //        myuc.mysetter.konghang = Convert.ToInt32(myuc.cbbkonghang.Text);
        //        //把uc提取到集合中
        //        list_myuc.Add(myuc);
        //    }
        //    List<string> listfilename = new List<string>();//接受选中的列用于文件名
        //    Label mylbl = null;
        //    for (int i = 0; i < flpfield.Controls.Count; i++)
        //    {
        //        mylbl = ((Label)flpfield.Controls[i]);
        //        if (mylbl.BackColor == Color.SteelBlue)
        //        {
        //            listfilename.Add(mylbl.Text);
        //        }
        //    }



        //         string path = tbpath.Text;
        //         /*生成一个新的word*/
        //         Spire.Doc.Document spdoc = new Spire.Doc.Document();
        //         /*循环把list中的mycu内容添加到word文档*/
        //         for (int rowindex = 2; rowindex <= lastrow; rowindex++)
        //         {
        //             //更新状态栏文字
        //             string str_statue = "正在生成第{0}个，共{1}个……";
        //             UpdateStatue(string.Format(str_statue, rowindex - 1, lastrow - 1));
        //             ///载入一个空白文档
        //             spdoc.LoadFromFile(Environment.CurrentDirectory + @"\newdoc.docx");
        //             for (int i = list_myuc.Count - 1; i >= 0; i--)
        //             {
        //                 //设置文本
        //                 string str_n = string.Empty;
        //                 //设置空行
        //                 for (int ji = 0; ji < list_myuc[i].mysetter.konghang; ji++)
        //                 {
        //                     str_n += "\n";
        //                 }
        //                 //添加一个段落

        //                 Spire.Doc.Documents.Paragraph parainsert = spdoc.LastSection.AddParagraph();
        //                 //Spire.Doc.Documents.Paragraph parainsert = spdoc.CreateParagraph();
        //                 //TextRange tx = parainsert.AppendText(GetContent(list_myuc[i].mysetter.listcolumn, rowindex, tbfilename.Text) + str_n);
        //                 //字体名称
        //                 //tx.CharacterFormat.FontName = list_myuc[i].mysetter.fontname;
        //                 //字体大小
        //                 //tx.CharacterFormat.FontSize = list_myuc[i].mysetter.fontsize;
        //                 //设置行距
        //                 switch (list_myuc[i].mysetter.hangjustyle)
        //                 {
        //                     case "单倍行距":
        //                         parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.AtLeast;
        //                         break;
        //                     case "1.5倍行距":
        //                         parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
        //                         break;
        //                     case "2倍行距":
        //                         parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Multiple;
        //                         break;
        //                     default:
        //                         parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
        //                         parainsert.Format.LineSpacing = list_myuc[i].mysetter.hangjuvalue;
        //                         break;
        //                 }
        //                 //首行缩进
        //                 parainsert.Format.SetFirstLineIndent(list_myuc[i].mysetter.suojin);//首行缩进
        //                                                                                    //粗体
        //                 tx.CharacterFormat.Bold = list_myuc[i].mysetter.bold == 1 ? true : false;
        //                 switch (list_myuc[i].mysetter.juzhong)
        //                 {
        //                     case "左对齐":
        //                         parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
        //                         break;
        //                     case "居中":
        //                         parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
        //                         break;
        //                     case "右对齐":
        //                         parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
        //                         break;
        //                 }
        //             }

        //             SectionCollection sections = spdoc.Sections;
        //             //创建一个HeaderFooter类实例，添加页脚
        //             for (int i = 0; i < sections.Count; i++)
        //             {
        //                 sections[i].PageSetup.Margins.Top = 72f;
        //                 sections[i].PageSetup.Margins.Left = 90f;
        //                 sections[i].PageSetup.Margins.Bottom = 72f;
        //                 sections[i].PageSetup.Margins.Right = 90f;
        //                 Spire.Doc.HeaderFooter footer = sections[i].HeadersFooters.Footer;
        //                 Spire.Doc.Documents.Paragraph footerPara = footer.AddParagraph();

        //                 //添加字段类型为页码，添加当前页、分隔线以及总页数
        //                 footerPara.AppendField("页码", FieldType.FieldPage);
        //                 footerPara.AppendText(" / ");
        //                 footerPara.AppendField("总页数", FieldType.FieldNumPages);
        //                 footerPara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
        //             }
        //             /*保存文档*/
        //             //组成文件名
        //             List<string> strfilename = new List<string>();
        //             for (int i = 0; i < listfilename.Count; i++)
        //             {
        //                 int colindex = 0;
        //                 for (int j = 0; j < mysht.LastColumn; j++)
        //                 {
        //                     if (mysht.Range[1,j+1].Value.Equals(listfilename[i]))
        //                     {
        //                         colindex = j + 1;
        //                     }
        //                 }
        //                 string filename_element = Regex.Replace(mysht.Range[rowindex, colindex].Value, @"[""“”\s/\:*?''<>|]", "");
        //                 strfilename.Add(filename_element);
        //             }
        //             spdoc.BuiltinDocumentProperties.Author = "潜挖智库";
        //             string savepath = path + @"\" + string.Join("-", strfilename) + @".docx";
        //             spdoc.SaveToFile(savepath);
        //             spdoc.Close();

        //             //去水印
        //             Aspose.Words.Document mydoc = new Aspose.Words.Document(savepath);
        //             mydoc.Sections[0].Body.Paragraphs.RemoveAt(0);
        //             mydoc.Save(savepath);
        //         }


        //    /*提示完成*/
        //    UpdateStatue("版权所有 深圳前海极简信息咨询服务有限公司");

        //    MessageBox.Show("本次生成文档结束！");

        //    //iar = a.BeginInvoke(o =>
        //    //  {
        //    //     
        //    //  }, null);

        //}
        #region MyRegion
        ///// <summary>
        ///// 生成word文档的方法
        ///// </summary>
        ///// <param name="lastrow"></param>
        ///// <param name="listfilename"></param>
        ///// <param name="list_myuc"></param>
        ///// <param name="mysht"></param>
        //private void CreateWord(int lastrow, List<int> listfilename, List<UCformate2w> list_myuc, Worksheet mysht)
        //{
        //    string path = tbpath.Text;
        //    /*生成一个新的word*/
        //    Word.Application myapp = new Word.Application();
        //    //myapp.Visible = true;
        //    /*循环把list中的mycu内容添加到word文档*/
        //    for (int rowindex = 2; rowindex <= lastrow; rowindex++)
        //    {
        //        //更新状态栏文字
        //        string str_statue = "正在生成第{0}个，共{1}个……";
        //        UpdateStatue(string.Format(str_statue, rowindex - 1, lastrow - 1));
        //        Word.Document mydoc = myapp.Documents.Add();
        //        for (int i = list_myuc.Count - 1; i >= 0; i--)
        //        {
        //            mydoc.Paragraphs.Add();
        //            //字体名称
        //            mydoc.Paragraphs.Last.Range.Font.Name = list_myuc[i].mysetter.fontname;
        //            //字体大小
        //            mydoc.Paragraphs.Last.Range.Font.Size = list_myuc[i].mysetter.fontsize;
        //            //设置行距
        //            switch (list_myuc[i].mysetter.hangjustyle)
        //            {
        //                case "单倍行距":
        //                    mydoc.Paragraphs.Last.Range.Paragraphs.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
        //                    break;
        //                case "1.5倍行距":
        //                    mydoc.Paragraphs.Last.Range.Paragraphs.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpace1pt5;
        //                    break;
        //                case "2倍行距":
        //                    mydoc.Paragraphs.Last.Range.Paragraphs.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceDouble;
        //                    break;
        //                default:
        //                    mydoc.Paragraphs.Last.Range.Paragraphs.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceExactly;
        //                    mydoc.Paragraphs.Last.Range.Paragraphs.LineSpacing = list_myuc[i].mysetter.hangjuvalue;
        //                    break;
        //            }
        //            //首行缩进
        //            mydoc.Paragraphs.Last.Range.Paragraphs.CharacterUnitFirstLineIndent = list_myuc[i].mysetter.suojin;//首行缩进
        //                                                                                                               //加粗
        //            mydoc.Paragraphs.Last.Range.Font.Bold = list_myuc[i].mysetter.bold;//黑体字
        //                                                                               //设置居中
        //            switch (list_myuc[i].mysetter.juzhong)
        //            {
        //                case "左对齐":
        //                    mydoc.Paragraphs.Last.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;//居中
        //                    break;
        //                case "居中":
        //                    mydoc.Paragraphs.Last.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;//居中
        //                    break;
        //                case "右对齐":
        //                    mydoc.Paragraphs.Last.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;//居中
        //                    break;
        //            }
        //            //设置文本
        //            string str_n = string.Empty;
        //            //设置空行
        //            for (int ji = 0; ji < list_myuc[i].mysetter.konghang; ji++)
        //            {
        //                str_n += "\n";
        //            }
        //            mydoc.Paragraphs.Last.Range.Text = GetContent(list_myuc[i].mysetter.listcolumn, rowindex, tbfilename.Text) + str_n;

        //        }
        //        /*保存文档*/
        //        //组成文件名
        //        List<string> strfilename = new List<string>();
        //        for (int i = 0; i < listfilename.Count; i++)
        //        {
        //            string filename_element = Regex.Replace(mysht.Range[rowindex, listfilename[i] + 1].Value, @"[\s/\:*?''<>|]", "");
        //            strfilename.Add(filename_element);
        //        }
        //        mydoc.SaveAs2(path + @"\" + string.Join("-", strfilename) + @".docx");
        //        mydoc.Close();

        //        mydoc = null;
        //    }
        //    myapp.Quit();
        //}

        #endregion

        /// <summary>
        /// 更新状态栏文字
        /// </summary>
        /// <param name="str"></param>
        private void UpdateStatue(string str)
        {
            if (this.InvokeRequired)
            {
                Action<string> a = UpdateStatue;
                this.BeginInvoke(a, str);
            }
            else
            {
                lblstatue.Text = str;
            }
        }

        Workbook mywbk = null;

        /// <summary>
        /// 获得setter的content内容
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="row"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetContent(List<int> list, int row, DataTable dt)
        {
            //List<string> listresult = new List<string>();
            //Spire.Xls.Workbook mywbk = new Workbook();
            //mywbk.LoadFromFile(filename);
            //Worksheet mysht = mywbk.Worksheets[0];
            string result = string.Empty;

            for (int i = 0; i < list.Count; i++)
            {
                // listresult.Add(mysht.Range[row, list[i] + 1].Value);
                //result += mysht.Range[row, list[i] + 1].Value;
                result += dt.Rows[row][list[i]];
            }
            //string str = string.Join("\n", listresult);
            return result;
        }

        /// <summary>
        /// 获得setter的content内容
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="row"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetContent(List<int> list, int row, string filename)
        {
            List<string> listresult = new List<string>();
            if (mywbk == null)
            {
                mywbk = new Workbook();
                mywbk.LoadFromFile(filename);

            }
            Worksheet mysht = mywbk.Worksheets[0];
            string result = string.Empty;

            for (int i = 0; i < list.Count; i++)
            {
                // listresult.Add(mysht.Range[row, list[i] + 1].Value);
                result += mysht.Range[row, list[i] + 1].Value;
            }
            //string str = string.Join("\n", listresult);
            return result;
        }
        /// <summary>
        /// 点击保存目录时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbpath.Text = fbd.SelectedPath;
            }
        }
        /// <summary>
        /// 点击前移按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label8_Click(object sender, EventArgs e)
        {
            //FlowLayoutPanel panel = (FlowLayoutPanel)((Label)sender).Parent;
            for (int i = 0; i < flpfield.Controls.Count; i++)
            {
                Label mylbl = ((Label)flpfield.Controls[i]);
                if (mylbl.BackColor == Color.SteelBlue)
                {//向前移动
                    if (i == 0)
                    {
                        return;
                    }
                    flpfield.Controls.SetChildIndex(mylbl, i - 1);
                    break;
                }
            }

        }

        /// <summary>
        /// 点击后移按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label9_Click(object sender, EventArgs e)
        {
            //FlowLayoutPanel panel = (FlowLayoutPanel)((Label)sender).Parent;

            for (int i = 0; i < flpfield.Controls.Count; i++)
            {
                Label mylbl = ((Label)flpfield.Controls[i]);
                if (mylbl.BackColor == Color.SteelBlue)
                {
                    //向后移动
                    if (i == flpfield.Controls.Count - 1)
                    {
                        return;
                    }
                    flpfield.Controls.SetChildIndex(mylbl, i + 1);
                    break;
                }
            }

        }
        /// <summary>
        /// 点击清空段落时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label4_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
        }
        /// <summary>
        /// 鼠标进入按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, -1);
        }
        /// <summary>
        /// 鼠标离开按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            int margin = ((Control)sender).Margin.Top;
            mydrawer.UpdateCSize((Control)sender, 1);



        }


        #region 不需要动的一些代码



        #endregion

        private void btnstop_Click(object sender, EventArgs e)
        {
            try
            {
                Global.t.Abort();
                isrun = false;
                do
                {
                    UpdateStatue("正在终止，请稍等……");
                } while (Global.t.ThreadState != ThreadState.Aborted);

                //清空所有控件内容
                tbfilename.Clear();
                tbpath.Clear();
                flpfield.Controls.Clear();
                panel.Controls.Clear();
                UpdateStatue("版权所有 深圳前海极简信息咨询服务有限公司！");
            }
            catch { }

        }
        /// <summary>
        /// 切换总体格式下拉列表时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbzongtigeshi_SelectedIndexChanged(object sender, EventArgs e)
        {

            //加载总体格式
            Dictionary<string, object> mydic = new Dictionary<string, object> {
                {"totalname", cbbzongtigeshi.Text}
            };

            var list_data = _mycontroller._sqlhelper.GetAnySet("tablesplit", mydic);
            //加载段落
            panel.Controls.Clear();
            foreach (object o in list_data)
            {
                UCformate2w uce2w = new UCformate2w(o);
                uce2w.Dock = DockStyle.Top;
                panel.Controls.Add(uce2w);
            }
            //加载选中标题
            flpfield.Controls.Clear();
            Dictionary<string, object> dic = list_data[0] as Dictionary<string, object>;
            string[] arr_allfields = dic["alltitle"].ToString().Split(new char[] { ',', '，' });
            for (int i = 0; i < arr_allfields.Length; i++)
            {
                Label lbl_field = new Label
                {
                    Text = arr_allfields[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                    Width = 80,
                    Margin = new Padding(1, 1, 1, 1)
                };
                lbl_field.Click += Mylbl_Click;
                flpfield.Controls.Add(lbl_field);
            }
            //显示标题
            string[] arr_alltitle = dic["allfields"].ToString().Split(new char[] { ',', '，' });
            string[] arr_title = dic["titlefields"].ToString().Split(new char[] { ',', '，' });
            foreach (Control c in flpfield.Controls)
            {
                if (arr_title.Contains(c.Text))
                {
                    c.BackColor = Color.SteelBlue;
                    c.ForeColor = Color.White;
                }
            }
        }


        private void UCExcelToWord_Load(object sender, EventArgs e)
        {
            cbbzongtigeshi.Items.Clear();
            //加载总体格式
            var list = _mycontroller._sqlhelper.GetSingleField("totalname", "tablesplit");
            cbbzongtigeshi.Items.Add(list.ToArray());
        }
        /// <summary>
        /// 点击删除总体格式按钮时触发得事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblshanchu_Click(object sender, EventArgs e)
        {
            _mycontroller._sqlhelper.DeleteAnyFormat("totalname", cbbzongtigeshi.Text, "tablesplit");
            MessageBox.Show("删除格式成功！");
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblbaocun_Click(object sender, EventArgs e)
        {
            if (cbbzongtigeshi.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("总体格式名不许为空！");
                return;
            }

            string fieldstr = cbbzongtigeshi.Text;
            //打开数据库
            //构造数据

            List<Dictionary<string, object>> list_dic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = null;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                dic = new Dictionary<string, object>();
                //获得选中字段和全部字段
                List<string> list_allfields = new List<string>();
                List<string> list_selectfields = new List<string>();
                List<Control> list_control = new List<Control>();
                for (int j = 0; j < ((UCformate2w)panel.Controls[i]).flp.Controls.Count; j++)
                {
                    list_allfields.Add(((UCformate2w)panel.Controls[i]).flp.Controls[j].Text);
                    if (((UCformate2w)panel.Controls[i]).flp.Controls[j].ForeColor == Color.White)//获得所有字段
                    {
                        list_selectfields.Add(((UCformate2w)panel.Controls[i]).flp.Controls[j].Text);
                    }

                }
                //获得标题
                List<string> list_titlefields = new List<string>();
                List<string> list_alltitle = new List<string>();
                for (int k = 0; k < flpfield.Controls.Count; k++)
                {
                    list_alltitle.Add(flpfield.Controls[k].Text);
                    if (flpfield.Controls[k].ForeColor == Color.White)
                    {
                        list_titlefields.Add(flpfield.Controls[k].Text);
                    }

                }
                dic["allfields"] = string.Join(",", list_allfields);
                dic["selectfields"] = string.Join(",", list_selectfields);
                dic["titlefields"] = string.Join(",", list_titlefields);
                dic["hangju"] = ((UCformate2w)panel.Controls[i]).cbblinespace.Text;
                dic["hangjuvalue"] = ((UCformate2w)panel.Controls[i]).nudlinespace.Value;
                dic["fontname"] = ((UCformate2w)panel.Controls[i]).tbfontname.Text;
                dic["fontsize"] = ((UCformate2w)panel.Controls[i]).nudfontsize.Value;
                dic["bold"] = ((UCformate2w)panel.Controls[i]).cbbold.Checked;
                dic["position"] = ((UCformate2w)panel.Controls[i]).cbbposition.Text;
                dic["space"] = ((UCformate2w)panel.Controls[i]).cbbkonghang.Text;
                dic["suojin"] = ((UCformate2w)panel.Controls[i]).nudsuojin.Value;
                dic["formatname"] = ((UCformate2w)panel.Controls[i]).cbbformat.Text;
                dic["sort"] = i;
                dic["totalname"] = cbbzongtigeshi.Text;
                dic["alltitle"] = string.Join(",", list_alltitle);
                list_dic.Add(dic);
            }




            //删除数据
            _mycontroller._sqlhelper.DeleteAnyFormat("totalname", fieldstr, "tablesplit");
            //保存数据
            for (int i = 0; i < list_dic.Count; i++)
            {
                _mycontroller._sqlhelper.SaveAnyFormat(list_dic[i], "tablesplit");
            }
            MessageBox.Show("保存数据成功！");
        }



        private void tbqiefen_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tbpath_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblabort_Click(object sender, EventArgs e)
        {

        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {

        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {

        }

        private void lblcreate_Click(object sender, EventArgs e)
        {

        }

        private void lblconvert_Click(object sender, EventArgs e)
        {

        }

        private void lbl_yichang_Click(object sender, EventArgs e)
        {

        }

        private void lblsave_Click(object sender, EventArgs e)
        {

        }

        private void lbldelete_Click(object sender, EventArgs e)
        {

        }

        private void Lblbaocun_Click(object sender, EventArgs e)
        {

        }

        private void Lblshanchu_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 批量根据excel生成文档
        /// </summary>
        /// <param name="o"></param>
        //public void CreateDoces(object o)
        //{
        //    //if (this.InvokeRequired)
        //    //{
        //    //    Action<object> a = CreateDoces;
        //    //    this.BeginInvoke(a, o);
        //    //}
        //    //else
        //    //{
        //        Action a = () => { 
        //        //判断输出路径是否存在
        //        string importpath = savepath;
        //        if (!Directory.Exists(importpath))
        //        {
        //            MessageBox.Show("保存路径不存在！");
        //            return;
        //        }
        //        UpdateStatue("正在提取文本格式……");
        //        //读取excel，得到行数
        //        Workbook mywbk = new Workbook();
        //        mywbk.LoadFromFile(tbfilename.Text);
        //        Worksheet mysht = mywbk.Worksheets[0];
        //        int lastrow = mysht.LastRow;
        //        /*识别所有的mycu*/
        //        UCformate2w myuc = null;
        //        List<UCformate2w> list_myuc = new List<UCformate2w>();

        //        for (int i = 0; i < panel.Controls.Count; i++)
        //        {
        //            myuc = new UCformate2w();
        //            myuc = ((UCformate2w)panel.Controls[i]);
        //            myuc.mysetter = new Model.setter();
        //            //给myuc的setter赋值
        //            for (int j = 0; j < myuc.flp.Controls.Count; j++)
        //            {
        //                Label mylbl0 = ((Label)myuc.flp.Controls[j]);
        //                if (mylbl0.BackColor == Color.SteelBlue)
        //                {
        //                    //myuc.mysetter.listcolumn.Add(mylbl0.TabIndex);
        //                }
        //            }
        //            //myuc.mysetter.listcolumn = GetContent(tbfilename.Text, rowindex, myuc);
        //            myuc.mysetter.hangjustyle = myuc.cbblinespace.Text;
        //            myuc.mysetter.hangjuvalue = Convert.ToSingle(myuc.nudlinespace.Value);
        //            myuc.mysetter.fontname = myuc.tbfontname.Text;
        //            myuc.mysetter.fontsize = Convert.ToSingle(myuc.nudfontsize.Value);
        //            myuc.mysetter.juzhong = myuc.cbbposition.Text;
        //            myuc.mysetter.bold = myuc.cbbold.Checked ? 1 : 0;
        //            myuc.mysetter.suojin = Convert.ToSingle(myuc.nudsuojin.Value);
        //            myuc.mysetter.konghang = Convert.ToInt32(myuc.cbbkonghang.Text);
        //            //把uc提取到集合中
        //            list_myuc.Add(myuc);
        //        }
        //        List<string> listfilename = new List<string>();//接受选中的列用于文件名
        //        Label mylbl = null;
        //        for (int i = 0; i < flpfield.Controls.Count; i++)
        //        {
        //            mylbl = ((Label)flpfield.Controls[i]);
        //            if (mylbl.BackColor == Color.SteelBlue)
        //            {
        //                listfilename.Add(mylbl.Text);
        //            }
        //        }



        //        string path = tbpath.Text;
        //        /*生成一个新的word*/
        //        Spire.Doc.Document spdoc = new Spire.Doc.Document();
        //        /*循环把list中的mycu内容添加到word文档*/
        //        for (int rowindex = 2; rowindex <= lastrow; rowindex++)
        //        {
        //            //更新状态栏文字
        //            //string str_statue = "正在生成第{0}个，共{1}个……";
        //            //UpdateStatue(string.Format(str_statue, rowindex - 1, lastrow - 1));
        //            ///载入一个空白文档
        //            spdoc.LoadFromFile(Environment.CurrentDirectory + @"\newdoc.docx");
        //            for (int i = list_myuc.Count - 1; i >= 0; i--)
        //            {
        //                //设置文本
        //                string str_n = string.Empty;
        //                //设置空行
        //                for (int ji = 0; ji < list_myuc[i].mysetter.konghang; ji++)
        //                {
        //                    str_n += "\n";
        //                }
        //                //添加一个段落

        //                Spire.Doc.Documents.Paragraph parainsert = spdoc.LastSection.AddParagraph();
        //                //Spire.Doc.Documents.Paragraph parainsert = spdoc.CreateParagraph();
        //                //TextRange tx = parainsert.AppendText(GetContent(list_myuc[i].mysetter.listcolumn, rowindex, tbfilename.Text) + str_n);
        //                //字体名称
        //                tx.CharacterFormat.FontName = list_myuc[i].mysetter.fontname;
        //                //字体大小
        //                tx.CharacterFormat.FontSize = list_myuc[i].mysetter.fontsize;
        //                //设置行距
        //                switch (list_myuc[i].mysetter.hangjustyle)
        //                {
        //                    case "单倍行距":
        //                        parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.AtLeast;
        //                        break;
        //                    case "1.5倍行距":
        //                        parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
        //                        break;
        //                    case "2倍行距":
        //                        parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Multiple;
        //                        break;
        //                    default:
        //                        parainsert.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
        //                        parainsert.Format.LineSpacing = list_myuc[i].mysetter.hangjuvalue;
        //                        break;
        //                }
        //                //首行缩进
        //                parainsert.Format.SetFirstLineIndent(list_myuc[i].mysetter.suojin);//首行缩进
        //                                                                                   //粗体
        //                tx.CharacterFormat.Bold = list_myuc[i].mysetter.bold == 1 ? true : false;
        //                switch (list_myuc[i].mysetter.juzhong)
        //                {
        //                    case "左对齐":
        //                        parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
        //                        break;
        //                    case "居中":
        //                        parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
        //                        break;
        //                    case "右对齐":
        //                        parainsert.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
        //                        break;
        //                }
        //            }

        //            SectionCollection sections = spdoc.Sections;
        //            //创建一个HeaderFooter类实例，添加页脚
        //            for (int i = 0; i < sections.Count; i++)
        //            {
        //                sections[i].PageSetup.Margins.Top = 72f;
        //                sections[i].PageSetup.Margins.Left = 90f;
        //                sections[i].PageSetup.Margins.Bottom = 72f;
        //                sections[i].PageSetup.Margins.Right = 90f;
        //                Spire.Doc.HeaderFooter footer = sections[i].HeadersFooters.Footer;
        //                Spire.Doc.Documents.Paragraph footerPara = footer.AddParagraph();

        //                //添加字段类型为页码，添加当前页、分隔线以及总页数
        //                footerPara.AppendField("页码", FieldType.FieldPage);
        //                footerPara.AppendText(" / ");
        //                footerPara.AppendField("总页数", FieldType.FieldNumPages);
        //                footerPara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
        //            }
        //            /*保存文档*/
        //            //组成文件名
        //            List<string> strfilename = new List<string>();
        //            for (int i = 0; i < listfilename.Count; i++)
        //            {
        //                int colindex = 0;
        //                for (int j = 0; j < mysht.LastColumn; j++)
        //                {
        //                    if (mysht.Range[1, j + 1].Value.Equals(listfilename[i]))
        //                    {
        //                        colindex = j + 1;
        //                    }
        //                }
        //                string filename_element = Regex.Replace(mysht.Range[rowindex, colindex].Value, @"[""“”\s/\:*?''<>|]", "");
        //                strfilename.Add(filename_element);
        //            }
        //            spdoc.BuiltinDocumentProperties.Author = "潜挖智库";
        //            string savepath = path + @"\" + string.Join("-", strfilename) + @".docx";
        //            spdoc.SaveToFile(savepath);
        //            spdoc.Close();

        //            ////去水印
        //            //Aspose.Words.Document mydoc = new Aspose.Words.Document(savepath);
        //            //mydoc.Sections[0].Body.Paragraphs.RemoveAt(0);
        //            //mydoc.Save(savepath);
        //        }
        //        };
        //    this.BeginInvoke(a);
        //    //}
        //}
        public void SaveDT2Excel(DataTable dt, string path, string wbkname)
        {
            Aspose.Cells.Workbook mywbk = new Aspose.Cells.Workbook();
            Aspose.Cells.Worksheet mysht = mywbk.Worksheets[0];
            mysht.Name = "Result";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                mysht.Cells[0, i].Value = dt.Columns[i].ColumnName;
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    if (dt.Rows[j][k] != null)
                    {
                        mysht.Cells[j + 1, k].Value = dt.Rows[j][k].ToString();

                    }
                    else
                    {
                        mysht.Cells[j, k].Value = "";
                    }
                }
            }
            mywbk.Save(path + @"\" + wbkname, Aspose.Cells.SaveFormat.Xlsx);
        }

        /// <summary>
        /// 从excel数据库提取数据
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public System.Data.DataTable ExcelToDS(string excelPath, string sqlstr)

        {
            DataSet ds = null;
            System.Data.DataTable dt = null;
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + excelPath + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            strExcel = sqlstr;//这里sheet1对应excel的工作表名称，一定要注意。
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            dt = ds.Tables[0];
            conn.Close();
            return dt;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //判断输出路径是否存在
            if (!Directory.Exists(savepath))
            {
                MessageBox.Show("保存路径不存在！");
                return;
            }

            //根据选择情况开始绑定事件
            DelOneStep myonestep = null;
            if (cb1.Checked)
            {
                //绑定文件切割事件
                //myonestep += CreateDoces;
            }
            if (cb2.Checked)
            {
                //绑定批量改名事件
                myonestep += GaiMinges;
            }

            if (cb3.Checked)
            {
                //绑定格式调整事件
                myonestep += UpdateFormat;

            }
            //执行事件
            this.BeginInvoke(myonestep, new object());
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
        WordHelper myworder = new WordHelper();

        /// <summary>
        /// 格式调整
        /// </summary>
        public void UpdateFormat(object o)
        {

            #region 获得格式
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
            #region 筛选文件
            //获得savepath下所有的word文档
            DirectoryInfo di = new DirectoryInfo(savepath);
            List<string> list_word = new List<string>();
            GetFiles(di, "*", ref list_word);
            foreach (string item in list_word)
            {
                if (item.Contains("xls"))
                {
                    list_word.Remove(item);
                }
            }
            #endregion
            //用spire打开每一个文件
            Spire.Doc.Document mydoc = new Spire.Doc.Document();
            Action a = () =>
            {
                for (int word = 0; word < list_word.Count; word++)
                {


                    //dgv_task.Rows[d].Cells["zhuangtai"].Value = (100 * Convert.ToDecimal(word + 1) / Convert.ToDecimal(list_word.Count)).ToString("00.00") + "%";

                    string file = list_word[word];
                    #region 设置格式
                    mydoc.LoadFromFile(file);
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
                    //提取word内容
                    //string wordcontent = mydoc.Document.GetText();
                    StringBuilder wordcontent = new StringBuilder();

                    //遍历节和段落，获取段落中的文本
                    foreach (Section section in mydoc.Sections)
                    {
                        foreach (Paragraph paragraph in section.Paragraphs)
                        {
                            wordcontent.AppendLine(paragraph.Text);
                        }
                    }

                    MatchCollection mckw = null;
                    TextSelection[] myts = null;

                    /*1、设置正文格式*/
                    mckw = Regex.Matches(wordcontent.ToString(), @".+?\r\n");

                    for (int i = 0; i < mckw.Count; i++)
                    {
                        myts = mydoc.FindAllString(Regex.Replace(mckw[i].ToString(), @"\r\n", ""), false, false);
                        if (myts == null)
                        {
                            continue;
                        }
                        foreach (TextSelection ts in myts)
                        {
                            myworder.FormatSet(ts, dic_format["正文"]);
                        }
                        if (i == mckw.Count - 1)
                        {
                            int spacenum = dic_format["正文"].space;
                            myworder.AddSpaceLine(mydoc, mckw[i].ToString(), spacenum);
                        }
                    }


                    /*2、设置大标题格式*/
                    //提取大标题


                    mckw = Regex.Matches(wordcontent.ToString(), @".*?\r\n");
                    string str_title = string.Empty;
                    int titlerow = 0;//记录大标题再第几行，用于定位副标题
                    for (int i = 0; i < mckw.Count; i++)
                    {
                        if (!mckw[i].ToString().Trim().Equals(""))
                        {
                            str_title = Regex.Replace(mckw[i].ToString(), "\r\n", "");
                            titlerow = i;
                            break;
                        }

                    }
                    //大标题格式设置
                    TextSelection ts_title = mydoc.FindString(str_title, false, false);
                    myworder.FormatSet(ts_title, dic_format["大标题"]);
                    //增加空行
                    int space = dic_format["大标题"].space;
                    myworder.AddSpaceLine(mydoc, str_title, space);
                    //增加第一编，第一章开头的段落设置为大标题格式
                    foreach (Section sec in mydoc.Sections)
                    {
                        foreach (Paragraph para in sec.Paragraphs)
                        {
                            if (Regex.IsMatch(para.Text.Trim(), @"^\s*?第[一二三四五六七八九十].*?[章编].*"))
                            {
                                TextSelection ts = para.Find(new Regex(@"^\s*?第[一二三四五六七八九十].*?[章编].*"));
                                myworder.FormatSet(ts, dic_format["大标题"]);
                                //增加空行
                                int space0 = dic_format["大标题"].space;
                                myworder.AddSpaceLine(mydoc, para.Text.Trim(), space0);


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
                    //for (int i = title2start; i < mckw.Count; i++)
                    //{
                    //    if (mckw[i].ToString().Trim().Equals(""))
                    //    {
                    //        title2end = i;
                    //        break;
                    //    }
                    //}
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
                        //增加空行
                        space = dic_format["大标题"].space;
                        myworder.AddSpaceLine(mydoc, title2, space);

                    }
                    //补充副标题格式设置
                    //增加第一编，第一章开头的段落设置为大标题格式
                    foreach (Section sec in mydoc.Sections)
                    {
                        foreach (Paragraph para in sec.Paragraphs)
                        {
                            if (Regex.IsMatch(para.Text.Trim(), @"^\s*?第[一二三四五六七八九十].*?节.*"))
                            {
                                TextSelection ts = para.Find(new Regex(@"^\s*?第[一二三四五六七八九十].*?节.*"));
                                myworder.FormatSet(ts, dic_format["副标题"]);
                                space = dic_format["副标题"].space;
                                myworder.AddSpaceLine(mydoc, para.Text.Trim(), space);

                            }
                            if (Regex.IsMatch(para.Text.Trim(), @"^\s*?(目\s*?录|前\s*?言).*"))
                            {
                                TextSelection ts = para.Find(new Regex(@"^\s*?(目\s*?录|前\s*?言).*"));
                                myworder.FormatSet(ts, dic_format["副标题"]);
                                //增加空行
                                space = dic_format["副标题"].space;
                                myworder.AddSpaceLine(mydoc, para.Text.Trim(), space);

                            }

                        }
                    }

                    /*3、设置一级标题格式*/
                    string regexrule = @"^[一二三四五六七八九十][一二三四五六七八九十]?、.+";

                    foreach (Section section in mydoc.Sections)
                    {
                        foreach (Paragraph para in section.Paragraphs)
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
                                    //增加空行
                                    space = dic_format["一级标题"].space;
                                    myworder.AddSpaceLine(mydoc, para.Text.Trim(), space);

                                }
                            }
                        }
                    }
                    /*4、设置二级标题格式*/
                    regexrule = @"^[(（][一二三四五六七八九十].{0,2}[)）].*?(\r\n|。)";
                    string regexrule2 = @"^[(（][一二三四五六七八九十].{0,2}[)）].*?$";
                    foreach (Section section in mydoc.Sections)
                    {
                        foreach (Paragraph para in section.Paragraphs)
                        {
                            //判断段落的开头是否满足规则
                            if (Regex.IsMatch(para.Text, regexrule))
                            {
                                TextSelection ts = para.Find(new Regex(regexrule));
                                myworder.FormatSet(ts, dic_format["二级标题"]);
                                //增加空行
                                space = dic_format["二级标题"].space;
                                myworder.AddSpaceLine(mydoc, para.Text.Trim(), space);

                            }
                            else if (Regex.IsMatch(para.Text, regexrule2))
                            {

                                TextSelection ts = para.Find(new Regex(regexrule2));
                                myworder.FormatSet(ts, dic_format["二级标题"]);
                                //增加空行
                                space = dic_format["二级标题"].space;
                                myworder.AddSpaceLine(mydoc, para.Text.Trim(), space);

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
                                "第([一二三四五六七八九十].*?)条(?![\u4e00-\u9fa5])";
                    MatchCollection mc = Regex.Matches(mydoc.GetText(), regexrule);
                    foreach (Match item in mc)
                    {
                        TextSelection[] ts = mydoc.FindAllString(item.Value, false, false);
                        foreach (TextSelection t in ts)
                        {
                            myworder.FormatSet(t, dic_format["三级标题"]);
                            //增加空行
                            space = dic_format["三级标题"].space;
                            myworder.AddSpaceLine(mydoc, t.GetAsOneRange().OwnerParagraph.Text, space);

                        }

                    }

                    foreach (Section section in mydoc.Sections)
                    {
                        foreach (Paragraph para in section.Paragraphs)
                        {
                            TextSelection ts = para.Find(new Regex(@"(^\s*?([1-9]\d{0,2}|300)[,，\\.])|(^\s*?第[一二三四五六七八九十].*?条之[一二三四五六七八九十])"));
                            myworder.FormatSet(ts, dic_format["三级标题"]);
                            //增加空行
                            space = dic_format["三级标题"].space;
                            myworder.AddSpaceLine(mydoc, para.Text.Trim(), space);
                        }
                    }
                    //保存一次
                    mydoc.SaveToFile(list_word[word]);
                    #endregion
                    #region 设置页面
                    /*设置页边距*/
                    if (cbqiyong.Checked)
                    {
                        SectionCollection sections = mydoc.Sections;
                        for (int i = 0; i < sections.Count; i++)
                        {
                            //页边距 
                            sections[i].PageSetup.Margins.Left = Convert.ToSingle(nudleft.Value);
                            sections[i].PageSetup.Margins.Right = Convert.ToSingle(nudright.Value);
                            sections[i].PageSetup.Margins.Top = Convert.ToSingle(nudtop.Value);
                            sections[i].PageSetup.Margins.Bottom = Convert.ToSingle(nudbottom.Value);
                        }
                    }
                    /*设置页眉*/
                    if (cbqiyongyemei.Checked)
                    {
                        SectionCollection sections = mydoc.Sections;

                        for (int i = 0; i < sections.Count; i++)
                        {

                            //添加页眉
                            HeaderFooter header = sections[i].HeadersFooters.Header;
                            //先清空一下页眉
                            header.ChildObjects.Clear();
                            Paragraph headerpara = header.AddParagraph();
                            if (cbbjuzhong0.Text.Equals("左对齐"))
                            {
                                headerpara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                            }
                            else if (cbbjuzhong0.Text.Equals("居中"))
                            {
                                headerpara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;

                            }
                            else if (cbbjuzhong0.Text.Equals("右对齐"))
                            {
                                headerpara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;

                            }
                            TextRange headertr = headerpara.AppendText(tbcontent0.Text);
                            headertr.CharacterFormat.FontName = tbfontname0.Text;
                            headertr.CharacterFormat.FontSizeBidi = Convert.ToSingle(nudfontsize0.Value);
                            headertr.CharacterFormat.Bold = cbymbold.Checked;
                        }
                    }
                    /*设置页脚*/
                    if (cbqiyongyejiao.Checked)
                    {
                        SectionCollection sections = mydoc.Sections;
                        for (int i = 0; i < sections.Count; i++)
                        {
                            //添加页脚
                            HeaderFooter footer = sections[i].HeadersFooters.Footer;
                            footer.ChildObjects.Clear();
                            sections[i].PageSetup.DifferentOddAndEvenPagesHeaderFooter = false;
                            Paragraph footerpara = footer.AddParagraph();
                            if (cbbjuzhong1.Text.Equals("左对齐"))
                            {
                                footerpara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                            }
                            else if (cbbjuzhong1.Text.Equals("居中"))
                            {
                                footerpara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                            }
                            else if (cbbjuzhong1.Text.Equals("右对齐"))
                            {
                                footerpara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                            }
                            TextRange footertr = footerpara.AppendText(tbcontent1.Text);
                            footertr.CharacterFormat.FontName = tbfontname1.Text;
                            footertr.CharacterFormat.FontSize = Convert.ToSingle(nudfontsize1.Value);
                            footertr.CharacterFormat.Bold = cbyjbold.Checked;
                            if (cbpage.Checked)
                            {
                                Paragraph yemapara = footer.AddParagraph();
                                Field f = null;
                                //添加页码

                                f = yemapara.AppendField("页码", FieldType.FieldPage);
                                f.CharacterFormat.FontSize = 10.5f;
                                f.CharacterFormat.FontName = "微软雅黑";
                                yemapara.AppendText(" / ").CharacterFormat.FontSize = 10.5f;
                                f = yemapara.AppendField("总页数", FieldType.FieldNumPages);
                                f.CharacterFormat.FontSize = 10.5f;
                                f.CharacterFormat.FontName = "微软雅黑";
                                yemapara.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;

                            }
                        }
                    }

                    #endregion
                    //保存为指定格式
                    if (rbdoc.Checked)
                    {

                        //mydoc.SaveToFile(list_word[word], Spire.Doc.FileFormat.Doc);
                        SaveDoc(list_word[word]);
                    }
                    else
                    {
                        SaveDocx(list_word[word]);
                    }

                }
            };
            this.BeginInvoke(a);
            //完成mbox
            //MessageBox.Show("所需要的转换已经完成！");

        }
        /// <summary>
        /// 将word保存为doc格式
        /// </summary>
        /// <param name="o"></param>
        public void SaveDoc(object o)
        {
            string file = o as string;
            Spire.Doc.Document mydoc = new Document();

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
        }
        /// <summary>
        /// 将文件保存为docx格式的word文档
        /// </summary>
        /// <param name="o"></param>
        public void SaveDocx(object o)
        {
            string file = o as string;
            Spire.Doc.Document mydoc = new Document();

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

        /// <summary>
        /// 批量改名事件
        /// </summary>
        /// <param name="o"></param>
        public void GaiMinges(object o)
        {
            //MessageBox.Show("批量改名");
            //绑定批量改名事件
            DirectoryInfo mydi = new DirectoryInfo(savepath);
            List<string> list = new List<string>();
            GetFiles(mydi, "*", ref list);
            string field = cbbfield.Text;
            bool qian = rbqian.Checked;
            for (int i = 0; i < list.Count; i++)
            {
                string filename = list[i];
                Dictionary<string, object> dic = new Dictionary<string, object>() {
                    {"filename",filename },
                    {"field", field},
                    { "qian", qian}
                };
                GaiMingSingle(dic);


            }


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

        private void Tbpath_TextChanged_1(object sender, EventArgs e)
        {
            savepath = tbpath.Text;
        }
    }
}
