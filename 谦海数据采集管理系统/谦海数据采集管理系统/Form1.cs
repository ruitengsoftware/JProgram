using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 谦海数据采集管理系统.JJModel;
using 谦海数据采集管理系统.JJUserControl;

namespace 谦海数据采集管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //显示所有的任务卡片
            List<JJTaskInfo> list = GetAllTaskInfo();



            //代办卡片
            var list0 = list.Where((r) =>
            {
                return r._yongdao=="待办";
            });
            foreach (JJTaskInfo item in list0)
            {
                JJReuqirementCard _mycard = new JJReuqirementCard() {
                    _myTaskInfo = item                };
                panel_daiban.Controls.Add(_mycard);
            }

            //设计卡片
             list0 = list.Where((r) =>
            {
                return r._yongdao == "设计";
            });
            foreach (JJTaskInfo item in list0)
            {
                JJReuqirementCard _mycard = new JJReuqirementCard()
                {
                    _myTaskInfo = item
                };
                panel_sheji.Controls.Add(_mycard);
            }


            //开发卡片

            //测试卡片

            //发布卡片

            //完成卡片




        }

        private void lbl_newcard_Click(object sender, EventArgs e)
        {
            JJWinForm.JJWFnewcard mywin = new JJWinForm.JJWFnewcard();
            if (mywin.ShowDialog()==DialogResult.OK)
            {
                //如果点击了新建卡片窗体中的保存按钮，则添加这个卡片实例化，添加到待办列表
                JJModel.JJTaskInfo _taskInfo = mywin._myTaskInfo;
                JJReuqirementCard _mycard = new JJReuqirementCard() { 
                _myTaskInfo=_taskInfo
                };
                panel_daiban.Controls.Add(_mycard);

            }
        }



        #region 方法
        /// <summary>
        /// 获得所有的任务信息
        /// </summary>
        /// <param name="yongdao"></param>
        /// <returns></returns>
        public List<JJTaskInfo> GetAllTaskInfo()
        {
            List<JJTaskInfo> list_result = new List<JJTaskInfo>();
            string str_sql = $"select * from 谦海数据库.任务信息表 " +
                    $"where 删除=0";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
            DataTable mydt = MySqlHelper.ExecuteDataset(constr, str_sql).Tables[0];
            foreach (DataRow dataRow in mydt.Rows)
            {
                JJTaskInfo _ti = new JJTaskInfo() { 
                _bianhao=dataRow["编号"].ToString(),
                    _mingcheng = dataRow["名称"].ToString(),
                    _miaoshu = dataRow["描述"].ToString(),
                    _fuzeren = dataRow["负责人"].ToString(),
                    _quanxian = dataRow["权限"].ToString(),
                    _youxianji = dataRow["优先级"].ToString(),
                    _chuangjianren = dataRow["创建人"].ToString(),
                    _chuangjianshijian = dataRow["创建时间"].ToString(),
                    _haoshi = dataRow["耗时"].ToString(),
                    _yujikaishi = dataRow["预计开始"].ToString(),
                    _yujijieshu = dataRow["预计结束"].ToString(),
                    _yongdao=dataRow["泳道"].ToString()
                };
                list_result.Add(_ti);
            }
            return list_result;
        }


        #endregion


    }
}
