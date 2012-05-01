using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using GoodsReportManage.ItemClass;
using GoodsReportManage.Stock;

namespace GoodsReportManage.Stock
{
    public partial class ChangeGoods : Form
    {
        public ChangeGoods()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();
        WinOperationClass G_WinFormClass = new WinOperationClass();
        int G_Int_status;  //保存工具栏按钮操作状态

        /// <summary>
        /// 将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            this.cbxIn.SelectedIndex = 0;

            this.txtGoodsName.Text = "";
            this.txtNum.Text = "";

            this.labOut.Text = "";
            this.labGoodsCount.Text = "";
            this.labGoodsID.Text = "";
        }

        /// <summary>
        /// 控制控件状态
        /// </summary>
        private void ControlStatus()
        {
            this.toolSave.Enabled = !this.toolSave.Enabled;
            this.toolAdd.Enabled = !this.toolAdd.Enabled;
            this.toolCancel.Enabled = !this.toolCancel.Enabled;

            this.groupBox1.Enabled = !this.groupBox1.Enabled;

            this.dgvChangeInfo.Enabled = !this.dgvChangeInfo.Enabled;
        }

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.labGoodsID.Text = this.dgvChangeInfo[0, this.dgvChangeInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsCount.Text = this.dgvChangeInfo[7, this.dgvChangeInfo.CurrentCell.RowIndex].Value.ToString();
                this.labOut.Text = this.dgvChangeInfo[4, this.dgvChangeInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtGoodsName.Text = this.dgvChangeInfo[3, this.dgvChangeInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtNum.Text = this.dgvChangeInfo[8, this.dgvChangeInfo.CurrentCell.RowIndex].Value.ToString();
                this.cbxIn.Text = this.dgvChangeInfo[5, this.dgvChangeInfo.CurrentCell.RowIndex].Value.ToString();
            }
            catch { }
        }

        private void ChangeGoods_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            string P_Str_cmdtxt = "SELECT StockTempID,UserID,GoodsID as 图书ID,GoodsName as 图书名称";
            P_Str_cmdtxt += ",FDepotName 调出仓库,LDepotName as 调入仓库,CGoodsTime as 调动时间";
            P_Str_cmdtxt += ",StockNum as 库存数量,CGoodsNum as 调出数量 FROM tb_StockTemp";
            this.dgvChangeInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            this.dgvChangeInfo.Columns[0].Visible = false;　　　//控制DataGridView中列的状态
            this.dgvChangeInfo.Columns[1].Visible = false;
            G_WinFormClass.BindComboBox("SELECT * FROM tb_Depot", cbxIn, "DepotSort");  //绑定ComboBox控件
        }

