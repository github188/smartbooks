// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_AREA.cs
// 功能描述:控制区违章信息表 -- 接口实现
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
    /// 控制区违章信息表 -- 接口实现
    /// </summary>
    public partial class BASE_AREA : IBASE_AREA {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_AREA");
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
        public void Add(Entity.BASE_AREA entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_AREA(");
            strSql.Append("ID,AREANAME,TYPEID,LINENAME,STAKEK,STAKEM,SUMMARY,COMPTIME,REGTIME,OWNER,DETAILED,STATUS,REMARK,PHOTO,DEPTID");
            strSql.Append(") values (");
            strSql.Append(":ID,:AREANAME,:TYPEID,:LINENAME,:STAKEK,:STAKEM,:SUMMARY,:COMPTIME,:REGTIME,:OWNER,:DETAILED,:STATUS,:REMARK,:PHOTO,:DEPTID");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":AREANAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4) ,            
                        new OracleParameter(":LINENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":STAKEK", OracleType.Number,4) ,            
                        new OracleParameter(":STAKEM", OracleType.Number,4) ,            
                        new OracleParameter(":SUMMARY", OracleType.VarChar,50) ,            
                        new OracleParameter(":COMPTIME", OracleType.DateTime) ,            
                        new OracleParameter(":REGTIME", OracleType.DateTime) ,            
                        new OracleParameter(":OWNER", OracleType.VarChar,50) ,            
                        new OracleParameter(":DETAILED", OracleType.VarChar,200) ,            
                        new OracleParameter(":STATUS", OracleType.VarChar,200) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,200) ,            
                        new OracleParameter(":PHOTO", OracleType.VarChar,200) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.AREANAME;
            parameters[2].Value = entity.TYPEID;
            parameters[3].Value = entity.LINENAME;
            parameters[4].Value = entity.STAKEK;
            parameters[5].Value = entity.STAKEM;
            parameters[6].Value = entity.SUMMARY;
            parameters[7].Value = entity.COMPTIME;
            parameters[8].Value = entity.REGTIME;
            parameters[9].Value = entity.OWNER;
            parameters[10].Value = entity.DETAILED;
            parameters[11].Value = entity.STATUS;
            parameters[12].Value = entity.REMARK;
            parameters[13].Value = entity.PHOTO;
            parameters[14].Value = entity.DEPTID;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_AREA entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_AREA set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" AREANAME = :AREANAME , ");
            strSql.Append(" TYPEID = :TYPEID , ");
            strSql.Append(" LINENAME = :LINENAME , ");
            strSql.Append(" STAKEK = :STAKEK , ");
            strSql.Append(" STAKEM = :STAKEM , ");
            strSql.Append(" SUMMARY = :SUMMARY , ");
            strSql.Append(" COMPTIME = :COMPTIME , ");
            strSql.Append(" REGTIME = :REGTIME , ");
            strSql.Append(" OWNER = :OWNER , ");
            strSql.Append(" DETAILED = :DETAILED , ");
            strSql.Append(" STATUS = :STATUS , ");
            strSql.Append(" REMARK = :REMARK , ");
            strSql.Append(" PHOTO = :PHOTO , ");
            strSql.Append(" DEPTID = :DEPTID  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":AREANAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":TYPEID", OracleType.Number,4) ,            
                        new OracleParameter(":LINENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":STAKEK", OracleType.Number,4) ,            
                        new OracleParameter(":STAKEM", OracleType.Number,4) ,            
                        new OracleParameter(":SUMMARY", OracleType.VarChar,50) ,            
                        new OracleParameter(":COMPTIME", OracleType.DateTime) ,            
                        new OracleParameter(":REGTIME", OracleType.DateTime) ,            
                        new OracleParameter(":OWNER", OracleType.VarChar,50) ,            
                        new OracleParameter(":DETAILED", OracleType.VarChar,200) ,            
                        new OracleParameter(":STATUS", OracleType.VarChar,200) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,200) ,            
                        new OracleParameter(":PHOTO", OracleType.VarChar,200) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4)             
              
            };

            parameters[15].Value = entity.ID;
            parameters[16].Value = entity.AREANAME;
            parameters[17].Value = entity.TYPEID;
            parameters[18].Value = entity.LINENAME;
            parameters[19].Value = entity.STAKEK;
            parameters[20].Value = entity.STAKEM;
            parameters[21].Value = entity.SUMMARY;
            parameters[22].Value = entity.COMPTIME;
            parameters[23].Value = entity.REGTIME;
            parameters[24].Value = entity.OWNER;
            parameters[25].Value = entity.DETAILED;
            parameters[26].Value = entity.STATUS;
            parameters[27].Value = entity.REMARK;
            parameters[28].Value = entity.PHOTO;
            parameters[29].Value = entity.DEPTID;
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
            strSql.Append("delete from BASE_AREA ");
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
        public Entity.BASE_AREA GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AREANAME, TYPEID, LINENAME, STAKEK, STAKEM, SUMMARY, COMPTIME, REGTIME, OWNER, DETAILED, STATUS, REMARK, PHOTO, DEPTID  ");
            strSql.Append("  from BASE_AREA ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_AREA entity = new Entity.BASE_AREA();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                entity.AREANAME = dt.Rows[0]["AREANAME"].ToString();
                if (dt.Rows[0]["TYPEID"].ToString() != "") {
                    entity.TYPEID = decimal.Parse(dt.Rows[0]["TYPEID"].ToString());
                }
                entity.LINENAME = dt.Rows[0]["LINENAME"].ToString();
                if (dt.Rows[0]["STAKEK"].ToString() != "") {
                    entity.STAKEK = decimal.Parse(dt.Rows[0]["STAKEK"].ToString());
                }
                if (dt.Rows[0]["STAKEM"].ToString() != "") {
                    entity.STAKEM = decimal.Parse(dt.Rows[0]["STAKEM"].ToString());
                }
                entity.SUMMARY = dt.Rows[0]["SUMMARY"].ToString();
                if (dt.Rows[0]["COMPTIME"].ToString() != "") {
                    entity.COMPTIME = DateTime.Parse(dt.Rows[0]["COMPTIME"].ToString());
                }
                if (dt.Rows[0]["REGTIME"].ToString() != "") {
                    entity.REGTIME = DateTime.Parse(dt.Rows[0]["REGTIME"].ToString());
                }
                entity.OWNER = dt.Rows[0]["OWNER"].ToString();
                entity.DETAILED = dt.Rows[0]["DETAILED"].ToString();
                entity.STATUS = dt.Rows[0]["STATUS"].ToString();
                entity.REMARK = dt.Rows[0]["REMARK"].ToString();
                entity.PHOTO = dt.Rows[0]["PHOTO"].ToString();
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
            strSql.Append(" FROM BASE_AREA ");
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
            strSql.Append(" FROM BASE_AREA ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

