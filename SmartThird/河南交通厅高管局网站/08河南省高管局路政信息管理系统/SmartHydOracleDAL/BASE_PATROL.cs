// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PATROL.cs
// 功能描述:人工巡逻日志表 -- 接口实现
//
// 创建标识：付晓 2012-06-14
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
	/// 人工巡逻日志表 -- 接口实现
	/// </summary>
	public partial class BASE_PATROL: IBASE_PATROL
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		public bool Exists(decimal PATROLID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_PATROL");
			strSql.Append(" where ");
			                                       strSql.Append(" PATROLID = :PATROLID  ");
                            			OracleParameter[] parameters = {
					new OracleParameter(":PATROLID", OracleType.Number,4)			};
			parameters[0].Value = PATROLID;

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
		public int Add(Entity.BASE_PATROL entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_PATROL(");			
            strSql.Append("PATROLID,DEPTID,RESPUSER,PATROLUSER,BUSNUMBER,MILEAGE,WEATHER,WITHIN,NEXTWITHIN,ACCEPTCAPTAIN,SHIFTCAPTAIN,ACCEPTBUSNUMBER,TICKTIME,BUSKM,GOODS,STATE,ATTENTION,REMARK");
			strSql.Append(") values (");
            strSql.Append(":PATROLID,:DEPTID,:RESPUSER,:PATROLUSER,:BUSNUMBER,:MILEAGE,:WEATHER,:WITHIN,:NEXTWITHIN,:ACCEPTCAPTAIN,:SHIFTCAPTAIN,:ACCEPTBUSNUMBER,:TICKTIME,:BUSKM,:GOODS,:STATE,:ATTENTION,:REMARK");            
            strSql.Append(") ");            
            		
			OracleParameter[] parameters = {
			            new OracleParameter(":PATROLID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":RESPUSER", OracleType.VarChar,20) ,            
                        new OracleParameter(":PATROLUSER", OracleType.VarChar,20) ,            
                        new OracleParameter(":BUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":MILEAGE", OracleType.Number,4) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":WITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":NEXTWITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":ACCEPTCAPTAIN", OracleType.VarChar,20) ,            
                        new OracleParameter(":SHIFTCAPTAIN", OracleType.VarChar,20) ,            
                        new OracleParameter(":ACCEPTBUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":BUSKM", OracleType.Number,4) ,            
                        new OracleParameter(":GOODS", OracleType.VarChar,500) ,            
                        new OracleParameter(":STATE", OracleType.Number,4) ,            
                        new OracleParameter(":ATTENTION", OracleType.VarChar,500) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500)             
              
            };
			            
            parameters[0].Value = entity.PATROLID;                        
            parameters[1].Value = entity.DEPTID;                        
            parameters[2].Value = entity.RESPUSER;                        
            parameters[3].Value = entity.PATROLUSER;                        
            parameters[4].Value = entity.BUSNUMBER;                        
            parameters[5].Value = entity.MILEAGE;                        
            parameters[6].Value = entity.WEATHER;                        
            parameters[7].Value = entity.WITHIN;                        
            parameters[8].Value = entity.NEXTWITHIN;                        
            parameters[9].Value = entity.ACCEPTCAPTAIN;                        
            parameters[10].Value = entity.SHIFTCAPTAIN;                        
            parameters[11].Value = entity.ACCEPTBUSNUMBER;                        
            parameters[12].Value = entity.TICKTIME;                        
            parameters[13].Value = entity.BUSKM;                        
            parameters[14].Value = entity.GOODS;                        
            parameters[15].Value = entity.STATE;                        
            parameters[16].Value = entity.ATTENTION;                        
            parameters[17].Value = entity.REMARK;                        
			  return OracleHelper.ExecuteNonQuery(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_PATROL entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_PATROL set ");
			                        
            strSql.Append(" PATROLID = :PATROLID , ");                                    
            strSql.Append(" DEPTID = :DEPTID , ");                                    
            strSql.Append(" RESPUSER = :RESPUSER , ");                                    
            strSql.Append(" PATROLUSER = :PATROLUSER , ");                                    
            strSql.Append(" BUSNUMBER = :BUSNUMBER , ");                                    
            strSql.Append(" MILEAGE = :MILEAGE , ");                                    
            strSql.Append(" WEATHER = :WEATHER , ");                                    
            strSql.Append(" WITHIN = :WITHIN , ");                                    
            strSql.Append(" NEXTWITHIN = :NEXTWITHIN , ");                                    
            strSql.Append(" ACCEPTCAPTAIN = :ACCEPTCAPTAIN , ");                                    
            strSql.Append(" SHIFTCAPTAIN = :SHIFTCAPTAIN , ");                                    
            strSql.Append(" ACCEPTBUSNUMBER = :ACCEPTBUSNUMBER , ");                                    
            strSql.Append(" TICKTIME = :TICKTIME , ");                                    
            strSql.Append(" BUSKM = :BUSKM , ");                                    
            strSql.Append(" GOODS = :GOODS , ");                                    
            strSql.Append(" STATE = :STATE , ");                                    
            strSql.Append(" ATTENTION = :ATTENTION , ");                                    
            strSql.Append(" REMARK = :REMARK  ");            			
			strSql.Append(" where PATROLID=:PATROLID  ");
						
OracleParameter[] parameters = {
			            new OracleParameter(":PATROLID", OracleType.Number,4) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":RESPUSER", OracleType.VarChar,20) ,            
                        new OracleParameter(":PATROLUSER", OracleType.VarChar,20) ,            
                        new OracleParameter(":BUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":MILEAGE", OracleType.Number,4) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":WITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":NEXTWITHIN", OracleType.VarChar,500) ,            
                        new OracleParameter(":ACCEPTCAPTAIN", OracleType.VarChar,20) ,            
                        new OracleParameter(":SHIFTCAPTAIN", OracleType.VarChar,20) ,            
                        new OracleParameter(":ACCEPTBUSNUMBER", OracleType.VarChar,20) ,            
                        new OracleParameter(":TICKTIME", OracleType.DateTime) ,            
                        new OracleParameter(":BUSKM", OracleType.Number,4) ,            
                        new OracleParameter(":GOODS", OracleType.VarChar,500) ,            
                        new OracleParameter(":STATE", OracleType.Number,4) ,            
                        new OracleParameter(":ATTENTION", OracleType.VarChar,500) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500)             
              
            };
			            
            parameters[0].Value = entity.PATROLID;                        
            parameters[1].Value = entity.DEPTID;                        
            parameters[2].Value = entity.RESPUSER;                        
            parameters[3].Value = entity.PATROLUSER;                        
            parameters[4].Value = entity.BUSNUMBER;                        
            parameters[5].Value = entity.MILEAGE;                        
            parameters[6].Value = entity.WEATHER;                        
            parameters[7].Value = entity.WITHIN;                        
            parameters[8].Value = entity.NEXTWITHIN;                        
            parameters[9].Value = entity.ACCEPTCAPTAIN;                        
            parameters[10].Value = entity.SHIFTCAPTAIN;                        
            parameters[11].Value = entity.ACCEPTBUSNUMBER;                        
            parameters[12].Value = entity.TICKTIME;                        
            parameters[13].Value = entity.BUSKM;                        
            parameters[14].Value = entity.GOODS;                        
            parameters[15].Value = entity.STATE;                        
            parameters[16].Value = entity.ATTENTION;                        
            parameters[17].Value = entity.REMARK;                        
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
		public bool Delete(decimal PATROLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BASE_PATROL ");
			strSql.Append(" where PATROLID=:PATROLID ");
						OracleParameter[] parameters = {
					new OracleParameter(":PATROLID", OracleType.Number,4)			};
			parameters[0].Value = PATROLID;


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
		public Entity.BASE_PATROL GetEntity(decimal PATROLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PATROLID, DEPTID, RESPUSER, PATROLUSER, BUSNUMBER, MILEAGE, WEATHER, WITHIN, NEXTWITHIN, ACCEPTCAPTAIN, SHIFTCAPTAIN, ACCEPTBUSNUMBER, TICKTIME, BUSKM, GOODS, STATE, ATTENTION, REMARK  ");			
			strSql.Append("  from BASE_PATROL ");
			strSql.Append(" where PATROLID=:PATROLID ");
						OracleParameter[] parameters = {
					new OracleParameter(":PATROLID", OracleType.Number,4)			};
			parameters[0].Value = PATROLID;

			
			Entity.BASE_PATROL entity=new Entity.BASE_PATROL();
			DataTable dt=OracleHelper.Query(CommandType.Text,strSql.ToString(),parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["PATROLID"].ToString()!="")
				{
					entity.PATROLID=decimal.Parse(dt.Rows[0]["PATROLID"].ToString());
				}
																																if(dt.Rows[0]["DEPTID"].ToString()!="")
				{
					entity.DEPTID=decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
				}
																																				entity.RESPUSER= dt.Rows[0]["RESPUSER"].ToString();
																																entity.PATROLUSER= dt.Rows[0]["PATROLUSER"].ToString();
																																entity.BUSNUMBER= dt.Rows[0]["BUSNUMBER"].ToString();
																												if(dt.Rows[0]["MILEAGE"].ToString()!="")
				{
					entity.MILEAGE=decimal.Parse(dt.Rows[0]["MILEAGE"].ToString());
				}
																																				entity.WEATHER= dt.Rows[0]["WEATHER"].ToString();
																																entity.WITHIN= dt.Rows[0]["WITHIN"].ToString();
																																entity.NEXTWITHIN= dt.Rows[0]["NEXTWITHIN"].ToString();
																																entity.ACCEPTCAPTAIN= dt.Rows[0]["ACCEPTCAPTAIN"].ToString();
																																entity.SHIFTCAPTAIN= dt.Rows[0]["SHIFTCAPTAIN"].ToString();
																																entity.ACCEPTBUSNUMBER= dt.Rows[0]["ACCEPTBUSNUMBER"].ToString();
																												if(dt.Rows[0]["TICKTIME"].ToString()!="")
				{
					entity.TICKTIME=DateTime.Parse(dt.Rows[0]["TICKTIME"].ToString());
				}
																																if(dt.Rows[0]["BUSKM"].ToString()!="")
				{
					entity.BUSKM=decimal.Parse(dt.Rows[0]["BUSKM"].ToString());
				}
																																				entity.GOODS= dt.Rows[0]["GOODS"].ToString();
																												if(dt.Rows[0]["STATE"].ToString()!="")
				{
					entity.STATE=decimal.Parse(dt.Rows[0]["STATE"].ToString());
				}
																																				entity.ATTENTION= dt.Rows[0]["ATTENTION"].ToString();
																																entity.REMARK= dt.Rows[0]["REMARK"].ToString();
																										
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
			strSql.Append(" FROM BASE_PATROL ");
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
			strSql.Append(" FROM BASE_PATROL ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

