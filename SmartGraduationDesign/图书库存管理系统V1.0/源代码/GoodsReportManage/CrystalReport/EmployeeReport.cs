using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;  //�������
using CrystalDecisions.Shared;
using GoodsReportManage.ItemClass;


namespace GoodsReportManage.CrystalReport
{
    public partial class EmployeeReport : Form
    {
        public EmployeeReport()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();  //�������ݿ���������
        WinOperationClass G_OperationForm = new WinOperationClass();

        private void EmployeeReport_Load(object sender, EventArgs e)
        {
            G_OperationForm.BindComboBox("SELECT * FROM tb_Post", cbxPost, "PostName");  //��ComboBox�ؼ�
            G_OperationForm.BindComboBox("SELECT * FROM tb_Department", cbxDepName, "DepName");

            this.cbxSex.SelectedIndex = 0;  //�趨Ĭ����
        }

        private void btnFindOk_Click(object sender, EventArgs e)
        {
            //Ϊ�����趨��ѯ���
            string P_selectionFormula = "{tb_User.Name} like "
                + "'*" + this.txtName.Text + "*' and {tb_User.Sex}='" + this.cbxSex.Items[this.cbxSex.SelectedIndex].ToString() + "'";
            P_selectionFormula += " and {tb_User.Post}='" + this.cbxPost.SelectedValue.ToString();
            P_selectionFormula += "' and {tb_User.Department}='" + this.cbxDepName.SelectedValue.ToString() + "'";

            this.crystalReportViewer1.ReportSource = G_OperationForm.CrystalReports("CrystalEmployeeReport.rpt",P_selectionFormula); ;  //��ʾ���������ı�����Ϣ
        }

    }
}