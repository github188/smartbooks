// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROLE.cs
// 功能描述:角色信息表 -- 接口实现
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
    /// 角色信息表 -- 接口实现
    /// </summary>
    public partial class BASE_ROLE : IBASE_ROLE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ROLEID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ROLE");
            strSql.Append(" where ");
            strSql.Append(" ROLEID = :ROLEID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":ROLEID", OracleType.Number,4)			};
            parameters[0].Value = ROLEID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_ROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ROLE(");
            strSql.Append("ROLEID,ROLENAME,ROLEINFO");
            strSql.Append(") values (");
            strSql.Append(":ROLEID,:ROLENAME,:ROLEINFO");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ROLEID", OracleType.Number,4) ,            
                        new OracleParameter(":ROLENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":ROLEINFO", OracleType.VarChar,20)             
              
            };

            parameters[0].Value = entity.ROLEID;
            parameters[1].Value = entity.ROLENAME;
            parameters[2].Value = entity.ROLEINFO;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_ROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_ROLE set ");

            strSql.Append(" ROLEID = :ROLEID , ");
            strSql.Append(" ROLENAME = :ROLENAME , ");
            strSql.Append(" ROLEINFO = :ROLEINFO  ");
            strSql.Append(" where ROLEID=:ROLEID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ROLEID", OracleType.Number,4) ,            
                        new OracleParameter(":ROLENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":ROLEINFO", OracleType.VarChar,20)             
              
            };

            parameters[0].Value = entity.ROLEID;
            parameters[1].Value = entity.ROLENAME;
            parameters[2].Value = entity.ROLEINFO;
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
        public bool Delete(decimal ROLEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ROLE ");
            strSql.Append(" where ROLEID=:ROLEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ROLEID", OracleType.Number,4)			};
            parameters[0].Value = ROLEID;


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
        public Entity.BASE_ROLE GetEntity(decimal ROLEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROLEID, ROLENAME, ROLEINFO  ");
            strSql.Append("  from BASE_ROLE ");
            strSql.Append(" where ROLEID=:ROLEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ROLEID", OracleType.Number,4)			};
            parameters[0].Value = ROLEID;


            Entity.BASE_ROLE entity = new Entity.BASE_ROLE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ROLEID"].ToString() != "") {
                    entity.ROLEID = decimal.Parse(dt.Rows[0]["ROLEID"].ToString());
                }
                entity.ROLENAME = dt.Rows[0]["ROLENAME"].ToString();
                entity.ROLEINFO = dt.Rows[0]["ROLEINFO"].ToString();

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
            strSql.Append(" FROM BASE_ROLE ");
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
            strSql.Append(" FROM BASE_ROLE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

