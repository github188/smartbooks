﻿namespace GoodsReportManage
{
    partial class AppMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuBaseManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStockManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGoodsIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGoodsOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSellManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSellGoods = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGoodsBack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSellFind = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDepotManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDepotChange = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDepotAlarm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDepotFind = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmployeeReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompanyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStockReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSEmployeeReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.进货分析报表JToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.销售分析报表OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.员工销售分析报表XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSysManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSysUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPopedomSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDatabak = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReBakData = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statuslabMenuInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBaseManage,
            this.menuStockManage,
            this.menuSellManage,
            this.menuDepotManage,
            this.menuReportManage,
            this.menuSysManage});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuBaseManage
            // 
            this.menuBaseManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEmployee,
            this.menuCompany,
            this.menuCustomer,
            this.toolStripMenuItem1,
            this.menuLogin});
            this.menuBaseManage.Name = "menuBaseManage";
            this.menuBaseManage.Size = new System.Drawing.Size(83, 20);
            this.menuBaseManage.Text = "基本档案[&B]";
            // 
            // menuEmployee
            // 
            this.menuEmployee.Name = "menuEmployee";
            this.menuEmployee.Size = new System.Drawing.Size(148, 22);
            this.menuEmployee.Tag = "1";
            this.menuEmployee.Text = "员工信息[&E]";
            this.menuEmployee.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuCompany
            // 
            this.menuCompany.Name = "menuCompany";
            this.menuCompany.Size = new System.Drawing.Size(148, 22);
            this.menuCompany.Tag = "2";
            this.menuCompany.Text = "供应商信息[&C]";
            this.menuCompany.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuCustomer
            // 
            this.menuCustomer.Name = "menuCustomer";
            this.menuCustomer.Size = new System.Drawing.Size(148, 22);
            this.menuCustomer.Tag = "30";
            this.menuCustomer.Text = "客户档案[&K]";
            this.menuCustomer.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // menuLogin
            // 
            this.menuLogin.Name = "menuLogin";
            this.menuLogin.Size = new System.Drawing.Size(148, 22);
            this.menuLogin.Tag = "3";
            this.menuLogin.Text = "用户登录[&L]";
            this.menuLogin.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuStockManage
            // 
            this.menuStockManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGoodsIn,
            this.menuGoodsOut,
            this.toolStripMenuItem2,
            this.menuFind});
            this.menuStockManage.Name = "menuStockManage";
            this.menuStockManage.Size = new System.Drawing.Size(83, 20);
            this.menuStockManage.Text = "进货管理[&C]";
            // 
            // menuGoodsIn
            // 
            this.menuGoodsIn.Name = "menuGoodsIn";
            this.menuGoodsIn.Size = new System.Drawing.Size(136, 22);
            this.menuGoodsIn.Tag = "5";
            this.menuGoodsIn.Text = "采购进货[&S]";
            this.menuGoodsIn.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuGoodsOut
            // 
            this.menuGoodsOut.Name = "menuGoodsOut";
            this.menuGoodsOut.Size = new System.Drawing.Size(136, 22);
            this.menuGoodsOut.Tag = "6";
            this.menuGoodsOut.Text = "采购退货[&E]";
            this.menuGoodsOut.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
            // 
            // menuFind
            // 
            this.menuFind.Name = "menuFind";
            this.menuFind.Size = new System.Drawing.Size(136, 22);
            this.menuFind.Tag = "7";
            this.menuFind.Text = "采购查询[&F]";
            this.menuFind.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuSellManage
            // 
            this.menuSellManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSellGoods,
            this.menuGoodsBack,
            this.toolStripMenuItem3,
            this.menuSellFind});
            this.menuSellManage.Name = "menuSellManage";
            this.menuSellManage.Size = new System.Drawing.Size(83, 20);
            this.menuSellManage.Text = "销售管理[&S]";
            // 
            // menuSellGoods
            // 
            this.menuSellGoods.Name = "menuSellGoods";
            this.menuSellGoods.Size = new System.Drawing.Size(136, 22);
            this.menuSellGoods.Tag = "8";
            this.menuSellGoods.Text = "图书销售[&G]";
            this.menuSellGoods.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuGoodsBack
            // 
            this.menuGoodsBack.Name = "menuGoodsBack";
            this.menuGoodsBack.Size = new System.Drawing.Size(136, 22);
            this.menuGoodsBack.Tag = "9";
            this.menuGoodsBack.Text = "客户退货[&E]";
            this.menuGoodsBack.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 6);
            // 
            // menuSellFind
            // 
            this.menuSellFind.Name = "menuSellFind";
            this.menuSellFind.Size = new System.Drawing.Size(136, 22);
            this.menuSellFind.Tag = "10";
            this.menuSellFind.Text = "销售查询[&F]";
            this.menuSellFind.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuDepotManage
            // 
            this.menuDepotManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDepotChange,
            this.menuDepotAlarm,
            this.toolStripMenuItem4,
            this.menuDepotFind});
            this.menuDepotManage.Name = "menuDepotManage";
            this.menuDepotManage.Size = new System.Drawing.Size(83, 20);
            this.menuDepotManage.Text = "库存管理[&D]";
            // 
            // menuDepotChange
            // 
            this.menuDepotChange.Name = "menuDepotChange";
            this.menuDepotChange.Size = new System.Drawing.Size(136, 22);
            this.menuDepotChange.Tag = "11";
            this.menuDepotChange.Text = "库存调拨[&B]";
            this.menuDepotChange.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuDepotAlarm
            // 
            this.menuDepotAlarm.Name = "menuDepotAlarm";
            this.menuDepotAlarm.Size = new System.Drawing.Size(136, 22);
            this.menuDepotAlarm.Tag = "12";
            this.menuDepotAlarm.Text = "库存报警[&J]";
            this.menuDepotAlarm.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(133, 6);
            // 
            // menuDepotFind
            // 
            this.menuDepotFind.Name = "menuDepotFind";
            this.menuDepotFind.Size = new System.Drawing.Size(136, 22);
            this.menuDepotFind.Tag = "13";
            this.menuDepotFind.Text = "库存查询[&C]";
            this.menuDepotFind.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuReportManage
            // 
            this.menuReportManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEmployeeReport,
            this.menuCompanyReport,
            this.toolStripMenuItem7,
            this.menuStockReport,
            this.menuSEmployeeReport,
            this.toolStripMenuItem6,
            this.进货分析报表JToolStripMenuItem,
            this.销售分析报表OToolStripMenuItem,
            this.员工销售分析报表XToolStripMenuItem});
            this.menuReportManage.Name = "menuReportManage";
            this.menuReportManage.Size = new System.Drawing.Size(83, 20);
            this.menuReportManage.Text = "报表设计[&J]";
            // 
            // menuEmployeeReport
            // 
            this.menuEmployeeReport.Name = "menuEmployeeReport";
            this.menuEmployeeReport.Size = new System.Drawing.Size(184, 22);
            this.menuEmployeeReport.Tag = "14";
            this.menuEmployeeReport.Text = "员工信息报表[&E]";
            this.menuEmployeeReport.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuCompanyReport
            // 
            this.menuCompanyReport.Name = "menuCompanyReport";
            this.menuCompanyReport.Size = new System.Drawing.Size(184, 22);
            this.menuCompanyReport.Tag = "15";
            this.menuCompanyReport.Text = "供应商信息报表[&W]";
            this.menuCompanyReport.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(181, 6);
            // 
            // menuStockReport
            // 
            this.menuStockReport.Name = "menuStockReport";
            this.menuStockReport.Size = new System.Drawing.Size(184, 22);
            this.menuStockReport.Tag = "16";
            this.menuStockReport.Text = "进货图书报表[&S]";
            this.menuStockReport.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuSEmployeeReport
            // 
            this.menuSEmployeeReport.Name = "menuSEmployeeReport";
            this.menuSEmployeeReport.Size = new System.Drawing.Size(184, 22);
            this.menuSEmployeeReport.Tag = "18";
            this.menuSEmployeeReport.Text = "员工销售报表[&B]";
            this.menuSEmployeeReport.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(181, 6);
            // 
            // 进货分析报表JToolStripMenuItem
            // 
            this.进货分析报表JToolStripMenuItem.Name = "进货分析报表JToolStripMenuItem";
            this.进货分析报表JToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.进货分析报表JToolStripMenuItem.Tag = "19";
            this.进货分析报表JToolStripMenuItem.Text = "图书进货分析报表[&J]";
            this.进货分析报表JToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            // 
            // 销售分析报表OToolStripMenuItem
            // 
            this.销售分析报表OToolStripMenuItem.Name = "销售分析报表OToolStripMenuItem";
            this.销售分析报表OToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.销售分析报表OToolStripMenuItem.Tag = "20";
            this.销售分析报表OToolStripMenuItem.Text = "销售价格分析报表[&O]";
            this.销售分析报表OToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            // 
            // 员工销售分析报表XToolStripMenuItem
            // 
            this.员工销售分析报表XToolStripMenuItem.Name = "员工销售分析报表XToolStripMenuItem";
            this.员工销售分析报表XToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.员工销售分析报表XToolStripMenuItem.Tag = "31";
            this.员工销售分析报表XToolStripMenuItem.Text = "员工销售分析报表[&X]";
            this.员工销售分析报表XToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuSysManage
            // 
            this.menuSysManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSysUser,
            this.menuPopedomSet,
            this.menuChangePwd,
            this.toolStripMenuItem5,
            this.menuDatabak,
            this.menuReBakData});
            this.menuSysManage.Name = "menuSysManage";
            this.menuSysManage.Size = new System.Drawing.Size(83, 20);
            this.menuSysManage.Text = "系统维护[&W]";
            // 
            // menuSysUser
            // 
            this.menuSysUser.Name = "menuSysUser";
            this.menuSysUser.Size = new System.Drawing.Size(136, 22);
            this.menuSysUser.Tag = "25";
            this.menuSysUser.Text = "系统用户[&S]";
            this.menuSysUser.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuPopedomSet
            // 
            this.menuPopedomSet.Name = "menuPopedomSet";
            this.menuPopedomSet.Size = new System.Drawing.Size(136, 22);
            this.menuPopedomSet.Tag = "21";
            this.menuPopedomSet.Text = "权限设置[&Q]";
            this.menuPopedomSet.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuChangePwd
            // 
            this.menuChangePwd.Name = "menuChangePwd";
            this.menuChangePwd.Size = new System.Drawing.Size(136, 22);
            this.menuChangePwd.Tag = "22";
            this.menuChangePwd.Text = "更改密码[&C]";
            this.menuChangePwd.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(133, 6);
            // 
            // menuDatabak
            // 
            this.menuDatabak.Name = "menuDatabak";
            this.menuDatabak.Size = new System.Drawing.Size(136, 22);
            this.menuDatabak.Tag = "23";
            this.menuDatabak.Text = "数据备份[&B]";
            this.menuDatabak.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuReBakData
            // 
            this.menuReBakData.Name = "menuReBakData";
            this.menuReBakData.Size = new System.Drawing.Size(136, 22);
            this.menuReBakData.Tag = "24";
            this.menuReBakData.Text = "数据还原[&R]";
            this.menuReBakData.Click += new System.EventHandler(this.Menu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(195)))), ((int)(((byte)(230)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslabMenuInfo,
            this.toolStripStatusLabel1,
            this.statusUser,
            this.toolStripStatusLabel2,
            this.statusTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuslabMenuInfo
            // 
            this.statuslabMenuInfo.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statuslabMenuInfo.Name = "statuslabMenuInfo";
            this.statuslabMenuInfo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.statuslabMenuInfo.Size = new System.Drawing.Size(285, 17);
            this.statuslabMenuInfo.Spring = true;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // statusUser
            // 
            this.statusUser.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.statusUser.Name = "statusUser";
            this.statusUser.Size = new System.Drawing.Size(285, 17);
            this.statusUser.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // statusTime
            // 
            this.statusTime.Name = "statusTime";
            this.statusTime.Size = new System.Drawing.Size(285, 17);
            this.statusTime.Spring = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AppMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(892, 563);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AppMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图书库存管理系统V1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppMain_FormClosed);
            this.Load += new System.EventHandler(this.AppMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem menuBaseManage;
        private System.Windows.Forms.ToolStripStatusLabel statuslabMenuInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusUser;
        private System.Windows.Forms.ToolStripStatusLabel statusTime;
        private System.Windows.Forms.ToolStripMenuItem menuEmployee;
        private System.Windows.Forms.ToolStripMenuItem menuCompany;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuLogin;
        private System.Windows.Forms.ToolStripMenuItem menuStockManage;
        private System.Windows.Forms.ToolStripMenuItem menuGoodsIn;
        private System.Windows.Forms.ToolStripMenuItem menuGoodsOut;
        private System.Windows.Forms.ToolStripMenuItem menuFind;
        private System.Windows.Forms.ToolStripMenuItem menuSellManage;
        private System.Windows.Forms.ToolStripMenuItem menuSellGoods;
        private System.Windows.Forms.ToolStripMenuItem menuGoodsBack;
        private System.Windows.Forms.ToolStripMenuItem menuSellFind;
        private System.Windows.Forms.ToolStripMenuItem menuDepotManage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuDepotChange;
        private System.Windows.Forms.ToolStripMenuItem menuDepotAlarm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuDepotFind;
        private System.Windows.Forms.ToolStripMenuItem menuReportManage;
        private System.Windows.Forms.ToolStripMenuItem menuEmployeeReport;
        private System.Windows.Forms.ToolStripMenuItem menuCompanyReport;
        private System.Windows.Forms.ToolStripMenuItem menuStockReport;
        private System.Windows.Forms.ToolStripMenuItem menuSEmployeeReport;
        private System.Windows.Forms.ToolStripMenuItem menuSysManage;
        private System.Windows.Forms.ToolStripMenuItem menuPopedomSet;
        private System.Windows.Forms.ToolStripMenuItem menuChangePwd;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuDatabak;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem menuReBakData;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem 进货分析报表JToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 销售分析报表OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuSysUser;
        private System.Windows.Forms.ToolStripMenuItem 员工销售分析报表XToolStripMenuItem;
    }
}