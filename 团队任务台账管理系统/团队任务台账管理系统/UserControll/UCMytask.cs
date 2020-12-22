using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;
using System.Text.RegularExpressions;
using 团队任务台账管理系统.WinForm;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCMytask : UserControl
    {
        ControllerUCmytask _mycontroller = new ControllerUCmytask();
        public UCMytask()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public void lbl_quanbu_Click(object sender, EventArgs e)
        {
            foreach (Control  c  in tlp_button.Controls)
            {
                c.BackColor = Color.Tomato;
            }
            lbl_quanbu.BackColor = Color.Salmon;



            //清空界面首先
            panel_task.Controls.Clear();
            //获得全部任务 
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态<>'已删除'";
            var list = _mycontroller.GetTaskinfo(str_sql);

            //构造ucteakmsg
            foreach (JJTaskInfo ti in list)
            {
                UCTaskmsg myuc = new UCTaskmsg(ti);
                myuc.a = () => { splitContainer1.Panel2Collapsed = false; };
                myuc._closepanel = () => { splitContainer1.Panel2Collapsed = true; };
                myuc._updatedata = () => {
                    //获得当前显示的数据
                    string data = string.Empty;
                    foreach (Control c in tlp_button.Controls)
                    {
                        if (c.BackColor==Color.Salmon)
                        {
                            data = c.Text;
                        }
                    }
                    //模拟不同的按钮点击事件
                    if (data.Equals("全部"))
                    {
                        lbl_quanbu_Click(null,null);
                    }
                    else if(data.Equals("我发起的"))
                    {
                        lbl_wofaqide_Click(null, null);
                    }
                    else if (data.Equals("我的待办"))
                    {
                        lbl_daiban_Click(null, null);
                    }
                    else if (data.Equals("我参与的"))
                    {
                        lbl_canyu_Click(null, null);
                    }
                    else if (data.Equals("已处理"))
                    {
                        lbl_chuli_Click(null, null);
                    }
                    else if (data.Equals("回收站"))
                    {
                        lbl_huishou_Click(null, null);
                    }

                };
                myuc._p = p_taskdetail;
                //添加到panel_task

                panel_task.Controls.Add(myuc);

            }
        }
        /// <summary>
        /// 点击我的待办按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_daiban_Click(object sender, EventArgs e)
        {
            foreach (Control c in tlp_button.Controls)
            {
                c.BackColor = Color.Tomato;
            }
            lbl_daiban.BackColor = Color.Salmon;

            //清空界面首先
            panel_task.Controls.Clear();

            //获得全部任务 
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态<>'已处理' and 状态<>'已删除'";
            var list = _mycontroller.GetTaskinfo(str_sql);

            //构造ucteakmsg
            foreach (JJTaskInfo ti in list)
            {
                UCTaskmsg myuc = new UCTaskmsg(ti);
                myuc.a = () => { splitContainer1.Panel2Collapsed = false; };
                myuc._closepanel = () => { splitContainer1.Panel2Collapsed = true; };
                myuc._updatedata = () => {
                    //获得当前显示的数据
                    string data = string.Empty;
                    foreach (Control c in tlp_button.Controls)
                    {
                        if (c.BackColor == Color.Salmon)
                        {
                            data = c.Text;
                        }
                    }
                    //模拟不同的按钮点击事件
                    if (data.Equals("全部"))
                    {
                        lbl_quanbu_Click(null, null);
                    }
                    else if (data.Equals("我发起的"))
                    {
                        lbl_wofaqide_Click(null, null);
                    }
                    else if (data.Equals("我的待办"))
                    {
                        lbl_daiban_Click(null, null);
                    }
                    else if (data.Equals("我参与的"))
                    {
                        lbl_canyu_Click(null, null);
                    }
                    else if (data.Equals("已处理"))
                    {
                        lbl_chuli_Click(null, null);
                    }
                    else if (data.Equals("回收站"))
                    {
                        lbl_huishou_Click(null, null);
                    }

                };

                myuc._p = p_taskdetail;
                //添加到panel_task

                panel_task.Controls.Add(myuc);

            }

        }
        /// <summary>
        /// 点击我参与的按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_canyu_Click(object sender, EventArgs e)
        {
            foreach (Control c in tlp_button.Controls)
            {
                c.BackColor = Color.Tomato;
            }
            lbl_canyu.BackColor = Color.Salmon;

            //清空界面首先
            panel_task.Controls.Clear();

            //获得全部任务 
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 ";
            var list = _mycontroller.GetTaskinfo(str_sql);
            //构造ucteakmsg
            foreach (JJTaskInfo ti in list)
            {
                //判断参与人是否包括登录者，如果不包括就continue
                string[] str = Regex.Split(ti._canyuren, @"[|,，]");
                if (!str.Contains(JJLoginInfo._huaming))
                {
                    continue;
                }
                UCTaskmsg myuc = new UCTaskmsg(ti);
                myuc.a = () => { splitContainer1.Panel2Collapsed = false; };
                myuc._closepanel = () => { splitContainer1.Panel2Collapsed = true; };
                myuc._updatedata = () => {
                    //获得当前显示的数据
                    string data = string.Empty;
                    foreach (Control c in tlp_button.Controls)
                    {
                        if (c.BackColor == Color.Salmon)
                        {
                            data = c.Text;
                        }
                    }
                    //模拟不同的按钮点击事件
                    if (data.Equals("全部"))
                    {
                        lbl_quanbu_Click(null, null);
                    }
                    else if (data.Equals("我发起的"))
                    {
                        lbl_wofaqide_Click(null, null);
                    }
                    else if (data.Equals("我的待办"))
                    {
                        lbl_daiban_Click(null, null);
                    }
                    else if (data.Equals("我参与的"))
                    {
                        lbl_canyu_Click(null, null);
                    }
                    else if (data.Equals("已处理"))
                    {
                        lbl_chuli_Click(null, null);
                    }
                    else if (data.Equals("回收站"))
                    {
                        lbl_huishou_Click(null, null);
                    }

                };

                myuc._p = p_taskdetail;
                //添加到panel_task
                panel_task.Controls.Add(myuc);
            }
        }
        /// <summary>
        /// 点击已处理按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_chuli_Click(object sender, EventArgs e)
        {
            foreach (Control c in tlp_button.Controls)
            {
                c.BackColor = Color.Tomato;
            }
            lbl_chuli.BackColor = Color.Salmon;

            //清空界面首先
            panel_task.Controls.Clear();
            //获得全部任务 
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态='已处理'";
            var list = _mycontroller.GetTaskinfo(str_sql);
            //构造ucteakmsg
            foreach (JJTaskInfo ti in list)
            {
                UCTaskmsg myuc = new UCTaskmsg(ti);
                myuc.a = () => { splitContainer1.Panel2Collapsed = false; };
                myuc._closepanel = () => { splitContainer1.Panel2Collapsed = true; };
                myuc._updatedata = () => {
                    //获得当前显示的数据
                    string data = string.Empty;
                    foreach (Control c in tlp_button.Controls)
                    {
                        if (c.BackColor == Color.Salmon)
                        {
                            data = c.Text;
                        }
                    }
                    //模拟不同的按钮点击事件
                    if (data.Equals("全部"))
                    {
                        lbl_quanbu_Click(null, null);
                    }
                    else if (data.Equals("我发起的"))
                    {
                        lbl_wofaqide_Click(null, null);
                    }
                    else if (data.Equals("我的待办"))
                    {
                        lbl_daiban_Click(null, null);
                    }
                    else if (data.Equals("我参与的"))
                    {
                        lbl_canyu_Click(null, null);
                    }
                    else if (data.Equals("已处理"))
                    {
                        lbl_chuli_Click(null, null);
                    }
                    else if (data.Equals("回收站"))
                    {
                        lbl_huishou_Click(null, null);
                    }

                };

                myuc._p = p_taskdetail;
                //添加到panel_task
                panel_task.Controls.Add(myuc);
            }
        }
        /// <summary>
        /// 点击回收站按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_huishou_Click(object sender, EventArgs e)
        {
            foreach (Control c in tlp_button.Controls)
            {
                c.BackColor = Color.Tomato;
            }
            lbl_huishou.BackColor = Color.Salmon;

            //清空界面首先
            panel_task.Controls.Clear();
            //获得全部任务 
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态='已删除'";
            var list = _mycontroller.GetTaskinfo(str_sql);
            //构造ucteakmsg
            foreach (JJTaskInfo ti in list)
            {
                UCTaskmsg myuc = new UCTaskmsg(ti);
                myuc.a = () => { splitContainer1.Panel2Collapsed = false; };
                myuc._closepanel = () => { splitContainer1.Panel2Collapsed = true; };
                myuc._updatedata = () => {
                    //获得当前显示的数据
                    string data = string.Empty;
                    foreach (Control c in tlp_button.Controls)
                    {
                        if (c.BackColor == Color.Salmon)
                        {
                            data = c.Text;
                        }
                    }
                    //模拟不同的按钮点击事件
                    if (data.Equals("全部"))
                    {
                        lbl_quanbu_Click(null, null);
                    }
                    else if (data.Equals("我发起的"))
                    {
                        lbl_wofaqide_Click(null, null);
                    }
                    else if (data.Equals("我的待办"))
                    {
                        lbl_daiban_Click(null, null);
                    }
                    else if (data.Equals("我参与的"))
                    {
                        lbl_canyu_Click(null, null);
                    }
                    else if (data.Equals("已处理"))
                    {
                        lbl_chuli_Click(null, null);
                    }
                    else if (data.Equals("回收站"))
                    {
                        lbl_huishou_Click(null, null);
                    }

                };

                myuc._p = p_taskdetail;
                //添加到panel_task
                panel_task.Controls.Add(myuc);
            }
        }

        private void lbl_wofaqide_Click(object sender, EventArgs e)
        {
            foreach (Control c in tlp_button.Controls)
            {
                c.BackColor = Color.Tomato;
            }
            lbl_wofaqide.BackColor = Color.Salmon;

            //清空界面首先
            panel_task.Controls.Clear();
            //获得全部任务 
            string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态<>'已删除' and 创建人='{JJLoginInfo._huaming}'";
            var list = _mycontroller.GetTaskinfo(str_sql);
            //构造ucteakmsg
            foreach (JJTaskInfo ti in list)
            {
                UCTaskmsg myuc = new UCTaskmsg(ti);
                myuc.a = () => { splitContainer1.Panel2Collapsed = false; };
                myuc._closepanel = () => { splitContainer1.Panel2Collapsed = true; };
                myuc._updatedata = () => {
                    //获得当前显示的数据
                    string data = string.Empty;
                    foreach (Control c in tlp_button.Controls)
                    {
                        if (c.BackColor == Color.Salmon)
                        {
                            data = c.Text;
                        }
                    }
                    //模拟不同的按钮点击事件
                    if (data.Equals("全部"))
                    {
                        lbl_quanbu_Click(null, null);
                    }
                    else if (data.Equals("我发起的"))
                    {
                        lbl_wofaqide_Click(null, null);
                    }
                    else if (data.Equals("我的待办"))
                    {
                        lbl_daiban_Click(null, null);
                    }
                    else if (data.Equals("我参与的"))
                    {
                        lbl_canyu_Click(null, null);
                    }
                    else if (data.Equals("已处理"))
                    {
                        lbl_chuli_Click(null, null);
                    }
                    else if (data.Equals("回收站"))
                    {
                        lbl_huishou_Click(null, null);
                    }

                };

                myuc._p = p_taskdetail;
                //添加到panel_task
                panel_task.Controls.Add(myuc);
            }

        }

        private void UCMytask_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            lbl_quanbu_Click(null, null);
        }

        private void lbl_newtask_Click(object sender, EventArgs e)
        {
            WFchangguishixiang wfxinjian = new WFchangguishixiang() { StartPosition = FormStartPosition.CenterParent };
            wfxinjian.StartPosition = FormStartPosition.CenterParent;
            if (wfxinjian.ShowDialog()==DialogResult.OK)
            {
                var myt = wfxinjian.mytask;
                //如果负责人或者责任人包括登录名称，需要在我的任务右侧显示红点
                string[] arr_canyuren = Regex.Split(myt._canyuren, "[,，|]");
                if (myt._fuzeren.Contains(JJLoginInfo._huaming) || arr_canyuren.Contains(JJLoginInfo._huaming))
                {
                    (this.ParentForm as Form1).pb_newtask.Visible = true;
                }

                //刷新数据
                //获得当前显示的数据
                string data = string.Empty;
                foreach (Control c in tlp_button.Controls)
                {
                    if (c.BackColor == Color.Salmon)
                    {
                        data = c.Text;
                    }
                }
                //模拟不同的按钮点击事件
                if (data.Equals("全部"))
                {
                    lbl_quanbu_Click(null, null);
                }
                else if (data.Equals("我发起的"))
                {
                    lbl_wofaqide_Click(null, null);
                }
                else if (data.Equals("我的待办"))
                {
                    lbl_daiban_Click(null, null);
                }
                else if (data.Equals("我参与的"))
                {
                    lbl_canyu_Click(null, null);
                }
                else if (data.Equals("已处理"))
                {
                    lbl_chuli_Click(null, null);
                }
                else if (data.Equals("回收站"))
                {
                    lbl_huishou_Click(null, null);
                }


            }


        }
    }
}
