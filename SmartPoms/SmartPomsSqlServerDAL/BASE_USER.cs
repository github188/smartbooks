// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USER.cs
// 功能描述:用户帐户信息表 -- 接口实现
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
    /// 用户帐户信息表 -- 接口实现
    /// </summary>
    public partial class BASE_USER : IBASE_USER {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int UserID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_User");
            strSql.Append(" where ");
            strSql.Append(" UserID = @UserID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_USER entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_User(");
            strSql.Append("UserName,Password,Email,Question,Answer,RoleID,UserGroup,CreateTime,LastLoginTime,Status,IsOnline,IsLimit");
            strSql.Append(") values (");
            strSql.Append("@UserName,@Password,@Email,@Question,@Answer,@RoleID,@UserGroup,@CreateTime,@LastLoginTime,@Status,@IsOnline,@IsLimit");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserName", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Password", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Email", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Question", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Answer", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserGroup", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastLoginTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsOnline", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsLimit", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = entity.UserName;
            parameters[1].Value = entity.Password;
            parameters[2].Value = entity.Email;
            parameters[3].Value = entity.Question;
            parameters[4].Value = entity.Answer;
            parameters[5].Value = entity.RoleID;
            parameters[6].Value = entity.UserGroup;
            parameters[7].Value = entity.CreateTime;
            parameters[8].Value = entity.LastLoginTime;
            parameters[9].Value = entity.Status;
            parameters[10].Value = entity.IsOnline;
            parameters[11].Value = entity.IsLimit;

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
        public bool Update(Entity.BASE_USER entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_User set ");

            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" Password = @Password , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" Question = @Question , ");
            strSql.Append(" Answer = @Answer , ");
            strSql.Append(" RoleID = @RoleID , ");
            strSql.Append(" UserGroup = @UserGroup , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" LastLoginTime = @LastLoginTime , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" IsOnline = @IsOnline , ");
            strSql.Append(" IsLimit = @IsLimit  ");
            strSql.Append(" where UserID=@UserID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserName", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Password", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Email", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Question", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@Answer", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@RoleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserGroup", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastLoginTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsOnline", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsLimit", SqlDbType.Bit,1)             
              
            };

            parameters[12].Value = entity.UserID;
            parameters[13].Value = entity.UserName;
            parameters[14].Value = entity.Password;
            parameters[15].Value = entity.Email;
            parameters[16].Value = entity.Question;
            parameters[17].Value = entity.Answer;
            parameters[18].Value = entity.RoleID;
            parameters[19].Value = entity.UserGroup;
            parameters[20].Value = entity.CreateTime;
            parameters[21].Value = entity.LastLoginTime;
            parameters[22].Value = entity.Status;
            parameters[23].Value = entity.IsOnline;
            parameters[24].Value = entity.IsLimit;
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
        public bool Delete(int UserID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_User ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;


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
        public bool DeleteList(string UserIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_User ");
            strSql.Append(" where ID in (" + UserIDlist + ")  ");
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
        public Entity.BASE_USER GetEntity(int UserID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID, UserName, Password, Email, Question, Answer, RoleID, UserGroup, CreateTime, LastLoginTime, Status, IsOnline, IsLimit  ");
            strSql.Append("  from Base_User ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;


            Entity.BASE_USER entity = new Entity.BASE_USER();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    entity.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                entity.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                entity.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                entity.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                entity.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                entity.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();
                if (ds.Tables[0].Rows[0]["UserGroup"].ToString() != "") {
                    entity.UserGroup = int.Parse(ds.Tables[0].Rows[0]["UserGroup"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "") {
                    entity.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "") {
                    entity.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "") {
                    entity.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOnline"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsOnline"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsOnline"].ToString().ToLower() == "true")) {
                        entity.IsOnline = true;
                    } else {
                        entity.IsOnline = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsLimit"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsLimit"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLimit"].ToString().ToLower() == "true")) {
                        entity.IsLimit = true;
                    } else {
                        entity.IsLimit = false;
                    }
                }

                //读取角色
                entity.RoleID = GetUserRoleArray(entity.UserID);

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
            strSql.Append(" FROM Base_User ");
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
            strSql.Append(" FROM Base_User ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


        #region 用户操作
        /// <summary>
        /// 用户是否存在该
        /// </summary>
        public bool UserExists(string UserName) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_User");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,128)};
            parameters[0].Value = UserName;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 创建一个新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateUser(Entity.BASE_USER model) {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_User(");
            strSql.Append("UserName,Password,Email,UserGroup,CreateTime,IsLimit)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@Email,@UserGroup,@CreateTime,@IsLimit)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,128),
					new SqlParameter("@Password", SqlDbType.NVarChar,128),
                    new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@UserGroup", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsLimit", SqlDbType.Bit,1)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.UserGroup;
            parameters[4].Value = DateTime.Now;
            parameters[5].Value = model.IsLimit;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj != null) {
                ret = int.Parse(obj.ToString());
            }

            return ret;
        }

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public int UpdateUser(Entity.BASE_USER model) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_User set UserName=@UserName,UserGroup=@UserGroup,Email=@Email,Status=@Status where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,128),
                    new SqlParameter("@UserGroup", SqlDbType.Int,4),
                    new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserGroup;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Status;

            return SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 用户登录检测
        /// </summary>
        public bool CheckLogin(string UserName, string pwd) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_User");
            strSql.Append(" where UserName=@UserName and Password=@Password");
            SqlParameter[] parameters = {
                     new SqlParameter("@UserName", SqlDbType.NVarChar,128),
					 new SqlParameter("@Password", SqlDbType.NVarChar,128)};
            parameters[0].Value = UserName;
            parameters[1].Value = pwd;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新用户登录时间
        /// </summary>
        /// <param name="id"></param>
        public void UpdateLoginTime(int id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_User set LastLoginTime=@LastLoginTime where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime)};
            parameters[0].Value = id;
            parameters[1].Value = DateTime.Now;

            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 判断用户原密码是否正确
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">原密码</param>
        /// <returns></returns>
        public bool VerifyPassword(int id, string pwd) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_User");
            strSql.Append(" where UserID=@UserID and Password=@Password");
            SqlParameter[] parameters = {
                     new SqlParameter("@UserID", SqlDbType.Int,4),
					 new SqlParameter("@Password", SqlDbType.NVarChar,128)};
            parameters[0].Value = id;
            parameters[1].Value = pwd;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        public bool ChangePassword(int id, string pwd) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_User set ");
            strSql.Append("Password=@Password");
            strSql.Append(" where UserID=@UserID");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Password", SqlDbType.NVarChar,128)};
            parameters[0].Value = id;
            parameters[1].Value = pwd;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }

        }

        /// <summary>
        /// 更新安全信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="question">问题</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        public bool ChangeSecureInfo(int id, string question, string answer) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_User set ");
            strSql.Append("Question=@Question,Answer=@Answer");
            strSql.Append(" where UserID=@UserID");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Question", SqlDbType.NVarChar,100),
					new SqlParameter("@Answer", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            parameters[1].Value = question;
            parameters[2].Value = answer;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserID">用户ID</param>
        public bool DeleteUser(int UserID) {

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            ArrayList SQLList = new ArrayList();

            try {
                SQLList.Add("delete Base_RoleAuthorityList where UserID=" + parameters[0].Value);
                SQLList.Add("delete Base_UserRole where UserID=" + parameters[0].Value);
                SQLList.Add("delete Base_User where UserID=" + parameters[0].Value);
                SqlServerHelper.ExecuteSqlTran(SQLList);
                return true;//删除成功
            } catch {
                return false;//删除失败
            }

        }

        /// <summary>
        /// 根据ID得到用户对象实体
        /// </summary>
        public Entity.BASE_USER GetUserModel(int UserID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Base_User ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            Entity.BASE_USER model = new Entity.BASE_USER();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                model.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();

                if (ds.Tables[0].Rows[0]["UserGroup"].ToString() != "") {
                    model.UserGroup = int.Parse(ds.Tables[0].Rows[0]["UserGroup"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "") {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "") {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "") {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOnline"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsOnline"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsOnline"].ToString().ToLower() == "true")) {
                        model.IsOnline = true;
                    } else {
                        model.IsOnline = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsLimit"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsLimit"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLimit"].ToString().ToLower() == "true")) {
                        model.IsLimit = true;
                    } else {
                        model.IsLimit = false;
                    }
                }

                //读取角色
                model.RoleID = GetUserRoleArray(model.UserID);

                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名得到用户对象实体
        /// </summary>
        public Entity.BASE_USER GetUserModel(string UserName) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Base_User ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,128)};
            parameters[0].Value = UserName;

            Entity.BASE_USER model = new Entity.BASE_USER();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                model.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();

                if (ds.Tables[0].Rows[0]["UserGroup"].ToString() != "") {
                    model.UserGroup = int.Parse(ds.Tables[0].Rows[0]["UserGroup"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "") {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "") {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "") {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOnline"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsOnline"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsOnline"].ToString().ToLower() == "true")) {
                        model.IsOnline = true;
                    } else {
                        model.IsOnline = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsLimit"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsLimit"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLimit"].ToString().ToLower() == "true")) {
                        model.IsLimit = true;
                    } else {
                        model.IsLimit = false;
                    }
                }

                //读取角色
                model.RoleID = GetUserRoleArray(model.UserID);

                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserList(string strWhere, string strOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Base_User.*, Base_UserGroup.UG_Name ");
            strSql.Append("FROM Base_User INNER JOIN ");
            strSql.Append("Base_UserGroup ON Base_User.UserGroup = Base_UserGroup.UG_ID ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }

            if (strOrder.Trim() != "") {
                strSql.Append(" " + strOrder);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 读取角色名称
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public object GetRoleName(int roleid) {
            return SqlServerHelper.GetSingle("select RoleName from Base_Role where RoleID=" + roleid);
        }


        #endregion

        #region 角色操作

        /// <summary>
        /// 添加一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool addUserRole(int UserID, int RoleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_UserRole(");
            strSql.Append("UserID,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@RoleID)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleID;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 批量添加用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool addUserRole(ArrayList list) {
            ArrayList SQLList = new ArrayList();

            for (int i = 0; i < list.Count; i++) {
                string[] val = list[i].ToString().Split(',');
                SQLList.Add("insert into Base_UserRole(UserID,RoleID) values (" + val[0] + "," + val[1] + ")");
            }

            try {
                SqlServerHelper.ExecuteSqlTran(SQLList);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 删除一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool DeleteUserRole(int UserID, int RoleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_UserRole where UserID=@UserID and RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            parameters[0].Value = RoleID;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 批量删除用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteUserRole(ArrayList list) {
            ArrayList SQLList = new ArrayList();

            for (int i = 0; i < list.Count; i++) {
                string[] val = list[i].ToString().Split(',');
                SQLList.Add("delete Base_UserRole where UserID=" + val[0] + " and RoleID=" + val[1]);
            }

            try {
                SqlServerHelper.ExecuteSqlTran(SQLList);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetUserRole(int UserID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Base_UserRole.*, Base_Role.RoleName ");
            strSql.Append("FROM Base_UserRole INNER JOIN ");
            strSql.Append("Base_Role ON Base_UserRole.RoleID = Base_Role.RoleID ");
            return SqlServerHelper.Query(strSql.ToString() + "where UserID=" + UserID.ToString());
        }

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ArrayList GetUserRoleArray(int UserID) {
            ArrayList ret = new ArrayList();
            DataSet rds = GetUserRole(UserID);
            if (rds.Tables[0].Rows.Count != 0) {
                for (int i = 0; i < rds.Tables[0].Rows.Count; i++) {
                    ret.Add(rds.Tables[0].Rows[i]["RoleID"].ToString() + "," + rds.Tables[0].Rows[i]["RoleName"].ToString());
                }
            }
            return ret;
        }

        #endregion


    }
}

