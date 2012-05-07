// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_LICENSE_ACCEPT.cs
// 功能描述:路政许可申请表 -- 接口实现
//
// 创建标识：付晓 2012-05-04
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
	/// 路政许可申请表 -- 接口实现
	/// </summary>
	public partial class BASE_LICENSE_ACCEPT: IBASE_LICENSE_ACCEPT
	{
   		/// <summary>
		/// 确定记录是否存在
		/// </summary>
        public bool Exists(decimal REQUISITIONID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_LICENSE_ACCEPT");
			strSql.Append(" where ");
            strSql.Append(" REQUISITIONID = :REQUISITIONID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":REQUISITIONID", OracleType.Number,4)			};
            parameters[0].Value = REQUISITIONID;

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
		public void Add(Entity.BASE_LICENSE_ACCEPT entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_LICENSE_ACCEPT(");			
            strSql.Append("REQUISITIONID,REQUISITIONNAME,ADDRESS,TEL,PHONE,EMAIL,POST,REQUISITIONCONTENT,DEPUTY,MATERIALS,MARK,CREATDATE,AUDITOR,AUDIT_STATE,FILE_PATH,AUDIT_DESC,AUDIT_REPLY");
			strSql.Append(") values (");
            strSql.Append(":REQUISITIONID,:REQUISITIONNAME,:ADDRESS,:TEL,:PHONE,:EMAIL,:POST,:REQUISITIONCONTENT,:DEPUTY,:MATERIALS,:MARK,:CREATDATE,:AUDITOR,:AUDIT_STATE,:FILE_PATH,:AUDIT_DESC,:AUDIT_REPLY");            
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":REQUISITIONID", OracleType.Number,4) ,            
                        new OracleParameter(":REQUISITIONNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":ADDRESS", OracleType.VarChar,50) ,            
                        new OracleParameter(":TEL", OracleType.VarChar,50) ,            
                        new OracleParameter(":PHONE", OracleType.VarChar,50) ,            
                        new OracleParameter(":EMAIL", OracleType.VarChar,50) ,            
                        new OracleParameter(":POST", OracleType.VarChar,20) ,            
                        new OracleParameter(":REQUISITIONCONTENT", OracleType.VarChar,200) ,            
                        new OracleParameter(":DEPUTY", OracleType.VarChar,20) ,            
                        new OracleParameter(":MATERIALS", OracleType.VarChar,20) ,            
                        new OracleParameter(":MARK", OracleType.VarChar,20) ,            
                        new OracleParameter(":CREATDATE", OracleType.DateTime) ,            
                        new OracleParameter(":AUDITOR", OracleType.VarChar,20) ,            
                        new OracleParameter(":AUDIT_STATE", OracleType.Number,4) ,            
                        new OracleParameter(":FILE_PATH", OracleType.VarChar,50) ,            
                        new OracleParameter(":AUDIT_DESC", OracleType.VarChar,200) ,            
                        new OracleParameter(":AUDIT_REPLY", OracleType.VarChar,200)             
              
            };
			            
            parameters[0].Value = entity.REQUISITIONID;
            parameters[1].Value = entity.REQUISITIONNAME;
            parameters[2].Value = entity.ADDRESS;
            parameters[3].Value = entity.TEL;
            parameters[4].Value = entity.PHONE;
            parameters[5].Value = entity.EMAIL;
            parameters[6].Value = entity.POST;
            parameters[7].Value = entity.REQUISITIONCONTENT;
            parameters[8].Value = entity.DEPUTY;
            parameters[9].Value = entity.MATERIALS;
            parameters[10].Value = entity.MARK;
            parameters[11].Value = entity.CREATDATE;
            parameters[12].Value = entity.AUDITOR;
            parameters[13].Value = entity.AUDIT_STATE;
            parameters[14].Value = entity.FILE_PATH;
            parameters[15].Value = entity.AUDIT_DESC;
            parameters[16].Value = entity.AUDIT_REPLY;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Entity.BASE_LICENSE_ACCEPT entity)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_LICENSE_ACCEPT set ");
			                        
            strSql.Append(" REQUISITIONID = :REQUISITIONID , ");                                    
            strSql.Append(" REQUISITIONNAME = :REQUISITIONNAME , ");                                    
            strSql.Append(" ADDRESS = :ADDRESS , ");                                    
            strSql.Append(" TEL = :TEL , ");                                    
            strSql.Append(" PHONE = :PHONE , ");                                    
            strSql.Append(" EMAIL = :EMAIL , ");                                    
            strSql.Append(" POST = :POST , ");                                    
            strSql.Append(" REQUISITIONCONTENT = :REQUISITIONCONTENT , ");                                    
            strSql.Append(" DEPUTY = :DEPUTY , ");                                    
            strSql.Append(" MATERIALS = :MATERIALS , ");                                    
            strSql.Append(" MARK = :MARK , ");                                    
            strSql.Append(" CREATDATE = :CREATDATE , ");                                    
            strSql.Append(" AUDITOR = :AUDITOR , ");                                    
            strSql.Append(" AUDIT_STATE = :AUDIT_STATE , ");                                    
            strSql.Append(" FILE_PATH = :FILE_PATH , ");                                    
            strSql.Append(" AUDIT_DESC = :AUDIT_DESC , ");                                    
            strSql.Append(" AUDIT_REPLY = :AUDIT_REPLY  ");            			
			strSql.Append(" where  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":REQUISITIONID", OracleType.Number,4) ,            
                        new OracleParameter(":REQUISITIONNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":ADDRESS", OracleType.VarChar,50) ,            
                        new OracleParameter(":TEL", OracleType.VarChar,50) ,            
                        new OracleParameter(":PHONE", OracleType.VarChar,50) ,            
                        new OracleParameter(":EMAIL", OracleType.VarChar,50) ,            
                        new OracleParameter(":POST", OracleType.VarChar,20) ,            
                        new OracleParameter(":REQUISITIONCONTENT", OracleType.VarChar,200) ,            
                        new OracleParameter(":DEPUTY", OracleType.VarChar,20) ,            
                        new OracleParameter(":MATERIALS", OracleType.VarChar,20) ,            
                        new OracleParameter(":MARK", OracleType.VarChar,20) ,            
                        new OracleParameter(":CREATDATE", OracleType.DateTime) ,            
                        new OracleParameter(":AUDITOR", OracleType.VarChar,20) ,            
                        new OracleParameter(":AUDIT_STATE", OracleType.Number,4) ,            
                        new OracleParameter(":FILE_PATH", OracleType.VarChar,50) ,            
                        new OracleParameter(":AUDIT_DESC", OracleType.VarChar,200) ,            
                        new OracleParameter(":AUDIT_REPLY", OracleType.VarChar,200)             
              
            };
			            
            parameters[17].Value = entity.REQUISITIONID;
            parameters[18].Value = entity.REQUISITIONNAME;
            parameters[19].Value = entity.ADDRESS;
            parameters[20].Value = entity.TEL;
            parameters[21].Value = entity.PHONE;
            parameters[22].Value = entity.EMAIL;
            parameters[23].Value = entity.POST;
            parameters[24].Value = entity.REQUISITIONCONTENT;
            parameters[25].Value = entity.DEPUTY;
            parameters[26].Value = entity.MATERIALS;
            parameters[27].Value = entity.MARK;
            parameters[28].Value = entity.CREATDATE;
            parameters[29].Value = entity.AUDITOR;
            parameters[30].Value = entity.AUDIT_STATE;
            parameters[31].Value = entity.FILE_PATH;
            parameters[32].Value = entity.AUDIT_DESC;
            parameters[33].Value = entity.AUDIT_REPLY;
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
			strSql.Append("delete from BASE_LICENSE_ACCEPT ");
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
		public Entity.BASE_LICENSE_ACCEPT GetEntity()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select REQUISITIONID, REQUISITIONNAME, ADDRESS, TEL, PHONE, EMAIL, POST, REQUISITIONCONTENT, DEPUTY, MATERIALS, MARK, CREATDATE, AUDITOR, AUDIT_STATE, FILE_PATH, AUDIT_DESC, AUDIT_REPLY  ");			
			strSql.Append("  from BASE_LICENSE_ACCEPT ");
			strSql.Append(" where ");
						OracleParameter[] parameters = {
			};

			
			Entity.BASE_LICENSE_ACCEPT entity=new Entity.BASE_LICENSE_ACCEPT();
            DataTable dt = OracleHelper.Query(CommandType.Text,strSql.ToString(), parameters);
			
			if(dt.Rows.Count>0)
			{
												if(dt.Rows[0]["REQUISITIONID"].ToString()!="")
				{
					entity.REQUISITIONID=decimal.Parse(dt.Rows[0]["REQUISITIONID"].ToString());
				}
																																				entity.REQUISITIONNAME= dt.Rows[0]["REQUISITIONNAME"].ToString();
																																entity.ADDRESS= dt.Rows[0]["ADDRESS"].ToString();
																																entity.TEL= dt.Rows[0]["TEL"].ToString();
																																entity.PHONE= dt.Rows[0]["PHONE"].ToString();
																																entity.EMAIL= dt.Rows[0]["EMAIL"].ToString();
																																entity.POST= dt.Rows[0]["POST"].ToString();
																																entity.REQUISITIONCONTENT= dt.Rows[0]["REQUISITIONCONTENT"].ToString();
																																entity.DEPUTY= dt.Rows[0]["DEPUTY"].ToString();
																																entity.MATERIALS= dt.Rows[0]["MATERIALS"].ToString();
																																entity.MARK= dt.Rows[0]["MARK"].ToString();
																												if(dt.Rows[0]["CREATDATE"].ToString()!="")
				{
					entity.CREATDATE=DateTime.Parse(dt.Rows[0]["CREATDATE"].ToString());
				}
																																				entity.AUDITOR= dt.Rows[0]["AUDITOR"].ToString();
																												if(dt.Rows[0]["AUDIT_STATE"].ToString()!="")
				{
					entity.AUDIT_STATE=decimal.Parse(dt.Rows[0]["AUDIT_STATE"].ToString());
				}
																																				entity.FILE_PATH= dt.Rows[0]["FILE_PATH"].ToString();
																																entity.AUDIT_DESC= dt.Rows[0]["AUDIT_DESC"].ToString();
																																entity.AUDIT_REPLY= dt.Rows[0]["AUDIT_REPLY"].ToString();
																										
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
			strSql.Append(" FROM BASE_LICENSE_ACCEPT ");
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
			strSql.Append(" FROM BASE_LICENSE_ACCEPT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
		}

   
	}
}

