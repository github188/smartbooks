// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USER.cs
// 功能描述:用户信息表 -- 接口实现
//
// 创建标识：王 亚 2012-03-12
namespace SmartPoms.SQLServerDAL {
    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// 用户信息表 -- 接口实现
    /// </summary>
    public partial class BASE_USER : IBASE_USER {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int USERID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_USER");
            strSql.Append(" where ");
            strSql.Append(" USERID = @USERID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@USERID", SqlDbType.Int,4)
			};
            parameters[0].Value = USERID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_USER entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_USER(");
            strSql.Append("USERNAME,USERPWD,ROLEID");
            strSql.Append(") values (");
            strSql.Append("@USERNAME,@USERPWD,@ROLEID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@USERNAME", SqlDbType.VarChar,18) ,            
                        new SqlParameter("@USERPWD", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@ROLEID", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = entity.USERNAME;
            parameters[1].Value = entity.USERPWD;
            parameters[2].Value = entity.ROLEID;

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
            strSql.Append("update BASE_USER set ");

            strSql.Append(" USERNAME = @USERNAME , ");
            strSql.Append(" USERPWD = @USERPWD , ");
            strSql.Append(" ROLEID = @ROLEID  ");
            strSql.Append(" where USERID=@USERID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@USERID", SqlDbType.Int,4) ,            
                        new SqlParameter("@USERNAME", SqlDbType.VarChar,18) ,            
                        new SqlParameter("@USERPWD", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@ROLEID", SqlDbType.VarChar,50)             
              
            };

            parameters[3].Value = entity.USERID;
            parameters[4].Value = entity.USERNAME;
            parameters[5].Value = entity.USERPWD;
            parameters[6].Value = entity.ROLEID;
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
        public bool Delete(int USERID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_USER ");
            strSql.Append(" where USERID=@USERID");
            SqlParameter[] parameters = {
					new SqlParameter("@USERID", SqlDbType.Int,4)
			};
            parameters[0].Value = USERID;


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
        public bool DeleteList(string USERIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_USER ");
            strSql.Append(" where ID in (" + USERIDlist + ")  ");
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
        public Entity.BASE_USER GetEntity(int USERID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USERID, USERNAME, USERPWD, ROLEID  ");
            strSql.Append("  from BASE_USER ");
            strSql.Append(" where USERID=@USERID");
            SqlParameter[] parameters = {
					new SqlParameter("@USERID", SqlDbType.Int,4)
			};
            parameters[0].Value = USERID;


            Entity.BASE_USER entity = new Entity.BASE_USER();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["USERID"].ToString() != "") {
                    entity.USERID = int.Parse(ds.Tables[0].Rows[0]["USERID"].ToString());
                }
                entity.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                entity.USERPWD = ds.Tables[0].Rows[0]["USERPWD"].ToString();
                entity.ROLEID = ds.Tables[0].Rows[0]["ROLEID"].ToString();

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
            strSql.Append(" FROM BASE_USER ");
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
            strSql.Append(" FROM BASE_USER ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }
    }
}