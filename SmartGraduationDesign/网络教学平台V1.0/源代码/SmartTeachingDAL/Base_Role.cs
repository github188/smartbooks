using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Smart.DBUtility;
namespace SmartTeaching.DAL
{
    //Base_Role
    public partial class Base_Role
    {

        public bool Exists(int RoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Role");
            strSql.Append(" where ");
            strSql.Append(" RoleId = @RoleId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleId;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Role(");
            strSql.Append("RoleName,Description");
            strSql.Append(") values (");
            strSql.Append("@RoleName,@Description");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@RoleName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Description", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.Description;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Role set ");

            strSql.Append(" RoleName = @RoleName , ");
            strSql.Append(" Description = @Description  ");
            strSql.Append(" where RoleId=@RoleId ");

            SqlParameter[] parameters = {
			            new SqlParameter("@RoleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Description", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.RoleId;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.Description;
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
        public bool Delete(int RoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Role ");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleId;


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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string RoleIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Role ");
            strSql.Append(" where ID in (" + RoleIdlist + ")  ");
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString());
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
        public SmartTeaching.Entity.Base_Role GetModel(int RoleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleId, RoleName, Description  ");
            strSql.Append("  from Base_Role ");
            strSql.Append(" where RoleId=@RoleId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleId;


            SmartTeaching.Entity.Base_Role model = new SmartTeaching.Entity.Base_Role();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(ds.Tables[0].Rows[0]["RoleId"].ToString());
                }
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();

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
            strSql.Append(" FROM Base_Role ");
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
            strSql.Append(" FROM Base_Role ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

