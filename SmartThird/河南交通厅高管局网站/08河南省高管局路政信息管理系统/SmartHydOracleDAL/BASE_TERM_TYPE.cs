// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_TERM_TYPE.cs
// 功能描述:装备类型表 -- 接口实现
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
    /// 装备类型表 -- 接口实现
    /// </summary>
    public partial class BASE_TERM_TYPE : IBASE_TERM_TYPE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal TYPEID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_TERM_TYPE");
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
        public void Add(Entity.BASE_TERM_TYPE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_TERM_TYPE(");
            strSql.Append("TYPEID,TYPENAME");
            strSql.Append(") values (");
            strSql.Append(":TYPEID,:TYPENAME");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":TYPEID", OracleType.Number,4) ,            
                        new OracleParameter(":TYPENAME", OracleType.VarChar,50)             
              
            };

            parameters[0].Value = entity.TYPEID;
            parameters[1].Value = entity.TYPENAME;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_TERM_TYPE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_TERM_TYPE set ");

            strSql.Append(" TYPEID = :TYPEID , ");
            strSql.Append(" TYPENAME = :TYPENAME  ");
            strSql.Append(" where TYPEID=:TYPEID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":TYPEID", OracleType.Number,4) ,            
                        new OracleParameter(":TYPENAME", OracleType.VarChar,50)             
              
            };

            parameters[2].Value = entity.TYPEID;
            parameters[3].Value = entity.TYPENAME;
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
            strSql.Append("delete from BASE_TERM_TYPE ");
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
        public Entity.BASE_TERM_TYPE GetEntity(decimal TYPEID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TYPEID, TYPENAME  ");
            strSql.Append("  from BASE_TERM_TYPE ");
            strSql.Append(" where TYPEID=:TYPEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":TYPEID", OracleType.Number,4)			};
            parameters[0].Value = TYPEID;


            Entity.BASE_TERM_TYPE entity = new Entity.BASE_TERM_TYPE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["TYPEID"].ToString() != "") {
                    entity.TYPEID = decimal.Parse(dt.Rows[0]["TYPEID"].ToString());
                }
                entity.TYPENAME = dt.Rows[0]["TYPENAME"].ToString();

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
            strSql.Append(" FROM BASE_TERM_TYPE ");
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
            strSql.Append(" FROM BASE_TERM_TYPE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }

        #region 自定义查询
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList() {
            return OracleHelper.Query("SELECT * FROM BASE_TERM_TYPE").Tables[0];
        }
        #endregion
    }
}