        private void toolSave_Click_1(object sender, EventArgs e)
        {
            string P_Str_cmdtxt;
            if (this.cbxIn.SelectedValue.ToString() != "")
            {
                if (this.labOut.Text != this.cbxIn.SelectedValue.ToString() && Convert.ToInt32(this.labGoodsCount.Text) >= Convert.ToInt32(this.txtNum.Text))
                {
                    string P_Str_cmdtxt3 = "INSERT INTO tb_Stock (GoodsID,CompanyName,DepotName,GoodsName,StockNum,GoodsUnit,GoodsTime";
                    P_Str_cmdtxt3 += ",GoodsSpec,GoodsPrice,SellPrice) VALUES('" + PropertyClass.GetGoodsID + "'";
                    P_Str_cmdtxt3 += ",'" + PropertyClass.GetCompanyName + "','" + this.cbxIn.SelectedValue.ToString() + "'";
                    P_Str_cmdtxt3 += ",'" + this.txtGoodsName.Text + "','" + this.txtNum.Text + "','" + PropertyClass.GetStockUnit + "'";
                    P_Str_cmdtxt3 += ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + PropertyClass.GetStockSpec + "'";
                    P_Str_cmdtxt3 += "," + PropertyClass.GetGoodsInPrice + "," + PropertyClass.GetSellPrice + ")";
                    G_SqlClass.GetExecute(P_Str_cmdtxt3);
                    string P_Str_cmdtxt2 = "UPDATE tb_Stock SET StockNum="
                        + (Convert.ToInt32(PropertyClass.StockNum) - Convert.ToInt32(this.txtNum.Text))
                        + ",NeedPay=" + (Convert.ToInt32(PropertyClass.StockNum) - Convert.ToInt32(this.txtNum.Text)) * Convert.ToDecimal(PropertyClass.GetGoodsInPrice)
                        + ", HasPay=" + (Convert.ToInt32(PropertyClass.StockNum) - Convert.ToInt32(this.txtNum.Text)) * Convert.ToDecimal(PropertyClass.GetGoodsInPrice)
                        + " WHERE StockID='" + PropertyClass.GetStockID + "'";
                    G_SqlClass.GetExecute(P_Str_cmdtxt2);
                    if ((Convert.ToInt32(PropertyClass.StockNum) - Convert.ToInt32(this.txtNum.Text)) <= 0)
                    {
                        string P_Str_delete = "DELETE FROM tb_Stock WHERE StockID='" + PropertyClass.GetStockID + "'";
                        G_SqlClass.GetExecute(P_Str_delete);
                    }
                    //下面是要执行的SQL语句
                    P_Str_cmdtxt = "INSERT INTO tb_StockTemp(StockTempID,UserID,GoodsID,GoodsName,FDepotName,LDepotName,CGoodsTime,StockNum,CGoodsNum)";
                    P_Str_cmdtxt += " VALUES('" + this.labGoodsID.Text + "','" + PropertyClass.SendUserIDValue + "','" + PropertyClass.GetGoodsID + "'";
                    P_Str_cmdtxt += ",'" + this.txtGoodsName.Text + "','" + this.labOut.Text + "','" + this.cbxIn.SelectedValue.ToString() + "'";
                    P_Str_cmdtxt += ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + this.labGoodsCount.Text + "','" + this.txtNum.Text + "')";

                    if (this.txtGoodsName.Text == "")
                    {
                        MessageBox.Show("图书名称不能为空！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
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
                }
                else
                {
                    if (this.labOut.Text == this.cbxIn.SelectedValue.ToString())
                    {
                        MessageBox.Show("调入调出仓库名称不能相同！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Convert.ToInt32(this.labGoodsCount.Text) > Convert.ToInt32(this.txtNum.Text))
                    {
                        MessageBox.Show("调出图书数量不能大于图书库存量！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择仓库名称！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //绑定数据显示控件
            string P_Str_cmdtxt1 = "SELECT StockTempID,UserID,GoodsID as 图书ID,GoodsName as 图书名称";
            P_Str_cmdtxt1 += ",FDepotName 调出仓库,LDepotName as 调入仓库,CGoodsTime as 调动时间";
            P_Str_cmdtxt1 += ",StockNum as 库存数量,CGoodsNum as 调出数量 FROM tb_StockTemp";
            this.dgvChangeInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt1).Tables[0];
        }

        private void toolCancel_Click_1(object sender, EventArgs e)
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
            SqlDataReader P_dr = G_SqlClass.GetReader("SELECT TOP 1 * FROM tb_StockTemp ORDER BY StockTempID DESC");
            P_dr.Read();
            if (P_dr.HasRows)
            {
                string P_Str_GoodsID = P_dr["StockTempID"].ToString();
                P_Int_Num = Convert.ToInt16(P_Str_GoodsID.Substring(11)) + 1;
            }
            else
            {
                this.labGoodsID.Text = "DB" + DateTime.Now.ToString("yyyyMMdd") + "-" + "1000";
                P_dr.Close();
                return;
            }
            P_dr.Close();
            this.labGoodsID.Text = "DB" + DateTime.Now.ToString("yyyyMMdd") + "-" + P_Int_Num.ToString();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string P_Str_condition = this.dgvChangeInfo[0, this.dgvChangeInfo.CurrentCell.RowIndex].Value.ToString();
            string P_Str_cmdtxt = "DELETE FROM tb_StockTemp WHERE StockTempID='" + P_Str_condition + "'";
            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                MessageBox.Show("数据删除成功！");
            }
            else
            {
                MessageBox.Show("数据删除失败！");
            }
            string P_Str_cmdtxt1 = "SELECT StockTempID,UserID,GoodsID as 图书ID,GoodsName as 图书名称";
            P_Str_cmdtxt1 += ",FDepotName 调出仓库,LDepotName as 调入仓库,CGoodsTime as 调动时间";
            P_Str_cmdtxt1 += ",StockNum as 库存数量,CGoodsNum as 调出数量 FROM tb_StockTemp";
            this.dgvChangeInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt1).Tables[0];
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChangeInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PropertyClass.GetGoodsID != null)
            {
                this.txtGoodsName.Text = PropertyClass.GetDgvData;
                this.labGoodsCount.Text = PropertyClass.StockNum;
                this.labOut.Text = PropertyClass.StockName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockFind stockfind = new StockFind();
            stockfind.StartPosition = FormStartPosition.CenterScreen;
            stockfind.ShowDialog();
        }
    }
}