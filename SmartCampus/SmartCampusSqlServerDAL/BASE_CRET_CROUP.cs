
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_CRET_CROUP : IBASE_CRET_CROUP
    {
        #region IBASE_CRET_CROUP 成员

        public bool Exists(int cretgroupid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CRET_CROUP");
            strSql.Append(" where ");
            strSql.Append(" CRETGROUPID = @CRETGROUPID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETGROUPID", SqlDbType.Int,4)};
            parameters[0].Value = cretgroupid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_CRET_CROUP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_CRET_CROUP(");
            strSql.Append("CRETGROUPID,TITLE,SUMMARY,PARENTID,STATUS");
            strSql.Append(") values (");
            strSql.Append("@CRETGROUPID,@TITLE,@SUMMARY,@PARENTID,@STATUS");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@CRETGROUPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PARENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.CRETGROUPID;
            parameters[1].Value = model.TITLE;
            parameters[2].Value = model.SUMMARY;
            parameters[3].Value = model.PARENTID;
            parameters[4].Value = model.STATUS;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_CRET_CROUP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CRET_CROUP set ");

            strSql.Append(" CRETGROUPID = @CRETGROUPID , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" SUMMARY = @SUMMARY , ");
            strSql.Append(" PARENTID = @PARENTID , ");
            strSql.Append(" STATUS = @STATUS  ");
            strSql.Append(" where CRETGROUPID=@CRETGROUPID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@CRETGROUPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SUMMARY", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PARENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4)             
              
            };

            parameters[5].Value = model.CRETGROUPID;
            parameters[6].Value = model.TITLE;
            parameters[7].Value = model.SUMMARY;
            parameters[8].Value = model.PARENTID;
            parameters[9].Value = model.STATUS;
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

        public bool Delete(int cretgroupid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_CRET_CROUP ");
            strSql.Append(" where CRETGROUPID=@CRETGROUPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETGROUPID", SqlDbType.Int,4)};
            parameters[0].Value = cretgroupid;


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

        public SmartCampus.Entity.BASE_CRET_CROUP GetEntity(int cretgroupid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CRETGROUPID, TITLE, SUMMARY, PARENTID, STATUS  ");
            strSql.Append("  from BASE_CRET_CROUP ");
            strSql.Append(" where CRETGROUPID=@CRETGROUPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CRETGROUPID", SqlDbType.Int,4)};
            parameters[0].Value = cretgroupid;


            SmartCampus.Entity.BASE_CRET_CROUP model = new SmartCampus.Entity.BASE_CRET_CROUP();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CRETGROUPID"].ToString() != "")
                {
                    model.CRETGROUPID = int.Parse(ds.Tables[0].Rows[0]["CRETGROUPID"].ToString());
                }
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.SUMMARY = ds.Tables[0].Rows[0]["SUMMARY"].ToString();
                if (ds.Tables[0].Rows[0]["PARENTID"].ToString() != "")
                {
                    model.PARENTID = int.Parse(ds.Tables[0].Rows[0]["PARENTID"].ToString());
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
            strSql.Append(" FROM BASE_CRET_CROUP ");
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
            strSql.Append(" FROM BASE_CRET_CROUP ");
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
