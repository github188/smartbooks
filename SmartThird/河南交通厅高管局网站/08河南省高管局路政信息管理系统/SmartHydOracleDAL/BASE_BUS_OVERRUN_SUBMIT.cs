// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_BUS_OVERRUN_SUBMIT.cs
// 功能描述:查处非法超限车辆数据 -- 接口实现
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
    /// 查处非法超限车辆数据 -- 接口实现
    /// </summary>
    public partial class BASE_BUS_OVERRUN_SUBMIT : IBASE_BUS_OVERRUN_SUBMIT {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_BUS_OVERRUN_SUBMIT");
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
        public void Add(Entity.BASE_BUS_OVERRUN_SUBMIT entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_BUS_OVERRUN_SUBMIT(");
            strSql.Append("ID,BUSCODE,BUSLONG,BUSWIDTH,BUSHEIGHT,WEIGHT,PHOTO,INNAME,OUTNAME,TICKTIME,USERID,DEPTID,LOCATION,BUSUNIT,REMARKS");
            strSql.Append(") values (");
            strSql.Append(":ID,:BUSCODE,:BUSLONG,:BUSWIDTH,:BUSHEIGHT,:WEIGHT,:PHOTO,:INNAME,:OUTNAME,:TICKTIME,:USERID,:DEPTID,:LOCATION,:BUSUNIT,:REMARKS");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":BUSCODE", OracleType.VarChar,20) ,            
                        new OracleParameter(":BUSLONG", OracleType.Number,4) ,            
                        new OracleParameter(":BUSWIDTH", OracleType.Number,4) ,            
                        new OracleParameter(":BUSHEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":WEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":PHOTO", OracleType.VarChar,200) ,            
                        new OracleParameter(":INNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":OUTNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":LOCATION", OracleType.VarChar,100) ,            
                        new OracleParameter(":BUSUNIT", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARKS", OracleType.VarChar,50)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.BUSCODE;
            parameters[2].Value = entity.BUSLONG;
            parameters[3].Value = entity.BUSWIDTH;
            parameters[4].Value = entity.BUSHEIGHT;
            parameters[5].Value = entity.WEIGHT;
            parameters[6].Value = entity.PHOTO;
            parameters[7].Value = entity.INNAME;
            parameters[8].Value = entity.OUTNAME;
            parameters[9].Value = entity.TICKTIME;
            parameters[10].Value = entity.USERID;
            parameters[11].Value = entity.DEPTID;
            parameters[12].Value = entity.LOCATION;
            parameters[13].Value = entity.BUSUNIT;
            parameters[14].Value = entity.REMARKS;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_BUS_OVERRUN_SUBMIT entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_BUS_OVERRUN_SUBMIT set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" BUSCODE = :BUSCODE , ");
            strSql.Append(" BUSLONG = :BUSLONG , ");
            strSql.Append(" BUSWIDTH = :BUSWIDTH , ");
            strSql.Append(" BUSHEIGHT = :BUSHEIGHT , ");
            strSql.Append(" WEIGHT = :WEIGHT , ");
            strSql.Append(" PHOTO = :PHOTO , ");
            strSql.Append(" INNAME = :INNAME , ");
            strSql.Append(" OUTNAME = :OUTNAME , ");
            strSql.Append(" TICKTIME = :TICKTIME , ");
            strSql.Append(" USERID = :USERID , ");
            strSql.Append(" DEPTID = :DEPTID , ");
            strSql.Append(" LOCATION = :LOCATION , ");
            strSql.Append(" BUSUNIT = :BUSUNIT , ");
            strSql.Append(" REMARKS = :REMARKS  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":BUSCODE", OracleType.VarChar,20) ,            
                        new OracleParameter(":BUSLONG", OracleType.Number,4) ,            
                        new OracleParameter(":BUSWIDTH", OracleType.Number,4) ,            
                        new OracleParameter(":BUSHEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":WEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":PHOTO", OracleType.VarChar,200) ,            
                        new OracleParameter(":INNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":OUTNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":LOCATION", OracleType.VarChar,100) ,            
                        new OracleParameter(":BUSUNIT", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARKS", OracleType.VarChar,50)             
              
            };

            parameters[15].Value = entity.ID;
            parameters[16].Value = entity.BUSCODE;
            parameters[17].Value = entity.BUSLONG;
            parameters[18].Value = entity.BUSWIDTH;
            parameters[19].Value = entity.BUSHEIGHT;
            parameters[20].Value = entity.WEIGHT;
            parameters[21].Value = entity.PHOTO;
            parameters[22].Value = entity.INNAME;
            parameters[23].Value = entity.OUTNAME;
            parameters[24].Value = entity.TICKTIME;
            parameters[25].Value = entity.USERID;
            parameters[26].Value = entity.DEPTID;
            parameters[27].Value = entity.LOCATION;
            parameters[28].Value = entity.BUSUNIT;
            parameters[29].Value = entity.REMARKS;
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
            strSql.Append("delete from BASE_BUS_OVERRUN_SUBMIT ");
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
        public Entity.BASE_BUS_OVERRUN_SUBMIT GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, BUSCODE, BUSLONG, BUSWIDTH, BUSHEIGHT, WEIGHT, PHOTO, INNAME, OUTNAME, TICKTIME, USERID, DEPTID, LOCATION, BUSUNIT, REMARKS  ");
            strSql.Append("  from BASE_BUS_OVERRUN_SUBMIT ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_BUS_OVERRUN_SUBMIT entity = new Entity.BASE_BUS_OVERRUN_SUBMIT();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                entity.BUSCODE = dt.Rows[0]["BUSCODE"].ToString();
                if (dt.Rows[0]["BUSLONG"].ToString() != "") {
                    entity.BUSLONG = decimal.Parse(dt.Rows[0]["BUSLONG"].ToString());
                }
                if (dt.Rows[0]["BUSWIDTH"].ToString() != "") {
                    entity.BUSWIDTH = decimal.Parse(dt.Rows[0]["BUSWIDTH"].ToString());
                }
                if (dt.Rows[0]["BUSHEIGHT"].ToString() != "") {
                    entity.BUSHEIGHT = decimal.Parse(dt.Rows[0]["BUSHEIGHT"].ToString());
                }
                if (dt.Rows[0]["WEIGHT"].ToString() != "") {
                    entity.WEIGHT = decimal.Parse(dt.Rows[0]["WEIGHT"].ToString());
                }
                entity.PHOTO = dt.Rows[0]["PHOTO"].ToString();
                entity.INNAME = dt.Rows[0]["INNAME"].ToString();
                entity.OUTNAME = dt.Rows[0]["OUTNAME"].ToString();
                if (dt.Rows[0]["TICKTIME"].ToString() != "") {
                    entity.TICKTIME = DateTime.Parse(dt.Rows[0]["TICKTIME"].ToString());
                }
                if (dt.Rows[0]["USERID"].ToString() != "") {
                    entity.USERID = decimal.Parse(dt.Rows[0]["USERID"].ToString());
                }
                if (dt.Rows[0]["DEPTID"].ToString() != "") {
                    entity.DEPTID = decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
                }
                entity.LOCATION = dt.Rows[0]["LOCATION"].ToString();
                entity.BUSUNIT = dt.Rows[0]["BUSUNIT"].ToString();
                entity.REMARKS = dt.Rows[0]["REMARKS"].ToString();

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
            strSql.Append(" FROM BASE_BUS_OVERRUN_SUBMIT ");
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
            strSql.Append(" FROM BASE_BUS_OVERRUN_SUBMIT ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

