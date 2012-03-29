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
    /// 高速公路信息数据访问类
    /// </summary>
   public static class HighWayInfoService
    {
       /// <summary>
       /// 获得所有高速公路信息
       /// </summary>
       /// <returns></returns>
       public static DataTable Get_AllHighWayInfo() {
           string sqlStr = "select * from T_HighWayInfo";
           return DBHelper.GetDataSet(sqlStr);
       }

       public static DataTable Get_HighWayInfoById(int id) {
           string sqlStr = "select * from T_HighWayInfo where H_ID="+id;
           return DBHelper.GetDataSet(sqlStr);
       }

       public static DataTable GetHighWayType() {
           string sql = "select * from T_ClassOfHighWay";

           return DBHelper.GetDataSet(sql);
       }

       public static DataTable Get_HighWayListByTypeID(int typeID) {
           string sqlStr = "select * from T_HighWayInfo where H_CID="+typeID;
           return DBHelper.GetDataSet(sqlStr);
       }
    }
}
