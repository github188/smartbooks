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
    using System.Collections;
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

        #region 模块分类
        /// <summary>
        /// 判断模块分类是否存在
        /// </summary>
        /// <param name="ModuleTypeName">模块分类名称</param>
        /// <returns></returns>
        public bool ModuleTypeExists(string ModuleTypeName) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_ModuleType");
            strSql.Append(" where ModuleTypeName=@ModuleTypeName ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeName", SqlDbType.NVarChar,30)};
            parameters[0].Value = ModuleTypeName;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一个模块分类
        /// </summary>
        /// <param name="model">模块分类实体类</param>
        /// <returns></returns>
        public int CreateModuleType(Entity.BASE_MODULETYPE model) {
            int ret = 0;
            if (!ModuleTypeExists(model.ModuleTypeName)) {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Base_ModuleType(");
                strSql.Append("ModuleTypeName,ModuleTypeOrder,ModuleTypeSuperiorID,ModuleTypeDepth,ModuleTypeDescription)");
                strSql.Append(" values (");
                strSql.Append("@ModuleTypeName,@ModuleTypeOrder,@ModuleTypeSuperiorID,@ModuleTypeDepth,@ModuleTypeDescription)");
                SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeName", SqlDbType.NVarChar,30),
					new SqlParameter("@ModuleTypeOrder", SqlDbType.Int,4),
                    new SqlParameter("@ModuleTypeSuperiorID", SqlDbType.Int,4),
                    new SqlParameter("@ModuleTypeDepth", SqlDbType.Int,4),
					new SqlParameter("@ModuleTypeDescription", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.ModuleTypeName;
                parameters[1].Value = model.ModuleTypeOrder;
                parameters[2].Value = model.ModuleTypeSuperiorID;
                parameters[3].Value = GetModuleDepth(model.ModuleTypeSuperiorID) + 1;//更新级别深度
                parameters[4].Value = model.ModuleTypeDescription;

                if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                    ret = 1;
                }
            } else {
                ret = 2;
            }
            return ret;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">模块分类实体类</param>
        /// <returns></returns>
        public bool UpdateModuleType(Entity.BASE_MODULETYPE model) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_ModuleType set ");
            strSql.Append("ModuleTypeName=@ModuleTypeName,");
            strSql.Append("ModuleTypeOrder=@ModuleTypeOrder,");
            strSql.Append("ModuleTypeSuperiorID=@ModuleTypeSuperiorID,");
            strSql.Append("ModuleTypeDepth=@ModuleTypeDepth,");
            strSql.Append("ModuleTypeDescription=@ModuleTypeDescription");
            strSql.Append(" where ModuleTypeID=@ModuleTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4),
					new SqlParameter("@ModuleTypeName", SqlDbType.NVarChar,30),
					new SqlParameter("@ModuleTypeOrder", SqlDbType.Int,4),
                    new SqlParameter("@ModuleTypeSuperiorID", SqlDbType.Int,4),
                    new SqlParameter("@ModuleTypeDepth", SqlDbType.Int,4),
					new SqlParameter("@ModuleTypeDescription", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ModuleTypeID;
            parameters[1].Value = model.ModuleTypeName;
            parameters[2].Value = model.ModuleTypeOrder;
            parameters[3].Value = model.ModuleTypeSuperiorID;
            parameters[4].Value = GetModuleDepth(model.ModuleTypeSuperiorID) + 1;//更新级别深度
            parameters[5].Value = model.ModuleTypeDescription;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }

        }

        /// <summary>
        /// 删除模块分类
        /// </summary>
        /// <param name="ModuleTypeID">模块分类ID</param>
        /// <returns></returns>
        public int DeleteModuleType(int ModuleTypeID) {
            int ret = 0;

            string strSql1 = "Select ModuleID from Base_Module where ModuleTypeID=@ModuleTypeID";
            string strSql2 = "Select ModuleTypeID from Base_ModuleType where ModuleTypeSuperiorID=@ModuleTypeID";
            string strSql3 = "delete Base_ModuleType where ModuleTypeID=@ModuleTypeID";

            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleTypeID;

            if (!SqlServerHelper.Exists(strSql1, parameters) && !SqlServerHelper.Exists(strSql2, parameters)) {
                if (SqlServerHelper.ExecuteSql(strSql3, parameters) >= 1) {
                    ret = 1;
                } else {
                    ret = 0;
                }
            } else {
                ret = 2;
            }
            return ret;
        }

        /// <summary>
        /// 获取模块深度
        /// </summary>
        /// <param name="ModuleTypeID">模块ID</param>
        /// <returns></returns>
        public int GetModuleDepth(int ModuleTypeID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleTypeDepth from Base_ModuleType where ModuleTypeID=@ModuleTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleTypeID;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 得到一个模块分类实体
        /// </summary>
        /// <param name="ModuleTypeID">模块分类ID</param>
        /// <returns></returns>
        public Entity.BASE_MODULETYPE GetModuleTypeModel(int ModuleTypeID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Base_ModuleType ");
            strSql.Append(" where ModuleTypeID=@ModuleTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleTypeID;

            Entity.BASE_MODULETYPE model = new Entity.BASE_MODULETYPE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ModuleTypeID"].ToString() != "") {
                    model.ModuleTypeID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeID"].ToString());
                }
                model.ModuleTypeName = ds.Tables[0].Rows[0]["ModuleTypeName"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleTypeOrder"].ToString() != "") {
                    model.ModuleTypeOrder = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeOrder"].ToString());
                }
                model.ModuleTypeDescription = ds.Tables[0].Rows[0]["ModuleTypeDescription"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleTypeDepth"].ToString() != "") {
                    model.ModuleTypeDepth = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeDepth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeSuperiorID"].ToString() != "") {
                    model.ModuleTypeSuperiorID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeSuperiorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeCount"].ToString() != "") {
                    model.ModuleTypeCount = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeCount"].ToString());
                }

                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得模块分类数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetModuleTypeList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_ModuleType ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ModuleTypeSuperiorID,ModuleTypeOrder desc");

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得模块分类下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public DataSet GetChildModuleTypeList(int id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_ModuleType where ModuleTypeSuperiorID=" + id.ToString() + "order by ModuleTypeOrder asc");
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 判断模块分类下是否有模块
        /// </summary>
        /// <param name="ModuleTypeID">分类iD</param>
        /// <returns></returns>
        public bool IsModules(int ModuleTypeID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleID from Base_Module where ModuleTypeID=" + ModuleTypeID.ToString());
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) == 0) {
                return false;
            } else {
                return true;
            }

        }

        #endregion

        #region 模块操作
        /// <summary>
        /// 判断模块是否存在
        /// </summary>
        /// <param name="ModuleName">模块名称</param>
        /// <returns></returns>
        public bool ModuleExists(string ModuleTag) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Module");
            strSql.Append(" where ModuleTag=@ModuleTag");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = ModuleTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新时判断模块是否存在
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <param name="ModuleName">模块名称</param>
        /// <returns></returns>
        public bool UpdateExists(int ModuleID, string ModuleTag) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Module");
            strSql.Append(" where ModuleID<>@ModuleID and ModuleTag=@ModuleTag");
            SqlParameter[] parameters = {
                    new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = ModuleID;
            parameters[1].Value = ModuleTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一个模块
        /// </summary>
        /// <param name="model">模块实体类</param>
        /// <returns></returns>
        public int CreateModule(Entity.BASE_MODULE model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Module(");
            strSql.Append("ModuleTypeID,ModuleName,ModuleTag,ModuleURL,ModuleDisabled,ModuleOrder,ModuleDescription,IsMenu)");
            strSql.Append(" values (");
            strSql.Append("@ModuleTypeID,@ModuleName,@ModuleTag,@ModuleURL,@ModuleDisabled,@ModuleOrder,@ModuleDescription,@IsMenu)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4),
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,30),
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50),
					new SqlParameter("@ModuleURL", SqlDbType.NVarChar,500),
					new SqlParameter("@ModuleDisabled", SqlDbType.Bit,1),
					new SqlParameter("@ModuleOrder", SqlDbType.Int,4),
					new SqlParameter("@ModuleDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsMenu", SqlDbType.Bit,1)};
            parameters[0].Value = model.ModuleTypeID;
            parameters[1].Value = model.ModuleName;
            parameters[2].Value = model.ModuleTag;
            parameters[3].Value = model.ModuleURL;
            parameters[4].Value = model.ModuleDisabled;
            parameters[5].Value = model.ModuleOrder;
            parameters[6].Value = model.ModuleDescription;
            parameters[7].Value = model.IsMenu;

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
        /// <param name="model">模块实体类</param>
        /// <returns></returns>
        public int UpdateModule(Entity.BASE_MODULE model) {
            int ret = 0;

            if (!UpdateExists(model.ModuleID, model.ModuleTag)) {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Base_Module set ");
                strSql.Append("ModuleTypeID=@ModuleTypeID,");
                strSql.Append("ModuleName=@ModuleName,");
                strSql.Append("ModuleTag=@ModuleTag,");
                strSql.Append("ModuleURL=@ModuleURL,");
                strSql.Append("ModuleDisabled=@ModuleDisabled,");
                strSql.Append("ModuleOrder=@ModuleOrder,");
                strSql.Append("ModuleDescription=@ModuleDescription,");
                strSql.Append("IsMenu=@IsMenu");
                strSql.Append(" where ModuleID=@ModuleID ");
                SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4),
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,30),
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50),
					new SqlParameter("@ModuleURL", SqlDbType.NVarChar,500),
					new SqlParameter("@ModuleDisabled", SqlDbType.Bit,1),
					new SqlParameter("@ModuleOrder", SqlDbType.Int,4),
					new SqlParameter("@ModuleDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsMenu", SqlDbType.Bit,1)};
                parameters[0].Value = model.ModuleID;
                parameters[1].Value = model.ModuleTypeID;
                parameters[2].Value = model.ModuleName;
                parameters[3].Value = model.ModuleTag;
                parameters[4].Value = model.ModuleURL;
                parameters[5].Value = model.ModuleDisabled;
                parameters[6].Value = model.ModuleOrder;
                parameters[7].Value = model.ModuleDescription;
                parameters[8].Value = model.IsMenu;

                if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                    ret = 1;
                }
            } else {
                ret = 2;
            }
            return ret;
        }

        /// <summary>
        /// 删除模块，以及相应的权限
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public bool DeleteModule(int ModuleID) {

            ArrayList List = new ArrayList();
            List.Add("delete Base_Module where ModuleID=" + ModuleID.ToString());
            List.Add("delete Base_ModuleAuthorityList where ModuleID=" + ModuleID.ToString());
            try {
                SqlServerHelper.ExecuteSqlTran(List);
                return true;
            } catch {
                return false;
            }

        }

        /// <summary>
        /// 得到一个模块实体
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public Entity.BASE_MODULE GetModuleModel(int ModuleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Base_Module ");
            strSql.Append(" where ModuleID=@ModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleID;

            Entity.BASE_MODULE model = new Entity.BASE_MODULE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "") {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeID"].ToString() != "") {
                    model.ModuleTypeID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeID"].ToString());
                }
                model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                model.ModuleTag = ds.Tables[0].Rows[0]["ModuleTag"].ToString();
                model.ModuleURL = ds.Tables[0].Rows[0]["ModuleURL"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleDisabled"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["ModuleDisabled"].ToString() == "1") || (ds.Tables[0].Rows[0]["ModuleDisabled"].ToString().ToLower() == "true")) {
                        model.ModuleDisabled = true;
                    } else {
                        model.ModuleDisabled = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ModuleOrder"].ToString() != "") {
                    model.ModuleOrder = int.Parse(ds.Tables[0].Rows[0]["ModuleOrder"].ToString());
                }
                model.ModuleDescription = ds.Tables[0].Rows[0]["ModuleDescription"].ToString();

                if (ds.Tables[0].Rows[0]["IsMenu"].ToString() != "") {
                    if ((ds.Tables[0].Rows[0]["IsMenu"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsMenu"].ToString().ToLower() == "true")) {
                        model.IsMenu = true;
                    } else {
                        model.IsMenu = false;
                    }
                }

                return model;
            } else {
                return null;
            }
        }

        /// <summary>
        /// 获得模块数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetModuleList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_Module ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" order by ModuleOrder asc");

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得模块数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet GetModuleList2(string strWhere) {
            //ModuleDisabled为布尔值，在SQL Server中TRUE为1
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Base_Module where ModuleDisabled=1 and ModuleTypeID=" + strWhere + " order by ModuleOrder asc");

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取模块ID
        /// </summary>
        /// <param name="ModuleTag">模块标识</param>
        /// <returns></returns>
        public int GetModuleID(string ModuleTag) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleID from Base_Module where ModuleTag=@ModuleTag");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = ModuleTag;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 模块是否关闭
        /// </summary>
        /// <param name="ModuleTag">模块标识</param>
        /// <returns></returns>
        public bool IsModule(string ModuleTag) {
            bool ret = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleDisabled from Base_Module where ModuleTag=@ModuleTag");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = ModuleTag;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj != null) {
                if ((obj.ToString() == "1") || (obj.ToString().ToLower() == "true"))
                    ret = true;
            }
            return ret;
        }

        #endregion

        #region 授权

        /// <summary>
        /// 增加模块权限
        /// </summary>
        /// <param name="list">权限列表</param>
        /// <returns></returns>
        public bool CreateAuthorityList(ArrayList list) {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++) {
                string[] val = list[i].ToString().Split('|');
                AuthorityList.Add("insert into Base_ModuleAuthorityList(ModuleID,AuthorityTag) values (" + val[0] + ",'" + val[1] + "')");
            }

            try {
                SqlServerHelper.ExecuteSqlTran(AuthorityList);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 更新模块权限
        /// </summary>
        public bool UpdateAuthorityList(ArrayList list) {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++) {
                string[] val = list[i].ToString().Split('|');
                if (val[2] == "0")//如果为0就删除权限
                {
                    //删除模块权限
                    AuthorityList.Add("delete Base_ModuleAuthorityList where ModuleID=" + val[0] + " and AuthorityTag='" + val[1] + "'");
                    //删除角色所对应该模块标识的权限
                    AuthorityList.Add("delete Base_RoleAuthorityList where ModuleID=" + val[0] + " and AuthorityTag='" + val[1] + "'");
                } else {
                    AuthorityList.Add("insert into Base_ModuleAuthorityList(ModuleID,AuthorityTag) values (" + val[0] + ",'" + val[1] + "')");
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
        /// 删除指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int ModuleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_ModuleAuthorityList ");
            strSql.Append(" where ModuleID=@ModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleID;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 获得指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(int ModuleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Base_ModuleAuthorityList where ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityNameList(int ModuleID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Base_ModuleAuthorityList.*, Base_AuthorityDir.AuthorityName FROM Base_ModuleAuthorityList INNER JOIN Base_AuthorityDir ON Base_ModuleAuthorityList.AuthorityTag = Base_AuthorityDir.AuthorityTag where ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }

        #endregion
    }
}

