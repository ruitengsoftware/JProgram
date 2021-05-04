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
using 谦海数据解析系统.JJwinform;
using static 谦海数据解析系统.JJmodel.TagInfo;

namespace 谦海数据解析系统.JJusercontrol
{
    public partial class BiaoqianControl : UserControl
    {
        /// <summary>
        /// 记录控件是否已经展开
        /// </summary>
        bool _zhankai = false;
        /// <summary>
        /// 控件自身的标签信息
        /// </summary>
        TagInfo _bqInfo = null;

        public BiaoqianControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }
        /// <summary>
        /// 构造函数，传一个标签信息实例进来
        /// </summary>
        /// <param name="myinfo"></param>
        public BiaoqianControl(TagInfo myinfo)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            _bqInfo = myinfo;
        }

        private void BiaoqianControl_Load(object sender, EventArgs e)
        {
            //把标签信息显示在窗体上，标签名称
            lbl_mingcheng.Text = _bqInfo._mingcheng;
            //需要根据标签信息的级别进行左侧的缩进，每一级缩进30
            this.Padding = new Padding(30 * _bqInfo._jibie, 0, 0, 0);
            //界面的优化，如果是内容标签那么不显示修改和删除，
            if (_bqInfo._mingcheng=="内容标签")
            {
                pb_edit.Visible = false;
                pb_delete.Visible = false;
            }
            //判断是否有子标签，如果没有，不显示折叠按钮
            bool b = HasChildren();
            if (!b)
            {
                pb_zhankai.Visible = false;
            }
            //根据自身标签信息更改背景色
            //1级标签#CDCDC1(205 197 191)、2级#EEEEE0(238 229 222)、3级#FFFFF0(255 245 238)
            if (_bqInfo._jibie==1)
            {
                this.BackColor = Color.FromArgb(105,105,105);
            }
            else if(_bqInfo._jibie == 2)
            {
                this.BackColor = Color.FromArgb(156,156,156);

            }
            else if (_bqInfo._jibie == 3)
            {
                this.BackColor = Color.FromArgb(207,207,207);

            }




        }

        /// <summary>
        /// 判断标签是否有子标签
        /// </summary>
        /// <returns></returns>
        public bool HasChildren()
        {
            string str_sql = $"select count(*) from 数据解析库.内容标签表 where 父标签名='{_bqInfo._mingcheng}' and 库名='{_bqInfo._kuming}' and 删除=0";
            var num = MySqlHelper.ExecuteScalar(SystemInfo._strConn, str_sql);
            return Convert.ToInt32(num) > 0 ? true : false;
        
        
        }


        /// <summary>
        /// 点击展开按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_zhankai_Click(object sender, EventArgs e)
        {
            //判断当前标签的状态是折叠还是展开，取反
            _zhankai = !_zhankai;
            if (_zhankai)
            {

                pb_zhankai.BackgroundImage = Properties.Resources.deletefielden;
            }
            else
            {
                pb_zhankai.BackgroundImage = Properties.Resources.add;

            }
        }
        /// <summary>
        /// 点击加号按钮时触发的事件，添加子标签节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_add_Click(object sender, EventArgs e)
        {
            //弹出添加标签窗体，进行设置，保存到内容标签表数据库
            //将所点击的标签信息传递给parentinfo
            NewBQForm myform = new NewBQForm() { _parentInfo = _bqInfo };
            if (myform.ShowDialog() == DialogResult.OK)
            {

            }
        }
        /// <summary>
        /// 折叠图片背景图发生变化时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_zhankai_BackgroundImageChanged(object sender, EventArgs e)
        {
            if (_zhankai)
            {
                //如果是展开状态，从数据库中获得该节点全部的子节点，然后循环实例化标签control，调整childrenindex，插入到容器中
                Panel p = this.Parent as Panel;
                int index = p.Controls.GetChildIndex(this);

                for (int i = 0; i < _bqInfo._childNodes.Count; i++)
                {
                    BiaoqianControl myuc = new BiaoqianControl(_bqInfo._childNodes[i]);
                    p.Controls.Add(myuc);
                    p.Controls.SetChildIndex(myuc, index);
                }
            }
            else
            {
                Panel p = this.Parent as Panel;
                //如果是折叠状态，循环判断biaoqiancontrol的标签信息的父标签名,如果等于父标签名称，那么展开状态改为折叠，
                int index = p.Controls.IndexOf(this);
                for (int i = index - 1; i >= 0; i--)
                {
                    if ((p.Controls[i] as BiaoqianControl)._bqInfo._jibie > _bqInfo._jibie)
                    {
                        p.Controls.Remove(p.Controls[i]);
                    }
                }
            }
        }

        private void pb_edit_Click(object sender, EventArgs e)
        {
            //弹出添加标签窗体，进行设置，保存到内容标签表数据库
            //将所点击的标签信息传递给parentinfo
            NewBQForm myform = new NewBQForm() {_tagInfo= _bqInfo};
            if (myform.ShowDialog() == DialogResult.OK)
            {

            }

        }
        /// <summary>
        /// 点击删除标签按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_delete_Click(object sender, EventArgs e)
        {
            DialogResult mydr = MessageBox.Show($"确定删除 {_bqInfo._mingcheng} 标签吗?","消息提示",MessageBoxButtons.YesNoCancel);
            if (mydr==DialogResult.Yes)
            {
            ////修改数据库中记录的删除状态==1，以及所有子标签
            //string str_sql = $"update 数据解析库.内容标签表 set 删除=1 where 名称='{_bqInfo._mingcheng}'";
            ////开始删除子标签
            //var list = GetChildNodes().Select(t=>t._mingcheng).ToList();
            Panel p = this.Parent as Panel;

            //for (int i = p.Controls.Count - 1; i >=0; i--)
            //{
            //    if (list.Contains((p.Controls[i] as BiaoqianControl)._bqInfo._mingcheng))
            //    {
            //        p.Controls.Remove(p.Controls[i]);
            //    }
            //}
            //MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);


            //定位当前需要删除的标签在容器中的位置
            int index = p.Controls.IndexOf(this);
            //开始循环位置，不停删除，知道遇到了控件级别等于或者小于自己的控件停止
            
            for (int i =index-1; i >=0; i--)
            {
                if ((p.Controls[i] as BiaoqianControl)._bqInfo._jibie>_bqInfo._jibie)
                {
                    p.Controls.Remove(p.Controls[i]);
                }
            }
            (this.Parent as Panel).Controls.Remove(this);
            DeleteNode();
            MessageBox.Show($"标签 {_bqInfo._mingcheng} 已删除成功！");

            }


        }


        /// <summary>
        /// 删除标签以及子标签
        /// </summary>
        private void DeleteNode()
        {
            string str_sql = $"update 数据解析库.内容标签表 " +
                $"set 删除=1 " +
                $"where (名称='{_bqInfo._mingcheng}' or 父标签名='{_bqInfo._mingcheng}') and 删除=0";
            MySqlHelper.ExecuteNonQuery(SystemInfo._strConn, str_sql);
        }

    }
}
