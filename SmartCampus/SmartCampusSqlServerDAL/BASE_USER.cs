
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;


    public class BASE_USER : IBASE_USER
    {
        #region IBASE_USER 成员

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="userid">用户编号</param>
        public bool Exists(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_USER");
            strSql.Append(" where ");
            strSql.Append(" USERID = @USERID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@USERID", SqlDbType.Int,4)};
            parameters[0].Value = userid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <remarks>用户实体对象userid不必赋值。</remarks>
        /// <param name="entity">用户实体</param>
        public void Add(SmartCampus.Entity.BASE_USER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_USER(");
            strSql.Append("USERID,STATUS,ICON,ROLEID,USERNAME,PWD,SEX,EMAIL,TEL,SDATE,EDATE,VERSION");
            strSql.Append(") values (");
            strSql.Append("@USERID,@STATUS,@ICON,@ROLEID,@USERNAME,@PWD,@SEX,@EMAIL,@TEL,@SDATE,@EDATE,@VERSION");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@USERID", SqlDbType.Int,4) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ROLEID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@USERNAME", SqlDbType.VarChar,12) ,            
                        new SqlParameter("@PWD", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@SEX", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@EMAIL", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@TEL", SqlDbType.VarChar,11) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10)             
              
            };

            parameters[0].Value = model.USERID;
            parameters[1].Value = model.STATUS;
            parameters[2].Value = model.ICON;
            parameters[3].Value = model.ROLEID;
            parameters[4].Value = model.USERNAME;
            parameters[5].Value = model.PWD;
            parameters[6].Value = model.SEX;
            parameters[7].Value = model.EMAIL;
            parameters[8].Value = model.TEL;
            parameters[9].Value = model.SDATE;
            parameters[10].Value = model.EDATE;
            parameters[11].Value = model.VERSION;
            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一个用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        public bool Update(SmartCampus.Entity.BASE_USER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_USER set ");

            strSql.Append(" USERID = @USERID , ");
            strSql.Append(" STATUS = @STATUS , ");
            strSql.Append(" ICON = @ICON , ");
            strSql.Append(" ROLEID = @ROLEID , ");
            strSql.Append(" USERNAME = @USERNAME , ");
            strSql.Append(" PWD = @PWD , ");
            strSql.Append(" SEX = @SEX , ");
            strSql.Append(" EMAIL = @EMAIL , ");
            strSql.Append(" TEL = @TEL , ");
            strSql.Append(" SDATE = @SDATE , ");
            strSql.Append(" EDATE = @EDATE , ");
            strSql.Append(" VERSION = @VERSION  ");
            strSql.Append(" where USERID=@USERID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@USERID", SqlDbType.Int,4) ,            
                        new SqlParameter("@STATUS", SqlDbType.Int,4) ,            
                        new SqlParameter("@ICON", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ROLEID", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@USERNAME", SqlDbType.VarChar,12) ,            
                        new SqlParameter("@PWD", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@SEX", SqlDbType.VarChar,2) ,            
                        new SqlParameter("@EMAIL", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@TEL", SqlDbType.VarChar,11) ,            
                        new SqlParameter("@SDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@EDATE", SqlDbType.DateTime) ,            
                        new SqlParameter("@VERSION", SqlDbType.VarChar,10)             
              
            };

            parameters[12].Value = model.USERID;
            parameters[13].Value = model.STATUS;
            parameters[14].Value = model.ICON;
            parameters[15].Value = model.ROLEID;
            parameters[16].Value = model.USERNAME;
            parameters[17].Value = model.PWD;
            parameters[18].Value = model.SEX;
            parameters[19].Value = model.EMAIL;
            parameters[20].Value = model.TEL;
            parameters[21].Value = model.SDATE;
            parameters[22].Value = model.EDATE;
            parameters[23].Value = model.VERSION;
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

        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>true成功,false失败</returns>
        public bool Delete(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_USER ");
            strSql.Append(" where USERID=@USERID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USERID", SqlDbType.Int,4)};
            parameters[0].Value = userid;


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

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="userid">用户编号</param>
        public SmartCampus.Entity.BASE_USER GetEntity(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USERID, STATUS, ICON, ROLEID, USERNAME, PWD, SEX, EMAIL, TEL, SDATE, EDATE, VERSION  ");
            strSql.Append("  from BASE_USER ");
            strSql.Append(" where USERID=@USERID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USERID", SqlDbType.Int,4)};
            parameters[0].Value = userid;


            SmartCampus.Entity.BASE_USER model = new SmartCampus.Entity.BASE_USER();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["USERID"].ToString() != "")
                {
                    model.USERID = int.Parse(ds.Tables[0].Rows[0]["USERID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
                }
                model.ICON = ds.Tables[0].Rows[0]["ICON"].ToString();
                model.ROLEID = ds.Tables[0].Rows[0]["ROLEID"].ToString();
                model.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                model.PWD = ds.Tables[0].Rows[0]["PWD"].ToString();
                model.SEX = ds.Tables[0].Rows[0]["SEX"].ToString();
                model.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                model.TEL = ds.Tables[0].Rows[0]["TEL"].ToString();
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

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BASE_USER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取前Top条记录
        /// </summary>
        /// <param name="Top">返回几条记录</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="filedOrder">Order字段</param>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM BASE_USER ");
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
