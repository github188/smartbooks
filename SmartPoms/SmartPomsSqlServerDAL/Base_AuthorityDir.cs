﻿// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_AUTHORITYDIR.cs
// 功能描述:Base_AuthorityDir -- 接口实现
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
    /// Base_AuthorityDir -- 接口实现
    /// </summary>
    public partial class BASE_AUTHORITYDIR : IBASE_AUTHORITYDIR {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int AuthorityID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_AuthorityDir");
            strSql.Append(" where ");
            strSql.Append(" AuthorityID = @AuthorityID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4)
			};
            parameters[0].Value = AuthorityID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_AUTHORITYDIR entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_AuthorityDir(");
            strSql.Append("AuthorityName,AuthorityTag,AuthorityDescription,AuthorityOrder");
            strSql.Append(") values (");
            strSql.Append("@AuthorityName,@AuthorityTag,@AuthorityDescription,@AuthorityOrder");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@AuthorityName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AuthorityDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AuthorityOrder", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.AuthorityName;
            parameters[1].Value = entity.AuthorityTag;
            parameters[2].Value = entity.AuthorityDescription;
            parameters[3].Value = entity.AuthorityOrder;

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
        public bool Update(Entity.BASE_AUTHORITYDIR entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_AuthorityDir set ");

            strSql.Append(" AuthorityName = @AuthorityName , ");
            strSql.Append(" AuthorityTag = @AuthorityTag , ");
            strSql.Append(" AuthorityDescription = @AuthorityDescription , ");
            strSql.Append(" AuthorityOrder = @AuthorityOrder  ");
            strSql.Append(" where AuthorityID=@AuthorityID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@AuthorityID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AuthorityName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AuthorityDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AuthorityOrder", SqlDbType.Int,4)             
              
            };

            parameters[4].Value = entity.AuthorityID;
            parameters[5].Value = entity.AuthorityName;
            parameters[6].Value = entity.AuthorityTag;
            parameters[7].Value = entity.AuthorityDescription;
            parameters[8].Value = entity.AuthorityOrder;
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
        public bool Delete(int AuthorityID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_AuthorityDir ");
            strSql.Append(" where AuthorityID=@AuthorityID");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4)
			};
            parameters[0].Value = AuthorityID;


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
        public bool DeleteList(string AuthorityIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_AuthorityDir ");
            strSql.Append(" where ID in (" + AuthorityIDlist + ")  ");
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
        public Entity.BASE_AUTHORITYDIR GetEntity(int AuthorityID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AuthorityID, AuthorityName, AuthorityTag, AuthorityDescription, AuthorityOrder  ");
            strSql.Append("  from Base_AuthorityDir ");
            strSql.Append(" where AuthorityID=@AuthorityID");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4)
			};
            parameters[0].Value = AuthorityID;


            Entity.BASE_AUTHORITYDIR entity = new Entity.BASE_AUTHORITYDIR();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["AuthorityID"].ToString() != "") {
                    entity.AuthorityID = int.Parse(ds.Tables[0].Rows[0]["AuthorityID"].ToString());
                }
                entity.AuthorityName = ds.Tables[0].Rows[0]["AuthorityName"].ToString();
                entity.AuthorityTag = ds.Tables[0].Rows[0]["AuthorityTag"].ToString();
                entity.AuthorityDescription = ds.Tables[0].Rows[0]["AuthorityDescription"].ToString();
                if (ds.Tables[0].Rows[0]["AuthorityOrder"].ToString() != "") {
                    entity.AuthorityOrder = int.Parse(ds.Tables[0].Rows[0]["AuthorityOrder"].ToString());
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
            strSql.Append(" FROM Base_AuthorityDir ");
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
            strSql.Append(" FROM Base_AuthorityDir ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


        /// <summary>
        /// 判断权限标识否存在
        /// </summary>
        /// <param name="AuthorityTag">权限标识</param>
        /// <returns></returns>
        public bool Exists(string AuthorityTag) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Base_AuthorityDir");
            strSql.Append(" where AuthorityTag=@AuthorityTag ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = AuthorityTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一个权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        public bool CreateAuthority(Entity.BASE_AUTHORITYDIR model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_AuthorityDir(");
            strSql.Append("AuthorityName,AuthorityTag,AuthorityDescription,AuthorityOrder)");
            strSql.Append(" values (");
            strSql.Append("@AuthorityName,@AuthorityTag,@AuthorityDescription,@AuthorityOrder)");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityName", SqlDbType.NVarChar,30),
					new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@AuthorityOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.AuthorityName;
            parameters[1].Value = model.AuthorityTag;
            parameters[2].Value = model.AuthorityDescription;
            parameters[3].Value = model.AuthorityOrder;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 更新指定的权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        public bool UpdateAuthority(Entity.BASE_AUTHORITYDIR model) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_AuthorityDir set ");
            strSql.Append("AuthorityName=@AuthorityName,");
            strSql.Append("AuthorityTag=@AuthorityTag,");
            strSql.Append("AuthorityDescription=@AuthorityDescription,");
            strSql.Append("AuthorityOrder=@AuthorityOrder");
            strSql.Append(" where AuthorityID=@AuthorityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4),
					new SqlParameter("@AuthorityName", SqlDbType.NVarChar,30),
					new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityDescription", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.AuthorityID;
            parameters[1].Value = model.AuthorityName;
            parameters[2].Value = model.AuthorityTag;
            parameters[3].Value = model.AuthorityDescription;
            parameters[4].Value = model.AuthorityOrder;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }

        }

        /// <summary>
        /// 删除一个权限
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int AuthorityID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_AuthorityDir ");
            strSql.Append(" where AuthorityID=@AuthorityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4)};
            parameters[0].Value = AuthorityID;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }

        }

        /// <summary>
        /// 得到一个权限实体
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        public Entity.BASE_AUTHORITYDIR GetAuthorityModel(int AuthorityID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * FROM Base_AuthorityDir ");
            strSql.Append(" where AuthorityID=@AuthorityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4)};
            parameters[0].Value = AuthorityID;

            Entity.BASE_AUTHORITYDIR model = new Entity.BASE_AUTHORITYDIR();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["AuthorityID"].ToString() != "") {
                    model.AuthorityID = int.Parse(ds.Tables[0].Rows[0]["AuthorityID"].ToString());
                }
                model.AuthorityName = ds.Tables[0].Rows[0]["AuthorityName"].ToString();
                model.AuthorityTag = ds.Tables[0].Rows[0]["AuthorityTag"].ToString();
                model.AuthorityDescription = ds.Tables[0].Rows[0]["AuthorityDescription"].ToString();
                if (ds.Tables[0].Rows[0]["AuthorityOrder"].ToString() != "") {
                    model.AuthorityOrder = int.Parse(ds.Tables[0].Rows[0]["AuthorityOrder"].ToString());
                }

                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得权限数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(string strWhere, string strOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_AuthorityDir ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }

            if (strOrder.Trim() != "") {
                strSql.Append(" " + strOrder);
            }

            return SqlServerHelper.Query(strSql.ToString());
        }
    }
}

