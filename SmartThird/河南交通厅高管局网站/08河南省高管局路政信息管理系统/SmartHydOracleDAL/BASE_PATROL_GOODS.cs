// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PATROL_GOODS.cs
// 功能描述:移交器材表 -- 接口实现
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
    /// 移交器材表 -- 接口实现
    /// </summary>
    public partial class BASE_PATROL_GOODS : IBASE_PATROL_GOODS {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal PATROLGOODSID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PATROL_GOODS");
            strSql.Append(" where ");
            strSql.Append(" PATROLGOODSID = :PATROLGOODSID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":PATROLGOODSID", OracleType.Number,4)			};
            parameters[0].Value = PATROLGOODSID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_PATROL_GOODS entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_PATROL_GOODS(");
            strSql.Append("PATROLGOODSID,PATROLID,AMOUNT,TOOLNAME");
            strSql.Append(") values (");
            strSql.Append(":PATROLGOODSID,:PATROLID,:AMOUNT,:TOOLNAME");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":PATROLGOODSID", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLID", OracleType.Number,4) ,            
                        new OracleParameter(":AMOUNT", OracleType.Number,4) ,            
                        new OracleParameter(":TOOLNAME", OracleType.VarChar,50)             
              
            };

            parameters[0].Value = entity.PATROLGOODSID;
            parameters[1].Value = entity.PATROLID;
            parameters[2].Value = entity.AMOUNT;
            parameters[3].Value = entity.TOOLNAME;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_PATROL_GOODS entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PATROL_GOODS set ");

            strSql.Append(" PATROLGOODSID = :PATROLGOODSID , ");
            strSql.Append(" PATROLID = :PATROLID , ");
            strSql.Append(" AMOUNT = :AMOUNT , ");
            strSql.Append(" TOOLNAME = :TOOLNAME  ");
            strSql.Append(" where PATROLGOODSID=:PATROLGOODSID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":PATROLGOODSID", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLID", OracleType.Number,4) ,            
                        new OracleParameter(":AMOUNT", OracleType.Number,4) ,            
                        new OracleParameter(":TOOLNAME", OracleType.VarChar,50)             
              
            };

            parameters[4].Value = entity.PATROLGOODSID;
            parameters[5].Value = entity.PATROLID;
            parameters[6].Value = entity.AMOUNT;
            parameters[7].Value = entity.TOOLNAME;
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
        public bool Delete(decimal PATROLGOODSID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_PATROL_GOODS ");
            strSql.Append(" where PATROLGOODSID=:PATROLGOODSID ");
            OracleParameter[] parameters = {
					new OracleParameter(":PATROLGOODSID", OracleType.Number,4)			};
            parameters[0].Value = PATROLGOODSID;


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
        public Entity.BASE_PATROL_GOODS GetEntity(decimal PATROLGOODSID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PATROLGOODSID, PATROLID, AMOUNT, TOOLNAME  ");
            strSql.Append("  from BASE_PATROL_GOODS ");
            strSql.Append(" where PATROLGOODSID=:PATROLGOODSID ");
            OracleParameter[] parameters = {
					new OracleParameter(":PATROLGOODSID", OracleType.Number,4)			};
            parameters[0].Value = PATROLGOODSID;


            Entity.BASE_PATROL_GOODS entity = new Entity.BASE_PATROL_GOODS();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["PATROLGOODSID"].ToString() != "") {
                    entity.PATROLGOODSID = decimal.Parse(dt.Rows[0]["PATROLGOODSID"].ToString());
                }
                if (dt.Rows[0]["PATROLID"].ToString() != "") {
                    entity.PATROLID = decimal.Parse(dt.Rows[0]["PATROLID"].ToString());
                }
                if (dt.Rows[0]["AMOUNT"].ToString() != "") {
                    entity.AMOUNT = decimal.Parse(dt.Rows[0]["AMOUNT"].ToString());
                }
                entity.TOOLNAME = dt.Rows[0]["TOOLNAME"].ToString();

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
            strSql.Append(" FROM BASE_PATROL_GOODS ");
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
            strSql.Append(" FROM BASE_PATROL_GOODS ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

