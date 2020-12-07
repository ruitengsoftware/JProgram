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
using 团队任务台账管理系统.WinForm;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCtuandui : UserControl
    {
        ControllerTuandui _mycontroller = new ControllerTuandui();


        public UCtuandui()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击接触团队按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_jiechutuandui_Click(object sender, EventArgs e)
        {
            //string teamname = tb_tuandui.Text;
            //bool b = mycontroller.JiechuTuandui(teamname);
            //Action myfun = () =>
            //{
            //    //清空dgv_data
            //    dgv_data.DataSource = null;
            //    //获得全部数据
            //    DataTable mydt = mycontroller.GetTuandui();
            //    //刷新显示数据
            //    dgv_data.DataSource = mydt;
            //    dgv_data_CellMouseClick(null, null);
            //};
            //myfun();
            //if (b) MessageBox.Show("已删除该团队！");
        }
        /// <summary>
        /// 点击创建团队按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_chuangjian_Click(object sender, EventArgs e)
        {
            //WFtuandui mywinform = new WFtuandui();
            //mywinform.StartPosition = FormStartPosition.CenterParent;
            //mywinform.updatedata = () =>
            //{
            //    //清空dgv_data
            //    dgv_data.DataSource = null;
            //    //获得全部数据
            //    DataTable mydt = mycontroller.GetTuandui();
            //    //刷新显示数据
            //    dgv_data.DataSource = mydt;
            //    dgv_data_CellMouseClick(null, null);
            //};
            //if (mywinform.ShowDialog() == DialogResult.OK)
            //{




            //}



        }

        private void UCtuandui_Load(object sender, EventArgs e)
        {
            //清空数据
            flp_tuandui.Controls.Clear();
            //获得全部团队数据
            DataTable mydt = _mycontroller.GetTuandui();
            //刷新显示数据，循环构造tuanduixinxi类uctuanduanxiangqing，加入到flp中
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                var mydr = mydt.Rows[i];
                JJTuanduiInfo mytuanduiinfo = new JJTuanduiInfo()
                {
                    _mingcheng = mydr["名称"].ToString(),
                    _fuzeren = mydr["负责人"].ToString(),
                    _chengyuan = mydr["成员"].ToString(),
                    _chuangjianshijian = mydr["创建时间"].ToString(),
                    _zhuangtai = mydr["状态"].ToString(),
                    _jiechushijian = mydr["解除时间"].ToString(),
                    _tuanduitupian = mydr["团队图片"].ToString(),
                    _gongzuolingyu = mydr["工作领域"].ToString()
                };

                UCtuanduixiagnqing myuc = new UCtuanduixiagnqing(mytuanduiinfo);
                myuc.Updatedate += UCtuandui_Load;
                //把刷新窗体事件传给myuc

                flp_tuandui.Controls.Add(myuc);
            }
        }

        private void dgv_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ////获得选中行
            //DataGridViewRow mydr = dgv_data.CurrentCell.OwningRow;
            ////显示信息
            //string tuanduimingcheng = mydr.Cells["名称"].Value.ToString();
            //string fuzeren = mydr.Cells["负责人"].Value.ToString();
            //string chengyuan = mydr.Cells["成员"].Value.ToString();
            //tb_tuandui.Text = tuanduimingcheng;
            //tb_fuzeren.Text = fuzeren;
            //tb_chengyuan.Text = chengyuan;



        }
        /// <summary>
        /// 点击接触按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_jiechu_Click(object sender, EventArgs e)
        {
            //获得选中的团队名称
            List<string> list_name = new List<string>();
            foreach (UCtuanduixiagnqing myuc in flp_tuandui.Controls)
            {
                if (myuc._checked)
                {
                    list_name.Add(myuc.lbl_tuanduimingcheng.Text);
                }
            }
            //如果没有选中团队，要提示，然后退出
            if (list_name.Count == 0)
            {
                MessageBox.Show("没有选中任何团队！");
                return;
            }
            //从数据库中删除
            bool b = _mycontroller.JiechuTuandui(list_name);
            if (b)
            {
                //刷新前端显示
                UCtuandui_Load(null, null);

                MessageBox.Show("团队已解除！");
            }

        }
        /// <summary>
        /// 点击加入团队按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label5_Click(object sender, EventArgs e)
        {
            //获得选中的团队名称
            List<string> list_name = new List<string>();
            foreach (UCtuanduixiagnqing myuc in flp_tuandui.Controls)
            {
                if (myuc._checked)
                {
                    list_name.Add(myuc.lbl_tuanduimingcheng.Text);
                }
            }

            //添加到这个团队中


            bool b = _mycontroller.JiaruTuandui(list_name);
            if (b)
            {
                //刷新前端显示
                UCtuandui_Load(null, null);

                MessageBox.Show("已加入所选团队！");
            }



        }
        /// <summary>
        /// 点击退出团队按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label6_Click(object sender, EventArgs e)
        {
            //获得选中的团队名称
            List<string> list_name = new List<string>();
            foreach (UCtuanduixiagnqing myuc in flp_tuandui.Controls)
            {
                if (myuc._checked)
                {
                    list_name.Add(myuc.lbl_tuanduimingcheng.Text);
                }
            }

            //添加到这个团队中


            bool b = _mycontroller.TuichuTuandui(list_name);
            if (b)
            {
                //刷新前端显示
                UCtuandui_Load(null, null);

                MessageBox.Show("已退出所选团队！");
            }

        }

        private void lbl_chuangjian_Click(object sender, EventArgs e)
        {
            WFtuandui mywin = new WFtuandui();
            if (mywin.ShowDialog()==DialogResult.OK)
            {
                //刷新前端显示
                UCtuandui_Load(null, null);

            }
        }
    }
}
