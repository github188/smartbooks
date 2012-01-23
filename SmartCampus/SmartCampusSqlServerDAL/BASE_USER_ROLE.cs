
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_USER_ROLE : IBASE_USER_ROLE
    {
        #region IBASE_USER_ROLE 成员

        public bool Exists(int roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_USER_ROLE");
            strSql.Append(" where ");
            strSql.Append(" ROLEID = @ROLEID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLEID", SqlDbType.Int,4)};
            parameters[0].Value = roleid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_USER_ROLE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_USER_ROLE(");
            strSql.Append("ROLEID,TITLE,SUMMARY,SDATE,EDATE,STATUS,VERSION");
            strSql.Append(") values (");
            strSql.Append("@ROLEID,@TITLE,@SUMMARY,@SDATE,@EDATE,@STATUS,@VERSION");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ROLEID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10)             
              
            };

            parameters[0].Value = model.ROLEID;
            parameters[1].Value = model.TITLE;
            parameters[2].Value = model.SUMMARY;
            parameters[3].Value = model.SDATE;
            parameters[4].Value = model.EDATE;
            parameters[5].Value = model.STATUS;
            parameters[6].Value = model.VERSION;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_USER_ROLE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_USER_ROLE set ");

            strSql.Append(" ROLEID = @ROLEID , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" STATUS = @STATUS , ");
            strSql.Append(" VERSION = @VERSION  ");
            strSql.Append(" where ROLEID=@ROLEID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ROLEID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10)             
              
            };

            parameters[7].Value = model.ROLEID;
            parameters[8].Value = model.TITLE;
            parameters[9].Value = model.SUMMARY;
            parameters[10].Value = model.SDATE;
            parameters[11].Value = model.EDATE;
            parameters[12].Value = model.STATUS;
            parameters[13].Value = model.VERSION;
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

        public bool Delete(int roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_USER_ROLE ");
            strSql.Append(" where ROLEID=@ROLEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLEID", SqlDbType.Int,4)};
            parameters[0].Value = roleid;


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

        public SmartCampus.Entity.BASE_USER_ROLE GetEntity(int roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROLEID, TITLE, SUMMARY, SDATE, EDATE, STATUS, VERSION  ");
            strSql.Append("  from BASE_USER_ROLE ");
            strSql.Append(" where ROLEID=@ROLEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLEID", SqlDbType.Int,4)};
            parameters[0].Value = roleid;


            SmartCampus.Entity.BASE_USER_ROLE model = new SmartCampus.Entity.BASE_USER_ROLE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ROLEID"].ToString() != "")
                {
                    model.ROLEID = int.Parse(ds.Tables[0].Rows[0]["ROLEID"].ToString());
                }
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
                }
                model.VERSION = ds.Tables[0].Rows[0]["VERSION"].ToString();

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
            strSql.Append(" FROM BASE_USER_ROLE ");
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
            strSql.Append(" FROM BASE_USER_ROLE ");
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
