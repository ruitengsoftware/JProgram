namespace 团队任务台账管理系统.UserControll
{
    partial class UCTaskmsg
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
            this.lbl_renwuming = new System.Windows.Forms.Label();
            this.lbl_renwuleixing = new System.Windows.Forms.Label();
            this.pb_weidu = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_shixian = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_weidu)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_renwuming
            // 
            this.lbl_renwuming.AutoSize = true;
            this.lbl_renwuming.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_renwuming.Location = new System.Drawing.Point(67, 5);
            this.lbl_renwuming.Margin = new System.Windows.Forms.Padding(1, 10, 1, 1);
            this.lbl_renwuming.Name = "lbl_renwuming";
            this.lbl_renwuming.Size = new System.Drawing.Size(32, 17);
            this.lbl_renwuming.TabIndex = 1;
            this.lbl_renwuming.Text = "名称";
            this.lbl_renwuming.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_renwuming.Click += new System.EventHandler(this.lbl_renwuming_Click);
            // 
            // lbl_renwuleixing
            // 
            this.lbl_renwuleixing.AutoSize = true;
            this.lbl_renwuleixing.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_renwuleixing.Location = new System.Drawing.Point(35, 5);
            this.lbl_renwuleixing.Margin = new System.Windows.Forms.Padding(1, 10, 1, 1);
            this.lbl_renwuleixing.Name = "lbl_renwuleixing";
            this.lbl_renwuleixing.Size = new System.Drawing.Size(32, 17);
            this.lbl_renwuleixing.TabIndex = 2;
            this.lbl_renwuleixing.Text = "类型";
            this.lbl_renwuleixing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_renwuleixing.Click += new System.EventHandler(this.lbl_renwuleixing_Click);
            // 
            // pb_weidu
            // 
            this.pb_weidu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_weidu.Image = global::团队任务台账管理系统.Properties.Resources.redpoint;
            this.pb_weidu.Location = new System.Drawing.Point(5, 5);
            this.pb_weidu.Margin = new System.Windows.Forms.Padding(0);
            this.pb_weidu.Name = "pb_weidu";
            this.pb_weidu.Size = new System.Drawing.Size(30, 17);
            this.pb_weidu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_weidu.TabIndex = 3;
            this.pb_weidu.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_shixian);
            this.panel1.Controls.Add(this.lbl_renwuming);
            this.panel1.Controls.Add(this.lbl_renwuleixing);
            this.panel1.Controls.Add(this.pb_weidu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(494, 27);
            this.panel1.TabIndex = 1;
            // 
            // lbl_shixian
            // 
            this.lbl_shixian.AutoSize = true;
            this.lbl_shixian.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_shixian.Location = new System.Drawing.Point(99, 5);
            this.lbl_shixian.Margin = new System.Windows.Forms.Padding(1, 10, 1, 1);
            this.lbl_shixian.Name = "lbl_shixian";
            this.lbl_shixian.Size = new System.Drawing.Size(32, 17);
            this.lbl_shixian.TabIndex = 4;
            this.lbl_shixian.Text = "时间";
            this.lbl_shixian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_shixian.Click += new System.EventHandler(this.lbl_shixian_Click);
            // 
            // UCTaskmsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCTaskmsg";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(498, 31);
            ((System.ComponentModel.ISupportInitialize)(this.pb_weidu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_renwuming;
        private System.Windows.Forms.Label lbl_renwuleixing;
        private System.Windows.Forms.PictureBox pb_weidu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_shixian;
    }
}
