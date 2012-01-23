
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_MENU : IBASE_MENU
    {
        #region IBASE_MENU 成员

        public bool Exists(int menuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_MENU");
            strSql.Append(" where ");
            strSql.Append(" MENUID = @MENUID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@MENUID", SqlDbType.Int,4)};
            parameters[0].Value = menuid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_MENU model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_MENU(");
            strSql.Append("MENUID,VERSION,SDATE,EDATE,TITLE,SUMMARY,PATH,PARENTID,STATUS,SORT,ICON,LICENSECODE");
            strSql.Append(") values (");
            strSql.Append("@MENUID,@VERSION,@SDATE,@EDATE,@TITLE,@SUMMARY,@PATH,@PARENTID,@STATUS,@SORT,@ICON,@LICENSECODE");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@MENUID", SqlDbType.Int,4) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PATH", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PARENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@LICENSECODE", SqlDbType.VarChar,32)             
              
            };

            parameters[0].Value = model.MENUID;
            parameters[1].Value = model.VERSION;
            parameters[2].Value = model.SDATE;
            parameters[3].Value = model.EDATE;
            parameters[4].Value = model.TITLE;
            parameters[5].Value = model.SUMMARY;
            parameters[6].Value = model.PATH;
            parameters[7].Value = model.PARENTID;
            parameters[8].Value = model.STATUS;
            parameters[9].Value = model.SORT;
            parameters[10].Value = model.ICON;
            parameters[11].Value = model.LICENSECODE;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_MENU model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_MENU set ");

            strSql.Append(" MENUID = @MENUID , ");
            strSql.Append(" VERSION = @VERSION , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" PATH = @PATH , ");
            strSql.Append(" PARENTID = @PARENTID , ");
            strSql.Append(" STATUS = @STATUS , ");
            strSql.Append(" SORT = @SORT , ");
            strSql.Append(" ICON = @ICON , ");
            strSql.Append(" LICENSECODE = @LICENSECODE  ");
            strSql.Append(" where MENUID=@MENUID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@MENUID", SqlDbType.Int,4) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PATH", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PARENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@SORT", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@LICENSECODE", SqlDbType.VarChar,32)             
              
            };

            parameters[12].Value = model.MENUID;
            parameters[13].Value = model.VERSION;
            parameters[14].Value = model.SDATE;
            parameters[15].Value = model.EDATE;
            parameters[16].Value = model.TITLE;
            parameters[17].Value = model.SUMMARY;
            parameters[18].Value = model.PATH;
            parameters[19].Value = model.PARENTID;
            parameters[20].Value = model.STATUS;
            parameters[21].Value = model.SORT;
            parameters[22].Value = model.ICON;
            parameters[23].Value = model.LICENSECODE;
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

        public bool Delete(int menuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_MENU ");
            strSql.Append(" where MENUID=@MENUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MENUID", SqlDbType.Int,4)};
            parameters[0].Value = menuid;


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

        public SmartCampus.Entity.BASE_MENU GetEntity(int menuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MENUID, VERSION, SDATE, EDATE, TITLE, SUMMARY, PATH, PARENTID, STATUS, SORT, ICON, LICENSECODE  ");
            strSql.Append("  from BASE_MENU ");
            strSql.Append(" where MENUID=@MENUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MENUID", SqlDbType.Int,4)};
            parameters[0].Value = menuid;


            SmartCampus.Entity.BASE_MENU model = new SmartCampus.Entity.BASE_MENU();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MENUID"].ToString() != "")
                {
                    model.MENUID = int.Parse(ds.Tables[0].Rows[0]["MENUID"].ToString());
                }
                model.VERSION = ds.Tables[0].Rows[0]["VERSION"].ToString();
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
                }
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                model.PATH = ds.Tables[0].Rows[0]["PATH"].ToString();
                if (ds.Tables[0].Rows[0]["PARENTID"].ToString() != "")
                {
                    model.PARENTID = int.Parse(ds.Tables[0].Rows[0]["PARENTID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SORT"].ToString() != "")
                {
                    model.SORT = int.Parse(ds.Tables[0].Rows[0]["SORT"].ToString());
                }
                model.ICON = ds.Tables[0].Rows[0]["ICON"].ToString();
                model.LICENSECODE = ds.Tables[0].Rows[0]["LICENSECODE"].ToString();

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
            strSql.Append(" FROM BASE_MENU ");
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
            strSql.Append(" FROM BASE_MENU ");
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
