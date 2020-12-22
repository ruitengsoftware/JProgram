namespace 团队任务台账管理系统.WinForm
{
    partial class WFgongzuoqingdan
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
            this.lbl_quxiao = new System.Windows.Forms.Label();
            this.lbl_queding = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_renwumingcheng = new System.Windows.Forms.TextBox();
            this.cbb_xiangxian = new System.Windows.Forms.ComboBox();
            this.tb_zhubanren = new System.Windows.Forms.TextBox();
            this.dtp_wanchengshijian = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbl_quxiao
            // 
            this.lbl_quxiao.AutoSize = true;
            this.lbl_quxiao.BackColor = System.Drawing.Color.Tomato;
            this.lbl_quxiao.ForeColor = System.Drawing.Color.White;
            this.lbl_quxiao.Location = new System.Drawing.Point(225, 216);
            this.lbl_quxiao.Name = "lbl_quxiao";
            this.lbl_quxiao.Size = new System.Drawing.Size(48, 17);
            this.lbl_quxiao.TabIndex = 1;
            this.lbl_quxiao.Text = "取    消";
            this.lbl_quxiao.Click += new System.EventHandler(this.lbl_quxiao_Click);
            // 
            // lbl_queding
            // 
            this.lbl_queding.AutoSize = true;
            this.lbl_queding.BackColor = System.Drawing.Color.Tomato;
            this.lbl_queding.ForeColor = System.Drawing.Color.White;
            this.lbl_queding.Location = new System.Drawing.Point(115, 216);
            this.lbl_queding.Name = "lbl_queding";
            this.lbl_queding.Size = new System.Drawing.Size(48, 17);
            this.lbl_queding.TabIndex = 2;
            this.lbl_queding.Text = "确    定";
            this.lbl_queding.Click += new System.EventHandler(this.lbl_queding_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "任务完成时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "主办人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "象限选择";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "任务名称";
            // 
            // tb_renwumingcheng
            // 
            this.tb_renwumingcheng.Location = new System.Drawing.Point(131, 43);
            this.tb_renwumingcheng.Name = "tb_renwumingcheng";
            this.tb_renwumingcheng.Size = new System.Drawing.Size(194, 23);
            this.tb_renwumingcheng.TabIndex = 7;
            // 
            // cbb_xiangxian
            // 
            this.cbb_xiangxian.FormattingEnabled = true;
            this.cbb_xiangxian.Items.AddRange(new object[] {
            "A类重要且紧急",
            "B类重要但不紧急",
            "C类不重要但紧急",
            "D类不重要也不紧急"});
            this.cbb_xiangxian.Location = new System.Drawing.Point(132, 74);
            this.cbb_xiangxian.Name = "cbb_xiangxian";
            this.cbb_xiangxian.Size = new System.Drawing.Size(192, 25);
            this.cbb_xiangxian.TabIndex = 8;
            // 
            // tb_zhubanren
            // 
            this.tb_zhubanren.Location = new System.Drawing.Point(131, 112);
            this.tb_zhubanren.Name = "tb_zhubanren";
            this.tb_zhubanren.Size = new System.Drawing.Size(194, 23);
            this.tb_zhubanren.TabIndex = 7;
            // 
            // dtp_wanchengshijian
            // 
            this.dtp_wanchengshijian.Location = new System.Drawing.Point(133, 151);
            this.dtp_wanchengshijian.Name = "dtp_wanchengshijian";
            this.dtp_wanchengshijian.Size = new System.Drawing.Size(192, 23);
            this.dtp_wanchengshijian.TabIndex = 9;
            // 
            // WFgongzuoqingdan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 282);
            this.Controls.Add(this.dtp_wanchengshijian);
            this.Controls.Add(this.cbb_xiangxian);
            this.Controls.Add(this.tb_zhubanren);
            this.Controls.Add(this.tb_renwumingcheng);
            this.Controls.Add(this.lbl_quxiao);
            this.Controls.Add(this.lbl_queding);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WFgongzuoqingdan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建工作清单";
            this.Load += new System.EventHandler(this.WFgongzuoqingdan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_quxiao;
        private System.Windows.Forms.Label lbl_queding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_renwumingcheng;
        private System.Windows.Forms.ComboBox cbb_xiangxian;
        private System.Windows.Forms.TextBox tb_zhubanren;
        private System.Windows.Forms.DateTimePicker dtp_wanchengshijian;
    }
}