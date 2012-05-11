// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_FAWEN.cs
// 功能描述:发文信息表 -- 接口实现
//
// 创建标识：付晓 2012-05-07
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Data.OracleClient;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// 发文信息表 -- 接口实现
    /// </summary>
    public partial class BASE_FAWEN : IBASE_FAWEN {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal FID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_FAWEN");
            strSql.Append(" where ");
            strSql.Append(" FID = :FID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":FID", OracleType.Number,4)			};
            parameters[0].Value = FID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_FAWEN entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_FAWEN(");
            strSql.Append("FID,F_NUMBER,F_TITLE,F_TYPE,F_CONTENT,F_ANNEX,F_DATE,REMARK,F_ORGAN,F_LEVEL,F_DEGREE,F_DELSTATE");
            strSql.Append(") values (");
            strSql.Append(":FID,:F_NUMBER,:F_TITLE,:F_TYPE,:F_CONTENT,:F_ANNEX,:F_DATE,:REMARK,:F_ORGAN,:F_LEVEL,:F_DEGREE,:F_DELSTATE");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":FID", OracleType.Number,4) ,            
                        new OracleParameter(":F_NUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_TITLE", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_TYPE", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_CONTENT", OracleType.VarChar,800) ,            
                        new OracleParameter(":F_ANNEX", OracleType.VarChar,100) ,            
                        new OracleParameter(":F_DATE", OracleType.DateTime) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500) ,            
                        new OracleParameter(":F_ORGAN", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_LEVEL", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_DEGREE", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_DELSTATE", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.FID;
            parameters[1].Value = entity.F_NUMBER;
            parameters[2].Value = entity.F_TITLE;
            parameters[3].Value = entity.F_TYPE;
            parameters[4].Value = entity.F_CONTENT;
            parameters[5].Value = entity.F_ANNEX;
            parameters[6].Value = entity.F_DATE;
            parameters[7].Value = entity.REMARK;
            parameters[8].Value = entity.F_ORGAN;
            parameters[9].Value = entity.F_LEVEL;
            parameters[10].Value = entity.F_DEGREE;
            parameters[11].Value = entity.F_DELSTATE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_FAWEN entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_FAWEN set ");

            strSql.Append(" FID = :FID , ");
            strSql.Append(" F_NUMBER = :F_NUMBER , ");
            strSql.Append(" F_TITLE = :F_TITLE , ");
            strSql.Append(" F_TYPE = :F_TYPE , ");
            strSql.Append(" F_CONTENT = :F_CONTENT , ");
            strSql.Append(" F_ANNEX = :F_ANNEX , ");
            strSql.Append(" F_DATE = :F_DATE , ");
            strSql.Append(" REMARK = :REMARK , ");
            strSql.Append(" F_ORGAN = :F_ORGAN , ");
            strSql.Append(" F_LEVEL = :F_LEVEL , ");
            strSql.Append(" F_DEGREE = :F_DEGREE , ");
            strSql.Append(" F_DELSTATE = :F_DELSTATE  ");
            strSql.Append(" where  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":FID", OracleType.Number,4) ,            
                        new OracleParameter(":F_NUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_TITLE", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_TYPE", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_CONTENT", OracleType.VarChar,800) ,            
                        new OracleParameter(":F_ANNEX", OracleType.VarChar,100) ,            
                        new OracleParameter(":F_DATE", OracleType.DateTime) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500) ,            
                        new OracleParameter(":F_ORGAN", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_LEVEL", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_DEGREE", OracleType.VarChar,50) ,            
                        new OracleParameter(":F_DELSTATE", OracleType.Number,4)             
              
            };

            parameters[12].Value = entity.FID;
            parameters[13].Value = entity.F_NUMBER;
            parameters[14].Value = entity.F_TITLE;
            parameters[15].Value = entity.F_TYPE;
            parameters[16].Value = entity.F_CONTENT;
            parameters[17].Value = entity.F_ANNEX;
            parameters[18].Value = entity.F_DATE;
            parameters[19].Value = entity.REMARK;
            parameters[20].Value = entity.F_ORGAN;
            parameters[21].Value = entity.F_LEVEL;
            parameters[22].Value = entity.F_DEGREE;
            parameters[23].Value = entity.F_DELSTATE;
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
        public bool Delete(decimal FID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_FAWEN ");
            strSql.Append(" where ");
            strSql.Append(" FID = :FID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":FID", OracleType.Number,4)			};
            parameters[0].Value = FID;

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
        public Entity.BASE_FAWEN GetEntity(decimal FID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FID, F_NUMBER, F_TITLE, F_TYPE, F_CONTENT, F_ANNEX, F_DATE, REMARK, F_ORGAN, F_LEVEL, F_DEGREE, F_DELSTATE  ");
            strSql.Append("  from BASE_FAWEN ");
            strSql.Append(" where ");
            strSql.Append(" FID = :FID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":FID", OracleType.Number,4)			};
            parameters[0].Value = FID;


            Entity.BASE_FAWEN entity = new Entity.BASE_FAWEN();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["FID"].ToString() != "") {
                    entity.FID = decimal.Parse(dt.Rows[0]["FID"].ToString());
                }
                entity.F_NUMBER = dt.Rows[0]["F_NUMBER"].ToString();
                entity.F_TITLE = dt.Rows[0]["F_TITLE"].ToString();
                entity.F_TYPE = dt.Rows[0]["F_TYPE"].ToString();
                entity.F_CONTENT = dt.Rows[0]["F_CONTENT"].ToString();
                entity.F_ANNEX = dt.Rows[0]["F_ANNEX"].ToString();
                if (dt.Rows[0]["F_DATE"].ToString() != "") {
                    entity.F_DATE = DateTime.Parse(dt.Rows[0]["F_DATE"].ToString());
                }
                entity.REMARK = dt.Rows[0]["REMARK"].ToString();
                entity.F_ORGAN = dt.Rows[0]["F_ORGAN"].ToString();
                entity.F_LEVEL = dt.Rows[0]["F_LEVEL"].ToString();
                entity.F_DEGREE = dt.Rows[0]["F_DEGREE"].ToString();
                if (dt.Rows[0]["F_DELSTATE"].ToString() != "") {
                    entity.F_DELSTATE = decimal.Parse(dt.Rows[0]["F_DELSTATE"].ToString());
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
            strSql.Append(" FROM BASE_FAWEN ");
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
            strSql.Append(" FROM BASE_FAWEN ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

