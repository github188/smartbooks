using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using GoodsReportManage.ItemClass;


namespace GoodsReportManage.CrystalReport
{
    public partial class SellGoodsAnalysisReport : Form
    {
        public SellGoodsAnalysisReport()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();

        private void btnOkFind_Click(object sender, EventArgs e)
        {
            string reportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            reportPath += @"\CrystalReport\ReportDoc\CrystalSellAnalysisReport.rpt";   //获取报表路径
            ReportDocument doc = new ReportDocument();
            string P_Str_cmdtxt = "SELECT * FROM v_UserSell WHERE SellID LIKE '%" + this.txtGoodsID.Text + "%'";
            P_Str_cmdtxt += " AND GoodsName LIKE '%" + this.txtGoodsName.Text + "%' AND Name LIKE '%" + this.txtEmployeeName.Text + "%'";
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