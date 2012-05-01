namespace GoodsReportManage.Sell
{
    partial class s
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(s));
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.dtBirthday = new System.Windows.Forms.DateTimePicker();
            this.labDay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxCustomerName = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxSellName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnFindGoods = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHasPay = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNeedPay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labGoodsID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGoodsInPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSellInfo = new System.Windows.Forms.DataGridView();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellInfo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(520, 56);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.ReadOnly = true;
            this.txtSpec.Size = new System.Drawing.Size(114, 21);
            this.txtSpec.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "销售数量:";
            // 
            // cbxUnit
            // 
            this.cbxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.IntegralHeight = false;
            this.cbxUnit.Location = new System.Drawing.Point(395, 56);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(40, 20);
            this.cbxUnit.TabIndex = 6;
            // 
            // dtBirthday
            // 
            this.dtBirthday.Location = new System.Drawing.Point(520, 24);
            this.dtBirthday.Name = "dtBirthday";
            this.dtBirthday.Size = new System.Drawing.Size(114, 21);
            this.dtBirthday.TabIndex = 5;
            // 
            // labDay
            // 
            this.labDay.AutoSize = true;
            this.labDay.Location = new System.Drawing.Point(456, 32);
            this.labDay.Name = "labDay";
            this.labDay.Size = new System.Drawing.Size(59, 12);
            this.labDay.TabIndex = 4;
            this.labDay.Text = "销售日期:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxCustomerName);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cbxSellName);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.btnFindGoods);
            this.groupBox1.Controls.Add(this.txtSpec);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtHasPay);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtNeedPay);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.txtGoodsName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labGoodsID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSellPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGoodsInPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxUnit);
            this.groupBox1.Controls.Add(this.dtBirthday);
            this.groupBox1.Controls.Add(this.labDay);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(14, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 154);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "销售记录项";
            // 
            // cbxCustomerName
            // 
            this.cbxCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCustomerName.FormattingEnabled = true;
            this.cbxCustomerName.IntegralHeight = false;
            this.cbxCustomerName.Location = new System.Drawing.Point(82, 122);
            this.cbxCustomerName.Name = "cbxCustomerName";
            this.cbxCustomerName.Size = new System.Drawing.Size(126, 20);
            this.cbxCustomerName.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 126);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "客户姓名:";
            // 
            // cbxSellName
            // 
            this.cbxSellName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSellName.FormattingEnabled = true;
            this.cbxSellName.IntegralHeight = false;
            this.cbxSellName.Location = new System.Drawing.Point(93, 56);
            this.cbxSellName.Name = "cbxSellName";
            this.cbxSellName.Size = new System.Drawing.Size(141, 20);
            this.cbxSellName.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "销售员姓名:";
            // 
            // btnFindGoods
            // 
            this.btnFindGoods.Image = ((System.Drawing.Image)(resources.GetObject("btnFindGoods.Image")));
            this.btnFindGoods.Location = new System.Drawing.Point(410, 23);
            this.btnFindGoods.Name = "btnFindGoods";
            this.btnFindGoods.Size = new System.Drawing.Size(34, 23);
            this.btnFindGoods.TabIndex = 30;
            this.btnFindGoods.UseVisualStyleBackColor = true;
            this.btnFindGoods.Click += new System.EventHandler(this.btnFindGoods_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(621, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "元";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(470, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "元";
            // 
            // txtHasPay
            // 
            this.txtHasPay.Location = new System.Drawing.Point(557, 90);
            this.txtHasPay.Name = "txtHasPay";
            this.txtHasPay.Size = new System.Drawing.Size(64, 21);
            this.txtHasPay.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(492, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "实收金额:";
            // 
            // txtNeedPay
            // 
            this.txtNeedPay.Location = new System.Drawing.Point(398, 90);
            this.txtNeedPay.Name = "txtNeedPay";
            this.txtNeedPay.ReadOnly = true;
            this.txtNeedPay.Size = new System.Drawing.Size(72, 21);
            this.txtNeedPay.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(334, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "应收金额:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(312, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "元";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "元";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(318, 56);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(72, 21);
            this.txtNum.TabIndex = 20;
            this.txtNum.TextChanged += new System.EventHandler(this.txtNum_TextChanged);
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(240, 24);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.ReadOnly = true;
            this.txtGoodsName.Size = new System.Drawing.Size(169, 21);
            this.txtGoodsName.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "图书名称:";
            // 
            // labGoodsID
            // 
            this.labGoodsID.AutoSize = true;
            this.labGoodsID.ForeColor = System.Drawing.Color.Red;
            this.labGoodsID.Location = new System.Drawing.Point(80, 32);
            this.labGoodsID.Name = "labGoodsID";
            this.labGoodsID.Size = new System.Drawing.Size(0, 12);
            this.labGoodsID.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "销 售 ID:";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(273, 122);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(359, 21);
            this.txtRemark.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "  备  注 :";
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Location = new System.Drawing.Point(240, 90);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.ReadOnly = true;
            this.txtSellPrice.Size = new System.Drawing.Size(69, 21);
            this.txtSellPrice.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "销售价格:";
            // 
            // txtGoodsInPrice
            // 
            this.txtGoodsInPrice.Location = new System.Drawing.Point(80, 90);
            this.txtGoodsInPrice.Name = "txtGoodsInPrice";
            this.txtGoodsInPrice.ReadOnly = true;
            this.txtGoodsInPrice.Size = new System.Drawing.Size(75, 21);
            this.txtGoodsInPrice.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "进货价格:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "图书规格:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSellInfo);
            this.groupBox2.Location = new System.Drawing.Point(13, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 192);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "销售信息显示";
            // 
            // dgvSellInfo
            // 
            this.dgvSellInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSellInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvSellInfo.Name = "dgvSellInfo";
            this.dgvSellInfo.ReadOnly = true;
            this.dgvSellInfo.RowTemplate.Height = 20;
            this.dgvSellInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSellInfo.Size = new System.Drawing.Size(650, 172);
            this.dgvSellInfo.TabIndex = 0;
            this.dgvSellInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSellInfo_CellClick);
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
            this.toolStrip1.TabIndex = 18;
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
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "s";
            this.Text = "图书销售";
            this.Load += new System.EventHandler(this.SellGoods_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellInfo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxUnit;
        private System.Windows.Forms.DateTimePicker dtBirthday;
        private System.Windows.Forms.Label labDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHasPay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNeedPay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labGoodsID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGoodsInPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSellInfo;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.Button btnFindGoods;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbxSellName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxCustomerName;
        private System.Windows.Forms.Label label15;
    }
}