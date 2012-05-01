using System;
using System.Collections.Generic;
using System.Text;

using System.Data;            //�������
using System.Windows.Forms;
using System.Data.SqlClient;  
using System.Configuration;

namespace GoodsReportManage.ItemClass
{
    class SqlBaseClass
    {
        #region   �������õ��ı���
        SqlDataAdapter G_Da;    //������������������
        DataSet G_Ds;           //�������ݼ�����
        SqlCommand G_Com;
        public string G_Str_ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection G_Con;  //�������Ӷ���
        #endregion

        #region  ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public SqlBaseClass()
        {

        }
        #endregion

        #region   �������ݿ�
        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetCon()
        {
            G_Con = new SqlConnection(G_Str_ConnectionString);
            G_Con.Open();
            return G_Con;
        }
        #endregion

        #region   ִ��SQL���
        /// <summary>
        /// ִ��SQL���
        /// </summary>
        /// <param name="cmdtxt">Ҫִ�е�SQL���</param>
        /// <returns></returns>
        public bool GetExecute(string cmdtxt)
        {
            G_Com = new SqlCommand(cmdtxt, GetCon());
            try
            {
                G_Com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("����" + ex.Message, "������ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (GetCon().State == ConnectionState.Open)
                {
                    GetCon().Close();
                    GetCon().Dispose();
                }
            }
        }
        #endregion

        #region    �������ݼ�����
        /// <summary>
        /// �������ݼ�����
        /// </summary>
        /// <param name="cmdtxt">��Ҫ��ѯ��SQL���</param>
        /// <returns></returns>
        public DataSet GetDs(string cmdtxt)
        {
            try
            {
                G_Da = new SqlDataAdapter(cmdtxt, GetCon());
                G_Ds = new DataSet();
                G_Da.Fill(G_Ds);
                return G_Ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("����" + ex.Message, "������ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (GetCon().State == ConnectionState.Open)
                {
                    GetCon().Close();
                    GetCon().Dispose();
                }
            }
        }

        #endregion

        #region    �������ݱ�����
        /// <summary>
        /// �������ݱ�
        /// </summary>
        /// <param name="cmdtxt"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataTable GetTable(string cmdtxt,string tablename)
        {
            DataTable P_tbl;   //����һ��DataTable����
            try
            {
                G_Da = new SqlDataAdapter(cmdtxt, tablename);
                P_tbl = new DataTable(tablename);
                G_Da.Fill(P_tbl);   //�����ж������P_tbl��
                return P_tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("����" + ex.Message, "������ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (GetCon().State == ConnectionState.Open)
                {
                    GetCon().Close();
                    GetCon().Dispose();
                }
            }
        }

        #endregion

        #region   ����SqlDaraReader��������

        /// <summary>
        /// ����SqlDataReader��������
        /// </summary>
        /// <param name="cmdtxt">Ҫִ�е�SQL���</param>
        /// <returns></returns>
        public SqlDataReader GetReader(string cmdtxt)
        {
            G_Com = new SqlCommand(cmdtxt, GetCon());  //����SqlCommand����
            SqlDataReader P_Dr;
            try
            {
                P_Dr = G_Com.ExecuteReader();
                return P_Dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("����" + ex.Message, "������ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (GetCon().State == ConnectionState.Open)
                {
                    GetCon().Close();
                    GetCon().Dispose();
                }
            }
        }
        #endregion
    }
}
