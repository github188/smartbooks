// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_OBSERVED.cs
// 功能描述:电子巡逻日志表 -- 接口实现
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
	/// 电子巡逻日志表 -- 接口实现
	/// </summary>
	public partial class BASE_OBSERVED: IBASE_OBSERVED
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		public bool Exists(decimal OBSERVEDID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_OBSERVED");
			strSql.Append(" where ");
			                                       strSql.Append(" OBSERVEDID = :OBSERVEDID  ");
                            			OracleParameter[] parameters = {
					new OracleParameter(":OBSERVEDID", OracleType.Number,4)			};
			parameters[0].Value = OBSERVEDID;
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
		public int Add(Entity.BASE_OBSERVED entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_OBSERVED(");			
            strSql.Append("OBSERVEDID,PATROLUSER,WEATHER,DEPTID,STATE,REMARK");
			strSql.Append(") values (");
            strSql.Append(":OBSERVEDID,:PATROLUSER,:WEATHER,:DEPTID,:STATE,:REMARK");            
            strSql.Append(") ");            
            		
			OracleParameter[] parameters = {
			            new OracleParameter(":OBSERVEDID", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLUSER", OracleType.VarChar,50) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":STATE", OracleType.Number,4) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500)             
              
            };
			            
            parameters[0].Value = entity.OBSERVEDID;                        
            parameters[1].Value = entity.PATROLUSER;                        
            parameters[2].Value = entity.WEATHER;                        
            parameters[3].Value = entity.DEPTID;                        
            parameters[4].Value = entity.STATE;                        
            parameters[5].Value = entity.REMARK;                        
			return OracleHelper.ExecuteNonQuery(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_OBSERVED entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_OBSERVED set ");
			                        
            strSql.Append(" OBSERVEDID = :OBSERVEDID , ");                                    
            strSql.Append(" PATROLUSER = :PATROLUSER , ");                                    
            strSql.Append(" WEATHER = :WEATHER , ");                                    
            strSql.Append(" DEPTID = :DEPTID , ");                                    
            strSql.Append(" STATE = :STATE , ");                                    
            strSql.Append(" REMARK = :REMARK  ");            			
			strSql.Append(" where OBSERVEDID=:OBSERVEDID  ");
						
OracleParameter[] parameters = {
			            new OracleParameter(":OBSERVEDID", OracleType.Number,4) ,            
                        new OracleParameter(":PATROLUSER", OracleType.VarChar,50) ,            
                        new OracleParameter(":WEATHER", OracleType.VarChar,50) ,            
                        new OracleParameter(":DEPTID", OracleType.Number,4) ,            
                        new OracleParameter(":STATE", OracleType.Number,4) ,            
                        new OracleParameter(":REMARK", OracleType.VarChar,500)             
              
            };
			            
            parameters[0].Value = entity.OBSERVEDID;                        
            parameters[1].Value = entity.PATROLUSER;                        
            parameters[2].Value = entity.WEATHER;                        
            parameters[3].Value = entity.DEPTID;                        
            parameters[4].Value = entity.STATE;                        
            parameters[5].Value = entity.REMARK;                        
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
		public bool Delete(decimal OBSERVEDID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BASE_OBSERVED ");
			strSql.Append(" where OBSERVEDID=:OBSERVEDID ");
						OracleParameter[] parameters = {
					new OracleParameter(":OBSERVEDID", OracleType.Number,4)			};
			parameters[0].Value = OBSERVEDID;


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
		public Entity.BASE_OBSERVED GetEntity(decimal OBSERVEDID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OBSERVEDID, PATROLUSER, WEATHER, DEPTID, STATE, REMARK  ");			
			strSql.Append("  from BASE_OBSERVED ");
			strSql.Append(" where OBSERVEDID=:OBSERVEDID ");
						OracleParameter[] parameters = {
					new OracleParameter(":OBSERVEDID", OracleType.Number,4)			};
			parameters[0].Value = OBSERVEDID;

			
			Entity.BASE_OBSERVED entity=new Entity.BASE_OBSERVED();
			DataTable dt=OracleHelper.Query(CommandType.Text,strSql.ToString(),parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["OBSERVEDID"].ToString()!="")
				{
					entity.OBSERVEDID=decimal.Parse(dt.Rows[0]["OBSERVEDID"].ToString());
				}
																																				entity.PATROLUSER= dt.Rows[0]["PATROLUSER"].ToString();
																																entity.WEATHER= dt.Rows[0]["WEATHER"].ToString();
																												if(dt.Rows[0]["DEPTID"].ToString()!="")
				{
					entity.DEPTID=decimal.Parse(dt.Rows[0]["DEPTID"].ToString());
				}
																																if(dt.Rows[0]["STATE"].ToString()!="")
				{
					entity.STATE=decimal.Parse(dt.Rows[0]["STATE"].ToString());
				}
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
			strSql.Append(" FROM BASE_OBSERVED ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return OracleHelper.Query(strSql.ToString());
		}
        /// <summary>
        /// 获取最大ID编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxID()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(OBSERVEDID) as ID");
            strSql.Append("  from BASE_OBSERVED ");
            Entity.BASE_OBSERVED entity = new Entity.BASE_OBSERVED();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString());
            string id = string.Empty;
            if (dt.Rows.Count > 0)
            {
                if (null == dt.Rows[0]["ID"] || "" == dt.Rows[0]["ID"].ToString())
                {
                    id = "-1";
                }
                else
                {
                    id = dt.Rows[0]["ID"].ToString();
                }
            }
            else
            {
                id = "-1";
            }
            return id;
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
			strSql.Append(" FROM BASE_OBSERVED ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return OracleHelper.Query(strSql.ToString());
		}


        /// <summary>
        /// 根据指定条件，获取某个部门下的电子巡逻日志数据
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetLogObserved(string strwhere)
        {
            StringBuilder where = new StringBuilder();
            where.Append("SELECT b.observedid, a.dptname, b.patroluser, b.weather, b.deptid ");
            where.Append("FROM base_dept a, base_observed b ");
            where.Append("WHERE a.deptid = b.deptid ");
            where.AppendFormat("AND " + strwhere);

            return OracleHelper.Query(where.ToString()).Tables[0];
        }
   
	}
}

