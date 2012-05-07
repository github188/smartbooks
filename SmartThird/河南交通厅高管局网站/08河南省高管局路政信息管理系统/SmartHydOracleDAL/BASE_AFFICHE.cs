// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_AFFICHE.cs
// 功能描述:公告信息表 -- 接口实现
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
	/// 公告信息表 -- 接口实现
	/// </summary>
	public partial class BASE_AFFICHE: IBASE_AFFICHE
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
        public bool Exists(decimal AFFICHEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_AFFICHE");
			strSql.Append(" where ");
			  strSql.Append(" AFFICHEID = :AFFICHEID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":AFFICHEID", OracleType.Number,4)			};
            parameters[0].Value = AFFICHEID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Entity.BASE_AFFICHE entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_AFFICHE(");			
            strSql.Append("AFFICHEID,AFFICHETITLE,AFFICHECONTENTS,AFFICHER,AFFICHEDATE");
			strSql.Append(") values (");
            strSql.Append(":AFFICHEID,:AFFICHETITLE,:AFFICHECONTENTS,:AFFICHER,:AFFICHEDATE");            
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":AFFICHEID", OracleType.Number,4) ,            
                        new OracleParameter(":AFFICHETITLE", OracleType.VarChar,60) ,            
                        new OracleParameter(":AFFICHECONTENTS", OracleType.VarChar,200) ,            
                        new OracleParameter(":AFFICHER", OracleType.VarChar,20) ,            
                        new OracleParameter(":AFFICHEDATE", OracleType.DateTime)             
              
            };
			            
            parameters[0].Value = entity.AFFICHEID;                        
            parameters[1].Value = entity.AFFICHETITLE;                        
            parameters[2].Value = entity.AFFICHECONTENTS;                        
            parameters[3].Value = entity.AFFICHER;                        
            parameters[4].Value = entity.AFFICHEDATE;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_AFFICHE entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_AFFICHE set ");
			                        
            strSql.Append(" AFFICHEID = :AFFICHEID , ");                                    
            strSql.Append(" AFFICHETITLE = :AFFICHETITLE , ");                                    
            strSql.Append(" AFFICHECONTENTS = :AFFICHECONTENTS , ");                                    
            strSql.Append(" AFFICHER = :AFFICHER , ");                                    
            strSql.Append(" AFFICHEDATE = :AFFICHEDATE  ");            			
			strSql.Append(" where  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":AFFICHEID", OracleType.Number,4) ,            
                        new OracleParameter(":AFFICHETITLE", OracleType.VarChar,60) ,            
                        new OracleParameter(":AFFICHECONTENTS", OracleType.VarChar,200) ,            
                        new OracleParameter(":AFFICHER", OracleType.VarChar,20) ,            
                        new OracleParameter(":AFFICHEDATE", OracleType.DateTime)             
              
            };
			            
            parameters[5].Value = entity.AFFICHEID;
            parameters[6].Value = entity.AFFICHETITLE;
            parameters[7].Value = entity.AFFICHECONTENTS;
            parameters[8].Value = entity.AFFICHER;
            parameters[9].Value = entity.AFFICHEDATE;
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
			strSql.Append("delete from BASE_AFFICHE ");
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
		public Entity.BASE_AFFICHE GetEntity()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AFFICHEID, AFFICHETITLE, AFFICHECONTENTS, AFFICHER, AFFICHEDATE  ");			
			strSql.Append("  from BASE_AFFICHE ");
			strSql.Append(" where AFFICHEID = :AFFICHEID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":AFFICHEID", OracleType.Number,4)};

			
			Entity.BASE_AFFICHE entity=new Entity.BASE_AFFICHE();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["AFFICHEID"].ToString()!="")
				{
					entity.AFFICHEID=decimal.Parse(dt.Rows[0]["AFFICHEID"].ToString());
				}
																																				entity.AFFICHETITLE= dt.Rows[0]["AFFICHETITLE"].ToString();
																																entity.AFFICHECONTENTS= dt.Rows[0]["AFFICHECONTENTS"].ToString();
																																entity.AFFICHER= dt.Rows[0]["AFFICHER"].ToString();
																												if(dt.Rows[0]["AFFICHEDATE"].ToString()!="")
				{
					entity.AFFICHEDATE=DateTime.Parse(dt.Rows[0]["AFFICHEDATE"].ToString());
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
			strSql.Append(" FROM BASE_AFFICHE ");
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
			strSql.Append(" FROM BASE_AFFICHE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

