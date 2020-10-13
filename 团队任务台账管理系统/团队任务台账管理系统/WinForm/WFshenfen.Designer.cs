namespace 团队任务台账管理系统.WinForm
{
    partial class WFshenfen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("深圳前海极简信息咨询服务有限公司");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("深圳写手智能科技有限公司");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("谦海科技发展（清远市）有限公司");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("公司", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("第一技术开发团队");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("第二技术开发团队");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("第三技术开发团队");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("第四技术开发团队");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("第五技术开发团队");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("第六技术开发团队");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("开发团队", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("其他部门");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("其他部门", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.tv_my = new System.Windows.Forms.TreeView();
            this.btn_queding = new System.Windows.Forms.Button();
            this.btn_guanbi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tv_my
            // 
            this.tv_my.Location = new System.Drawing.Point(63, 38);
            this.tv_my.Name = "tv_my";
            treeNode1.Name = "节点3";
            treeNode1.Text = "深圳前海极简信息咨询服务有限公司";
            treeNode2.Name = "节点4";
            treeNode2.Text = "深圳写手智能科技有限公司";
            treeNode3.Name = "节点5";
            treeNode3.Text = "谦海科技发展（清远市）有限公司";
            treeNode4.Name = "节点0";
            treeNode4.Text = "公司";
            treeNode5.Name = "节点6";
            treeNode5.Text = "第一技术开发团队";
            treeNode6.Name = "节点8";
            treeNode6.Text = "第二技术开发团队";
            treeNode7.Name = "节点9";
            treeNode7.Text = "第三技术开发团队";
            treeNode8.Name = "节点10";
            treeNode8.Text = "第四技术开发团队";
            treeNode9.Name = "节点11";
            treeNode9.Text = "第五技术开发团队";
            treeNode10.Name = "节点12";
            treeNode10.Text = "第六技术开发团队";
            treeNode11.Name = "节点1";
            treeNode11.Text = "开发团队";
            treeNode12.Name = "节点13";
            treeNode12.Text = "其他部门";
            treeNode13.Name = "节点2";
            treeNode13.Text = "其他部门";
            this.tv_my.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode11,
            treeNode13});
            this.tv_my.Size = new System.Drawing.Size(454, 343);
            this.tv_my.TabIndex = 0;
            // 
            // btn_queding
            // 
            this.btn_queding.Location = new System.Drawing.Point(153, 400);
            this.btn_queding.Name = "btn_queding";
            this.btn_queding.Size = new System.Drawing.Size(100, 43);
            this.btn_queding.TabIndex = 1;
            this.btn_queding.Text = "确认";
            this.btn_queding.UseVisualStyleBackColor = true;
            this.btn_queding.Click += new System.EventHandler(this.btn_queding_Click);
            // 
            // btn_guanbi
            // 
            this.btn_guanbi.Location = new System.Drawing.Point(309, 400);
            this.btn_guanbi.Name = "btn_guanbi";
            this.btn_guanbi.Size = new System.Drawing.Size(100, 43);
            this.btn_guanbi.TabIndex = 1;
            this.btn_guanbi.Text = "关闭";
            this.btn_guanbi.UseVisualStyleBackColor = true;
            this.btn_guanbi.Click += new System.EventHandler(this.btn_guanbi_Click);
            // 
            // WFshenfen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 455);
            this.Controls.Add(this.btn_guanbi);
            this.Controls.Add(this.btn_queding);
            this.Controls.Add(this.tv_my);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WFshenfen";
            this.Text = "WFshenfen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_my;
        private System.Windows.Forms.Button btn_queding;
        private System.Windows.Forms.Button btn_guanbi;
    }
}