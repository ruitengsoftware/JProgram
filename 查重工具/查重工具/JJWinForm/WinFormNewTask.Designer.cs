namespace 查重工具
{
    partial class WinFormNewTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_folder = new System.Windows.Forms.TextBox();
            this.cbb_format = new System.Windows.Forms.ComboBox();
            this.btn_queding = new System.Windows.Forms.Button();
            this.btn_guanbi = new System.Windows.Forms.Button();
            this.pb_folder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件夹";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择格式";
            // 
            // tb_folder
            // 
            this.tb_folder.Location = new System.Drawing.Point(125, 43);
            this.tb_folder.Name = "tb_folder";
            this.tb_folder.Size = new System.Drawing.Size(327, 23);
            this.tb_folder.TabIndex = 2;
            // 
            // cbb_format
            // 
            this.cbb_format.FormattingEnabled = true;
            this.cbb_format.Location = new System.Drawing.Point(125, 103);
            this.cbb_format.Name = "cbb_format";
            this.cbb_format.Size = new System.Drawing.Size(326, 25);
            this.cbb_format.TabIndex = 3;
            this.cbb_format.DropDown += new System.EventHandler(this.cbb_format_DropDown);
            this.cbb_format.TextChanged += new System.EventHandler(this.cbb_format_TextChanged);
            // 
            // btn_queding
            // 
            this.btn_queding.Location = new System.Drawing.Point(154, 178);
            this.btn_queding.Name = "btn_queding";
            this.btn_queding.Size = new System.Drawing.Size(93, 31);
            this.btn_queding.TabIndex = 4;
            this.btn_queding.Text = "确定";
            this.btn_queding.UseVisualStyleBackColor = true;
            this.btn_queding.Click += new System.EventHandler(this.btn_queding_Click);
            // 
            // btn_guanbi
            // 
            this.btn_guanbi.Location = new System.Drawing.Point(306, 178);
            this.btn_guanbi.Name = "btn_guanbi";
            this.btn_guanbi.Size = new System.Drawing.Size(93, 31);
            this.btn_guanbi.TabIndex = 4;
            this.btn_guanbi.Text = "关闭";
            this.btn_guanbi.UseVisualStyleBackColor = true;
            this.btn_guanbi.Click += new System.EventHandler(this.btn_guanbi_Click);
            // 
            // pb_folder
            // 
            this.pb_folder.Image = global::查重工具.Properties.Resources.folder1;
            this.pb_folder.Location = new System.Drawing.Point(467, 42);
            this.pb_folder.Name = "pb_folder";
            this.pb_folder.Size = new System.Drawing.Size(45, 24);
            this.pb_folder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_folder.TabIndex = 5;
            this.pb_folder.TabStop = false;
            this.pb_folder.Click += new System.EventHandler(this.pb_folder_Click);
            // 
            // WinFormNewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 250);
            this.Controls.Add(this.pb_folder);
            this.Controls.Add(this.btn_guanbi);
            this.Controls.Add(this.btn_queding);
            this.Controls.Add(this.cbb_format);
            this.Controls.Add(this.tb_folder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormNewTask";
            this.Text = "新建任务";
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_folder;
        private System.Windows.Forms.ComboBox cbb_format;
        private System.Windows.Forms.Button btn_queding;
        private System.Windows.Forms.Button btn_guanbi;
        private System.Windows.Forms.PictureBox pb_folder;
    }
}