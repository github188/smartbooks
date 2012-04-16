using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StationService
{
    public class SQLHelper
    {
        protected SqlConnection con = null;
        protected SqlCommand com = new SqlCommand();
        protected string strcon = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
        /// <summary>
        /// 执行非查询sql语句
        /// </summary>
        /// <param name="sqlstr">command语句</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string sqlstr)
        {
            int i = -1;
            con = new SqlConnection(strcon);
            com.Connection = con;
            using (con)
            {
                con.Open();
                com.CommandText = sqlstr;
                i = com.ExecuteNonQuery();
                if (i == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlstr">查询语句</param>
        /// <param name="op">SqlParameter数组</param>
        /// <returns></returns>
        public bool SqlDbExcuteSql(string sqlstr, SqlParameter[] op)
        {
            int i = -1;
            con = new SqlConnection(strcon);
            using (con)
            {
                com.Connection = con;
                con.Open();
                foreach (SqlParameter o in op)
                {
                    com.Parameters.Add(o);
                }
                com.CommandText = sqlstr;
                i = com.ExecuteNonQuery();
                if (i == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 返回指定sql语句的SqlDataReader对象，使用时请注意关闭这个对象.
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public SqlDataReader SqlDBDataReader(string sqlstr)
        {
            SqlDataReader dr = null;
            con = new SqlConnection(strcon);
            com.Connection = con;
            con.Open();
            com.CommandText = sqlstr;
            dr = com.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// 返回指定sql语句的datatable
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public DataTable SqlDataTable(string sqlstr)
        {
            con = new SqlConnection(strcon);
            com.Connection = con;
            com.CommandText = sqlstr;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            using (con)
            {
                con.Open();
                da.Fill(dt);
            }
            return dt;
        }
        /// <summary>
        /// 添加SqlParameter
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public void StringSqlParameter(string key, string value, int size)
        {
            SqlParameter odp = null;
            com.Connection = con;
            odp = com.Parameters.Add(key, SqlDbType.VarChar, size);
            odp.Value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void TextSqlParameter(string key, string value)
        {
            SqlParameter odp = null;
            com.Connection = con;
            odp = com.Parameters.Add(key, SqlDbType.Text);
            odp.Value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void FloatSqlParameter(string key, float value)
        {
            SqlParameter odp = null;
            com.Connection = con;
            odp = com.Parameters.Add(key, SqlDbType.Float);
            odp.Value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void IntSqlParameter(string key, int value)
        {
            SqlParameter odp = null;
            com.Connection = con;
            odp = com.Parameters.Add(key, SqlDbType.Int);
            odp.Value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void BoolSqlParameter(string key, bool value)
        {
            SqlParameter odp = null;
            com.Connection = con;
            odp = com.Parameters.Add(key, SqlDbType.Bit);
            odp.Value = value;
        }
        public void DateTimeParameter(string key, DateTime value)
        {
            SqlParameter odp = null;
            com.Connection = con;
            odp = com.Parameters.Add(key, SqlDbType.DateTime);
            odp.Value = value;
        }
    }
}
