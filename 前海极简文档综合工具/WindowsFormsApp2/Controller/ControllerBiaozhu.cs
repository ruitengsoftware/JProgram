using Aspose.Words;
using Aspose.Words.Replacing;
using Model;
using RuiTengDll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindowsFormsApp2.DLL;

namespace WindowsFormsApp2.Controller
{
    public class ControllerBiaozhu
    {
        //格式名称
        public string _format = string.Empty;
        //规则列表集合
        public List<BiaozhuInfo> list_biaozhu = new List<BiaozhuInfo>();
        //是否启用
        public bool _enable = false;
        //数据库
        string dbfile = $"{Environment.CurrentDirectory}\\ruitengdb.db";
        public ControllerBiaozhu()
        {
        }

        public void WenbenBiaozhu(string filename)
        {
            Aspose.Words.Document doc = new Aspose.Words.Document(filename);
            //循环规则
            foreach (BiaozhuInfo bzinfo in list_biaozhu)
            {
                //在全文范围内匹配到所有内容,拆分内容为独立关键词
                List<string> list_kw = Regex.Split(bzinfo._content, "[;；]").ToList();
                //如果是高亮效果
                if (bzinfo._style.Contains("高亮"))
                {
                        FindReplaceOptions options = new FindReplaceOptions();
                        //获得高亮颜色
                        string str_rgb = Regex.Match(bzinfo._style,@"(?<=\[).*(?=\])").Value;
                        Color highcolor = Color.FromArgb(Convert.ToInt32( Regex.Split(str_rgb,",")[0]), Convert.ToInt32(Regex.Split(str_rgb, ",")[1]), Convert.ToInt32(Regex.Split(str_rgb, ",")[2]));

                    foreach (string str in list_kw)
                    {
                        options.ReplacingCallback = new ReplaceEvaluatorFindAndHighlight(highcolor);
                        options.Direction = FindReplaceDirection.Backward;

                        //我们希望突出显示“您的文档”短语。
                        Regex regex = new Regex(str, RegexOptions.IgnoreCase);
                        doc.Range.Replace(regex, "", options);
                    }
                }
                else if (bzinfo._style.Contains("加粗"))
                {
                    foreach (string str in list_kw)
                    {
                        FindReplaceOptions options = new FindReplaceOptions();
                        options.ReplacingCallback = new ReplaceEvaluatorFindAndBold();
                        options.Direction = FindReplaceDirection.Backward;

                        //我们希望突出显示“您的文档”短语。
                        Regex regex = new Regex(str, RegexOptions.IgnoreCase);
                        doc.Range.Replace(regex, "", options);
                    }
                }
                else if (bzinfo._style.Contains("下划线"))
                {
                    string str_rgb = Regex.Match(bzinfo._style, @"(?<=\[).*(?=\])").Value;
                    Color highcolor = Color.FromArgb(Convert.ToInt32(Regex.Split(str_rgb, ",")[0]), Convert.ToInt32(Regex.Split(str_rgb, ",")[1]), Convert.ToInt32(Regex.Split(str_rgb, ",")[2]));

                    foreach (string str in list_kw)
                    {
                        FindReplaceOptions options = new FindReplaceOptions();
                        options.ReplacingCallback = new ReplaceEvaluatorFindAndUnderline(highcolor);
                        options.Direction = FindReplaceDirection.Backward;

                        //我们希望突出显示“您的文档”短语。
                        Regex regex = new Regex(str, RegexOptions.IgnoreCase);
                        doc.Range.Replace(regex, "", options);
                    }
                }

                else if (bzinfo._style.Contains("倾斜"))
                {
                    foreach (string str in list_kw)
                    {
                        FindReplaceOptions options = new FindReplaceOptions();
                        options.ReplacingCallback = new ReplaceEvaluatorFindAndItalic();
                        options.Direction = FindReplaceDirection.Backward;

                        //我们希望突出显示“您的文档”短语。
                        Regex regex = new Regex(str, RegexOptions.IgnoreCase);
                        doc.Range.Replace(regex, "", options);
                    }
                }
                else if (bzinfo._style.Contains("字体颜色"))
                {
                    string str_rgb = Regex.Match(bzinfo._style, @"(?<=\[).*(?=\])").Value;
                    Color highcolor = Color.FromArgb(Convert.ToInt32(Regex.Split(str_rgb, ",")[0]), Convert.ToInt32(Regex.Split(str_rgb, ",")[1]), Convert.ToInt32(Regex.Split(str_rgb, ",")[2]));

                    foreach (string str in list_kw)
                    {
                        FindReplaceOptions options = new FindReplaceOptions();
                        options.ReplacingCallback = new ReplaceEvaluatorFindAndFcolor(highcolor);
                        options.Direction = FindReplaceDirection.Backward;

                        //我们希望突出显示“您的文档”短语。
                        Regex regex = new Regex(str, RegexOptions.IgnoreCase);
                        doc.Range.Replace(regex, "", options);
                    }
                }
                //高亮，前景色，加粗，倾斜
            }
            doc.Save(filename);
        }


