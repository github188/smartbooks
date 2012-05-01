using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Smart.DBUtility;
namespace SmartTeaching.DAL
{
    //Base_News
    public partial class Base_News
    {

        public bool Exists(int NewsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_News");
            strSql.Append(" where ");
            strSql.Append(" NewsId = @NewsId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsId;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_News(");
            strSql.Append("NewsTypeId,UserId,NewsTitle,NewsContent,CreateDate,Summary,FileName,FilePath,FileSize");
            strSql.Append(") values (");
            strSql.Append("@NewsTypeId,@UserId,@NewsTitle,@NewsContent,@CreateDate,@Summary,@FileName,@FilePath,@FileSize");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@NewsTypeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@NewsTitle", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@NewsContent", SqlDbType.Text) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Summary", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FileName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@FilePath", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FileSize", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.NewsTypeId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.NewsTitle;
            parameters[3].Value = model.NewsContent;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.Summary;
            parameters[6].Value = model.FileName;
            parameters[7].Value = model.FilePath;
            parameters[8].Value = model.FileSize;

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
        public bool Update(SmartTeaching.Entity.Base_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_News set ");

            strSql.Append(" NewsTypeId = @NewsTypeId , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" NewsTitle = @NewsTitle , ");
            strSql.Append(" NewsContent = @NewsContent , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" Summary = @Summary , ");
            strSql.Append(" FileName = @FileName , ");
            strSql.Append(" FilePath = @FilePath , ");
            strSql.Append(" FileSize = @FileSize  ");
            strSql.Append(" where NewsId=@NewsId ");

            SqlParameter[] parameters = {
			            new SqlParameter("@NewsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@NewsTypeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@NewsTitle", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@NewsContent", SqlDbType.Text) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Summary", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FileName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@FilePath", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FileSize", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.NewsId;
            parameters[1].Value = model.NewsTypeId;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.NewsTitle;
            parameters[4].Value = model.NewsContent;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.Summary;
            parameters[7].Value = model.FileName;
            parameters[8].Value = model.FilePath;
            parameters[9].Value = model.FileSize;
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
        public bool Delete(int NewsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_News ");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsId;


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
        public bool DeleteList(string NewsIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_News ");
            strSql.Append(" where ID in (" + NewsIdlist + ")  ");
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
        public SmartTeaching.Entity.Base_News GetModel(int NewsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NewsId, NewsTypeId, UserId, NewsTitle, NewsContent, CreateDate, Summary, FileName, FilePath, FileSize  ");
            strSql.Append("  from Base_News ");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsId;


            SmartTeaching.Entity.Base_News model = new SmartTeaching.Entity.Base_News();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["NewsId"].ToString() != "")
                {
                    model.NewsId = int.Parse(ds.Tables[0].Rows[0]["NewsId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewsTypeId"].ToString() != "")
                {
                    model.NewsTypeId = int.Parse(ds.Tables[0].Rows[0]["NewsTypeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                model.NewsTitle = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                model.NewsContent = ds.Tables[0].Rows[0]["NewsContent"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                model.Summary = ds.Tables[0].Rows[0]["Summary"].ToString();
                model.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                if (ds.Tables[0].Rows[0]["FileSize"].ToString() != "")
                {
                    model.FileSize = int.Parse(ds.Tables[0].Rows[0]["FileSize"].ToString());
                }

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
            strSql.Append(" FROM Base_News ");
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
            strSql.Append(" FROM Base_News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

