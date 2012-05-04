// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PATROL.cs
// 功能描述:人工巡逻日志表 -- 接口实现
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
    /// 人工巡逻日志表 -- 接口实现
    /// </summary>
    public partial class BASE_PATROL : IBASE_PATROL {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal PATROLID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PATROL");
            strSql.Append(" where ");
            strSql.Append(" PATROLID = :PATROLID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":PATROLID", OracleType.Number,4)			};
            parameters[0].Value = PATROLID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_PATROL entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_PATROL(");
            strSql.Append("PATROLID,DEPTID,RESPUSER,PATROLUSER,BUSNUMBER,MILEAGE,WEATHER,LOG,BEGINTIME,ENDTIME,TRANSFER,ACCEPT,WITHIN,NEXTWITHIN,ACCEPTCAPTAIN,SHIFTCAPTAIN,ACCEPTBUSNUMBER,TICKTIME,BUSKM");
            strSql.Append(") values (");
            strSql.Append(":PATROLID,:DEPTID,:RESPUSER,:PATROLUSER,:BUSNUMBER,:MILEAGE,:WEATHER,:LOG,:BEGINTIME,:ENDTIME,:TRANSFER,:ACCEPT,:WITHIN,:NEXTWITHIN,:ACCEPTCAPTAIN,:SHIFTCAPTAIN,:ACCEPTBUSNUMBER,:TICKTIME,:BUSKM");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":PATROLID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":RESPUSER", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLUSER", OracleType.Number,4) ,            
                        new OracleParameter(":BUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":MILEAGE", OracleType.Number,4) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":LOG", OracleType.VarChar,500) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":TRANSFER", OracleType.Number,4) ,            
                        new OracleParameter(":ACCEPT", OracleType.Number,4) ,            
                        new OracleParameter(":WITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":NEXTWITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":ACCEPTCAPTAIN", OracleType.Number,4) ,            
                        new OracleParameter(":SHIFTCAPTAIN", OracleType.Number,4) ,            
                        new OracleParameter(":ACCEPTBUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":BUSKM", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.PATROLID;
            parameters[1].Value = entity.DEPTID;
            parameters[2].Value = entity.RESPUSER;
            parameters[3].Value = entity.PATROLUSER;
            parameters[4].Value = entity.BUSNUMBER;
            parameters[5].Value = entity.MILEAGE;
            parameters[6].Value = entity.WEATHER;
            parameters[7].Value = entity.LOG;
            parameters[8].Value = entity.BEGINTIME;
            parameters[9].Value = entity.ENDTIME;
            parameters[10].Value = entity.TRANSFER;
            parameters[11].Value = entity.ACCEPT;
            parameters[12].Value = entity.WITHIN;
            parameters[13].Value = entity.NEXTWITHIN;
            parameters[14].Value = entity.ACCEPTCAPTAIN;
            parameters[15].Value = entity.SHIFTCAPTAIN;
            parameters[16].Value = entity.ACCEPTBUSNUMBER;
            parameters[17].Value = entity.TICKTIME;
            parameters[18].Value = entity.BUSKM;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_PATROL entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PATROL set ");

            strSql.Append(" PATROLID = :PATROLID , ");
            strSql.Append(" DEPTID = :DEPTID , ");
            strSql.Append(" RESPUSER = :RESPUSER , ");
            strSql.Append(" PATROLUSER = :PATROLUSER , ");
            strSql.Append(" BUSNUMBER = :BUSNUMBER , ");
            strSql.Append(" MILEAGE = :MILEAGE , ");
            strSql.Append(" WEATHER = :WEATHER , ");
            strSql.Append(" LOG = :LOG , ");
            strSql.Append(" BEGINTIME = :BEGINTIME , ");
            strSql.Append(" ENDTIME = :ENDTIME , ");
            strSql.Append(" TRANSFER = :TRANSFER , ");
            strSql.Append(" ACCEPT = :ACCEPT , ");
            strSql.Append(" WITHIN = :WITHIN , ");
            strSql.Append(" NEXTWITHIN = :NEXTWITHIN , ");
            strSql.Append(" ACCEPTCAPTAIN = :ACCEPTCAPTAIN , ");
            strSql.Append(" SHIFTCAPTAIN = :SHIFTCAPTAIN , ");
            strSql.Append(" ACCEPTBUSNUMBER = :ACCEPTBUSNUMBER , ");
            strSql.Append(" TICKTIME = :TICKTIME , ");
            strSql.Append(" BUSKM = :BUSKM  ");
            strSql.Append(" where PATROLID=:PATROLID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":PATROLID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":RESPUSER", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLUSER", OracleType.Number,4) ,            
                        new OracleParameter(":BUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":MILEAGE", OracleType.Number,4) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":LOG", OracleType.VarChar,500) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":TRANSFER", OracleType.Number,4) ,            
                        new OracleParameter(":ACCEPT", OracleType.Number,4) ,            
                        new OracleParameter(":WITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":NEXTWITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":ACCEPTCAPTAIN", OracleType.Number,4) ,            
                        new OracleParameter(":SHIFTCAPTAIN", OracleType.Number,4) ,            
                        new OracleParameter(":ACCEPTBUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":BUSKM", OracleType.Number,4)             
              
            };

            parameters[19].Value = entity.PATROLID;
            parameters[20].Value = entity.DEPTID;
            parameters[21].Value = entity.RESPUSER;
            parameters[22].Value = entity.PATROLUSER;
            parameters[23].Value = entity.BUSNUMBER;
            parameters[24].Value = entity.MILEAGE;
            parameters[25].Value = entity.WEATHER;
            parameters[26].Value = entity.LOG;
            parameters[27].Value = entity.BEGINTIME;
            parameters[28].Value = entity.ENDTIME;
            parameters[29].Value = entity.TRANSFER;
            parameters[30].Value = entity.ACCEPT;
            parameters[31].Value = entity.WITHIN;
            parameters[32].Value = entity.NEXTWITHIN;
            parameters[33].Value = entity.ACCEPTCAPTAIN;
            parameters[34].Value = entity.SHIFTCAPTAIN;
            parameters[35].Value = entity.ACCEPTBUSNUMBER;
            parameters[36].Value = entity.TICKTIME;
            parameters[37].Value = entity.BUSKM;
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
        public bool Delete(decimal PATROLID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_PATROL ");
            strSql.Append(" where PATROLID=:PATROLID ");
            OracleParameter[] parameters = {
					new OracleParameter(":PATROLID", OracleType.Number,4)			};
            parameters[0].Value = PATROLID;


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
        public Entity.BASE_PATROL GetEntity(decimal PATROLID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PATROLID, DEPTID, RESPUSER, PATROLUSER, BUSNUMBER, MILEAGE, WEATHER, LOG, BEGINTIME, ENDTIME, TRANSFER, ACCEPT, WITHIN, NEXTWITHIN, ACCEPTCAPTAIN, SHIFTCAPTAIN, ACCEPTBUSNUMBER, TICKTIME, BUSKM  ");
            strSql.Append("  from BASE_PATROL ");
            strSql.Append(" where PATROLID=:PATROLID ");
            OracleParameter[] parameters = {
					new OracleParameter(":PATROLID", OracleType.Number,4)			};
            parameters[0].Value = PATROLID;


            Entity.BASE_PATROL entity = new Entity.BASE_PATROL();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["PATROLID"].ToString() != "") {
                    entity.PATROLID = decimal.Parse(dt.Rows[0]["PATROLID"].ToString());
                }
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
                }
                if (dt.Rows[0]["RESPUSER"].ToString() != "") {
                    entity.RESPUSER = decimal.Parse(dt.Rows[0]["RESPUSER"].ToString());
                }
                if (dt.Rows[0]["PATROLUSER"].ToString() != "") {
                    entity.PATROLUSER = decimal.Parse(dt.Rows[0]["PATROLUSER"].ToString());
                }
                entity.BUSNUMBER = dt.Rows[0]["BUSNUMBER"].ToString();
                if (dt.Rows[0]["MILEAGE"].ToString() != "") {
                    entity.MILEAGE = decimal.Parse(dt.Rows[0]["MILEAGE"].ToString());
                }
                entity.WEATHER = dt.Rows[0]["WEATHER"].ToString();
                entity.LOG = dt.Rows[0]["LOG"].ToString();
                if (dt.Rows[0]["BEGINTIME"].ToString() != "") {
                    entity.BEGINTIME = DateTime.Parse(dt.Rows[0]["BEGINTIME"].ToString());
                }
                if (dt.Rows[0]["ENDTIME"].ToString() != "") {
                    entity.ENDTIME = DateTime.Parse(dt.Rows[0]["ENDTIME"].ToString());
                }
                if (dt.Rows[0]["TRANSFER"].ToString() != "") {
                    entity.TRANSFER = decimal.Parse(dt.Rows[0]["TRANSFER"].ToString());
                }
                if (dt.Rows[0]["ACCEPT"].ToString() != "") {
                    entity.ACCEPT = decimal.Parse(dt.Rows[0]["ACCEPT"].ToString());
                }
                entity.WITHIN = dt.Rows[0]["WITHIN"].ToString();
                entity.NEXTWITHIN = dt.Rows[0]["NEXTWITHIN"].ToString();
                if (dt.Rows[0]["ACCEPTCAPTAIN"].ToString() != "") {
                    entity.ACCEPTCAPTAIN = decimal.Parse(dt.Rows[0]["ACCEPTCAPTAIN"].ToString());
                }
                if (dt.Rows[0]["SHIFTCAPTAIN"].ToString() != "") {
                    entity.SHIFTCAPTAIN = decimal.Parse(dt.Rows[0]["SHIFTCAPTAIN"].ToString());
                }
                entity.ACCEPTBUSNUMBER = dt.Rows[0]["ACCEPTBUSNUMBER"].ToString();
                if (dt.Rows[0]["TICKTIME"].ToString() != "") {
                    entity.TICKTIME = DateTime.Parse(dt.Rows[0]["TICKTIME"].ToString());
                }
                if (dt.Rows[0]["BUSKM"].ToString() != "") {
                    entity.BUSKM = decimal.Parse(dt.Rows[0]["BUSKM"].ToString());
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
            strSql.Append(" FROM BASE_PATROL ");
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
            strSql.Append(" FROM BASE_PATROL ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

