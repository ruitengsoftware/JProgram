using RuiTengDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WFperson : Form
    {


        public List<string> list_selected = new List<string>();//获得所有选中节点的名称
        ControllerWFperson mycontroller = new ControllerWFperson();
        /// <summary>
        /// 用于保存构造函数传进来的已选中人员名单
        /// </summary>
        List<string> list_person = new List<string>();
        List<string> listr_allperson = new List<string>();
        public WFperson(List<string> list)
        {
            InitializeComponent();
            list_person = list;
        }
        public WFperson()
        {
            InitializeComponent();
        }


        public void GetSelected(TreeNode node)
        {
            foreach (TreeNode n in node.Nodes)
            {
                if (n.Checked)
                {
                    if (listr_allperson.Contains(n.Text))
                    {
                        list_selected.Add(n.Text);

                    }

                }
                GetSelected(n);
            }
        }


        private void WFperson_Load(object sender, EventArgs e)
        {
            tv_my.Nodes.Add("全部", "全部");
            var data = mycontroller.GetAllPerson();
            //获得全部人员list
            foreach (DataRow dataRow in data.Rows)
            {
                listr_allperson.Add(dataRow["花名"].ToString());
            }
            var data_bumen = mycontroller.GetAllBumen();
            //添加一级部门,同时打勾构造函数传进来的选中人员
            foreach (DataRow dr in data_bumen.Rows)
            {
                //TreeNode tr = new TreeNode(dr["所属部门"].ToString());
                if (dr["级别"].ToString().Equals("一级部门"))
                {
                    tv_my.Nodes["全部"].Nodes.Add(dr["名称"].ToString(), dr["名称"].ToString());
                    foreach (DataRow dr2 in data.Rows)
                    {
                        if (dr2["部门"].ToString().Equals(dr["名称"].ToString()))
                        {
                            //tv_my.Nodes["全部"].Nodes[dr["名称"].ToString()].Nodes.Add($"{dr2["花名"].ToString()}({dr2["实名"].ToString()})", $"{dr2["花名"].ToString()}({dr2["实名"].ToString()})");
                          var node=  tv_my.Nodes["全部"].Nodes[dr["名称"].ToString()].Nodes.Add($"{dr2["花名"].ToString()}", $"{dr2["花名"].ToString()}");
                            if (list_person.Contains(dr2["花名"].ToString()))
                            {
                                node.Checked = true;
                            }
                        }
                    }
                }
            }
            //添加二级部门，同时将构造函数传过来的选中人员名单进行打勾

            foreach (DataRow dr in data_bumen.Rows)
            {
                //TreeNode tr = new TreeNode(dr["所属部门"].ToString());
                if (dr["级别"].ToString().Equals("二级部门"))
                {

                    tv_my.Nodes["全部"].Nodes[dr["所属部门"].ToString()].Nodes.Add(dr["名称"].ToString(), dr["名称"].ToString());
                    foreach (DataRow dr2 in data.Rows)
                    {
                        if (dr2["部门"].ToString().Equals(dr["名称"].ToString()))
                        {
                          var node=  tv_my.Nodes["全部"].Nodes[dr["所属部门"].ToString()].Nodes[dr["名称"].ToString()].Nodes.Add($"{dr2["花名"].ToString()}", $"{dr2["花名"].ToString()}");
                            if (list_person.Contains(dr2["花名"].ToString()))
                            {
                                node.Checked = true;
                            }
                        }
                    }

                }
            }





        }





        private void btn_guanbi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_quding_Click(object sender, EventArgs e)
        {
            GetSelected(tv_my.Nodes["全部"]);
            this.DialogResult = DialogResult.OK;
        }




        private void tv_my_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void tv_my_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Action != TreeViewAction.Unknown)
            {
                UpdateCheckStatus(e);
            }
        }
        private void UpdateCheckStatus(TreeViewEventArgs e)
        {
            CheckAllChildNodes(e.Node);
            UpdateAllParentNodes(e.Node);
        }

        private void UpdateAllParentNodes(TreeNode treeNode)
        {
            TreeNode parent = treeNode.Parent;
            if (parent != null)
            {
                if (parent.Checked && !treeNode.Checked)
                {
                    parent.Checked = false;
                    UpdateAllParentNodes(parent);
                }
                else if (!parent.Checked && treeNode.Checked)
                {
                    bool all = true;
                    foreach (TreeNode node in parent.Nodes)
                    {
                        if (!node.Checked)
                        {
                            all = false;
                            break;
                        }
                    }
                    if (all)
                    {
                        parent.Checked = true;
                        UpdateAllParentNodes(parent);
                    }
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = treeNode.Checked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node);
                }
            }
        }
        UIHelper _ui = new UIHelper();
        private void label1_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawRoundRect((Control)sender);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, -1);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.UpdateCSize((Control)sender, +1);

        }
    }
}
