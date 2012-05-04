// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CASE_CLOSED.cs
// 功能描述:路产案件（议案结案表） -- 接口实现
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
    /// 路产案件（议案结案表） -- 接口实现
    /// </summary>
    public partial class BASE_CASE_CLOSED : IBASE_CASE_CLOSED {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CASE_CLOSED");
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
        public void Add(Entity.BASE_CASE_CLOSED entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_CASE_CLOSED(");
            strSql.Append("ID,MOTIONTIME,MOTIONLOCATION,MOTIONPRO,RECORD,DISCUSS,LEAD,CLOSEDTIME,RECOVERLOSS,CLOSEDEAY,RESULT,REMARK,CASEID");
            strSql.Append(") values (");
            strSql.Append(":ID,:MOTIONTIME,:MOTIONLOCATION,:MOTIONPRO,:RECORD,:DISCUSS,:LEAD,:CLOSEDTIME,:RECOVERLOSS,:CLOSEDEAY,:RESULT,:REMARK,:CASEID");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":MOTIONTIME", OracleType.DateTime) ,            
                        new OracleParameter(":MOTIONLOCATION", OracleType.DateTime) ,            
                        new OracleParameter(":MOTIONPRO", OracleType.VarChar,50) ,            
                        new OracleParameter(":RECORD", OracleType.VarChar,50) ,            
                        new OracleParameter(":DISCUSS", OracleType.VarChar,500) ,            
                        new OracleParameter(":LEAD", OracleType.VarChar,500) ,            
                        new OracleParameter(":CLOSEDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":RECOVERLOSS", OracleType.Number,4) ,            
                        new OracleParameter(":CLOSEDEAY", OracleType.VarChar,500) ,            
                        new OracleParameter(":RESULT", OracleType.VarChar,500) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500) ,            
                        new OracleParameter(":CASEID", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.MOTIONTIME;
            parameters[2].Value = entity.MOTIONLOCATION;
            parameters[3].Value = entity.MOTIONPRO;
            parameters[4].Value = entity.RECORD;
            parameters[5].Value = entity.DISCUSS;
            parameters[6].Value = entity.LEAD;
            parameters[7].Value = entity.CLOSEDTIME;
            parameters[8].Value = entity.RECOVERLOSS;
            parameters[9].Value = entity.CLOSEDEAY;
            parameters[10].Value = entity.RESULT;
            parameters[11].Value = entity.REMARK;
            parameters[12].Value = entity.CASEID;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_CASE_CLOSED entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CASE_CLOSED set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" MOTIONTIME = :MOTIONTIME , ");
            strSql.Append(" MOTIONLOCATION = :MOTIONLOCATION , ");
            strSql.Append(" MOTIONPRO = :MOTIONPRO , ");
            strSql.Append(" RECORD = :RECORD , ");
            strSql.Append(" DISCUSS = :DISCUSS , ");
            strSql.Append(" LEAD = :LEAD , ");
            strSql.Append(" CLOSEDTIME = :CLOSEDTIME , ");
            strSql.Append(" RECOVERLOSS = :RECOVERLOSS , ");
            strSql.Append(" CLOSEDEAY = :CLOSEDEAY , ");
            strSql.Append(" RESULT = :RESULT , ");
            strSql.Append(" REMARK = :REMARK , ");
            strSql.Append(" CASEID = :CASEID  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":MOTIONTIME", OracleType.DateTime) ,            
                        new OracleParameter(":MOTIONLOCATION", OracleType.DateTime) ,            
                        new OracleParameter(":MOTIONPRO", OracleType.VarChar,50) ,            
                        new OracleParameter(":RECORD", OracleType.VarChar,50) ,            
                        new OracleParameter(":DISCUSS", OracleType.VarChar,500) ,            
                        new OracleParameter(":LEAD", OracleType.VarChar,500) ,            
                        new OracleParameter(":CLOSEDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":RECOVERLOSS", OracleType.Number,4) ,            
                        new OracleParameter(":CLOSEDEAY", OracleType.VarChar,500) ,            
                        new OracleParameter(":RESULT", OracleType.VarChar,500) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500) ,            
                        new OracleParameter(":CASEID", OracleType.Number,4)             
              
            };

            parameters[13].Value = entity.ID;
            parameters[14].Value = entity.MOTIONTIME;
            parameters[15].Value = entity.MOTIONLOCATION;
            parameters[16].Value = entity.MOTIONPRO;
            parameters[17].Value = entity.RECORD;
            parameters[18].Value = entity.DISCUSS;
            parameters[19].Value = entity.LEAD;
            parameters[20].Value = entity.CLOSEDTIME;
            parameters[21].Value = entity.RECOVERLOSS;
            parameters[22].Value = entity.CLOSEDEAY;
            parameters[23].Value = entity.RESULT;
            parameters[24].Value = entity.REMARK;
            parameters[25].Value = entity.CASEID;
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
            strSql.Append("delete from BASE_CASE_CLOSED ");
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
        public Entity.BASE_CASE_CLOSED GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, MOTIONTIME, MOTIONLOCATION, MOTIONPRO, RECORD, DISCUSS, LEAD, CLOSEDTIME, RECOVERLOSS, CLOSEDEAY, RESULT, REMARK, CASEID  ");
            strSql.Append("  from BASE_CASE_CLOSED ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_CASE_CLOSED entity = new Entity.BASE_CASE_CLOSED();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["MOTIONTIME"].ToString() != "") {
                    entity.MOTIONTIME = DateTime.Parse(dt.Rows[0]["MOTIONTIME"].ToString());
                }
                if (dt.Rows[0]["MOTIONLOCATION"].ToString() != "") {
                    entity.MOTIONLOCATION = DateTime.Parse(dt.Rows[0]["MOTIONLOCATION"].ToString());
                }
                entity.MOTIONPRO = dt.Rows[0]["MOTIONPRO"].ToString();
                entity.RECORD = dt.Rows[0]["RECORD"].ToString();
                entity.DISCUSS = dt.Rows[0]["DISCUSS"].ToString();
                entity.LEAD = dt.Rows[0]["LEAD"].ToString();
                if (dt.Rows[0]["CLOSEDTIME"].ToString() != "") {
                    entity.CLOSEDTIME = DateTime.Parse(dt.Rows[0]["CLOSEDTIME"].ToString());
                }
                if (dt.Rows[0]["RECOVERLOSS"].ToString() != "") {
                    entity.RECOVERLOSS = decimal.Parse(dt.Rows[0]["RECOVERLOSS"].ToString());
                }
                entity.CLOSEDEAY = dt.Rows[0]["CLOSEDEAY"].ToString();
                entity.RESULT = dt.Rows[0]["RESULT"].ToString();
                entity.REMARK = dt.Rows[0]["REMARK"].ToString();
                if (dt.Rows[0]["CASEID"].ToString() != "") {
                    entity.CASEID = decimal.Parse(dt.Rows[0]["CASEID"].ToString());
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
            strSql.Append(" FROM BASE_CASE_CLOSED ");
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
            strSql.Append(" FROM BASE_CASE_CLOSED ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

