namespace GoodsReportManage.SysManage
{
    partial class SysUser
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("员工信息");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("供应商信息");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("客户档案");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("基本档案", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("采购进货");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("采购退货");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("进货管理", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("图书销售");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("客户退货");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("销售管理", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("库存调拨");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("库存报警");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("库存管理", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("系统用户");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("权限设置");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("数据备份");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("数据还原");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("系统维护", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labMessage = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxLogin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOkPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labMessage);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "待设置用户列表";
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(10, 191);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(0, 12);
            this.labMessage.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(7, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(116, 160);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(6, 20);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Tag = "2";
            treeNode1.Text = "员工信息";
            treeNode2.Name = "节点2";
            treeNode2.Tag = "3";
            treeNode2.Text = "供应商信息";
            treeNode3.Name = "节点0";
            treeNode3.Tag = "18";
            treeNode3.Text = "客户档案";
            treeNode4.Name = "节点0";
            treeNode4.Tag = "1";
            treeNode4.Text = "基本档案";
            treeNode5.Name = "节点6";
            treeNode5.Tag = "5";
            treeNode5.Text = "采购进货";
            treeNode6.Name = "节点7";
            treeNode6.Tag = "6";
            treeNode6.Text = "采购退货";
            treeNode7.Name = "节点5";
            treeNode7.Tag = "4";
            treeNode7.Text = "进货管理";
            treeNode8.Name = "节点9";
            treeNode8.Tag = "8";
            treeNode8.Text = "图书销售";
            treeNode9.Name = "节点10";
            treeNode9.Tag = "9";
            treeNode9.Text = "客户退货";
            treeNode10.Name = "节点8";
            treeNode10.Tag = "7";
            treeNode10.Text = "销售管理";
            treeNode11.Name = "节点12";
            treeNode11.Tag = "11";
            treeNode11.Text = "库存调拨";
            treeNode12.Name = "节点13";
            treeNode12.Tag = "12";
            treeNode12.Text = "库存报警";
            treeNode13.Name = "节点11";
            treeNode13.Tag = "10";
            treeNode13.Text = "库存管理";
            treeNode14.Name = "节点0";
            treeNode14.Text = "系统用户";
            treeNode15.Name = "节点2";
            treeNode15.Tag = "15";
            treeNode15.Text = "权限设置";
            treeNode16.Name = "节点3";
            treeNode16.Tag = "16";
            treeNode16.Text = "数据备份";
            treeNode17.Name = "节点5";
            treeNode17.Tag = "17";
            treeNode17.Text = "数据还原";
            treeNode18.Name = "节点0";
            treeNode18.Tag = "13";
            treeNode18.Text = "系统维护";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7,
            treeNode10,
            treeNode13,
            treeNode18});
            this.treeView1.Size = new System.Drawing.Size(127, 184);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(147, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 217);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "权限设置";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Location = new System.Drawing.Point(290, 178);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 51);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "执行操作";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "设置/修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(94, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxLogin);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtOkPwd);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtPwd);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(292, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 159);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "用户设置";
            // 
            // cbxLogin
            // 
            this.cbxLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLogin.FormattingEnabled = true;
            this.cbxLogin.Location = new System.Drawing.Point(78, 13);
            this.cbxLogin.Name = "cbxLogin";
            this.cbxLogin.Size = new System.Drawing.Size(82, 20);
            this.cbxLogin.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "登录身份:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "确认密码:";
            // 
            // txtOkPwd
            // 
            this.txtOkPwd.Location = new System.Drawing.Point(78, 132);
            this.txtOkPwd.Name = "txtOkPwd";
            this.txtOkPwd.PasswordChar = '*';
            this.txtOkPwd.ReadOnly = true;
            this.txtOkPwd.Size = new System.Drawing.Size(82, 21);
            this.txtOkPwd.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "密    码:";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(78, 105);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.ReadOnly = true;
            this.txtPwd.Size = new System.Drawing.Size(82, 21);
            this.txtPwd.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "用 户 名:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 59);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(82, 21);
            this.txtName.TabIndex = 3;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(30, 86);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "设置密码";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "设置登录名";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SysUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 239);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SysUser";
            this.Text = "设置系统用户";
            this.Load += new System.EventHandler(this.SysUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOkPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbxLogin;
        private System.Windows.Forms.Label labMessage;
    }
}