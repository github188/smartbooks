// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROLE.cs
// 功能描述:Base_Role -- 接口实现
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
    /// Base_Role -- 接口实现
    /// </summary>
    public partial class BASE_ROLE : IBASE_ROLE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int RoleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Role");
            strSql.Append(" where ");
            strSql.Append(" RoleID = @RoleID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_ROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Role(");
            strSql.Append("RoleGroupID,RoleName,RoleDescription,RoleOrder");
            strSql.Append(") values (");
            strSql.Append("@RoleGroupID,@RoleName,@RoleDescription,@RoleOrder");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@RoleGroupID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@RoleDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@RoleOrder", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.RoleGroupID;
            parameters[1].Value = entity.RoleName;
            parameters[2].Value = entity.RoleDescription;
            parameters[3].Value = entity.RoleOrder;

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
        public bool Update(Entity.BASE_ROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Role set ");

            strSql.Append(" RoleGroupID = @RoleGroupID , ");
            strSql.Append(" RoleName = @RoleName , ");
            strSql.Append(" RoleDescription = @RoleDescription , ");
            strSql.Append(" RoleOrder = @RoleOrder  ");
            strSql.Append(" where RoleID=@RoleID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleGroupID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@RoleDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@RoleOrder", SqlDbType.Int,4)             
              
            };

            parameters[4].Value = entity.RoleID;
            parameters[5].Value = entity.RoleGroupID;
            parameters[6].Value = entity.RoleName;
            parameters[7].Value = entity.RoleDescription;
            parameters[8].Value = entity.RoleOrder;
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
        public bool Delete(int RoleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Role ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;


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
        public bool DeleteList(string RoleIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Role ");
            strSql.Append(" where ID in (" + RoleIDlist + ")  ");
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
        public Entity.BASE_ROLE GetEntity(int RoleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID, RoleGroupID, RoleName, RoleDescription, RoleOrder  ");
            strSql.Append("  from Base_Role ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;


            Entity.BASE_ROLE entity = new Entity.BASE_ROLE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "") {
                    entity.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleGroupID"].ToString() != "") {
                    entity.RoleGroupID = int.Parse(ds.Tables[0].Rows[0]["RoleGroupID"].ToString());
                }
                entity.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                entity.RoleDescription = ds.Tables[0].Rows[0]["RoleDescription"].ToString();
                if (ds.Tables[0].Rows[0]["RoleOrder"].ToString() != "") {
                    entity.RoleOrder = int.Parse(ds.Tables[0].Rows[0]["RoleOrder"].ToString());
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
            strSql.Append(" FROM Base_Role ");
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
            strSql.Append(" FROM Base_Role ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

