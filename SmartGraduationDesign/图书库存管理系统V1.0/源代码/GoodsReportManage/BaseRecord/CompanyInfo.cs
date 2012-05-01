using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass; //�������

namespace GoodsReportManage.BaseRecord
{
    public partial class CompanyInfo : Form
    {
        public CompanyInfo()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();  //�������ݿ������Ķ���
        WinOperationClass G_OperationForm = new WinOperationClass();  //�����Դ�������������
        int G_Int_status;  //���������ť����

        /// <summary>
        /// ���ƿؼ�״̬
        /// </summary>
        private void ControlStatus()
        {
            this.toolSave.Enabled = !this.toolSave.Enabled;
            this.toolAdd.Enabled = !this.toolAdd.Enabled;
            this.toolCancel.Enabled = !this.toolCancel.Enabled;
            this.toolAmend.Enabled = !this.toolAmend.Enabled;

            this.txtAddress.ReadOnly = !this.txtAddress.ReadOnly;
            this.txtCompanyName.ReadOnly = !this.txtCompanyName.ReadOnly;
            this.txtDirector.ReadOnly = !this.txtDirector.ReadOnly;
            this.txtFax.ReadOnly = !this.txtFax.ReadOnly;
            this.txtPhone.ReadOnly = !this.txtPhone.ReadOnly;
            this.txtRemark.ReadOnly = !this.txtRemark.ReadOnly;
        }

