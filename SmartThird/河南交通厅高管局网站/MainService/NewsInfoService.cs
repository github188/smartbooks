using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using System.Data;
using PubClass;

namespace MainService
{
    /// <summary>
    /// 门户网站新闻信息数据访问类
    /// </summary>
   public static class NewsInfoService
    {
       /// <summary>
       /// 插入新闻信息(发布时间为当期时间)
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int Insert_NewsInfo(NewsInfo news) {
           string sqlStr = "insert into Main_NewsInfo(N_Title,N_Content,N_ImgPath,N_ImgView,N_From,N_HotIco,N_PicIco,N_TID) values('"+news.N_Title+"','"+news.N_Content+"','"+news.N_ImgPath+"','"+news.N_ImgView+"','"+news.N_From+"','"+news.N_HotIco+"','"+news.N_PicIco+"','"+news.N_TID+"')";
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// 插入新闻信息(发布时间为指定的时间)
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int Insert_NewsInfoWithTime(NewsInfo news)
       {
           string sqlStr = "insert into Main_NewsInfo(N_Title,N_Content,N_ImgPath,N_ImgView,N_From,N_HotIco,N_PicIco,N_TID,N_Time) values('" + news.N_Title + "','" + news.N_Content + "','" + news.N_ImgPath + "','" + news.N_ImgView + "','" + news.N_From + "','" + news.N_HotIco + "','" + news.N_PicIco + "','" + news.N_TID + "','"+news.N_Time+"')";
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// 删除新闻信息
       /// </summary>
       /// <param name="nid"></param>
       /// <returns></returns>
       public static int Delete_NewsInfo(int nid) {
           string sqlStr = "delete from Main_NewsInfo where N_ID="+nid;
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// 编辑新闻信息(不编辑发布时间)
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int Update_NewsInfo(NewsInfo news) {
           string sqlStr = "update Main_NewsInfo set N_Title='" + news.N_Title + "',N_Content='" + news.N_Content + "',N_From='" + news.N_From + "',N_ImgPath='"+news.N_ImgPath+"',N_ImgView='"+news.N_ImgView+"',N_HotIco='"+news.N_HotIco+"',N_PicIco='"+news.N_PicIco+"'  where N_ID=" + news.N_ID;
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// 编辑新闻信息(编辑发布时间)
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int Update_NewsInfoWithTime(NewsInfo news)
       {
           string sqlStr = "update Main_NewsInfo set N_Title='" + news.N_Title + "',N_Content='" + news.N_Content + "',N_From='" + news.N_From + "',N_ImgPath='" + news.N_ImgPath + "',N_ImgView='" + news.N_ImgView + "',N_HotIco='" + news.N_HotIco + "',N_PicIco='" + news.N_PicIco + "',N_Time='"+news.N_Time+"'  where N_ID=" + news.N_ID;
           return DBHelper.ExecuteCommand(sqlStr);
       } 
       /// <summary>
       /// 更新点击率
       /// </summary>
       /// <param name="nid"></param>
       /// <returns></returns>
       public static int Update_ClickCount(int nid) {
           string sqlStr = "update Main_NewsInfo set N_ClickCount=N_ClickCount+1 where N_ID="+nid;
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// 获得新闻信息
       /// </summary>
       /// <param name="nid"></param>
       /// <returns></returns>
       public static DataTable Get_NewsInfo(int nid) {
           string sqlStr = "select * from Main_NewsInfo  where N_ID="+nid;
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据新闻编号获得新闻视图信息
       /// </summary>
       /// <param name="nid"></param>
       /// <returns></returns>
       public static DataTable Get_NewsInfoView(int nid) {
           string sqlStr = "select * from M_NewsInfoView where N_ID="+nid;
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据子模块类型编号获得所有符合条件的新闻信息视图列表
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static DataTable Get_NewsInfoViewList(int tid) {
           string sqlStr = "select * from M_NewsInfoView where T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据子模块类型编号获得指定时间内的新闻信息视图列表
       /// </summary>
       /// <param name="tid"></param>
       /// <param name="startDate"></param>
       /// <param name="endDate"></param>
       /// <returns></returns>
       public static DataTable Get_NewsInfoViewList(int tid,string startDate,string endDate){
           string sqlStr = "select * from M_NewsInfoView where T_ID='" + tid + "' and N_Time>='" + startDate + "' and N_Time<'" + endDate + "' order by N_Time desc,N_ID desc";
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       ///根据子模块类型编号获得指定条数新闻信息视图列表
       /// </summary>
       /// <param name="tid"></param>
       /// <param name="listSize">当listSize为0时获得所有符合查询条件的数据</param>
       /// <returns></returns>
       public static DataTable Get_TopNewsInfoViewList(int tid,int listSize)
       {
           string sqlStr = "";
           if (listSize == 0)
           {
               sqlStr = "select * from M_NewsInfoView where T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           }
           else {
               sqlStr = "select top " + listSize + "  * from M_NewsInfoView where T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           }
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据父模块类型名称获得指定条数新闻信息视图列表
       /// </summary>
       /// <param name="tid"></param>
       /// <param name="listSize">当listSize为0时获得所有符合查询条件的数据</param>
       /// <returns></returns>
       public static DataTable Get_TopNewsInfoViewList(string baseType, int listSize) {
           string sqlStr = "";
           if (listSize == 0)
           {
               sqlStr = "select * from M_NewsInfoView where T_Remark='" + baseType + "' order by N_Time desc,N_ID desc";
           }
           else
           {
               sqlStr = "select top " + listSize + "  * from M_NewsInfoView where T_Remark='" + baseType + "' order by N_Time desc,N_ID desc";
           }
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 获得头若干条图片新闻
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static DataTable Get_TopAnyPicNews(int tid,int listSize) {
           string sqlStr = "";
           if (listSize == 0)
           {
               sqlStr = "select * from M_NewsInfoView where N_PicIco='图片新闻'  and T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           }
           else {
               sqlStr = "select top " + listSize + " * from M_NewsInfoView where N_PicIco='图片新闻'  and T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           }
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据子模块类型编号获得头1条新闻信息视图
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static DataTable Get_Top1NewsInfoView(int tid) {
           string sqlStr = "select top 1  * from M_NewsInfoView where T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据子模块类型编号获得头2-5条新闻信息视图
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static DataTable Get_Top2To5NewsInfoViewList(int tid) {
           string sqlStr = "select top 4 * from M_NewsInfoView where  T_ID=" + tid + " and  N_ID not in(select top 1 N_ID from M_NewsInfoView where T_ID=" + tid + " order by N_Time desc,N_ID desc) order by N_Time desc,N_ID desc";
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据子模块编号获得子模块信息
       /// </summary>
       /// <param name="?"></param>
       /// <returns></returns>
       public static DataTable Get_TypeInfoByTypeId(int tid){
           string sqlStr = "select * from Main_NewsType where T_ID=" + tid;
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据子模块编号获得指定年份子模块视图信息列表
       /// </summary>
       /// <param name="tid"></param>
       /// <param name="year"></param>
       /// <returns></returns>
       public static DataTable Get_NewsInfoViewListByYear(int tid,int year)
       {
           string sqlStr = "select * from M_NewsInfoView where T_ID='" + tid + "' and year(N_Time)='" + year + "' order by N_Time desc,N_ID desc";
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// 根据新闻信息编号更新新闻模块编号
       /// </summary>
       /// <param name="nid"></param>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static int Update_NewsInfoTidById(int nid, int tid) {
           string sqlStr = "update Main_NewsInfo set N_TID="+tid+" where N_ID="+nid;
           return DBHelper.ExecuteCommand(sqlStr);
       }
    }
}
