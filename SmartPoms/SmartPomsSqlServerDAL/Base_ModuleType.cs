// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MODULETYPE.cs
// 功能描述:Base_ModuleType -- 接口实现
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
    /// Base_ModuleType -- 接口实现
    /// </summary>
    public partial class BASE_MODULETYPE : IBASE_MODULETYPE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int ModuleTypeID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_ModuleType");
            strSql.Append(" where ");
            strSql.Append(" ModuleTypeID = @ModuleTypeID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModuleTypeID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_MODULETYPE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_ModuleType(");
            strSql.Append("ModuleTypeName,ModuleTypeOrder,ModuleTypeDescription,ModuleTypeDepth,ModuleTypeSuperiorID,ModuleTypeCount");
            strSql.Append(") values (");
            strSql.Append("@ModuleTypeName,@ModuleTypeOrder,@ModuleTypeDescription,@ModuleTypeDepth,@ModuleTypeSuperiorID,@ModuleTypeCount");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ModuleTypeName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@ModuleTypeOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleTypeDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ModuleTypeDepth", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleTypeSuperiorID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleTypeCount", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.ModuleTypeName;
            parameters[1].Value = entity.ModuleTypeOrder;
            parameters[2].Value = entity.ModuleTypeDescription;
            parameters[3].Value = entity.ModuleTypeDepth;
            parameters[4].Value = entity.ModuleTypeSuperiorID;
            parameters[5].Value = entity.ModuleTypeCount;

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
        public bool Update(Entity.BASE_MODULETYPE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_ModuleType set ");

            strSql.Append(" ModuleTypeName = @ModuleTypeName , ");
            strSql.Append(" ModuleTypeOrder = @ModuleTypeOrder , ");
            strSql.Append(" ModuleTypeDescription = @ModuleTypeDescription , ");
            strSql.Append(" ModuleTypeDepth = @ModuleTypeDepth , ");
            strSql.Append(" ModuleTypeSuperiorID = @ModuleTypeSuperiorID , ");
            strSql.Append(" ModuleTypeCount = @ModuleTypeCount  ");
            strSql.Append(" where ModuleTypeID=@ModuleTypeID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ModuleTypeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleTypeName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@ModuleTypeOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleTypeDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ModuleTypeDepth", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleTypeSuperiorID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleTypeCount", SqlDbType.Int,4)             
              
            };

            parameters[6].Value = entity.ModuleTypeID;
            parameters[7].Value = entity.ModuleTypeName;
            parameters[8].Value = entity.ModuleTypeOrder;
            parameters[9].Value = entity.ModuleTypeDescription;
            parameters[10].Value = entity.ModuleTypeDepth;
            parameters[11].Value = entity.ModuleTypeSuperiorID;
            parameters[12].Value = entity.ModuleTypeCount;
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
        public bool Delete(int ModuleTypeID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_ModuleType ");
            strSql.Append(" where ModuleTypeID=@ModuleTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModuleTypeID;


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
        public bool DeleteList(string ModuleTypeIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_ModuleType ");
            strSql.Append(" where ID in (" + ModuleTypeIDlist + ")  ");
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
        public Entity.BASE_MODULETYPE GetEntity(int ModuleTypeID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleTypeID, ModuleTypeName, ModuleTypeOrder, ModuleTypeDescription, ModuleTypeDepth, ModuleTypeSuperiorID, ModuleTypeCount  ");
            strSql.Append("  from Base_ModuleType ");
            strSql.Append(" where ModuleTypeID=@ModuleTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModuleTypeID;


            Entity.BASE_MODULETYPE entity = new Entity.BASE_MODULETYPE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ModuleTypeID"].ToString() != "") {
                    entity.ModuleTypeID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeID"].ToString());
                }
                entity.ModuleTypeName = ds.Tables[0].Rows[0]["ModuleTypeName"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleTypeOrder"].ToString() != "") {
                    entity.ModuleTypeOrder = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeOrder"].ToString());
                }
                entity.ModuleTypeDescription = ds.Tables[0].Rows[0]["ModuleTypeDescription"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleTypeDepth"].ToString() != "") {
                    entity.ModuleTypeDepth = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeDepth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeSuperiorID"].ToString() != "") {
                    entity.ModuleTypeSuperiorID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeSuperiorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeCount"].ToString() != "") {
                    entity.ModuleTypeCount = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeCount"].ToString());
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
            strSql.Append(" FROM Base_ModuleType ");
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
            strSql.Append(" FROM Base_ModuleType ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

