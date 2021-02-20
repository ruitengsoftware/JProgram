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
                this.lbl_leixing.Text = Regex.Match(info._xiangxian, @".类").Value;
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
                JJTongzhiInfo info = o as JJTongzhiInfo;
                //不是清单关闭销项
                lbl_leixing.Visible = false;
                pb_xiaoxiang.Visible = false;
                pb_shanchu.Visible = false;
                //如果创建人等于登陆人那么显示编辑和删除按钮
                if (info._chuangjianren.Equals(JJLoginInfo._shiming))
                {
                    link_bianji.Visible = true;
                    link_shanchu.Visible = true;

                }

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
                    myti._zhuangtai = "办理中";
                    _myc.UpdateZhuangtai(myti);
                }
                //判断未读任务数量，如果是0，要取消主界面我的任务右侧的红点

                int num = JJLoginInfo.GetWeiduTaskNum();
                if (num > 0)
                {
                    (this.ParentForm as Form1).lbl_newtask.Visible = true;

                    (this.ParentForm as Form1).lbl_newtask.Text = $"{num}";
                }
                else
                {
                    (this.ParentForm as Form1).lbl_newtask.Visible = false;

                }
                //在这里，不能直接使用转换后的task，因为信息不完整，应当根据类型和名称获得状态为“保存的”taskinfo
                JJTaskInfo info0 = task as JJTaskInfo;
                JJTaskInfo info = GetBaocunTask(info0);
                Form mywin = null;
                if (info._leixing.Equals("OKR事项"))
                {
                    mywin = new WFokrshixiang(info) { StartPosition = FormStartPosition.CenterParent };

                }
                else if (info._leixing.Equals("常规事项"))
                {
                    mywin = new WFchangguishixiang(info) { StartPosition = FormStartPosition.CenterParent };

                }
                else if (info._leixing.Equals("请休假单"))
                {
                    mywin = new WFqingxiujiadan(info) { StartPosition = FormStartPosition.CenterParent };

                }
                else if (info._leixing.Equals("意见建议"))
                {
                    mywin = new WFyijianjianyi(info) { StartPosition = FormStartPosition.CenterParent };

                }
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                    JJMethod.a_shuaxinzhuye(null, null);
                }
            }
            //如果是通知公告类型
            if (task is JJTongzhiInfo)
            {
                //将该任务的状态变为已读，，字体从粗体变为常规
                this.lbl_mingcheng.Font = new System.Drawing.Font(this.Font.Name, 9, FontStyle.Regular);
                JJTongzhiInfo info = task as JJTongzhiInfo;

                _myc.Yidu(info);//将状态从未读变为已读
                WinFormTongzhi mywin = new WinFormTongzhi(info) { StartPosition = FormStartPosition.CenterParent };
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
            //如果是工作清单类型
            if (task is JJQingdanInfo)
            {
                JJQingdanInfo ci = task as JJQingdanInfo;
                WFgongzuoqingdan mywin = new WFgongzuoqingdan(ci) { StartPosition = FormStartPosition.CenterParent };
                if (mywin.ShowDialog() == DialogResult.OK)
                {
                    //刷新数据
                    JJMethod.a_shuaxinzhuye(null, null);

                }
            }
        }
        MySQLHelper _mysql = new MySQLHelper();
        /// <summary>
        /// 获得状态为保存的任务信息
        /// </summary>
        /// <returns></returns>
        public JJTaskInfo GetBaocunTask(JJTaskInfo info)
        {
            string str_sql = string.Empty;
            //判断类型,请休假单事由，事项名称，意见建议标题
            if (info._leixing.Equals("常规事项") || info._leixing.Equals("OKR事项"))
            {
                str_sql = $"select * from jjdbrenwutaizhang.任务信息表 " +
                    $"where 名称='{info._mingcheng}' and 类型='{info._leixing}' and 状态='保存' and 删除=0";

            }
            else if (info._leixing.Equals("请休假单"))
            {
                str_sql = $"select * from jjdbrenwutaizhang.任务信息表 " +
                    $"where 事由='{info._shiyou}' and 类型='{info._leixing}' and 状态='保存' and 删除=0";

            }
            else if (info._leixing.Equals("意见建议"))
            {
                str_sql = $"select * from jjdbrenwutaizhang.任务信息表 " +
    $"where 标题='{info._biaoti}' and 类型='{info._leixing}' and 状态='保存' and 删除=0";

            }


            DataRow mydr = _mysql.ExecuteDataRow(str_sql);
            JJTaskInfo result = new JJTaskInfo();

            try
            {
                result._mingcheng = mydr["名称"].ToString();
            }
            catch (Exception)
            {
                result._mingcheng = string.Empty;
            }
            try
            {
                result._leixing = mydr["类型"].ToString();
            }
            catch { result._leixing = string.Empty; }
            result._zhuangtai = mydr["状态"].ToString();
            result._xiangqing = mydr["详情"].ToString();
            result._chuangjianren = mydr["创建人"].ToString();
            result._chuangjianshijian = mydr["创建时间"].ToString();
            result._duqushijian = mydr["读取时间"].ToString();
            result._shixian = mydr["时限"].ToString();
            result._jinjichengdu = mydr["紧急程度"].ToString();
            result._mubiao = mydr["总体目标"].ToString();
            result._chengguoji = mydr["成果集"].ToString();
            result._shenqingren = mydr["申请人"].ToString();
            result._shiyou = mydr["事由"].ToString();
            result._kaishishijian = mydr["开始时间"].ToString();
            result._jieshushijian = mydr["结束时间"].ToString();
            result._weituoduixiang = mydr["委托对象"].ToString();
            result._shenheyijian = mydr["审核意见"].ToString();
            result._biaoti = mydr["标题"].ToString();
            result._fankuiren = mydr["反馈人"].ToString();
            result._fankuiduixiang = mydr["反馈对象"].ToString();
            result._neirong = mydr["内容"].ToString();
            result._banliyijian = mydr["办理意见"].ToString();
            result._banlirenyuan = mydr["办理人员"].ToString();
            result._jinzhanqingkuang = mydr["进展情况"].ToString();
            result._zongtiyanshouren = mydr["总体验收人"].ToString();
            result._chuliyijian = mydr["处理意见"].ToString();
            result._shenherenyuan = mydr["审核人员"].ToString();
            result._fasongren = mydr["发送人"].ToString();
            result._fasongshijian = mydr["发送时间"].ToString();
            result._jutiyaoqiu = mydr["具体要求"].ToString();
            result._fujian = mydr["附件"].ToString();
            result._qizhishijian = mydr["起止时间"].ToString();
            result._xiaojiaqingkuang = mydr["销假情况"].ToString();
            result._qingjiatianshu = mydr["请假天数"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(mydr["请假天数"].ToString());
            return result;


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
        /// <summary>
        /// 点击删除图片时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shanchu_Click(object sender, EventArgs e)
        {
            //工作清单删除=0
            bool b = _myc.DeleteGongzuoqingdan(task);
            if (b)
            {
                JJMethod.a_shuaxinzhuye(null, null);
                MessageBox.Show("工作清单已删除！");
            }
        }
        /// <summary>
        /// 点击删除按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_shanchu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //显示提示框，是否确认删除
            DialogResult mydr = MessageBox.Show("确认删除?", "删除信息", MessageBoxButtons.YesNo);
            if (mydr == DialogResult.Yes)
            {
                //从通知公告表中删除通知
                string name = lbl_mingcheng.Text;
                string str_sql = $"delete from jjdbrenwutaizhang.通知公告表 where 标题='{name}'";
                _mysql.ExecuteNonQuery(str_sql);
                //刷新主界面
                JJMethod.a_shuaxinzhuye(null, null);
                //显示删除成功
                MessageBox.Show("通知公告已删除！");
            }


        }

        private void link_bianji_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //获得通知公告表中标题对应的信息，实例化一个jjtongzhiinfo
            string biaoti = lbl_mingcheng.Text;
            string leixing = lbl_leixing.Text;
            //实例化一个mftongzhigonggao，把jjtongzhiinfo传递进来，mftongzhigonggao的状态设置为编辑模式（还有一个是创建模式）
            string str_sql = $"select * from jjdbrenwutaizhang.通知公告表 " +
                $"where 标题='{biaoti}'";
            DataTable mydt = _mysql.ExecuteDataTable(str_sql);
            List<string> list_fanwei = new List<string>();
            foreach (DataRow dataRow in mydt.Rows)
            {
                list_fanwei.Add(dataRow["阅读范围"].ToString());
            }
            JJTongzhiInfo myinfo = new JJTongzhiInfo() {
                _biaoti = mydt.Rows[0]["标题"].ToString(),
                _qianfaren = mydt.Rows[0]["签发人"].ToString(),
                _qingzhonghuanji = mydt.Rows[0]["轻重缓急"].ToString(),
                _neirongpath = mydt.Rows[0]["内容"].ToString(),
                _shixian = mydt.Rows[0]["时限"].ToString(),
                _fujian = mydt.Rows[0]["附件"].ToString(),
                _chuangjianren = mydt.Rows[0]["创建人"].ToString(),
                _yuedufanwei = string.Join(",", list_fanwei)
            };
            WFtongzhigonggao mywin = new WFtongzhigonggao(myinfo);
            mywin.mode = "编辑";
            if (mywin.ShowDialog()==DialogResult.OK)
            {
                JJMethod.a_shuaxinzhuye(null, null);
            }

        }
    }
}
