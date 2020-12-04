using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCtongxunluxiangqing : UserControl
    {
        public UCtongxunluxiangqing()
        {
            InitializeComponent();
        }
        public UCtongxunluxiangqing(JJPersonInfo personinfo)
        {
            InitializeComponent();

            this.lbl_xingming.Text = personinfo._shiming;
            this.lbl_zhiwu.Text = personinfo._zhiji;
            this.lbl_lianxifangshi.Text = personinfo._shoujihao;

        }

    }
}
