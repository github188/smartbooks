using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StationModel;
using PubClass;
using System.Data.SqlClient;

namespace StationService
{
    /// <summary>
    /// 用户信息数据访问类
    /// </summary>
  public  class UserInfoService
    {
      /// <summary>
      /// 根据用户名获得用户信息实体对象
      /// </summary>
      /// <param name="strLoginName"></param>
      /// <returns></returns>
      public static UserInfo Get_UserInfoEntity(string strLoginName) {
          UserInfo info = null;
          string sqlStr = "select * from S_UserInfo where U_LoginName=@name";
          SqlParameter[] param ={ 
             new SqlParameter("@name",strLoginName)
          };
          DataTable dt = DBHelper.GetDataSet(sqlStr, param);
          if (dt != null && dt.Rows.Count > 0) {
              info = new UserInfo();
              info.U_ID = Convert.ToInt32(dt.Rows[0]["U_ID"]);
              info.U_LoginName = strLoginName;
              info.U_LoginPwd = dt.Rows[0]["U_LoginPwd"].ToString();
              int TS_ID = Convert.ToInt32(dt.Rows[0]["U_StationID"]);
              info.U_TollStation = TollStationService.Get_TollStationEntity(TS_ID);
              info.U_IsSuper = Convert.ToInt32(dt.Rows[0]["U_IsSuper"]);
          }
          return info;
      }
    }
}