        /// <summary>
        /// 该方法用于删除数据库中的格式设置信息
        /// </summary>
        /// <param name="formatname"></param>
        public void DeleteFormat(string formatname)
        {
            _sqlhelper.DeleteAnyFormat("名称", formatname, "标注信息表");
        }

        /// <summary>
        /// 该方法用于保存设置
        /// </summary>
        /// <param name="formatname"></param>
        public void SaveFormat(Dictionary<string, object> dic)
        {
            _sqlhelper.SaveAnyFormat(dic, "标注信息表");
        }
        /// <summary>
        /// 获得软件设置表中的所有格式
        /// </summary>
        /// <returns></returns>
        public string[] GetFormat()
        {

           var list= _sqlhelper.GetSingleField("名称", "标注信息表");
            return list.ToArray();
        }
        MySqlHelper _sqlhelper = new MySqlHelper();
        /// <summary>
        /// 该方法用于获得指定格式下所有设置
        /// </summary>
        /// <param name="formatname"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetMuBan(string formatname)
        {
            var list = _sqlhelper.GetAnySet("标注信息表", new Dictionary<string, object> { { "名称", formatname } });
            return list[0];
        }




    }
  /// <summary>
  /// 高亮文本
  /// </summary>
    public class ReplaceEvaluatorFindAndHighlight : IReplacingCallback
    {
        Color mycolor = Color.Red;
        public ReplaceEvaluatorFindAndHighlight(Color c)
        {
            mycolor = c;
        }

        /// <summary>    
        /// 将指定运行的文本分成两个运行。    
        /// 在指定的运行之后插入新的运行。  
        /// </summary>    
        private static Run SplitRun(Run run, int position)
        {
            Run afterRun = (Run)run.Clone(true);
            afterRun.Text = run.Text.Substring(position);
            run.Text = run.Text.Substring(0, position);
            run.ParentNode.InsertAfter(afterRun, run);
            return afterRun;
        }
        /// <summary>    
        /// Aspose.Words为每个匹配项查找并替换引擎调用此方法。    
        ///即使跨多个运行，此方法也会突出显示匹配字符串。
        /// </summary>    
        ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
        {
            // 这是一个Run节点，其中包含开始或完全匹配。  
            Node currentNode = e.MatchNode;
            // 第一次（可能是唯一一次）运行可以包含比赛前的文字，
            // 在这种情况下，有必要拆分运行。  
            if (e.MatchOffset > 0)
                currentNode = SplitRun((Run)currentNode, e.MatchOffset);
            // 此数组用于存储匹配的所有节点以进一步突出显示。  
            ArrayList runs = new ArrayList();
            // 查找包含匹配字符串部分的所有运行。    
            int remainingLength = e.Match.Value.Length;
            while (
            (remainingLength > 0) &&
            (currentNode != null) &&
            (currentNode.GetText().Length <= remainingLength))
            {
                runs.Add(currentNode);
                remainingLength = remainingLength - currentNode.GetText().Length;
                //选择下一个“运行”节点。
                //必须循环，因为可能还有其他节点，例如BookmarkStart等。 
                do
                {
                    currentNode = currentNode.NextSibling;
                }
                while ((currentNode != null) && (currentNode.NodeType != NodeType.Run));
            }
            //如果剩余文本，则拆分包含该匹配项的最后一次运行。    
            if ((currentNode != null) && (remainingLength > 0))
            {
                SplitRun((Run)currentNode, remainingLength);
                runs.Add(currentNode);
            }
            //现在突出显示序列中的所有运行。
            foreach (Run run in runs)
                run.Font.HighlightColor =mycolor;
            //向替换引擎发出信号，表示什么都不做，因为我们已经完成了所有想要做的事情。
            return ReplaceAction.Skip;
        }
    }
    /// <summary>
    /// 加粗文本
    /// </summary>

