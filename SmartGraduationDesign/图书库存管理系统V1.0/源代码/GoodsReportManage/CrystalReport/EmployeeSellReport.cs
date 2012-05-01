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
    public partial class EmployeeSellReport : Form
    {
        public EmployeeSellReport()
        {
            InitializeComponent();
        }

        WinOperationClass G_OperationWinForm = new WinOperationClass();

        private void EmployeeSellReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string P_select = " {v_UserSell.Name} like '*" + this.txtEmployeeName.Text + "*'";
            P_select += " and {v_UserSell.Sex} like '*" + this.txtEmployeeSex.Text + "*'";
            P_select += " and {v_UserSell.GoodsID} like '*" + this.txtGoodsID.Text + "*'";
            P_select += " and {v_UserSell.SellID} like '*" + this.txtSellID.Text + "*'"; 

            this.crystalReportViewer1.ReportSource = G_OperationWinForm.CrystalReports("CrystalEmployeeSellReport.rpt", P_select);
        }

    }
}