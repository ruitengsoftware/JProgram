namespace 团队任务台账管理系统.WinForm
{
    partial class WFzhiji
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("M1-主管");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("M2-经理");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("M3-资深经理");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("M4-总监");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("M5-资深总监");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("M6-副总裁");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("M7-资深副总裁");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("M8-执行副总裁");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("M9-副董事长");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("M10-董事长");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("管理类", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("P1-实习");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("P2-试用期");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("P3-新入职");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("P4-初级工程师");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("P5-中级工程师");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("P6-高级工程师");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("P7-专家");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("P8-高级专家");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("P9-资深专家");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("P10-研究员");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("P11-资深研究员");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("P12-科学家");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("P13-资深科学家");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("技术类", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("C1-股东");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("C2-咨询顾问");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("C3-外部开发负责人");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("C4-外部开发成员");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("C5-产品设计负责人");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("C6-产品设计师");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("C7-产品体验负责人");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("C8-产品体验师");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("C9-产品营销团队负责人");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("C10-产品营销师");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("C11-一键成文作者");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("C12-一键成文团队成员");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("综合类", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37});
            this.btn_guanbi = new System.Windows.Forms.Button();
            this.btn_queding = new System.Windows.Forms.Button();
            this.tv_my = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btn_guanbi
            // 
            this.btn_guanbi.Location = new System.Drawing.Point(236, 377);
            this.btn_guanbi.Name = "btn_guanbi";
            this.btn_guanbi.Size = new System.Drawing.Size(97, 28);
            this.btn_guanbi.TabIndex = 4;
            this.btn_guanbi.Text = "关闭";
            this.btn_guanbi.UseVisualStyleBackColor = true;
            this.btn_guanbi.Click += new System.EventHandler(this.btn_guanbi_Click);
            // 
            // btn_queding
            // 
            this.btn_queding.Location = new System.Drawing.Point(105, 377);
            this.btn_queding.Name = "btn_queding";
            this.btn_queding.Size = new System.Drawing.Size(96, 28);
            this.btn_queding.TabIndex = 3;
            this.btn_queding.Text = "确认";
            this.btn_queding.UseVisualStyleBackColor = true;
            this.btn_queding.Click += new System.EventHandler(this.btn_queding_Click);
            // 
            // tv_my
            // 
            this.tv_my.Location = new System.Drawing.Point(12, 12);
            this.tv_my.Name = "tv_my";
            treeNode1.Name = "节点3";
            treeNode1.Text = "M1-主管";
            treeNode2.Name = "节点4";
            treeNode2.Text = "M2-经理";
            treeNode3.Name = "节点5";
            treeNode3.Text = "M3-资深经理";
            treeNode4.Name = "节点2";
            treeNode4.Text = "M4-总监";
            treeNode5.Name = "节点3";
            treeNode5.Text = "M5-资深总监";
            treeNode6.Name = "节点4";
            treeNode6.Text = "M6-副总裁";
            treeNode7.Name = "节点5";
            treeNode7.Text = "M7-资深副总裁";
            treeNode8.Name = "节点6";
            treeNode8.Text = "M8-执行副总裁";
            treeNode9.Name = "节点7";
            treeNode9.Text = "M9-副董事长";
            treeNode10.Name = "节点8";
            treeNode10.Text = "M10-董事长";
            treeNode11.Name = "节点0";
            treeNode11.Text = "管理类";
            treeNode12.Name = "节点6";
            treeNode12.Text = "P1-实习";
            treeNode13.Name = "节点8";
            treeNode13.Text = "P2-试用期";
            treeNode14.Name = "节点9";
            treeNode14.Text = "P3-新入职";
            treeNode15.Name = "节点10";
            treeNode15.Text = "P4-初级工程师";
            treeNode16.Name = "节点11";
            treeNode16.Text = "P5-中级工程师";
            treeNode17.Name = "节点12";
            treeNode17.Text = "P6-高级工程师";
            treeNode18.Name = "节点10";
            treeNode18.Text = "P7-专家";
            treeNode19.Name = "节点11";
            treeNode19.Text = "P8-高级专家";
            treeNode20.Name = "节点12";
            treeNode20.Text = "P9-资深专家";
            treeNode21.Name = "节点13";
            treeNode21.Text = "P10-研究员";
            treeNode22.Name = "节点14";
            treeNode22.Text = "P11-资深研究员";
            treeNode23.Name = "节点15";
            treeNode23.Text = "P12-科学家";
            treeNode24.Name = "节点17";
            treeNode24.Text = "P13-资深科学家";
            treeNode25.Name = "节点1";
            treeNode25.Text = "技术类";
            treeNode26.Name = "节点13";
            treeNode26.Text = "C1-股东";
            treeNode27.Name = "节点19";
            treeNode27.Text = "C2-咨询顾问";
            treeNode28.Name = "节点20";
            treeNode28.Text = "C3-外部开发负责人";
            treeNode29.Name = "节点21";
            treeNode29.Text = "C4-外部开发成员";
            treeNode30.Name = "节点22";
            treeNode30.Text = "C5-产品设计负责人";
            treeNode31.Name = "节点23";
            treeNode31.Text = "C6-产品设计师";
            treeNode32.Name = "节点24";
            treeNode32.Text = "C7-产品体验负责人";
            treeNode33.Name = "节点25";
            treeNode33.Text = "C8-产品体验师";
            treeNode34.Name = "节点26";
            treeNode34.Text = "C9-产品营销团队负责人";
            treeNode35.Name = "节点27";
            treeNode35.Text = "C10-产品营销师";
            treeNode36.Name = "节点28";
            treeNode36.Text = "C11-一键成文作者";
            treeNode37.Name = "节点29";
            treeNode37.Text = "C12-一键成文团队成员";
            treeNode38.Name = "节点2";
            treeNode38.Text = "综合类";
            this.tv_my.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode25,
            treeNode38});
            this.tv_my.Size = new System.Drawing.Size(454, 343);
            this.tv_my.TabIndex = 2;
            // 
            // WFzhiji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 432);
            this.Controls.Add(this.btn_guanbi);
            this.Controls.Add(this.btn_queding);
            this.Controls.Add(this.tv_my);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WFzhiji";
            this.Text = "WFzhiji";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_guanbi;
        private System.Windows.Forms.Button btn_queding;
        private System.Windows.Forms.TreeView tv_my;
    }
}