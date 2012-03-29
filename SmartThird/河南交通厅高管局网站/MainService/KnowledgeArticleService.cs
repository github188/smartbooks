using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using System.Data;
using PubClass;

namespace MainService
{
    /// <summary>
    /// 高速知识文章数据访问类
    /// </summary>
  public static  class KnowledgeArticleService
    {
      /// <summary>
      /// 添加文章信息
      /// </summary>
      /// <param name="article"></param>
      /// <returns></returns>
      public static int Insert_KnowledgeArticle(KnowledgeArticle article) {
          string sqlStr = "insert into Main_KnowledgeArticle(KA_Title,KA_Content,KA_CreateDate,KA_KMID) values('"+article.KA_Title+"','"+article.KA_Content+"','"+article.KA_CreateDate+"','"+article.KA_KMID+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除文章信息
      /// </summary>
      /// <param name="KAID"></param>
      /// <returns></returns>
      public static int Delete_KnowledgeArticle(int KAID) {
          string sqlStr = "delete from Main_KnowledgeArticle where KA_ID="+KAID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 更新文章信息
      /// </summary>
      /// <param name="article"></param>
      /// <returns></returns>
      public static int Update_KnowledgeArticle(KnowledgeArticle article) {
          string sqlStr = "update Main_KnowledgeArticle set KA_Title='"+article.KA_Title+"',KA_Content='"+article.KA_Content+"',KA_CreateDate='"+article.KA_CreateDate+"',KA_KMID='"+article.KA_KMID+"' where KA_ID="+article.KA_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 根据模块编号获得文章视图列表
      /// </summary>
      /// <param name="KMID"></param>
      /// <returns></returns>
      public static DataTable Get_KnowledgeArticleViewList(int KMID) {
          string sqlStr = "select * from  M_KnowledgeArticleView where KM_ID="+KMID;
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 获得文章视图信息
      /// </summary>
      /// <param name="KAID"></param>
      /// <returns></returns>
      public static DataTable Get_KnowledgeArticleViewInfo(int KAID) {
          string sqlStr = "select * from  M_KnowledgeArticleView where KA_ID="+KAID;
          return DBHelper.GetDataSet(sqlStr);
      }

    }





    /// <summary>
    /// 高速知识模块数据访问类
    /// </summary>
    public static class KnowledgeModuleService{
        /// <summary>
        /// 获得高速知识模块信息
        /// </summary>
        /// <param name="kmid"></param>
        /// <returns></returns>
        public static DataTable Get_KnowledgeModuleInfo(int kmid)
        {
            string sqlStr = "select * from Main_KnowledgeModule where KM_ID="+kmid;
            return DBHelper.GetDataSet(sqlStr);
        }
        /// <summary>
        /// 获得高速知识模块信息列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_KnowledgeModuleList(){
            string sqlStr = "select * from Main_KnowledgeModule";
            return DBHelper.GetDataSet(sqlStr);
        }
    }
}
