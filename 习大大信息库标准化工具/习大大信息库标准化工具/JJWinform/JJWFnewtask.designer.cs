namespace 习大大信息库标准化工具.JJWinform
{
    partial class JJWFnewtask
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_queding = new System.Windows.Forms.Label();
            this.lbl_closing = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_folder = new System.Windows.Forms.TextBox();
            this.pb_folder = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_jiexigeshi = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 53);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 230);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_queding, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_closing, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 190);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(350, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbl_queding
            // 
            this.lbl_queding.AutoSize = true;
            this.lbl_queding.BackColor = System.Drawing.Color.Tomato;
            this.lbl_queding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_queding.ForeColor = System.Drawing.Color.White;
            this.lbl_queding.Location = new System.Drawing.Point(30, 6);
            this.lbl_queding.Margin = new System.Windows.Forms.Padding(30, 6, 30, 6);
            this.lbl_queding.Name = "lbl_queding";
            this.lbl_queding.Size = new System.Drawing.Size(115, 28);
            this.lbl_queding.TabIndex = 0;
            this.lbl_queding.Text = "确    定";
            this.lbl_queding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_queding.Click += new System.EventHandler(this.btn_query_Click);
            this.lbl_queding.Paint += new System.Windows.Forms.PaintEventHandler(this.label3_Paint);
            this.lbl_queding.MouseEnter += new System.EventHandler(this.lbl_queding_MouseEnter);
            this.lbl_queding.MouseLeave += new System.EventHandler(this.lbl_queding_MouseLeave);
            // 
            // lbl_closing
            // 
            this.lbl_closing.AutoSize = true;
            this.lbl_closing.BackColor = System.Drawing.Color.Tomato;
            this.lbl_closing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_closing.ForeColor = System.Drawing.Color.White;
            this.lbl_closing.Location = new System.Drawing.Point(205, 6);
            this.lbl_closing.Margin = new System.Windows.Forms.Padding(30, 6, 30, 6);
            this.lbl_closing.Name = "lbl_closing";
            this.lbl_closing.Size = new System.Drawing.Size(115, 28);
            this.lbl_closing.TabIndex = 0;
            this.lbl_closing.Text = "关    闭";
            this.lbl_closing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_closing.Click += new System.EventHandler(this.btn_close_Click);
            this.lbl_closing.Paint += new System.Windows.Forms.PaintEventHandler(this.label3_Paint);
            this.lbl_closing.MouseEnter += new System.EventHandler(this.lbl_queding_MouseEnter);
            this.lbl_closing.MouseLeave += new System.EventHandler(this.lbl_queding_MouseLeave);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tb_folder, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.pb_folder, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(350, 120);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标文件夹";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_folder
            // 
            this.tb_folder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_folder.Location = new System.Drawing.Point(100, 8);
            this.tb_folder.Margin = new System.Windows.Forms.Padding(0, 8, 0, 3);
            this.tb_folder.Multiline = true;
            this.tb_folder.Name = "tb_folder";
            this.tb_folder.Size = new System.Drawing.Size(210, 109);
            this.tb_folder.TabIndex = 1;
            // 
            // pb_folder
            // 
            this.pb_folder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_folder.Location = new System.Drawing.Point(318, 10);
            this.pb_folder.Margin = new System.Windows.Forms.Padding(8, 10, 8, 90);
            this.pb_folder.Name = "pb_folder";
            this.pb_folder.Size = new System.Drawing.Size(24, 20);
            this.pb_folder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_folder.TabIndex = 2;
            this.pb_folder.TabStop = false;
            this.pb_folder.Click += new System.EventHandler(this.pb_folder_Click);
            this.pb_folder.MouseEnter += new System.EventHandler(this.label3_MouseEnter);
            this.pb_folder.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbb_jiexigeshi, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 120);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(350, 40);
            this.tableLayoutPanel4.TabIndex = 1;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件名格式";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbb_jiexigeshi
            // 
            this.cbb_jiexigeshi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbb_jiexigeshi.FormattingEnabled = true;
            this.cbb_jiexigeshi.Location = new System.Drawing.Point(100, 7);
            this.cbb_jiexigeshi.Margin = new System.Windows.Forms.Padding(0, 7, 0, 3);
            this.cbb_jiexigeshi.Name = "cbb_jiexigeshi";
            this.cbb_jiexigeshi.Size = new System.Drawing.Size(210, 25);
            this.cbb_jiexigeshi.TabIndex = 4;
            this.cbb_jiexigeshi.DropDown += new System.EventHandler(this.cbb_jiexigeshi_DropDown);
            this.cbb_jiexigeshi.SelectedIndexChanged += new System.EventHandler(this.cbb_jiexigeshi_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(391, 337);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // JJWFnewtask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(391, 337);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JJWFnewtask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建任务";
            this.Load += new System.EventHandler(this.WinFormNewTask_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_queding;
        private System.Windows.Forms.Label lbl_closing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_folder;
        private System.Windows.Forms.PictureBox pb_folder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_jiexigeshi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}