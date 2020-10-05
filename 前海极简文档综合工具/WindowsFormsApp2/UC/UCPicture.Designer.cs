namespace WindowsFormsApp2.UC
{
    partial class UCPicture
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_name = new System.Windows.Forms.Label();
            this.pb_xuanze = new System.Windows.Forms.PictureBox();
            this.pb_tupian = new System.Windows.Forms.PictureBox();
            this.cms_right = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_xuanze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_tupian)).BeginInit();
            this.cms_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pb_xuanze);
            this.panel1.Controls.Add(this.pb_tupian);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 171);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_name, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 141);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(186, 30);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_name.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_name.ForeColor = System.Drawing.Color.White;
            this.lbl_name.Location = new System.Drawing.Point(0, 0);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(186, 30);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "label1";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_xuanze
            // 
            this.pb_xuanze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_xuanze.BackColor = System.Drawing.Color.Transparent;
            this.pb_xuanze.Image = global::WindowsFormsApp2.Properties.Resources.圆圈;
            this.pb_xuanze.Location = new System.Drawing.Point(153, 3);
            this.pb_xuanze.Name = "pb_xuanze";
            this.pb_xuanze.Size = new System.Drawing.Size(30, 30);
            this.pb_xuanze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_xuanze.TabIndex = 4;
            this.pb_xuanze.TabStop = false;
            this.pb_xuanze.Click += new System.EventHandler(this.Pb_xuanze_Click);
            // 
            // pb_tupian
            // 
            this.pb_tupian.BackColor = System.Drawing.Color.White;
            this.pb_tupian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_tupian.Location = new System.Drawing.Point(0, 0);
            this.pb_tupian.Name = "pb_tupian";
            this.pb_tupian.Size = new System.Drawing.Size(186, 141);
            this.pb_tupian.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_tupian.TabIndex = 3;
            this.pb_tupian.TabStop = false;
            this.pb_tupian.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Pb_tupian_MouseClick);
            // 
            // cms_right
            // 
            this.cms_right.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cms_right.Name = "cms_right";
            this.cms_right.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // UCPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCPicture";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(190, 175);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_xuanze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_tupian)).EndInit();
            this.cms_right.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pb_xuanze;
        private System.Windows.Forms.PictureBox pb_tupian;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ContextMenuStrip cms_right;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}
