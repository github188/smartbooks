using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PubClass;

namespace MainService
{
    /// <summary>
    /// 收费站在线调查投票结果数据访问类
    /// </summary>
  public static  class StationVoteService
    {
      /// <summary>
      /// 参与投票 SV_ItemA:非常满意 SV_ItemB:满意 SV_ItemC:基本满意 SV_ItemD:不满意
      /// </summary>
      /// <param name="strItem"></param>
      /// <returns></returns>
      public static int Insert_StationVote(string strItem) {
          string sqlStr = "update Main_StationVote set "+strItem+"="+strItem+"+1";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 更改投票数，作弊时用
      /// </summary>
      /// <param name="itemA"></param>
      /// <param name="itemB"></param>
      /// <param name="itemC"></param>
      /// <param name="itemD"></param>
      /// <returns></returns>
      public static int Update_StationVoteNum(int itemA,int itemB,int itemC,int itemD) {
          string sqlStr = "update Main_StationVote set SV_ItemA="+itemA+",SV_ItemB="+itemB+",SV_ItemC="+itemC+",SV_ItemD="+itemD;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得总投票数和各项投票数 intArr[0]:总投票数 intArr[1]:非常满意 intArr[2]:满意 intArr[3]:基本满意 intArr[4]：不满意
      /// </summary>
      /// <returns></returns>
      public static int[] Get_StationVote() {
          int[] intArr = new int[5];
          string sqlStr = "select * from Main_StationVote";
          DataTable dt = DBHelper.GetDataSet(sqlStr);
          intArr[1] = Convert.ToInt32(dt.Rows[0]["SV_ItemA"]);
          intArr[2] = Convert.ToInt32(dt.Rows[0]["SV_ItemB"]);
          intArr[3] = Convert.ToInt32(dt.Rows[0]["SV_ItemC"]);
          intArr[4] = Convert.ToInt32(dt.Rows[0]["SV_ItemD"]);
          intArr[0] = intArr[1] + intArr[2] + intArr[3] + intArr[4];
          return intArr;
      }
    }
}
