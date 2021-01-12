using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuiTengDll;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.WinForm;
using Aspose.Words;
using 团队任务台账管理系统.Common;
using System.Text.RegularExpressions;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCMessage : UserControl
    {
        ControllerUCmsg _myc = new ControllerUCmsg();
        object task = new object();
        public Action<object, EventArgs> _updatemaindata = null;
        public UCMessage()
        {
            InitializeComponent();
        }
        UIHelper _ui = new UIHelper();
        public UCMessage(object o)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            task = o;
            if (o is JJQingdanInfo)//如果是工作清单
            {
                JJQingdanInfo info = o as JJQingdanInfo;
                //在uc上显示   象限  名称  完成时间
                this.lbl_xiangxian.Text = info._xiangxian;
                this.lbl_mingcheng.Text = info._renwumingcheng;
                this.lbl_shijian.Text = Convert.ToDateTime(info._wanchengshijian).ToString("yyyy-MM-dd");
                //获得当前时间
                //计算完成时间和现在的差
                DateTime dt0 = Convert.ToDateTime(info._wanchengshijian);
                DateTime dt = DateTime.Now;
                TimeSpan ts = dt0.Subtract(dt);

                //如果当前时间超过完成时间显示红点，如果完成时间比现在大不到三天显示黄点
                if (dt > dt0)
                {
                    pb_point.Image = Properties.Resources.redpoint;
                }
                if (dt < dt0 && dt.AddDays(3) > dt0)
                {
                    pb_point.Image = Properties.Resources.yellowpoint;

                }


            }
            if (o is JJTongzhiInfo)//如果是通知公告
            {
                //不是清单关闭销项
                lbl_leixing.Visible = false;
                pb_xiaoxiang.Visible = false;
                pb_shanchu.Visible = false;

                JJTongzhiInfo info = o as JJTongzhiInfo;
                //在uc上显示  状态标题 发布时间
                lbl_xiangxian.Text = string.Empty;
                this.lbl_shijian.Text = Convert.ToDateTime(info._shixian).ToString("yyyy-MM-dd");

                if (info._zhuangtai.Equals("未读"))
                {
                    this.lbl_mingcheng.Font = new System.Drawing.Font(this.Font.Name, 9, FontStyle.Bold);


                }
                this.lbl_mingcheng.Text = info._biaoti;
                this.lbl_shijian.Text = Convert.ToDateTime(info._fabushijian).ToString("yyyy-MM-dd");
                //判断轻重缓急，如果是紧急，任务显示红色，如果是普通，正常显示为黑色
                if (info._qingzhonghuanji.Equals("紧急"))
                {
                    lbl_mingcheng.ForeColor = Color.Red;
                }
            }
            if (o is JJTaskInfo)//如果是四大任务直以
            {
                //不是清单关闭销项
               
                pb_xiaoxiang.Visible = false;
                pb_shanchu.Visible = false;
                JJTaskInfo info = o as JJTaskInfo;
                string leixing = string.Empty;
                if (info._leixing.Equals("请休假单"))
                {
                    leixing = "假单";
                    //请假单时间赋值为终止时间
                    string end_time = Regex.Split(info._qizhishijian, @"\|")[1];
                    this.lbl_shijian.Text = Convert.ToDateTime(end_time).ToString("yyyy-MM-dd");
                    this.lbl_mingcheng.Text = info._shiyou;

                }
                else if (info._leixing.Equals("OKR事项"))
                {
                    leixing = "OKR";
                    this.lbl_shijian.Visible = false;
                    this.lbl_mingcheng.Text = info._mingcheng;

                }
                else if (info._leixing.Equals("常规事项"))
                {
                    leixing = "事务";
                    this.lbl_shijian.Text = Convert.ToDateTime(info._shixian).ToString("yyyy-MM-dd");
                    this.lbl_mingcheng.Text = info._mingcheng;

                }
                else if (info._leixing.Equals("意见建议"))
                {
                    leixing = "建言";
                    this.lbl_shijian.Visible = false;
                    this.lbl_mingcheng.Text = info._biaoti;

                }
                if (info._zhuangtai.Equals("未读"))
                {
                lbl_zhuangtai.Text = info._zhuangtai;
                    lbl_zhuangtai.Visible = true;
                }
                lbl_leixing.Text = leixing;
                lbl_leixing.Visible = true;

                this.lbl_xiangxian.Text = info._jinjichengdu;
                this.lbl_mingcheng.TextAlign = ContentAlignment.MiddleLeft;
                //判断紧急程度，如果是紧急，任务显示红色，如果是普通，正常显示为黑色
                if (info._jinjichengdu.Equals("紧急"))
                {
                    lbl_mingcheng.ForeColor = Color.Red;
                }

                try
                {
                    this.lbl_shijian.Text = Convert.ToDateTime(info._shixian).ToString("yyyy-MM-dd");

                }
                catch { }

            }




        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.SteelBlue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.DimGray;
        }
        /// <summary>
        /// 点击名称时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            //判断uc的类型，工作清单，通知公告，待办任务
            if (task is JJTaskInfo)
            {
                var myti = task as JJTaskInfo;
                //如果myti的状态是未读，就把状态变成未处理，然后让信封消失
                if (myti._zhuangtai.Equals("未读"))
                {
                    lbl_zhuangtai.Visible = false;
                    myti._zhuangtai = "处理中";
                    _myc.UpdateZhuangtai(myti);
                }
                //判断未读任务数量，如果是0，要取消主界面我的任务右侧的红点

                int num = JJLoginInfo.GetWeiduTaskNum();
                if (num > 0)
                {
                    (this.ParentForm as Form1).lbl_newtask.Visible = true;
                    (this.ParentForm as Form1).btn_woderenwu.Width = 65;

                    (this.ParentForm as Form1).lbl_newtask.Text = $"{num}";
                }
                else
                {
                    (this.ParentForm as Form1).lbl_newtask.Visible = false;
                    (this.ParentForm as Form1).btn_woderenwu.Width = 94;

                }

                JJTaskInfo info = task as JJTaskInfo;
                Form mywin = null;
                if (info._leixing.Equals("OKR事项"))
                {
                    mywin = new WFokrshixiang(info);

                }
                else if (info._leixing.Equals("常规事项"))
                {
                    mywin = new WFchangguishixiang(info);

                }
                else if (info._leixing.Equals("请休假单"))
                {
                    mywin = new WFqingxiujiadan(info);

                }
                else if (info._leixing.Equals("意见建议"))
                {
                    mywin = new WFyijianjianyi(info);

                }
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                    JJMethod.a_shuaxinzhuye(null, null);
                }
            }
            if (task is JJTongzhiInfo)
            {
                //将该任务的状态变为已读，，字体从粗体变为常规
                this.lbl_mingcheng.Font = new System.Drawing.Font(this.Font.Name, 9, FontStyle.Regular);
                JJTongzhiInfo info = task as JJTongzhiInfo;

                _myc.Yidu(info);//将状态从未读变为已读
                WinFormTongzhi mywin = new WinFormTongzhi(info);
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    JJMethod.a_shuaxinzhuye(null, null);
                }


                //WFtongzhigonggao mywin = new WFtongzhigonggao(info);
                //if (mywin.ShowDialog() == DialogResult.OK)
                //{
                //    //刷新数据
                //    _updatemaindata(null, null);

                //}
            }
            if (task is JJQingdanInfo)

            {





                JJQingdanInfo ci = task as JJQingdanInfo;
                WFgongzuoqingdan mywin = new WFgongzuoqingdan(ci);
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                    JJMethod.a_shuaxinzhuye(null, null);

                }
            }











        }
        /// <summary>
        /// 点击销项按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_xiaoxiang_Click(object sender, EventArgs e)
        {
            //显示心得体会窗口
            WinFormXiaoxiang mywin = new WinFormXiaoxiang(task)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            //刷新数据
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                JJMethod.a_shuaxinzhuye(null, null);
            }



        }

        private void lbl_shanchu_Click(object sender, EventArgs e)
        {
            //工作清单删除=0
            bool b = _myc.DeleteGongzuoqingdan(task);
            if (b)
            {
                _updatemaindata(null, null);
                MessageBox.Show("工作清单已删除！");
            }




        }
    }
}
