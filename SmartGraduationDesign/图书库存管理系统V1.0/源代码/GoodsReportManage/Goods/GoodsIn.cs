using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;  //�������
using GoodsReportManage.ItemClass;

namespace GoodsReportManage.Goods
{
    public partial class GoodsIn : Form
    {
        public GoodsIn()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();  //�������ݿ������Ķ���
        WinOperationClass G_OperationForm = new WinOperationClass();  //�����Դ�������������
        int G_Int_status;  //���湤������ť����״̬

        /// <summary>
        /// ���ƿؼ�״̬
        /// </summary>
        private void ControlStatus()
        {
            this.toolSave.Enabled = !this.toolSave.Enabled;
            this.toolAdd.Enabled = !this.toolAdd.Enabled;
            this.toolCancel.Enabled = !this.toolCancel.Enabled;
            this.toolAmend.Enabled = !this.toolAmend.Enabled;
            this.txtGoodsName.ReadOnly = !this.txtGoodsName.ReadOnly;
            this.txtHasPay.ReadOnly = !this.txtHasPay.ReadOnly;
            this.txtRemark.ReadOnly = !this.txtRemark.ReadOnly;
            this.txtSellPrice.ReadOnly = !this.txtSellPrice.ReadOnly;
            this.txtSpec.ReadOnly = !this.txtSpec.ReadOnly;
            this.txtGoodsInPrice.ReadOnly = !this.txtGoodsInPrice.ReadOnly;
            this.dtBirthday.Enabled = !this.dtBirthday.Enabled;
            this.txtNum.ReadOnly = !this.txtNum.ReadOnly;
            this.cbxDepot.Enabled = !this.cbxDepot.Enabled;
            this.cbxCompanyName.Enabled = !this.cbxCompanyName.Enabled;
            this.cbxUnit.Enabled = !this.cbxUnit.Enabled;
            this.cbxEmployeeName.Enabled = !this.cbxEmployeeName.Enabled;

            this.dgvGoodsInfo.Enabled = !this.dgvGoodsInfo.Enabled;
        }

