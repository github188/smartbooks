using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;//添加引用
using System.Data.SqlClient;

namespace GoodsReportManage.SysManage
{
    public partial class ReBakData : Form
    {
        public ReBakData()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();

        private void ReBakData_Load(object sender, EventArgs e)
        {

        }

        static string P_Str_BakPath = String.Empty;//定义变量保存路径

        private void btnFindFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFile = new OpenFileDialog();
            if (P_OpenFile.ShowDialog() == DialogResult.OK)
            {
                this.txtPlace.Text = P_OpenFile.FileName;
                P_Str_BakPath = P_OpenFile.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtPlace.Text != "")
            {
                try
                {
                    string P_Str_cmdtxt = "USE master DECLARE tb CURSOR LOCAL FOR SELECT 'Kill '+ CAST(Spid AS VARCHAR) FROM master.dbo.sysprocesses";
                    P_Str_cmdtxt += " WHERE dbid=DB_ID('db_GoodsManage') DECLARE @s nvarchar(1000) OPEN tb FETCH tb INTO @s";
                    P_Str_cmdtxt += " WHILE @@FETCH_STATUS = 0 BEGIN EXEC (@s) FETCH tb INTO @s END CLOSE tb DEALLOCATE tb";
                    P_Str_cmdtxt += "  RESTORE DATABASE db_GoodsManage FROM disk='" + P_Str_BakPath + "'";
                    if (G_SqlClass.GetCon().State == ConnectionState.Open)
                    {
                        G_SqlClass.GetCon().Close();
                        try
                        {
                            SqlCommand sqlcom = new SqlCommand(P_Str_cmdtxt, G_SqlClass.GetCon());
                            sqlcom.ExecuteNonQuery();
                            MessageBox.Show("数据还原成功！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (G_SqlClass.GetCon().State == ConnectionState.Closed)
                            {
                                G_SqlClass.GetCon().Open();
                            }
                        }
                        catch
                        {
                            button1_Click(sender, e);
                        }
                    }
                }
                catch
                {
                    button1_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("请选择备份的正确位置及文件名！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}