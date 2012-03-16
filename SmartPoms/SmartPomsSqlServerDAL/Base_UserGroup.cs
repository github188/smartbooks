// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USERGROUP.cs
// 功能描述:Base_UserGroup -- 接口实现
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
    /// Base_UserGroup -- 接口实现
    /// </summary>
    public partial class BASE_USERGROUP : IBASE_USERGROUP {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int UG_ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_UserGroup");
            strSql.Append(" where ");
            strSql.Append(" UG_ID = @UG_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UG_ID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_USERGROUP entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_UserGroup(");
            strSql.Append("UG_Name,UG_Order,UG_Description,UG_Depth,UG_SuperiorID,UG_Count");
            strSql.Append(") values (");
            strSql.Append("@UG_Name,@UG_Order,@UG_Description,@UG_Depth,@UG_SuperiorID,@UG_Count");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UG_Name", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@UG_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Description", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@UG_Depth", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_SuperiorID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Count", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.UG_Name;
            parameters[1].Value = entity.UG_Order;
            parameters[2].Value = entity.UG_Description;
            parameters[3].Value = entity.UG_Depth;
            parameters[4].Value = entity.UG_SuperiorID;
            parameters[5].Value = entity.UG_Count;

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
        public bool Update(Entity.BASE_USERGROUP entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_UserGroup set ");

            strSql.Append(" UG_Name = @UG_Name , ");
            strSql.Append(" UG_Order = @UG_Order , ");
            strSql.Append(" UG_Description = @UG_Description , ");
            strSql.Append(" UG_Depth = @UG_Depth , ");
            strSql.Append(" UG_SuperiorID = @UG_SuperiorID , ");
            strSql.Append(" UG_Count = @UG_Count  ");
            strSql.Append(" where UG_ID=@UG_ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UG_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Name", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@UG_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Description", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@UG_Depth", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_SuperiorID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Count", SqlDbType.Int,4)             
              
            };

            parameters[6].Value = entity.UG_ID;
            parameters[7].Value = entity.UG_Name;
            parameters[8].Value = entity.UG_Order;
            parameters[9].Value = entity.UG_Description;
            parameters[10].Value = entity.UG_Depth;
            parameters[11].Value = entity.UG_SuperiorID;
            parameters[12].Value = entity.UG_Count;
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
        public bool Delete(int UG_ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_UserGroup ");
            strSql.Append(" where UG_ID=@UG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UG_ID;


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
        public bool DeleteList(string UG_IDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_UserGroup ");
            strSql.Append(" where ID in (" + UG_IDlist + ")  ");
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
        public Entity.BASE_USERGROUP GetEntity(int UG_ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UG_ID, UG_Name, UG_Order, UG_Description, UG_Depth, UG_SuperiorID, UG_Count  ");
            strSql.Append("  from Base_UserGroup ");
            strSql.Append(" where UG_ID=@UG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UG_ID;


            Entity.BASE_USERGROUP entity = new Entity.BASE_USERGROUP();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["UG_ID"].ToString() != "") {
                    entity.UG_ID = int.Parse(ds.Tables[0].Rows[0]["UG_ID"].ToString());
                }
                entity.UG_Name = ds.Tables[0].Rows[0]["UG_Name"].ToString();
                if (ds.Tables[0].Rows[0]["UG_Order"].ToString() != "") {
                    entity.UG_Order = int.Parse(ds.Tables[0].Rows[0]["UG_Order"].ToString());
                }
                entity.UG_Description = ds.Tables[0].Rows[0]["UG_Description"].ToString();
                if (ds.Tables[0].Rows[0]["UG_Depth"].ToString() != "") {
                    entity.UG_Depth = int.Parse(ds.Tables[0].Rows[0]["UG_Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UG_SuperiorID"].ToString() != "") {
                    entity.UG_SuperiorID = int.Parse(ds.Tables[0].Rows[0]["UG_SuperiorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UG_Count"].ToString() != "") {
                    entity.UG_Count = int.Parse(ds.Tables[0].Rows[0]["UG_Count"].ToString());
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
            strSql.Append(" FROM Base_UserGroup ");
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
            strSql.Append(" FROM Base_UserGroup ");
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

        #region 用户分组
        /// <summary>
        /// 判断用户分组是否存在
        /// </summary>
        /// <param name="UG_Name">用户分组名称</param>
        /// <returns></returns>
        public bool UserGroupExists(string Name) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_UserGroup");
            strSql.Append(" where UG_Name=@UG_Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_Name", SqlDbType.NVarChar,30)};
            parameters[0].Value = Name;


            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一个用户分组
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        public int CreateUserGroup(Entity.BASE_USERGROUP model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_UserGroup(");
            strSql.Append("UG_Name,UG_Order,UG_SuperiorID,UG_Depth,UG_Description)");
            strSql.Append(" values (");
            strSql.Append("@UG_Name,@UG_Order,@UG_SuperiorID,@UG_Depth,@UG_Description)");

            SqlParameter[] parameters = {
					new SqlParameter("@UG_Name", SqlDbType.NVarChar,30),
					new SqlParameter("@UG_Order", SqlDbType.Int,4),
                    new SqlParameter("@UG_SuperiorID", SqlDbType.Int,4),
                    new SqlParameter("@UG_Depth", SqlDbType.Int,4),
					new SqlParameter("@UG_Description", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UG_Name;
            parameters[1].Value = model.UG_Order;
            parameters[2].Value = model.UG_SuperiorID;
            parameters[3].Value = GetUserGroupDepth(model.UG_SuperiorID) + 1;//更新级别深度
            parameters[4].Value = model.UG_Description;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        public bool UpdateUserGroup(Entity.BASE_USERGROUP model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_UserGroup set ");
            strSql.Append("UG_Name=@UG_Name,");
            strSql.Append("UG_Order=@UG_Order,");
            strSql.Append("UG_SuperiorID=@UG_SuperiorID,");
            strSql.Append("UG_Depth=@UG_Depth,");
            strSql.Append("UG_Description=@UG_Description");
            strSql.Append(" where UG_ID=@UG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4),
					new SqlParameter("@UG_Name", SqlDbType.NVarChar,30),
					new SqlParameter("@UG_Order", SqlDbType.Int,4),
                    new SqlParameter("@UG_SuperiorID", SqlDbType.Int,4),
                    new SqlParameter("@UG_Depth", SqlDbType.Int,4),
					new SqlParameter("@UG_Description", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UG_ID;
            parameters[1].Value = model.UG_Name;
            parameters[2].Value = model.UG_Order;
            parameters[3].Value = model.UG_SuperiorID;
            parameters[4].Value = GetUserGroupDepth(model.UG_SuperiorID) + 1;//更新级别深度
            parameters[5].Value = model.UG_Description;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除用户分组
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        public int DeleteUserGroup(int id) {
            int ret = 0;
            string strSql1 = "Select UserID from Base_User where UserGroup=@UG_ID";
            string strSql2 = "Select UG_ID from Base_UserGroup where UG_SuperiorID=@UG_ID";
            string strSql3 = "delete Base_UserGroup where UG_ID=@UG_ID";

            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            if (!SqlServerHelper.Exists(strSql1, parameters) && !SqlServerHelper.Exists(strSql2, parameters)) {
                if (SqlServerHelper.ExecuteSql(strSql3, parameters) >= 1) {
                    ret = 1;
                } else {
                    ret = 0;
                }
            } else {
                ret = 2;
            }
            return ret;
        }

        /// <summary>
        /// 获取模块深度
        /// </summary>
        /// <param name="ID">模块ID</param>
        /// <returns></returns>
        public int GetUserGroupDepth(int id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UG_Depth from Base_UserGroup where UG_ID=@UG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 得到一个用户分组实体
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        public Entity.BASE_USERGROUP GetUserGroupModel(int id) {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select top 1 * from Base_UserGroup ");
            strSql.Append(" where UG_ID=@UG_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Entity.BASE_USERGROUP model = new Entity.BASE_USERGROUP();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["UG_ID"].ToString() != "") {
                    model.UG_ID = int.Parse(ds.Tables[0].Rows[0]["UG_ID"].ToString());
                }
                model.UG_Name = ds.Tables[0].Rows[0]["UG_Name"].ToString();
                if (ds.Tables[0].Rows[0]["UG_Order"].ToString() != "") {
                    model.UG_Order = int.Parse(ds.Tables[0].Rows[0]["UG_Order"].ToString());
                }
                model.UG_Description = ds.Tables[0].Rows[0]["UG_Description"].ToString();
                if (ds.Tables[0].Rows[0]["UG_Depth"].ToString() != "") {
                    model.UG_Depth = int.Parse(ds.Tables[0].Rows[0]["UG_Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UG_SuperiorID"].ToString() != "") {
                    model.UG_SuperiorID = int.Parse(ds.Tables[0].Rows[0]["UG_SuperiorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UG_Count"].ToString() != "") {
                    model.UG_Count = int.Parse(ds.Tables[0].Rows[0]["UG_Count"].ToString());
                }

                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得用户分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet GetUserGroupList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_UserGroup ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by UG_Order,UG_SuperiorID desc");

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得用户分组下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public DataSet GetChildUserGroupList(int id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_UserGroup where UG_SuperiorID=" + id.ToString() + "order by UG_Order asc");
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 判断用户分组下是否有模块
        /// </summary>
        /// <param name="ID">分类iD</param>
        /// <returns></returns>
        public bool IsUser(int id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID from Base_User where UG_ID=" + id.ToString());
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) == 0) {
                return false;
            } else {
                return true;
            }

        }

        #endregion

    }
}

