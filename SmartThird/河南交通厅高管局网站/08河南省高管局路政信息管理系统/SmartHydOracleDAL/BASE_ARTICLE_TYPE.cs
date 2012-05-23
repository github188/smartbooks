// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE_TYPE.cs
// 功能描述:公文类别表 -- 接口实现
//
// 创建标识：王 亚 2012-05-18
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;

    /// <summary>
    /// 公文类别表 -- 接口实现
    /// </summary>
    public partial class BASE_ARTICLE_TYPE : IBASE_ARTICLE_TYPE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ARTICLE_TYPE");
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
        public void Add(Entity.BASE_ARTICLE_TYPE model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ARTICLE_TYPE(");
            strSql.Append("ID,TYPENAME,SUMMARY,STATUS,PARENT,SORT,DEPTID");
            strSql.Append(") values (");
            strSql.Append(":ID,:TYPENAME,:SUMMARY,:STATUS,:PARENT,:SORT,:DEPTID");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":TYPENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":SUMMARY", OracleType.VarChar,200) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":PARENT", OracleType.Number,4) ,            
                        new OracleParameter(":SORT", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.TYPENAME;
            parameters[2].Value = model.SUMMARY;
            parameters[3].Value = model.STATUS;
            parameters[4].Value = model.PARENT;
            parameters[5].Value = model.SORT;
            parameters[6].Value = model.DEPTID;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_ARTICLE_TYPE model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_ARTICLE_TYPE set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" TYPENAME = :TYPENAME , ");
            strSql.Append(" SUMMARY = :SUMMARY , ");
            strSql.Append(" STATUS = :STATUS , ");
            strSql.Append(" PARENT = :PARENT , ");
            strSql.Append(" SORT = :SORT , ");
            strSql.Append(" DEPTID = :DEPTID  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":TYPENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":SUMMARY", OracleType.VarChar,200) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4) ,            
                        new OracleParameter(":PARENT", OracleType.Number,4) ,            
                        new OracleParameter(":SORT", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.TYPENAME;
            parameters[2].Value = model.SUMMARY;
            parameters[3].Value = model.STATUS;
            parameters[4].Value = model.PARENT;
            parameters[5].Value = model.SORT;
            parameters[6].Value = model.DEPTID;
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
            strSql.Append("delete from BASE_ARTICLE_TYPE ");
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
        public Entity.BASE_ARTICLE_TYPE GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, TYPENAME, SUMMARY, STATUS, PARENT, SORT, DEPTID  ");
            strSql.Append("  from BASE_ARTICLE_TYPE ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_ARTICLE_TYPE entity = new Entity.BASE_ARTICLE_TYPE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                entity.TYPENAME = dt.Rows[0]["TYPENAME"].ToString();
                entity.SUMMARY = dt.Rows[0]["SUMMARY"].ToString();
                if (dt.Rows[0]["STATUS"].ToString() != "") {
                    entity.STATUS = decimal.Parse(dt.Rows[0]["STATUS"].ToString());
                }
                if (dt.Rows[0]["PARENT"].ToString() != "") {
                    entity.PARENT = decimal.Parse(dt.Rows[0]["PARENT"].ToString());
                }
                if (dt.Rows[0]["SORT"].ToString() != "") {
                    entity.SORT = decimal.Parse(dt.Rows[0]["SORT"].ToString());
                }
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
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
            strSql.Append(" FROM BASE_ARTICLE_TYPE ");
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
            strSql.Append(" FROM BASE_ARTICLE_TYPE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

