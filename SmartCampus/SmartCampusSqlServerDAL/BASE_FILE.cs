
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_FILE : IBASE_FILE
    {
        #region IBASE_FILE 成员

        public bool Exists(int fileid)
        {
            throw new NotImplementedException();
        }

        public void Add(SmartCampus.Entity.BASE_FILE entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SmartCampus.Entity.BASE_FILE entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int fileid)
        {
            throw new NotImplementedException();
        }

        public SmartCampus.Entity.BASE_FILE GetEntity(int fileid)
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
