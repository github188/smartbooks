namespace GoodsReportManage.Stock
{
    partial class ChangeGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeGoods));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxIn = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labOut = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labGoodsCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labGoodsID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvChangeInfo = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChangeInfo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbxIn);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labOut);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labGoodsCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtGoodsName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labGoodsID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(13, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库存调拨记录项";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(531, 54);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 21);
            this.txtNum.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "调动数量:";
            // 
            // cbxIn
            // 
            this.cbxIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIn.FormattingEnabled = true;
            this.cbxIn.Location = new System.Drawing.Point(273, 54);
            this.cbxIn.Name = "cbxIn";
            this.cbxIn.Size = new System.Drawing.Size(135, 20);
            this.cbxIn.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "调入仓库:";
            // 
            // labOut
            // 
            this.labOut.AutoSize = true;
            this.labOut.Location = new System.Drawing.Point(83, 57);
            this.labOut.Name = "labOut";
            this.labOut.Size = new System.Drawing.Size(0, 12);
            this.labOut.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "调出仓库:";
            // 
            // labGoodsCount
            // 
            this.labGoodsCount.AutoSize = true;
            this.labGoodsCount.ForeColor = System.Drawing.Color.Red;
            this.labGoodsCount.Location = new System.Drawing.Point(529, 21);
            this.labGoodsCount.Name = "labGoodsCount";
            this.labGoodsCount.Size = new System.Drawing.Size(0, 12);
            this.labGoodsCount.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "库存数量:";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(414, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(273, 18);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.ReadOnly = true;
            this.txtGoodsName.Size = new System.Drawing.Size(135, 21);
            this.txtGoodsName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "图书名称:";
            // 
            // labGoodsID
            // 
            this.labGoodsID.AutoSize = true;
            this.labGoodsID.ForeColor = System.Drawing.Color.Red;
            this.labGoodsID.Location = new System.Drawing.Point(83, 21);
            this.labGoodsID.Name = "labGoodsID";
            this.labGoodsID.Size = new System.Drawing.Size(0, 12);
            this.labGoodsID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "调 拨 ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvChangeInfo);
            this.groupBox2.Location = new System.Drawing.Point(13, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 300);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存调拨显示项";
            // 
            // dgvChangeInfo
            // 
            this.dgvChangeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChangeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChangeInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvChangeInfo.Name = "dgvChangeInfo";
            this.dgvChangeInfo.ReadOnly = true;
            this.dgvChangeInfo.RowTemplate.Height = 20;
            this.dgvChangeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChangeInfo.Size = new System.Drawing.Size(656, 280);
            this.dgvChangeInfo.TabIndex = 0;
            this.dgvChangeInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChangeInfo_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolAdd,
            this.toolDelete,
            this.toolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 21;
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
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click_1);
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
            this.toolCancel.Click += new System.EventHandler(this.toolCancel_Click_1);
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
            // ChangeGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 436);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChangeGoods";
            this.Text = "库存调拨";
            this.Load += new System.EventHandler(this.ChangeGoods_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChangeInfo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labGoodsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labGoodsID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxIn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvChangeInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.Timer timer1;
    }
}