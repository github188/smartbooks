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
        #region 通用查询
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
            strSql.Append("PATROLID,ENDTIME,TRANSFER,ACCEPT,WITHIN,NEXTWITHIN,ACCEPTCAPTAIN,SHIFTCAPTAIN,ACCEPTBUSNUMBER,TICKTIME,BUSKM,DEPTID,GOODS,RESPUSER,PATROLUSER,BUSNUMBER,MILEAGE,WEATHER,LOG,BEGINTIME");
            strSql.Append(") values (");
            strSql.Append(":PATROLID,:ENDTIME,:TRANSFER,:ACCEPT,:WITHIN,:NEXTWITHIN,:ACCEPTCAPTAIN,:SHIFTCAPTAIN,:ACCEPTBUSNUMBER,:TICKTIME,:BUSKM,:DEPTID,:GOODS,:RESPUSER,:PATROLUSER,:BUSNUMBER,:MILEAGE,:WEATHER,:LOG,:BEGINTIME");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":PATROLID", OracleType.Number,4) ,            
                        new OracleParameter(":ENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":TRANSFER", OracleType.Number,4) ,            
                        new OracleParameter(":ACCEPT", OracleType.Number,4) ,            
                        new OracleParameter(":WITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":NEXTWITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":ACCEPTCAPTAIN", OracleType.VarChar,20) ,            
                        new OracleParameter(":SHIFTCAPTAIN", OracleType.VarChar,20) ,            
                        new OracleParameter(":ACCEPTBUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":BUSKM", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":GOODS", OracleType.VarChar,500) ,            
                        new OracleParameter(":RESPUSER", OracleType.VarChar,20) ,            
                        new OracleParameter(":PATROLUSER", OracleType.VarChar,20) ,            
                        new OracleParameter(":BUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":MILEAGE", OracleType.Number,4) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":LOG", OracleType.VarChar,500) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime)             
              
            };

            parameters[0].Value = entity.PATROLID;
            parameters[1].Value = entity.ENDTIME;
            parameters[2].Value = entity.TRANSFER;
            parameters[3].Value = entity.ACCEPT;
            parameters[4].Value = entity.WITHIN;
            parameters[5].Value = entity.NEXTWITHIN;
            parameters[6].Value = entity.ACCEPTCAPTAIN;
            parameters[7].Value = entity.SHIFTCAPTAIN;
            parameters[8].Value = entity.ACCEPTBUSNUMBER;
            parameters[9].Value = entity.TICKTIME;
            parameters[10].Value = entity.BUSKM;
            parameters[11].Value = entity.DEPTID;
            parameters[12].Value = entity.GOODS;
            parameters[13].Value = entity.RESPUSER;
            parameters[14].Value = entity.PATROLUSER;
            parameters[15].Value = entity.BUSNUMBER;
            parameters[16].Value = entity.MILEAGE;
            parameters[17].Value = entity.WEATHER;
            parameters[18].Value = entity.LOG;
            parameters[19].Value = entity.BEGINTIME;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_PATROL entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PATROL set ");

            strSql.Append(" PATROLID = :PATROLID , ");
            strSql.Append(" ENDTIME = :ENDTIME , ");
            strSql.Append(" TRANSFER = :TRANSFER , ");
            strSql.Append(" ACCEPT = :ACCEPT , ");
            strSql.Append(" WITHIN = :WITHIN , ");
            strSql.Append(" NEXTWITHIN = :NEXTWITHIN , ");
            strSql.Append(" ACCEPTCAPTAIN = :ACCEPTCAPTAIN , ");
            strSql.Append(" SHIFTCAPTAIN = :SHIFTCAPTAIN , ");
            strSql.Append(" ACCEPTBUSNUMBER = :ACCEPTBUSNUMBER , ");
            strSql.Append(" TICKTIME = :TICKTIME , ");
            strSql.Append(" BUSKM = :BUSKM , ");
            strSql.Append(" DEPTID = :DEPTID , ");
            strSql.Append(" GOODS = :GOODS , ");
            strSql.Append(" RESPUSER = :RESPUSER , ");
            strSql.Append(" PATROLUSER = :PATROLUSER , ");
            strSql.Append(" BUSNUMBER = :BUSNUMBER , ");
            strSql.Append(" MILEAGE = :MILEAGE , ");
            strSql.Append(" WEATHER = :WEATHER , ");
            strSql.Append(" LOG = :LOG , ");
            strSql.Append(" BEGINTIME = :BEGINTIME  ");
            strSql.Append(" where PATROLID=:PATROLID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":PATROLID", OracleType.Number,4) ,            
                        new OracleParameter(":ENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":TRANSFER", OracleType.Number,4) ,            
                        new OracleParameter(":ACCEPT", OracleType.Number,4) ,            
                        new OracleParameter(":WITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":NEXTWITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":ACCEPTCAPTAIN", OracleType.VarChar,20) ,            
                        new OracleParameter(":SHIFTCAPTAIN", OracleType.VarChar,20) ,            
                        new OracleParameter(":ACCEPTBUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":BUSKM", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":GOODS", OracleType.VarChar,500) ,            
                        new OracleParameter(":RESPUSER", OracleType.VarChar,20) ,            
                        new OracleParameter(":PATROLUSER", OracleType.VarChar,20) ,            
                        new OracleParameter(":BUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":MILEAGE", OracleType.Number,4) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":LOG", OracleType.VarChar,500) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime)             
              
            };

            parameters[20].Value = entity.PATROLID;
            parameters[21].Value = entity.ENDTIME;
            parameters[22].Value = entity.TRANSFER;
            parameters[23].Value = entity.ACCEPT;
            parameters[24].Value = entity.WITHIN;
            parameters[25].Value = entity.NEXTWITHIN;
            parameters[26].Value = entity.ACCEPTCAPTAIN;
            parameters[27].Value = entity.SHIFTCAPTAIN;
            parameters[28].Value = entity.ACCEPTBUSNUMBER;
            parameters[29].Value = entity.TICKTIME;
            parameters[30].Value = entity.BUSKM;
            parameters[31].Value = entity.DEPTID;
            parameters[32].Value = entity.GOODS;
            parameters[33].Value = entity.RESPUSER;
            parameters[34].Value = entity.PATROLUSER;
            parameters[35].Value = entity.BUSNUMBER;
            parameters[36].Value = entity.MILEAGE;
            parameters[37].Value = entity.WEATHER;
            parameters[38].Value = entity.LOG;
            parameters[39].Value = entity.BEGINTIME;
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
            strSql.Append("select PATROLID, ENDTIME, TRANSFER, ACCEPT, WITHIN, NEXTWITHIN, ACCEPTCAPTAIN, SHIFTCAPTAIN, ACCEPTBUSNUMBER, TICKTIME, BUSKM, DEPTID, GOODS, RESPUSER, PATROLUSER, BUSNUMBER, MILEAGE, WEATHER, LOG, BEGINTIME  ");
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
                entity.ACCEPTCAPTAIN = dt.Rows[0]["ACCEPTCAPTAIN"].ToString();
                entity.SHIFTCAPTAIN = dt.Rows[0]["SHIFTCAPTAIN"].ToString();
                entity.ACCEPTBUSNUMBER = dt.Rows[0]["ACCEPTBUSNUMBER"].ToString();
                if (dt.Rows[0]["TICKTIME"].ToString() != "") {
                    entity.TICKTIME = DateTime.Parse(dt.Rows[0]["TICKTIME"].ToString());
                }
                if (dt.Rows[0]["BUSKM"].ToString() != "") {
                    entity.BUSKM = decimal.Parse(dt.Rows[0]["BUSKM"].ToString());
                }
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
                }
                entity.GOODS = dt.Rows[0]["GOODS"].ToString();
                entity.RESPUSER = dt.Rows[0]["RESPUSER"].ToString();
                entity.PATROLUSER = dt.Rows[0]["PATROLUSER"].ToString();
                entity.BUSNUMBER = dt.Rows[0]["BUSNUMBER"].ToString();
                if (dt.Rows[0]["MILEAGE"].ToString() != "") {
                    entity.MILEAGE = decimal.Parse(dt.Rows[0]["MILEAGE"].ToString());
                }
                entity.WEATHER = dt.Rows[0]["WEATHER"].ToString();
                entity.LOG = dt.Rows[0]["LOG"].ToString();
                if (dt.Rows[0]["BEGINTIME"].ToString() != "") {
                    entity.BEGINTIME = DateTime.Parse(dt.Rows[0]["BEGINTIME"].ToString());
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

        #endregion

        /*
         * 修改说明:增加获取指定部门下巡逻日志
         * 修改标志:20120507 王亚
         */
        #region 自定义查询

        /// <summary>
        /// 获取指定时间范围内某部门下日志
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptCode">部门ID编号</param>
        /// <returns>日志数据</returns>
        public DataTable GetDeptLog(DateTime beginTime, DateTime endTime, int deptCode) {
            string procName = "PKG_PATROL_QUERY.proc_getdeptlog";
            OracleParameter[] param = new OracleParameter[4];

            param[0] = new OracleParameter();
            param[1] = new OracleParameter();
            param[2] = new OracleParameter();
            param[3] = new OracleParameter();

            param[0].Direction = ParameterDirection.Input;
            param[0].OracleType = OracleType.DateTime;
            param[0].ParameterName = "begintime";
            param[0].Value = beginTime;

            param[1].Direction = ParameterDirection.Input;
            param[1].OracleType = OracleType.DateTime;
            param[1].ParameterName = "endtime";
            param[1].Value = endTime;

            param[2].Direction = ParameterDirection.Input;
            param[2].OracleType = OracleType.Number;
            param[2].ParameterName = "dptcode";
            param[2].Value = deptCode;

            param[3].Direction = ParameterDirection.Output;
            param[3].OracleType = OracleType.Cursor;
            param[3].ParameterName = "out_cursor";

            return OracleHelper.RunProcedure(procName, param).Tables[0];
        }

        #endregion
    }
}