    public class ReplaceEvaluatorFindAndBold : IReplacingCallback
    {
        /// <summary>    
     /// 将指定运行的文本分成两个运行。    
     /// 在指定的运行之后插入新的运行。  
     /// </summary>    
        private static Run SplitRun(Run run, int position)
        {
            Run afterRun = (Run)run.Clone(true);
            afterRun.Text = run.Text.Substring(position);
            run.Text = run.Text.Substring(0, position);
            run.ParentNode.InsertAfter(afterRun, run);
            return afterRun;
        }
        /// <summary>    
        /// Aspose.Words为每个匹配项查找并替换引擎调用此方法。    
        ///即使跨多个运行，此方法也会突出显示匹配字符串。
        /// </summary>    
        ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
        {
            // 这是一个Run节点，其中包含开始或完全匹配。  
            Node currentNode = e.MatchNode;
            // 第一次（可能是唯一一次）运行可以包含比赛前的文字，
            // 在这种情况下，有必要拆分运行。  
            if (e.MatchOffset > 0)
                currentNode = SplitRun((Run)currentNode, e.MatchOffset);
            // 此数组用于存储匹配的所有节点以进一步突出显示。  
            ArrayList runs = new ArrayList();
            // 查找包含匹配字符串部分的所有运行。    
            int remainingLength = e.Match.Value.Length;
            while (
            (remainingLength > 0) &&
            (currentNode != null) &&
            (currentNode.GetText().Length <= remainingLength))
            {
                runs.Add(currentNode);
                remainingLength = remainingLength - currentNode.GetText().Length;
                //选择下一个“运行”节点。
                //必须循环，因为可能还有其他节点，例如BookmarkStart等。 
                do
                {
                    currentNode = currentNode.NextSibling;
                }
                while ((currentNode != null) && (currentNode.NodeType != NodeType.Run));
            }
            //如果剩余文本，则拆分包含该匹配项的最后一次运行。    
            if ((currentNode != null) && (remainingLength > 0))
            {
                SplitRun((Run)currentNode, remainingLength);
                runs.Add(currentNode);
            }
            //现在突出显示序列中的所有运行。
            foreach (Run run in runs)
                run.Font.Bold = true;
            //向替换引擎发出信号，表示什么都不做，因为我们已经完成了所有想要做的事情。
            return ReplaceAction.Skip;
        }
    }
    /// <summary>
    /// 倾斜文本
    /// </summary>

    public class ReplaceEvaluatorFindAndItalic : IReplacingCallback
    {
        /// <summary>    
        /// 将指定运行的文本分成两个运行。    
        /// 在指定的运行之后插入新的运行。  
        /// </summary>    
        private static Run SplitRun(Run run, int position)
        {
            Run afterRun = (Run)run.Clone(true);
            afterRun.Text = run.Text.Substring(position);
            run.Text = run.Text.Substring(0, position);
            run.ParentNode.InsertAfter(afterRun, run);
            return afterRun;
        }
        /// <summary>    
        /// Aspose.Words为每个匹配项查找并替换引擎调用此方法。    
        ///即使跨多个运行，此方法也会突出显示匹配字符串。
        /// </summary>    
        ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
        {
            // 这是一个Run节点，其中包含开始或完全匹配。  
            Node currentNode = e.MatchNode;
            // 第一次（可能是唯一一次）运行可以包含比赛前的文字，
            // 在这种情况下，有必要拆分运行。  
            if (e.MatchOffset > 0)
                currentNode = SplitRun((Run)currentNode, e.MatchOffset);
            // 此数组用于存储匹配的所有节点以进一步突出显示。  
            ArrayList runs = new ArrayList();
            // 查找包含匹配字符串部分的所有运行。    
            int remainingLength = e.Match.Value.Length;
            while (
            (remainingLength > 0) &&
            (currentNode != null) &&
            (currentNode.GetText().Length <= remainingLength))
            {
                runs.Add(currentNode);
                remainingLength = remainingLength - currentNode.GetText().Length;
                //选择下一个“运行”节点。
                //必须循环，因为可能还有其他节点，例如BookmarkStart等。 
                do
                {
                    currentNode = currentNode.NextSibling;
                }
                while ((currentNode != null) && (currentNode.NodeType != NodeType.Run));
            }
            //如果剩余文本，则拆分包含该匹配项的最后一次运行。    
            if ((currentNode != null) && (remainingLength > 0))
            {
                SplitRun((Run)currentNode, remainingLength);
                runs.Add(currentNode);
            }
            //现在突出显示序列中的所有运行。
            foreach (Run run in runs)
                run.Font.Italic = true;
            //向替换引擎发出信号，表示什么都不做，因为我们已经完成了所有想要做的事情。
            return ReplaceAction.Skip;
        }
    }
    /// <summary>
    /// 前景色文本
    /// </summary>

