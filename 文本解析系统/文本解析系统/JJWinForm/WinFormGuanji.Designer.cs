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
            this.btn_guanji = new System.Windows.Forms.Button();
            this.btn_quxiao = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "此电脑正在关闭……";
            // 
            // btn_guanji
            // 
            this.btn_guanji.Location = new System.Drawing.Point(84, 84);
            this.btn_guanji.Name = "btn_guanji";
            this.btn_guanji.Size = new System.Drawing.Size(89, 36);
            this.btn_guanji.TabIndex = 1;
            this.btn_guanji.Text = "关机（10s）";
            this.btn_guanji.UseVisualStyleBackColor = true;
            this.btn_guanji.Click += new System.EventHandler(this.btn_guanji_Click);
            // 
            // btn_quxiao
            // 
            this.btn_quxiao.Location = new System.Drawing.Point(247, 84);
            this.btn_quxiao.Name = "btn_quxiao";
            this.btn_quxiao.Size = new System.Drawing.Size(89, 36);
            this.btn_quxiao.TabIndex = 1;
            this.btn_quxiao.Text = "取消";
            this.btn_quxiao.UseVisualStyleBackColor = true;
            this.btn_quxiao.Click += new System.EventHandler(this.btn_quxiao_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WinFormGuanji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 152);
            this.Controls.Add(this.btn_quxiao);
            this.Controls.Add(this.btn_guanji);
            this.Controls.Add(this.label1);
            this.Name = "WinFormGuanji";
            this.Text = "关机";
            this.Load += new System.EventHandler(this.WinFormGuanji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_guanji;
        private System.Windows.Forms.Button btn_quxiao;
        private System.Windows.Forms.Timer timer1;
    }
}