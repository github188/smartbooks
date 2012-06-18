// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_DOCUMENT.cs
// 功能描述:档案信息表 -- 接口实现
//
// 创建标识：王 亚 2012-06-18
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;

    /// <summary>
    /// 档案信息表 -- 接口实现
    /// </summary>
    public partial class BASE_DOCUMENT : IBASE_DOCUMENT {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_DOCUMENT");
            strSql.Append(" where ");
            strSql.Append(" ID = :ID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            }
            else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_DOCUMENT model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_DOCUMENT(");
            strSql.Append("ID,YEAR,FONDSNO,CATALOGNUMBER,CASEFILENUMBER,RETENTION,TIELE,BEGINTIME,ENDTIME,NUMBEROFCOPIES,UNIT,ANNEX,DEPTCODE,TYPECODE");
            strSql.Append(") values (");
            strSql.Append(":ID,:YEAR,:FONDSNO,:CATALOGNUMBER,:CASEFILENUMBER,:RETENTION,:TIELE,:BEGINTIME,:ENDTIME,:NUMBEROFCOPIES,:UNIT,:ANNEX,:DEPTCODE,:TYPECODE");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":YEAR", OracleType.Number,4) ,            
                        new OracleParameter(":FONDSNO", OracleType.VarChar,50) ,            
                        new OracleParameter(":CATALOGNUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":CASEFILENUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":RETENTION", OracleType.Number,4) ,            
                        new OracleParameter(":TIELE", OracleType.VarChar,200) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":NUMBEROFCOPIES", OracleType.Number,4) ,            
                        new OracleParameter(":UNIT", OracleType.VarChar,50) ,            
                        new OracleParameter(":ANNEX", OracleType.VarChar,2000) ,            
                        new OracleParameter(":DEPTCODE", OracleType.Number,4) ,            
                        new OracleParameter(":TYPECODE", OracleType.Number,4)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.YEAR;
            parameters[2].Value = model.FONDSNO;
            parameters[3].Value = model.CATALOGNUMBER;
            parameters[4].Value = model.CASEFILENUMBER;
            parameters[5].Value = model.RETENTION;
            parameters[6].Value = model.TIELE;
            parameters[7].Value = model.BEGINTIME;
            parameters[8].Value = model.ENDTIME;
            parameters[9].Value = model.NUMBEROFCOPIES;
            parameters[10].Value = model.UNIT;
            parameters[11].Value = model.ANNEX;
            parameters[12].Value = model.DEPTCODE;
            parameters[13].Value = model.TYPECODE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_DOCUMENT model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_DOCUMENT set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" YEAR = :YEAR , ");
            strSql.Append(" FONDSNO = :FONDSNO , ");
            strSql.Append(" CATALOGNUMBER = :CATALOGNUMBER , ");
            strSql.Append(" CASEFILENUMBER = :CASEFILENUMBER , ");
            strSql.Append(" RETENTION = :RETENTION , ");
            strSql.Append(" TIELE = :TIELE , ");
            strSql.Append(" BEGINTIME = :BEGINTIME , ");
            strSql.Append(" ENDTIME = :ENDTIME , ");
            strSql.Append(" NUMBEROFCOPIES = :NUMBEROFCOPIES , ");
            strSql.Append(" UNIT = :UNIT , ");
            strSql.Append(" ANNEX = :ANNEX , ");
            strSql.Append(" DEPTCODE = :DEPTCODE , ");
            strSql.Append(" TYPECODE = :TYPECODE  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":YEAR", OracleType.Number,4) ,            
                        new OracleParameter(":FONDSNO", OracleType.VarChar,50) ,            
                        new OracleParameter(":CATALOGNUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":CASEFILENUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":RETENTION", OracleType.Number,4) ,            
                        new OracleParameter(":TIELE", OracleType.VarChar,200) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":NUMBEROFCOPIES", OracleType.Number,4) ,            
                        new OracleParameter(":UNIT", OracleType.VarChar,50) ,            
                        new OracleParameter(":ANNEX", OracleType.VarChar,2000) ,            
                        new OracleParameter(":DEPTCODE", OracleType.Number,4) ,            
                        new OracleParameter(":TYPECODE", OracleType.Number,4)             
              
            };

            parameters[14].Value = model.ID;
            parameters[15].Value = model.YEAR;
            parameters[16].Value = model.FONDSNO;
            parameters[17].Value = model.CATALOGNUMBER;
            parameters[18].Value = model.CASEFILENUMBER;
            parameters[19].Value = model.RETENTION;
            parameters[20].Value = model.TIELE;
            parameters[21].Value = model.BEGINTIME;
            parameters[22].Value = model.ENDTIME;
            parameters[23].Value = model.NUMBEROFCOPIES;
            parameters[24].Value = model.UNIT;
            parameters[25].Value = model.ANNEX;
            parameters[26].Value = model.DEPTCODE;
            parameters[27].Value = model.TYPECODE;
            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            }
            else {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_DOCUMENT ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            }
            else {
                return false;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.BASE_DOCUMENT GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, YEAR, FONDSNO, CATALOGNUMBER, CASEFILENUMBER, RETENTION, TIELE, BEGINTIME, ENDTIME, NUMBEROFCOPIES, UNIT, ANNEX, DEPTCODE, TYPECODE  ");
            strSql.Append("  from BASE_DOCUMENT ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_DOCUMENT entity = new Entity.BASE_DOCUMENT();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["YEAR"].ToString() != "") {
                    entity.YEAR = decimal.Parse(dt.Rows[0]["YEAR"].ToString());
                }
                entity.FONDSNO = dt.Rows[0]["FONDSNO"].ToString();
                entity.CATALOGNUMBER = dt.Rows[0]["CATALOGNUMBER"].ToString();
                entity.CASEFILENUMBER = dt.Rows[0]["CASEFILENUMBER"].ToString();
                if (dt.Rows[0]["RETENTION"].ToString() != "") {
                    entity.RETENTION = decimal.Parse(dt.Rows[0]["RETENTION"].ToString());
                }
                entity.TIELE = dt.Rows[0]["TIELE"].ToString();
                if (dt.Rows[0]["BEGINTIME"].ToString() != "") {
                    entity.BEGINTIME = DateTime.Parse(dt.Rows[0]["BEGINTIME"].ToString());
                }
                if (dt.Rows[0]["ENDTIME"].ToString() != "") {
                    entity.ENDTIME = DateTime.Parse(dt.Rows[0]["ENDTIME"].ToString());
                }
                if (dt.Rows[0]["NUMBEROFCOPIES"].ToString() != "") {
                    entity.NUMBEROFCOPIES = decimal.Parse(dt.Rows[0]["NUMBEROFCOPIES"].ToString());
                }
                entity.UNIT = dt.Rows[0]["UNIT"].ToString();
                entity.ANNEX = dt.Rows[0]["ANNEX"].ToString();
                if (dt.Rows[0]["DEPTCODE"].ToString() != "") {
                    entity.DEPTCODE = decimal.Parse(dt.Rows[0]["DEPTCODE"].ToString());
                }
                if (dt.Rows[0]["TYPECODE"].ToString() != "") {
                    entity.TYPECODE = decimal.Parse(dt.Rows[0]["TYPECODE"].ToString());
                }

                return entity;
            }
            else {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BASE_DOCUMENT ");
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
            strSql.Append(" FROM BASE_DOCUMENT ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

