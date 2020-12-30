namespace 团队任务台账管理系统.WinForm
{
    partial class WFyijianjianyi
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_biaoti = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_fankuiduixiang = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tb_neirong = new System.Windows.Forms.TextBox();
            this.lbl_baocun = new System.Windows.Forms.Label();
            this.lbl_quxiao = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rb_putong = new System.Windows.Forms.RadioButton();
            this.rb_jinji = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "标题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "反馈对象";
            // 
            // tb_biaoti
            // 
            this.tb_biaoti.Location = new System.Drawing.Point(111, 24);
            this.tb_biaoti.Name = "tb_biaoti";
            this.tb_biaoti.Size = new System.Drawing.Size(210, 23);
            this.tb_biaoti.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "上传附件";
            // 
            // tb_fankuiduixiang
            // 
            this.tb_fankuiduixiang.Location = new System.Drawing.Point(111, 62);
            this.tb_fankuiduixiang.Name = "tb_fankuiduixiang";
            this.tb_fankuiduixiang.Size = new System.Drawing.Size(210, 23);
            this.tb_fankuiduixiang.TabIndex = 28;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 259);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 23);
            this.textBox1.TabIndex = 28;
            // 
            // tb_neirong
            // 
            this.tb_neirong.Location = new System.Drawing.Point(115, 154);
            this.tb_neirong.Multiline = true;
            this.tb_neirong.Name = "tb_neirong";
            this.tb_neirong.Size = new System.Drawing.Size(210, 89);
            this.tb_neirong.TabIndex = 26;
            // 
            // lbl_baocun
            // 
            this.lbl_baocun.AutoSize = true;
            this.lbl_baocun.BackColor = System.Drawing.Color.Tomato;
            this.lbl_baocun.ForeColor = System.Drawing.Color.White;
            this.lbl_baocun.Location = new System.Drawing.Point(86, 323);
            this.lbl_baocun.Name = "lbl_baocun";
            this.lbl_baocun.Size = new System.Drawing.Size(32, 17);
            this.lbl_baocun.TabIndex = 30;
            this.lbl_baocun.Text = "保存";
            this.lbl_baocun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_baocun.Click += new System.EventHandler(this.lbl_baocun_Click);
            // 
            // lbl_quxiao
            // 
            this.lbl_quxiao.AutoSize = true;
            this.lbl_quxiao.BackColor = System.Drawing.Color.Tomato;
            this.lbl_quxiao.ForeColor = System.Drawing.Color.White;
            this.lbl_quxiao.Location = new System.Drawing.Point(249, 323);
            this.lbl_quxiao.Name = "lbl_quxiao";
            this.lbl_quxiao.Size = new System.Drawing.Size(32, 17);
            this.lbl_quxiao.TabIndex = 29;
            this.lbl_quxiao.Text = "取消";
            this.lbl_quxiao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_quxiao.Click += new System.EventHandler(this.lbl_quxiao_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "内容";
            // 
            // rb_putong
            // 
            this.rb_putong.AutoSize = true;
            this.rb_putong.Checked = true;
            this.rb_putong.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb_putong.Location = new System.Drawing.Point(4, 4);
            this.rb_putong.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.rb_putong.Name = "rb_putong";
            this.rb_putong.Size = new System.Drawing.Size(50, 22);
            this.rb_putong.TabIndex = 0;
            this.rb_putong.TabStop = true;
            this.rb_putong.Text = "普通";
            this.rb_putong.UseVisualStyleBackColor = true;
            // 
            // rb_jinji
            // 
            this.rb_jinji.AutoSize = true;
            this.rb_jinji.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb_jinji.Location = new System.Drawing.Point(54, 4);
            this.rb_jinji.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.rb_jinji.Name = "rb_jinji";
            this.rb_jinji.Size = new System.Drawing.Size(50, 22);
            this.rb_jinji.TabIndex = 0;
            this.rb_jinji.Text = "紧急";
            this.rb_jinji.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_jinji);
            this.panel1.Controls.Add(this.rb_putong);
            this.panel1.Location = new System.Drawing.Point(111, 106);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(214, 30);
            this.panel1.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "紧急程度";
            // 
            // WFyijianjianyi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 540);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_quxiao);
            this.Controls.Add(this.lbl_baocun);
            this.Controls.Add(this.tb_neirong);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tb_fankuiduixiang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_biaoti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WFyijianjianyi";
            this.Text = "WFyijianjianyi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_biaoti;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_fankuiduixiang;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tb_neirong;
        private System.Windows.Forms.Label lbl_baocun;
        private System.Windows.Forms.Label lbl_quxiao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rb_putong;
        private System.Windows.Forms.RadioButton rb_jinji;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
    }
}