namespace Common.WinForm
{
    partial class WinFromEditTable
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_queding = new System.Windows.Forms.Label();
            this.lbl_guanbi = new System.Windows.Forms.Label();
            this.tb_biaoming = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_oldname = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_queding, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_guanbi, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tb_biaoming, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_oldname, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 86);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "新建表名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_queding
            // 
            this.lbl_queding.AutoSize = true;
            this.lbl_queding.BackColor = System.Drawing.Color.Tomato;
            this.lbl_queding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_queding.ForeColor = System.Drawing.Color.White;
            this.lbl_queding.Location = new System.Drawing.Point(284, 46);
            this.lbl_queding.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_queding.Name = "lbl_queding";
            this.lbl_queding.Size = new System.Drawing.Size(54, 24);
            this.lbl_queding.TabIndex = 0;
            this.lbl_queding.Text = "确  定";
            this.lbl_queding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_queding.Click += new System.EventHandler(this.Lbl_queding_Click);
            this.lbl_queding.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_queding_Paint);
            this.lbl_queding.MouseEnter += new System.EventHandler(this.Lbl_queding_MouseEnter);
            this.lbl_queding.MouseLeave += new System.EventHandler(this.Lbl_queding_MouseLeave);
            // 
            // lbl_guanbi
            // 
            this.lbl_guanbi.AutoSize = true;
            this.lbl_guanbi.BackColor = System.Drawing.Color.Tomato;
            this.lbl_guanbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_guanbi.ForeColor = System.Drawing.Color.White;
            this.lbl_guanbi.Location = new System.Drawing.Point(344, 46);
            this.lbl_guanbi.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_guanbi.Name = "lbl_guanbi";
            this.lbl_guanbi.Size = new System.Drawing.Size(54, 24);
            this.lbl_guanbi.TabIndex = 0;
            this.lbl_guanbi.Text = "关  闭";
            this.lbl_guanbi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_guanbi.Click += new System.EventHandler(this.Lbl_guanbi_Click);
            this.lbl_guanbi.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_queding_Paint);
            this.lbl_guanbi.MouseEnter += new System.EventHandler(this.Lbl_queding_MouseEnter);
            this.lbl_guanbi.MouseLeave += new System.EventHandler(this.Lbl_queding_MouseLeave);
            // 
            // tb_biaoming
            // 
            this.tb_biaoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_biaoming.Location = new System.Drawing.Point(84, 47);
            this.tb_biaoming.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tb_biaoming.Name = "tb_biaoming";
            this.tb_biaoming.Size = new System.Drawing.Size(194, 23);
            this.tb_biaoming.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前表名：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_oldname
            // 
            this.tb_oldname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_oldname.Location = new System.Drawing.Point(84, 17);
            this.tb_oldname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tb_oldname.Name = "tb_oldname";
            this.tb_oldname.Size = new System.Drawing.Size(194, 23);
            this.tb_oldname.TabIndex = 1;
            // 
            // WinFromEditTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 86);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFromEditTable";
            this.Text = "WinFromEditTable";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_queding;
        private System.Windows.Forms.Label lbl_guanbi;
        private System.Windows.Forms.TextBox tb_biaoming;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_oldname;
    }
}