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
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "") {
                    entity.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
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


    }
}

