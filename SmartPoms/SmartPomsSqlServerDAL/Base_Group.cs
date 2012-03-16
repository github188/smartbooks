// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_GROUP.cs
// 功能描述:Base_Group -- 接口实现
//
// 创建标识：王 亚 2012-03-14
namespace SmartPoms.SQLServerDAL {
    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using System.Collections;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// Base_Group -- 接口实现
    /// </summary>
    public partial class BASE_GROUP : IBASE_GROUP {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int GroupID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Group");
            strSql.Append(" where ");
            strSql.Append(" GroupID = @GroupID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)
			};
            parameters[0].Value = GroupID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_GROUP entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Group(");
            strSql.Append("GroupName,GroupOrder,GroupDescription,GroupType");
            strSql.Append(") values (");
            strSql.Append("@GroupName,@GroupOrder,@GroupDescription,@GroupType");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@GroupName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@GroupOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GroupType", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.GroupName;
            parameters[1].Value = entity.GroupOrder;
            parameters[2].Value = entity.GroupDescription;
            parameters[3].Value = entity.GroupType;

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
        public bool Update(Entity.BASE_GROUP entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Group set ");

            strSql.Append(" GroupName = @GroupName , ");
            strSql.Append(" GroupOrder = @GroupOrder , ");
            strSql.Append(" GroupDescription = @GroupDescription , ");
            strSql.Append(" GroupType = @GroupType  ");
            strSql.Append(" where GroupID=@GroupID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@GroupID", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@GroupOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GroupType", SqlDbType.Int,4)             
              
            };

            parameters[4].Value = entity.GroupID;
            parameters[5].Value = entity.GroupName;
            parameters[6].Value = entity.GroupOrder;
            parameters[7].Value = entity.GroupDescription;
            parameters[8].Value = entity.GroupType;
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
        public bool Delete(int GroupID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Group ");
            strSql.Append(" where GroupID=@GroupID");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)
			};
            parameters[0].Value = GroupID;


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
        public bool DeleteList(string GroupIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Group ");
            strSql.Append(" where ID in (" + GroupIDlist + ")  ");
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
        public Entity.BASE_GROUP GetEntity(int GroupID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GroupID, GroupName, GroupOrder, GroupDescription, GroupType  ");
            strSql.Append("  from Base_Group ");
            strSql.Append(" where GroupID=@GroupID");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)
			};
            parameters[0].Value = GroupID;


            Entity.BASE_GROUP entity = new Entity.BASE_GROUP();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["GroupID"].ToString() != "") {
                    entity.GroupID = int.Parse(ds.Tables[0].Rows[0]["GroupID"].ToString());
                }
                entity.GroupName = ds.Tables[0].Rows[0]["GroupName"].ToString();
                if (ds.Tables[0].Rows[0]["GroupOrder"].ToString() != "") {
                    entity.GroupOrder = int.Parse(ds.Tables[0].Rows[0]["GroupOrder"].ToString());
                }
                entity.GroupDescription = ds.Tables[0].Rows[0]["GroupDescription"].ToString();
                if (ds.Tables[0].Rows[0]["GroupType"].ToString() != "") {
                    entity.GroupType = int.Parse(ds.Tables[0].Rows[0]["GroupType"].ToString());
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
            strSql.Append(" FROM Base_Group ");
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
            strSql.Append(" FROM Base_Group ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }

        #region  成员方法

        /// <summary>
        /// 判断分组是否存在
        /// </summary>
        /// <param name="GroupName">分组名称</param>
        /// <returns></returns>
        public bool Exists(string GroupName, int GroupType) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Group");
            strSql.Append(" where GroupName=@GroupName and GroupType=@GroupType");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
                    new SqlParameter("@GroupType", SqlDbType.Int,4)};
            parameters[0].Value = GroupName;
            parameters[1].Value = GroupType;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一个分组
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        public bool CreateGroup(Entity.BASE_GROUP model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Group(");
            strSql.Append("GroupName,GroupOrder,GroupDescription,GroupType)");
            strSql.Append(" values (");
            strSql.Append("@GroupName,@GroupOrder,@GroupDescription,@GroupType)");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
					new SqlParameter("@GroupOrder", SqlDbType.Int,4),
					new SqlParameter("@GroupDescription", SqlDbType.NVarChar),
                    new SqlParameter("@GroupType", SqlDbType.Int,4)};
            parameters[0].Value = model.GroupName;
            parameters[1].Value = model.GroupOrder;
            parameters[2].Value = model.GroupDescription;
            parameters[3].Value = model.GroupType;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        public bool UpdateGroup(Entity.BASE_GROUP model) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Group set ");
            strSql.Append("GroupName=@GroupName,");
            strSql.Append("GroupOrder=@GroupOrder,");
            strSql.Append("GroupDescription=@GroupDescription");
            strSql.Append(" where GroupID=@GroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
					new SqlParameter("@GroupOrder", SqlDbType.Int,4),
					new SqlParameter("@GroupDescription", SqlDbType.NVarChar)};
            parameters[0].Value = model.GroupID;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.GroupOrder;
            parameters[3].Value = model.GroupDescription;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        public int DeleteGroup(int GroupID) {
            int ret = 0;

            string strSql1 = "Select RoleID from Base_Role where RoleGroupID=@GroupID"; //查看应组下是否存在角色
            string strSql2 = "Select UserID from Base_User where UserGroup=@GroupID";        //查看应组下是否存在用户

            ArrayList SQLList = new ArrayList();

            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)};
            parameters[0].Value = GroupID;

            if (!SqlServerHelper.Exists(strSql1.ToString(), parameters)) {
                if (!SqlServerHelper.Exists(strSql2.ToString(), parameters)) {
                    try {
                        SQLList.Add("delete Base_RoleAuthorityList where GroupID=" + parameters[0].Value);
                        SQLList.Add("delete Base_Group where GroupID=" + parameters[0].Value);
                        SqlServerHelper.ExecuteSqlTran(SQLList);
                        ret = 1;//删除成功
                    } catch {
                        ret = 0;//删除失败
                    }
                } else {
                    ret = 2;//有用户，不能删除
                }
            } else {
                ret = 3;//有角色，不能删除
            }
            return ret;
        }

        /// <summary>
        /// 得到一个分组实体
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        public Entity.BASE_GROUP GetGroupModel(int GroupID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Base_Group ");
            strSql.Append(" where GroupID=@GroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)};
            parameters[0].Value = GroupID;

            Entity.BASE_GROUP model = new Entity.BASE_GROUP();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["GroupID"].ToString() != "") {
                    model.GroupID = int.Parse(ds.Tables[0].Rows[0]["GroupID"].ToString());
                }
                model.GroupName = ds.Tables[0].Rows[0]["GroupName"].ToString();
                if (ds.Tables[0].Rows[0]["GroupOrder"].ToString() != "") {
                    model.GroupOrder = int.Parse(ds.Tables[0].Rows[0]["GroupOrder"].ToString());
                }
                model.GroupDescription = ds.Tables[0].Rows[0]["GroupDescription"].ToString();

                if (ds.Tables[0].Rows[0]["GroupType"].ToString() != "") {
                    model.GroupType = int.Parse(ds.Tables[0].Rows[0]["GroupType"].ToString());
                }

                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetGroupList(string strWhere, string strOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_Group ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }

            if (strOrder.Trim() != "") {
                strSql.Append(" " + strOrder);
            }

            return SqlServerHelper.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

