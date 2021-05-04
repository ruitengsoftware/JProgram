using Aspose.Words;
using Aspose.Words.Replacing;
using DocumentFormat.OpenXml.Packaging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static 谦海数据解析系统.JJmodel.TagInfo;

namespace 谦海数据解析系统.JJmodel
{
    class MyMethod
    {

        /// <summary>
        /// 用于刷新内容标签的方法
        /// </summary>
        public static Action _updateTag = null;



        /// <summary>
        /// 从规则信息表中获得所有规则信息datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRules(string ruleType, string kw)
        {
            string str_sql = $"select * from 数据解析库.规则信息表 where 规则名称 like '%{kw}%' and 删除=0 and 规则类型='{ruleType}'";

            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            return mydt;
        }
        /// <summary>
        /// 从规则信息表中获得所有规则信息datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRulesOriginal(string kw)
        {
            string str_sql = $"select * from 数据解析库.规则信息表_基础 where 名称 like '%{kw}%' and 删除=0";

            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            return mydt;
        }

        /// <summary>
        /// 获得指定格式类型的所有格式名称
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFormats(string ruleType)
        {
            List<string> list_result = new List<string>();
            string str_sql = $"select 格式名称 from 数据解析库.格式信息表 where 删除=0 and 格式类型='{ruleType}'";
            DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                list_result.Add(mydt.Rows[i]["格式名称"].ToString());
            }
            return list_result;
        }


        /// <summary>
        /// 在指定空间后面位置插入新的控件
        /// </summary>
        public static void AddControl(Control c, Control parentc)
        {
            //获得父控件的容器和父控件的位置
            Panel _panel = parentc.Parent as Panel;
            int _index = _panel.Controls.GetChildIndex(c);
            //位置+1，把c插入到容器中
            _panel.Controls.Add(c);
            _panel.Controls.SetChildIndex(c, _index - 1);
        }

        /// <summary>
        /// 在指定空间后面位置插入新的控件
        /// </summary>
        public static void AddControl(Control c, Panel panel)
        {
            //获得父控件的容器和父控件的位置
            panel.Controls.Add(c);
            panel.Controls.SetChildIndex(c, 0);

        }



        /// <summary>
        /// 获得内容节点的所有子节点信息
        /// </summary>
        /// <returns></returns>
        //public static List<BiaoqianInfo> GetChildNodes(BiaoqianInfo2 _bqInfo2)
        //{
        //    List<BiaoqianInfo> list_result = new List<BiaoqianInfo>();
        //    string str_sql = $"select * from 数据解析库.内容标签表 " +
        //        $"where 删除=0 and 父标签名='{_bqInfo2.list_tag.Last()}' and 库名='{_bqInfo2._dbName}'";
        //    DataTable mydt = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
        //    for (int i = 0; i < mydt.Rows.Count; i++)
        //    {
        //        DataRow mydr = mydt.Rows[i];
        //        BiaoqianInfo myinfo = new BiaoqianInfo()
        //        {
        //            _kuming = mydr["库名"].ToString(),
        //            _mingcheng = mydr["名称"].ToString(),
        //            _jibie = Convert.ToInt32(mydr["级别"].ToString()),
        //            _fubiaoqianming = mydr["父标签名"].ToString(),
        //            _biaoqianSet = mydr["设置"].ToString(),
        //            _chuangjianren = mydr["创建人"].ToString(),
        //            _chuangjianshijian = mydr["创建时间"].ToString()
        //        };
        //        BiaoqianRoot root = JsonConvert.DeserializeObject<BiaoqianRoot>(myinfo._biaoqianSet);
        //        myinfo._biaoqianRoot = root;
        //        list_result.Add(myinfo);
        //    }
        //    return list_result;
        //}




