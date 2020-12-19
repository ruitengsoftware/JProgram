namespace 团队任务台账管理系统.UserControll
{
    partial class UCTaskInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_fuzeren = new System.Windows.Forms.TextBox();
            this.tb_canyuren = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_fasong = new System.Windows.Forms.Label();
            this.lbl_wancheng = new System.Windows.Forms.Label();
            this.dtp_shixian = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_xiangqing = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.rb_teji = new System.Windows.Forms.RadioButton();
            this.rb_putong = new System.Windows.Forms.RadioButton();
            this.rb_jijian = new System.Windows.Forms.RadioButton();
            this.tb_renwumingcheng = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_delete = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_fuzeren
            // 
            this.tb_fuzeren.Location = new System.Drawing.Point(83, 183);
            this.tb_fuzeren.Name = "tb_fuzeren";
            this.tb_fuzeren.Size = new System.Drawing.Size(275, 23);
            this.tb_fuzeren.TabIndex = 8;
            this.tb_fuzeren.TextChanged += new System.EventHandler(this.tb_fuzeren_TextChanged);
            // 
            // tb_canyuren
            // 
            this.tb_canyuren.Location = new System.Drawing.Point(83, 213);
            this.tb_canyuren.Name = "tb_canyuren";
            this.tb_canyuren.Size = new System.Drawing.Size(275, 23);
            this.tb_canyuren.TabIndex = 8;
            this.tb_canyuren.TextChanged += new System.EventHandler(this.tb_canyuren_TextChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel4.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel5.Controls.Add(this.lbl_wancheng, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lbl_fasong, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.pictureBox1, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.pb_delete, 4, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(361, 30);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // lbl_fasong
            // 
            this.lbl_fasong.AutoSize = true;
            this.lbl_fasong.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_fasong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_fasong.ForeColor = System.Drawing.Color.White;
            this.lbl_fasong.Location = new System.Drawing.Point(153, 3);
            this.lbl_fasong.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_fasong.Name = "lbl_fasong";
            this.lbl_fasong.Size = new System.Drawing.Size(74, 24);
            this.lbl_fasong.TabIndex = 0;
            this.lbl_fasong.Text = "发送任务 ";
            this.lbl_fasong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_fasong.Click += new System.EventHandler(this.lbl_fasong_Click);
            // 
            // lbl_wancheng
            // 
            this.lbl_wancheng.AutoSize = true;
            this.lbl_wancheng.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_wancheng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_wancheng.ForeColor = System.Drawing.Color.White;
            this.lbl_wancheng.Location = new System.Drawing.Point(73, 3);
            this.lbl_wancheng.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_wancheng.Name = "lbl_wancheng";
            this.lbl_wancheng.Size = new System.Drawing.Size(74, 24);
            this.lbl_wancheng.TabIndex = 0;
            this.lbl_wancheng.Text = "完成任务";
            this.lbl_wancheng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_wancheng.Click += new System.EventHandler(this.lbl_wancheng_Click);
            // 
            // dtp_shixian
            // 
            this.dtp_shixian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtp_shixian.Location = new System.Drawing.Point(83, 243);
            this.dtp_shixian.Name = "dtp_shixian";
            this.dtp_shixian.Size = new System.Drawing.Size(275, 23);
            this.dtp_shixian.TabIndex = 7;
            this.dtp_shixian.ValueChanged += new System.EventHandler(this.dtp_shixian_ValueChanged);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.tb_xiangqing, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(80, 120);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(281, 60);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // tb_xiangqing
            // 
            this.tb_xiangqing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_xiangqing.Location = new System.Drawing.Point(3, 3);
            this.tb_xiangqing.Multiline = true;
            this.tb_xiangqing.Name = "tb_xiangqing";
            this.tb_xiangqing.Size = new System.Drawing.Size(275, 54);
            this.tb_xiangqing.TabIndex = 0;
            this.tb_xiangqing.TextChanged += new System.EventHandler(this.tb_xiangqing_TextChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.rb_jijian, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.rb_putong, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.rb_teji, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(83, 93);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(275, 24);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // rb_teji
            // 
            this.rb_teji.AutoSize = true;
            this.rb_teji.Location = new System.Drawing.Point(163, 3);
            this.rb_teji.Name = "rb_teji";
            this.rb_teji.Size = new System.Drawing.Size(50, 18);
            this.rb_teji.TabIndex = 0;
            this.rb_teji.Text = "特急";
            this.rb_teji.UseVisualStyleBackColor = true;
            this.rb_teji.CheckedChanged += new System.EventHandler(this.rb_teji_CheckedChanged);
            // 
            // rb_putong
            // 
            this.rb_putong.AutoSize = true;
            this.rb_putong.Checked = true;
            this.rb_putong.Location = new System.Drawing.Point(3, 3);
            this.rb_putong.Name = "rb_putong";
            this.rb_putong.Size = new System.Drawing.Size(50, 18);
            this.rb_putong.TabIndex = 0;
            this.rb_putong.TabStop = true;
            this.rb_putong.Text = "普通";
            this.rb_putong.UseVisualStyleBackColor = true;
            this.rb_putong.CheckedChanged += new System.EventHandler(this.rb_putong_CheckedChanged);
            // 
            // rb_jijian
            // 
            this.rb_jijian.AutoSize = true;
            this.rb_jijian.Location = new System.Drawing.Point(83, 3);
            this.rb_jijian.Name = "rb_jijian";
            this.rb_jijian.Size = new System.Drawing.Size(50, 18);
            this.rb_jijian.TabIndex = 0;
            this.rb_jijian.Text = "急件";
            this.rb_jijian.UseVisualStyleBackColor = true;
            this.rb_jijian.CheckedChanged += new System.EventHandler(this.rb_jijian_CheckedChanged);
            // 
            // tb_renwumingcheng
            // 
            this.tb_renwumingcheng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_renwumingcheng.Location = new System.Drawing.Point(83, 33);
            this.tb_renwumingcheng.Multiline = true;
            this.tb_renwumingcheng.Name = "tb_renwumingcheng";
            this.tb_renwumingcheng.Size = new System.Drawing.Size(275, 54);
            this.tb_renwumingcheng.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(1, 241);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 28);
            this.label11.TabIndex = 0;
            this.label11.Text = "时限";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(1, 211);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "参与人";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(1, 181);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "负责人";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(1, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 58);
            this.label4.TabIndex = 0;
            this.label4.Text = "详情";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(1, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "紧急程度";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(1, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 58);
            this.label2.TabIndex = 0;
            this.label2.Text = "任务名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.tb_renwumingcheng, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.dtp_shixian, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tb_canyuren, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.tb_fuzeren, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(361, 497);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::团队任务台账管理系统.Properties.Resources.delete3;
            this.pictureBox1.Location = new System.Drawing.Point(333, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pb_delete
            // 
            this.pb_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_delete.Image = global::团队任务台账管理系统.Properties.Resources.delete1;
            this.pb_delete.Location = new System.Drawing.Point(303, 3);
            this.pb_delete.Name = "pb_delete";
            this.pb_delete.Size = new System.Drawing.Size(24, 24);
            this.pb_delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_delete.TabIndex = 2;
            this.pb_delete.TabStop = false;
            this.pb_delete.Click += new System.EventHandler(this.pb_delete_Click);
            // 
            // UCTaskInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCTaskInfo";
            this.Size = new System.Drawing.Size(361, 497);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_fuzeren;
        private System.Windows.Forms.TextBox tb_canyuren;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_renwumingcheng;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.RadioButton rb_jijian;
        private System.Windows.Forms.RadioButton rb_putong;
        private System.Windows.Forms.RadioButton rb_teji;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TextBox tb_xiangqing;
        private System.Windows.Forms.DateTimePicker dtp_shixian;
        private System.Windows.Forms.Label lbl_wancheng;
        private System.Windows.Forms.Label lbl_fasong;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pb_delete;
    }
}
