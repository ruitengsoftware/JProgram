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
            this.pb_guanbi = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_chuangjianren = new System.Windows.Forms.Label();
            this.lbl_shijian = new System.Windows.Forms.Label();
            this.lbl_xiazai = new System.Windows.Forms.Label();
            this.pb_shanchu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_guanbi)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shanchu)).BeginInit();
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
            this.lbl_info.Location = new System.Drawing.Point(371, 2);
            this.lbl_info.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(43, 17);
            this.lbl_info.TabIndex = 1;
            this.lbl_info.Text = "label2";
            // 
            // pb_guanbi
            // 
            this.pb_guanbi.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_guanbi.Image = global::团队任务台账管理系统.Properties.Resources.delete3;
            this.pb_guanbi.Location = new System.Drawing.Point(414, 2);
            this.pb_guanbi.Margin = new System.Windows.Forms.Padding(0);
            this.pb_guanbi.Name = "pb_guanbi";
            this.pb_guanbi.Size = new System.Drawing.Size(27, 17);
            this.pb_guanbi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_guanbi.TabIndex = 2;
            this.pb_guanbi.TabStop = false;
            this.pb_guanbi.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lbl_chuangjianren);
            this.panel1.Controls.Add(this.lbl_shijian);
            this.panel1.Controls.Add(this.lbl_xiazai);
            this.panel1.Controls.Add(this.lbl_info);
            this.panel1.Controls.Add(this.pb_guanbi);
            this.panel1.Controls.Add(this.lbl_wenjianming);
            this.panel1.Controls.Add(this.pb_shanchu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(460, 21);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.UCfujianInfo_Paint);
            // 
            // lbl_chuangjianren
            // 
            this.lbl_chuangjianren.AutoSize = true;
            this.lbl_chuangjianren.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_chuangjianren.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl_chuangjianren.Location = new System.Drawing.Point(253, 2);
            this.lbl_chuangjianren.Name = "lbl_chuangjianren";
            this.lbl_chuangjianren.Size = new System.Drawing.Size(43, 17);
            this.lbl_chuangjianren.TabIndex = 5;
            this.lbl_chuangjianren.Text = "label2";
            this.lbl_chuangjianren.Visible = false;
            // 
            // lbl_shijian
            // 
            this.lbl_shijian.AutoSize = true;
            this.lbl_shijian.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_shijian.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl_shijian.Location = new System.Drawing.Point(296, 2);
            this.lbl_shijian.Name = "lbl_shijian";
            this.lbl_shijian.Size = new System.Drawing.Size(43, 17);
            this.lbl_shijian.TabIndex = 4;
            this.lbl_shijian.Text = "label1";
            this.lbl_shijian.Visible = false;
            // 
            // lbl_xiazai
            // 
            this.lbl_xiazai.AutoSize = true;
            this.lbl_xiazai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_xiazai.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_xiazai.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_xiazai.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_xiazai.Location = new System.Drawing.Point(339, 2);
            this.lbl_xiazai.Name = "lbl_xiazai";
            this.lbl_xiazai.Size = new System.Drawing.Size(32, 17);
            this.lbl_xiazai.TabIndex = 3;
            this.lbl_xiazai.Text = "下载";
            this.lbl_xiazai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_xiazai.Visible = false;
            this.lbl_xiazai.Click += new System.EventHandler(this.lbl_xiazai_Click);
            // 
            // pb_shanchu
            // 
            this.pb_shanchu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_shanchu.Image = global::团队任务台账管理系统.Properties.Resources.delete1;
            this.pb_shanchu.Location = new System.Drawing.Point(441, 2);
            this.pb_shanchu.Name = "pb_shanchu";
            this.pb_shanchu.Size = new System.Drawing.Size(17, 17);
            this.pb_shanchu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_shanchu.TabIndex = 6;
            this.pb_shanchu.TabStop = false;
            this.pb_shanchu.Visible = false;
            this.pb_shanchu.Click += new System.EventHandler(this.pb_shanchu_Click);
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
            this.Size = new System.Drawing.Size(466, 27);
            this.Load += new System.EventHandler(this.UCfujianInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_guanbi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shanchu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_wenjianming;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.PictureBox pb_guanbi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_chuangjianren;
        private System.Windows.Forms.Label lbl_shijian;
        private System.Windows.Forms.Label lbl_xiazai;
        private System.Windows.Forms.PictureBox pb_shanchu;
    }
}
