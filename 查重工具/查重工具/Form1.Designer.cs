namespace 查重工具
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_task = new System.Windows.Forms.DataGridView();
            this.xuhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wenjianming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geshi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhuangtai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chongfulv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_tianjiarenwu = new System.Windows.Forms.Button();
            this.btn_kaishi = new System.Windows.Forms.Button();
            this.btn_qingkong = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbb_geshimingcheng = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_baifenbi = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_zhengwenchongfulujing = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_quanwenchachong = new System.Windows.Forms.CheckBox();
            this.cb_zhengwenchachong = new System.Windows.Forms.CheckBox();
            this.cb_biaozhunjuchachong = new System.Windows.Forms.CheckBox();
            this.cb_biaozhunduanchachong = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cb_quanwenruku = new System.Windows.Forms.CheckBox();
            this.cb_biaozhunjuruku = new System.Windows.Forms.CheckBox();
            this.cb_zhengwenruku = new System.Windows.Forms.CheckBox();
            this.cb_biaozhunduanruku = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_chachongku = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_tingzhi = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.pb_folder = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_adddb = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_task)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_adddb)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgv_task, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.156309F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.84369F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(306, 531);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dgv_task
            // 
            this.dgv_task.AllowUserToAddRows = false;
            this.dgv_task.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xuhao,
            this.wenjianming,
            this.geshi,
            this.zhuangtai,
            this.chongfulv});
            this.dgv_task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_task.Location = new System.Drawing.Point(3, 41);
            this.dgv_task.Name = "dgv_task";
            this.dgv_task.RowHeadersVisible = false;
            this.dgv_task.RowTemplate.Height = 23;
            this.dgv_task.Size = new System.Drawing.Size(300, 487);
            this.dgv_task.TabIndex = 1;
            // 
            // xuhao
            // 
            this.xuhao.HeaderText = "序号";
            this.xuhao.Name = "xuhao";
            // 
            // wenjianming
            // 
            this.wenjianming.HeaderText = "文件名";
            this.wenjianming.Name = "wenjianming";
            // 
            // geshi
            // 
            this.geshi.HeaderText = "格式";
            this.geshi.Name = "geshi";
            // 
            // zhuangtai
            // 
            this.zhuangtai.HeaderText = "状态";
            this.zhuangtai.Name = "zhuangtai";
            // 
            // chongfulv
            // 
            this.chongfulv.HeaderText = "重复率";
            this.chongfulv.Name = "chongfulv";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.btn_tianjiarenwu, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_kaishi, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_qingkong, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_tingzhi, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(300, 32);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btn_tianjiarenwu
            // 
            this.btn_tianjiarenwu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tianjiarenwu.Location = new System.Drawing.Point(3, 3);
            this.btn_tianjiarenwu.Name = "btn_tianjiarenwu";
            this.btn_tianjiarenwu.Size = new System.Drawing.Size(69, 26);
            this.btn_tianjiarenwu.TabIndex = 0;
            this.btn_tianjiarenwu.Text = "添加任务";
            this.btn_tianjiarenwu.UseVisualStyleBackColor = true;
            this.btn_tianjiarenwu.Click += new System.EventHandler(this.btn_tianjiarenwu_Click);
            // 
            // btn_kaishi
            // 
            this.btn_kaishi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_kaishi.Location = new System.Drawing.Point(153, 3);
            this.btn_kaishi.Name = "btn_kaishi";
            this.btn_kaishi.Size = new System.Drawing.Size(69, 26);
            this.btn_kaishi.TabIndex = 12;
            this.btn_kaishi.Text = "开始";
            this.btn_kaishi.UseVisualStyleBackColor = true;
            this.btn_kaishi.Click += new System.EventHandler(this.btn_kaishi_Click);
            // 
            // btn_qingkong
            // 
            this.btn_qingkong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_qingkong.Location = new System.Drawing.Point(78, 3);
            this.btn_qingkong.Name = "btn_qingkong";
            this.btn_qingkong.Size = new System.Drawing.Size(69, 26);
            this.btn_qingkong.TabIndex = 0;
            this.btn_qingkong.Text = "清空任务";
            this.btn_qingkong.UseVisualStyleBackColor = true;
            this.btn_qingkong.Click += new System.EventHandler(this.btn_qingkong_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox1, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.groupBox3, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(610, 531);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.Controls.Add(this.button3, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbb_geshimingcheng, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(610, 30);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(533, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 24);
            this.button3.TabIndex = 10;
            this.button3.Text = "删除格式";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(453, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 24);
            this.button2.TabIndex = 10;
            this.button2.Text = "保存格式";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbb_geshimingcheng
            // 
            this.cbb_geshimingcheng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbb_geshimingcheng.FormattingEnabled = true;
            this.cbb_geshimingcheng.Location = new System.Drawing.Point(83, 3);
            this.cbb_geshimingcheng.Name = "cbb_geshimingcheng";
            this.cbb_geshimingcheng.Size = new System.Drawing.Size(364, 25);
            this.cbb_geshimingcheng.TabIndex = 2;
            this.cbb_geshimingcheng.DropDown += new System.EventHandler(this.cbb_geshimingcheng_DropDown);
            this.cbb_geshimingcheng.TextChanged += new System.EventHandler(this.cbb_geshimingcheng_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 28);
            this.label3.TabIndex = 9;
            this.label3.Text = "格式名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 325);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "百分比设置";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_baifenbi, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.76982F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.23018F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 303);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 266);
            this.panel1.TabIndex = 0;
            // 
            // btn_baifenbi
            // 
            this.btn_baifenbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_baifenbi.Location = new System.Drawing.Point(3, 275);
            this.btn_baifenbi.Name = "btn_baifenbi";
            this.btn_baifenbi.Size = new System.Drawing.Size(592, 25);
            this.btn_baifenbi.TabIndex = 1;
            this.btn_baifenbi.Text = "添加百分比";
            this.btn_baifenbi.UseVisualStyleBackColor = true;
            this.btn_baifenbi.Click += new System.EventHandler(this.btn_baifenbi_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel7.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tb_zhengwenchongfulujing, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.pb_folder, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(610, 30);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "重复正文存放路径";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_zhengwenchongfulujing
            // 
            this.tb_zhengwenchongfulujing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_zhengwenchongfulujing.Location = new System.Drawing.Point(163, 3);
            this.tb_zhengwenchongfulujing.Name = "tb_zhengwenchongfulujing";
            this.tb_zhengwenchongfulujing.Size = new System.Drawing.Size(414, 23);
            this.tb_zhengwenchongfulujing.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_quanwenchachong);
            this.groupBox2.Controls.Add(this.cb_zhengwenchachong);
            this.groupBox2.Controls.Add(this.cb_biaozhunjuchachong);
            this.groupBox2.Controls.Add(this.cb_biaozhunduanchachong);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(604, 49);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查重设置";
            // 
            // cb_quanwenchachong
            // 
            this.cb_quanwenchachong.AutoSize = true;
            this.cb_quanwenchachong.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_quanwenchachong.Location = new System.Drawing.Point(254, 21);
            this.cb_quanwenchachong.Name = "cb_quanwenchachong";
            this.cb_quanwenchachong.Size = new System.Drawing.Size(75, 23);
            this.cb_quanwenchachong.TabIndex = 11;
            this.cb_quanwenchachong.Text = "全文查重";
            this.cb_quanwenchachong.UseVisualStyleBackColor = true;
            // 
            // cb_zhengwenchachong
            // 
            this.cb_zhengwenchachong.AutoSize = true;
            this.cb_zhengwenchachong.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_zhengwenchachong.Location = new System.Drawing.Point(179, 21);
            this.cb_zhengwenchachong.Name = "cb_zhengwenchachong";
            this.cb_zhengwenchachong.Size = new System.Drawing.Size(75, 23);
            this.cb_zhengwenchachong.TabIndex = 11;
            this.cb_zhengwenchachong.Text = "正文查重";
            this.cb_zhengwenchachong.UseVisualStyleBackColor = true;
            // 
            // cb_biaozhunjuchachong
            // 
            this.cb_biaozhunjuchachong.AutoSize = true;
            this.cb_biaozhunjuchachong.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_biaozhunjuchachong.Location = new System.Drawing.Point(92, 21);
            this.cb_biaozhunjuchachong.Name = "cb_biaozhunjuchachong";
            this.cb_biaozhunjuchachong.Size = new System.Drawing.Size(87, 23);
            this.cb_biaozhunjuchachong.TabIndex = 11;
            this.cb_biaozhunjuchachong.Text = "标准句查重";
            this.cb_biaozhunjuchachong.UseVisualStyleBackColor = true;
            // 
            // cb_biaozhunduanchachong
            // 
            this.cb_biaozhunduanchachong.AutoSize = true;
            this.cb_biaozhunduanchachong.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_biaozhunduanchachong.Location = new System.Drawing.Point(5, 21);
            this.cb_biaozhunduanchachong.Name = "cb_biaozhunduanchachong";
            this.cb_biaozhunduanchachong.Size = new System.Drawing.Size(87, 23);
            this.cb_biaozhunduanchachong.TabIndex = 11;
            this.cb_biaozhunduanchachong.Text = "标准段查重";
            this.cb_biaozhunduanchachong.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cb_quanwenruku);
            this.groupBox3.Controls.Add(this.cb_biaozhunjuruku);
            this.groupBox3.Controls.Add(this.cb_zhengwenruku);
            this.groupBox3.Controls.Add(this.cb_biaozhunduanruku);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(604, 49);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "入库设置";
            // 
            // cb_quanwenruku
            // 
            this.cb_quanwenruku.AutoSize = true;
            this.cb_quanwenruku.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_quanwenruku.Location = new System.Drawing.Point(254, 21);
            this.cb_quanwenruku.Name = "cb_quanwenruku";
            this.cb_quanwenruku.Size = new System.Drawing.Size(75, 23);
            this.cb_quanwenruku.TabIndex = 11;
            this.cb_quanwenruku.Text = "全文入库";
            this.cb_quanwenruku.UseVisualStyleBackColor = true;
            // 
            // cb_biaozhunjuruku
            // 
            this.cb_biaozhunjuruku.AutoSize = true;
            this.cb_biaozhunjuruku.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_biaozhunjuruku.Location = new System.Drawing.Point(167, 21);
            this.cb_biaozhunjuruku.Name = "cb_biaozhunjuruku";
            this.cb_biaozhunjuruku.Size = new System.Drawing.Size(87, 23);
            this.cb_biaozhunjuruku.TabIndex = 11;
            this.cb_biaozhunjuruku.Text = "标准句入库";
            this.cb_biaozhunjuruku.UseVisualStyleBackColor = true;
            // 
            // cb_zhengwenruku
            // 
            this.cb_zhengwenruku.AutoSize = true;
            this.cb_zhengwenruku.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_zhengwenruku.Location = new System.Drawing.Point(92, 21);
            this.cb_zhengwenruku.Name = "cb_zhengwenruku";
            this.cb_zhengwenruku.Size = new System.Drawing.Size(75, 23);
            this.cb_zhengwenruku.TabIndex = 11;
            this.cb_zhengwenruku.Text = "正文入库";
            this.cb_zhengwenruku.UseVisualStyleBackColor = true;
            // 
            // cb_biaozhunduanruku
            // 
            this.cb_biaozhunduanruku.AutoSize = true;
            this.cb_biaozhunduanruku.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_biaozhunduanruku.Location = new System.Drawing.Point(5, 21);
            this.cb_biaozhunduanruku.Name = "cb_biaozhunduanruku";
            this.cb_biaozhunduanruku.Size = new System.Drawing.Size(87, 23);
            this.cb_biaozhunduanruku.TabIndex = 11;
            this.cb_biaozhunduanruku.Text = "标准段入库";
            this.cb_biaozhunduanruku.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.cbb_chachongku, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(610, 30);
            this.tableLayoutPanel8.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "查 重 库";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbb_chachongku
            // 
            this.cbb_chachongku.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbb_chachongku.FormattingEnabled = true;
            this.cbb_chachongku.Location = new System.Drawing.Point(83, 3);
            this.cbb_chachongku.Name = "cbb_chachongku";
            this.cbb_chachongku.Size = new System.Drawing.Size(524, 25);
            this.cbb_chachongku.TabIndex = 8;
            this.cbb_chachongku.DropDown += new System.EventHandler(this.cbb_chachongku_DropDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(43, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel5);
            this.splitContainer1.Size = new System.Drawing.Size(920, 531);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(966, 537);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // btn_tingzhi
            // 
            this.btn_tingzhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tingzhi.Location = new System.Drawing.Point(228, 3);
            this.btn_tingzhi.Name = "btn_tingzhi";
            this.btn_tingzhi.Size = new System.Drawing.Size(69, 26);
            this.btn_tingzhi.TabIndex = 13;
            this.btn_tingzhi.Text = "停止";
            this.btn_tingzhi.UseVisualStyleBackColor = true;
            this.btn_tingzhi.Click += new System.EventHandler(this.btn_tingzhi_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.pb_adddb, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(40, 537);
            this.tableLayoutPanel9.TabIndex = 16;
            // 
            // pb_folder
            // 
            this.pb_folder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_folder.Image = global::查重工具.Properties.Resources.folder1;
            this.pb_folder.Location = new System.Drawing.Point(583, 3);
            this.pb_folder.Name = "pb_folder";
            this.pb_folder.Size = new System.Drawing.Size(24, 24);
            this.pb_folder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_folder.TabIndex = 5;
            this.pb_folder.TabStop = false;
            this.pb_folder.Click += new System.EventHandler(this.pb_folder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::查重工具.Properties.Resources.抽屉A;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pb_adddb
            // 
            this.pb_adddb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_adddb.Image = global::查重工具.Properties.Resources.tianjia2__1_;
            this.pb_adddb.Location = new System.Drawing.Point(3, 43);
            this.pb_adddb.Name = "pb_adddb";
            this.pb_adddb.Size = new System.Drawing.Size(34, 34);
            this.pb_adddb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_adddb.TabIndex = 1;
            this.pb_adddb.TabStop = false;
            this.pb_adddb.Click += new System.EventHandler(this.pb_adddb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(966, 537);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "查重工具 V1.0.4 2020年12月27日";
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_task)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_adddb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgv_task;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn wenjianming;
        private System.Windows.Forms.DataGridViewTextBoxColumn geshi;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhuangtai;
        private System.Windows.Forms.DataGridViewTextBoxColumn chongfulv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btn_tianjiarenwu;
        private System.Windows.Forms.Button btn_kaishi;
        private System.Windows.Forms.Button btn_qingkong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbb_geshimingcheng;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_baifenbi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_zhengwenchongfulujing;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_quanwenchachong;
        private System.Windows.Forms.CheckBox cb_zhengwenchachong;
        private System.Windows.Forms.CheckBox cb_biaozhunjuchachong;
        private System.Windows.Forms.CheckBox cb_biaozhunduanchachong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cb_quanwenruku;
        private System.Windows.Forms.CheckBox cb_biaozhunjuruku;
        private System.Windows.Forms.CheckBox cb_zhengwenruku;
        private System.Windows.Forms.CheckBox cb_biaozhunduanruku;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_chachongku;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pb_folder;
        private System.Windows.Forms.Button btn_tingzhi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pb_adddb;
    }
}

