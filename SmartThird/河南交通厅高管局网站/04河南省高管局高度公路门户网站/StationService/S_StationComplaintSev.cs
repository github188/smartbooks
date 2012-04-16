using System;
using System.Collections.Generic;
using System.Text;
using StationModel;
using System.Data;
using System.Data.SqlClient;

namespace StationService
{
    public class S_StationComplaintSev : SQLHelper
    {
        /// <summary>
        /// 添加一条S_StationComplaint数据
        /// </summary>
        /// <param name="o">S_StationComplaint对象</param>
        /// <returns>bool值，表达该过程执行结果</returns>
        public bool AddS_StationComplaint(S_StationComplaint complain)
        {
            string sqlStr = "insert into S_StationComplaint(SC_CptName,SC_CptContent,SC_Phone,SC_Address,SC_TSID) values('"+complain.SC_CptName+"','"+complain.SC_CptContent+"','"+complain.SC_Phone+"','"+complain.SC_Address+"','"+complain.SC_TSID+"')";
            return ExecuteNonQuery(sqlStr);
        }
        /// <summary>
        /// 删除一条S_StationComplaint数据
        /// </summary>
        /// <param name="id">所要进行修改的数据行的id</param>
        /// <returns>bool值，表达该过程执行结果</returns>
        public bool RemoveS_StationComplaint(int id)
        {
            IntSqlParameter("@id", id);
            return ExecuteNonQuery("delete from S_StationComplaint where SC_id=@id");
        }
        /// <summary>
        /// 添加一条S_StationComplaint数据
        /// </summary>
        /// <param name="ID">字段ID值</param>
        /// <param name="ReplyContent">回复内容</param>
        /// <returns>bool值，表达该过程执行结果</returns>
        public bool Reply(int ID,string ReplyContent)
        {
            IntSqlParameter("@SC_ID", ID);
            TextSqlParameter("@SC_Reply", ReplyContent);
            return ExecuteNonQuery("update S_StationComplaint set SC_Reply=@SC_Reply where SC_ID=@SC_ID");
        }
        /// <summary>
        /// 添加一条S_StationComplaint数据
        /// </summary>
        /// <param name="ID">字段ID值</param>
        /// <param name="Operate">是否在前台页面显示</param>
        /// <returns>bool值，表达该过程执行结果</returns>
        public bool Operate(int ID,bool Operate)
        {
            IntSqlParameter("@SC_ID", ID);
            BoolSqlParameter("@SC_Open", Operate);
            return ExecuteNonQuery("update S_StationComplaint set SC_Open=@SC_Open where SC_ID=@SC_ID");
        }
        /// <summary>
        /// 返回一个DataTable对象
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetS_StationComplaintList()
        {
            return SqlDataTable("select * from SC_StationSueView order by SC_ID desc");
        }
        /// <summary>
        /// 返回一个DataTable对象
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetS_StationComplaintList(bool result)
        {
            BoolSqlParameter("@SC_Open",result);
            return SqlDataTable("select * from SC_StationSueView where SC_Open=@SC_Open order by SC_ID desc");
        }
        /// <summary>
        /// 返回一个DataTable对象
        /// </summary>
        /// <param name="TSID">收费站ID</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSingleStationComplaintList(int TSID)
        {
            IntSqlParameter("@SC_TSID", TSID);
            return SqlDataTable("select * from SC_StationSueView where SC_TSID=@SC_TSID order by SC_ID desc");
        }
        /// <summary>
        /// 返回一个DataTable对象
        /// </summary>
        /// <param name="TSID">ID</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSingleStationComplaintListById(int ID)
        {
            IntSqlParameter("@SC_ID", ID);
            return SqlDataTable("select * from SC_StationSueView where SC_ID=@SC_ID");
        }
    }
}

