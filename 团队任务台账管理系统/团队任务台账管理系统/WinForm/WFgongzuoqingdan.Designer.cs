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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_renwumingcheng = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_queding = new System.Windows.Forms.Label();
            this.lbl_quxiao = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tb_beizhu = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtp_wanchengshijian = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_d = new System.Windows.Forms.RadioButton();
            this.rb_c = new System.Windows.Forms.RadioButton();
            this.rb_b = new System.Windows.Forms.RadioButton();
            this.rb_a = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_zishu = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_renwuneirong = new System.Windows.Forms.TextBox();
            this.lbl_zishu2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_zishu);
            this.groupBox1.Controls.Add(this.tb_renwumingcheng);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任务名称";
            // 
            // tb_renwumingcheng
            // 
            this.tb_renwumingcheng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_renwumingcheng.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tb_renwumingcheng.Location = new System.Drawing.Point(3, 19);
            this.tb_renwumingcheng.Multiline = true;
            this.tb_renwumingcheng.Name = "tb_renwumingcheng";
            this.tb_renwumingcheng.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_renwumingcheng.Size = new System.Drawing.Size(504, 122);
            this.tb_renwumingcheng.TabIndex = 0;
            this.tb_renwumingcheng.TextChanged += new System.EventHandler(this.tb_renwumingcheng_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_queding, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_quxiao, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 578);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(516, 35);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lbl_queding
            // 
            this.lbl_queding.AutoSize = true;
            this.lbl_queding.BackColor = System.Drawing.Color.Tomato;
            this.lbl_queding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_queding.ForeColor = System.Drawing.Color.White;
            this.lbl_queding.Location = new System.Drawing.Point(183, 5);
            this.lbl_queding.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_queding.Name = "lbl_queding";
            this.lbl_queding.Size = new System.Drawing.Size(70, 25);
            this.lbl_queding.TabIndex = 2;
            this.lbl_queding.Text = "确    定";
            this.lbl_queding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_queding.Click += new System.EventHandler(this.lbl_queding_Click);
            this.lbl_queding.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_quxiao_Paint);
            this.lbl_queding.MouseEnter += new System.EventHandler(this.lbl_queding_MouseEnter);
            this.lbl_queding.MouseLeave += new System.EventHandler(this.lbl_quxiao_MouseLeave);
            // 
            // lbl_quxiao
            // 
            this.lbl_quxiao.AutoSize = true;
            this.lbl_quxiao.BackColor = System.Drawing.Color.Tomato;
            this.lbl_quxiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_quxiao.ForeColor = System.Drawing.Color.White;
            this.lbl_quxiao.Location = new System.Drawing.Point(263, 5);
            this.lbl_quxiao.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_quxiao.Name = "lbl_quxiao";
            this.lbl_quxiao.Size = new System.Drawing.Size(70, 25);
            this.lbl_quxiao.TabIndex = 1;
            this.lbl_quxiao.Text = "取    消";
            this.lbl_quxiao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_quxiao.Click += new System.EventHandler(this.lbl_quxiao_Click);
            this.lbl_quxiao.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_quxiao_Paint);
            this.lbl_quxiao.MouseEnter += new System.EventHandler(this.lbl_queding_MouseEnter);
            this.lbl_quxiao.MouseLeave += new System.EventHandler(this.lbl_quxiao_MouseLeave);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tb_beizhu);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(3, 403);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(510, 172);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "进展备注";
            // 
            // tb_beizhu
            // 
            this.tb_beizhu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_beizhu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tb_beizhu.Location = new System.Drawing.Point(3, 19);
            this.tb_beizhu.Multiline = true;
            this.tb_beizhu.Name = "tb_beizhu";
            this.tb_beizhu.Size = new System.Drawing.Size(504, 150);
            this.tb_beizhu.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtp_wanchengshijian);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(3, 353);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 44);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "任务完成时间";
            // 
            // dtp_wanchengshijian
            // 
            this.dtp_wanchengshijian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtp_wanchengshijian.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dtp_wanchengshijian.Location = new System.Drawing.Point(3, 19);
            this.dtp_wanchengshijian.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.dtp_wanchengshijian.Name = "dtp_wanchengshijian";
            this.dtp_wanchengshijian.Size = new System.Drawing.Size(504, 23);
            this.dtp_wanchengshijian.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_d);
            this.groupBox2.Controls.Add(this.rb_c);
            this.groupBox2.Controls.Add(this.rb_b);
            this.groupBox2.Controls.Add(this.rb_a);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(3, 303);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 44);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轻重缓急";
            // 
            // rb_d
            // 
            this.rb_d.AutoSize = true;
            this.rb_d.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb_d.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rb_d.Location = new System.Drawing.Point(333, 19);
            this.rb_d.Name = "rb_d";
            this.rb_d.Size = new System.Drawing.Size(119, 22);
            this.rb_d.TabIndex = 2;
            this.rb_d.Text = "D类不急且不重要";
            this.rb_d.UseVisualStyleBackColor = true;
            this.rb_d.CheckedChanged += new System.EventHandler(this.rb_a_CheckedChanged);
            // 
            // rb_c
            // 
            this.rb_c.AutoSize = true;
            this.rb_c.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb_c.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rb_c.Location = new System.Drawing.Point(227, 19);
            this.rb_c.Name = "rb_c";
            this.rb_c.Size = new System.Drawing.Size(106, 22);
            this.rb_c.TabIndex = 1;
            this.rb_c.Text = "C类不急但重要";
            this.rb_c.UseVisualStyleBackColor = true;
            this.rb_c.CheckedChanged += new System.EventHandler(this.rb_a_CheckedChanged);
            // 
            // rb_b
            // 
            this.rb_b.AutoSize = true;
            this.rb_b.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb_b.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rb_b.Location = new System.Drawing.Point(109, 19);
            this.rb_b.Name = "rb_b";
            this.rb_b.Size = new System.Drawing.Size(118, 22);
            this.rb_b.TabIndex = 0;
            this.rb_b.Text = "B类紧急但不重要";
            this.rb_b.UseVisualStyleBackColor = true;
            this.rb_b.CheckedChanged += new System.EventHandler(this.rb_a_CheckedChanged);
            // 
            // rb_a
            // 
            this.rb_a.AutoSize = true;
            this.rb_a.Checked = true;
            this.rb_a.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb_a.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rb_a.Location = new System.Drawing.Point(3, 19);
            this.rb_a.Name = "rb_a";
            this.rb_a.Size = new System.Drawing.Size(106, 22);
            this.rb_a.TabIndex = 0;
            this.rb_a.TabStop = true;
            this.rb_a.Text = "A类紧急且重要";
            this.rb_a.UseVisualStyleBackColor = true;
            this.rb_a.CheckedChanged += new System.EventHandler(this.rb_a_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(516, 613);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // lbl_zishu
            // 
            this.lbl_zishu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_zishu.AutoSize = true;
            this.lbl_zishu.Location = new System.Drawing.Point(433, 122);
            this.lbl_zishu.Name = "lbl_zishu";
            this.lbl_zishu.Size = new System.Drawing.Size(56, 17);
            this.lbl_zishu.TabIndex = 1;
            this.lbl_zishu.Text = "400/400";
            this.lbl_zishu.Click += new System.EventHandler(this.lbl_zishu_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_zishu2);
            this.groupBox3.Controls.Add(this.tb_renwuneirong);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(3, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 144);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "任务内容";
            // 
            // tb_renwuneirong
            // 
            this.tb_renwuneirong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_renwuneirong.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tb_renwuneirong.Location = new System.Drawing.Point(3, 19);
            this.tb_renwuneirong.Multiline = true;
            this.tb_renwuneirong.Name = "tb_renwuneirong";
            this.tb_renwuneirong.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_renwuneirong.Size = new System.Drawing.Size(504, 122);
            this.tb_renwuneirong.TabIndex = 0;
            this.tb_renwuneirong.TextChanged += new System.EventHandler(this.tb_renwuneirong_TextChanged);
            // 
            // lbl_zishu2
            // 
            this.lbl_zishu2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_zishu2.AutoSize = true;
            this.lbl_zishu2.Location = new System.Drawing.Point(433, 123);
            this.lbl_zishu2.Name = "lbl_zishu2";
            this.lbl_zishu2.Size = new System.Drawing.Size(56, 17);
            this.lbl_zishu2.TabIndex = 1;
            this.lbl_zishu2.Text = "400/400";
            this.lbl_zishu2.Click += new System.EventHandler(this.lbl_zishu_Click);
            // 
            // WFgongzuoqingdan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(516, 613);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WFgongzuoqingdan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建工作清单";
            this.Load += new System.EventHandler(this.WFgongzuoqingdan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_renwumingcheng;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_queding;
        private System.Windows.Forms.Label lbl_quxiao;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tb_beizhu;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtp_wanchengshijian;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_d;
        private System.Windows.Forms.RadioButton rb_c;
        private System.Windows.Forms.RadioButton rb_b;
        private System.Windows.Forms.RadioButton rb_a;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_zishu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_renwuneirong;
        private System.Windows.Forms.Label lbl_zishu2;
    }
}