        /// <summary>
        /// �ڿؼ������ѡ�е�DataGridView�ؼ�������
        /// </summary>
        private void FillControls()
        {
            try
            {
                GoodsMoney();
                this.labGoodsID.Text = this.dgvGoodsInfo[0, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtGoodsInPrice.Text = this.dgvGoodsInfo[6, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtGoodsName.Text = this.dgvGoodsInfo[1, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtHasPay.Text = this.dgvGoodsInfo[11, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNeedPay.Text = this.dgvGoodsInfo[10, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNum.Text = this.dgvGoodsInfo[4, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtRemark.Text = this.dgvGoodsInfo[12, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtSellPrice.Text = this.dgvGoodsInfo[9, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtSpec.Text = this.dgvGoodsInfo[8, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxCompanyName.Text = this.dgvGoodsInfo[3, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxDepot.Text = this.dgvGoodsInfo[7, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxUnit.Text = this.dgvGoodsInfo[5, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.dtBirthday.Value = Convert.ToDateTime(this.dgvGoodsInfo[2, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString());
                string P_Str_cmdtxt = "SELECT GoodsID,UserID FROM tb_Goods WHERE GoodsID='" + this.dgvGoodsInfo[0, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString() + "'";
                SqlDataReader P_dr = G_SqlClass.GetReader(P_Str_cmdtxt);
                P_dr.Read();
                if (P_dr.HasRows)
                {
                    string P_Str_cmdtxt2 = "SELECT UserID,Name FROM tb_User WHERE UserID='" + P_dr["UserID"].ToString() + "'";
                    SqlDataReader P_dr2 = G_SqlClass.GetReader(P_Str_cmdtxt2);
                    P_dr2.Read();
                    if (P_dr2.HasRows)
                    {
                        cbxEmployeeName.Text = P_dr2["Name"].ToString();
                    }
                    P_dr2.Close();
                }
                P_dr.Close();
            }
            catch { }
        }

        private void GoodsMoney()
        {
            string P_Str_cmdtxt = "SELECT GoodsNum*GoodsPrice AS ͼ����۽��,GoodsNum*(SellPrice-GoodsPrice) AS ͼ��ӯ����";
            P_Str_cmdtxt += " FROM tb_Goods WHERE GoodsID = '"+this.dgvGoodsInfo[0, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString() + "'";
            DataSet P_ds = G_SqlClass.GetDs(P_Str_cmdtxt);
            this.labGoodsIn.Text = P_ds.Tables[0].Rows[0][0].ToString();
            this.labGain.Text = P_ds.Tables[0].Rows[0][1].ToString();

            string P_Str_cmdtxt1 = "SELECT SUM(ͼ����۽��),SUM(ͼ��ӯ����) FROM (SELECT GoodsNum*GoodsPrice AS ͼ����۽��,GoodsNum*(SellPrice-GoodsPrice) AS ͼ��ӯ���� FROM tb_Goods) DERIVEDTBL";
            DataSet P_ds1 = G_SqlClass.GetDs(P_Str_cmdtxt1);

            this.labInTotalM.Text = P_ds1.Tables[0].Rows[0][0].ToString();
            this.lalTotalG.Text = P_ds1.Tables[0].Rows[0][1].ToString();
        }

        /// <summary>
        /// ���ؼ��ָ���ԭʼ״̬
        /// </summary>
        private void ClearControls()
        {
            this.cbxCompanyName.SelectedIndex = 0;
            this.cbxUnit.SelectedIndex = 0;
            this.cbxDepot.SelectedIndex = 0;

            this.txtGoodsInPrice.Text = "";
            this.txtGoodsName.Text = "";
            this.txtHasPay.Text = "";
            this.txtNeedPay.Text = "";
            this.txtNum.Text = "";
            this.txtRemark.Text = "";
            this.txtSellPrice.Text = "";
            this.txtSpec.Text = "";

            this.labGoodsID.Text = "";
        }

        private void GoodsIn_Load(object sender, EventArgs e)
        {
            string cmdtxt = "SELECT GoodsID as ͼ��ID,GoodsName as ͼ������,GoodsTime as ��������,CompanyName as ��Ӧ������";
            cmdtxt += ",GoodsNum as ��������,GoodsUnit as ͼ�鵥λ,GoodsPrice as ͼ�����,DepotName as �����ֿ�,GoodsSpec as ͼ����";
            cmdtxt += ",SellPrice as ���ۼ۸�,NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Goods";
            this.dgvGoodsInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];

            G_OperationForm.BindComboBox("SELECT * FROM tb_Company", cbxCompanyName, "CompanyName");  //��ComboBox�ؼ�
            G_OperationForm.BindComboBox("SELECT * FROM tb_Unit", cbxUnit, "UnitName");
            G_OperationForm.BindComboBox("SELECT * FROM tb_Depot", cbxDepot, "DepotSort");
            G_OperationForm.BindComboBox("SELECT * FROM tb_User",cbxEmployeeName, "Name");
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string P_Str_condition, P_Str_cmdtxt;
            switch (G_Int_status)
            {
                case 1:
                    if (this.cbxEmployeeName.SelectedValue.ToString() != "")
                    {
                        string P_Str_Id = String.Empty;

                        //�������ݿ��ж�Ӧ�ͻ���ID
                        string P_Str_cmdtxt2 = "SELECT UserID,Name FROM tb_User WHERE Name='" + this.cbxEmployeeName.SelectedValue.ToString() + "'";
                        SqlDataReader P_dr = G_SqlClass.GetReader(P_Str_cmdtxt2);
                        P_dr.Read();
                        if (P_dr.HasRows)
                        {
                            P_Str_Id = P_dr["UserID"].ToString();
                        }
                        P_dr.Close();
                        //������Ҫִ�е�SQL���
                        P_Str_cmdtxt = "INSERT INTO tb_Goods(GoodsID,UserID,CompanyName,DepotName,GoodsName,GoodsNum,GoodsUnit,GoodsTime,GoodsSpec,GoodsPrice,SellPrice";
                        P_Str_cmdtxt += ",Remark,NeedPay,HasPay) VALUES('" + this.labGoodsID.Text + "','" + P_Str_Id + "'";
                        P_Str_cmdtxt += ",'" + this.cbxCompanyName.SelectedValue.ToString() + "','" + this.cbxDepot.SelectedValue.ToString() + "'";
                        P_Str_cmdtxt += ",'" + this.txtGoodsName.Text + "','" + this.txtNum.Text + "','" + this.cbxUnit.SelectedValue.ToString() + "'";
                        P_Str_cmdtxt += ",'" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "','" + this.txtSpec.Text + "'," + this.txtGoodsInPrice.Text + "";
                        P_Str_cmdtxt += "," + this.txtSellPrice.Text + ",'" + this.txtRemark.Text + "'";
                        P_Str_cmdtxt += "," + this.txtNeedPay.Text + "," + this.txtHasPay.Text + ")";

                        if (this.txtGoodsName.Text == "")
                        {
                            MessageBox.Show("ͼ�����Ʋ���Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtNum.Text == "")
                        {
                            MessageBox.Show("ͼ����������Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtGoodsInPrice.Text == "")
                        {
                            MessageBox.Show("ͼ����۲���Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtSellPrice.Text == "")
                        {
                            MessageBox.Show("���ۼ۸���Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (!G_OperationForm.IsNumeric(this.txtNum.Text) && !G_OperationForm.IsNumeric(this.txtGoodsInPrice.Text)
                            && !G_OperationForm.IsNumeric(this.txtHasPay.Text) && !G_OperationForm.IsNumeric(this.txtSellPrice.Text))
                        {
                            MessageBox.Show("����������ݸ�ʽ����", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //ִ��SQL��䲢����ִ�н��
                            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                            {

                                MessageBox.Show("������ӳɹ���");
                                ControlStatus();
                            }
                            else
                            {
                                MessageBox.Show("�������ʧ�ܣ�");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("��ѡ������Ա������", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                    if (this.cbxEmployeeName.SelectedValue.ToString() != "")
                    {
                        string P_Str_Id = String.Empty;

                        //�������ݿ��ж�Ӧ�ͻ���ID
                        string P_Str_cmdtxt2 = "SELECT UserID,Name FROM tb_User WHERE Name='" + this.cbxEmployeeName.SelectedValue.ToString() + "'";
                        SqlDataReader P_dr = G_SqlClass.GetReader(P_Str_cmdtxt2);
                        P_dr.Read();
                        if (P_dr.HasRows)
                        {
                            P_Str_Id = P_dr["UserID"].ToString();
                        }
                        P_dr.Close();

                        P_Str_condition = this.dgvGoodsInfo[0, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                        P_Str_cmdtxt = "UPDATE tb_Goods SET GoodsName='" + this.txtGoodsName.Text + "',CompanyName='" + this.cbxCompanyName.SelectedValue.ToString() + "'";
                        P_Str_cmdtxt += ",DepotName='" + this.cbxDepot.SelectedValue.ToString() + "',GoodsNum='" + this.txtNum.Text + "'";
                        P_Str_cmdtxt += ",GoodsUnit='" + this.cbxUnit.SelectedValue.ToString() + "',GoodsTime='" + this.dtBirthday.Value + "'";
                        P_Str_cmdtxt += ",GoodsSpec='" + this.txtSpec.Text + "',UserID='"+P_Str_Id+"',GoodsPrice=" + this.txtGoodsInPrice.Text + "";
                        P_Str_cmdtxt += ",SellPrice=" + this.txtSellPrice.Text + ",Remark='" + this.txtRemark.Text + "'";
                        P_Str_cmdtxt += ",NeedPay=" + this.txtNeedPay.Text + ",HasPay=" + this.txtHasPay.Text + " WHERE GoodsID='" + P_Str_condition + "'";

                        if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                        {
                            MessageBox.Show("�����޸ĳɹ���");
                            ControlStatus();
                        }
                        else
                        {
                            MessageBox.Show("�����޸�ʧ�ܣ�");
                        }
                    }
                    else
                    {
                        MessageBox.Show("��ѡ������Ա������", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                default:
                    break;
            }
            //��������ʾ�ؼ�
            string cmdtxt = "SELECT GoodsID as ͼ��ID,GoodsName as ͼ������,GoodsTime as ��������,CompanyName as ��Ӧ������";
            cmdtxt += ",GoodsNum as ��������,GoodsUnit as ͼ�鵥λ,GoodsPrice as ͼ�����,DepotName as �����ֿ�,GoodsSpec as ͼ����";
            cmdtxt += ",SellPrice as ���ۼ۸�,NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Goods";
            this.dgvGoodsInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            this.txtNum.ReadOnly = true;
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            G_Int_status = 1;
            int P_Int_Num = 0;
            SqlDataReader P_dr = G_SqlClass.GetReader("SELECT TOP 1 * FROM tb_Goods ORDER BY GoodsID DESC");
            P_dr.Read();
            if (P_dr.HasRows)
            {
                string P_Str_GoodsID = P_dr["GoodsID"].ToString();
                P_Int_Num = Convert.ToInt16(P_Str_GoodsID.Substring(11)) + 1;
            }
            else
            {
                this.labGoodsID.Text = "JH" + DateTime.Now.ToString("yyyyMMdd") + "-" + "1000";
                P_dr.Close();
                return;
            }
            P_dr.Close();
            this.labGoodsID.Text = "JH" + DateTime.Now.ToString("yyyyMMdd") + "-" + P_Int_Num.ToString();
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            G_Int_status = 2;
            this.txtNum.ReadOnly = true;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string P_Str_condition = this.dgvGoodsInfo[0, this.dgvGoodsInfo.CurrentCell.RowIndex].Value.ToString();
            string P_Str_cmdtxt = "DELETE FROM tb_Goods WHERE GoodsID='" + P_Str_condition + "'";
            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                MessageBox.Show("����ɾ���ɹ���");
            }
            else
            {
                MessageBox.Show("����ɾ��ʧ�ܣ�");
            }
            string cmdtxt = "SELECT GoodsID as ͼ��ID,GoodsName as ͼ������,GoodsTime as ��������,CompanyName as ��Ӧ������";
            cmdtxt += ",GoodsNum as ��������,GoodsUnit as ͼ�鵥λ,GoodsPrice as ͼ�����,DepotName as �����ֿ�,GoodsSpec as ͼ����";
            cmdtxt += ",SellPrice as ���ۼ۸�,NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Goods";
            this.dgvGoodsInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void toolrefulsh_Click(object sender, EventArgs e)
        {
            string cmdtxt = "SELECT GoodsID as ͼ��ID,GoodsName as ͼ������,GoodsTime as ��������,CompanyName as ��Ӧ������";
            cmdtxt += ",GoodsNum as ��������,GoodsUnit as ͼ�鵥λ,GoodsPrice as ͼ�����,DepotName as �����ֿ�,GoodsSpec as ͼ����";
            cmdtxt += ",SellPrice as ���ۼ۸�,NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Goods";
            this.dgvGoodsInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGoodsInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void txtGoodsInPrice_TextChanged(object sender, EventArgs e)
        {
            if (this.txtGoodsInPrice.Text != "" && this.txtNum.Text != ""&&G_OperationForm.IsNumeric(this.txtGoodsInPrice.Text)&&G_OperationForm.IsNumeric(this.txtNum.Text))
            {
                this.txtNeedPay.Text = Convert.ToString(Convert.ToInt32(this.txtGoodsInPrice.Text) * Convert.ToInt32(this.txtNum.Text));
            }
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (this.txtGoodsInPrice.Text != "" && this.txtNum.Text != "" && G_OperationForm.IsNumeric(this.txtNum.Text))
            {
                this.txtNeedPay.Text = Convert.ToString(Convert.ToDecimal(this.txtGoodsInPrice.Text) * Convert.ToInt32(this.txtNum.Text));
            }
        }
    }
}