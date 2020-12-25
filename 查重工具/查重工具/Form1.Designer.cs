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
            this.btn_tianjiarenwu = new System.Windows.Forms.Button();
            this.dgv_task = new System.Windows.Forms.DataGridView();
            this.xuhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wenjianming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geshi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhuangtai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chongfulv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbb_geshimingcheng = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_quanwenchongfulujing = new System.Windows.Forms.TextBox();
            this.cb_quanwenmoren = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_baifenbi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_chachongku = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_zhengwenchongfulujing = new System.Windows.Forms.TextBox();
            this.cb_zhengwenmoren = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cb_quanwenchachong = new System.Windows.Forms.CheckBox();
            this.cb_zhengwenchachong = new System.Windows.Forms.CheckBox();
            this.cb_biaozhunduanchachong = new System.Windows.Forms.CheckBox();
            this.cb_biaozhunjuchachong = new System.Windows.Forms.CheckBox();
            this.cb_quanwenruku = new System.Windows.Forms.CheckBox();
            this.cb_zhengwenruku = new System.Windows.Forms.CheckBox();
            this.cb_biaozhunduanruku = new System.Windows.Forms.CheckBox();
            this.cb_biaozhunjuruku = new System.Windows.Forms.CheckBox();
            this.btn_qingkong = new System.Windows.Forms.Button();
            this.btn_kaishi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_task)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_tianjiarenwu
            // 
            this.btn_tianjiarenwu.Location = new System.Drawing.Point(42, 27);
            this.btn_tianjiarenwu.Name = "btn_tianjiarenwu";
            this.btn_tianjiarenwu.Size = new System.Drawing.Size(76, 32);
            this.btn_tianjiarenwu.TabIndex = 0;
            this.btn_tianjiarenwu.Text = "添加任务";
            this.btn_tianjiarenwu.UseVisualStyleBackColor = true;
            this.btn_tianjiarenwu.Click += new System.EventHandler(this.btn_tianjiarenwu_Click);
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
            this.dgv_task.Location = new System.Drawing.Point(33, 73);
            this.dgv_task.Name = "dgv_task";
            this.dgv_task.RowHeadersVisible = false;
            this.dgv_task.RowTemplate.Height = 23;
            this.dgv_task.Size = new System.Drawing.Size(319, 553);
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
            // cbb_geshimingcheng
            // 
            this.cbb_geshimingcheng.FormattingEnabled = true;
            this.cbb_geshimingcheng.Location = new System.Drawing.Point(486, 39);
            this.cbb_geshimingcheng.Name = "cbb_geshimingcheng";
            this.cbb_geshimingcheng.Size = new System.Drawing.Size(189, 20);
            this.cbb_geshimingcheng.TabIndex = 2;
            this.cbb_geshimingcheng.DropDown += new System.EventHandler(this.cbb_geshimingcheng_DropDown);
            this.cbb_geshimingcheng.TextChanged += new System.EventHandler(this.cbb_geshimingcheng_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "全文重复路径";
            // 
            // tb_quanwenchongfulujing
            // 
            this.tb_quanwenchongfulujing.Location = new System.Drawing.Point(579, 100);
            this.tb_quanwenchongfulujing.Name = "tb_quanwenchongfulujing";
            this.tb_quanwenchongfulujing.Size = new System.Drawing.Size(244, 21);
            this.tb_quanwenchongfulujing.TabIndex = 4;
            // 
            // cb_quanwenmoren
            // 
            this.cb_quanwenmoren.AutoSize = true;
            this.cb_quanwenmoren.Location = new System.Drawing.Point(503, 104);
            this.cb_quanwenmoren.Name = "cb_quanwenmoren";
            this.cb_quanwenmoren.Size = new System.Drawing.Size(72, 16);
            this.cb_quanwenmoren.TabIndex = 5;
            this.cb_quanwenmoren.Text = "默认路径";
            this.cb_quanwenmoren.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(398, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 411);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 391);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 316);
            this.panel1.TabIndex = 0;
            // 
            // btn_baifenbi
            // 
            this.btn_baifenbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_baifenbi.Location = new System.Drawing.Point(3, 325);
            this.btn_baifenbi.Name = "btn_baifenbi";
            this.btn_baifenbi.Size = new System.Drawing.Size(536, 63);
            this.btn_baifenbi.TabIndex = 1;
            this.btn_baifenbi.Text = "添加百分比";
            this.btn_baifenbi.UseVisualStyleBackColor = true;
            this.btn_baifenbi.Click += new System.EventHandler(this.btn_baifenbi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "查重库";
            // 
            // cbb_chachongku
            // 
            this.cbb_chachongku.FormattingEnabled = true;
            this.cbb_chachongku.Items.AddRange(new object[] {
            "裁判文书库",
            "政策库",
            "新文库",
            "法规库"});
            this.cbb_chachongku.Location = new System.Drawing.Point(486, 70);
            this.cbb_chachongku.Name = "cbb_chachongku";
            this.cbb_chachongku.Size = new System.Drawing.Size(211, 20);
            this.cbb_chachongku.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "格式名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "正文重复路径";
            // 
            // tb_zhengwenchongfulujing
            // 
            this.tb_zhengwenchongfulujing.Location = new System.Drawing.Point(579, 127);
            this.tb_zhengwenchongfulujing.Name = "tb_zhengwenchongfulujing";
            this.tb_zhengwenchongfulujing.Size = new System.Drawing.Size(244, 21);
            this.tb_zhengwenchongfulujing.TabIndex = 4;
            // 
            // cb_zhengwenmoren
            // 
            this.cb_zhengwenmoren.AutoSize = true;
            this.cb_zhengwenmoren.Location = new System.Drawing.Point(503, 131);
            this.cb_zhengwenmoren.Name = "cb_zhengwenmoren";
            this.cb_zhengwenmoren.Size = new System.Drawing.Size(72, 16);
            this.cb_zhengwenmoren.TabIndex = 5;
            this.cb_zhengwenmoren.Text = "默认路径";
            this.cb_zhengwenmoren.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(681, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 27);
            this.button2.TabIndex = 10;
            this.button2.Text = "保存格式";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(759, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 27);
            this.button3.TabIndex = 10;
            this.button3.Text = "删除格式";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cb_quanwenchachong
            // 
            this.cb_quanwenchachong.AutoSize = true;
            this.cb_quanwenchachong.Location = new System.Drawing.Point(398, 161);
            this.cb_quanwenchachong.Name = "cb_quanwenchachong";
            this.cb_quanwenchachong.Size = new System.Drawing.Size(72, 16);
            this.cb_quanwenchachong.TabIndex = 11;
            this.cb_quanwenchachong.Text = "全文查重";
            this.cb_quanwenchachong.UseVisualStyleBackColor = true;
            // 
            // cb_zhengwenchachong
            // 
            this.cb_zhengwenchachong.AutoSize = true;
            this.cb_zhengwenchachong.Location = new System.Drawing.Point(497, 161);
            this.cb_zhengwenchachong.Name = "cb_zhengwenchachong";
            this.cb_zhengwenchachong.Size = new System.Drawing.Size(72, 16);
            this.cb_zhengwenchachong.TabIndex = 11;
            this.cb_zhengwenchachong.Text = "正文查重";
            this.cb_zhengwenchachong.UseVisualStyleBackColor = true;
            // 
            // cb_biaozhunduanchachong
            // 
            this.cb_biaozhunduanchachong.AutoSize = true;
            this.cb_biaozhunduanchachong.Location = new System.Drawing.Point(591, 161);
            this.cb_biaozhunduanchachong.Name = "cb_biaozhunduanchachong";
            this.cb_biaozhunduanchachong.Size = new System.Drawing.Size(84, 16);
            this.cb_biaozhunduanchachong.TabIndex = 11;
            this.cb_biaozhunduanchachong.Text = "标准段查重";
            this.cb_biaozhunduanchachong.UseVisualStyleBackColor = true;
            // 
            // cb_biaozhunjuchachong
            // 
            this.cb_biaozhunjuchachong.AutoSize = true;
            this.cb_biaozhunjuchachong.Location = new System.Drawing.Point(692, 161);
            this.cb_biaozhunjuchachong.Name = "cb_biaozhunjuchachong";
            this.cb_biaozhunjuchachong.Size = new System.Drawing.Size(84, 16);
            this.cb_biaozhunjuchachong.TabIndex = 11;
            this.cb_biaozhunjuchachong.Text = "标准句查重";
            this.cb_biaozhunjuchachong.UseVisualStyleBackColor = true;
            // 
            // cb_quanwenruku
            // 
            this.cb_quanwenruku.AutoSize = true;
            this.cb_quanwenruku.Location = new System.Drawing.Point(398, 183);
            this.cb_quanwenruku.Name = "cb_quanwenruku";
            this.cb_quanwenruku.Size = new System.Drawing.Size(72, 16);
            this.cb_quanwenruku.TabIndex = 11;
            this.cb_quanwenruku.Text = "全文入库";
            this.cb_quanwenruku.UseVisualStyleBackColor = true;
            // 
            // cb_zhengwenruku
            // 
            this.cb_zhengwenruku.AutoSize = true;
            this.cb_zhengwenruku.Location = new System.Drawing.Point(497, 183);
            this.cb_zhengwenruku.Name = "cb_zhengwenruku";
            this.cb_zhengwenruku.Size = new System.Drawing.Size(72, 16);
            this.cb_zhengwenruku.TabIndex = 11;
            this.cb_zhengwenruku.Text = "正文入库";
            this.cb_zhengwenruku.UseVisualStyleBackColor = true;
            // 
            // cb_biaozhunduanruku
            // 
            this.cb_biaozhunduanruku.AutoSize = true;
            this.cb_biaozhunduanruku.Location = new System.Drawing.Point(591, 183);
            this.cb_biaozhunduanruku.Name = "cb_biaozhunduanruku";
            this.cb_biaozhunduanruku.Size = new System.Drawing.Size(84, 16);
            this.cb_biaozhunduanruku.TabIndex = 11;
            this.cb_biaozhunduanruku.Text = "标准段入库";
            this.cb_biaozhunduanruku.UseVisualStyleBackColor = true;
            // 
            // cb_biaozhunjuruku
            // 
            this.cb_biaozhunjuruku.AutoSize = true;
            this.cb_biaozhunjuruku.Location = new System.Drawing.Point(692, 183);
            this.cb_biaozhunjuruku.Name = "cb_biaozhunjuruku";
            this.cb_biaozhunjuruku.Size = new System.Drawing.Size(84, 16);
            this.cb_biaozhunjuruku.TabIndex = 11;
            this.cb_biaozhunjuruku.Text = "标准句入库";
            this.cb_biaozhunjuruku.UseVisualStyleBackColor = true;
            // 
            // btn_qingkong
            // 
            this.btn_qingkong.Location = new System.Drawing.Point(136, 27);
            this.btn_qingkong.Name = "btn_qingkong";
            this.btn_qingkong.Size = new System.Drawing.Size(76, 32);
            this.btn_qingkong.TabIndex = 0;
            this.btn_qingkong.Text = "清空任务";
            this.btn_qingkong.UseVisualStyleBackColor = true;
            this.btn_qingkong.Click += new System.EventHandler(this.btn_qingkong_Click);
            // 
            // btn_kaishi
            // 
            this.btn_kaishi.Location = new System.Drawing.Point(236, 27);
            this.btn_kaishi.Name = "btn_kaishi";
            this.btn_kaishi.Size = new System.Drawing.Size(102, 31);
            this.btn_kaishi.TabIndex = 12;
            this.btn_kaishi.Text = "开始";
            this.btn_kaishi.UseVisualStyleBackColor = true;
            this.btn_kaishi.Click += new System.EventHandler(this.btn_kaishi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 655);
            this.Controls.Add(this.btn_kaishi);
            this.Controls.Add(this.cb_biaozhunjuruku);
            this.Controls.Add(this.cb_biaozhunjuchachong);
            this.Controls.Add(this.cb_biaozhunduanruku);
            this.Controls.Add(this.cb_biaozhunduanchachong);
            this.Controls.Add(this.cb_zhengwenruku);
            this.Controls.Add(this.cb_zhengwenchachong);
            this.Controls.Add(this.cb_quanwenruku);
            this.Controls.Add(this.cb_quanwenchachong);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbb_chachongku);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cb_zhengwenmoren);
            this.Controls.Add(this.cb_quanwenmoren);
            this.Controls.Add(this.tb_zhengwenchongfulujing);
            this.Controls.Add(this.tb_quanwenchongfulujing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_geshimingcheng);
            this.Controls.Add(this.dgv_task);
            this.Controls.Add(this.btn_qingkong);
            this.Controls.Add(this.btn_tianjiarenwu);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_task)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_tianjiarenwu;
        private System.Windows.Forms.DataGridView dgv_task;
        private System.Windows.Forms.ComboBox cbb_geshimingcheng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_quanwenchongfulujing;
        private System.Windows.Forms.CheckBox cb_quanwenmoren;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_baifenbi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_chachongku;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_zhengwenchongfulujing;
        private System.Windows.Forms.CheckBox cb_zhengwenmoren;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox cb_quanwenchachong;
        private System.Windows.Forms.CheckBox cb_zhengwenchachong;
        private System.Windows.Forms.CheckBox cb_biaozhunduanchachong;
        private System.Windows.Forms.CheckBox cb_biaozhunjuchachong;
        private System.Windows.Forms.CheckBox cb_quanwenruku;
        private System.Windows.Forms.CheckBox cb_zhengwenruku;
        private System.Windows.Forms.CheckBox cb_biaozhunduanruku;
        private System.Windows.Forms.CheckBox cb_biaozhunjuruku;
        private System.Windows.Forms.Button btn_qingkong;
        private System.Windows.Forms.Button btn_kaishi;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn wenjianming;
        private System.Windows.Forms.DataGridViewTextBoxColumn geshi;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhuangtai;
        private System.Windows.Forms.DataGridViewTextBoxColumn chongfulv;
    }
}

