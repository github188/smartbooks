using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using PubClass;
using System.Data;

namespace MainService
{
    /// <summary>
    /// 留言板数据访问类
    /// </summary>
  public static  class MessageBoardService
    {
      /// <summary>
      /// 插入
      /// </summary>
      /// <param name="mess"></param>
      /// <returns></returns>
      public static int Insert_MessageBoard(MessageBoard mess) {
          string sqlStr = "insert into Main_MessageBoard(M_UName,M_Email,M_Phone,M_Content) values('"+mess.M_UName+"','"+mess.M_Email+"','"+mess.M_Phone+"','"+mess.M_Content+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static int Delete_MessageBoard(int mid) {
          string sqlStr = "delete from Main_MessageBoard where M_ID="+mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 回复
      /// </summary>
      /// <param name="mid"></param>
      /// <param name="strReply"></param>
      /// <returns></returns>
      public static int Reply_MessageBoard(int mid, string strReply) {
          string sqlStr = "update Main_MessageBoard set M_Reply='"+strReply+"',M_RTime=getdate() where M_ID="+mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 公开留言
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static int Open_MessageBoard(int mid) {
          string sqlStr = "update Main_MessageBoard set M_Open='是' where M_ID="+mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得留言信息
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static DataTable Get_MessageBoard(int mid) {
          string sqlStr = "select * from Main_MessageBoard where M_ID="+mid;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得所有留言列表
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_AllMessageBoard() {
          string sqlStr = "select * from Main_MessageBoard order by M_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得已公开留言列表
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_OpenedMessageBoard() {
          string sqlStr = "select * from Main_MessageBoard where M_Open='是' order by M_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }
    }
}
