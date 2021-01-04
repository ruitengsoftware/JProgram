using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.WinForm;
using 团队任务台账管理系统.JJModel;
using 团队任务台账管理系统.Controller;

namespace 团队任务台账管理系统.UserControll
{
    public partial class UCbumentongxun : UserControl
    {
        ControllerBumentongxun _myc = new ControllerBumentongxun();
        public UCbumentongxun()
        {
            InitializeComponent();
            UpdateBumen();
        }
        /// <summary>
        /// 点击添加部门按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_tianjiabumen_Click(object sender, EventArgs e)
        {
            WinFormTianjiabumen mywin = new WinFormTianjiabumen() { StartPosition=FormStartPosition.CenterParent};
            if (mywin.ShowDialog()== DialogResult.OK)
            {
                //跟新部门列表
                UpdateBumen();
            }


         }




        private void UpdateBumen()
        {
            tv_my.Nodes.Clear();
            var infos = _myc.GetBumeninfos();
            //添加一级列表
            foreach (JJBumenInfo info in infos)
            {
                if (info._jibie=="一级部门")
                {
                    tv_my.Nodes.Add(info._mingcheng,info._mingcheng);

                }
            }
            //获得二级列表，加载到对应的一级列表中去
            foreach (JJBumenInfo info in infos)
            {
                if (info._jibie=="二级部门")
                {
                    tv_my.Nodes[info._suoshubumen].Nodes.Add(info._mingcheng, info._mingcheng);
                }
            }
        }

        private void btn_shanchubumen_Click(object sender, EventArgs e)
        {
            //删除选中节点
            string node = tv_my.SelectedNode.Text;
            JJBumenInfo ji = new JJBumenInfo() { _mingcheng=node};
            bool b = _myc.DeleteBumen(ji);
            if (b)
            {
                MessageBox.Show("删除部门成功！");
            }
            //更新界面
            UpdateBumen();
        }

        private void tv_my_AfterSelect(object sender, TreeViewEventArgs e)
        {
            flp_person.Controls.Clear();
            //获得所有人员信息
            string bumen = tv_my.SelectedNode.Text;
            //获得所有员工信息 datatable
            DataTable mydt = _myc.GetPersonInfo(bumen);
            //循环员工信息构造jjpersoninfo
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                var mydr = mydt.Rows[i];
                JJPersonInfo mypersoninfo = new JJPersonInfo()
                {
                    _huaming = mydr["花名"].ToString(),

                    _shiming = mydr["实名"].ToString(),
                    _bumen = mydr["部门"].ToString(),
                    _quanxian = mydr["权限"].ToString(),
                    _zhiji = mydr["职级"].ToString(),
                    _shoujihao = mydr["手机号"].ToString(),
                    _dianziyouxiang = mydr["电子邮箱"].ToString(),
                    _zidingyizhanghao = mydr["自定义账号"].ToString(),
                    _touxiang = mydr["头像"].ToString(),
                    _gongzuozhengjianzhao = mydr["工作证件照"].ToString(),
                    _weixinhao = mydr["微信号"].ToString(),
                    _gerenqianming = mydr["个人签名"].ToString(),
                    _dengluquan = Convert.ToInt32(mydr["登录权"].ToString()),
                    _diaoyongguize = mydr["调用规则"].ToString(),
                    _diaoyongchachongku = mydr["调用查重库"].ToString(),
                    _suodingguize = mydr["锁定规则"].ToString(),
                    _suodingchachongku = mydr["锁定查重库"].ToString(),





                };
                //构造uctongxunluxiangqing,加载到flp种
                UCtongxunluxiangqing myuc = new UCtongxunluxiangqing(mypersoninfo);
                flp_person.Controls.Add(myuc);
            }

            //构成人员信息uc，加载到右侧部门人员


        }
    }
}
