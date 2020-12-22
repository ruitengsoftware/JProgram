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
            this.SuspendLayout();
            // 
            // tb_xindetihui
            // 
            this.tb_xindetihui.Location = new System.Drawing.Point(27, 24);
            this.tb_xindetihui.Multiline = true;
            this.tb_xindetihui.Name = "tb_xindetihui";
            this.tb_xindetihui.Size = new System.Drawing.Size(454, 218);
            this.tb_xindetihui.TabIndex = 0;
            // 
            // lbl_queding
            // 
            this.lbl_queding.Location = new System.Drawing.Point(147, 259);
            this.lbl_queding.Name = "lbl_queding";
            this.lbl_queding.Size = new System.Drawing.Size(92, 33);
            this.lbl_queding.TabIndex = 1;
            this.lbl_queding.Text = "确定销项";
            this.lbl_queding.UseVisualStyleBackColor = true;
            this.lbl_queding.Click += new System.EventHandler(this.lbl_queding_Click);
            // 
            // lbl_guanbi
            // 
            this.lbl_guanbi.Location = new System.Drawing.Point(292, 259);
            this.lbl_guanbi.Name = "lbl_guanbi";
            this.lbl_guanbi.Size = new System.Drawing.Size(92, 33);
            this.lbl_guanbi.TabIndex = 1;
            this.lbl_guanbi.Text = "关闭";
            this.lbl_guanbi.UseVisualStyleBackColor = true;
            this.lbl_guanbi.Click += new System.EventHandler(this.lbl_guanbi_Click);
            // 
            // WinFormXiaoxiang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 297);
            this.Controls.Add(this.lbl_guanbi);
            this.Controls.Add(this.lbl_queding);
            this.Controls.Add(this.tb_xindetihui);
            this.Name = "WinFormXiaoxiang";
            this.Text = "WinFormXiaoxiang";
            this.Load += new System.EventHandler(this.WinFormXiaoxiang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_xindetihui;
        private System.Windows.Forms.Button lbl_queding;
        private System.Windows.Forms.Button lbl_guanbi;
    }
}