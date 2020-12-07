namespace 团队任务台账管理系统.WinForm
{
    partial class WFqingxiujiadan
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
            this.lbl_quxiao = new System.Windows.Forms.Label();
            this.lbl_baocun = new System.Windows.Forms.Label();
            this.tb_weituoduixiang = new System.Windows.Forms.TextBox();
            this.tb_shiyou = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_shenheyijian = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_quxiao
            // 
            this.lbl_quxiao.AutoSize = true;
            this.lbl_quxiao.BackColor = System.Drawing.Color.Tomato;
            this.lbl_quxiao.ForeColor = System.Drawing.Color.White;
            this.lbl_quxiao.Location = new System.Drawing.Point(306, 285);
            this.lbl_quxiao.Name = "lbl_quxiao";
            this.lbl_quxiao.Size = new System.Drawing.Size(29, 12);
            this.lbl_quxiao.TabIndex = 19;
            this.lbl_quxiao.Text = "取消";
            this.lbl_quxiao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_quxiao.Click += new System.EventHandler(this.lbl_quxiao_Click);
            // 
            // lbl_baocun
            // 
            this.lbl_baocun.AutoSize = true;
            this.lbl_baocun.BackColor = System.Drawing.Color.Tomato;
            this.lbl_baocun.ForeColor = System.Drawing.Color.White;
            this.lbl_baocun.Location = new System.Drawing.Point(143, 285);
            this.lbl_baocun.Name = "lbl_baocun";
            this.lbl_baocun.Size = new System.Drawing.Size(29, 12);
            this.lbl_baocun.TabIndex = 20;
            this.lbl_baocun.Text = "保存";
            this.lbl_baocun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_baocun.Click += new System.EventHandler(this.lbl_baocun_Click);
            // 
            // tb_weituoduixiang
            // 
            this.tb_weituoduixiang.Location = new System.Drawing.Point(179, 174);
            this.tb_weituoduixiang.Name = "tb_weituoduixiang";
            this.tb_weituoduixiang.Size = new System.Drawing.Size(210, 21);
            this.tb_weituoduixiang.TabIndex = 16;
            // 
            // tb_shiyou
            // 
            this.tb_shiyou.Location = new System.Drawing.Point(179, 62);
            this.tb_shiyou.Name = "tb_shiyou";
            this.tb_shiyou.Size = new System.Drawing.Size(210, 21);
            this.tb_shiyou.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "休假期间工作委托对象";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "起止时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "是由";
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(179, 97);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(142, 21);
            this.dtp_start.TabIndex = 21;
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(179, 124);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(142, 21);
            this.dtp_end.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "审核意见";
            // 
            // tb_shenheyijian
            // 
            this.tb_shenheyijian.Location = new System.Drawing.Point(179, 218);
            this.tb_shenheyijian.Name = "tb_shenheyijian";
            this.tb_shenheyijian.Size = new System.Drawing.Size(210, 21);
            this.tb_shenheyijian.TabIndex = 16;
            // 
            // WFqingxiujiadan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 399);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtp_end);
            this.Controls.Add(this.dtp_start);
            this.Controls.Add(this.lbl_quxiao);
            this.Controls.Add(this.lbl_baocun);
            this.Controls.Add(this.tb_shenheyijian);
            this.Controls.Add(this.tb_weituoduixiang);
            this.Controls.Add(this.tb_shiyou);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WFqingxiujiadan";
            this.Text = "请休假单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_quxiao;
        private System.Windows.Forms.Label lbl_baocun;
        private System.Windows.Forms.TextBox tb_weituoduixiang;
        private System.Windows.Forms.TextBox tb_shiyou;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_shenheyijian;
    }
}