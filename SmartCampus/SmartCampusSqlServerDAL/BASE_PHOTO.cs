
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_PHOTO : IBASE_PHOTO
    {
        #region IBASE_PHOTO 成员

        public bool Exists(int photoid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PHOTO");
            strSql.Append(" where ");
            strSql.Append(" PHOTOID = @PHOTOID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@PHOTOID", SqlDbType.Int,4)};
            parameters[0].Value = photoid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_PHOTO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_PHOTO(");
            strSql.Append("PHOTOID,ICON,TITLE,SUMMARY,PATH,VERSION,SDATE,EDATE,GROUPID,STATUS");
            strSql.Append(") values (");
            strSql.Append("@PHOTOID,@ICON,@TITLE,@SUMMARY,@PATH,@VERSION,@SDATE,@EDATE,@GROUPID,@STATUS");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PHOTOID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PATH", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@GROUPID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.PHOTOID;
            parameters[1].Value = model.ICON;
            parameters[2].Value = model.TITLE;
            parameters[3].Value = model.SUMMARY;
            parameters[4].Value = model.PATH;
            parameters[5].Value = model.VERSION;
            parameters[6].Value = model.SDATE;
            parameters[7].Value = model.EDATE;
            parameters[8].Value = model.GROUPID;
            parameters[9].Value = model.STATUS;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_PHOTO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PHOTO set ");

            strSql.Append(" PHOTOID = @PHOTOID , ");
            strSql.Append(" ICON = @ICON , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" PATH = @PATH , ");
            strSql.Append(" VERSION = @VERSION , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" GROUPID = @GROUPID , ");
            strSql.Append(" STATUS = @STATUS  ");
            strSql.Append(" where PHOTOID=@PHOTOID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PHOTOID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PATH", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@GROUPID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4)             
              
            };

            parameters[10].Value = model.PHOTOID;
            parameters[11].Value = model.ICON;
            parameters[12].Value = model.TITLE;
            parameters[13].Value = model.SUMMARY;
            parameters[14].Value = model.PATH;
            parameters[15].Value = model.VERSION;
            parameters[16].Value = model.SDATE;
            parameters[17].Value = model.EDATE;
            parameters[18].Value = model.GROUPID;
            parameters[19].Value = model.STATUS;
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

        public bool Delete(int photoid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_PHOTO ");
            strSql.Append(" where PHOTOID=@PHOTOID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PHOTOID", SqlDbType.Int,4)};
            parameters[0].Value = photoid;


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

        public SmartCampus.Entity.BASE_PHOTO GetEntity(int photoid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PHOTOID, ICON, TITLE, SUMMARY, PATH, VERSION, SDATE, EDATE, GROUPID, STATUS  ");
            strSql.Append("  from BASE_PHOTO ");
            strSql.Append(" where PHOTOID=@PHOTOID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PHOTOID", SqlDbType.Int,4)};
            parameters[0].Value = photoid;


            SmartCampus.Entity.BASE_PHOTO model = new SmartCampus.Entity.BASE_PHOTO();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PHOTOID"].ToString() != "")
                {
                    model.PHOTOID = int.Parse(ds.Tables[0].Rows[0]["PHOTOID"].ToString());
                }
                model.ICON = ds.Tables[0].Rows[0]["ICON"].ToString();
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                model.PATH = ds.Tables[0].Rows[0]["PATH"].ToString();
                model.VERSION = ds.Tables[0].Rows[0]["VERSION"].ToString();
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
                }
                model.GROUPID = ds.Tables[0].Rows[0]["GROUPID"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
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
            strSql.Append(" FROM BASE_PHOTO ");
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
            strSql.Append(" FROM BASE_PHOTO ");
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
