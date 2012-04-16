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
    /// ������ģ����Ϣ���ݷ�����
    /// </summary>
  public static  class ServiceItemService
    {
      /// <summary>
      /// ���
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public static int Insert_ServiceItem(ServiceItem item) {
          string sqlStr = "insert into T_ServiceItem(I_Title,I_Content,I_MID,I_SID) values('"+item.I_Title+"','"+item.I_Content+"','"+item.I_MID+"','"+item.I_SID+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// ɾ��
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static int Delete_ServiceItem(int id) {
          string sqlStr = "delete from T_ServiceItem where I_ID="+id;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// �༭
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public static int Update_ServiceItem(ServiceItem item) {
          string sqlStr = "update T_ServiceItem set I_Title='"+item.I_Title+"',I_Content='"+item.I_Content+"',I_MID='"+item.I_MID+"',I_SID='"+item.I_SID+"' where I_ID=" + item.I_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// ��÷�������ɫ��Ϣ
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItem(int id) {
          string sqlStr = "select * from T_ServiceItem where I_ID="+id;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// ������Ϣ��Ż�÷�����Ϣ��ͼ
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItemView(int id) {
          string sqlStr = "select * from V_ServiceItemInfo where I_ID="+id;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// ��÷�����������ɫ��Ϣ�б�
      /// </summary>
      /// <param name="sid"></param>
      /// <returns></returns>
      public static DataTable Get_ServiceItemList(int sid) {
          string sqlStr = "select top 6 * from T_ServiceItem where I_SID="+sid;
          return DBHelper.GetDataSet(sqlStr);
      }


      /// <summary>
      /// ����ģ���÷�������̬
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
      /// ���ݸ�������Ŀ��������ӷ�����Ŀ�����е���Ϣ
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
      /// ��÷������ӷ�����Ŀ��ͷ����������
      /// </summary>
      /// <param name="itemId">��������Ŀ���</param>
      /// <param name="sid">���������</param>
      /// <param name="topCount">���ͷ���������� Ϊ0ʱ���ȫ������</param>
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
