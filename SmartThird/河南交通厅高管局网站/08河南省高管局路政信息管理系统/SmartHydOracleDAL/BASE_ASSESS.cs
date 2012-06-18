// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ASSESS.cs
// 功能描述:考评项目记录表 -- 接口实现
//
// 创建标识：王 亚 2012-06-18
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;

    /// <summary>
    /// 考评项目记录表 -- 接口实现
    /// </summary>
    public partial class BASE_ASSESS : IBASE_ASSESS {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ASSESS");
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
        public void Add(Entity.BASE_ASSESS model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ASSESS(");
            strSql.Append("ID,DEPTCODE,SCORE,REASON,TYPEID,TICKTIME,STATUS");
            strSql.Append(") values (");
            strSql.Append(":ID,:DEPTCODE,:SCORE,:REASON,:TYPEID,:TICKTIME,:STATUS");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTCODE", OracleType.Number,4) ,            
                        new OracleParameter(":SCORE", OracleType.Number,4) ,            
                        new OracleParameter(":REASON", OracleType.VarChar,200) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.DEPTCODE;
            parameters[2].Value = model.SCORE;
            parameters[3].Value = model.REASON;
            parameters[4].Value = model.TYPEID;
            parameters[5].Value = model.TICKTIME;
            parameters[6].Value = model.STATUS;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_ASSESS model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_ASSESS set ");

            strSql.Append(" DEPTCODE = :DEPTCODE , ");
            strSql.Append(" SCORE = :SCORE , ");
            strSql.Append(" REASON = :REASON , ");
            strSql.Append(" TYPEID = :TYPEID , ");
            strSql.Append(" TICKTIME = :TICKTIME , ");
            strSql.Append(" STATUS = :STATUS  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
                        new OracleParameter(":DEPTCODE", OracleType.Number,4) ,            
                        new OracleParameter(":SCORE", OracleType.Number,4) ,            
                        new OracleParameter(":REASON", OracleType.VarChar,200) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,
                        new OracleParameter(":ID", OracleType.Number,4) 
              
            };

            
            parameters[0].Value = model.DEPTCODE;
            parameters[1].Value = model.SCORE;
            parameters[2].Value = model.REASON;
            parameters[3].Value = model.TYPEID;
            parameters[4].Value = model.TICKTIME;
            parameters[5].Value = model.STATUS;
            parameters[6].Value = model.ID;

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
            strSql.Append("delete from BASE_ASSESS ");
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
        public Entity.BASE_ASSESS GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, DEPTCODE, SCORE, REASON, TYPEID, TICKTIME, STATUS  ");
            strSql.Append("  from BASE_ASSESS ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_ASSESS entity = new Entity.BASE_ASSESS();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["DEPTCODE"].ToString() != "") {
                    entity.DEPTCODE = decimal.Parse(dt.Rows[0]["DEPTCODE"].ToString());
                }
                if (dt.Rows[0]["SCORE"].ToString() != "") {
                    entity.SCORE = decimal.Parse(dt.Rows[0]["SCORE"].ToString());
                }
                entity.REASON = dt.Rows[0]["REASON"].ToString();
                if (dt.Rows[0]["TYPEID"].ToString() != "") {
                    entity.TYPEID = decimal.Parse(dt.Rows[0]["TYPEID"].ToString());
                }
                if (dt.Rows[0]["TICKTIME"].ToString() != "") {
                    entity.TICKTIME = DateTime.Parse(dt.Rows[0]["TICKTIME"].ToString());
                }
                if (dt.Rows[0]["STATUS"].ToString() != "") {
                    entity.STATUS = decimal.Parse(dt.Rows[0]["STATUS"].ToString());
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
            strSql.Append(" FROM BASE_ASSESS ");
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
            strSql.Append(" FROM BASE_ASSESS ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }

        public void Query(string sqlString) {
            OracleHelper.Query(sqlString);
        }
    }
}