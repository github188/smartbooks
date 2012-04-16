using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StationModel;
using PubClass;


namespace StationService
{
    /// <summary>
    /// 河南18地市数据访问类
    /// </summary>
    public class CityInfoService
    {
        /// <summary>
        /// 根据地市编号获得地市信息实体对象
        /// </summary>
        /// <param name="CI_ID"></param>
        /// <returns></returns>
        public static CityInfo Get_CityInfoEntity(int CI_ID) {
            CityInfo city = null;
            string sqlStr = "select * from S_CityInfo where CI_ID='"+CI_ID+"'";
            DataTable dt = DBHelper.GetDataSet(sqlStr);
            if (dt != null && dt.Rows.Count > 0) {
                city = new CityInfo();
                city.CI_ID = CI_ID;
                city.CI_Name = dt.Rows[0]["CI_Name"].ToString();
            }
            return city;
        }
    }
}
