using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Model;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace BLL
{
    public class WordHelper
    {
        /// <summary>
        /// 使用com设置文本格式
        /// </summary>
        public void FormatSet(Spire.Doc.Document mydoc, List<Paragraphs> listp, Format f)
        {
            for (int i = 0; i < listp.Count; i++)
            {
                //字体名称
                listp[i].Last.Range.Font.Name = f.fontname;
                //字体大小
                listp[i].Last.Range.Font.Size = f.fontsize;
                //设置行距
                switch (f.lstype)
                {
                    case "单倍行距":
                        listp[i].Last.Range.Paragraphs.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                        break;
                    case "1.5倍行距":
                        listp[i].Last.Range.Paragraphs.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpace1pt5;
                        break;
                    case "2倍行距":
                        listp[i].Last.Range.Paragraphs.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceDouble;
                        break;
                    default:
                        listp[i].Last.Range.Paragraphs.LineSpacing = f.lsvalue;
                        break;
                }
                //首行缩进
                listp[i].Last.Range.Paragraphs.CharacterUnitFirstLineIndent = f.suojin;//首行缩进
                                                                                       //加粗
                listp[i].Last.Range.Font.Bold = f.bold;//黑体字
                                                       //设置居中
                switch (f.juzhong)
                {
                    case "左对齐":
                        listp[i].Last.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居中
                        break;
                    case "居中":
                        listp[i].Last.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;//居中
                        break;
                    case "右对齐":
                        listp[i].Last.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;//居中
                        break;
                }

            }

        }
        /// <summary>
        /// 使用spire设置文本格式
        /// </summary>
        /// <param name="myts"></param>
        /// <param name="f"></param>
        public void FormatSet(TextSelection[] myts, Format f)
        {
            //如果该格式未启用，不执行任何方法
            if (!f.enable || myts == null)
            {
                return;
            }
            for (int i = 0; i < myts.Length; i++)
            {
                //得到文本区域
                TextRange mytr = myts[i].GetAsOneRange();
              
                //设置字体名称
                mytr.CharacterFormat.FontName = f.fontname;
                //设置字体大小
                mytr.CharacterFormat.FontSize = f.fontsize;
                //设置粗体
                mytr.CharacterFormat.Bold = f.bold == 1 ? true : false;
                //设置行距
                switch (f.lstype)
                {
                    case "单倍行距":
                        mytr.OwnerParagraph.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.AtLeast;
                        break;
                    case "1.5倍行距":
                        mytr.OwnerParagraph.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
                        break;
                    case "2倍行距":
                        mytr.OwnerParagraph.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Multiple;
                        break;
                    default:
                        mytr.OwnerParagraph.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
                        mytr.OwnerParagraph.Format.LineSpacing = f.lsvalue;
                        break;

                }
                //设置居中
                switch (f.juzhong)
                {
                    case "左对齐":
                        mytr.OwnerParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                        break;
                    case "居中":
                        mytr.OwnerParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                        break;
                    case "右对齐":
                        mytr.OwnerParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                        break;
                }
                //设置空行

                //设置缩进
                Spire.Doc.Formatting.ParagraphFormat mypformat = new Spire.Doc.Formatting.ParagraphFormat();
                float suojin = mytr.OwnerParagraph.Format.FirstLineIndent;
                if (suojin==0)
                {
                mytr.OwnerParagraph.Format.FirstLineIndent = f.suojin;

                }
            }
        }
        /// <summary>
        /// 向指定位置添加空行
        /// </summary>
        /// <param name="mydoc"></param>
        /// <param name="str"></param>
        /// <param name="spacenum"></param>
        public void AddSpaceLine(Spire.Doc.Document mydoc, string str,int spacenum)
        {
            var myts = mydoc.FindAllString(Regex.Replace(str, @"\r\n", ""), false, false);
            for (int spaceindex = 0; spaceindex < spacenum; spaceindex++)
            {
                myts[myts.Length - 1].GetAsOneRange().OwnerParagraph.AppendText("\r\n");
            }


        }


        /// <summary>
        /// 使用spire设置文本格式
        /// </summary>
        /// <param name="myts"></param>
        /// <param name="f"></param>
        public void FormatSet(TextSelection myts, Format f)
        {
            //如果该格式未启用，不执行任何方法
            if (!f.enable || myts==null || myts.Count==0)
            {
                return;
            }

            //得到文本区域
            TextRange mytr = myts.GetAsOneRange();
            //设置字体名称
            mytr.CharacterFormat.FontName = f.fontname;
            //设置字体大小
            mytr.CharacterFormat.FontSize = f.fontsize;
            //设置粗体
            mytr.CharacterFormat.Bold = f.bold == 1 ? true : false;
            //设置行距
            switch (f.lstype)
            {
                case "单倍行距":
                    mytr.OwnerParagraph.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.AtLeast;
                    break;
                case "1.5倍行距":
                    mytr.OwnerParagraph.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
                    break;
                case "2倍行距":
                    mytr.OwnerParagraph.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Multiple;
                    break;
                default:
                    mytr.OwnerParagraph.Format.LineSpacingRule = Spire.Doc.LineSpacingRule.Exactly;
                    mytr.OwnerParagraph.Format.LineSpacing = f.lsvalue;
                    break;

            }
            //设置居中
            switch (f.juzhong)
            {
                case "左对齐":
                    mytr.OwnerParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                    break;
                case "居中":
                    mytr.OwnerParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                    break;
                case "右对齐":
                    mytr.OwnerParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                    break;
            }
            //先删除空格

            //增加空行
            int spacenum =f.space;

            for (int spaceindex = 0; spaceindex < spacenum; spaceindex++)
            {
                mytr.OwnerParagraph.AppendText("\n");
            }
            //设置缩进
            Spire.Doc.Formatting.ParagraphFormat mypformat = new Spire.Doc.Formatting.ParagraphFormat();
            mytr.OwnerParagraph.Format.FirstLineIndent = f.suojin;
        }


    }
}
