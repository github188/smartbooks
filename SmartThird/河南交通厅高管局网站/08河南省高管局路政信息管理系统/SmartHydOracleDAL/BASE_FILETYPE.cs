// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_FILETYPE.cs
// 功能描述:公文类型表 -- 接口实现
//
// 创建标识：付晓 2012-05-08
namespace SmartHyd.OracleDAL
{
    using System;
    using System.Text;
    using System.Data.OracleClient;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// 公文类型表 -- 接口实现
    /// </summary>
    public partial class BASE_FILETYPE : IBASE_FILETYPE
    {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal FTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_FILETYPE");
            strSql.Append(" where ");
            strSql.Append(" FTID = :FTID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":FTID", OracleType.Number,4)			};
            parameters[0].Value = FTID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_FILETYPE entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_FILETYPE(");
            strSql.Append("FTID,FT_NAME,FT_DESCRIBE,FT_DEPT,FT_PREFIX,FT_SUFFIX,FT_STATE");
            strSql.Append(") values (");
            strSql.Append(":FTID,:FT_NAME,:FT_DESCRIBE,:FT_DEPT,:FT_PREFIX,:FT_SUFFIX,:FT_STATE");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":FTID", OracleType.Number,4) ,            
                        new OracleParameter(":FT_NAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_DESCRIBE", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_DEPT", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_PREFIX", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_SUFFIX", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_STATE", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.FTID;
            parameters[1].Value = entity.FT_NAME;
            parameters[2].Value = entity.FT_DESCRIBE;
            parameters[3].Value = entity.FT_DEPT;
            parameters[4].Value = entity.FT_PREFIX;
            parameters[5].Value = entity.FT_SUFFIX;
            parameters[6].Value = entity.FT_STATE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_FILETYPE entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_FILETYPE set ");

            strSql.Append(" FTID = :FTID , ");
            strSql.Append(" FT_NAME = :FT_NAME , ");
            strSql.Append(" FT_DESCRIBE = :FT_DESCRIBE , ");
            strSql.Append(" FT_DEPT = :FT_DEPT , ");
            strSql.Append(" FT_PREFIX = :FT_PREFIX , ");
            strSql.Append(" FT_SUFFIX = :FT_SUFFIX , ");
            strSql.Append(" FT_STATE = :FT_STATE  ");
            strSql.Append(" where FTID=:FTID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":FTID", OracleType.Number,4) ,            
                        new OracleParameter(":FT_NAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_DESCRIBE", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_DEPT", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_PREFIX", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_SUFFIX", OracleType.VarChar,50) ,            
                        new OracleParameter(":FT_STATE", OracleType.Number,4)             
              
            };

            parameters[7].Value = entity.FTID;
            parameters[8].Value = entity.FT_NAME;
            parameters[9].Value = entity.FT_DESCRIBE;
            parameters[10].Value = entity.FT_DEPT;
            parameters[11].Value = entity.FT_PREFIX;
            parameters[12].Value = entity.FT_SUFFIX;
            parameters[13].Value = entity.FT_STATE;
            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        public bool Delete(decimal FTID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_FILETYPE ");
            strSql.Append(" where FTID=:FTID ");
            OracleParameter[] parameters = {
					new OracleParameter(":FTID", OracleType.Number,4)			};
            parameters[0].Value = FTID;


            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        public Entity.BASE_FILETYPE GetEntity(decimal FTID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FTID, FT_NAME, FT_DESCRIBE, FT_DEPT, FT_PREFIX, FT_SUFFIX, FT_STATE  ");
            strSql.Append("  from BASE_FILETYPE ");
            strSql.Append(" where FTID=:FTID ");
            OracleParameter[] parameters = {
					new OracleParameter(":FTID", OracleType.Number,4)			};
            parameters[0].Value = FTID;


            Entity.BASE_FILETYPE entity = new Entity.BASE_FILETYPE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["FTID"].ToString() != "")
                {
                    entity.FTID = decimal.Parse(dt.Rows[0]["FTID"].ToString());
                }
                entity.FT_NAME = dt.Rows[0]["FT_NAME"].ToString();
                entity.FT_DESCRIBE = dt.Rows[0]["FT_DESCRIBE"].ToString();
                entity.FT_DEPT = dt.Rows[0]["FT_DEPT"].ToString();
                entity.FT_PREFIX = dt.Rows[0]["FT_PREFIX"].ToString();
                entity.FT_SUFFIX = dt.Rows[0]["FT_SUFFIX"].ToString();
                if (dt.Rows[0]["FT_STATE"].ToString() != "")
                {
                    entity.FT_STATE = decimal.Parse(dt.Rows[0]["FT_STATE"].ToString());
                }

                return entity;
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
            strSql.Append(" FROM BASE_FILETYPE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return OracleHelper.Query(strSql.ToString());
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
            strSql.Append(" FROM BASE_FILETYPE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }


    }
}

