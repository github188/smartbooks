
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_STUDENT : IBASE_STUDENT
    {
        #region IBASE_STUDENT 成员

        public bool Exists(int studentid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_STUDENT");
            strSql.Append(" where ");
            strSql.Append(" STUDENTID = @STUDENTID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@STUDENTID", SqlDbType.Int,4)};
            parameters[0].Value = studentid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_STUDENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_STUDENT(");
            strSql.Append("STUDENTID,USERNAME,PWD,SEX,CARDNUMBER,SDATE,EDATE,PHOTO,ADDRESS");
            strSql.Append(") values (");
            strSql.Append("@STUDENTID,@USERNAME,@PWD,@SEX,@CARDNUMBER,@SDATE,@EDATE,@PHOTO,@ADDRESS");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@STUDENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@USERNAME", SqlDbType.VarChar,12) ,            
                        new SqlParameter("@PWD", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@SEX", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@CARDNUMBER", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@PHOTO", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ADDRESS", SqlDbType.VarChar,200)             
              
            };

            parameters[0].Value = model.STUDENTID;
            parameters[1].Value = model.USERNAME;
            parameters[2].Value = model.PWD;
            parameters[3].Value = model.SEX;
            parameters[4].Value = model.CARDNUMBER;
            parameters[5].Value = model.SDATE;
            parameters[6].Value = model.EDATE;
            parameters[7].Value = model.PHOTO;
            parameters[8].Value = model.ADDRESS;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Update(SmartCampus.Entity.BASE_STUDENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_STUDENT set ");

            strSql.Append(" STUDENTID = @STUDENTID , ");
            strSql.Append(" USERNAME = @USERNAME , ");
            strSql.Append(" PWD = @PWD , ");
            strSql.Append(" SEX = @SEX , ");
            strSql.Append(" CARDNUMBER = @CARDNUMBER , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" PHOTO = @PHOTO , ");
            strSql.Append(" ADDRESS = @ADDRESS  ");
            strSql.Append(" where STUDENTID=@STUDENTID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@STUDENTID", SqlDbType.Int,4) ,            
                        new SqlParameter("@USERNAME", SqlDbType.VarChar,12) ,            
                        new SqlParameter("@PWD", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@SEX", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@CARDNUMBER", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@PHOTO", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ADDRESS", SqlDbType.VarChar,200)             
              
            };

            parameters[9].Value = model.STUDENTID;
            parameters[10].Value = model.USERNAME;
            parameters[11].Value = model.PWD;
            parameters[12].Value = model.SEX;
            parameters[13].Value = model.CARDNUMBER;
            parameters[14].Value = model.SDATE;
            parameters[15].Value = model.EDATE;
            parameters[16].Value = model.PHOTO;
            parameters[17].Value = model.ADDRESS;
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

        public bool Delete(int studentid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_STUDENT ");
            strSql.Append(" where STUDENTID=@STUDENTID ");
            SqlParameter[] parameters = {
					new SqlParameter("@STUDENTID", SqlDbType.Int,4)};
            parameters[0].Value = studentid;


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

        public SmartCampus.Entity.BASE_STUDENT GetEntity(int studentid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select STUDENTID, USERNAME, PWD, SEX, CARDNUMBER, SDATE, EDATE, PHOTO, ADDRESS  ");
            strSql.Append("  from BASE_STUDENT ");
            strSql.Append(" where STUDENTID=@STUDENTID ");
            SqlParameter[] parameters = {
					new SqlParameter("@STUDENTID", SqlDbType.Int,4)};
            parameters[0].Value = studentid;


            SmartCampus.Entity.BASE_STUDENT model = new SmartCampus.Entity.BASE_STUDENT();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["STUDENTID"].ToString() != "")
                {
                    model.STUDENTID = int.Parse(ds.Tables[0].Rows[0]["STUDENTID"].ToString());
                }
                model.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                model.PWD = ds.Tables[0].Rows[0]["PWD"].ToString();
                model.SEX = ds.Tables[0].Rows[0]["SEX"].ToString();
                model.CARDNUMBER = ds.Tables[0].Rows[0]["CARDNUMBER"].ToString();
                if (ds.Tables[0].Rows[0]["SDATE"].ToString() != "")
                {
                    model.SDATE = DateTime.Parse(ds.Tables[0].Rows[0]["SDATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EDATE"].ToString() != "")
                {
                    model.EDATE = DateTime.Parse(ds.Tables[0].Rows[0]["EDATE"].ToString());
                }
                model.PHOTO = ds.Tables[0].Rows[0]["PHOTO"].ToString();
                model.ADDRESS = ds.Tables[0].Rows[0]["ADDRESS"].ToString();

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
            strSql.Append(" FROM BASE_STUDENT ");
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
            strSql.Append(" FROM BASE_STUDENT ");
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
