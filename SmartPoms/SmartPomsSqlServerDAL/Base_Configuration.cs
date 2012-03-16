// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CONFIGURATION.cs
// 功能描述:Base_Configuration -- 接口实现
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
    /// Base_Configuration -- 接口实现
    /// </summary>
    public partial class BASE_CONFIGURATION : IBASE_CONFIGURATION {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int ItemID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Configuration");
            strSql.Append(" where ");
            strSql.Append(" ItemID = @ItemID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4)
			};
            parameters[0].Value = ItemID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_CONFIGURATION entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Configuration(");
            strSql.Append("ItemName,ItemValue,ItemDescription");
            strSql.Append(") values (");
            strSql.Append("@ItemName,@ItemValue,@ItemDescription");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ItemName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ItemValue", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ItemDescription", SqlDbType.NVarChar,500)             
              
            };

            parameters[0].Value = entity.ItemName;
            parameters[1].Value = entity.ItemValue;
            parameters[2].Value = entity.ItemDescription;

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
        public bool Update(Entity.BASE_CONFIGURATION entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Configuration set ");

            strSql.Append(" ItemName = @ItemName , ");
            strSql.Append(" ItemValue = @ItemValue , ");
            strSql.Append(" ItemDescription = @ItemDescription  ");
            strSql.Append(" where ItemID=@ItemID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ItemID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ItemName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ItemValue", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ItemDescription", SqlDbType.NVarChar,500)             
              
            };

            parameters[3].Value = entity.ItemID;
            parameters[4].Value = entity.ItemName;
            parameters[5].Value = entity.ItemValue;
            parameters[6].Value = entity.ItemDescription;
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
        public bool Delete(int ItemID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Configuration ");
            strSql.Append(" where ItemID=@ItemID");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4)
			};
            parameters[0].Value = ItemID;


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
        public bool DeleteList(string ItemIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Configuration ");
            strSql.Append(" where ID in (" + ItemIDlist + ")  ");
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
        public Entity.BASE_CONFIGURATION GetEntity(int ItemID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ItemID, ItemName, ItemValue, ItemDescription  ");
            strSql.Append("  from Base_Configuration ");
            strSql.Append(" where ItemID=@ItemID");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4)
			};
            parameters[0].Value = ItemID;


            Entity.BASE_CONFIGURATION entity = new Entity.BASE_CONFIGURATION();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ItemID"].ToString() != "") {
                    entity.ItemID = int.Parse(ds.Tables[0].Rows[0]["ItemID"].ToString());
                }
                entity.ItemName = ds.Tables[0].Rows[0]["ItemName"].ToString();
                entity.ItemValue = ds.Tables[0].Rows[0]["ItemValue"].ToString();
                entity.ItemDescription = ds.Tables[0].Rows[0]["ItemDescription"].ToString();

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
            strSql.Append(" FROM Base_Configuration ");
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
            strSql.Append(" FROM Base_Configuration ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 判断配置项是否存在
        /// </summary>
        /// <param name="ItemName">配置项名称</param>
        /// <returns></returns>
        public bool Exists(string ItemName) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) Base_Configuration");
            strSql.Append(" where ItemName=@ItemName ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50)};
            parameters[0].Value = ItemName;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 创建新配置
        /// </summary>
        /// <param name="ItemName">配置名称</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool CreateItem(string ItemName, string ItemValue) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Configuration(");
            strSql.Append("ItemName,ItemValue)");
            strSql.Append(" values (");
            strSql.Append("@ItemName,@ItemValue)");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ModuleTypeDescription", SqlDbType.NVarChar)};
            parameters[0].Value = ItemName;
            parameters[1].Value = ItemValue;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemName">配置名称</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool UpdateItem(int id, string ItemName, string ItemValue) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Configuration set ");
            strSql.Append("ItemName=@ItemName,");
            strSql.Append("ItemValue=@ItemValue,");
            strSql.Append(" where ItemID=@ItemID");
            SqlParameter[] parameters = {					
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemValue",SqlDbType.NVarChar),
                    new SqlParameter("@ItemID", SqlDbType.Int,4)};
            parameters[0].Value = ItemName;
            parameters[1].Value = ItemValue;
            parameters[2].Value = id;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }

        }

        /// <summary>
        /// 更新配置值
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool UpdateItem(int id, string ItemValue) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Configuration set ");
            strSql.Append("ItemValue=@ItemValue ");
            strSql.Append("where ItemID=@ItemID");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@ItemValue",SqlDbType.NVarChar)};
            parameters[0].Value = id;
            parameters[1].Value = ItemValue;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1) {
                return true;
            } else {
                return false;
            }

        }

        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool DeleteItem(int id) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_Configuration ");
            strSql.Append(" where ItemID=@ItemID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 获取配置项的址
        /// </summary>
        /// <param name="ItemName">配置项名称</param>
        /// <returns></returns>
        public string GetItemValue(string ItemName) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ItemValue Base_Configuration where ItemName=@ItemName");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50)};
            parameters[0].Value = ItemName;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return "";
            } else {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 获取配置的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetItemList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * Base_Configuration ");

            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }

            return SqlServerHelper.Query(strSql.ToString());
        }
    }
}

