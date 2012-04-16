using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StationModel;
using PubClass;


namespace StationService
{
    /// <summary>
    /// 运营管理单位数据访问类
    /// </summary>
    public class CompanyINfoService
    {
        /// <summary>
        /// 根据运营管理单位编号获得单位信息实体对象
        /// </summary>
        /// <param name="C_ID"></param>
        /// <returns></returns>
        public static CompanyInfo Get_CompanyInfoEntity(int C_ID) {
            CompanyInfo info = null;
            string sqlStr = "select C_Name,C_ID from T_CompanyInfo where C_ID='"+C_ID+"'";
            DataTable dt = DBHelper.GetDataSet(sqlStr);
            if (dt != null && dt.Rows.Count > 0) {
                info = new CompanyInfo();
                info.C_ID = C_ID;
                info.C_Name = dt.Rows[0]["C_Name"].ToString();
            }
            return info;
        }
    }
}
