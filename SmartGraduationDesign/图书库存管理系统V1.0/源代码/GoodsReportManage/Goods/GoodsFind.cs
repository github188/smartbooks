using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;  //添加引用

namespace GoodsReportManage.Goods
{
    public partial class GoodsFind : Form
    {
        public GoodsFind()
        {
            InitializeComponent();
        }

        private void GoodsFind_Load(object sender, EventArgs e)
        {

        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
        /// </summary>
        private void FillControls()
        {
            try
            {
                if (this.radioButton3.Checked)
                {
                    this.labGoodsID.Text = this.dgvGoodsFindInfo[0, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labGoodsName.Text = this.dgvGoodsFindInfo[1, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labGoodsSpec.Text = this.dgvGoodsFindInfo[8, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labNum.Text = this.dgvGoodsFindInfo[4, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labRMoney.Text = this.dgvGoodsFindInfo[10, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labGoodsPrice.Text = this.dgvGoodsFindInfo[6, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labHasPay.Text = this.dgvGoodsFindInfo[11, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                }
                if (this.radioButton4.Checked)
                {
                    this.labGoodsID.Text = this.dgvGoodsFindInfo[1, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labGoodsName.Text = this.dgvGoodsFindInfo[2, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labGoodsSpec.Text = this.dgvGoodsFindInfo[6, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labNum.Text = this.dgvGoodsFindInfo[4, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labRMoney.Text = this.dgvGoodsFindInfo[8, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labGoodsPrice.Text = this.dgvGoodsFindInfo[7, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                    this.labHasPay.Text = this.dgvGoodsFindInfo[9, this.dgvGoodsFindInfo.CurrentCell.RowIndex].Value.ToString();
                }
            }
            catch { }
        }

        private void btnSfind_Click(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = String.Empty;
            string P_Str_select = String.Empty;
            if (this.radioButton3.Checked)
            {
                P_Str_select = "GoodsID LIKE '%"+this.txtGoodsID.Text +"%' AND GoodsName LIKE '%"+this.txtGoodsName.Text+"%'";
                P_Str_select += " AND GoodsTime BETWEEN '"+this.dtStartTime.Value.ToString("yyyy-MM-dd")+"' AND ";
                P_Str_select += "'"+this.dtEndTime.Value.ToString("yyyy-MM-dd")+"'";
                P_Str_cmdtxt = "SELECT GoodsID as 图书ID,GoodsName as 图书名称,GoodsTime as 进货日期,CompanyName as 供应商名称";
                P_Str_cmdtxt += ",GoodsNum as 进货数量,GoodsUnit as 图书单位,GoodsPrice as 图书进价,DepotName as 所属仓库,GoodsSpec as 图书规格";
                P_Str_cmdtxt += ",SellPrice as 销售价格,NeedPay as 应付金额,HasPay as 实付金额,Remark as 备注 FROM tb_Goods";
                P_Str_cmdtxt += " WHERE "+P_Str_select+"";
                this.dgvGoodsFindInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            }
            if (this.radioButton4.Checked)
            {
                P_Str_select = "GoodsID LIKE '%" + this.txtGoodsID.Text + "%' AND ReGoodsName LIKE '%" + this.txtGoodsName.Text + "%'";
                P_Str_select += " AND ReGoodsTime BETWEEN '" + this.dtStartTime.Value.ToString("yyyy-MM-dd") + "' AND ";
                P_Str_select += "'" + this.dtEndTime.Value.ToString("yyyy-MM-dd") + "'";
                P_Str_cmdtxt = "SELECT ReGoodsID as 退货ID,GoodsID as 图书ID,ReGoodsName as 图书名称,ReGoodsTime as 退货日期,ReGoodsNum as 退货数量";
                P_Str_cmdtxt += ",ReGoodsUnit as 图书单位,ReGoodsSpec as 图书规格,ReGoodsPrice as 进货价格,NeedPay as 应收金额,HasPay as 实收金额,ReGoodsResult as 退货原因";
                P_Str_cmdtxt += " FROM tb_ReGoods WHERE "+P_Str_select+"";
                this.dgvGoodsFindInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            }
        }

        private void btnCfind_Click(object sender, EventArgs e)
        {
            this.txtGoodsName.Text = "";
            this.txtGoodsID.Text = "";

            this.dtEndTime.Value = DateTime.Now;
            this.dtStartTime.Value = DateTime.Now;
        }

        private void dgvGoodsFindInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.label10.Text = "应付金额";
            this.label15.Text = "实付金额";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.label10.Text = "应收金额";
            this.label15.Text = "实收金额";
        }
    }
}