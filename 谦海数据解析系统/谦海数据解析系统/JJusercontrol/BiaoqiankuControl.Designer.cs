
namespace 谦海数据解析系统.JJusercontrol
{
    partial class BiaoqiankuControl
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_shengcheng = new System.Windows.Forms.Label();
            this.lbl_daochu = new System.Windows.Forms.Label();
            this.lbl_daoru = new System.Windows.Forms.Label();
            this.cb_biaoqianku = new System.Windows.Forms.CheckBox();
            this.panel_biaoqian = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_biaoqian, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 313);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_shengcheng, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_daochu, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_daoru, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cb_biaoqianku, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(707, 36);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbl_shengcheng
            // 
            this.lbl_shengcheng.AutoSize = true;
            this.lbl_shengcheng.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_shengcheng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_shengcheng.ForeColor = System.Drawing.Color.White;
            this.lbl_shengcheng.Location = new System.Drawing.Point(441, 4);
            this.lbl_shengcheng.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_shengcheng.Name = "lbl_shengcheng";
            this.lbl_shengcheng.Size = new System.Drawing.Size(142, 28);
            this.lbl_shengcheng.TabIndex = 0;
            this.lbl_shengcheng.Text = "生成标签库解析表";
            this.lbl_shengcheng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_shengcheng.Click += new System.EventHandler(this.lbl_shengcheng_Click);
            // 
            // lbl_daochu
            // 
            this.lbl_daochu.AutoSize = true;
            this.lbl_daochu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_daochu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_daochu.ForeColor = System.Drawing.Color.White;
            this.lbl_daochu.Location = new System.Drawing.Point(591, 4);
            this.lbl_daochu.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_daochu.Name = "lbl_daochu";
            this.lbl_daochu.Size = new System.Drawing.Size(52, 28);
            this.lbl_daochu.TabIndex = 0;
            this.lbl_daochu.Text = "导出";
            this.lbl_daochu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_daoru
            // 
            this.lbl_daoru.AutoSize = true;
            this.lbl_daoru.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_daoru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_daoru.ForeColor = System.Drawing.Color.White;
            this.lbl_daoru.Location = new System.Drawing.Point(651, 4);
            this.lbl_daoru.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_daoru.Name = "lbl_daoru";
            this.lbl_daoru.Size = new System.Drawing.Size(52, 28);
            this.lbl_daoru.TabIndex = 0;
            this.lbl_daoru.Text = "导入";
            this.lbl_daoru.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_biaoqianku
            // 
            this.cb_biaoqianku.AutoSize = true;
            this.cb_biaoqianku.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_biaoqianku.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_biaoqianku.ForeColor = System.Drawing.Color.White;
            this.cb_biaoqianku.Location = new System.Drawing.Point(10, 4);
            this.cb_biaoqianku.Margin = new System.Windows.Forms.Padding(10, 4, 3, 3);
            this.cb_biaoqianku.Name = "cb_biaoqianku";
            this.cb_biaoqianku.Size = new System.Drawing.Size(424, 29);
            this.cb_biaoqianku.TabIndex = 1;
            this.cb_biaoqianku.Text = "习近平公共信息库标签库";
            this.cb_biaoqianku.UseVisualStyleBackColor = true;
            // 
            // panel_biaoqian
            // 
            this.panel_biaoqian.AutoSize = true;
            this.panel_biaoqian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_biaoqian.Location = new System.Drawing.Point(0, 36);
            this.panel_biaoqian.Margin = new System.Windows.Forms.Padding(0);
            this.panel_biaoqian.Name = "panel_biaoqian";
            this.panel_biaoqian.Size = new System.Drawing.Size(707, 277);
            this.panel_biaoqian.TabIndex = 1;
            // 
            // BiaoqiankuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BiaoqiankuControl";
            this.Size = new System.Drawing.Size(707, 313);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_shengcheng;
        private System.Windows.Forms.Label lbl_daochu;
        private System.Windows.Forms.Label lbl_daoru;
        public System.Windows.Forms.CheckBox cb_biaoqianku;
        private System.Windows.Forms.Panel panel_biaoqian;
    }
}
