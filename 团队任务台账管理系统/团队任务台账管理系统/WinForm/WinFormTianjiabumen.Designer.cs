namespace 团队任务台账管理系统.WinForm
{
    partial class WinFormTianjiabumen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_queding = new System.Windows.Forms.Button();
            this.btn_guanbi = new System.Windows.Forms.Button();
            this.flp_suoshubumen = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_suoshubumen = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_jibie = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_mingcheng = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flp_suoshubumen.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.flp_suoshubumen);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 191);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_queding, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_guanbi, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 120);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(228, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_queding
            // 
            this.btn_queding.Location = new System.Drawing.Point(37, 3);
            this.btn_queding.Name = "btn_queding";
            this.btn_queding.Size = new System.Drawing.Size(74, 34);
            this.btn_queding.TabIndex = 0;
            this.btn_queding.Text = "确定";
            this.btn_queding.UseVisualStyleBackColor = true;
            this.btn_queding.Click += new System.EventHandler(this.btn_queding_Click);
            // 
            // btn_guanbi
            // 
            this.btn_guanbi.Location = new System.Drawing.Point(117, 3);
            this.btn_guanbi.Name = "btn_guanbi";
            this.btn_guanbi.Size = new System.Drawing.Size(74, 34);
            this.btn_guanbi.TabIndex = 0;
            this.btn_guanbi.Text = "关闭";
            this.btn_guanbi.UseVisualStyleBackColor = true;
            this.btn_guanbi.Click += new System.EventHandler(this.btn_guanbi_Click);
            // 
            // flp_suoshubumen
            // 
            this.flp_suoshubumen.ColumnCount = 2;
            this.flp_suoshubumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.flp_suoshubumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flp_suoshubumen.Controls.Add(this.label2, 0, 0);
            this.flp_suoshubumen.Controls.Add(this.cbb_suoshubumen, 1, 0);
            this.flp_suoshubumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.flp_suoshubumen.Location = new System.Drawing.Point(0, 80);
            this.flp_suoshubumen.Margin = new System.Windows.Forms.Padding(0);
            this.flp_suoshubumen.Name = "flp_suoshubumen";
            this.flp_suoshubumen.RowCount = 1;
            this.flp_suoshubumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flp_suoshubumen.Size = new System.Drawing.Size(228, 40);
            this.flp_suoshubumen.TabIndex = 1;
            this.flp_suoshubumen.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 8, 8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "所属部门";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbb_suoshubumen
            // 
            this.cbb_suoshubumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbb_suoshubumen.FormattingEnabled = true;
            this.cbb_suoshubumen.Location = new System.Drawing.Point(83, 8);
            this.cbb_suoshubumen.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbb_suoshubumen.Name = "cbb_suoshubumen";
            this.cbb_suoshubumen.Size = new System.Drawing.Size(142, 25);
            this.cbb_suoshubumen.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbb_jibie, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(228, 40);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "级别";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbb_jibie
            // 
            this.cbb_jibie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbb_jibie.FormattingEnabled = true;
            this.cbb_jibie.Location = new System.Drawing.Point(83, 8);
            this.cbb_jibie.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbb_jibie.Name = "cbb_jibie";
            this.cbb_jibie.Size = new System.Drawing.Size(142, 25);
            this.cbb_jibie.TabIndex = 1;
            this.cbb_jibie.TextChanged += new System.EventHandler(this.cbb_jibie_TextChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tb_mingcheng, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(228, 40);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 8, 8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_mingcheng
            // 
            this.tb_mingcheng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_mingcheng.Location = new System.Drawing.Point(83, 8);
            this.tb_mingcheng.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.tb_mingcheng.Name = "tb_mingcheng";
            this.tb_mingcheng.Size = new System.Drawing.Size(142, 23);
            this.tb_mingcheng.TabIndex = 1;
            // 
            // WinFormTianjiabumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(228, 191);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormTianjiabumen";
            this.Text = "添加部门";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flp_suoshubumen.ResumeLayout(false);
            this.flp_suoshubumen.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_queding;
        private System.Windows.Forms.Button btn_guanbi;
        private System.Windows.Forms.TableLayoutPanel flp_suoshubumen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_suoshubumen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_jibie;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_mingcheng;
    }
}