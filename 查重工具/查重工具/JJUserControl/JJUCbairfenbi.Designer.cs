namespace 查重工具.JJUserControl
{
    partial class JJUCbairfenbi
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
            this.tb_baifenbi = new System.Windows.Forms.TextBox();
            this.cb_morenlujing = new System.Windows.Forms.CheckBox();
            this.tb_baocunlujing = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tb_baifenbi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cb_morenlujing, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_baocunlujing, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 31);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tb_baifenbi
            // 
            this.tb_baifenbi.Location = new System.Drawing.Point(3, 4);
            this.tb_baifenbi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_baifenbi.Name = "tb_baifenbi";
            this.tb_baifenbi.Size = new System.Drawing.Size(74, 23);
            this.tb_baifenbi.TabIndex = 0;
            this.tb_baifenbi.TextChanged += new System.EventHandler(this.tb_baifenbi_TextChanged);
            // 
            // cb_morenlujing
            // 
            this.cb_morenlujing.AutoSize = true;
            this.cb_morenlujing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_morenlujing.Location = new System.Drawing.Point(83, 7);
            this.cb_morenlujing.Margin = new System.Windows.Forms.Padding(3, 7, 3, 4);
            this.cb_morenlujing.Name = "cb_morenlujing";
            this.cb_morenlujing.Size = new System.Drawing.Size(84, 20);
            this.cb_morenlujing.TabIndex = 1;
            this.cb_morenlujing.Text = "默认路径";
            this.cb_morenlujing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_morenlujing.UseVisualStyleBackColor = true;
            this.cb_morenlujing.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tb_baocunlujing
            // 
            this.tb_baocunlujing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_baocunlujing.Location = new System.Drawing.Point(173, 4);
            this.tb_baocunlujing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_baocunlujing.Name = "tb_baocunlujing";
            this.tb_baocunlujing.Size = new System.Drawing.Size(368, 23);
            this.tb_baocunlujing.TabIndex = 2;
            this.tb_baocunlujing.TextChanged += new System.EventHandler(this.tb_baocunlujing_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::查重工具.Properties.Resources.delete3;
            this.pictureBox1.Location = new System.Drawing.Point(574, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::查重工具.Properties.Resources.folder1;
            this.pictureBox2.Location = new System.Drawing.Point(544, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // JJUCbairfenbi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JJUCbairfenbi";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(608, 35);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tb_baifenbi;
        private System.Windows.Forms.CheckBox cb_morenlujing;
        private System.Windows.Forms.TextBox tb_baocunlujing;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
