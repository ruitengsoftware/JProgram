namespace WindowsFormsApp2.UC
{
    partial class UCFenlei
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_task = new System.Windows.Forms.DataGridView();
            this.xuhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wenjianjiamingcheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shuliang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_addtask = new System.Windows.Forms.Label();
            this.lbl_start = new System.Windows.Forms.Label();
            this.lbl_stop = new System.Windows.Forms.Label();
            this.lbl_clear = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_shuliang = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_moren = new System.Windows.Forms.CheckBox();
            this.tb_wenjianjia = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_jianqiedao = new System.Windows.Forms.TextBox();
            this.pb_rizhi = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.cbb_geshi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_baocun = new System.Windows.Forms.Label();
            this.lbl_shanchu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_task)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_rizhi)).BeginInit();
            this.tableLayoutPanel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(916, 686);
            this.splitContainer1.SplitterDistance = 302;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_task);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 680);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "我的任务";
            // 
            // dgv_task
            // 
            this.dgv_task.AllowUserToAddRows = false;
            this.dgv_task.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_task.BackgroundColor = System.Drawing.Color.White;
            this.dgv_task.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_task.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_task.ColumnHeadersHeight = 25;
            this.dgv_task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xuhao,
            this.wenjianjiamingcheng,
            this.shuliang,
            this.状态});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_task.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_task.EnableHeadersVisualStyles = false;
            this.dgv_task.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv_task.Location = new System.Drawing.Point(3, 19);
            this.dgv_task.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_task.Name = "dgv_task";
            this.dgv_task.RowHeadersVisible = false;
            this.dgv_task.RowTemplate.Height = 23;
            this.dgv_task.Size = new System.Drawing.Size(290, 658);
            this.dgv_task.TabIndex = 0;
            // 
            // xuhao
            // 
            this.xuhao.HeaderText = "序号";
            this.xuhao.Name = "xuhao";
            // 
            // wenjianjiamingcheng
            // 
            this.wenjianjiamingcheng.HeaderText = "文件夹名称";
            this.wenjianjiamingcheng.Name = "wenjianjiamingcheng";
            // 
            // shuliang
            // 
            this.shuliang.HeaderText = "数量";
            this.shuliang.Name = "shuliang";
            // 
            // 状态
            // 
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(610, 686);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lbl_addtask, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_start, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_stop, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_clear, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(610, 30);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lbl_addtask
            // 
            this.lbl_addtask.AutoSize = true;
            this.lbl_addtask.BackColor = System.Drawing.Color.Tomato;
            this.lbl_addtask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_addtask.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_addtask.ForeColor = System.Drawing.Color.White;
            this.lbl_addtask.Location = new System.Drawing.Point(3, 3);
            this.lbl_addtask.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_addtask.Name = "lbl_addtask";
            this.lbl_addtask.Size = new System.Drawing.Size(74, 24);
            this.lbl_addtask.TabIndex = 0;
            this.lbl_addtask.Text = "添加任务";
            this.lbl_addtask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_addtask.Click += new System.EventHandler(this.Lbl_addtask_Click);
            this.lbl_addtask.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_baocun_Paint);
            this.lbl_addtask.MouseEnter += new System.EventHandler(this.Lbl_baocun_MouseEnter);
            this.lbl_addtask.MouseLeave += new System.EventHandler(this.Lbl_baocun_MouseLeave);
            // 
            // lbl_start
            // 
            this.lbl_start.AutoSize = true;
            this.lbl_start.BackColor = System.Drawing.Color.Tomato;
            this.lbl_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_start.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_start.ForeColor = System.Drawing.Color.White;
            this.lbl_start.Location = new System.Drawing.Point(83, 3);
            this.lbl_start.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_start.Name = "lbl_start";
            this.lbl_start.Size = new System.Drawing.Size(74, 24);
            this.lbl_start.TabIndex = 0;
            this.lbl_start.Text = "全部开始";
            this.lbl_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_start.Click += new System.EventHandler(this.Lbl_start_Click);
            this.lbl_start.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_baocun_Paint);
            this.lbl_start.MouseEnter += new System.EventHandler(this.Lbl_baocun_MouseEnter);
            this.lbl_start.MouseLeave += new System.EventHandler(this.Lbl_baocun_MouseLeave);
            // 
            // lbl_stop
            // 
            this.lbl_stop.AutoSize = true;
            this.lbl_stop.BackColor = System.Drawing.Color.Tomato;
            this.lbl_stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_stop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_stop.ForeColor = System.Drawing.Color.White;
            this.lbl_stop.Location = new System.Drawing.Point(163, 3);
            this.lbl_stop.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_stop.Name = "lbl_stop";
            this.lbl_stop.Size = new System.Drawing.Size(74, 24);
            this.lbl_stop.TabIndex = 0;
            this.lbl_stop.Text = "全部停止";
            this.lbl_stop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_stop.Click += new System.EventHandler(this.Lbl_stop_Click);
            this.lbl_stop.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_baocun_Paint);
            this.lbl_stop.MouseEnter += new System.EventHandler(this.Lbl_baocun_MouseEnter);
            this.lbl_stop.MouseLeave += new System.EventHandler(this.Lbl_baocun_MouseLeave);
            // 
            // lbl_clear
            // 
            this.lbl_clear.AutoSize = true;
            this.lbl_clear.BackColor = System.Drawing.Color.Tomato;
            this.lbl_clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_clear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_clear.ForeColor = System.Drawing.Color.White;
            this.lbl_clear.Location = new System.Drawing.Point(243, 3);
            this.lbl_clear.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_clear.Name = "lbl_clear";
            this.lbl_clear.Size = new System.Drawing.Size(74, 24);
            this.lbl_clear.TabIndex = 0;
            this.lbl_clear.Text = "清空任务";
            this.lbl_clear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_clear.Click += new System.EventHandler(this.Lbl_clear_Click);
            this.lbl_clear.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_baocun_Paint);
            this.lbl_clear.MouseEnter += new System.EventHandler(this.Lbl_baocun_MouseEnter);
            this.lbl_clear.MouseLeave += new System.EventHandler(this.Lbl_baocun_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 656);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel14);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.splitContainer2.Size = new System.Drawing.Size(610, 656);
            this.splitContainer2.SplitterDistance = 544;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.tableLayoutPanel18, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 2;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(544, 656);
            this.tableLayoutPanel14.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 620);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoScroll = true;
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(538, 620);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel8);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(532, 142);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "分类处理设置";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 4;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(526, 120);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tb_shuliang, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(526, 40);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "分类标准";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_shuliang
            // 
            this.tb_shuliang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_shuliang.Location = new System.Drawing.Point(83, 8);
            this.tb_shuliang.Name = "tb_shuliang";
            this.tb_shuliang.Size = new System.Drawing.Size(54, 23);
            this.tb_shuliang.TabIndex = 1;
            this.tb_shuliang.Text = "10000";
            this.tb_shuliang.Leave += new System.EventHandler(this.Tb_shuliang_Leave);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.cb_moren, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.tb_wenjianjia, 2, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(526, 40);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "文件夹命名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_moren
            // 
            this.cb_moren.AutoSize = true;
            this.cb_moren.Location = new System.Drawing.Point(83, 11);
            this.cb_moren.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cb_moren.Name = "cb_moren";
            this.cb_moren.Size = new System.Drawing.Size(99, 21);
            this.cb_moren.TabIndex = 1;
            this.cb_moren.Text = "默认名命方式";
            this.cb_moren.UseVisualStyleBackColor = true;
            this.cb_moren.CheckedChanged += new System.EventHandler(this.Cb_zhengwen_CheckedChanged);
            // 
            // tb_wenjianjia
            // 
            this.tb_wenjianjia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_wenjianjia.Enabled = false;
            this.tb_wenjianjia.Location = new System.Drawing.Point(193, 8);
            this.tb_wenjianjia.Name = "tb_wenjianjia";
            this.tb_wenjianjia.Size = new System.Drawing.Size(330, 23);
            this.tb_wenjianjia.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_jianqiedao, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pb_rizhi, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.SlateGray;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 8);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 24);
            this.label18.TabIndex = 0;
            this.label18.Text = "剪切到";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_jianqiedao
            // 
            this.tb_jianqiedao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_jianqiedao.Location = new System.Drawing.Point(83, 9);
            this.tb_jianqiedao.Margin = new System.Windows.Forms.Padding(3, 4, 0, 3);
            this.tb_jianqiedao.Name = "tb_jianqiedao";
            this.tb_jianqiedao.Size = new System.Drawing.Size(413, 23);
            this.tb_jianqiedao.TabIndex = 1;
            // 
            // pb_rizhi
            // 
            this.pb_rizhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_rizhi.Image = global::WindowsFormsApp2.Properties.Resources.folderlv;
            this.pb_rizhi.Location = new System.Drawing.Point(500, 9);
            this.pb_rizhi.Margin = new System.Windows.Forms.Padding(4);
            this.pb_rizhi.Name = "pb_rizhi";
            this.pb_rizhi.Size = new System.Drawing.Size(22, 22);
            this.pb_rizhi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_rizhi.TabIndex = 2;
            this.pb_rizhi.TabStop = false;
            this.pb_rizhi.Click += new System.EventHandler(this.Pb_rizhi_Click);
            this.pb_rizhi.MouseEnter += new System.EventHandler(this.Pb_rizhi_MouseEnter);
            this.pb_rizhi.MouseLeave += new System.EventHandler(this.Pb_rizhi_MouseLeave);
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 4;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel18.Controls.Add(this.cbb_geshi, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.lbl_baocun, 2, 0);
            this.tableLayoutPanel18.Controls.Add(this.lbl_shanchu, 3, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(544, 30);
            this.tableLayoutPanel18.TabIndex = 2;
            // 
            // cbb_geshi
            // 
            this.cbb_geshi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbb_geshi.FormattingEnabled = true;
            this.cbb_geshi.Location = new System.Drawing.Point(83, 3);
            this.cbb_geshi.Name = "cbb_geshi";
            this.cbb_geshi.Size = new System.Drawing.Size(338, 25);
            this.cbb_geshi.TabIndex = 0;
            this.cbb_geshi.DropDown += new System.EventHandler(this.cbb_geshi_DropDown);
            this.cbb_geshi.SelectedIndexChanged += new System.EventHandler(this.Cbb_geshi_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "选择格式";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_baocun
            // 
            this.lbl_baocun.AutoSize = true;
            this.lbl_baocun.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_baocun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_baocun.ForeColor = System.Drawing.Color.White;
            this.lbl_baocun.Location = new System.Drawing.Point(427, 3);
            this.lbl_baocun.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_baocun.Name = "lbl_baocun";
            this.lbl_baocun.Size = new System.Drawing.Size(54, 24);
            this.lbl_baocun.TabIndex = 1;
            this.lbl_baocun.Text = "保  存";
            this.lbl_baocun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_baocun.Click += new System.EventHandler(this.Lbl_baocun_Click);
            this.lbl_baocun.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_baocun_Paint);
            this.lbl_baocun.MouseEnter += new System.EventHandler(this.Lbl_baocun_MouseEnter);
            this.lbl_baocun.MouseLeave += new System.EventHandler(this.Lbl_baocun_MouseLeave);
            // 
            // lbl_shanchu
            // 
            this.lbl_shanchu.AutoSize = true;
            this.lbl_shanchu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_shanchu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_shanchu.ForeColor = System.Drawing.Color.White;
            this.lbl_shanchu.Location = new System.Drawing.Point(487, 3);
            this.lbl_shanchu.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_shanchu.Name = "lbl_shanchu";
            this.lbl_shanchu.Size = new System.Drawing.Size(54, 24);
            this.lbl_shanchu.TabIndex = 1;
            this.lbl_shanchu.Text = "删  除";
            this.lbl_shanchu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_shanchu.Click += new System.EventHandler(this.Lbl_shanchu_Click);
            this.lbl_shanchu.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_baocun_Paint);
            this.lbl_shanchu.MouseEnter += new System.EventHandler(this.Lbl_baocun_MouseEnter);
            this.lbl_shanchu.MouseLeave += new System.EventHandler(this.Lbl_baocun_MouseLeave);
            // 
            // UCFenlei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCFenlei";
            this.Size = new System.Drawing.Size(916, 686);
            this.Load += new System.EventHandler(this.UCFenlei_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_task)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_rizhi)).EndInit();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_task;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_addtask;
        private System.Windows.Forms.Label lbl_start;
        private System.Windows.Forms.Label lbl_stop;
        private System.Windows.Forms.Label lbl_clear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.ComboBox cbb_geshi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_baocun;
        private System.Windows.Forms.Label lbl_shanchu;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn wenjianjiamingcheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn shuliang;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_shuliang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_moren;
        private System.Windows.Forms.TextBox tb_wenjianjia;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_jianqiedao;
        private System.Windows.Forms.PictureBox pb_rizhi;
    }
}
