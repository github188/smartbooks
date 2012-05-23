// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USER_ROLE.cs
// 功能描述:用户角色信息表 -- 接口实现
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
    /// 用户角色信息表 -- 接口实现
    /// </summary>
    public partial class BASE_USER_ROLE : IBASE_USER_ROLE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal USERROLEID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_USER_ROLE");
            strSql.Append(" where ");
            strSql.Append(" USERROLEID = :USERROLEID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":USERROLEID", OracleType.Number,4)			};
            parameters[0].Value = USERROLEID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 确定用户权限是否存在
        /// </summary>
        /// <param name="USERID"></param>
        /// <returns></returns>
        public bool ExistsUserid(decimal USERID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_USER_ROLE");
            strSql.Append(" where ");
            strSql.Append("USERID = :USERID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.Number,4)			};
            parameters[0].Value = USERID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) < 0)//执行查询语句，返回-1
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
        public void Add(Entity.BASE_USER_ROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_USER_ROLE(");
            strSql.Append("USERROLEID,USERID,ROLEID,MENUID,ACTIONID");
            strSql.Append(") values (");
            strSql.Append(":USERROLEID,:USERID,:ROLEID,:MENUID,:ACTIONID");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":USERROLEID", OracleType.Number,4) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":ROLEID", OracleType.Number,4) ,            
                        new OracleParameter(":MENUID", OracleType.Number,4) ,            
                        new OracleParameter(":ACTIONID", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.USERROLEID;
            parameters[1].Value = entity.USERID;
            parameters[2].Value = entity.ROLEID;
            parameters[3].Value = entity.MENUID;
            parameters[4].Value = entity.ACTIONID;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_USER_ROLE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_USER_ROLE set ");

            strSql.Append(" USERROLEID = :USERROLEID , ");
            strSql.Append(" USERID = :USERID , ");
            strSql.Append(" ROLEID = :ROLEID , ");
            strSql.Append(" MENUID = :MENUID , ");
            strSql.Append(" ACTIONID = :ACTIONID  ");
            strSql.Append(" where USERROLEID=:USERROLEID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":USERROLEID", OracleType.Number,4) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":ROLEID", OracleType.Number,4) ,            
                        new OracleParameter(":MENUID", OracleType.Number,4) ,            
                        new OracleParameter(":ACTIONID", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.USERROLEID;
            parameters[1].Value = entity.USERID;
            parameters[2].Value = entity.ROLEID;
            parameters[3].Value = entity.MENUID;
            parameters[4].Value = entity.ACTIONID;
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
        public bool Delete(decimal USERROLEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_USER_ROLE ");
            strSql.Append(" where USERROLEID=:USERROLEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":USERROLEID", OracleType.Number,4)			};
            parameters[0].Value = USERROLEID;


            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 根据指定条件删除数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool deletelist(string strWhere)
        { 
        StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_USER_ROLE ");
            strSql.Append(" where ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.BASE_USER_ROLE GetEntity(decimal USERROLEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USERROLEID, USERID, ROLEID, MENUID, ACTIONID  ");
            strSql.Append("  from BASE_USER_ROLE ");
            strSql.Append(" where USERROLEID=:USERROLEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":USERROLEID", OracleType.Number,4)			};
            parameters[0].Value = USERROLEID;


            Entity.BASE_USER_ROLE entity = new Entity.BASE_USER_ROLE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["USERROLEID"].ToString() != "") {
                    entity.USERROLEID = decimal.Parse(dt.Rows[0]["USERROLEID"].ToString());
                }
                if (dt.Rows[0]["USERID"].ToString() != "") {
                    entity.USERID = decimal.Parse(dt.Rows[0]["USERID"].ToString());
                }
                if (dt.Rows[0]["ROLEID"].ToString() != "") {
                    entity.ROLEID = decimal.Parse(dt.Rows[0]["ROLEID"].ToString());
                }
                if (dt.Rows[0]["MENUID"].ToString() != "") {
                    entity.MENUID = decimal.Parse(dt.Rows[0]["MENUID"].ToString());
                }
                if (dt.Rows[0]["ACTIONID"].ToString() != "") {
                    entity.ACTIONID = decimal.Parse(dt.Rows[0]["ACTIONID"].ToString());
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
            strSql.Append(" FROM BASE_USER_ROLE ");
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
            strSql.Append(" FROM BASE_USER_ROLE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

