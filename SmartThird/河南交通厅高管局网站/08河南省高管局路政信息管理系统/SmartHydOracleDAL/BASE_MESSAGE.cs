// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MESSAGE.cs
// 功能描述:消息记录信息表 -- 接口实现
//
// 创建标识：付晓 2012-05-04
namespace SmartHyd.OracleDAL
{
	using System;
	using System.Text;
	using System.Data.SqlClient;
	using System.Collections.Generic; 
	using System.Data;
	using Smart.DBUtility;
	using IDAL;
    using System.Data.OracleClient;
	
	/// <summary>
	/// 消息记录信息表 -- 接口实现
	/// </summary>
	public partial class BASE_MESSAGE: IBASE_MESSAGE
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
        public bool Exists(decimal MESSAGEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_MESSAGE");
			strSql.Append(" where ");
            strSql.Append(" MESSAGEID = :MESSAGEID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":MESSAGEID", OracleType.Number,4)			};
            parameters[0].Value = MESSAGEID;

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
		public void Add(Entity.BASE_MESSAGE entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_MESSAGE(");			
            strSql.Append("MESSAGEID,SENDER,TOUSER,MESSAGEBODY,SENDDATE,STATE");
			strSql.Append(") values (");
            strSql.Append(":MESSAGEID,:SENDER,:TOUSER,:MESSAGEBODY,:SENDDATE,:STATE");            
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":MESSAGEID", OracleType.Number,4) ,            
                        new OracleParameter(":SENDER", OracleType.Number,4) ,            
                        new OracleParameter(":TOUSER", OracleType.Number,4) ,            
                        new OracleParameter(":MESSAGEBODY", OracleType.VarChar,200) ,            
                        new OracleParameter(":SENDDATE", OracleType.DateTime) ,            
                        new OracleParameter(":STATE", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.MESSAGEID;
            parameters[1].Value = entity.SENDER;
            parameters[2].Value = entity.TOUSER;
            parameters[3].Value = entity.MESSAGEBODY;
            parameters[4].Value = entity.SENDDATE;
            parameters[5].Value = entity.STATE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_MESSAGE entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_MESSAGE set ");
			                        
            strSql.Append(" MESSAGEID = :MESSAGEID , ");                                    
            strSql.Append(" SENDER = :SENDER , ");                                    
            strSql.Append(" TOUSER = :TOUSER , ");                                    
            strSql.Append(" MESSAGEBODY = :MESSAGEBODY , ");                                    
            strSql.Append(" SENDDATE = :SENDDATE , ");                                    
            strSql.Append(" STATE = :STATE  ");            			
			strSql.Append(" where  ");
						
OracleParameter[] parameters = {
			            new OracleParameter(":MESSAGEID", OracleType.Number,4) ,            
                        new OracleParameter(":SENDER", OracleType.Number,4) ,            
                        new OracleParameter(":TOUSER", OracleType.Number,4) ,            
                        new OracleParameter(":MESSAGEBODY", OracleType.VarChar,200) ,            
                        new OracleParameter(":SENDDATE", OracleType.DateTime) ,            
                        new OracleParameter(":STATE", OracleType.Number,4)             
              
            };

parameters[6].Value = entity.MESSAGEID;
parameters[7].Value = entity.SENDER;
parameters[8].Value = entity.TOUSER;
parameters[9].Value = entity.MESSAGEBODY;
parameters[10].Value = entity.SENDDATE;
parameters[11].Value = entity.STATE;
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
        public bool Delete(decimal MESSAGEID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BASE_MESSAGE ");

            strSql.Append(" where MESSAGEID=:MESSAGEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":MESSAGEID", OracleType.Number,4)			};
            parameters[0].Value = MESSAGEID;


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
        public Entity.BASE_MESSAGE GetEntity(decimal MESSAGEID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MESSAGEID, SENDER, TOUSER, MESSAGEBODY, SENDDATE, STATE  ");			
			strSql.Append("  from BASE_MESSAGE ");
            strSql.Append(" where MESSAGEID=:MESSAGEID ");
            OracleParameter[] parameters = {
					new OracleParameter(":MESSAGEID", OracleType.Number,4)			};
            parameters[0].Value = MESSAGEID;


			Entity.BASE_MESSAGE entity=new Entity.BASE_MESSAGE();
            DataTable dt = OracleHelper.Query(CommandType.Text,strSql.ToString(), parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["MESSAGEID"].ToString()!="")
				{
					entity.MESSAGEID=decimal.Parse(dt.Rows[0]["MESSAGEID"].ToString());
				}
																																if(dt.Rows[0]["SENDER"].ToString()!="")
				{
					entity.SENDER=decimal.Parse(dt.Rows[0]["SENDER"].ToString());
				}
																																if(dt.Rows[0]["TOUSER"].ToString()!="")
				{
					entity.TOUSER=decimal.Parse(dt.Rows[0]["TOUSER"].ToString());
				}
																																				entity.MESSAGEBODY= dt.Rows[0]["MESSAGEBODY"].ToString();
																												if(dt.Rows[0]["SENDDATE"].ToString()!="")
				{
					entity.SENDDATE=DateTime.Parse(dt.Rows[0]["SENDDATE"].ToString());
				}
																																if(dt.Rows[0]["STATE"].ToString()!="")
				{
					entity.STATE=decimal.Parse(dt.Rows[0]["STATE"].ToString());
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
			strSql.Append(" FROM BASE_MESSAGE ");
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
			strSql.Append(" FROM BASE_MESSAGE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

