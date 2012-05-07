// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_SHOUWEN.cs
// 功能描述:收文信息表 -- 接口实现
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
	/// 收文信息表 -- 接口实现
	/// </summary>
	public partial class BASE_SHOUWEN: IBASE_SHOUWEN
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
        public bool Exists(decimal SID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_SHOUWEN");
			strSql.Append(" where ");
            strSql.Append(" SID = :SID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":SID", OracleType.Number,4)			};
            parameters[0].Value = SID;

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
		public void Add(Entity.BASE_SHOUWEN entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_SHOUWEN(");			
            strSql.Append("SID,S_NUMBERS,S_ORGAN,S_FROMDATE,S_TITLE,S_HANDLINGTIME,S_DEP_ORGAN,S_HANDLEPROGRESS,S_RESULT,S_APPLICANT,S_HANDLER,REMARKS,S_CONTENT");
			strSql.Append(") values (");
            strSql.Append(":SID,:S_NUMBERS,:S_ORGAN,:S_FROMDATE,:S_TITLE,:S_HANDLINGTIME,:S_DEP_ORGAN,:S_HANDLEPROGRESS,:S_RESULT,:S_APPLICANT,:S_HANDLER,:REMARKS,:S_CONTENT");            
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":SID", OracleType.Number,4) ,            
                        new OracleParameter(":S_NUMBERS", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_ORGAN", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_FROMDATE", OracleType.DateTime) ,            
                        new OracleParameter(":S_TITLE", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_HANDLINGTIME", OracleType.DateTime) ,            
                        new OracleParameter(":S_DEP_ORGAN", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_HANDLEPROGRESS", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_RESULT", OracleType.VarChar,200) ,            
                        new OracleParameter(":S_APPLICANT", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_HANDLER", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARKS", OracleType.VarChar,200) ,            
                        new OracleParameter(":S_CONTENT", OracleType.VarChar,300)             
              
            };
			            
            parameters[0].Value = entity.SID;
            parameters[1].Value = entity.S_NUMBERS;
            parameters[2].Value = entity.S_ORGAN;
            parameters[3].Value = entity.S_FROMDATE;
            parameters[4].Value = entity.S_TITLE;
            parameters[5].Value = entity.S_HANDLINGTIME;
            parameters[6].Value = entity.S_DEP_ORGAN;
            parameters[7].Value = entity.S_HANDLEPROGRESS;
            parameters[8].Value = entity.S_RESULT;
            parameters[9].Value = entity.S_APPLICANT;
            parameters[10].Value = entity.S_HANDLER;
            parameters[11].Value = entity.REMARKS;
            parameters[12].Value = entity.S_CONTENT;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_SHOUWEN entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_SHOUWEN set ");
			                        
            strSql.Append(" SID = :SID , ");                                    
            strSql.Append(" S_NUMBERS = :S_NUMBERS , ");                                    
            strSql.Append(" S_ORGAN = :S_ORGAN , ");                                    
            strSql.Append(" S_FROMDATE = :S_FROMDATE , ");                                    
            strSql.Append(" S_TITLE = :S_TITLE , ");                                    
            strSql.Append(" S_HANDLINGTIME = :S_HANDLINGTIME , ");                                    
            strSql.Append(" S_DEP_ORGAN = :S_DEP_ORGAN , ");                                    
            strSql.Append(" S_HANDLEPROGRESS = :S_HANDLEPROGRESS , ");                                    
            strSql.Append(" S_RESULT = :S_RESULT , ");                                    
            strSql.Append(" S_APPLICANT = :S_APPLICANT , ");                                    
            strSql.Append(" S_HANDLER = :S_HANDLER , ");                                    
            strSql.Append(" REMARKS = :REMARKS , ");                                    
            strSql.Append(" S_CONTENT = :S_CONTENT  ");            			
			strSql.Append(" where  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":SID", OracleType.Number,4) ,            
                        new OracleParameter(":S_NUMBERS", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_ORGAN", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_FROMDATE", OracleType.DateTime) ,            
                        new OracleParameter(":S_TITLE", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_HANDLINGTIME", OracleType.DateTime) ,            
                        new OracleParameter(":S_DEP_ORGAN", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_HANDLEPROGRESS", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_RESULT", OracleType.VarChar,200) ,            
                        new OracleParameter(":S_APPLICANT", OracleType.VarChar,50) ,            
                        new OracleParameter(":S_HANDLER", OracleType.VarChar,50) ,            
                        new OracleParameter(":REMARKS", OracleType.VarChar,200) ,            
                        new OracleParameter(":S_CONTENT", OracleType.VarChar,300)             
              
            };
			            
            parameters[13].Value = entity.SID;                        
            parameters[14].Value = entity.S_NUMBERS;                        
            parameters[15].Value = entity.S_ORGAN;                        
            parameters[16].Value = entity.S_FROMDATE;                        
            parameters[17].Value = entity.S_TITLE;                        
            parameters[18].Value = entity.S_HANDLINGTIME;                        
            parameters[19].Value = entity.S_DEP_ORGAN;                        
            parameters[20].Value = entity.S_HANDLEPROGRESS;                        
            parameters[21].Value = entity.S_RESULT;                        
            parameters[22].Value = entity.S_APPLICANT;                        
            parameters[23].Value = entity.S_HANDLER;                        
            parameters[24].Value = entity.REMARKS;                        
            parameters[25].Value = entity.S_CONTENT;
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
		public bool Delete()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BASE_SHOUWEN ");
			strSql.Append(" where ");
						OracleParameter[] parameters = {
			};


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
		public Entity.BASE_SHOUWEN GetEntity(decimal SID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SID, S_NUMBERS, S_ORGAN, S_FROMDATE, S_TITLE, S_HANDLINGTIME, S_DEP_ORGAN, S_HANDLEPROGRESS, S_RESULT, S_APPLICANT, S_HANDLER, REMARKS, S_CONTENT  ");			
			strSql.Append("  from BASE_SHOUWEN ");
			strSql.Append(" where ");
            strSql.Append(" SID = :SID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":SID", OracleType.Number,4)			};
            parameters[0].Value = SID;
			
			Entity.BASE_SHOUWEN entity=new Entity.BASE_SHOUWEN();
            DataTable dt = OracleHelper.Query(CommandType.Text,strSql.ToString(), parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["SID"].ToString()!="")
				{
					entity.SID=decimal.Parse(dt.Rows[0]["SID"].ToString());
				}
																																				entity.S_NUMBERS= dt.Rows[0]["S_NUMBERS"].ToString();
																																entity.S_ORGAN= dt.Rows[0]["S_ORGAN"].ToString();
																												if(dt.Rows[0]["S_FROMDATE"].ToString()!="")
				{
					entity.S_FROMDATE=DateTime.Parse(dt.Rows[0]["S_FROMDATE"].ToString());
				}
																																				entity.S_TITLE= dt.Rows[0]["S_TITLE"].ToString();
																												if(dt.Rows[0]["S_HANDLINGTIME"].ToString()!="")
				{
					entity.S_HANDLINGTIME=DateTime.Parse(dt.Rows[0]["S_HANDLINGTIME"].ToString());
				}
																																				entity.S_DEP_ORGAN= dt.Rows[0]["S_DEP_ORGAN"].ToString();
																																entity.S_HANDLEPROGRESS= dt.Rows[0]["S_HANDLEPROGRESS"].ToString();
																																entity.S_RESULT= dt.Rows[0]["S_RESULT"].ToString();
																																entity.S_APPLICANT= dt.Rows[0]["S_APPLICANT"].ToString();
																																entity.S_HANDLER= dt.Rows[0]["S_HANDLER"].ToString();
																																entity.REMARKS= dt.Rows[0]["REMARKS"].ToString();
																																entity.S_CONTENT= dt.Rows[0]["S_CONTENT"].ToString();
																										
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
			strSql.Append(" FROM BASE_SHOUWEN ");
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
			strSql.Append(" FROM BASE_SHOUWEN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