        /// <summary>
        /// �ڿؼ������ѡ�е�DataGridView�ؼ�������
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.txtCompanyName.Text = this.dgvCompanyInfo[1, this.dgvCompanyInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtDirector.Text = this.dgvCompanyInfo[2, this.dgvCompanyInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtFax.Text = this.dgvCompanyInfo[4, this.dgvCompanyInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtPhone.Text = this.dgvCompanyInfo[3, this.dgvCompanyInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtRemark.Text = this.dgvCompanyInfo[6, this.dgvCompanyInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtAddress.Text = this.dgvCompanyInfo[5, this.dgvCompanyInfo.CurrentCell.RowIndex].Value.ToString();
            }
            catch { }
        }

        /// <summary>
        /// ���ؼ��ָ���ԭʼ״̬
        /// </summary>
        private void ClearControls()
        {
            this.txtAddress.Text = "";
            this.txtCompanyName.Text = "";
            this.txtDirector.Text = "";
            this.txtFax.Text = "";
            this.txtPhone.Text = "";
            this.txtRemark.Text = "";
        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            string cmdtxt = "SELECT CompanyID as ��Ӧ��ID,CompanyName as ��Ӧ������,CompanyDirector as ��Ӧ������,CompanyPhone as ��Ӧ�̵绰";
            cmdtxt += ",CompanyFax as ��Ӧ�̴���,CompanyAddress as ��Ӧ�̵�ַ,CompanyRemark as ��ע FROM tb_Company";
            this.dgvCompanyInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];

            this.cbxCondition.SelectedIndex = 0;

            this.dgvCompanyInfo.Columns[0].Visible = false;
 
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string P_Str_condition, P_Str_cmdtxt;
            switch (G_Int_status)
            {
                case 1:
                    //������Ҫִ�е�SQL���
                    P_Str_cmdtxt = "INSERT INTO tb_Company(CompanyName,CompanyDirector,CompanyPhone,CompanyFax,CompanyAddress,CompanyRemark)";
                    P_Str_cmdtxt += " VALUES('" + this.txtCompanyName.Text + "','" + this.txtDirector.Text + "','" + this.txtPhone.Text + "'";
                    P_Str_cmdtxt += ",'" + this.txtFax.Text + "','" + this.txtAddress.Text + "','" + this.txtRemark.Text + "')";

                    if (this.txtCompanyName.Text == "")
                    {
                        MessageBox.Show("��Ӧ�����Ʋ���Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
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
                    break;
                case 2:
                    P_Str_condition = this.dgvCompanyInfo[0, this.dgvCompanyInfo.CurrentCell.RowIndex].Value.ToString();
                    P_Str_cmdtxt = "UPDATE tb_Company SET CompanyName='" + this.txtCompanyName.Text + "',CompanyDirector='" + this.txtDirector.Text + "'";
                    P_Str_cmdtxt += ",CompanyPhone='" + this.txtPhone.Text + "',CompanyFax='" + this.txtFax.Text + "'";
                    P_Str_cmdtxt += ",CompanyAddress='" + this.txtAddress.Text + "',CompanyRemark='" + this.txtRemark.Text + "'";
                    P_Str_cmdtxt += " WHERE CompanyID=" + P_Str_condition + "";

                    if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                    {
                        MessageBox.Show("�����޸ĳɹ���");
                        ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("�����޸�ʧ�ܣ�");
                    }
                    break;
                default:
                    break;
                //��������ʾ�ؼ�
            }
            string cmdtxt = "SELECT CompanyID as ��Ӧ��ID,CompanyName as ��Ӧ������,CompanyDirector as ��Ӧ������,CompanyPhone as ��Ӧ�̵绰";
            cmdtxt += ",CompanyFax as ��Ӧ�̴���,CompanyAddress as ��Ӧ�̵�ַ,CompanyRemark as ��ע FROM tb_Company";
            this.dgvCompanyInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
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
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            G_Int_status = 2;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string P_Str_condition = this.dgvCompanyInfo[0, this.dgvCompanyInfo.CurrentCell.RowIndex].Value.ToString();
            string P_Str_cmdtxt = "DELETE FROM tb_Company WHERE CompanyID=" + P_Str_condition + "";
            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                MessageBox.Show("����ɾ���ɹ���");
            }
            else
            {
                MessageBox.Show("����ɾ��ʧ�ܣ�");
            }
            string cmdtxt = "SELECT CompanyID as ��Ӧ��ID,CompanyName as ��Ӧ������,CompanyDirector as ��Ӧ������,CompanyPhone as ��Ӧ�̵绰";
            cmdtxt += ",CompanyFax as ��Ӧ�̴���,CompanyAddress as ��Ӧ�̵�ַ,CompanyRemark as ��ע FROM tb_Company";
            this.dgvCompanyInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = "SELECT CompanyID as ��Ӧ��ID,CompanyName as ��Ӧ������,CompanyDirector as ��Ӧ������,CompanyPhone as ��Ӧ�̵绰";
            P_Str_cmdtxt += ",CompanyFax as ��Ӧ�̴���,CompanyAddress as ��Ӧ�̵�ַ,CompanyRemark as ��ע FROM tb_Company";
            this.dgvCompanyInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = String.Empty;
            string P_Str_selectcondition = this.cbxCondition.Items[this.cbxCondition.SelectedIndex].ToString();
            switch (P_Str_selectcondition)
            {
                case "��Ӧ������":
                    P_Str_cmdtxt = "SELECT CompanyID as ��Ӧ��ID,CompanyName as ��Ӧ������,CompanyDirector as ��Ӧ������,CompanyPhone as ��Ӧ�̵绰";
                    P_Str_cmdtxt += ",CompanyFax as ��Ӧ�̴���,CompanyAddress as ��Ӧ�̵�ַ,CompanyRemark as ��ע FROM tb_Company ";
                    P_Str_cmdtxt += " WHERE CompanyName LIKE '%" + this.txtKeyWord.Text + "%'";
                    this.dgvCompanyInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                case "��Ӧ������":
                    P_Str_cmdtxt = "SELECT CompanyID as ��Ӧ��ID,CompanyName as ��Ӧ������,CompanyDirector as ��Ӧ������,CompanyPhone as ��Ӧ�̵绰";
                    P_Str_cmdtxt += ",CompanyFax as ��Ӧ�̴���,CompanyAddress as ��Ӧ�̵�ַ,CompanyRemark as ��ע FROM tb_Company ";
                    P_Str_cmdtxt += " WHERE CompanyDirector LIKE '%" + this.txtKeyWord.Text + "%'";
                    this.dgvCompanyInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                default:
                    break;
            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCompanyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }
    }
}