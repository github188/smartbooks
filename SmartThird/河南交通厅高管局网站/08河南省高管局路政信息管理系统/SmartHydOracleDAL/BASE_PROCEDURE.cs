// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PROCEDURE.cs
// 功能描述:路政许可流程表 -- 接口实现
//
// 创建标识：付晓 2012-05-04
namespace SmartHyd.OracleDAL
{
	using System;
	using System.Text;
	using System.Data.SqlClient;
    using System.Data.OracleClient;
	using System.Collections.Generic; 
	using System.Data;
	using Smart.DBUtility;
	using IDAL;
	
	/// <summary>
	/// 路政许可流程表 -- 接口实现
	/// </summary>
	public partial class BASE_PROCEDURE: IBASE_PROCEDURE
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
        public bool Exists(decimal PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_PROCEDURE");
			strSql.Append(" where ");
            strSql.Append(" PID = :PID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":PID", OracleType.Number,4)			};
            parameters[0].Value = PID;

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
		public void Add(Entity.BASE_PROCEDURE entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_PROCEDURE(");			
            strSql.Append("PID,REQUISITIONID,DEPARTMENT,TRANSACTOR,CONTENTS,RESULT,P_DATE");
			strSql.Append(") values (");
            strSql.Append(":PID,:REQUISITIONID,:DEPARTMENT,:TRANSACTOR,:CONTENTS,:RESULT,:P_DATE");            
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":PID", OracleType.Number,4) ,            
                        new OracleParameter(":REQUISITIONID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPARTMENT", OracleType.VarChar,50) ,            
                        new OracleParameter(":TRANSACTOR", OracleType.VarChar,50) ,            
                        new OracleParameter(":CONTENTS", OracleType.VarChar,50) ,            
                        new OracleParameter(":RESULT", OracleType.VarChar,50) ,            
                        new OracleParameter(":P_DATE", OracleType.DateTime)             
              
            };

            parameters[0].Value = entity.PID;
            parameters[1].Value = entity.REQUISITIONID;
            parameters[2].Value = entity.DEPARTMENT;
            parameters[3].Value = entity.TRANSACTOR;
            parameters[4].Value = entity.CONTENTS;
            parameters[5].Value = entity.RESULT;
            parameters[6].Value = entity.P_DATE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_PROCEDURE entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_PROCEDURE set ");
			                        
            strSql.Append(" PID = :PID , ");                                    
            strSql.Append(" REQUISITIONID = :REQUISITIONID , ");                                    
            strSql.Append(" DEPARTMENT = :DEPARTMENT , ");                                    
            strSql.Append(" TRANSACTOR = :TRANSACTOR , ");                                    
            strSql.Append(" CONTENTS = :CONTENTS , ");                                    
            strSql.Append(" RESULT = :RESULT , ");                                    
            strSql.Append(" P_DATE = :P_DATE  ");            			
			strSql.Append(" where  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":PID", OracleType.Number,4) ,            
                        new OracleParameter(":REQUISITIONID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPARTMENT", OracleType.VarChar,50) ,            
                        new OracleParameter(":TRANSACTOR", OracleType.VarChar,50) ,            
                        new OracleParameter(":CONTENTS", OracleType.VarChar,50) ,            
                        new OracleParameter(":RESULT", OracleType.VarChar,50) ,            
                        new OracleParameter(":P_DATE", OracleType.DateTime)             
              
            };
			            
            parameters[7].Value = entity.PID;                        
            parameters[8].Value = entity.REQUISITIONID;                        
            parameters[9].Value = entity.DEPARTMENT;                        
            parameters[10].Value = entity.TRANSACTOR;                        
            parameters[11].Value = entity.CONTENTS;                        
            parameters[12].Value = entity.RESULT;                        
            parameters[13].Value = entity.P_DATE;
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
        public bool Delete(decimal PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BASE_PROCEDURE ");
			strSql.Append(" where ");
            strSql.Append(" PID=:PID ");
            OracleParameter[] parameters = {
					new OracleParameter(":PID", OracleType.Number,4)			};
            parameters[0].Value = PID;


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
		public Entity.BASE_PROCEDURE GetEntity(decimal PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PID, REQUISITIONID, DEPARTMENT, TRANSACTOR, CONTENTS, RESULT, P_DATE  ");			
			strSql.Append("  from BASE_PROCEDURE ");
			strSql.Append(" where ");
            strSql.Append(" PID=:PID ");
            OracleParameter[] parameters = {
					new OracleParameter(":PID", OracleType.Number,4)			};
            parameters[0].Value = PID;
			
			Entity.BASE_PROCEDURE entity=new Entity.BASE_PROCEDURE();
            DataTable dt = OracleHelper.Query(CommandType.Text,strSql.ToString(), parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["PID"].ToString()!="")
				{
					entity.PID=decimal.Parse(dt.Rows[0]["PID"].ToString());
				}
																																if(dt.Rows[0]["REQUISITIONID"].ToString()!="")
				{
					entity.REQUISITIONID=decimal.Parse(dt.Rows[0]["REQUISITIONID"].ToString());
				}
																																				entity.DEPARTMENT= dt.Rows[0]["DEPARTMENT"].ToString();
																																entity.TRANSACTOR= dt.Rows[0]["TRANSACTOR"].ToString();
																																entity.CONTENTS= dt.Rows[0]["CONTENTS"].ToString();
																																entity.RESULT= dt.Rows[0]["RESULT"].ToString();
																												if(dt.Rows[0]["P_DATE"].ToString()!="")
				{
					entity.P_DATE=DateTime.Parse(dt.Rows[0]["P_DATE"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM BASE_PROCEDURE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return OracleHelper.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM BASE_PROCEDURE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

