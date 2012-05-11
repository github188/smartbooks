// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USER.cs
// 功能描述:用户信息表 -- 接口实现
//
// 创建标识：王 亚 2012-05-10
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
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
        public void Add(Entity.BASE_USER model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_USER(");
            strSql.Append("USERID,IDNUMBER,JOBNUMBER,PHOTO,PROF,REMARK,STSTUS,PHONE,USERNAME,USERPWD,PARENTID,SEX,DEPTID,BIRTHDAY,DEGREE,FACE");
            strSql.Append(") values (");
            strSql.Append(":USERID,:IDNUMBER,:JOBNUMBER,:PHOTO,:PROF,:REMARK,:STSTUS,:PHONE,:USERNAME,:USERPWD,:PARENTID,:SEX,:DEPTID,:BIRTHDAY,:DEGREE,:FACE");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":IDNUMBER", OracleType.VarChar,18) ,            
                        new OracleParameter(":JOBNUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":PHOTO", OracleType.VarChar,200) ,            
                        new OracleParameter(":PROF", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,50) ,            
                        new OracleParameter(":STSTUS", OracleType.Number,4) ,            
                        new OracleParameter(":PHONE", OracleType.VarChar,50) ,            
                        new OracleParameter(":USERNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":USERPWD", OracleType.VarChar,32) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":SEX", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":BIRTHDAY", OracleType.DateTime) ,            
                        new OracleParameter(":DEGREE", OracleType.VarChar,50) ,            
                        new OracleParameter(":FACE", OracleType.VarChar,50)             
              
            };

            parameters[0].Value = model.USERID;
            parameters[1].Value = model.IDNUMBER;
            parameters[2].Value = model.JOBNUMBER;
            parameters[3].Value = model.PHOTO;
            parameters[4].Value = model.PROF;
            parameters[5].Value = model.REMARK;
            parameters[6].Value = model.STSTUS;
            parameters[7].Value = model.PHONE;
            parameters[8].Value = model.USERNAME;
            parameters[9].Value = model.USERPWD;
            parameters[10].Value = model.PARENTID;
            parameters[11].Value = model.SEX;
            parameters[12].Value = model.DEPTID;
            parameters[13].Value = model.BIRTHDAY;
            parameters[14].Value = model.DEGREE;
            parameters[15].Value = model.FACE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_USER model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_USER set ");

            strSql.Append(" USERID = :USERID , ");
            strSql.Append(" IDNUMBER = :IDNUMBER , ");
            strSql.Append(" JOBNUMBER = :JOBNUMBER , ");
            strSql.Append(" PHOTO = :PHOTO , ");
            strSql.Append(" PROF = :PROF , ");
            strSql.Append(" REMARK = :REMARK , ");
            strSql.Append(" STSTUS = :STSTUS , ");
            strSql.Append(" PHONE = :PHONE , ");
            strSql.Append(" USERNAME = :USERNAME , ");
            strSql.Append(" USERPWD = :USERPWD , ");
            strSql.Append(" PARENTID = :PARENTID , ");
            strSql.Append(" SEX = :SEX , ");
            strSql.Append(" DEPTID = :DEPTID , ");
            strSql.Append(" BIRTHDAY = :BIRTHDAY , ");
            strSql.Append(" DEGREE = :DEGREE , ");
            strSql.Append(" FACE = :FACE  ");
            strSql.Append(" where USERID=:USERID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":IDNUMBER", OracleType.VarChar,18) ,            
                        new OracleParameter(":JOBNUMBER", OracleType.VarChar,50) ,            
                        new OracleParameter(":PHOTO", OracleType.VarChar,200) ,            
                        new OracleParameter(":PROF", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,50) ,            
                        new OracleParameter(":STSTUS", OracleType.Number,4) ,            
                        new OracleParameter(":PHONE", OracleType.VarChar,50) ,            
                        new OracleParameter(":USERNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":USERPWD", OracleType.VarChar,32) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":SEX", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":BIRTHDAY", OracleType.DateTime) ,            
                        new OracleParameter(":DEGREE", OracleType.VarChar,50) ,            
                        new OracleParameter(":FACE", OracleType.VarChar,50)             
              
            };

            parameters[16].Value = model.USERID;
            parameters[17].Value = model.IDNUMBER;
            parameters[18].Value = model.JOBNUMBER;
            parameters[19].Value = model.PHOTO;
            parameters[20].Value = model.PROF;
            parameters[21].Value = model.REMARK;
            parameters[22].Value = model.STSTUS;
            parameters[23].Value = model.PHONE;
            parameters[24].Value = model.USERNAME;
            parameters[25].Value = model.USERPWD;
            parameters[26].Value = model.PARENTID;
            parameters[27].Value = model.SEX;
            parameters[28].Value = model.DEPTID;
            parameters[29].Value = model.BIRTHDAY;
            parameters[30].Value = model.DEGREE;
            parameters[31].Value = model.FACE;
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
            strSql.Append("select USERID, IDNUMBER, JOBNUMBER, PHOTO, PROF, REMARK, STSTUS, PHONE, USERNAME, USERPWD, PARENTID, SEX, DEPTID, BIRTHDAY, DEGREE, FACE  ");
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
                entity.IDNUMBER = dt.Rows[0]["IDNUMBER"].ToString();
                entity.JOBNUMBER = dt.Rows[0]["JOBNUMBER"].ToString();
                entity.PHOTO = dt.Rows[0]["PHOTO"].ToString();
                entity.PROF = dt.Rows[0]["PROF"].ToString();
                entity.REMARK = dt.Rows[0]["REMARK"].ToString();
                if (dt.Rows[0]["STSTUS"].ToString() != "") {
                    entity.STSTUS = decimal.Parse(dt.Rows[0]["STSTUS"].ToString());
                }
                entity.PHONE = dt.Rows[0]["PHONE"].ToString();
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

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList() {
            string procName = "PKG_USER_QUERY.proc_getuser";
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[1] = new OracleParameter();

            param[0].Direction = ParameterDirection.Input;
            param[0].OracleType = OracleType.Number;
            param[0].ParameterName = "dptcode";
            param[0].Value = 1;

            param[1].Direction = ParameterDirection.Output;
            param[1].OracleType = OracleType.Cursor;
            param[1].ParameterName = "out_cursor";

            return OracleHelper.RunProcedure(procName, param).Tables[0];
        }
    }
}

