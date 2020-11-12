namespace 文本解析系统.JJWinForm
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
            this.tb_folder = new System.Windows.Forms.TextBox();
            this.pb_folder = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_jiexigeshi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_wu = new System.Windows.Forms.CheckBox();
            this.cb_guanji = new System.Windows.Forms.CheckBox();
            this.btn_query = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标文件夹";
            // 
            // tb_folder
            // 
            this.tb_folder.Location = new System.Drawing.Point(136, 23);
            this.tb_folder.Name = "tb_folder";
            this.tb_folder.Size = new System.Drawing.Size(356, 23);
            this.tb_folder.TabIndex = 1;
            // 
            // pb_folder
            // 
            this.pb_folder.Image = global::文本解析系统.Properties.Resources.folderlv;
            this.pb_folder.Location = new System.Drawing.Point(503, 23);
            this.pb_folder.Name = "pb_folder";
            this.pb_folder.Size = new System.Drawing.Size(29, 22);
            this.pb_folder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_folder.TabIndex = 2;
            this.pb_folder.TabStop = false;
            this.pb_folder.Click += new System.EventHandler(this.pb_folder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "解析格式选择";
            // 
            // cbb_jiexigeshi
            // 
            this.cbb_jiexigeshi.FormattingEnabled = true;
            this.cbb_jiexigeshi.Location = new System.Drawing.Point(136, 77);
            this.cbb_jiexigeshi.Name = "cbb_jiexigeshi";
            this.cbb_jiexigeshi.Size = new System.Drawing.Size(348, 25);
            this.cbb_jiexigeshi.TabIndex = 4;
            this.cbb_jiexigeshi.DropDown += new System.EventHandler(this.cbb_jiexigeshi_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "解析完成后操作";
            // 
            // cb_wu
            // 
            this.cb_wu.AutoSize = true;
            this.cb_wu.Checked = true;
            this.cb_wu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_wu.Location = new System.Drawing.Point(146, 131);
            this.cb_wu.Name = "cb_wu";
            this.cb_wu.Size = new System.Drawing.Size(39, 21);
            this.cb_wu.TabIndex = 6;
            this.cb_wu.Text = "无";
            this.cb_wu.UseVisualStyleBackColor = true;
            // 
            // cb_guanji
            // 
            this.cb_guanji.AutoSize = true;
            this.cb_guanji.Location = new System.Drawing.Point(264, 131);
            this.cb_guanji.Name = "cb_guanji";
            this.cb_guanji.Size = new System.Drawing.Size(51, 21);
            this.cb_guanji.TabIndex = 6;
            this.cb_guanji.Text = "关机";
            this.cb_guanji.UseVisualStyleBackColor = true;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(150, 189);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(94, 31);
            this.btn_query.TabIndex = 7;
            this.btn_query.Text = "确定";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(296, 189);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(94, 31);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // WinFormNewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(572, 261);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.cb_guanji);
            this.Controls.Add(this.cb_wu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbb_jiexigeshi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pb_folder);
            this.Controls.Add(this.tb_folder);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WinFormNewTask";
            this.Text = "WinFormNewTask";
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_folder;
        private System.Windows.Forms.PictureBox pb_folder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_jiexigeshi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_wu;
        private System.Windows.Forms.CheckBox cb_guanji;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button btn_close;
    }
}