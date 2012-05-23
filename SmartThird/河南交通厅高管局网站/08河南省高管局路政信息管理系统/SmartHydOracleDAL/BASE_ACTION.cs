// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ACTION.cs
// 功能描述:动作信息表 -- 接口实现
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
    /// 动作信息表 -- 接口实现
    /// </summary>
    public partial class BASE_ACTION : IBASE_ACTION {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ACTIONID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ACTION");
            strSql.Append(" where ");
            strSql.Append(" ACTIONID = :ACTIONID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":ACTIONID", OracleType.Number,4)			};
            parameters[0].Value = ACTIONID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_ACTION entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ACTION(");
            strSql.Append("ACTIONID,ACTIONNAME,STATUS,ACTIONINFO");
            strSql.Append(") values (");
            strSql.Append(":ACTIONID,:ACTIONNAME,:STATUS,:ACTIONINFO");
            strSql.Append(") ");


            OracleParameter[] parameters = {
			            new OracleParameter(":ACTIONID", OracleType.Number,4) ,            
                        new OracleParameter(":ACTIONNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":ACTIONINFO", OracleType.VarChar,50)             
              
            };

            parameters[0].Value = entity.ACTIONID;
            parameters[1].Value = entity.ACTIONNAME;
            parameters[2].Value = entity.STATUS;
            parameters[3].Value = entity.ACTIONINFO;

            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_ACTION entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_ACTION set ");

            strSql.Append(" ACTIONID = :ACTIONID , ");
            strSql.Append(" ACTIONNAME = :ACTIONNAME , ");
            strSql.Append(" STATUS = :STATUS , ");
            strSql.Append(" ACTIONINFO = :ACTIONINFO  ");
            strSql.Append(" where ACTIONID=:ACTIONID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ACTIONID", OracleType.Number,4) ,            
                        new OracleParameter(":ACTIONNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":ACTIONINFO", OracleType.VarChar,50)             
              
            };

            parameters[0].Value = entity.ACTIONID;
            parameters[1].Value = entity.ACTIONNAME;
            parameters[2].Value = entity.STATUS;
            parameters[3].Value = entity.ACTIONINFO;
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
        public bool Delete(decimal ACTIONID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ACTION ");
            strSql.Append(" where ACTIONID=:ACTIONID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ACTIONID", OracleType.Number,4)			};
            parameters[0].Value = ACTIONID;


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
        public Entity.BASE_ACTION GetEntity(decimal ACTIONID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ACTIONID, ACTIONNAME, STATUS, ACTIONINFO  ");
            strSql.Append("  from BASE_ACTION ");
            strSql.Append(" where ACTIONID=:ACTIONID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ACTIONID", OracleType.Number,4)			};
            parameters[0].Value = ACTIONID;


            Entity.BASE_ACTION entity = new Entity.BASE_ACTION();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ACTIONID"].ToString() != "") {
                    entity.ACTIONID = decimal.Parse(dt.Rows[0]["ACTIONID"].ToString());
                }
                entity.ACTIONNAME = dt.Rows[0]["ACTIONNAME"].ToString();
                if (dt.Rows[0]["STATUS"].ToString() != "") {
                    entity.STATUS = decimal.Parse(dt.Rows[0]["STATUS"].ToString());
                }
                entity.ACTIONINFO = dt.Rows[0]["ACTIONINFO"].ToString();

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
            strSql.Append(" FROM BASE_ACTION ");
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
            strSql.Append(" FROM BASE_ACTION ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

