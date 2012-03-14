// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USERGROUP.cs
// 功能描述:Base_UserGroup -- 接口实现
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
    /// Base_UserGroup -- 接口实现
    /// </summary>
    public partial class BASE_USERGROUP : IBASE_USERGROUP {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int UG_ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_UserGroup");
            strSql.Append(" where ");
            strSql.Append(" UG_ID = @UG_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UG_ID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_USERGROUP entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_UserGroup(");
            strSql.Append("UG_Name,UG_Order,UG_Description,UG_Depth,UG_SuperiorID,UG_Count");
            strSql.Append(") values (");
            strSql.Append("@UG_Name,@UG_Order,@UG_Description,@UG_Depth,@UG_SuperiorID,@UG_Count");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UG_Name", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@UG_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Description", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@UG_Depth", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_SuperiorID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Count", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.UG_Name;
            parameters[1].Value = entity.UG_Order;
            parameters[2].Value = entity.UG_Description;
            parameters[3].Value = entity.UG_Depth;
            parameters[4].Value = entity.UG_SuperiorID;
            parameters[5].Value = entity.UG_Count;

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
        public bool Update(Entity.BASE_USERGROUP entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_UserGroup set ");

            strSql.Append(" UG_Name = @UG_Name , ");
            strSql.Append(" UG_Order = @UG_Order , ");
            strSql.Append(" UG_Description = @UG_Description , ");
            strSql.Append(" UG_Depth = @UG_Depth , ");
            strSql.Append(" UG_SuperiorID = @UG_SuperiorID , ");
            strSql.Append(" UG_Count = @UG_Count  ");
            strSql.Append(" where UG_ID=@UG_ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UG_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Name", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@UG_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Description", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@UG_Depth", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_SuperiorID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UG_Count", SqlDbType.Int,4)             
              
            };

            parameters[6].Value = entity.UG_ID;
            parameters[7].Value = entity.UG_Name;
            parameters[8].Value = entity.UG_Order;
            parameters[9].Value = entity.UG_Description;
            parameters[10].Value = entity.UG_Depth;
            parameters[11].Value = entity.UG_SuperiorID;
            parameters[12].Value = entity.UG_Count;
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
        public bool Delete(int UG_ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_UserGroup ");
            strSql.Append(" where UG_ID=@UG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UG_ID;


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
        public bool DeleteList(string UG_IDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_UserGroup ");
            strSql.Append(" where ID in (" + UG_IDlist + ")  ");
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
        public Entity.BASE_USERGROUP GetEntity(int UG_ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UG_ID, UG_Name, UG_Order, UG_Description, UG_Depth, UG_SuperiorID, UG_Count  ");
            strSql.Append("  from Base_UserGroup ");
            strSql.Append(" where UG_ID=@UG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UG_ID;


            Entity.BASE_USERGROUP entity = new Entity.BASE_USERGROUP();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["UG_ID"].ToString() != "") {
                    entity.UG_ID = int.Parse(ds.Tables[0].Rows[0]["UG_ID"].ToString());
                }
                entity.UG_Name = ds.Tables[0].Rows[0]["UG_Name"].ToString();
                if (ds.Tables[0].Rows[0]["UG_Order"].ToString() != "") {
                    entity.UG_Order = int.Parse(ds.Tables[0].Rows[0]["UG_Order"].ToString());
                }
                entity.UG_Description = ds.Tables[0].Rows[0]["UG_Description"].ToString();
                if (ds.Tables[0].Rows[0]["UG_Depth"].ToString() != "") {
                    entity.UG_Depth = int.Parse(ds.Tables[0].Rows[0]["UG_Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UG_SuperiorID"].ToString() != "") {
                    entity.UG_SuperiorID = int.Parse(ds.Tables[0].Rows[0]["UG_SuperiorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UG_Count"].ToString() != "") {
                    entity.UG_Count = int.Parse(ds.Tables[0].Rows[0]["UG_Count"].ToString());
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
            strSql.Append(" FROM Base_UserGroup ");
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
            strSql.Append(" FROM Base_UserGroup ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

