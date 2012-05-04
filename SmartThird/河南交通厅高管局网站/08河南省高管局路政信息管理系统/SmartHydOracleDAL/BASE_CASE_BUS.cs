// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CASE_BUS.cs
// 功能描述:路产案件（车辆人员信息） -- 接口实现
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
    /// 路产案件（车辆人员信息） -- 接口实现
    /// </summary>
    public partial class BASE_CASE_BUS : IBASE_CASE_BUS {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CASE_BUS");
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
        public void Add(Entity.BASE_CASE_BUS entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_CASE_BUS(");
            strSql.Append("ID,PARTY,SEX,AGE,PHONE,DRIVING,CARDID,BUSTYPE,BUSNUMBER,LABEL,PATTERN,ADDRESS,ZIPCODE,ATTRIB,CASEID");
            strSql.Append(") values (");
            strSql.Append(":ID,:PARTY,:SEX,:AGE,:PHONE,:DRIVING,:CARDID,:BUSTYPE,:BUSNUMBER,:LABEL,:PATTERN,:ADDRESS,:ZIPCODE,:ATTRIB,:CASEID");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":PARTY", OracleType.VarChar,50) ,            
                        new OracleParameter(":SEX", OracleType.Number,4) ,            
                        new OracleParameter(":AGE", OracleType.Number,4) ,            
                        new OracleParameter(":PHONE", OracleType.VarChar,51) ,            
                        new OracleParameter(":DRIVING", OracleType.Number,4) ,            
                        new OracleParameter(":CARDID", OracleType.VarChar,16) ,            
                        new OracleParameter(":BUSTYPE", OracleType.VarChar,20) ,            
                        new OracleParameter(":BUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":LABEL", OracleType.VarChar,20) ,            
                        new OracleParameter(":PATTERN", OracleType.VarChar,20) ,            
                        new OracleParameter(":ADDRESS", OracleType.VarChar,80) ,            
                        new OracleParameter(":ZIPCODE", OracleType.VarChar,10) ,            
                        new OracleParameter(":ATTRIB", OracleType.VarChar,10) ,            
                        new OracleParameter(":CASEID", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.PARTY;
            parameters[2].Value = entity.SEX;
            parameters[3].Value = entity.AGE;
            parameters[4].Value = entity.PHONE;
            parameters[5].Value = entity.DRIVING;
            parameters[6].Value = entity.CARDID;
            parameters[7].Value = entity.BUSTYPE;
            parameters[8].Value = entity.BUSNUMBER;
            parameters[9].Value = entity.LABEL;
            parameters[10].Value = entity.PATTERN;
            parameters[11].Value = entity.ADDRESS;
            parameters[12].Value = entity.ZIPCODE;
            parameters[13].Value = entity.ATTRIB;
            parameters[14].Value = entity.CASEID;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_CASE_BUS entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CASE_BUS set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" PARTY = :PARTY , ");
            strSql.Append(" SEX = :SEX , ");
            strSql.Append(" AGE = :AGE , ");
            strSql.Append(" PHONE = :PHONE , ");
            strSql.Append(" DRIVING = :DRIVING , ");
            strSql.Append(" CARDID = :CARDID , ");
            strSql.Append(" BUSTYPE = :BUSTYPE , ");
            strSql.Append(" BUSNUMBER = :BUSNUMBER , ");
            strSql.Append(" LABEL = :LABEL , ");
            strSql.Append(" PATTERN = :PATTERN , ");
            strSql.Append(" ADDRESS = :ADDRESS , ");
            strSql.Append(" ZIPCODE = :ZIPCODE , ");
            strSql.Append(" ATTRIB = :ATTRIB , ");
            strSql.Append(" CASEID = :CASEID  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":PARTY", OracleType.VarChar,50) ,            
                        new OracleParameter(":SEX", OracleType.Number,4) ,            
                        new OracleParameter(":AGE", OracleType.Number,4) ,            
                        new OracleParameter(":PHONE", OracleType.VarChar,51) ,            
                        new OracleParameter(":DRIVING", OracleType.Number,4) ,            
                        new OracleParameter(":CARDID", OracleType.VarChar,16) ,            
                        new OracleParameter(":BUSTYPE", OracleType.VarChar,20) ,            
                        new OracleParameter(":BUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":LABEL", OracleType.VarChar,20) ,            
                        new OracleParameter(":PATTERN", OracleType.VarChar,20) ,            
                        new OracleParameter(":ADDRESS", OracleType.VarChar,80) ,            
                        new OracleParameter(":ZIPCODE", OracleType.VarChar,10) ,            
                        new OracleParameter(":ATTRIB", OracleType.VarChar,10) ,            
                        new OracleParameter(":CASEID", OracleType.Number,4)             
              
            };

            parameters[15].Value = entity.ID;
            parameters[16].Value = entity.PARTY;
            parameters[17].Value = entity.SEX;
            parameters[18].Value = entity.AGE;
            parameters[19].Value = entity.PHONE;
            parameters[20].Value = entity.DRIVING;
            parameters[21].Value = entity.CARDID;
            parameters[22].Value = entity.BUSTYPE;
            parameters[23].Value = entity.BUSNUMBER;
            parameters[24].Value = entity.LABEL;
            parameters[25].Value = entity.PATTERN;
            parameters[26].Value = entity.ADDRESS;
            parameters[27].Value = entity.ZIPCODE;
            parameters[28].Value = entity.ATTRIB;
            parameters[29].Value = entity.CASEID;
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
            strSql.Append("delete from BASE_CASE_BUS ");
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
        public Entity.BASE_CASE_BUS GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, PARTY, SEX, AGE, PHONE, DRIVING, CARDID, BUSTYPE, BUSNUMBER, LABEL, PATTERN, ADDRESS, ZIPCODE, ATTRIB, CASEID  ");
            strSql.Append("  from BASE_CASE_BUS ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_CASE_BUS entity = new Entity.BASE_CASE_BUS();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                entity.PARTY = dt.Rows[0]["PARTY"].ToString();
                if (dt.Rows[0]["SEX"].ToString() != "") {
                    entity.SEX = decimal.Parse(dt.Rows[0]["SEX"].ToString());
                }
                if (dt.Rows[0]["AGE"].ToString() != "") {
                    entity.AGE = decimal.Parse(dt.Rows[0]["AGE"].ToString());
                }
                entity.PHONE = dt.Rows[0]["PHONE"].ToString();
                if (dt.Rows[0]["DRIVING"].ToString() != "") {
                    entity.DRIVING = decimal.Parse(dt.Rows[0]["DRIVING"].ToString());
                }
                entity.CARDID = dt.Rows[0]["CARDID"].ToString();
                entity.BUSTYPE = dt.Rows[0]["BUSTYPE"].ToString();
                entity.BUSNUMBER = dt.Rows[0]["BUSNUMBER"].ToString();
                entity.LABEL = dt.Rows[0]["LABEL"].ToString();
                entity.PATTERN = dt.Rows[0]["PATTERN"].ToString();
                entity.ADDRESS = dt.Rows[0]["ADDRESS"].ToString();
                entity.ZIPCODE = dt.Rows[0]["ZIPCODE"].ToString();
                entity.ATTRIB = dt.Rows[0]["ATTRIB"].ToString();
                if (dt.Rows[0]["CASEID"].ToString() != "") {
                    entity.CASEID = decimal.Parse(dt.Rows[0]["CASEID"].ToString());
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
            strSql.Append(" FROM BASE_CASE_BUS ");
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
            strSql.Append(" FROM BASE_CASE_BUS ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

