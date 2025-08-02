namespace PointsCloud
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi_openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_compute = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_output = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_openFile = new System.Windows.Forms.ToolStripButton();
            this.tsb_compute = new System.Windows.Forms.ToolStripButton();
            this.tsb_output = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_isOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_isCompute = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_input = new System.Windows.Forms.DataGridView();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtb_result = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_input)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_openFile,
            this.tsmi_compute,
            this.tsmi_output});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_openFile
            // 
            this.tsmi_openFile.Name = "tsmi_openFile";
            this.tsmi_openFile.Size = new System.Drawing.Size(68, 21);
            this.tsmi_openFile.Text = "打开文件";
            this.tsmi_openFile.Click += new System.EventHandler(this.tsmi_openFile_Click);
            // 
            // tsmi_compute
            // 
            this.tsmi_compute.Name = "tsmi_compute";
            this.tsmi_compute.Size = new System.Drawing.Size(68, 21);
            this.tsmi_compute.Text = "一键计算";
            this.tsmi_compute.Click += new System.EventHandler(this.tsmi_compute_Click);
            // 
            // tsmi_output
            // 
            this.tsmi_output.Name = "tsmi_output";
            this.tsmi_output.Size = new System.Drawing.Size(68, 21);
            this.tsmi_output.Text = "输出结果";
            this.tsmi_output.Click += new System.EventHandler(this.tsmi_output_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_openFile,
            this.tsb_compute,
            this.tsb_output});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 55);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_openFile
            // 
            this.tsb_openFile.Image = global::PointsCloud.Properties.Resources.openFile;
            this.tsb_openFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_openFile.Name = "tsb_openFile";
            this.tsb_openFile.Size = new System.Drawing.Size(108, 52);
            this.tsb_openFile.Text = "打开文件";
            this.tsb_openFile.Click += new System.EventHandler(this.tsb_openFile_Click);
            // 
            // tsb_compute
            // 
            this.tsb_compute.Image = global::PointsCloud.Properties.Resources.compute;
            this.tsb_compute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_compute.Name = "tsb_compute";
            this.tsb_compute.Size = new System.Drawing.Size(108, 52);
            this.tsb_compute.Text = "一键计算";
            this.tsb_compute.Click += new System.EventHandler(this.tsb_compute_Click);
            // 
            // tsb_output
            // 
            this.tsb_output.Image = global::PointsCloud.Properties.Resources.output;
            this.tsb_output.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_output.Name = "tsb_output";
            this.tsb_output.Size = new System.Drawing.Size(108, 52);
            this.tsb_output.Text = "输出结果";
            this.tsb_output.Click += new System.EventHandler(this.tsb_output_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 336);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_input);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "输入数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtb_result);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "计算结果";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssl_isOpen,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.tssl_isCompute});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "打开文件:";
            // 
            // tssl_isOpen
            // 
            this.tssl_isOpen.Name = "tssl_isOpen";
            this.tssl_isOpen.Size = new System.Drawing.Size(44, 17);
            this.tssl_isOpen.Text = "未打开";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabel3.Text = "   ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel4.Text = "进行计算:";
            // 
            // tssl_isCompute
            // 
            this.tssl_isCompute.Name = "tssl_isCompute";
            this.tssl_isCompute.Size = new System.Drawing.Size(44, 17);
            this.tssl_isCompute.Text = "未计算";
            // 
            // dgv_input
            // 
            this.dgv_input.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_input.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x,
            this.y,
            this.z});
            this.dgv_input.Location = new System.Drawing.Point(7, 7);
            this.dgv_input.Name = "dgv_input";
            this.dgv_input.RowTemplate.Height = 23;
            this.dgv_input.Size = new System.Drawing.Size(739, 297);
            this.dgv_input.TabIndex = 0;
            // 
            // x
            // 
            this.x.HeaderText = "x";
            this.x.Name = "x";
            // 
            // y
            // 
            this.y.HeaderText = "y";
            this.y.Name = "y";
            // 
            // z
            // 
            this.z.HeaderText = "z";
            this.z.Name = "z";
            // 
            // rtb_result
            // 
            this.rtb_result.Location = new System.Drawing.Point(6, 6);
            this.rtb_result.Name = "rtb_result";
            this.rtb_result.Size = new System.Drawing.Size(740, 298);
            this.rtb_result.TabIndex = 0;
            this.rtb_result.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "点云处理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_openFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_compute;
        private System.Windows.Forms.ToolStripMenuItem tsmi_output;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_openFile;
        private System.Windows.Forms.ToolStripButton tsb_compute;
        private System.Windows.Forms.ToolStripButton tsb_output;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_isOpen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tssl_isCompute;
        private System.Windows.Forms.DataGridView dgv_input;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn z;
        private System.Windows.Forms.RichTextBox rtb_result;
    }
}

