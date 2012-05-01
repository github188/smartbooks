using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;

namespace GoodsReportManage.BaseRecord
{
    public partial class CustomerInfo : Form
    {
        public CustomerInfo()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();  //声明数据库操作类的对象
        WinOperationClass G_OperationForm = new WinOperationClass();  //声明对窗体操作的类对象
        int G_Int_status;  //保存工具栏按钮操作状态

        /// <summary>
        /// 控制控件状态
        /// </summary>
        private void ControlStatus()
        {
            this.groupBox1.Enabled = !this.groupBox1.Enabled;

            this.toolSave.Enabled = !this.toolSave.Enabled;
            this.toolAdd.Enabled = !this.toolAdd.Enabled;
            this.toolCancel.Enabled = !this.toolCancel.Enabled;
            this.toolAmend.Enabled = !this.toolAmend.Enabled;

            this.dgvCustomerInfo.Enabled = !this.dgvCustomerInfo.Enabled;
        }

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.txtName.Text = this.dgvCustomerInfo[1, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtPhoneH.Text = this.dgvCustomerInfo[4, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtPhoneM.Text = this.dgvCustomerInfo[5, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtAddress.Text = this.dgvCustomerInfo[6, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtRemark.Text = this.dgvCustomerInfo[7, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();

                this.cbxSex.Text = this.dgvCustomerInfo[2, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();

                this.dtBirthday.Value = Convert.ToDateTime(this.dgvCustomerInfo[3, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString());
            }
            catch { }
        }

        /// <summary>
        /// 将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            this.cbxSex.SelectedIndex = 0;

            this.txtAddress.Text = "";
            this.txtName.Text = "";
            this.txtPhoneH.Text = "";
            this.txtPhoneM.Text = "";
            this.txtRemark.Text = "";

            this.dtBirthday.Value = DateTime.Now;
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            string cmdtxt = "SELECT CustomerID as 客户ID,Name as 客户姓名,Sex as 客户性别,Birthday as 出生日期";
            cmdtxt += ",PhoneH as 家庭电话,PhoneM as 手机号码,Address as 家庭住址,Remark as 备注 FROM tb_Customer";
            this.dgvCustomerInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];

            this.cbxSex.SelectedIndex = 0;   //设置默认选项
            this.cbxCondition.SelectedIndex = 0;

            this.dgvCustomerInfo.Columns[0].Visible = false;  //设置DataGridView控件隐藏列
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string P_Str_condition, P_Str_cmdtxt;
            switch (G_Int_status)
            {
                case 1:
                    //下面是要执行的SQL语句
                    P_Str_cmdtxt = "INSERT INTO tb_Customer(Name,Sex,Birthday,PhoneH,PhoneM,Address,Remark)";
                    P_Str_cmdtxt += " VALUES('" + this.txtName.Text + "','" + this.cbxSex.Items[this.cbxSex.SelectedIndex].ToString() + "','" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "'";
                    P_Str_cmdtxt += ",'" + this.txtPhoneH.Text + "','" + this.txtPhoneM.Text + "'";
                    P_Str_cmdtxt += ",'" + this.txtAddress.Text + "','" + this.txtRemark.Text + "')";

                    if (this.txtName.Text == "")
                    {
                        MessageBox.Show("客户姓名不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        //执行SQL语句并返回执行结果
                        if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                        {

                            MessageBox.Show("数据添加成功！");
                            ControlStatus();
                        }
                        else
                        {
                            MessageBox.Show("数据添加失败！");
                        }
                    }
                    break;
                case 2:
                    P_Str_condition = this.dgvCustomerInfo[0, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
                    P_Str_cmdtxt = "UPDATE tb_Customer SET [Name]='" + this.txtName.Text + "',Sex='" + this.cbxSex.Items[this.cbxSex.SelectedIndex].ToString() + "'";
                    P_Str_cmdtxt += ",Birthday='" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "'";
                    P_Str_cmdtxt += ",PhoneH='" + this.txtPhoneH.Text + "',PhoneM='" + this.txtPhoneM.Text + "'";
                    P_Str_cmdtxt += ",Address='" + this.txtAddress.Text + "',Remark='" + this.txtRemark.Text + "' WHERE CustomerID=" + P_Str_condition + "";

                    if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                    {
                        MessageBox.Show("数据修改成功！");
                        ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("数据修改失败！");
                    }
                    break;
                default:
                    break;
            }
            //绑定数据显示控件
            string cmdtxt = "SELECT CustomerID as 客户ID,Name as 客户姓名,Sex as 客户性别,Birthday as 出生日期";
            cmdtxt += ",PhoneH as 家庭电话,PhoneM as 手机号码,Address as 家庭住址,Remark as 备注 FROM tb_Customer";
            this.dgvCustomerInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
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
            string P_Str_condition = this.dgvCustomerInfo[0, this.dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            string P_Str_cmdtxt = "DELETE FROM tb_Customer WHERE CustomerID=" + P_Str_condition + "";
            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                MessageBox.Show("数据删除成功！");
            }
            else
            {
                MessageBox.Show("数据删除失败！");
            }
            string cmdtxt = "SELECT CustomerID as 客户ID,Name as 客户姓名,Sex as 客户性别,Birthday as 出生日期";
            cmdtxt += ",PhoneH as 家庭电话,PhoneM as 手机号码,Address as 家庭住址,Remark as 备注 FROM tb_Customer";
            this.dgvCustomerInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void toolrefesh_Click(object sender, EventArgs e)
        {
            string cmdtxt = "SELECT CustomerID as 客户ID,Name as 客户姓名,Sex as 客户性别,Birthday as 出生日期";
            cmdtxt += ",PhoneH as 家庭电话,PhoneM as 手机号码,Address as 家庭住址,Remark as 备注 FROM tb_Customer";
            this.dgvCustomerInfo.DataSource = G_SqlClass.GetDs(cmdtxt).Tables[0];
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = String.Empty;
            string P_Str_selectcondition = this.cbxCondition.Items[this.cbxCondition.SelectedIndex].ToString();
            switch (P_Str_selectcondition)
            {
                case "客户姓名":
                    P_Str_cmdtxt = "SELECT CustomerID as 客户ID,Name as 客户姓名,Sex as 客户性别,Birthday as 出生日期";
                    P_Str_cmdtxt += ",PhoneH as 家庭电话,PhoneM as 手机号码,Address as 家庭住址,Remark as 备注 FROM tb_Customer";
                    P_Str_cmdtxt += " WHERE Name LIKE '%"+this.txtKeyWord.Text+"%'";
                    this.dgvCustomerInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                case "客户性别":
                    P_Str_cmdtxt = "SELECT CustomerID as 客户ID,Name as 客户姓名,Sex as 客户性别,Birthday as 出生日期";
                    P_Str_cmdtxt += ",PhoneH as 家庭电话,PhoneM as 手机号码,Address as 家庭住址,Remark as 备注 FROM tb_Customer";
                    P_Str_cmdtxt += " WHERE Sex = '"+this.txtKeyWord.Text+"'";
                    this.dgvCustomerInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                case "手机号码":
                    P_Str_cmdtxt = "SELECT CustomerID as 客户ID,Name as 客户姓名,Sex as 客户性别,Birthday as 出生日期";
                    P_Str_cmdtxt += ",PhoneH as 家庭电话,PhoneM as 手机号码,Address as 家庭住址,Remark as 备注 FROM tb_Customer";
                    P_Str_cmdtxt += " WHERE PhoneM LIKE '%"+this.txtKeyWord.Text+"%'";
                    this.dgvCustomerInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
                    break;
                default:
                    break;
            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

    }
}