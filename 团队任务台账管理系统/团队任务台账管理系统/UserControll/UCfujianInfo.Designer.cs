namespace 团队任务台账管理系统.UserControll
{
    partial class UCfujianInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_wenjianming = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_wenjianming
            // 
            this.lbl_wenjianming.AutoSize = true;
            this.lbl_wenjianming.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_wenjianming.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl_wenjianming.Location = new System.Drawing.Point(2, 2);
            this.lbl_wenjianming.Name = "lbl_wenjianming";
            this.lbl_wenjianming.Size = new System.Drawing.Size(43, 17);
            this.lbl_wenjianming.TabIndex = 0;
            this.lbl_wenjianming.Text = "label1";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_info.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl_info.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_info.Location = new System.Drawing.Point(189, 2);
            this.lbl_info.Margin = new System.Windows.Forms.Padding(1, 10, 1, 1);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(43, 17);
            this.lbl_info.TabIndex = 1;
            this.lbl_info.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::团队任务台账管理系统.Properties.Resources.delete3;
            this.pictureBox1.Location = new System.Drawing.Point(232, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lbl_info);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbl_wenjianming);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(261, 21);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.UCfujianInfo_Paint);
            // 
            // UCfujianInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCfujianInfo";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(267, 27);
            this.Load += new System.EventHandler(this.UCfujianInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_wenjianming;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
