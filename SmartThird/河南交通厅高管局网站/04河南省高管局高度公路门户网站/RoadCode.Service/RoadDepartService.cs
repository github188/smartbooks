using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PubClass;
using RoadEntity;
using StationService;

namespace RoadService
{
    /// <summary>
    /// 路政单位信息数据访问类
    /// </summary>
  public  class RoadDepartService
    {
      /// <summary>
      /// 根据单位编号获得单位实体类对象
      /// </summary>
      /// <param name="RD_ID"></param>
      /// <returns></returns>
      public static RoadDepart Get_RoadDepartEntity(int RD_ID) {
          RoadDepart depart = null;
          string sqlStr = "select * from R_RoadDepart where RD_ID="+RD_ID;
          DataTable dt = DBHelper.GetDataSet(sqlStr);
          if (dt != null && dt.Rows.Count > 0) {
              depart = new RoadDepart();
              depart.RD_ID = RD_ID;
              depart.RD_Name = dt.Rows[0]["RD_Name"].ToString();
              depart.RD_Manager = dt.Rows[0]["RD_Manager"].ToString();
              depart.RD_Phone = dt.Rows[0]["RD_Phone"].ToString();
              depart.RD_Fax = dt.Rows[0]["RD_Fax"].ToString();
              depart.RD_Email = dt.Rows[0]["RD_Email"].ToString();
              depart.RD_PostCode = dt.Rows[0]["RD_QQ"].ToString();
              depart.RD_QQ = dt.Rows[0]["RD_QQ"].ToString();
              int CI_ID = Convert.ToInt32(dt.Rows[0]["RD_City"]);
              depart.RD_City = CityInfoService.Get_CityInfoEntity(CI_ID);
              depart.RD_Address = dt.Rows[0]["RD_Address"].ToString();
              depart.RD_Honour = dt.Rows[0]["RD_Honour"].ToString();
              depart.RD_Slogon = dt.Rows[0]["RD_Slogon"].ToString();
              depart.RD_Remark = dt.Rows[0]["RD_Remark"].ToString();
              depart.RD_MainPhoto = dt.Rows[0]["RD_MainPhoto"].ToString();
              depart.RD_ViewPhoto = dt.Rows[0]["RD_ViewPhoto"].ToString();
              depart.RD_Logo = dt.Rows[0]["RD_Logo"].ToString();
              depart.RD_Report = dt.Rows[0]["RD_Report"].ToString();
          }
          return depart;
      }
    }
}