        /// <summary>
        /// 已段落为单位调整格式的方法
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static void UpdateFormat2(string file, BzhRuleRoot _root)
        {
            bool _existdabiaoti = false;
            LoadOptions lo = new LoadOptions(LoadFormat.WordML, "", "");
            Aspose.Words.Document mydoc = new Aspose.Words.Document(file, lo);

            //WordprocessingDocument doc = WordprocessingDocument.Open(file, true);
            //DocumentFormat.OpenXml.Wordprocessing.Body body = doc.MainDocumentPart.Document.Body;
            //string filestr = "C:\\Users\\lixingrui\\Desktop\\test\\testword2.docx";
            //FileStream fs = new FileStream(filestr,FileMode.Create);
            //doc.MainDocumentPart.Document.Save();
            //foreach (var item in body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>())
            //{
            //    Console.WriteLine(item.OuterXml);
            //}
            //doc.Save();

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(file);
            //XmlNode rootNode = xmlDoc.GetElementsByTagName("body")[0];
            ////创建student子节点
            //XmlNode studentNode = xmlDoc.CreateElement("student");
            ////创建一个属性
            //XmlAttribute nameAttribute = xmlDoc.CreateAttribute("name");
            //nameAttribute.Value = "张同学";
            //studentNode.InnerText = "哈哈哈哈哈哈哈哈";
            ////xml节点附件属性
            //studentNode.Attributes.Append(nameAttribute);
            //rootNode.AppendChild(studentNode);
            //xmlDoc.Save(file);
            //mydoc.FirstSection.Range.Replace(new Regex("\v"), ControlChar.Cr);
            var paras = mydoc.FirstSection.Body.Paragraphs;//获得文档所有的自然段
            //List<string> list_para = Regex.Split(mydoc.Range.Text,"[\v\r]").ToList();
            //list_para.Remove("");
            //1、调整文档格式
            for (int i = 0; i < paras.Count; i++)
            {


                //去掉段内的空格              
                var para = paras[i];
                //para.Range.Replace(new Regex(@"\s"), "", new FindReplaceOptions());
                string str_text = para.Range.Text;
                //判断是否居中，以此来分别主副标题和其他类型段落
                if (para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                {
                    bool bb1 = Regex.IsMatch(str_text, @"^第[一二三四五六七八九十]+?[编章][\s\S]*");//是否以指定文字开头
                    bool b1 = Regex.IsMatch(str_text, @"^第[一二三四五六七八九十]节[\s\S]*");//是否以指定文字开头
                    bool b2 = Regex.IsMatch(str_text, @"目\s*录[\s\S]*");
                    bool b3 = Regex.IsMatch(str_text, @"前\s*言[\s\S]*");
                    //bool b4 = Regex.IsMatch(str_text, @"\s\S+[。.；;！!，,：:……~'”‘’？?""“]$");//是否以符号结尾
                    if (bb1 || !_existdabiaoti)
                    {
                        _existdabiaoti = true;
                        SetParaFormat(para, "大标题", _root);
                        continue;
                    }
                    if (_existdabiaoti || b1 || b2 || b3)
                    {
                        SetParaFormat(para, "副标题", _root);
                        continue;
                    }
                }
                else
                {
                    //1、判断是否为大标题
                    bool bb1 = Regex.IsMatch(str_text, @"^第[一二三四五六七八九十]+?[编章][\s\S]*");//是否以指定文字开头
                    if (bb1)
                    {
                        SetParaFormat(para, "大标题", _root);
                        continue;
                    }
                    //2、判断正文，一二三级标题
                    SetStrFormat(para, _root);
                }
            }
            //2、调整页边距
            var sections = mydoc.Sections;
            for (int i = 0; i < sections.Count; i++)
            {

                sections[i].PageSetup.LeftMargin = Convert.ToSingle(_root._zuobianju);
                sections[i].PageSetup.RightMargin = Convert.ToSingle(_root._youbianju);
                sections[i].PageSetup.TopMargin = Convert.ToSingle(_root._shangbianju);
                sections[i].PageSetup.BottomMargin = Convert.ToSingle(_root._xiabianju);
            }
            #region  3、设置页眉页脚页码
            DocumentBuilder builder = new DocumentBuilder(mydoc);
            // 光标移动到页眉,并设置页眉的居中
            builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.HeaderPrimary);

            if (_root._yemeijz.Equals("左对齐"))
            {
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            }
            else if (_root._yemeijz.Equals("居中"))
            {
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            }
            else if (_root._yemeijz.Equals("右对齐"))
            {
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
            }
            builder.Write(_root._yemeinr);
            builder.Font.NameBi = _root._yemeizt;
            builder.Font.SizeBi = Convert.ToDouble(_root._yemeizh);
            builder.Font.BoldBi = _root._yemeict;
            /*设置页脚*/
            builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
            // 光标移动到页眉,并设置页眉的居中
            if (_root._yjjz.Equals("左对齐"))
            {
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            }
            else if (_root._yjjz.Equals("居中"))
            {
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            }
            else if (_root._yjjz.Equals("右对齐"))
            {
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
            }
            builder.Font.NameBi = _root._yjzt;
            builder.Font.SizeBi = Convert.ToDouble(_root._yjzh);
            builder.Font.BoldBi = _root._yjct;
            var newpara = builder.InsertParagraph();
            builder.MoveTo(newpara);
            builder.Write(_root._yjnr);
            /*设置页码*/
            ////光标定位到页脚
            builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
            //判断是否已经包含页码字样，如果是，跳出判断
            string str_yemau = builder.CurrentSection.GetText();
            if (!str_yemau.Contains("PAGE") && !str_yemau.Contains("NUMPAGES"))
            {

                //设置页码居中样式
                if (_root._ymjz.Equals("左对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
                }
                else if (_root._ymjz.Equals("居中"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                }
                else if (_root._ymjz.Equals("右对齐"))
                {
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                }
                newpara = builder.InsertParagraph();
                builder.MoveTo(newpara);
                //判断
                //设置页码格式并插入页码
                if (_root._ymgs.Equals("1、2……"))
                {
                    builder.InsertField("PAGE", "");
                }
                else if (_root._ymgs.Equals("-1-"))
                {
                    builder.Write("- ");
                    builder.InsertField("PAGE", "");

                    builder.Write(" -");

                }
                else if (_root._ymgs.Equals("第 1 页，第 2 页……"))
                {
                    builder.Write("第 ");
                    builder.InsertField("PAGE", "");

                    builder.Write(" 页");

                }
                else if (_root._ymgs.Equals("第 1 页，共 2 页……"))
                {
                    builder.Write("第 ");
                    builder.InsertField("PAGE", "");
                    builder.Write(" 页，");
                    builder.Write("共 ");
                    builder.InsertField("NUMPAGES", "");
                    builder.Write(" 页");

                }
                else if (_root._ymgs.Equals("1/N,2/N……"))
                {
                    //builder.InsertField("PAGE", "");
                    builder.InsertField(Aspose.Words.Fields.FieldType.FieldPage, true);

                    builder.Write("/");
                    builder.InsertField(Aspose.Words.Fields.FieldType.FieldNumPages, true);

                    //builder.InsertField("NUMPAGES", "");

                }
                //设置页码字体
                if (_root._ymzt.Equals("1、2、3……"))
                {
                    builder.PageSetup.PageNumberStyle = NumberStyle.Arabic;
                }
                else if (_root._ymzt.Equals("Ⅰ、Ⅱ、Ⅲ……"))
                {
                    builder.PageSetup.PageNumberStyle = NumberStyle.UppercaseRoman;

                }
                else if (_root._ymzt.Equals("a、b、c……"))
                {
                    builder.PageSetup.PageNumberStyle = NumberStyle.LowercaseLetter;

                }
                else if (_root._ymzt.Equals("A、B、C……"))
                {
                    builder.PageSetup.PageNumberStyle = NumberStyle.UppercaseLetter;
                }
            }
            //删除页脚多余的空行
            builder.MoveToHeaderFooter(Aspose.Words.HeaderFooterType.FooterPrimary);
            builder.CurrentSection.HeadersFooters[0].Paragraphs.RemoveAt(0);
            #endregion 

            mydoc.Save(file);

        }
        /// <summary>
        /// 调整一二三级标题的格式，包括正文部分字体格式和标题格式
        /// </summary>
        /// <param name="mypara"></param>
        /// <param name="dic_format"></param>
        public static void SetStrFormat(Aspose.Words.Paragraph mypara, BzhRuleRoot _root)
        {
            Regex regex = null;
            //格式的设置包括那几个方面，字体大小，字体名称，斜体，加粗，倾斜，下划线等,缩进，对齐，行距值
            //1、将整个段落的格式设置成正文
            //获得正文格式
            SetParaFormat(mypara, "正文", _root);
            //2、提取一级标题，设置格式
            FindReplaceOptions options = new FindReplaceOptions();
            options.Direction = FindReplaceDirection.Backward;
            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(_root._yjbtzt, Convert.ToDouble(_root._yjbtzh), _root._yjbtct);
            regex = new Regex(@"((?<!。).)*[一二三四五六七八九十]、[\s\S]*$", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@"^[一二三四五六七八九十]、[\s\S]*$", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);
            //3、提取二级标题，设置格式
            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(_root._ejbtzt, Convert.ToDouble(_root._ejbtzh), _root._ejbtct);
            regex = new Regex(@"^[（\(][一二三四五六七八九十][\)）][\s\S]*$", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);
            //4、提取三级标题，设置格式
            //调整文字
            options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(_root._sjbtzt, Convert.ToDouble(_root._sjbtzh), _root._sjbtct);
            regex = new Regex(@"第[一二三四五六七八九十]+?[,，][\s\S]*", RegexOptions.IgnoreCase);
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@"第[一二三四五六七八九十条款]+?[条款项][\s\S]*");
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@"^(其次|首先)[\s\S]*");
            mypara.Range.Replace(regex, "", options);
            regex = new Regex(@"^[一二三四五六七八九十]+?是要[\s\S]*");
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
        public static void SetParaFormat(Aspose.Words.Paragraph _para, string _type, BzhRuleRoot _root)
        {
            //大标题
            if (_type.Equals("大标题"))
            {
                foreach (Run myrun in _para.Runs)
                {

                    //mypara.ParagraphFormat.Style.Font.Name = f.fontname;//设置字体
                    myrun.Font.Name = _root._dbtzt;                                               //设置字号
                                                                                                  //mypara.ParagraphFormat.Style.Font.Size = f.fontsize;
                    myrun.Font.Size = Convert.ToDouble(_root._dbtzh);
                    //设置 粗体
                    //mypara.ParagraphFormat.Style.Font.Bold = f.bold == 1;
                    myrun.Font.Bold = _root._dbtct;
                    //设置缩进
                    //mypara.ParagraphFormat.FirstLineIndent = f.suojin;

                    myrun.ParentParagraph.ParagraphFormat.FirstLineIndent = Convert.ToDouble(_root._dbtsj);
                    //设置对齐
                    string juzhong = _root._dbtdqType;
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
                    myrun.ParentParagraph.ParagraphFormat.LineSpacing = Convert.ToDouble(_root._dbthjValue);

                }
            }

            //副标题
            else if (_type.Equals("副标题"))
            {
                foreach (Run myrun in _para.Runs)
                {

                    //mypara.ParagraphFormat.Style.Font.Name = f.fontname;//设置字体
                    myrun.Font.Name = _root._fbtzt;                                               //设置字号
                                                                                                  //mypara.ParagraphFormat.Style.Font.Size = f.fontsize;
                    myrun.Font.Size = Convert.ToDouble(_root._fbtzh);
                    //设置 粗体
                    //mypara.ParagraphFormat.Style.Font.Bold = f.bold == 1;
                    myrun.Font.Bold = _root._fbtct;
                    //设置缩进
                    //mypara.ParagraphFormat.FirstLineIndent = f.suojin;

                    myrun.ParentParagraph.ParagraphFormat.FirstLineIndent = Convert.ToDouble(_root._fbtsj);
                    //设置对齐
                    string juzhong = _root._fbtdqType;
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
                    myrun.ParentParagraph.ParagraphFormat.LineSpacing = Convert.ToDouble(_root._fbthjValue);

                }

            }
            //正文
            else if (_type.Equals("正文"))
            {
                foreach (Run myrun in _para.Runs)
                {

                    //mypara.ParagraphFormat.Style.Font.Name = f.fontname;//设置字体
                    myrun.Font.Name = _root._zwzt;                                               //设置字号
                                                                                                 //mypara.ParagraphFormat.Style.Font.Size = f.fontsize;
                    myrun.Font.Size = Convert.ToDouble(_root._zwzh);
                    //设置 粗体
                    //mypara.ParagraphFormat.Style.Font.Bold = f.bold == 1;
                    myrun.Font.Bold = _root._zwct;
                    //设置缩进
                    //mypara.ParagraphFormat.FirstLineIndent = f.suojin;

                    myrun.ParentParagraph.ParagraphFormat.FirstLineIndent = Convert.ToDouble(_root._zwsj);
                    //设置对齐
                    string juzhong = _root._zwdqType;
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
                    myrun.ParentParagraph.ParagraphFormat.LineSpacing = Convert.ToDouble(_root._zwhjValue);

                }

            }
        }


        #region 尝试使用style的方法调整样式，失败，问题是设置了style文档没有变化
        ///// <summary>
        ///// 判断paragraph的格式，赋予大标题等样式
        ///// </summary>
        //public static void SetParaStyle(Paragraph _para,BzhRuleRoot _root)
        //{
        //    bool _existdabiaoti = false;
        //    string str_text = _para.Range.Text;
        //    if (str_text.Trim().Equals(string.Empty))
        //    {
        //        return;
        //    }
        //    //判断是否居中，以此来分别主副标题和其他类型段落
        //    if (_para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
        //    {
        //        bool bb1 = Regex.IsMatch(str_text, @"^第[一二三四五六七八九十]+?[编章][\s\S]*");//是否以指定文字开头
        //        bool b1 = Regex.IsMatch(str_text, @"^第[一二三四五六七八九十]节[\s\S]*");//是否以指定文字开头
        //        bool b2 = Regex.IsMatch(str_text, @"目\s*录[\s\S]*");
        //        bool b3 = Regex.IsMatch(str_text, @"前\s*言[\s\S]*");
        //        //bool b4 = Regex.IsMatch(str_text, @"\s\S+[。.；;！!，,：:……~'”‘’？?""“]$");//是否以符号结尾
        //        if (bb1 || !_existdabiaoti)
        //        {
        //            _existdabiaoti = true;
        //            //_para.ParagraphFormat.StyleName = "JJTitle1";
        //            _para.Runs[0].Font.Name = _root._dbtzt;
        //            _para.Runs[0].Font.Size = Convert.ToDouble(_root._dbtzh);
        //            _para.Runs[0].Font.Bold = _root._dbtct;
        //            _para.ParagraphFormat.FirstLineIndent = Convert.ToDouble(_root._dbtsj);
        //            _para.ParagraphFormat.LineSpacingRule = Aspose.Words.LineSpacingRule.Exactly;
        //            _para.ParagraphFormat.LineSpacing = Convert.ToDouble(_root._dbthjValue);
        //            if (_root._dbtdqType != null)
        //            {
        //                if (_root._dbtdqType == "左对齐")
        //                {
        //                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        //                    _para.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        //                }
        //                else if (_root._dbtdqType == "居中")
        //                {
        //                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        //                    _para.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        //                }
        //                else if (_root._dbtdqType == "右对齐")
        //                {
        //                    //mypara.ParagraphFormat.Alignment = ParagraphAlignment.Right;
        //                    _para.ParagraphFormat.Alignment = ParagraphAlignment.Right;
        //                }
        //            }
        //            return;
        //        }
        //        if (_existdabiaoti || b1 || b2 || b3)
        //        {
        //           // _para.ParagraphFormat.Style = _para.Document.Styles["JJTitle2"];
        //        }
        //    }
        //    else
        //    {
        //        //1、判断是否为大标题
        //        bool bb1 = Regex.IsMatch(str_text, @"^第[一二三四五六七八九十]+?[编章][\s\S]*");//是否以指定文字开头
        //        if (bb1)
        //        {
        //            //_para.ParagraphFormat.Style = _para.Document.Styles["JJTitle1"];
        //        }
        //        //2、判断正文和一二三级标题
        //        //_para.ParagraphFormat.Style = _para.Document.Styles["JJtext"];
        //        //2.1、提取一级标题，设置格式
        //        bool h11 = Regex.IsMatch(str_text, @"((?<!。).)*[一二三四五六七八九十]、[\s\S]*$");
        //        bool h12 = Regex.IsMatch(str_text, @"^[一二三四五六七八九十]、[\s\S]*$");
        //        if (h11 || h12)
        //        {
        //           // _para.ParagraphFormat.Style = _para.Document.Styles["JJHeading 1"];

        //        }
        //        bool h21 = Regex.IsMatch(str_text, @"^[（\(][一二三四五六七八九十][\)）][\s\S]*$");
        //        if (h21)
        //        {
        //           // _para.ParagraphFormat.Style = _para.Document.Styles["JJHeading 2"];

        //        }
        //        bool h31 = Regex.IsMatch(str_text, @"第[一二三四五六七八九十]+?[,，][\s\S]*");
        //        bool h32 = Regex.IsMatch(str_text, @"第[一二三四五六七八九十条款]+?[条款项][\s\S]*");
        //        bool h33 = Regex.IsMatch(str_text, @"^(其次|首先)[\s\S]*");
        //        bool h34 = Regex.IsMatch(str_text, @"^[一二三四五六七八九十]+?是要[\s\S]*");
        //        bool h35 = Regex.IsMatch(str_text, @"（\([123456789]\)）[\s\S]*");
        //        bool h36 = Regex.IsMatch(str_text, @"^[①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳㉑㉒㉓㉔㉕㉖㉗㉘㉙㉚㉛㉜㉝㉞㉟㊱㊲㊳㊴㊵㊶㊷㊸㊹㊺㊻㊼㊽㊾㊿][\s\S]*");
        //        if (h31 || h32 || h33 || h34 || h35 || h36)
        //        {
        //            //_para.ParagraphFormat.Style = _para.Document.Styles["JJHeading 3"];
        //        }
        //    }
        //}

        ///// <summary>
        ///// 设置一二三级标题格式
        ///// </summary>
        //public static void SetHeadingFormat(Paragraph _para, BzhRuleRoot _root)
        //{





        //    Regex regex = null;
        //    FindReplaceOptions options = new FindReplaceOptions();
        //    options.Direction = FindReplaceDirection.Backward;
        //    //调整文字
        //    options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(_root._yjbtzt, Convert.ToDouble(_root._yjbtzh), _root._yjbtct);
        //    regex = new Regex(@"((?<!。).)*[一二三四五六七八九十]、[\s\S]*$", RegexOptions.IgnoreCase);
        //    regex = new Regex(@"^[一二三四五六七八九十]、[\s\S]*$", RegexOptions.IgnoreCase);
        //    _para.Range.Replace(regex, "", options);
        //    //2.2、提取二级标题，设置格式
        //    //调整文字
        //    options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(_root._ejbtzt, Convert.ToDouble(_root._ejbtzh), _root._ejbtct);
        //    regex = new Regex(@"^[（\(][一二三四五六七八九十][\)）][\s\S]*$", RegexOptions.IgnoreCase);
        //    _para.Range.Replace(regex, "", options);
        //    //2.3、提取三级标题，设置格式
        //    //调整文字
        //    options.ReplacingCallback = new ReplaceEvaluatorFindAndFont(_root._sjbtzt, Convert.ToDouble(_root._sjbtzh), _root._sjbtct);
        //    regex = new Regex(@"第[一二三四五六七八九十]+?[,，][\s\S]*", RegexOptions.IgnoreCase);
        //    _para.Range.Replace(regex, "", options);
        //    regex = new Regex(@"第[一二三四五六七八九十条款]+?[条款项][\s\S]*");
        //    _para.Range.Replace(regex, "", options);
        //    regex = new Regex(@"^(其次|首先)[\s\S]*");
        //    _para.Range.Replace(regex, "", options);
        //    regex = new Regex(@"^[一二三四五六七八九十]+?是要[\s\S]*");
        //    _para.Range.Replace(regex, "", options);
        //    regex = new Regex(@"（\([123456789]\)）[\s\S]*");
        //    _para.Range.Replace(regex, "", options);
        //    regex = new Regex(@"^[①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳㉑㉒㉓㉔㉕㉖㉗㉘㉙㉚㉛㉜㉝㉞㉟㊱㊲㊳㊴㊵㊶㊷㊸㊹㊺㊻㊼㊽㊾㊿][\s\S]*");
        //    _para.Range.Replace(regex, "", options);

        //}

        #endregion
    }
}
