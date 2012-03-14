// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_WORD.cs
// 功能描述:关键字信息表 -- 接口实现
//
// 创建标识：王 亚 2012-03-14
namespace SmartPoms.SQLServerDAL {
    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// 关键字信息表 -- 接口实现
    /// </summary>
    public partial class BASE_WORD : IBASE_WORD {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(int WordID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Word");
            strSql.Append(" where ");
            strSql.Append(" WordID = @WordID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@WordID", SqlDbType.Int,4)
			};
            parameters[0].Value = WordID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.BASE_WORD entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Word(");
            strSql.Append("WordName,Score,WordIDParent,Enable");
            strSql.Append(") values (");
            strSql.Append("@WordName,@Score,@WordIDParent,@Enable");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@WordName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Score", SqlDbType.Float,8) ,            
                        new SqlParameter("@WordIDParent", SqlDbType.Int,4) ,            
                        new SqlParameter("@Enable", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = entity.WordName;
            parameters[1].Value = entity.Score;
            parameters[2].Value = entity.WordIDParent;
            parameters[3].Value = entity.Enable;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null) {
                return 0;
            } else {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_WORD entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Word set ");

            strSql.Append(" WordName = @WordName , ");
            strSql.Append(" Score = @Score , ");
            strSql.Append(" WordIDParent = @WordIDParent , ");
            strSql.Append(" Enable = @Enable  ");
            strSql.Append(" where WordID=@WordID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@WordID", SqlDbType.Int,4) ,            
                        new SqlParameter("@WordName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Score", SqlDbType.Float,8) ,            
                        new SqlParameter("@WordIDParent", SqlDbType.Int,4) ,            
                        new SqlParameter("@Enable", SqlDbType.Int,4)             
              
            };

            parameters[4].Value = entity.WordID;
            parameters[5].Value = entity.WordName;
            parameters[6].Value = entity.Score;
            parameters[7].Value = entity.WordIDParent;
            parameters[8].Value = entity.Enable;
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int WordID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Word ");
            strSql.Append(" where WordID=@WordID");
            SqlParameter[] parameters = {
					new SqlParameter("@WordID", SqlDbType.Int,4)
			};
            parameters[0].Value = WordID;


            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string WordIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Base_Word ");
            strSql.Append(" where ID in (" + WordIDlist + ")  ");
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString());
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.BASE_WORD GetEntity(int WordID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WordID, WordName, Score, WordIDParent, Enable  ");
            strSql.Append("  from Base_Word ");
            strSql.Append(" where WordID=@WordID");
            SqlParameter[] parameters = {
					new SqlParameter("@WordID", SqlDbType.Int,4)
			};
            parameters[0].Value = WordID;


            Entity.BASE_WORD entity = new Entity.BASE_WORD();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0) {
                if (ds.Tables[0].Rows[0]["WordID"].ToString() != "") {
                    entity.WordID = int.Parse(ds.Tables[0].Rows[0]["WordID"].ToString());
                }
                entity.WordName = ds.Tables[0].Rows[0]["WordName"].ToString();
                if (ds.Tables[0].Rows[0]["Score"].ToString() != "") {
                    entity.Score = decimal.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WordIDParent"].ToString() != "") {
                    entity.WordIDParent = int.Parse(ds.Tables[0].Rows[0]["WordIDParent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Enable"].ToString() != "") {
                    entity.Enable = int.Parse(ds.Tables[0].Rows[0]["Enable"].ToString());
                }

                return entity;
            } else {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Base_Word ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Base_Word ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }


    }
}

