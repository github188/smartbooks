// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_EVENTWORD.cs
// 功能描述:Base_EventWord -- 接口实现
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
    /// Base_EventWord -- 接口实现
    /// </summary>
    public partial class BASE_EVENTWORD : IBASE_EVENTWORD {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int EventWordID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_EventWord");
            strSql.Append(" where ");
            strSql.Append(" EventWordID = @EventWordID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@EventWordID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventWordID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_EVENTWORD entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_EventWord(");
            strSql.Append("EventID,WordID");
            strSql.Append(") values (");
            strSql.Append("@EventID,@WordID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@EventID", SqlDbType.Int,4) ,            
                        new SqlParameter("@WordID", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.EventID;
            parameters[1].Value = entity.WordID;

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
        public bool Update(Entity.BASE_EVENTWORD entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_EventWord set ");

            strSql.Append(" EventID = @EventID , ");
            strSql.Append(" WordID = @WordID  ");
            strSql.Append(" where EventWordID=@EventWordID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@EventWordID", SqlDbType.Int,4) ,            
                        new SqlParameter("@EventID", SqlDbType.Int,4) ,            
                        new SqlParameter("@WordID", SqlDbType.Int,4)             
              
            };

            parameters[2].Value = entity.EventWordID;
            parameters[3].Value = entity.EventID;
            parameters[4].Value = entity.WordID;
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
        public bool Delete(int EventWordID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_EventWord ");
            strSql.Append(" where EventWordID=@EventWordID");
            SqlParameter[] parameters = {
					new SqlParameter("@EventWordID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventWordID;


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
        public bool DeleteList(string EventWordIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_EventWord ");
            strSql.Append(" where ID in (" + EventWordIDlist + ")  ");
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
        public Entity.BASE_EVENTWORD GetEntity(int EventWordID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EventWordID, EventID, WordID  ");
            strSql.Append("  from Base_EventWord ");
            strSql.Append(" where EventWordID=@EventWordID");
            SqlParameter[] parameters = {
					new SqlParameter("@EventWordID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventWordID;


            Entity.BASE_EVENTWORD entity = new Entity.BASE_EVENTWORD();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["EventWordID"].ToString() != "") {
                    entity.EventWordID = int.Parse(ds.Tables[0].Rows[0]["EventWordID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EventID"].ToString() != "") {
                    entity.EventID = int.Parse(ds.Tables[0].Rows[0]["EventID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WordID"].ToString() != "") {
                    entity.WordID = int.Parse(ds.Tables[0].Rows[0]["WordID"].ToString());
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
            strSql.Append(" FROM Base_EventWord ");
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
            strSql.Append(" FROM Base_EventWord ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

