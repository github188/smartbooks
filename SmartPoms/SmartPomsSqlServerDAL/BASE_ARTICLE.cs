// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE.cs
// 功能描述:文章信息表 -- 接口实现
//
// 创建标识：王 亚 2012-03-14
namespace SmartPoms.SQLServerDAL {
    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// 文章信息表 -- 接口实现
    /// </summary>
    public partial class BASE_ARTICLE : IBASE_ARTICLE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int ArticleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Article");
            strSql.Append(" where ");
            strSql.Append(" ArticleID = @ArticleID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ArticleID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_ARTICLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Article(");
            strSql.Append("Title,Detail,SendTime,Media,Author,ClickNum,CommentNum,Url,ExtractionTime,Score");
            strSql.Append(") values (");
            strSql.Append("@Title,@Detail,@SendTime,@Media,@Author,@ClickNum,@CommentNum,@Url,@ExtractionTime,@Score");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Title", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Detail", SqlDbType.Text) ,            
                        new SqlParameter("@SendTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Media", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Author", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ClickNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@CommentNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@Url", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@ExtractionTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Score", SqlDbType.Float,8)             
              
            };

            parameters[0].Value = entity.Title;
            parameters[1].Value = entity.Detail;
            parameters[2].Value = entity.SendTime;
            parameters[3].Value = entity.Media;
            parameters[4].Value = entity.Author;
            parameters[5].Value = entity.ClickNum;
            parameters[6].Value = entity.CommentNum;
            parameters[7].Value = entity.Url;
            parameters[8].Value = entity.ExtractionTime;
            parameters[9].Value = entity.Score;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 0;
            } else {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_ARTICLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Article set ");

            strSql.Append(" Title = @Title , ");
            strSql.Append(" Detail = @Detail , ");
            strSql.Append(" SendTime = @SendTime , ");
            strSql.Append(" Media = @Media , ");
            strSql.Append(" Author = @Author , ");
            strSql.Append(" ClickNum = @ClickNum , ");
            strSql.Append(" CommentNum = @CommentNum , ");
            strSql.Append(" Url = @Url , ");
            strSql.Append(" ExtractionTime = @ExtractionTime , ");
            strSql.Append(" Score = @Score  ");
            strSql.Append(" where ArticleID=@ArticleID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ArticleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Detail", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@SendTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Media", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Author", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ClickNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@CommentNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@Url", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@ExtractionTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Score", SqlDbType.Float,8)             
              
            };

            parameters[10].Value = entity.ArticleID;
            parameters[11].Value = entity.Title;
            parameters[12].Value = entity.Detail;
            parameters[13].Value = entity.SendTime;
            parameters[14].Value = entity.Media;
            parameters[15].Value = entity.Author;
            parameters[16].Value = entity.ClickNum;
            parameters[17].Value = entity.CommentNum;
            parameters[18].Value = entity.Url;
            parameters[19].Value = entity.ExtractionTime;
            parameters[20].Value = entity.Score;
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ArticleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Article ");
            strSql.Append(" where ArticleID=@ArticleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ArticleID;


            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ArticleIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Article ");
            strSql.Append(" where ID in (" + ArticleIDlist + ")  ");
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString());
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.BASE_ARTICLE GetEntity(int ArticleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ArticleID, Title, Detail, SendTime, Media, Author, ClickNum, CommentNum, Url, ExtractionTime, Score  ");
            strSql.Append("  from Base_Article ");
            strSql.Append(" where ArticleID=@ArticleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ArticleID;


            Entity.BASE_ARTICLE entity = new Entity.BASE_ARTICLE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ArticleID"].ToString() != "") {
                    entity.ArticleID = int.Parse(ds.Tables[0].Rows[0]["ArticleID"].ToString());
                }
                entity.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                entity.Detail = ds.Tables[0].Rows[0]["Detail"].ToString();
                if (ds.Tables[0].Rows[0]["SendTime"].ToString() != "") {
                    entity.SendTime = DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
                }
                entity.Media = ds.Tables[0].Rows[0]["Media"].ToString();
                entity.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                if (ds.Tables[0].Rows[0]["ClickNum"].ToString() != "") {
                    entity.ClickNum = int.Parse(ds.Tables[0].Rows[0]["ClickNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CommentNum"].ToString() != "") {
                    entity.CommentNum = int.Parse(ds.Tables[0].Rows[0]["CommentNum"].ToString());
                }
                entity.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                if (ds.Tables[0].Rows[0]["ExtractionTime"].ToString() != "") {
                    entity.ExtractionTime = DateTime.Parse(ds.Tables[0].Rows[0]["ExtractionTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Score"].ToString() != "") {
                    entity.Score = decimal.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }

                return entity;
            } else {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Base_Article ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Base_Article ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

