namespace 团队任务台账管理系统.UserControll
{
    partial class UCtongxunlu
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
            this.flp_my = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_my
            // 
            this.flp_my.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_my.Location = new System.Drawing.Point(0, 0);
            this.flp_my.Name = "flp_my";
            this.flp_my.Size = new System.Drawing.Size(498, 411);
            this.flp_my.TabIndex = 0;
            // 
            // UCtongxunlu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flp_my);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCtongxunlu";
            this.Size = new System.Drawing.Size(498, 411);
            this.Load += new System.EventHandler(this.UCtongxunlu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_my;
    }
}
