// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_WARNING.cs
// 功能描述:预警信息表 -- 接口实现
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
    /// 预警信息表 -- 接口实现
    /// </summary>
    public partial class BASE_WARNING : IBASE_WARNING {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int WARNINGID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_WARNING");
            strSql.Append(" where ");
            strSql.Append(" WARNINGID = @WARNINGID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@WARNINGID", SqlDbType.Int,4)
			};
            parameters[0].Value = WARNINGID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_WARNING entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_WARNING(");
            strSql.Append("TITLE,DETAIL,GENERATEDATE,ARTICLE,ENABLE,SNAPSHOT,ISREAD,SORT");
            strSql.Append(") values (");
            strSql.Append("@TITLE,@DETAIL,@GENERATEDATE,@ARTICLE,@ENABLE,@SNAPSHOT,@ISREAD,@SORT");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DETAIL", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GENERATEDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@ARTICLE", SqlDbType.Int,4) ,            
                        new SqlParameter("@ENABLE", SqlDbType.Int,4) ,            
                        new SqlParameter("@SNAPSHOT", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ISREAD", SqlDbType.Int,4) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.TITLE;
            parameters[1].Value = entity.DETAIL;
            parameters[2].Value = entity.GENERATEDATE;
            parameters[3].Value = entity.ARTICLE;
            parameters[4].Value = entity.ENABLE;
            parameters[5].Value = entity.SNAPSHOT;
            parameters[6].Value = entity.ISREAD;
            parameters[7].Value = entity.SORT;

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
        public bool Update(Entity.BASE_WARNING entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_WARNING set ");

            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" DETAIL = @DETAIL , ");
            strSql.Append(" GENERATEDATE = @GENERATEDATE , ");
            strSql.Append(" ARTICLE = @ARTICLE , ");
            strSql.Append(" ENABLE = @ENABLE , ");
            strSql.Append(" SNAPSHOT = @SNAPSHOT , ");
            strSql.Append(" ISREAD = @ISREAD , ");
            strSql.Append(" SORT = @SORT  ");
            strSql.Append(" where WARNINGID=@WARNINGID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@WARNINGID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DETAIL", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GENERATEDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@ARTICLE", SqlDbType.Int,4) ,            
                        new SqlParameter("@ENABLE", SqlDbType.Int,4) ,            
                        new SqlParameter("@SNAPSHOT", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ISREAD", SqlDbType.Int,4) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4)             
              
            };

            parameters[8].Value = entity.WARNINGID;
            parameters[9].Value = entity.TITLE;
            parameters[10].Value = entity.DETAIL;
            parameters[11].Value = entity.GENERATEDATE;
            parameters[12].Value = entity.ARTICLE;
            parameters[13].Value = entity.ENABLE;
            parameters[14].Value = entity.SNAPSHOT;
            parameters[15].Value = entity.ISREAD;
            parameters[16].Value = entity.SORT;
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
        public bool Delete(int WARNINGID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_WARNING ");
            strSql.Append(" where WARNINGID=@WARNINGID");
            SqlParameter[] parameters = {
					new SqlParameter("@WARNINGID", SqlDbType.Int,4)
			};
            parameters[0].Value = WARNINGID;


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
        public bool DeleteList(string WARNINGIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_WARNING ");
            strSql.Append(" where ID in (" + WARNINGIDlist + ")  ");
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
        public Entity.BASE_WARNING GetEntity(int WARNINGID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WARNINGID, TITLE, DETAIL, GENERATEDATE, ARTICLE, ENABLE, SNAPSHOT, ISREAD, SORT  ");
            strSql.Append("  from BASE_WARNING ");
            strSql.Append(" where WARNINGID=@WARNINGID");
            SqlParameter[] parameters = {
					new SqlParameter("@WARNINGID", SqlDbType.Int,4)
			};
            parameters[0].Value = WARNINGID;


            Entity.BASE_WARNING entity = new Entity.BASE_WARNING();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["WARNINGID"].ToString() != "") {
                    entity.WARNINGID = int.Parse(ds.Tables[0].Rows[0]["WARNINGID"].ToString());
                }
                entity.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                entity.DETAIL = ds.Tables[0].Rows[0]["DETAIL"].ToString();
                if (ds.Tables[0].Rows[0]["GENERATEDATE"].ToString() != "") {
                    entity.GENERATEDATE = DateTime.Parse(ds.Tables[0].Rows[0]["GENERATEDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ARTICLE"].ToString() != "") {
                    entity.ARTICLE = int.Parse(ds.Tables[0].Rows[0]["ARTICLE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ENABLE"].ToString() != "") {
                    entity.ENABLE = int.Parse(ds.Tables[0].Rows[0]["ENABLE"].ToString());
                }
                entity.SNAPSHOT = ds.Tables[0].Rows[0]["SNAPSHOT"].ToString();
                if (ds.Tables[0].Rows[0]["ISREAD"].ToString() != "") {
                    entity.ISREAD = int.Parse(ds.Tables[0].Rows[0]["ISREAD"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SORT"].ToString() != "") {
                    entity.SORT = int.Parse(ds.Tables[0].Rows[0]["SORT"].ToString());
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
            strSql.Append(" FROM BASE_WARNING ");
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
            strSql.Append(" FROM BASE_WARNING ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }
    }
}