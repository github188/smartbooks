using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PubClass
{
    /// <summary>
    /// DBHelper类
    /// 定义 操作数据库的属性和方法
    /// </summary>
    public static class DBHelper
    {
     /// <summary>
     /// 定义connection字段，并对此进行封装
     /// </summary>
     private static SqlConnection connection=null;
     public static SqlConnection Connection
        {
            //获得connection对象
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
     /// 定义 增，删 ，改 的方法
     /// </summary>
     /// <param name="safeSql"></param>
     /// <returns>int</returns>
      public static int ExecuteCommand(string safeSql) {
          SqlCommand cmd = new SqlCommand(safeSql,Connection);
          int result = cmd.ExecuteNonQuery();
          return result;
      }
      /// <summary>
      /// 定义 增，删 ，改 的方法
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
      /// 定义查询单个整数值的方法
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
      ///  定义查询单个整数值的方法
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
      ///  定义查询单个字符串的方法
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
      /// 定义查询单个字符串的方法
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
      /// 获得DataTable对象
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
      /// 获得DataTable对象
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
      /// 获得DataSet对象
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
      /// 查询记录是否存在
      /// </summary>
      /// <param name="sql">sql语句如：select count(*)</param>
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
      /// 查询记录是否存在
      /// </summary>
      /// <param name="sql">sql语句如：select count(*)</param>
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
      /// 执行一些互相联系需要一次成功的sql语句，要么就不执行
      /// </summary>
      /// <param name="SqlStrings"></param>
      /// <returns></returns>
      public static bool ExecuteSQL(String[] SqlStrings)
      {
          bool success = true;
          SqlCommand cmd = new SqlCommand();
          SqlTransaction trans = Connection.BeginTransaction(); //开始事务
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
