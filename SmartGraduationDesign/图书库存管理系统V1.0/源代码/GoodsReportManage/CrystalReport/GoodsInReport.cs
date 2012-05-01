using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;   //添加引用
using GoodsReportManage.CrystalReport.ReportDoc;
using CrystalDecisions.CrystalReports.Engine;

namespace GoodsReportManage.CrystalReport
{
    public partial class GoodsInReport : Form
    {
        public GoodsInReport()
        {
            InitializeComponent();
        }

        WinOperationClass G_OperationWinForm = new WinOperationClass();   //声明类对象
        SqlBaseClass G_SqlClass = new SqlBaseClass();

        private void GoodsInReport_Load(object sender, EventArgs e)
        {

        }

        private void btnOkFind_Click(object sender, EventArgs e)
        {
            string reportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            reportPath += @"\CrystalReport\ReportDoc\CrystalGoodsInReport.rpt";   //获取报表路径
            ReportDocument doc = new ReportDocument();
            string P_Str_cmdtxt = "SELECT * FROM v_GoodsIn WHERE GoodsID LIKE '%" + this.txtGoodsID.Text + "%'";
            P_Str_cmdtxt += " AND GoodsName LIKE '%"+this.txtGoodsName.Text+"%' AND Name LIKE '%"+this.txtEmployeeName.Text+"%'";
            if (this.checkBox1.Checked)
            {
                P_Str_cmdtxt += "AND GoodsTime BETWEEN '" + this.dtStartTime.Value.ToString("yyyy-MM-dd") + "' AND '" + this.dtEndTime.Value.ToString("yyyy-MM-dd") + "'";
            }
            DataSet P_ds = G_SqlClass.GetDs(P_Str_cmdtxt);

            doc.Load(reportPath);
            doc.SetDataSource(P_ds.Tables[0].DefaultView);
            this.crystalReportViewer1.ReportSource = doc;
        }
    }
}