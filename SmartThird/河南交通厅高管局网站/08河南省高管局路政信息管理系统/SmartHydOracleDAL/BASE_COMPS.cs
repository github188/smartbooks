// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_COMPS.cs
// 功能描述:赔偿标准信息表 -- 接口实现
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
    /// 赔偿标准信息表 -- 接口实现
    /// </summary>
    public partial class BASE_COMPS : IBASE_COMPS {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_COMPS");
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
        public void Add(Entity.BASE_COMPS entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_COMPS(");
            strSql.Append("ID,COMPSNAME,UNIT,MONEY,REMARK");
            strSql.Append(") values (");
            strSql.Append(":ID,:COMPSNAME,:UNIT,:MONEY,:REMARK");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":COMPSNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":UNIT", OracleType.VarChar,10) ,            
                        new OracleParameter(":MONEY", OracleType.Number,4) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,50)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.COMPSNAME;
            parameters[2].Value = entity.UNIT;
            parameters[3].Value = entity.MONEY;
            parameters[4].Value = entity.REMARK;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_COMPS entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_COMPS set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" COMPSNAME = :COMPSNAME , ");
            strSql.Append(" UNIT = :UNIT , ");
            strSql.Append(" MONEY = :MONEY , ");
            strSql.Append(" REMARK = :REMARK  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":COMPSNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":UNIT", OracleType.VarChar,10) ,            
                        new OracleParameter(":MONEY", OracleType.Number,4) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,50)             
              
            };

            parameters[5].Value = entity.ID;
            parameters[6].Value = entity.COMPSNAME;
            parameters[7].Value = entity.UNIT;
            parameters[8].Value = entity.MONEY;
            parameters[9].Value = entity.REMARK;
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
            strSql.Append("delete from BASE_COMPS ");
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
        public Entity.BASE_COMPS GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, COMPSNAME, UNIT, MONEY, REMARK  ");
            strSql.Append("  from BASE_COMPS ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_COMPS entity = new Entity.BASE_COMPS();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                entity.COMPSNAME = dt.Rows[0]["COMPSNAME"].ToString();
                entity.UNIT = dt.Rows[0]["UNIT"].ToString();
                if (dt.Rows[0]["MONEY"].ToString() != "") {
                    entity.MONEY = decimal.Parse(dt.Rows[0]["MONEY"].ToString());
                }
                entity.REMARK = dt.Rows[0]["REMARK"].ToString();

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
            strSql.Append(" FROM BASE_COMPS ");
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
            strSql.Append(" FROM BASE_COMPS ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

