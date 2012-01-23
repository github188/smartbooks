
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_LINK : IBASE_LINK
    {
        #region IBASE_LINK 成员

        public bool Exists(int linkid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_LINK");
            strSql.Append(" where ");
            strSql.Append(" LINKID = @LINKID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@LINKID", SqlDbType.Int,4)};
            parameters[0].Value = linkid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_LINK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_LINK(");
            strSql.Append("LINKID,VERSION,ICON,TITLE,SUMMARY,HOME,PR,IMAGE,SDATE,EDATE,STATUS");
            strSql.Append(") values (");
            strSql.Append("@LINKID,@VERSION,@ICON,@TITLE,@SUMMARY,@HOME,@PR,@IMAGE,@SDATE,@EDATE,@STATUS");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@LINKID", SqlDbType.Int,4) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@HOME", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PR", SqlDbType.Int,4) ,            
                        new SqlParameter("@IMAGE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.LINKID;
            parameters[1].Value = model.VERSION;
            parameters[2].Value = model.ICON;
            parameters[3].Value = model.TITLE;
            parameters[4].Value = model.SUMMARY;
            parameters[5].Value = model.HOME;
            parameters[6].Value = model.PR;
            parameters[7].Value = model.IMAGE;
            parameters[8].Value = model.SDATE;
            parameters[9].Value = model.EDATE;
            parameters[10].Value = model.STATUS;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_LINK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_LINK set ");

            strSql.Append(" LINKID = @LINKID , ");
            strSql.Append(" VERSION = @VERSION , ");
            strSql.Append(" ICON = @ICON , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" HOME = @HOME , ");
            strSql.Append(" PR = @PR , ");
            strSql.Append(" IMAGE = @IMAGE , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" STATUS = @STATUS  ");
            strSql.Append(" where LINKID=@LINKID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@LINKID", SqlDbType.Int,4) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@HOME", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PR", SqlDbType.Int,4) ,            
                        new SqlParameter("@IMAGE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4)             
              
            };

            parameters[11].Value = model.LINKID;
            parameters[12].Value = model.VERSION;
            parameters[13].Value = model.ICON;
            parameters[14].Value = model.TITLE;
            parameters[15].Value = model.SUMMARY;
            parameters[16].Value = model.HOME;
            parameters[17].Value = model.PR;
            parameters[18].Value = model.IMAGE;
            parameters[19].Value = model.SDATE;
            parameters[20].Value = model.EDATE;
            parameters[21].Value = model.STATUS;
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

        public bool Delete(int linkid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_LINK ");
            strSql.Append(" where LINKID=@LINKID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LINKID", SqlDbType.Int,4)};
            parameters[0].Value = linkid;


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

        public SmartCampus.Entity.BASE_LINK GetEntity(int linkid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LINKID, VERSION, ICON, TITLE, SUMMARY, HOME, PR, IMAGE, SDATE, EDATE, STATUS  ");
            strSql.Append("  from BASE_LINK ");
            strSql.Append(" where LINKID=@LINKID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LINKID", SqlDbType.Int,4)};
            parameters[0].Value = linkid;


            SmartCampus.Entity.BASE_LINK model = new SmartCampus.Entity.BASE_LINK();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["LINKID"].ToString() != "")
                {
                    model.LINKID = int.Parse(ds.Tables[0].Rows[0]["LINKID"].ToString());
                }
                model.VERSION = ds.Tables[0].Rows[0]["VERSION"].ToString();
                model.ICON = ds.Tables[0].Rows[0]["ICON"].ToString();
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                model.HOME = ds.Tables[0].Rows[0]["HOME"].ToString();
                if (ds.Tables[0].Rows[0]["PR"].ToString() != "")
                {
                    model.PR = int.Parse(ds.Tables[0].Rows[0]["PR"].ToString());
                }
                model.IMAGE = ds.Tables[0].Rows[0]["IMAGE"].ToString();
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
            strSql.Append(" FROM BASE_LINK ");
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
            strSql.Append(" FROM BASE_LINK ");
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
