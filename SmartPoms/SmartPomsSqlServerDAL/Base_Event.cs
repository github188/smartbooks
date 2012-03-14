// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_EVENT.cs
// 功能描述:专题信息表 -- 接口实现
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
    /// 专题信息表 -- 接口实现
    /// </summary>
    public partial class BASE_EVENT : IBASE_EVENT {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int EventID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Event");
            strSql.Append(" where ");
            strSql.Append(" EventID = @EventID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@EventID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_EVENT entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Event(");
            strSql.Append("EventName,Summary,Score,EventIDParent,Enable,Sort");
            strSql.Append(") values (");
            strSql.Append("@EventName,@Summary,@Score,@EventIDParent,@Enable,@Sort");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@EventName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Summary", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Score", SqlDbType.Int,4) ,            
                        new SqlParameter("@EventIDParent", SqlDbType.Int,4) ,            
                        new SqlParameter("@Enable", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.EventName;
            parameters[1].Value = entity.Summary;
            parameters[2].Value = entity.Score;
            parameters[3].Value = entity.EventIDParent;
            parameters[4].Value = entity.Enable;
            parameters[5].Value = entity.Sort;

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
        public bool Update(Entity.BASE_EVENT entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Event set ");

            strSql.Append(" EventName = @EventName , ");
            strSql.Append(" Summary = @Summary , ");
            strSql.Append(" Score = @Score , ");
            strSql.Append(" EventIDParent = @EventIDParent , ");
            strSql.Append(" Enable = @Enable , ");
            strSql.Append(" Sort = @Sort  ");
            strSql.Append(" where EventID=@EventID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@EventID", SqlDbType.Int,4) ,            
                        new SqlParameter("@EventName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Summary", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Score", SqlDbType.Int,4) ,            
                        new SqlParameter("@EventIDParent", SqlDbType.Int,4) ,            
                        new SqlParameter("@Enable", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4)             
              
            };

            parameters[6].Value = entity.EventID;
            parameters[7].Value = entity.EventName;
            parameters[8].Value = entity.Summary;
            parameters[9].Value = entity.Score;
            parameters[10].Value = entity.EventIDParent;
            parameters[11].Value = entity.Enable;
            parameters[12].Value = entity.Sort;
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
        public bool Delete(int EventID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Event ");
            strSql.Append(" where EventID=@EventID");
            SqlParameter[] parameters = {
					new SqlParameter("@EventID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventID;


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
        public bool DeleteList(string EventIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Event ");
            strSql.Append(" where ID in (" + EventIDlist + ")  ");
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
        public Entity.BASE_EVENT GetEntity(int EventID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EventID, EventName, Summary, Score, EventIDParent, Enable, Sort  ");
            strSql.Append("  from Base_Event ");
            strSql.Append(" where EventID=@EventID");
            SqlParameter[] parameters = {
					new SqlParameter("@EventID", SqlDbType.Int,4)
			};
            parameters[0].Value = EventID;


            Entity.BASE_EVENT entity = new Entity.BASE_EVENT();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["EventID"].ToString() != "") {
                    entity.EventID = int.Parse(ds.Tables[0].Rows[0]["EventID"].ToString());
                }
                entity.EventName = ds.Tables[0].Rows[0]["EventName"].ToString();
                entity.Summary = ds.Tables[0].Rows[0]["Summary"].ToString();
                if (ds.Tables[0].Rows[0]["Score"].ToString() != "") {
                    entity.Score = int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EventIDParent"].ToString() != "") {
                    entity.EventIDParent = int.Parse(ds.Tables[0].Rows[0]["EventIDParent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Enable"].ToString() != "") {
                    entity.Enable = int.Parse(ds.Tables[0].Rows[0]["Enable"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "") {
                    entity.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
            strSql.Append(" FROM Base_Event ");
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
            strSql.Append(" FROM Base_Event ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

