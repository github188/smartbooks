using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;

namespace GoodsReportManage.SysManage
{
    public partial class ChangePwd : Form
    {
        public ChangePwd()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();
        WinOperationClass G_WinFormClass = new WinOperationClass();

        private void ChangePwd_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.txtInitPwd.Text.Length < 6)
            {
                this.errorProvider1.SetError(this.txtInitPwd, "���벻��С��6λ��");
                return;
            }
            if (this.txtAmendPwd.Text.Length < 6)
            {
                this.errorProvider1.SetError(this.txtAmendPwd, "���벻��С��6λ��");
                return;
            }
            if (this.txtOkPwd.Text.Length < 6)
            {
                this.errorProvider1.SetError(this.txtOkPwd, "���벻��С��6λ��");
                return;
            }
            if (this.txtInitPwd.Text.Trim() == G_WinFormClass.DESDecrypt(PropertyClass.SavePassword))
            {
                if (this.txtAmendPwd.Text == this.txtOkPwd.Text)
                {
                    string P_Str_cmdtxt = "UPDATE tb_User SET Pwd='" + G_WinFormClass.DESEncrypt(this.txtAmendPwd.Text.Trim()) + "' where UserID = '" + PropertyClass.SendUserIDValue + "'";
                    if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                    {
                        MessageBox.Show("�����޸ĳɹ����´ε�¼ʱ�޸ĵ����뽫��Ч��", "��ʾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("�����޸�ʧ�ܣ�", "��ʾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("�����������벻һ�£�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("����������ԭʼ���벻һ�£�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}