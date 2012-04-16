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
    /// 友情链接数据访问类
    /// </summary>
  public static  class MyLinkService
    {
      /// <summary>
      /// 添加友情链接
      /// </summary>
      /// <param name="link"></param>
      /// <returns></returns>
      public static int Insert_MyLink(MyLink link) {
          string sqlStr = "insert into T_MyLink(L_Title,L_URL,L_SID) values('"+link.L_Title+"','"+link.L_URL+"','"+link.L_SID+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除友情链接
      /// </summary>
      /// <param name="lid"></param>
      /// <returns></returns>
      public static int Delete_MyLink(int lid) {
          string sqlStr = "delete from T_MyLink where L_ID="+lid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得服务区友情链接列表
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static DataTable Get_AllLinks(int sid) {
          string sqlStr = "select * from T_MyLink where L_SID="+sid;
          return DBHelper.GetDataSet(sqlStr);
      }

      public static DataTable Get_Links(int sid,int record)
      {
          string sqlStr = "";
          if (record == 0)
          {
              sqlStr = "select * from T_MyLink where L_SID=" + sid;
          }
          else
          {
              sqlStr = "select top " + record + " * from T_MyLink where L_SID=" + sid;
          }
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得友情链接基本信息
      /// </summary>
      /// <param name="lid"></param>
      /// <returns></returns>
      public static DataTable Get_MyLink(int lid) {
          string sqlStr = "select * from T_MyLink where L_ID="+lid;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 编辑友情链接信息
      /// </summary>
      /// <param name="link"></param>
      /// <returns></returns>
      public static int Update_MyLink(MyLink link) {
          string sqlStr = "update T_MyLink set L_Title='"+link.L_Title+"',L_URL='"+link.L_URL+"',L_SID='"+link.L_SID+"' where L_ID="+link.L_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
    }
}
