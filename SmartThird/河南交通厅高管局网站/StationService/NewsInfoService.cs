using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StationModel;
using PubClass;

namespace StationService
{
    /// <summary>
    /// 收费站文章信息数据访问类
    /// </summary>
  public  class NewsInfoService
    {
      /// <summary>
      /// 获得文章视图信息列表
      /// </summary>
      /// <param name="TS_ID"></param>
      /// <param name="T_ID"></param>
      /// <param name="listSize"></param>
      /// <returns></returns>
      public static DataTable Get_NewsViewList(int TS_ID, int T_ID, int listSize) {
          string sqlStr = "";
          if (listSize == 0)
          {
              sqlStr = "select * from S_NewsView where N_TSID='"+TS_ID+"' and T_ID='"+T_ID+"' order by N_Date desc,N_ID desc";
          }
          else {
              sqlStr = "select top "+listSize+" * from S_NewsView where N_TSID='"+TS_ID+"' and T_ID='"+T_ID+"' order by N_Date desc,N_ID desc";
          }
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得文章视图信息
      /// </summary>
      /// <param name="N_ID"></param>
      /// <returns></returns>
      public static DataTable Get_NewsView(int N_ID) {
          string sqlStr = "select * from S_NewsView where N_ID='"+N_ID+"'";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得最新头5条图片新闻视图信息
      /// </summary>
      /// <param name="TS_ID"></param>
      /// <param name="T_ID"></param>
      /// <returns></returns>
      public static DataTable Get_Top5ImgNewsViewList(int TS_ID, int T_ID)
      {
          string sqlStr = "select top 5 * from S_NewsView where N_TSID='"+TS_ID+"' and T_ID='"+T_ID+"' and N_ImgPath is not null and N_ImgPath<>'' and N_ImgView is not null and N_ImgView<>'' order by N_Date desc,N_ID desc";
          return DBHelper.GetDataSet(sqlStr);
      }
      
  }
}
