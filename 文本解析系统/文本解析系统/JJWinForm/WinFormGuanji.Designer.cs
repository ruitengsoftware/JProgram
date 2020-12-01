namespace 文本解析系统.JJWinForm
{
    partial class WinFormGuanji
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_guanji = new System.Windows.Forms.Label();
            this.lbl_quxiao = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "此电脑正在关闭……";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_guanji
            // 
            this.lbl_guanji.AutoSize = true;
            this.lbl_guanji.BackColor = System.Drawing.Color.Tomato;
            this.lbl_guanji.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_guanji.ForeColor = System.Drawing.Color.White;
            this.lbl_guanji.Location = new System.Drawing.Point(10, 10);
            this.lbl_guanji.Margin = new System.Windows.Forms.Padding(10);
            this.lbl_guanji.Name = "lbl_guanji";
            this.lbl_guanji.Size = new System.Drawing.Size(112, 30);
            this.lbl_guanji.TabIndex = 2;
            this.lbl_guanji.Text = "关机（10s）";
            this.lbl_guanji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_guanji.Click += new System.EventHandler(this.btn_guanji_Click);
            this.lbl_guanji.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_quxiao_Paint);
            this.lbl_guanji.MouseEnter += new System.EventHandler(this.lbl_quxiao_MouseEnter);
            this.lbl_guanji.MouseLeave += new System.EventHandler(this.lbl_quxiao_MouseLeave);
            // 
            // lbl_quxiao
            // 
            this.lbl_quxiao.AutoSize = true;
            this.lbl_quxiao.BackColor = System.Drawing.Color.Tomato;
            this.lbl_quxiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_quxiao.ForeColor = System.Drawing.Color.White;
            this.lbl_quxiao.Location = new System.Drawing.Point(142, 10);
            this.lbl_quxiao.Margin = new System.Windows.Forms.Padding(10);
            this.lbl_quxiao.Name = "lbl_quxiao";
            this.lbl_quxiao.Size = new System.Drawing.Size(113, 30);
            this.lbl_quxiao.TabIndex = 3;
            this.lbl_quxiao.Text = "取消";
            this.lbl_quxiao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_quxiao.Click += new System.EventHandler(this.btn_quxiao_Click);
            this.lbl_quxiao.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_quxiao_Paint);
            this.lbl_quxiao.MouseEnter += new System.EventHandler(this.lbl_quxiao_MouseEnter);
            this.lbl_quxiao.MouseLeave += new System.EventHandler(this.lbl_quxiao_MouseLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(265, 100);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_quxiao, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_guanji, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(265, 50);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // WinFormGuanji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(305, 140);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "WinFormGuanji";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关机";
            this.Load += new System.EventHandler(this.WinFormGuanji_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_guanji;
        private System.Windows.Forms.Label lbl_quxiao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}