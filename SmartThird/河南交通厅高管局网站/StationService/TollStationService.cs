using System;
using System.Collections.Generic;
using System.Text;
using StationModel;
using PubClass;
using System.Data;

namespace StationService
{
    /// <summary>
    /// 收费站信息数据访问类
    /// </summary>
   public class TollStationService
    {
       public static TollStation Get_TollStationEntity(int TS_ID) {
           TollStation station = null;
           string sqlStr = "select * from S_TollStation where TS_ID='"+TS_ID+"'";
           DataTable dt = DBHelper.GetDataSet(sqlStr);
           if (dt != null && dt.Rows.Count > 0) {
               station = new TollStation();
               station.TS_ID = TS_ID;
               station.TS_Name = dt.Rows[0]["TS_Name"].ToString();
               station.TS_PinYin = dt.Rows[0]["TS_PinYin"].ToString();
               station.TS_Stake = dt.Rows[0]["TS_Stake"].ToString();
               station.TS_StakeNum = Convert.ToDouble(dt.Rows[0]["TS_StakeNum"]);
               station.TS_Manager = dt.Rows[0]["TS_Manager"].ToString();
               station.TS_Phone = dt.Rows[0]["TS_Phone"].ToString();
               station.TS_Honour = dt.Rows[0]["TS_Honour"].ToString();
               station.TS_Star = dt.Rows[0]["TS_Star"].ToString();
               station.TS_Welcome = dt.Rows[0]["TS_Welcome"].ToString();
               int H_ID = Convert.ToInt32(dt.Rows[0]["TS_Highway"]);
               station.TS_Highway = HeighWayInfoService.Get_HighwayInfoEntity(H_ID);
               int C_ID = Convert.ToInt32(dt.Rows[0]["TS_Company"]);
               station.TS_Company = CompanyINfoService.Get_CompanyInfoEntity(C_ID);
               int CI_ID = Convert.ToInt32(dt.Rows[0]["TS_City"]);
               station.TS_City = CityInfoService.Get_CityInfoEntity(CI_ID);
               station.TS_LaneNum = dt.Rows[0]["TS_LaneNum"].ToString();
               station.TS_ExitToRoad = dt.Rows[0]["TS_ExitToRoad"].ToString();
               station.TS_MainPhoto = dt.Rows[0]["TS_MainPhoto"].ToString();
               station.TS_ViewPhoto = dt.Rows[0]["TS_ViewPhoto"].ToString();
               station.TS_Logo = dt.Rows[0]["TS_Logo"].ToString();
               station.TS_Remark = dt.Rows[0]["TS_Remark"].ToString();
           }
           return station;
       }
    }
}
