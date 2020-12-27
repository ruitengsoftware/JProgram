namespace 查重工具.JJWinForm
{
    partial class WinFormData
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
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.xuhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbb_ku = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flp_page = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_shouye = new System.Windows.Forms.Button();
            this.btn_shangyiye = new System.Windows.Forms.Button();
            this.tb_page = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_xiayiye = new System.Windows.Forms.Button();
            this.btn_weiye = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.flp_page.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xuhao});
            this.dgv_data.Location = new System.Drawing.Point(12, 70);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowTemplate.Height = 23;
            this.dgv_data.Size = new System.Drawing.Size(945, 397);
            this.dgv_data.TabIndex = 3;
            // 
            // xuhao
            // 
            this.xuhao.HeaderText = "序号";
            this.xuhao.Name = "xuhao";
            // 
            // cbb_ku
            // 
            this.cbb_ku.FormattingEnabled = true;
            this.cbb_ku.Location = new System.Drawing.Point(94, 18);
            this.cbb_ku.Name = "cbb_ku";
            this.cbb_ku.Size = new System.Drawing.Size(205, 25);
            this.cbb_ku.TabIndex = 4;
            this.cbb_ku.DropDown += new System.EventHandler(this.cbb_ku_DropDown);
            this.cbb_ku.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择库";
            // 
            // flp_page
            // 
            this.flp_page.Controls.Add(this.btn_shouye);
            this.flp_page.Controls.Add(this.btn_shangyiye);
            this.flp_page.Controls.Add(this.tb_page);
            this.flp_page.Controls.Add(this.label2);
            this.flp_page.Controls.Add(this.btn_xiayiye);
            this.flp_page.Controls.Add(this.btn_weiye);
            this.flp_page.Location = new System.Drawing.Point(13, 483);
            this.flp_page.Name = "flp_page";
            this.flp_page.Size = new System.Drawing.Size(943, 36);
            this.flp_page.TabIndex = 6;
            // 
            // btn_shouye
            // 
            this.btn_shouye.Location = new System.Drawing.Point(3, 3);
            this.btn_shouye.Name = "btn_shouye";
            this.btn_shouye.Size = new System.Drawing.Size(100, 29);
            this.btn_shouye.TabIndex = 4;
            this.btn_shouye.Text = "首页";
            this.btn_shouye.UseVisualStyleBackColor = true;
            this.btn_shouye.Click += new System.EventHandler(this.btn_shouye_Click);
            // 
            // btn_shangyiye
            // 
            this.btn_shangyiye.Location = new System.Drawing.Point(109, 3);
            this.btn_shangyiye.Name = "btn_shangyiye";
            this.btn_shangyiye.Size = new System.Drawing.Size(94, 29);
            this.btn_shangyiye.TabIndex = 0;
            this.btn_shangyiye.Text = "上一页";
            this.btn_shangyiye.UseVisualStyleBackColor = true;
            this.btn_shangyiye.Click += new System.EventHandler(this.btn_shangyiye_Click);
            // 
            // tb_page
            // 
            this.tb_page.Location = new System.Drawing.Point(209, 3);
            this.tb_page.Name = "tb_page";
            this.tb_page.Size = new System.Drawing.Size(85, 23);
            this.tb_page.TabIndex = 1;
            this.tb_page.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_page_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(300, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "共 XX  页";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_xiayiye
            // 
            this.btn_xiayiye.Location = new System.Drawing.Point(366, 3);
            this.btn_xiayiye.Name = "btn_xiayiye";
            this.btn_xiayiye.Size = new System.Drawing.Size(91, 29);
            this.btn_xiayiye.TabIndex = 3;
            this.btn_xiayiye.Text = "下一页";
            this.btn_xiayiye.UseVisualStyleBackColor = true;
            this.btn_xiayiye.Click += new System.EventHandler(this.btn_xiayiye_Click);
            // 
            // btn_weiye
            // 
            this.btn_weiye.Location = new System.Drawing.Point(463, 3);
            this.btn_weiye.Name = "btn_weiye";
            this.btn_weiye.Size = new System.Drawing.Size(100, 29);
            this.btn_weiye.TabIndex = 4;
            this.btn_weiye.Text = "尾页";
            this.btn_weiye.UseVisualStyleBackColor = true;
            this.btn_weiye.Click += new System.EventHandler(this.btn_weiye_Click);
            // 
            // WinFormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(969, 609);
            this.Controls.Add(this.flp_page);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_ku);
            this.Controls.Add(this.dgv_data);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormData";
            this.Text = "WinFormData";
            this.Load += new System.EventHandler(this.WinFormData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.flp_page.ResumeLayout(false);
            this.flp_page.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.ComboBox cbb_ku;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flp_page;
        private System.Windows.Forms.Button btn_shouye;
        private System.Windows.Forms.Button btn_shangyiye;
        private System.Windows.Forms.TextBox tb_page;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_xiayiye;
        private System.Windows.Forms.Button btn_weiye;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuhao;
    }
}