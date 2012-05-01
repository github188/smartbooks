namespace GoodsReportManage.Stock
{
    partial class StockAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockAlarm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAllInfo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labGoodsPrice = new System.Windows.Forms.Label();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.txtAlarmNum = new System.Windows.Forms.TextBox();
            this.labAlarmNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labGoodsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labGoodsID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolAmend,
            this.toolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 24;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAllInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 295);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存报警记录显示";
            // 
            // dgvAllInfo
            // 
            this.dgvAllInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvAllInfo.Name = "dgvAllInfo";
            this.dgvAllInfo.ReadOnly = true;
            this.dgvAllInfo.RowTemplate.Height = 23;
            this.dgvAllInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllInfo.Size = new System.Drawing.Size(657, 275);
            this.dgvAllInfo.TabIndex = 0;
            this.dgvAllInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllInfo_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSellPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labGoodsPrice);
            this.groupBox1.Controls.Add(this.txtSpec);
            this.groupBox1.Controls.Add(this.txtAlarmNum);
            this.groupBox1.Controls.Add(this.labAlarmNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labGoodsCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGoodsName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labGoodsID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 91);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库存报警记录项";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(431, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 50;
            this.label9.Text = "元";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(286, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "元";
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Location = new System.Drawing.Point(371, 52);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.ReadOnly = true;
            this.txtSellPrice.Size = new System.Drawing.Size(58, 21);
            this.txtSellPrice.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "销售价格:";
            // 
            // labGoodsPrice
            // 
            this.labGoodsPrice.AutoSize = true;
            this.labGoodsPrice.ForeColor = System.Drawing.Color.Red;
            this.labGoodsPrice.Location = new System.Drawing.Point(248, 61);
            this.labGoodsPrice.Name = "labGoodsPrice";
            this.labGoodsPrice.Size = new System.Drawing.Size(0, 12);
            this.labGoodsPrice.TabIndex = 46;
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(96, 55);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.ReadOnly = true;
            this.txtSpec.Size = new System.Drawing.Size(87, 21);
            this.txtSpec.TabIndex = 45;
            // 
            // txtAlarmNum
            // 
            this.txtAlarmNum.Location = new System.Drawing.Point(541, 52);
            this.txtAlarmNum.Name = "txtAlarmNum";
            this.txtAlarmNum.ReadOnly = true;
            this.txtAlarmNum.Size = new System.Drawing.Size(87, 21);
            this.txtAlarmNum.TabIndex = 44;
            // 
            // labAlarmNum
            // 
            this.labAlarmNum.AutoSize = true;
            this.labAlarmNum.Location = new System.Drawing.Point(476, 59);
            this.labAlarmNum.Name = "labAlarmNum";
            this.labAlarmNum.Size = new System.Drawing.Size(59, 12);
            this.labAlarmNum.TabIndex = 43;
            this.labAlarmNum.Text = "报警数量:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "进货价格:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "图书规格:";
            // 
            // labGoodsCount
            // 
            this.labGoodsCount.AutoSize = true;
            this.labGoodsCount.ForeColor = System.Drawing.Color.Red;
            this.labGoodsCount.Location = new System.Drawing.Point(541, 27);
            this.labGoodsCount.Name = "labGoodsCount";
            this.labGoodsCount.Size = new System.Drawing.Size(0, 12);
            this.labGoodsCount.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "库存数量:";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(255, 20);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.ReadOnly = true;
            this.txtGoodsName.Size = new System.Drawing.Size(193, 21);
            this.txtGoodsName.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "图书名称:";
            // 
            // labGoodsID
            // 
            this.labGoodsID.AutoSize = true;
            this.labGoodsID.Location = new System.Drawing.Point(95, 28);
            this.labGoodsID.Name = "labGoodsID";
            this.labGoodsID.Size = new System.Drawing.Size(0, 12);
            this.labGoodsID.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "商 品 ID:";
            // 
            // StockAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StockAlarm";
            this.Text = "库存警报";
            this.Load += new System.EventHandler(this.StockAlarm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAllInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAlarmNum;
        private System.Windows.Forms.Label labAlarmNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labGoodsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labGoodsID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labGoodsPrice;


    }
}