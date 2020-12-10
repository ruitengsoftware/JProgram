namespace 文本解析系统.JJWinForm
{
    partial class WinFormSelect
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
            this.xuanze = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_guanbi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xuanze});
            this.dgv_data.Location = new System.Drawing.Point(27, 48);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersVisible = false;
            this.dgv_data.RowTemplate.Height = 23;
            this.dgv_data.Size = new System.Drawing.Size(608, 230);
            this.dgv_data.TabIndex = 0;
            // 
            // xuanze
            // 
            this.xuanze.HeaderText = "选择";
            this.xuanze.Name = "xuanze";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Tomato;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "确定";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_guanbi
            // 
            this.lbl_guanbi.AutoSize = true;
            this.lbl_guanbi.BackColor = System.Drawing.Color.Tomato;
            this.lbl_guanbi.ForeColor = System.Drawing.Color.White;
            this.lbl_guanbi.Location = new System.Drawing.Point(398, 314);
            this.lbl_guanbi.Name = "lbl_guanbi";
            this.lbl_guanbi.Size = new System.Drawing.Size(32, 17);
            this.lbl_guanbi.TabIndex = 1;
            this.lbl_guanbi.Text = "关闭";
            this.lbl_guanbi.Click += new System.EventHandler(this.lbl_guanbi_Click);
            // 
            // WinFormDiaoyongguize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(666, 436);
            this.Controls.Add(this.lbl_guanbi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_data);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormDiaoyongguize";
            this.Text = "WinFormDiaoyongguize";
            this.Load += new System.EventHandler(this.WinFormDiaoyongguize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn xuanze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_guanbi;
    }
}