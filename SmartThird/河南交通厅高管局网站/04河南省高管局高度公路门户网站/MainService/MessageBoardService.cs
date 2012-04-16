using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using PubClass;
using System.Data;

namespace MainService
{
    /// <summary>
    /// ���԰����ݷ�����
    /// </summary>
  public static  class MessageBoardService
    {
      /// <summary>
      /// ����
      /// </summary>
      /// <param name="mess"></param>
      /// <returns></returns>
      public static int Insert_MessageBoard(MessageBoard mess) {
          string sqlStr = "insert into Main_MessageBoard(M_UName,M_Email,M_Phone,M_Content) values('"+mess.M_UName+"','"+mess.M_Email+"','"+mess.M_Phone+"','"+mess.M_Content+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// ɾ��
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static int Delete_MessageBoard(int mid) {
          string sqlStr = "delete from Main_MessageBoard where M_ID="+mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// �ظ�
      /// </summary>
      /// <param name="mid"></param>
      /// <param name="strReply"></param>
      /// <returns></returns>
      public static int Reply_MessageBoard(int mid, string strReply) {
          string sqlStr = "update Main_MessageBoard set M_Reply='"+strReply+"',M_RTime=getdate() where M_ID="+mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// ��������
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static int Open_MessageBoard(int mid) {
          string sqlStr = "update Main_MessageBoard set M_Open='��' where M_ID="+mid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// ���������Ϣ
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
      public static DataTable Get_MessageBoard(int mid) {
          string sqlStr = "select * from Main_MessageBoard where M_ID="+mid;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// ������������б�
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_AllMessageBoard() {
          string sqlStr = "select * from Main_MessageBoard order by M_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// ����ѹ��������б�
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_OpenedMessageBoard() {
          string sqlStr = "select * from Main_MessageBoard where M_Open='��' order by M_Time desc";
          return DBHelper.GetDataSet(sqlStr);
      }
    }
}
