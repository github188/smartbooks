using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;　　　//添加引用
using GoodsReportManage.ItemClass;

namespace GoodsReportManage.CrystalReport
{
    public partial class EmployeeSellAnalysisReport : Form
    {
        public EmployeeSellAnalysisReport()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();

        private void btnOKfind_Click(object sender, EventArgs e)
        {
            string reportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
    Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            reportPath += @"\CrystalReport\ReportDoc\CrystalEmployeeSellAnalysisReportReport.rpt";   //获取报表路径
            ReportDocument doc = new ReportDocument();
            string P_Str_cmdtxt = "SELECT * FROM v_UserSell WHERE Sex LIKE '%" + this.txtEmployeeSex.Text + "%'";
            P_Str_cmdtxt += " AND GoodsID LIKE '%" + this.txtGoodsID.Text + "%' AND Name LIKE '%" + this.txtEmployeeName.Text + "%' AND SellID LIKE '%" + this.txtSellID.Text + "%'";
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