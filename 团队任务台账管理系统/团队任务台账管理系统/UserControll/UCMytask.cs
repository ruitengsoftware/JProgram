﻿using System;
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
        MySQLHelper _mysql = new MySQLHelper();
        public void lbl_quanbu_Click(object sender, EventArgs e)
        {
            #region 老版本显示任务

            ////更新按钮样式，选中的按钮 高亮
            //foreach (Control  c  in tlp_button.Controls)
            //{
            //    c.BackColor = Color.Tomato;
            //}
            //lbl_quanbu.BackColor = Color.Salmon;



            ////清空界面首先
            //panel_task.Controls.Clear();
            ////获得全部任务 
            //string str_sql = $"select * from jjdbrenwutaizhang.任务信息表 where 状态<>'已删除' and (办理人员='{JJLoginInfo._shiming}' " +
            //    $"or 创建人='{JJLoginInfo._shiming}' or 审核人员='{JJLoginInfo._shiming}' or 反馈对象='{JJLoginInfo._shiming}')";
            //var list = _mycontroller.GetTaskinfo(str_sql);

            ////构造ucteakmsg
            //foreach (JJTaskInfo ti in list)
            //{
            //    UCTaskmsg myuc = new UCTaskmsg(ti);
            //    myuc.a = () => { splitContainer1.Panel2Collapsed = false; };
            //    myuc._closepanel = () => { splitContainer1.Panel2Collapsed = true; };
            //    myuc._updatedata = () => {
            //        //获得当前显示的数据
            //        string data = string.Empty;
            //        foreach (Control c in tlp_button.Controls)
            //        {
            //            if (c.BackColor==Color.Salmon)
            //            {
            //                data = c.Text;
            //            }
            //        }
            //        //模拟不同的按钮点击事件
            //        if (data.Equals("全部"))
            //        {
            //            lbl_quanbu_Click(null,null);
            //        }
            //        else if(data.Equals("我发起的"))
            //        {
            //            lbl_wofaqide_Click(null, null);
            //        }
            //        else if (data.Equals("我的待办"))
            //        {
            //            lbl_daiban_Click(null, null);
            //        }
            //        else if (data.Equals("我参与的"))
            //        {
            //            lbl_canyu_Click(null, null);
            //        }
            //        else if (data.Equals("已处理"))
            //        {
            //            lbl_chuli_Click(null, null);
            //        }
            //        else if (data.Equals("回收站"))
            //        {
            //            lbl_huishou_Click(null, null);
            //        }

            //    };
            //    myuc._p = p_taskdetail;
            //    //添加到panel_task

            //    panel_task.Controls.Add(myuc);

            //}

            #endregion
            List<object> _list_my = new List<object>();
            //获得我创建的工作清单
            string str_sql = $"select * from jjdbrenwutaizhang.工作清单表 " +
                $"where 创建人='{JJLoginInfo._shiming}'";
            DataTable _mydt = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow dataRow in _mydt.Rows)
            {
                JJQingdanInfo _myInfo = new JJQingdanInfo() { 
                _renwumingcheng=dataRow[""].ToString(),
                _qingzhonghuanji= dataRow[""].ToString(),
                _jingyanjiaoxun= dataRow[""].ToString(),
                _beizhu= dataRow[""].ToString(),
                _wanchengshijian= dataRow[""].ToString(),

                };
                _list_my.Add(_myInfo);
            }
            //获得我创建的通知公告
            str_sql = $"select * from jjdbrenwutaizhang.通知公告表 " +
                  $"where 创建人='{JJLoginInfo._shiming}'";
            _mydt = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow dataRow in _mydt.Rows)
            {
                JJTongzhiInfo _myInfo = new JJTongzhiInfo()
                {
                    _biaoti = dataRow[""].ToString(),
                    _neirongpath = dataRow[""].ToString(),
                    _qingzhonghuanji = dataRow[""].ToString(),
                    _yuedufanwei  = dataRow[""].ToString(),
                };
                _list_my.Add(_myInfo);
            }

            //获得我创建的任务
            str_sql = $"select * from jjdbrenwutaizhang.任务信息表 " +
                        $"where 创建人='{JJLoginInfo._shiming}'";
            _mydt = _mysql.ExecuteDataTable(str_sql);
            foreach (DataRow dataRow in _mydt.Rows)
            {
                JJTaskInfo _myInfo = new JJTaskInfo()
                {
                    _mingcheng = dataRow[""].ToString(),
                    _leixing = dataRow[""].ToString(),
                    _xiangqing= dataRow[""].ToString(),
                    _shixian = dataRow[""].ToString(),
                    _jinjichengdu = dataRow[""].ToString(),
                    _mubiao= dataRow[""].ToString(),
                    _chengguoji= dataRow[""].ToString(),
                    _shenqingren= dataRow[""].ToString(),
                    _weituoduixiang= dataRow[""].ToString(),
                                       _shenheyijian = dataRow[""].ToString(),
                                       _biaoti= dataRow[""].ToString(),
                                       _fankuiren= dataRow[""].ToString(),
                                       _fankuiduixiang= dataRow[""].ToString(),
                                       _neirong= dataRow[""].ToString(),
                    _shiyou = dataRow[""].ToString(),
                    _banliyijian = dataRow[""].ToString(),
                    _banlirenyuan = dataRow[""].ToString(),
                    _jinzhanqingkuang = dataRow[""].ToString(),
                    _shenherenyuan= dataRow[""].ToString(),
                    _jutiyaoqiu = dataRow[""].ToString(),
                    _fujian= dataRow[""].ToString(),
                    _qizhishijian= dataRow[""].ToString(),


                };
                _list_my.Add(_myInfo);
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
