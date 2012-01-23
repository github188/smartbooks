
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_CRET : IBASE_CRET
    {
        #region IBASE_CRET 成员

        public bool Exists(int cretid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CRET");
            strSql.Append(" where ");
            strSql.Append(" CRETID = @CRETID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETID", SqlDbType.Int,4)};
            parameters[0].Value = cretid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_CRET entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_CRET(");
            strSql.Append("CRETID,CRETNO,CRETNAME,CRETGROUPID,SUMMARY,IMAGE,SDATE,EDATE");
            strSql.Append(") values (");
            strSql.Append("@CRETID,@CRETNO,@CRETNAME,@CRETGROUPID,@SUMMARY,@IMAGE,@SDATE,@EDATE");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@CRETID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CRETNO", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CRETNAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CRETGROUPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@IMAGE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = entity.CRETID;
            parameters[1].Value = entity.CRETNO;
            parameters[2].Value = entity.CRETNAME;
            parameters[3].Value = entity.CRETGROUPID;
            parameters[4].Value = entity.SUMMARY;
            parameters[5].Value = entity.IMAGE;
            parameters[6].Value = entity.SDATE;
            parameters[7].Value = entity.EDATE;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_CRET model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CRET set ");

            strSql.Append(" CRETID = @CRETID , ");
            strSql.Append(" CRETNO = @CRETNO , ");
            strSql.Append(" CRETNAME = @CRETNAME , ");
            strSql.Append(" CRETGROUPID = @CRETGROUPID , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" IMAGE = @IMAGE , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE  ");
            strSql.Append(" where CRETID=@CRETID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@CRETID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CRETNO", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CRETNAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CRETGROUPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@IMAGE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime)             
              
            };

            parameters[8].Value = model.CRETID;
            parameters[9].Value = model.CRETNO;
            parameters[10].Value = model.CRETNAME;
            parameters[11].Value = model.CRETGROUPID;
            parameters[12].Value = model.SUMMARY;
            parameters[13].Value = model.IMAGE;
            parameters[14].Value = model.SDATE;
            parameters[15].Value = model.EDATE;
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

        public bool Delete(int cretid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_CRET ");
            strSql.Append(" where CRETID=@CRETID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETID", SqlDbType.Int,4)};
            parameters[0].Value = cretid;


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

        public SmartCampus.Entity.BASE_CRET GetEntity(int cretid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CRETID, CRETNO, CRETNAME, CRETGROUPID, SUMMARY, IMAGE, SDATE, EDATE  ");
            strSql.Append("  from BASE_CRET ");
            strSql.Append(" where CRETID=@CRETID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETID", SqlDbType.Int,4)};
            parameters[0].Value = cretid;


            SmartCampus.Entity.BASE_CRET model = new SmartCampus.Entity.BASE_CRET();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CRETID"].ToString() != "")
                {
                    model.CRETID = int.Parse(ds.Tables[0].Rows[0]["CRETID"].ToString());
                }
                model.CRETNO = ds.Tables[0].Rows[0]["CRETNO"].ToString();
                model.CRETNAME = ds.Tables[0].Rows[0]["CRETNAME"].ToString();
                if (ds.Tables[0].Rows[0]["CRETGROUPID"].ToString() != "")
                {
                    model.CRETGROUPID = int.Parse(ds.Tables[0].Rows[0]["CRETGROUPID"].ToString());
                }
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                model.IMAGE = ds.Tables[0].Rows[0]["IMAGE"].ToString();
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
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
            strSql.Append(" FROM BASE_CRET ");
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
            strSql.Append(" FROM BASE_CRET ");
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
