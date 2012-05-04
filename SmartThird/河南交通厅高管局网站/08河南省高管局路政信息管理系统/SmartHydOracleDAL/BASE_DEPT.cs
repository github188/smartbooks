// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_DEPT.cs
// 功能描述:部门信息表 -- 接口实现
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
    /// 部门信息表 -- 接口实现
    /// </summary>
    public partial class BASE_DEPT : IBASE_DEPT {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal DEPTID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_DEPT");
            strSql.Append(" where ");
            strSql.Append(" DEPTID = :DEPTID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":DEPTID", OracleType.Number,4)			};
            parameters[0].Value = DEPTID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_DEPT entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_DEPT(");
            strSql.Append("DEPTID,DPTNAME,DPTINFO,PARENTID,STATUS");
            strSql.Append(") values (");
            strSql.Append(":DEPTID,:DPTNAME,:DPTINFO,:PARENTID,:STATUS");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":DPTNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":DPTINFO", OracleType.VarChar,50) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.DEPTID;
            parameters[1].Value = entity.DPTNAME;
            parameters[2].Value = entity.DPTINFO;
            parameters[3].Value = entity.PARENTID;
            parameters[4].Value = entity.STATUS;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_DEPT entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_DEPT set ");

            strSql.Append(" DEPTID = :DEPTID , ");
            strSql.Append(" DPTNAME = :DPTNAME , ");
            strSql.Append(" DPTINFO = :DPTINFO , ");
            strSql.Append(" PARENTID = :PARENTID , ");
            strSql.Append(" STATUS = :STATUS  ");
            strSql.Append(" where DEPTID=:DEPTID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":DPTNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":DPTINFO", OracleType.VarChar,50) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4)             
              
            };

            parameters[5].Value = entity.DEPTID;
            parameters[6].Value = entity.DPTNAME;
            parameters[7].Value = entity.DPTINFO;
            parameters[8].Value = entity.PARENTID;
            parameters[9].Value = entity.STATUS;
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
        public bool Delete(decimal DEPTID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_DEPT ");
            strSql.Append(" where DEPTID=:DEPTID ");
            OracleParameter[] parameters = {
					new OracleParameter(":DEPTID", OracleType.Number,4)			};
            parameters[0].Value = DEPTID;


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
        public Entity.BASE_DEPT GetEntity(decimal DEPTID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DEPTID, DPTNAME, DPTINFO, PARENTID, STATUS  ");
            strSql.Append("  from BASE_DEPT ");
            strSql.Append(" where DEPTID=:DEPTID ");
            OracleParameter[] parameters = {
					new OracleParameter(":DEPTID", OracleType.Number,4)			};
            parameters[0].Value = DEPTID;


            Entity.BASE_DEPT entity = new Entity.BASE_DEPT();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
                }
                entity.DPTNAME = dt.Rows[0]["DPTNAME"].ToString();
                entity.DPTINFO = dt.Rows[0]["DPTINFO"].ToString();
                if (dt.Rows[0]["PARENTID"].ToString() != "") {
                    entity.PARENTID = decimal.Parse(dt.Rows[0]["PARENTID"].ToString());
                }
                if (dt.Rows[0]["STATUS"].ToString() != "") {
                    entity.STATUS = decimal.Parse(dt.Rows[0]["STATUS"].ToString());
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
            strSql.Append(" FROM BASE_DEPT ");
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
            strSql.Append(" FROM BASE_DEPT ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

