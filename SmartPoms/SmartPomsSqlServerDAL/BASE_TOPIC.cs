// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_TOPIC.cs
// 功能描述:专题信息表 -- 接口实现
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
    /// 专题信息表 -- 接口实现
    /// </summary>
    public partial class BASE_TOPIC : IBASE_TOPIC {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int TOPICID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_TOPIC");
            strSql.Append(" where ");
            strSql.Append(" TOPICID = @TOPICID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@TOPICID", SqlDbType.Int,4)
			};
            parameters[0].Value = TOPICID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_TOPIC entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_TOPIC(");
            strSql.Append("TOPICNAME,SUMMARY,SCORE,TOPICIDPARENT,ENABLE,SORT");
            strSql.Append(") values (");
            strSql.Append("@TOPICNAME,@SUMMARY,@SCORE,@TOPICIDPARENT,@ENABLE,@SORT");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@TOPICNAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SCORE", SqlDbType.Int,4) ,            
                        new SqlParameter("@TOPICIDPARENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@ENABLE", SqlDbType.Int,4) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.TOPICNAME;
            parameters[1].Value = entity.SUMMARY;
            parameters[2].Value = entity.SCORE;
            parameters[3].Value = entity.TOPICIDPARENT;
            parameters[4].Value = entity.ENABLE;
            parameters[5].Value = entity.SORT;

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
        public bool Update(Entity.BASE_TOPIC entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_TOPIC set ");

            strSql.Append(" TOPICNAME = @TOPICNAME , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" SCORE = @SCORE , ");
            strSql.Append(" TOPICIDPARENT = @TOPICIDPARENT , ");
            strSql.Append(" ENABLE = @ENABLE , ");
            strSql.Append(" SORT = @SORT  ");
            strSql.Append(" where TOPICID=@TOPICID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@TOPICID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TOPICNAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SCORE", SqlDbType.Int,4) ,            
                        new SqlParameter("@TOPICIDPARENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@ENABLE", SqlDbType.Int,4) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4)             
              
            };

            parameters[6].Value = entity.TOPICID;
            parameters[7].Value = entity.TOPICNAME;
            parameters[8].Value = entity.SUMMARY;
            parameters[9].Value = entity.SCORE;
            parameters[10].Value = entity.TOPICIDPARENT;
            parameters[11].Value = entity.ENABLE;
            parameters[12].Value = entity.SORT;
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
        public bool Delete(int TOPICID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_TOPIC ");
            strSql.Append(" where TOPICID=@TOPICID");
            SqlParameter[] parameters = {
					new SqlParameter("@TOPICID", SqlDbType.Int,4)
			};
            parameters[0].Value = TOPICID;


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
        public bool DeleteList(string TOPICIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_TOPIC ");
            strSql.Append(" where ID in (" + TOPICIDlist + ")  ");
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
        public Entity.BASE_TOPIC GetEntity(int TOPICID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOPICID, TOPICNAME, SUMMARY, SCORE, TOPICIDPARENT, ENABLE, SORT  ");
            strSql.Append("  from BASE_TOPIC ");
            strSql.Append(" where TOPICID=@TOPICID");
            SqlParameter[] parameters = {
					new SqlParameter("@TOPICID", SqlDbType.Int,4)
			};
            parameters[0].Value = TOPICID;


            Entity.BASE_TOPIC entity = new Entity.BASE_TOPIC();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["TOPICID"].ToString() != "") {
                    entity.TOPICID = int.Parse(ds.Tables[0].Rows[0]["TOPICID"].ToString());
                }
                entity.TOPICNAME = ds.Tables[0].Rows[0]["TOPICNAME"].ToString();
                entity.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                if (ds.Tables[0].Rows[0]["SCORE"].ToString() != "") {
                    entity.SCORE = int.Parse(ds.Tables[0].Rows[0]["SCORE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TOPICIDPARENT"].ToString() != "") {
                    entity.TOPICIDPARENT = int.Parse(ds.Tables[0].Rows[0]["TOPICIDPARENT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ENABLE"].ToString() != "") {
                    entity.ENABLE = int.Parse(ds.Tables[0].Rows[0]["ENABLE"].ToString());
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
            strSql.Append(" FROM BASE_TOPIC ");
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
            strSql.Append(" FROM BASE_TOPIC ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }
    }
}