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
    /// 服务区信息数据访问类
    /// </summary>
  public static  class ServiceInfoService
    {
      /// <summary>
      /// 添加服务区信息
      /// </summary>
      /// <param name="info"></param>
      /// <returns></returns>
      public static int Insert_ServiceInfo(ServiceInfo info) {
          string sqlStr = "insert into T_ServiceInfo(S_Name,S_Star,S_Type,S_HID,S_City,S_Welcome) values('" + info.S_Name + "','" + info.S_Star + "','" + info.S_Type + "','" + info.S_HID + "','"+info.S_City+"','"+info.S_Welcome+"') select @@identity";
          return DBHelper.GetIntScalar(sqlStr);
      }
      /// <summary>
      /// 删除服务区信息
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static int Delete_ServiceInfo(int sid) {
          string sqlStr = "delete from  T_ServiceInfo where S_ID="+sid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 编辑服务区基本信息
      /// </summary>
      /// <param name="info"></param>
      /// <returns></returns>
      public static int Update_ServiceBasicInfo(ServiceInfo info) {
          string sqlStr = "update T_ServiceInfo set S_Star='" + info.S_Star + "' ,S_Type='" + info.S_Type + "',S_HID='" + info.S_HID + "',S_Stake='" + info.S_Stake + "',S_Service='" + info.S_Service + "',S_Phone='" + info.S_Phone + "',S_Remark='" + info.S_Remark + "',S_CYRemark='" + info.S_CYRemark + "',S_CSRemark='" + info.S_CSRemark + "',S_JYZRemark='" + info.S_JYZRemark + "',S_ZSRemark='" + info.S_ZSRemark + "',S_QXRemark='" + info.S_QXRemark + "' ,S_TCSRemark='" + info.S_TCSRemark + "',S_StakeNum='" + info.S_StakeNum + "',S_WSJRemark='" + info.S_WSJRemark + "',S_FWDWRemark='" + info.S_FWDWRemark + "',S_City='"+info.S_City+"',S_Welcome='"+info.S_Welcome+"'  where S_ID=" + info.S_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 编辑服务区图片信息
      /// </summary>
      /// <param name="sid"></param>
      /// <param name="columnName"></param>
      /// <param name="strImagePath"></param>
      /// <returns></returns>
      public static int Update_ServiceImage(int sid,string columnName,string strImagePath) {
          string sqlStr = "update T_ServiceInfo set "+columnName+"='"+strImagePath+"' where S_ID="+sid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得服务区信息
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static ServiceInfo Get_ServiceInfo(int sid) {
          ServiceInfo info = null;
          string sqlStr = "select * from T_ServiceInfo where S_ID="+sid;
          DataTable dt = DBHelper.GetDataSet(sqlStr);
          if (dt != null && dt.Rows.Count > 0) {
              info = new ServiceInfo();
              info.S_ID = Convert.ToInt32(dt.Rows[0]["S_ID"]);
              info.S_HID = Convert.ToInt32(dt.Rows[0]["S_HID"]);
              info.S_Name = dt.Rows[0]["S_Name"].ToString();
              info.S_Star = dt.Rows[0]["S_Star"].ToString();
              info.S_Type = dt.Rows[0]["S_Type"].ToString();
              info.S_Stake = dt.Rows[0]["S_Stake"].ToString();
              info.S_StakeNum = Convert.ToDouble(dt.Rows[0]["S_StakeNum"]);
              info.S_Service = dt.Rows[0]["S_Service"].ToString();
              info.S_Phone = dt.Rows[0]["S_Phone"].ToString();
              info.S_Remark = dt.Rows[0]["S_Remark"].ToString();
              info.S_Image = dt.Rows[0]["S_Image"].ToString();
              info.S_CYRemark = dt.Rows[0]["S_CYRemark"].ToString();
              info.S_CYImage = dt.Rows[0]["S_CYImage"].ToString();
              info.S_CSRemark = dt.Rows[0]["S_CSRemark"].ToString();
              info.S_CSImage = dt.Rows[0]["S_CSImage"].ToString();
              info.S_JYZRemark = dt.Rows[0]["S_JYZRemark"].ToString();
              info.S_JYZImage = dt.Rows[0]["S_JYZImage"].ToString();
              info.S_ZSRemark = dt.Rows[0]["S_ZSRemark"].ToString();
              info.S_ZSImage = dt.Rows[0]["S_ZSImage"].ToString();
              info.S_QXRemark = dt.Rows[0]["S_QXRemark"].ToString();
              info.S_QXImage = dt.Rows[0]["S_QXImage"].ToString();
              info.S_TCSRemark = dt.Rows[0]["S_TCSRemark"].ToString();
              info.S_TCSImage = dt.Rows[0]["S_TCSImage"].ToString();
              info.S_WSJRemark = dt.Rows[0]["S_WSJRemark"].ToString();
              info.S_WSJImage = dt.Rows[0]["S_WSJImage"].ToString();
              info.S_FWDWRemark = dt.Rows[0]["S_FWDWRemark"].ToString();
              info.S_FWDWImage = dt.Rows[0]["S_FWDWImage"].ToString();
              info.S_QuarterRank = Convert.ToInt32(dt.Rows[0]["S_QuarterRank"]);
              info.S_HeaderImg = dt.Rows[0]["S_HeaderImg"].ToString();
              info.S_City = dt.Rows[0]["S_City"].ToString();
              info.S_Welcome = dt.Rows[0]["S_Welcome"].ToString();
          }
          return info;
      }
      /// <summary>
      /// 获得所有服务区信息
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_AllServiceInfo()
      {
          string sqlStr = "select * from T_ServiceInfo order by S_QuarterRank asc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 判断服务区是否存在
      /// </summary>
      /// <param name="strName"></param>
      /// <returns></returns>
      public static bool IsExist_ServiceInfo(string strName)
      {
          string sqlStr = "select count(*) from T_ServiceInfo where S_Name='" + strName + "'";
          return DBHelper.IsExistRecord(sqlStr);
      }

      /// <summary>
      /// 根据高速公路得到下属服务区
      /// </summary>
      /// <param name="hid"></param>
      /// <returns></returns>
      public static DataTable GetServiceInfoByHid(int hid) {
          string sql = "select * from T_ServiceInfo where S_HID="+hid+" order by S_Name";
          return DBHelper.GetDataSet(sql);
      }

      public static DataTable Get_ServiceInfoById(int id)
      {
          string sqlStr = "SELECT [S_ID]"
                          +",[S_Name]"
                          +",[S_Star]"
                          +",[S_Type]"
                          +",(select H_Name from T_HighWayInfo where H_ID=SM.S_HID) as H_Name"
                          +",[S_Stake]"
                          +",[S_StakeNum]"
                          +",[S_Service]"
                          +",[S_Phone]"
                          +",[S_Remark]"
                          +",[S_Image]"
                          +",[S_CYRemark]"
                          +",[S_CYImage]"
                          +",[S_CSRemark]"
                          +",[S_CSImage]"
                          +",[S_JYZRemark]"
                          +",[S_JYZImage]"
                          +",[S_ZSRemark]"
                          +",[S_ZSImage]"
                          +",[S_QXRemark]"
                          +",[S_QXImage]"
                          +",[S_TCSRemark]"
                          +",[S_TCSImage]"
                          +",[S_WSJRemark]"
                          +",[S_WSJImage]"
                          +",[S_FWDWRemark]"
                          +",[S_FWDWImage]"
                          + ",[S_QuarterRank]"
                          + ",[S_HeaderImg]"
                          + ",[S_City]"
                          + ",[S_Welcome]"
                      +"FROM [T_ServiceInfo] as SM where S_ID="+id;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 根据服务区名称模糊查询服务区信息
      /// </summary>
      /// <param name="strName"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceInfoByName(string strName) {
          string sqlStr = "select * from T_ServiceInfo where S_Name like '%"+strName+"%'";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 编辑服务区季度排名
      /// </summary>
      /// <param name="sId"></param>
      /// <param name="rankId"></param>
      /// <returns></returns>
      public static int Update_QuarterRank(int sId,int rankId) {
          string sqlStr = "update T_ServiceInfo set S_QuarterRank='"+rankId+"' where S_ID='"+sId+"'";
          return DBHelper.ExecuteCommand(sqlStr);
      }
    }
}
