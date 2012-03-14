// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROLEAUTHORITYKIST.cs
// 功能描述:Base_RoleAuthorityKist -- 接口实现
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
    /// Base_RoleAuthorityKist -- 接口实现
    /// </summary>
    public partial class BASE_ROLEAUTHORITYKIST : IBASE_ROLEAUTHORITYKIST {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_RoleAuthorityKist");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_ROLEAUTHORITYKIST entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_RoleAuthorityKist(");
            strSql.Append("UserID,RoleID,GroupID,ModuleID,AuthorityTag,Flag");
            strSql.Append(") values (");
            strSql.Append("@UserID,@RoleID,@GroupID,@ModuleID,@AuthorityTag,@Flag");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Flag", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = entity.UserID;
            parameters[1].Value = entity.RoleID;
            parameters[2].Value = entity.GroupID;
            parameters[3].Value = entity.ModuleID;
            parameters[4].Value = entity.AuthorityTag;
            parameters[5].Value = entity.Flag;

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
        public bool Update(Entity.BASE_ROLEAUTHORITYKIST entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_RoleAuthorityKist set ");

            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" RoleID = @RoleID , ");
            strSql.Append(" GroupID = @GroupID , ");
            strSql.Append(" ModuleID = @ModuleID , ");
            strSql.Append(" AuthorityTag = @AuthorityTag , ");
            strSql.Append(" Flag = @Flag  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Flag", SqlDbType.Bit,1)             
              
            };

            parameters[6].Value = entity.ID;
            parameters[7].Value = entity.UserID;
            parameters[8].Value = entity.RoleID;
            parameters[9].Value = entity.GroupID;
            parameters[10].Value = entity.ModuleID;
            parameters[11].Value = entity.AuthorityTag;
            parameters[12].Value = entity.Flag;
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
        public bool Delete(int ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_RoleAuthorityKist ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


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
        public bool DeleteList(string IDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_RoleAuthorityKist ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Entity.BASE_ROLEAUTHORITYKIST GetEntity(int ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, UserID, RoleID, GroupID, ModuleID, AuthorityTag, Flag  ");
            strSql.Append("  from Base_RoleAuthorityKist ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            Entity.BASE_ROLEAUTHORITYKIST entity = new Entity.BASE_ROLEAUTHORITYKIST();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "") {
                    entity.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    entity.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "") {
                    entity.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GroupID"].ToString() != "") {
                    entity.GroupID = int.Parse(ds.Tables[0].Rows[0]["GroupID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "") {
                    entity.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                entity.AuthorityTag = ds.Tables[0].Rows[0]["AuthorityTag"].ToString();
                if (ds.Tables[0].Rows[0]["Flag"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["Flag"].ToString() == "1") || (ds.Tables[0].Rows[0]["Flag"].ToString().ToLower() == "true")) {
                        entity.Flag = true;
                    } else {
                        entity.Flag = false;
                    }
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
            strSql.Append(" FROM Base_RoleAuthorityKist ");
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
            strSql.Append(" FROM Base_RoleAuthorityKist ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

