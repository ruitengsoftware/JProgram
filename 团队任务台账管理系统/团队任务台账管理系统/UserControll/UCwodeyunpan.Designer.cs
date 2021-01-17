namespace 团队任务台账管理系统.UserControll
{
    partial class UCwodeyunpan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_gongxiang = new System.Windows.Forms.Label();
            this.lbl_wodeshangchuan = new System.Windows.Forms.Label();
            this.panel_fujian = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pb_shangchuan = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_kw = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shangchuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_fujian, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(790, 628);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 50);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lbl_gongxiang, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_wodeshangchuan, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(790, 50);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lbl_gongxiang
            // 
            this.lbl_gongxiang.AutoSize = true;
            this.lbl_gongxiang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_gongxiang.ForeColor = System.Drawing.Color.White;
            this.lbl_gongxiang.Location = new System.Drawing.Point(0, 0);
            this.lbl_gongxiang.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_gongxiang.Name = "lbl_gongxiang";
            this.lbl_gongxiang.Size = new System.Drawing.Size(395, 50);
            this.lbl_gongxiang.TabIndex = 0;
            this.lbl_gongxiang.Text = "共享文件";
            this.lbl_gongxiang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_gongxiang.Click += new System.EventHandler(this.lbl_gongxiang_Click);
            // 
            // lbl_wodeshangchuan
            // 
            this.lbl_wodeshangchuan.AutoSize = true;
            this.lbl_wodeshangchuan.BackColor = System.Drawing.Color.White;
            this.lbl_wodeshangchuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_wodeshangchuan.Location = new System.Drawing.Point(395, 0);
            this.lbl_wodeshangchuan.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_wodeshangchuan.Name = "lbl_wodeshangchuan";
            this.lbl_wodeshangchuan.Size = new System.Drawing.Size(395, 50);
            this.lbl_wodeshangchuan.TabIndex = 0;
            this.lbl_wodeshangchuan.Text = "我的上传";
            this.lbl_wodeshangchuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_wodeshangchuan.Click += new System.EventHandler(this.lbl_wodeshangchuan_Click);
            // 
            // panel_fujian
            // 
            this.panel_fujian.BackColor = System.Drawing.Color.White;
            this.panel_fujian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_fujian.Location = new System.Drawing.Point(0, 85);
            this.panel_fujian.Margin = new System.Windows.Forms.Padding(0);
            this.panel_fujian.Name = "panel_fujian";
            this.panel_fujian.Size = new System.Drawing.Size(790, 543);
            this.panel_fujian.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pb_shangchuan);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.tb_kw);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 35);
            this.panel2.TabIndex = 4;
            // 
            // pb_shangchuan
            // 
            this.pb_shangchuan.Image = global::团队任务台账管理系统.Properties.Resources.upload1;
            this.pb_shangchuan.Location = new System.Drawing.Point(376, 5);
            this.pb_shangchuan.Name = "pb_shangchuan";
            this.pb_shangchuan.Size = new System.Drawing.Size(29, 26);
            this.pb_shangchuan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_shangchuan.TabIndex = 0;
            this.pb_shangchuan.TabStop = false;
            this.pb_shangchuan.Click += new System.EventHandler(this.pb_shangchuan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::团队任务台账管理系统.Properties.Resources.fangdajing;
            this.pictureBox1.Location = new System.Drawing.Point(350, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tb_kw
            // 
            this.tb_kw.Location = new System.Drawing.Point(6, 6);
            this.tb_kw.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.tb_kw.Name = "tb_kw";
            this.tb_kw.Size = new System.Drawing.Size(369, 23);
            this.tb_kw.TabIndex = 0;
            // 
            // UCwodeyunpan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCwodeyunpan";
            this.Size = new System.Drawing.Size(790, 628);
            this.Load += new System.EventHandler(this.UCwodeyunpan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shangchuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_gongxiang;
        private System.Windows.Forms.Label lbl_wodeshangchuan;
        private System.Windows.Forms.Panel panel_fujian;
        private System.Windows.Forms.TextBox tb_kw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pb_shangchuan;
    }
}
