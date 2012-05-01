using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Data.SqlClient;  //添加引用
using GoodsReportManage.ItemClass;
using System.Diagnostics;

namespace GoodsReportManage
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlExecute = new SqlBaseClass();    //声明类对象
        PropertyClass G_Property = new PropertyClass();
        WinOperationClass G_WinFormClass = new WinOperationClass();

        private void Login_Load(object sender, EventArgs e)
        {
            string cmdtxt = "SELECT postname FROM tb_post";
            this.cbxDegree.BeginUpdate();
            this.cbxDegree.DataSource = G_SqlExecute.GetDs(cmdtxt).Tables[0];
            this.cbxDegree.DisplayMember = "postname";
            this.cbxDegree.ValueMember = "postname";
            this.cbxDegree.EndUpdate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtUid.Text.Length == 0)
            {
                this.errAllInfo.SetError(this.txtUid, "用户名不能为空！");
            }
            if (this.txtPwd.Text.Length < 6)
            {
                this.errAllInfo.SetError(this.txtPwd, "密码不能小于6位！");
            }
            string P_DESDcrypt = G_WinFormClass.DESEncrypt(this.txtPwd.Text);
            string cmdtxt = "SELECT UserID,SysLoginName,Pwd,SysUserSort,PopedomID FROM v_UserView WHERE SysLoginName='"+this.txtUid.Text.Trim()+"'";
            cmdtxt += "AND Pwd='"+ P_DESDcrypt +"' AND SysUserSort='"+this.cbxDegree.SelectedValue.ToString()+"'";
            SqlDataReader P_dr = G_SqlExecute.GetReader(cmdtxt);
            P_dr.Read();
            if (P_dr.HasRows)
            {
                AppMain AppForm = new AppMain();
                this.Hide();
                PropertyClass.SendNameValue = this.txtUid.Text;
                PropertyClass.SendPopedomValue = P_dr["PopedomID"].ToString();
                PropertyClass.SendUserIDValue = P_dr["UserID"].ToString();
                PropertyClass.SavePassword = P_dr["Pwd"].ToString();
                AppForm.Show();
            }
            else
            {
                MessageBox.Show("用户名、密码或身份不正确！", "登录提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                P_dr.Close();
            }
            P_dr.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}