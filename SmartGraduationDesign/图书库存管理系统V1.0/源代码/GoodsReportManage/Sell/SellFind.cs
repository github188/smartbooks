using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;

namespace GoodsReportManage.Sell
{
    public partial class SellFind : Form
    {
        public SellFind()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.labGoodsID.Text = this.dgvStockInfo[1, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsName.Text = this.dgvStockInfo[2, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsSpec.Text = this.dgvStockInfo[6, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labNum.Text = this.dgvStockInfo[3, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labRMoney.Text = this.dgvStockInfo[9, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsPrice.Text = this.dgvStockInfo[8, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                this.labHasPay.Text = this.dgvStockInfo[10, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            }
            catch { }
        }

        private void SellFind_Load(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = "SELECT SellID as 销售ID,GoodsID as 图书ID,GoodsName as 图书名称,GoodsNum as 销售数量";
            P_Str_cmdtxt += ",GoodsUnit as 图书单位,GoodsTime as 销售时间,GoodsSpec as 图书规格,GoodsPrice as 进货价格,SellPrice as 销售价格";
            P_Str_cmdtxt += ",NeedPay as 应收金额,HasPay as 实收金额,Remark as 备注 FROM tb_Sell";
            this.dgvStockInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];

            this.cbxCondition1.SelectedIndex = 0;
            this.cbxCondition2.SelectedIndex = 0;
        }

        private void btnFindOK_Click(object sender, EventArgs e)
        {
            string P_Str_select = " WHERE SellID LIKE '%"+this.txtSellID.Text+"%' AND GoodsName LIKE '%" + this.txtGoodsName.Text + "%'";
            P_Str_select += " AND GoodsID LIKE '%" + this.txtGoodsID.Text + "%' AND GoodsNum LIKE '%" + this.txtStockNum.Text + "%' ";
            if (this.txtGoodsPrice.Text != "")
            {
                P_Str_select += " AND GoodsPrice " + this.cbxCondition1.Items[this.cbxCondition1.SelectedIndex].ToString() + this.txtGoodsPrice.Text + "";
            }
            if (this.txtSellPrice.Text != "")
            {
                P_Str_select += "AND SellPrice " + this.cbxCondition2.Items[this.cbxCondition2.SelectedIndex].ToString() + this.txtSellPrice.Text + "";
            }
            string P_Str_cmdtxt = "SELECT SellID as 销售ID,GoodsID as 图书ID,GoodsName as 图书名称,GoodsNum as 销售数量";
            P_Str_cmdtxt += ",GoodsUnit as 图书单位,GoodsTime as 销售时间,GoodsSpec as 图书规格,GoodsPrice as 进货价格,SellPrice as 销售价格";
            P_Str_cmdtxt += ",NeedPay as 应收金额,HasPay as 实收金额,Remark as 备注 FROM tb_Sell" + P_Str_select;
            this.dgvStockInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStockInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void dgvStockInfo_DoubleClick(object sender, EventArgs e)
        {
            PropertyClass.GetDgvData = this.dgvStockInfo[2, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetGoodsID = this.dgvStockInfo[1, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetStockUnit = this.dgvStockInfo[4, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetGoodsInPrice = this.dgvStockInfo[7, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetSellPrice = this.dgvStockInfo[8, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            PropertyClass.GetStockSpec = this.dgvStockInfo[6, this.dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            this.Close();
        }
    }
}