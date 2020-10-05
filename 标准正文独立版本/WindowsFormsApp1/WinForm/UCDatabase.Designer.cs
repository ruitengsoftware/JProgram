namespace Common.WinForm
{
    partial class UCDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDatabase));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_chongfu = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_dbname = new System.Windows.Forms.Label();
            this.pb_delete = new System.Windows.Forms.PictureBox();
            this.pb_left = new System.Windows.Forms.PictureBox();
            this.pb_right = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pb_left, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_right, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(191, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Controls.Add(this.pb_delete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_chongfu, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 30);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(151, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbl_chongfu
            // 
            this.lbl_chongfu.AutoSize = true;
            this.lbl_chongfu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_chongfu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_chongfu.ForeColor = System.Drawing.Color.White;
            this.lbl_chongfu.Location = new System.Drawing.Point(11, 1);
            this.lbl_chongfu.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_chongfu.Name = "lbl_chongfu";
            this.lbl_chongfu.Size = new System.Drawing.Size(99, 28);
            this.lbl_chongfu.TabIndex = 2;
            this.lbl_chongfu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.19868F));
            this.tableLayoutPanel3.Controls.Add(this.lbl_dbname, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(20, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(151, 30);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // lbl_dbname
            // 
            this.lbl_dbname.AutoSize = true;
            this.lbl_dbname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_dbname.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_dbname.ForeColor = System.Drawing.Color.White;
            this.lbl_dbname.Location = new System.Drawing.Point(1, 1);
            this.lbl_dbname.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_dbname.Name = "lbl_dbname";
            this.lbl_dbname.Size = new System.Drawing.Size(149, 28);
            this.lbl_dbname.TabIndex = 1;
            this.lbl_dbname.Text = "label1";
            this.lbl_dbname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_delete
            // 
            this.pb_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_delete.Image = global::WindowsFormsApp1.Properties.Resources.delete3;
            this.pb_delete.Location = new System.Drawing.Point(116, 5);
            this.pb_delete.Margin = new System.Windows.Forms.Padding(5);
            this.pb_delete.Name = "pb_delete";
            this.pb_delete.Size = new System.Drawing.Size(20, 20);
            this.pb_delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_delete.TabIndex = 0;
            this.pb_delete.TabStop = false;
            this.pb_delete.Click += new System.EventHandler(this.Pb_delete_Click);
            this.pb_delete.MouseEnter += new System.EventHandler(this.Pb_delete_MouseEnter);
            this.pb_delete.MouseLeave += new System.EventHandler(this.Pb_delete_MouseLeave);
            // 
            // pb_left
            // 
            this.pb_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_left.Image = ((System.Drawing.Image)(resources.GetObject("pb_left.Image")));
            this.pb_left.Location = new System.Drawing.Point(0, 0);
            this.pb_left.Margin = new System.Windows.Forms.Padding(0);
            this.pb_left.Name = "pb_left";
            this.tableLayoutPanel1.SetRowSpan(this.pb_left, 2);
            this.pb_left.Size = new System.Drawing.Size(20, 60);
            this.pb_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_left.TabIndex = 2;
            this.pb_left.TabStop = false;
            this.pb_left.Click += new System.EventHandler(this.Pb_left_Click);
            // 
            // pb_right
            // 
            this.pb_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_right.Image = global::WindowsFormsApp1.Properties.Resources.rightlv;
            this.pb_right.Location = new System.Drawing.Point(171, 0);
            this.pb_right.Margin = new System.Windows.Forms.Padding(0);
            this.pb_right.Name = "pb_right";
            this.tableLayoutPanel1.SetRowSpan(this.pb_right, 2);
            this.pb_right.Size = new System.Drawing.Size(20, 60);
            this.pb_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_right.TabIndex = 2;
            this.pb_right.TabStop = false;
            this.pb_right.Click += new System.EventHandler(this.Pb_right_Click);
            // 
            // UCDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCDatabase";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(195, 64);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pb_delete;
        public System.Windows.Forms.Label lbl_dbname;
        private System.Windows.Forms.PictureBox pb_left;
        private System.Windows.Forms.PictureBox pb_right;
        public System.Windows.Forms.Label lbl_chongfu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
