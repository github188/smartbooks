namespace GoodsReportManage
{
    partial class Login
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
            this.errAllInfo = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.labPwd = new System.Windows.Forms.Label();
            this.cbxDegree = new System.Windows.Forms.ComboBox();
            this.labDegree = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errAllInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errAllInfo
            // 
            this.errAllInfo.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.labPwd);
            this.groupBox1.Controls.Add(this.cbxDegree);
            this.groupBox1.Controls.Add(this.labDegree);
            this.groupBox1.Controls.Add(this.txtUid);
            this.groupBox1.Controls.Add(this.labName);
            this.groupBox1.Location = new System.Drawing.Point(24, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 161);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户登录";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(132, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(43, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(107, 81);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(99, 21);
            this.txtPwd.TabIndex = 11;
            // 
            // labPwd
            // 
            this.labPwd.AutoSize = true;
            this.labPwd.Location = new System.Drawing.Point(44, 87);
            this.labPwd.Name = "labPwd";
            this.labPwd.Size = new System.Drawing.Size(59, 12);
            this.labPwd.TabIndex = 10;
            this.labPwd.Text = "密    码:";
            // 
            // cbxDegree
            // 
            this.cbxDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDegree.FormattingEnabled = true;
            this.cbxDegree.Location = new System.Drawing.Point(107, 52);
            this.cbxDegree.Name = "cbxDegree";
            this.cbxDegree.Size = new System.Drawing.Size(100, 20);
            this.cbxDegree.TabIndex = 9;
            // 
            // labDegree
            // 
            this.labDegree.AutoSize = true;
            this.labDegree.Location = new System.Drawing.Point(42, 56);
            this.labDegree.Name = "labDegree";
            this.labDegree.Size = new System.Drawing.Size(59, 12);
            this.labDegree.TabIndex = 8;
            this.labDegree.Text = "登录身份:";
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(107, 22);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(100, 21);
            this.txtUid.TabIndex = 7;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(42, 28);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(59, 12);
            this.labName.TabIndex = 6;
            this.labName.Text = "用 户 名:";
            // 
            // Login
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(305, 196);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errAllInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errAllInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label labPwd;
        private System.Windows.Forms.ComboBox cbxDegree;
        private System.Windows.Forms.Label labDegree;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}

