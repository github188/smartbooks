using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Smart.DBUtility;
namespace SmartTeaching.DAL
{
    //Base_BBS
    public partial class Base_BBS
    {

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_BBS");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_BBS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_BBS(");
            strSql.Append("UserId,ToUserId,NewsId,CreateDate,NewsContent");
            strSql.Append(") values (");
            strSql.Append("@UserId,@ToUserId,@NewsId,@CreateDate,@NewsContent");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ToUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@NewsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@NewsContent", SqlDbType.VarChar,200)             
              
            };

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.ToUserId;
            parameters[2].Value = model.NewsId;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.NewsContent;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_BBS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_BBS set ");

            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" ToUserId = @ToUserId , ");
            strSql.Append(" NewsId = @NewsId , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" NewsContent = @NewsContent  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ToUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@NewsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@NewsContent", SqlDbType.VarChar,200)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.ToUserId;
            parameters[3].Value = model.NewsId;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.NewsContent;
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_BBS ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_BBS ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public SmartTeaching.Entity.Base_BBS GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, UserId, ToUserId, NewsId, CreateDate, NewsContent  ");
            strSql.Append("  from Base_BBS ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            SmartTeaching.Entity.Base_BBS model = new SmartTeaching.Entity.Base_BBS();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ToUserId"].ToString() != "")
                {
                    model.ToUserId = int.Parse(ds.Tables[0].Rows[0]["ToUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewsId"].ToString() != "")
                {
                    model.NewsId = int.Parse(ds.Tables[0].Rows[0]["NewsId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                model.NewsContent = ds.Tables[0].Rows[0]["NewsContent"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Base_BBS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Base_BBS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

