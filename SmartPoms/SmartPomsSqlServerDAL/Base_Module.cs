// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MODULE.cs
// 功能描述:Base_Module -- 接口实现
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
    /// Base_Module -- 接口实现
    /// </summary>
    public partial class BASE_MODULE : IBASE_MODULE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int ModuleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Module");
            strSql.Append(" where ");
            strSql.Append(" ModuleID = @ModuleID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModuleID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_MODULE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Module(");
            strSql.Append("ModuleTypeID,ModuleName,ModuleTag,ModuleURL,ModuleDisabled,ModuleOrder,ModuleDescription,IsMenu");
            strSql.Append(") values (");
            strSql.Append("@ModuleTypeID,@ModuleName,@ModuleTag,@ModuleURL,@ModuleDisabled,@ModuleOrder,@ModuleDescription,@IsMenu");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ModuleTypeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ModuleURL", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ModuleDisabled", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ModuleOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@IsMenu", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = entity.ModuleTypeID;
            parameters[1].Value = entity.ModuleName;
            parameters[2].Value = entity.ModuleTag;
            parameters[3].Value = entity.ModuleURL;
            parameters[4].Value = entity.ModuleDisabled;
            parameters[5].Value = entity.ModuleOrder;
            parameters[6].Value = entity.ModuleDescription;
            parameters[7].Value = entity.IsMenu;

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
        public bool Update(Entity.BASE_MODULE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Module set ");

            strSql.Append(" ModuleTypeID = @ModuleTypeID , ");
            strSql.Append(" ModuleName = @ModuleName , ");
            strSql.Append(" ModuleTag = @ModuleTag , ");
            strSql.Append(" ModuleURL = @ModuleURL , ");
            strSql.Append(" ModuleDisabled = @ModuleDisabled , ");
            strSql.Append(" ModuleOrder = @ModuleOrder , ");
            strSql.Append(" ModuleDescription = @ModuleDescription , ");
            strSql.Append(" IsMenu = @IsMenu  ");
            strSql.Append(" where ModuleID=@ModuleID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ModuleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleTypeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleName", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ModuleURL", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ModuleDisabled", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ModuleOrder", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleDescription", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@IsMenu", SqlDbType.Bit,1)             
              
            };

            parameters[8].Value = entity.ModuleID;
            parameters[9].Value = entity.ModuleTypeID;
            parameters[10].Value = entity.ModuleName;
            parameters[11].Value = entity.ModuleTag;
            parameters[12].Value = entity.ModuleURL;
            parameters[13].Value = entity.ModuleDisabled;
            parameters[14].Value = entity.ModuleOrder;
            parameters[15].Value = entity.ModuleDescription;
            parameters[16].Value = entity.IsMenu;
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
        public bool Delete(int ModuleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Module ");
            strSql.Append(" where ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModuleID;


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
        public bool DeleteList(string ModuleIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Module ");
            strSql.Append(" where ID in (" + ModuleIDlist + ")  ");
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
        public Entity.BASE_MODULE GetEntity(int ModuleID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleID, ModuleTypeID, ModuleName, ModuleTag, ModuleURL, ModuleDisabled, ModuleOrder, ModuleDescription, IsMenu  ");
            strSql.Append("  from Base_Module ");
            strSql.Append(" where ModuleID=@ModuleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ModuleID;


            Entity.BASE_MODULE entity = new Entity.BASE_MODULE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "") {
                    entity.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeID"].ToString() != "") {
                    entity.ModuleTypeID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeID"].ToString());
                }
                entity.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                entity.ModuleTag = ds.Tables[0].Rows[0]["ModuleTag"].ToString();
                entity.ModuleURL = ds.Tables[0].Rows[0]["ModuleURL"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleDisabled"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["ModuleDisabled"].ToString() == "1") || (ds.Tables[0].Rows[0]["ModuleDisabled"].ToString().ToLower() == "true")) {
                        entity.ModuleDisabled = true;
                    } else {
                        entity.ModuleDisabled = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ModuleOrder"].ToString() != "") {
                    entity.ModuleOrder = int.Parse(ds.Tables[0].Rows[0]["ModuleOrder"].ToString());
                }
                entity.ModuleDescription = ds.Tables[0].Rows[0]["ModuleDescription"].ToString();
                if (ds.Tables[0].Rows[0]["IsMenu"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsMenu"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsMenu"].ToString().ToLower() == "true")) {
                        entity.IsMenu = true;
                    } else {
                        entity.IsMenu = false;
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
            strSql.Append(" FROM Base_Module ");
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
            strSql.Append(" FROM Base_Module ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

