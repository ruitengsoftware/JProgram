namespace WindowsFormsApp2.UC
{
    partial class UCchuli
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
            this.pb_left = new System.Windows.Forms.PictureBox();
            this.pb_right = new System.Windows.Forms.PictureBox();
            this.pb_delete = new System.Windows.Forms.PictureBox();
            this.lbl_buzhou = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.pb_left, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_right, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_delete, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_buzhou, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(299, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pb_left
            // 
            this.pb_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_left.Image = global::WindowsFormsApp2.Properties.Resources.leftenter;
            this.pb_left.Location = new System.Drawing.Point(3, 3);
            this.pb_left.Name = "pb_left";
            this.pb_left.Size = new System.Drawing.Size(24, 24);
            this.pb_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_left.TabIndex = 0;
            this.pb_left.TabStop = false;
            this.pb_left.Click += new System.EventHandler(this.Pb_left_Click);
            // 
            // pb_right
            // 
            this.pb_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_right.Image = global::WindowsFormsApp2.Properties.Resources.rightenter;
            this.pb_right.Location = new System.Drawing.Point(242, 3);
            this.pb_right.Name = "pb_right";
            this.pb_right.Size = new System.Drawing.Size(24, 24);
            this.pb_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_right.TabIndex = 0;
            this.pb_right.TabStop = false;
            this.pb_right.Click += new System.EventHandler(this.Pb_right_Click);
            // 
            // pb_delete
            // 
            this.pb_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_delete.Image = global::WindowsFormsApp2.Properties.Resources.delete3;
            this.pb_delete.Location = new System.Drawing.Point(272, 3);
            this.pb_delete.Name = "pb_delete";
            this.pb_delete.Size = new System.Drawing.Size(24, 24);
            this.pb_delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_delete.TabIndex = 0;
            this.pb_delete.TabStop = false;
            this.pb_delete.Click += new System.EventHandler(this.Pb_delete_Click);
            this.pb_delete.MouseEnter += new System.EventHandler(this.Pb_delete_MouseEnter);
            this.pb_delete.MouseLeave += new System.EventHandler(this.Pb_delete_MouseLeave);
            // 
            // lbl_buzhou
            // 
            this.lbl_buzhou.AutoSize = true;
            this.lbl_buzhou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_buzhou.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_buzhou.Location = new System.Drawing.Point(31, 1);
            this.lbl_buzhou.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_buzhou.Name = "lbl_buzhou";
            this.lbl_buzhou.Size = new System.Drawing.Size(207, 28);
            this.lbl_buzhou.TabIndex = 1;
            this.lbl_buzhou.Text = "XXXX";
            this.lbl_buzhou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_buzhou.Click += new System.EventHandler(this.Lbl_buzhou_Click);
            this.lbl_buzhou.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_buzhou_Paint);
            // 
            // UCchuli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCchuli";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(303, 34);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pb_left;
        private System.Windows.Forms.PictureBox pb_right;
        private System.Windows.Forms.PictureBox pb_delete;
        public System.Windows.Forms.Label lbl_buzhou;
    }
}
