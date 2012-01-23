
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_ARTICLE : IBASE_ARTICLE
    {
        #region IBASE_ARTICLE 成员

        public bool Exists(int articleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ARTICLE");
            strSql.Append(" where ");
            strSql.Append(" ARTICLEID = @ARTICLEID  ");

            SqlParameter[] parameters = { new SqlParameter("@ARTICLEID", SqlDbType.Int, 4) };
            parameters[0].Value = articleid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_ARTICLE entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_ARTICLE(");
            strSql.Append("ARTICLEID,QUOTE,MENUID,PHOTOID,FILEID,VERSION,STATUS,ICON,TITLE,CONTENT,SDATE,EDATE,READ,COMMENT,COPYRIGHT,AUTHOR");
            strSql.Append(") values (");
            strSql.Append("@ARTICLEID,@QUOTE,@MENUID,@PHOTOID,@FILEID,@VERSION,@STATUS,@ICON,@TITLE,@CONTENT,@SDATE,@EDATE,@READ,@COMMENT,@COPYRIGHT,@AUTHOR");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ARTICLEID", SqlDbType.Int,4) ,            
                        new SqlParameter("@QUOTE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@MENUID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PHOTOID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FILEID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@CONTENT", SqlDbType.Text) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@READ", SqlDbType.Int,4) ,            
                        new SqlParameter("@COMMENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@COPYRIGHT", SqlDbType.VarChar,2000) ,            
                        new SqlParameter("@AUTHOR", SqlDbType.VarChar,20)             
              
            };

            parameters[0].Value = entity.ARTICLEID;
            parameters[1].Value = entity.QUOTE;
            parameters[2].Value = entity.MENUID;
            parameters[3].Value = entity.PHOTOID;
            parameters[4].Value = entity.FILEID;
            parameters[5].Value = entity.VERSION;
            parameters[6].Value = entity.STATUS;
            parameters[7].Value = entity.ICON;
            parameters[8].Value = entity.TITLE;
            parameters[9].Value = entity.CONTENT;
            parameters[10].Value = entity.SDATE;
            parameters[11].Value = entity.EDATE;
            parameters[12].Value = entity.READ;
            parameters[13].Value = entity.COMMENT;
            parameters[14].Value = entity.COPYRIGHT;
            parameters[15].Value = entity.AUTHOR;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_ARTICLE entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_ARTICLE set ");

            strSql.Append(" ARTICLEID = @ARTICLEID , ");
            strSql.Append(" QUOTE = @QUOTE , ");
            strSql.Append(" MENUID = @MENUID , ");
            strSql.Append(" PHOTOID = @PHOTOID , ");
            strSql.Append(" FILEID = @FILEID , ");
            strSql.Append(" VERSION = @VERSION , ");
            strSql.Append(" STATUS = @STATUS , ");
            strSql.Append(" ICON = @ICON , ");
            strSql.Append(" TITLE = @TITLE , ");
            strSql.Append(" CONTENT = @CONTENT , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" READ = @READ , ");
            strSql.Append(" COMMENT = @COMMENT , ");
            strSql.Append(" COPYRIGHT = @COPYRIGHT , ");
            strSql.Append(" AUTHOR = @AUTHOR  ");
            strSql.Append(" where ARTICLEID=@ARTICLEID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ARTICLEID", SqlDbType.Int,4) ,            
                        new SqlParameter("@QUOTE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@MENUID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@PHOTOID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FILEID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@TITLE", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@CONTENT", SqlDbType.Text) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@READ", SqlDbType.Int,4) ,            
                        new SqlParameter("@COMMENT", SqlDbType.Int,4) ,            
                        new SqlParameter("@COPYRIGHT", SqlDbType.VarChar,2000) ,            
                        new SqlParameter("@AUTHOR", SqlDbType.VarChar,20)             
              
            };

            parameters[16].Value = entity.ARTICLEID;
            parameters[17].Value = entity.QUOTE;
            parameters[18].Value = entity.MENUID;
            parameters[19].Value = entity.PHOTOID;
            parameters[20].Value = entity.FILEID;
            parameters[21].Value = entity.VERSION;
            parameters[22].Value = entity.STATUS;
            parameters[23].Value = entity.ICON;
            parameters[24].Value = entity.TITLE;
            parameters[25].Value = entity.CONTENT;
            parameters[26].Value = entity.SDATE;
            parameters[27].Value = entity.EDATE;
            parameters[28].Value = entity.READ;
            parameters[29].Value = entity.COMMENT;
            parameters[30].Value = entity.COPYRIGHT;
            parameters[31].Value = entity.AUTHOR;
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

        public bool Delete(int articleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_ARTICLE ");
            strSql.Append(" where ARTICLEID=@ARTICLEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARTICLEID", SqlDbType.Int,4)};
            parameters[0].Value = articleid;


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

        public SmartCampus.Entity.BASE_ARTICLE GetEntity(int articleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ARTICLEID, QUOTE, MENUID, PHOTOID, FILEID, VERSION, STATUS, ICON, TITLE, CONTENT, SDATE, EDATE, READ, COMMENT, COPYRIGHT, AUTHOR  ");
            strSql.Append("  from BASE_ARTICLE ");
            strSql.Append(" where ARTICLEID=@ARTICLEID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARTICLEID", SqlDbType.Int,4)};
            parameters[0].Value = articleid;


            SmartCampus.Entity.BASE_ARTICLE model = new SmartCampus.Entity.BASE_ARTICLE();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ARTICLEID"].ToString() != "")
                {
                    model.ARTICLEID = int.Parse(ds.Tables[0].Rows[0]["ARTICLEID"].ToString());
                }
                model.QUOTE = ds.Tables[0].Rows[0]["QUOTE"].ToString();
                model.MENUID = ds.Tables[0].Rows[0]["MENUID"].ToString();
                model.PHOTOID = ds.Tables[0].Rows[0]["PHOTOID"].ToString();
                model.FILEID = ds.Tables[0].Rows[0]["FILEID"].ToString();
                model.VERSION = ds.Tables[0].Rows[0]["VERSION"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
                }
                model.ICON = ds.Tables[0].Rows[0]["ICON"].ToString();
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                model.CONTENT = ds.Tables[0].Rows[0]["CONTENT"].ToString();
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["READ"].ToString() != "")
                {
                    model.READ = int.Parse(ds.Tables[0].Rows[0]["READ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COMMENT"].ToString() != "")
                {
                    model.COMMENT = int.Parse(ds.Tables[0].Rows[0]["COMMENT"].ToString());
                }
                model.COPYRIGHT = ds.Tables[0].Rows[0]["COPYRIGHT"].ToString();
                model.AUTHOR = ds.Tables[0].Rows[0]["AUTHOR"].ToString();

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
            strSql.Append(" FROM BASE_ARTICLE ");
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
            strSql.Append(" FROM BASE_ARTICLE ");
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
