
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using System.Configuration;

    /// <summary>
    /// 写入Sql数据库 Appender
    /// </summary>
    public class SqlAppender : IAppender
    {
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString,string commandText)
        {  
            using (SqlConnection conn = new SqlConnection(connectionString))
            {   
                SqlCommand cmd = new SqlCommand();
                
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }          
        }
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString,string commandText,params SqlParameter [] commandParameters)
        {   
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

              
                foreach (SqlParameter parm in commandParameters)
                    cmd.Parameters.Add(parm);

                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val ;
            }          
        }
       

        /// <summary>
        /// 执行sql命令，返回记录集
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteQuery(string connectionString, string commandText)
        {  
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                 SqlCommand cmd = new SqlCommand();

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;    
              
                SqlDataAdapter SqlDA = new SqlDataAdapter();
                SqlDA.SelectCommand = cmd;
                DataSet ds = new DataSet();
                SqlDA.Fill(ds);
                
                return ds;
            }         
        }
        /// <summary>
        /// 执行查询，返回单个结果
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static Object  ExecuteScalar(string connectionString, string commandText)
        {   
            using (SqlConnection conn = new SqlConnection(connectionString))
            {  
                SqlCommand cmd = new SqlCommand();

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                Object obj = cmd.ExecuteScalar();     
                return obj;
            }
        }
    }
}
