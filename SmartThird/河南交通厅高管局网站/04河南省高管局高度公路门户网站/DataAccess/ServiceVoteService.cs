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
    /// 服务区满意度调查数据访问类
    /// </summary>
  public static  class ServiceVoteService
    {
      /// <summary>
      /// 增加一条投票信息
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static int Insert_ServiceVote(ServiceVote vote) {
          string sqlStr = "insert into T_ServiceVote(SV_ZH,SV_GY,SV_SF,SV_HJ,SV_TC,SV_GL,SV_YJ,SV_ZA,SV_SS,SV_GC,SV_CS,SV_CY,SV_KF,SV_JY,SV_QX,SV_Remark,SV_SID) values('"+vote.SV_ZH+"','"+vote.SV_GY+"','"+vote.SV_SF+"','"+vote.SV_HJ+"','"+vote.SV_TC+"','"+vote.SV_GL+"','"+vote.SV_YJ+"','"+vote.SV_ZA+"','"+vote.SV_SS+"','"+vote.SV_GC+"','"+vote.SV_CS+"','"+vote.SV_CY+"','"+vote.SV_KF+"','"+vote.SV_JY+"','"+vote.SV_QX+"','"+vote.SV_Remark+"','"+vote.SV_SID+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得投票总数
      /// </summary>
      /// <param name="sId"></param>
      /// <returns></returns>
      public static int Get_VoteCount(int sId) {
          string sqlStr = "select count(*) from T_ServiceVote where SV_SID="+sId;
          return DBHelper.GetIntScalar(sqlStr);
      }
      /// <summary>
      /// 获得指定调查项的投票数量
      /// </summary>
      /// <param name="sId"></param>
      /// <param name="columnName"></param>
      /// <returns></returns>
      public static int Get_ABCVoteCount(int sId, string columnName,string columnValue) { 
         string sqlStr="select count(*) from T_ServiceVote where SV_SID="+sId+" and  "+columnName+"='"+columnValue+"'";
         return DBHelper.GetIntScalar(sqlStr);
      }
      /// <summary>
      /// 获得所有服务区
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static DataTable Get_AllVoteInfo(int sid) {
          string sqlStr = "select * from T_ServiceVote where SV_SID='"+sid+"' order by SV_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }
    }
}
