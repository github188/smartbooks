using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StationModel;
using PubClass;

namespace StationService
{  
    /// <summary>
    /// 高速公路信息数据访问类
    /// </summary>
    public class HeighWayInfoService
    {   
        /// <summary>
        /// 根据高速公路编号获得公路信息实体对象
        /// </summary>
        /// <param name="H_ID"></param>
        /// <returns></returns>
        public static HighwayInfo Get_HighwayInfoEntity(int H_ID) {
            HighwayInfo info = null;
            string sqlStr = "select H_ID,H_Name from T_HighWayInfo where H_ID='"+H_ID+"'";
            DataTable dt = DBHelper.GetDataSet(sqlStr);
            if (dt != null && dt.Rows.Count > 0)
            {
                info = new HighwayInfo();
                info.H_ID = H_ID;
                info.H_Name = dt.Rows[0]["H_Name"].ToString();
            }
            return info;
        }
    }
}
