// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MODULEAUTHORITYLIST.cs
// 功能描述:Base_ModuleAuthorityList -- 接口实现
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
    /// Base_ModuleAuthorityList -- 接口实现
    /// </summary>
    public partial class BASE_MODULEAUTHORITYLIST : IBASE_MODULEAUTHORITYLIST {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_ModuleAuthorityList");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_MODULEAUTHORITYLIST entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_ModuleAuthorityList(");
            strSql.Append("ModuleID,AuthorityTag");
            strSql.Append(") values (");
            strSql.Append("@ModuleID,@AuthorityTag");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ModuleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = entity.ModuleID;
            parameters[1].Value = entity.AuthorityTag;

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
        public bool Update(Entity.BASE_MODULEAUTHORITYLIST entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_ModuleAuthorityList set ");

            strSql.Append(" ModuleID = @ModuleID , ");
            strSql.Append(" AuthorityTag = @AuthorityTag  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50)             
              
            };

            parameters[2].Value = entity.ID;
            parameters[3].Value = entity.ModuleID;
            parameters[4].Value = entity.AuthorityTag;
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
        public bool Delete(int ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_ModuleAuthorityList ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


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
        public bool DeleteList(string IDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_ModuleAuthorityList ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Entity.BASE_MODULEAUTHORITYLIST GetEntity(int ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ModuleID, AuthorityTag  ");
            strSql.Append("  from Base_ModuleAuthorityList ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            Entity.BASE_MODULEAUTHORITYLIST entity = new Entity.BASE_MODULEAUTHORITYLIST();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "") {
                    entity.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "") {
                    entity.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                entity.AuthorityTag = ds.Tables[0].Rows[0]["AuthorityTag"].ToString();

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
            strSql.Append(" FROM Base_ModuleAuthorityList ");
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
            strSql.Append(" FROM Base_ModuleAuthorityList ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

