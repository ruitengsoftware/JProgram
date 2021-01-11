namespace 团队任务台账管理系统.UserControll
{
    partial class UCMessage
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
            this.lbl_xiangxian = new System.Windows.Forms.Label();
            this.lbl_mingcheng = new System.Windows.Forms.Label();
            this.lbl_wanchengshijian = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_leixing = new System.Windows.Forms.Label();
            this.pb_xiaoxiang = new System.Windows.Forms.PictureBox();
            this.pb_shanchu = new System.Windows.Forms.PictureBox();
            this.pb_point = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_xiaoxiang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shanchu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_point)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_xiangxian
            // 
            this.lbl_xiangxian.AutoSize = true;
            this.lbl_xiangxian.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_xiangxian.Location = new System.Drawing.Point(47, 1);
            this.lbl_xiangxian.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_xiangxian.Name = "lbl_xiangxian";
            this.lbl_xiangxian.Size = new System.Drawing.Size(43, 17);
            this.lbl_xiangxian.TabIndex = 0;
            this.lbl_xiangxian.Text = "label1";
            this.lbl_xiangxian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_mingcheng
            // 
            this.lbl_mingcheng.AutoSize = true;
            this.lbl_mingcheng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_mingcheng.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_mingcheng.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_mingcheng.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_mingcheng.Location = new System.Drawing.Point(90, 1);
            this.lbl_mingcheng.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_mingcheng.Name = "lbl_mingcheng";
            this.lbl_mingcheng.Size = new System.Drawing.Size(43, 17);
            this.lbl_mingcheng.TabIndex = 0;
            this.lbl_mingcheng.Text = "label1";
            this.lbl_mingcheng.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_mingcheng.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_wanchengshijian
            // 
            this.lbl_wanchengshijian.AutoEllipsis = true;
            this.lbl_wanchengshijian.AutoSize = true;
            this.lbl_wanchengshijian.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_wanchengshijian.Location = new System.Drawing.Point(153, 1);
            this.lbl_wanchengshijian.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_wanchengshijian.Name = "lbl_wanchengshijian";
            this.lbl_wanchengshijian.Size = new System.Drawing.Size(43, 17);
            this.lbl_wanchengshijian.TabIndex = 0;
            this.lbl_wanchengshijian.Text = "label1";
            this.lbl_wanchengshijian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pb_xiaoxiang);
            this.panel1.Controls.Add(this.pb_shanchu);
            this.panel1.Controls.Add(this.lbl_wanchengshijian);
            this.panel1.Controls.Add(this.pb_point);
            this.panel1.Controls.Add(this.lbl_mingcheng);
            this.panel1.Controls.Add(this.lbl_xiangxian);
            this.panel1.Controls.Add(this.lbl_leixing);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(542, 20);
            this.panel1.TabIndex = 1;
            // 
            // lbl_leixing
            // 
            this.lbl_leixing.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_leixing.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_leixing.Location = new System.Drawing.Point(1, 1);
            this.lbl_leixing.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_leixing.Name = "lbl_leixing";
            this.lbl_leixing.Size = new System.Drawing.Size(46, 18);
            this.lbl_leixing.TabIndex = 4;
            this.lbl_leixing.Text = "类型";
            // 
            // pb_xiaoxiang
            // 
            this.pb_xiaoxiang.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_xiaoxiang.Image = global::团队任务台账管理系统.Properties.Resources.xiaoxiang;
            this.pb_xiaoxiang.Location = new System.Drawing.Point(225, 1);
            this.pb_xiaoxiang.Name = "pb_xiaoxiang";
            this.pb_xiaoxiang.Size = new System.Drawing.Size(29, 18);
            this.pb_xiaoxiang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_xiaoxiang.TabIndex = 2;
            this.pb_xiaoxiang.TabStop = false;
            this.pb_xiaoxiang.Click += new System.EventHandler(this.lbl_xiaoxiang_Click);
            // 
            // pb_shanchu
            // 
            this.pb_shanchu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_shanchu.Image = global::团队任务台账管理系统.Properties.Resources.shanchu3;
            this.pb_shanchu.Location = new System.Drawing.Point(196, 1);
            this.pb_shanchu.Name = "pb_shanchu";
            this.pb_shanchu.Size = new System.Drawing.Size(29, 18);
            this.pb_shanchu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_shanchu.TabIndex = 2;
            this.pb_shanchu.TabStop = false;
            this.pb_shanchu.Click += new System.EventHandler(this.lbl_shanchu_Click);
            // 
            // pb_point
            // 
            this.pb_point.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_point.Location = new System.Drawing.Point(133, 1);
            this.pb_point.Name = "pb_point";
            this.pb_point.Size = new System.Drawing.Size(20, 18);
            this.pb_point.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_point.TabIndex = 3;
            this.pb_point.TabStop = false;
            // 
            // UCMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCMessage";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(546, 24);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_xiaoxiang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shanchu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_point)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_xiangxian;
        private System.Windows.Forms.Label lbl_mingcheng;
        private System.Windows.Forms.Label lbl_wanchengshijian;
        private System.Windows.Forms.PictureBox pb_shanchu;
        private System.Windows.Forms.PictureBox pb_xiaoxiang;
        private System.Windows.Forms.PictureBox pb_point;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbl_leixing;
    }
}
