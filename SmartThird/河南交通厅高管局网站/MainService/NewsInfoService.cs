using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using System.Data;
using PubClass;

namespace MainService
{
    /// <summary>
    /// �Ż���վ������Ϣ���ݷ�����
    /// </summary>
   public static class NewsInfoService
    {
       /// <summary>
       /// ����������Ϣ(����ʱ��Ϊ����ʱ��)
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int Insert_NewsInfo(NewsInfo news) {
           string sqlStr = "insert into Main_NewsInfo(N_Title,N_Content,N_ImgPath,N_ImgView,N_From,N_HotIco,N_PicIco,N_TID) values('"+news.N_Title+"','"+news.N_Content+"','"+news.N_ImgPath+"','"+news.N_ImgView+"','"+news.N_From+"','"+news.N_HotIco+"','"+news.N_PicIco+"','"+news.N_TID+"')";
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// ����������Ϣ(����ʱ��Ϊָ����ʱ��)
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int Insert_NewsInfoWithTime(NewsInfo news)
       {
           string sqlStr = "insert into Main_NewsInfo(N_Title,N_Content,N_ImgPath,N_ImgView,N_From,N_HotIco,N_PicIco,N_TID,N_Time) values('" + news.N_Title + "','" + news.N_Content + "','" + news.N_ImgPath + "','" + news.N_ImgView + "','" + news.N_From + "','" + news.N_HotIco + "','" + news.N_PicIco + "','" + news.N_TID + "','"+news.N_Time+"')";
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// ɾ��������Ϣ
       /// </summary>
       /// <param name="nid"></param>
       /// <returns></returns>
       public static int Delete_NewsInfo(int nid) {
           string sqlStr = "delete from Main_NewsInfo where N_ID="+nid;
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// �༭������Ϣ(���༭����ʱ��)
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int Update_NewsInfo(NewsInfo news) {
           string sqlStr = "update Main_NewsInfo set N_Title='" + news.N_Title + "',N_Content='" + news.N_Content + "',N_From='" + news.N_From + "',N_ImgPath='"+news.N_ImgPath+"',N_ImgView='"+news.N_ImgView+"',N_HotIco='"+news.N_HotIco+"',N_PicIco='"+news.N_PicIco+"'  where N_ID=" + news.N_ID;
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// �༭������Ϣ(�༭����ʱ��)
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int Update_NewsInfoWithTime(NewsInfo news)
       {
           string sqlStr = "update Main_NewsInfo set N_Title='" + news.N_Title + "',N_Content='" + news.N_Content + "',N_From='" + news.N_From + "',N_ImgPath='" + news.N_ImgPath + "',N_ImgView='" + news.N_ImgView + "',N_HotIco='" + news.N_HotIco + "',N_PicIco='" + news.N_PicIco + "',N_Time='"+news.N_Time+"'  where N_ID=" + news.N_ID;
           return DBHelper.ExecuteCommand(sqlStr);
       } 
       /// <summary>
       /// ���µ����
       /// </summary>
       /// <param name="nid"></param>
       /// <returns></returns>
       public static int Update_ClickCount(int nid) {
           string sqlStr = "update Main_NewsInfo set N_ClickCount=N_ClickCount+1 where N_ID="+nid;
           return DBHelper.ExecuteCommand(sqlStr);
       }
       /// <summary>
       /// ���������Ϣ
       /// </summary>
       /// <param name="nid"></param>
       /// <returns></returns>
       public static DataTable Get_NewsInfo(int nid) {
           string sqlStr = "select * from Main_NewsInfo  where N_ID="+nid;
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// �������ű�Ż��������ͼ��Ϣ
       /// </summary>
       /// <param name="nid"></param>
       /// <returns></returns>
       public static DataTable Get_NewsInfoView(int nid) {
           string sqlStr = "select * from M_NewsInfoView where N_ID="+nid;
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// ������ģ�����ͱ�Ż�����з���������������Ϣ��ͼ�б�
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static DataTable Get_NewsInfoViewList(int tid) {
           string sqlStr = "select * from M_NewsInfoView where T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// ������ģ�����ͱ�Ż��ָ��ʱ���ڵ�������Ϣ��ͼ�б�
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
       ///������ģ�����ͱ�Ż��ָ������������Ϣ��ͼ�б�
       /// </summary>
       /// <param name="tid"></param>
       /// <param name="listSize">��listSizeΪ0ʱ������з��ϲ�ѯ����������</param>
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
       /// ���ݸ�ģ���������ƻ��ָ������������Ϣ��ͼ�б�
       /// </summary>
       /// <param name="tid"></param>
       /// <param name="listSize">��listSizeΪ0ʱ������з��ϲ�ѯ����������</param>
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
       /// ���ͷ������ͼƬ����
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static DataTable Get_TopAnyPicNews(int tid,int listSize) {
           string sqlStr = "";
           if (listSize == 0)
           {
               sqlStr = "select * from M_NewsInfoView where N_PicIco='ͼƬ����'  and T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           }
           else {
               sqlStr = "select top " + listSize + " * from M_NewsInfoView where N_PicIco='ͼƬ����'  and T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           }
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// ������ģ�����ͱ�Ż��ͷ1��������Ϣ��ͼ
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static DataTable Get_Top1NewsInfoView(int tid) {
           string sqlStr = "select top 1  * from M_NewsInfoView where T_ID='" + tid + "' order by N_Time desc,N_ID desc";
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// ������ģ�����ͱ�Ż��ͷ2-5��������Ϣ��ͼ
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
       public static DataTable Get_Top2To5NewsInfoViewList(int tid) {
           string sqlStr = "select top 4 * from M_NewsInfoView where  T_ID=" + tid + " and  N_ID not in(select top 1 N_ID from M_NewsInfoView where T_ID=" + tid + " order by N_Time desc,N_ID desc) order by N_Time desc,N_ID desc";
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// ������ģ���Ż����ģ����Ϣ
       /// </summary>
       /// <param name="?"></param>
       /// <returns></returns>
       public static DataTable Get_TypeInfoByTypeId(int tid){
           string sqlStr = "select * from Main_NewsType where T_ID=" + tid;
           return DBHelper.GetDataSet(sqlStr);
       }
       /// <summary>
       /// ������ģ���Ż��ָ�������ģ����ͼ��Ϣ�б�
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
       /// ����������Ϣ��Ÿ�������ģ����
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
