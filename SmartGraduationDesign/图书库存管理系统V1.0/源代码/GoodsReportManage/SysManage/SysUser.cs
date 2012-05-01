using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;  //添加引用
using System.Collections;
using System.Data.SqlClient;

namespace GoodsReportManage.SysManage
{
    public partial class SysUser : Form
    {
        public SysUser()
        {
            InitializeComponent();
        }

        WinOperationClass G_WinFormClass = new WinOperationClass();
        SqlBaseClass G_SqlClass = new SqlBaseClass();

        private void SysUser_Load(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = "SELECT Name FROM tb_User";
            this.listBox1.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            this.listBox1.DisplayMember = "Name";
            this.listBox1.ValueMember = "Name";

            this.listBox1.SelectedIndex = 0;
            G_WinFormClass.BindComboBox("SELECT DISTINCT postname FROM tb_post", cbxLogin, "postname");

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cbxLogin.Text == "")
            {
                this.errorProvider1.SetError(this.cbxLogin, "登录身份不能为空！");
                return;
            }
            if (this.checkBox1.Checked && this.txtName.Text == "")
            {
                this.errorProvider1.SetError(this.txtName, "用户名不能为空！");
                return;
            }
            if (this.checkBox2.Checked && this.txtOkPwd.Text != this.txtPwd.Text)
            {
                this.errorProvider1.SetError(this.txtOkPwd, "两次输入密码不一致！");
                return;
            }
            if (this.checkBox2.Checked && this.txtPwd.Text.Length < 6)
            {
                this.errorProvider1.SetError(this.txtPwd, "输入密码不能小于6位！");
                return;
            }
            if (this.checkBox2.Checked && this.txtOkPwd.Text.Length < 6)
            {
                this.errorProvider1.SetError(this.txtOkPwd, "输入密码不能小于6位！");
                return;
            }
            //从树控件中读取设置的值
            ArrayList arylst = new ArrayList();
            foreach (TreeNode nodes in this.treeView1.Nodes)
            {
                foreach (TreeNode node in nodes.Nodes)
                {
                    if (node.Checked)
                    {
                        arylst.Add("1");
                    }
                    else
                    {
                        arylst.Add("0");
                    }
                }
            }
           if (this.labMessage.Text == "该用户已为系统用户")
            {
                //判断权限表中是否存在要设置权限的用户
                string P_Str_select2 = "SELECT * FROM tb_User WHERE Name = '" + this.listBox1.SelectedValue.ToString() + "'";
                SqlDataReader P_dr4 = G_SqlClass.GetReader(P_Str_select2);
                P_dr4.Read();
                string loginame = String.Empty;
                if (P_dr4.HasRows)
                {
                    loginame = P_dr4["SysLoginName"].ToString();
                }
                P_dr4.Close();
                if (MessageBox.Show("是否确认修改？", "提示对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                    == DialogResult.OK)
                {
                    string P_Str_cmdtxt = String.Empty;

                    if (this.checkBox1.Checked)
                    {
                        string P_Str_select = "SELECT * FROM tb_User WHERE SysLoginName = '" + this.txtName.Text + "'";
                        SqlDataReader P_dr2 = G_SqlClass.GetReader(P_Str_select);
                        P_dr2.Read();
                        if (P_dr2.HasRows)
                        {
                           MessageBox.Show("该用户已存在！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           return;
                        }
                        else
                        {
                            P_Str_cmdtxt = "UPDATE tb_User SET SysLoginName = '" + this.txtName.Text + "'";
                            P_Str_cmdtxt += " WHERE SysLoginName = '" + loginame + "'";
                            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                            {
                                string P_Str_cmdtxt2 = "UPDATE tb_Popedom SET SysUserName='" + this.txtName.Text + "'  WHERE SysUserName = '" + loginame + "'";
                                G_SqlClass.GetExecute(P_Str_cmdtxt2);
                            }
                            else
                            {
                                MessageBox.Show("用户修改失败！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    if (this.checkBox2.Checked)
                    {
                        P_Str_cmdtxt = "UPDATE tb_User SET Pwd = '" + G_WinFormClass.DESEncrypt(this.txtOkPwd.Text) + "'";
                        P_Str_cmdtxt += " where UserID = '" + PropertyClass.SendUserIDValue + "'";
                        if (!G_SqlClass.GetExecute(P_Str_cmdtxt))
                        {
                            MessageBox.Show("用户修改失败！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            G_SqlClass.GetExecute(P_Str_cmdtxt);
                        }
                    }
                    MessageBox.Show("用户修改成功,系统下次启动后生效！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string P_Str_cmdtxt = String.Empty;
                string P_Str_update = String.Empty;
                string P_Str_select = String.Empty;
                //执行设置系统用户及权限的语句
                P_Str_cmdtxt = "INSERT INTO tb_Popedom(SysUserSort,SysUserName,EmployeeInfo,CompanyInfo,CustomerInfo";
                P_Str_cmdtxt += ",GoodsInInfo,GoodsOutInfo,SellGoodsInfo,ReGoodsInfo,StockChangeInfo,StockAlarmInfo";
                P_Str_cmdtxt += ",SysUser,PopedomInfo,BakDataInfo,ReBakDataInfo) VALUES('" + this.cbxLogin.Text + "','" + this.listBox1.SelectedValue.ToString() + "'";
                P_Str_cmdtxt += "," + arylst[0].ToString() + "," + arylst[1].ToString() + "," + arylst[2].ToString() + "";
                P_Str_cmdtxt += "," + arylst[3].ToString() + "," + arylst[4].ToString() + "," + arylst[5].ToString() + "";
                P_Str_cmdtxt += "," + arylst[6].ToString() + "," + arylst[7].ToString() + "," + arylst[8].ToString() + "";
                P_Str_cmdtxt += "," + arylst[9].ToString() + "," + arylst[10].ToString() + "," + arylst[11].ToString() + "," + arylst[12].ToString() + ")";
                if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                {
                    //获取权限表中最后一条记录
                    P_Str_select = "SELECT PopedomID FROM tb_Popedom WHERE SysUserName = '" + this.listBox1.SelectedValue.ToString() + "'";
                    DataSet P_ds = G_SqlClass.GetDs(P_Str_select);
                    string P_Str_Num = P_ds.Tables[0].Rows[0][0].ToString();
                    P_Str_update = "UPDATE tb_User SET SysLoginName = '" + this.listBox1.SelectedValue.ToString() + "'";
                    P_Str_update += ",Pwd='" + G_WinFormClass.DESEncrypt(this.txtOkPwd.Text) + "',PopedomID='" + P_Str_Num + "' WHERE Name = '" + this.listBox1.SelectedValue.ToString() + "'";
                    G_SqlClass.GetExecute(P_Str_update);
                    MessageBox.Show("权限设置成功,系统下次启动时生效！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("权限设置失败！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.txtName.ReadOnly = false;
            }
            else
            {
                this.txtName.ReadOnly = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.txtPwd.ReadOnly = false;
                this.txtOkPwd.ReadOnly = false;
            }
            else
            {
                this.txtPwd.ReadOnly = true;
                this.txtOkPwd.ReadOnly = true;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string P_Str_cmdtxt2 = "SELECT * FROM tb_User WHERE Name = '" + this.listBox1.SelectedValue.ToString() + "'";
            P_Str_cmdtxt2 += " AND SysLoginName IS NOT NULL";
            SqlDataReader P_dr1 = G_SqlClass.GetReader(P_Str_cmdtxt2);
            P_dr1.Read();
            if (!P_dr1.HasRows)
            {
                this.checkBox1.Enabled = false;
                this.checkBox2.Enabled = false;
                this.checkBox2.Checked = true;
                this.cbxLogin.Enabled = true;
                this.treeView1.Enabled = true;
                this.labMessage.Text = "该用户不为系统用户";
            }
            else
            {
                this.checkBox1.Enabled = true;
                this.checkBox2.Enabled = true;
                this.checkBox2.Checked = false;
                this.treeView1.Enabled = false;
                this.cbxLogin.Enabled = false;
                SqlDataReader P_dr2 = G_SqlClass.GetReader("SELECT UserID,Name,SysUserSort FROM v_UserView"
                    + " WHERE Name = '" + this.listBox1.SelectedValue.ToString() + "'");
                if (P_dr2.Read())
                {
                    PropertyClass.SendUserIDValue = P_dr2["UserID"].ToString();
                    this.cbxLogin.SelectedValue = P_dr2["SysUserSort"].ToString();
                }
                P_dr2.Close();
                this.labMessage.Text = "该用户已为系统用户";
            }
            P_dr1.Close();
        }
    }
}