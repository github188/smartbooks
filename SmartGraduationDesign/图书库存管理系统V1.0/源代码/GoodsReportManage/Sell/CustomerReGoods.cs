using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.Stock;
using GoodsReportManage.ItemClass;
using System.Data.SqlClient;

namespace GoodsReportManage.Sell
{
    public partial class CustomerReGoods : Form
    {
        public CustomerReGoods()
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
            this.dgvReGoodsInfo.Enabled = !this.dgvReGoodsInfo.Enabled;
        }

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.labReGoodsID.Text = this.dgvReGoodsInfo[0, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetDgvData = this.dgvReGoodsInfo[2, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetSellPrice = this.dgvReGoodsInfo[8, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetStockSpec = this.dgvReGoodsInfo[7, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtHasPay.Text = this.dgvReGoodsInfo[10, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNeedPay.Text = this.dgvReGoodsInfo[9, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNum.Text = this.dgvReGoodsInfo[5, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtResult.Text = this.dgvReGoodsInfo[11, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxUnit.Text = this.dgvReGoodsInfo[6, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxCustomerName.Text = this.dgvReGoodsInfo[3, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                this.dtBirthday.Value = Convert.ToDateTime(this.dgvReGoodsInfo[3, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString());
            }
            catch { }
        }

        /// <summary>
        /// 将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            this.cbxUnit.SelectedIndex = 0;
            this.cbxCustomerName.SelectedIndex = 0;
            this.txtGoodsName.Text = "";
            this.txtHasPay.Text = "";
            this.txtNeedPay.Text = "";
            this.txtNum.Text = "";
            this.txtReGoodsPrice.Text = "";
            this.txtResult.Text = "";
            this.txtSpec.Text = "";
            this.dtBirthday.Value = DateTime.Now;
            this.labReGoodsID.Text = "";
        }

        private void ReGoods_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            string P_Str_cmdtxt = "SELECT ReGoodsID as 退货ID,GoodsID as 进货ID,ReGoodsName as 图书名称,Name as 顾客姓名,ReGoodsTime as 退货日期";
            P_Str_cmdtxt += ",ReGoodsNum as 退货数量,ReGoodsUnit as 图书单位,ReGoodsSpec as 图书规格,ReGoodsPrice as 销售价格,NeedPay as 应付金额";
            P_Str_cmdtxt += ",HasPay as 实付金额,ReGoodsResult as 退货原因 FROM v_ReGoods WHERE ReGoodsSort='1'";
            this.dgvReGoodsInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            G_OperationForm.BindComboBox("SELECT * FROM tb_Unit", cbxUnit, "UnitName");
            G_OperationForm.BindComboBox("SELECT * FROM tb_Customer", cbxCustomerName, "Name");
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string P_Str_condition, P_Str_cmdtxt;
            switch (G_Int_status)
            {
                case 1:
                    if (this.cbxCustomerName.SelectedValue.ToString() != "")
                    {
                        if (this.txtGoodsName.Text == "")
                        {
                            MessageBox.Show("图书名称不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtNum.Text == "")
                        {
                            MessageBox.Show("图书数量不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtReGoodsPrice.Text == "")
                        {
                            MessageBox.Show("图书进价不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (!G_OperationForm.IsNumeric(this.txtNum.Text) && !G_OperationForm.IsNumeric(this.txtHasPay.Text)
                            && !G_OperationForm.IsNumeric(this.txtReGoodsPrice.Text))
                        {
                            MessageBox.Show("您输入的数据格式有误！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        string P_Str_Id = String.Empty;
  
                        //检索数据库中对应客户的ID
                        string P_Str_cmdtxt2 = "SELECT CustomerID,Name FROM tb_Customer WHERE Name='"+this.cbxCustomerName.SelectedValue.ToString()+"'";
                        SqlDataReader P_dr = G_SqlClass.GetReader(P_Str_cmdtxt2);
                        P_dr.Read();
                        if (P_dr.HasRows)
                        {
                            P_Str_Id = P_dr["CustomerID"].ToString();
                        }
                        P_dr.Close();
                        //下面是要执行的SQL语句
                        P_Str_cmdtxt = "INSERT INTO tb_ReGoods(ReGoodsID,GoodsID,UserID,CustomerID,ReGoodsName,ReGoodsSpec,ReGoodsNum,ReGoodsUnit";
                        P_Str_cmdtxt += ",ReGoodsTime,ReGoodsPrice,NeedPay,HasPay,ReGoodsResult,ReGoodsSort,StockID) VALUES('" + this.labReGoodsID.Text + "'";
                        P_Str_cmdtxt += ",'" + PropertyClass.GetGoodsID + "','" + PropertyClass.SendUserIDValue + "'," + P_Str_Id + "";
                        P_Str_cmdtxt += ",'" + this.txtGoodsName.Text + "','" + this.txtSpec.Text + "','" + this.txtNum.Text + "'";
                        P_Str_cmdtxt += ",'" + this.cbxUnit.SelectedValue.ToString() + "','" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "'";
                        P_Str_cmdtxt += "," + Convert.ToDecimal(this.txtReGoodsPrice.Text) + "," + Convert.ToDecimal(this.txtNeedPay.Text) + "," + Convert.ToDecimal(this.txtHasPay.Text) + "";
                        P_Str_cmdtxt += ",'" + this.txtResult.Text + "','1','" + PropertyClass.GetStockID + "')";

                        if (this.txtGoodsName.Text == "")
                        {
                            MessageBox.Show("图书名称不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            SqlDataReader P_dr2 = G_SqlClass.GetReader("select GoodsID,GoodsNum from tb_Sell where GoodsID='" 
                                + PropertyClass.GetGoodsID + "' and GoodsNum<'" + Convert.ToInt32(txtNum.Text.Trim()) + "'");
                            P_dr2.Read();
                            if (P_dr2.HasRows)
                            {
                                MessageBox.Show("没有销售过这么多图书，请重新填写退货数量！");
                                txtNum.Text = "";
                                txtNum.Focus();
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
                            P_dr2.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择客户姓名！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                    if (this.cbxCustomerName.SelectedValue.ToString() != "")
                    {
                        string P_Str_Id = String.Empty;

                        //检索数据库中对应客户的ID
                        string P_Str_cmdtxt2 = "SELECT CustomerID,Name FROM tb_Customer WHERE Name='" + this.cbxCustomerName.SelectedValue.ToString() + "'";
                        SqlDataReader P_dr = G_SqlClass.GetReader(P_Str_cmdtxt2);
                        P_dr.Read();
                        if (P_dr.HasRows)
                        {
                            P_Str_Id = P_dr["CustomerID"].ToString();
                        }
                        P_dr.Close();

                        P_Str_condition = this.dgvReGoodsInfo[0, this.dgvReGoodsInfo.CurrentCell.RowIndex].Value.ToString();
                        P_Str_cmdtxt = "UPDATE tb_ReGoods SET ReGoodsName='" + this.txtGoodsName.Text + "',ReGoodsSpec='" + this.txtSpec.Text + "'";
                        P_Str_cmdtxt += ",ReGoodsTime='" + this.dtBirthday.Value + "',CustomerID = "+P_Str_Id+",ReGoodsNum='" + this.txtNum.Text + "'";
                        P_Str_cmdtxt += ",ReGoodsUnit='" + this.cbxUnit.SelectedValue.ToString() + "',ReGoodsPrice=" + Convert.ToDecimal(this.txtReGoodsPrice.Text) + "";
                        P_Str_cmdtxt += ",ReGoodsResult='" + this.txtResult.Text + "',NeedPay=" + Convert.ToDecimal(this.txtNeedPay.Text) + ",HasPay=" + Convert.ToDecimal(this.txtHasPay.Text) + "";
                        P_Str_cmdtxt += " WHERE ReGoodsID='" + P_Str_condition + "'";

                        if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                        {
                            MessageBox.Show("数据修改成功！");
                            ControlStatus();
                            PropertyClass.GetGoodsID = null;
                        }
                        else
                        {
                            MessageBox.Show("数据修改失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择客户姓名！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                default:
                    break;
            }
            //绑定数据显示控件
            string P_Str_cmdtxt1 = "SELECT ReGoodsID as 退货ID,GoodsID as 进货ID,ReGoodsName as 图书名称,Name as 顾客姓名,ReGoodsTime as 退货日期";
            P_Str_cmdtxt1 += ",ReGoodsNum as 退货数量,ReGoodsUnit as 图书单位,ReGoodsSpec as 图书规格,ReGoodsPrice as 进货价格,NeedPay as 应付金额";
            P_Str_cmdtxt1 += ",HasPay as 实付金额,ReGoodsResult as 退货原因 FROM v_ReGoods WHERE ReGoodsSort='1'";
            this.dgvReGoodsInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt1).Tables[0];
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
                MessageBox.Show("数据删除成功！");
            }
            else
            {
                MessageBox.Show("数据删除失败！");
            }
            string P_Str_cmdtxt1 = "SELECT ReGoodsID as 退货ID,GoodsID as 进货ID,ReGoodsName as 图书名称,Name as 顾客姓名,ReGoodsTime as 退货日期";
            P_Str_cmdtxt1 += ",ReGoodsNum as 退货数量,ReGoodsUnit as 图书单位,ReGoodsSpec as 图书规格,ReGoodsPrice as 进货价格,NeedPay as 应付金额";
            P_Str_cmdtxt1 += ",HasPay as 实付金额,ReGoodsResult as 退货原因 FROM v_ReGoods WHERE ReGoodsSort='1'";
            this.dgvReGoodsInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt1).Tables[0];
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReGoodsInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SellFind sellfind = new SellFind();
            sellfind.StartPosition = FormStartPosition.CenterParent;
            sellfind.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PropertyClass.GetDgvData != null)
            {
                this.txtGoodsName.Text = PropertyClass.GetDgvData;
                this.txtReGoodsPrice.Text = PropertyClass.GetSellPrice;
                this.txtSpec.Text = PropertyClass.GetStockSpec;
            }
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (this.txtReGoodsPrice.Text != "" && this.txtNum.Text != "" && G_OperationForm.IsNumeric(this.txtNum.Text))
            {
                this.txtNeedPay.Text = Convert.ToString(Convert.ToDecimal(this.txtReGoodsPrice.Text) * Convert.ToInt32(this.txtNum.Text));
            }
        }
    }
}