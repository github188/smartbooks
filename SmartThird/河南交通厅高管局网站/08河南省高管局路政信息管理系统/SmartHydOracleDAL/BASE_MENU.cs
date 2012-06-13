// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MENU.cs
// 功能描述:菜单信息表 -- 接口实现
//
// 创建标识：王 亚 2012-05-04
namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Data.OracleClient;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using IDAL;

    /// <summary>
    /// 菜单信息表 -- 接口实现
    /// </summary>
    public partial class BASE_MENU : IBASE_MENU {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        public bool Exists(decimal MENUID) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_MENU");
            strSql.Append(" where ");
            strSql.Append(" MENUID = :MENUID  ");
            OracleParameter[] parameters = {
					new OracleParameter(":MENUID", OracleType.Number,4)			};
            parameters[0].Value = MENUID;

            if (OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Entity.BASE_MENU entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_MENU(");
            strSql.Append("MENUID,MENUNAME,MENUINFO,MENUURL,ICON,PARENTID,STATUS");
            strSql.Append(") values (");
            strSql.Append(":MENUID,:MENUNAME,:MENUINFO,:MENUURL,:ICON,:PARENTID,:STATUS");
            strSql.Append(") ");

            OracleParameter[] parameters = {
			            new OracleParameter(":MENUID", OracleType.Number,4) ,            
                        new OracleParameter(":MENUNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":MENUINFO", OracleType.VarChar,200) ,            
                        new OracleParameter(":MENUURL", OracleType.VarChar,200) ,            
                        new OracleParameter(":ICON", OracleType.VarChar,50) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.MENUID;
            parameters[1].Value = entity.MENUNAME;
            parameters[2].Value = entity.MENUINFO;
            parameters[3].Value = entity.MENUURL;
            parameters[4].Value = entity.ICON;
            parameters[5].Value = entity.PARENTID;
            parameters[6].Value = entity.STATUS;
            OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.BASE_MENU entity) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_MENU set ");

            strSql.Append(" MENUID = :MENUID , ");
            strSql.Append(" MENUNAME = :MENUNAME , ");
            strSql.Append(" MENUINFO = :MENUINFO , ");
            strSql.Append(" MENUURL = :MENUURL , ");
            strSql.Append(" ICON = :ICON , ");
            strSql.Append(" PARENTID = :PARENTID , ");
            strSql.Append(" STATUS = :STATUS  ");
            strSql.Append(" where MENUID=:MENUID  ");

            OracleParameter[] parameters = {
			            new OracleParameter(":MENUID", OracleType.Number,4) ,            
                        new OracleParameter(":MENUNAME", OracleType.VarChar,50) ,            
                        new OracleParameter(":MENUINFO", OracleType.VarChar,200) ,            
                        new OracleParameter(":MENUURL", OracleType.VarChar,200) ,            
                        new OracleParameter(":ICON", OracleType.VarChar,50) ,            
                        new OracleParameter(":PARENTID", OracleType.Number,4) ,            
                        new OracleParameter(":STATUS", OracleType.Number,4)             
              
            };

            parameters[0].Value = entity.MENUID;
            parameters[1].Value = entity.MENUNAME;
            parameters[2].Value = entity.MENUINFO;
            parameters[3].Value = entity.MENUURL;
            parameters[4].Value = entity.ICON;
            parameters[5].Value = entity.PARENTID;
            parameters[6].Value = entity.STATUS;
            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal MENUID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_MENU ");
            strSql.Append(" where MENUID=:MENUID ");
            OracleParameter[] parameters = {
					new OracleParameter(":MENUID", OracleType.Number,4)			};
            parameters[0].Value = MENUID;


            int rows = OracleHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0) {
                return true;
            } else {
                return false;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.BASE_MENU GetEntity(decimal MENUID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MENUID, MENUNAME, MENUINFO, MENUURL, ICON, PARENTID, STATUS  ");
            strSql.Append("  from BASE_MENU ");
            strSql.Append(" where MENUID=:MENUID ");
            OracleParameter[] parameters = {
					new OracleParameter(":MENUID", OracleType.Number,4)			};
            parameters[0].Value = MENUID;


            Entity.BASE_MENU entity = new Entity.BASE_MENU();
            DataTable dt = OracleHelper.Query(CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["MENUID"].ToString() != "") {
                    entity.MENUID = decimal.Parse(dt.Rows[0]["MENUID"].ToString());
                }
                entity.MENUNAME = dt.Rows[0]["MENUNAME"].ToString();
                entity.MENUINFO = dt.Rows[0]["MENUINFO"].ToString();
                entity.MENUURL = dt.Rows[0]["MENUURL"].ToString();
                entity.ICON = dt.Rows[0]["ICON"].ToString();
                if (dt.Rows[0]["PARENTID"].ToString() != "") {
                    entity.PARENTID = decimal.Parse(dt.Rows[0]["PARENTID"].ToString());
                }
                if (dt.Rows[0]["STATUS"].ToString() != "") {
                    entity.STATUS = decimal.Parse(dt.Rows[0]["STATUS"].ToString());
                }

                return entity;
            } else {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BASE_MENU ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return OracleHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM BASE_MENU ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return OracleHelper.Query(strSql.ToString());
        }



        /// <summary>
        /// comment:    为菜单JSON数据提供数据源
        /// date:       2012-06-13
        /// author:     hyw
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public DataTable GetMenuList() {
            string strSql = "SELECT MENUID,PARENTID,MENUNAME,ICONCLS,ISLEAF FROM BASE_MENU  ORDER BY SEQUENCE";

            return OracleHelper.Query(strSql).Tables[0];
        }
    }
}

