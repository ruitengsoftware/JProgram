namespace 团队任务台账管理系统.UserControll
{
    partial class UCfujian
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
            this.tlp_fujian = new System.Windows.Forms.TableLayoutPanel();
            this.panel_fujian = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pb_shangchuan = new System.Windows.Forms.PictureBox();
            this.tlp_fujian.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shangchuan)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_fujian
            // 
            this.tlp_fujian.ColumnCount = 2;
            this.tlp_fujian.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_fujian.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp_fujian.Controls.Add(this.panel_fujian, 0, 0);
            this.tlp_fujian.Controls.Add(this.panel2, 1, 0);
            this.tlp_fujian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_fujian.Location = new System.Drawing.Point(0, 0);
            this.tlp_fujian.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_fujian.Name = "tlp_fujian";
            this.tlp_fujian.RowCount = 1;
            this.tlp_fujian.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_fujian.Size = new System.Drawing.Size(680, 349);
            this.tlp_fujian.TabIndex = 6;
            // 
            // panel_fujian
            // 
            this.panel_fujian.AutoScroll = true;
            this.panel_fujian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_fujian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_fujian.Location = new System.Drawing.Point(1, 1);
            this.panel_fujian.Margin = new System.Windows.Forms.Padding(1);
            this.panel_fujian.Name = "panel_fujian";
            this.panel_fujian.Size = new System.Drawing.Size(652, 347);
            this.panel_fujian.TabIndex = 10;
            this.panel_fujian.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel_fujian_ControlAdded);
            this.panel_fujian.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panel_fujian_ControlRemoved);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pb_shangchuan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(654, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(26, 349);
            this.panel2.TabIndex = 11;
            // 
            // pb_shangchuan
            // 
            this.pb_shangchuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_shangchuan.Image = global::团队任务台账管理系统.Properties.Resources.upload1;
            this.pb_shangchuan.Location = new System.Drawing.Point(0, 0);
            this.pb_shangchuan.Name = "pb_shangchuan";
            this.pb_shangchuan.Size = new System.Drawing.Size(26, 25);
            this.pb_shangchuan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_shangchuan.TabIndex = 1;
            this.pb_shangchuan.TabStop = false;
            this.pb_shangchuan.Click += new System.EventHandler(this.pb_shangchuan_Click);
            // 
            // UCfujian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlp_fujian);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCfujian";
            this.Size = new System.Drawing.Size(680, 349);
            this.tlp_fujian.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_shangchuan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlp_fujian;
        public System.Windows.Forms.Panel panel_fujian;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pb_shangchuan;
    }
}
