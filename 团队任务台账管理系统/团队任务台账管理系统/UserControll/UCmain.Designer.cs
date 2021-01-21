namespace 团队任务台账管理系统.UserControll
{
    partial class UCmain
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
            this.cms_right = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_daibairenwu = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_kw = new System.Windows.Forms.TextBox();
            this.pb_search = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_daibanrenwu = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gb_tongzhigonggao = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_tongzhi = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_gongzuoqingdan = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_dingzi = new System.Windows.Forms.PictureBox();
            this.lbl_gongzuoqingdan = new System.Windows.Forms.Label();
            this.ucpagetongzhi = new 团队任务台账管理系统.UserControll.UCpage();
            this.ucpagegongzuoqingdan = new 团队任务台账管理系统.UserControll.UCpage();
            this.ucpagedaiban = new 团队任务台账管理系统.UserControll.UCpage();
            this.cms_right.SuspendLayout();
            this.gb_daibairenwu.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gb_tongzhigonggao.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dingzi)).BeginInit();
            this.SuspendLayout();
            // 
            // cms_right
            // 
            this.cms_right.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.完成ToolStripMenuItem});
            this.cms_right.Name = "cms_right";
            this.cms_right.Size = new System.Drawing.Size(101, 70);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 完成ToolStripMenuItem
            // 
            this.完成ToolStripMenuItem.Name = "完成ToolStripMenuItem";
            this.完成ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.完成ToolStripMenuItem.Text = "完成";
            this.完成ToolStripMenuItem.Click += new System.EventHandler(this.完成ToolStripMenuItem_Click);
            // 
            // gb_daibairenwu
            // 
            this.gb_daibairenwu.Controls.Add(this.tableLayoutPanel13);
            this.gb_daibairenwu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_daibairenwu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.gb_daibairenwu.Location = new System.Drawing.Point(3, 421);
            this.gb_daibairenwu.Name = "gb_daibairenwu";
            this.gb_daibairenwu.Size = new System.Drawing.Size(848, 204);
            this.gb_daibairenwu.TabIndex = 2;
            this.gb_daibairenwu.TabStop = false;
            this.gb_daibairenwu.Text = "待办任务";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.tableLayoutPanel14, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.panel_daibanrenwu, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.ucpagedaiban, 0, 2);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 3;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(842, 182);
            this.tableLayoutPanel13.TabIndex = 0;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 4;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.tb_kw, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.pb_search, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(842, 30);
            this.tableLayoutPanel14.TabIndex = 3;
            // 
            // tb_kw
            // 
            this.tb_kw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_kw.Location = new System.Drawing.Point(84, 4);
            this.tb_kw.Margin = new System.Windows.Forms.Padding(4);
            this.tb_kw.Name = "tb_kw";
            this.tb_kw.Size = new System.Drawing.Size(192, 23);
            this.tb_kw.TabIndex = 0;
            this.tb_kw.TextChanged += new System.EventHandler(this.tb_kw_TextChanged);
            // 
            // pb_search
            // 
            this.pb_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_search.Image = global::团队任务台账管理系统.Properties.Resources.fangdajing;
            this.pb_search.Location = new System.Drawing.Point(283, 3);
            this.pb_search.Name = "pb_search";
            this.pb_search.Size = new System.Drawing.Size(29, 24);
            this.pb_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_search.TabIndex = 1;
            this.pb_search.TabStop = false;
            this.pb_search.Click += new System.EventHandler(this.pb_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "关键词";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_daibanrenwu
            // 
            this.panel_daibanrenwu.AutoScroll = true;
            this.panel_daibanrenwu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_daibanrenwu.Location = new System.Drawing.Point(0, 30);
            this.panel_daibanrenwu.Margin = new System.Windows.Forms.Padding(0);
            this.panel_daibanrenwu.Name = "panel_daibanrenwu";
            this.panel_daibanrenwu.Size = new System.Drawing.Size(842, 120);
            this.panel_daibanrenwu.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gb_daibairenwu, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 628);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.gb_tongzhigonggao, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 209);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(854, 209);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // gb_tongzhigonggao
            // 
            this.gb_tongzhigonggao.Controls.Add(this.tableLayoutPanel3);
            this.gb_tongzhigonggao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_tongzhigonggao.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.gb_tongzhigonggao.Location = new System.Drawing.Point(3, 3);
            this.gb_tongzhigonggao.Name = "gb_tongzhigonggao";
            this.gb_tongzhigonggao.Size = new System.Drawing.Size(848, 203);
            this.gb_tongzhigonggao.TabIndex = 0;
            this.gb_tongzhigonggao.TabStop = false;
            this.gb_tongzhigonggao.Text = "通知公告";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel_tongzhi, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ucpagetongzhi, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(842, 181);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // panel_tongzhi
            // 
            this.panel_tongzhi.AutoScroll = true;
            this.panel_tongzhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tongzhi.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.panel_tongzhi.Location = new System.Drawing.Point(0, 0);
            this.panel_tongzhi.Margin = new System.Windows.Forms.Padding(0);
            this.panel_tongzhi.Name = "panel_tongzhi";
            this.panel_tongzhi.Size = new System.Drawing.Size(842, 149);
            this.panel_tongzhi.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.panel_gongzuoqingdan, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.ucpagegongzuoqingdan, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(854, 209);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // panel_gongzuoqingdan
            // 
            this.panel_gongzuoqingdan.AutoScroll = true;
            this.panel_gongzuoqingdan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_gongzuoqingdan.Location = new System.Drawing.Point(0, 30);
            this.panel_gongzuoqingdan.Margin = new System.Windows.Forms.Padding(0);
            this.panel_gongzuoqingdan.Name = "panel_gongzuoqingdan";
            this.panel_gongzuoqingdan.Size = new System.Drawing.Size(854, 147);
            this.panel_gongzuoqingdan.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pb_dingzi);
            this.panel1.Controls.Add(this.lbl_gongzuoqingdan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.panel1.Size = new System.Drawing.Size(854, 30);
            this.panel1.TabIndex = 4;
            // 
            // pb_dingzi
            // 
            this.pb_dingzi.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_dingzi.Image = global::团队任务台账管理系统.Properties.Resources.dingzi;
            this.pb_dingzi.Location = new System.Drawing.Point(64, 8);
            this.pb_dingzi.Margin = new System.Windows.Forms.Padding(0);
            this.pb_dingzi.Name = "pb_dingzi";
            this.pb_dingzi.Size = new System.Drawing.Size(44, 22);
            this.pb_dingzi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_dingzi.TabIndex = 0;
            this.pb_dingzi.TabStop = false;
            this.pb_dingzi.Click += new System.EventHandler(this.pb_dingzi_Click);
            // 
            // lbl_gongzuoqingdan
            // 
            this.lbl_gongzuoqingdan.AutoSize = true;
            this.lbl_gongzuoqingdan.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_gongzuoqingdan.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_gongzuoqingdan.Location = new System.Drawing.Point(8, 8);
            this.lbl_gongzuoqingdan.Margin = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.lbl_gongzuoqingdan.Name = "lbl_gongzuoqingdan";
            this.lbl_gongzuoqingdan.Size = new System.Drawing.Size(56, 17);
            this.lbl_gongzuoqingdan.TabIndex = 0;
            this.lbl_gongzuoqingdan.Text = "工作清单";
            this.lbl_gongzuoqingdan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucpagetongzhi
            // 
            this.ucpagetongzhi.BackColor = System.Drawing.Color.White;
            this.ucpagetongzhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucpagetongzhi.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucpagetongzhi.Location = new System.Drawing.Point(0, 149);
            this.ucpagetongzhi.Margin = new System.Windows.Forms.Padding(0);
            this.ucpagetongzhi.Name = "ucpagetongzhi";
            this.ucpagetongzhi.Padding = new System.Windows.Forms.Padding(2);
            this.ucpagetongzhi.Size = new System.Drawing.Size(842, 32);
            this.ucpagetongzhi.TabIndex = 4;
            // 
            // ucpagegongzuoqingdan
            // 
            this.ucpagegongzuoqingdan.BackColor = System.Drawing.Color.White;
            this.ucpagegongzuoqingdan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucpagegongzuoqingdan.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucpagegongzuoqingdan.Location = new System.Drawing.Point(0, 177);
            this.ucpagegongzuoqingdan.Margin = new System.Windows.Forms.Padding(0);
            this.ucpagegongzuoqingdan.Name = "ucpagegongzuoqingdan";
            this.ucpagegongzuoqingdan.Padding = new System.Windows.Forms.Padding(2);
            this.ucpagegongzuoqingdan.Size = new System.Drawing.Size(854, 32);
            this.ucpagegongzuoqingdan.TabIndex = 5;
            // 
            // ucpagedaiban
            // 
            this.ucpagedaiban.BackColor = System.Drawing.Color.White;
            this.ucpagedaiban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucpagedaiban.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucpagedaiban.Location = new System.Drawing.Point(0, 150);
            this.ucpagedaiban.Margin = new System.Windows.Forms.Padding(0);
            this.ucpagedaiban.Name = "ucpagedaiban";
            this.ucpagedaiban.Padding = new System.Windows.Forms.Padding(2);
            this.ucpagedaiban.Size = new System.Drawing.Size(842, 32);
            this.ucpagedaiban.TabIndex = 5;
            // 
            // UCmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCmain";
            this.Size = new System.Drawing.Size(854, 628);
            this.Load += new System.EventHandler(this.UCmain_Load);
            this.cms_right.ResumeLayout(false);
            this.gb_daibairenwu.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gb_tongzhigonggao.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dingzi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cms_right;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 完成ToolStripMenuItem;
        private System.Windows.Forms.GroupBox gb_daibairenwu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TextBox tb_kw;
        private System.Windows.Forms.PictureBox pb_search;
        private System.Windows.Forms.Panel panel_daibanrenwu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel_tongzhi;
        private System.Windows.Forms.GroupBox gb_tongzhigonggao;
        private UCpage ucpagedaiban;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private UCpage ucpagetongzhi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel_gongzuoqingdan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pb_dingzi;
        private System.Windows.Forms.Label lbl_gongzuoqingdan;
        private UCpage ucpagegongzuoqingdan;
        private System.Windows.Forms.Label label1;
    }
}
