using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;  //�������
using GoodsReportManage.ItemClass;

namespace GoodsReportManage.SysManage
{
    public partial class BakData : Form
    {
        public BakData()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();

        private void btnFindFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog();
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {
                this.txtPlace.Text = P_File_Folder.SelectedPath;
            }
        }

        private void BakData_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtBakName.Text != ""&&this.txtPlace.Text!="")
            {
                string P_Str_cmdtxt2 = "backup database db_GoodsManage to disk='" + this.txtPlace.Text.Trim() + "\\" + this.txtBakName.Text.Trim() + ".bak'";
                if (G_SqlClass.GetExecute(P_Str_cmdtxt2))
                {
                    MessageBox.Show("���ݱ��ݳɹ���", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("���ݱ���ʧ�ܣ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("����д���ݵ���ȷλ�ü��ļ�����", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}