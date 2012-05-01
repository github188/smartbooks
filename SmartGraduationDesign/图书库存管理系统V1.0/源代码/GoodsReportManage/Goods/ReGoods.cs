using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoodsReportManage.ItemClass;　　//添加引用
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
        }

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
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
        /// 将控件恢复到原始状态
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
            string P_Str_cmdtxt = "SELECT ReGoodsID as 退货ID,GoodsID as 进货ID,CompanyName as 供应商名称,ReGoodsName as 图书名称,ReGoodsTime as 退货日期,ReGoodsNum as 退货数量";
            P_Str_cmdtxt += ",ReGoodsUnit as 图书单位,ReGoodsSpec as 图书规格,ReGoodsPrice as 进货价格,NeedPay as 应付金额,HasPay as 实付金额,ReGoodsResult as 退货原因";
            P_Str_cmdtxt += " FROM tb_ReGoods WHERE ReGoodsSort='0'";
            this.dgvReGoodsInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            G_OperationForm.BindComboBox("SELECT * FROM tb_Unit", cbxUnit, "UnitName"); //绑定ComboBox控件
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
                            MessageBox.Show("图书名称不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtNum.Text == "")
                        {
                            MessageBox.Show("图书数量不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtGoodsPrice.Text == "")
                        {
                            MessageBox.Show("图书进价不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtHasPay.Text == "")
                        {
                            MessageBox.Show("销售价格不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (!G_OperationForm.IsNumeric(this.txtNum.Text) && !G_OperationForm.IsNumeric(this.txtGoodsPrice.Text)
                            && !G_OperationForm.IsNumeric(this.txtHasPay.Text))
                        {
                            MessageBox.Show("您输入的数据格式有误！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //下面是要执行的SQL语句
                        P_Str_cmdtxt = "INSERT INTO tb_ReGoods(ReGoodsID,GoodsID,UserID,CompanyName,ReGoodsName,ReGoodsSpec,ReGoodsNum,ReGoodsUnit";
                        P_Str_cmdtxt += ",ReGoodsTime,ReGoodsPrice,NeedPay,HasPay,ReGoodsResult,ReGoodsSort,StockID) VALUES('" + this.labReGoodsID.Text + "'";
                        P_Str_cmdtxt += ",'" + PropertyClass.GetGoodsID + "','" + PropertyClass.SendUserIDValue + "','" + this.cbxCompanyName.SelectedValue.ToString() + "'";
                        P_Str_cmdtxt += ",'" + this.txtGoodsName.Text + "','" + this.txtSpec.Text + "','" + this.txtNum.Text + "'";
                        P_Str_cmdtxt += ",'" + this.cbxUnit.SelectedValue.ToString() + "','" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "'";
                        P_Str_cmdtxt += "," + this.txtGoodsPrice.Text + "," + this.txtNeedPay.Text + "," + this.txtHasPay.Text + "";
                        P_Str_cmdtxt += ",'" + this.txtResult.Text + "','0','" + PropertyClass.GetStockID + "')";

                        if (this.txtGoodsName.Text == "")
                        {
                            MessageBox.Show("图书名称不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            SqlDataReader P_dr2 = G_SqlClass.GetReader("select GoodsID,StockNum from tb_Stock where GoodsID='"
                                + PropertyClass.GetGoodsID + "' and StockNum<'" + Convert.ToInt32(txtNum.Text.Trim()) + "'");
                            P_dr2.Read();
                            if (P_dr2.HasRows)
                            {
                                MessageBox.Show("库存中没有如此多的图书，请重新填写退货数量！");
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
                                    PropertyClass.GetDgvData = null;
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
                        MessageBox.Show("请选择供应商名称！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("数据修改成功！");
                                ControlStatus();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("数据修改失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择供应商名称！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("数据删除成功！");
            }
            else
            {
                MessageBox.Show("数据删除失败！");
            }
            string P_Str_cmdtxt1 = "SELECT ReGoodsID as 退货ID,GoodsID as 进货ID,ReGoodsName as 图书名称,ReGoodsTime as 退货日期,ReGoodsNum as 退货数量";
            P_Str_cmdtxt1 += ",ReGoodsUnit as 图书单位,ReGoodsSpec as 图书规格,ReGoodsPrice as 进货价格,NeedPay as 应付金额,HasPay as 实付金额,ReGoodsResult as 退货原因";
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