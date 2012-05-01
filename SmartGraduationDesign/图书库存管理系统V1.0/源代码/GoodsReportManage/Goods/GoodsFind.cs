using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;  //�������

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
        /// �ڿؼ������ѡ�е�DataGridView�ؼ�������
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
                P_Str_cmdtxt = "SELECT GoodsID as ͼ��ID,GoodsName as ͼ������,GoodsTime as ��������,CompanyName as ��Ӧ������";
                P_Str_cmdtxt += ",GoodsNum as ��������,GoodsUnit as ͼ�鵥λ,GoodsPrice as ͼ�����,DepotName as �����ֿ�,GoodsSpec as ͼ����";
                P_Str_cmdtxt += ",SellPrice as ���ۼ۸�,NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Goods";
                P_Str_cmdtxt += " WHERE "+P_Str_select+"";
                this.dgvGoodsFindInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            }
            if (this.radioButton4.Checked)
            {
                P_Str_select = "GoodsID LIKE '%" + this.txtGoodsID.Text + "%' AND ReGoodsName LIKE '%" + this.txtGoodsName.Text + "%'";
                P_Str_select += " AND ReGoodsTime BETWEEN '" + this.dtStartTime.Value.ToString("yyyy-MM-dd") + "' AND ";
                P_Str_select += "'" + this.dtEndTime.Value.ToString("yyyy-MM-dd") + "'";
                P_Str_cmdtxt = "SELECT ReGoodsID as �˻�ID,GoodsID as ͼ��ID,ReGoodsName as ͼ������,ReGoodsTime as �˻�����,ReGoodsNum as �˻�����";
                P_Str_cmdtxt += ",ReGoodsUnit as ͼ�鵥λ,ReGoodsSpec as ͼ����,ReGoodsPrice as �����۸�,NeedPay as Ӧ�ս��,HasPay as ʵ�ս��,ReGoodsResult as �˻�ԭ��";
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
            this.label10.Text = "Ӧ�����";
            this.label15.Text = "ʵ�����";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.label10.Text = "Ӧ�ս��";
            this.label15.Text = "ʵ�ս��";
        }
    }
}