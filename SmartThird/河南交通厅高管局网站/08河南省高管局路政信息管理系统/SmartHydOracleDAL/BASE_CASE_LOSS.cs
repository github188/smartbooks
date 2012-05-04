// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CASE_LOSS.cs
// 功能描述:路产案件损失表 -- 接口实现
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
    /// 路产案件损失表 -- 接口实现
    /// </summary>
    public partial class BASE_CASE_LOSS : IBASE_CASE_LOSS {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CASE_LOSS");
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
        public void Add(Entity.BASE_CASE_LOSS entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_CASE_LOSS(");
            strSql.Append("ID,COMPSID,CASEID,AMOUNT");
            strSql.Append(") values (");
            strSql.Append(":ID,:COMPSID,:CASEID,:AMOUNT");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":COMPSID", OracleType.Number,4) ,            
                        new OracleParameter(":CASEID", OracleType.Number,4) ,            
                        new OracleParameter(":AMOUNT", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.COMPSID;
            parameters[2].Value = entity.CASEID;
            parameters[3].Value = entity.AMOUNT;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_CASE_LOSS entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CASE_LOSS set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" COMPSID = :COMPSID , ");
            strSql.Append(" CASEID = :CASEID , ");
            strSql.Append(" AMOUNT = :AMOUNT  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":COMPSID", OracleType.Number,4) ,            
                        new OracleParameter(":CASEID", OracleType.Number,4) ,            
                        new OracleParameter(":AMOUNT", OracleType.Number,4)             
              
            };

            parameters[4].Value = entity.ID;
            parameters[5].Value = entity.COMPSID;
            parameters[6].Value = entity.CASEID;
            parameters[7].Value = entity.AMOUNT;
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
            strSql.Append("delete from BASE_CASE_LOSS ");
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
        public Entity.BASE_CASE_LOSS GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, COMPSID, CASEID, AMOUNT  ");
            strSql.Append("  from BASE_CASE_LOSS ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_CASE_LOSS entity = new Entity.BASE_CASE_LOSS();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["COMPSID"].ToString() != "") {
                    entity.COMPSID = decimal.Parse(dt.Rows[0]["COMPSID"].ToString());
                }
                if (dt.Rows[0]["CASEID"].ToString() != "") {
                    entity.CASEID = decimal.Parse(dt.Rows[0]["CASEID"].ToString());
                }
                if (dt.Rows[0]["AMOUNT"].ToString() != "") {
                    entity.AMOUNT = decimal.Parse(dt.Rows[0]["AMOUNT"].ToString());
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
            strSql.Append(" FROM BASE_CASE_LOSS ");
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
            strSql.Append(" FROM BASE_CASE_LOSS ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

