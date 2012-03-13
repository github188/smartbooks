// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE.cs
// 功能描述:文章信息表 -- 接口实现
//
// 创建标识：王 亚 2012-03-12
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
        public bool Exists(int ARTICLEID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ARTICLE");
            strSql.Append(" where ");
            strSql.Append(" ARTICLEID = @ARTICLEID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARTICLEID", SqlDbType.Int,4)
			};
            parameters[0].Value = ARTICLEID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_ARTICLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ARTICLE(");
            strSql.Append("TOPICID,TITLE,PUBLISHDATE,SOURCE,AUTHOR,CLICK,COMMENT,DETAIL,REFERER,EXTRACTIONDATE,SCORE");
            strSql.Append(") values (");
            strSql.Append("@TOPICID,@TITLE,@PUBLISHDATE,@SOURCE,@AUTHOR,@CLICK,@COMMENT,@DETAIL,@REFERER,@EXTRACTIONDATE,@SCORE");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@TOPICID", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PUBLISHDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@SOURCE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@AUTHOR", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CLICK", SqlDbType.Int,4) ,            
                        new SqlParameter("@COMMENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@DETAIL", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@REFERER", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@EXTRACTIONDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@SCORE", SqlDbType.Float,8)             
              
            };

            parameters[0].Value = entity.TOPICID;
            parameters[1].Value = entity.TITLE;
            parameters[2].Value = entity.PUBLISHDATE;
            parameters[3].Value = entity.SOURCE;
            parameters[4].Value = entity.AUTHOR;
            parameters[5].Value = entity.CLICK;
            parameters[6].Value = entity.COMMENT;
            parameters[7].Value = entity.DETAIL;
            parameters[8].Value = entity.REFERER;
            parameters[9].Value = entity.EXTRACTIONDATE;
            parameters[10].Value = entity.SCORE;

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
            strSql.Append("update BASE_ARTICLE set ");

            strSql.Append(" TOPICID = @TOPICID , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" PUBLISHDATE = @PUBLISHDATE , ");
            strSql.Append(" SOURCE = @SOURCE , ");
            strSql.Append(" AUTHOR = @AUTHOR , ");
            strSql.Append(" CLICK = @CLICK , ");
            strSql.Append(" COMMENT = @COMMENT , ");
            strSql.Append(" DETAIL = @DETAIL , ");
            strSql.Append(" REFERER = @REFERER , ");
            strSql.Append(" EXTRACTIONDATE = @EXTRACTIONDATE , ");
            strSql.Append(" SCORE = @SCORE  ");
            strSql.Append(" where ARTICLEID=@ARTICLEID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ARTICLEID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TOPICID", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PUBLISHDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@SOURCE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@AUTHOR", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CLICK", SqlDbType.Int,4) ,            
                        new SqlParameter("@COMMENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@DETAIL", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@REFERER", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@EXTRACTIONDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@SCORE", SqlDbType.Float,8)             
              
            };

            parameters[11].Value = entity.ARTICLEID;
            parameters[12].Value = entity.TOPICID;
            parameters[13].Value = entity.TITLE;
            parameters[14].Value = entity.PUBLISHDATE;
            parameters[15].Value = entity.SOURCE;
            parameters[16].Value = entity.AUTHOR;
            parameters[17].Value = entity.CLICK;
            parameters[18].Value = entity.COMMENT;
            parameters[19].Value = entity.DETAIL;
            parameters[20].Value = entity.REFERER;
            parameters[21].Value = entity.EXTRACTIONDATE;
            parameters[22].Value = entity.SCORE;
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
        public bool Delete(int ARTICLEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ARTICLE ");
            strSql.Append(" where ARTICLEID=@ARTICLEID");
            SqlParameter[] parameters = {
					new SqlParameter("@ARTICLEID", SqlDbType.Int,4)
			};
            parameters[0].Value = ARTICLEID;


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
        public bool DeleteList(string ARTICLEIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ARTICLE ");
            strSql.Append(" where ID in (" + ARTICLEIDlist + ")  ");
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
        public Entity.BASE_ARTICLE GetEntity(int ARTICLEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ARTICLEID, TOPICID, TITLE, PUBLISHDATE, SOURCE, AUTHOR, CLICK, COMMENT, DETAIL, REFERER, EXTRACTIONDATE, SCORE  ");
            strSql.Append("  from BASE_ARTICLE ");
            strSql.Append(" where ARTICLEID=@ARTICLEID");
            SqlParameter[] parameters = {
					new SqlParameter("@ARTICLEID", SqlDbType.Int,4)
			};
            parameters[0].Value = ARTICLEID;


            Entity.BASE_ARTICLE entity = new Entity.BASE_ARTICLE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ARTICLEID"].ToString() != "") {
                    entity.ARTICLEID = int.Parse(ds.Tables[0].Rows[0]["ARTICLEID"].ToString());
                }
                entity.TOPICID = ds.Tables[0].Rows[0]["TOPICID"].ToString();
                entity.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                if (ds.Tables[0].Rows[0]["PUBLISHDATE"].ToString() != "") {
                    entity.PUBLISHDATE = DateTime.Parse(ds.Tables[0].Rows[0]["PUBLISHDATE"].ToString());
                }
                entity.SOURCE = ds.Tables[0].Rows[0]["SOURCE"].ToString();
                entity.AUTHOR = ds.Tables[0].Rows[0]["AUTHOR"].ToString();
                if (ds.Tables[0].Rows[0]["CLICK"].ToString() != "") {
                    entity.CLICK = int.Parse(ds.Tables[0].Rows[0]["CLICK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COMMENT"].ToString() != "") {
                    entity.COMMENT = int.Parse(ds.Tables[0].Rows[0]["COMMENT"].ToString());
                }
                entity.DETAIL = ds.Tables[0].Rows[0]["DETAIL"].ToString();
                entity.REFERER = ds.Tables[0].Rows[0]["REFERER"].ToString();
                if (ds.Tables[0].Rows[0]["EXTRACTIONDATE"].ToString() != "") {
                    entity.EXTRACTIONDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EXTRACTIONDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SCORE"].ToString() != "") {
                    entity.SCORE = decimal.Parse(ds.Tables[0].Rows[0]["SCORE"].ToString());
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
            strSql.Append("select ARTICLEID,TOPICID,TITLE,PUBLISHDATE,SOURCE,AUTHOR,CLICK,COMMENT,DETAIL,REFERER,EXTRACTIONDATE,SCORE ");
            strSql.Append(" FROM BASE_ARTICLE ");
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
            strSql.Append(" FROM BASE_ARTICLE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }
    }
}