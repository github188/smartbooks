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
                this.errorProvider1.SetError(this.txtInitPwd, "密码不能小于6位！");
                return;
            }
            if (this.txtAmendPwd.Text.Length < 6)
            {
                this.errorProvider1.SetError(this.txtAmendPwd, "密码不能小于6位！");
                return;
            }
            if (this.txtOkPwd.Text.Length < 6)
            {
                this.errorProvider1.SetError(this.txtOkPwd, "密码不能小于6位！");
                return;
            }
            if (this.txtInitPwd.Text.Trim() == G_WinFormClass.DESDecrypt(PropertyClass.SavePassword))
            {
                if (this.txtAmendPwd.Text == this.txtOkPwd.Text)
                {
                    string P_Str_cmdtxt = "UPDATE tb_User SET Pwd='" + G_WinFormClass.DESEncrypt(this.txtAmendPwd.Text.Trim()) + "' where UserID = '" + PropertyClass.SendUserIDValue + "'";
                    if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                    {
                        MessageBox.Show("密码修改成功，下次登录时修改的密码将生效！", "提示框", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("密码修改失败！", "提示框", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("两次密码输入不一致！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("输入密码与原始密码不一致！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}