// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USEREVENT.cs
// 功能描述:Base_UserEvent -- 接口实现
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
    /// Base_UserEvent -- 接口实现
    /// </summary>
    public partial class BASE_USEREVENT : IBASE_USEREVENT {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_UserEvent");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_USEREVENT entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_UserEvent(");
            strSql.Append("ID,UserID,EventID");
            strSql.Append(") values (");
            strSql.Append("@ID,@UserID,@EventID");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@EventID", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.UserID;
            parameters[2].Value = entity.EventID;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_USEREVENT entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_UserEvent set ");

            strSql.Append(" ID = @ID , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" EventID = @EventID  ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@EventID", SqlDbType.Int,4)             
              
            };

            parameters[3].Value = entity.ID;
            parameters[4].Value = entity.UserID;
            parameters[5].Value = entity.EventID;
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
            strSql.Append("delete from Base_UserEvent ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;


            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.BASE_USEREVENT GetEntity(int ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, UserID, EventID  ");
            strSql.Append("  from Base_UserEvent ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;


            Entity.BASE_USEREVENT entity = new Entity.BASE_USEREVENT();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "") {
                    entity.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    entity.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EventID"].ToString() != "") {
                    entity.EventID = int.Parse(ds.Tables[0].Rows[0]["EventID"].ToString());
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
            strSql.Append(" FROM Base_UserEvent ");
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
            strSql.Append(" FROM Base_UserEvent ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

