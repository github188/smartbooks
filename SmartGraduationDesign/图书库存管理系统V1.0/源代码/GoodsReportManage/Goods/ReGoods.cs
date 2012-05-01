using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoodsReportManage.ItemClass;����//�������
using System.Data.SqlClient;
using GoodsReportManage.Stock;

namespace GoodsReportManage.Goods
{
    public partial class ReGoods : Form
    {
        public ReGoods()
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
            this.groupBox1.Enabled = !this.groupBox1.Enabled;
            this.toolSave.Enabled = !this.toolSave.Enabled;
            this.toolAdd.Enabled = !this.toolAdd.Enabled;
            this.toolCancel.Enabled = !this.toolCancel.Enabled;
            this.toolAmend.Enabled = !this.toolAmend.Enabled;
        }

        /// <summary>
        /// �ڿؼ������ѡ�е�DataGridView�ؼ�������
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.labReGoodsID.Text = this.dgvReGoodsInfo[0, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtHasPay.Text = this.dgvReGoodsInfo[10, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNeedPay.Text = this.dgvReGoodsInfo[9, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNum.Text = this.dgvReGoodsInfo[5, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtResult.Text = this.dgvReGoodsInfo[11, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxUnit.Text = this.dgvReGoodsInfo[6, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.dtBirthday.Value = Convert.ToDateTime(this.dgvReGoodsInfo[4, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString());
                PropertyClass.GetDgvData = this.dgvReGoodsInfo[3, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetGoodsInPrice = this.dgvReGoodsInfo[8, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetStockSpec = this.dgvReGoodsInfo[7, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetCompanyName = this.dgvReGoodsInfo[2, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
            }
            catch { }
        }

        /// <summary>
        /// ���ؼ��ָ���ԭʼ״̬
        /// </summary>
        private void ClearControls()
        {
            this.cbxUnit.SelectedIndex = 0;

            this.txtGoodsName.Text = "";
            this.txtHasPay.Text = "";
            this.txtNeedPay.Text = "";
            this.txtNum.Text = "";
            this.txtGoodsPrice.Text = "";
            this.txtResult.Text = "";
            this.txtSpec.Text = "";

            this.dtBirthday.Value = DateTime.Now;

            this.labReGoodsID.Text = "";
        }

        private void ReGoods_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            string P_Str_cmdtxt = "SELECT ReGoodsID as �˻�ID,GoodsID as ����ID,CompanyName as ��Ӧ������,ReGoodsName as ͼ������,ReGoodsTime as �˻�����,ReGoodsNum as �˻�����";
            P_Str_cmdtxt += ",ReGoodsUnit as ͼ�鵥λ,ReGoodsSpec as ͼ����,ReGoodsPrice as �����۸�,NeedPay as Ӧ�����,HasPay as ʵ�����,ReGoodsResult as �˻�ԭ��";
            P_Str_cmdtxt += " FROM tb_ReGoods WHERE ReGoodsSort='0'";
            this.dgvReGoodsInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            G_OperationForm.BindComboBox("SELECT * FROM tb_Unit", cbxUnit, "UnitName"); //��ComboBox�ؼ�
            G_OperationForm.BindComboBox("SELECT DISTINCT * FROM tb_Company",cbxCompanyName,"CompanyName");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PropertyClass.GetDgvData != null)
            {
                this.txtGoodsName.Text = PropertyClass.GetDgvData;
                this.txtGoodsPrice.Text = PropertyClass.GetGoodsInPrice;
                this.txtSpec.Text = PropertyClass.GetStockSpec;
                this.cbxCompanyName.Text = PropertyClass.GetCompanyName;
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string P_Str_condition, P_Str_cmdtxt;
            switch (G_Int_status)
            {
                case 1: 
                    if (this.cbxCompanyName.SelectedValue.ToString() != "")
                    {

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
                        if (this.txtGoodsPrice.Text == "")
                        {
                            MessageBox.Show("ͼ����۲���Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtHasPay.Text == "")
                        {
                            MessageBox.Show("���ۼ۸���Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (!G_OperationForm.IsNumeric(this.txtNum.Text) && !G_OperationForm.IsNumeric(this.txtGoodsPrice.Text)
                            && !G_OperationForm.IsNumeric(this.txtHasPay.Text))
                        {
                            MessageBox.Show("����������ݸ�ʽ����", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //������Ҫִ�е�SQL���
                        P_Str_cmdtxt = "INSERT INTO tb_ReGoods(ReGoodsID,GoodsID,UserID,CompanyName,ReGoodsName,ReGoodsSpec,ReGoodsNum,ReGoodsUnit";
                        P_Str_cmdtxt += ",ReGoodsTime,ReGoodsPrice,NeedPay,HasPay,ReGoodsResult,ReGoodsSort,StockID) VALUES('" + this.labReGoodsID.Text + "'";
                        P_Str_cmdtxt += ",'" + PropertyClass.GetGoodsID + "','" + PropertyClass.SendUserIDValue + "','" + this.cbxCompanyName.SelectedValue.ToString() + "'";
                        P_Str_cmdtxt += ",'" + this.txtGoodsName.Text + "','" + this.txtSpec.Text + "','" + this.txtNum.Text + "'";
                        P_Str_cmdtxt += ",'" + this.cbxUnit.SelectedValue.ToString() + "','" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "'";
                        P_Str_cmdtxt += "," + this.txtGoodsPrice.Text + "," + this.txtNeedPay.Text + "," + this.txtHasPay.Text + "";
                        P_Str_cmdtxt += ",'" + this.txtResult.Text + "','0','" + PropertyClass.GetStockID + "')";

                        if (this.txtGoodsName.Text == "")
                        {
                            MessageBox.Show("ͼ�����Ʋ���Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            SqlDataReader P_dr2 = G_SqlClass.GetReader("select GoodsID,StockNum from tb_Stock where GoodsID='"
                                + PropertyClass.GetGoodsID + "' and StockNum<'" + Convert.ToInt32(txtNum.Text.Trim()) + "'");
                            P_dr2.Read();
                            if (P_dr2.HasRows)
                            {
                                MessageBox.Show("�����û����˶��ͼ�飬��������д�˻�������");
                                txtNum.Text = "";
                                txtNum.Focus();
                            }
                            else
                            {
                                //ִ��SQL��䲢����ִ�н��
                                if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                                {

                                    MessageBox.Show("������ӳɹ���");
                                    ControlStatus();
                                    PropertyClass.GetDgvData = null;
                                }
                                else
                                {
                                    MessageBox.Show("�������ʧ�ܣ�");
                                }
                            }
                            P_dr2.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("��ѡ��Ӧ�����ƣ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                    if (this.cbxCompanyName.SelectedValue.ToString() != "")
                    {

                        P_Str_condition = this.dgvReGoodsInfo[0, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                        P_Str_cmdtxt = "UPDATE tb_ReGoods SET ReGoodsName='" + this.txtGoodsName.Text + "',ReGoodsSpec='" + this.txtSpec.Text + "'";
                        P_Str_cmdtxt += ",ReGoodsTime='" + this.dtBirthday.Value + "',ReGoodsNum='" + this.txtNum.Text + "'";
                        P_Str_cmdtxt += ",ReGoodsUnit='" + this.cbxUnit.SelectedValue.ToString() + "',ReGoodsPrice=" + Convert.ToDecimal(this.txtGoodsPrice.Text) + "";
                        P_Str_cmdtxt += ",ReGoodsResult='" + this.txtResult.Text + "',NeedPay=" + Convert.ToDecimal(this.txtNeedPay.Text) + ",HasPay=" + Convert.ToDecimal(this.txtHasPay.Text) + "";
                        P_Str_cmdtxt += " WHERE ReGoodsID='" + P_Str_condition + "'";
                        try
                        {
                            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                            {
                                MessageBox.Show("�����޸ĳɹ���");
                                ControlStatus();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("�����޸�ʧ�ܣ�");
                        }
                    }
                    else
                    {
                        MessageBox.Show("��ѡ��Ӧ�����ƣ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                default:
                    break;
            }
            ReGoods_Load(sender, e);
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            G_Int_status = 1;
            int P_Int_Num = 0;
            SqlDataReader P_dr = G_SqlClass.GetReader("SELECT TOP 1 * FROM tb_ReGoods ORDER BY ReGoodsID DESC");
            P_dr.Read();
            if (P_dr.HasRows)
            {
                string P_Str_GoodsID = P_dr["ReGoodsID"].ToString();
                P_Int_Num = Convert.ToInt16(P_Str_GoodsID.Substring(11)) + 1;
            }
            else
            {
                this.labReGoodsID.Text = "TH" + DateTime.Now.ToString("yyyyMMdd") + "-" + "1000";
                P_dr.Close();
                return;
            }
            P_dr.Close();
            this.labReGoodsID.Text = "TH" + DateTime.Now.ToString("yyyyMMdd") + "-" + P_Int_Num.ToString();
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            G_Int_status = 2;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string P_Str_condition = this.dgvReGoodsInfo[0, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
            string P_Str_cmdtxt = "DELETE FROM tb_ReGoods WHERE ReGoodsID='" + P_Str_condition + "'";
            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                MessageBox.Show("����ɾ���ɹ���");
            }
            else
            {
                MessageBox.Show("����ɾ��ʧ�ܣ�");
            }
            string P_Str_cmdtxt1 = "SELECT ReGoodsID as �˻�ID,GoodsID as ����ID,ReGoodsName as ͼ������,ReGoodsTime as �˻�����,ReGoodsNum as �˻�����";
            P_Str_cmdtxt1 += ",ReGoodsUnit as ͼ�鵥λ,ReGoodsSpec as ͼ����,ReGoodsPrice as �����۸�,NeedPay as Ӧ�����,HasPay as ʵ�����,ReGoodsResult as �˻�ԭ��";
            P_Str_cmdtxt1 += " FROM tb_ReGoods WHERE ReGoodsSort='0'";
            this.dgvReGoodsInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt1).Tables[0];
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            StockFind stockfind = new StockFind();
            stockfind.StartPosition = FormStartPosition.CenterParent;
            stockfind.ShowDialog();
        }

        private void dgvReGoodsInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNum.Text != "" && G_OperationForm.IsNumeric(this.txtNum.Text))
            {
                this.txtNeedPay.Text = Convert.ToString(Convert.ToDecimal(this.txtGoodsPrice.Text) * Convert.ToInt32(this.txtNum.Text));
            }
        }

    }
}