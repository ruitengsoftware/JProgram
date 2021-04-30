using Aspose.Words;
using Aspose.Words.Replacing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 谦海数据解析系统.JJmodel
{
    /// <summary>
    /// 更换字体的大小，粗体，和字体名称
    /// </summary>
    public class ReplaceEvaluatorFindAndFont : IReplacingCallback
    {
        string myfontname = string.Empty;
        double mysize = 0;
        bool mybold = false;
        /// <summary>
        /// 调整字体的构造函数
        /// </summary>
        /// <param name="str">字体名称</param>
        /// <param name="size">字体尺寸</param>
        /// <param name="bold">是否粗体</param>
        public ReplaceEvaluatorFindAndFont(string str, double size, bool bold)
        {
            myfontname = str;
            mysize = size;
            mybold = bold;

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
            {
                run.Font.Name = myfontname;
                run.Font.Size = mysize;
                run.Font.Bold = mybold;
            }
            //向替换引擎发出信号，表示什么都不做，因为我们已经完成了所有想要做的事情。
            return ReplaceAction.Skip;
        }
    }

}
