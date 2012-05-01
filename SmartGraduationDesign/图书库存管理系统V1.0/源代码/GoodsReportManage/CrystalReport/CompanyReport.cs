using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;  //ÃÌº”“˝”√

namespace GoodsReportManage.CrystalReport
{
    public partial class CompanyReport : Form
    {
        public CompanyReport()
        {
            InitializeComponent();
        }

        WinOperationClass G_OperationWinForm = new WinOperationClass();

        private void CompanyReport_Load(object sender, EventArgs e)
        {

        }

        private void btnFindOk_Click(object sender, EventArgs e)
        {
            string P_select = " {tb_Company.CompanyName} like '*"+this.txtName.Text+"*'";
            P_select += " and {tb_Company.CompanyDirector} like '*" + this.txtDirector.Text + "*'";
            P_select += " and {tb_Company.CompanyAddress} like '*" + this.txtAddress.Text + "*'";

            this.crystalReportViewer1.ReportSource = G_OperationWinForm.CrystalReports("CrystalCompanyReport.rpt", P_select);
        }
    }
}