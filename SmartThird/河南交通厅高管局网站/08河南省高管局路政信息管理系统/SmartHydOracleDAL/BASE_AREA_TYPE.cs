// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_AREA_TYPE.cs
// 功能描述:控制区违章类型表 -- 接口实现
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
    /// 控制区违章类型表 -- 接口实现
    /// </summary>
    public partial class BASE_AREA_TYPE : IBASE_AREA_TYPE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal TYPEID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_AREA_TYPE");
            strSql.Append(" where ");
            strSql.Append(" TYPEID = :TYPEID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":TYPEID", OracleType.Number,4)			};
            parameters[0].Value = TYPEID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_AREA_TYPE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_AREA_TYPE(");
            strSql.Append("TYPENAME,TYPEID");
            strSql.Append(") values (");
            strSql.Append(":TYPENAME,:TYPEID");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":TYPENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.TYPENAME;
            parameters[1].Value = entity.TYPEID;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_AREA_TYPE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_AREA_TYPE set ");

            strSql.Append(" TYPENAME = :TYPENAME , ");
            strSql.Append(" TYPEID = :TYPEID  ");
            strSql.Append(" where TYPEID=:TYPEID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":TYPENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.TYPENAME;
            parameters[1].Value = entity.TYPEID;
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
        public bool Delete(decimal TYPEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_AREA_TYPE ");
            strSql.Append(" where TYPEID=:TYPEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":TYPEID", OracleType.Number,4)			};
            parameters[0].Value = TYPEID;


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
        public Entity.BASE_AREA_TYPE GetEntity(decimal TYPEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TYPENAME, TYPEID  ");
            strSql.Append("  from BASE_AREA_TYPE ");
            strSql.Append(" where TYPEID=:TYPEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":TYPEID", OracleType.Number,4)			};
            parameters[0].Value = TYPEID;


            Entity.BASE_AREA_TYPE entity = new Entity.BASE_AREA_TYPE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                entity.TYPENAME = dt.Rows[0]["TYPENAME"].ToString();
                if (dt.Rows[0]["TYPEID"].ToString() != "") {
                    entity.TYPEID = decimal.Parse(dt.Rows[0]["TYPEID"].ToString());
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
            strSql.Append(" FROM BASE_AREA_TYPE ");
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
            strSql.Append(" FROM BASE_AREA_TYPE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

