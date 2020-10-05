namespace WindowsFormsApp1.UC
{
    partial class UCTask
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
            this.lbl_filename = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_jindu = new System.Windows.Forms.Label();
            this.lbl_chongfulv = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_filename, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(376, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_filename.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_filename.Location = new System.Drawing.Point(2, 2);
            this.lbl_filename.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(372, 46);
            this.lbl_filename.TabIndex = 0;
            this.lbl_filename.Text = "label1";
            this.lbl_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_jindu, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_chongfulv, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(376, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lbl_jindu
            // 
            this.lbl_jindu.AutoSize = true;
            this.lbl_jindu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_jindu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_jindu.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_jindu.Location = new System.Drawing.Point(2, 2);
            this.lbl_jindu.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_jindu.Name = "lbl_jindu";
            this.lbl_jindu.Size = new System.Drawing.Size(96, 30);
            this.lbl_jindu.TabIndex = 0;
            this.lbl_jindu.Text = "进度:";
            this.lbl_jindu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_chongfulv
            // 
            this.lbl_chongfulv.AutoSize = true;
            this.lbl_chongfulv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_chongfulv.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_chongfulv.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_chongfulv.Location = new System.Drawing.Point(102, 2);
            this.lbl_chongfulv.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_chongfulv.Name = "lbl_chongfulv";
            this.lbl_chongfulv.Size = new System.Drawing.Size(272, 30);
            this.lbl_chongfulv.TabIndex = 0;
            this.lbl_chongfulv.Text = "重复率:";
            this.lbl_chongfulv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCTask";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(396, 104);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_jindu;
        public System.Windows.Forms.Label lbl_chongfulv;
    }
}
