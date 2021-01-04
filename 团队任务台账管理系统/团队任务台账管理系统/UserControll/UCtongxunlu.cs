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
    public partial class UCtongxunlu : UserControl
    {
        ControllerUCtongxulu _mycontroller = new ControllerUCtongxulu();
        public UCtongxunlu()
        {
            InitializeComponent();
        }

        private void UCtongxunlu_Load(object sender, EventArgs e)
        {
            //获得所有员工信息 datatable
            DataTable mydt = _mycontroller.GetPersonInfo();
            //循环员工信息构造jjpersoninfo
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                var mydr = mydt.Rows[i];
                JJPersonInfo mypersoninfo = new JJPersonInfo() {
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
                flp_my.Controls.Add(myuc);
            }
            




        }
    }
}
