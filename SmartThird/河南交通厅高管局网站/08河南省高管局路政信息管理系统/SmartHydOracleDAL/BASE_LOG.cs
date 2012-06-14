// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_LOG.cs
// 功能描述:系统日志表 -- 接口实现
//
// 创建标识：付晓 2012-05-15
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
	/// 系统日志表 -- 接口实现
	/// </summary>
	public partial class BASE_LOG: IBASE_LOG
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		public bool Exists(decimal LOGID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_LOG");
			strSql.Append(" where ");
			                                       strSql.Append(" LOGID = :LOGID  ");
                            			OracleParameter[] parameters = {
					new OracleParameter(":LOGID", OracleType.Number,4)			};
			parameters[0].Value = LOGID;

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
		public int Add(Entity.BASE_LOG entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_LOG(");			
            strSql.Append("LOGID,LOGTYPE,CREATEDATE,OPERATORID,DESCRIPTION,IPADDRESS");
			strSql.Append(") values (");
            strSql.Append(":LOGID,:LOGTYPE,:CREATEDATE,:OPERATORID,:DESCRIPTION,:IPADDRESS");            
            strSql.Append(") ");            
            		
			OracleParameter[] parameters = {
			            new OracleParameter(":LOGID", OracleType.Number,4) ,            
                        new OracleParameter(":LOGTYPE", OracleType.VarChar,50) ,            
                        new OracleParameter(":CREATEDATE", OracleType.DateTime) ,            
                        new OracleParameter(":OPERATORID", OracleType.Number,4) ,            
                        new OracleParameter(":DESCRIPTION", OracleType.VarChar,200) ,            
                        new OracleParameter(":IPADDRESS", OracleType.VarChar,50)             
              
            };
			            
            parameters[0].Value = entity.LOGID;                        
            parameters[1].Value = entity.LOGTYPE;                        
            parameters[2].Value = entity.CREATEDATE;                        
            parameters[3].Value = entity.OPERATORID;                        
            parameters[4].Value = entity.DESCRIPTION;                        
            parameters[5].Value = entity.IPADDRESS;                        
			return OracleHelper.ExecuteNonQuery(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_LOG entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_LOG set ");
			                        
            strSql.Append(" LOGID = :LOGID , ");                                    
            strSql.Append(" LOGTYPE = :LOGTYPE , ");                                    
            strSql.Append(" CREATEDATE = :CREATEDATE , ");                                    
            strSql.Append(" OPERATORID = :OPERATORID , ");                                    
            strSql.Append(" DESCRIPTION = :DESCRIPTION , ");                                    
            strSql.Append(" IPADDRESS = :IPADDRESS  ");            			
			strSql.Append(" where LOGID=:LOGID  ");
						
OracleParameter[] parameters = {
			            new OracleParameter(":LOGID", OracleType.Number,4) ,            
                        new OracleParameter(":LOGTYPE", OracleType.VarChar,50) ,            
                        new OracleParameter(":CREATEDATE", OracleType.DateTime) ,            
                        new OracleParameter(":OPERATORID", OracleType.Number,4) ,            
                        new OracleParameter(":DESCRIPTION", OracleType.VarChar,200) ,            
                        new OracleParameter(":IPADDRESS", OracleType.VarChar,50)             
              
            };
			            
            parameters[0].Value = entity.LOGID;                        
            parameters[1].Value = entity.LOGTYPE;                        
            parameters[2].Value = entity.CREATEDATE;                        
            parameters[3].Value = entity.OPERATORID;                        
            parameters[4].Value = entity.DESCRIPTION;                        
            parameters[5].Value = entity.IPADDRESS;                        
            int rows=OracleHelper.ExecuteNonQuery(strSql.ToString(),parameters);
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
		public bool Delete(decimal LOGID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BASE_LOG ");
			strSql.Append(" where LOGID=:LOGID ");
						OracleParameter[] parameters = {
					new OracleParameter(":LOGID", OracleType.Number,4)			};
			parameters[0].Value = LOGID;


			int rows=OracleHelper.ExecuteNonQuery(strSql.ToString(),parameters);
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
		public Entity.BASE_LOG GetEntity(decimal LOGID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LOGID, LOGTYPE, CREATEDATE, OPERATORID, DESCRIPTION, IPADDRESS  ");			
			strSql.Append("  from BASE_LOG ");
			strSql.Append(" where LOGID=:LOGID ");
						OracleParameter[] parameters = {
					new OracleParameter(":LOGID", OracleType.Number,4)			};
			parameters[0].Value = LOGID;

			
			Entity.BASE_LOG entity=new Entity.BASE_LOG();
			DataTable dt=OracleHelper.Query(CommandType.Text,strSql.ToString(),parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["LOGID"].ToString()!="")
				{
					entity.LOGID=decimal.Parse(dt.Rows[0]["LOGID"].ToString());
				}
																																				entity.LOGTYPE= dt.Rows[0]["LOGTYPE"].ToString();
																												if(dt.Rows[0]["CREATEDATE"].ToString()!="")
				{
					entity.CREATEDATE=DateTime.Parse(dt.Rows[0]["CREATEDATE"].ToString());
				}
																																if(dt.Rows[0]["OPERATORID"].ToString()!="")
				{
					entity.OPERATORID=decimal.Parse(dt.Rows[0]["OPERATORID"].ToString());
				}
																																				entity.DESCRIPTION= dt.Rows[0]["DESCRIPTION"].ToString();
																																entity.IPADDRESS= dt.Rows[0]["IPADDRESS"].ToString();
																										
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
			strSql.Append(" FROM BASE_LOG ");
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
			strSql.Append(" FROM BASE_LOG ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

