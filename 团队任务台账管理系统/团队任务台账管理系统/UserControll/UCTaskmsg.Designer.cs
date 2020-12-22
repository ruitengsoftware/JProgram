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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pb_lishi = new System.Windows.Forms.PictureBox();
            this.lbl_renwuming = new System.Windows.Forms.Label();
            this.lbl_renwuleixing = new System.Windows.Forms.Label();
            this.pb_weidu = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_lishi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_weidu)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.pb_lishi, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_renwuming, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_renwuleixing, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_weidu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(630, 36);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // pb_lishi
            // 
            this.pb_lishi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_lishi.Image = global::团队任务台账管理系统.Properties.Resources.历史1;
            this.pb_lishi.Location = new System.Drawing.Point(595, 5);
            this.pb_lishi.Margin = new System.Windows.Forms.Padding(5);
            this.pb_lishi.Name = "pb_lishi";
            this.pb_lishi.Size = new System.Drawing.Size(30, 26);
            this.pb_lishi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_lishi.TabIndex = 0;
            this.pb_lishi.TabStop = false;
            this.pb_lishi.Visible = false;
            // 
            // lbl_renwuming
            // 
            this.lbl_renwuming.AutoSize = true;
            this.lbl_renwuming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_renwuming.Location = new System.Drawing.Point(31, 1);
            this.lbl_renwuming.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_renwuming.Name = "lbl_renwuming";
            this.lbl_renwuming.Size = new System.Drawing.Size(438, 34);
            this.lbl_renwuming.TabIndex = 1;
            this.lbl_renwuming.Text = "label1";
            this.lbl_renwuming.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_renwuming.Click += new System.EventHandler(this.lbl_renwuming_Click);
            // 
            // lbl_renwuleixing
            // 
            this.lbl_renwuleixing.AutoSize = true;
            this.lbl_renwuleixing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_renwuleixing.Location = new System.Drawing.Point(471, 1);
            this.lbl_renwuleixing.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_renwuleixing.Name = "lbl_renwuleixing";
            this.lbl_renwuleixing.Size = new System.Drawing.Size(118, 34);
            this.lbl_renwuleixing.TabIndex = 2;
            this.lbl_renwuleixing.Text = "label1";
            this.lbl_renwuleixing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_weidu
            // 
            this.pb_weidu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_weidu.Image = global::团队任务台账管理系统.Properties.Resources.redpoint;
            this.pb_weidu.Location = new System.Drawing.Point(0, 0);
            this.pb_weidu.Margin = new System.Windows.Forms.Padding(0);
            this.pb_weidu.Name = "pb_weidu";
            this.pb_weidu.Size = new System.Drawing.Size(30, 36);
            this.pb_weidu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_weidu.TabIndex = 3;
            this.pb_weidu.TabStop = false;
            // 
            // UCTaskmsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCTaskmsg";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(634, 40);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_lishi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_weidu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pb_lishi;
        private System.Windows.Forms.Label lbl_renwuming;
        private System.Windows.Forms.Label lbl_renwuleixing;
        private System.Windows.Forms.PictureBox pb_weidu;
    }
}
