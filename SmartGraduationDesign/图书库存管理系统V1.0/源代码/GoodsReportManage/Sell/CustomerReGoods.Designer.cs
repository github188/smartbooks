namespace GoodsReportManage.Sell
{
    partial class CustomerReGoods
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerReGoods));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvReGoodsInfo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxCustomerName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHasPay = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNeedPay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labReGoodsID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReGoodsPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.dtBirthday = new System.Windows.Forms.DateTimePicker();
            this.labDay = new System.Windows.Forms.Label();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReGoodsInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvReGoodsInfo);
            this.groupBox2.Location = new System.Drawing.Point(15, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 224);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "退货信息显示";
            // 
            // dgvReGoodsInfo
            // 
            this.dgvReGoodsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReGoodsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReGoodsInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvReGoodsInfo.Name = "dgvReGoodsInfo";
            this.dgvReGoodsInfo.ReadOnly = true;
            this.dgvReGoodsInfo.RowTemplate.Height = 20;
            this.dgvReGoodsInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReGoodsInfo.Size = new System.Drawing.Size(650, 204);
            this.dgvReGoodsInfo.TabIndex = 0;
            this.dgvReGoodsInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReGoodsInfo_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxCustomerName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSpec);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtHasPay);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtNeedPay);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.txtGoodsName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labReGoodsID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtReGoodsPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxUnit);
            this.groupBox1.Controls.Add(this.dtBirthday);
            this.groupBox1.Controls.Add(this.labDay);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(16, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 120);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "退货记录项";
            // 
            // cbxCustomerName
            // 
            this.cbxCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCustomerName.FormattingEnabled = true;
            this.cbxCustomerName.IntegralHeight = false;
            this.cbxCustomerName.Location = new System.Drawing.Point(548, 22);
            this.cbxCustomerName.Name = "cbxCustomerName";
            this.cbxCustomerName.Size = new System.Drawing.Size(86, 20);
            this.cbxCustomerName.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(483, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "客户姓名:";
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(422, 56);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.ReadOnly = true;
            this.txtSpec.Size = new System.Drawing.Size(55, 21);
            this.txtSpec.TabIndex = 30;
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(443, 21);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(34, 23);
            this.btnFind.TabIndex = 29;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(303, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "元";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "元";
            // 
            // txtHasPay
            // 
            this.txtHasPay.Location = new System.Drawing.Point(231, 90);
            this.txtHasPay.Name = "txtHasPay";
            this.txtHasPay.Size = new System.Drawing.Size(70, 21);
            this.txtHasPay.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(167, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "实付金额:";
            // 
            // txtNeedPay
            // 
            this.txtNeedPay.Location = new System.Drawing.Point(81, 90);
            this.txtNeedPay.Name = "txtNeedPay";
            this.txtNeedPay.ReadOnly = true;
            this.txtNeedPay.Size = new System.Drawing.Size(59, 21);
            this.txtNeedPay.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "应付金额:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(617, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "元";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(261, 56);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(48, 21);
            this.txtNum.TabIndex = 20;
            this.txtNum.TextChanged += new System.EventHandler(this.txtNum_TextChanged);
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(261, 22);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.ReadOnly = true;
            this.txtGoodsName.Size = new System.Drawing.Size(176, 21);
            this.txtGoodsName.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "图书名称:";
            // 
            // labReGoodsID
            // 
            this.labReGoodsID.AutoSize = true;
            this.labReGoodsID.ForeColor = System.Drawing.Color.Red;
            this.labReGoodsID.Location = new System.Drawing.Point(80, 26);
            this.labReGoodsID.Name = "labReGoodsID";
            this.labReGoodsID.Size = new System.Drawing.Size(0, 12);
            this.labReGoodsID.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "退 货 ID:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(399, 90);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(235, 21);
            this.txtResult.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "退货原因:";
            // 
            // txtReGoodsPrice
            // 
            this.txtReGoodsPrice.Location = new System.Drawing.Point(548, 56);
            this.txtReGoodsPrice.Name = "txtReGoodsPrice";
            this.txtReGoodsPrice.ReadOnly = true;
            this.txtReGoodsPrice.Size = new System.Drawing.Size(63, 21);
            this.txtReGoodsPrice.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "销售价格:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "图书规格:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "退货数量:";
            // 
            // cbxUnit
            // 
            this.cbxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.IntegralHeight = false;
            this.cbxUnit.Location = new System.Drawing.Point(311, 56);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(40, 20);
            this.cbxUnit.TabIndex = 6;
            // 
            // dtBirthday
            // 
            this.dtBirthday.Location = new System.Drawing.Point(81, 56);
            this.dtBirthday.Name = "dtBirthday";
            this.dtBirthday.Size = new System.Drawing.Size(114, 21);
            this.dtBirthday.TabIndex = 5;
            // 
            // labDay
            // 
            this.labDay.AutoSize = true;
            this.labDay.Location = new System.Drawing.Point(17, 60);
            this.labDay.Name = "labDay";
            this.labDay.Size = new System.Drawing.Size(59, 12);
            this.labDay.TabIndex = 4;
            this.labDay.Text = "退货日期:";
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolAdd,
            this.toolAmend,
            this.toolDelete,
            this.toolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(49, 22);
            this.toolExit.Tag = "7";
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CustomerReGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 403);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "CustomerReGoods";
            this.Text = "客户退货";
            this.Load += new System.EventHandler(this.ReGoods_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReGoodsInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvReGoodsInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHasPay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNeedPay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labReGoodsID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReGoodsPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxUnit;
        private System.Windows.Forms.DateTimePicker dtBirthday;
        private System.Windows.Forms.Label labDay;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbxCustomerName;
        private System.Windows.Forms.Label label5;
    }
}