using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using System.Data;
using PubClass;

namespace MainService
{
    /// <summary>
    /// �ļ��������ݷ�����
    /// </summary>
  public static  class FileDownloadService
    {
      /// <summary>
      /// ��������ļ�
      /// </summary>
      /// <param name="download"></param>
      /// <returns></returns>
      public static int Insert_FileDownload(FileDownload download) {
          string sqlStr = "insert into Main_FileDownLoad(FD_Title,FD_Path,FD_Size,FD_FTID,FD_CreateDate) values('" + download.FD_Title + "','" + download.FD_Path + "','" + download.FD_Size + "','" + download.FD_FTID + "','"+download.FD_CreateDate+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// ɾ�������ļ�
      /// </summary>
      /// <param name="fileId"></param>
      /// <returns></returns>
      public static int Delete_FileDownload(int fileId) { 
       string sqlStr = "delete from Main_FileDownLoad where FD_ID="+fileId;
        return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// �����ļ����ͻ��ͷ�����������ļ���Ϣ,���listSize=0���ѯ���з�������������
      /// </summary>
      /// <param name="typeId"></param>
      /// <param name="listSize"></param>
      /// <returns></returns>
      public static DataTable Get_TopFileDownloadView(int typeId, int listSize) {
          string sqlStr = "";
          if (listSize == 0)
          {
              sqlStr="select * from M_FileDownLoadView  where FD_FTID=" + typeId + " order by FD_CreateDate desc";
          }
          else {
              sqlStr = "select top "+listSize+"  * from M_FileDownLoadView  where FD_FTID=" + typeId + " order by FD_CreateDate desc";
          }
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// �����ļ����ͱ�Ż��������Ϣ
      /// </summary>
      /// <param name="typeId"></param>
      /// <returns></returns>
      public static DataTable Get_FileTypeInfo(int typeId) {
          string sqlStr = "select * from Main_FileType where FT_ID="+typeId;
          return DBHelper.GetDataSet(sqlStr);
      }
    }
}
