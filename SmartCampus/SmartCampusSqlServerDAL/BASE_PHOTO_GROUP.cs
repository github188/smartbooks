
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_PHOTO_GROUP : IBASE_PHOTO_GROUP
    {
        #region IBASE_PHOTO_GROUP 成员

        public bool Exists(int groupid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PHOTO_GROUP");
            strSql.Append(" where ");
            strSql.Append(" GROUPID = @GROUPID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@GROUPID", SqlDbType.Int,4)};
            parameters[0].Value = groupid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_PHOTO_GROUP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_PHOTO_GROUP(");
            strSql.Append("GROUPID,ICON,TITLE,SUMMARY,SORT,STATUS,PARENTID,SDATE,EDATE,VERSION");
            strSql.Append(") values (");
            strSql.Append("@GROUPID,@ICON,@TITLE,@SUMMARY,@SORT,@STATUS,@PARENTID,@SDATE,@EDATE,@VERSION");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@GROUPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@PARENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10)             
              
            };

            parameters[0].Value = model.GROUPID;
            parameters[1].Value = model.ICON;
            parameters[2].Value = model.TITLE;
            parameters[3].Value = model.SUMMARY;
            parameters[4].Value = model.SORT;
            parameters[5].Value = model.STATUS;
            parameters[6].Value = model.PARENTID;
            parameters[7].Value = model.SDATE;
            parameters[8].Value = model.EDATE;
            parameters[9].Value = model.VERSION;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_PHOTO_GROUP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PHOTO_GROUP set ");

            strSql.Append(" GROUPID = @GROUPID , ");
            strSql.Append(" ICON = @ICON , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" SORT = @SORT , ");
            strSql.Append(" STATUS = @STATUS , ");
            strSql.Append(" PARENTID = @PARENTID , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" VERSION = @VERSION  ");
            strSql.Append(" where GROUPID=@GROUPID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@GROUPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@PARENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10)             
              
            };

            parameters[10].Value = model.GROUPID;
            parameters[11].Value = model.ICON;
            parameters[12].Value = model.TITLE;
            parameters[13].Value = model.SUMMARY;
            parameters[14].Value = model.SORT;
            parameters[15].Value = model.STATUS;
            parameters[16].Value = model.PARENTID;
            parameters[17].Value = model.SDATE;
            parameters[18].Value = model.EDATE;
            parameters[19].Value = model.VERSION;
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

        public bool Delete(int groupid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_PHOTO_GROUP ");
            strSql.Append(" where GROUPID=@GROUPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GROUPID", SqlDbType.Int,4)};
            parameters[0].Value = groupid;


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

        public SmartCampus.Entity.BASE_PHOTO_GROUP GetEntity(int groupid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GROUPID, ICON, TITLE, SUMMARY, SORT, STATUS, PARENTID, SDATE, EDATE, VERSION  ");
            strSql.Append("  from BASE_PHOTO_GROUP ");
            strSql.Append(" where GROUPID=@GROUPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GROUPID", SqlDbType.Int,4)};
            parameters[0].Value = groupid;


            SmartCampus.Entity.BASE_PHOTO_GROUP model = new SmartCampus.Entity.BASE_PHOTO_GROUP();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["GROUPID"].ToString() != "")
                {
                    model.GROUPID = int.Parse(ds.Tables[0].Rows[0]["GROUPID"].ToString());
                }
                model.ICON = ds.Tables[0].Rows[0]["ICON"].ToString();
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                if (ds.Tables[0].Rows[0]["SORT"].ToString() != "")
                {
                    model.SORT = int.Parse(ds.Tables[0].Rows[0]["SORT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PARENTID"].ToString() != "")
                {
                    model.PARENTID = int.Parse(ds.Tables[0].Rows[0]["PARENTID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
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
            strSql.Append(" FROM BASE_PHOTO_GROUP ");
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
            strSql.Append(" FROM BASE_PHOTO_GROUP ");
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
