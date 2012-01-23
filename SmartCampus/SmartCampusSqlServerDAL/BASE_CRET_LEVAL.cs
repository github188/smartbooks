
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_CRET_LEVAL : IBASE_CRET_LEVAL
    {
        #region IBASE_CRET_LEVAL 成员

        public bool Exists(int cretlevalid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CRET_LEVAL");
            strSql.Append(" where ");
            strSql.Append(" CRETLEVALID = @CRETLEVALID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETLEVALID", SqlDbType.Int,4)};
            parameters[0].Value = cretlevalid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_CRET_LEVAL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_CRET_LEVAL(");
            strSql.Append("CRETLEVALID,CRETID,SCORE,TITLE,SUMMARY,STATUS");
            strSql.Append(") values (");
            strSql.Append("@CRETLEVALID,@CRETID,@SCORE,@TITLE,@SUMMARY,@STATUS");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@CRETLEVALID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CRETID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SCORE", SqlDbType.Float,8) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.CRETLEVALID;
            parameters[1].Value = model.CRETID;
            parameters[2].Value = model.SCORE;
            parameters[3].Value = model.TITLE;
            parameters[4].Value = model.SUMMARY;
            parameters[5].Value = model.STATUS;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_CRET_LEVAL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CRET_LEVAL set ");

            strSql.Append(" CRETLEVALID = @CRETLEVALID , ");
            strSql.Append(" CRETID = @CRETID , ");
            strSql.Append(" SCORE = @SCORE , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" STATUS = @STATUS  ");
            strSql.Append(" where CRETLEVALID=@CRETLEVALID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@CRETLEVALID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CRETID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SCORE", SqlDbType.Float,8) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4)             
              
            };

            parameters[6].Value = model.CRETLEVALID;
            parameters[7].Value = model.CRETID;
            parameters[8].Value = model.SCORE;
            parameters[9].Value = model.TITLE;
            parameters[10].Value = model.SUMMARY;
            parameters[11].Value = model.STATUS;
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

        public bool Delete(int cretlevalid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_CRET_LEVAL ");
            strSql.Append(" where CRETLEVALID=@CRETLEVALID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETLEVALID", SqlDbType.Int,4)};
            parameters[0].Value = cretlevalid;


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

        public SmartCampus.Entity.BASE_CRET_LEVAL GetEntity(int cretlevalid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CRETLEVALID, CRETID, SCORE, TITLE, SUMMARY, STATUS  ");
            strSql.Append("  from BASE_CRET_LEVAL ");
            strSql.Append(" where CRETLEVALID=@CRETLEVALID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETLEVALID", SqlDbType.Int,4)};
            parameters[0].Value = cretlevalid;


            SmartCampus.Entity.BASE_CRET_LEVAL model = new SmartCampus.Entity.BASE_CRET_LEVAL();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CRETLEVALID"].ToString() != "")
                {
                    model.CRETLEVALID = int.Parse(ds.Tables[0].Rows[0]["CRETLEVALID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CRETID"].ToString() != "")
                {
                    model.CRETID = int.Parse(ds.Tables[0].Rows[0]["CRETID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SCORE"].ToString() != "")
                {
                    model.SCORE = decimal.Parse(ds.Tables[0].Rows[0]["SCORE"].ToString());
                }
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
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
            strSql.Append(" FROM BASE_CRET_LEVAL ");
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
            strSql.Append(" FROM BASE_CRET_LEVAL ");
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
