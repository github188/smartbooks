using System;
using System.Collections.Generic;
using System.Text;

using System.Data;            //添加引用
using System.Windows.Forms;
using System.Data.SqlClient;  
using System.Configuration;

namespace GoodsReportManage.ItemClass
{
    class SqlBaseClass
    {
        #region   代码中用到的变量
        SqlDataAdapter G_Da;    //声明数据适配器对象
        DataSet G_Ds;           //声明数据集对象
        SqlCommand G_Com;
        public string G_Str_ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection G_Con;  //声明链接对象
        #endregion

        #region  构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public SqlBaseClass()
        {

        }
        #endregion

        #region   连接数据库
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetCon()
        {
            G_Con = new SqlConnection(G_Str_ConnectionString);
            G_Con.Open();
            return G_Con;
        }
        #endregion

        #region   执行SQL语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdtxt">要执行的SQL语句</param>
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
                MessageBox.Show("错误：" + ex.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        #region    返回数据集类型
        /// <summary>
        /// 返回数据集类型
        /// </summary>
        /// <param name="cmdtxt">需要查询的SQL语句</param>
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
                MessageBox.Show("错误：" + ex.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        #region    返回数据表类型
        /// <summary>
        /// 返回数据表
        /// </summary>
        /// <param name="cmdtxt"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataTable GetTable(string cmdtxt,string tablename)
        {
            DataTable P_tbl;   //声明一个DataTable对象
            try
            {
                G_Da = new SqlDataAdapter(cmdtxt, tablename);
                P_tbl = new DataTable(tablename);
                G_Da.Fill(P_tbl);   //将表中对象放入P_tbl中
                return P_tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        #region   返回SqlDaraReader类型数据

        /// <summary>
        /// 返回SqlDataReader类型数据
        /// </summary>
        /// <param name="cmdtxt">要执行的SQL语句</param>
        /// <returns></returns>
        public SqlDataReader GetReader(string cmdtxt)
        {
            G_Com = new SqlCommand(cmdtxt, GetCon());  //声明SqlCommand对象
            SqlDataReader P_Dr;
            try
            {
                P_Dr = G_Com.ExecuteReader();
                return P_Dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
