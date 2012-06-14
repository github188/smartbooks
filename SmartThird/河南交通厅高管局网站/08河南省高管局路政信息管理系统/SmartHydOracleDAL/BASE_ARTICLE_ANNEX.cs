// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE_ANNEX.cs
// 功能描述:公文信息表 -- 接口实现
//
// 创建标识：王 亚 2012-05-18
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;

    /// <summary>
    /// 公文附件表 -- 接口实现
    /// </summary>
    public partial class BASE_ARTICLE_ANNEX : IBASE_ARTICLE_ANNEX {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ARTICLE_ANNEX");
            strSql.Append(" where ");
            strSql.Append(" ID = :ID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_ARTICLE_ANNEX model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ARTICLE_ANNEX(");
            strSql.Append("ID,SOURCENAME,EXTENSION,SERVERNAME,SERVERPATH,UPTIME,STATUS,UPAUTHOR");
            strSql.Append(") values (");
            strSql.Append(":ID,:SOURCENAME,:EXTENSION,:SERVERNAME,:SERVERPATH,:UPTIME,:STATUS,:UPAUTHOR");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":SOURCENAME", OracleType.VarChar,100) ,            
                        new OracleParameter(":EXTENSION", OracleType.VarChar,10) ,            
                        new OracleParameter(":SERVERNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":SERVERPATH", OracleType.VarChar,100) ,            
                        new OracleParameter(":UPTIME", OracleType.DateTime) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":UPAUTHOR", OracleType.Number,4)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.SOURCENAME;
            parameters[2].Value = model.EXTENSION;
            parameters[3].Value = model.SERVERNAME;
            parameters[4].Value = model.SERVERPATH;
            parameters[5].Value = model.UPTIME;
            parameters[6].Value = model.STATUS;
            parameters[7].Value = model.UPAUTHOR;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_ARTICLE_ANNEX model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_ARTICLE_ANNEX set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" SOURCENAME = :SOURCENAME , ");
            strSql.Append(" EXTENSION = :EXTENSION , ");
            strSql.Append(" SERVERNAME = :SERVERNAME , ");
            strSql.Append(" SERVERPATH = :SERVERPATH , ");
            strSql.Append(" UPTIME = :UPTIME , ");
            strSql.Append(" STATUS = :STATUS , ");
            strSql.Append(" UPAUTHOR = :UPAUTHOR  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":SOURCENAME", OracleType.VarChar,100) ,            
                        new OracleParameter(":EXTENSION", OracleType.VarChar,10) ,            
                        new OracleParameter(":SERVERNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":SERVERPATH", OracleType.VarChar,100) ,            
                        new OracleParameter(":UPTIME", OracleType.DateTime) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":UPAUTHOR", OracleType.Number,4)             
              
            };

            parameters[8].Value = model.ID;
            parameters[9].Value = model.SOURCENAME;
            parameters[10].Value = model.EXTENSION;
            parameters[11].Value = model.SERVERNAME;
            parameters[12].Value = model.SERVERPATH;
            parameters[13].Value = model.UPTIME;
            parameters[14].Value = model.STATUS;
            parameters[15].Value = model.UPAUTHOR;
            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ARTICLE_ANNEX ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.BASE_ARTICLE_ANNEX GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, SOURCENAME, EXTENSION, SERVERNAME, SERVERPATH, UPTIME, STATUS, UPAUTHOR  ");
            strSql.Append("  from BASE_ARTICLE_ANNEX ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_ARTICLE_ANNEX entity = new Entity.BASE_ARTICLE_ANNEX();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                entity.SOURCENAME = dt.Rows[0]["SOURCENAME"].ToString();
                entity.EXTENSION = dt.Rows[0]["EXTENSION"].ToString();
                entity.SERVERNAME = dt.Rows[0]["SERVERNAME"].ToString();
                entity.SERVERPATH = dt.Rows[0]["SERVERPATH"].ToString();
                if (dt.Rows[0]["UPTIME"].ToString() != "") {
                    entity.UPTIME = DateTime.Parse(dt.Rows[0]["UPTIME"].ToString());
                }
                if (dt.Rows[0]["STATUS"].ToString() != "") {
                    entity.STATUS = decimal.Parse(dt.Rows[0]["STATUS"].ToString());
                }
                if (dt.Rows[0]["UPAUTHOR"].ToString() != "") {
                    entity.UPAUTHOR = decimal.Parse(dt.Rows[0]["UPAUTHOR"].ToString());
                }

                return entity;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BASE_ARTICLE_ANNEX ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return OracleHelper.Query(strSql.ToString());
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
            strSql.Append(" FROM BASE_ARTICLE_ANNEX ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }
    }
}