using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;     //�������
using System.Data.SqlClient;

namespace GoodsReportManage.BaseRecord
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
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
           
            this.txtName.ReadOnly = !this.txtName.ReadOnly;
            this.txtPhoneH.ReadOnly = !this.txtPhoneH.ReadOnly;
            this.txtPhoneM.ReadOnly = !this.txtPhoneM.ReadOnly;
            this.txtAddress.ReadOnly = !this.txtAddress.ReadOnly;

            this.cbxSex.Enabled = !this.cbxSex.Enabled;
            this.cbxPost.Enabled = !this.cbxPost.Enabled;
            this.cbxDepartment.Enabled = !this.cbxDepartment.Enabled;

            this.dtBirthday.Enabled = !this.dtBirthday.Enabled;
            this.dgvUserInfo.Enabled = !this.dgvUserInfo.Enabled;
        }

        /// <summary>
        /// �ڿؼ������ѡ�е�DataGridView�ؼ�������
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.txtName.Text = this.dgvUserInfo[1, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtPhoneH.Text = this.dgvUserInfo[6, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtPhoneM.Text = this.dgvUserInfo[7, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtAddress.Text = this.dgvUserInfo[8, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();

                this.cbxDepartment.Text = this.dgvUserInfo[4, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxPost.Text = this.dgvUserInfo[5, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxSex.Text = this.dgvUserInfo[2, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();

                this.dtBirthday.Value = Convert.ToDateTime(this.dgvUserInfo[3, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString());
            }
            catch { }
        }

        /// <summary>
        /// ���ؼ��ָ���ԭʼ״̬
        /// </summary>
        private void ClearControls()
        {
            this.cbxDepartment.SelectedIndex = 0;
            this.cbxPost.SelectedIndex = 0;
            this.cbxSex.SelectedIndex = 0;

            this.txtAddress.Text = "";
            this.txtName.Text = "";
            this.txtPhoneH.Text = "";
            this.txtPhoneM.Text = "";

            this.dtBirthday.Value = DateTime.Now;
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {
            string cmdtxt = "SELECT UserID as Ա��ID,Name as Ա������,Sex as Ա���Ա�,Birthday as ��������,Department as ��������,Post as ����ְλ";
            cmdtxt += ",PhoneH as ��ͥ�绰,PhoneM as �ֻ�����,Address as ��ͥסַ FROM tb_User";
            this.dgvUserInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
            G_OperationForm.BindComboBox("SELECT * FROM tb_Post", cbxPost, "PostName");
            G_OperationForm.BindComboBox("SELECT * FROM tb_Department", cbxDepartment, "DepName");
            
            this.cbxSex.SelectedIndex = 0;   //����Ĭ��ѡ��
            this.cbxCondition.SelectedIndex = 0;

            this.dgvUserInfo.Columns[0].Visible = false;  //����DataGridView�ؼ�������
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            G_Int_status = 1;
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string P_Str_condition, P_Str_cmdtxt;
            switch (G_Int_status)
            {
                case 1:
                    string P_Str_select = "SELECT Name FROM tb_User WHERE Name = '"+this.txtName.Text+"' ";
                    SqlDataReader P_dr1 = G_SqlClass.GetReader(P_Str_select);
                    P_dr1.Read();
                    if (P_dr1.HasRows)
                    {
                        MessageBox.Show("��Ա���Ѿ��Ǽǣ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    P_dr1.Close();
                    //������Ҫִ�е�SQL���
                    P_Str_cmdtxt = "INSERT INTO tb_User(Name,Sex,Birthday,Department,Post,PhoneH,PhoneM,Address,PopedomID)";
                    P_Str_cmdtxt += " VALUES('" + this.txtName.Text + "','" + this.cbxSex.Items[this.cbxSex.SelectedIndex].ToString() + "','" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "'";
                    P_Str_cmdtxt += ",'" + this.cbxDepartment.SelectedValue.ToString() + "','" + this.cbxPost.SelectedValue.ToString() + "'";
                    P_Str_cmdtxt += ",'" + this.txtPhoneH.Text + "','" + this.txtPhoneM.Text + "','" + this.txtAddress.Text + "','0')";

                    if (this.txtName.Text == "")
                    {
                        MessageBox.Show("Ա����������Ϊ�գ�", "��ʾ�Ի���", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    P_Str_condition = this.dgvUserInfo[0, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();
                    P_Str_cmdtxt = "UPDATE tb_User SET [Name]='" + this.txtName.Text + "',Sex='" + this.cbxSex.Items[this.cbxSex.SelectedIndex].ToString() + "'";
                    P_Str_cmdtxt += ",Birthday='" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "',Department='" + this.cbxDepartment.SelectedValue.ToString() +"'";
                    P_Str_cmdtxt += ",Post='"+this.cbxPost.SelectedValue.ToString() +"',PhoneH='" + this.txtPhoneH.Text + "',PhoneM='" + this.txtPhoneM.Text + "'";
                    P_Str_cmdtxt += ",Address='" + this.txtAddress.Text + "' WHERE UserID=" + P_Str_condition + "";

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
            }
            //��������ʾ�ؼ�
            string cmdtxt = "SELECT UserID as Ա��ID,Name as Ա������,Sex as Ա���Ա�,Birthday as ��������,Department as ��������,Post as ����ְλ";
            cmdtxt += ",PhoneH as ��ͥ�绰,PhoneM as �ֻ�����,Address as ��ͥסַ FROM tb_User";
            this.dgvUserInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
            ControlStatus();
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            G_Int_status = 2;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string P_Str_condition = this.dgvUserInfo[0, this.dgvUserInfo.CurrentCell.RowIndex].Value.ToString();
            string P_Str_cmdtxt = "DELETE FROM tb_User WHERE UserID=" + P_Str_condition + "";
            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                MessageBox.Show("����ɾ���ɹ���");
            }
            else
            {
                MessageBox.Show("����ɾ��ʧ�ܣ�");
            }
            string cmdtxt = "SELECT UserID as Ա��ID,Name as Ա������,Sex as Ա���Ա�,Birthday as ��������,Department as ��������,Post as ����ְλ";
            cmdtxt += ",PhoneH as ��ͥ�绰,PhoneM as �ֻ�����,Address as ��ͥסַ FROM tb_User";
            this.dgvUserInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = String.Empty; 
            string P_Str_selectcondition = this.cbxCondition.Items[this.cbxCondition.SelectedIndex].ToString();
            switch (P_Str_selectcondition)
            {
                case "Ա������":
                    P_Str_cmdtxt = "SELECT UserID as Ա��ID,Name as Ա������,Sex as Ա���Ա�,Birthday as ��������,Department as ��������,Post as ����ְλ";
                    P_Str_cmdtxt += ",PhoneH as ��ͥ�绰,PhoneM as �ֻ�����,Address as ��ͥסַ FROM tb_User WHERE [Name] LIKE '%" + this.txtKeyWord.Text + "%'";
                    this.dgvUserInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                case "Ա���Ա�":
                    P_Str_cmdtxt = "SELECT UserID as Ա��ID,Name as Ա������,Sex as Ա���Ա�,Birthday as ��������,Department as ��������,Post as ����ְλ";
                    P_Str_cmdtxt += ",PhoneH as ��ͥ�绰,PhoneM as �ֻ�����,Address as ��ͥסַ FROM tb_User WHERE Sex='" + this.txtKeyWord.Text + "'";
                    this.dgvUserInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                case "��������":
                    P_Str_cmdtxt = "SELECT UserID as Ա��ID,Name as Ա������,Sex as Ա���Ա�,Birthday as ��������,Department as ��������,Post as ����ְλ";
                    P_Str_cmdtxt += ",PhoneH as ��ͥ�绰,PhoneM as �ֻ�����,Address as ��ͥסַ FROM tb_User WHERE Department LIKE '%" + this.txtKeyWord.Text + "%'";
                    this.dgvUserInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                case "Ա��ְλ":
                    P_Str_cmdtxt = "SELECT UserID as Ա��ID,Name as Ա������,Sex as Ա���Ա�,Birthday as ��������,Department as ��������,Post as ����ְλ";
                    P_Str_cmdtxt += ",PhoneH as ��ͥ�绰,PhoneM as �ֻ�����,Address as ��ͥסַ FROM tb_User WHERE Post LIKE '%" + this.txtKeyWord.Text + "%'";
                    this.dgvUserInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                default:
                    break;
            }
        }

        private void toolrefesh_Click(object sender, EventArgs e)
        {
            string cmdtxt = "SELECT UserID as Ա��ID,Name as Ա������,Sex as Ա���Ա�,Birthday as ��������,Department as ��������,Post as ����ְλ";
            cmdtxt += ",PhoneH as ��ͥ�绰,PhoneM as �ֻ�����,Address as ��ͥסַ FROM tb_User";
            this.dgvUserInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }



    }
}