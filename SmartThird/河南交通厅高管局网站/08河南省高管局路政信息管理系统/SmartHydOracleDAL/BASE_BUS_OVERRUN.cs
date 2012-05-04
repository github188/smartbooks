// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_BUS_OVERRUN.cs
// 功能描述:高速公路超限车辆数据表 -- 接口实现
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
    /// 高速公路超限车辆数据表 -- 接口实现
    /// </summary>
    public partial class BASE_BUS_OVERRUN : IBASE_BUS_OVERRUN {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_BUS_OVERRUN");
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
        public void Add(Entity.BASE_BUS_OVERRUN entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_BUS_OVERRUN(");
            strSql.Append("ID,BUSCODE,INNAME,INTIME,OUTNAME,OUTTIME,PAY,AXIS,OVERLOADRATE,TOTALWEIGHT,MONEY,MILEAGE");
            strSql.Append(") values (");
            strSql.Append(":ID,:BUSCODE,:INNAME,:INTIME,:OUTNAME,:OUTTIME,:PAY,:AXIS,:OVERLOADRATE,:TOTALWEIGHT,:MONEY,:MILEAGE");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":BUSCODE", OracleType.VarChar,20) ,            
                        new OracleParameter(":INNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":INTIME", OracleType.DateTime) ,            
                        new OracleParameter(":OUTNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":OUTTIME", OracleType.DateTime) ,            
                        new OracleParameter(":PAY", OracleType.VarChar,20) ,            
                        new OracleParameter(":AXIS", OracleType.Number,4) ,            
                        new OracleParameter(":OVERLOADRATE", OracleType.Number,4) ,            
                        new OracleParameter(":TOTALWEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":MONEY", OracleType.Number,4) ,            
                        new OracleParameter(":MILEAGE", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.BUSCODE;
            parameters[2].Value = entity.INNAME;
            parameters[3].Value = entity.INTIME;
            parameters[4].Value = entity.OUTNAME;
            parameters[5].Value = entity.OUTTIME;
            parameters[6].Value = entity.PAY;
            parameters[7].Value = entity.AXIS;
            parameters[8].Value = entity.OVERLOADRATE;
            parameters[9].Value = entity.TOTALWEIGHT;
            parameters[10].Value = entity.MONEY;
            parameters[11].Value = entity.MILEAGE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_BUS_OVERRUN entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_BUS_OVERRUN set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" BUSCODE = :BUSCODE , ");
            strSql.Append(" INNAME = :INNAME , ");
            strSql.Append(" INTIME = :INTIME , ");
            strSql.Append(" OUTNAME = :OUTNAME , ");
            strSql.Append(" OUTTIME = :OUTTIME , ");
            strSql.Append(" PAY = :PAY , ");
            strSql.Append(" AXIS = :AXIS , ");
            strSql.Append(" OVERLOADRATE = :OVERLOADRATE , ");
            strSql.Append(" TOTALWEIGHT = :TOTALWEIGHT , ");
            strSql.Append(" MONEY = :MONEY , ");
            strSql.Append(" MILEAGE = :MILEAGE  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":BUSCODE", OracleType.VarChar,20) ,            
                        new OracleParameter(":INNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":INTIME", OracleType.DateTime) ,            
                        new OracleParameter(":OUTNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":OUTTIME", OracleType.DateTime) ,            
                        new OracleParameter(":PAY", OracleType.VarChar,20) ,            
                        new OracleParameter(":AXIS", OracleType.Number,4) ,            
                        new OracleParameter(":OVERLOADRATE", OracleType.Number,4) ,            
                        new OracleParameter(":TOTALWEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":MONEY", OracleType.Number,4) ,            
                        new OracleParameter(":MILEAGE", OracleType.Number,4)             
              
            };

            parameters[12].Value = entity.ID;
            parameters[13].Value = entity.BUSCODE;
            parameters[14].Value = entity.INNAME;
            parameters[15].Value = entity.INTIME;
            parameters[16].Value = entity.OUTNAME;
            parameters[17].Value = entity.OUTTIME;
            parameters[18].Value = entity.PAY;
            parameters[19].Value = entity.AXIS;
            parameters[20].Value = entity.OVERLOADRATE;
            parameters[21].Value = entity.TOTALWEIGHT;
            parameters[22].Value = entity.MONEY;
            parameters[23].Value = entity.MILEAGE;
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
            strSql.Append("delete from BASE_BUS_OVERRUN ");
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
        public Entity.BASE_BUS_OVERRUN GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, BUSCODE, INNAME, INTIME, OUTNAME, OUTTIME, PAY, AXIS, OVERLOADRATE, TOTALWEIGHT, MONEY, MILEAGE  ");
            strSql.Append("  from BASE_BUS_OVERRUN ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_BUS_OVERRUN entity = new Entity.BASE_BUS_OVERRUN();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                entity.BUSCODE = dt.Rows[0]["BUSCODE"].ToString();
                entity.INNAME = dt.Rows[0]["INNAME"].ToString();
                if (dt.Rows[0]["INTIME"].ToString() != "") {
                    entity.INTIME = DateTime.Parse(dt.Rows[0]["INTIME"].ToString());
                }
                entity.OUTNAME = dt.Rows[0]["OUTNAME"].ToString();
                if (dt.Rows[0]["OUTTIME"].ToString() != "") {
                    entity.OUTTIME = DateTime.Parse(dt.Rows[0]["OUTTIME"].ToString());
                }
                entity.PAY = dt.Rows[0]["PAY"].ToString();
                if (dt.Rows[0]["AXIS"].ToString() != "") {
                    entity.AXIS = decimal.Parse(dt.Rows[0]["AXIS"].ToString());
                }
                if (dt.Rows[0]["OVERLOADRATE"].ToString() != "") {
                    entity.OVERLOADRATE = decimal.Parse(dt.Rows[0]["OVERLOADRATE"].ToString());
                }
                if (dt.Rows[0]["TOTALWEIGHT"].ToString() != "") {
                    entity.TOTALWEIGHT = decimal.Parse(dt.Rows[0]["TOTALWEIGHT"].ToString());
                }
                if (dt.Rows[0]["MONEY"].ToString() != "") {
                    entity.MONEY = decimal.Parse(dt.Rows[0]["MONEY"].ToString());
                }
                if (dt.Rows[0]["MILEAGE"].ToString() != "") {
                    entity.MILEAGE = decimal.Parse(dt.Rows[0]["MILEAGE"].ToString());
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
            strSql.Append(" FROM BASE_BUS_OVERRUN ");
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
            strSql.Append(" FROM BASE_BUS_OVERRUN ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

