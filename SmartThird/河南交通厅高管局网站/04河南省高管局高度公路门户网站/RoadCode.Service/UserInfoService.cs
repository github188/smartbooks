using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PubClass;
using RoadEntity;
using StationService;
using System.Data.SqlClient;

namespace RoadService
{
    /// <summary>
    /// 路政单位用户信息数据访问类
    /// </summary>
  public  class UserInfoService
    {
      /// <summary>
      /// 根据登录用户名获得用户信息实体类对象
      /// </summary>
      /// <param name="strLoginName"></param>
      /// <returns></returns>
       public static UserInfo Get_UserInfoEntity(string strLoginName){
           UserInfo info = null;
           string sqlStr = "select * from R_UserInfo where U_LoginName=@loginname";
           SqlParameter[] param ={ 
             new SqlParameter("@loginname",strLoginName)
           };
           DataTable dt = DBHelper.GetDataSet(sqlStr, param);
           if (dt != null && dt.Rows.Count > 0) {
               info = new UserInfo();
               info.U_ID = Convert.ToInt32(dt.Rows[0]["U_ID"]);
               info.U_LoginName = strLoginName;
               info.U_LoginPwd = dt.Rows[0]["U_LoginPwd"].ToString();
               info.U_TrueName = dt.Rows[0]["U_TrueName"].ToString();
               info.U_Phone = dt.Rows[0]["U_Phone"].ToString();
               int RD_ID = Convert.ToInt32(dt.Rows[0]["U_RoadID"]);
               info.U_RoadDepart = RoadDepartService.Get_RoadDepartEntity(RD_ID);
               info.U_IsSuper = Convert.ToInt32(dt.Rows[0]["U_IsSuper"]);
           }
           return info;
       }
    }
}
