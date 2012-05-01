using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Smart.DBUtility;
namespace SmartTeaching.DAL
{
    //Base_NewsType
    public partial class Base_NewsType
    {

        public bool Exists(int NewsTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_NewsType");
            strSql.Append(" where ");
            strSql.Append(" NewsTypeId = @NewsTypeId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsTypeId", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsTypeId;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_NewsType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_NewsType(");
            strSql.Append("NewsTypeName,Remarks,ParentId");
            strSql.Append(") values (");
            strSql.Append("@NewsTypeName,@Remarks,@ParentId");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@NewsTypeName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ParentId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.NewsTypeName;
            parameters[1].Value = model.Remarks;
            parameters[2].Value = model.ParentId;

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
        public bool Update(SmartTeaching.Entity.Base_NewsType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_NewsType set ");

            strSql.Append(" NewsTypeName = @NewsTypeName , ");
            strSql.Append(" Remarks = @Remarks , ");
            strSql.Append(" ParentId = @ParentId  ");
            strSql.Append(" where NewsTypeId=@NewsTypeId ");

            SqlParameter[] parameters = {
			            new SqlParameter("@NewsTypeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@NewsTypeName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ParentId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.NewsTypeId;
            parameters[1].Value = model.NewsTypeName;
            parameters[2].Value = model.Remarks;
            parameters[3].Value = model.ParentId;
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
        public bool Delete(int NewsTypeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_NewsType ");
            strSql.Append(" where NewsTypeId=@NewsTypeId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsTypeId", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsTypeId;


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
        public bool DeleteList(string NewsTypeIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_NewsType ");
            strSql.Append(" where ID in (" + NewsTypeIdlist + ")  ");
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
        public SmartTeaching.Entity.Base_NewsType GetModel(int NewsTypeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NewsTypeId, NewsTypeName, Remarks, ParentId  ");
            strSql.Append("  from Base_NewsType ");
            strSql.Append(" where NewsTypeId=@NewsTypeId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsTypeId", SqlDbType.Int,4)
			};
            parameters[0].Value = NewsTypeId;


            SmartTeaching.Entity.Base_NewsType model = new SmartTeaching.Entity.Base_NewsType();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["NewsTypeId"].ToString() != "")
                {
                    model.NewsTypeId = int.Parse(ds.Tables[0].Rows[0]["NewsTypeId"].ToString());
                }
                model.NewsTypeName = ds.Tables[0].Rows[0]["NewsTypeName"].ToString();
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
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
            strSql.Append(" FROM Base_NewsType ");
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
            strSql.Append(" FROM Base_NewsType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

