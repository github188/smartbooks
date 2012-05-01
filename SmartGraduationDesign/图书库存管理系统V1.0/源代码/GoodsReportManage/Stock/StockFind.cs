using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;  //�������

namespace GoodsReportManage.Stock
{
    public partial class StockFind : Form
    {
        public StockFind()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();

        /// <summary>
        /// �ڿؼ������ѡ�е�DataGridView�ؼ�������
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.labGoodsID.Text = this.dgvStockInfo[1, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsName.Text = this.dgvStockInfo[2, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsSpec.Text = this.dgvStockInfo[9, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labNum.Text = this.dgvStockInfo[5, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labRMoney.Text = this.dgvStockInfo[12, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsPrice.Text = this.dgvStockInfo[10, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labHasPay.Text = this.dgvStockInfo[13, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labAlarmNum.Text = this.dgvStockInfo[6, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            }
            catch { }
        }


        private void StockFind_Load(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = "SELECT StockID as ���ID,GoodsID as ͼ��ID,GoodsName as ͼ������,DepotName as �ֿ�����";
            P_Str_cmdtxt += ",CompanyName as ��Ӧ������,StockNum as �������,AlarmNum as ��������,GoodsUnit as ͼ�鵥λ";
            P_Str_cmdtxt +=",GoodsTime as ����ʱ��,GoodsSpec as ͼ����,GoodsPrice as �����۸�,SellPrice as ���ۼ۸�";
            P_Str_cmdtxt +=",NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Stock" ;
            this.dgvStockInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            this.cbxCondition1.SelectedIndex = 0;
            this.cbxCondition2.SelectedIndex = 0;
            this.dgvStockInfo.Columns[0].Visible = false;
        }

        private void btnFindOK_Click(object sender, EventArgs e)
        {
            string P_Str_select = " WHERE GoodsName LIKE '%" + this.txtGoodsName.Text + "%' AND GoodsID LIKE '%" + this.txtGoodsID.Text + "%'";
            P_Str_select += "AND StockNum LIKE '%" + this.txtStockNum.Text + "%' AND AlarmNum LIKE '%" + this.txtAlarmNum.Text + "%'";
            if (this.txtGoodsPrice.Text != "" )
            {
                P_Str_select +=" AND GoodsPrice " + this.cbxCondition1.Items[this.cbxCondition1.SelectedIndex].ToString() + this.txtGoodsPrice.Text + "";
            }
            if(this.txtSellPrice.Text!="")
            {
                P_Str_select += "AND SellPrice " + this.cbxCondition2.Items[this.cbxCondition2.SelectedIndex].ToString() + this.txtSellPrice.Text + "";
            }
            string P_Str_cmdtxt = "SELECT StockID as ���ID,GoodsID as ͼ��ID,GoodsName as ͼ������,DepotName as �ֿ�����";
            P_Str_cmdtxt += ",CompanyName as ��Ӧ������,StockNum as �������,AlarmNum as ��������,GoodsUnit as ͼ�鵥λ";
            P_Str_cmdtxt += ",GoodsTime as ����ʱ��,GoodsSpec as ͼ����,GoodsPrice as �����۸�,SellPrice as ���ۼ۸�";
            P_Str_cmdtxt += ",NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Stock "+P_Str_select;
            this.dgvStockInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtAlarmNum.Text = "";
            this.txtGoodsID.Text = "";
            this.txtGoodsName.Text = "";
            this.txtGoodsPrice.Text = "";
            this.txtSellPrice.Text = "";
            this.txtStockNum.Text = "";
            StockFind_Load(sender, e);
        }

        private void dgvStockInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void dgvStockInfo_DoubleClick(object sender, EventArgs e)
        {
            PropertyClass.GetDgvData = this.dgvStockInfo[2, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetGoodsID = this.dgvStockInfo[1, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.StockNum = this.dgvStockInfo[5, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.StockName = this.dgvStockInfo[3, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetStockID = this.dgvStockInfo[0, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetCompanyName = this.dgvStockInfo[4, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetStockUnit = this.dgvStockInfo[7, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetGoodsInPrice = this.dgvStockInfo[10, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetSellPrice = this.dgvStockInfo[11, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetStockSpec = this.dgvStockInfo[9, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            this.Close();
        }

    }
}