﻿// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE.cs
// 功能描述:公文信息表 -- 接口实现
//
// 创建标识：王 亚 2012-05-18
namespace Maticsoft.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;

    /// <summary>
    /// 公文信息表 -- 接口实现
    /// </summary>
    public partial class BASE_ARTICLE : IBASE_ARTICLE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ARTICLE");
            strSql.Append(" where ");
            strSql.Append(" ID = :ID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_ARTICLE model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ARTICLE(");
            strSql.Append("ID,STATUS,ISREPLY,TYPEID,SENDCODE,USERID,DEPTID,PARENTID,TITLE,CONTENT,TIMESTAMP,SCORE,ANNEX");
            strSql.Append(") values (");
            strSql.Append(":ID,:STATUS,:ISREPLY,:TYPEID,:SENDCODE,:USERID,:DEPTID,:PARENTID,:TITLE,:CONTENT,:TIMESTAMP,:SCORE,:ANNEX");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":ISREPLY", OracleType.Number,4) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4) ,            
                        new OracleParameter(":SENDCODE", OracleType.VarChar,80) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":TITLE", OracleType.VarChar,200) ,            
                        new OracleParameter(":CONTENT", OracleType.VarChar,4000) ,            
                        new OracleParameter(":TIMESTAMP", OracleType.DateTime) ,            
                        new OracleParameter(":SCORE", OracleType.Number,4) ,            
                        new OracleParameter(":ANNEX", OracleType.VarChar,200)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.STATUS;
            parameters[2].Value = model.ISREPLY;
            parameters[3].Value = model.TYPEID;
            parameters[4].Value = model.SENDCODE;
            parameters[5].Value = model.USERID;
            parameters[6].Value = model.DEPTID;
            parameters[7].Value = model.PARENTID;
            parameters[8].Value = model.TITLE;
            parameters[9].Value = model.CONTENT;
            parameters[10].Value = model.TIMESTAMP;
            parameters[11].Value = model.SCORE;
            parameters[12].Value = model.ANNEX;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_ARTICLE model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_ARTICLE set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" STATUS = :STATUS , ");
            strSql.Append(" ISREPLY = :ISREPLY , ");
            strSql.Append(" TYPEID = :TYPEID , ");
            strSql.Append(" SENDCODE = :SENDCODE , ");
            strSql.Append(" USERID = :USERID , ");
            strSql.Append(" DEPTID = :DEPTID , ");
            strSql.Append(" PARENTID = :PARENTID , ");
            strSql.Append(" TITLE = :TITLE , ");
            strSql.Append(" CONTENT = :CONTENT , ");
            strSql.Append(" TIMESTAMP = :TIMESTAMP , ");
            strSql.Append(" SCORE = :SCORE , ");
            strSql.Append(" ANNEX = :ANNEX  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":ISREPLY", OracleType.Number,4) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4) ,            
                        new OracleParameter(":SENDCODE", OracleType.VarChar,80) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":TITLE", OracleType.VarChar,200) ,            
                        new OracleParameter(":CONTENT", OracleType.VarChar,4000) ,            
                        new OracleParameter(":TIMESTAMP", OracleType.DateTime) ,            
                        new OracleParameter(":SCORE", OracleType.Number,4) ,            
                        new OracleParameter(":ANNEX", OracleType.VarChar,200)             
              
            };

            parameters[13].Value = model.ID;
            parameters[14].Value = model.STATUS;
            parameters[15].Value = model.ISREPLY;
            parameters[16].Value = model.TYPEID;
            parameters[17].Value = model.SENDCODE;
            parameters[18].Value = model.USERID;
            parameters[19].Value = model.DEPTID;
            parameters[20].Value = model.PARENTID;
            parameters[21].Value = model.TITLE;
            parameters[22].Value = model.CONTENT;
            parameters[23].Value = model.TIMESTAMP;
            parameters[24].Value = model.SCORE;
            parameters[25].Value = model.ANNEX;
            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ARTICLE ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.BASE_ARTICLE GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, STATUS, ISREPLY, TYPEID, SENDCODE, USERID, DEPTID, PARENTID, TITLE, CONTENT, TIMESTAMP, SCORE, ANNEX  ");
            strSql.Append("  from BASE_ARTICLE ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_ARTICLE entity = new Entity.BASE_ARTICLE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["STATUS"].ToString() != "") {
                    entity.STATUS = decimal.Parse(dt.Rows[0]["STATUS"].ToString());
                }
                if (dt.Rows[0]["ISREPLY"].ToString() != "") {
                    entity.ISREPLY = decimal.Parse(dt.Rows[0]["ISREPLY"].ToString());
                }
                if (dt.Rows[0]["TYPEID"].ToString() != "") {
                    entity.TYPEID = decimal.Parse(dt.Rows[0]["TYPEID"].ToString());
                }
                entity.SENDCODE = dt.Rows[0]["SENDCODE"].ToString();
                if (dt.Rows[0]["USERID"].ToString() != "") {
                    entity.USERID = decimal.Parse(dt.Rows[0]["USERID"].ToString());
                }
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
                }
                if (dt.Rows[0]["PARENTID"].ToString() != "") {
                    entity.PARENTID = decimal.Parse(dt.Rows[0]["PARENTID"].ToString());
                }
                entity.TITLE = dt.Rows[0]["TITLE"].ToString();
                entity.CONTENT = dt.Rows[0]["CONTENT"].ToString();
                if (dt.Rows[0]["TIMESTAMP"].ToString() != "") {
                    entity.TIMESTAMP = DateTime.Parse(dt.Rows[0]["TIMESTAMP"].ToString());
                }
                if (dt.Rows[0]["SCORE"].ToString() != "") {
                    entity.SCORE = decimal.Parse(dt.Rows[0]["SCORE"].ToString());
                }
                entity.ANNEX = dt.Rows[0]["ANNEX"].ToString();

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
            strSql.Append(" FROM BASE_ARTICLE ");
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
            strSql.Append(" FROM BASE_ARTICLE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

