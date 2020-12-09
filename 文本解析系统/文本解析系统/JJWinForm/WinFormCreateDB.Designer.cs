namespace 文本解析系统.JJWinForm
{
    partial class WinFormCreateDB
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
            this.tb_dbname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_leixing = new System.Windows.Forms.ComboBox();
            this.btn_query = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pb_error = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_error)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "查重库名称";
            // 
            // tb_dbname
            // 
            this.tb_dbname.Location = new System.Drawing.Point(140, 20);
            this.tb_dbname.Name = "tb_dbname";
            this.tb_dbname.Size = new System.Drawing.Size(204, 23);
            this.tb_dbname.TabIndex = 1;
            this.tb_dbname.Leave += new System.EventHandler(this.tb_dbname_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "查重库类别选择";
            // 
            // cbb_leixing
            // 
            this.cbb_leixing.FormattingEnabled = true;
            this.cbb_leixing.Items.AddRange(new object[] {
            "全文查重库",
            "正文查重库",
            "标准段查重库",
            "标准句查重库"});
            this.cbb_leixing.Location = new System.Drawing.Point(140, 61);
            this.cbb_leixing.Name = "cbb_leixing";
            this.cbb_leixing.Size = new System.Drawing.Size(204, 25);
            this.cbb_leixing.TabIndex = 3;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(88, 120);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(89, 27);
            this.btn_query.TabIndex = 4;
            this.btn_query.Text = "确定";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(286, 120);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(90, 27);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // pb_error
            // 
            this.pb_error.Image = global::文本解析系统.Properties.Resources.delete3;
            this.pb_error.Location = new System.Drawing.Point(355, 21);
            this.pb_error.Name = "pb_error";
            this.pb_error.Size = new System.Drawing.Size(21, 22);
            this.pb_error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_error.TabIndex = 5;
            this.pb_error.TabStop = false;
            this.pb_error.Visible = false;
            // 
            // WinFormCreateDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 171);
            this.Controls.Add(this.pb_error);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.cbb_leixing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_dbname);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormCreateDB";
            this.Text = "WinFormCreateDB";
            ((System.ComponentModel.ISupportInitialize)(this.pb_error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_dbname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_leixing;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.PictureBox pb_error;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}