    public class ReplaceEvaluatorFindAndFcolor : IReplacingCallback
    {
        Color mycolor = Color.Red;
        public ReplaceEvaluatorFindAndFcolor(Color c) {
            mycolor = c;
        }
        /// <summary>    
        /// 将指定运行的文本分成两个运行。    
        /// 在指定的运行之后插入新的运行。  
        /// </summary>    
        private static Run SplitRun(Run run, int position)
        {
            Run afterRun = (Run)run.Clone(true);
            afterRun.Text = run.Text.Substring(position);
            run.Text = run.Text.Substring(0, position);
            run.ParentNode.InsertAfter(afterRun, run);
            return afterRun;
        }
        /// <summary>    
        /// Aspose.Words为每个匹配项查找并替换引擎调用此方法。    
        ///即使跨多个运行，此方法也会突出显示匹配字符串。
        /// </summary>    
        ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
        {
            // 这是一个Run节点，其中包含开始或完全匹配。  
            Node currentNode = e.MatchNode;
            // 第一次（可能是唯一一次）运行可以包含比赛前的文字，
            // 在这种情况下，有必要拆分运行。  
            if (e.MatchOffset > 0)
                currentNode = SplitRun((Run)currentNode, e.MatchOffset);
            // 此数组用于存储匹配的所有节点以进一步突出显示。  
            ArrayList runs = new ArrayList();
            // 查找包含匹配字符串部分的所有运行。    
            int remainingLength = e.Match.Value.Length;
            while (
            (remainingLength > 0) &&
            (currentNode != null) &&
            (currentNode.GetText().Length <= remainingLength))
            {
                runs.Add(currentNode);
                remainingLength = remainingLength - currentNode.GetText().Length;
                //选择下一个“运行”节点。
                //必须循环，因为可能还有其他节点，例如BookmarkStart等。 
                do
                {
                    currentNode = currentNode.NextSibling;
                }
                while ((currentNode != null) && (currentNode.NodeType != NodeType.Run));
            }
            //如果剩余文本，则拆分包含该匹配项的最后一次运行。    
            if ((currentNode != null) && (remainingLength > 0))
            {
                SplitRun((Run)currentNode, remainingLength);
                runs.Add(currentNode);
            }
            //现在突出显示序列中的所有运行。
            foreach (Run run in runs)
                run.Font.Color = mycolor;
            //向替换引擎发出信号，表示什么都不做，因为我们已经完成了所有想要做的事情。
            return ReplaceAction.Skip;
        }
    }
    /// <summary>
    /// 背景色文本
    /// </summary>

    public class ReplaceEvaluatorFindAndUnderline : IReplacingCallback
    {
        Color mycolor = Color.Red;
        public ReplaceEvaluatorFindAndUnderline(Color c)
        {
            mycolor = c;
        }
        /// <summary>    
        /// 将指定运行的文本分成两个运行。    
        /// 在指定的运行之后插入新的运行。  
        /// </summary>    
        private static Run SplitRun(Run run, int position)
        {
            Run afterRun = (Run)run.Clone(true);
            afterRun.Text = run.Text.Substring(position);
            run.Text = run.Text.Substring(0, position);
            run.ParentNode.InsertAfter(afterRun, run);
            return afterRun;
        }
        /// <summary>    
        /// Aspose.Words为每个匹配项查找并替换引擎调用此方法。    
        ///即使跨多个运行，此方法也会突出显示匹配字符串。
        /// </summary>    
        ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
        {
            // 这是一个Run节点，其中包含开始或完全匹配。  
            Node currentNode = e.MatchNode;
            // 第一次（可能是唯一一次）运行可以包含比赛前的文字，
            // 在这种情况下，有必要拆分运行。  
            if (e.MatchOffset > 0)
                currentNode = SplitRun((Run)currentNode, e.MatchOffset);
            // 此数组用于存储匹配的所有节点以进一步突出显示。  
            ArrayList runs = new ArrayList();
            // 查找包含匹配字符串部分的所有运行。    
            int remainingLength = e.Match.Value.Length;
            while (
            (remainingLength > 0) &&
            (currentNode != null) &&
            (currentNode.GetText().Length <= remainingLength))
            {
                runs.Add(currentNode);
                remainingLength = remainingLength - currentNode.GetText().Length;
                //选择下一个“运行”节点。
                //必须循环，因为可能还有其他节点，例如BookmarkStart等。 
                do
                {
                    currentNode = currentNode.NextSibling;
                }
                while ((currentNode != null) && (currentNode.NodeType != NodeType.Run));
            }
            //如果剩余文本，则拆分包含该匹配项的最后一次运行。    
            if ((currentNode != null) && (remainingLength > 0))
            {
                SplitRun((Run)currentNode, remainingLength);
                runs.Add(currentNode);
            }
            //现在突出显示序列中的所有运行。
            foreach (Run run in runs) { 
                run.Font.Underline = Underline.Single;
            run.Font.UnderlineColor = mycolor;
}
            //向替换引擎发出信号，表示什么都不做，因为我们已经完成了所有想要做的事情。
            return ReplaceAction.Skip;
        }
    }


}
