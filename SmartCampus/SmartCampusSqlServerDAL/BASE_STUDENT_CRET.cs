
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_STUDENT_CRET : IBASE_STUDENT_CRET
    {
        #region IBASE_STUDENT_CRET 成员

        public bool Exists(int studentcretid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_STUDENT_CRET");
            strSql.Append(" where ");
            strSql.Append(" STUDENTCRETID = @STUDENTCRETID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@STUDENTCRETID", SqlDbType.Int,4)};
            parameters[0].Value = studentcretid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_STUDENT_CRET model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_STUDENT_CRET(");
            strSql.Append("STUDENTCRETID,STUDENTID,CRETID,SDATE,EDATE,BISHI,JISHI,STATUS,CRETLEVALID");
            strSql.Append(") values (");
            strSql.Append("@STUDENTCRETID,@STUDENTID,@CRETID,@SDATE,@EDATE,@BISHI,@JISHI,@STATUS,@CRETLEVALID");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@STUDENTCRETID", SqlDbType.Int,4) ,            
                        new SqlParameter("@STUDENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CRETID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@BISHI", SqlDbType.Float,8) ,            
                        new SqlParameter("@JISHI", SqlDbType.Float,8) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@CRETLEVALID", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.STUDENTCRETID;
            parameters[1].Value = model.STUDENTID;
            parameters[2].Value = model.CRETID;
            parameters[3].Value = model.SDATE;
            parameters[4].Value = model.EDATE;
            parameters[5].Value = model.BISHI;
            parameters[6].Value = model.JISHI;
            parameters[7].Value = model.STATUS;
            parameters[8].Value = model.CRETLEVALID;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_STUDENT_CRET model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_STUDENT_CRET set ");

            strSql.Append(" STUDENTCRETID = @STUDENTCRETID , ");
            strSql.Append(" STUDENTID = @STUDENTID , ");
            strSql.Append(" CRETID = @CRETID , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" BISHI = @BISHI , ");
            strSql.Append(" JISHI = @JISHI , ");
            strSql.Append(" STATUS = @STATUS , ");
            strSql.Append(" CRETLEVALID = @CRETLEVALID  ");
            strSql.Append(" where STUDENTCRETID=@STUDENTCRETID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@STUDENTCRETID", SqlDbType.Int,4) ,            
                        new SqlParameter("@STUDENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CRETID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@BISHI", SqlDbType.Float,8) ,            
                        new SqlParameter("@JISHI", SqlDbType.Float,8) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@CRETLEVALID", SqlDbType.Int,4)             
              
            };

            parameters[9].Value = model.STUDENTCRETID;
            parameters[10].Value = model.STUDENTID;
            parameters[11].Value = model.CRETID;
            parameters[12].Value = model.SDATE;
            parameters[13].Value = model.EDATE;
            parameters[14].Value = model.BISHI;
            parameters[15].Value = model.JISHI;
            parameters[16].Value = model.STATUS;
            parameters[17].Value = model.CRETLEVALID;
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int studentcretid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_STUDENT_CRET ");
            strSql.Append(" where STUDENTCRETID=@STUDENTCRETID ");
            SqlParameter[] parameters = {
					new SqlParameter("@STUDENTCRETID", SqlDbType.Int,4)};
            parameters[0].Value = studentcretid;


            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SmartCampus.Entity.BASE_STUDENT_CRET GetEntity(int studentcretid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select STUDENTCRETID, STUDENTID, CRETID, SDATE, EDATE, BISHI, JISHI, STATUS, CRETLEVALID  ");
            strSql.Append("  from BASE_STUDENT_CRET ");
            strSql.Append(" where STUDENTCRETID=@STUDENTCRETID ");
            SqlParameter[] parameters = {
					new SqlParameter("@STUDENTCRETID", SqlDbType.Int,4)};
            parameters[0].Value = studentcretid;


            SmartCampus.Entity.BASE_STUDENT_CRET model = new SmartCampus.Entity.BASE_STUDENT_CRET();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["STUDENTCRETID"].ToString() != "")
                {
                    model.STUDENTCRETID = int.Parse(ds.Tables[0].Rows[0]["STUDENTCRETID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STUDENTID"].ToString() != "")
                {
                    model.STUDENTID = int.Parse(ds.Tables[0].Rows[0]["STUDENTID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CRETID"].ToString() != "")
                {
                    model.CRETID = int.Parse(ds.Tables[0].Rows[0]["CRETID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BISHI"].ToString() != "")
                {
                    model.BISHI = decimal.Parse(ds.Tables[0].Rows[0]["BISHI"].ToString());
                }
                if (ds.Tables[0].Rows[0]["JISHI"].ToString() != "")
                {
                    model.JISHI = decimal.Parse(ds.Tables[0].Rows[0]["JISHI"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CRETLEVALID"].ToString() != "")
                {
                    model.CRETLEVALID = int.Parse(ds.Tables[0].Rows[0]["CRETLEVALID"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BASE_STUDENT_CRET ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM BASE_STUDENT_CRET ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }

        #endregion
    }
}
