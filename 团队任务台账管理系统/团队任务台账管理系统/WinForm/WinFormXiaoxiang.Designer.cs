namespace 团队任务台账管理系统.WinForm
{
    partial class WinFormXiaoxiang
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
            this.tb_xindetihui = new System.Windows.Forms.TextBox();
            this.lbl_queding = new System.Windows.Forms.Button();
            this.lbl_guanbi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_xindetihui
            // 
            this.tb_xindetihui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_xindetihui.Location = new System.Drawing.Point(3, 20);
            this.tb_xindetihui.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_xindetihui.Multiline = true;
            this.tb_xindetihui.Name = "tb_xindetihui";
            this.tb_xindetihui.Size = new System.Drawing.Size(422, 221);
            this.tb_xindetihui.TabIndex = 0;
            // 
            // lbl_queding
            // 
            this.lbl_queding.Location = new System.Drawing.Point(140, 4);
            this.lbl_queding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_queding.Name = "lbl_queding";
            this.lbl_queding.Size = new System.Drawing.Size(74, 27);
            this.lbl_queding.TabIndex = 1;
            this.lbl_queding.Text = "确定销项";
            this.lbl_queding.UseVisualStyleBackColor = true;
            this.lbl_queding.Click += new System.EventHandler(this.lbl_queding_Click);
            // 
            // lbl_guanbi
            // 
            this.lbl_guanbi.Location = new System.Drawing.Point(220, 4);
            this.lbl_guanbi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_guanbi.Name = "lbl_guanbi";
            this.lbl_guanbi.Size = new System.Drawing.Size(74, 27);
            this.lbl_guanbi.TabIndex = 1;
            this.lbl_guanbi.Text = "关闭";
            this.lbl_guanbi.UseVisualStyleBackColor = true;
            this.lbl_guanbi.Click += new System.EventHandler(this.lbl_guanbi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_xindetihui);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(428, 245);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "经验教训";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 288);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_queding, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_guanbi, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 253);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(434, 35);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // WinFormXiaoxiang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 288);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormXiaoxiang";
            this.Text = "销项";
            this.Load += new System.EventHandler(this.WinFormXiaoxiang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_xindetihui;
        private System.Windows.Forms.Button lbl_queding;
        private System.Windows.Forms.Button lbl_guanbi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}