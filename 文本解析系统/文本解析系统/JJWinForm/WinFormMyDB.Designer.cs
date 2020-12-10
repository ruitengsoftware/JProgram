namespace 文本解析系统.JJWinForm
{
    partial class WinFormMyDB
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
            this.cbb_leibie = new System.Windows.Forms.ComboBox();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_shanchu = new System.Windows.Forms.Label();
            this.lbl_guanbi = new System.Windows.Forms.Label();
            this.xuanze = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_leibie
            // 
            this.cbb_leibie.FormattingEnabled = true;
            this.cbb_leibie.Items.AddRange(new object[] {
            "全文查重库",
            "正文查重库",
            "标准段查重库",
            "标准句查重库"});
            this.cbb_leibie.Location = new System.Drawing.Point(106, 17);
            this.cbb_leibie.Name = "cbb_leibie";
            this.cbb_leibie.Size = new System.Drawing.Size(389, 25);
            this.cbb_leibie.TabIndex = 0;
            this.cbb_leibie.SelectedIndexChanged += new System.EventHandler(this.cbb_leibie_SelectedIndexChanged);
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xuanze});
            this.dgv_data.Location = new System.Drawing.Point(49, 68);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersVisible = false;
            this.dgv_data.RowTemplate.Height = 23;
            this.dgv_data.Size = new System.Drawing.Size(504, 255);
            this.dgv_data.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "类别";
            // 
            // lbl_shanchu
            // 
            this.lbl_shanchu.AutoSize = true;
            this.lbl_shanchu.BackColor = System.Drawing.Color.Tomato;
            this.lbl_shanchu.ForeColor = System.Drawing.Color.White;
            this.lbl_shanchu.Location = new System.Drawing.Point(152, 340);
            this.lbl_shanchu.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_shanchu.Name = "lbl_shanchu";
            this.lbl_shanchu.Size = new System.Drawing.Size(32, 17);
            this.lbl_shanchu.TabIndex = 3;
            this.lbl_shanchu.Text = "删除";
            this.lbl_shanchu.Click += new System.EventHandler(this.lbl_shanchu_Click);
            // 
            // lbl_guanbi
            // 
            this.lbl_guanbi.AutoSize = true;
            this.lbl_guanbi.BackColor = System.Drawing.Color.Tomato;
            this.lbl_guanbi.ForeColor = System.Drawing.Color.White;
            this.lbl_guanbi.Location = new System.Drawing.Point(342, 340);
            this.lbl_guanbi.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_guanbi.Name = "lbl_guanbi";
            this.lbl_guanbi.Size = new System.Drawing.Size(32, 17);
            this.lbl_guanbi.TabIndex = 3;
            this.lbl_guanbi.Text = "关闭";
            this.lbl_guanbi.Click += new System.EventHandler(this.lbl_guanbi_Click);
            // 
            // xuanze
            // 
            this.xuanze.HeaderText = "选择";
            this.xuanze.Name = "xuanze";
            // 
            // WinFormMyDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(622, 404);
            this.Controls.Add(this.lbl_guanbi);
            this.Controls.Add(this.lbl_shanchu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_data);
            this.Controls.Add(this.cbb_leibie);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormMyDB";
            this.Text = "WinFormMyDB";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_leibie;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_shanchu;
        private System.Windows.Forms.Label lbl_guanbi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn xuanze;
    }
}