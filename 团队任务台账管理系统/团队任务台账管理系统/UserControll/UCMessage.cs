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
            if (o is JJQingdanInfo)
            {
                JJQingdanInfo info = o as JJQingdanInfo;
                //在uc上显示   象限  名称  完成时间
                this.lbl_xiangxian.Text = info._xiangxian;
                this.lbl_mingcheng.Text = info._renwumingcheng;
                this.lbl_wanchengshijian.Text =Convert.ToDateTime( info._wanchengshijian).ToString("yyyy-MM-dd");
                //获得当前时间
                //计算完成时间和现在的差
                DateTime dt0 = Convert.ToDateTime(info._wanchengshijian);
                DateTime dt = DateTime.Now;
                TimeSpan ts = dt0.Subtract(dt);

                //如果当前时间超过完成时间显示红点，如果完成时间比现在大不到三天显示黄点
                if (dt>dt0)
                {
                    pb_point.Image = Properties.Resources.redpoint;
                }
                if (dt<dt0 && dt.AddDays(3)>dt0)
                {
                    pb_point.Image = Properties.Resources.yellowpoint;

                }


            }
            if (o is JJTongzhiInfo)
            {
                //不是清单关闭销项
                pb_xiaoxiang.Visible = false;
                pb_shanchu.Visible = false;
                JJTongzhiInfo info = o as JJTongzhiInfo;
                //在uc上显示  状态标题 发布时间
                lbl_xiangxian.Text = string.Empty;
                if (info._zhuangtai.Equals("未读"))
                {
                    this.lbl_mingcheng.Font = new System.Drawing.Font(this.Font.Name, 9, FontStyle.Bold);


                }
                this.lbl_mingcheng.Text = info._biaoti;
                this.lbl_wanchengshijian.Text = info._fabushijian;

            }
            if (o is JJTaskInfo)
            {
                //不是清单关闭销项
                pb_xiaoxiang.Visible = false;
                pb_shanchu.Visible = false;

                JJTaskInfo info = o as JJTaskInfo;
                this.lbl_xiangxian.Text = info._jinjichengdu;
                this.tableLayoutPanel1.ColumnStyles[0].Width = 60;
                this.lbl_mingcheng.Text = info._mingcheng;
                this.lbl_mingcheng.TextAlign = ContentAlignment.MiddleLeft;
                this.lbl_wanchengshijian.Text = info._shixian;

            }




        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            _ui.DrawRoundRect((Control)sender);
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
        /// 点击内容按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            //判断uc的类型，工作清单，通知公告，待办任务
            if (task is JJTaskInfo)
            {
                JJTaskInfo info = task as JJTaskInfo;
                WFchangguishixiang mywin = new WFchangguishixiang(info);
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                    _updatemaindata(null, null);
                }
            }
            if (task is JJTongzhiInfo)
            {
                //将该任务的状态变为已读，，字体从粗体变为常规
                this.lbl_mingcheng.Font = new System.Drawing.Font(this.Font.Name, 9, FontStyle.Regular);
                JJTongzhiInfo info = task as JJTongzhiInfo;

                _myc.Yidu(info);//将状态从未读变为已读
                                //这里不在显示原窗体，改为word形式
                Document myword = new Document();
                DocumentBuilder myb = new DocumentBuilder(myword);
                //添加标题
                Aspose.Words.Font font = myb.Font;
                font.Size = 16;
                font.Bold = true;
                //font.Color = System.Drawing.Color.Blue;
                //font.Name = "Arial";
                //font.Underline = Underline.Dash;

                // Specify paragraph formatting
                ParagraphFormat paragraphFormat = myb.ParagraphFormat;
                //paragraphFormat.FirstLineIndent = 8;
                paragraphFormat.Alignment = ParagraphAlignment.Center;
                //paragraphFormat.KeepTogether = true;

                myb.Writeln(info._biaoti);



                //添加 签发人
               
                font.Size = 12;
                font.Bold = true;
                //font.Color = System.Drawing.Color.Blue;
                //font.Name = "Arial";
                //font.Underline = Underline.Dash;

                // Specify paragraph formatting
                 paragraphFormat = myb.ParagraphFormat;
                //paragraphFormat.FirstLineIndent = 8;
                paragraphFormat.Alignment = ParagraphAlignment.Center;
                //paragraphFormat.KeepTogether = true;

                myb.Writeln(info._qianfaren);
                myb.Writeln("");



                //添加内容
                font.Size = 12;
                font.Bold = false;
                //font.Color = System.Drawing.Color.Blue;
                //font.Name = "Arial";
                //font.Underline = Underline.Dash;

                // Specify paragraph formatting
                paragraphFormat = myb.ParagraphFormat;
                paragraphFormat.FirstLineIndent = 8;
                paragraphFormat.Alignment = ParagraphAlignment.Justify;
                //paragraphFormat.KeepTogether = true;

                myb.Writeln(info._neirong);

                string dataDir = @".\tongzhi.rtf";
                myword.Save(dataDir, SaveFormat.Rtf);
                WinFormTongzhi mywin = new WinFormTongzhi();
                mywin.ShowDialog();


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
                    _updatemaindata(null, null);

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
                _updatemaindata(null, null);

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
