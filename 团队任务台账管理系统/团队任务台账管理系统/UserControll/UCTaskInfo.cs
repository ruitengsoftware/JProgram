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
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.WinForm;
using System.Text.RegularExpressions;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCTaskInfo : UserControl
    {

        ControllerUCtaskinfo myc = new ControllerUCtaskinfo();
        JJTaskInfo myti = new JJTaskInfo();
        public Action _closepanel = null;

        public Action _updatedata = null;

        public UCTaskInfo()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }


        public UCTaskInfo(JJTaskInfo ti)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            myti = ti;
            tb_renwumingcheng.Text = ti._mingcheng;
            if (ti._jinjichengdu == "普通")
            {
                rb_putong.Checked = true;
            }
            else if (ti._jinjichengdu == "急件")
            {
                rb_jijian.Checked = true;
            }
            else if (ti._jinjichengdu == "特急")
            {
                rb_teji.Checked = true;
            }
            tb_xiangqing.Text = ti._xiangqing;
            tb_fuzeren.Text = ti._fuzeren;
            tb_canyuren.Text = ti._canyuren;
            dtp_shixian.Value = Convert.ToDateTime(ti._shixian);


        }
        /// <summary>
        /// 点击完成任务时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_wancheng_Click(object sender, EventArgs e)
        {
            //不新增任务，修改当前未处理任务状态

            string str_sql = $"update jjdbrenwutaizhang.任务信息表 set 状态='已处理' where 名称='{tb_renwumingcheng.Text}' and 状态='未处理'";
            bool b = myc.DoSql(str_sql);
            if (b)
            {
                //刷新数据
                _updatedata();
                MessageBox.Show("任务已完成！");
            }
        }

        private void lbl_fasong_Click(object sender, EventArgs e)
        {
            //修改当前myti的状态为已处理，同时插入新的任务记录，状态为未读取
            string str_sql = $"update jjdbrenwutaizhang.任务信息表 set 状态='已处理'  where 名称='{tb_renwumingcheng.Text}' and 状态='未处理'";
            myc.DoSql(str_sql);



            //不新增任务，修改当前未处理任务状态
            str_sql = $"insert into jjdbrenwutaizhang.任务信息表 values('{myti._mingcheng}'," +
                $"'{myti._leixing}','{myti._fuzeren}','{myti._canyuren}','未读','{myti._xiangqing}','{JJLoginInfo._huaming}','{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'," +
                $"'','{myti._shixian}','{myti._jinjichengdu}',0)";
            bool b = myc.DoSql(str_sql);
            if (b)
            {
                //如果负责人或者责任人包括登录名称，需要在我的任务右侧显示红点
                string[] arr_canyuren = Regex.Split(myti._canyuren, "[,，|]");
                if (myti._fuzeren.Contains(JJLoginInfo._huaming)|| arr_canyuren.Contains(JJLoginInfo._huaming))
                {
                    (this.ParentForm as Form1).pb_newtask.Visible = true;
                }


                _updatedata();
                MessageBox.Show("任务已发送！");
            }

        }

        private void rb_putong_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_putong.Checked)
            {
                myti._jinjichengdu = "普通";
            }
        }

        private void rb_jijian_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_jijian.Checked)
            {
                myti._jinjichengdu = "急件";
            }

        }

        private void rb_teji_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_teji.Checked)
            {
                myti._jinjichengdu = "特急";
            }

        }

        private void tb_xiangqing_TextChanged(object sender, EventArgs e)
        {
            myti._xiangqing = tb_xiangqing.Text;
        }



        private void dtp_shixian_ValueChanged(object sender, EventArgs e)
        {
            myti._shixian = Convert.ToDateTime(dtp_shixian.Value).ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _closepanel();
        }

        private void tb_fuzeren_TextChanged(object sender, EventArgs e)
        {
            myti._fuzeren = tb_fuzeren.Text;
        }

        private void tb_canyuren_TextChanged(object sender, EventArgs e)
        {
            myti._canyuren = tb_canyuren.Text;
        }

        private void pb_delete_Click(object sender, EventArgs e)
        {
            string str_sql = $"update jjdbrenwutaizhang.任务信息表 set 状态='已删除'  where 名称='{myti._mingcheng}' and 创建人='{myti._chuangjianren}' and 创建时间='{myti._chuangjianshijian}'";
            bool b = myc.DoSql(str_sql);
            if (b)
            {
                _updatedata();
                MessageBox.Show("任务已删除！");
            }
        }

        private void lbl_chakanyidu_Click(object sender, EventArgs e)
        {
            WinFormYidu mywin = new WinFormYidu(myti);
            mywin.StartPosition = FormStartPosition.CenterParent;
            if (mywin.ShowDialog()==DialogResult.OK)
            {

            }
        }
    }
}
