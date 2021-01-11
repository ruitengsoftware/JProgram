using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 团队任务台账管理系统.UserControll
{
    class JJTreeView:TreeView
    {
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x203) { m.Result = IntPtr.Zero; }
            else base.WndProc(ref m);

        }
    }
}
