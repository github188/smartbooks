
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Configuration;
    using System.Data.SqlClient;
    using SmartCampus.Utility;

    /// <summary>
    /// 业务日志Logger
    /// </summary>
    public class OperationLoggerSql 
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private readonly string connectionString = ConfigManager.GetConnectionString();
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return this.connectionString; 
            }  
        }
        /// <summary>
        /// 构造
        /// </summary>
        public OperationLoggerSql()
        {
           
        }
        
        /// <summary>
        /// 写业务日志数据
        /// </summary>
        /// <param name="systemID">子系统编号</param>
        /// <param name="stationID">工作站编号</param>
        /// <param name="empCode">职员代码</param>
        /// <param name="outid">学工号</param>
        /// <param name="name">姓名</param>
        /// <param name="message">消息</param>
        /// <param name="logType">日志类型</param>
        /// <returns></returns>
        public bool WriteLog(string systemID, string stationID, int empID, string outid,int Customerid,int Cardsn,int Cardno,
            string name, string message, int logType)
        {

            string commandText = string.Format(" INSERT INTO LOG_OPERATION (SYSTEMID,STATIONID ,EMPID  ,CUSTOMERID, CARDNO, CARDSN, OUTID  ,NAME ,MESSAGE ,LOGTYPE)" +
                                                " VALUES({0},{1},'{2}', '{3}','{4}', {5},{6})",
                                              "@prmSystemID", "@prmStationID", empID,Customerid,Cardno,Cardsn,
                                                StringHelper.GetSubStr(outid,20),StringHelper.GetSubStr(name,50),"@prmMessage",
                                                logType);

            #region 定义参数
            SqlParameter[] para = new SqlParameter[3];  

            para[0] = new SqlParameter();
            para[0].Direction = ParameterDirection.Input;
            para[0].SqlDbType = SqlDbType.VarChar;
            para[0].ParameterName = "@prmSystemID";
            para[0].Value = StringHelper.GetSubStr(systemID,30);     

            para[1] = new SqlParameter();
            para[1].Direction = ParameterDirection.Input;
            para[1].SqlDbType = SqlDbType.VarChar;
            para[1].ParameterName = "@prmStationID";
            para[1].Value = StringHelper.GetSubStr(stationID,30);

            para[2] = new SqlParameter();     
            para[2].Direction = ParameterDirection.Input;
            para[2].SqlDbType = SqlDbType.VarChar;
            para[2].ParameterName = "@prmMessage";
            para[2].Value = StringHelper.GetSubStr(message, 2000);
            #endregion

            return SqlAppender.ExecuteNonQuery(connectionString, commandText,para) > 0;

        }
        /// <summary>       
        /// 获取指定日期、指定类型的子系统日志
        /// 
        /// 分页数据   
        /// </summary>
        /// <param name="systemID">子系统ID</param>
        /// <param name="logType">日志类型</param>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">结束日期</param>       
        /// <returns>日志记录集合</returns>
        public DataSet GetLog(int systemID, int logType, DateTime beginDate, DateTime endDate)
        {
            string commandText = string.Format("SELECT ID as ID ,EmpCode as Empcode ,OutID as OutID,Name as Name,Message as Message,CreateDate as CreateDate" +
               " FROM LOG_OPERATION " +
               " WHERE CREATEDATE BETWEEN cast('" + beginDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) AND cast('" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) " +
               " AND SYSTEMID={0} AND LOGTYPE={1} "+
               " Order by CreateDate"
               , systemID, logType);

            return SqlAppender.ExecuteQuery(connectionString, commandText);
        }
      
        /// <summary>       
        /// 获取指定日期、指定类型的子系统日志
        /// 
        /// 分页数据   
        /// </summary>
        /// <param name="systemID">子系统ID</param>
        /// <param name="logType">日志类型</param>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="pageSize">每页容量</param>
        /// <param name="pageNo">页号</param>
        /// <returns>日志记录集合</returns>
        public DataSet GetLog(int systemID, int logType, DateTime beginDate, DateTime endDate,int pageSize,int pageNo)
        {
            int maxRowNum = pageNo * pageSize;
            int minRowNum = maxRowNum -pageSize +1;
         
            //string commandText = string.Format("SELECT rn,ID as ID ,EmpCode as Empcode ,OutID as OutID,Name as Name,Message as Message,CreateDate as CreateDate" +
            //   " FROM ( select A.* ,rownum as rn from LOG_OPERATION A "+
            //   " WHERE CREATEDATE BETWEEN cast('" + beginDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) AND cast('" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) " +
            //   " AND SYSTEMID={0} AND LOGTYPE={1} " +
            //   " Order by CreateDate)"+
            //   " Where rn <={2} and rn >={3}",
            //     systemID, logType,maxRowNum ,minRowNum);
            //return SqlAppender.ExecuteQuery(connectionString, commandText);

            string sqlString = "select * from LOG_OPERATION  " +
               " WHERE CREATEDATE BETWEEN cast('" + beginDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) AND cast('" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) " +
               " AND SYSTEMID="+systemID+" AND LOGTYPE="+logType +" Order by CreateDate";

            //string commandText = string.Format(sqlString);
            //return SqlAppender.ExecuteQuery(connectionString, commandText);

            DataSet ds = new DataSet();

            StringBuilder commandText = new StringBuilder("pkg_page$sp_page$1");

            SqlConnection Conn = new SqlConnection(connectionString);
            try
            {

                SqlCommand DSCmd = new SqlCommand(commandText.ToString(), Conn);
                Conn.Open();

                DSCmd.CommandType = CommandType.StoredProcedure;
                //Set in/out paramlist
                DSCmd.Parameters.Add("@p_pagesize", SqlDbType.Int).Value = (Decimal)pageSize;
                DSCmd.Parameters["@p_pagesize"].Direction = ParameterDirection.Input;
                //Set in/out paramlist
                DSCmd.Parameters.Add("@p_pageno", SqlDbType.Int).Value = (Decimal)pageNo;
                DSCmd.Parameters["@p_pageno"].Direction = ParameterDirection.Input;
                //Set in/out paramlist
                DSCmd.Parameters.Add("@p_sqlselect", SqlDbType.VarChar).Value = sqlString;
                DSCmd.Parameters["@p_sqlselect"].Direction = ParameterDirection.Input;

                SqlDataAdapter DBAdopter = new SqlDataAdapter(DSCmd);
              
                DataSet dataSet1 = new DataSet();
                DBAdopter.Fill(dataSet1);

                ds.Tables.Add(dataSet1.Tables[2].Copy());

                Conn.Close();
            }
            catch (Exception e)
            {
                Conn.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

            return ds;
           
        }
        /// <summary>
        /// 获取指定系统指定类型的记录数
        /// </summary>
        /// <param name="systemID">子系统编号</param>
        /// <param name="logType">日志类型</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>记录个数</returns>
        public int GetCount(int systemID, int logType, DateTime beginDate, DateTime endDate)
        {
            string commandText = string.Format("SELECT COUNT(1) FROM LOG_OPERATION " +
                " WHERE CREATEDATE BETWEEN cast('" + beginDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) AND cast('" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) " +
                " AND SYSTEMID={0} AND LOGTYPE={1} ",  
                 systemID, logType);

            Object obj = SqlAppender.ExecuteScalar(connectionString, commandText);
            return Int32.Parse(obj.ToString());
        }
        /// <summary>
        /// 获取日志类型
        /// </summary>
        /// <param name="systemID">子系统编号</param>
        /// <returns>日志类型集合，保含ID、Name</returns>
        public DataSet GetLogTypeBySystemID(int systemID)
        {
            string commandText = string.Format("SELECT ID AS ID ,NAME AS NAME FROM LOG_TYPE WHERE SYSTEMID={0} ORDER BY SORTID",
                                               systemID);

            return SqlAppender.ExecuteQuery(connectionString, commandText);
        }
    }
}
