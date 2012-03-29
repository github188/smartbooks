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
    /// 留言板信息数据访问类
    /// </summary>
  public static  class MessageBoardService
    {
      /// <summary>
      /// 添加留言信息
      /// </summary>
      /// <param name="m"></param>
      /// <returns></returns>
      public static int Insert_MessageBoard(MessageBoard m) {
          string sqlStr = "insert into T_MessageBoard(M_UName,M_Content,M_Emotion,M_SID) values('" + m.M_UName + "','" + m.M_Content + "','" + m.M_Emotion + "','" + m.M_SID + "')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除留言信息
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static int Delete_MessageBoard(int mid) {
          string sqlStr = "delete from T_MessageBoard where M_ID=" + mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 回复留言信息
      /// </summary>
      /// <returns></returns>
      public static int Reply_MessageBoard(int mid,string strReply) {
          string sqlStr = "update T_MessageBoard set M_Reply='" + strReply + "' where M_ID=" + mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 审核发布留言信息
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static int Update_MessageStatus(int mid) {
          string sqlStr = "update T_MessageBoard set M_Status='是' where M_ID=" + mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得留言信息
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static DataTable Get_MessageBoard(int mid) {
          string sqlStr = "select * from  T_MessageBoard  where M_ID=" + mid;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得公开留言信息
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static DataTable Get_OpenMessage(int sid) {
          string sqlStr = "select * from  T_MessageBoard  where M_Status='是' and M_SID='" + sid + "' order by M_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得服务区所有留言信息
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static DataTable Get_AllMessage(int sid) {
          string sqlStr = "select * from  T_MessageBoard  where  M_SID='" + sid + "' order by M_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }


      /// <summary>
      /// 获得服务区所有留言信息
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static DataTable Get_MessageList(int sid,int record)
      {
          string sqlStr = "";
          if (record == 0)
          {
              sqlStr = "select * from  T_MessageBoard  where  M_SID='" + sid + "' and M_Status='是' order by M_Time desc";
          }
          else
          {
              sqlStr = "SELECT TOP " + record + " [M_ID]"
                        + ",[M_UName]"
                        + ",[M_Content]"
                        + ",[M_Time]"
                        + ",[M_Emotion]"
                        + ",[M_Reply]"
                        + ",[M_Status]"
                        + ",[M_SID]"
                    + "FROM [T_MessageBoard] where M_Status='是' and M_SID=" + sid + " order by M_Time desc";
          }

          
          return DBHelper.GetDataSet(sqlStr);
      }

      /// <summary>
      /// 前台页面留言信息的提交
      /// </summary>
      /// <param name="mb"></param>
      public static void AddMessage(MessageBoard mb)
      {
          string sql = "";
          string uname = "";
          string namenumber = "";

          if (mb.M_UName.Contains("路人"))
          {
              sql = "select top 1 M_UName from T_MessageBoard where M_UName like '%路人%' order by M_ID desc";
              uname = DBHelper.GetStringScalar(sql);

              if (uname == "")
              {
                  mb.M_UName = mb.M_UName + "1";
                  Insert_MessageBoard(mb);
              }
              else
              {
                  namenumber = uname.Substring(2, uname.Length - 2);
                  uname = "路人"+Convert.ToString((Convert.ToInt32(namenumber)+1));
                  mb.M_UName = uname;

                  Insert_MessageBoard(mb);
              }
          }
          else
          {
              Insert_MessageBoard(mb);
          }
          
      }
    }
}
