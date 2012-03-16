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
    using System.Collections;
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

        #region 角色管理

        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <param name="RoleGroupID">角色分组ID</param>
        /// <returns></returns>
        public bool RoleExists(string RoleName, int RoleGroupID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Role");
            strSql.Append(" where RoleName=@RoleName and RoleGroupID=@RoleGroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,30),
                    new SqlParameter("@RoleGroupID", SqlDbType.Int,4)};
            parameters[0].Value = RoleName;
            parameters[1].Value = RoleGroupID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        public int CreateRole(Entity.BASE_ROLE model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Role(");
            strSql.Append("RoleGroupID,RoleName,RoleDescription,RoleOrder)");
            strSql.Append(" values (");
            strSql.Append("@RoleGroupID,@RoleName,@RoleDescription,@RoleOrder)");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleGroupID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,30),
					new SqlParameter("@RoleDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@RoleOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleGroupID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.RoleDescription;
            parameters[3].Value = model.RoleOrder;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)

                return 1;
            else
                return 0;

        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        public bool UpdateRole(Entity.BASE_ROLE model) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Role set ");
            strSql.Append("RoleGroupID=@RoleGroupID,");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleDescription=@RoleDescription,");
            strSql.Append("RoleOrder=@RoleOrder");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleGroupID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,30),
					new SqlParameter("@RoleDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@RoleOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleGroupID;
            parameters[2].Value = model.RoleName;
            parameters[3].Value = model.RoleDescription;
            parameters[4].Value = model.RoleOrder;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }

        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public int DeleteRole(int RoleID) {
            int ret = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;


            string strSql1 = "Select userid from Base_User where RoleID=@RoleID";

            //删除角色的同时删除相关的权限
            ArrayList list = new ArrayList();
            list.Add("delete Base_RoleAuthorityList where RoleID=" + RoleID.ToString());
            list.Add("delete Base_Role where RoleID=" + RoleID.ToString());

            if (!SqlServerHelper.Exists(strSql1, parameters)) {
                try {
                    SqlServerHelper.ExecuteSqlTran(list);
                    ret = 1;
                } catch {
                    ;
                }
            } else {
                ret = 2;
            }
            return ret;
        }

        /// <summary>
        /// 获取角色实体
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public Entity.BASE_ROLE GetRoleModel(int RoleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Base_Role ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;

            Entity.BASE_ROLE model = new Entity.BASE_ROLE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "") {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleRoleID"].ToString() != "") {
                    model.RoleGroupID = int.Parse(ds.Tables[0].Rows[0]["RoleGroupID"].ToString());
                }
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                model.RoleDescription = ds.Tables[0].Rows[0]["RoleDescription"].ToString();

                if (ds.Tables[0].Rows[0]["RoleOrder"].ToString() != "") {
                    model.RoleOrder = int.Parse(ds.Tables[0].Rows[0]["RoleOrder"].ToString());
                }

                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得角色数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetRoleList(string strWhere, string strOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_Role ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }

            if (strOrder.Trim() != "") {
                strSql.Append(" " + strOrder);
            }

            return SqlServerHelper.Query(strSql.ToString());
        }

        #endregion

        #region 授权


        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        public bool RoleAuthorityExists(Entity.BASE_ROLEAUTHORITYLIST model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_RoleAuthorityList where ");
            if (model.UserID != 0)//判断是角色权限还是用户权限
            { strSql.Append("UserID=@UserID"); } else if (model.RoleID != 0) { strSql.Append("RoleID=@RoleID"); } else { strSql.Append("GroupID=@GroupID"); }
            strSql.Append(" and ModuleID=@ModuleID and AuthorityTag=@AuthorityTag");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.GroupID;
            parameters[3].Value = model.ModuleID;
            parameters[4].Value = model.AuthorityTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        #region 用户授权
        /// <summary>
        /// 判断用户权限是否存在
        /// </summary>
        /// <param name="UserID">UID</param>
        /// <param name="ModuleID">模块ID</param>
        /// <param name="AuthorityTag">标限标识</param>
        /// <returns></returns>
        public bool UserAuthorityExists(int UserID, int ModuleID, string AuthorityTag) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_RoleAuthorityList");
            strSql.Append(" where UserID=@UserID and ModuleID=@ModuleID and AuthorityTag=@AuthorityTag");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ModuleID", SqlDbType.Int,4),
                    new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserID;
            parameters[1].Value = ModuleID;
            parameters[2].Value = AuthorityTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改用户模块权限
        /// </summary>
        public bool UpdateUserAuthority(ArrayList list) {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++) {
                string[] val = list[i].ToString().Split('|');

                switch (val[3]) {
                    case "0"://加入允许权限
                        //判断记录是否存在
                        if (UserAuthorityExists(int.Parse(val[0]), int.Parse(val[1]), val[2])) {
                            //存在则更新权限Flag=flase(禁止)
                            AuthorityList.Add("update Base_RoleAuthorityList set Flag=0 where UserID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                        } else {
                            //如果不存在则新增一条
                            AuthorityList.Add("insert into Base_RoleAuthorityList(UserID,ModuleID,AuthorityTag,Flag) values (" + val[0] + "," + val[1] + ",'" + val[2] + "',0)");
                        }
                        break;
                    case "1"://加入禁止权限
                        if (UserAuthorityExists(int.Parse(val[0]), int.Parse(val[1]), val[2])) {
                            //存在则更新权限Flag=True(允许)
                            AuthorityList.Add("update Base_RoleAuthorityList set Flag=1 where UserID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                        } else {
                            //如果不存在则新增一条
                            AuthorityList.Add("insert into Base_RoleAuthorityList(UserID,ModuleID,AuthorityTag) values (" + val[0] + "," + val[1] + ",'" + val[2] + "')");
                        }
                        break;
                    case "2"://删除权限
                        if (UserAuthorityExists(int.Parse(val[0]), int.Parse(val[1]), val[2]))
                            AuthorityList.Add("delete Base_RoleAuthorityList where UserID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                        break;
                }
            }

            try {
                SqlServerHelper.ExecuteSqlTran(AuthorityList);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 读取用户的模块权限
        /// </summary>
        public DataSet GetUserAuthorityList(int UserID, int ModuleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_RoleAuthorityList where UserID=" + UserID.ToString() + " and ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #region 角色授权
        /// <summary>
        /// 修改角色模块权限
        /// </summary>
        public bool UpdateRoleAuthority(ArrayList list) {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++) {
                string[] val = list[i].ToString().Split('|');
                if (val[3] == "0")//如果为0就删除权限
                {
                    AuthorityList.Add("delete Base_RoleAuthorityList where RoleID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                } else {
                    AuthorityList.Add("insert into Base_RoleAuthorityList(RoleID,ModuleID,AuthorityTag) values (" + val[0] + "," + val[1] + ",'" + val[2] + "')");
                }
            }

            try {
                SqlServerHelper.ExecuteSqlTran(AuthorityList);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 读取角色的模块权限
        /// </summary>
        public DataSet GetRoleAuthorityList(int RoleID, int ModuleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_RoleAuthorityList where RoleID=" + RoleID.ToString() + " and ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #region 分组授权
        /// <summary>
        /// 修改用户模块权限
        /// </summary>
        public bool UpdateGroupAuthority(ArrayList list) {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++) {
                string[] val = list[i].ToString().Split('|');
                if (val[3] == "0")//如果为0就删除权限
                {
                    AuthorityList.Add("delete Base_RoleAuthorityList where GroupID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                } else {
                    AuthorityList.Add("insert into Base_RoleAuthorityList(GroupID,ModuleID,AuthorityTag) values (" + val[0] + "," + val[1] + ",'" + val[2] + "')");
                }
            }

            try {
                SqlServerHelper.ExecuteSqlTran(AuthorityList);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 读取用户的模块权限
        /// </summary>
        public DataSet GetGroupAuthorityList(int GroupID, int ModuleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_RoleAuthorityList where GroupID=" + GroupID.ToString() + " and ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #endregion
    }
}

