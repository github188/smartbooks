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
    /// 服务区模块数据访问类
    /// </summary>
  public static  class ServiceModelService
    {
      /// <summary>
      /// 获得父模块信息列表
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_ParentModelList() {
          string sqlStr = "select * from T_ServiceModel where M_ParentID=0";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 根据父模块编号获得子模块信息列表
      /// </summary>
      /// <param name="parentID"></param>
      /// <returns></returns>
      public static DataTable Get_SonModelListByParent(int parentID) {
          string sqlStr = "select * from T_ServiceModel where M_ParentID="+parentID;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 添加模块信息
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public static int Insert_ServiceModel(ServiceModel model) {
          string sqlStr = "insert into T_ServiceModel(M_Name,M_ParentID) values('"+model.M_Name+"','"+model.M_ParentID+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除模块信息
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static int Delete_ServiceModel(int mid) {
          string sqlStr = "delete from  T_ServiceModel  where M_ID="+mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 编辑模块信息
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public static int Update_ServiceModel(ServiceModel model) {
          string sqlStr = "update T_ServiceModel set M_Name='"+model.M_Name+"',M_ParentID='"+model.M_ParentID+"' where M_ID="+model.M_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得模块信息
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceModel(int mid) {
          string sqlStr = "select * from T_ServiceModel where M_ID="+mid;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 查询是否存在制定的模块
      /// </summary>
      /// <param name="strName"></param>
      /// <returns></returns>
      public static bool IsExist_ServiceModel(string strName) {
          string sqlStr = "select count(*) from T_ServiceModel where M_Name='"+strName+"'";
          return DBHelper.IsExistRecord(sqlStr);
      }

      /// <summary>
      /// 获得子模块列表(按父模块编号排序)
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_SonModelOrderByParent()
      {
          string sqlStr = "select * from T_ServiceModel　where M_ParentID<>0 order by M_ParentID asc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 根据服务项目编号获得服务项目名称
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static string Get_ServiceItemName(int mid) {
          string sqlStr = "select M_Name from T_ServiceModel where M_ID="+mid;
          return DBHelper.GetStringScalar(sqlStr);
      }

      
    }
}
