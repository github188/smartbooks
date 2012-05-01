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
    public partial class s : Form
    {
        public s()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();
        WinOperationClass G_OperationClass = new WinOperationClass();
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

            this.dgvSellInfo.Enabled = !this.dgvSellInfo.Enabled;

        }

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.labGoodsID.Text = this.dgvSellInfo[0, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtHasPay.Text = this.dgvSellInfo[11, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNeedPay.Text = this.dgvSellInfo[10, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNum.Text = this.dgvSellInfo[4, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtRemark.Text = this.dgvSellInfo[12, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxUnit.Text = this.dgvSellInfo[5, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxSellName.Text = this.dgvSellInfo[2, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                this.dtBirthday.Value = Convert.ToDateTime(this.dgvSellInfo[7, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString());
                PropertyClass.GetDgvData = this.dgvSellInfo[3, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetGoodsInPrice = this.dgvSellInfo[8, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetSellPrice = this.dgvSellInfo[9, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                PropertyClass.GetStockSpec = this.dgvSellInfo[6, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
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
            this.txtGoodsInPrice.Text = "";
            this.txtRemark.Text = "";
            this.txtSpec.Text = "";
            this.txtSellPrice.Text = "";

            this.dtBirthday.Value = DateTime.Now;

            this.labGoodsID.Text = "";
        }

        private void SellGoods_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            string P_Str_cmdtxt = "SELECT SellID,GoodsID as 图书ID,[Name] as 销售员姓名,GoodsName as 图书名称";
            P_Str_cmdtxt +=",GoodsNum as 销售数量,GoodsUnit as 图书单位,GoodsSpec as 图书规格,GoodsTime as 销售时间";
            P_Str_cmdtxt += ",GoodsPrice 进货价格,SellPrice as 销售价格,NeedPay as 应收金额,HasPay as 实收金额,Remark as 备注";
            P_Str_cmdtxt += " FROM v_UserSell";
            this.dgvSellInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            G_OperationClass.BindComboBox("SELECT * FROM tb_Customer", cbxCustomerName, "Name");
            G_OperationClass.BindComboBox("SELECT * FROM tb_Unit", cbxUnit, "UnitName");
            G_OperationClass.BindComboBox("SELECT * FROM tb_User",cbxSellName,"Name");
        }

        private void btnFindGoods_Click(object sender, EventArgs e)
        {
            StockFind stockfind = new StockFind();
            stockfind.StartPosition = FormStartPosition.CenterScreen;
            stockfind.ShowDialog();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string P_Str_condition, P_Str_cmdtxt;
            switch (G_Int_status)
            {
                case 1:
                    if (this.cbxSellName.SelectedValue.ToString() != "")
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
                        if (this.txtGoodsInPrice.Text == "")
                        {
                            MessageBox.Show("图书进价不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtSellPrice.Text == "")
                        {
                            MessageBox.Show("销售价格不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.txtNeedPay.Text == "")
                        {
                            MessageBox.Show("应付金额不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (!G_OperationClass.IsNumeric(this.txtNum.Text) && !G_OperationClass.IsNumeric(this.txtGoodsInPrice.Text)
                            && !G_OperationClass.IsNumeric(this.txtHasPay.Text) && !G_OperationClass.IsNumeric(this.txtSellPrice.Text))
                        {
                            MessageBox.Show("您输入的数据格式有误！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        string P_Str_Id = String.Empty;

                        //检索数据库中对应客户的ID
                        string P_Str_cmdtxt2 = "SELECT UserID,Name FROM tb_User WHERE Name='" + this.cbxSellName.SelectedValue.ToString() + "'";
                        SqlDataReader P_dr = G_SqlClass.GetReader(P_Str_cmdtxt2);
                        P_dr.Read();
                        if (P_dr.HasRows)
                        {
                            P_Str_Id = P_dr["UserID"].ToString();
                        }
                        P_dr.Close();
                        //下面是要执行的SQL语句
                        P_Str_cmdtxt = "INSERT INTO tb_Sell(SellID,GoodsID,UserID,GoodsName,GoodsNum,GoodsUnit,GoodsTime,GoodsSpec,GoodsPrice,SellPrice";
                        P_Str_cmdtxt += ",Remark,NeedPay,HasPay,StockID) VALUES('" + this.labGoodsID.Text + "','" + PropertyClass.GetGoodsID + "','" + P_Str_Id + "'";
                        P_Str_cmdtxt += ",'" + this.txtGoodsName.Text + "','" + this.txtNum.Text + "','" + this.cbxUnit.SelectedValue.ToString() + "'";
                        P_Str_cmdtxt += ",'" + this.dtBirthday.Value.ToString("yyyy-MM-dd") + "','" + this.txtSpec.Text + "'," + this.txtGoodsInPrice.Text + "";
                        P_Str_cmdtxt += "," + this.txtSellPrice.Text + ",'" + this.txtRemark.Text + "'";
                        P_Str_cmdtxt += "," + this.txtNeedPay.Text + "," + this.txtHasPay.Text + ",'" + PropertyClass.GetStockID + "')";
                        SqlDataReader P_dr2 = G_SqlClass.GetReader("select GoodsID,StockNum from tb_Stock where GoodsID='"
                                + PropertyClass.GetGoodsID + "' and StockNum<'" + Convert.ToInt32(txtNum.Text.Trim()) + "'");
                        P_dr2.Read();
                        if (P_dr2.HasRows)
                        {
                            MessageBox.Show("库存中没有足够数量的图书，请重新填写销售数量！");
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
                                PropertyClass.GetGoodsID = null;
                            }
                            else
                            {
                                MessageBox.Show("数据添加失败！");
                            }
                        }
                        P_dr2.Close();
                    }
                    else
                    {
                        MessageBox.Show("请选择销售员姓名！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                    if (this.cbxSellName.SelectedValue.ToString() != "")
                    {
                        string P_Str_Id = String.Empty;

                        //检索数据库中对应客户的ID
                        string P_Str_cmdtxt2 = "SELECT UserID,Name FROM tb_User WHERE Name='" + this.cbxSellName.SelectedValue.ToString() + "'";
                        SqlDataReader P_dr = G_SqlClass.GetReader(P_Str_cmdtxt2);
                        P_dr.Read();
                        if (P_dr.HasRows)
                        {
                            P_Str_Id = P_dr["UserID"].ToString();
                        }
                        P_dr.Close();

                        P_Str_condition = this.dgvSellInfo[0, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
                        P_Str_cmdtxt = "UPDATE tb_Sell SET GoodsName='" + this.txtGoodsName.Text + "',GoodsNum='" + this.txtNum.Text + "'";
                        P_Str_cmdtxt += ",GoodsUnit='" + this.cbxUnit.SelectedValue.ToString() + "',GoodsTime='" + this.dtBirthday.Value + "'";
                        P_Str_cmdtxt += ",GoodsSpec='" + this.txtSpec.Text + "',UserID='"+P_Str_Id+"',GoodsPrice=" + this.txtGoodsInPrice.Text + "";
                        P_Str_cmdtxt += ",SellPrice=" + this.txtSellPrice.Text + ",Remark='" + this.txtRemark.Text + "'";
                        P_Str_cmdtxt += ",NeedPay=" + this.txtNeedPay.Text + ",HasPay=" + this.txtHasPay.Text + " WHERE SellID='" + P_Str_condition + "'";

                        if (G_SqlClass.GetExecute(P_Str_cmdtxt))
                        {
                            MessageBox.Show("数据修改成功！");
                            ControlStatus();
                        }
                        else
                        {
                            MessageBox.Show("数据修改失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择销售员姓名！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                default:
                    break;
            }
            //绑定数据显示控件
            string P_Str_cmdtxt1 = "SELECT SellID,GoodsID as 图书ID,[Name] as 销售员姓名,GoodsName as 图书名称";
            P_Str_cmdtxt1 += ",GoodsNum as 销售数量,GoodsUnit as 图书单位,GoodsSpec as 图书规格,GoodsTime as 销售时间";
            P_Str_cmdtxt1 += ",GoodsPrice 进货价格,SellPrice as 销售价格,NeedPay as 应收金额,HasPay as 实收金额,Remark as 备注";
            P_Str_cmdtxt1 += " FROM v_UserSell";
            this.dgvSellInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt1).Tables[0];

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
            SqlDataReader P_dr = G_SqlClass.GetReader("SELECT TOP 1 * FROM tb_Sell ORDER BY SellID DESC");
            P_dr.Read();
            if (P_dr.HasRows)
            {
                string P_Str_GoodsID = P_dr["SellID"].ToString();
                P_Int_Num = Convert.ToInt16(P_Str_GoodsID.Substring(11)) + 1;
            }
            else
            {
                this.labGoodsID.Text = "XS" + DateTime.Now.ToString("yyyyMMdd") + "-" + "1000";
                P_dr.Close();
                return;
            }
            P_dr.Close();
            this.labGoodsID.Text = "XS" + DateTime.Now.ToString("yyyyMMdd") + "-" + P_Int_Num.ToString();

        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            G_Int_status = 2;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string P_Str_condition = this.dgvSellInfo[0, this.dgvSellInfo.CurrentCell.RowIndex].Value.ToString();
            string P_Str_cmdtxt = "DELETE FROM tb_Sell WHERE SellID='" + P_Str_condition + "'";
            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                MessageBox.Show("数据删除成功！");
            }
            else
            {
                MessageBox.Show("数据删除失败！");
            }
            string P_Str_cmdtxt1 = "SELECT SellID,GoodsID as 图书ID,[Name] as 销售员姓名,GoodsName as 图书名称";
            P_Str_cmdtxt1 += ",GoodsNum as 销售数量,GoodsUnit as 图书单位,GoodsSpec as 图书规格,GoodsTime as 销售时间";
            P_Str_cmdtxt1 += ",GoodsPrice 进货价格,SellPrice as 销售价格,NeedPay as 应收金额,HasPay as 实收金额,Remark as 备注";
            P_Str_cmdtxt1 += " FROM v_UserSell";
            this.dgvSellInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt1).Tables[0];
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSellInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
            this.txtGoodsName.Text = PropertyClass.GetDgvData;
            this.txtGoodsInPrice.Text = PropertyClass.GetGoodsInPrice;
            this.txtSellPrice.Text = PropertyClass.GetSellPrice;
            this.txtSpec.Text = PropertyClass.GetStockSpec;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PropertyClass.GetGoodsID != null)
            {
                this.txtGoodsName.Text = PropertyClass.GetDgvData;
                this.txtGoodsInPrice.Text = PropertyClass.GetGoodsInPrice;
                this.txtSellPrice.Text = PropertyClass.GetSellPrice;
                this.txtSpec.Text = PropertyClass.GetStockSpec;
            }
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSellPrice.Text != "" && this.txtNum.Text != "" && G_OperationClass.IsNumeric(this.txtNum.Text))
            {
                this.txtNeedPay.Text = Convert.ToString(Convert.ToDecimal(PropertyClass.GetSellPrice) * Convert.ToInt32(this.txtNum.Text));
            }
        }
    }
}