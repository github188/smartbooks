using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using PubClass;

namespace DataAccess
{
    /// <summary>
    /// 服务区站内新闻数据访问类
    /// </summary>
  public static class ServiceNewService
    {

      /// <summary>
      /// 删除站内新闻
      /// </summary>
      /// <param name="nid"></param>
      /// <returns></returns>
      public static int Delete_News(int nid) {
          string sqlStr = "delete from T_ServiceNews where N_ID="+nid;
          return DBHelper.ExecuteCommand(sqlStr);
      }

      /// <summary>
      /// 获得新闻信息
      /// </summary>
      /// <param name="nid"></param>
      /// <returns></returns>
      public static DataTable Get_News(int nid) {
          string sqlStr = "select * from T_ServiceNews where  N_ID="+nid;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得服务区所有站内信息
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static DataTable Get_AllNews(int sid) {
          string sqlStr = "SELECT  [N_ID]"
                          +",[N_Title]"
                          +",[N_Content]"
                          +",[N_Time]"
                          +",[N_Frorm]"
                          +",[N_SID]"
                          + ",(SELECT TypeName FROM T_ServiceNewsType WHERE TypeID=SN.[N_NewsType]) AS N_TypeName"
                          +",[N_ViewedCount]"
                      +"FROM [dbo].[T_ServiceNews] AS SN where  N_SID='"+sid+"' order by N_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }

      /// <summary>
      /// 根据指定的服务区返回指定条目的记录数
      /// </summary>
      /// <param name="sid"></param>
      /// <param name="record"></param>
      /// <returns></returns>
      public static DataTable Get_AllNews(int sid,int record,int type)
      {
          string sqlStr = "";
          if (record != 0)
          {
              sqlStr = "SELECT top " + record + " [N_ID]"
                          + ",[N_Title]"
                          + ",[N_Content]"
                          + ",[N_Time]"
                          + ",[N_Frorm]"
                          + ",[N_SID]"
                          + ",(SELECT TypeName FROM T_ServiceNewsType WHERE TypeID=SN.[N_NewsType]) AS N_TypeName"
                          + ",[N_ViewedCount]"
                      + "FROM [dbo].[T_ServiceNews] AS SN where  N_SID=" + sid + " and N_NewsType=" + type + " order by N_Time desc";
          }
          else
          {
              sqlStr = "SELECT [N_ID]"
                          + ",[N_Title]"
                          + ",[N_Content]"
                          + ",[N_Time]"
                          + ",[N_Frorm]"
                          + ",[N_SID]"
                          + ",(SELECT TypeName FROM T_ServiceNewsType WHERE TypeID=SN.[N_NewsType]) AS N_TypeName"
                          + ",[N_ViewedCount]"
                      + "FROM [dbo].[T_ServiceNews] AS SN where  N_SID=" + sid + " and N_NewsType=" + type + " order by N_Time desc";

          }
          return DBHelper.GetDataSet(sqlStr);
      }

      public static DataTable Get_ImageNews(int sid, int record)
      {
          string sqlStr = "";
          if (record != 0)
          {
              sqlStr = "SELECT top " + record + " *" 
                      + " FROM [dbo].[T_ServiceNews] AS SN where  N_SID=" + sid + " and N_NewsType=6 order by N_Time desc";
          }
          else
          {
              sqlStr = "SELECT * FROM [dbo].[T_ServiceNews] AS SN where  N_SID=" + sid + " and N_NewsType=6 and datediff(week,N_Time,getdate())=0 order by N_Time desc";
                         
          }
          return DBHelper.GetDataSet(sqlStr);
      }

      public static string GetInfoType(int typeId)
      {
          string sql = "select TypeName from T_ServiceNewsType where TypeID=" + typeId;
          DataTable dt = DBHelper.GetDataSet(sql);

          return dt.Rows[0]["TypeName"].ToString();
      }

      /// <summary>
      /// 获取指定服务区信息
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static List<ServiceNews> GetInfoList(int sid)
      {
          List<ServiceNews> listInfo = new List<ServiceNews>();
          DataTable dataTableInfo = Get_NewsById(sid);

          foreach (DataRow dr in dataTableInfo.Rows)
          {
              ServiceNews serviceNews = new ServiceNews();
              serviceNews.N_ID = (int)dr["N_ID"];
              serviceNews.N_Title=(string)dr["N_Title"];
              serviceNews.N_Time = (DateTime)dr["N_Time"];
              serviceNews.N_From = (string)dr["N_Frorm"];
              serviceNews.N_SID = (int)dr["N_SID"];
              serviceNews.N_Content = (string)dr["N_Content"];
              serviceNews.N_NewsType = (string)dr["N_TypeName"];//出错
              serviceNews.N_ViewedCount = (int)dr["N_ViewedCount"];

              listInfo.Add(serviceNews);
          }

          return listInfo;
      }

      public static DataTable Get_NewsById(int id)
      {
          string sqlStr = "SELECT [N_ID]"
                          + ",[N_Title]"
                          + ",[N_Content]"
                          + ",[N_Time]"
                          + ",[N_Frorm]"
                          + ",[N_SID]"
                          + ",(SELECT TypeName FROM T_ServiceNewsType WHERE TypeID=a.N_NewsType) as N_TypeName"
                          + ",[N_ViewedCount]"
                      + "FROM [dbo].[T_ServiceNews] as a where N_ID=" + id + " order by N_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }

      /// <summary>
      /// 统计文章浏览次数
      /// </summary>
      /// <param name="newsId"></param>
      /// <returns></returns>
      public static int RecordViewedTimes(int newsId)
      {
          string update_sql = "update T_ServiceNews set N_ViewedCount=N_ViewedCount+1 where N_ID="+newsId;
          return DBHelper.ExecuteCommand(update_sql);
      }



      /// <summary>
      /// 获得服务区新闻视图信息(根据服务区编号和新闻类型编号查询)
      /// </summary>
      /// <param name="sid"></param>
      /// <param name="tid"></param>
      /// <returns></returns>
      public static DataTable GetNewsViewByType(int sid, int tid) {
          string sqlStr = "select * from V_ServiceNewsInfo where N_SID=" + sid + " and N_NewsType=" + tid + " order  by N_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 添加站内新闻
      /// </summary>
      /// <param name="news"></param>
      /// <returns></returns>
      public static int Insert_News(ServiceNews news) {
          string sqlStr = "insert into  T_ServiceNews(N_Title,N_Content,N_Frorm,N_SID,N_NewsType) values('" + news.N_Title + "','" + news.N_Content + "','" + news.N_From + "','" + news.N_SID + "','" + news.N_NewsType + "') ";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 编辑站内新闻
      /// </summary>
      /// <param name="news"></param>
      /// <returns></returns>
      public static int Update_News(ServiceNews news) {
          string sqlStr = "update T_ServiceNews set N_Title='" + news.N_Title + "',N_Content='" + news.N_Content + "',N_Frorm='" + news.N_From + "' where N_ID=" + news.N_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 根据新闻编号获得新闻视图信息
      /// </summary>
      /// <param name="nid"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceNewsViewById(int nid) {
          string sqlStr = "select * from V_ServiceNewsInfo where N_ID="+nid;
          return DBHelper.GetDataSet(sqlStr);
      }

    }
}
