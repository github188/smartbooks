// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_BUS_OVERRUN.cs
// 功能描述:高速公路超限车辆数据表 -- 接口实现
//
// 创建标识：王 亚 2012-05-15
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;

    public delegate void OnCompleteSingle(int size, int count);

    /// <summary>
    /// 高速公路超限车辆数据表 -- 接口实现
    /// </summary>
    public partial class BASE_BUS_OVERRUN : IBASE_BUS_OVERRUN {
        public event OnCompleteSingle On_CompleteSingle;

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
        public void Add(Entity.BASE_BUS_OVERRUN model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_BUS_OVERRUN(");
            strSql.Append("ID,AXISNUM,OVERLOADRATE,TOTALWEIGHT,TOTALTOLL,DISTANCE,IMPORTDATE,VEHICLELICENSE,ENTRYSTATION,ENTRYSTATIONNAME,ENTRYTIME,EXITSTATION,EXITSTATIONNAME,EXITTIME,PAYTYPE");
            strSql.Append(") values (");
            strSql.Append(":ID,:AXISNUM,:OVERLOADRATE,:TOTALWEIGHT,:TOTALTOLL,:DISTANCE,:IMPORTDATE,:VEHICLELICENSE,:ENTRYSTATION,:ENTRYSTATIONNAME,:ENTRYTIME,:EXITSTATION,:EXITSTATIONNAME,:EXITTIME,:PAYTYPE");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":AXISNUM", OracleType.Number,4) ,            
                        new OracleParameter(":OVERLOADRATE", OracleType.Number,4) ,            
                        new OracleParameter(":TOTALWEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":TOTALTOLL", OracleType.Number,4) ,            
                        new OracleParameter(":DISTANCE", OracleType.Number,4) ,            
                        new OracleParameter(":IMPORTDATE", OracleType.DateTime) ,            
                        new OracleParameter(":VEHICLELICENSE", OracleType.VarChar,200) ,            
                        new OracleParameter(":ENTRYSTATION", OracleType.Number,4) ,            
                        new OracleParameter(":ENTRYSTATIONNAME", OracleType.VarChar,200) ,            
                        new OracleParameter(":ENTRYTIME", OracleType.DateTime) ,            
                        new OracleParameter(":EXITSTATION", OracleType.Number,4) ,            
                        new OracleParameter(":EXITSTATIONNAME", OracleType.VarChar,200) ,            
                        new OracleParameter(":EXITTIME", OracleType.DateTime) ,            
                        new OracleParameter(":PAYTYPE", OracleType.VarChar,200)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.AXISNUM;
            parameters[2].Value = model.OVERLOADRATE;
            parameters[3].Value = model.TOTALWEIGHT;
            parameters[4].Value = model.TOTALTOLL;
            parameters[5].Value = model.DISTANCE;
            parameters[6].Value = model.IMPORTDATE;
            parameters[7].Value = model.VEHICLELICENSE;
            parameters[8].Value = model.ENTRYSTATION;
            parameters[9].Value = model.ENTRYSTATIONNAME;
            parameters[10].Value = model.ENTRYTIME;
            parameters[11].Value = model.EXITSTATION;
            parameters[12].Value = model.EXITSTATIONNAME;
            parameters[13].Value = model.EXITTIME;
            parameters[14].Value = model.PAYTYPE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_BUS_OVERRUN model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_BUS_OVERRUN set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" AXISNUM = :AXISNUM , ");
            strSql.Append(" OVERLOADRATE = :OVERLOADRATE , ");
            strSql.Append(" TOTALWEIGHT = :TOTALWEIGHT , ");
            strSql.Append(" TOTALTOLL = :TOTALTOLL , ");
            strSql.Append(" DISTANCE = :DISTANCE , ");
            strSql.Append(" IMPORTDATE = :IMPORTDATE , ");
            strSql.Append(" VEHICLELICENSE = :VEHICLELICENSE , ");
            strSql.Append(" ENTRYSTATION = :ENTRYSTATION , ");
            strSql.Append(" ENTRYSTATIONNAME = :ENTRYSTATIONNAME , ");
            strSql.Append(" ENTRYTIME = :ENTRYTIME , ");
            strSql.Append(" EXITSTATION = :EXITSTATION , ");
            strSql.Append(" EXITSTATIONNAME = :EXITSTATIONNAME , ");
            strSql.Append(" EXITTIME = :EXITTIME , ");
            strSql.Append(" PAYTYPE = :PAYTYPE  ");
            strSql.Append(" where ID=:ID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":ID", OracleType.Number,4) ,            
                        new OracleParameter(":AXISNUM", OracleType.Number,4) ,            
                        new OracleParameter(":OVERLOADRATE", OracleType.Number,4) ,            
                        new OracleParameter(":TOTALWEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":TOTALTOLL", OracleType.Number,4) ,            
                        new OracleParameter(":DISTANCE", OracleType.Number,4) ,            
                        new OracleParameter(":IMPORTDATE", OracleType.DateTime) ,            
                        new OracleParameter(":VEHICLELICENSE", OracleType.VarChar,200) ,            
                        new OracleParameter(":ENTRYSTATION", OracleType.Number,4) ,            
                        new OracleParameter(":ENTRYSTATIONNAME", OracleType.VarChar,200) ,            
                        new OracleParameter(":ENTRYTIME", OracleType.DateTime) ,            
                        new OracleParameter(":EXITSTATION", OracleType.Number,4) ,            
                        new OracleParameter(":EXITSTATIONNAME", OracleType.VarChar,200) ,            
                        new OracleParameter(":EXITTIME", OracleType.DateTime) ,            
                        new OracleParameter(":PAYTYPE", OracleType.VarChar,200)             
              
            };

            parameters[15].Value = model.ID;
            parameters[16].Value = model.AXISNUM;
            parameters[17].Value = model.OVERLOADRATE;
            parameters[18].Value = model.TOTALWEIGHT;
            parameters[19].Value = model.TOTALTOLL;
            parameters[20].Value = model.DISTANCE;
            parameters[21].Value = model.IMPORTDATE;
            parameters[22].Value = model.VEHICLELICENSE;
            parameters[23].Value = model.ENTRYSTATION;
            parameters[24].Value = model.ENTRYSTATIONNAME;
            parameters[25].Value = model.ENTRYTIME;
            parameters[26].Value = model.EXITSTATION;
            parameters[27].Value = model.EXITSTATIONNAME;
            parameters[28].Value = model.EXITTIME;
            parameters[29].Value = model.PAYTYPE;
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
            strSql.Append("select ID, AXISNUM, OVERLOADRATE, TOTALWEIGHT, TOTALTOLL, DISTANCE, IMPORTDATE, VEHICLELICENSE, ENTRYSTATION, ENTRYSTATIONNAME, ENTRYTIME, EXITSTATION, EXITSTATIONNAME, EXITTIME, PAYTYPE  ");
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
                if (dt.Rows[0]["AXISNUM"].ToString() != "") {
                    entity.AXISNUM = decimal.Parse(dt.Rows[0]["AXISNUM"].ToString());
                }
                if (dt.Rows[0]["OVERLOADRATE"].ToString() != "") {
                    entity.OVERLOADRATE = decimal.Parse(dt.Rows[0]["OVERLOADRATE"].ToString());
                }
                if (dt.Rows[0]["TOTALWEIGHT"].ToString() != "") {
                    entity.TOTALWEIGHT = decimal.Parse(dt.Rows[0]["TOTALWEIGHT"].ToString());
                }
                if (dt.Rows[0]["TOTALTOLL"].ToString() != "") {
                    entity.TOTALTOLL = decimal.Parse(dt.Rows[0]["TOTALTOLL"].ToString());
                }
                if (dt.Rows[0]["DISTANCE"].ToString() != "") {
                    entity.DISTANCE = decimal.Parse(dt.Rows[0]["DISTANCE"].ToString());
                }
                if (dt.Rows[0]["IMPORTDATE"].ToString() != "") {
                    entity.IMPORTDATE = DateTime.Parse(dt.Rows[0]["IMPORTDATE"].ToString());
                }
                entity.VEHICLELICENSE = dt.Rows[0]["VEHICLELICENSE"].ToString();
                if (dt.Rows[0]["ENTRYSTATION"].ToString() != "") {
                    entity.ENTRYSTATION = decimal.Parse(dt.Rows[0]["ENTRYSTATION"].ToString());
                }
                entity.ENTRYSTATIONNAME = dt.Rows[0]["ENTRYSTATIONNAME"].ToString();
                if (dt.Rows[0]["ENTRYTIME"].ToString() != "") {
                    entity.ENTRYTIME = DateTime.Parse(dt.Rows[0]["ENTRYTIME"].ToString());
                }
                if (dt.Rows[0]["EXITSTATION"].ToString() != "") {
                    entity.EXITSTATION = decimal.Parse(dt.Rows[0]["EXITSTATION"].ToString());
                }
                entity.EXITSTATIONNAME = dt.Rows[0]["EXITSTATIONNAME"].ToString();
                if (dt.Rows[0]["EXITTIME"].ToString() != "") {
                    entity.EXITTIME = DateTime.Parse(dt.Rows[0]["EXITTIME"].ToString());
                }
                entity.PAYTYPE = dt.Rows[0]["PAYTYPE"].ToString();

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

        #region 自定义查询

        public void ExecImportDataToOracle(string tabname, string connectionAccess) {
            using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionAccess)) {
                #region 定义Access数据连接对象
                string select = string.Format("SELECT AXISNUM,OVERLOADRATE,TOTALWEIGHT,TOTALTOLL,DISTANCE,VEHICLELICENSE,ENTRYSTATION,ENTRYSTATIONNAME,ENTRYTIME,EXITSTATION,EXITSTATIONNAME,EXITTIME,PAYTYPE FROM {0}", tabname);
                connection.Open();
                System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(select, connection);
                System.Data.OleDb.OleDbDataReader dataRead = command.ExecuteReader();
                
                //获取记录总数
                int size = 0;
                int count = 0;
                DataTable dtCount = new DataTable();
                System.Data.OleDb.OleDbDataAdapter oleDa = new System.Data.OleDb.OleDbDataAdapter(
                    string.Format("select count(1) from {0}",tabname),
                    connectionAccess);
                oleDa.Fill(dtCount);
                count = Convert.ToInt32(dtCount.Rows[0][0].ToString());

                #endregion

                #region Oracle
                #region Insert语句
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into BASE_BUS_OVERRUN(");
                strSql.Append("AXISNUM,OVERLOADRATE,TOTALWEIGHT,TOTALTOLL,DISTANCE,VEHICLELICENSE,ENTRYSTATION,ENTRYSTATIONNAME,ENTRYTIME,EXITSTATION,EXITSTATIONNAME,EXITTIME,PAYTYPE");
                strSql.Append(") values (");
                strSql.Append(":AXISNUM,:OVERLOADRATE,:TOTALWEIGHT,:TOTALTOLL,:DISTANCE,:VEHICLELICENSE,:ENTRYSTATION,:ENTRYSTATIONNAME,:ENTRYTIME,:EXITSTATION,:EXITSTATIONNAME,:EXITTIME,:PAYTYPE");
                strSql.Append(") ");
                #endregion

                #region Oracle参数对象
                OracleParameter[] parameters = {
			            new OracleParameter(":AXISNUM", OracleType.Number,4) ,            
                        new OracleParameter(":OVERLOADRATE", OracleType.Number,4) ,            
                        new OracleParameter(":TOTALWEIGHT", OracleType.Number,4) ,            
                        new OracleParameter(":TOTALTOLL", OracleType.Number,4) ,            
                        new OracleParameter(":DISTANCE", OracleType.Number,4),            
                        new OracleParameter(":VEHICLELICENSE", OracleType.VarChar,200) ,            
                        new OracleParameter(":ENTRYSTATION", OracleType.Number,4) ,            
                        new OracleParameter(":ENTRYSTATIONNAME", OracleType.VarChar,200) ,            
                        new OracleParameter(":ENTRYTIME", OracleType.DateTime) ,            
                        new OracleParameter(":EXITSTATION", OracleType.Number,4) ,            
                        new OracleParameter(":EXITSTATIONNAME", OracleType.VarChar,200) ,            
                        new OracleParameter(":EXITTIME", OracleType.DateTime) ,            
                        new OracleParameter(":PAYTYPE", OracleType.VarChar,200)
                };
                #endregion

                OracleConnection OraConnection = new OracleConnection(OracleHelper.ConnectionString);
                OraConnection.Open();
                OracleCommand Oracommand = OraConnection.CreateCommand();
                Oracommand.CommandType = CommandType.Text;
                Oracommand.CommandText = strSql.ToString();

                #endregion

                #region Begin
                try {
                    while (dataRead.Read()) {
                        parameters[0].Value = dataRead["AXISNUM"];
                        parameters[1].Value = dataRead["OVERLOADRATE"];
                        parameters[2].Value = dataRead["TOTALWEIGHT"];
                        parameters[3].Value = dataRead["TOTALTOLL"];
                        parameters[4].Value = dataRead["DISTANCE"];
                        parameters[5].Value = dataRead["VEHICLELICENSE"];
                        parameters[6].Value = dataRead["ENTRYSTATION"];
                        parameters[7].Value = dataRead["ENTRYSTATIONNAME"];
                        parameters[8].Value = dataRead["ENTRYTIME"];
                        parameters[9].Value = dataRead["EXITSTATION"];
                        parameters[10].Value = dataRead["EXITSTATIONNAME"];
                        parameters[11].Value = dataRead["EXITTIME"];
                        parameters[12].Value = dataRead["PAYTYPE"];
                        foreach (OracleParameter pm in parameters) {
                            Oracommand.Parameters.Add(pm);
                        }
                        
                        Oracommand.ExecuteNonQuery();
                        Oracommand.Parameters.Clear();
                        size++;
                        if (On_CompleteSingle != null) {
                            On_CompleteSingle(size, count);
                        }
                    }
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    connection.Close();
                    connection.Dispose();
                }
                #endregion
            }
        }
        #endregion
    }
}