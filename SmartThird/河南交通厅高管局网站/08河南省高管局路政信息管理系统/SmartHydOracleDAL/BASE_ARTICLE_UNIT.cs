// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE_UNIT.cs
// 功能描述:公文发送单位表 -- 接口实现
//
// 创建标识：王 亚 2012-05-22
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;

    /// <summary>
    /// 公文发送单位表 -- 接口实现
    /// </summary>
    public partial class BASE_ARTICLE_UNIT : IBASE_ARTICLE_UNIT {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ARTICLE_UNIT");
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
        public void Add(Entity.BASE_ARTICLE_UNIT model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ARTICLE_UNIT(");
            strSql.Append("ID,ARTICLEID,DPTCODE,ISREAD,READTIME");
            strSql.Append(") values (");
            strSql.Append(":ID,:ARTICLEID,:DPTCODE,:ISREAD,:READTIME");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":ARTICLEID", OracleType.Number,4) ,            
                        new OracleParameter(":DPTCODE", OracleType.Number,4) ,            
                        new OracleParameter(":ISREAD", OracleType.Number,4) ,            
                        new OracleParameter(":READTIME", OracleType.DateTime)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.ARTICLEID;
            parameters[2].Value = model.DPTCODE;
            parameters[3].Value = model.ISREAD;
            parameters[4].Value = model.READTIME;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_ARTICLE_UNIT model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_ARTICLE_UNIT set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" ARTICLEID = :ARTICLEID , ");
            strSql.Append(" DPTCODE = :DPTCODE , ");
            strSql.Append(" ISREAD = :ISREAD , ");
            strSql.Append(" READTIME = :READTIME  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":ARTICLEID", OracleType.Number,4) ,            
                        new OracleParameter(":DPTCODE", OracleType.Number,4) ,            
                        new OracleParameter(":ISREAD", OracleType.Number,4) ,            
                        new OracleParameter(":READTIME", OracleType.DateTime)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.ARTICLEID;
            parameters[2].Value = model.DPTCODE;
            parameters[3].Value = model.ISREAD;
            parameters[4].Value = model.READTIME;
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
            strSql.Append("delete from BASE_ARTICLE_UNIT ");
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
        public Entity.BASE_ARTICLE_UNIT GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ARTICLEID, DPTCODE, ISREAD, READTIME  ");
            strSql.Append("  from BASE_ARTICLE_UNIT ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_ARTICLE_UNIT entity = new Entity.BASE_ARTICLE_UNIT();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["ARTICLEID"].ToString() != "") {
                    entity.ARTICLEID = decimal.Parse(dt.Rows[0]["ARTICLEID"].ToString());
                }
                if (dt.Rows[0]["DPTCODE"].ToString() != "") {
                    entity.DPTCODE = decimal.Parse(dt.Rows[0]["DPTCODE"].ToString());
                }
                if (dt.Rows[0]["ISREAD"].ToString() != "") {
                    entity.ISREAD = decimal.Parse(dt.Rows[0]["ISREAD"].ToString());
                }
                if (dt.Rows[0]["READTIME"].ToString() != "") {
                    entity.READTIME = DateTime.Parse(dt.Rows[0]["READTIME"].ToString());
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
            strSql.Append(" FROM BASE_ARTICLE_UNIT ");
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
            strSql.Append(" FROM BASE_ARTICLE_UNIT ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

