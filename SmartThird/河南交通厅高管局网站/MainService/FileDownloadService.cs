using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using System.Data;
using PubClass;

namespace MainService
{
    /// <summary>
    /// 文件下载数据访问类
    /// </summary>
  public static  class FileDownloadService
    {
      /// <summary>
      /// 添加下载文件
      /// </summary>
      /// <param name="download"></param>
      /// <returns></returns>
      public static int Insert_FileDownload(FileDownload download) {
          string sqlStr = "insert into Main_FileDownLoad(FD_Title,FD_Path,FD_Size,FD_FTID,FD_CreateDate) values('" + download.FD_Title + "','" + download.FD_Path + "','" + download.FD_Size + "','" + download.FD_FTID + "','"+download.FD_CreateDate+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除下载文件
      /// </summary>
      /// <param name="fileId"></param>
      /// <returns></returns>
      public static int Delete_FileDownload(int fileId) { 
       string sqlStr = "delete from Main_FileDownLoad where FD_ID="+fileId;
        return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 根据文件类型获得头若干条下载文件信息,如果listSize=0则查询所有符合条件的数据
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
      /// 根据文件类型编号获得类型信息
      /// </summary>
      /// <param name="typeId"></param>
      /// <returns></returns>
      public static DataTable Get_FileTypeInfo(int typeId) {
          string sqlStr = "select * from Main_FileType where FT_ID="+typeId;
          return DBHelper.GetDataSet(sqlStr);
      }
    }
}
