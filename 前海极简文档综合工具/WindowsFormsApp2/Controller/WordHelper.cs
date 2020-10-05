using Model;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Doc.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Controller
{
    public class WordHelper
    {
        public void AddSpaceLine(Document mydoc, string str, int spacenum)
        {
            TextSelection[] selectionArray = mydoc.FindAllString(Regex.Replace(str, @"\r\n", ""), false, false);
            for (int i = 0; i < spacenum; i++)
            {
                selectionArray[selectionArray.Length - 1].GetAsOneRange().OwnerParagraph.AppendText("\r\n");
            }
        }

        public void FormatSet(TextSelection[] myts, Format f)
        {
            int num;
            if (f.enable && (myts != null))
            {
                num = 0;
            }
            else
            {
                return;
            }
            while (true)
            {
                TextRange asOneRange;
                while (true)
                {
                    if (num < myts.Length)
                    {
                        asOneRange = myts[num].GetAsOneRange();
                        
                        asOneRange.CharacterFormat.FontName = f.fontname;
                        asOneRange.CharacterFormat.FontSize = f.fontsize;
                        asOneRange.CharacterFormat.Bold = f.bold == 1;
                        string lstype = f.lstype;
                        if (lstype != null)
                        {
                            if (lstype == "单倍行距")
                            {
                                asOneRange.OwnerParagraph.Format.LineSpacingRule = LineSpacingRule.AtLeast;
                                break;
                            }
                            if (lstype == "1.5倍行距")
                            {
                                asOneRange.OwnerParagraph.Format.LineSpacingRule = LineSpacingRule.Exactly;
                                break;
                            }
                            if (lstype == "2倍行距")
                            {
                                asOneRange.OwnerParagraph.Format.LineSpacingRule = LineSpacingRule.Multiple;
                                break;
                            }
                        }
                        asOneRange.OwnerParagraph.Format.LineSpacingRule = LineSpacingRule.Exactly;
                        asOneRange.OwnerParagraph.Format.LineSpacing = f.lsvalue;
                    }
                    else
                    {
                        return;
                    }
                    break;
                }
                string juzhong = f.juzhong;
                if (juzhong != null)
                {
                    if (juzhong == "左对齐")
                    {
                        asOneRange.OwnerParagraph.Format.HorizontalAlignment = HorizontalAlignment.Left;
                    }
                    else if (juzhong == "居中")
                    {
                        asOneRange.OwnerParagraph.Format.HorizontalAlignment = HorizontalAlignment.Center;
                    }
                    else if (juzhong == "右对齐")
                    {
                        asOneRange.OwnerParagraph.Format.HorizontalAlignment = HorizontalAlignment.Right;
                    }
                }
                ParagraphFormat format = new ParagraphFormat();
                if (asOneRange.OwnerParagraph.Format.FirstLineIndent == 0f)
                {
                    asOneRange.OwnerParagraph.Format.FirstLineIndent = f.suojin;
                }
                num++;
            }
        }
        /// <summary>
        /// 队选中的文本区域进行格式设置
        /// </summary>
        /// <param name="myts"></param>
        /// <param name="f"></param>
        public void FormatSet(TextSelection myts, Format f)
        {
          
            //Regex.Replace(myts.SelectedText, "\v", "\r\n");
            TextRange asOneRange;
            Paragraph mypara;
            string str3;
            bool flag1;
            if (!f.enable || (myts == null))//判断该格式是否启用，如果f.enable是false，则退出本方法
            {
                flag1 = true;
            }
            else
            {
                flag1 = myts.Count == 0;
            }

            if (!flag1)
            {
                //var myranges= myts.GetRanges();

                
                asOneRange = myts.GetAsOneRange();
                asOneRange.CharacterFormat.FontName = f.fontname;
                asOneRange.CharacterFormat.FontSize = f.fontsize;

                mypara = asOneRange.OwnerParagraph;
                mypara.Text = mypara.Text.Trim();
                
                if (asOneRange == null) return;
                //asOneRange.CharacterFormat.ClearFormatting();
               
                //asOneRange.Document.SaveToFile(@"C:\Users\瑞腾软件\Desktop\正文字体问题\ceshi.docx",FileFormat.Docx);
                asOneRange.CharacterFormat.Bold = f.bold == 1;
                string lstype = f.lstype;
                if (lstype != null)
                {
                    if (lstype == "单倍行距")
                    {
                        mypara.Format.LineSpacingRule = LineSpacingRule.AtLeast;
                        goto TR_000D;
                    }
                    else if (lstype == "1.5倍行距")
                    {
                        mypara.Format.LineSpacingRule = LineSpacingRule.Exactly;
                        goto TR_000D;
                    }
                    else if (lstype == "2倍行距")
                    {
                        mypara.Format.LineSpacingRule = LineSpacingRule.Multiple;
                        goto TR_000D;
                    }
                }
                //if (asOneRange.OwnerParagraph==null)
                //{
                //    return;

                //}
                mypara.Format.LineSpacingRule = LineSpacingRule.Exactly;
                //设置行距
                mypara.Format.LineSpacing = f.lsvalue;
                //设置段落前后距
                //asOneRange.OwnerParagraph.Format.AfterSpacing = 0;
                mypara.Format.BeforeSpacing = 0; ;
            }
            else
            {
                return;
            }
            TR_000D:
            str3 = f.juzhong;
            if (str3 != null)
            {
                if (str3 == "左对齐")
                {
                    mypara.Format.HorizontalAlignment = HorizontalAlignment.Left;
                }
                else if (str3 == "居中")
                {
                    mypara.Format.HorizontalAlignment = HorizontalAlignment.Center;
                }
                else if (str3 == "右对齐")
                {
                    mypara.Format.HorizontalAlignment = HorizontalAlignment.Right;
                }
            }
            //调整缩进和空行
            int space = f.space;
            int num2 = 0;
            while (true)
            {
                if (num2 >= space)
                {
                    //pire.Doc.Formatting.ParagraphFormat format = new Spire.Doc.Formatting.ParagraphFormat();
                     mypara.Format.FirstLineIndent = f.suojin;
                    //asOneRange.OwnerParagraph.Format
                    break;
                }
                 mypara.AppendText("\n");
                num2++;
            }
            
        }

        public void FormatSet(Spire.Doc.Document mydoc, List<Microsoft.Office.Interop.Word.Paragraphs> listp, Format f)
        {
            int num = 0;
            while (true)
            {
                while (true)
                {
                    if (num >= listp.Count)
                    {
                        return;
                    }
                    listp[num].Last.Range.Font.Name = f.fontname;
                    listp[num].Last.Range.Font.Size = f.fontsize;
                    string lstype = f.lstype;
                    if (lstype != null)
                    {
                        if (lstype == "单倍行距")
                        {
                            listp[num].Last.Range.Paragraphs.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                            break;
                        }
                        if (lstype == "1.5倍行距")
                        {
                            listp[num].Last.Range.Paragraphs.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpace1pt5;
                            break;
                        }
                        if (lstype == "2倍行距")
                        {
                            listp[num].Last.Range.Paragraphs.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceDouble;
                            break;
                        }
                    }
                    listp[num].Last.Range.Paragraphs.LineSpacing = f.lsvalue;
                    break;
                }
                listp[num].Last.Range.Paragraphs.CharacterUnitFirstLineIndent = f.suojin;
                listp[num].Last.Range.Font.Bold = f.bold;
                string juzhong = f.juzhong;
                if (juzhong != null)
                {
                    if (juzhong == "左对齐")
                    {
                        listp[num].Last.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                    else if (juzhong == "居中")
                    {
                        listp[num].Last.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    else if (juzhong == "右对齐")
                    {
                        listp[num].Last.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    }
                }
                num++;
            }
        }
    }


}
