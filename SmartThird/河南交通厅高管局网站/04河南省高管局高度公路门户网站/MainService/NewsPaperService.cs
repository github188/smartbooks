using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using System.Data;
using PubClass;

namespace MainService
{
    /// <summary>
    /// 服务区行业报刊数据访问类
    /// </summary>
  public static  class NewsPaperService
    {
      /// <summary>
      /// 添加信息
      /// </summary>
      /// <param name="p"></param>
      /// <returns></returns>
      public static int Insert_NewsPaper(NewsPaper paper) {
          string sqlStr = "INSERT INTO Main_NewsPaper(N_Title,N_Time,N_AImg,N_AImgView,N_BImg,N_BImgView,N_CImg,N_CImgView,N_DImg,N_DImgView) values('" + paper.N_Title + "','" + paper.N_Time + "','" + paper.N_AImg + "','" + paper.N_AImgView + "','" + paper.N_BImg + "','" + paper.N_BImgView + "','" + paper.N_CImg + "','" + paper.N_CImgView + "','" + paper.N_DImg + "','" + paper.N_DImgView + "')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除信息
      /// </summary>
      /// <param name="nid"></param>
      /// <returns></returns>
      public static int Delete_NewsPaper(int nid ) {
          string sqlStr = "delete from  Main_NewsPaper where N_ID="+nid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 编辑行业报刊信息
      /// </summary>
      /// <param name="paper"></param>
      /// <returns></returns>
      public static int Update_NewsPaper(NewsPaper paper) {
          string sqlStr = "update Main_NewsPaper set N_Title='" + paper.N_Title + "',N_AImg='" + paper.N_AImg + "',N_AImgView='" + paper.N_AImgView + "',N_BImg='" + paper.N_BImg + "',N_BImgView='" + paper.N_BImgView + "',N_CImg='" + paper.N_CImg + "',N_CImgView='" + paper.N_CImgView + "',N_DImg='" + paper.N_DImg + "',N_DImgView='" + paper.N_DImgView + "',N_Time='"+paper.N_Time+"' where N_ID=" + paper.N_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得服务区报刊实体类信息
      /// </summary>
      /// <param name="nid"></param>
      /// <returns></returns>
      public static NewsPaper Get_NewsPaperModel(int nid) {
          NewsPaper paper = null;
          string sqlStr = "select * from Main_NewsPaper where N_ID= " + nid;
          DataTable dt = DBHelper.GetDataSet(sqlStr);
          if (dt != null && dt.Rows.Count > 0) {
              paper = new NewsPaper();
              paper.N_ID = Convert.ToInt32(dt.Rows[0]["N_ID"]);
              paper.N_Title = dt.Rows[0]["N_Title"].ToString();
              paper.N_Time = dt.Rows[0]["N_Time"].ToString();
              paper.N_AImg = dt.Rows[0]["N_AImg"].ToString();
              paper.N_AImgView = dt.Rows[0]["N_AImgView"].ToString();
              paper.N_BImg = dt.Rows[0]["N_BImg"].ToString();
              paper.N_BImgView = dt.Rows[0]["N_BImgView"].ToString();
              paper.N_CImg = dt.Rows[0]["N_CImg"].ToString();
              paper.N_CImgView = dt.Rows[0]["N_CImgView"].ToString();
              paper.N_DImg = dt.Rows[0]["N_DImg"].ToString();
              paper.N_DImgView = dt.Rows[0]["N_DImgView"].ToString();
          }
          return paper;
      }
      /// <summary>
      /// 获得服务区报刊DataTable
      /// </summary>
      /// <param name="nid"></param>
      /// <returns></returns>
      public static DataTable Get_NewsPaperDt(int nid) {
          string sqlStr = "select * from Main_NewsPaper where N_ID= "+nid;
          return DBHelper.GetDataSet(sqlStr);
      }
     /// <summary>
      /// 获得Top N条服务区报刊信息，当listSize为0时获得全部信息
     /// </summary>
     /// <param name="listSize"></param>
     /// <returns></returns>
      public static DataTable Get_NewsPaperList(int listSize) {
          string sqlStr = "";
          if (listSize == 0)
          {
              sqlStr = "select * from Main_NewsPaper order by N_Time desc";
          }
          else {
              sqlStr = "select top "+listSize+"  * from Main_NewsPaper order by N_Time desc";
          }
          return DBHelper.GetDataSet(sqlStr);
      }
    }
}
