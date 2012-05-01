using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Smart.DBUtility;
namespace SmartTeaching.DAL
{
    //Base_UserRole
    public partial class Base_UserRole
    {

        public bool Exists(int UserRoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_UserRole");
            strSql.Append(" where ");
            strSql.Append(" UserRoleId = @UserRoleId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserRoleId", SqlDbType.Int,4)			};
            parameters[0].Value = UserRoleId;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(SmartTeaching.Entity.Base_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_UserRole(");
            strSql.Append("UserId,RoleId,NewsTypeId");
            strSql.Append(") values (");
            strSql.Append("@UserId,@RoleId,@NewsTypeId");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@NewsTypeId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.RoleId;
            parameters[2].Value = model.NewsTypeId;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_UserRole set ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" RoleId = @RoleId , ");
            strSql.Append(" NewsTypeId = @NewsTypeId  ");
            strSql.Append(" where UserRoleId=@UserRoleId  ");

            SqlParameter[] parameters = {        
                        new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@NewsTypeId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.RoleId;
            parameters[2].Value = model.NewsTypeId;
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserRoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_UserRole ");
            strSql.Append(" where UserRoleId=@UserRoleId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserRoleId", SqlDbType.Int,4)			};
            parameters[0].Value = UserRoleId;


            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SmartTeaching.Entity.Base_UserRole GetModel(int UserRoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserRoleId, UserId, RoleId, NewsTypeId  ");
            strSql.Append("  from Base_UserRole ");
            strSql.Append(" where UserRoleId=@UserRoleId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserRoleId", SqlDbType.Int,4)			};
            parameters[0].Value = UserRoleId;


            SmartTeaching.Entity.Base_UserRole model = new SmartTeaching.Entity.Base_UserRole();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserRoleId"].ToString() != "")
                {
                    model.UserRoleId = int.Parse(ds.Tables[0].Rows[0]["UserRoleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(ds.Tables[0].Rows[0]["RoleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewsTypeId"].ToString() != "")
                {
                    model.NewsTypeId = int.Parse(ds.Tables[0].Rows[0]["NewsTypeId"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Base_UserRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Base_UserRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

