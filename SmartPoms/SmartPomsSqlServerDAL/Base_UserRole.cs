// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USERROLE.cs
// 功能描述:Base_UserRole -- 接口实现
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
    /// Base_UserRole -- 接口实现
    /// </summary>
    public partial class BASE_USERROLE : IBASE_USERROLE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int UR_ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_UserRole");
            strSql.Append(" where ");
            strSql.Append(" UR_ID = @UR_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UR_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UR_ID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_USERROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_UserRole(");
            strSql.Append("UserID,RoleID");
            strSql.Append(") values (");
            strSql.Append("@UserID,@RoleID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleID", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.UserID;
            parameters[1].Value = entity.RoleID;

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
        public bool Update(Entity.BASE_USERROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_UserRole set ");

            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" RoleID = @RoleID  ");
            strSql.Append(" where UR_ID=@UR_ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UR_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleID", SqlDbType.Int,4)             
              
            };

            parameters[2].Value = entity.UR_ID;
            parameters[3].Value = entity.UserID;
            parameters[4].Value = entity.RoleID;
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
        public bool Delete(int UR_ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_UserRole ");
            strSql.Append(" where UR_ID=@UR_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UR_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UR_ID;


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
        public bool DeleteList(string UR_IDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_UserRole ");
            strSql.Append(" where ID in (" + UR_IDlist + ")  ");
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
        public Entity.BASE_USERROLE GetEntity(int UR_ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UR_ID, UserID, RoleID  ");
            strSql.Append("  from Base_UserRole ");
            strSql.Append(" where UR_ID=@UR_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UR_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UR_ID;


            Entity.BASE_USERROLE entity = new Entity.BASE_USERROLE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["UR_ID"].ToString() != "") {
                    entity.UR_ID = int.Parse(ds.Tables[0].Rows[0]["UR_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    entity.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "") {
                    entity.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
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
            strSql.Append(" FROM Base_UserRole ");
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
            strSql.Append(" FROM Base_UserRole ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

