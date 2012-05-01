namespace GoodsReportManage.SysManage
{
    partial class SetPopedom
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户列表";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(7, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(94, 184);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(125, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 217);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "权限设置";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(7, 20);
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
            this.treeView1.Size = new System.Drawing.Size(137, 184);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(39, 235);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(186, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(105, 235);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除用户";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // SetPopedom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 271);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SetPopedom";
            this.Text = "用户权限";
            this.Load += new System.EventHandler(this.SetPopedom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
    }
}