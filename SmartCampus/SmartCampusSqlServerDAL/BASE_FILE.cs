
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_FILE : IBASE_FILE
    {
        #region IBASE_FILE 成员

        public bool Exists(int fileid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_FILE");
            strSql.Append(" where ");
            strSql.Append(" FILEID = @FILEID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@FILEID", SqlDbType.Int,4)};
            parameters[0].Value = fileid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_FILE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_FILE(");
            strSql.Append("FILEID,TITLE,SUMMARY,PATH,SDATE,EDATE,VERSION,ICON");
            strSql.Append(") values (");
            strSql.Append("@FILEID,@TITLE,@SUMMARY,@PATH,@SDATE,@EDATE,@VERSION,@ICON");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@FILEID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PATH", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200)             
              
            };

            parameters[0].Value = model.FILEID;
            parameters[1].Value = model.TITLE;
            parameters[2].Value = model.SUMMARY;
            parameters[3].Value = model.PATH;
            parameters[4].Value = model.SDATE;
            parameters[5].Value = model.EDATE;
            parameters[6].Value = model.VERSION;
            parameters[7].Value = model.ICON;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_FILE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_FILE set ");

            strSql.Append(" FILEID = @FILEID , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" PATH = @PATH , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" VERSION = @VERSION , ");
            strSql.Append(" ICON = @ICON  ");
            strSql.Append(" where FILEID=@FILEID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@FILEID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PATH", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200)             
              
            };

            parameters[8].Value = model.FILEID;
            parameters[9].Value = model.TITLE;
            parameters[10].Value = model.SUMMARY;
            parameters[11].Value = model.PATH;
            parameters[12].Value = model.SDATE;
            parameters[13].Value = model.EDATE;
            parameters[14].Value = model.VERSION;
            parameters[15].Value = model.ICON;
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

        public bool Delete(int fileid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_FILE ");
            strSql.Append(" where FILEID=@FILEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FILEID", SqlDbType.Int,4)};
            parameters[0].Value = fileid;


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

        public SmartCampus.Entity.BASE_FILE GetEntity(int fileid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FILEID, TITLE, SUMMARY, PATH, SDATE, EDATE, VERSION, ICON  ");
            strSql.Append("  from BASE_FILE ");
            strSql.Append(" where FILEID=@FILEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FILEID", SqlDbType.Int,4)};
            parameters[0].Value = fileid;


            SmartCampus.Entity.BASE_FILE model = new SmartCampus.Entity.BASE_FILE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FILEID"].ToString() != "")
                {
                    model.FILEID = int.Parse(ds.Tables[0].Rows[0]["FILEID"].ToString());
                }
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                model.PATH = ds.Tables[0].Rows[0]["PATH"].ToString();
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
                }
                model.VERSION = ds.Tables[0].Rows[0]["VERSION"].ToString();
                model.ICON = ds.Tables[0].Rows[0]["ICON"].ToString();

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
            strSql.Append(" FROM BASE_FILE ");
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
            strSql.Append(" FROM BASE_FILE ");
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
