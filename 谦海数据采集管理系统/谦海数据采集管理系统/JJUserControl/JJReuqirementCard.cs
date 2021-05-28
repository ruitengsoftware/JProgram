using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 谦海数据采集管理系统.JJModel;

namespace 谦海数据采集管理系统.JJUserControl
{
    public partial class JJReuqirementCard : UserControl
    {
    public     JJTaskInfo _myTaskInfo = new JJTaskInfo();


        public JJReuqirementCard()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }

        private void JJReuqirementCard_Load(object sender, EventArgs e)
        {
            lbl_bianhao.Text = $"No.{_myTaskInfo._bianhao}";
            lbl_youxianji.Text = $"优先级：{_myTaskInfo._youxianji}";
            lbl_mingcheng.Text = $"{_myTaskInfo._mingcheng}";
            lbl_fuzeren.Text = $"{_myTaskInfo._fuzeren}";
            lbl_haoshi.Text = $"{_myTaskInfo._haoshi}";
        }
        /// <summary>
        /// 点击任务名称触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_mingcheng_Click(object sender, EventArgs e)
        {
            //显示任务详情窗体，编号固定不可变
            //用户可以在详情窗体中修改信息，切换泳道，切换负责人，切换优先级，任务描述尽量不要修改
            //可以添加备注
            //修改完之后，可以保存，保存之后关闭详情窗体，然后卡片颜色显示黄色，表示有变化
            //如果提醒了某人，某人可以在卡片上看到红色的原点，当他点击查看之后，原点消失








        }
    }
}
