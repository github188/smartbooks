// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_TERM.cs
// 功能描述:装备信息表 -- 接口实现
//
// 创建标识：王 亚 2012-05-04
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Data.OracleClient;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// 装备信息表 -- 接口实现
    /// </summary>
    public partial class BASE_TERM : IBASE_TERM {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal TERMID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_TERM");
            strSql.Append(" where ");
            strSql.Append(" TERMID = :TERMID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":TERMID", OracleType.Number,4)			};
            parameters[0].Value = TERMID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_TERM entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_TERM(");
            strSql.Append("TERMID,DEPTID,TERMCODE,TERMNAME,SERIALCODE,FORMAT,BRAND,USE,USETIME,SAVEPOINT,REMARK,STATUS,TYPEID");
            strSql.Append(") values (");
            strSql.Append(":TERMID,:DEPTID,:TERMCODE,:TERMNAME,:SERIALCODE,:FORMAT,:BRAND,:USE,:USETIME,:SAVEPOINT,:REMARK,:STATUS,:TYPEID");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":TERMID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":TERMCODE", OracleType.VarChar,50) ,            
                        new OracleParameter(":TERMNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":SERIALCODE", OracleType.VarChar,50) ,            
                        new OracleParameter(":FORMAT", OracleType.VarChar,50) ,            
                        new OracleParameter(":BRAND", OracleType.VarChar,50) ,            
                        new OracleParameter(":USE", OracleType.VarChar,50) ,            
                        new OracleParameter(":USETIME", OracleType.DateTime) ,            
                        new OracleParameter(":SAVEPOINT", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,50) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.TERMID;
            parameters[1].Value = entity.DEPTID;
            parameters[2].Value = entity.TERMCODE;
            parameters[3].Value = entity.TERMNAME;
            parameters[4].Value = entity.SERIALCODE;
            parameters[5].Value = entity.FORMAT;
            parameters[6].Value = entity.BRAND;
            parameters[7].Value = entity.USE;
            parameters[8].Value = entity.USETIME;
            parameters[9].Value = entity.SAVEPOINT;
            parameters[10].Value = entity.REMARK;
            parameters[11].Value = entity.STATUS;
            parameters[12].Value = entity.TYPEID;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_TERM entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_TERM set ");

            strSql.Append(" TERMID = :TERMID , ");
            strSql.Append(" DEPTID = :DEPTID , ");
            strSql.Append(" TERMCODE = :TERMCODE , ");
            strSql.Append(" TERMNAME = :TERMNAME , ");
            strSql.Append(" SERIALCODE = :SERIALCODE , ");
            strSql.Append(" FORMAT = :FORMAT , ");
            strSql.Append(" BRAND = :BRAND , ");
            strSql.Append(" USE = :USE , ");
            strSql.Append(" USETIME = :USETIME , ");
            strSql.Append(" SAVEPOINT = :SAVEPOINT , ");
            strSql.Append(" REMARK = :REMARK , ");
            strSql.Append(" STATUS = :STATUS , ");
            strSql.Append(" TYPEID = :TYPEID  ");
            strSql.Append(" where TERMID=:TERMID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":TERMID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":TERMCODE", OracleType.VarChar,50) ,            
                        new OracleParameter(":TERMNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":SERIALCODE", OracleType.VarChar,50) ,            
                        new OracleParameter(":FORMAT", OracleType.VarChar,50) ,            
                        new OracleParameter(":BRAND", OracleType.VarChar,50) ,            
                        new OracleParameter(":USE", OracleType.VarChar,50) ,            
                        new OracleParameter(":USETIME", OracleType.DateTime) ,            
                        new OracleParameter(":SAVEPOINT", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,50) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4)             
              
            };

            parameters[13].Value = entity.TERMID;
            parameters[14].Value = entity.DEPTID;
            parameters[15].Value = entity.TERMCODE;
            parameters[16].Value = entity.TERMNAME;
            parameters[17].Value = entity.SERIALCODE;
            parameters[18].Value = entity.FORMAT;
            parameters[19].Value = entity.BRAND;
            parameters[20].Value = entity.USE;
            parameters[21].Value = entity.USETIME;
            parameters[22].Value = entity.SAVEPOINT;
            parameters[23].Value = entity.REMARK;
            parameters[24].Value = entity.STATUS;
            parameters[25].Value = entity.TYPEID;
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
        public bool Delete(decimal TERMID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_TERM ");
            strSql.Append(" where TERMID=:TERMID ");
            OracleParameter[] parameters = {
					new OracleParameter(":TERMID", OracleType.Number,4)			};
            parameters[0].Value = TERMID;


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
        public Entity.BASE_TERM GetEntity(decimal TERMID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TERMID, DEPTID, TERMCODE, TERMNAME, SERIALCODE, FORMAT, BRAND, USE, USETIME, SAVEPOINT, REMARK, STATUS, TYPEID  ");
            strSql.Append("  from BASE_TERM ");
            strSql.Append(" where TERMID=:TERMID ");
            OracleParameter[] parameters = {
					new OracleParameter(":TERMID", OracleType.Number,4)			};
            parameters[0].Value = TERMID;


            Entity.BASE_TERM entity = new Entity.BASE_TERM();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["TERMID"].ToString() != "") {
                    entity.TERMID = decimal.Parse(dt.Rows[0]["TERMID"].ToString());
                }
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
                }
                entity.TERMCODE = dt.Rows[0]["TERMCODE"].ToString();
                entity.TERMNAME = dt.Rows[0]["TERMNAME"].ToString();
                entity.SERIALCODE = dt.Rows[0]["SERIALCODE"].ToString();
                entity.FORMAT = dt.Rows[0]["FORMAT"].ToString();
                entity.BRAND = dt.Rows[0]["BRAND"].ToString();
                entity.USE = dt.Rows[0]["USE"].ToString();
                if (dt.Rows[0]["USETIME"].ToString() != "") {
                    entity.USETIME = DateTime.Parse(dt.Rows[0]["USETIME"].ToString());
                }
                entity.SAVEPOINT = dt.Rows[0]["SAVEPOINT"].ToString();
                entity.REMARK = dt.Rows[0]["REMARK"].ToString();
                if (dt.Rows[0]["STATUS"].ToString() != "") {
                    entity.STATUS = decimal.Parse(dt.Rows[0]["STATUS"].ToString());
                }
                if (dt.Rows[0]["TYPEID"].ToString() != "") {
                    entity.TYPEID = decimal.Parse(dt.Rows[0]["TYPEID"].ToString());
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
            strSql.Append(" FROM BASE_TERM ");
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
            strSql.Append(" FROM BASE_TERM ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

