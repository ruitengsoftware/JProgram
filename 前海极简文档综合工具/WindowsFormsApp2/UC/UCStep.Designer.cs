namespace WindowsFormsApp2.UC
{
    partial class UCStep
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
            this.pb_right = new System.Windows.Forms.PictureBox();
            this.pb_left = new System.Windows.Forms.PictureBox();
            this.lbl_text = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_right
            // 
            this.pb_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_right.Image = global::WindowsFormsApp2.Properties.Resources.rightenter;
            this.pb_right.Location = new System.Drawing.Point(104, 4);
            this.pb_right.Margin = new System.Windows.Forms.Padding(4);
            this.pb_right.Name = "pb_right";
            this.pb_right.Size = new System.Drawing.Size(12, 21);
            this.pb_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_right.TabIndex = 2;
            this.pb_right.TabStop = false;
            this.pb_right.Click += new System.EventHandler(this.Pb_right_Click);
            // 
            // pb_left
            // 
            this.pb_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_left.Image = global::WindowsFormsApp2.Properties.Resources.leftenter;
            this.pb_left.Location = new System.Drawing.Point(4, 4);
            this.pb_left.Margin = new System.Windows.Forms.Padding(4);
            this.pb_left.Name = "pb_left";
            this.pb_left.Size = new System.Drawing.Size(12, 21);
            this.pb_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_left.TabIndex = 2;
            this.pb_left.TabStop = false;
            this.pb_left.Click += new System.EventHandler(this.Pb_left_Click);
            // 
            // lbl_text
            // 
            this.lbl_text.AutoSize = true;
            this.lbl_text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_text.ForeColor = System.Drawing.Color.Black;
            this.lbl_text.Location = new System.Drawing.Point(21, 1);
            this.lbl_text.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(78, 27);
            this.lbl_text.TabIndex = 1;
            this.lbl_text.Text = "文档生成";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_text.Click += new System.EventHandler(this.lbl_text_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_text, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_left, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_right, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(120, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UCStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCStep";
            this.Size = new System.Drawing.Size(120, 29);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UCStep_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_right;
        private System.Windows.Forms.PictureBox pb_left;
        public System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
