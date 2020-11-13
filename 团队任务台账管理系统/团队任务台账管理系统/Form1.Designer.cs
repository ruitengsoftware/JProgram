namespace 团队任务台账管理系统
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel_my = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_shezhi = new System.Windows.Forms.Button();
            this.btn_yanshou = new System.Windows.Forms.Button();
            this.btn_daiban = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pb_tuichu = new System.Windows.Forms.PictureBox();
            this.pb_touxiang = new System.Windows.Forms.PictureBox();
            this.pb_home = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_tuichu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_touxiang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel1MinSize = 100;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel_my);
            this.splitContainer2.Size = new System.Drawing.Size(794, 464);
            this.splitContainer2.SplitterDistance = 100;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel_my
            // 
            this.panel_my.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_my.Location = new System.Drawing.Point(0, 0);
            this.panel_my.Margin = new System.Windows.Forms.Padding(0);
            this.panel_my.Name = "panel_my";
            this.panel_my.Size = new System.Drawing.Size(693, 464);
            this.panel_my.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_daiban, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_yanshou, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_shezhi, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(100, 464);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_shezhi
            // 
            this.btn_shezhi.Location = new System.Drawing.Point(3, 83);
            this.btn_shezhi.Name = "btn_shezhi";
            this.btn_shezhi.Size = new System.Drawing.Size(94, 34);
            this.btn_shezhi.TabIndex = 0;
            this.btn_shezhi.Text = "用户设置";
            this.btn_shezhi.UseVisualStyleBackColor = true;
            this.btn_shezhi.Click += new System.EventHandler(this.btn_shezhi_Click);
            // 
            // btn_yanshou
            // 
            this.btn_yanshou.Location = new System.Drawing.Point(3, 43);
            this.btn_yanshou.Name = "btn_yanshou";
            this.btn_yanshou.Size = new System.Drawing.Size(94, 34);
            this.btn_yanshou.TabIndex = 0;
            this.btn_yanshou.Text = "我的验收";
            this.btn_yanshou.UseVisualStyleBackColor = true;
            this.btn_yanshou.Click += new System.EventHandler(this.btn_yanshou_Click);
            // 
            // btn_daiban
            // 
            this.btn_daiban.Location = new System.Drawing.Point(3, 3);
            this.btn_daiban.Name = "btn_daiban";
            this.btn_daiban.Size = new System.Drawing.Size(94, 34);
            this.btn_daiban.TabIndex = 0;
            this.btn_daiban.Text = "我的待办";
            this.btn_daiban.UseVisualStyleBackColor = true;
            this.btn_daiban.Click += new System.EventHandler(this.btn_daiban_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pb_home, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pb_touxiang, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_tuichu, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(50, 464);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pb_tuichu
            // 
            this.pb_tuichu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_tuichu.Image = global::团队任务台账管理系统.Properties.Resources.退出;
            this.pb_tuichu.Location = new System.Drawing.Point(3, 83);
            this.pb_tuichu.Name = "pb_tuichu";
            this.pb_tuichu.Size = new System.Drawing.Size(44, 34);
            this.pb_tuichu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_tuichu.TabIndex = 1;
            this.pb_tuichu.TabStop = false;
            this.pb_tuichu.Click += new System.EventHandler(this.pb_tuichu_Click);
            // 
            // pb_touxiang
            // 
            this.pb_touxiang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_touxiang.Image = global::团队任务台账管理系统.Properties.Resources.touxiang;
            this.pb_touxiang.Location = new System.Drawing.Point(7, 7);
            this.pb_touxiang.Margin = new System.Windows.Forms.Padding(7);
            this.pb_touxiang.Name = "pb_touxiang";
            this.pb_touxiang.Size = new System.Drawing.Size(26, 26);
            this.pb_touxiang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_touxiang.TabIndex = 0;
            this.pb_touxiang.TabStop = false;
            this.pb_touxiang.Click += new System.EventHandler(this.pb_touxiang_Click);
            // 
            // pb_home
            // 
            this.pb_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_home.Image = global::团队任务台账管理系统.Properties.Resources.home;
            this.pb_home.Location = new System.Drawing.Point(7, 47);
            this.pb_home.Margin = new System.Windows.Forms.Padding(7);
            this.pb_home.Name = "pb_home";
            this.pb_home.Size = new System.Drawing.Size(26, 26);
            this.pb_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_home.TabIndex = 0;
            this.pb_home.TabStop = false;
            this.pb_home.Click += new System.EventHandler(this.pb_home_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(848, 464);
            this.splitContainer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(848, 464);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "写手任务台账管理系统V1.1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_tuichu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_touxiang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_home)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_daiban;
        private System.Windows.Forms.Button btn_yanshou;
        private System.Windows.Forms.Button btn_shezhi;
        private System.Windows.Forms.Panel panel_my;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pb_home;
        public System.Windows.Forms.PictureBox pb_touxiang;
        private System.Windows.Forms.PictureBox pb_tuichu;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

