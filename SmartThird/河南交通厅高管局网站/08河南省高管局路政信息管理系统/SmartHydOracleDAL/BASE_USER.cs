﻿// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USER.cs
// 功能描述:用户信息表 -- 接口实现
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
    /// 用户信息表 -- 接口实现
    /// </summary>
    public partial class BASE_USER : IBASE_USER {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal USERID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_USER");
            strSql.Append(" where ");
            strSql.Append(" USERID = :USERID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.Number,4)			};
            parameters[0].Value = USERID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_USER entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_USER(");
            strSql.Append("USERID,USERNAME,USERPWD,PARENTID,SEX,DEPTID,BIRTHDAY,DEGREE,FACE,IDNUMBER,JOBNUMBER,PHOTO,PROF,REMARK,STSTUS");
            strSql.Append(") values (");
            strSql.Append(":USERID,:USERNAME,:USERPWD,:PARENTID,:SEX,:DEPTID,:BIRTHDAY,:DEGREE,:FACE,:IDNUMBER,:JOBNUMBER,:PHOTO,:PROF,:REMARK,:STSTUS");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":USERNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":USERPWD", OracleType.VarChar,32) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":SEX", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":BIRTHDAY", OracleType.DateTime) ,            
                        new OracleParameter(":DEGREE", OracleType.VarChar,50) ,            
                        new OracleParameter(":FACE", OracleType.VarChar,50) ,            
                        new OracleParameter(":IDNUMBER", OracleType.VarChar,18) ,            
                        new OracleParameter(":JOBNUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":PHOTO", OracleType.VarChar,200) ,            
                        new OracleParameter(":PROF", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,50) ,            
                        new OracleParameter(":STSTUS", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.USERID;
            parameters[1].Value = entity.USERNAME;
            parameters[2].Value = entity.USERPWD;
            parameters[3].Value = entity.PARENTID;
            parameters[4].Value = entity.SEX;
            parameters[5].Value = entity.DEPTID;
            parameters[6].Value = entity.BIRTHDAY;
            parameters[7].Value = entity.DEGREE;
            parameters[8].Value = entity.FACE;
            parameters[9].Value = entity.IDNUMBER;
            parameters[10].Value = entity.JOBNUMBER;
            parameters[11].Value = entity.PHOTO;
            parameters[12].Value = entity.PROF;
            parameters[13].Value = entity.REMARK;
            parameters[14].Value = entity.STSTUS;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_USER entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_USER set ");

            strSql.Append(" USERID = :USERID , ");
            strSql.Append(" USERNAME = :USERNAME , ");
            strSql.Append(" USERPWD = :USERPWD , ");
            strSql.Append(" PARENTID = :PARENTID , ");
            strSql.Append(" SEX = :SEX , ");
            strSql.Append(" DEPTID = :DEPTID , ");
            strSql.Append(" BIRTHDAY = :BIRTHDAY , ");
            strSql.Append(" DEGREE = :DEGREE , ");
            strSql.Append(" FACE = :FACE , ");
            strSql.Append(" IDNUMBER = :IDNUMBER , ");
            strSql.Append(" JOBNUMBER = :JOBNUMBER , ");
            strSql.Append(" PHOTO = :PHOTO , ");
            strSql.Append(" PROF = :PROF , ");
            strSql.Append(" REMARK = :REMARK , ");
            strSql.Append(" STSTUS = :STSTUS  ");
            strSql.Append(" where USERID=:USERID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":USERNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":USERPWD", OracleType.VarChar,32) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":SEX", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":BIRTHDAY", OracleType.DateTime) ,            
                        new OracleParameter(":DEGREE", OracleType.VarChar,50) ,            
                        new OracleParameter(":FACE", OracleType.VarChar,50) ,            
                        new OracleParameter(":IDNUMBER", OracleType.VarChar,18) ,            
                        new OracleParameter(":JOBNUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":PHOTO", OracleType.VarChar,200) ,            
                        new OracleParameter(":PROF", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,50) ,            
                        new OracleParameter(":STSTUS", OracleType.Number,4)             
              
            };

            parameters[15].Value = entity.USERID;
            parameters[16].Value = entity.USERNAME;
            parameters[17].Value = entity.USERPWD;
            parameters[18].Value = entity.PARENTID;
            parameters[19].Value = entity.SEX;
            parameters[20].Value = entity.DEPTID;
            parameters[21].Value = entity.BIRTHDAY;
            parameters[22].Value = entity.DEGREE;
            parameters[23].Value = entity.FACE;
            parameters[24].Value = entity.IDNUMBER;
            parameters[25].Value = entity.JOBNUMBER;
            parameters[26].Value = entity.PHOTO;
            parameters[27].Value = entity.PROF;
            parameters[28].Value = entity.REMARK;
            parameters[29].Value = entity.STSTUS;
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
        public bool Delete(decimal USERID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_USER ");
            strSql.Append(" where USERID=:USERID ");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.Number,4)			};
            parameters[0].Value = USERID;


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
        public Entity.BASE_USER GetEntity(decimal USERID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USERID, USERNAME, USERPWD, PARENTID, SEX, DEPTID, BIRTHDAY, DEGREE, FACE, IDNUMBER, JOBNUMBER, PHOTO, PROF, REMARK, STSTUS  ");
            strSql.Append("  from BASE_USER ");
            strSql.Append(" where USERID=:USERID ");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleType.Number,4)			};
            parameters[0].Value = USERID;


            Entity.BASE_USER entity = new Entity.BASE_USER();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["USERID"].ToString() != "") {
                    entity.USERID = decimal.Parse(dt.Rows[0]["USERID"].ToString());
                }
                entity.USERNAME = dt.Rows[0]["USERNAME"].ToString();
                entity.USERPWD = dt.Rows[0]["USERPWD"].ToString();
                if (dt.Rows[0]["PARENTID"].ToString() != "") {
                    entity.PARENTID = decimal.Parse(dt.Rows[0]["PARENTID"].ToString());
                }
                if (dt.Rows[0]["SEX"].ToString() != "") {
                    entity.SEX = decimal.Parse(dt.Rows[0]["SEX"].ToString());
                }
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
                }
                if (dt.Rows[0]["BIRTHDAY"].ToString() != "") {
                    entity.BIRTHDAY = DateTime.Parse(dt.Rows[0]["BIRTHDAY"].ToString());
                }
                entity.DEGREE = dt.Rows[0]["DEGREE"].ToString();
                entity.FACE = dt.Rows[0]["FACE"].ToString();
                entity.IDNUMBER = dt.Rows[0]["IDNUMBER"].ToString();
                entity.JOBNUMBER = dt.Rows[0]["JOBNUMBER"].ToString();
                entity.PHOTO = dt.Rows[0]["PHOTO"].ToString();
                entity.PROF = dt.Rows[0]["PROF"].ToString();
                entity.REMARK = dt.Rows[0]["REMARK"].ToString();
                if (dt.Rows[0]["STSTUS"].ToString() != "") {
                    entity.STSTUS = decimal.Parse(dt.Rows[0]["STSTUS"].ToString());
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
            strSql.Append(" FROM BASE_USER ");
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
            strSql.Append(" FROM BASE_USER ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

