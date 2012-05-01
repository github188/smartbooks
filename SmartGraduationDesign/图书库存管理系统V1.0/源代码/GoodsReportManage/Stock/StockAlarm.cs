using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;

namespace GoodsReportManage.Stock
{
    public partial class StockAlarm : Form
    {
        public StockAlarm()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();
        WinOperationClass G_OperationForm = new WinOperationClass();  //声明对窗体操作的类对象
        int G_Int_status;  //保存工具栏按钮操作状态


        /// <summary>
        /// 控制控件状态
        /// </summary>
        private void ControlStatus()
        {
            this.toolSave.Enabled = !this.toolSave.Enabled;
            this.toolCancel.Enabled = !this.toolCancel.Enabled;
            this.toolAmend.Enabled = !this.toolAmend.Enabled;

            this.txtAlarmNum.ReadOnly = !this.txtAlarmNum.ReadOnly;
        }

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
        /// </summary>
        private void FillControls()
        {
            try
            {
                this.labGoodsID.Text = this.dgvAllInfo[1, this.dgvAllInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsCount.Text = this.dgvAllInfo[5, this.dgvAllInfo.CurrentCell.RowIndex].Value.ToString();
                this.labGoodsPrice.Text = this.dgvAllInfo[10, this.dgvAllInfo.CurrentCell.RowIndex].Value.ToString();

                this.txtGoodsName.Text = this.dgvAllInfo[2, this.dgvAllInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtAlarmNum.Text = this.dgvAllInfo[6, this.dgvAllInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtSellPrice.Text = this.dgvAllInfo[11, this.dgvAllInfo.CurrentCell.RowIndex].Value.ToString();
                this.txtSpec.Text = this.dgvAllInfo[9, this.dgvAllInfo.CurrentCell.RowIndex].Value.ToString();
            }
            catch { }
        }


        private void StockAlarm_Load(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = "SELECT StockID as 库存ID,GoodsID as 图书ID,GoodsName as 图书名称,DepotName as 仓库名称";
            P_Str_cmdtxt += ",CompanyName as 供应商名称,StockNum as 库存数量,AlarmNum as 报警数量,GoodsUnit as 图书单位";
            P_Str_cmdtxt += ",GoodsTime as 进货时间,GoodsSpec as 图书规格,GoodsPrice as 进货价格,SellPrice as 销售价格";
            P_Str_cmdtxt += ",NeedPay as 应付金额,HasPay as 实付金额,Remark as 备注 FROM tb_Stock WHERE StockNum >= AlarmNum";
            this.dgvAllInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            this.dgvAllInfo.Columns[0].Visible = false;
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (G_Int_status == 1)
            {
                string P_Str_cmdtxt = "UPDATE tb_Stock SET AlarmNum = " + this.txtAlarmNum.Text + " WHERE StockID='" + this.dgvAllInfo[0, this.dgvAllInfo.CurrentCell.RowIndex].Value.ToString() +"'";
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
            string P_Str_cmdtxt1 = "SELECT StockID as 库存ID,GoodsID as 图书ID,GoodsName as 图书名称,DepotName as 仓库名称";
            P_Str_cmdtxt1 += ",CompanyName as 供应商名称,StockNum as 库存数量,AlarmNum as 报警数量,GoodsUnit as 图书单位";
            P_Str_cmdtxt1 += ",GoodsTime as 进货时间,GoodsSpec as 图书规格,GoodsPrice as 进货价格,SellPrice as 销售价格";
            P_Str_cmdtxt1 += ",NeedPay as 应付金额,HasPay as 实付金额,Remark as 备注 FROM tb_Stock WHERE StockNum >= AlarmNum";
            this.dgvAllInfo.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt1).Tables[0];
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ControlStatus();
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            G_Int_status = 1;
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAllInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillControls();
        }
    }
}