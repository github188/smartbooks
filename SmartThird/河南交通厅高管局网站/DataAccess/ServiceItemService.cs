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
    /// 服务区模块信息数据访问类
    /// </summary>
  public static  class ServiceItemService
    {
      /// <summary>
      /// 添加
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public static int Insert_ServiceItem(ServiceItem item) {
          string sqlStr = "insert into T_ServiceItem(I_Title,I_Content,I_MID,I_SID) values('"+item.I_Title+"','"+item.I_Content+"','"+item.I_MID+"','"+item.I_SID+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static int Delete_ServiceItem(int id) {
          string sqlStr = "delete from T_ServiceItem where I_ID="+id;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 编辑
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public static int Update_ServiceItem(ServiceItem item) {
          string sqlStr = "update T_ServiceItem set I_Title='"+item.I_Title+"',I_Content='"+item.I_Content+"',I_MID='"+item.I_MID+"',I_SID='"+item.I_SID+"' where I_ID=" + item.I_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得服务区特色信息
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItem(int id) {
          string sqlStr = "select * from T_ServiceItem where I_ID="+id;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 根据信息编号获得服务信息视图
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItemView(int id) {
          string sqlStr = "select * from V_ServiceItemInfo where I_ID="+id;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得服务区服务特色信息列表
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItemList(int sid) {
          string sqlStr = "select top 6 * from T_ServiceItem where I_SID="+sid;
          return DBHelper.GetDataSet(sqlStr);
      }


      /// <summary>
      /// 根据模块获得服务区动态
      /// </summary>
      /// <param name="sid"></param>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItemListByType(int sid, int mid)
      {
          string sqlStr = " select * from V_ServiceItemInfo where I_SID='" + sid + "' and I_MID='" + mid + "' order by I_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 根据父服务项目获得所有子服务项目下所有的信息
      /// </summary>
      /// <param name="sid"></param>
      /// <param name="parentItemId"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItemListByParentItem(int sid, int parentItemId) {
          string sqlStr = " select * from V_ServiceItemInfo where I_SID='" + sid + "' and M_ParentID='" + parentItemId + "' order by I_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sid"></param>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItemListByModuleId(int sid, int mid) {
          string sqlStr = " select * from V_ServiceItemInfo where I_SID=" + sid + " and M_ParentID=" + mid+" order by I_Time desc ";
          return DBHelper.GetDataSet(sqlStr);
      }

      public static DataTable Get_ServiceItemListByModuleId(int amount,int sid, int mid)
      {
          string sqlStr = "";
          if (amount == 0)
          {
              sqlStr = " select * from V_ServiceItemInfo where I_SID=" + sid + " and M_ID=" + mid+" order by I_Time desc";
    
          }
          else
          {
              sqlStr = " select top " + amount + " * from V_ServiceItemInfo where I_SID=" + sid + " and M_ID=" + mid + " order by I_Time desc";
          }
          
          return DBHelper.GetDataSet(sqlStr);
      }

      public static DataTable Get_ServiceItemListById(int id) {
          string sqlStr = " select * from V_ServiceModuleContentDetail where I_ID=" + id;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得服务区子服务项目的头若干条数据
      /// </summary>
      /// <param name="itemId">服务子项目编号</param>
      /// <param name="sid">服务区编号</param>
      /// <param name="topCount">获得头若干条数据 为0时获得全部数据</param>
      /// <returns></returns>
      public static DataTable Get_ServiceItemListByMIdAdnSId(int mid,int sid,int topCount){
         string sqlStr="";
         if (topCount == 0)
         {
             sqlStr = "select * from V_ServiceItemInfo where M_ID='" + mid + "' and I_SID='" + sid + "' order by I_Time desc";
         }
         else {
             sqlStr = "select top " + topCount + "  * from V_ServiceItemInfo where M_ID='" + mid + "' and I_SID='" + sid + "' order by I_Time desc";
         }
         return DBHelper.GetDataSet(sqlStr);
      }

    }
}
