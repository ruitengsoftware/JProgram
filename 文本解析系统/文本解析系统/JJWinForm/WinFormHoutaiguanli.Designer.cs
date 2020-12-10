namespace 文本解析系统.JJWinForm
{
    partial class WinFormHoutaiguanli
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
            this.dgv_person = new System.Windows.Forms.DataGridView();
            this.lbl_baocun = new System.Windows.Forms.Label();
            this.lbl_guanbi = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_diaoyongguize = new System.Windows.Forms.TextBox();
            this.tb_diaoyongchachongku = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_jiechuguize = new System.Windows.Forms.TextBox();
            this.tb_jiechuchachongku = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_huaming = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rb_keyi = new System.Windows.Forms.RadioButton();
            this.rb_bukeyi = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_person)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_person
            // 
            this.dgv_person.AllowUserToAddRows = false;
            this.dgv_person.BackgroundColor = System.Drawing.Color.White;
            this.dgv_person.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_person.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_person.Location = new System.Drawing.Point(3, 131);
            this.dgv_person.Name = "dgv_person";
            this.dgv_person.RowHeadersVisible = false;
            this.dgv_person.RowTemplate.Height = 23;
            this.dgv_person.Size = new System.Drawing.Size(607, 276);
            this.dgv_person.TabIndex = 0;
            this.dgv_person.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_person_CellMouseClick);
            // 
            // lbl_baocun
            // 
            this.lbl_baocun.AutoSize = true;
            this.lbl_baocun.BackColor = System.Drawing.Color.Tomato;
            this.lbl_baocun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_baocun.ForeColor = System.Drawing.Color.White;
            this.lbl_baocun.Location = new System.Drawing.Point(229, 3);
            this.lbl_baocun.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_baocun.Name = "lbl_baocun";
            this.lbl_baocun.Size = new System.Drawing.Size(74, 24);
            this.lbl_baocun.TabIndex = 1;
            this.lbl_baocun.Text = "保存";
            this.lbl_baocun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_baocun.Click += new System.EventHandler(this.lbl_baocun_Click);
            // 
            // lbl_guanbi
            // 
            this.lbl_guanbi.AutoSize = true;
            this.lbl_guanbi.BackColor = System.Drawing.Color.Tomato;
            this.lbl_guanbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_guanbi.ForeColor = System.Drawing.Color.White;
            this.lbl_guanbi.Location = new System.Drawing.Point(309, 3);
            this.lbl_guanbi.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_guanbi.Name = "lbl_guanbi";
            this.lbl_guanbi.Size = new System.Drawing.Size(74, 24);
            this.lbl_guanbi.TabIndex = 1;
            this.lbl_guanbi.Text = "关闭";
            this.lbl_guanbi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_guanbi.Click += new System.EventHandler(this.lbl_guanbi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "授权管理";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(601, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tb_diaoyongguize, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tb_diaoyongchachongku, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(601, 30);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(305, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "调用查重库";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(5, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "调用规则";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_diaoyongguize
            // 
            this.tb_diaoyongguize.Location = new System.Drawing.Point(103, 3);
            this.tb_diaoyongguize.Name = "tb_diaoyongguize";
            this.tb_diaoyongguize.Size = new System.Drawing.Size(194, 23);
            this.tb_diaoyongguize.TabIndex = 1;
            // 
            // tb_diaoyongchachongku
            // 
            this.tb_diaoyongchachongku.Location = new System.Drawing.Point(403, 3);
            this.tb_diaoyongchachongku.Name = "tb_diaoyongchachongku";
            this.tb_diaoyongchachongku.Size = new System.Drawing.Size(194, 23);
            this.tb_diaoyongchachongku.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.tb_jiechuguize, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.tb_jiechuchachongku, 3, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(601, 30);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(5, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "删除规则";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(305, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "删除查重库";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_jiechuguize
            // 
            this.tb_jiechuguize.Location = new System.Drawing.Point(103, 3);
            this.tb_jiechuguize.Name = "tb_jiechuguize";
            this.tb_jiechuguize.Size = new System.Drawing.Size(194, 23);
            this.tb_jiechuguize.TabIndex = 1;
            // 
            // tb_jiechuchachongku
            // 
            this.tb_jiechuchachongku.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_jiechuchachongku.Location = new System.Drawing.Point(403, 3);
            this.tb_jiechuchachongku.Name = "tb_jiechuchachongku";
            this.tb_jiechuchachongku.Size = new System.Drawing.Size(195, 23);
            this.tb_jiechuchachongku.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tb_huaming, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel1, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(601, 30);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(305, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "登陆权限";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(5, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "花名";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_huaming
            // 
            this.tb_huaming.Location = new System.Drawing.Point(103, 3);
            this.tb_huaming.Name = "tb_huaming";
            this.tb_huaming.Size = new System.Drawing.Size(194, 23);
            this.tb_huaming.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rb_keyi);
            this.flowLayoutPanel1.Controls.Add(this.rb_bukeyi);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(400, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(201, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // rb_keyi
            // 
            this.rb_keyi.AutoSize = true;
            this.rb_keyi.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb_keyi.Location = new System.Drawing.Point(5, 5);
            this.rb_keyi.Name = "rb_keyi";
            this.rb_keyi.Size = new System.Drawing.Size(50, 21);
            this.rb_keyi.TabIndex = 0;
            this.rb_keyi.TabStop = true;
            this.rb_keyi.Text = "可以";
            this.rb_keyi.UseVisualStyleBackColor = true;
            // 
            // rb_bukeyi
            // 
            this.rb_bukeyi.AutoSize = true;
            this.rb_bukeyi.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb_bukeyi.Location = new System.Drawing.Point(61, 5);
            this.rb_bukeyi.Name = "rb_bukeyi";
            this.rb_bukeyi.Size = new System.Drawing.Size(62, 21);
            this.rb_bukeyi.TabIndex = 1;
            this.rb_bukeyi.TabStop = true;
            this.rb_bukeyi.Text = "不可以";
            this.rb_bukeyi.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_person, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 440);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_baocun, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_guanbi, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 410);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(613, 30);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // WinFormHoutaiguanli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 440);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormHoutaiguanli";
            this.Text = "WinFormHoutaiguanli";
            this.Load += new System.EventHandler(this.WinFormHoutaiguanli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_person)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_person;
        private System.Windows.Forms.Label lbl_baocun;
        private System.Windows.Forms.Label lbl_guanbi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tb_diaoyongguize;
        private System.Windows.Forms.TextBox tb_diaoyongchachongku;
        private System.Windows.Forms.TextBox tb_jiechuguize;
        private System.Windows.Forms.TextBox tb_jiechuchachongku;
        private System.Windows.Forms.TextBox tb_huaming;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rb_keyi;
        private System.Windows.Forms.RadioButton rb_bukeyi;
    }
}