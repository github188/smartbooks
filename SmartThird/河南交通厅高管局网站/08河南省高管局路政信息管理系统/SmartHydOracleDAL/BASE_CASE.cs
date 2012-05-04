// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CASE.cs
// 功能描述:路产案件表 -- 接口实现
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
    /// 路产案件表 -- 接口实现
    /// </summary>
    public partial class BASE_CASE : IBASE_CASE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal ID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CASE");
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
        public void Add(Entity.BASE_CASE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_CASE(");
            strSql.Append("ID,CASECODE,USERID,TICKTIME,WEATHER,LINENAME,STAKEK,STAKEM,LINETYPE,ACCIDENTTYPE,ACCIDENTCAUSE,ACTION,LAUNCH,PRESENTERS,PRESENTERSID,PRESENTERSDUTY,INQUEST,INQUESTID,INQUESTDUTY,INQUESTBEGINTIME,INQUESTENDTIME,INVITE,INVITETEL,INVITEDUTY,BUSLOSS,DEATH,WEIGHT,LIGHT,SUMMARY,CREATETIME");
            strSql.Append(") values (");
            strSql.Append(":ID,:CASECODE,:USERID,:TICKTIME,:WEATHER,:LINENAME,:STAKEK,:STAKEM,:LINETYPE,:ACCIDENTTYPE,:ACCIDENTCAUSE,:ACTION,:LAUNCH,:PRESENTERS,:PRESENTERSID,:PRESENTERSDUTY,:INQUEST,:INQUESTID,:INQUESTDUTY,:INQUESTBEGINTIME,:INQUESTENDTIME,:INVITE,:INVITETEL,:INVITEDUTY,:BUSLOSS,:DEATH,:WEIGHT,:LIGHT,:SUMMARY,:CREATETIME");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":CASECODE", OracleType.VarChar,50) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":LINENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":STAKEK", OracleType.Number,4) ,            
                        new OracleParameter(":STAKEM", OracleType.Number,4) ,            
                        new OracleParameter(":LINETYPE", OracleType.VarChar,50) ,            
                        new OracleParameter(":ACCIDENTTYPE", OracleType.VarChar,50) ,            
                        new OracleParameter(":ACCIDENTCAUSE", OracleType.VarChar,50) ,            
                        new OracleParameter(":ACTION", OracleType.VarChar,50) ,            
                        new OracleParameter(":LAUNCH", OracleType.VarChar,50) ,            
                        new OracleParameter(":PRESENTERS", OracleType.VarChar,50) ,            
                        new OracleParameter(":PRESENTERSID", OracleType.VarChar,50) ,            
                        new OracleParameter(":PRESENTERSDUTY", OracleType.VarChar,50) ,            
                        new OracleParameter(":INQUEST", OracleType.VarChar,50) ,            
                        new OracleParameter(":INQUESTID", OracleType.VarChar,50) ,            
                        new OracleParameter(":INQUESTDUTY", OracleType.VarChar,50) ,            
                        new OracleParameter(":INQUESTBEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":INQUESTENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":INVITE", OracleType.VarChar,50) ,            
                        new OracleParameter(":INVITETEL", OracleType.VarChar,50) ,            
                        new OracleParameter(":INVITEDUTY", OracleType.VarChar,50) ,            
                        new OracleParameter(":BUSLOSS", OracleType.Number,4) ,            
                        new OracleParameter(":DEATH", OracleType.Number,4) ,            
                        new OracleParameter(":WEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":LIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":SUMMARY", OracleType.VarChar,1000) ,            
                        new OracleParameter(":CREATETIME", OracleType.DateTime)             
              
            };

            parameters[0].Value = entity.ID;
            parameters[1].Value = entity.CASECODE;
            parameters[2].Value = entity.USERID;
            parameters[3].Value = entity.TICKTIME;
            parameters[4].Value = entity.WEATHER;
            parameters[5].Value = entity.LINENAME;
            parameters[6].Value = entity.STAKEK;
            parameters[7].Value = entity.STAKEM;
            parameters[8].Value = entity.LINETYPE;
            parameters[9].Value = entity.ACCIDENTTYPE;
            parameters[10].Value = entity.ACCIDENTCAUSE;
            parameters[11].Value = entity.ACTION;
            parameters[12].Value = entity.LAUNCH;
            parameters[13].Value = entity.PRESENTERS;
            parameters[14].Value = entity.PRESENTERSID;
            parameters[15].Value = entity.PRESENTERSDUTY;
            parameters[16].Value = entity.INQUEST;
            parameters[17].Value = entity.INQUESTID;
            parameters[18].Value = entity.INQUESTDUTY;
            parameters[19].Value = entity.INQUESTBEGINTIME;
            parameters[20].Value = entity.INQUESTENDTIME;
            parameters[21].Value = entity.INVITE;
            parameters[22].Value = entity.INVITETEL;
            parameters[23].Value = entity.INVITEDUTY;
            parameters[24].Value = entity.BUSLOSS;
            parameters[25].Value = entity.DEATH;
            parameters[26].Value = entity.WEIGHT;
            parameters[27].Value = entity.LIGHT;
            parameters[28].Value = entity.SUMMARY;
            parameters[29].Value = entity.CREATETIME;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_CASE entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CASE set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" CASECODE = :CASECODE , ");
            strSql.Append(" USERID = :USERID , ");
            strSql.Append(" TICKTIME = :TICKTIME , ");
            strSql.Append(" WEATHER = :WEATHER , ");
            strSql.Append(" LINENAME = :LINENAME , ");
            strSql.Append(" STAKEK = :STAKEK , ");
            strSql.Append(" STAKEM = :STAKEM , ");
            strSql.Append(" LINETYPE = :LINETYPE , ");
            strSql.Append(" ACCIDENTTYPE = :ACCIDENTTYPE , ");
            strSql.Append(" ACCIDENTCAUSE = :ACCIDENTCAUSE , ");
            strSql.Append(" ACTION = :ACTION , ");
            strSql.Append(" LAUNCH = :LAUNCH , ");
            strSql.Append(" PRESENTERS = :PRESENTERS , ");
            strSql.Append(" PRESENTERSID = :PRESENTERSID , ");
            strSql.Append(" PRESENTERSDUTY = :PRESENTERSDUTY , ");
            strSql.Append(" INQUEST = :INQUEST , ");
            strSql.Append(" INQUESTID = :INQUESTID , ");
            strSql.Append(" INQUESTDUTY = :INQUESTDUTY , ");
            strSql.Append(" INQUESTBEGINTIME = :INQUESTBEGINTIME , ");
            strSql.Append(" INQUESTENDTIME = :INQUESTENDTIME , ");
            strSql.Append(" INVITE = :INVITE , ");
            strSql.Append(" INVITETEL = :INVITETEL , ");
            strSql.Append(" INVITEDUTY = :INVITEDUTY , ");
            strSql.Append(" BUSLOSS = :BUSLOSS , ");
            strSql.Append(" DEATH = :DEATH , ");
            strSql.Append(" WEIGHT = :WEIGHT , ");
            strSql.Append(" LIGHT = :LIGHT , ");
            strSql.Append(" SUMMARY = :SUMMARY , ");
            strSql.Append(" CREATETIME = :CREATETIME  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":CASECODE", OracleType.VarChar,50) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":LINENAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":STAKEK", OracleType.Number,4) ,            
                        new OracleParameter(":STAKEM", OracleType.Number,4) ,            
                        new OracleParameter(":LINETYPE", OracleType.VarChar,50) ,            
                        new OracleParameter(":ACCIDENTTYPE", OracleType.VarChar,50) ,            
                        new OracleParameter(":ACCIDENTCAUSE", OracleType.VarChar,50) ,            
                        new OracleParameter(":ACTION", OracleType.VarChar,50) ,            
                        new OracleParameter(":LAUNCH", OracleType.VarChar,50) ,            
                        new OracleParameter(":PRESENTERS", OracleType.VarChar,50) ,            
                        new OracleParameter(":PRESENTERSID", OracleType.VarChar,50) ,            
                        new OracleParameter(":PRESENTERSDUTY", OracleType.VarChar,50) ,            
                        new OracleParameter(":INQUEST", OracleType.VarChar,50) ,            
                        new OracleParameter(":INQUESTID", OracleType.VarChar,50) ,            
                        new OracleParameter(":INQUESTDUTY", OracleType.VarChar,50) ,            
                        new OracleParameter(":INQUESTBEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":INQUESTENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":INVITE", OracleType.VarChar,50) ,            
                        new OracleParameter(":INVITETEL", OracleType.VarChar,50) ,            
                        new OracleParameter(":INVITEDUTY", OracleType.VarChar,50) ,            
                        new OracleParameter(":BUSLOSS", OracleType.Number,4) ,            
                        new OracleParameter(":DEATH", OracleType.Number,4) ,            
                        new OracleParameter(":WEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":LIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":SUMMARY", OracleType.VarChar,1000) ,            
                        new OracleParameter(":CREATETIME", OracleType.DateTime)             
              
            };

            parameters[30].Value = entity.ID;
            parameters[31].Value = entity.CASECODE;
            parameters[32].Value = entity.USERID;
            parameters[33].Value = entity.TICKTIME;
            parameters[34].Value = entity.WEATHER;
            parameters[35].Value = entity.LINENAME;
            parameters[36].Value = entity.STAKEK;
            parameters[37].Value = entity.STAKEM;
            parameters[38].Value = entity.LINETYPE;
            parameters[39].Value = entity.ACCIDENTTYPE;
            parameters[40].Value = entity.ACCIDENTCAUSE;
            parameters[41].Value = entity.ACTION;
            parameters[42].Value = entity.LAUNCH;
            parameters[43].Value = entity.PRESENTERS;
            parameters[44].Value = entity.PRESENTERSID;
            parameters[45].Value = entity.PRESENTERSDUTY;
            parameters[46].Value = entity.INQUEST;
            parameters[47].Value = entity.INQUESTID;
            parameters[48].Value = entity.INQUESTDUTY;
            parameters[49].Value = entity.INQUESTBEGINTIME;
            parameters[50].Value = entity.INQUESTENDTIME;
            parameters[51].Value = entity.INVITE;
            parameters[52].Value = entity.INVITETEL;
            parameters[53].Value = entity.INVITEDUTY;
            parameters[54].Value = entity.BUSLOSS;
            parameters[55].Value = entity.DEATH;
            parameters[56].Value = entity.WEIGHT;
            parameters[57].Value = entity.LIGHT;
            parameters[58].Value = entity.SUMMARY;
            parameters[59].Value = entity.CREATETIME;
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
            strSql.Append("delete from BASE_CASE ");
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
        public Entity.BASE_CASE GetEntity(decimal ID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, CASECODE, USERID, TICKTIME, WEATHER, LINENAME, STAKEK, STAKEM, LINETYPE, ACCIDENTTYPE, ACCIDENTCAUSE, ACTION, LAUNCH, PRESENTERS, PRESENTERSID, PRESENTERSDUTY, INQUEST, INQUESTID, INQUESTDUTY, INQUESTBEGINTIME, INQUESTENDTIME, INVITE, INVITETEL, INVITEDUTY, BUSLOSS, DEATH, WEIGHT, LIGHT, SUMMARY, CREATETIME  ");
            strSql.Append("  from BASE_CASE ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;


            Entity.BASE_CASE entity = new Entity.BASE_CASE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["ID"].ToString() != "") {
                    entity.ID = decimal.Parse(dt.Rows[0]["ID"].ToString());
                }
                entity.CASECODE = dt.Rows[0]["CASECODE"].ToString();
                if (dt.Rows[0]["USERID"].ToString() != "") {
                    entity.USERID = decimal.Parse(dt.Rows[0]["USERID"].ToString());
                }
                if (dt.Rows[0]["TICKTIME"].ToString() != "") {
                    entity.TICKTIME = DateTime.Parse(dt.Rows[0]["TICKTIME"].ToString());
                }
                entity.WEATHER = dt.Rows[0]["WEATHER"].ToString();
                entity.LINENAME = dt.Rows[0]["LINENAME"].ToString();
                if (dt.Rows[0]["STAKEK"].ToString() != "") {
                    entity.STAKEK = decimal.Parse(dt.Rows[0]["STAKEK"].ToString());
                }
                if (dt.Rows[0]["STAKEM"].ToString() != "") {
                    entity.STAKEM = decimal.Parse(dt.Rows[0]["STAKEM"].ToString());
                }
                entity.LINETYPE = dt.Rows[0]["LINETYPE"].ToString();
                entity.ACCIDENTTYPE = dt.Rows[0]["ACCIDENTTYPE"].ToString();
                entity.ACCIDENTCAUSE = dt.Rows[0]["ACCIDENTCAUSE"].ToString();
                entity.ACTION = dt.Rows[0]["ACTION"].ToString();
                entity.LAUNCH = dt.Rows[0]["LAUNCH"].ToString();
                entity.PRESENTERS = dt.Rows[0]["PRESENTERS"].ToString();
                entity.PRESENTERSID = dt.Rows[0]["PRESENTERSID"].ToString();
                entity.PRESENTERSDUTY = dt.Rows[0]["PRESENTERSDUTY"].ToString();
                entity.INQUEST = dt.Rows[0]["INQUEST"].ToString();
                entity.INQUESTID = dt.Rows[0]["INQUESTID"].ToString();
                entity.INQUESTDUTY = dt.Rows[0]["INQUESTDUTY"].ToString();
                if (dt.Rows[0]["INQUESTBEGINTIME"].ToString() != "") {
                    entity.INQUESTBEGINTIME = DateTime.Parse(dt.Rows[0]["INQUESTBEGINTIME"].ToString());
                }
                if (dt.Rows[0]["INQUESTENDTIME"].ToString() != "") {
                    entity.INQUESTENDTIME = DateTime.Parse(dt.Rows[0]["INQUESTENDTIME"].ToString());
                }
                entity.INVITE = dt.Rows[0]["INVITE"].ToString();
                entity.INVITETEL = dt.Rows[0]["INVITETEL"].ToString();
                entity.INVITEDUTY = dt.Rows[0]["INVITEDUTY"].ToString();
                if (dt.Rows[0]["BUSLOSS"].ToString() != "") {
                    entity.BUSLOSS = decimal.Parse(dt.Rows[0]["BUSLOSS"].ToString());
                }
                if (dt.Rows[0]["DEATH"].ToString() != "") {
                    entity.DEATH = decimal.Parse(dt.Rows[0]["DEATH"].ToString());
                }
                if (dt.Rows[0]["WEIGHT"].ToString() != "") {
                    entity.WEIGHT = decimal.Parse(dt.Rows[0]["WEIGHT"].ToString());
                }
                if (dt.Rows[0]["LIGHT"].ToString() != "") {
                    entity.LIGHT = decimal.Parse(dt.Rows[0]["LIGHT"].ToString());
                }
                entity.SUMMARY = dt.Rows[0]["SUMMARY"].ToString();
                if (dt.Rows[0]["CREATETIME"].ToString() != "") {
                    entity.CREATETIME = DateTime.Parse(dt.Rows[0]["CREATETIME"].ToString());
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
            strSql.Append(" FROM BASE_CASE ");
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
            strSql.Append(" FROM BASE_CASE ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

