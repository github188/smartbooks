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
        WinOperationClass G_OperationForm = new WinOperationClass();  //�����Դ�������������
        int G_Int_status;  //���湤������ť����״̬


        /// <summary>
        /// ���ƿؼ�״̬
        /// </summary>
        private void ControlStatus()
        {
            this.toolSave.Enabled = !this.toolSave.Enabled;
            this.toolCancel.Enabled = !this.toolCancel.Enabled;
            this.toolAmend.Enabled = !this.toolAmend.Enabled;

            this.txtAlarmNum.ReadOnly = !this.txtAlarmNum.ReadOnly;
        }

        /// <summary>
        /// �ڿؼ������ѡ�е�DataGridView�ؼ�������
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
            string P_Str_cmdtxt = "SELECT StockID as ���ID,GoodsID as ͼ��ID,GoodsName as ͼ������,DepotName as �ֿ�����";
            P_Str_cmdtxt += ",CompanyName as ��Ӧ������,StockNum as �������,AlarmNum as ��������,GoodsUnit as ͼ�鵥λ";
            P_Str_cmdtxt += ",GoodsTime as ����ʱ��,GoodsSpec as ͼ����,GoodsPrice as �����۸�,SellPrice as ���ۼ۸�";
            P_Str_cmdtxt += ",NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Stock WHERE StockNum >= AlarmNum";
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
                    MessageBox.Show("�����޸ĳɹ���");
                    ControlStatus();
                }
                else
                {
                    MessageBox.Show("�����޸�ʧ�ܣ�");
                } 
            }
            string P_Str_cmdtxt1 = "SELECT StockID as ���ID,GoodsID as ͼ��ID,GoodsName as ͼ������,DepotName as �ֿ�����";
            P_Str_cmdtxt1 += ",CompanyName as ��Ӧ������,StockNum as �������,AlarmNum as ��������,GoodsUnit as ͼ�鵥λ";
            P_Str_cmdtxt1 += ",GoodsTime as ����ʱ��,GoodsSpec as ͼ����,GoodsPrice as �����۸�,SellPrice as ���ۼ۸�";
            P_Str_cmdtxt1 += ",NeedPay as Ӧ�����,HasPay as ʵ�����,Remark as ��ע FROM tb_Stock WHERE StockNum >= AlarmNum";
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