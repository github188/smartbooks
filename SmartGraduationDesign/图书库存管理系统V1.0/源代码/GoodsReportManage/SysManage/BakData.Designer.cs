namespace GoodsReportManage.SysManage
{
    partial class BakData
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BakData));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtBakName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindFolder = new System.Windows.Forms.Button();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.txtBakName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnFindFolder);
            this.groupBox1.Controls.Add(this.txtPlace);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据备份信息";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(257, 58);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(42, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtBakName
            // 
            this.txtBakName.Location = new System.Drawing.Point(81, 60);
            this.txtBakName.Name = "txtBakName";
            this.txtBakName.Size = new System.Drawing.Size(170, 21);
            this.txtBakName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "备份名称:";
            // 
            // btnFindFolder
            // 
            this.btnFindFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnFindFolder.Image")));
            this.btnFindFolder.Location = new System.Drawing.Point(258, 17);
            this.btnFindFolder.Name = "btnFindFolder";
            this.btnFindFolder.Size = new System.Drawing.Size(42, 23);
            this.btnFindFolder.TabIndex = 2;
            this.btnFindFolder.UseVisualStyleBackColor = true;
            this.btnFindFolder.Click += new System.EventHandler(this.btnFindFolder_Click);
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(81, 20);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.ReadOnly = true;
            this.txtPlace.Size = new System.Drawing.Size(170, 21);
            this.txtPlace.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "备份位置:";
            // 
            // BakData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 125);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BakData";
            this.Text = "数据备份";
            this.Load += new System.EventHandler(this.BakData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtBakName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFindFolder;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}