using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PubClass
{
    /// <summary>
    /// DBHelper��
    /// ���� �������ݿ�����Ժͷ���
    /// </summary>
    public static class DBHelper
    {
     /// <summary>
     /// ����connection�ֶΣ����Դ˽��з�װ
     /// </summary>
     private static SqlConnection connection=null;
     public static SqlConnection Connection
        {
            //���connection����
            get {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
                if (connection == null) {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }else if(connection.State==System.Data.ConnectionState.Closed){
                    connection.Open();
                }else if(connection.State==System.Data.ConnectionState.Broken){
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
     /// <summary>
     /// ���� ����ɾ ���� �ķ���
     /// </summary>
     /// <param name="safeSql"></param>
     /// <returns>int</returns>
      public static int ExecuteCommand(string safeSql) {
          SqlCommand cmd = new SqlCommand(safeSql,Connection);
          int result = cmd.ExecuteNonQuery();
          return result;
      }
      /// <summary>
      /// ���� ����ɾ ���� �ķ���
      /// </summary>
      /// <param name="sql"></param>
      /// <param name="values"></param>
      /// <returns>int</returns>
      public static int ExecuteCommand(string sql, params SqlParameter[] values) {
          SqlCommand cmd = new SqlCommand(sql,Connection);
          cmd.Parameters.AddRange(values);
          return cmd.ExecuteNonQuery();
      }
      /// <summary>
      /// �����ѯ��������ֵ�ķ���
      /// </summary>
      /// <param name="sql"></param>
      /// <returns>int</returns>
      public static int GetIntScalar(string sql) {
          SqlCommand cmd = new SqlCommand(sql,Connection);
          object result = cmd.ExecuteScalar();
          if (result == null)
              return 0;
          return Convert.ToInt32(result);
      }
      /// <summary>
      ///  �����ѯ��������ֵ�ķ���
      /// </summary>
      /// <param name="sql"></param>
      /// <param name="values"></param>
      /// <returns>int</returns>
      public static int GetIntScalar(string sql, params SqlParameter[] values)
      {
          SqlCommand cmd = new SqlCommand(sql, Connection);
          cmd.Parameters.AddRange(values);
          object result = cmd.ExecuteScalar();
          if (result == null)
              return 0;
          return Convert.ToInt32(result);
      }
      /// <summary>
      ///  �����ѯ�����ַ����ķ���
      /// </summary>
      /// <param name="sql"></param>
      /// <param name="values"></param>
      /// <returns>int</returns>
      public static string  GetStringScalar(string sql, params SqlParameter[] values) {
          using (SqlCommand cmd = new SqlCommand(sql, Connection))
          {
              cmd.Parameters.AddRange(values);
              object result = cmd.ExecuteScalar();
              if (result == null)
                  return "";
              return result.ToString();
          }
      }
      /// <summary>
      /// �����ѯ�����ַ����ķ���
      /// </summary>
      /// <param name="sql"></param>
      /// <returns>int</returns>
      public static string GetStringScalar(string sql)
      {
          using (SqlCommand cmd = new SqlCommand(sql, Connection))
          {
              object result = cmd.ExecuteScalar();
              if (result == null)
                  return "";
              return result.ToString();
          }  
      }
      /// <summary>
      /// ���DataTable����
      /// </summary>
      /// <param name="sql"></param>
      /// <returns>DataTable</returns>
      public static DataTable GetDataSet(string sql) {
          DataSet ds = new DataSet();
          SqlCommand cmd = new SqlCommand(sql,Connection);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          return ds.Tables[0];
      }
      /// <summary>
      /// ���DataTable����
      /// </summary>
      /// <param name="sql"></param>
      /// <param name="values"></param>
      /// <returns>DataTable</returns>
      public static DataTable GetDataSet(string sql,params SqlParameter[] values)
      {
          DataSet ds = new DataSet();
          SqlCommand cmd = new SqlCommand(sql, Connection);
          cmd.Parameters.AddRange(values);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          return ds.Tables[0];
      }
      /// <summary>
      /// ���DataSet����
      /// </summary>
      /// <param name="sqlStr"></param>
      /// <returns></returns>
      public static DataSet Get_DataSet(string sqlStr) {
          DataSet ds = new DataSet();
          SqlCommand cmd = new SqlCommand(sqlStr, Connection);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          return ds;
        }
      /// <summary>
      /// ��ѯ��¼�Ƿ����
      /// </summary>
      /// <param name="sql">sql����磺select count(*)</param>
      /// <returns></returns>
      public static bool IsExistRecord(string sql)
      {
          SqlCommand cmd = new SqlCommand(sql, Connection);
          int result = Convert.ToInt32(cmd.ExecuteScalar());
          if (result > 0)
              return true;
          return false;
      }
      /// <summary>
      /// ��ѯ��¼�Ƿ����
      /// </summary>
      /// <param name="sql">sql����磺select count(*)</param>
      /// <param name="values"></param>
      /// <returns></returns>
      public static bool IsExistRecord(string sql, params SqlParameter[] values)
      {
          SqlCommand cmd = new SqlCommand(sql, Connection);
          cmd.Parameters.AddRange(values);
          int result = Convert.ToInt32(cmd.ExecuteScalar());
          if (result > 0)
              return true;
          return false;
      }
      /// <summary>
      /// ִ��һЩ������ϵ��Ҫһ�γɹ���sql��䣬Ҫô�Ͳ�ִ��
      /// </summary>
      /// <param name="SqlStrings"></param>
      /// <returns></returns>
      public static bool ExecuteSQL(String[] SqlStrings)
      {
          bool success = true;
          SqlCommand cmd = new SqlCommand();
          SqlTransaction trans = Connection.BeginTransaction(); //��ʼ����
          cmd.Connection = Connection;
          cmd.Transaction = trans;
          try
          {
              foreach (String str in SqlStrings)
              {
                  cmd.CommandText = str;
                  cmd.ExecuteNonQuery();
              }
              trans.Commit();
          }
          catch
          {
              success = false;
              trans.Rollback();
          }
          return success;
      }
  }
}
