namespace GoodsReportManage.BaseRecord
{
    partial class CustomerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInfo));
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.dgvCustomerInfo = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.labCondation = new System.Windows.Forms.ToolStripLabel();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.labK = new System.Windows.Forms.ToolStripLabel();
            this.toolrefesh = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbxCondition = new System.Windows.Forms.ToolStripComboBox();
            this.txtKeyWord = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtOK = new System.Windows.Forms.ToolStripButton();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhoneM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBirthday = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.labSex = new System.Windows.Forms.Label();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // dgvCustomerInfo
            // 
            this.dgvCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvCustomerInfo.Name = "dgvCustomerInfo";
            this.dgvCustomerInfo.ReadOnly = true;
            this.dgvCustomerInfo.RowTemplate.Height = 20;
            this.dgvCustomerInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerInfo.Size = new System.Drawing.Size(646, 218);
            this.dgvCustomerInfo.TabIndex = 0;
            this.dgvCustomerInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerInfo_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCustomerInfo);
            this.groupBox2.Location = new System.Drawing.Point(16, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(652, 238);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "客户信息显示";
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
            // labCondation
            // 
            this.labCondation.Name = "labCondation";
            this.labCondation.Size = new System.Drawing.Size(59, 22);
            this.labCondation.Text = "查询条件:";
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
            // labK
            // 
            this.labK.Name = "labK";
            this.labK.Size = new System.Drawing.Size(29, 22);
            this.labK.Text = "    ";
            // 
            // toolrefesh
            // 
            this.toolrefesh.Image = ((System.Drawing.Image)(resources.GetObject("toolrefesh.Image")));
            this.toolrefesh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolrefesh.Name = "toolrefesh";
            this.toolrefesh.Size = new System.Drawing.Size(49, 22);
            this.toolrefesh.Text = "刷新";
            this.toolrefesh.Click += new System.EventHandler(this.toolrefesh_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolAdd,
            this.toolAmend,
            this.toolDelete,
            this.toolrefesh,
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
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbxCondition
            // 
            this.cbxCondition.Items.AddRange(new object[] {
            "客户姓名",
            "客户性别",
            "手机号码"});
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
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(441, 54);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(195, 21);
            this.txtAddress.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "家庭住址:";
            // 
            // txtPhoneM
            // 
            this.txtPhoneM.Location = new System.Drawing.Point(248, 55);
            this.txtPhoneM.MaxLength = 20;
            this.txtPhoneM.Name = "txtPhoneM";
            this.txtPhoneM.Size = new System.Drawing.Size(123, 21);
            this.txtPhoneM.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "手机号码:";
            // 
            // txtPhoneH
            // 
            this.txtPhoneH.Location = new System.Drawing.Point(72, 55);
            this.txtPhoneH.MaxLength = 20;
            this.txtPhoneH.Name = "txtPhoneH";
            this.txtPhoneH.Size = new System.Drawing.Size(100, 21);
            this.txtPhoneH.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "家庭电话:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPhoneM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPhoneH);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtBirthday);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labSex);
            this.groupBox1.Controls.Add(this.cbxSex);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.labName);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(16, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 120);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户记录项";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(72, 87);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(564, 21);
            this.txtRemark.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = " 备 注 :";
            // 
            // dtBirthday
            // 
            this.dtBirthday.Location = new System.Drawing.Point(441, 24);
            this.dtBirthday.Name = "dtBirthday";
            this.dtBirthday.Size = new System.Drawing.Size(195, 21);
            this.dtBirthday.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "出生日期:";
            // 
            // labSex
            // 
            this.labSex.AutoSize = true;
            this.labSex.Location = new System.Drawing.Point(184, 32);
            this.labSex.Name = "labSex";
            this.labSex.Size = new System.Drawing.Size(59, 12);
            this.labSex.TabIndex = 3;
            this.labSex.Text = "客户性别:";
            // 
            // cbxSex
            // 
            this.cbxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.IntegralHeight = false;
            this.cbxSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbxSex.Location = new System.Drawing.Point(248, 24);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(123, 20);
            this.cbxSex.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 24);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 1;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(8, 32);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(59, 12);
            this.labName.TabIndex = 0;
            this.labName.Text = "客户姓名:";
            // 
            // CustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CustomerInfo";
            this.Text = "客户基本信息";
            this.Load += new System.EventHandler(this.CustomerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.DataGridView dgvCustomerInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripLabel labCondation;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.ToolStripLabel labK;
        private System.Windows.Forms.ToolStripButton toolrefesh;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbxCondition;
        private System.Windows.Forms.ToolStripTextBox txtKeyWord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton txtOK;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhoneM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhoneH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtBirthday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labSex;
        private System.Windows.Forms.ComboBox cbxSex;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
    }
}