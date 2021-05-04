using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 谦海数据解析系统.JJmodel;
using static 谦海数据解析系统.JJmodel.TagInfo;

namespace 谦海数据解析系统.JJwinform
{
    public partial class NewBQForm : Form
    {


        /// <summary>
        /// 需要创建的标签的父节点信息
        /// </summary>
        public TagInfo _parentInfo = null;
        /// <summary>
        /// 属于窗体本身的标签信息
        /// </summary>
        public TagInfo _tagInfo = null;

        public NewBQForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 该构造函数用于编辑标签时使用
        /// </summary>
        /// <param name="bqi"></param>
        public NewBQForm(TagInfo bqi)
        {
            InitializeComponent();
            
            _tagInfo = bqi;
        }

        /// <summary>
        /// 点击取消按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 加载窗体时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewBQForm_Load(object sender, EventArgs e)
        {

            ///如果biaoqianinfo不为null，说明已经有标签信息传进来，需要显示在界面上
            if (_tagInfo != null)
            {
                tb_mingcheng.Text = _tagInfo._mingcheng;
                tb_shuoming.Text = _tagInfo._tagRoot.shuoming;
                tb_zhengze.Text = _tagInfo._tagRoot.zhengze;
                foreach (Control c in panel_neirong.Controls)//内容标签内容
                {

                    if (c is CheckBox && _tagInfo._tagRoot.list_neirong.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_weizhi.Controls)//对象位置
                {

                    if (c is CheckBox && _tagInfo._tagRoot.list_position.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_pipeidu.Controls)
                {

                    if (c is CheckBox && _tagInfo._tagRoot.list_pipei.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }

                foreach (Control c in flp_jiedian.Controls)
                {

                    if (c is CheckBox && _tagInfo._tagRoot.list_neirong.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in flp_yupian.Controls)
                {

                    if (c is CheckBox && _tagInfo._tagRoot.list_yupian.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }
                foreach (Control c in panel_neirong.Controls)
                {
                    if (c is CheckBox && _tagInfo._tagRoot.list_leibie.Contains(c.Text))
                    {
                        (c as CheckBox).Checked = true;
                    }
                }


                tb_shunshu.Text = _tagInfo._tagRoot.shunshu.ToString();
                tb_daoshu.Text = _tagInfo._tagRoot.daoshu.ToString();
                tb_gudingzhi.Text = _tagInfo._tagRoot.gudingzhi;
                tb_jushouzhi.Text = _tagInfo._tagRoot.jushouzhi;
                tb_juzhongzhi.Text = _tagInfo._tagRoot.juzhongzhi;
                tb_juweizhi.Text = _tagInfo._tagRoot.juweizhi;
                tb_weizhiqian0.Text = _tagInfo._tagRoot.weizhiqian0;
                tb_weizhiqian1.Text = _tagInfo._tagRoot.weizhiqian1;
                tb_weizhihou0.Text = _tagInfo._tagRoot.weizhihou0;
                tb_weizhihou1.Text = _tagInfo._tagRoot.weizhihou1;
                tb_zhengzetiqu.Text = _tagInfo._tagRoot.zhengzetiqu;

            }
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            //构造一个biaoqianinfo实例，保存在数据库中内容标签表
            TagRoot _bqRoot = new TagRoot()
            {
                shuoming = tb_shuoming.Text,
                zhengze = tb_zhengze.Text,
                shunshu = Convert.ToInt32(tb_shunshu.Text),
                daoshu = Convert.ToInt32(tb_daoshu.Text),
                gudingzhi = tb_gudingzhi.Text,
                jushouzhi = tb_jushouzhi.Text,
                juzhongzhi = tb_juzhongzhi.Text,
                juweizhi = tb_juweizhi.Text,
                weizhiqian0 = tb_weizhiqian0.Text,
                weizhiqian1 = tb_weizhiqian1.Text,
                weizhihou0 = tb_weizhihou0.Text,
                weizhihou1 = tb_weizhihou1.Text,
                zhengzetiqu = tb_zhengzetiqu.Text,
            };
            foreach (Control c in panel_neirong.Controls)
            {

                if (c is CheckBox && (c as CheckBox).Checked == true)
                {
                    _bqRoot.list_leibie.Add(c.Text);
                }
            }
            foreach (Control c in flp_weizhi.Controls)
            {

                if (c is CheckBox && (c as CheckBox).Checked == true)
                {
                    _bqRoot.list_position.Add(c.Text);
                }
            }
            foreach (Control c in flp_pipeidu.Controls)
            {

                if (c is CheckBox && (c as CheckBox).Checked == true)
                {
                    _bqRoot.list_pipei.Add(c.Text);
                }
            }

            foreach (Control c in flp_jiedian.Controls)
            {

                if (c is CheckBox && (c as CheckBox).Checked == true)
                {
                    _bqRoot.list_neirong.Add(c.Text);
                }
            }
            foreach (Control c in flp_yupian.Controls)
            {

                if (c is CheckBox && (c as CheckBox).Checked == true)
                {
                    _bqRoot.list_yupian.Add(c.Text);
                }
            }
            string _bqSetJson = JsonConvert.SerializeObject(_bqRoot);

            //如果是新建一个标签，那么父标签是有实例传进来的，而自身的tagInfo没有
            //如果是编辑标签，那么父标签是没有实例的，而自身的tagInfo有值
            if (_parentInfo != null)
            {
                _tagInfo = new TagInfo() { };
                _tagInfo._kuming = _parentInfo._kuming;
                _tagInfo._mingcheng = tb_mingcheng.Text;
                _tagInfo._jibie = _parentInfo._jibie+1;
                //_tagInfo._fubiaoqianming = _parentInfo._mingcheng;
                _tagInfo._biaoqianSet = _bqSetJson;
                _tagInfo._chuangjianren = SystemInfo._userInfo._shiming;
                _tagInfo._chuangjianshijian = DateTime.Now.ToString("yyyy-MM-dd");
                _tagInfo._parent = _parentInfo;
                //保存biaoqianinfo
                SaveBiaoqianInfo();
                MessageBox.Show($"内容标签 {_tagInfo._mingcheng} 已添加成功！");
                MyMethod._updateTag();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                _tagInfo._biaoqianSet = _bqSetJson;
                //保存biaoqianinfo
                SaveBiaoqianInfo();
                MessageBox.Show($"内容标签 {_tagInfo._mingcheng} 已设置成功！");
                MyMethod._updateTag();
                this.DialogResult = DialogResult.OK;
            }
        }
        /// <summary>
        /// 保存自身标签信息到数据库
        /// </summary>
        public void SaveBiaoqianInfo()
        {
            string str_sql = $"delete from  数据解析库.内容标签表 where 名称='{_tagInfo._mingcheng}'";
            MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);

            str_sql = $"insert into 数据解析库.内容标签表 " +
                $"value ('{_tagInfo._kuming}','{_tagInfo._mingcheng}',{_tagInfo._jibie}," +
                $"'{_tagInfo._parent._mingcheng}','{_tagInfo._biaoqianSet}'," +
                $"'{_tagInfo._chuangjianren}','{_tagInfo._chuangjianshijian}',0)";
            MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
        }

    }
}
