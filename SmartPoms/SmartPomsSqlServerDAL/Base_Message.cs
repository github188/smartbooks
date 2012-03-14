// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MESSAGE.cs
// 功能描述:预警信息表 -- 接口实现
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
    /// 预警信息表 -- 接口实现
    /// </summary>
    public partial class BASE_MESSAGE : IBASE_MESSAGE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int MessageID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Message");
            strSql.Append(" where ");
            strSql.Append(" MessageID = @MessageID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageID", SqlDbType.Int,4)
			};
            parameters[0].Value = MessageID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_MESSAGE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Message(");
            strSql.Append("Title,Detail,CreateTime,Status,Snapshop,UserID");
            strSql.Append(") values (");
            strSql.Append("@Title,@Detail,@CreateTime,@Status,@Snapshop,@UserID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Title", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Detail", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Snapshop", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.Title;
            parameters[1].Value = entity.Detail;
            parameters[2].Value = entity.CreateTime;
            parameters[3].Value = entity.Status;
            parameters[4].Value = entity.Snapshop;
            parameters[5].Value = entity.UserID;

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
        public bool Update(Entity.BASE_MESSAGE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Message set ");

            strSql.Append(" Title = @Title , ");
            strSql.Append(" Detail = @Detail , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Snapshop = @Snapshop , ");
            strSql.Append(" UserID = @UserID  ");
            strSql.Append(" where MessageID=@MessageID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@MessageID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Detail", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Snapshop", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4)             
              
            };

            parameters[6].Value = entity.MessageID;
            parameters[7].Value = entity.Title;
            parameters[8].Value = entity.Detail;
            parameters[9].Value = entity.CreateTime;
            parameters[10].Value = entity.Status;
            parameters[11].Value = entity.Snapshop;
            parameters[12].Value = entity.UserID;
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
        public bool Delete(int MessageID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Message ");
            strSql.Append(" where MessageID=@MessageID");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageID", SqlDbType.Int,4)
			};
            parameters[0].Value = MessageID;


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
        public bool DeleteList(string MessageIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Message ");
            strSql.Append(" where ID in (" + MessageIDlist + ")  ");
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
        public Entity.BASE_MESSAGE GetEntity(int MessageID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MessageID, Title, Detail, CreateTime, Status, Snapshop, UserID  ");
            strSql.Append("  from Base_Message ");
            strSql.Append(" where MessageID=@MessageID");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageID", SqlDbType.Int,4)
			};
            parameters[0].Value = MessageID;


            Entity.BASE_MESSAGE entity = new Entity.BASE_MESSAGE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() != "") {
                    entity.MessageID = int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
                entity.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                entity.Detail = ds.Tables[0].Rows[0]["Detail"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "") {
                    entity.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "") {
                    entity.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                entity.Snapshop = ds.Tables[0].Rows[0]["Snapshop"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "") {
                    entity.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
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
            strSql.Append(" FROM Base_Message ");
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
            strSql.Append(" FROM Base_Message ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

