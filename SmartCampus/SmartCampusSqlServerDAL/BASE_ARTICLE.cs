
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using SmartCampus.IDAL;
    using SmartCampus.DBUtility;

    public class BASE_ARTICLE : IBASE_ARTICLE
    {
        #region IBASE_ARTICLE 成员

        public bool Exists(int articleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_ARTICLE");
            strSql.Append(" where ");
            strSql.Append(" ARTICLEID = @ARTICLEID  ");

            SqlParameter[] parameters = { new SqlParameter("@ARTICLEID", SqlDbType.Int, 4) };
            parameters[0].Value = articleid;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        public void Add(SmartCampus.Entity.BASE_ARTICLE entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_ARTICLE entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int articleid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_ARTICLE GetEntity(int articleid)
        {
            throw new NotImplementedException();
        }

        public DataSet GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
