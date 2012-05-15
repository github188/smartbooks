﻿// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PLAN.cs
// 功能描述:日程信息表 -- 接口实现
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
	/// 日程信息表 -- 接口实现
	/// </summary>
	public partial class BASE_PLAN: IBASE_PLAN
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		public bool Exists(decimal CALENDARID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_PLAN");
			strSql.Append(" where ");
			                                       strSql.Append(" CALENDARID = :CALENDARID  ");
                            			OracleParameter[] parameters = {
					new OracleParameter(":CALENDARID", OracleType.Number,4)			};
			parameters[0].Value = CALENDARID;
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
		public void Add(Entity.BASE_PLAN entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_PLAN(");			
            strSql.Append("CALENDARID,USERID,CALENDARCONTENT,START_DATE,END_DATE,CALENDARREMIND,CALENDARTYPE");
			strSql.Append(") values (");
            strSql.Append(":CALENDARID,:USERID,:CALENDARCONTENT,:START_DATE,:END_DATE,:CALENDARREMIND,:CALENDARTYPE");            
            strSql.Append(") ");            
            		
			OracleParameter[] parameters = {
			            new OracleParameter(":CALENDARID", OracleType.Number,4) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":CALENDARCONTENT", OracleType.VarChar,200) ,            
                        new OracleParameter(":START_DATE", OracleType.DateTime) ,            
                        new OracleParameter(":END_DATE", OracleType.DateTime) ,            
                        new OracleParameter(":CALENDARREMIND", OracleType.DateTime) ,            
                        new OracleParameter(":CALENDARTYPE", OracleType.VarChar,50)             
              
            };
			            
            parameters[0].Value = entity.CALENDARID;                        
            parameters[1].Value = entity.USERID;                        
            parameters[2].Value = entity.CALENDARCONTENT;                        
            parameters[3].Value = entity.START_DATE;                        
            parameters[4].Value = entity.END_DATE;                        
            parameters[5].Value = entity.CALENDARREMIND;                        
            parameters[6].Value = entity.CALENDARTYPE;                        
			            OracleHelper.ExecuteNonQuery(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_PLAN entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_PLAN set ");
			                        
            strSql.Append(" CALENDARID = :CALENDARID , ");                                    
            strSql.Append(" USERID = :USERID , ");                                    
            strSql.Append(" CALENDARCONTENT = :CALENDARCONTENT , ");                                    
            strSql.Append(" START_DATE = :START_DATE , ");                                    
            strSql.Append(" END_DATE = :END_DATE , ");                                    
            strSql.Append(" CALENDARREMIND = :CALENDARREMIND , ");                                    
            strSql.Append(" CALENDARTYPE = :CALENDARTYPE  ");            			
			strSql.Append(" where CALENDARID=:CALENDARID  ");
						
OracleParameter[] parameters = {
			            new OracleParameter(":CALENDARID", OracleType.Number,4) ,            
                        new OracleParameter(":USERID", OracleType.Number,4) ,            
                        new OracleParameter(":CALENDARCONTENT", OracleType.VarChar,200) ,            
                        new OracleParameter(":START_DATE", OracleType.DateTime) ,            
                        new OracleParameter(":END_DATE", OracleType.DateTime) ,            
                        new OracleParameter(":CALENDARREMIND", OracleType.DateTime) ,            
                        new OracleParameter(":CALENDARTYPE", OracleType.VarChar,50)             
              
            };
			            
            parameters[0].Value = entity.CALENDARID;                        
            parameters[1].Value = entity.USERID;                        
            parameters[2].Value = entity.CALENDARCONTENT;                        
            parameters[3].Value = entity.START_DATE;                        
            parameters[4].Value = entity.END_DATE;                        
            parameters[5].Value = entity.CALENDARREMIND;                        
            parameters[6].Value = entity.CALENDARTYPE;                        
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
		public bool Delete(decimal CALENDARID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BASE_PLAN ");
			strSql.Append(" where CALENDARID=:CALENDARID ");
						OracleParameter[] parameters = {
					new OracleParameter(":CALENDARID", OracleType.Number,4)			};
			parameters[0].Value = CALENDARID;


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
		public Entity.BASE_PLAN GetEntity(decimal CALENDARID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CALENDARID, USERID, CALENDARCONTENT, START_DATE, END_DATE, CALENDARREMIND, CALENDARTYPE  ");			
			strSql.Append("  from BASE_PLAN ");
			strSql.Append(" where CALENDARID=:CALENDARID ");
						OracleParameter[] parameters = {
					new OracleParameter(":CALENDARID", OracleType.Number,4)			};
			parameters[0].Value = CALENDARID;

			
			Entity.BASE_PLAN entity=new Entity.BASE_PLAN();
			DataTable dt=OracleHelper.Query(CommandType.Text,strSql.ToString(),parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["CALENDARID"].ToString()!="")
				{
					entity.CALENDARID=decimal.Parse(dt.Rows[0]["CALENDARID"].ToString());
				}
																																if(dt.Rows[0]["USERID"].ToString()!="")
				{
					entity.USERID=decimal.Parse(dt.Rows[0]["USERID"].ToString());
				}
																																				entity.CALENDARCONTENT= dt.Rows[0]["CALENDARCONTENT"].ToString();
																												if(dt.Rows[0]["START_DATE"].ToString()!="")
				{
					entity.START_DATE=DateTime.Parse(dt.Rows[0]["START_DATE"].ToString());
				}
																																if(dt.Rows[0]["END_DATE"].ToString()!="")
				{
					entity.END_DATE=DateTime.Parse(dt.Rows[0]["END_DATE"].ToString());
				}
																																if(dt.Rows[0]["CALENDARREMIND"].ToString()!="")
				{
					entity.CALENDARREMIND=DateTime.Parse(dt.Rows[0]["CALENDARREMIND"].ToString());
				}
																																				entity.CALENDARTYPE= dt.Rows[0]["CALENDARTYPE"].ToString();
																										
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
			strSql.Append(" FROM BASE_PLAN ");
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
			strSql.Append(" FROM BASE_PLAN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

