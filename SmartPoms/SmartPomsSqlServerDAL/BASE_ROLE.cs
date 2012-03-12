// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROLE.cs
// 功能描述:角色信息表 -- 接口实现
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
    /// 角色信息表 -- 接口实现
    /// </summary>
    public partial class BASE_ROLE : IBASE_ROLE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int ROLEID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ROLE");
            strSql.Append(" where ");
            strSql.Append(" ROLEID = @ROLEID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLEID", SqlDbType.Int,4)
			};
            parameters[0].Value = ROLEID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_ROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ROLE(");
            strSql.Append("ROLENAME,ROLEIDPARENT,SORT,SUMMARY,ENABLE,LINK");
            strSql.Append(") values (");
            strSql.Append("@ROLENAME,@ROLEIDPARENT,@SORT,@SUMMARY,@ENABLE,@LINK");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ROLENAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ROLEIDPARENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ENABLE", SqlDbType.Int,4),
                        new SqlParameter("@LINK", SqlDbType.VarChar,50)
              
            };

            parameters[0].Value = entity.ROLENAME;
            parameters[1].Value = entity.ROLEIDPARENT;
            parameters[2].Value = entity.SORT;
            parameters[3].Value = entity.SUMMARY;
            parameters[4].Value = entity.ENABLE;
            parameters[5].Value = entity.LINK;

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
            strSql.Append("update BASE_ROLE set ");

            strSql.Append(" ROLENAME = @ROLENAME , ");
            strSql.Append(" ROLEIDPARENT = @ROLEIDPARENT , ");
            strSql.Append(" SORT = @SORT , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" ENABLE = @ENABLE  ");
            strSql.Append(" LINK = @LINK  ");
            strSql.Append(" where ROLEID=@ROLEID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ROLEID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ROLENAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ROLEIDPARENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ENABLE", SqlDbType.Int,4),
                         new SqlParameter("@LINK", SqlDbType.VarChar,50)
            };

            parameters[0].Value = entity.ROLEID;
            parameters[1].Value = entity.ROLENAME;
            parameters[2].Value = entity.ROLEIDPARENT;
            parameters[3].Value = entity.SORT;
            parameters[4].Value = entity.SUMMARY;
            parameters[5].Value = entity.ENABLE;
            parameters[6].Value = entity.LINK;
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
        public bool Delete(int ROLEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ROLE ");
            strSql.Append(" where ROLEID=@ROLEID");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLEID", SqlDbType.Int,4)
			};
            parameters[0].Value = ROLEID;


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
        public bool DeleteList(string ROLEIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ROLE ");
            strSql.Append(" where ID in (" + ROLEIDlist + ")  ");
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
        public Entity.BASE_ROLE GetEntity(int ROLEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROLEID, ROLENAME, ROLEIDPARENT, SORT, SUMMARY, ENABLE,LINK  ");
            strSql.Append("  from BASE_ROLE ");
            strSql.Append(" where ROLEID=@ROLEID");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLEID", SqlDbType.Int,4)
			};
            parameters[0].Value = ROLEID;


            Entity.BASE_ROLE entity = new Entity.BASE_ROLE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ROLEID"].ToString() != "") {
                    entity.ROLEID = int.Parse(ds.Tables[0].Rows[0]["ROLEID"].ToString());
                }
                entity.ROLENAME = ds.Tables[0].Rows[0]["ROLENAME"].ToString();
                if (ds.Tables[0].Rows[0]["ROLEIDPARENT"].ToString() != "") {
                    entity.ROLEIDPARENT = int.Parse(ds.Tables[0].Rows[0]["ROLEIDPARENT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SORT"].ToString() != "") {
                    entity.SORT = int.Parse(ds.Tables[0].Rows[0]["SORT"].ToString());
                }
                entity.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                if (ds.Tables[0].Rows[0]["ENABLE"].ToString() != "") {
                    entity.ENABLE = int.Parse(ds.Tables[0].Rows[0]["ENABLE"].ToString());
                }
                entity.LINK = ds.Tables[0].Rows[0]["LINK"].ToString();

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
            strSql.Append("select ROLEID,ROLENAME,ROLEIDPARENT,SORT,SUMMARY,ENABLE,LINK ");
            strSql.Append(" FROM BASE_ROLE ");
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
            strSql.Append(" FROM BASE_ROLE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }
    }
}