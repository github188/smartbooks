
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Configuration;
    using System.Data.OracleClient;

    /// <summary>
    /// 写入Oracle数据库 Appender
    /// </summary>
    public class OracleAppender : IAppender
    {
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString,string commandText)
        {  
            using (OracleConnection conn = new OracleConnection(connectionString))
            {   
                OracleCommand cmd = new OracleCommand();
                
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
        public static int ExecuteNonQuery(string connectionString,string commandText,params OracleParameter [] commandParameters)
        {   
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand();
                
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

              
                foreach (OracleParameter parm in commandParameters)
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
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                 OracleCommand cmd = new OracleCommand();

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;    
              
                OracleDataAdapter oracleDA = new OracleDataAdapter();
                oracleDA.SelectCommand = cmd;
                DataSet ds = new DataSet();
                oracleDA.Fill(ds);
                
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
            using (OracleConnection conn = new OracleConnection(connectionString))
            {  
                OracleCommand cmd = new OracleCommand();

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
