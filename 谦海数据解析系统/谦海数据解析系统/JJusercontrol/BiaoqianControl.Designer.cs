
namespace 谦海数据解析系统.JJusercontrol
{
    partial class BiaoqianControl
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
            this.panel_my = new System.Windows.Forms.Panel();
            this.pb_add = new System.Windows.Forms.PictureBox();
            this.pb_edit = new System.Windows.Forms.PictureBox();
            this.pb_delete = new System.Windows.Forms.PictureBox();
            this.lbl_mingcheng = new System.Windows.Forms.Label();
            this.pb_zhankai = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_my.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_zhankai)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_my
            // 
            this.panel_my.Controls.Add(this.tableLayoutPanel1);
            this.panel_my.Controls.Add(this.pb_add);
            this.panel_my.Controls.Add(this.pb_edit);
            this.panel_my.Controls.Add(this.pb_delete);
            this.panel_my.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_my.Location = new System.Drawing.Point(0, 0);
            this.panel_my.Margin = new System.Windows.Forms.Padding(0);
            this.panel_my.Name = "panel_my";
            this.panel_my.Size = new System.Drawing.Size(577, 35);
            this.panel_my.TabIndex = 0;
            // 
            // pb_add
            // 
            this.pb_add.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_add.Image = global::谦海数据解析系统.Properties.Resources.addfieldlv;
            this.pb_add.Location = new System.Drawing.Point(517, 0);
            this.pb_add.Margin = new System.Windows.Forms.Padding(5);
            this.pb_add.Name = "pb_add";
            this.pb_add.Size = new System.Drawing.Size(20, 35);
            this.pb_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_add.TabIndex = 4;
            this.pb_add.TabStop = false;
            this.pb_add.Click += new System.EventHandler(this.pb_add_Click);
            // 
            // pb_edit
            // 
            this.pb_edit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_edit.Image = global::谦海数据解析系统.Properties.Resources.编辑2;
            this.pb_edit.Location = new System.Drawing.Point(537, 0);
            this.pb_edit.Margin = new System.Windows.Forms.Padding(5);
            this.pb_edit.Name = "pb_edit";
            this.pb_edit.Size = new System.Drawing.Size(20, 35);
            this.pb_edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_edit.TabIndex = 3;
            this.pb_edit.TabStop = false;
            this.pb_edit.Click += new System.EventHandler(this.pb_edit_Click);
            // 
            // pb_delete
            // 
            this.pb_delete.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_delete.Image = global::谦海数据解析系统.Properties.Resources.delete1;
            this.pb_delete.Location = new System.Drawing.Point(557, 0);
            this.pb_delete.Margin = new System.Windows.Forms.Padding(5);
            this.pb_delete.Name = "pb_delete";
            this.pb_delete.Size = new System.Drawing.Size(20, 35);
            this.pb_delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_delete.TabIndex = 2;
            this.pb_delete.TabStop = false;
            this.pb_delete.Click += new System.EventHandler(this.pb_delete_Click);
            // 
            // lbl_mingcheng
            // 
            this.lbl_mingcheng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_mingcheng.Location = new System.Drawing.Point(23, 0);
            this.lbl_mingcheng.Name = "lbl_mingcheng";
            this.lbl_mingcheng.Size = new System.Drawing.Size(491, 35);
            this.lbl_mingcheng.TabIndex = 1;
            this.lbl_mingcheng.Text = "label1";
            this.lbl_mingcheng.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb_zhankai
            // 
            this.pb_zhankai.BackgroundImage = global::谦海数据解析系统.Properties.Resources.add;
            this.pb_zhankai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_zhankai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_zhankai.Location = new System.Drawing.Point(0, 0);
            this.pb_zhankai.Margin = new System.Windows.Forms.Padding(0);
            this.pb_zhankai.Name = "pb_zhankai";
            this.pb_zhankai.Size = new System.Drawing.Size(20, 35);
            this.pb_zhankai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_zhankai.TabIndex = 0;
            this.pb_zhankai.TabStop = false;
            this.pb_zhankai.BackgroundImageChanged += new System.EventHandler(this.pb_zhankai_BackgroundImageChanged);
            this.pb_zhankai.Click += new System.EventHandler(this.pb_zhankai_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_mingcheng, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_zhankai, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(517, 35);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // BiaoqianControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel_my);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BiaoqianControl";
            this.Size = new System.Drawing.Size(577, 35);
            this.Load += new System.EventHandler(this.BiaoqianControl_Load);
            this.panel_my.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_zhankai)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_my;
        private System.Windows.Forms.PictureBox pb_add;
        private System.Windows.Forms.PictureBox pb_edit;
        private System.Windows.Forms.PictureBox pb_delete;
        private System.Windows.Forms.Label lbl_mingcheng;
        private System.Windows.Forms.PictureBox pb_zhankai;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
