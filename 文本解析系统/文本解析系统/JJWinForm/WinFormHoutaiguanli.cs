using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 文本解析系统.JJCommon;
using 文本解析系统.JJController;

namespace 文本解析系统.JJWinForm
{
    public partial class WinFormHoutaiguanli : Form
    {
       public Action<DataGridView> _a = null;
        ControllerWFhoutai _mycontroller = new ControllerWFhoutai();
       public DataGridView _dgv = null;
        public WinFormHoutaiguanli()
        {
            InitializeComponent();
        }

        private void WinFormHoutaiguanli_Load(object sender, EventArgs e)
        {
            //显示personinfo
            string str_sql = $"select * from jjdbrenwutaizhang.jjperson where 删除='0'";
            DataTable mydt = _mycontroller.GetDataTable(str_sql);
            dgv_person.DataSource = mydt;
            //模拟点击一次表格
            dgv_person_CellMouseClick(null, null);
            //模拟选中锁定规则
            rb_guize.Checked = true;
        }

        private void lbl_guanbi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgv_person_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             //获得选中行
            DataGridViewRow mydr = dgv_person.CurrentRow;
            //把信息显示在窗体中
            tb_huaming.Text = mydr.Cells["花名"].Value.ToString();
            tb_diaoyongguize.Text = mydr.Cells["调用规则"].Value.ToString();
            tb_diaoyongchachongku.Text = mydr.Cells["调用查重库"].Value.ToString();
            cbb_quanxian.Text = mydr.Cells["权限"].Value.ToString();
            if (Convert.ToInt32(mydr.Cells["登录权"].Value) == 1)
                
            {
                rb_keyi.Checked = true;
            }
            else
            {
                rb_bukeyi.Checked = true;

            }

        }
        /// <summary>
        /// 点击授权按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {





            //实例化一个personinfo
            PersonInfo pi = new PersonInfo() {
                _huaming = tb_huaming.Text,
                _dengluquan = rb_keyi.Checked == true ? 1 : 0,
                _quanxian=cbb_quanxian.Text,
                _diaoyongguize=tb_diaoyongguize.Text,
                _diaoyongchachongku=tb_diaoyongchachongku.Text
            
            };
            //判断管理员数量,获得管理员名集合,如果管理员已经有3位并且不含有准备授权的花名，提示管理员数量已经到3位，return
            List<string> list_guanliyuan = new List<string>();
            foreach (DataGridViewRow dr in dgv_person.Rows)
            {
                string quanxian = dr.Cells["权限"].Value.ToString();
                if (quanxian.Equals("管理员"))
                {
                    list_guanliyuan.Add(dr.Cells["花名"].Value.ToString());
                }
            }
            if (!list_guanliyuan.Contains(pi._huaming) && list_guanliyuan.Count>=3)
            {
                MessageBox.Show("授权失败，管理员数量已达上限！");
                return;
            }
            //更新personinfo花名对应的登录权，权限，调用规则，调用查重库
            bool b = _mycontroller.UpdateShouquan(pi);
            if (b)
            {
                //显示personinfo
                string str_sql = $"select * from jjdbrenwutaizhang.jjperson where 删除='0'";

                DataTable mydt = _mycontroller.GetDataTable(str_sql);
                dgv_person.DataSource = null;
                dgv_person.DataSource = mydt;
                //模拟点击一次表格
                dgv_person_CellMouseClick(null, null);
                //更新登陆人员信息
                LoginInfo.GetLoginInfo(LoginInfo._huaming);

                //更新主界面的规则数据
                _a(_dgv);
                MessageBox.Show("授权成功！");
            }











        }

        private void pb_diaoyongguize_Click(object sender, EventArgs e)
        {
            WinFormSelect mywin = new WinFormSelect(tb_diaoyongguize.Text, "规则");
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_diaoyongguize.Text =string.Join(",", mywin.list_select);
            }
        }

        private void pb_shanchuguize_Click(object sender, EventArgs e)
        {




        }

        private void pb_diaoyongku_Click(object sender, EventArgs e)
        {
            WinFormSelect mywin = new WinFormSelect(tb_diaoyongchachongku.Text, "查重");
            if (mywin.ShowDialog() == DialogResult.OK)
            {
                tb_diaoyongchachongku.Text =string.Join(",", mywin.list_select);
            }
        }

        private void rb_guize_CheckedChanged(object sender, EventArgs e)
        {
            //判断解析规则是否选中
            bool b = rb_guize.Checked;


            //如果选中，显示解析规则，如果没选中，显示查重库
            if (b)
            {
                dgv_suoding.DataSource = null;
                string str_sql = "select * from jjdbwenbenjiexi.规则信息表 where 删除=0";
                DataTable mydt = _mycontroller.GetDataTable(str_sql);
                dgv_suoding.DataSource = mydt;
                //对所有已锁定的项目打勾
                List<string> list = Regex.Split(LoginInfo._suodingguize, ",").ToList();
                foreach (DataGridViewRow dr in dgv_suoding.Rows)
                {
                    if (list.Contains(dr.Cells["名称"].Value.ToString()))
                    {
                        dr.Cells["xuanze"].Value = true;
                    }

                }


            }
            else//显示查重库
            {
                dgv_suoding.DataSource = null;
                string str_sql = "select * from jjdbwenbenjiexi.查重库信息表 where 删除=0";
                DataTable mydt = _mycontroller.GetDataTable(str_sql);
                dgv_suoding.DataSource = mydt;
                //对所有已锁定的项目打勾
                List<string> list = Regex.Split(LoginInfo._suodingchachongku,",").ToList();
                foreach (DataGridViewRow dr in dgv_suoding.Rows)
                {
                    if (list.Contains(dr.Cells["名称"].Value.ToString()))
                    {
                        dr.Cells["xuanze"].Value = true;
                    }

                }

            }



        }

        private void lbl_suoding_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (DataGridViewRow dr in dgv_suoding.Rows)
            {
                bool bb = Convert.ToBoolean((dr.Cells["xuanze"] as DataGridViewCheckBoxCell).EditingCellFormattedValue);
                if (bb)
                {
                    list.Add(dr.Cells["名称"].Value.ToString());
                }
            }
            string str = string.Join(",", list);
            //获得需要更新的类型，规则或查重库
            string st = string.Empty;
            if (rb_guize.Checked)
            {
                st = "锁定规则";
            }
            else
            {
                st = "锁定查重库";

            }
            //更新person的信息

           bool b= _mycontroller.UpdateSuoding(str, st);
            if (b)
            {
                //刷新persondgv
                //显示personinfo
                string str_sql = $"select * from jjdbrenwutaizhang.jjperson where 删除='0'";

                DataTable mydt = _mycontroller.GetDataTable(str_sql);
                dgv_person.DataSource = null;
                dgv_person.DataSource = mydt;
                //模拟点击一次表格
                dgv_person_CellMouseClick(null, null);
                MessageBox.Show("锁定成功！");
            }


        }
    }
}
