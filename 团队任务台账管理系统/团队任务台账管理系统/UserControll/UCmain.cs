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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using 团队任务台账管理系统.Common;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCmain : UserControl
    {
        ControllerUCmain _mycontroller = new ControllerUCmain();
        //记录当前右键选中的dgv
        DataGridView dgv_right = null;
        public UCmain()
        {
            InitializeComponent();
        }
        List<string> _list_item = new List<string>();//显示哪些项目，通知公告，待办任务，工作清单
        public UCmain(List<string> list)
        {
            InitializeComponent();
            _list_item = list;

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
        private void btn_daiban_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCdaiban uc_daiban = new UCdaiban();
            uc_daiban.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_daiban);

        }

        private void btn_xinjian_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCxinjian uc_xinjian = new UCxinjian();
            uc_xinjian.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_xinjian);

        }

        private void btn_tuandui_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCtuandui uc_tuandui = new UCtuandui();
            uc_tuandui.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_tuandui);

        }

        private void btn_rizhi_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            UCrizhi uc_rizhi = new UCrizhi();
            uc_rizhi.Dock = DockStyle.Fill;
            parent.Controls.Add(uc_rizhi);
        }

        private void btn_fankui_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();
            parent.Controls.Add(new UCfankui() { Dock = DockStyle.Fill }); ;
        }

       

        private void btn_shouquan_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            parent.Controls.Clear();

            parent.Controls.Add(new UCshouquan() { Dock = DockStyle.Fill });

        }

        private void tb_qianming_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BorderStyle = BorderStyle.FixedSingle;
        }

        private void tb_qianming_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BorderStyle = BorderStyle.None;

        }


        public void UpdatePgongzuoqingdan(object o)
        {
            List<JJQingdanInfo> list = o as List<JJQingdanInfo>;
            //加载工作清单
            panel_gongzuoqingdan.Controls.Clear();

            //记载是否已经显示了ABC类
            List<string> list_leibie = new List<string>();


            for (int i = 0; i < list.Count; i++)
            {
                var info = list[i];
                UCMessage myuc = new UCMessage(info);
                myuc._updatemaindata = UCmain_Load;
                //判断INFO的类别，给myuc的lbl_leibie赋值，但是如果已经出现过，就不赋值
                string str_lei = Regex.Match(info._qingzhonghuanji, @".类").Value;
                if (!list_leibie.Contains(str_lei))
                {
                    myuc.lbl_leixing.Text = str_lei;
                    //改颜色 A红B黄C绿D黑
                    if (str_lei.Equals("A类"))
                    {
                        myuc.lbl_leixing.ForeColor = Color.Red;
                    }
                    if (str_lei.Equals("B类"))
                    {
                        myuc.lbl_leixing.ForeColor = Color.Gold;
                    }
                    if (str_lei.Equals("C类"))
                    {
                        myuc.lbl_leixing.ForeColor = Color.Green;
                    }
                    if (str_lei.Equals("D类"))
                    {
                        myuc.lbl_leixing.ForeColor = Color.Black;
                    }



                    list_leibie.Add(str_lei);
                }
                else
                {
                    myuc.lbl_leixing.Text = string.Empty;
                }


                panel_gongzuoqingdan.Controls.Add(myuc);
                panel_gongzuoqingdan.Controls.SetChildIndex(myuc, 0);
            }

            //刷新工作清单总数
            //lbl_gongzuoqingdan.Text = $"工作清单  {qingdannum}项";
            lbl_gongzuoqingdan.Text = $"工作清单  共{panel_gongzuoqingdan.Controls.Count}项";

        }

        public void UpdatePdaiban(object o)
        {
            panel_daibanrenwu.Controls.Clear();
            List<JJTaskInfo> list_daiban = o as List<JJTaskInfo>;
            for (int i = list_daiban.Count - 1; i >= 0; i--)
            {
                JJTaskInfo info = list_daiban[i];
                UCMessage myuc = new UCMessage(info);
                panel_daibanrenwu.Controls.Add(myuc);
            }
            //显示待办任务数量
            gb_daibairenwu.Text = $"待办任务 共{panel_daibanrenwu.Controls.Count}项";


        }

        public void UpdatePtongzhi(object o)
        {
            /*刷新通知公告*/
            panel_tongzhi.Controls.Clear();
            var list_tongzhi = o as List<JJTongzhiInfo>;
            //dgv_tongzhi.DataSource = null;
            //dgv_tongzhi.DataSource = mydt;
            foreach (JJTongzhiInfo dr in list_tongzhi)
            {
                UCMessage myuc = new UCMessage(dr);
                panel_tongzhi.Controls.Add(myuc);
            }
            //显示通知公告,显示多少项，红几项，黄几项
            gb_tongzhigonggao.Text = $"通知公告 共{panel_tongzhi.Controls.Count}项";
        }




        private void UCmain_Load(object sender, EventArgs e)
        {
            //加载ucmain的时候要提取登陆者信息，显示在界面中
            if (_list_item.Contains("工作清单"))
            {
                if (_list_item.Count == 3)//判断一下主界面是否为单任务界面，单任务界面显示50条数据，多任务界面显示10条数据
                {
                    ucpagegongzuoqingdan.displaynum = 10;
                    _mycontroller._displaynum = 10;

                }
                else
                {
                    ucpagegongzuoqingdan.displaynum = 30;
                    _mycontroller._displaynum = 30;

                }

                double pagenums= _mycontroller.GetGongzuoqingdanPagenums();
                ucpagegongzuoqingdan.totalpage = pagenums;
                ucpagegongzuoqingdan.f= _mycontroller.GetGongzuoqingdan;
                ucpagegongzuoqingdan.a = UpdatePgongzuoqingdan;
                ucpagegongzuoqingdan.tb_page.Text = "1";
                ucpagegongzuoqingdan.lbl_pagenums.Text = $"共 {pagenums} 页";

            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 0;
            }

            if (_list_item.Contains("待办任务"))
            {
                if (_list_item.Count == 3)//判断一下主界面是否为单任务界面，单任务界面显示50条数据，多任务界面显示10条数据
                {
                    ucpagedaiban.displaynum = 10;
                    _mycontroller._displaynum = 10;

                }
                else
                {
                    ucpagedaiban.displaynum = 30;
                    _mycontroller._displaynum = 30;

                }

                string keyword = tb_kw.Text;
                double pagenums = _mycontroller.GetDaibanPagenums();
                ucpagedaiban.kw = keyword;
                ucpagedaiban.totalpage = pagenums;
                ucpagedaiban.f = _mycontroller.GetDaibanRenwu;
                ucpagedaiban.a = UpdatePdaiban;
                ucpagedaiban.tb_page.Text = "1";
                ucpagedaiban.lbl_pagenums.Text = $"共 {pagenums} 页";
            }
            else
            {
                tableLayoutPanel1.RowStyles[2].Height = 0;

            }
            if (_list_item.Contains("通知公告"))
            {
                if (_list_item.Count == 3)//判断一下主界面是否为单任务界面，单任务界面显示50条数据，多任务界面显示10条数据
                {
                    ucpagetongzhi.displaynum = 10;
                    _mycontroller._displaynum = 10;
                }
                else
                {
                    ucpagetongzhi.displaynum = 30;
                    _mycontroller._displaynum = 30;

                }

                double pagenums = _mycontroller.GetTongzhiPagenums();
                ucpagetongzhi.totalpage = pagenums;
                ucpagetongzhi.f = _mycontroller.GetTongzhi;
                ucpagetongzhi.a = UpdatePtongzhi;
                ucpagetongzhi.tb_page.Text = "1";
                ucpagetongzhi.lbl_pagenums.Text = $"共 {pagenums} 页";

            }
            else
            {
                tableLayoutPanel1.RowStyles[1].Height = 0;

            }

        }
        string str_con = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();

        SqlDependency dependency = new SqlDependency();


        private void Update(string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                //此处 要注意 不能使用*  表名要加[dbo]  否则会出现一直调用执行 OnChange
                string sql = "select 删除 from jjdbrenwuqingdan.工作清单表";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    //必须要执行一下command
                    command.ExecuteNonQuery();
                    MessageBox.Show("enenanananan啊啊啊");
                }
            }
        }




        /// <summary>
        /// 数据发生变化时出发的时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change) //只有数据发生变化时,才重新获取并数据
            {
                MessageBox.Show("数据发生了变化");
            }
        }

        private void lbl_name_Click(object sender, EventArgs e)
        {
            //弹出注册窗体
            WFzhuce mywin = new WFzhuce(0);
            if (mywin.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点击钉子按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_dingzi_Click(object sender, EventArgs e)
        {
            WinForm.WFgongzuoqingdan mywinform = new WinForm.WFgongzuoqingdan();
            if (mywinform.ShowDialog() == DialogResult.OK)
            {
                JJMethod.a_shuaxinzhuye(null, null);
            }
        }

        private void dgv_a_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    ((DataGridView)sender).ClearSelection();
                    ((DataGridView)sender).Rows[e.RowIndex].Selected = true;
                    ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cms_right.Show(MousePosition.X, MousePosition.Y);//dgv_rightmenu是鼠标右键菜单控件
                    dgv_right = (DataGridView)sender;
                }
            }
        }

        private void dgv_daiban_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ////判断是否左键点击
            //if (e.Button == MouseButtons.Right)
            //{
            //    return;
            //}

            ////判断是否点击了任务名称列
            //bool b = ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("任务名称");
            ////获得任务名称
            //string renwuming = ((DataGridView)sender).CurrentCell.Value.ToString();
            ////如果是,构造jjchangguiinfo,弹出任务详情窗体
            //DataGridViewRow mydr = dgv_daiban.CurrentRow;
            //JJchangguiInfo info = new JJchangguiInfo()
            //{
            //    _renwumingcheng = mydr.Cells["任务名称"].Value.ToString(),
            //    _jinjichengdu = mydr.Cells["紧急程度"].Value.ToString(),
            //    //_jutiyaoqiu = mydr.Cells["具体要求"].Value.ToString(),
            //    //_zerenren = mydr.Cells["责任人"].Value.ToString(),
            //    //_yanshouren = mydr.Cells["验收人"].Value.ToString(),
            //    _shixian = mydr.Cells["时限"].Value.ToString(),
            //    _jinzhanqingkuang = mydr.Cells["进展情况"].Value.ToString()
            //};



            //if (b)
            //{

            //    WFdaiban mywin = new WFdaiban(info);
            //    if (mywin.ShowDialog() == DialogResult.OK)
            //    {
            //        ///刷新数据
            //        this.UCmain_Load(null, null);
            //    }
            //}
        }

        private void dgv_a_Paint(object sender, PaintEventArgs e)
        {
            DataGridView mydgv = sender as DataGridView;
            /*过期清单标记为红色*/
            //获得当前日期
            DateTime _now = DateTime.Now;
            //循环获得dgv中的日期
            for (int i = 0; i < mydgv.Rows.Count; i++)
            {
                DataGridViewRow myrow = mydgv.Rows[i];
                DateTime _finish = Convert.ToDateTime(myrow.Cells["完成时间"].Value);
                //判断，如果当前日期>完成日期
                if (_now > _finish)
                {
                    //显示为红色
                    mydgv.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得按钮所在的contextmenustrip
            //获得选中行,构造一个清单info
            var mydr = dgv_right.CurrentRow;
            JJQingdanInfo myqi = new JJQingdanInfo()
            {
                _renwumingcheng = mydr.Cells["任务名称"].Value.ToString(),
                _xiangxian = mydr.Cells["象限"].Value.ToString(),
                _wanchengshijian = mydr.Cells["完成时间"].Value.ToString()

            };
            //构造一个wfgongzuoqingdan
            WFgongzuoqingdan mywin = new WFgongzuoqingdan(myqi);
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                //更新任务内容
                UCmain_Load(null, null);

            }




        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得清单名称
            string qingdanmingcheng = dgv_right.CurrentRow.Cells["任务名称"].Value.ToString();

            //删除清单和人名对应的这条清单，删除=1
            bool b = _mycontroller.DeleteQingdan(qingdanmingcheng);
            if (b)
            {
                //更新任务内容
                UCmain_Load(null, null);
            }
        }

        private void 完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得清单名称
            string qingdanmingcheng = dgv_right.CurrentRow.Cells["任务名称"].Value.ToString();

            //删除清单和人名对应的这条清单，删除=1
            bool b = _mycontroller.FinishQingdan(qingdanmingcheng);
            if (b)
            {
                //更新任务内容
                UCmain_Load(null, null);
            }
        }
        /// <summary>
        /// 重回通知公告信息时触发的事件，未读的通知要加粗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_tongzhi_Paint(object sender, PaintEventArgs e)
        {
            DataGridView mydgv = sender as DataGridView;
            int weidunum = 0;//记录未读数量
            for (int i = 0; i < mydgv.Rows.Count; i++)
            {
                string zhuangtai = mydgv.Rows[i].Cells["状态"].Value.ToString();
                if (zhuangtai.Equals("未读"))
                {
                    mydgv.Rows[i].DefaultCellStyle.Font = new Font(mydgv.Font, FontStyle.Bold);
                    weidunum++;
                }


            }
            //刷新通知公告栏 数量
            panel_tongzhi.Text = $"通知公告 共{weidunum}项";

        }

        private void pb_search_Click(object sender, EventArgs e)
        {
            string keyword = tb_kw.Text;

            double pagenums = _mycontroller.GetDaibanPagenums();
            ucpagedaiban.kw = keyword;
            ucpagedaiban.totalpage = pagenums;
            ucpagedaiban.tb_page_TextChanged(null, null);
            ucpagedaiban.tb_page.Text = "1";
            ucpagedaiban.lbl_pagenums.Text = $"共 {pagenums} 页";

        }

        private void tb_kw_TextChanged(object sender, EventArgs e)
        {
            //if (tb_kw.Text.Trim().Equals(string.Empty))
            //{
            //    DataTable mydt = _mycontroller.GetDaibanRenwuDT(string.Empty);
            //    dgv_daiban.DataSource = null;
            //    dgv_daiban.DataSource = mydt;

            //}
        }

        private void dgv_tongzhi_DataSourceChanged(object sender, EventArgs e)
        {
            //隐藏签发人，内容，删除，状态
            //dgv_tongzhi.Columns["签发人"].Visible = false;
            //dgv_tongzhi.Columns["内容"].Visible = false;
            //dgv_tongzhi.Columns["删除"].Visible = false;
            //dgv_tongzhi.Columns["状态"].Visible = false;


        }
    }
}

