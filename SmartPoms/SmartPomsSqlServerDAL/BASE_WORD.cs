// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_WORD.cs
// 功能描述:关键字信息表 -- 接口实现
//
// 创建标识：王 亚 2012-03-12
namespace SmartPoms.SQLServerDAL {
    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// 关键字信息表 -- 接口实现
    /// </summary>
    public partial class BASE_WORD : IBASE_WORD {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int WORDID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_WORD");
            strSql.Append(" where ");
            strSql.Append(" WORDID = @WORDID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@WORDID", SqlDbType.Int,4)
			};
            parameters[0].Value = WORDID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_WORD entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_WORD(");
            strSql.Append("WORDNAME,SCORE,WORDIDPARENT,ENABLE,TOPICID");
            strSql.Append(") values (");
            strSql.Append("@WORDNAME,@SCORE,@WORDIDPARENT,@ENABLE,@TOPICID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@WORDNAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SCORE", SqlDbType.Float,8) ,            
                        new SqlParameter("@WORDIDPARENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@ENABLE", SqlDbType.Int,4) ,            
                        new SqlParameter("@TOPICID", SqlDbType.VarChar,500)             
              
            };

            parameters[0].Value = entity.WORDNAME;
            parameters[1].Value = entity.SCORE;
            parameters[2].Value = entity.WORDIDPARENT;
            parameters[3].Value = entity.ENABLE;
            parameters[4].Value = entity.TOPICID;

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
        public bool Update(Entity.BASE_WORD entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_WORD set ");

            strSql.Append(" WORDNAME = @WORDNAME , ");
            strSql.Append(" SCORE = @SCORE , ");
            strSql.Append(" WORDIDPARENT = @WORDIDPARENT , ");
            strSql.Append(" ENABLE = @ENABLE , ");
            strSql.Append(" TOPICID = @TOPICID  ");
            strSql.Append(" where WORDID=@WORDID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@WORDID", SqlDbType.Int,4) ,            
                        new SqlParameter("@WORDNAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SCORE", SqlDbType.Float,8) ,            
                        new SqlParameter("@WORDIDPARENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@ENABLE", SqlDbType.Int,4) ,            
                        new SqlParameter("@TOPICID", SqlDbType.VarChar,500)             
              
            };

            parameters[5].Value = entity.WORDID;
            parameters[6].Value = entity.WORDNAME;
            parameters[7].Value = entity.SCORE;
            parameters[8].Value = entity.WORDIDPARENT;
            parameters[9].Value = entity.ENABLE;
            parameters[10].Value = entity.TOPICID;
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
        public bool Delete(int WORDID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_WORD ");
            strSql.Append(" where WORDID=@WORDID");
            SqlParameter[] parameters = {
					new SqlParameter("@WORDID", SqlDbType.Int,4)
			};
            parameters[0].Value = WORDID;


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
        public bool DeleteList(string WORDIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_WORD ");
            strSql.Append(" where ID in (" + WORDIDlist + ")  ");
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
        public Entity.BASE_WORD GetEntity(int WORDID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WORDID, WORDNAME, SCORE, WORDIDPARENT, ENABLE, TOPICID  ");
            strSql.Append("  from BASE_WORD ");
            strSql.Append(" where WORDID=@WORDID");
            SqlParameter[] parameters = {
					new SqlParameter("@WORDID", SqlDbType.Int,4)
			};
            parameters[0].Value = WORDID;


            Entity.BASE_WORD entity = new Entity.BASE_WORD();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["WORDID"].ToString() != "") {
                    entity.WORDID = int.Parse(ds.Tables[0].Rows[0]["WORDID"].ToString());
                }
                entity.WORDNAME = ds.Tables[0].Rows[0]["WORDNAME"].ToString();
                if (ds.Tables[0].Rows[0]["SCORE"].ToString() != "") {
                    entity.SCORE = decimal.Parse(ds.Tables[0].Rows[0]["SCORE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WORDIDPARENT"].ToString() != "") {
                    entity.WORDIDPARENT = int.Parse(ds.Tables[0].Rows[0]["WORDIDPARENT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ENABLE"].ToString() != "") {
                    entity.ENABLE = int.Parse(ds.Tables[0].Rows[0]["ENABLE"].ToString());
                }
                entity.TOPICID = ds.Tables[0].Rows[0]["TOPICID"].ToString();

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
            strSql.Append("select WORDID,WORDNAME,SCORE,WORDIDPARENT,ENABLE,TOPICID ");
            strSql.Append(" FROM BASE_WORD ");
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
            strSql.Append(" FROM BASE_WORD ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }
    }
}