// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_OBSERVED.cs
// 功能描述:电子巡逻日志表 -- 接口实现
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
    /// 电子巡逻日志表 -- 接口实现
    /// </summary>
    public partial class BASE_OBSERVED : IBASE_OBSERVED {
        #region 通用查询接口
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal OBSERVEDID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_OBSERVED");
            strSql.Append(" where ");
            strSql.Append(" OBSERVEDID = :OBSERVEDID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":OBSERVEDID", OracleType.Number,4)			};
            parameters[0].Value = OBSERVEDID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_OBSERVED entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_OBSERVED(");

            strSql.Append("OBSERVEDID,PATROLUSER,WEATHER,BEGINTIME,ENDDATE,LOG,DEPTID,STATE,REMARK");
            strSql.Append(") values (");
            strSql.Append(":OBSERVEDID,:PATROLUSER,:WEATHER,:BEGINTIME,:ENDDATE,:LOG,:DEPTID,:STATE,:REMARK");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":OBSERVEDID", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLUSER", OracleType.VarChar,50) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDDATE", OracleType.DateTime) ,            
                        new OracleParameter(":LOG", OracleType.VarChar,500) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":STATE", OracleType.Number,4) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500)             
              
            };

            parameters[0].Value = entity.OBSERVEDID;
            parameters[1].Value = entity.PATROLUSER;
            parameters[2].Value = entity.WEATHER;
            parameters[3].Value = entity.BEGINTIME;
            parameters[4].Value = entity.ENDDATE;
            parameters[5].Value = entity.LOG;
            parameters[6].Value = entity.DEPTID;
            parameters[7].Value = entity.STATE;
            parameters[8].Value = entity.REMARK; 
            return OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_OBSERVED entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_OBSERVED set ");

            strSql.Append(" OBSERVEDID = :OBSERVEDID , ");
            strSql.Append(" PATROLUSER = :PATROLUSER , ");
            strSql.Append(" WEATHER = :WEATHER , ");
            strSql.Append(" BEGINTIME = :BEGINTIME , ");
            strSql.Append(" ENDDATE = :ENDDATE , ");
            strSql.Append(" LOG = :LOG , ");
            strSql.Append(" DEPTID = :DEPTID,");
            strSql.Append(" STATE = :STATE,");
            strSql.Append(" REMARK = :REMARK  ");  
            strSql.Append(" where OBSERVEDID=:OBSERVEDID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":OBSERVEDID", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLUSER", OracleType.VarChar,50) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDDATE", OracleType.DateTime) ,            
                        new OracleParameter(":LOG", OracleType.VarChar,500) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4), 
                        new OracleParameter(":STATE", OracleType.Number,4) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500)             
              
            };

            parameters[0].Value = entity.OBSERVEDID;
            parameters[1].Value = entity.PATROLUSER;
            parameters[2].Value = entity.WEATHER;
            parameters[3].Value = entity.BEGINTIME;
            parameters[4].Value = entity.ENDDATE;
            parameters[5].Value = entity.LOG;
            parameters[6].Value = entity.DEPTID;
            parameters[7].Value = entity.STATE;
            parameters[8].Value = entity.REMARK; 
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
        public bool Delete(decimal OBSERVEDID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_OBSERVED ");
            strSql.Append(" where OBSERVEDID=:OBSERVEDID ");
            OracleParameter[] parameters = {
					new OracleParameter(":OBSERVEDID", OracleType.Number,4)			};
            parameters[0].Value = OBSERVEDID;


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
        public Entity.BASE_OBSERVED GetEntity(decimal OBSERVEDID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OBSERVEDID, PATROLUSER, WEATHER, BEGINTIME, ENDDATE, LOG, DEPTID,STATE,REMARK");
            strSql.Append("  from BASE_OBSERVED ");
            strSql.Append(" where OBSERVEDID=:OBSERVEDID ");
            OracleParameter[] parameters = {
					new OracleParameter(":OBSERVEDID", OracleType.Number,4)			};
            parameters[0].Value = OBSERVEDID;


            Entity.BASE_OBSERVED entity = new Entity.BASE_OBSERVED();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["OBSERVEDID"].ToString() != "") {
                    entity.OBSERVEDID = decimal.Parse(dt.Rows[0]["OBSERVEDID"].ToString());
                }
                entity.PATROLUSER = dt.Rows[0]["PATROLUSER"].ToString();
                entity.WEATHER = dt.Rows[0]["WEATHER"].ToString();
                if (dt.Rows[0]["BEGINTIME"].ToString() != "") {
                    entity.BEGINTIME = DateTime.Parse(dt.Rows[0]["BEGINTIME"].ToString());
                }
                if (dt.Rows[0]["ENDDATE"].ToString() != "") {
                    entity.ENDDATE = DateTime.Parse(dt.Rows[0]["ENDDATE"].ToString());
                }
                entity.LOG = dt.Rows[0]["LOG"].ToString();
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
                }
                if (dt.Rows[0]["STATE"].ToString() != "")
                {
                    entity.STATE = decimal.Parse(dt.Rows[0]["STATE"].ToString());
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
            strSql.Append(" FROM BASE_OBSERVED ");
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
            strSql.Append(" FROM BASE_OBSERVED ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }
        #endregion

        #region 自定义数据查询

        /// <summary>
        /// 根据指定时间范围，获取某个部门下的电子巡逻日志数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptCode">部门ID</param>
        /// <returns>电子巡逻日志数据</returns>
        public DataTable GetDeptLog(DateTime beginTime, DateTime endTime, int deptCode,int state)
        {
            StringBuilder where = new StringBuilder();
            where.Append("SELECT b.observedid, a.dptname, b.patroluser, b.weather, b.begintime, b.enddate, b.LOG, b.deptid ");
            where.Append("FROM base_dept a, base_observed b ");
            where.Append("WHERE a.deptid = b.deptid ");
            where.AppendFormat("AND b.begintime >= TO_DATE ('{0}', 'yyyy-mm-dd') ", beginTime.ToString("yyyy-MM-dd"));
            where.AppendFormat("AND b.enddate <= TO_DATE ('{0}', 'yyyy-mm-dd') ", endTime.ToString("yyyy-MM-dd"));
            where.AppendFormat("AND b.deptid = {0}", deptCode.ToString());
            where.AppendFormat("AND b.state = {0}", state.ToString());

            return OracleHelper.Query(where.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据指定条件，获取某个部门下的电子巡逻日志数据
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetLogObserved(string strwhere)
        {
            StringBuilder where = new StringBuilder();
            where.Append("SELECT b.observedid, a.dptname, b.patroluser, b.weather, b.begintime, b.enddate, b.LOG, b.deptid ");
            where.Append("FROM base_dept a, base_observed b ");
            where.Append("WHERE a.deptid = b.deptid ");
            where.AppendFormat("AND "+strwhere);

            return OracleHelper.Query(where.ToString()).Tables[0];
        }

        #endregion
    }
}

