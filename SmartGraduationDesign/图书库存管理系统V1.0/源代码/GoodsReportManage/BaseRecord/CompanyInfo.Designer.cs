namespace GoodsReportManage.BaseRecord
{
    partial class CompanyInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyInfo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolreflush = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labCondation = new System.Windows.Forms.ToolStripLabel();
            this.cbxCondition = new System.Windows.Forms.ToolStripComboBox();
            this.txtKeyWord = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtOK = new System.Windows.Forms.ToolStripButton();
            this.labK = new System.Windows.Forms.ToolStripLabel();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCompanyInfo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labDirector = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolAdd,
            this.toolAmend,
            this.toolDelete,
            this.toolreflush,
            this.toolStripSeparator1,
            this.labCondation,
            this.cbxCondition,
            this.txtKeyWord,
            this.toolStripSeparator2,
            this.txtOK,
            this.labK,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(689, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.Enabled = false;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(49, 22);
            this.toolSave.Tag = "1";
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.Enabled = false;
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(49, 22);
            this.toolCancel.Tag = "2";
            this.toolCancel.Text = "取消";
            this.toolCancel.Click += new System.EventHandler(this.toolCancel_Click);
            // 
            // toolAdd
            // 
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(49, 22);
            this.toolAdd.Tag = "3";
            this.toolAdd.Text = "添加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolAmend
            // 
            this.toolAmend.Image = ((System.Drawing.Image)(resources.GetObject("toolAmend.Image")));
            this.toolAmend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAmend.Name = "toolAmend";
            this.toolAmend.Size = new System.Drawing.Size(49, 22);
            this.toolAmend.Tag = "4";
            this.toolAmend.Text = "修改";
            this.toolAmend.Click += new System.EventHandler(this.toolAmend_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(49, 22);
            this.toolDelete.Tag = "5";
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolreflush
            // 
            this.toolreflush.Image = ((System.Drawing.Image)(resources.GetObject("toolreflush.Image")));
            this.toolreflush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolreflush.Name = "toolreflush";
            this.toolreflush.Size = new System.Drawing.Size(49, 22);
            this.toolreflush.Text = "刷新";
            this.toolreflush.Click += new System.EventHandler(this.toolreflush_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // labCondation
            // 
            this.labCondation.Name = "labCondation";
            this.labCondation.Size = new System.Drawing.Size(59, 22);
            this.labCondation.Text = "查询条件:";
            // 
            // cbxCondition
            // 
            this.cbxCondition.Items.AddRange(new object[] {
            "供应商名称",
            "供应商主管"});
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(75, 25);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtOK
            // 
            this.txtOK.Image = ((System.Drawing.Image)(resources.GetObject("txtOK.Image")));
            this.txtOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtOK.Name = "txtOK";
            this.txtOK.Size = new System.Drawing.Size(49, 22);
            this.txtOK.Tag = "6";
            this.txtOK.Text = "查找";
            this.txtOK.Click += new System.EventHandler(this.txtOK_Click);
            // 
            // labK
            // 
            this.labK.Name = "labK";
            this.labK.Size = new System.Drawing.Size(29, 22);
            this.labK.Text = "    ";
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(49, 22);
            this.toolExit.Tag = "7";
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCompanyInfo);
            this.groupBox2.Location = new System.Drawing.Point(17, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(652, 224);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "供应商信息显示";
            // 
            // dgvCompanyInfo
            // 
            this.dgvCompanyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompanyInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvCompanyInfo.Name = "dgvCompanyInfo";
            this.dgvCompanyInfo.ReadOnly = true;
            this.dgvCompanyInfo.RowTemplate.Height = 20;
            this.dgvCompanyInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompanyInfo.Size = new System.Drawing.Size(646, 204);
            this.dgvCompanyInfo.TabIndex = 0;
            this.dgvCompanyInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyInfo_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.txtFax);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDirector);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labDirector);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Controls.Add(this.labName);
            this.groupBox1.Location = new System.Drawing.Point(17, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 124);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "供应商记录项";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(72, 87);
            this.txtRemark.MaxLength = 400;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(568, 21);
            this.txtRemark.TabIndex = 6;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(72, 55);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.ReadOnly = true;
            this.txtFax.Size = new System.Drawing.Size(171, 21);
            this.txtFax.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(521, 20);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(119, 21);
            this.txtPhone.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(457, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "供应商电话:";
            // 
            // txtDirector
            // 
            this.txtDirector.Location = new System.Drawing.Point(323, 23);
            this.txtDirector.MaxLength = 20;
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.ReadOnly = true;
            this.txtDirector.Size = new System.Drawing.Size(112, 21);
            this.txtDirector.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(323, 55);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(317, 21);
            this.txtAddress.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = " 备  注 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "供应商地址:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "供应商传真:";
            // 
            // labDirector
            // 
            this.labDirector.AutoSize = true;
            this.labDirector.Location = new System.Drawing.Point(258, 32);
            this.labDirector.Name = "labDirector";
            this.labDirector.Size = new System.Drawing.Size(59, 12);
            this.labDirector.TabIndex = 3;
            this.labDirector.Text = "供应商主管:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(72, 24);
            this.txtCompanyName.MaxLength = 100;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(171, 21);
            this.txtCompanyName.TabIndex = 1;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(8, 32);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(59, 12);
            this.labName.TabIndex = 0;
            this.labName.Text = "供应商名称:";
            // 
            // CompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CompanyInfo";
            this.Text = "供应商信息";
            this.Load += new System.EventHandler(this.CompanyInfo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labCondation;
        private System.Windows.Forms.ToolStripComboBox cbxCondition;
        private System.Windows.Forms.ToolStripTextBox txtKeyWord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton txtOK;
        private System.Windows.Forms.ToolStripLabel labK;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCompanyInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labDirector;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.ToolStripButton toolreflush;
    }
}