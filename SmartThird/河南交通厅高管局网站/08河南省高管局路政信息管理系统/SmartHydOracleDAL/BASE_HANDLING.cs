// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_HANDLING.cs
// 功能描述:巡查处理情况表 -- 接口实现
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
	/// 巡查处理情况表 -- 接口实现
	/// </summary>
	public partial class BASE_HANDLING: IBASE_HANDLING
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		public bool Exists(decimal HID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_HANDLING");
			strSql.Append(" where ");
			                                       strSql.Append(" HID = :HID  ");
                            			OracleParameter[] parameters = {
					new OracleParameter(":HID", OracleType.Number,4)			};
			parameters[0].Value = HID;
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
        /// 获取当期日期下记录总数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as counts from BASE_HANDLING where  1=1 and to_char(BEGINTIME,'yyyy-MM-dd')=to_char(sysdate,'yyyy-MM-dd')");
            DataSet ds = OracleHelper.Query(strSql.ToString());
            int counts = Convert.ToInt32(ds.Tables[0].Rows[0]["counts"]);
            return counts;
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Entity.BASE_HANDLING entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_HANDLING(");			
            strSql.Append("HID,PATROLTYPE,BEGINTIME,ENDTIME,TIMES,CONTENT,REMARK,PID");
			strSql.Append(") values (");
            strSql.Append(":HID,:PATROLTYPE,:BEGINTIME,:ENDTIME,:TIMES,:CONTENT,:REMARK,:PID");            
            strSql.Append(") ");            
            		
			OracleParameter[] parameters = {
			            new OracleParameter(":HID", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLTYPE", OracleType.VarChar,20) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":TIMES", OracleType.Number,4) ,            
                        new OracleParameter(":CONTENT", OracleType.VarChar,200) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,200) ,            
                        new OracleParameter(":PID", OracleType.Number,4)             
              
            };
			            
            parameters[0].Value = entity.HID;                        
            parameters[1].Value = entity.PATROLTYPE;                        
            parameters[2].Value = entity.BEGINTIME;                        
            parameters[3].Value = entity.ENDTIME;                        
            parameters[4].Value = entity.TIMES;                        
            parameters[5].Value = entity.CONTENT;                        
            parameters[6].Value = entity.REMARK;                        
            parameters[7].Value = entity.PID;                        
			return OracleHelper.ExecuteNonQuery(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_HANDLING entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_HANDLING set ");
			                        
            strSql.Append(" HID = :HID , ");                                    
            strSql.Append(" PATROLTYPE = :PATROLTYPE , ");                                    
            strSql.Append(" BEGINTIME = :BEGINTIME , ");                                    
            strSql.Append(" ENDTIME = :ENDTIME , ");                                    
            strSql.Append(" TIMES = :TIMES , ");                                    
            strSql.Append(" CONTENT = :CONTENT , ");                                    
            strSql.Append(" REMARK = :REMARK , ");                                    
            strSql.Append(" PID = :PID  ");            			
			strSql.Append(" where HID=:HID  ");
						
OracleParameter[] parameters = {
			            new OracleParameter(":HID", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLTYPE", OracleType.VarChar,20) ,            
                        new OracleParameter(":BEGINTIME", OracleType.DateTime) ,            
                        new OracleParameter(":ENDTIME", OracleType.DateTime) ,            
                        new OracleParameter(":TIMES", OracleType.Number,4) ,            
                        new OracleParameter(":CONTENT", OracleType.VarChar,200) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,200) ,            
                        new OracleParameter(":PID", OracleType.Number,4)             
              
            };
			            
            parameters[0].Value = entity.HID;                        
            parameters[1].Value = entity.PATROLTYPE;                        
            parameters[2].Value = entity.BEGINTIME;                        
            parameters[3].Value = entity.ENDTIME;                        
            parameters[4].Value = entity.TIMES;                        
            parameters[5].Value = entity.CONTENT;                        
            parameters[6].Value = entity.REMARK;                        
            parameters[7].Value = entity.PID;                        
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
		public bool Delete(decimal HID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BASE_HANDLING ");
			strSql.Append(" where HID=:HID ");
						OracleParameter[] parameters = {
					new OracleParameter(":HID", OracleType.Number,4)			};
			parameters[0].Value = HID;


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
		public Entity.BASE_HANDLING GetEntity(decimal HID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select HID, PATROLTYPE, BEGINTIME, ENDTIME, TIMES, CONTENT, REMARK, PID  ");			
			strSql.Append("  from BASE_HANDLING ");
			strSql.Append(" where HID=:HID ");
						OracleParameter[] parameters = {
					new OracleParameter(":HID", OracleType.Number,4)			};
			parameters[0].Value = HID;

			
			Entity.BASE_HANDLING entity=new Entity.BASE_HANDLING();
			DataTable dt=OracleHelper.Query(CommandType.Text,strSql.ToString(),parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["HID"].ToString()!="")
				{
					entity.HID=decimal.Parse(dt.Rows[0]["HID"].ToString());
				}
																																				entity.PATROLTYPE= dt.Rows[0]["PATROLTYPE"].ToString();
																												if(dt.Rows[0]["BEGINTIME"].ToString()!="")
				{
					entity.BEGINTIME=DateTime.Parse(dt.Rows[0]["BEGINTIME"].ToString());
				}
																																if(dt.Rows[0]["ENDTIME"].ToString()!="")
				{
					entity.ENDTIME=DateTime.Parse(dt.Rows[0]["ENDTIME"].ToString());
				}
																																if(dt.Rows[0]["TIMES"].ToString()!="")
				{
					entity.TIMES=decimal.Parse(dt.Rows[0]["TIMES"].ToString());
				}
																																				entity.CONTENT= dt.Rows[0]["CONTENT"].ToString();
																																entity.REMARK= dt.Rows[0]["REMARK"].ToString();
																												if(dt.Rows[0]["PID"].ToString()!="")
				{
					entity.PID=decimal.Parse(dt.Rows[0]["PID"].ToString());
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
			strSql.Append(" FROM BASE_HANDLING ");
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
			strSql.Append(" FROM BASE_HANDLING ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

