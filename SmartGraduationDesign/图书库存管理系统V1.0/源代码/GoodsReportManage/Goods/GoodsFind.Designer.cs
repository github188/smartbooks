namespace GoodsReportManage.Goods
{
    partial class GoodsFind
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGoodsID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGoodsFindInfo = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labRMoney = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labHasPay = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labGoodsPrice = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labGoodsSpec = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labNum = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labGoodsName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labGoodsID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCfind = new System.Windows.Forms.Button();
            this.btnSfind = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsFindInfo)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 73);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "采购类型";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(23, 45);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(95, 16);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Text = "采购退货查询";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(23, 23);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(95, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "采购进货查询";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtEndTime);
            this.groupBox3.Controls.Add(this.dtStartTime);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtGoodsName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtGoodsID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(166, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 73);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // dtEndTime
            // 
            this.dtEndTime.Location = new System.Drawing.Point(269, 43);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(115, 21);
            this.dtEndTime.TabIndex = 7;
            // 
            // dtStartTime
            // 
            this.dtStartTime.Location = new System.Drawing.Point(75, 46);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(114, 21);
            this.dtStartTime.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "结束时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "起始时间:";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(269, 18);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.Size = new System.Drawing.Size(115, 21);
            this.txtGoodsName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "图书名称:";
            // 
            // txtGoodsID
            // 
            this.txtGoodsID.Location = new System.Drawing.Point(76, 18);
            this.txtGoodsID.Name = "txtGoodsID";
            this.txtGoodsID.Size = new System.Drawing.Size(113, 21);
            this.txtGoodsID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商 品 ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGoodsFindInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 303);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询结果显示";
            // 
            // dgvGoodsFindInfo
            // 
            this.dgvGoodsFindInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsFindInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoodsFindInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvGoodsFindInfo.Name = "dgvGoodsFindInfo";
            this.dgvGoodsFindInfo.ReadOnly = true;
            this.dgvGoodsFindInfo.RowTemplate.Height = 20;
            this.dgvGoodsFindInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoodsFindInfo.Size = new System.Drawing.Size(436, 283);
            this.dgvGoodsFindInfo.TabIndex = 1;
            this.dgvGoodsFindInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoodsFindInfo_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.labRMoney);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.labHasPay);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.labGoodsPrice);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.labGoodsSpec);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.labNum);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.labGoodsName);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.labGoodsID);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(460, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(215, 303);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "图书信息显示";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(155, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "元";
            // 
            // labRMoney
            // 
            this.labRMoney.AutoSize = true;
            this.labRMoney.Location = new System.Drawing.Point(104, 197);
            this.labRMoney.Name = "labRMoney";
            this.labRMoney.Size = new System.Drawing.Size(0, 12);
            this.labRMoney.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "应付金额:";
            // 
            // label12
            // 
            this.label12.AutoEllipsis = true;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-3, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 12);
            this.label12.TabIndex = 16;
            // 
            // labHasPay
            // 
            this.labHasPay.AutoSize = true;
            this.labHasPay.Location = new System.Drawing.Point(104, 224);
            this.labHasPay.Name = "labHasPay";
            this.labHasPay.Size = new System.Drawing.Size(0, 12);
            this.labHasPay.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "实付金额:";
            // 
            // labGoodsPrice
            // 
            this.labGoodsPrice.AutoSize = true;
            this.labGoodsPrice.ForeColor = System.Drawing.Color.Red;
            this.labGoodsPrice.Location = new System.Drawing.Point(104, 168);
            this.labGoodsPrice.Name = "labGoodsPrice";
            this.labGoodsPrice.Size = new System.Drawing.Size(0, 12);
            this.labGoodsPrice.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(41, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 11;
            this.label17.Text = "图书价格:";
            // 
            // labGoodsSpec
            // 
            this.labGoodsSpec.AutoSize = true;
            this.labGoodsSpec.Location = new System.Drawing.Point(104, 141);
            this.labGoodsSpec.Name = "labGoodsSpec";
            this.labGoodsSpec.Size = new System.Drawing.Size(0, 12);
            this.labGoodsSpec.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "图书规格:";
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Location = new System.Drawing.Point(104, 113);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(0, 12);
            this.labNum.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "图书数量:";
            // 
            // labGoodsName
            // 
            this.labGoodsName.AutoSize = true;
            this.labGoodsName.ForeColor = System.Drawing.Color.Red;
            this.labGoodsName.Location = new System.Drawing.Point(104, 86);
            this.labGoodsName.Name = "labGoodsName";
            this.labGoodsName.Size = new System.Drawing.Size(0, 12);
            this.labGoodsName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "图书名称:";
            // 
            // labGoodsID
            // 
            this.labGoodsID.AutoSize = true;
            this.labGoodsID.Location = new System.Drawing.Point(104, 59);
            this.labGoodsID.Name = "labGoodsID";
            this.labGoodsID.Size = new System.Drawing.Size(0, 12);
            this.labGoodsID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "商 品 ID:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCfind);
            this.groupBox5.Controls.Add(this.btnSfind);
            this.groupBox5.Location = new System.Drawing.Point(565, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(110, 73);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "操作区";
            // 
            // btnCfind
            // 
            this.btnCfind.Location = new System.Drawing.Point(17, 43);
            this.btnCfind.Name = "btnCfind";
            this.btnCfind.Size = new System.Drawing.Size(75, 23);
            this.btnCfind.TabIndex = 1;
            this.btnCfind.Text = "取消查询";
            this.btnCfind.UseVisualStyleBackColor = true;
            this.btnCfind.Click += new System.EventHandler(this.btnCfind_Click);
            // 
            // btnSfind
            // 
            this.btnSfind.Location = new System.Drawing.Point(17, 16);
            this.btnSfind.Name = "btnSfind";
            this.btnSfind.Size = new System.Drawing.Size(75, 23);
            this.btnSfind.TabIndex = 0;
            this.btnSfind.Text = "开始查询";
            this.btnSfind.UseVisualStyleBackColor = true;
            this.btnSfind.Click += new System.EventHandler(this.btnSfind_Click);
            // 
            // GoodsFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 416);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GoodsFind";
            this.Text = "采购查询";
            this.Load += new System.EventHandler(this.GoodsFind_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsFindInfo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtGoodsID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvGoodsFindInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labGoodsName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labGoodsID;
        private System.Windows.Forms.Label labGoodsSpec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labRMoney;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labHasPay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labGoodsPrice;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCfind;
        private System.Windows.Forms.Button btnSfind;
    }
}